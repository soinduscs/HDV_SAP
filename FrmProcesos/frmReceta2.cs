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
    public partial class frmReceta2 : Form
    {
        public frmReceta2()
        {
            InitializeComponent();
        }

        private void frmReceta_Load(object sender, EventArgs e)
        {
            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_itemname.Text = VariablesGlobales.glb_ItemName;

            carga_recetas_sap();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void carga_recetas_sap()
        {

            if (t_itemname.Text == "")
            {
                return;
            }

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales_SAP(t_itemcode.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_tipolmat.Text = dTable.Rows[0]["TipoLMat"].ToString();
            }
            catch
            {
                t_tipolmat.Clear();
            }

            try
            {
                t_costo.Text = dTable.Rows[0][""].ToString();
            }
            catch
            {
                t_costo.Clear();
            }

            try
            {
                t_tamano_producto.Text = Convert.ToDouble(dTable.Rows[0]["PIAvgSize"].ToString()).ToString("N2");
            }
            catch
            {
                t_tamano_producto.Clear();
            }

            try
            {
                t_cant.Text = Convert.ToDouble(dTable.Rows[0]["Qauntity"].ToString()).ToString("N2");  
            }
            catch
            {
                t_cant.Clear();
            }

            try
            {
                t_almacen.Text = dTable.Rows[0]["ToWH"].ToString();
            }
            catch
            {
                t_almacen.Clear();
            }

            try
            {
                t_norma.Text = dTable.Rows[0][""].ToString();
            }
            catch
            {
                t_norma.Clear();
            }

            try
            {
                t_proyecto.Text = dTable.Rows[0]["Project"].ToString();
            }
            catch
            {
                t_proyecto.Clear();
            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega, cListaPre;
            string cMetodoEmision;
            double nCantidad, nPrecio;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["ChildNum"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cItemCode = dTable.Rows[i]["Code"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["CodeName"].ToString();
                }
                catch
                {
                    cItemName = "";

                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                try
                {
                    cUM = dTable.Rows[i][""].ToString();
                }
                catch
                {
                    cUM = "";
                }

                try
                {
                    cBodega = dTable.Rows[i]["Warehouse"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cListaPre = dTable.Rows[i][""].ToString();
                }
                catch
                {
                    cListaPre = "";
                }

                try
                {
                    nPrecio = Convert.ToDouble(dTable.Rows[i]["Price"].ToString());
                }
                catch
                {
                    nPrecio = 0;
                }
            
                try
                {
                    cMetodoEmision = dTable.Rows[i][""].ToString();
                }
                catch
                {
                    cMetodoEmision = "";
                }

                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidad.ToString("N2");
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = cMetodoEmision;
                grilla[8] = cListaPre;
                grilla[9] = nPrecio.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {

            string UserCode;
            int UserId;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Copiar la Lista de Materiales", "Lista de Materiales ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                String mensaje = clsProduccion.SAPB1_RECETA(t_itemcode.Text , UserId);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Copiado Exitosamente", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Close();

            }

        }


    }

}
