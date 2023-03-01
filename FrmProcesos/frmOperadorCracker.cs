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
    public partial class frmOperadorCracker : Form
    {
        public frmOperadorCracker()
        {
            InitializeComponent();
        }

        private void frmOperadorCracker_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Operadores_Cracker();

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo";
                this.dataGridView1.Columns[0].Width = 120;
                this.dataGridView1.Columns[1].HeaderText = "Nombre Operador";
                this.dataGridView1.Columns[1].Width = 250;

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

            frmOperadorCracker1 f2 = new frmOperadorCracker1();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }
    }
}
