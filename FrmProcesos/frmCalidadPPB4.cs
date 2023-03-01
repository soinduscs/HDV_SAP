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
    public partial class frmCalidadPPB4 : Form
    {
        public frmCalidadPPB4()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB4_Load(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Referencia1 = "";


        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Referencia1 = "_X_";
            Close();

        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Referencia1 = t_valor.Text;
            Close();

        }

    }

}
