using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CapaNegocio;

namespace MovilUtiles
{
    public partial class Solicit_Transf1 : System.Web.UI.Page
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
                string cDocEntry = Request["DocEntry"];

                t_docentry.Text = cDocEntry;
                t_solicitante.Text = "";
                t_de_almacen.Text = "";


                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Solicitud_de_transferencia(cDocEntry);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_solicitante.Text = dTable.Rows[0]["U_NAME"].ToString();
                }
                catch
                {
                    t_solicitante.Text = "";
                }

                try
                {
                    t_de_almacen.Text = dTable.Rows[0]["Filler"].ToString();
                }
                catch
                {
                    t_de_almacen.Text = "";
                }

                clsProduccion objproducto1 = new clsProduccion();
                objproducto1.cls_Consulta_Solicitud_de_transferencia_x_lote(cDocEntry);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                DataTable dt = new DataTable();

                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("ItemName", typeof(string));
                    dt.Columns.Add("MdAbsEntry", typeof(string));
                    dt.Columns.Add("MdAbsEntry1", typeof(string));
                    dt.Columns.Add("AllocQty", typeof(string));
                    dt.Columns.Add("WhsCode", typeof(string));
                    dt.Columns.Add("FromWhsCod", typeof(string));
                    dt.Columns.Add("LineNum", typeof(string));
                    dt.Columns.Add("ItemCode", typeof(string));
                    dt.Columns.Add("OcrCode", typeof(string));
                    dt.Columns.Add("OcrCode2", typeof(string));
                    dt.Columns.Add("OcrCode3", typeof(string));

                }

                string cItemName, cLote, WhsCode;
                string cItemCode, FromWhsCod;
                string cOcrCode, cOcrCode2, cOcrCode3;

                double nQuantity;
                int nLineNum;

                for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
                {

                    try
                    {
                        nQuantity = Convert.ToDouble(dTable1.Rows[i]["AllocQty"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;

                    }

                    if (nQuantity > 0)
                    {
                        DataRow grilla = dt.NewRow();

                        try
                        {
                            cItemName = dTable1.Rows[i]["ItemName"].ToString();
                        }
                        catch
                        {
                            cItemName = "";

                        }

                        try
                        {
                            cLote = dTable1.Rows[i]["MdAbsEntry"].ToString();
                        }
                        catch
                        {
                            cLote = "";

                        }

                        try
                        {
                            WhsCode = dTable1.Rows[i]["WhsCode"].ToString();
                        }
                        catch
                        {
                            WhsCode = "";

                        }

                        try
                        {
                            FromWhsCod = dTable1.Rows[i]["FromWhsCod"].ToString();
                        }
                        catch
                        {
                            FromWhsCod = "";

                        }

                        try
                        {
                            nLineNum = Convert.ToInt32(dTable1.Rows[i]["LineNum"].ToString());
                        }
                        catch
                        {
                            nLineNum = 0;

                        }

                        try
                        {
                            cItemCode = dTable1.Rows[i]["ItemCode"].ToString();
                        }
                        catch
                        {
                            cItemCode = "";

                        }

                        try
                        {
                            cOcrCode = dTable1.Rows[i]["OcrCode"].ToString();
                        }
                        catch
                        {
                            cOcrCode = "";

                        }

                        try
                        {
                            cOcrCode2 = dTable1.Rows[i]["OcrCode2"].ToString();
                        }
                        catch
                        {
                            cOcrCode2 = "";

                        }

                        try
                        {
                            cOcrCode3 = dTable1.Rows[i]["OcrCode3"].ToString();
                        }
                        catch
                        {
                            cOcrCode3 = "";

                        }

                        grilla[0] = cItemName + " ";
                        grilla[1] = cLote;
                        grilla[2] = "";
                        grilla[3] = nQuantity.ToString("N") + " ";
                        grilla[4] = FromWhsCod;
                        grilla[5] = WhsCode;
                        grilla[6] = nLineNum.ToString();
                        grilla[7] = cItemCode;
                        grilla[8] = cOcrCode;
                        grilla[9] = cOcrCode2;
                        grilla[10] = cOcrCode3;

                        dt.Rows.Add(grilla);

                        Grid1.DataSource = dt;
                        Grid1.DataBind();

                    }

                }

            }

            Grid1.Columns[6].Visible = false;
            Grid1.Columns[7].Visible = false;
            Grid1.Columns[8].Visible = false;
            Grid1.Columns[9].Visible = false;
            Grid1.Columns[10].Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            t_referencia.Text = "";

            string cNewLote;

            try
            {
                cNewLote = t_lote.Text;

            }
            catch
            {
                cNewLote = "";

            }

            if (cNewLote == "")
            {
                t_referencia.Text = "Debe ingresar un lote válido";
                t_lote.Text = "";
                t_lote.Focus();
                return;
            }

            string cLote;

            for (int i = 0; i <= Grid1.Rows.Count - 1; i++)
            {

                cLote = "";

                try
                {
                    cLote = Grid1.Rows[i].Cells[1].Text;
                }
                catch
                {
                    cLote = "";

                }

                if (cLote == cNewLote)
                {
                    Grid1.Rows[i].Cells[2].Text = cNewLote;
                    t_lote.Text = "";
                    t_lote.Focus();
                    return;

                }

            }

            t_referencia.Text = "Lote ingresado No solicitado";
            t_lote.Text = "";
            t_lote.Focus();

        }

        protected void Grabar_Click(object sender, EventArgs e)
        {
            if (Session["glb_tipo_usuario"] == "2")
            {
                //MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string mensaje;

            DateTime dt;

            dt = DateTime.Now;

            int nLineNum, nDocEntry;

            string cFecha, cItemCode, cLote;
            string cDimension1, cDimension2, cDimension3;
            string cWhsCode, cBodegaDestino, cLoteNew;

            double nQuantity;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Genero un resumen con los registros seleccionados

            string[] grilla;
            grilla = new string[30];

            string[,] d_arrDetalle = new string[20, 1000];

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j;

            j = 0;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            if (nDocEntry == 0)
            {
                Response.Write("<script>alert('Debe seleccionar una solicitud de traslado valida')</script>");
                return;

            }

            string[,] d_arrDetalle1 = new string[10, 1000];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle1[1, i] = "";

            }

            j = 0;

            for (int x = 0; x <= Grid1.Rows.Count - 1; x++)
            {

                cItemCode = Grid1.Rows[x].Cells[7].Text;
                cLote = Grid1.Rows[x].Cells[1].Text;
                cLoteNew = Grid1.Rows[x].Cells[2].Text;

                if (cLote.Trim() == cLoteNew.Trim())
                {
                    try
                    {
                        nQuantity = Convert.ToDouble(Grid1.Rows[x].Cells[3].Text);
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        nLineNum = Convert.ToInt32(Grid1.Rows[x].Cells[6].Text);

                    }
                    catch
                    {
                        nLineNum = -1;

                    }

                    cWhsCode = Grid1.Rows[x].Cells[4].Text;
                    cBodegaDestino = Grid1.Rows[x].Cells[5].Text;


                    d_arrDetalle1[1, j] = cItemCode;
                    d_arrDetalle1[2, j] = cLote;
                    d_arrDetalle1[3, j] = nQuantity.ToString();
                    d_arrDetalle1[4, j] = cWhsCode;
                    d_arrDetalle1[5, j] = cBodegaDestino;
                    d_arrDetalle1[6, j] = nLineNum.ToString();

                    d_arrDetalle1[7, j] = "";

                    if (Grid1.Rows[x].Cells[8].Text != "&nbsp;")
                    {
                        d_arrDetalle1[7, j] = Grid1.Rows[x].Cells[8].Text;

                    }

                    d_arrDetalle1[8, j] = "";

                    if (Grid1.Rows[x].Cells[9].Text != "&nbsp;")
                    {
                        d_arrDetalle1[8, j] = Grid1.Rows[x].Cells[9].Text;

                    }

                    d_arrDetalle1[9, j] = "";

                    if (Grid1.Rows[x].Cells[10].Text != "&nbsp;")
                    {
                        d_arrDetalle1[9, j] = Grid1.Rows[x].Cells[10].Text;

                    }

                    j += 1;

                }
            
            }

            string cLineNum_Ref, cExiste_Det;
            int nCabecera;

            nCabecera = 0;

            if (j>0)
            {
                for (int x = 0; x <= j - 1; x++)
                {

                    cLineNum_Ref = d_arrDetalle1[6, x];
                    cExiste_Det = "N";

                    for (int z = 0; z <= nCabecera - 1; z++)
                    {
                        if (cLineNum_Ref == d_arrDetalle[16, z])
                        {
                            cExiste_Det = "Y";
                            break;
                        }

                    }

                    if (cExiste_Det == "N")
                    {

                        d_arrDetalle[1, nCabecera] = d_arrDetalle1[1, x]; //cItemCode
                        d_arrDetalle[2, nCabecera] = d_arrDetalle1[4, x]; //cWhsCode
                        d_arrDetalle[3, nCabecera] = 0.ToString(); // nQuantity
                        d_arrDetalle[4, nCabecera] = d_arrDetalle1[5, x]; // cBodegaDestino

                        d_arrDetalle[10, nCabecera] = "";
                        d_arrDetalle[11, nCabecera] = d_arrDetalle1[7, x]; // cDimension1;
                        d_arrDetalle[12, nCabecera] = d_arrDetalle1[8, x]; // cDimension2;
                        d_arrDetalle[13, nCabecera] = d_arrDetalle1[9, x]; // cDimension3;
                        d_arrDetalle[14, nCabecera] = "Comments"; //  t_Comments.Text;
                        d_arrDetalle[15, nCabecera] = "nombre"; //  t_nombre.Text;
                        d_arrDetalle[16, nCabecera] = d_arrDetalle1[6, x]; // nLineNum.ToString();
                        d_arrDetalle[17, nCabecera] = nDocEntry.ToString();

                        nCabecera += 1;

                    }

                }

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////
                // Recalculo el total por linea

                double nQuantity_Det;

                for (int x = 0; x <= nCabecera - 1; x++)
                {

                    cLineNum_Ref = d_arrDetalle[16, x];
                    nQuantity = 0;

                    for (int z = 0; z <= j - 1; z++)
                    {
                        if (cLineNum_Ref == d_arrDetalle1[6, z])
                        {
                            try
                            {
                                nQuantity_Det = Convert.ToDouble(d_arrDetalle1[3, z]);

                            }
                            catch
                            {
                                nQuantity_Det = 0;

                            }

                            nQuantity += nQuantity_Det;

                        }

                    }

                    d_arrDetalle[3, x] = nQuantity.ToString(); // nQuantity

                }

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////

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

                dt = DateTime.Now;

                cFecha = dt.ToString("yyyyMMdd");

                int nStockTransferEntry;

                nStockTransferEntry = 0;

                mensaje = clsOrdenFabricacion.Transfer_Stock(nDocEntry, cFecha, d_arrDetalle, d_arrDetalle1, "", "", UsuarioSap, ClaveSap);

                try
                {
                    nStockTransferEntry = int.Parse(mensaje);
                    Response.Write("<script>alert('Traslado realizado con existo - " + mensaje + "')</script>");
                    
                    Response.Redirect("Solicit_Transf.aspx");

                }
                catch
                {
                    nStockTransferEntry = 0;
                    Response.Write("<script>alert('Error en la generación del traslado :::::: " + mensaje + "')</script>");

                }

            }

        }

    }

}
