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
    public partial class frmVariedad : Form
    {
        public frmVariedad()
        {
            InitializeComponent();
        }

        private void frmVariedad_Load(object sender, EventArgs e)
        {
            this.Size = new Size(600, 380);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Variables();

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo";
                this.dataGridView1.Columns[0].Width = 110;
                this.dataGridView1.Columns[1].HeaderText = "Variedad";
                this.dataGridView1.Columns[1].Width =120;
                this.dataGridView1.Columns[2].HeaderText = "Tipo Fruta";
                this.dataGridView1.Columns[2].Width = 120;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            frmVariedad1 f2 = new frmVariedad1();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }
    }
}
