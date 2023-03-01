using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using System.Data;

namespace MovilUtiles
{
    public partial class Solicit_Transf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["glb_User_Name"] == null)
            {
                Response.Redirect("login.aspx");

            }

            lbl_usuario.Text = "Usuario: " + Session["glb_User_Name"];

            try
            {

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_ConsultaLista_PartidasAbiertas_Solicitudes();

                this.Grid1.DataSource = objproducto.cResultado;
                this.Grid1.DataBind();

            }
            catch (Exception ex)
            {

            }

        }

    }

}