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
    public partial class frmCalidadMPA9 : Form
    {
        public frmCalidadMPA9()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA9_Load(object sender, EventArgs e)
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

                carga_datos_x_id();
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
            t_conductor.Clear();
            t_peso_bruto.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_cantidad_envases.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, 0);

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
                fecha_hora2 = DateTime.Parse(dTable.Rows[0].ItemArray[18].ToString());

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
            string cItemName_D, cStatusCalidad;
            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nLineId, nLineasAnalisis_D, nCantAnalisis_D;
            int nCantAtributos;

            int nCantItems, nCantRegistros, nCantRegistroAprobados;
            int nCantRegistroRechazados;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

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
                nLineasAnalisis_D = 0;
                nCantAnalisis_D = 0;
                nCantAtributos = 0;

                try
                {
                    nLineId = Convert.ToInt32(dTable.Rows[i]["LineId_D"].ToString());

                }
                catch
                {
                    nLineId = -1;

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
                    cItemName_D = "";
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
                    nCantAnalisis_D = Convert.ToInt32(dTable.Rows[i]["Cant_Analisis_Calidad"].ToString());

                }
                catch
                {
                    nCantAnalisis_D = 0;

                }

                try
                {
                    nLineasAnalisis_D = Convert.ToInt32(dTable.Rows[i]["DocEntry_Calidad"].ToString());

                }
                catch
                {
                    nLineasAnalisis_D = 0;

                }

                try
                {
                    nCantAtributos = Convert.ToInt32(dTable.Rows[i]["Registro_Calidad"].ToString());
                }
                catch
                {
                    nCantAtributos = 0;
                }


                try
                {
                    nCantRegistros = Convert.ToInt32(dTable.Rows[i]["Cant_Registros_Calidad"].ToString());
                }
                catch
                {
                    nCantRegistros = 0;
                }

                try
                {
                    nCantRegistroAprobados = Convert.ToInt32(dTable.Rows[i]["Cant_Registros_Aprobados"].ToString());
                }
                catch
                {
                    nCantRegistroAprobados = 0;
                }

                try
                {
                    nCantRegistroRechazados = Convert.ToInt32(dTable.Rows[i]["Cant_Registros_Rechazados"].ToString());
                }
                catch
                {
                    nCantRegistroRechazados = 0;
                }

                nCantItems = 1;

                if (nCantRegistroRechazados > 0)
                {
                    if (nCantRegistroAprobados > 0)
                    {
                        nCantRegistroRechazados = 0;

                    }

                }


                if ((nCantRegistros - nCantRegistroRechazados) > 0)
                {
                    nCantRegistroRechazados = 0;

                }

                cStatusCalidad = "Inspección no Registrada";

                if ((nCantRegistros + nCantRegistroAprobados) == 0)
                {
                    cStatusCalidad = "Inspección no Registrada";
                }
                else
                {
                    if (nCantRegistros > 0)
                    {
                        cStatusCalidad = "Inspección en Proceso";

                    }
                    if (nCantRegistroAprobados == nCantItems)
                    {
                        cStatusCalidad = "Inspección Finalizada - Aprobado";

                    }
                    if (nCantRegistroRechazados == nCantItems)
                    {
                        cStatusCalidad = "Inspección Finalizada - Rechazado";

                    }

                }

                grilla[0] = nLineId.ToString();
                grilla[1] = nNumOC_D.ToString();
                grilla[2] = cCardCode_D.ToUpper();
                grilla[3] = cCardName_D.ToUpper();
                grilla[4] = cItemCode_D.ToUpper();
                grilla[5] = cItemName_D.ToUpper();
                grilla[6] = ItemCodeBins;
                grilla[7] = Convert.ToString(nCantBins_D);
                grilla[8] = Convert.ToString(n_PesoUnitBins_D);
                grilla[9] = cStatusCalidad;
                grilla[10] = nCantAnalisis_D.ToString();
                grilla[11] = Convert.ToString(nLineasAnalisis_D);
                grilla[12] = Convert.ToString(nCantAtributos);

                Grid1.Rows.Add(grilla);

                if (cStatusCalidad == "Inspección no Registrada")
                {
                    Grid1[9, i].Style.BackColor = Color.Empty;
                }

                if (cStatusCalidad == "Inspección en Proceso")
                {
                    Grid1[9, i].Style.BackColor = Color.Yellow;
                }

                if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                {
                    Grid1[9, i].Style.BackColor = Color.Green;
                }

                if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                {
                    Grid1[9, i].Style.BackColor = Color.Red;
                }

            }

            //Calcula_bins();

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;

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


            }

            if (peso_bins != 0)
            {
                t_peso_envases.Text = peso_bins.ToString("N2");

            }

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            //cbb_envase.SelectedIndex = id_envase;
            t_cantidad_envases.Text = cant_envases.ToString();
            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }





        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_analisis_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nLineId, nLineaAnalisis;
            int nIdCalidad, nCantAnalisis;
            string cItemCode;

            fila = 0;
            nLineId = 0;
            nLineaAnalisis = 0;
            nIdCalidad = 0;
            nCantAnalisis = 0;
            cItemCode = "";

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLineId = Convert.ToInt32(Grid1[0, fila].Value.ToString());

            }
            catch
            {
                nLineId = -1;

            }

            try
            {
                cItemCode = Grid1[4, fila].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }

            try
            {
                nLineaAnalisis = Convert.ToInt32(Grid1[12, fila].Value.ToString());
            }
            catch
            {
                nLineaAnalisis = 0;
            }

            try
            {
                nIdCalidad = Convert.ToInt32(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                nCantAnalisis = Convert.ToInt32(Grid1[10, fila].Value.ToString());

            }
            catch
            {
                nCantAnalisis = 0;

            }

            if (nLineId < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nLineaAnalisis == 0)
            {
                MessageBox.Show("El Código de Producto No tiene parametros de calidad validos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_id_calidad = nIdCalidad;
            VariablesGlobales.glb_Object = "100100";
            VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_romana.Text);
            VariablesGlobales.glb_LineId = nLineId;
            VariablesGlobales.glb_ItemCode = cItemCode;

            if (nCantAnalisis <= 1)
            {
                frmCalidadMPA8 f2 = new frmCalidadMPA8();
                DialogResult res = f2.ShowDialog();

            }
            else
            {
                frmCalidadMP5 f2 = new frmCalidadMP5();
                DialogResult res = f2.ShowDialog();

            }

            carga_datos_x_id();

        }
    }
}
