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
    public partial class frmSel_OrdendeVenta : Form
    {
        public frmSel_OrdendeVenta()
        {
            InitializeComponent();
        }

        private void frmSel_OrdendeVenta_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new  clsMaestros();
                objproducto.cls_Consultar_Ordenes_de_venta_abiertas(t_buscar.Text);

                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Width = 80;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[0].HeaderText = "Número";
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[1].HeaderText = "Fecha Emisión";
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Width = 350;
                this.dataGridView1.Columns[3].HeaderText = "Cliente";
                this.dataGridView1.Columns[4].Visible = false;
                //this.dataGridView1.Columns[5].Visible = false;
                this.dataGridView1.Columns[5].Width = 350;
                this.dataGridView1.Columns[5].HeaderText = "Especie";
                //this.dataGridView1.Columns[7].Width = 65;
                //this.dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns[7].HeaderText = "Cant. Pendiente";
                //this.dataGridView1.Columns[7].DefaultCellStyle.Format = "n2";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            int fila;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_NumOC = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardCode = dataGridView1[2, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardName = dataGridView1[3, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemCode = dataGridView1[4, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemName = dataGridView1[5, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_NumOC = "";
                    VariablesGlobales.glb_CardCode = "";
                    VariablesGlobales.glb_CardName = "";
                    VariablesGlobales.glb_ItemCode = "";
                    VariablesGlobales.glb_ItemName = "";

                }

            }

            Close();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }
    }
}
