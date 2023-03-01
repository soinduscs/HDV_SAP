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
    public partial class FRP08 : Form
    {
        public FRP08()
        {
            InitializeComponent();
        }

        private void FRP08_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_guias_excluidas();

                //this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Estado";
                this.dataGridView1.Columns[0].Width = 140;
                this.dataGridView1.Columns[1].Visible = false;
                this.dataGridView1.Columns[2].HeaderText = "Productor";
                this.dataGridView1.Columns[2].Width = 210;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderText = "Artículo";
                this.dataGridView1.Columns[4].Width = 230;

                this.dataGridView1.Columns[5].HeaderText = "Folio";
                this.dataGridView1.Columns[5].Width = 60;
                this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[6].HeaderText = "Lote";
                this.dataGridView1.Columns[6].Width = 70;
                this.dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[7].HeaderText = "Cant. Bins";
                this.dataGridView1.Columns[7].Width = 50;
                this.dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[8].HeaderText = "Orden";
                this.dataGridView1.Columns[8].Width = 60;
                this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[9].HeaderText = "Fecha/Hora";
                this.dataGridView1.Columns[9].Width = 110;

                this.dataGridView1.Columns[10].Visible = false;
                this.dataGridView1.Columns[11].Visible = false;

                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[12].HeaderText = "Stock";
                this.dataGridView1.Columns[12].Width = 70;
                this.dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRP09 f2 = new FRP09();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
