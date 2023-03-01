using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmRomanaA6 : Form
    {
        public frmRomanaA6()
        {
            InitializeComponent();
        }

        private void frmRomanaA6_Load(object sender, EventArgs e)
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

            btn_nuevo_Click(sender, e);

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto.cResultado;
            my_DGVCboColumn.Name = "Tipo de Envases";
            my_DGVCboColumn.ValueMember = "ItemCode";
            my_DGVCboColumn.DisplayMember = "ItemName";

            Grid1.Columns.RemoveAt(5);
            Grid1.Columns.Insert(5, my_DGVCboColumn);
            Grid1.Columns[5].Width = 240;

            if (VariablesGlobales.glb_id_acceso != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_acceso.ToString();
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                carga_datos_x_id();

                t_num_guia.Text = VariablesGlobales.glb_id_acceso.ToString();

                btn_pesaje_entrada.Enabled = false;
                btn_pesaje_previo.Enabled = false;
                btn_graba_bruto.Enabled = false;
                btn_graba_neto.Enabled = false;

                //btn_ok.Enabled = false;

                //tsb_agrega_productor.Enabled = false;
                //tsb_define.Enabled = false;
                //tsb_eliminar.Enabled = false;

                //Grid1.Columns[5].ReadOnly = true;
                //Grid1.Columns[6].ReadOnly = true;

            }

            timer1.Enabled = true;

            float nPorcentajeDesviacion_SP, nPorcentajeDesviacion_BJ;

            clsRomana objproducto1 = new clsRomana();
            objproducto1.cls_Consulta_tabla_parametros();

            DataTable dTable = new DataTable();
            dTable = objproducto1.cResultado;

            try
            {
                nPorcentajeDesviacion_SP = float.Parse(dTable.Rows[0]["U_Por_Tolerancia_Romana"].ToString());

            }
            catch
            {
                nPorcentajeDesviacion_SP = 0;

            }

            t_porcentaje_desviacion_sp.Text = nPorcentajeDesviacion_SP.ToString("N");

            try
            {
                nPorcentajeDesviacion_BJ = float.Parse(dTable.Rows[0]["U_Por_Tolerancia_Romana2"].ToString());

            }
            catch
            {
                nPorcentajeDesviacion_BJ = 0;

            }

            t_porcentaje_desviacion_bp.Text = nPorcentajeDesviacion_BJ.ToString("N");

            try
            {
                t_de_bloqueo.Text = dTable.Rows[0]["U_Tolerancia_de_Bloqueo"].ToString();

            }
            catch
            {
                t_de_bloqueo.Text = "";

            }

            try
            {
                t_de_bloqueo2.Text = dTable.Rows[0]["U_Tolerancia_de_Bloqueo2"].ToString();

            }
            catch
            {
                t_de_bloqueo2.Text = "";

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            ///////////////////////////////////////////
            ///////////////////////////////////////////

            //t_PesoBalanza.Text = "10030";
            //return;

            t_balanza.BackColor = Color.Red;
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;

            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0;

            //int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;
            int nErr = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "COM1";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 1200;
            }

            //try
            //{
            //    //nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            //}
            //catch
            //{
            //    nBalanza_BitsDatos = 0;
            //}

            SerialPort mySerialPort = new SerialPort(cBalanza_Puerto);

            mySerialPort.BaudRate = nBalanza_Baudios;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            try
            {
                mySerialPort.Open();
                nErr = 0;
            }
            catch
            {
                nErr = 1;
            }

            if (nErr == 1)
            {
                try
                {
                    mySerialPort.Close();
                }
                catch
                {

                }

                t_PesoBalanza.Text = "E_";
                t_balanza.BackColor = Color.Empty;

                //Thread.Sleep(300);
                timer1.Enabled = true;
                return;

            }

            string b, cPack, cNumero;
            int nPeso;

            try
            {
                while (true)
                {

                    cPack = "";
                    nPeso = 0;
                    b = "";

                    try
                    {
                        b = mySerialPort.ReadExisting();
                    }
                    catch
                    {
                        b = "";
                    }

                    try
                    {
                        cPack = b.Substring(2, 1);
                    }
                    catch
                    {
                        cPack = "";
                    }

                    if (cPack == "0")
                    {
                        try
                        {
                            cNumero = b.Substring(2, 6);
                        }
                        catch
                        {
                            cNumero = "0";
                        }

                        nPeso = int.Parse(cNumero);

                    }
                    else
                    {

                    }

                    grilla[0] = i.ToString();
                    grilla[1] = b;
                    grilla[2] = nPeso.ToString();

                    Grid_Peso.Rows.Add(grilla);

                    Thread.Sleep(30);
                    i += 1;

                    if (i > 12)
                    {
                        break;
                    }

                }
            }
            catch
            {

            }

            try
            {
                //serialPort.DiscardInBuffer();
                mySerialPort.Close();
            }
            catch
            {

            }

            int nPesoBalanza, nPesoFinal;

            nPesoBalanza = 0;
            nPesoFinal = 0;

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    nPesoBalanza = int.Parse(Grid_Peso[2, j].Value.ToString());
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = nPesoBalanza;
                }

            }

            t_PesoBalanza.Text = nPesoFinal.ToString();

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza.BackColor = Color.Empty;
            timer1.Enabled = true;

        }

        private void Calcula_bins()
        {

            int total_bins, cant_unit_bins;
            int peso_tot_bins, peso_unit_bins;

            total_bins = 0;
            cant_unit_bins = 0;
            peso_tot_bins = 0;
            peso_unit_bins = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cant_unit_bins = Convert.ToInt32(Grid1[6, i].Value);

                }
                catch
                {
                    cant_unit_bins = 0;
                }

                try
                {
                    peso_unit_bins = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    peso_unit_bins = 0;
                }

                total_bins = total_bins + cant_unit_bins;
                peso_tot_bins = peso_tot_bins + (peso_unit_bins * cant_unit_bins);

            }

            t_cantidad_envases.Text = total_bins.ToString();
            t_peso_envases.Text = peso_tot_bins.ToString("N2");

        }

        private void btn_pesaje_entrada_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            t_ref_origen.Clear();

            VariablesGlobales.glb_id_acceso = 0;
            VariablesGlobales.glb_Referencia1 = "Romana";
            VariablesGlobales.glb_Razon_Ingreso = "1";

            frmRomanaA8 f2 = new frmRomanaA8();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_id_romana != 0)
            {

                t_ref_origen.Text = "PesoIngreso";
                t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                carga_datos_x_id();

                t_num_guia.Text = VariablesGlobales.glb_id_romana.ToString();

                carga_datos_x_id_2do_peso();

                t_peso_bruto.Text = "0";

                t_cardcode.ReadOnly = true;
                t_num_guia.ReadOnly = true;
                t_patente.ReadOnly = true;
                t_conductor.ReadOnly = true;

                lnk_ver_documento.Enabled = true;

                btn_graba_bruto.Enabled = true;
                btn_graba_neto.Enabled = false;

                btn_pesaje_entrada.Enabled = false;
                btn_pesaje_previo.Enabled = false;

            }

            timer1.Enabled = true;

            VariablesGlobales.glb_Referencia1 = "";

        }

        private void carga_datos_x_id_2do_peso()
        {

            int id_porteria;

            try
            {
                id_porteria = Convert.ToInt32(t_id_acceso.Text);
            }
            catch
            {
                id_porteria = 0;

            }

            if (id_porteria == 0)
            {
                return;
            }

            float peso_guia;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id_2do_peso(id_porteria);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                peso_guia = float.Parse(dTable.Rows[0]["U_PesoGuia"].ToString());

            }
            catch
            {
                peso_guia = 0;

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D, ItemCodeBins;
            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D, nCantAnalisisCalidad_Total;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nCantAnalisisCalidad_Total = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nNumOC_D = 0;
                cCardCode_D = "";
                cCardName_D = "";
                cItemCode_D = "";
                cItemName_D = "";
                nCantBins_D = 0;
                n_PesoUnitBins_D = 0;
                nCantAnalisisCalidad_D = 0;

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
                    cCardCode_D = dTable.Rows[i]["U_CardCode"].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cCardName_D = dTable.Rows[i]["U_CardName"].ToString().ToUpper();

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

                try
                {
                    cItemName_D = dTable.Rows[i]["U_ItemName"].ToString().ToUpper();

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

                try
                {
                    nCantBins_D = Convert.ToInt32(dTable.Rows[i]["U_CantidadBins"].ToString().ToUpper());

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    n_PesoUnitBins_D = Convert.ToInt32(dTable.Rows[i]["U_PesoBins"].ToString().ToUpper());
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

                nCantAnalisisCalidad_Total = nCantAnalisisCalidad_Total + nCantAnalisisCalidad_D;

                grilla[0] = nNumOC_D.ToString();
                grilla[1] = cCardCode_D.ToUpper();
                grilla[2] = cCardName_D.ToUpper();
                grilla[3] = ""; // cItemCode_D.ToUpper();
                grilla[4] = cItemName_D.ToUpper();
                grilla[5] = ItemCodeBins;
                grilla[6] = Convert.ToString(nCantBins_D);
                grilla[7] = Convert.ToString(n_PesoUnitBins_D);
                grilla[8] = Convert.ToString(nCantAnalisisCalidad_D);
                grilla[9] = cItemCode_D.ToUpper();

                Grid1.Rows.Add(grilla);

            }

            Calcula_bins();

            if (peso_guia != 0)
            {
                t_peso_guia.Text = peso_guia.ToString("N2");

            }

            t_ref.Text = "S";

            double nPesoBins_Tot;

            nPesoBins_Tot = 0;

            try
            {
                nPesoBins_Tot = Convert.ToDouble(t_peso_envases.Text);

            }
            catch
            {
                nPesoBins_Tot = 0;

            }

            if (nPesoBins_Tot > 0)
            {
                Grid1.Columns[5].ReadOnly = true;
                Grid1.Columns[6].ReadOnly = true;

            }


        }

        private void btn_pesaje_previo_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_id_romana = 0;
            VariablesGlobales.glb_LineId = 0;
            VariablesGlobales.glb_Razon_Ingreso = "2";

            frmRomanaA8 f2 = new frmRomanaA8();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_id_romana != 0)
            {
                t_ref_origen.Text = "PesoSalida";
                t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                carga_datos_x_id();

                t_num_guia.Text = VariablesGlobales.glb_id_romana.ToString();

                carga_datos_x_id_2do_peso();

                t_cardcode.ReadOnly = true;
                t_num_guia.ReadOnly = true;
                t_patente.ReadOnly = true;
                t_conductor.ReadOnly = true;

                lnk_ver_documento.Enabled = true;

                btn_graba_bruto.Enabled = false;
                btn_graba_neto.Enabled = true;

                btn_pesaje_entrada.Enabled = false;
                btn_pesaje_previo.Enabled = false;

            }

        }

        private void carga_datos_x_id()
        {

            int id_romana, nLineId;

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

            try
            {
                nLineId = int.Parse(t_Line_Id.Text);

            }
            catch
            {
                nLineId = 0;

            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor, ItemCodeBins;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia, peso_bins;
            string obs;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso;
            string CardCode_trans, CardName_trans;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            CardCode_trans = "";
            CardName_trans = "";
            ItemCodeBins = "_";
            numguia = 0;
            patente = "";
            conductor = "";
            peso_bruto = 0;
            peso_tara = 0;
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
            t_patentecarro.Clear();
            t_conductor.Clear();
            t_peso_bruto.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_cantidad_envases.Clear();
            t_observacion.Clear();
            t_fecha_1er_peso.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();
            t_CardoName_Trans.Clear();
            t_CardoCode_Trans.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, nLineId);

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
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                peso_bruto = float.Parse(dTable.Rows[0]["U_PesoBruto_Full"].ToString());

            }
            catch
            {
                peso_bruto = 0;

            }

            try
            {
                peso_tara = float.Parse(dTable.Rows[0].ItemArray[14].ToString());

            }
            catch
            {
                peso_tara = 0;

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
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());
            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");
            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[19].ToString());
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
                peso_guia = float.Parse(dTable.Rows[0]["PesoGuia_neto"].ToString());  //float.Parse(dTable.Rows[0].ItemArray[27].ToString());
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

            try
            {
                t_patentecarro.Text = dTable.Rows[0]["U_PatenteCarro"].ToString();
            }
            catch
            {
                t_patentecarro.Clear();
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D, cCodigo_CSG_D;
            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D, nCantAnalisisCalidad_Total;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nCantAnalisisCalidad_Total = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nNumOC_D = 0;
                cCardCode_D = "";
                cCardName_D = "";
                cItemCode_D = "";
                cItemName_D = "";
                nCantBins_D = 0;
                cCodigo_CSG_D = "";
                n_PesoUnitBins_D = 0;
                nCantAnalisisCalidad_D = 0;

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
                    cCardCode_D = dTable.Rows[i].ItemArray[28].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cCardName_D = dTable.Rows[i].ItemArray[29].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemCode_D = dTable.Rows[i].ItemArray[3].ToString().ToUpper();

                }
                catch
                {

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
                    ItemCodeBins = dTable.Rows[i].ItemArray[12].ToString();

                }
                catch
                {
                    ItemCodeBins = "_";

                }

                try
                {
                    nCantBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[30].ToString().ToUpper());

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    n_PesoUnitBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[32].ToString().ToUpper());
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
                    cCodigo_CSG_D = dTable.Rows[i]["U_Codigo_CSG"].ToString().ToUpper();

                }
                catch
                {

                }

                nCantAnalisisCalidad_Total = nCantAnalisisCalidad_Total + nCantAnalisisCalidad_D;

                grilla[0] = nNumOC_D.ToString();
                grilla[1] = cCardCode_D.ToUpper();
                grilla[2] = cCardName_D.ToUpper();
                grilla[3] = cCodigo_CSG_D.ToUpper();
                grilla[4] = cItemName_D.ToUpper();
                grilla[5] = ItemCodeBins;
                grilla[6] = Convert.ToString(nCantBins_D);
                grilla[7] = Convert.ToString(n_PesoUnitBins_D);
                grilla[8] = Convert.ToString(nCantAnalisisCalidad_D);
                grilla[9] = cItemCode_D.ToUpper();

                Grid1.Rows.Add(grilla);

            }

            Calcula_bins();

            //sql += "Patente 6, Envases 7, FechaPeso1 8, PesoBruto 9 ";
            //sql += "from db_ROMANA ";
            //sql += "where id_romana = " + id_romana + " ";

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_CardoName_Trans.Text = CardName_trans;
            t_CardoCode_Trans.Text = CardCode_trans;

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_peso_bruto.Text = peso_bruto.ToString("N2");
            t_tara.Clear();
            t_peso_neto.Clear();

            if (peso_tara != 0)
            {
                t_tara.Text = peso_tara.ToString("N2");

            }

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

            if (peso_guia != 0)
            {
                t_peso_guia.Text = peso_guia.ToString("N2");

            }

            if (peso_bins != 0)
            {
                t_peso_envases.Text = peso_bins.ToString("N2");

            }

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_1er_peso.Text = fecha_hora1.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            if (fecha_hora2.Year != 1900)
            {
                t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            //t_conductor.Text = conductor;
            //t_conductor.Text = conductor;
            //peso_tara = 0;
            //peso_neto = 0;

            t_ref.Text = "S";

            //cbb_envase.SelectedIndex = id_envase;
            t_cantidad_envases.Text = cant_envases.ToString();
            t_observacion.Text = obs;

            btn_graba_bruto.Enabled = false;
            btn_graba_neto.Enabled = true;
            btn_buscar1.Visible = false;
            btn_buscar2.Visible = false;

            if (peso_tara != 0)
            {
                btn_imprimir.Enabled = true;

            }

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            /////////////////////////////////////////////////////////////////
            //// Si el total de analisis es mayor que 0 no se puede modificar

            if (nCantAnalisisCalidad_Total > 0)
            {
                if (peso_neto > 0)
                {
                    btn_ok.Enabled = false;

                    Grid1.Columns[5].ReadOnly = true;
                    Grid1.Columns[6].ReadOnly = true;

                }

            }
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int num_guia;

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            if (num_guia == 0)
            {
                MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ///////////////////////////////////////////////////////////7
            // 
            // Valido los datos de la Romana **********
            // 
            // 

            string cCardCode_D, cItemCode_D, cItemCodeBis_D;
            int nCantBins_D, nCant_ItemsValidos_D, nSumaBins_D;
            int nNumOC_D;

            cCardCode_D = "";
            cItemCode_D = "";
            cItemCodeBis_D = "";
            nCantBins_D = 0;
            nCant_ItemsValidos_D = 0;
            nSumaBins_D = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC_D = Convert.ToInt32(Grid1[0, i].Value.ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                cCardCode_D = Grid1[1, i].Value.ToString().ToUpper();
                cItemCode_D = Grid1[4, i].Value.ToString().ToUpper();
                cItemCodeBis_D = Grid1[5, i].Value.ToString().ToUpper();

                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[6, i].Value);

                }
                catch
                {
                    nCantBins_D = 0;

                }

                if (cCardCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Productor válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Producto válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCodeBis_D.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un tipo de envase válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nCantBins_D == 0)
                {
                    MessageBox.Show("Debe ingresar una Cantidad de Bins válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                nSumaBins_D = nSumaBins_D + nCantBins_D;
                nCant_ItemsValidos_D = +1;

            }

            if (nCant_ItemsValidos_D == 0)
            {
                MessageBox.Show("Debe ingresar datos válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cantidad_envase != nSumaBins_D)
            {
                MessageBox.Show("La Cantidad total de Bins NO corresponde con lo definido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string CardCode, CardName; //, ItemName;
            string CardCode_trans, CardName_trans;
            string patente, conductor;
            int id_romana, id_acceso;
            int UserId;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia, peso_tot_bins;
 
            CardCode = t_cardcode.Text.Trim();
            CardName = t_cardname.Text.Trim();
            //num_pedido_compra 
            //itemcode
            //ItemName = cbb_Producto.Text.Trim();
            //num_guia;
            //cod_envase = "";
            //cantidad_envase

            patente = t_patente.Text.Trim();
            conductor = t_conductor.Text.Trim();

            CardCode_trans = t_CardoCode_Trans.Text.Trim();
            CardName_trans = t_CardoName_Trans.Text.Trim();

            UserId = VariablesGlobales.glb_User_id;

            id_romana = 0;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            peso_bruto = 0;

            try
            {
                peso_bruto = float.Parse(t_peso_bruto.Text);
            }
            catch
            {
                peso_bruto = 0;
            }

            peso_neto = 0;

            try
            {
                peso_neto = float.Parse(t_peso_neto.Text);
            }
            catch
            {
                peso_neto = 0;
            }

            peso_tara = 0;

            try
            {
                peso_tara = (float)Math.Round(float.Parse(t_tara.Text));
            }
            catch
            {
                peso_tara = 0;
            }

            peso_guia = 0;

            try
            {
                peso_guia = float.Parse(t_peso_guia.Text);
            }
            catch
            {
                peso_guia = 0;
            }

            peso_tot_bins = 0;

            try
            {
                peso_tot_bins = float.Parse(t_peso_envases.Text); 
            }
            catch
            {
                peso_tot_bins = 0;
            }

            if (peso_guia == 0)
            {
                MessageBox.Show("Debe ingresar un peso de guía válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (peso_bruto == 0)
            {
                MessageBox.Show("Debe ingresar un peso total válido para la guía, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);
            }
            catch
            {
                id_acceso = 0;
            }

            if ((id_romana > 0) && (t_ref_origen.Text == "PesoIngreso"))
            {
                DialogResult result = MessageBox.Show("Esta seguro de grabar el peso de ingreso", "Pesaje de guías de traslado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    float nPesoNetoBD;
                    string mensaje2;

                    nPesoNetoBD = 0;
                    mensaje2 = "";

                    try
                    {
                        nPesoNetoBD = float.Parse(t_peso_bruto.Text);

                    }
                    catch
                    {
                        nPesoNetoBD = 0;

                    }

                    if (nPesoNetoBD > 0)
                    {
                        mensaje2 = clsRomana.SAPB1_ROMANA3(id_romana, nPesoNetoBD, VariablesGlobales.glb_User_id);

                        MessageBox.Show("Registro Grabado", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btn_nuevo_Click(sender, e);

                    }

                }

            }

            string cExclusion_guias, cDocEntry_Exclusion;

            cExclusion_guias = "N";
            cDocEntry_Exclusion = "";

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id_exc(id_romana);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cDocEntry_Exclusion = dTable.Rows[0].ItemArray[0].ToString();

            }
            catch
            {
                cDocEntry_Exclusion = "";

            }

            if (cDocEntry_Exclusion != "")
            {
                cExclusion_guias = "S";

            }

            if ((id_romana > 0) && (t_ref_origen.Text != "PesoIngreso"))
            {

                DialogResult result = MessageBox.Show("Esta seguro de grabar el peso de ingreso", "Pesaje de guías de traslado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    float nPesoTara, nPesoNetoFinal;
                    double nPesoDesviacion, nPesoDiferencia;
                    double nPorcentajeTolerancia_sp, nPorcentajeTolerancia_bp, nPorcentajeDesviacion;

                    string mensaje3;

                    nPesoTara = 0;
                    nPesoNetoFinal = 0;
                    mensaje3 = "";
                    nPorcentajeDesviacion = 0;
                    nPesoDesviacion = 0;
                    nPorcentajeTolerancia_sp = 0; 
                    nPorcentajeTolerancia_bp = 0;

                    try
                    {
                        nPesoTara = float.Parse(t_tara.Text);

                    }
                    catch
                    {
                        nPesoTara = 0;

                    }

                    try
                    {
                        nPesoNetoFinal = float.Parse(t_peso_neto.Text);

                    }
                    catch
                    {
                        nPesoNetoFinal = 0;

                    }

                    // **************************************************
                    // **************************************************
                    // Defino la diferencia entre 1 peso
                    // Entre el peso nominal de produccion y el peso de romana

                    try
                    {
                        nPorcentajeTolerancia_sp = Convert.ToDouble(t_porcentaje_desviacion_sp.Text);

                    }
                    catch
                    {
                        nPorcentajeTolerancia_sp = 0;

                    }

                    try
                    {
                        nPorcentajeTolerancia_bp = Convert.ToDouble(t_porcentaje_desviacion_bp.Text);

                    }
                    catch
                    {
                        nPorcentajeTolerancia_bp = 0;

                    }

                    if (nPorcentajeDesviacion != 0)
                    {
                        nPesoDesviacion = Math.Round((nPesoNetoFinal) * nPorcentajeDesviacion / 100, 2);

                    }

                    nPesoDiferencia = 0;

                    if (cExclusion_guias == "N")
                    {

                        if ((nPesoNetoFinal) > peso_guia)
                        {
                            // Sobre peso

                            nPesoDiferencia = (nPesoNetoFinal) - peso_guia;

                            if (nPesoDiferencia > 0)
                            {
                                nPorcentajeDesviacion = Math.Round((nPesoDiferencia * 100) / peso_guia, 2);

                            }

                            if (nPorcentajeDesviacion > nPorcentajeTolerancia_sp)
                            {

                                ///BAJOPESO DETECTADO, 3,5% PESO PESO_GUIA_SECADO NETO DE LA GUIA DE SECADO RESPECTO PESO_ROAMANA.

                                if (t_de_bloqueo.Text == "Y")
                                {
                                    MessageBox.Show("ERROR DE VALIDACIÓN: SOBREPESO, " + nPorcentajeDesviacion.ToString("N") + "%, PESO " + peso_guia.ToString("N") + " DE LA GUIA DE SECADO RESPECTO " + nPesoNetoFinal.ToString("N") + ", opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }
                                else
                                {
                                    MessageBox.Show("ERROR DE VALIDACIÓN: SOBREPESO, " + nPorcentajeDesviacion.ToString("N") + "%, PESO " + peso_guia.ToString("N") + " DE LA GUIA DE SECADO RESPECTO " + nPesoNetoFinal.ToString("N"), "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("ALERTA DE VALIDACIÓN: El peso final de la guía tiene una diferencia con lo indicado por producción", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }

                        }
                        else
                        {
                            // Bajo de Peso

                            nPesoDiferencia = peso_guia - (nPesoNetoFinal);

                            if (nPesoDiferencia > 0)
                            {
                                nPorcentajeDesviacion = Math.Round((nPesoDiferencia * 100) / peso_guia, 2);

                            }

                            if (nPorcentajeDesviacion > nPorcentajeTolerancia_bp)
                            {

                                //SOBREPESO/BAJOPESO DETECTADO, 3,5% PESO PESO_GUIA_SECADO NETO DE LA GUIA DE SECADO RESPECTO PESO_ROAMANA.

                                if (t_de_bloqueo2.Text == "Y")
                                {
                                    MessageBox.Show("ERROR DE VALIDACIÓN: BAJOPESO, " + (nPorcentajeDesviacion * -1).ToString("N") + "%, PESO " + peso_guia.ToString("N") + " DE LA GUIA DE SECADO RESPECTO " + nPesoNetoFinal.ToString("N") + ", opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("ERROR DE VALIDACIÓN: El peso final de la guía tiene una diferencia con lo indicado por producción, contacte al administrador, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }
                                else
                                {
                                    MessageBox.Show("ERROR DE VALIDACIÓN: BAJOPESO, " + (nPorcentajeDesviacion * -1).ToString("N") + "%, PESO " + peso_guia.ToString("N") + " DE LA GUIA DE SECADO RESPECTO " + nPesoNetoFinal.ToString("N") + ", opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("ALERTA DE VALIDACIÓN: El peso final de la guía tiene una diferencia con lo indicado por producción", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }

                            }

                        }

                    }

                    if ((nPesoTara + nPesoNetoFinal) > 0)
                    {
                        mensaje3 = clsRomana.SAPB1_ROMANA5(id_romana, nPesoTara, nPesoNetoFinal, VariablesGlobales.glb_User_id);

                        MessageBox.Show("Registro Grabado", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btn_nuevo_Click(sender, e);

                    }

                }

            }

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            t_peso_tara.Clear();

            btn_pesaje_entrada.Enabled = true;
            btn_pesaje_previo.Enabled = true;
            btn_imprimir.Enabled = false;
            btn_ok.Enabled = true;

            t_cardcode.Clear();
            //btn_buscar1.Visible = true;
            t_cardname.Clear();
            //btn_buscar2.Visible = true;

            t_cardcode.ReadOnly = true;
            t_num_guia.ReadOnly = true;
            t_patente.ReadOnly = true;
            t_conductor.ReadOnly = true;

            t_num_guia.Clear();
            t_CardoName_Trans.Clear();
            t_patente.Clear();
            t_conductor.Clear();

            t_cantidad_envases.Clear();
            t_peso_bruto.Clear();
            t_fecha_1er_peso.Clear();

            t_tara.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_peso_envases.Clear();

            t_observacion.Clear();

            btn_graba_neto.Enabled = false;
            lnk_ver_documento.Enabled = false;

            t_id_acceso.Clear();
            t_ref.Clear();
            t_Line_Id.Clear();
            t_id_romana.Clear();

            t_cardcode.Focus();

            Grid1.Rows.Clear();

            Grid1.Columns[5].ReadOnly = false;
            Grid1.Columns[6].ReadOnly = false;

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            int id_romana;

            id_romana = 0;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmRomana3 f2 = new frmRomana3();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void btn_imagenes_Click(object sender, EventArgs e)
        {
            int nIdRomana;

            nIdRomana = 0;

            try
            {
                nIdRomana = int.Parse(t_id_romana.Text);

            }
            catch
            {
                nIdRomana = 0;

            }

            if (nIdRomana > 0)
            {

                VariablesGlobales.glb_id_romana1 = nIdRomana;

                frmRomana6 f2 = new frmRomana6();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_id_romana1 = 0;

            }

        }

        private void btn_graba_bruto_Click(object sender, EventArgs e)
        {
            if (t_PesoBalanza.Text == "E_")
            {
                if (VariablesGlobales.glb_User_Code.ToUpper() == "MANAGER")
                {
                    groupBox5.Visible = true;

                }

            }

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            t_peso_bruto.Text = t_PesoBalanza.Text;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_1er_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void btn_graba_neto_Click(object sender, EventArgs e)
        {
            t_peso_tara.Text = "x_x";

            if (t_PesoBalanza.Text == "E_")
            {
                if (VariablesGlobales.glb_User_Code.ToUpper() == "MANAGER")
                {
                    groupBox5.Visible = true;

                }

            }

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float peso_bruto, peso_tara, peso_neto;
            float peso_envases;

            peso_bruto = 0;
            peso_tara = 0;
            peso_neto = 0;
            peso_envases = 0;

            try
            {
                peso_bruto = float.Parse(t_peso_bruto.Text);

            }
            catch
            {
                peso_bruto = 0;
            }

            try
            {
                peso_envases = float.Parse(t_peso_envases.Text);
            }
            catch
            {
                peso_envases = 0;
            }

            t_tara.Text = t_PesoBalanza.Text;

            try
            {
                peso_tara = float.Parse(t_tara.Text);

            }
            catch
            {
                peso_tara = 0;
            }

            peso_neto = peso_bruto - peso_tara - peso_envases;

            t_peso_neto.Text = Convert.ToString(peso_neto);

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_2do_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nPesoProvisorio = 0;

            try
            {
                nPesoProvisorio = int.Parse(textBox1.Text);
            }
            catch
            {
                nPesoProvisorio = 0;
            }

            t_peso_bruto.Text = nPesoProvisorio.ToString();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_1er_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nPesoProvisorio = 0;

            try
            {
                nPesoProvisorio = int.Parse(textBox1.Text);
            }
            catch
            {
                nPesoProvisorio = 0;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float peso_bruto, peso_tara, peso_neto;
            float peso_envases;

            peso_bruto = 0;
            peso_tara = 0;
            peso_neto = 0;
            peso_envases = 0;

            try
            {
                peso_bruto = float.Parse(t_peso_bruto.Text);

            }
            catch
            {
                peso_bruto = 0;
            }

            try
            {
                peso_envases = float.Parse(t_peso_envases.Text);
            }
            catch
            {
                peso_envases = 0;
            }

            t_tara.Text = nPesoProvisorio.ToString();

            try
            {
                peso_tara = nPesoProvisorio;

            }
            catch
            {
                peso_tara = 0;
            }

            peso_neto = peso_bruto - peso_tara - peso_envases;

            t_peso_neto.Text = Convert.ToString(peso_neto);

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_2do_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void frmRomanaA6_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;

        }

    }

}
