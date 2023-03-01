using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Drawing.Printing;

namespace FrmProcesos
{
    public partial class frmRecepcionMPB1 : Form
    {
        public frmRecepcionMPB1()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB1_Load(object sender, EventArgs e)
        {
            cbb_seleccionar_impresora.Items.Clear();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                try
                {
                    cbb_seleccionar_impresora.Items.Add(strPrinter);
                }
                catch
                {

                }

            }

            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;

            dtp_fecha1_1.Value = dFecha;
            dtp_fecha2_1.Value = DateTime.Today;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "FldValue";
            cbb_procesos.DisplayMember = "Descr";

            carga_grilla1();


        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1.Value;

                string cfecha1, cfecha2, cWhsCode;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_entradas_semielaborados(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry, nNumGuia, nLinea;
                int nDocEntry_Calidad;

                string cFechaCreacion, cItemCode;
                string cProveedor, cInsumo, cNumOC;
                string cLote, cLoteProveedor, cStatusCalidad;
                string cEstado_RegInspeccion; 

                double nCant_Pendiente;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nNumGuia = int.Parse(dTable.Rows[i]["FolioNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;
                    }

                    try
                    {
                        nLinea = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                    }
                    catch
                    {
                        nLinea = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaCreacion = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        cProveedor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProveedor = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cInsumo = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cInsumo = "";
                    }

                    try
                    {
                        nCant_Pendiente = Convert.ToDouble(Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString()));
                    }
                    catch
                    {
                        nCant_Pendiente = 0;
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cLoteProveedor = dTable.Rows[i]["U_FolioPallet"].ToString();
                    }
                    catch
                    {
                        cLoteProveedor = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        nDocEntry_Calidad = Convert.ToInt32(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Calidad = 0;
                    }

                    try
                    {
                        cEstado_RegInspeccion = dTable.Rows[i]["Estado_RegInspeccion"].ToString();
                    }
                    catch
                    {
                        cEstado_RegInspeccion = "";
                    }

                    ////////////////////////////////////////////
                    ////////////////////////////////////////////

                    cStatusCalidad = "Inspección no Registrada";

                    //if (nCantidadRegistros > 0)
                    if (cEstado_RegInspeccion == "N")
                    {
                        cStatusCalidad = "Inspección en Proceso";
                    }

                    //if (nCantidadRechazada > 0)
                    if (cEstado_RegInspeccion == "R")
                    {
                        cStatusCalidad = "Inspección Finalizada - Rechazado";
                    }

                    //if (nCantidadAprobada > 0)
                    if (cEstado_RegInspeccion == "A")
                    {
                        cStatusCalidad = "Inspección Finalizada - Aprobado";
                    }

                    //if (nCantidadReparos > 0)
                    if (cEstado_RegInspeccion == "Q")
                    {
                        cStatusCalidad = "Inspección Finalizada - Aprob. con Reparos";
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nLinea.ToString("N");
                    grilla[2] = nNumGuia.ToString();
                    grilla[3] = cFechaCreacion;
                    grilla[4] = cProveedor;
                    grilla[5] = cNumOC;
                    grilla[6] = cLote;
                    grilla[7] = cLoteProveedor;
                    grilla[8] = cItemCode;
                    grilla[9] = cInsumo;
                    grilla[10] = nCant_Pendiente.ToString("N");
                    grilla[11] = nDocEntry.ToString();
                    grilla[12] = cWhsCode;
                    grilla[13] = nDocEntry_Calidad.ToString();
                    grilla[14] = cStatusCalidad;

                    Grid1.Rows.Add(grilla);

                    if (cStatusCalidad == "Inspección no Registrada")
                    {
                        Grid1[14, i].Style.BackColor = Color.Empty;
                    }

                    if (cStatusCalidad == "Inspección en Proceso")
                    {
                        Grid1[14, i].Style.BackColor = Color.Yellow;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                    {
                        Grid1[14, i].Style.BackColor = Color.Green;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                    {
                        Grid1[14, i].Style.BackColor = Color.Red;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Aprob. con Reparos")
                    {
                        Grid1[14, i].Style.BackColor = Color.Orange;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Recepción de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nNumOF, nNumEtiquetas;

            double nCantidad;

            string cNumGuia, cLote, cLoteProveedor;
            string cProveedor, cInsumo, cItemCode;
            string cOrdenCompra, cFechaRecepcion, cItemName;
            string cCardCode, cCardName, cComuna;
            string cCuidad, cTemporada;
            string cCSP, cComunaRes, cCuidadRes;
            string cNombreRes, cEspecie, cItmsGrpNam;

            DateTime dFechaEtiqueta;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                if (Grid1.Rows[x].Selected == true)
                {
                    fila = x;

                    try
                    {
                        cNumGuia = Grid1[2, fila].Value.ToString();

                    }
                    catch
                    {
                        cNumGuia = "0";

                    }

                    try
                    {
                        dFechaEtiqueta = Convert.ToDateTime(Grid1[3, fila].Value.ToString());

                    }
                    catch
                    {
                        dFechaEtiqueta = Convert.ToDateTime("01/01/1900");

                    }

                    try
                    {
                        cLote = Grid1[6, fila].Value.ToString();

                    }
                    catch
                    {
                        cLote = "0";

                    }

                    if (cLote == "")
                    {
                        cLote = "0";
                    }

                    try
                    {
                        cLoteProveedor = Grid1[7, fila].Value.ToString();

                    }
                    catch
                    {
                        cLoteProveedor = "0";

                    }

                    if (cNumGuia == "0")
                    {
                        MessageBox.Show("Debe seleccionar una guía valida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (cLote == "0")
                    {
                        MessageBox.Show("Debe seleccionar una guía valida (Falta número de lote), opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    try
                    {
                        nCantidad = double.Parse(Grid1[10, fila].Value.ToString());
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    nCantidad = 25;

                    try
                    {
                        cProveedor = Grid1[4, fila].Value.ToString();

                    }
                    catch
                    {
                        cProveedor = "";

                    }

                    try
                    {
                        cInsumo = Grid1[9, fila].Value.ToString();

                    }
                    catch
                    {
                        cInsumo = "";

                    }

                    try
                    {
                        cItemCode = Grid1[8, fila].Value.ToString();

                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    try
                    {
                        cItemName = Grid1[9, fila].Value.ToString();

                    }
                    catch
                    {
                        cItemName = "";

                    }

                    try
                    {
                        cOrdenCompra = Grid1[5, fila].Value.ToString();

                    }
                    catch
                    {
                        cOrdenCompra = "";

                    }

                    try
                    {
                        cFechaRecepcion = Grid1[3, fila].Value.ToString();

                    }
                    catch
                    {
                        cFechaRecepcion = "";

                    }

                    ////////////////////////////////////////////////////////////

                    cEspecie = "";
                    cItmsGrpNam = "";
                    nNumOF = 0;
                    nNumEtiquetas = 1;

                    cCSP = "114761";
                    cComunaRes = "PAINE";
                    cCuidadRes = "MAIPO";
                    cNombreRes = "Res 020290 de 02/04/2013 S. Salud RM";
                    cTemporada = "2019";

                    cCardName = "";
                    cComuna = "";
                    cCuidad = "";
                    cCardCode = "";

                    string cNuevo_ItemName;

                    cNuevo_ItemName = cItemName.Replace("ALMENDRA PROPIA", "ALMENDRA SIN CASCARA");
                    cNuevo_ItemName = cNuevo_ItemName.Replace("NUEZ PROPIA PT", "Nuez sin cascara");

                    if (cItemCode == "FP.ALM.PT.SMA1.XXX.X.XXX-XXX.RAY.C.0010K.01")
                    {
                        cNuevo_ItemName = "ALMENDRA SIN CASCARA PT RAYADA";

                    }

                    if (cItemCode == "FP.ALM.PT.SMA1.XXX.X.XXX-XXX.RAY.S.1000K.01")
                    {
                        cNuevo_ItemName = "ALMENDRA SIN CASCARA PT RAYADA";

                    }

                    if (cItemCode.Substring(0, 2).ToString() == "FP")
                    {
                        cCardName = "AGRIVIAL";
                        cComuna = "PIRQUE";
                        cCuidad = "CORDILLERA";
                        //""

                        if ((nNumOF == 6110) || (nNumOF == 6113))
                        {
                            cCardName = "";

                        }

                    }

                    if (cEspecie == "Nuez" && cItmsGrpNam == "NSC Man PT")
                    {
                        ////////////////////////////////
                        // Eso lo solicito Roberto Galaz 2018-06-22
                        // Esto es solo para Limache 

                        cCSP = "120048";
                        cComunaRes = "ISLA DE MAIPO";
                        cCuidadRes = "TALAGANTE";
                        cNombreRes = "Res 622 de 09/12/2004 S. Salud V REGION";

                    }

                    cCSP = "120048";
                    cComunaRes = "ISLA DE MAIPO";
                    cCuidadRes = "TALAGANTE";
                    cNombreRes = "Res 622 de 09/12/2004 S. Salud V REGION";
                    cNombreRes = "";

                    for (int i = 0; i <= 40 - 1; i++)
                    {
                        etiqueta_adhesiva(cLote, cNuevo_ItemName, cCardCode, cCardName, cComuna, cCuidad, cTemporada, i + 1, Convert.ToInt32(nNumEtiquetas), nCantidad, dFechaEtiqueta, cCSP, cComunaRes, cCuidadRes, cNombreRes);
                    }

                }

            }

        }

        private void etiqueta_adhesiva(string cLote, string cItemName, string cCardCode, string cCardName, string cComuna, string cCuidad, string cTemporada, int nFolio1, int nFolio2, double nPesoUnit, DateTime dFechaCreacion, string c_CSP, string cComunaRes, string cProvinciaRes, string cNombreRes)
        {

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                Font Font_Titulo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 8, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                if (cCardName != "")
                {
                    e1.Graphics.DrawString("Productor: " + cCardName, Font_Cuerpo, br, 5, 20);
                }

                e1.Graphics.DrawString("CSG: 153437", Font_Cuerpo, br, 280, 20);

                e1.Graphics.DrawString("Comuna: " + cComuna, Font_Cuerpo, br, 5, 35);
                e1.Graphics.DrawString("Provincia: " + cCuidad, Font_Cuerpo, br, 150, 35);

                e1.Graphics.DrawString("Cosecha: " + cTemporada, Font_Cuerpo, br, 5, 50);
                e1.Graphics.DrawString("Fecha de Elaboración: " + dFechaCreacion.ToString("dd/MM/yyyy"), Font_Cuerpo, br, 150, 50);

                e1.Graphics.DrawString("Peso Neto: " + nPesoUnit.ToString() + " Kgs", Font_Cuerpo, br, 5, 65);
                e1.Graphics.DrawString("Origen: " + "CHILE", Font_Cuerpo, br, 150, 65);

                e1.Graphics.DrawString(cItemName, Font_Cuerpo, br, 5, 80);

                e1.Graphics.DrawString("Envasado CSP " + c_CSP, Font_Cuerpo, br, 5, 95);
                //e1.Graphics.DrawString("*" + "AP2325" + "*", Font_CodigoBarra, br, 150, 95);

                e1.Graphics.DrawString("Comuna: " + cComunaRes, Font_Cuerpo, br, 5, 120);
                e1.Graphics.DrawString("Provincia: " + cProvinciaRes, Font_Cuerpo, br, 150, 120);

                e1.Graphics.DrawString(cNombreRes, Font_Cuerpo, br, 5, 135);
                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 150, 150);
                //e1.Graphics.DrawString(" " + nFolio1.ToString() + " de " + nFolio2.ToString() + " ", Font_Cuerpo, br, 280, 150);

                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 160, 180);

            };

            try
            {
                p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 50, 0, 50);
                //p.PrinterSettings.Copies = 20;               

                if (p.PrinterSettings.IsValid)
                {

                    for (int i = 0; i <= nFolio2 - 1; i++)
                    {


                    }

                    //p.PrintPage

                    p.Print();

                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad, nCantidadRegistros;

            string cItemCode;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            nCantidadRegistros = 0;
            cItemCode = "";

            try
            {
                id_Recepcion = int.Parse(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                id_Recepcion = 0;
            }


            try
            {
                id_LineNum = int.Parse(Grid1[1, fila].Value.ToString());
            }
            catch
            {
                id_LineNum = 0;
            }

            id_NumOF = 0;
            nLineOF = 0;

            try
            {
                nLote = int.Parse(Grid1[6, fila].Value.ToString());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                nIdCalidad = int.Parse(Grid1[13, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            if (nIdCalidad == 0)
            {
                if (cbb_procesos.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un proceso válido, opción Cancelada", "Recepción de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cbb_procesos.Text == "")
                {
                    MessageBox.Show("Debe seleccionar un proceso válido, opción Cancelada", "Recepción de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            try
            {
                nCantidadRegistros = int.Parse(Grid1[10, fila].Value.ToString());
            }
            catch
            {
                nCantidadRegistros = 0;
            }

            try
            {
                cItemCode = Grid1[8, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "20";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                VariablesGlobales.glb_CodeProceso = cbb_procesos.Text;

                //VariablesGlobales.glb_id_calidad = 0;

                if (VariablesGlobales.glb_id_calidad == 0)
                {
                    string cDestino;

                    cDestino = "";

                    clsCalidad objproducto22 = new clsCalidad();
                    objproducto22.cls_Consulta_Registro_Inspeccion_x_orden(id_NumOF);

                    DataTable dTable22 = new DataTable();
                    dTable22 = objproducto22.cResultado;

                    try
                    {
                        cDestino = dTable22.Rows[0]["Destino"].ToString();
                    }
                    catch
                    {
                        cDestino = "Proceso Anterior";
                    }

                    if (cDestino == "Proceso Anterior")
                    {
                        frmCalidadPP4 fv4 = new frmCalidadPP4();
                        DialogResult res4 = fv4.ShowDialog();

                    }
                    else
                    {
                        frmCalidadPPA6 fv0 = new frmCalidadPPA6();
                        DialogResult res0 = fv0.ShowDialog();

                    }

                }
                else
                {
                    string cModeloFrm;

                    cModeloFrm = "";

                    clsCalidad objproducto = new clsCalidad();
                    objproducto.cls_Consulta_Registro_Inspeccion(nIdCalidad);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        cModeloFrm = dTable.Rows[0]["ModeloFrm"].ToString();
                    }
                    catch
                    {
                        cModeloFrm = "";
                    }

                    if (cModeloFrm == "OLD")
                    {
                        frmCalidadPP4 fv1 = new frmCalidadPP4();
                        DialogResult res1 = fv1.ShowDialog();

                    }
                    else
                    {
                        frmCalidadPPA6 fv2 = new frmCalidadPPA6();
                        DialogResult res2 = fv2.ShowDialog();

                    }

                }

            }

            //carga_grilla1();

        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {
            int fila, nDocEntry_Calidad;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fila = -1;
            }

            nDocEntry_Calidad = 0;

            if (fila >= 0)
            {
                try
                {
                    nDocEntry_Calidad = Convert.ToInt32(Grid1[13, fila].Value.ToString());
                }
                catch
                {
                    nDocEntry_Calidad = 0;
                }

                if (nDocEntry_Calidad == 0)
                {
                    cbb_procesos.Enabled = true;
                    cbb_procesos.Text = "";
                }
                else
                {
                    cbb_procesos.Enabled = false;
                }

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }

}
