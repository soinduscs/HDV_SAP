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
    public partial class frmSel_Pallet : Form
    {
        public frmSel_Pallet()
        {
            InitializeComponent();
        }

        private void frmSel_Pallet_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                this.Dock = DockStyle.Fill;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consulta_pallet_existentes(VariablesGlobales.glb_ItemCode, VariablesGlobales.glb_Almacen);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo";
                this.dataGridView1.Columns[0].Width = 80;
                this.dataGridView1.Columns[1].HeaderText = "Fecha Creación";
                this.dataGridView1.Columns[1].Width = 90;
                this.dataGridView1.Columns[2].HeaderText = "Articulo";
                this.dataGridView1.Columns[2].Width = 300;
                this.dataGridView1.Columns[3].HeaderText = "Descripción";
                this.dataGridView1.Columns[3].Width = 300;
                this.dataGridView1.Columns[4].HeaderText = "Almacen";
                this.dataGridView1.Columns[4].Width = 90;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

            VariablesGlobales.glb_Pallet = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_Pallet = dataGridView1[0, fila].Value.ToString().ToUpper();
                }
                catch
                {
                    VariablesGlobales.glb_Pallet = "";
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
