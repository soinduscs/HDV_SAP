using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;

namespace MovilUtiles
{
    public partial class Consumo_of : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["glb_User_Name"] == null)
            {
                Response.Redirect("login.aspx");

            }

            lbl_usuario.Text = "Usuario: " + Session["glb_User_Name"];

            t_lote.Focus();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (t_lote.Text != "")
            {
                int nAbsEntry;

                nAbsEntry = 0;

                try
                {
                    nAbsEntry = Convert.ToInt32(t_lote.Text);

                }
                catch
                {
                    nAbsEntry = 0;

                }

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lotes_Asignados_para_Consumir_x_of(nAbsEntry);

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
                    t_stock.Text = string.Format("{0:#,##0}", double.Parse(dTable.Rows[0]["AllocQty"].ToString()));  //string.Format(CultureInfo.CurrentCulture, "{0:C}", double.Parse()); ;
                }
                catch
                {
                    t_stock.Text = "";
                }

                try
                {
                    t_almacen.Text = dTable.Rows[0]["LocCode"].ToString();
                }
                catch
                {
                    t_almacen.Text = "";
                }

                try
                {
                    t_bins.Text = dTable.Rows[0]["Bins"].ToString();
                }
                catch
                {
                    t_bins.Text = "";
                }

                try
                {
                    t_volteados.Text = dTable.Rows[0]["Volteados"].ToString();
                }
                catch
                {
                    t_volteados.Text = "";
                }

                try
                {
                    t_numof.Text = dTable.Rows[0]["DocEntry"].ToString();
                }
                catch
                {
                    t_numof.Text = "";
                }

            }

        }

        protected void Grabar_Click(object sender, EventArgs e)
        {

            int nAbsEntry, nNumOF;
            int nBins, nVolteados, nCantBins_x_Voltear;

            try
            {
                nAbsEntry = Convert.ToInt32(t_lote.Text);

            }
            catch
            {
                nAbsEntry = 0;

            }

            try
            {
                nNumOF = Convert.ToInt32(t_numof.Text);

            }
            catch
            {
                nNumOF = 0;

            }

            if (nAbsEntry == 0)
            {
                Response.Write("<script>alert('Debe seleccionar un lote válido')</script>");
                return;

            }

            // *****************************************************
            // Cargo los datos que me faltan

            string cWharehouse;

            int nLineNum;

            double nStockLote, nSotckAsignado, nQuantity;
            
            string cCardCode_Cliente, cCardName_Cliente;
            string cCardCode_Productor, cCardName_Productor;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_Lotes_Asignados_para_Consumir_x_of(nAbsEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            nStockLote = 0;
            nSotckAsignado = 0;
            nLineNum = 0;

            cCardCode_Productor = "";
            cCardName_Productor = "";
            cCardCode_Cliente = "";
            cCardName_Cliente = "";

            try
            {
                nSotckAsignado = double.Parse(dTable.Rows[0]["AllocQty"].ToString());  
            }
            catch
            {
                nSotckAsignado = 0;
            }

            try
            {
                nStockLote = double.Parse(dTable.Rows[0]["QuantityIni"].ToString());  
            }
            catch
            {
                nStockLote = 0;
            }

            try
            {
                cWharehouse = dTable.Rows[0]["LocCode"].ToString();
            }
            catch
            {
                cWharehouse = "";
            }

            try
            {
                cCardCode_Productor = dTable.Rows[0]["MnfSerial"].ToString();

            }
            catch
            {
                cCardCode_Productor = "";

            }

            try
            {
                cCardName_Productor = dTable.Rows[0]["U_NOMBPROD"].ToString();

            }
            catch
            {
                cCardName_Productor = "";

            }

            try
            {
                cCardCode_Cliente = dTable.Rows[0]["LotNumber"].ToString();

            }
            catch
            {
                cCardCode_Cliente = "";

            }

            try
            {
                cCardName_Cliente = dTable.Rows[0]["U_NOMBCLI"].ToString();

            }
            catch
            {
                cCardName_Cliente = "";

            }

            try
            {
                nLineNum = Convert.ToInt32 (dTable.Rows[0]["LineNum"].ToString());

            }
            catch
            {
                nLineNum = 0;

            }
           
            nBins = 0;
            nVolteados = 0;
            nCantBins_x_Voltear = 0;

            try
            {
                nBins = Convert.ToInt32(t_bins.Text);
                nVolteados = Convert.ToInt32(t_volteados.Text);

            }
            catch
            {
                nBins = 0;
                nVolteados = 0;

            }

            nCantBins_x_Voltear = nBins - nVolteados;

            if (nCantBins_x_Voltear < 0)
            {
                nCantBins_x_Voltear = 0;
            }

            if (nCantBins_x_Voltear == 0)
            {
                Response.Write("<script>alert('No Existen Bins por voltear')</script>");
                return;

            }

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                Response.Write("<script>alert('Su licencia NO permite realizar esta actividad, contacte al administrador del sistema')</script>");
                return;

            }

            // *****************************************************************************************************************************
            // *****************************************************************************************************************************
            // *****************************************************************************************************************************

            // Calculo el peso a consumir 

            int nCantidadBins;

            nCantidadBins = 1; // siempre es uno por esta plataforma
            nQuantity = 0; 

            if (nCantBins_x_Voltear == 1)
            {
                // lote de cierre - se rebaja el total pendiente x voltear

                nQuantity = nStockLote;

            }

            if (nCantBins_x_Voltear > 1)
            {
                // se calcula el peso del bins dividiendo el total de bins x el peso total

                nQuantity = Math.Round(nSotckAsignado / nBins, 2);

                if (nQuantity > nStockLote)
                {
                    if (((nQuantity / nStockLote) - 1) > 1)
                    {
                        Response.Write("<script>alert('Existe una inconsistencia entre el stock disponible y la cantidad de Bins a Voltear, opción Cancelada')</script>");
                        return;

                    }
                    else
                    {
                        nQuantity = nStockLote;

                    }

                }

            }

            // *****************************************************************************************************************************
            // *****************************************************************************************************************************

            string UsuarioSap, ClaveSap;
            string cErrorMensaje;

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


            DateTime dFecha;
            string cDocDate; 

            try
            {
                dFecha = DateTime.Now;
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDocDate = dFecha.ToString("yyyyMMdd");

            String mensaje;

            mensaje = "";

            mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nNumOF, nLineNum, nQuantity, cWharehouse, nCantidadBins, nAbsEntry.ToString(), cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap, "","");

            int nSalidaMercaderiaEntry;

            try
            {
                nSalidaMercaderiaEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                Response.Write("<script>alert('Consumo realizado con existo - " + mensaje + "')</script>");

                t_lote.Text = "";
                t_darticulo.Text = "";
                t_stock.Text = "";
                t_almacen.Text = "";
                t_bins.Text = "";
                t_volteados.Text = "";
                t_numof.Text = "";

                t_lote.Focus();

            }
            catch
            {
                nSalidaMercaderiaEntry = 0;
                cErrorMensaje = mensaje;

                Response.Write("<script>alert('Error en la generación del Consumo :::::: " + cErrorMensaje + "')</script>");

                t_lote.Focus();

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            
        }

    }

}