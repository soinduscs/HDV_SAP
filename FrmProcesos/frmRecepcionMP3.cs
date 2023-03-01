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

namespace FrmProcesos
{
    public partial class frmRecepcionMP3 : Form
    {
        public frmRecepcionMP3()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP3_Load(object sender, EventArgs e)
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

            if (VariablesGlobales.glb_id_romana != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
                t_lineId.Text = VariablesGlobales.glb_LineId.ToString();

                groupBox2.Text = "[ Item " + t_lineId.Text + " ]";

                carga_datos_x_id();

            }

        }


        private void carga_datos_x_id()
        {

            int id_romana, nlineId;

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
                nlineId = int.Parse(t_lineId.Text);
            }
            catch
            {
                nlineId = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor, ItemCodeBins;
            string obs, cReferencia1, cReferencia2;
            string CardCode_trans, CardName_trans;

            int numguia, cant_envases, id_acceso;
            int nIdReferencia1, nIdReferencia2, nPesoTotalBins_D;

            float peso_bruto, peso_neto;
            float peso_guia, peso_bins;

            DateTime fecha_hora1, fecha_hora2;

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
            peso_neto = 0;
            peso_guia = 0;
            cant_envases = 0;
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            peso_bins = 0;
            cReferencia1 = "";

            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_peso_neto.Clear();
            t_observacion.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_id_acceso.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana,0);

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
                peso_guia = float.Parse(dTable.Rows[0].ItemArray[27].ToString());

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
            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D;

            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D;
            int nLineId;

            double nCantidadReferencia1, nCantidadReferencia2;

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
                nPesoTotalBins_D = 0;

                try
                {
                    nLineId = Convert.ToInt32(dTable.Rows[i]["LineId_D"].ToString());

                }
                catch
                {
                    nLineId = 0;

                }

                if (nlineId== nLineId)
                {
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
                        cItemName_D = dTable.Rows[i].ItemArray[4].ToString().ToUpper();

                    }
                    catch
                    {

                    }

                    try
                    {
                        ItemCodeBins = dTable.Rows[0].ItemArray[12].ToString();

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

                    t_numoc.Text = nNumOC_D.ToString();
                    t_productor.Text = cCardName_D.ToUpper();
                    t_itemcode.Text = cItemCode_D.ToUpper();
                    t_itemname.Text = cItemName_D.ToUpper();

                    t_DocEntry_OPDN.Text = nIdReferencia1.ToString();

                    t_DocEntry_OWTR.Text = nIdReferencia2.ToString();

                }


                //grilla[0] = nLineId.ToString();

                //grilla[2] = nNumOC_D.ToString();
                //grilla[3] = cCardCode_D.ToUpper();
              
                //grilla[7] = ItemCodeBins;
                //grilla[8] = Convert.ToString(nCantBins_D);
                //grilla[9] = Convert.ToString(n_PesoUnitBins_D);
                //grilla[10] = Convert.ToString(nCantAnalisisCalidad_D);
                //grilla[11] = "BMPL1";
                //grilla[12] = cEstado_D;

                //if (nPesoTotalBins_D == 0)
                //{
                //    grilla[13] = 0.ToString("N2");

                //}
                //else
                //{
                //    grilla[13] = nPesoTotalBins_D.ToString("N2");

                //}

                //if (nCantidadReferencia1 == 0)
                //{
                //    grilla[14] = 0.ToString("N2");

                //}
                //else
                //{
                //    grilla[14] = nCantidadReferencia1.ToString("N2");

                //    btn_recibir.Enabled = false;
                //    btn_cancela_recepcion.Enabled = false;
                //    btn_genera_recepcion.Enabled = false;

                //}

                //grilla[15] = cReferencia1;
                //grilla[16] = nIdReferencia1.ToString();
                //grilla[17] = cReferencia2;
                //grilla[18] = nIdReferencia2.ToString();


            }

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
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

            t_observacion.Text = obs;

            int nDocEntry_OPDN;

            try
            {
                nDocEntry_OPDN = int.Parse(t_DocEntry_OPDN.Text);
            }
            catch
            {
                nDocEntry_OPDN = 0;

            }
            

            clsRecepcion objproducto1 = new clsRecepcion();
            objproducto1.cls_Consulta_EntradaMercaderia_x_DocEntry(nDocEntry_OPDN);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto.cResultado;


        }

        private void lnk_ver_documento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int id_acceso;

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);

            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso > 0)
            {

                VariablesGlobales.glb_id_acceso = id_acceso;
                VariablesGlobales.glb_Referencia2 = "N";

                frmPorteria2 f2 = new frmPorteria2();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
