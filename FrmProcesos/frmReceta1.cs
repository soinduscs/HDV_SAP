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
    public partial class frmReceta1 : Form
    {
        public frmReceta1()
        {
            InitializeComponent();
        }

        private void frmReceta1_Load(object sender, EventArgs e)
        {

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_ListaMateriales f2 = new frmSel_ListaMateriales();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode != "")
            {
                Grid1.Rows.Clear();

                t_itemcode_d.Text = VariablesGlobales.glb_ItemCode;
                t_itemname_d.Text = VariablesGlobales.glb_ItemName;

                carga_recetas_sap();

                carga_recetas();

            }

        }

        private void t_itemcode_d_Leave(object sender, EventArgs e)
        {


            clsProductos objproducto = new clsProductos();
            objproducto.cls_consultar_Producto_x_codigo(t_itemcode_d.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
               t_itemname_d.Text = dTable.Rows[0]["ItemName"].ToString();

            }
            catch
            {
                t_itemname_d.Clear();

            }

            carga_recetas_sap();

            carga_recetas();

        }

        private void carga_recetas_sap()
        {

            if (t_itemname_d.Text =="")
            {
                return;
            }

            string cResponsable;
            DateTime dFecha;
            int nCantItems;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales_SAP(t_itemcode_d.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];


            try
            {
                cResponsable = dTable.Rows[0]["UserName"].ToString();
            }
            catch
            {
                cResponsable = "";

            }

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["CreateDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");

            }

            try
            {
                nCantItems = Convert.ToInt32(dTable.Rows[0]["Cant_Items"].ToString());
            }
            catch
            {
                nCantItems = 0;
            }

            grilla[0] = cResponsable;
            grilla[1] = dFecha.ToString("dd/MM/yyyy");
            grilla[2] = nCantItems.ToString();

            Grid1.Rows.Add(grilla);

        }

        private void carga_recetas()
        {

            if (t_itemname_d.Text == "")
            {
                return;
            }

            string cReferencia, cResponsable;
            DateTime dFecha;
            int nDocEntry, nCantItems;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales_Resumen(t_itemcode_d.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    nDocEntry = Convert.ToInt32(dTable.Rows[i]["DocEntry"].ToString());
                }
                catch
                {
                    nDocEntry = 0;
                }

                try
                {
                    cReferencia = dTable.Rows[i]["U_Referencia"].ToString();
                }
                catch
                {
                    cReferencia = "";
                }

                try
                {
                    cResponsable = dTable.Rows[i]["U_Name"].ToString();
                }
                catch
                {
                    cResponsable = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                }
                catch
                {
                    dFecha = DateTime.Parse("01/01/1900");

                }

                try
                {
                    nCantItems = Convert.ToInt32(dTable.Rows[i]["Cant_Items"].ToString());
                }       
                catch
                {
                    nCantItems = 0;
                }

                grilla[0] = nDocEntry.ToString();
                grilla[1] = cReferencia;
                grilla[2] = cResponsable;
                grilla[3] = dFecha.ToString("dd/MM/yyyy");
                grilla[4] = nCantItems.ToString();

                Grid2.Rows.Add(grilla);

            }


        }


        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            btn_receta_sap_Click(sender, e);

        }

        private void btn_receta_sap_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = t_itemcode_d.Text;
            VariablesGlobales.glb_ItemName = t_itemname_d.Text;

            frmReceta2 f2 = new frmReceta2();
            DialogResult res = f2.ShowDialog();

            //carga_recetas_sap();

            carga_recetas();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_LMateriales;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                id_LMateriales = Convert.ToInt32(Grid2[0, fila].Value.ToString());

            }
            catch
            {
                id_LMateriales = 0;

            }

            VariablesGlobales.glb_ItemCode = t_itemcode_d.Text;
            VariablesGlobales.glb_ItemName = t_itemname_d.Text;
            VariablesGlobales.glb_id_LMateriales = id_LMateriales;

            frmReceta f2 = new frmReceta();
            DialogResult res = f2.ShowDialog();

            carga_recetas();

        }

        private void Grid2_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }
    }
}
