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
    public partial class frmTransferenciaStock : Form
    {
        public frmTransferenciaStock()
        {
            InitializeComponent();
        }

        private void frmTransferenciaStock_Load(object sender, EventArgs e)
        {
            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            carga_grilla1();
        }


        private void carga_grilla1()
        {

            string cWhsCode;

            try
            {
                cWhsCode = cbb_almacen.SelectedValue.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            if (cWhsCode == "")
            {
                MessageBox.Show("Debe seleccionar un Almacén válido, opción Cancelada", "Consulta por Lote ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Grid1.Rows.Clear();

            try
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Vista_Lotes_Rechazados_x_WhsCode(cWhsCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                double nCantidad;
                //DateTime dFecha;
                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    grilla[1] = dTable.Rows[i]["ItemCode"].ToString();
                    grilla[2] = dTable.Rows[i]["ItemName"].ToString();
                    grilla[3] = dTable.Rows[i]["StatusLote"].ToString();
                    grilla[4] = dTable.Rows[i]["WhsCode"].ToString();
                    grilla[5] = nCantidad.ToString("N2");
                    grilla[6] = dTable.Rows[i]["DistNumber"].ToString();
                    grilla[7] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    grilla[8] = dTable.Rows[i]["U_Temporada"].ToString();
                    grilla[9] = "0";
                  
                    Grid1.Rows.Add(grilla);

                    Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}
