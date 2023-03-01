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
    public partial class frmPallet1 : Form
    {
        public frmPallet1()
        {
            InitializeComponent();
        }

        private void frmPallet1_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Pallet();
                
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Pallet";
                this.dataGridView1.Columns[0].Width = 100;
                this.dataGridView1.Columns[1].HeaderText = "Codigo de Barra";
                this.dataGridView1.Columns[1].Width = 100;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].HeaderText = "Fecha";
                this.dataGridView1.Columns[3].Width = 90;
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].HeaderText = "Artículo";
                this.dataGridView1.Columns[5].Width = 350;
                this.dataGridView1.Columns[6].HeaderText = "Almacen";
                this.dataGridView1.Columns[6].Width = 100;
                //this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

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
        
            if (VariablesGlobales.glb_Pallet != "")
            {

                frmPallet f2 = new frmPallet();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }

}
