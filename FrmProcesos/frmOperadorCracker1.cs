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
    public partial class frmOperadorCracker1 : Form
    {
        public frmOperadorCracker1()
        {
            InitializeComponent();
        }

        private void frmOperadorCracker1_Load(object sender, EventArgs e)
        {

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cCode, cName; //, cTipoFruta

            try
            {
                cCode = t_code.Text;
            }
            catch
            {
                cCode = "";
            }

            try
            {
                cName = t_name.Text;
            }
            catch
            {
                cName = "";
            }

            if (cCode == "")
            {
                MessageBox.Show("Debe ingresar un Código válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cName == "")
            {
                MessageBox.Show("Debe ingresar un Nombre válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;
            string cErrorMensaje;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            cErrorMensaje = "";

            //////////////////////////////////////
            // Genero el avance de proceso

            String mensaje;

            mensaje = "";

            try
            {
                mensaje = clsMaestros.TablaUsuario_OperadorCracker(cCode, cName, UsuarioSap, ClaveSap);
            }
            catch
            {
                MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mensaje != cCode)
            {
                cErrorMensaje = mensaje;
                MessageBox.Show("Error en la generación del Color :::::: " + cErrorMensaje + ", opción Cancelada", "Registro de Colores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Close();

        }

    }

}
