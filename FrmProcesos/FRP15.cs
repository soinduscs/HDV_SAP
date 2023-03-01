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
    public partial class FRP15 : Form
    {
        public FRP15()
        {
            InitializeComponent();
        }

        private void FRP15_Load(object sender, EventArgs e)
        {
            carga_datos();

        }

        private void carga_datos()
        {

            try
            {

                double n_valor;
                string c_rango;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_nivel_stock();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["Tipo"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Capacidad"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    grilla[2] = n_valor.ToString("N");

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Real"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    grilla[3] = n_valor.ToString("N");

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Porcentaje"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    grilla[4] = n_valor.ToString("N");

                    c_rango = "";

                    try
                    {
                        c_rango = dTable.Rows[i]["Rango"].ToString();

                    }
                    catch
                    {
                        c_rango = "";

                    }

                    grid1.Rows.Add(grilla);

                    if (c_rango == "V")
                    {
                        grid1[4, grid1.RowCount - 1].Style.BackColor = Color.Green;

                    }

                    if (c_rango == "A")
                    {
                        grid1[4, grid1.RowCount - 1].Style.BackColor = Color.Yellow;

                    }

                    if (c_rango == "R")
                    {
                        grid1[4, grid1.RowCount - 1].Style.BackColor = Color.Red;

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            carga_datos();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

    }

}
