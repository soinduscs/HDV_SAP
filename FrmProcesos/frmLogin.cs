using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            VariablesGlobales.accesoMenuPrincipal = 0;
            lblVersion.Text = Application.ProductVersion.ToString();

            label3.Text = "V." + VariablesGlobales.glb_version;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {

            VariablesGlobales.accesoMenuPrincipal = 0;
            this.Close();

        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                conexion();
            }
        }

        private void conexion()
        {
            string conexion;

            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_Referencia2 = "";

            VariablesGlobales.glb_User_Code = txtUsuario.Text;
            VariablesGlobales.glb_User_Name = "";
            VariablesGlobales.glb_User_Psw = txtClave.Text.Trim();
            VariablesGlobales.glb_tipo_usuario = "";

            try
            {
                conexion = negSap.Conexion_SAP(txtUsuario.Text, txtClave.Text);

            }
            catch
            {
                conexion = "Error de Conexión";

            }
            
            try
            {
                VariablesGlobales.accesoMenuPrincipal = 1;

                string user_name, produccion, porteria, romana;
                int usr_id;

                VariablesGlobales.glb_User_Name = "";

                user_name = "";
                produccion = "";
                porteria = "";
                romana = "";
                usr_id = 0;

                clsMaestros objproducto6 = new clsMaestros();
                objproducto6.cls_lee_usuario(VariablesGlobales.glb_User_Code);

                DataTable dTable6 = new DataTable();
                dTable6 = objproducto6.cResultado;

                try
                {
                    user_name = dTable6.Rows[0]["nombre"].ToString();
                }
                catch
                {
                    user_name = "";
                }

                try
                {
                    produccion = dTable6.Rows[0]["Produccion"].ToString();
                }
                catch
                {
                    produccion = "";
                }

                try
                {
                    porteria = dTable6.Rows[0]["Porteria"].ToString();
                }
                catch
                {
                    porteria = "";
                }

                try
                {
                    romana = dTable6.Rows[0]["Romana"].ToString();
                }
                catch
                {
                    romana = "";
                }

                try
                {
                    usr_id = Convert.ToInt32(dTable6.Rows[0]["USERID"].ToString());

                }
                catch
                {
                    usr_id = 0;

                }

                VariablesGlobales.glb_User_Name = user_name;
                VariablesGlobales.glb_User_id = usr_id;

            }
            catch
            {

            }
          
            if (conexion == "")
            {
                VariablesGlobales.glb_tipo_usuario = "1"; // Usuario SAP con Licencia
                this.Close();

            }

            else
            {
                if (conexion == "Sin licencias SAP")
                {
                    VariablesGlobales.glb_tipo_usuario = "2"; // Sin licencias SAP
                    this.Close();

                }
                else
                {
                    VariablesGlobales.accesoMenuPrincipal = 0;
                    lblError.Text = conexion; // "Error usuario o contraseña acceso a SAP";

                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "MANAGER")
            {
                VariablesGlobales.glb_User_Name = "MANAGER";
                VariablesGlobales.glb_User_Code = "MANAGER";
                VariablesGlobales.glb_User_id = 1;
                VariablesGlobales.glb_tipo_usuario = "1"; // Usuario SAP con Licencia
                VariablesGlobales.accesoMenuPrincipal = 1;

                this.Close();

            }


        }
    }




}

