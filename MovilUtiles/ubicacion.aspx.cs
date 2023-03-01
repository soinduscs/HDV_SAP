using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using System.Threading;
using System.Configuration;

namespace MovilUtiles
{
    public partial class ubicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["glb_User_Name"] == null)
            {
                Response.Redirect("login.aspx");

            }

            lbl_usuario.Text = "Usuario: " + Session["glb_User_Name"];

            t_lote.Focus();

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

                    ddl_pasillo.Text = "";

                }
                catch
                {

                }
          
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (t_lote.Text != "")
            {

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Lote(t_lote.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_darticulo.Text = dTable.Rows[0]["itemName"].ToString();
                }
                catch
                {
                    t_darticulo.Text = "";
                }

                try
                {
                    t_stock.Text = string.Format("{0:#,##0}", double.Parse(dTable.Rows[0]["Quantity"].ToString()));  //string.Format(CultureInfo.CurrentCulture, "{0:C}", double.Parse()); ;
                }
                catch
                {
                    t_stock.Text = "";
                }

                try
                {
                    t_estado.Text = dTable.Rows[0]["nom_status"].ToString();
                }
                catch
                {
                    t_estado.Text = "";
                }

                try
                {
                     t_fumigado.Text = dTable.Rows[0]["U_FUMIGADO"].ToString();
                }

                catch
                {
                    t_fumigado.Text = "";
                }
                try
                {
                    t_cliente.Text = dTable.Rows[0]["U_NOMBCLI"].ToString();
                }
                catch
                {
                    t_cliente.Text = "";
                }

                try
                {
                    t_umedida.Text = dTable.Rows[0]["BuyUnitMsr"].ToString();
                }
                catch
                {
                    t_umedida.Text = "";
                }

                try
                {
                    t_uactual.Text = dTable.Rows[0]["BinCode"].ToString();
                }
                catch
                {
                    t_uactual.Text = "";
                }

                try
                {
                    t_bins.Text = dTable.Rows[0]["U_BINS"].ToString();
                }
                catch
                {
                    t_bins.Text = "";
                }

            }

            //  BuyUnitMsr



        }

        protected void Grabar_Click(object sender, EventArgs e)
        {

            if (Session["glb_tipo_usuario"] == "2")
            {
                //MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            {
                string mensaje;
                int nStockTransferEntry, nNewUbicacion;
                float nQuantity;
                DateTime dt;

                dt = DateTime.Now;

                string cItemCode_Solicitud, cUbicBodega_Solicitud;

                cUbicBodega_Solicitud = "";

                DropDownList drop = sender as DropDownList;
                string result;

                try
                {
                    result = drop.SelectedValue;

                }
                catch
                {
                    result = "";
                }

                string cUbicBodega, cUbicPasillo, cUbicPosicion;
                string cUbicBinCode;

                cUbicBodega = "";
                cUbicPasillo = "";
                cUbicPosicion = "";

                try
                {
                    cUbicBodega = ddl_bodega.SelectedValue.ToString();

                }
                catch
                {
                    cUbicBodega = "";
                }

                try
                {
                    cUbicPasillo = ddl_pasillo.SelectedValue.ToString();

                }
                catch
                {
                    cUbicPasillo = "";
                }

                try
                {
                    cUbicPosicion = ddl_ubicacion.SelectedValue.ToString();

                }
                catch
                {
                    cUbicPosicion = "";
                }

            
                if (cUbicBodega == "")
                {
                    Response.Write("<script>alert('Debe seleccionar una bodega valida')</script>");

                }

                if (cUbicPasillo == "")
                {
                    Response.Write("<script>alert('Debe seleccionar un pasillo valido')</script>");

                }


                if (cUbicPosicion == "")
                {
                   Response.Write("<script>alert('Debe seleccionar una ubicacion valida')</script>");

                }


                if (cUbicBodega == "" && cUbicPasillo == "" && cUbicPosicion == "")
                {
                    return;

                }

                cUbicBinCode = cUbicBodega + '-' + cUbicPasillo + '-' + cUbicPosicion;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Bodegas_Ubicaciones_x_bincode(cUbicBinCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    nNewUbicacion = int.Parse(dTable.Rows[0]["AbsEntry"].ToString());

                }
                catch
                {
                    nNewUbicacion = 0;
                }

                if (nNewUbicacion == 0)
                {
                    //MessageBox.Show("Debe seleccionar una ubicación valida, opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                ////////////////////////////////////////
                // Genero la transferencia con los bins

                string UsuarioSap, ClaveSap;

                try
                {
                    UsuarioSap = Session["glb_User_Code"].ToString();
                }
                catch
                {
                    UsuarioSap = "";
                }

                try
                {
                    ClaveSap = Session["glb_User_Psw"].ToString();
                }
                catch
                {
                    ClaveSap = "";
                }

                try
                {
                    nQuantity = float.Parse(t_stock.Text);
                }
                catch
                {
                    nQuantity = 0;
                }

                if (nQuantity == 0)
                {
                    //MessageBox.Show("Debe seleccionar un lote con stock opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                //MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                //DialogResult result;

                //result = MessageBox.Show("Esta Seguro de cambiar la ubicación de este lote", "Ubicación de Lotes ", buttons);

                //if (result == System.Windows.Forms.DialogResult.No)
                //{
                //    return;

                //}

                //mensaje = clsRecepcion.Sales_Order_Lotes(dt.ToString("yyyyMMdd"), t_itemcode.Text, int.Parse(t_lote.Text), nQuantity, "BPTP1", "BPTP1", UsuarioSap, ClaveSap);

                // Valido la ubicación para saber desde que bodega viene 

                string cBodegaOrigen = "";
                string cItemCode = "";

                if (t_lote.Text != "")
                {

                    objproducto.cls_Consulta_Lote(t_lote.Text);

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto.cResultado;

                    try
                    {
                        cBodegaOrigen = dTable1.Rows[0]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cBodegaOrigen = "";
                    }

                    try
                    {
                        cItemCode = dTable1.Rows[0]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        nQuantity = float.Parse(dTable1.Rows[0]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        dt = Convert.ToDateTime(dTable1.Rows[0]["fecha_hoy"].ToString());
                    }
                    catch
                    {
                        // dt = DateTime.Now;
                    }


                }

                int nDocEntry_Solicitud, nLineNum_Solicitud;

                //cUbicBodega
                nDocEntry_Solicitud = 0;

                /* *********************************************************** */
                /* *********************************************************** */
                /* Valido si el lote esta en alguna solicitud de transferencia */
                /* *********************************************************** */
                /* *********************************************************** */

                clsProduccion objproducto1 = new clsProduccion();
                objproducto1.cls_Consulta_Lote_en_solicitud_transferencia(t_lote.Text);

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto1.cResultado;

                try
                {
                    nDocEntry_Solicitud = int.Parse(dTable2.Rows[0]["DocEntry"].ToString());

                }
                catch
                {
                    nDocEntry_Solicitud = 0;
                }

                try
                {
                    nLineNum_Solicitud = int.Parse(dTable2.Rows[0]["LineNum"].ToString());

                }
                catch
                {
                    nLineNum_Solicitud = 0;
                }

                try
                {
                    cItemCode_Solicitud = dTable2.Rows[0]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode_Solicitud = "";
                }

                try
                {
                    cUbicBodega_Solicitud = dTable2.Rows[0]["WhsCode"].ToString();
                }
                catch
                {
                    cUbicBodega_Solicitud = "";
                }

                //Response.Write("<script>alert('Proceso de cambio de ubicacion -- 1')</script>");

                //t_cliente.Text = dt.ToString("yyyyMMdd");

                //return;

                //Thread.Sleep(9000);

                /* *********************************************************** */

                if (nDocEntry_Solicitud == 0)
                {

                    mensaje = "";

                    try
                    {
                        mensaje = clsRecepcion.Stock_Transfer_Ubicaciones_v2(dt.ToString("yyyyMMdd"), cItemCode, int.Parse(t_lote.Text), nQuantity, cBodegaOrigen, cUbicBodega, nNewUbicacion, 0, 0, UsuarioSap, ClaveSap);
                        //mensaje = clsRecepcion.Stock_Transfer_Ubicaciones_v2("20221024", cItemCode, int.Parse(t_lote.Text), nQuantity, cBodegaOrigen, cUbicBodega, nNewUbicacion, 0, 0, UsuarioSap, ClaveSap);

                    }
                    catch
                    {

                    }

                    //Response.Write("<script>alert('Proceso de cambio de ubicacion -- 1.1')</script>");

                    t_cliente.Text = mensaje.ToString();

                    //return;

                    nStockTransferEntry = 0;

                    try
                    {
                        nStockTransferEntry = int.Parse(mensaje);

                    }
                    catch
                    {
                        nStockTransferEntry = 0;

                    }

                    //Response.Write("<script>alert('ERROR: " + mensaje.ToString() + "' )</script>");

                    if (nStockTransferEntry > 0)
                    {
                        Response.Write("<script>alert('Ubicacion Asignada Exitosamente -- 1')</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('ERR-" + mensaje.ToString() + "-" + dt.ToString("yyyyMMdd") + "')</script>");
                        t_cliente.Text = mensaje.ToString() + " - " + dt.ToString("yyyyMMdd");

                    }

                    t_lote.Text = "";
                    t_darticulo.Text = "";
                    t_estado.Text = "";
                    //t_cliente.Text = "";
                    t_stock.Text = "";
                    t_umedida.Text = "";
                    t_uactual.Text = "";
                    //ddl_ubicacion.Items.Clear();

                    t_lote.Focus();

                    return;

                }

                Response.Write("<script>alert('Ubicacion PASO -- 2')</script>");

                if (nDocEntry_Solicitud > 0)
                {

                    if (cUbicBodega_Solicitud != cUbicBodega)
                    {
                        Response.Write("<script>alert('El lote esta incluido en la solicitud de transferencia " + nDocEntry_Solicitud.ToString() + ", cuyo almacen de destino es diferente al seleccionado, Debe seleccionar una ubicacion del almacen " + cUbicBodega_Solicitud + "' )</script>");
                        return;
                    }

                    mensaje = "";

                    try
                    {
                        mensaje = clsRecepcion.Stock_Transfer_Ubicaciones_v2(dt.ToString("yyyyMMdd"), cItemCode, int.Parse(t_lote.Text), nQuantity, cBodegaOrigen, cUbicBodega, nNewUbicacion, nDocEntry_Solicitud, nLineNum_Solicitud, UsuarioSap, ClaveSap);

                    }
                    catch
                    {

                    }

                    try
                    {
                        nStockTransferEntry = int.Parse(mensaje);
                        //MessageBox.Show("Proceso Terminado Exitosamente", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //button1.Enabled = false;

                        Response.Write("<script>alert('Ubicacion Asignada Exitosamente -- 2')</script>");

                    }
                    catch
                    {
                        //MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nStockTransferEntry = 0;

                        Response.Write("<script>alert('ERROR: " + mensaje.ToString() + "' )</script>");

                    }

                    t_lote.Text = "";
                    t_darticulo.Text = "";
                    t_estado.Text = "";
                    t_cliente.Text = "";
                    t_stock.Text = "";
                    t_umedida.Text = "";
                    t_uactual.Text = "";
                    //ddl_ubicacion.Items.Clear();

                    t_lote.Focus();

                    return;

                }

                //Button1_Click(sender, e);

                Response.Write("<script>alert('Ubicacion PASO -- 3')</script>");

                string c_u_sql;

                clsProduccion objproducto3 = new clsProduccion();
                objproducto3.cls_Consulta_Lote(t_lote.Text);

                DataTable dTable3 = new DataTable();
                dTable3 = objproducto3.cResultado;

                try
                {
                    c_u_sql = dTable3.Rows[0]["BinCode"].ToString();
                }
                catch
                {
                    c_u_sql = "";
                }

                string cUbicBodega_f, cUbicPasillo_f, cUbicPosicion_f;
                string cUbicBinCode_f;

                cUbicBodega_f = "";
                cUbicPasillo_f = "";
                cUbicPosicion_f = "";

                try
                {
                    cUbicBodega_f = ddl_bodega.SelectedValue.ToString();

                }
                catch
                {
                    cUbicBodega_f = "";
                }

                try
                {
                    cUbicPasillo_f = ddl_pasillo.SelectedValue.ToString();

                }
                catch
                {
                    cUbicPasillo_f = "";
                }

                try
                {
                    cUbicPosicion_f = ddl_ubicacion.SelectedValue.ToString();

                }
                catch
                {
                    cUbicPosicion_f = "";
                }

                cUbicBinCode_f = cUbicBodega_f + '-' + cUbicPasillo_f + '-' + cUbicPosicion_f;

                Response.Write("<script>alert('Ubicacion PASO -- 3')</script>");

                if (c_u_sql.Trim() != cUbicBinCode_f.Trim())
                {

                    mensaje = "";

                    try
                    {
                        mensaje = clsRecepcion.Stock_Transfer_Ubicaciones_v2(dt.ToString("yyyyMMdd"), cItemCode, int.Parse(t_lote.Text), nQuantity, cBodegaOrigen, cUbicBodega, nNewUbicacion, 0, 0, UsuarioSap, ClaveSap);

                    }
                    catch
                    {

                    }

                    t_cliente.Text = mensaje.ToString();

                    try
                    {
                        nStockTransferEntry = int.Parse(mensaje);
                        //MessageBox.Show("Proceso Terminado Exitosamente", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //button1.Enabled = false;

                        Response.Write("<script>alert('Ubicacion Asignada Exitosamente -- 3')</script>");

                    }
                    catch
                    {
                        //MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nStockTransferEntry = 0;

                        Response.Write("<script>alert('ERROR: " + mensaje.ToString() + "' )</script>");

                    }


                }
                else
                {

                    Response.Write("<script>alert('PASO X ACA ' )</script>");

                }

            }

            Response.Write("<script>alert('Ubicacion PASO -- 4')</script>");

            Response.Write("<script>alert('Ubicacion Asignada Exitosamente')</script>");

            t_lote.Text = "";
            t_darticulo.Text = "";
            t_estado.Text = "";
            t_cliente.Text = "";
            t_stock.Text = "";
            t_umedida.Text = "";
            t_uactual.Text = "";
            //ddl_ubicacion.Items.Clear();

            t_lote.Focus();

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page_Inter.aspx");

        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stock_Ubicacion.aspx");
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
                    objproducto.cls_Consulta_Pasillo_Ubicaciones_x_bodegas(cWhsCode);

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

        protected void ddl_pasillo_SelectedIndexChanged(object sender, EventArgs e)
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

            if (cWhsCode != "" || cPasillo != "")
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Pasillo_Ubicaciones_x_bodegas_y_pasillo(cWhsCode, cPasillo);

                ddl_ubicacion.DataValueField = "SL2Code";
                ddl_ubicacion.DataTextField = "SL2Code";

                ddl_ubicacion.DataSource = objproducto.cResultado;
                ddl_ubicacion.DataBind();

            }

            try
            {
                ddl_ubicacion.SelectedIndex = 0;

            }
            catch
            {

            }


        }

        protected void t_uactual_TextChanged(object sender, EventArgs e)
        {

        }
    }
}