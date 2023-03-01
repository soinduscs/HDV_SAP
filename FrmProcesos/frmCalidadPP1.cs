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


namespace FrmProcesos
{
    public partial class frmCalidadPP1 : Form
    {
        public frmCalidadPP1()
        {
            InitializeComponent();
        }

        private void frmCalidadPP1_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Today;

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;

            dtp_fecha4.Value = dFecha;
            dtp_fecha5.Value = DateTime.Today;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "FldValue";
            cbb_procesos.DisplayMember = "Descr";

            comboBox1.DataSource = objproducto.cResultado;
            comboBox1.ValueMember = "FldValue";
            comboBox1.DisplayMember = "Descr";

            btn_registros_pendientes_Click(sender, e);

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {

            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "", "");

            t_ultimo_boton.Text = "F1";

        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {

            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("F2", cfecha1, cfecha2, "");

            t_ultimo_boton.Text = "F2";

        }

        private void btn_consultar3_Click(object sender, EventArgs e)
        {

            int num_guia;
            string c_num_guia;

            num_guia = 0;
            c_num_guia = "";

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            c_num_guia = num_guia.ToString();
            
            carga_grilla("N", c_num_guia, "","");

            t_ultimo_boton.Text = "N";

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            t_cardcode.Clear();
            t_cardname.Clear();

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

                t_num_guia.Focus();

            }

        }

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

            string c_ItemCode;

            c_ItemCode = "";

            try
            {
                c_ItemCode = t_cardcode.Text;
            }
            catch
            {
                c_ItemCode = "";
            }

            carga_grilla("P", c_ItemCode, "","");

            t_ultimo_boton.Text = "P";

        }


        private void carga_grilla(string accion, string dato1, string dato2, string anhoactual)
        {
            string cProceso;

            if (accion=="X")
            {
                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un proceso válido, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    cProceso = comboBox1.SelectedValue.ToString();
                }
                catch
                {
                    cProceso = "";
                }

            }
            else
            {
                if (cbb_procesos.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un proceso válido, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    cProceso = cbb_procesos.SelectedValue.ToString();
                }
                catch
                {
                    cProceso = "";
                }

            }

            if (accion == "N")
            {
                cProceso = "%";
            }

            if (accion == "F2")
            {
                cProceso = "%";
            }

            if (accion == "P")
            {
                cProceso = "%";
            }

            if (accion == "R2")
            {
                cProceso = "%";
            }

            if (accion == "L")
            {
                cProceso = "%";
            }

            if (cProceso=="")
            {
                MessageBox.Show("Debe seleccionar un proceso válido, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {

                string cDocEntry, cLineID, cNumOF;
                string cLineOF, cCardName, cAlmacen;
                string cItemName, cStatusCalidad, cItemCode;
                string cLote, cMuestra, cCalibre;
                string cColor, cEstado_RegInspeccion;

                DateTime dFecha;

                int nCantItems, nCantidadRegistros, nCantidadAprobada;
                int nCantidadRechazada, nIdCalidad, nFila;
                int nCantidadReparos;

                double nQuantity;

                //int nCantItems, nCantRegistros, nCantRegistroAprobados;
                //int nCantRegistroRechazados, nIdCalidad;

                clsCalidad objproducto = new clsCalidad();

                if (accion != "R2")
                {
                    objproducto.cls_Consulta_Recepcion_PP_Calidad(accion, cProceso, dato1, dato2, anhoactual);
                }
                else
                {
                    objproducto.cls_Consulta_Recepcion_PP_Calidad_R(accion, cProceso, dato1, dato2);

                }

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                nFila = 0;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["DocEntry"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cLineID = dTable.Rows[i]["LineNum"].ToString();
                    }
                    catch
                    {
                        cLineID = "";

                    }

                    try
                    {
                        cNumOF = dTable.Rows[i]["BaseEntry"].ToString();

                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                        cLineOF = dTable.Rows[i]["BaseLine"].ToString();
                    }
                    catch
                    {
                        cLineOF = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
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
                        cItemName = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
                    }

                    try
                    {
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nCantItems = 0;
                    }

                    try
                    {
                        cAlmacen = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cAlmacen = "";
                    }

                    try
                    {
                        cLote = dTable.Rows[i]["MdAbsEntry"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCalibre = dTable.Rows[i]["U_Calibre"].ToString();
                    }
                    catch
                    {
                        cCalibre = "";
                    }

                    try
                    {
                        cColor = dTable.Rows[i]["U_HDV_COLOR"].ToString();
                    }
                    catch
                    {
                        cColor = "";
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    cEstado_RegInspeccion = "";

                    try
                    {
                        cEstado_RegInspeccion = dTable.Rows[i]["U_Estado"].ToString();
                    }
                    catch
                    {
                        cEstado_RegInspeccion = "";
                    }

                    nCantidadRegistros = 0;
                    nCantidadAprobada = 0;
                    nCantidadRechazada = 0;
                    nCantidadReparos = 0;

                    try
                    {
                        nCantidadRegistros = int.Parse(dTable.Rows[i]["Cant_Registros"].ToString());
                    }
                    catch
                    {
                        nCantidadRegistros = 0;
                    }

                    try
                    {
                        nCantidadAprobada = int.Parse(dTable.Rows[i]["Cant_Aprobado"].ToString());
                    }
                    catch
                    {
                        nCantidadAprobada = 0;
                    }

                    try
                    {
                        nCantidadRechazada = int.Parse(dTable.Rows[i]["Cant_Rechazado"].ToString());
                    }
                    catch
                    {
                        nCantidadRechazada = 0;
                    }

                    try
                    {
                        nCantidadReparos = int.Parse(dTable.Rows[i]["Cant_Reparos"].ToString());
                    }
                    catch
                    {
                        nCantidadReparos = 0;
                    }

                    try
                    {
                        nIdCalidad = int.Parse(dTable.Rows[i]["id_Calidad"].ToString());
                    }
                    catch
                    {
                        nIdCalidad = 0;
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

                    grilla[0] = cDocEntry;
                    grilla[1] = cLineID;
                    grilla[2] = cNumOF;
                    grilla[3] = cLineOF;
                    grilla[4] = cLote;
                    grilla[5] = dFecha.ToString("dd/MM/yyyy");
                    grilla[6] = cCardName;
                    grilla[7] = cItemCode;
                    grilla[8] = cItemName;

                    grilla[9] = cCalibre;
                    grilla[10] = cColor;
                    grilla[11] = nQuantity.ToString("N2");


                    grilla[12] = cAlmacen;
                    grilla[13] = cStatusCalidad;
                    grilla[14] = nCantidadRegistros.ToString();
                    grilla[15] = nIdCalidad.ToString();

                    //grilla[11] = cItemCode;

                    cMuestra = "S";

                    if (accion == "X")
                    {
                        cMuestra = "N";

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            cMuestra = "S";
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            cMuestra = "S";
                        }

                    }

                    if (cMuestra == "S")
                    {
                        Grid1.Rows.Add(grilla);

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            Grid1[13, nFila].Style.BackColor = Color.Empty;
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            Grid1[13, nFila].Style.BackColor = Color.Yellow;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                        {
                            Grid1[13, nFila].Style.BackColor = Color.Green;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                        {
                            Grid1[13, nFila].Style.BackColor = Color.Red;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Aprob. con Reparos")
                        {
                            Grid1[13, nFila].Style.BackColor = Color.Orange;
                        }

                        nFila += 1;

                    }

                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

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

            try
            {
                id_NumOF = int.Parse(Grid1[2, fila].Value.ToString());
            }
            catch
            {
                id_NumOF = 0;
            }

            try
            {
                nLineOF = int.Parse(Grid1[3, fila].Value.ToString());
            }
            catch
            {
                nLineOF = 0;
            }

            try
            {
                nLote = int.Parse(Grid1[4, fila].Value.ToString());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                nIdCalidad = int.Parse(Grid1[15, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                nCantidadRegistros = int.Parse(Grid1[14, fila].Value.ToString());
            }
            catch
            {
                nCantidadRegistros = 0;
            }

            try
            {
                cItemCode = Grid1[7, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

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

                    if (cModeloFrm == "NEW")
                    {
                        frmCalidadPPA6 fv2 = new frmCalidadPPA6();
                        DialogResult res2 = fv2.ShowDialog();

                    }

                    if (cModeloFrm == "")
                    {
                        MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Registro de calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

                if (t_ultimo_boton.Text == "F1")
                {
                    btn_consultar1_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "F2")
                {
                    btn_consultar2_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "X")
                {
                    btn_registros_pendientes_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "L")
                {
                    btn_consultar6_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "N")
                {
                    btn_consultar3_Click(sender, e);

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nEntMercaderia;

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

            try
            {
                nEntMercaderia = int.Parse(Grid1[0, fila].Value.ToString());

            }
            catch
            {
                nEntMercaderia = 0;

            }

            if (nEntMercaderia == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nEntMercaderia;

            frmOrdenFabricacionTR1_A f2 = new frmOrdenFabricacionTR1_A();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {

            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            fecha = "20171101";

            string c_anhoactual;

            c_anhoactual = "S";

            if (chk_anhoactual.Checked == true)
                c_anhoactual = "S";
            else
                c_anhoactual = "N";

            carga_grilla("X", fecha, "",c_anhoactual);

            t_ultimo_boton.Text = "X";

        }

        private void btn_consultar5_Click(object sender, EventArgs e)
        {

            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha4.Value;
            fecha2 = dtp_fecha5.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("R2", cfecha1, cfecha2,"");

            t_ultimo_boton.Text = "R2";

        }

        private void btn_consultar6_Click(object sender, EventArgs e)
        {
            int num_lote;
            string c_num_lote;

            num_lote = 0;
            c_num_lote = "";

            try
            {
                num_lote = Convert.ToInt32(t_num_lote.Text);
            }
            catch
            {
                num_lote = 0;
            }

            c_num_lote = num_lote.ToString();

            carga_grilla("L", c_num_lote, "","");

            t_ultimo_boton.Text = "L";

        }
    }

}
