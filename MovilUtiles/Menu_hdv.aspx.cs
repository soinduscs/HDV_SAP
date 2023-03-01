using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace MovilUtiles
{
    public partial class Menu_hdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["glb_User_Name"] == null)
            {
                Response.Redirect("login_hdv.aspx");

            }


            lbl_usuario.Text = "Usuario: " + Session["glb_User_Name"];

        }

        protected void btn_ubicacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("ubicacion.aspx");

        }

    }

}