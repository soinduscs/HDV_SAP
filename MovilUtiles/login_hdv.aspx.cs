using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using CapaNegocio;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            t_usuario.Focus();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (t_usuario.Text != "" && t_Clave.Text != "")
            {
                VariablesGlobales.glb_tipo_usuario = "";
                VariablesGlobales.glb_Referencia1 = "";

                conexion();

                if ((VariablesGlobales.glb_tipo_usuario == "1") || (VariablesGlobales.glb_tipo_usuario == "2"))
                {
                    Response.Redirect("Menu_hdv.aspx");

                }

                lbl_error.Text = VariablesGlobales.glb_Referencia1;
                lbl_error.Visible = true;


            }
            else
            {
                //lbl_error.Text = "Falta ingresar campos";
                //lbl_error.Visible = true;

            }

        }

        protected void conexion()
        {
            string conexion;

            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_Referencia2 = "";

            VariablesGlobales.glb_User_Code = t_usuario.Text;
            VariablesGlobales.glb_User_Name = "";
            VariablesGlobales.glb_User_Psw = t_Clave.Text.Trim();
            VariablesGlobales.glb_tipo_usuario = "";

            try
            {
                conexion = negSap.Conexion_SAP(t_usuario.Text, t_Clave.Text);

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
                conexion = "Nombre de Usuario o Clave de Acceso incorrecta";
            }

            if (conexion == "")
            {
                VariablesGlobales.glb_tipo_usuario = "1"; // Usuario SAP con Licencia

            }

            else
            {
                if (conexion == "Sin licencias SAP")
                {
                    VariablesGlobales.glb_tipo_usuario = "2"; // Sin licencias SAP

                }
                else
                {
                    VariablesGlobales.accesoMenuPrincipal = 0;

                }

            }

            VariablesGlobales.glb_Referencia1 = conexion;

        }
        

    }
}
