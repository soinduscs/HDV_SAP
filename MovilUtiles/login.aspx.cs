using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using CapaNegocio;

namespace MovilUtiles
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            t_usuario.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (t_usuario.Text != "" && t_Clave.Text != "")
            {

                Session["glb_tipo_usuario"] = "";
                Session["glb_Referencia1"] = "";
                Session["glb_User_Name"] = "";
                Session["glb_User_id"] = "";

                conexion();

                if ((Session["glb_tipo_usuario"] == "1") || (Session["glb_tipo_usuario"] == "2"))
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

            Session["glb_Referencia1"] = "";
            Session["glb_Referencia2"] = "";

            Session["glb_User_Code"] = t_usuario.Text;
            Session["glb_User_Name"] = "";
            Session["glb_User_Psw"] = t_Clave.Text.Trim();
            Session["glb_tipo_usuario"] = "";

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
                Session["accesoMenuPrincipal"] = 1;

                string user_name, produccion, porteria;
                string romana, user_code;

                int usr_id;

                Session["glb_User_Name"] = "";

                user_name = "";
                produccion = "";
                porteria = "";
                romana = "";
                usr_id = 0;

                user_code = Session["glb_User_Code"].ToString();

                clsMaestros objproducto6 = new clsMaestros();
                objproducto6.cls_lee_usuario(user_code);

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

                Session["glb_User_Name"] = user_name;
                Session["glb_User_id"] = usr_id;

            }
            catch
            {
                conexion = "Nombre de Usuario o Clave de Acceso incorrecta";
            }

            if (conexion == "")
            {
                Session["glb_tipo_usuario"] = "1"; // Usuario SAP con Licencia

            }

            else
            {
                if (conexion == "Sin licencias SAP")
                {
                    Session["glb_tipo_usuario"] = "2"; // Sin licencias SAP

                }
                else
                {
                    Session["accesoMenuPrincipal"] = 0;

                }

            }

            Session["glb_Referencia1"] = conexion;

        }


    }
}