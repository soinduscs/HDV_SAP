using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmTransportistas1 : Form
    {
        public frmTransportistas1()
        {
            InitializeComponent();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (t_code.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Codigo válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_name.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Transportista válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cCode, cName;

            cCode = t_code.Text.Trim();
            cName = t_name.Text.Trim();

            int UserId;

            UserId = 0;

            try
            {
                UserId = VariablesGlobales.glb_User_id;

            }
            catch
            {
                UserId = 0;

            }

            String mensaje = entSocioNegocio.SAPB1_TRANSP(cCode, cName, UserId);

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Registro de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Registro de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            VariablesGlobales.glb_CardCode = cCode;

            btn_finalizar_Click(sender, e);
             

        }

        private void frmTransportistas1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(450, 160);

        }
    }
}
