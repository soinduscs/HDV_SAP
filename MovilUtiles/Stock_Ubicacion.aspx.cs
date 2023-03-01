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
    public partial class Stock_Ubicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["glb_User_Name"] == null)
            {
                Response.Redirect("login.aspx");

            }

            lbl_usuario.Text = "Usuario: " + Session["glb_User_Name"];

            if (!IsPostBack)
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Bodegas_Ubicaciones();

                ddl_bodega.DataValueField = "WhsCode";
                ddl_bodega.DataTextField = "WhsCode";

                ddl_bodega.DataSource = objproducto.cResultado;
                ddl_bodega.DataBind();

                try
                {
                    ddl_bodega.SelectedIndex = 0;

                    ddl_bodega_SelectedIndexChanged(sender, e);

                }
                catch
                {

                }

            }

        }
        protected void Volver_Click(object sender, EventArgs e)
            {
               Response.Redirect("Page_Inter.aspx");
            }

        protected void ddl_bodega_SelectedIndexChanged(object sender, EventArgs e)
        {

            string cWhsCode;

            try
            {
                cWhsCode = ddl_bodega.SelectedValue;

            }
            catch
            {
                cWhsCode = "";

            }

            if (cWhsCode != "")
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Pasillo_Ubicaciones_x_bodegas_i(cWhsCode);

                ddl_pasillo.DataValueField = "SL1Code";
                ddl_pasillo.DataTextField = "SL1Code";

                ddl_pasillo.DataSource = objproducto.cResultado;
                ddl_pasillo.DataBind();

            }

            try
            {
                ddl_pasillo.SelectedIndex = 0;

            }
            catch
            {

            }


        }

        protected void cbb_consultar_Click(object sender, EventArgs e)
        {

            string cWhsCode, cPasillo;

            try
            {
                cWhsCode = ddl_bodega.SelectedValue;

            }
            catch
            {
                cWhsCode = "";

            }

            try
            {
                cPasillo = ddl_pasillo.SelectedValue;

            }
            catch
            {
                cPasillo = "";

            }


            if (cWhsCode != "")
            {

                try
                {

                    clsProduccion objproducto = new clsProduccion();
                    objproducto.cls_ConsultaLista_Ubicacion_Lote("L", cWhsCode, cPasillo);

                    this.Grid1.DataSource = objproducto.cResultado;
                    this.Grid1.DataBind();

                }
                catch (Exception ex)
                {
                    
                }

            }

        }

        protected void cbb_sin_ubicacion_Click(object sender, EventArgs e)
        {

            string cWhsCode, cPasillo;

            try
            {
                cWhsCode = ddl_bodega.SelectedValue;

            }
            catch
            {
                cWhsCode = "";

            }

            try
            {
                cPasillo = ddl_pasillo.SelectedValue;

            }
            catch
            {
                cPasillo = "";

            }


            if (cWhsCode != "")
            {

                try
                {

                    clsProduccion objproducto = new clsProduccion();
                    objproducto.cls_ConsultaLista_Ubicacion_Lote("X", cWhsCode, cPasillo);

                    this.Grid1.DataSource = objproducto.cResultado;
                    this.Grid1.DataBind();

                }
                catch (Exception ex)
                {

                }

            }

        }

    }

}
