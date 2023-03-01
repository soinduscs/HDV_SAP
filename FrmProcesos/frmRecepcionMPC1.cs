using System;
using System.IO;
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
    public partial class frmRecepcionMPC1 : Form
    {
        public frmRecepcionMPC1()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPC1_Load(object sender, EventArgs e)
        {

            Boolean exists;

            //exists = System.IO.Directory.Exists("c:\ExistingFolderName")

            exists = System.IO.Directory.Exists(@"c:\temp");

            if (exists == false)
            {
                MessageBox.Show("Debe crear la Carpeta >Temp< en el Disco C, de lo contrario la aplicación NO funcionara correctamente", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string sourceDir = @"c:\temp";

                string[] picList = Directory.GetFiles(sourceDir, "i*.png");

                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                }

                foreach (string f in picList)
                {
                    try
                    {
                        File.Delete(f);

                    }
                    catch
                    {

                    }
                }

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();

            if (VariablesGlobales.glb_id_romana != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();

                carga_datos_x_id();

                int nCantRegistrosRomana;

                nCantRegistrosRomana = -1;

                clsRecepcion objproducto = new clsRecepcion();
                objproducto.cls_Consulta_Pesos_x_Guia(int.Parse(t_id_romana.Text));

                this.cbb_romana.DataSource = objproducto.cResultado;
                this.cbb_romana.ValueMember = "LineId";
                this.cbb_romana.DisplayMember = "Ref_LineId";

                try
                {
                    cbb_romana.SelectedIndex = 0;

                }
                catch
                {

                }

                try
                {
                    nCantRegistrosRomana = cbb_romana.Items.Count;

                }
                catch
                {
                    nCantRegistrosRomana = 0;
                }

                if (nCantRegistrosRomana > 0)
                {
                    //btn_recibir.Enabled = true;
                    //btn_genera_recepcion.Enabled = true;
                }
                else
                {
                    cbb_romana.Text = "No Existen Pesos Pendientes";

                    cbb_romana.Enabled = false;
                    //btn_recibir.Enabled = false;
                    //btn_genera_recepcion.Enabled = false;
                }

            }

            if (VariablesGlobales.glb_Referencia1 == "F")
            {
                btn_recibir.Enabled = false;
                //button1.Enabled = false;
                btn_genera_recepcion.Enabled = false;

            }

            if (Grid1.RowCount > 1)
            {
                btn_genera_recepcion.Enabled = false;

            }

        }

        private void carga_datos_x_id()
        {

            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor, obs;
            string CardCode_trans, CardName_trans;

            int numguia, cant_envases, id_acceso;

            float peso_bruto, peso_neto;
            float peso_guia, peso_bins;

            DateTime fecha_hora1, fecha_hora2;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            CardCode_trans = "";
            CardName_trans = "";

            numguia = 0;
            patente = "";
            conductor = "";
            peso_bruto = 0;
            peso_neto = 0;
            peso_guia = 0;
            cant_envases = 0;
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            peso_bins = 0;

            t_cardcode.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_peso_neto.Clear();
            t_cantidad_envases.Clear();
            t_observacion.Clear();
            t_fecha_1er_peso.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();
            t_CardoName_Trans.Clear();
            t_CardoCode_Trans.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, -1);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0].ItemArray[2].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0].ItemArray[4].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                patente = dTable.Rows[0].ItemArray[6].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[20].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0].ItemArray[16].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = id_romana;

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                peso_bruto = float.Parse(dTable.Rows[0].ItemArray[13].ToString());

            }
            catch
            {
                peso_bruto = 0;

            }

            try
            {
                peso_neto = float.Parse(dTable.Rows[0].ItemArray[15].ToString());

            }
            catch
            {
                peso_neto = 0;

            }

            try
            {
                cant_envases = int.Parse(dTable.Rows[0].ItemArray[7].ToString());

            }
            catch
            {
                cant_envases = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0].ItemArray[17].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0].ItemArray[18].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["U_DocEntry_Acceso"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }

            try
            {
                CardCode_trans = dTable.Rows[0].ItemArray[21].ToString();

            }
            catch
            {
                CardCode_trans = "";

            }

            try
            {
                CardName_trans = dTable.Rows[0].ItemArray[22].ToString();

            }
            catch
            {
                CardName_trans = "";

            }

            try
            {

                peso_guia = float.Parse(dTable.Rows[0]["PesoGuia_neto"].ToString()); //float.Parse(dTable.Rows[0].ItemArray[27].ToString());

            }
            catch
            {
                peso_guia = 0;

            }

            try
            {
                peso_bins = float.Parse(dTable.Rows[0].ItemArray[31].ToString());

            }
            catch
            {
                peso_bins = 0;

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            carga_datos_de_detalle_x_id();

            ////////////////////////////////////////////////////7
            //// junto las grillas
            ////

            junta_grilla();

            ////////////////////////////////////////////////////7
            //// 
            ////

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_CardoName_Trans.Text = CardName_trans;
            t_CardoCode_Trans.Text = CardCode_trans;

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;

            if (conductor.Length > 30)
            {
                conductor = conductor.Substring(0, 30).ToString();
            }

            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_peso_neto.Clear();

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

            if (peso_guia != 0)
            {
                t_peso_guia.Text = peso_guia.ToString("N2");

            }

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_1er_peso.Text = fecha_hora1.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            if (fecha_hora2.Year != 1900)
            {
                t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_ref.Text = "S";

            //cbb_envase.SelectedIndex = id_envase;
            t_cantidad_envases.Text = cant_envases.ToString();
            t_observacion.Text = obs;

            //btn_buscar1.Visible = false;
            //btn_buscar2.Visible = false;

        }

        private void carga_datos_de_detalle_x_id()
        {

            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, -1);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D, cEstado_D, cLote_D;
            string ItemCodeBins, cReferencia1, cReferencia2;
            string cLoteOrigen, cCodigoCSG_D;

            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D, nCantAnalisisCalidad_Total;
            int nLineId, nOPDN_DocNum_D, nOWTR_DocNum_D;
            int nIdReferencia1, nIdReferencia2, nPesoTotalBins_D;
            int ocurrencias, nLineNumOC_D;
            int nItemTotalItems, nCantItemRecibidos;

            double nCantidadReferencia1, nCantidadReferencia2;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nCantAnalisisCalidad_Total = 0;
            nItemTotalItems = 0;
            nCantItemRecibidos = 0;

            //////////////////////////////////////////
            // Variables para validación de recepción
            // Si hay productores distintos - Ingreso Manual
            // Si hay especies distintas - Ingreso Manual
            // Si hay envases distintos - Ingreso Manual

            string cCardCode_Productor_V, cEspecia_V, cItemCode_Envase_V;
            string cTipodeIngreso_V;

            cCardCode_Productor_V = "_";
            cEspecia_V = "_";
            cItemCode_Envase_V = "_";
            cTipodeIngreso_V = "";

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nLineId = 0;
                nNumOC_D = 0;
                cCardCode_D = "";
                cCardName_D = "";
                cItemCode_D = "";
                cItemName_D = "";
                nCantBins_D = 0;
                n_PesoUnitBins_D = 0;
                nCantAnalisisCalidad_D = 0;
                cReferencia1 = "";
                cReferencia2 = "";
                nIdReferencia1 = 0;
                nIdReferencia2 = 0;
                nCantidadReferencia1 = 0;
                nCantidadReferencia2 = 0;
                cEstado_D = "";
                nPesoTotalBins_D = 0;
                cLote_D = "";
                nOPDN_DocNum_D = 0;
                nOWTR_DocNum_D = 0;
                cLoteOrigen = "";
                cCodigoCSG_D = "";
                nLineNumOC_D = 0;

                try
                {
                    nLineId = Convert.ToInt32(dTable.Rows[i]["LineId_D"].ToString());

                }
                catch
                {
                    nLineId = 0;

                }

                try
                {
                    nNumOC_D = Convert.ToInt32(dTable.Rows[i]["U_NumOC"].ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                try
                {
                    cCardCode_D = dTable.Rows[i]["U_CardCode_D"].ToString().ToUpper();

                }
                catch
                {

                }

                if (cCardCode_Productor_V == "_")
                {
                    cCardCode_Productor_V = cCardCode_D;
                }

                try
                {
                    cCardName_D = dTable.Rows[i]["U_CardName_D"].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemCode_D = dTable.Rows[i]["U_ItemCode"].ToString().ToUpper();

                }
                catch
                {

                }

                if (cEspecia_V == "_")
                {
                    cEspecia_V = cItemCode_D;
                }

                try
                {
                    cItemName_D = dTable.Rows[i]["U_ItemName_D2"].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    ItemCodeBins = dTable.Rows[i]["U_ItemCodeBins"].ToString();

                }
                catch
                {
                    ItemCodeBins = "_";

                }

                if (cItemCode_Envase_V == "_")
                {
                    cItemCode_Envase_V = ItemCodeBins;
                }

                try
                {
                    nCantBins_D = Convert.ToInt32(dTable.Rows[i]["Ref_Cantidad2"].ToString().ToUpper());

                }
                catch
                {
                    nCantBins_D = 0;

                }

                if (nCantBins_D == 0)
                {
                    try
                    {
                        nCantBins_D = Convert.ToInt32(dTable.Rows[i]["U_CantBins_D"].ToString().ToUpper());

                    }
                    catch
                    {
                        nCantBins_D = 0;

                    }

                }

                try
                {
                    n_PesoUnitBins_D = Convert.ToInt32(dTable.Rows[i]["U_PesoUnit_Bins"].ToString().ToUpper());

                }
                catch
                {
                    n_PesoUnitBins_D = 0;

                }

                try
                {
                    nCantAnalisisCalidad_D = Convert.ToInt32(dTable.Rows[i]["Cant_Analisis_Calidad"].ToString().ToUpper());

                }
                catch
                {
                    nCantAnalisisCalidad_D = 0;

                }

                try
                {
                    cReferencia1 = dTable.Rows[i]["Ref_BaseObject1"].ToString();

                }
                catch
                {
                    cReferencia1 = "";

                }

                try
                {
                    nIdReferencia1 = int.Parse(dTable.Rows[i]["Ref_BaseLine1"].ToString());

                }
                catch
                {
                    nIdReferencia1 = 0;

                }

                try
                {
                    nCantidadReferencia1 = double.Parse(dTable.Rows[i]["Ref_Cantidad1"].ToString());

                }
                catch
                {
                    nCantidadReferencia1 = 0;

                }

                try
                {
                    cReferencia2 = dTable.Rows[i]["Ref_BaseObject2"].ToString();

                }
                catch
                {
                    cReferencia2 = "";

                }

                try
                {
                    nIdReferencia2 = int.Parse(dTable.Rows[i]["Ref_BaseLine2"].ToString());

                }
                catch
                {
                    nIdReferencia2 = 0;

                }

                try
                {
                    nCantidadReferencia2 = double.Parse(dTable.Rows[i]["Ref_Cantidad2"].ToString());

                }
                catch
                {
                    nCantidadReferencia2 = 0;

                }

                try
                {
                    nPesoTotalBins_D = Convert.ToInt32(double.Parse(dTable.Rows[i]["Ref_PesoTotalBins2"].ToString()));

                }
                catch
                {
                    nPesoTotalBins_D = 0;

                }

                try
                {
                    cLote_D = dTable.Rows[i]["MdAbsEntry"].ToString();

                }
                catch
                {
                    cLote_D = "";

                }

                if (cReferencia1 == "")
                {
                    cEstado_D = "";

                }
                else
                {
                    cEstado_D = "X";

                }

                try
                {
                    nOPDN_DocNum_D = int.Parse(dTable.Rows[i]["Ref_OPDN_DocNum"].ToString());

                }
                catch
                {
                    nOPDN_DocNum_D = 0;

                }

                try
                {
                    nOWTR_DocNum_D = int.Parse(dTable.Rows[i]["Ref_OWTR_DocNum"].ToString());
                }
                catch
                {
                    nOWTR_DocNum_D = 0;
                }

                try
                {
                    cLoteOrigen = dTable.Rows[i]["Lote_guia_interna"].ToString();
                }
                catch
                {
                    cLoteOrigen = "";
                }

                try
                {
                    cCodigoCSG_D = dTable.Rows[i]["U_Codigo_CSG"].ToString().ToUpper();

                }
                catch
                {
                    cCodigoCSG_D = "";
                }

                try
                {
                    nLineNumOC_D = Convert.ToInt32(dTable.Rows[i]["U_LineIDOC"].ToString());

                }
                catch
                {
                    nLineNumOC_D = 0;
                }

                nCantAnalisisCalidad_Total = nCantAnalisisCalidad_Total + nCantAnalisisCalidad_D;

                grilla[0] = nLineId.ToString();

                grilla[2] = nNumOC_D.ToString();
                grilla[3] = cCardCode_D.ToUpper();
                grilla[4] = cCardName_D.ToUpper();
                grilla[5] = cCodigoCSG_D.ToUpper();
                grilla[6] = cItemName_D.ToUpper();
                grilla[7] = ItemCodeBins;
                grilla[8] = Convert.ToString(nCantBins_D);
                grilla[9] = Convert.ToString(n_PesoUnitBins_D);
                grilla[10] = Convert.ToString(nCantAnalisisCalidad_D);

                ocurrencias = cItemName_D.Split(new String[] { "ALM" }, StringSplitOptions.None).Length - 1;

                grilla[11] = "";
                grilla[23] = "";
                grilla[24] = cLoteOrigen;
                grilla[25] = cItemCode_D.ToUpper();
                grilla[26] = nLineNumOC_D.ToString();

                if (ocurrencias > 0)
                {
                    grilla[11] = "BMPP1";
                    grilla[23] = "BMPP1";
                }

                ocurrencias = cItemName_D.Split(new String[] { "NUE" }, StringSplitOptions.None).Length - 1;

                if (ocurrencias > 0)
                {
                    grilla[11] = "BMPP2";
                    grilla[23] = "BMPP2";
                }

                grilla[12] = cEstado_D;

                if (nPesoTotalBins_D == 0)
                {
                    grilla[13] = 0.ToString("N2");

                }
                else
                {
                    grilla[13] = nPesoTotalBins_D.ToString("N2");

                }

                if (nCantidadReferencia1 == 0)
                {
                    grilla[14] = 0.ToString("N2");

                }
                else
                {
                    grilla[14] = nCantidadReferencia1.ToString("N2");

                    //btn_recibir.Enabled = false;
                    //btn_cancela_recepcion.Enabled = false;
                    //btn_genera_recepcion.Enabled = false;

                }

                grilla[15] = cReferencia1;
                grilla[16] = nIdReferencia1.ToString();
                grilla[17] = cReferencia2;
                grilla[18] = nIdReferencia2.ToString();
                grilla[19] = nOPDN_DocNum_D.ToString();
                grilla[20] = cLote_D;
                grilla[21] = nOWTR_DocNum_D.ToString();

                Grid3.Rows.Add(grilla);

                nItemTotalItems += 1;

                if (cEstado_D == "")
                {
                    Grid3[1, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                }
                else
                {
                    Grid3[1, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Fill right).ico");

                    for (int x = 2; x <= 21; x++)
                    {
                        Grid3[x, i].Style.BackColor = Color.LightGray;

                    }

                }

                //////////////////////////////////////////
                // Esto determina el tipo de ingreso

                if (cCardCode_D != cCardCode_Productor_V)
                {
                    cTipodeIngreso_V = "M";

                }

                if (cItemCode_D != cEspecia_V)
                {
                    cTipodeIngreso_V = "M";
                }

                if (cItemCode_Envase_V != ItemCodeBins)
                {
                    cTipodeIngreso_V = "M";
                }

                if (nOWTR_DocNum_D > 0)
                {
                    cTipodeIngreso_V = "X";
                    nCantItemRecibidos += 1;

                }

            }

            /////////////////////////////////////////
            if (nItemTotalItems != nCantItemRecibidos)
            {
                if (cTipodeIngreso_V == "X")
                {
                    cTipodeIngreso_V = "M";

                }

            }

            if (cTipodeIngreso_V == "M")
            {
                btn_recibir.Enabled = false;
                btn_genera_recepcion.Enabled = false;
                button1.Enabled = true;

            }

            if (cTipodeIngreso_V == "X")
            {
                btn_recibir.Enabled = false;
                btn_genera_recepcion.Enabled = false;
                button1.Enabled = false;

            }

            if (cTipodeIngreso_V == "")
            {
                btn_recibir.Enabled = true;
                btn_genera_recepcion.Enabled = true;
                button1.Enabled = true;

            }

        }

        private void junta_grilla()
        {

            string[] grilla;
            grilla = new string[30];
            string cOC, cOC1, cAgregar;
            int nFila;

            nFila = 0;
            cOC = "";

            //////////////////////////////////////////////
            // Genero la grilla resumida x OC

            for (int i = 0; i <= Grid3.RowCount-1; i++)
            {

                try
                {
                    cOC = Grid3[2, i].Value.ToString();
                }
                catch
                {
                    cOC = "";
                }

                cAgregar = "S";

                for (int x = 0; x <= Grid1.RowCount - 1; x++)
                {
                    try
                    {
                        cOC1 = Grid1[2, x].Value.ToString();
                    }
                    catch
                    {
                        cOC1 = "";
                    }

                    if (cOC == cOC1)
                    {
                        cAgregar = "N";
                        break;

                    }

                }

                if (cAgregar == "S")
                {

                    grilla[0] = Grid3[0, i].Value.ToString();

                    for (int r = 2; r <= 26; r++)
                    {
                        try
                        {
                            grilla[r] = Grid3[r, i].Value.ToString();

                        }
                        catch
                        {

                        }

                    }

                    Grid1.Rows.Add(grilla);

                    if (Grid1[12, nFila].Value.ToString() == "")
                    {
                        Grid1[1, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    else
                    {
                        Grid1[1, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Fill right).ico");

                        for (int x = 2; x <= 21; x++)
                        {
                            Grid1[x, nFila].Style.BackColor = Color.LightGray;

                        }

                    }

                    nFila += 1;

                }

            }

            //////////////////////////////////////////////
            // Agrupo las cantidades de bins

            int nCantBins, nCantBins_D;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cOC = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cOC = "";
                }

                nCantBins = 0;

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    try
                    {
                        cOC1 = Grid3[2, x].Value.ToString();
                    }
                    catch
                    {
                        cOC1 = "";
                    }

                    try
                    {
                        nCantBins_D = Convert.ToInt32(Grid3[8, x].Value.ToString());
                    }
                    catch
                    {
                        nCantBins_D = 0;
                    }

                    if (cOC == cOC1)
                    {
                        nCantBins += nCantBins_D;

                    }

                }

                Grid1[8, i].Value = nCantBins.ToString();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Array1 = new int[200];
            VariablesGlobales.glb_Array2 = new string[200];
            VariablesGlobales.glb_Array3 = new string[200];
            VariablesGlobales.glb_Array4 = new string[200];
            VariablesGlobales.glb_Array5 = new string[200];
            VariablesGlobales.glb_Array6 = new int[200];

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nLineId_Romana;


            nLineId_Romana = -1;

            try
            {
                nLineId_Romana = cbb_romana.SelectedIndex;

            }
            catch
            {
                nLineId_Romana = -1;

            }

            if (nLineId_Romana == -1)
            {
                MessageBox.Show("Debe seleccionar un Pesaje de Roaman válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int id_romana, fila, nNumOC;
            int nLineId, nCantBins;
            string cItemCodeBins, cEstadoItem; //, cLoteOrigen;

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

            nLineId = 0;
            nNumOC = 0;
            cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, fila].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem == "X")
            {
                MessageBox.Show("El Registro seleccionar ya fue ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (fila >= 0)
            {
                try
                {
                    nNumOC = Convert.ToInt32(Grid1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;
                }

            }

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                id_romana = 0;

            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            VariablesGlobales.glb_NumOC = Grid1[2, fila].Value.ToString();
            VariablesGlobales.glb_CardCode = Grid1[3, fila].Value.ToString();
            VariablesGlobales.glb_CardName = Grid1[4, fila].Value.ToString();
            VariablesGlobales.glb_ItemCode = Grid1[25, fila].Value.ToString();
            VariablesGlobales.glb_ItemName = Grid1[6, fila].Value.ToString();
            VariablesGlobales.glb_Almacen = Grid1[23, fila].Value.ToString();
            VariablesGlobales.glb_Almacen_From = Grid1[11, fila].Value.ToString();
            VariablesGlobales.glb_Codigo_CSG = Grid1[5, fila].Value.ToString();
            VariablesGlobales.glb_LineNumOF = Convert.ToInt32(Grid1[26, fila].Value.ToString());

            nCantBins = 0;
            cItemCodeBins = "";

            try
            {
                cItemCodeBins = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cItemCodeBins = "";
            }

            try
            {
                nCantBins = Convert.ToInt32(Grid1[8, fila].Value);
            }
            catch
            {
                nCantBins = 0;
            }

            VariablesGlobales.glb_Array1_ind = 0;

            int nIndice = 0;
            int nMaximo = -1;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                try
                {
                    nIndice = Convert.ToInt32(Grid2[0, i].Value);

                }
                catch
                {
                    nIndice = -1;
                }

                if (nIndice == nLineId)
                {
                    nMaximo += 1;

                    VariablesGlobales.glb_Array1[nMaximo] = Convert.ToInt32(Grid2[1, i].Value);
                    VariablesGlobales.glb_Array2[nMaximo] = Grid2[2, i].Value.ToString();
                    VariablesGlobales.glb_Array3[nMaximo] = Grid2[3, i].Value.ToString();
                    VariablesGlobales.glb_Array4[nMaximo] = Grid2[4, i].Value.ToString();
                    VariablesGlobales.glb_Array5[nMaximo] = "";
                    VariablesGlobales.glb_Array6[nMaximo] = Convert.ToInt32(Grid2[6, i].Value);

                }

            }

            if (nMaximo == -1)
            {
                nMaximo = 0;

                VariablesGlobales.glb_Array1[nMaximo] = nCantBins;
                VariablesGlobales.glb_Array2[nMaximo] = cItemCodeBins;
                VariablesGlobales.glb_Array3[nMaximo] = "B_PRODUC";
                VariablesGlobales.glb_Array4[nMaximo] = "PAI_BINS";
                VariablesGlobales.glb_Array5[nMaximo] = "";
                VariablesGlobales.glb_Array6[nMaximo] = 0;

            }

            string cCardCode_Ori, cCardName_Ori;
            int nNumOC_Ori;

            string cCardCode_New, cCardName_New;
            int nNumOC_New;

            cCardCode_Ori = Grid1[3, fila].Value.ToString();
            cCardName_Ori = Grid1[4, fila].Value.ToString();
            nNumOC_Ori = nNumOC;

            VariablesGlobales.glb_Array1_ind = nMaximo;

            frmRecepcionMPC2 f2 = new frmRecepcionMPC2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode == "__")
            {
                return;

            }

            Grid1[2, fila].Value = VariablesGlobales.glb_NumOC;

            Grid1[3, fila].Value = VariablesGlobales.glb_CardCode;
            Grid1[4, fila].Value = VariablesGlobales.glb_CardName;
            Grid1[5, fila].Value = VariablesGlobales.glb_Codigo_CSG;

            Grid1[6, fila].Value = VariablesGlobales.glb_ItemName;

            Grid1[11, fila].Value = VariablesGlobales.glb_Almacen;
            Grid1[23, fila].Value = VariablesGlobales.glb_Almacen_From;

            Grid1[25, fila].Value = VariablesGlobales.glb_ItemCode;
            Grid1[26, fila].Value = VariablesGlobales.glb_LineNumOF.ToString();

            nMaximo = VariablesGlobales.glb_Array1_ind;

            cCardCode_New = VariablesGlobales.glb_CardCode;
            cCardName_New = VariablesGlobales.glb_CardName;
            nNumOC_New = Convert.ToInt32(VariablesGlobales.glb_NumOC);

            int nNumOC_grid3;

            if (nNumOC_Ori != nNumOC_New)
            {

                for (int v = 0; v <= Grid3.RowCount - 1; v++)
                {

                    try
                    {
                        nNumOC_grid3 = Convert.ToInt32(Grid3[2, v].Value.ToString());
                    }
                    catch
                    {
                        nNumOC_grid3 = 0;
                    }

                    if (nNumOC_grid3 == nNumOC_Ori)
                    {
                        Grid3[2, v].Value = nNumOC_New.ToString();

                    }

                }

            }

            //borra_item(nLineId);

            int nCantBins_D, nCantBinsVacios_D, nCantBins_Total;

            string[] grilla;
            grilla = new string[30];

            nCantBins_D = 0;
            nCantBinsVacios_D = 0;
            nCantBins_Total = 0;

            for (int i = 0; i <= nMaximo; i++)
            {

                grilla[0] = nLineId.ToString();

                grilla[1] = VariablesGlobales.glb_Array1[i].ToString();
                grilla[2] = VariablesGlobales.glb_Array2[i];
                grilla[3] = VariablesGlobales.glb_Array3[i];
                grilla[4] = VariablesGlobales.glb_Array4[i];
                grilla[5] = VariablesGlobales.glb_Array5[i];
                grilla[6] = VariablesGlobales.glb_Array6[i].ToString();

                Grid2.Rows.Add(grilla);

                try
                {
                    nCantBins_D = VariablesGlobales.glb_Array1[i];
                }
                catch
                {
                    nCantBins_D = 0;
                }

                try
                {
                    nCantBinsVacios_D = VariablesGlobales.glb_Array6[i];
                }
                catch
                {
                    nCantBinsVacios_D = 0;
                }

                nCantBins_Total = nCantBins_Total + (nCantBins_D + nCantBinsVacios_D);

            }

            Grid1[8, fila].Value = nCantBins_Total.ToString();
            Grid1[22, fila].Value = nCantBinsVacios_D.ToString();

            Grid1[1, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

            Grid1[12, fila].Value = "OK";

            cbb_romana.Enabled = false;

            /////////////////////////////////////////
            /// Calculo el peso por envase

            double nPesoTotalGuia, nPesoBins_D, nPesoTotal_D;
            string cConfirm;

            nPesoTotalGuia = 0;

            try
            {
                nPesoTotalGuia = Convert.ToDouble(t_peso_neto.Text);

            }
            catch
            {
                nPesoTotalGuia = 0;

            }

            nCantBins_Total = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[8, i].Value);

                }
                catch
                {
                    nCantBins_D = -1;
                }

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    if (nCantBins_D > 0)
                    {
                        nCantBins_Total += nCantBins_D;

                    }

                }

            }

            nPesoBins_D = 0;

            if (nCantBins_Total > 0)
            {
                nPesoBins_D = nPesoTotalGuia / nCantBins_Total;

            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[8, i].Value);

                }
                catch
                {
                    nCantBins_D = -1;
                }

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    if (nCantBins_D > 0)
                    {
                        nPesoTotal_D = nCantBins_D * nPesoBins_D;
                        Grid1[13, i].Value = nPesoBins_D.ToString("N2");
                        Grid1[14, i].Value = nPesoTotal_D.ToString("N2");

                    }

                }

            }

            ////////////////////////////////////////////
            // Confirmo un item con peso desde Romana
            // Des habilito la recepción manual

            button1.Enabled = false;

        }

        private void btn_genera_recepcion_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, 0].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem == "X")
            {
                MessageBox.Show("El Registro seleccionar ya fue ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Recepción de la Guía", "Recepción de Matería Prima", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cConfirm, cItemCode, cWareHouse;
            string cCodigo_CSG;

            int nNumOC, nLineasConfirmadas, nLineasValidas;
            int nPurchaseOrder, nBaseLineNum, nCantidadBins;
            int nCantidadBinsVacios, nLineNumOC; //, nCantidadBins_D - nStock;

            clsOrdendeCompra objproducto = new clsOrdendeCompra();

            clsRecepcion objproducto1 = new clsRecepcion();

            nLineasConfirmadas = 0;
            nLineasValidas = 0;

            //////////////////////////////////////////////////////
            // Valido los registros de items

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    nLineasConfirmadas += 1;
                    nPurchaseOrder = 0;
                    nBaseLineNum = 0;

                    try
                    {
                        nNumOC = Convert.ToInt32(Grid1[2, i].Value);

                    }
                    catch
                    {
                        nNumOC = -1;
                    }

                    try
                    {
                        nLineNumOC = Convert.ToInt32(Grid1[26, i].Value);

                    }
                    catch
                    {
                        nLineNumOC = -1;
                    }

                    try
                    {
                        cItemCode = Grid1[25, i].Value.ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cCodigo_CSG = Grid1[5, i].Value.ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    objproducto.cls_Consultar_Ordenes_de_compra_x_numero(nNumOC, cItemCode, nLineNumOC);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        nPurchaseOrder = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nPurchaseOrder = 0;
                    }

                    try
                    {
                        nBaseLineNum = Convert.ToInt32(dTable.Rows[0]["LineNum"].ToString());
                    }
                    catch
                    {
                        nBaseLineNum = 0;
                    }

                    if (nPurchaseOrder > 0 && nBaseLineNum >= 0)
                    {
                        nLineasValidas += 1;
                    }

                }

            }

            if (nLineasConfirmadas == 0)
            {
                MessageBox.Show("No Existen registros validos, opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nLineasConfirmadas != nLineasValidas)
            {
                MessageBox.Show("Existen lineas No validas, opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_genera_recepcion.Enabled = false;
            Application.DoEvents();

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //  
            // Comienzo el proceso de grabación 
            //  
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            int nLineId, nLote, nU_COMPRAPRODUCTOR;
            int nNumGuia, nId_Romana, nMes;
            int nAnho, nRomanaEntry, nEntradaMercaderiaEntry;
            int nStockTransferEntry;

            double nPesoNeto, nPesoGuia, nPrecioXUnidad;
            double nContraMuestra;

            string cCardCode, cCardName, cTipoLote;
            string mensaje, cPatente, cConductor;
            string cItemName, cItemCodeBins, cDistNumber;
            string CardCode_Serv, CardName_Serv;
            string cVARIEDAD, cPRESENTACION, cContraMuestra;
            string cLoteOrigen;

            string[,] d_arrDetalleBins = new string[20, 20];

            for (int i = 0; i <= 19; i++)
            {
                d_arrDetalleBins[i, 1] = "";

            }

            try
            {
                nId_Romana = int.Parse(t_id_romana.Text);

            }
            catch
            {
                nId_Romana = 0;

            }

            /////////////////////////////////////////////////////
            // Levanto el Splash para que el usuario espeeeeeeere

            Splash sp = new Splash();
            sp.ShowDialog();

            /////////////////////////////////////////////////////

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            mensaje = clsRecepcion.SAPB1_Recepcion(0, nId_Romana, VariablesGlobales.glb_User_id, "");

            ////////////////////////////////////////
            // Consulto el DocEntry de la Recepción

            objproducto1.cls_Consulta_Max_RecepcionMP();

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto1.cResultado;

            try
            {
                nRomanaEntry = int.Parse(dTable3.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nRomanaEntry = 0;

            }

            t_RomanaEntry.Text = nRomanaEntry.ToString();


            try
            {
                nNumGuia = int.Parse(t_num_guia.Text);

            }
            catch
            {
                nNumGuia = 0;

            }

            try
            {
                cPatente = t_patente.Text;
            }
            catch
            {
                cPatente = "";
            }

            try
            {
                cConductor = t_conductor.Text;
            }
            catch
            {
                cConductor = "";
            }

            try
            {
                nPesoGuia = Convert.ToDouble(t_peso_guia.Text);
            }
            catch
            {
                nPesoGuia = 0;
            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    nPurchaseOrder = 0;
                    nBaseLineNum = 0;

                    try
                    {
                        nLineId = int.Parse(Grid1[0, i].Value.ToString());

                    }
                    catch
                    {
                        nLineId = 0;

                    }

                    try
                    {
                        cCardCode = Grid1[3, i].Value.ToString();

                    }
                    catch
                    {
                        cCardCode = "";

                    }

                    try
                    {
                        cCardName = Grid1[4, i].Value.ToString();

                    }
                    catch
                    {
                        cCardName = "";

                    }

                    try
                    {
                        nCantidadBins = int.Parse(Grid1[8, i].Value.ToString());

                    }
                    catch
                    {
                        nCantidadBins = 0;

                    }

                    try
                    {
                        cWareHouse = Grid1[23, i].Value.ToString();

                    }
                    catch
                    {
                        cWareHouse = "";

                    }

                    try
                    {
                        nNumOC = Convert.ToInt32(Grid1[2, i].Value);

                    }
                    catch
                    {
                        nNumOC = -1;
                    }

                    try
                    {
                        cItemCode = Grid1[25, i].Value.ToString();

                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    try
                    {
                        cItemName = Grid1[6, i].Value.ToString();

                    }
                    catch
                    {
                        cItemName = "";

                    }

                    try
                    {
                        cItemCodeBins = Grid1[7, i].Value.ToString();

                    }
                    catch
                    {
                        cItemCodeBins = "";

                    }

                    try
                    {
                        nPesoNeto = Convert.ToDouble(Grid1[14, i].Value.ToString());
                    }
                    catch
                    {
                        nPesoNeto = 0;
                    }

                    try
                    {
                        nCantidadBinsVacios = int.Parse(Grid1[22, i].Value.ToString());

                    }
                    catch
                    {
                        nCantidadBinsVacios = 0;

                    }

                    cLoteOrigen = "0";

                    try
                    {
                        cLoteOrigen = Grid1[24, i].Value.ToString();
                    }
                    catch
                    {
                        cLoteOrigen = "0";
                    }

                    cCodigo_CSG = "";

                    try
                    {
                        cCodigo_CSG = Grid1[5, i].Value.ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    nLineNumOC = -1;

                    try
                    {
                        nLineNumOC = Convert.ToInt32(Grid1[26, i].Value.ToString());
                    }
                    catch
                    {
                        nLineNumOC = 0;
                    }


                    /////////////////////////////////////////
                    /////////////////////////////////////////
                    /// Determino el Cliente servicio

                    CardCode_Serv = "";
                    CardName_Serv = "";

                    if (nNumOC > 0)
                    {
                        objproducto.cls_Consultar_Ordenes_de_compra_x_DocNum(nNumOC);

                        DataTable dTable5 = new DataTable();
                        dTable5 = objproducto.cResultado;

                        try
                        {
                            CardCode_Serv = dTable5.Rows[0]["U_ClienteServ"].ToString();

                        }
                        catch
                        {
                            CardCode_Serv = "";

                        }

                        try
                        {
                            CardName_Serv = dTable5.Rows[0]["U_ClienteServ_Name"].ToString();

                        }
                        catch
                        {
                            CardName_Serv = "";

                        }

                    }

                    /////////////////////////////////////////
                    /////////////////////////////////////////
                    /// Determino el precio de costo OC

                    objproducto.cls_Consultar_Ordenes_de_compra_x_numero(nNumOC, cItemCode, nLineNumOC);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        nPurchaseOrder = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());

                    }
                    catch
                    {
                        nPurchaseOrder = 0;

                    }

                    try
                    {
                        nBaseLineNum = Convert.ToInt32(dTable.Rows[0]["LineNum"].ToString());
                    }
                    catch
                    {
                        nBaseLineNum = 0;
                    }

                    try
                    {
                        nPrecioXUnidad = Convert.ToDouble(dTable.Rows[0]["Price"].ToString());
                    }
                    catch
                    {
                        nPrecioXUnidad = 0;
                    }

                    try
                    {
                        nU_COMPRAPRODUCTOR = int.Parse(dTable.Rows[0]["U_COMPRAPRODUCTOR"].ToString());
                    }
                    catch
                    {
                        nU_COMPRAPRODUCTOR = 0;
                    }

                    try
                    {
                        cVARIEDAD = dTable.Rows[0]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVARIEDAD = "";
                    }

                    try
                    {
                        cPRESENTACION = dTable.Rows[0]["U_HDV_PRESENTACION"].ToString();
                    }
                    catch
                    {
                        cPRESENTACION = "";
                    }

                    nLote = 0;

                    objproducto1.cls_Consulta_Ultimo_Lote();

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto1.cResultado;

                    try
                    {
                        nLote = Convert.ToInt32(dTable1.Rows[0]["DistNumber"].ToString());

                    }
                    catch
                    {
                        nLote = 0;

                    }

                    nLote += 1;

                    DateTime dt;

                    dt = DateTime.Now;

                    //////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////

                    btn_recibir.Enabled = false;
                    t_mensaje.Visible = true;
                    t_mensaje.Clear();

                    //////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////

                    //////////////////////////////////////
                    // Actualizo el registro de romana

                    //////////////////////////////////////
                    // Primero borro el items 

                    Application.DoEvents();
                    t_mensaje.Text = "Inicio proceso de grabación (1)...";
                    Application.DoEvents();

                    int nCantBins_Ref, nLineID_Ref;
                    string cOC_Ref;

                    for (int x = 0; x <= Grid3.RowCount - 1; x++)
                    {
                        try
                        {
                            nLineID_Ref = Convert.ToInt32(Grid3[0, x].Value.ToString());
                        }
                        catch
                        {
                            nLineID_Ref = 0;
                        }

                        try
                        {
                            cOC_Ref = Grid3[2, x].Value.ToString();
                        }
                        catch
                        {
                            cOC_Ref = "";
                        }

                        try
                        {
                            nCantBins_Ref = Convert.ToInt32(Grid3[8, x].Value.ToString());
                        }
                        catch
                        {
                            nCantBins_Ref = 0;
                        }

                        try
                        {
                            cLoteOrigen = Grid3[24, x].Value.ToString();
                        }
                        catch
                        {
                            cLoteOrigen = "";
                        }

                        if (nNumOC == Convert.ToInt32(cOC_Ref))
                        {
                            mensaje = clsRomana.SAPB1_ROMANA2(nId_Romana, -2, cCardCode, cCardName, cItemCode, cItemName, cItemCodeBins, nLineID_Ref, nNumOC, 0, cLoteOrigen,"",0,"");

                            //////////////////////////////////////
                            // Ahora lo creo con el nuevo valor

                            Application.DoEvents();
                            t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 1 (2)...";
                            Application.DoEvents();

                            mensaje = clsRomana.SAPB1_ROMANA2(nId_Romana, nLineID_Ref, cCardCode, cCardName, cItemCode, cItemName, cItemCodeBins, nCantBins_Ref, nNumOC, 0, cLoteOrigen, cCodigo_CSG, nLineNumOC,"");

                            //////////////////////////////////////
                            // Genero la Entrada de mercaderia

                            Application.DoEvents();
                            t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 2 (3)...";
                            Application.DoEvents();

                        }

                    }

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 2 (3)...";
                    Application.DoEvents();

                    string UsuarioSap, ClaveSap;
                    string cErrorMensaje;

                    try
                    {
                        UsuarioSap = VariablesGlobales.glb_User_Code;
                    }
                    catch
                    {
                        UsuarioSap = "";
                    }

                    try
                    {
                        ClaveSap = VariablesGlobales.glb_User_Psw;
                    }
                    catch
                    {
                        ClaveSap = "";
                    }

                    cErrorMensaje = "";

                    cTipoLote = "0";

                    switch (nU_COMPRAPRODUCTOR)
                    {
                        case 0: // No Aplica
                            cTipoLote = "6"; //No Asginado
                            break;

                        case 1: // Normal
                            cTipoLote = "3"; //Minimo Garantizado
                            break;

                        case 2: // Compra a Firme
                            cTipoLote = "2"; //Compra a Firme
                            break;

                        case 3: // Servicio 
                            cTipoLote = "7"; //Servicio 
                            break;
                    }

                    if (cConductor.Length > 30)
                    {
                        cConductor = cConductor.Substring(0, 30);
                    }

                    //nNumGuia = Convert.ToInt32(cLoteOrigen);
                    nNumGuia = Convert.ToInt32(t_num_guia.Text);

                    mensaje = clsRecepcion.Entrada_Mercaderia(cCardCode, cCardName, cItemCode, nNumGuia, cPatente, cConductor, dt.ToString("yyyyMMdd"), float.Parse(nPesoNeto.ToString()), "", float.Parse(nPesoGuia.ToString()), cWareHouse, nPrecioXUnidad, nPurchaseOrder, nBaseLineNum, nLote, nCantidadBins - nCantidadBinsVacios, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "GI", cCodigo_CSG,"");

                    if (mensaje == "Error de Conexión")
                    {
                        mensaje = clsRecepcion.Entrada_Mercaderia(cCardCode, cCardName, cItemCode, nNumGuia, cPatente, cConductor, dt.ToString("yyyyMMdd"), float.Parse(nPesoNeto.ToString()), "", float.Parse(nPesoGuia.ToString()), cWareHouse, nPrecioXUnidad, nPurchaseOrder, nBaseLineNum, nLote, nCantidadBins - nCantidadBinsVacios, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "GI", cCodigo_CSG,"");

                    }

                    try
                    {
                        nEntradaMercaderiaEntry = int.Parse(mensaje);
                        cErrorMensaje = "";

                    }
                    catch
                    {
                        nEntradaMercaderiaEntry = 0;
                        cErrorMensaje = mensaje;

                        MessageBox.Show("Error en la generación de la entrada de mercancía :::::: " + cErrorMensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (nEntradaMercaderiaEntry > 0)
                    {
                        for (int x = 0; x <= Grid3.RowCount - 1; x++)
                        {
                            try
                            {
                                nLineID_Ref = Convert.ToInt32(Grid3[0, x].Value.ToString());
                            }
                            catch
                            {
                                nLineID_Ref = 0;
                            }

                            try
                            {
                                cOC_Ref = Grid3[2, x].Value.ToString();
                            }
                            catch
                            {
                                cOC_Ref = "";
                            }

                            if (nNumOC == Convert.ToInt32(cOC_Ref))
                            {
                                mensaje = clsRomana.SAPB1_ROMANA4v1(nNumGuia, nLineID_Ref, nEntradaMercaderiaEntry);

                                Application.DoEvents();
                                t_mensaje.Text = "Grabación de registro - Romamna 1 Ref//, Proceso 1 (2.2)...";
                                Application.DoEvents();

                            }

                        }

                    }

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Entrada de Mercancía " + nEntradaMercaderiaEntry.ToString() + " (4)...";
                    Application.DoEvents();

                    if (nEntradaMercaderiaEntry == 0)
                    {
                        //////////////////////////////////////
                        // Consulto el DocEntry Generado

                        try
                        {
                            nMes = int.Parse(dt.ToString("MM"));

                        }
                        catch
                        {
                            nMes = 0;

                        }

                        try
                        {
                            nAnho = int.Parse(dt.ToString("yyyy"));

                        }
                        catch
                        {
                            nAnho = 0;
                        }

                        objproducto1.cls_Consulta_Max_EntradaMercaderia(cCardCode, nMes, nAnho);

                        DataTable dTable2 = new DataTable();
                        dTable2 = objproducto1.cResultado;

                        try
                        {
                            nEntradaMercaderiaEntry = int.Parse(dTable2.Rows[0]["DocEntry"].ToString());

                        }
                        catch
                        {
                            nEntradaMercaderiaEntry = 0;

                        }

                    }

                    //////////////////////////////////////
                    // Corrigo el AbsEntry 

                    mensaje = clsRecepcion.SAPB1_RECEPCION3(nEntradaMercaderiaEntry, 20);

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Corrigo AbsEntry " + nEntradaMercaderiaEntry.ToString() + " (5)...";
                    Application.DoEvents();

                    //////////////////////////////////////
                    // Obtengo el Nro de Lote

                    //clsRecepcion objproducto1 = new clsRecepcion();
                    objproducto1.cls_Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(nEntradaMercaderiaEntry, 0);

                    DataTable dTable8 = new DataTable();
                    dTable8 = objproducto1.cResultado;

                    try
                    {
                        cDistNumber = dTable8.Rows[0]["Lote"].ToString();

                    }
                    catch
                    {
                        cDistNumber = "";

                    }

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Recupero Lote " + cDistNumber + " (6)...";
                    Application.DoEvents();

                    //////////////////////////////////////////////////////////
                    // Dejo el inventario en Cero siempre que sea fruta propia

                    string cTipoProducto;

                    cTipoProducto = "";

                    if (cItemCode != "")
                    {
                        try
                        {
                            cTipoProducto = cItemCode.Substring(0, 2);
                        }
                        catch
                        {
                            cTipoProducto = "";
                        }

                        if (cTipoProducto == "FP")
                        {
                            Application.DoEvents();
                            t_mensaje.Text = "Grabación de registro - Revalorización de Inventario (7)...";
                            Application.DoEvents();

                            mensaje = "";

                            try
                            {
                                mensaje = clsProductos.Revalorizacion_Inventario(dt.ToString("yyyyMMdd"), cItemCode, UsuarioSap, ClaveSap, "52-" + t_num_guia.Text);

                            }
                            catch
                            {

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                try
                                {
                                    mensaje = clsProductos.Revalorizacion_Inventario(dt.ToString("yyyyMMdd"), cItemCode, UsuarioSap, ClaveSap, "52-" + t_num_guia.Text);

                                }
                                catch
                                {

                                }

                            }

                        }

                    }

                    Application.DoEvents();

                    ////////////////////////////////////////
                    ////////////////////////////////////////
                    // Obtengo la cantidad de contramuestra 
                    // y descuento los x kilos para calidad

                    clsCalidad objproducto7 = new clsCalidad();
                    //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
                    objproducto7.cls_Consulta_Atributos_por_producto(cItemCode, "%");

                    DataTable dTable7 = new DataTable();
                    dTable7 = objproducto7.cResultado;

                    cContraMuestra = "";
                    nContraMuestra = 0;

                    try
                    {
                        cContraMuestra = dTable7.Rows[0]["U_ContraMu"].ToString();
                    }
                    catch
                    {
                        cContraMuestra = "";
                    }

                    //try
                    //{
                    //    nContraMuestra = Convert.ToDouble(dTable7.Rows[0]["U_CoMuSize"].ToString());
                    //}
                    //catch
                    //{
                    //    nContraMuestra = 0;
                    //}

                    try
                    {
                        nContraMuestra = Convert.ToDouble(dTable7.Rows[0]["Contra_Muestra"].ToString());
                    }
                    catch
                    {
                        nContraMuestra = 0;
                    }

                    if (nPesoNeto > nContraMuestra)
                    {
                        if (cContraMuestra == "Y")
                        {
                            if (nContraMuestra > 0)
                            {
                                if (cDistNumber != "")
                                {
                                    d_arrDetalleBins[1, 0] = cItemCode;
                                    d_arrDetalleBins[2, 0] = nContraMuestra.ToString();
                                    d_arrDetalleBins[3, 0] = cWareHouse;
                                    d_arrDetalleBins[4, 0] = "LABCC"; // Almacen Destino
                                    d_arrDetalleBins[5, 0] = "0";
                                    d_arrDetalleBins[6, 0] = cDistNumber; // lote

                                    mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                                    if (mensaje == "Error de Conexión")
                                    {
                                        mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                                    }

                                    try
                                    {
                                        nStockTransferEntry = int.Parse(mensaje);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        nStockTransferEntry = 0;

                                    }

                                    //////////////////////////////////////
                                    //////////////////////////////////////

                                    Application.DoEvents();
                                    t_mensaje.Text = "Grabación de registro - Transferencia de Lotes " + nStockTransferEntry.ToString() + " (7)...";
                                    Application.DoEvents();

                                    //////////////////////////////////////
                                    //////////////////////////////////////
                                    // Genero la referencia con la transferencia con los bins

                                    //mensaje = clsRecepcion.SAPB1_Recepcion2(nDocEntry, 0, nCantidadContraMuestra, nStockTransferEntry, "HDV_ORCAL", 0);

                                }

                            }

                        }

                    }

                    //////////////////////////////////////
                    //////////////////////////////////////
                    // Genero la referencia con la Entrada de mercaderia

                    mensaje = clsRecepcion.SAPB1_Recepcion1(nRomanaEntry, nLineId, cCardCode, cCardName, cItemCode, cItemName, float.Parse(nPesoNeto.ToString()), nEntradaMercaderiaEntry, cWareHouse, CardCode_Serv, CardName_Serv);

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Genero referencia de entrada (8)...";
                    Application.DoEvents();

                    //////////////////////////////////////////////
                    // Genero la devolución de los lotes de secado

                    t_mensaje.Text = "Genero Devolución al Productor (3)";
                    Application.DoEvents();
                    Application.DoEvents();

                    string cCardCode_devol, cCardName_devol, cItemCode_devol;
                    string cAlmacen_devol;

                    float Quantity_devol;
                    int CantBins_devol, OF_devol, TR_devol;

                    for (int x = 0; x <= Grid3.RowCount - 1; x++)
                    {
                        try
                        {
                            nLineID_Ref = Convert.ToInt32(Grid3[0, x].Value.ToString());
                        }
                        catch
                        {
                            nLineID_Ref = 0;
                        }

                        try
                        {
                            cOC_Ref = Grid3[2, x].Value.ToString();
                        }
                        catch
                        {
                            cOC_Ref = "";
                        }

                        try
                        {
                            nCantBins_Ref = Convert.ToInt32(Grid3[8, x].Value.ToString());
                        }
                        catch
                        {
                            nCantBins_Ref = 0;
                        }

                        try
                        {
                            cLoteOrigen = Grid3[24, x].Value.ToString();
                        }
                        catch
                        {
                            cLoteOrigen = "";
                        }

                        if (nNumOC == Convert.ToInt32(cOC_Ref))
                        {

                            clsCalidad objproducto9 = new clsCalidad();
                            objproducto9.cls_Consulta_romana9(cLoteOrigen, nNumGuia);

                            DataTable dTable9 = new DataTable();
                            dTable9 = objproducto9.cResultado;

                            cCardCode_devol = "";
                            cCardName_devol = "";
                            cItemCode_devol = "";
                            Quantity_devol = 0;
                            cAlmacen_devol = "";
                            CantBins_devol = 0;
                            OF_devol = 0;
                            TR_devol = 0;

                            try
                            {
                                cCardCode_devol = dTable9.Rows[0]["CardCode"].ToString();
                            }
                            catch
                            {
                                cCardCode_devol = "";
                            }

                            try
                            {
                                cCardName_devol = dTable9.Rows[0]["CardName"].ToString();
                            }
                            catch
                            {
                                cCardName_devol = "";
                            }

                            try
                            {
                                cItemCode_devol = dTable9.Rows[0]["ItemCode"].ToString();
                            }
                            catch
                            {
                                cItemCode_devol = "";
                            }

                            try
                            {
                                Quantity_devol = float.Parse(dTable9.Rows[0]["Peso_Romana"].ToString());
                            }
                            catch
                            {
                                Quantity_devol = 0;
                            }

                            //Quantity_devol = float.Parse(nPesoNeto.ToString());

                            try
                            {
                                cAlmacen_devol = dTable9.Rows[0]["BodProceso"].ToString();
                            }
                            catch
                            {
                                cAlmacen_devol = "";
                            }

                            try
                            {
                                CantBins_devol = Convert.ToInt32(dTable9.Rows[0]["Bins_Romana"].ToString());
                            }
                            catch
                            {
                                CantBins_devol = 0;
                            }

                            try
                            {
                                OF_devol = Convert.ToInt32(dTable9.Rows[0]["OrdenAfecta"].ToString());
                            }
                            catch
                            {
                                OF_devol = 0;
                            }

                            try
                            {
                                TR_devol = Convert.ToInt32(dTable9.Rows[0]["NumeroDocto"].ToString());
                            }
                            catch
                            {
                                TR_devol = 0;
                            }

                            try
                            {
                                //mensaje = clsRecepcion.Devolucion_Mercaderia(cCardCode_devol, cCardName_devol, cItemCode_devol, 0, "", "", dt.ToString("yyyyMMdd"), Quantity_devol, "", 0, cAlmacen_devol, 0, 0, 0, Convert.ToInt32(cLoteOrigen), CantBins_devol, "", "", "6", UsuarioSap, ClaveSap, "Devol. Proceso Secado - OF:" + OF_devol.ToString() + " - TR:" + TR_devol.ToString());

                            }
                            catch
                            {

                            }

                        }

                    }

                }

            }

            //////////////////////////////////////////
            //////////////////////////////////////////
            // Marco el pesaje de romana como Recibido

            int nLineId_Romana;

            nLineId_Romana = -1;

            try
            {
                nLineId_Romana = cbb_romana.SelectedIndex;

            }
            catch
            {
                nLineId_Romana = -1;

            }

            if (nLineId_Romana != -1)
            {
                mensaje = clsRomana.SAPB1_ROMANA4(nId_Romana, nLineId_Romana);

            }

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            btn_recibir.Enabled = false;
            t_mensaje.Visible = false;
            t_mensaje.Clear();

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            //////////////////////////////////////////
            // Cargo la pantalla

            VariablesGlobales.glb_Referencia1 = "F";
            frmRecepcionMPC1_Load(sender, e);

            //////////////////////////////////////////
            // Marco el pesaje de romana como Recibido

            try
            {
                button4_Click(sender, e);

            }
            catch
            {

            }

            MessageBox.Show("Registros Grabados con Exito", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Array1 = new int[200];
            VariablesGlobales.glb_Array2 = new string[200];
            VariablesGlobales.glb_Array3 = new string[200];
            VariablesGlobales.glb_Array4 = new string[200];
            VariablesGlobales.glb_Array5 = new string[200];
            VariablesGlobales.glb_Array6 = new int[200];

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int id_romana, fila, nNumOC;
            int nLineId, nCantBins, id_como_peso_romana;
            string cItemCodeBins, cEstadoItem;

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

            nLineId = 0;
            nNumOC = 0;
            cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, fila].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem == "X")
            {
                MessageBox.Show("El Registro seleccionar ya fue ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (fila >= 0)
            {
                try
                {
                    nNumOC = Convert.ToInt32(Grid1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;
                }

            }

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                id_romana = 0;

            }

            try
            {
                id_como_peso_romana = cbb_romana.SelectedIndex;
            }
            catch
            {
                id_como_peso_romana = -1;
            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            VariablesGlobales.glb_NumOC = Grid1[2, fila].Value.ToString();
            VariablesGlobales.glb_CardCode = Grid1[3, fila].Value.ToString();
            VariablesGlobales.glb_CardName = Grid1[4, fila].Value.ToString();
            VariablesGlobales.glb_ItemCode = Grid1[5, fila].Value.ToString();
            VariablesGlobales.glb_ItemName = Grid1[6, fila].Value.ToString();
            VariablesGlobales.glb_Almacen = Grid1[11, fila].Value.ToString();

            nCantBins = 0;
            cItemCodeBins = "";

            try
            {
                cItemCodeBins = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cItemCodeBins = "";
            }

            try
            {
                nCantBins = Convert.ToInt32(Grid1[8, fila].Value);
            }
            catch
            {
                nCantBins = 0;
            }

            VariablesGlobales.glb_Array1_ind = 0;

            int nIndice = 0;
            int nMaximo = -1;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                try
                {
                    nIndice = Convert.ToInt32(Grid2[0, i].Value);

                }
                catch
                {
                    nIndice = -1;
                }

                if (nIndice == nLineId)
                {
                    nMaximo += 1;

                    VariablesGlobales.glb_Array1[nMaximo] = Convert.ToInt32(Grid2[1, i].Value);
                    VariablesGlobales.glb_Array2[nMaximo] = Grid2[2, i].Value.ToString();
                    VariablesGlobales.glb_Array3[nMaximo] = Grid2[3, i].Value.ToString();
                    VariablesGlobales.glb_Array4[nMaximo] = Grid2[4, i].Value.ToString();
                    VariablesGlobales.glb_Array5[nMaximo] = "";

                }

            }

            if (nMaximo == -1)
            {
                nMaximo = 0;

                VariablesGlobales.glb_Array1[nMaximo] = nCantBins;
                VariablesGlobales.glb_Array2[nMaximo] = cItemCodeBins;
                VariablesGlobales.glb_Array3[nMaximo] = "B_PRODUC";
                VariablesGlobales.glb_Array4[nMaximo] = "PAI_BINS";
                VariablesGlobales.glb_Array5[nMaximo] = "";

            }

            VariablesGlobales.glb_Array1_ind = nMaximo;

            frmRecepcionMP8 f2 = new frmRecepcionMP8();
            DialogResult res = f2.ShowDialog();

            carga_datos_x_id();

            if (id_como_peso_romana >= 0)
            {
                cbb_romana.SelectedIndex = id_como_peso_romana;

                cbb_romana_SelectedIndexChanged(sender, e);

            }

            //////////////////////////////////////////
            // Marco el pesaje de romana como Recibido

            //int nLote_F;
            ////string mensaje_F;

            //string UsuarioSap_F, ClaveSap_F, mensaje;

            //try
            //{
            //    UsuarioSap_F = VariablesGlobales.glb_User_Code;
            //}
            //catch
            //{
            //    UsuarioSap_F = "";
            //}

            //try
            //{
            //    ClaveSap_F = VariablesGlobales.glb_User_Psw;
            //}
            //catch
            //{
            //    ClaveSap_F = "";
            //}

            //for (int i = 0; i <= Grid1.RowCount - 1; i++)
            //{

            //    try
            //    {
            //        nLote_F = int.Parse(Grid1[20, i].Value.ToString());
            //    }
            //    catch
            //    {
            //        nLote_F = 0;
            //    }

            //    if (nLote_F > 0)
            //    {
            //        mensaje = clsRecepcion.CambiaStatus_Lote(nLote_F, 1, UsuarioSap_F, ClaveSap_F);

            //    }


            //}

            if (VariablesGlobales.glb_CardCode == "__")
            {
                return;

            }

        }

        private void cbb_romana_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nDocEntry, nLineId;

            nDocEntry = -1;

            try
            {
                nDocEntry = int.Parse(t_id_romana.Text);

            }
            catch
            {
                nDocEntry = 0;
            }

            nLineId = -1;

            try
            {
                nLineId = int.Parse(cbb_romana.SelectedValue.ToString());

            }
            catch
            {
                nLineId = -1;

            }

            t_peso_neto.Clear();
            t_peso_bruto.Clear();
            t_tara.Clear();
            t_peso_neto1.Clear();

            if (nLineId >= 0)
            {

                double nPesoNeto, nPesoBruto, nTara;

                clsRecepcion objproducto = new clsRecepcion();
                objproducto.cls_Consulta_Pesos_x_Guia_Detalle(nDocEntry, nLineId);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                nPesoNeto = 0;
                nPesoBruto = 0;
                nTara = 0;

                try
                {
                    nPesoNeto = Convert.ToDouble(dTable.Rows[0]["U_PesoNeto"].ToString());

                }
                catch
                {
                    nPesoNeto = 0;

                }

                try
                {
                    nPesoBruto = Convert.ToDouble(dTable.Rows[0]["U_PesoBruto"].ToString());

                }
                catch
                {
                    nPesoBruto = 0;

                }

                try
                {
                    nTara = Convert.ToDouble(dTable.Rows[0]["U_PesoTara"].ToString());

                }
                catch
                {
                    nTara = 0;

                }

                t_peso_neto.Text = nPesoNeto.ToString("N2");
                t_peso_neto1.Text = nPesoNeto.ToString("N2");
                t_peso_bruto.Text = nPesoBruto.ToString("N2");
                t_tara.Text = nTara.ToString("N2");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cSupervisor = "NO";

            VariablesGlobales.glb_User_Code_Autorizacion = "";

            frmLoginSupervisor f5 = new frmLoginSupervisor();
            DialogResult res5 = f5.ShowDialog();

            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
            {
                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                }
                catch
                {
                    cSupervisor = "NO";

                }

            }

            if (cSupervisor == "NO")
            {
                return;
            }

            VariablesGlobales.glb_Array1 = new int[200];
            VariablesGlobales.glb_Array2 = new string[200];
            VariablesGlobales.glb_Array3 = new string[200];
            VariablesGlobales.glb_Array4 = new string[200];
            VariablesGlobales.glb_Array5 = new string[200];
            VariablesGlobales.glb_Array6 = new int[200];

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int id_romana, fila, nNumOC;
            int nLineId, nCantBins, id_como_peso_romana;
            string cItemCodeBins, cEstadoItem;

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

            nLineId = 0;
            nNumOC = 0;
            cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, fila].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem == "X")
            {
                MessageBox.Show("El Registro seleccionar ya fue ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (fila >= 0)
            {
                try
                {
                    nNumOC = Convert.ToInt32(Grid1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;
                }

            }

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                id_romana = 0;

            }

            try
            {
                id_como_peso_romana = cbb_romana.SelectedIndex;
            }
            catch
            {
                id_como_peso_romana = -1;
            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            VariablesGlobales.glb_NumOC = Grid1[2, fila].Value.ToString();
            VariablesGlobales.glb_CardCode = Grid1[3, fila].Value.ToString();
            VariablesGlobales.glb_CardName = Grid1[4, fila].Value.ToString();
            VariablesGlobales.glb_ItemCode = Grid1[25, fila].Value.ToString();
            VariablesGlobales.glb_ItemName = Grid1[6, fila].Value.ToString();
            VariablesGlobales.glb_Almacen = Grid1[11, fila].Value.ToString();
            VariablesGlobales.glb_Codigo_CSG = Grid1[5, fila].Value.ToString();
            VariablesGlobales.glb_LineNumOF = Convert.ToInt32(Grid1[26, fila].Value.ToString());

            nCantBins = 0;
            cItemCodeBins = "";

            try
            {
                cItemCodeBins = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cItemCodeBins = "";
            }

            try
            {
                nCantBins = Convert.ToInt32(Grid1[8, fila].Value);
            }
            catch
            {
                nCantBins = 0;
            }

            VariablesGlobales.glb_Array1_ind = 0;

            int nIndice = 0;
            int nMaximo = -1;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                try
                {
                    nIndice = Convert.ToInt32(Grid2[0, i].Value);

                }
                catch
                {
                    nIndice = -1;
                }

                if (nIndice == nLineId)
                {
                    nMaximo += 1;

                    VariablesGlobales.glb_Array1[nMaximo] = Convert.ToInt32(Grid2[1, i].Value);
                    VariablesGlobales.glb_Array2[nMaximo] = Grid2[2, i].Value.ToString();
                    VariablesGlobales.glb_Array3[nMaximo] = Grid2[3, i].Value.ToString();
                    VariablesGlobales.glb_Array4[nMaximo] = Grid2[4, i].Value.ToString();
                    VariablesGlobales.glb_Array5[nMaximo] = "";

                }

            }

            if (nMaximo == -1)
            {
                nMaximo = 0;

                VariablesGlobales.glb_Array1[nMaximo] = nCantBins;
                VariablesGlobales.glb_Array2[nMaximo] = cItemCodeBins;
                VariablesGlobales.glb_Array3[nMaximo] = "B_PRODUC";
                VariablesGlobales.glb_Array4[nMaximo] = "PAI_BINS";
                VariablesGlobales.glb_Array5[nMaximo] = "";

            }

            //////////////////////////////////
            //////////////////////////////////

            int nLinea;

            VariablesGlobales.glb_Array7 = new string[100, 100];

            for (int i = 0; i <= 99; i++)
            {
                VariablesGlobales.glb_Array7[0, i] = "";

            }

            VariablesGlobales.glb_Array7_ind = -1;

            nLinea = 0;

            for (int x = 0; x <= Grid3.RowCount - 1; x++)
            {

                for (int z = 0; z <= 21; z++)
                {
                    if (z != 2)
                    {
                        VariablesGlobales.glb_Array7[z, x] = Grid3[z, x].Value.ToString();

                    }

                }

                nLinea = x;

            }

            VariablesGlobales.glb_Array7_ind = nLinea;

            //////////////////////////////////
            //////////////////////////////////

            VariablesGlobales.glb_Array1_ind = nMaximo;

            frmRecepcionMPC3 f2 = new frmRecepcionMPC3();
            DialogResult res = f2.ShowDialog();

            frmRecepcionMPC1_Load(sender, e);
            //carga_datos_x_id();

            if (id_como_peso_romana >= 0)
            {
                cbb_romana.SelectedIndex = id_como_peso_romana;

                cbb_romana_SelectedIndexChanged(sender, e);

            }

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nEntMercaderia, nTransfStock;

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

            nEntMercaderia = 0;
            nTransfStock = 0;

            if (fila >= 0)
            {
                try
                {
                    nEntMercaderia = Convert.ToInt32(Grid1[19, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nEntMercaderia = 0;

                }

                try
                {
                    nTransfStock = Convert.ToInt32(Grid1[21, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nTransfStock = 0;
                }

                if (nEntMercaderia == 0)
                {
                    MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nTransfStock == 0)
                {
                    //MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                VariablesGlobales.glb_Referencia1 = nEntMercaderia.ToString();
                VariablesGlobales.glb_Referencia2 = nTransfStock.ToString();

                frmRecepcionMP5 f2 = new frmRecepcionMP5();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_Referencia1 = "";
                VariablesGlobales.glb_Referencia2 = "";

            }

        }

        private void btn_ver_guias_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int id_romana, fila, nLineId;
            string cEstadoItem;

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

            nLineId = 0;
            cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, fila].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem != "X")
            {
                MessageBox.Show("El Registro seleccionar no ha sido ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

            }
            catch
            {
                nLineId = 0;
            }

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                id_romana = 0;

            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            frmRecepcionMP3 f2 = new frmRecepcionMP3();
            DialogResult res = f2.ShowDialog();

        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nEntMercaderia, nTransfStock;

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

            nEntMercaderia = 0;
            nTransfStock = 0;

            if (fila >= 0)
            {
                try
                {
                    nEntMercaderia = Convert.ToInt32(Grid1[19, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nEntMercaderia = 0;

                }

                nTransfStock = 0;

                if (nEntMercaderia == 0)
                {
                    MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nTransfStock == 0)
                {
                    //MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                VariablesGlobales.glb_Referencia1 = nEntMercaderia.ToString();
                VariablesGlobales.glb_Referencia2 = nTransfStock.ToString();

                FRP01 f2 = new FRP01();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_Referencia1 = "";
                VariablesGlobales.glb_Referencia2 = "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, 0].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem != "X")
            {
                //MessageBox.Show("El Registro aun no ha sido ingresado, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result;
            //result = MessageBox.Show("Esta Seguro de Generar la Devolución", "Recepción de Matería Prima", buttons);
            //if (result == System.Windows.Forms.DialogResult.No)
            //{
                //return;
            //}

            int nNumOC;

            DateTime dt;

            dt = DateTime.Now;

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //  
            // Comienzo el proceso de grabación 
            //  
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            int nNumGuia;

            string mensaje, cLoteOrigen;

            string[,] d_arrDetalleBins = new string[20, 20];

            for (int i = 0; i <= 19; i++)
            {
                d_arrDetalleBins[i, 1] = "";

            }

            /////////////////////////////////////////////////////
            // Levanto el Splash para que el usuario espeeeeeeere

            Splash sp = new Splash();
            sp.ShowDialog();

            t_mensaje.Visible = true;
            Application.DoEvents();

            /////////////////////////////////////////////////////

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            try
            {
                nNumGuia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                nNumGuia = 0;
            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC = Convert.ToInt32(Grid1[2, i].Value.ToString());
                }
                catch
                {
                    nNumOC = 0;
                }

                if (nNumOC > 0)
                {

                    /////////////////////////////////////////
                    /////////////////////////////////////////
                    /// Determino el precio de costo OC

                    int nCantBins_Ref, nLineID_Ref;
                    string cOC_Ref;

                    Application.DoEvents();
                    t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 2 (3)...";
                    Application.DoEvents();

                    string UsuarioSap, ClaveSap;

                    try
                    {
                        UsuarioSap = VariablesGlobales.glb_User_Code;
                    }
                    catch
                    {
                        UsuarioSap = "";
                    }

                    try
                    {
                        ClaveSap = VariablesGlobales.glb_User_Psw;
                    }
                    catch
                    {
                        ClaveSap = "";
                    }

                    Application.DoEvents();

                    //////////////////////////////////////////////
                    // Genero la devolución de los lotes de secado

                    t_mensaje.Text = "Genero Devolución al Productor (3)";
                    Application.DoEvents();
                    Application.DoEvents();

                    string cCardCode_devol, cCardName_devol, cItemCode_devol;
                    string cAlmacen_devol;

                    float Quantity_devol;
                    int CantBins_devol, OF_devol, TR_devol;
                    int nNew_DocEntry_Devol; 

                    for (int x = 0; x <= Grid3.RowCount - 1; x++)
                    {
                        try
                        {
                            nLineID_Ref = Convert.ToInt32(Grid3[0, x].Value.ToString());
                        }
                        catch
                        {
                            nLineID_Ref = 0;
                        }

                        try
                        {
                            cOC_Ref = Grid3[2, x].Value.ToString();
                        }
                        catch
                        {
                            cOC_Ref = "";
                        }

                        try
                        {
                            nCantBins_Ref = Convert.ToInt32(Grid3[8, x].Value.ToString());
                        }
                        catch
                        {
                            nCantBins_Ref = 0;
                        }

                        try
                        {
                            cLoteOrigen = Grid3[24, x].Value.ToString();
                        }
                        catch
                        {
                            cLoteOrigen = "";
                        }

                        if (nNumOC == Convert.ToInt32(cOC_Ref))
                        {

                            t_tara.Text = cLoteOrigen;

                            clsCalidad objproducto9 = new clsCalidad();
                            objproducto9.cls_Consulta_romana9(cLoteOrigen, nNumGuia);

                            DataTable dTable9 = new DataTable();
                            dTable9 = objproducto9.cResultado;

                            cCardCode_devol = "";
                            cCardName_devol = "";
                            cItemCode_devol = "";
                            Quantity_devol = 0;
                            cAlmacen_devol = "";
                            CantBins_devol = 0;
                            OF_devol = 0;
                            TR_devol = 0;

                            try
                            {
                                cCardCode_devol = dTable9.Rows[0]["CardCode"].ToString();
                            }
                            catch
                            {
                                cCardCode_devol = "";
                            }

                            try
                            {
                                cCardName_devol = dTable9.Rows[0]["CardName"].ToString();
                            }
                            catch
                            {
                                cCardName_devol = "";
                            }

                            try
                            {
                                cItemCode_devol = dTable9.Rows[0]["ItemCode"].ToString();
                            }
                            catch
                            {
                                cItemCode_devol = "";
                            }

                            try
                            {
                                Quantity_devol = float.Parse(dTable9.Rows[0]["Peso_Romana"].ToString());
                            }
                            catch
                            {
                                Quantity_devol = 0;
                            }

                            //Quantity_devol = float.Parse(nPesoNeto.ToString());

                            try
                            {
                                cAlmacen_devol = dTable9.Rows[0]["BodProceso"].ToString();
                            }
                            catch
                            {
                                cAlmacen_devol = "";
                            }

                            try
                            {
                                CantBins_devol = Convert.ToInt32(dTable9.Rows[0]["Bins_Romana"].ToString());
                            }
                            catch
                            {
                                CantBins_devol = 0;
                            }

                            try
                            {
                                OF_devol = Convert.ToInt32(dTable9.Rows[0]["OrdenAfecta"].ToString());
                            }
                            catch
                            {
                                OF_devol = 0;
                            }

                            try
                            {
                                TR_devol = Convert.ToInt32(dTable9.Rows[0]["NumeroDocto"].ToString());
                            }
                            catch
                            {
                                TR_devol = 0;
                            }

                            mensaje = "";

                            try
                            {
                                mensaje = clsRecepcion.Devolucion_Mercaderia(cCardCode_devol, cCardName_devol, cItemCode_devol, 0, "", "", dt.ToString("yyyyMMdd"), Quantity_devol, "", 0, cAlmacen_devol, 0, 0, 0, Convert.ToInt32(cLoteOrigen), CantBins_devol, "", "", "6", UsuarioSap, ClaveSap, "Devol. Proceso Secado - OF:" + OF_devol.ToString() + " - TR:" + TR_devol.ToString());

                            }
                            catch
                            {

                            }

                            clsRecepcion objproducto10 = new clsRecepcion();
                            objproducto10.cls_Consulta_max_devolucion();

                            DataTable dTable10 = new DataTable();
                            dTable10 = objproducto10.cResultado;

                            nNew_DocEntry_Devol = 0;

                            try
                            {
                                nNew_DocEntry_Devol = Convert.ToInt32(dTable10.Rows[0]["DocEntry"].ToString());

                            }
                            catch
                            {
                                nNew_DocEntry_Devol = 0;

                            }

                            t_peso_bruto.Text = nNew_DocEntry_Devol.ToString();

                            if (nNew_DocEntry_Devol > 0)
                            {
                                try
                                {
                                    mensaje = clsRecepcion.Devolucion_Mercaderia_Cerrar(nNew_DocEntry_Devol.ToString(), UsuarioSap, ClaveSap);

                                }
                                catch
                                {

                                }

                            }

                            t_mensaje.Text = mensaje;

                        }

                    }

                }

            }

            //////////////////////////////////////////
            //////////////////////////////////////////
            // Marco el pesaje de romana como Recibido

            btn_recibir.Enabled = false;
            //t_mensaje.Visible = false;
            //t_mensaje.Clear();

            //////////////////////////////////////////
            // Cargo la pantalla

            MessageBox.Show("Registros Grabados con Exito", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Array1 = new int[200];
            VariablesGlobales.glb_Array2 = new string[200];
            VariablesGlobales.glb_Array3 = new string[200];
            VariablesGlobales.glb_Array4 = new string[200];
            VariablesGlobales.glb_Array5 = new string[200];
            VariablesGlobales.glb_Array6 = new int[200];

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nLineId_Romana;

            nLineId_Romana = -1;

            try
            {
                nLineId_Romana = cbb_romana.SelectedIndex;

            }
            catch
            {
                nLineId_Romana = -1;

            }

            if (nLineId_Romana == -1)
            {
                MessageBox.Show("Debe seleccionar un Pesaje de Roaman válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int id_romana, fila, nNumOC;
            int nLineId, nCantBins;
            string cItemCodeBins, cEstadoItem; //, cLoteOrigen;

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

            nLineId = 0;
            nNumOC = 0;
            cEstadoItem = "";

            try
            {
                cEstadoItem = Grid1[12, fila].Value.ToString();

            }
            catch
            {
                cEstadoItem = "";

            }

            if (cEstadoItem == "X")
            {

                string cSupervisor = "NO";

                VariablesGlobales.glb_User_Code_Autorizacion = "";

                frmLoginSupervisor f5 = new frmLoginSupervisor();
                DialogResult res5 = f5.ShowDialog();

                if (VariablesGlobales.glb_User_Code_Autorizacion == "")
                {
                    MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (VariablesGlobales.glb_User_Code_Autorizacion != "")
                {

                    clsMaestros objproducto1 = new clsMaestros();
                    objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto1.cResultado;

                    try
                    {
                        cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                    }
                    catch
                    {
                        cSupervisor = "NO";

                    }

                }

                if (cSupervisor == "NO")
                {
                    return;
                }

            }

            if (fila >= 0)
            {
                try
                {
                    nNumOC = Convert.ToInt32(Grid1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;
                }

            }

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                id_romana = 0;

            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            VariablesGlobales.glb_NumOC = Grid1[2, fila].Value.ToString();
            VariablesGlobales.glb_CardCode = Grid1[3, fila].Value.ToString();
            VariablesGlobales.glb_CardName = Grid1[4, fila].Value.ToString();
            VariablesGlobales.glb_ItemCode = Grid1[25, fila].Value.ToString();
            VariablesGlobales.glb_ItemName = Grid1[6, fila].Value.ToString();
            VariablesGlobales.glb_Almacen = Grid1[23, fila].Value.ToString();
            VariablesGlobales.glb_Almacen_From = Grid1[11, fila].Value.ToString();
            VariablesGlobales.glb_Codigo_CSG = Grid1[5, fila].Value.ToString();
            VariablesGlobales.glb_LineNumOF = Convert.ToInt32(Grid1[26, fila].Value.ToString());

            nCantBins = 0;
            cItemCodeBins = "";

            try
            {
                cItemCodeBins = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cItemCodeBins = "";
            }

            try
            {
                nCantBins = Convert.ToInt32(Grid1[8, fila].Value);
            }
            catch
            {
                nCantBins = 0;
            }

            VariablesGlobales.glb_Array1_ind = 0;

            int nIndice = 0;
            int nMaximo = -1;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                try
                {
                    nIndice = Convert.ToInt32(Grid2[0, i].Value);

                }
                catch
                {
                    nIndice = -1;
                }

                if (nIndice == nLineId)
                {
                    nMaximo += 1;

                    VariablesGlobales.glb_Array1[nMaximo] = Convert.ToInt32(Grid2[1, i].Value);
                    VariablesGlobales.glb_Array2[nMaximo] = Grid2[2, i].Value.ToString();
                    VariablesGlobales.glb_Array3[nMaximo] = Grid2[3, i].Value.ToString();
                    VariablesGlobales.glb_Array4[nMaximo] = Grid2[4, i].Value.ToString();
                    VariablesGlobales.glb_Array5[nMaximo] = "";
                    VariablesGlobales.glb_Array6[nMaximo] = Convert.ToInt32(Grid2[6, i].Value);

                }

            }

            if (nMaximo == -1)
            {
                nMaximo = 0;

                VariablesGlobales.glb_Array1[nMaximo] = nCantBins;
                VariablesGlobales.glb_Array2[nMaximo] = cItemCodeBins;
                VariablesGlobales.glb_Array3[nMaximo] = "B_PRODUC";
                VariablesGlobales.glb_Array4[nMaximo] = "PAI_BINS";
                VariablesGlobales.glb_Array5[nMaximo] = "";
                VariablesGlobales.glb_Array6[nMaximo] = 0;

            }

            string cCardCode_Ori, cCardName_Ori;
            int nNumOC_Ori;

            string cCardCode_New, cCardName_New;
            int nNumOC_New;

            cCardCode_Ori = Grid1[3, fila].Value.ToString();
            cCardName_Ori = Grid1[4, fila].Value.ToString();
            nNumOC_Ori = Convert.ToInt32(Grid1[2, fila].Value.ToString());

            VariablesGlobales.glb_Array1_ind = nMaximo;

            frmRecepcionMPC2 f2 = new frmRecepcionMPC2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode == "__")
            {
                return;

            }

            Grid1[2, fila].Value = VariablesGlobales.glb_NumOC;

            Grid1[3, fila].Value = VariablesGlobales.glb_CardCode;
            Grid1[4, fila].Value = VariablesGlobales.glb_CardName;
            Grid1[5, fila].Value = VariablesGlobales.glb_Codigo_CSG;

            Grid1[25, fila].Value = VariablesGlobales.glb_ItemCode;
            Grid1[6, fila].Value = VariablesGlobales.glb_ItemName;

            Grid1[11, fila].Value = VariablesGlobales.glb_Almacen;
            Grid1[23, fila].Value = VariablesGlobales.glb_Almacen_From;

            Grid1[26, fila].Value = VariablesGlobales.glb_LineNumOF.ToString();

            nMaximo = VariablesGlobales.glb_Array1_ind;

            cCardCode_New = VariablesGlobales.glb_CardCode;
            cCardName_New = VariablesGlobales.glb_CardName;
            nNumOC_New = Convert.ToInt32(VariablesGlobales.glb_NumOC);

            int nNumOC_grid3;

            if (nNumOC_Ori != nNumOC_New)
            {

                for (int v = 0; v <= Grid3.RowCount - 1; v++)
                {

                    try
                    {
                        nNumOC_grid3 = Convert.ToInt32(Grid3[2, v].Value.ToString());
                    }
                    catch
                    {
                        nNumOC_grid3 = 0;
                    }

                    if (nNumOC_grid3 == nNumOC_Ori)
                    {
                        Grid3[2, v].Value = nNumOC_New.ToString();
                        Grid3[26, fila].Value = VariablesGlobales.glb_LineNumOF.ToString();

                    }

                }

            }

            //borra_item(nLineId);

            int nCantBins_D, nCantBinsVacios_D, nCantBins_Total;

            string[] grilla;
            grilla = new string[30];

            nCantBins_D = 0;
            nCantBinsVacios_D = 0;
            nCantBins_Total = 0;

            for (int i = 0; i <= nMaximo; i++)
            {

                grilla[0] = nLineId.ToString();

                grilla[1] = VariablesGlobales.glb_Array1[i].ToString();
                grilla[2] = VariablesGlobales.glb_Array2[i];
                grilla[3] = VariablesGlobales.glb_Array3[i];
                grilla[4] = VariablesGlobales.glb_Array4[i];
                grilla[5] = VariablesGlobales.glb_Array5[i];
                grilla[6] = VariablesGlobales.glb_Array6[i].ToString();

                Grid2.Rows.Add(grilla);

                try
                {
                    nCantBins_D = VariablesGlobales.glb_Array1[i];
                }
                catch
                {
                    nCantBins_D = 0;
                }

                try
                {
                    nCantBinsVacios_D = VariablesGlobales.glb_Array6[i];
                }
                catch
                {
                    nCantBinsVacios_D = 0;
                }

                nCantBins_Total = nCantBins_Total + (nCantBins_D + nCantBinsVacios_D);

            }

            Grid1[8, fila].Value = nCantBins_Total.ToString();
            Grid1[22, fila].Value = nCantBinsVacios_D.ToString();

            Grid1[1, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

            Grid1[12, fila].Value = "OK";

            cbb_romana.Enabled = false;

            /////////////////////////////////////////
            /// Calculo el peso por envase

            double nPesoTotalGuia, nPesoBins_D, nPesoTotal_D;
            string cConfirm;

            nPesoTotalGuia = 0;

            try
            {
                nPesoTotalGuia = Convert.ToDouble(t_peso_neto.Text);

            }
            catch
            {
                nPesoTotalGuia = 0;

            }

            nCantBins_Total = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[8, i].Value);

                }
                catch
                {
                    nCantBins_D = -1;
                }

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    if (nCantBins_D > 0)
                    {
                        nCantBins_Total += nCantBins_D;

                    }

                }

            }

            nPesoBins_D = 0;

            if (nCantBins_Total > 0)
            {
                nPesoBins_D = nPesoTotalGuia / nCantBins_Total;

            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[8, i].Value);

                }
                catch
                {
                    nCantBins_D = -1;
                }

                try
                {
                    cConfirm = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cConfirm = "";
                }

                if (cConfirm == "OK")
                {
                    if (nCantBins_D > 0)
                    {
                        nPesoTotal_D = nCantBins_D * nPesoBins_D;
                        Grid1[13, i].Value = nPesoBins_D.ToString("N2");
                        Grid1[14, i].Value = nPesoTotal_D.ToString("N2");

                    }

                }

            }

            ////////////////////////////////////////////
            // Confirmo un item con peso desde Romana
            // Des habilito la recepción manual

            button1.Enabled = false;

        }
    }

}
