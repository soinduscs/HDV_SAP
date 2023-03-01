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
    public partial class frmCalidadMP7 : Form
    {
        public frmCalidadMP7()
        {
            InitializeComponent();
        }

        private void frmCalidadMP7_Load(object sender, EventArgs e)
        {

            double nCantidad;

            try
            {
                nCantidad = VariablesGlobales.glb_Cantidad;

            }
            catch
            {
                nCantidad = 0;
            }

            t_num_bultos.Text = nCantidad.ToString("N2");

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Cantidad = -1;
            Close();

        }

        private void btn_dividir_registro_Click(object sender, EventArgs e)
        {
            double nCantidad_old, nCantidad_new;

            try
            {
                nCantidad_old = Convert.ToDouble(t_num_bultos.Text);

            }
            catch
            {
                nCantidad_old = 0;
            }

            try
            {
                nCantidad_new = Convert.ToDouble(textBox1.Text);

            }
            catch
            {
                nCantidad_new = 0;
            }

            if (nCantidad_new > nCantidad_old)
            {
                MessageBox.Show("La Cantidad a Dividir No puede superar la cantidad Total de Envases, opción Cancelada", "Registro de Inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_Cantidad = nCantidad_new;
            Close();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double nCantidad;

            try
            {
                nCantidad = Convert.ToDouble(textBox1.Text);

            }
            catch
            {
                nCantidad = 0;
            }

            textBox1.Text = nCantidad.ToString("N2");

        }

    }
}
