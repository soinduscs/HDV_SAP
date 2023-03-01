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
    public partial class frmOrdenFabricacionTRA1 : Form
    {
        public frmOrdenFabricacionTRA1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTRA1_Load(object sender, EventArgs e)
        {
            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_itemname.Text = VariablesGlobales.glb_ItemName;

            t_almacen.Text = VariablesGlobales.glb_Almacen;
            t_total_tr.Text = VariablesGlobales.glb_Cantidad.ToString();

            Carga_datos();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            double nCantidad_TR, nCantidad_Pantalla;

            nCantidad_TR = 0;
            nCantidad_Pantalla = 0;

            try
            {
                nCantidad_TR = Convert.ToDouble(t_total.Text);
            }
            catch
            {
                nCantidad_TR = 0;
            }

            try
            {
                nCantidad_Pantalla = Convert.ToDouble(t_total_tr.Text);
            }
            catch
            {
                nCantidad_Pantalla = 0;
            }

            if (nCantidad_TR < nCantidad_Pantalla)
            {
                MessageBox.Show("La Cantidad Seleccionada NO corresponde con la cantidad procesada, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nCantidad;
            string cLote;
            int nLinea;

            nLinea = 0;
            VariablesGlobales.glb_Array1_ind = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                nCantidad = 0;

                try
                {
                    cLote = Grid1[0, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(Grid1[2, i].Value.ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                if ((nCantidad > 0) && (cLote != ""))
                {
                    VariablesGlobales.glb_Array7[0, nLinea] = cLote;
                    VariablesGlobales.glb_Array7[1, nLinea] = nCantidad.ToString();

                    nLinea += 1;

                    VariablesGlobales.glb_Array1_ind = nLinea;

                }

            }

            Close();


        }

        private void Carga_datos()
        {
            
            Grid1.Rows.Clear();

            clsProductos objproducto = new clsProductos();
            objproducto.cls_Consulta_stock_x_codigo_almacen_y_lote(t_itemcode.Text, t_almacen.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cLote, cLotePrecarga;
            double nStock, nAsignado, nCantidadPrecarga;

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
                    nStock = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nStock = 0;
                }

                nAsignado = 0;

                for (int x = 0; x <= VariablesGlobales.glb_Array1_ind; x++)
                {
                    try
                    {
                        cLotePrecarga = VariablesGlobales.glb_Array7[0, x];
                    }
                    catch
                    {
                        cLotePrecarga = "";
                    }                    

                    try
                    {
                        nCantidadPrecarga = Convert.ToDouble(VariablesGlobales.glb_Array7[1, x]);
                    }
                    catch
                    {
                        nCantidadPrecarga = 0;
                    }

                    if (cLotePrecarga == cLote)
                    {
                        nAsignado = nCantidadPrecarga;

                    }

                }

                grilla[0] = cLote;
                grilla[1] = nStock.ToString("N2");
                grilla[2] = nAsignado.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

            Calcula_totales();

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int fila;

            fila = 0;

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nStock, nCantidadAplicada;

            nStock = 0;
            nCantidadAplicada = 0;

            try
            {
                nStock = Convert.ToDouble(Grid1[1, fila].Value.ToString());
            }
            catch
            {
                nStock = 0;
            }

            try
            {
                nCantidadAplicada = Convert.ToDouble(Grid1[2, fila].Value.ToString());
            }
            catch
            {
                nCantidadAplicada = 0;
            }

            if (nCantidadAplicada > nStock)
            {
                nCantidadAplicada = nStock;
            }

            Grid1[2, fila].Value = nCantidadAplicada.ToString("N2");

            Calcula_totales();

        }

        private void Calcula_totales()
        {
            double nValorAsignado, nTotalAsignado;

            nTotalAsignado = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                nValorAsignado = 0;

                try
                {
                    nValorAsignado = Convert.ToDouble(Grid1[2, i].Value.ToString());
                }
                catch
                {
                    nValorAsignado = 0;
                }

                nTotalAsignado += nValorAsignado;

            }

            t_total.Text = nTotalAsignado.ToString("N2");

        }


    }


    


}
