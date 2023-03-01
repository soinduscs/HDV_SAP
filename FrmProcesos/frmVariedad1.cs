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
    public partial class frmVariedad1 : Form
    {
        public frmVariedad1()
        {
            InitializeComponent();
        }

        private void frmVariedad1_Load(object sender, EventArgs e)
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

            string cCode, cName, cTipoFruta;

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

            try
            {
                cTipoFruta = cbb_tipofruta.Text;
            }
            catch
            {
                cTipoFruta = "";
            }

            if (cCode=="")
            {
                MessageBox.Show("Debe ingresar un Código válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cName == "")
            {
                MessageBox.Show("Debe ingresar un Nombre válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_tipofruta.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de fruta válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cTipoFruta == "")
            {
                MessageBox.Show("Debe seleccionar un tipo de fruta válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            String mensaje = clsMaestros.TablaUsuario_Variedad(cCode, cName, cTipoFruta, UsuarioSap, ClaveSap);

            if (mensaje != cCode)
            {
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la variedad :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Close();

        }

    }

}
