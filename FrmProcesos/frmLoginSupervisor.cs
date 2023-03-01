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
    public partial class frmLoginSupervisor : Form
    {
        public frmLoginSupervisor()
        {
            InitializeComponent();
        }

        private void frmLoginSupervisor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion();
        }

        private void conexion()
        {
            string conexion;

            string cUser_Code, cUser_Name, cUser_Psw;
            string user_name, produccion, porteria, romana;
            string supervisor;

            int cUser_id;

            cUser_Code = txtUsuario.Text;
            cUser_Name = "";
            cUser_Psw = txtClave.Text.Trim();
            supervisor = "";

            //////////////////////////////////////
            // Genero el avance de proceso

            //String mensaje = clsMaestros.Valido_Clave("manager", "hdndndnd");

            try
            {
                conexion = clsMaestros.Valido_Clave(txtUsuario.Text, txtClave.Text);

            }
            catch
            {
                conexion = "Error de Conexión";

            }

            try
            {

                int usr_id;

                cUser_Name = "";

                user_name = "";
                produccion = "";
                porteria = "";
                romana = "";
                usr_id = 0;

                clsMaestros objproducto6 = new clsMaestros();
                objproducto6.cls_lee_usuario(cUser_Code);

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
                    supervisor = dTable6.Rows[0]["Supervisor"].ToString();
                }
                catch
                {
                    supervisor = "";
                }

                try
                {
                    usr_id = Convert.ToInt32(dTable6.Rows[0]["USERID"].ToString());

                }
                catch
                {
                    usr_id = 0;

                }

                cUser_Name = user_name;
                cUser_id = usr_id;

            }
            catch
            {

            }

            if (conexion == "S")
            {

                VariablesGlobales.glb_User_Code_Autorizacion = "";

                if (supervisor == "SI")
                {
                    VariablesGlobales.glb_User_Code_Autorizacion = cUser_Code;

                }

                this.Close();
            }

            else
            {
                if (conexion == "Sin licencias SAP")
                {
                    this.Close();

                }
                else
                {
                    lblError.Text = "Error, usuario o contraseña NO validos a SAP";

                }

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                conexion();
            }
        }
    }

}
