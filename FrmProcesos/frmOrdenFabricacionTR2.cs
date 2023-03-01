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
    public partial class frmOrdenFabricacionTR2 : Form
    {
        public frmOrdenFabricacionTR2()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR2_Load(object sender, EventArgs e)
        {
            btn_imprimir.Enabled = false;
            t_tipo_fruta.Text = "";

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            //string cSalida;
            int nDocEntry, nSalida;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación valida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_Salida.SelectedIndex < 0 )
            {
                MessageBox.Show("Debe seleccionar una Salida valida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nSalida = int.Parse(cbb_Salida.SelectedValue.ToString()); // + 1; //int.Parse(cbb_Salida.Text);
            }
            catch
            {
                nSalida = 0;
            }

            if (nSalida == 0)
            {
                MessageBox.Show("Debe seleccionar una Salida valida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_NumOF = nDocEntry;
            VariablesGlobales.glb_DocEntry = nSalida;

            frmOrdenFabricacionTR2A f2 = new frmOrdenFabricacionTR2A();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_NumOF = 0;
            VariablesGlobales.glb_DocEntry = 0;

        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
               
                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                Carga_fruta();

            }

        }

        private void t_DocNum_Leave(object sender, EventArgs e)
        {
            Carga_fruta();

        }

        private void Carga_fruta()
        {

            int nDocNum, nDocEntry, nConCascara;
            string cItemName, cItemCode; // cSalida, cTipoProducto;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            t_tipo_fruta.Clear();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_x_DocNum(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nDocEntry = int.Parse(dTable.Rows[0]["DocEntry"].ToString());
            }
            catch
            {
                nDocEntry = -1;
            }

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
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
                t_tipo_fruta.Text = dTable.Rows[0]["U_TipoProducto"].ToString();
            }
            catch
            {
                t_tipo_fruta.Text = "";
            }

            nConCascara = -1;

            try
            {
                nConCascara = cItemName.ToUpper().IndexOf("C/C");
            }
            catch
            {
                nConCascara = -1;
            }

            if (nConCascara == -1)
            {
                try
                {
                    nConCascara = cItemName.ToUpper().IndexOf("CON CASCARA");
                }
                catch
                {
                    nConCascara = -1;
                }

            }


            if (t_tipo_fruta.Text == "Nuez")
            {
                if (nConCascara >= 0)
                {
                    t_tipo_fruta.Text = "Nuez C/C";
                }
                else
                {
                    t_tipo_fruta.Text = "Nuez S/C";
                }

            }

            if (cItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                t_tipo_fruta.Text = "Otros";

            }
            //t_tipo_fruta.Text = "Nuez S/C";

            try
            {
                cbb_Salida.DataSource = null;
            }
            catch
            {

            }

            try
            {
                cbb_Salida.Items.Clear();
            }
            catch
            {

            }
           
            //clsProduccion objproducto3 = new clsProduccion();
            //objproducto3.cls_ConsultaLista_Almacenes_BM();
            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_SalidasProduccion_TipoProducto(t_tipo_fruta.Text);

            cbb_Salida.DataSource = objproducto1.cResultado;
            cbb_Salida.ValueMember = "U_HDV_Salida";
            cbb_Salida.DisplayMember = "nom_gate";

            //clsMaestros objproducto1 = new clsMaestros();
            //objproducto1.cls_Consultar_SalidasProduccion_TipoProducto(t_tipo_fruta.Text);

            //DataTable dTable1 = new DataTable();
            //dTable1 = objproducto1.cResultado;

            //for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            //{
            //    try
            //    {
            //        cSalida = dTable1.Rows[i]["U_HDV_Salida"].ToString();
            //    }
            //    catch
            //    {
            //        cSalida = "";
            //    }

            //    try
            //    {
            //        cTipoProducto = dTable1.Rows[i]["Name"].ToString();
            //    }
            //    catch
            //    {
            //        cTipoProducto = "";
            //    }

            //    cbb_Salida.Items.Add(cSalida + " - " + cTipoProducto);

            //}





            if (nDocNum == nDocEntry)
            {
                btn_imprimir.Enabled = true;
            }
            else
            {
                btn_imprimir.Enabled = false;
            }


        }


    }
}
