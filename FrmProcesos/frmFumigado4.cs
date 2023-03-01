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
    public partial class frmFumigado4 : Form
    {
        public frmFumigado4()
        {
            InitializeComponent();
        }

        private void frmFumigado4_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {

                this.Dock = DockStyle.Fill;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_de_fumigado();

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Num. Orden";
                //this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = 
                this.dataGridView1.Columns[0].Width = 80;
                this.dataGridView1.Columns[1].Visible = false;

                this.dataGridView1.Columns[2].HeaderText = "Fumigado";
                this.dataGridView1.Columns[2].Width = 80;
                this.dataGridView1.Columns[2].Visible = true;

                this.dataGridView1.Columns[3].HeaderText = "Fecha Fumigado"; 
                this.dataGridView1.Columns[3].Width = 90;
                this.dataGridView1.Columns[3].Visible = true; 

                this.dataGridView1.Columns[4].HeaderText = "Cant. Lotes"; 
                this.dataGridView1.Columns[4].Width = 90;
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[4].Visible = true;

                this.dataGridView1.Columns[5].Visible = false;

                this.dataGridView1.Columns[6].HeaderText = "Usuario";
                this.dataGridView1.Columns[6].Width = 300;
                this.dataGridView1.Columns[6].Visible = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;

            Close();

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

            int nDocEntry;

            VariablesGlobales.glb_DocEntry = 0;

            try
            {
                nDocEntry = int.Parse(dataGridView1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            btn_seleccionar_Click(sender, e);

        }

    }
}
