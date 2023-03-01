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
    public partial class frmSel_Lotes : Form
    {
        public frmSel_Lotes()
        {
            InitializeComponent();
        }

        private void frmSel_Lotes_Load(object sender, EventArgs e)
        {
            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_descripcion.Text = VariablesGlobales.glb_ItemName;
            t_almacen.Text = VariablesGlobales.glb_Almacen;

            carga_grilla();

        }

        private void carga_grilla()
        {

            Grid1.Rows.Clear();

            clsProductos objproducto = new clsProductos();
            objproducto.cls_Consulta_stock_x_codigo_almacen_y_lote(t_itemcode.Text, t_almacen.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cLote, cLoteProveedor;
            double nStock;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLote = dTable.Rows[i]["BatchNum"].ToString();
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
                    nStock = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nStock = 0;
                }
                
                grilla[0] = cLote;
                grilla[1] = cLoteProveedor;
                grilla[2] = nStock.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            int fila, nLote;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_Lote = 0;
            nLote = 0;

            if (fila >= 0)
            {
                try
                {
                    nLote = Convert.ToInt32(Grid1[0, fila].Value);
                }
                catch
                {
                    nLote = 0;
                }

            }

            if (nLote > 0)
            {
                VariablesGlobales.glb_Lote = nLote;

            }

            Close();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }
    }
}
