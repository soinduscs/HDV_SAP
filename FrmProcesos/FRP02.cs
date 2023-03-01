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
    public partial class FRP02 : Form
    {
        public FRP02()
        {
            InitializeComponent();
        }

        private void FRP02_Load(object sender, EventArgs e)
        {

            this.Size = new Size(520, 370);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.Cls_ConsultaLista_TipoFruta();

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Tipo Fruta";
                this.dataGridView1.Columns[0].Width = 130;
                this.dataGridView1.Columns[1].HeaderText = "Proceso";
                this.dataGridView1.Columns[1].Width = 250;
                this.dataGridView1.Columns[2].HeaderText = "Orden";
                this.dataGridView1.Columns[2].Width = 60;

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

            FRP03 f2 = new FRP03();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }
    }
}
