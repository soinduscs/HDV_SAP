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
    public partial class frmCalidadPPB6 : Form
    {
        public frmCalidadPPB6()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB6_Load(object sender, EventArgs e)
        {

            t_codatr_new.Text = VariablesGlobales.glb_MatrizAtr;
            t_atributo.Text = VariablesGlobales.glb_NameAtr;

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            if (t_atributo.Text == "")
            {
                MessageBox.Show("Debe ingresar un atributo válido", "Matriz de Procesos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string mensaje;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Copiar la Matriz de Parametros", "Matriz de Procesos ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                mensaje = "";

                try
                {
                    //mensaje = clsCalidad.Sapb1_utiles_matriz_new(Convert.ToInt32(VariablesGlobales.glb_MatrizAtr), VariablesGlobales.glb_NameAtr);
                    mensaje = clsCalidad.Sapb1_utiles_matriz_new(Convert.ToInt32(VariablesGlobales.glb_MatrizAtr), t_atributo.Text, "C");

                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Close();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

    }

}

