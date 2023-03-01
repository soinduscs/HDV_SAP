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
    public partial class frmReporteProduccion : Form
    {
        public frmReporteProduccion()
        {
            InitializeComponent();
        }

        private void frmReporteProduccion_Load(object sender, EventArgs e)
        {
            dtp_nueva_fecha.Enabled = false;
            cbb_seleccionar_impresora.Items.Clear();
            dtp_nueva_fecha.Value = DateTime.Today;
            T_Proceso.Clear();

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

            int nDocEntry;
            double nNumEtiquetas;
            string cFamilia, cProceso, cEstado;
            string cImpresion, cObjeto, cLote;

            try
            {
                nDocEntry = VariablesGlobales.glb_DocEntry;
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cObjeto = VariablesGlobales.glb_Object;

            }
            catch
            {
                cObjeto = "";

            }

            try
            {
                cLote = VariablesGlobales.glb_Lote.ToString();
            }
            catch
            {
                cLote = "";
            }

            if (cObjeto == "")
                cObjeto = "59";

            t_docentry.Text = nDocEntry.ToString();
            t_object.Text = cObjeto;
            t_lote.Text = cLote; 

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Datos_Entrada_x_id(nDocEntry, cObjeto, cLote);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cFamilia = dTable.Rows[0]["U_Familia"].ToString();
            }
            catch
            {
                cFamilia = "";
            }

            try
            {
                cProceso = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                cProceso = "";
            }

            T_Proceso.Text = cProceso;

            try
            {
                cEstado = dTable.Rows[0]["CodEstado"].ToString();
            }
            catch
            {
                cEstado = "";
            }

            try
            {
                cObjeto = dTable.Rows[0]["ObjType"].ToString(); // 

            }
            catch
            {
                cObjeto = "";

            }

            if (VariablesGlobales.glb_Object == null )
            {
                VariablesGlobales.glb_Object = cObjeto;

            }

            cImpresion = "";

            nNumEtiquetas = 1;

            if (cProceso != "Desp & Secado")
            {
                try
                {
                    nNumEtiquetas = double.Parse(dTable.Rows[0]["Quantity"].ToString());
                }
                catch
                {
                    nNumEtiquetas = 1;
                }

            }
            else
            {
                try
                {
                    nNumEtiquetas = double.Parse(dTable.Rows[0]["Cant_Bins"].ToString());
                }
                catch
                {
                    nNumEtiquetas = 1;
                }

            }

            cbb_cantidad_etiquetas.Items.Clear();
            t_total_bins.Text = nNumEtiquetas.ToString();

            if (nNumEtiquetas > 0)
            {
                for (int i = 0; i <= nNumEtiquetas - 1; i++)
                {
                    cbb_cantidad_etiquetas.Items.Add((i + 1).ToString());

                }

                try
                {
                    cbb_cantidad_etiquetas.SelectedIndex = Convert.ToInt32(nNumEtiquetas) - 1;

                }
                catch
                {

                }

            }

            /////////////////////////////////////////
            // Si es producto terminado se salta!
            // 

            if ((cFamilia != "Producto Terminado") && (cProceso != "Desp & Secado"))
            {

                // (cProceso == "")

                ////////////////////////////////////////////////////////
                // Reporte con logo de triangulo 
                // Seleccionado 

                if ((cProceso == "Selección Almendras") || (cProceso == "Selección Nueces") || (cProceso == "Selección Nueces M"))
                {

                    if (cEstado == "A")
                    {
                        //////////////////////////////////
                        // Aprobado

                        frmOrdenFabricacionTR1_A f2 = new frmOrdenFabricacionTR1_A();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "R") || (cEstado == "N") || (cEstado == ""))
                    {
                        //////////////////////////////////
                        // Rechazado

                        frmOrdenFabricacionTR1_R f2 = new frmOrdenFabricacionTR1_R();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "Q") || (cEstado == ""))
                    {
                        //////////////////////////////////
                        // Aprobado con Reparos

                        frmOrdenFabricacionTR1_AR f2 = new frmOrdenFabricacionTR1_AR();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                }

                ////////////////////////////////////////////////////////
                // Reporte con logo de cuadrado blanco 
                // Sorter

                if ((cProceso == "Sorter 1") || (cProceso == "Sorter 2"))
                {

                    if (cEstado == "A")
                    {
                        //////////////////////////////////
                        // Aprobado

                        frmOrdenFabricacionTR4_A f2 = new frmOrdenFabricacionTR4_A();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "R") || (cEstado == "N"))
                    {
                        //////////////////////////////////
                        // Rechazado

                        frmOrdenFabricacionTR4_R f2 = new frmOrdenFabricacionTR4_R();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "Q") || (cEstado == ""))
                    {
                        //////////////////////////////////
                        // Aprobado con Reparos

                        frmOrdenFabricacionTR4_AR f2 = new frmOrdenFabricacionTR4_AR();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                }

                ////////////////////////////////////////////////////////
                // Reporte con logo de cuadrado blanco / negro
                // fuera de color

                if ((cProceso == "._."))
                {
                    frmOrdenFabricacionTR5 f2 = new frmOrdenFabricacionTR5();
                    DialogResult res = f2.ShowDialog();
                    cImpresion = "Ok";

                }

                ////////////////////////////////////////////////////////
                // Reporte con logo de cuadrado negro
                // rayadas y partidas

                if ((cProceso == "._."))
                {
                    frmOrdenFabricacionTR6 f2 = new frmOrdenFabricacionTR6();
                    DialogResult res = f2.ShowDialog();
                    cImpresion = "Ok";

                }

                ////////////////////////////////////////////////////////
                // Reporte con logo de cuadrado negro
                // cracker

                if ((cProceso == "Cracker Nueces") || (cProceso == "Prelimpia & Cracker"))
                {

                    if (cProceso == "Prelimpia & Cracker")
                    {

                        frmOrdenFabricacionTRA3 f2_SA = new frmOrdenFabricacionTRA3();
                        DialogResult res_SA = f2_SA.ShowDialog();
                        cImpresion = "Ok";

                    }
                    else
                    {

                        if (cEstado == "A")
                        {
                            //////////////////////////////////
                            // Aprobado

                            frmOrdenFabricacionTR7_A f2 = new frmOrdenFabricacionTR7_A();
                            DialogResult res = f2.ShowDialog();
                            cImpresion = "Ok";

                            //frmOrdenFabricacionTR7_A1 f2 = new frmOrdenFabricacionTR7_A1();
                            //DialogResult res = f2.ShowDialog();

                        }

                        if ((cEstado == "R") || (cEstado == "N"))
                        {
                            //////////////////////////////////
                            // Rechazado

                            frmOrdenFabricacionTR7_R f2 = new frmOrdenFabricacionTR7_R();
                            DialogResult res = f2.ShowDialog();
                            cImpresion = "Ok";

                        }

                        if ((cEstado == "Q") || (cEstado == ""))
                        {
                            //////////////////////////////////
                            // Aprobado con Reparos

                            frmOrdenFabricacionTR7_AR f2 = new frmOrdenFabricacionTR7_AR();
                            DialogResult res = f2.ShowDialog();
                            cImpresion = "Ok";

                        }

                    }

                }

                ////////////////////////////////////////////////////////
                // Reporte sin logo
                // todo el resto ****

                if ((cProceso == "NCC L1") || (cProceso == "NCC L2") || (cProceso == "Partidura Manual") || (cProceso == "Calibrado Ciruelas") || (cProceso == "PT Sin Carozo"))
                {

                    frmOrdenFabricacionTR8_A f2 = new frmOrdenFabricacionTR8_A();
                    DialogResult res = f2.ShowDialog();
                    cImpresion = "Ok";

                }

                if ((cProceso == "PT Con Carozo") || (cProceso == "PT Condición Natural") || (cProceso == "N / A") || (cProceso == "Blanqueado") || (cProceso == "Blanqueado + Calibrado"))
                {

                    if (cEstado == "A")
                    {
                        //////////////////////////////////
                        // Aprobado

                        frmOrdenFabricacionTR8_A f2 = new frmOrdenFabricacionTR8_A();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "R") || (cEstado == "N"))
                    {
                        //////////////////////////////////
                        // Rechazado

                        frmOrdenFabricacionTR8_R f2 = new frmOrdenFabricacionTR8_R();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "Q") || (cEstado == ""))
                    {
                        //////////////////////////////////
                        // Aprobado con Reparos

                        frmOrdenFabricacionTR8_AR f2 = new frmOrdenFabricacionTR8_AR();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                }

                if ((cProceso == "Lavado") || (cProceso == "Lavado + Calibrado") || (cProceso == "Calibrado") || (cProceso == "Envasado Almendras"))
                {

                    if (cEstado == "A")
                    {
                        //////////////////////////////////
                        // Aprobado

                        frmOrdenFabricacionTR8_A f2 = new frmOrdenFabricacionTR8_A();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "R") || (cEstado == "N"))
                    {
                        //////////////////////////////////
                        // Rechazado

                        frmOrdenFabricacionTR8_R f2 = new frmOrdenFabricacionTR8_R();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                    if ((cEstado == "Q") || (cEstado == ""))
                    {
                        //////////////////////////////////
                        // Aprobado con Reparos

                        frmOrdenFabricacionTR8_AR f2 = new frmOrdenFabricacionTR8_AR();
                        DialogResult res = f2.ShowDialog();
                        cImpresion = "Ok";

                    }

                }

                if ((cProceso == "Secado") || (cProceso == "_Desp & Secado"))
                {
                    //////////////////////////////////
                    // Aprobado

                    frmOrdenFabricacionTRA2 f2 = new frmOrdenFabricacionTRA2();
                    DialogResult res = f2.ShowDialog();
                    cImpresion = "Ok";

                }


                if (cImpresion == "")
                {
                    frmOrdenFabricacionTR8_AR f2 = new frmOrdenFabricacionTR8_AR();
                    DialogResult res = f2.ShowDialog();

                }

                VariablesGlobales.glb_DocEntry = 0;

                Close();

            }


        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir1_Click(object sender, EventArgs e)
        {

            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_cantidad_etiquetas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad de etiquetas válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            
            int nDocEntry, nNumOF;
            string cObject;

            try
            {
                nDocEntry = int.Parse(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cObject = t_object.Text;
            }
            catch
            {
                cObject = "";
            }

            string cLote, cItemName, cCardCode;
            string cCardName, cComuna, cCuidad;
            string cTemporada, cItemCode, cProceso_OF;
            string cCSP, cItmsGrpNam, cEspecie;
            string cComunaRes, cCuidadRes, cNombreRes;
            string cCodigo_CSG;

            double nCantidad, nNumEtiquetas, nPeso_x_bins;
            double nQuantity;

            DateTime dFechaCreacion;
            DateTime dFechaFormulario;
            DateTime dFechaEtiqueta;

            try
            {
                dFechaFormulario = dtp_nueva_fecha.Value;
            }
            catch
            {
                dFechaFormulario = DateTime.Parse("01/01/1900");
            }

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Datos_Entrada_x_id(nDocEntry, cObject, t_lote.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            cLote = "";
            cItemCode = "";
            cItemName = "";
            cCardCode = "";
            cCardName = "";
            nCantidad = 0;
            cComuna = "";
            cCuidad = "";
            cTemporada = "";
            cCSP = "";
            cItmsGrpNam = "";
            cEspecie = "";
            cComunaRes = "";
            cCuidadRes = "";
            cNombreRes = "";
            nNumOF = 0;
            cCodigo_CSG = "";

            try
            {
                cLote = dTable.Rows[0]["MdAbsEntry"].ToString();
            }
            catch
            {
                cLote = "";
            }

            try
            {
                nNumOF = Convert.ToInt32(dTable.Rows[0]["BaseEntry"].ToString());
            }
            catch
            {
                nNumOF = 0;
            }

            try
            {
                cItemCode = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cItemName = dTable.Rows[0]["Dscription"].ToString();
            }
            catch
            {
                cItemName = "";
            }

            try
            {
                cCardCode = dTable.Rows[0]["CodProd"].ToString();
            }
            catch
            {
                cCardCode = "";
            }

            try
            {
                cCardName = dTable.Rows[0]["U_NOMBPROD"].ToString();
            }
            catch
            {
                cCardName = "";
            }

            try
            {
                nCantidad = double.Parse(dTable.Rows[0]["Peso_Unit"].ToString());
            }
            catch
            {
                nCantidad = 0;
            }

            try
            {
                dFechaCreacion = DateTime.Parse(dTable.Rows[0]["DocDate"].ToString());
            }
            catch
            {
                dFechaCreacion = DateTime.Parse("01/01/1900");
            }

            try
            {
                cComuna = dTable.Rows[0]["Comuna_Productor"].ToString();
            }
            catch
            {
                cComuna = "";
            }

            try
            {
                cCuidad = dTable.Rows[0]["Ciudad_Productor"].ToString();
            }
            catch
            {
                cCuidad = "";
            }

            try
            {
                cTemporada = dTable.Rows[0]["Temporada_Cosecha"].ToString();
            }
            catch
            {
                cTemporada = "";
            }

            try
            {
                cProceso_OF = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                cProceso_OF = "";
            }

            try
            {
                cItmsGrpNam = dTable.Rows[0]["ItmsGrpNam"].ToString();   
            }
            catch
            {
                cItmsGrpNam = "";
            }

            try
            {
                cEspecie = dTable.Rows[0]["Especie"].ToString();
            }
            catch
            {
                cEspecie = "";
            }

            try
            {
                cCodigo_CSG = dTable.Rows[0]["U_Codigo_CSG"].ToString();
            }
            catch
            {
                cCodigo_CSG = "";
            }

            nNumEtiquetas = 1;

            try
            {
                nNumEtiquetas = double.Parse(dTable.Rows[0]["Quantity"].ToString());
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            nQuantity = nNumEtiquetas;
            //nNumEtiquetas_t = nNumEtiquetas;

            try
            {
                nPeso_x_bins = double.Parse(dTable.Rows[0]["Peso_x_Bins"].ToString());
            }
            catch
            {
                nPeso_x_bins = 0;
            }

            try
            {
                nNumEtiquetas = Convert.ToInt32(cbb_cantidad_etiquetas.Text); 
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            if (cProceso_OF != "Desp & Secado")
            {
                cCSP = "114761";
                cComunaRes = "PAINE";
                cCuidadRes = "MAIPO";
                cNombreRes = "Res 020290 de 02/04/2013 S. Salud RM";

                string cNuevo_ItemName;

                cNuevo_ItemName = cItemName.Replace("ALMENDRA PROPIA", "ALMENDRA SIN CASCARA");
                cNuevo_ItemName = cNuevo_ItemName.Replace("NUEZ PROPIA PT", "Nuez sin cascara");

                if (cItemCode == "FP.ALM.PT.SMA1.XXX.X.XXX-XXX.RAY.C.0010K.01")
                {
                    cNuevo_ItemName = "ALMENDRA SIN CASCARA PT RAYADA";
                    cNuevo_ItemName = "ALMENDRA SIN CASCARA";

                }

                if (cItemCode == "FP.ALM.PT.SMA1.XXX.X.XXX-XXX.RAY.S.1000K.01")
                {
                    cNuevo_ItemName = "ALMENDRA SIN CASCARA PT RAYADA";

                }

                if (cItemCode.Substring(0, 2).ToString() == "FP")
                {
                    cCardName = "AGRICOLA HUERTOS DEL VALLE S.A.";
                    cComuna = "MOSTAZAL";
                    cCuidad = "CACHAPOAL";
                    //""

                    if ((nNumOF == 6110) || (nNumOF == 6113))
                    {
                        cCardName = "";

                    }

                }

                if (cEspecie == "Nuez" && cItmsGrpNam == "1108405-00 PT Man")
                {
                    ////////////////////////////////
                    // Eso lo solicito Roberto Galaz 2018-06-22
                    // Esto es solo para Limache 

                    cCSP = "114760";
                    cComunaRes = "LIMACHE";
                    cCuidadRes = "MARGA MARGA";
                    cNombreRes = "Res 622 de 09/12/2004 S. Salud V REGION";

                }

                if (checkBox1.Checked == true)
                {
                    dFechaEtiqueta = dFechaFormulario;
                }
                else
                {
                    dFechaEtiqueta = dFechaCreacion;
                }

                for (int i = 0; i <= nNumEtiquetas - 1; i++)
                {
                    etiqueta_adhesiva(cLote, cNuevo_ItemName, cCardCode, cCardName, cComuna, cCuidad, cTemporada, i + 1, Convert.ToInt32(nNumEtiquetas), nCantidad, dFechaEtiqueta, cCSP, cComunaRes, cCuidadRes, cNombreRes);
                }

            }
            else
            {
                cCSP = "114761";
                cComunaRes = "PAINE";
                cCuidadRes = "MAIPO";
                cNombreRes = "Res 020290 de 02/04/2013 S. Salud RM";

                string cNuevo_ItemName1;

                cNuevo_ItemName1 = "NUEZ SERVICIO PT SECADO";

                if (checkBox1.Checked == true)
                {
                    dFechaEtiqueta = dFechaFormulario;
                }
                else
                {
                    dFechaEtiqueta = dFechaCreacion;
                }

                double n_Peso_x_bins, nTotal_Bins;

                try
                {
                    nTotal_Bins = Convert.ToDouble(t_total_bins.Text);
                }
                catch
                {
                    nTotal_Bins = 1;
                }

                n_Peso_x_bins = Math.Round(nQuantity / nTotal_Bins,2);

                for (int i = 0; i <= nNumEtiquetas - 1; i++)
                {
                    etiqueta_adhesiva2(cLote, cNuevo_ItemName1, cCardCode, cCardName, nNumOF, i + 1, Convert.ToInt32(t_total_bins.Text), n_Peso_x_bins, dFechaEtiqueta, cCSP, cComunaRes, cCuidadRes, cNombreRes, cCodigo_CSG);
                }


            }

        }

        private void etiqueta_adhesiva2(string cLote, string cItemName, string cCardCode, string cCardName, int nNumOF, int nFolio1, int nFolio2, double nPesoUnit, DateTime dFechaCreacion, string c_CSP, string cComunaRes, string cProvinciaRes, string cNombreRes, string cCodigo_CSG)
        {

            //////////////////////////////////////
            // Etiqueta de D&S 

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 22);
                Font Font_Titulo = new Font("Consolas", 14, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Titulo_S = new Font("Consolas", 20, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                //e1.Graphics.DrawString("Despeloado & SecadoProductor: " + cCardName, Font_Cuerpo, br, 5, 20);

                e1.Graphics.DrawString("Despelonado & Secado", Font_Titulo, br, 10, 20);

                e1.Graphics.DrawString("****************************", Font_Cuerpo, br, 10, 40);

                e1.Graphics.DrawString("Productor: " + cCardName, Font_Cuerpo, br, 10, 60);

                e1.Graphics.DrawString("Peso Neto: " + nPesoUnit.ToString() + " Kgs", Font_Titulo, br, 10, 80);
                e1.Graphics.DrawString("Bins " + nFolio1.ToString() + " de " + nFolio2.ToString(), Font_Titulo, br, 260, 80);

                e1.Graphics.DrawString(cItemName, Font_Cuerpo, br, 10, 110);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 260, 130);

                e1.Graphics.DrawString("OF: " + nNumOF.ToString(), Font_Cuerpo, br, 10, 140);
                
                e1.Graphics.DrawString("F. emisión: " + dFechaCreacion.ToString("dd/MM/yy"), Font_Cuerpo, br, 10, 170);

                e1.Graphics.DrawString(cLote, Font_Titulo_S, br, 260, 180);

                e1.Graphics.DrawString("Codigo CSG: " + cCodigo_CSG, Font_Cuerpo, br, 10, 200);

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
        private void etiqueta_adhesiva(string cLote, string cItemName, string cCardCode, string cCardName, string cComuna, string cCuidad , string cTemporada , int nFolio1, int nFolio2, double nPesoUnit, DateTime dFechaCreacion, string c_CSP, string cComunaRes, string cProvinciaRes, string cNombreRes)
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

                e1.Graphics.DrawString("CSG: 115148", Font_Cuerpo, br, 280, 20);

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

        private void etiqueta_adhesiva_tiny(string cLote)
        {

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                Font Font_Titulo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 8, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 10, 20);
                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 10, 50);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 140, 20);
                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 140, 50);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 260, 20);
                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 260, 50);

            };

            try
            {
                p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 50, 0, 50);
                //p.PrinterSettings.Copies = 20;               

                if (p.PrinterSettings.IsValid)
                {

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

        private void btn_imprimir2_Click(object sender, EventArgs e)
        {

            if (T_Proceso.Text != "Desp & Secado")
            {
                frmOrdenFabricacionTR9_A f2 = new frmOrdenFabricacionTR9_A();
                DialogResult res = f2.ShowDialog();

            }
            else
            {
                frmOrdenFabricacionTR4_A f2 = new frmOrdenFabricacionTR4_A();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dtp_nueva_fecha.Enabled = true;
            }
            else
            {
                dtp_nueva_fecha.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_cantidad_etiquetas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad de etiquetas válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocEntry, nNumOF, nNumEtiquetas;
            string cObject;

            try
            {
                nDocEntry = int.Parse(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cObject = t_object.Text;
            }
            catch
            {
                cObject = "";
            }

            string cLote;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Datos_Entrada_x_id(nDocEntry, cObject, t_lote.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            cLote = "";
            nNumOF = 0;

            try
            {
                cLote = dTable.Rows[0]["MdAbsEntry"].ToString();
            }
            catch
            {
                cLote = "";
            }

            try
            {
                nNumOF = Convert.ToInt32(dTable.Rows[0]["BaseEntry"].ToString());
            }
            catch
            {
                nNumOF = 0;
            }

            nNumEtiquetas = 1;

            try
            {
                nNumEtiquetas = Convert.ToInt32(cbb_cantidad_etiquetas.Text);
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            etiqueta_adhesiva_tiny(cLote);

            //for (int i = 0; i <= nNumEtiquetas - 1; i++)
            //{
            //    etiqueta_adhesiva_tiny(cLote);
            //}

        }

    }

}
