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
    public partial class frmFumigado2 : Form
    {
        public frmFumigado2()
        {
            InitializeComponent();
        }

        private void frmFumigado2_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Now;
            dtp_fecha.Focus();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_fecha = Convert.ToDateTime("01/01/1900");
            Close();

        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_fecha = dtp_fecha.Value;
            Close();

        }

    }
}
