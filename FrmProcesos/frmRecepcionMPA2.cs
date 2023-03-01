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
using System.Drawing.Printing;

namespace FrmProcesos
{
    public partial class frmRecepcionMPA2 : Form
    {
        public frmRecepcionMPA2()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPA2_Load(object sender, EventArgs e)
        {

            cbb_seleccionar_impresora.Items.Clear();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                try
                {
                    cbb_seleccionar_impresora.Items.Add(strPrinter);
                }
                catch
                {

                }

            }

            ///////////////////////////////////////////////////////

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            ///////////////////////////////////////////////////////


        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_LineId = 0;

            frmSel_OrdendeCompra1 f2 = new frmSel_OrdendeCompra1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();
                t_numoc.Text = VariablesGlobales.glb_NumOC.Trim();
                t_itemcode.Text = VariablesGlobales.glb_ItemCode.Trim();
                t_itemname.Text = VariablesGlobales.glb_ItemName.Trim();
                t_line_ref.Text = Convert.ToString(VariablesGlobales.glb_LineId);

                int DocNum;
                string CardCode_Serv, CardName_Serv;

                CardCode_Serv = "";
                CardName_Serv = "";

                try
                {
                    DocNum = int.Parse(VariablesGlobales.glb_NumOC);
                }
                catch
                {
                    DocNum = 0;
                }

                if (DocNum > 0)
                {
                    clsOrdendeCompra objproducto = new clsOrdendeCompra();
                    objproducto.cls_Consultar_Ordenes_de_compra_x_DocNum(DocNum);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        CardCode_Serv = dTable.Rows[0]["U_ClienteServ"].ToString();

                    }
                    catch
                    {
                        CardCode_Serv = "";

                    }

                    try
                    {
                        CardName_Serv = dTable.Rows[0]["U_ClienteServ_Name"].ToString();

                    }
                    catch
                    {
                        CardName_Serv = "";

                    }

                    t_cardcode_clte.Text = CardCode_Serv;
                    t_cardname_clte.Text = CardName_Serv;

                    double nPrecioXUnidad;

                    objproducto.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text,0);

                    DataTable dTable9 = new DataTable();
                    dTable9 = objproducto.cResultado;

                    try
                    {
                        nPrecioXUnidad = Convert.ToDouble(dTable9.Rows[0]["Price"].ToString());

                    }
                    catch
                    {
                        nPrecioXUnidad = 0;

                    }

                    //t_precio_unit.Text = nPrecioXUnidad.ToString("N2");

                }

            }


        }

        private void tsb_agrega_oc_Click(object sender, EventArgs e)
        {

            if (t_cardname.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Proveedor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_itemname.Text == "")
            {
                MessageBox.Show("Debe seleccionar un insumo válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nLineas, nLoteInsumos;

            clsOrdendeCompra objproducto = new clsOrdendeCompra();

            objproducto.cls_Consultar_Lote_Max_Insumo();

            DataTable dTable9 = new DataTable();
            dTable9 = objproducto.cResultado;

            try
            {
                nLoteInsumos = Convert.ToInt32(dTable9.Rows[0]["Folio"].ToString());

            }
            catch
            {
                nLoteInsumos = 0;

            }

            string[] grilla;
            grilla = new string[10];            

            nLineas = 0;

            if (Grid1.RowCount == 0)
            {
                nLineas = 1;
            }
            else
            {
                nLineas = Convert.ToInt32(Grid1[0, Grid1.RowCount - 1].Value);
                nLineas += 1;

            }

            nLoteInsumos += nLineas;

            grilla[0] = nLineas.ToString();
            grilla[1] = 0.ToString(); 
            grilla[2] = nLoteInsumos.ToString();
            grilla[3] = "";

            Grid1.Rows.Add(grilla);
            



        }

        private void Calcula_total_unidades()
        {

            int nCantidad, nCantidadTotal;

            nCantidadTotal = 0;

            for (int x = 0; x <= Grid1.RowCount-1; x++)
            {

                try
                {
                    nCantidad = Convert.ToInt32(Grid1[1, x].Value.ToString());

                }
                catch
                {
                    nCantidad = 0;

                }

                nCantidadTotal += nCantidad;

            }

            t_cantidad_total.Text = nCantidadTotal.ToString();


        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil, nCantidad;

            try
            {
                fil = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                nCantidad = Convert.ToInt32(Grid1[1, fil].Value);

            }
            catch
            {
                nCantidad = 0;

            }


            Grid1[1, fil].Value = nCantidad.ToString();

            Calcula_total_unidades();


        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar una linea válida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Recepción de Insumos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {

            if (t_num_guia.Text == "")
            {
                MessageBox.Show("Debe ingresar una guía válida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_cantidad_total.Text == "")
            {
                MessageBox.Show("Debe ingresar un detalle de bultos válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_cardname.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Proveedor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_itemname.Text == "")
            {
                MessageBox.Show("Debe seleccionar un insumo válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cAlmacen;

            try
            {
                cAlmacen = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cAlmacen = "";

            }

            if (cAlmacen == "")
            {
                MessageBox.Show("Debe seleccionar un almacen válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nNumOC;

            try
            {
                nNumOC = Convert.ToInt32(t_numoc.Text);

            }
            catch
            {
                nNumOC = 0;

            }

            if (nNumOC == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Compra válida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsProductos objproducto4 = new clsProductos();
            DataTable dTable4 = new DataTable();

            int[] arrCantidad = new int[100];
            string[] arrItemCode = new string[100];
            string[] arrBodega1 = new string[100];
            string[] arrBodega2 = new string[100];
            string[] arrBodega3 = new string[100];

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //  
            // Genero el proceso de grabación 
            //  
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Recepción de la Guía", "Recepción de Insumos", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            int nPurchaseOrder, nBaseLineNum;
            //int nLote;
            int nNumGuia;
            int nEntradaMercaderiaEntry;
            int nU_COMPRAPRODUCTOR;

            double nPrecioXUnidad;

            string cCardCode, cCardName, mensaje;
            string cItemCode, cWareHouse, cItemName;
            string CardCode_Serv, CardName_Serv;

            clsOrdendeCompra objproducto = new clsOrdendeCompra();

            clsRecepcion objproducto1 = new clsRecepcion();

            try
            {
                nNumOC = int.Parse(t_numoc.Text);

            }
            catch
            {
                nNumOC = -1;
            }

            try
            {
                cItemCode = t_itemcode.Text;

            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                nBaseLineNum = int.Parse(t_line_ref.Text);
            }
            catch
            {
                nBaseLineNum = 0;
            }

            objproducto.cls_Consultar_Ordenes_de_compra_x_numero_1(nNumOC, cItemCode, nBaseLineNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nPurchaseOrder = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nPurchaseOrder = 0;

            }
           
            try
            {
                nPrecioXUnidad = Convert.ToDouble(dTable.Rows[0]["Price"].ToString());

            }
            catch
            {
                nPrecioXUnidad = 0;

            }

            try
            {
                nU_COMPRAPRODUCTOR = int.Parse(dTable.Rows[0]["U_COMPRAPRODUCTOR"].ToString());
            }
            catch
            {
                nU_COMPRAPRODUCTOR = 0;
            }

            //////////////////////////////////////
            //////////////////////////////////////

            try
            {
                nNumGuia = int.Parse(t_num_guia.Text);

            }
            catch
            {
                nNumGuia = 0;

            }

            if (nNumGuia == 0)
            {
                MessageBox.Show("Debe ingresar un número de guía válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            try
            {
                cCardCode = t_cardcode.Text;

            }
            catch
            {
                cCardCode = "";

            }

            try
            {
                cCardName = t_cardname.Text;

            }
            catch
            {
                cCardName = "";

            }

            try
            {
                cWareHouse = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cWareHouse = "";

            }

            try
            {
                nNumOC = int.Parse(t_numoc.Text);

            }
            catch
            {
                nNumOC = -1;
            }

            try
            {
                cItemCode = t_itemcode.Text;

            }
            catch
            {
                cItemCode = "";

            }

            try
            {
                cItemName = t_itemname.Text;

            }
            catch
            {
                cItemName = "";

            }
            
            /////////////////////////////////////////
            /////////////////////////////////////////
            /// Determino el Cliente servicio

            CardCode_Serv = "";
            CardName_Serv = "";

            if (nNumOC > 0)
            {
                objproducto.cls_Consultar_Ordenes_de_compra_x_DocNum(nNumOC);

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto.cResultado;

                try
                {
                    CardCode_Serv = dTable5.Rows[0]["U_ClienteServ"].ToString();

                }
                catch
                {
                    CardCode_Serv = "";

                }

                try
                {
                    CardName_Serv = dTable5.Rows[0]["U_ClienteServ_Name"].ToString();

                }
                catch
                {
                    CardName_Serv = "";

                }

            }

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            string[,] d_arrDetalle = new string[10, 1000];
            double nQuantity;
            string cLote, cLoteProveedor;

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j;

            j = 0;

            try
            {
                nQuantity = Convert.ToDouble(t_cantidad_total.Text);
            }
            catch
            {
                nQuantity = 0;
            }

            d_arrDetalle[1, j] = cItemCode;
            d_arrDetalle[2, j] = cAlmacen;
            d_arrDetalle[3, j] = nQuantity.ToString();
            d_arrDetalle[4, j] = "";

            j += 1;

            string[,] d_arrDetalle1 = new string[10, 1000];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle1[1, i] = "";

            }

            j = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                cLote = Grid1[2, x].Value.ToString();
                cLoteProveedor = Grid1[3, x].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[1, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                d_arrDetalle1[1, j] = cItemCode;
                d_arrDetalle1[2, j] = cLote;
                d_arrDetalle1[3, j] = nQuantity.ToString();
                d_arrDetalle1[4, j] = cLoteProveedor;

                j += 1;

            }

            int nCantBultos;

            nCantBultos = j;

            DateTime dt;

            dt = DateTime.Now;

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            btn_recibir.Enabled = false;
            tsb_agrega_oc.Enabled = false;
            tsb_agrega_productor.Enabled = true;
            tsb_eliminar.Enabled = false;

            t_mensaje.Visible = true;
            t_mensaje.Clear();

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            //////////////////////////////////////
            // Actualizo el registro de romana

            Application.DoEvents();
            t_mensaje.Text = "Inicio proceso de grabación (1)...";
            Application.DoEvents();

            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            string UsuarioSap, ClaveSap, cErrorMensaje;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }
            
            mensaje = clsRecepcion.Entrada_Mercaderia_Insumos(cCardCode, cCardName, cItemCode, nNumGuia, dt.ToString("yyyyMMdd"), "", cWareHouse, nPurchaseOrder, nBaseLineNum, nCantBultos, CardCode_Serv, CardName_Serv, "", d_arrDetalle, d_arrDetalle1, UsuarioSap, ClaveSap);

            if (mensaje == "Error de Conexión")
            {
                mensaje = clsRecepcion.Entrada_Mercaderia_Insumos(cCardCode, cCardName, cItemCode, nNumGuia, dt.ToString("yyyyMMdd"), "", cWareHouse, nPurchaseOrder, nBaseLineNum, nCantBultos, CardCode_Serv, CardName_Serv, "", d_arrDetalle, d_arrDetalle1, UsuarioSap, ClaveSap);

            }

            try
            {
                nEntradaMercaderiaEntry = int.Parse(mensaje);
                cErrorMensaje = "";

            }
            catch
            {
                nEntradaMercaderiaEntry = 0;

                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la entrada de mercancía :::::: " + cErrorMensaje + ", opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //if (cItemCode == "X_X")
            if (cItemCode != "")
            {
                try
                {
                    mensaje = clsProductos.Revalorizacion_Inventario(dt.ToString("yyyyMMdd"), cItemCode, UsuarioSap, ClaveSap,"52-" + t_num_guia.Text);
                }
                catch
                {

                }

            }

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Entrada de Mercancía " + nEntradaMercaderiaEntry.ToString() + " (4)...";
            Application.DoEvents();


            MessageBox.Show("Registros Grabados con Exito", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void tsb_agrega_productor_Click(object sender, EventArgs e)
        {

            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Recepción de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            double nCantidad;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cNumGuia, cLote, cLoteProveedor;
            string cProveedor, cInsumo, cItemCode;
            string cOrdenCompra, cFechaRecepcion;

            try
            {
                cNumGuia = t_num_guia.Text;

            }
            catch
            {
                cNumGuia = "0";

            }

            try
            {
                cLote = Grid1[2, fila].Value.ToString();

            }
            catch
            {
                cLote = "0";

            }

            if (cLote == "")
            {
                cLote = "0";
            }

            try
            {
                cLoteProveedor = Grid1[3, fila].Value.ToString();

            }
            catch
            {
                cLoteProveedor = "0";

            }

            if (cNumGuia == "0")
            {
                MessageBox.Show("Debe seleccionar una guía valida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cLote == "0")
            {
                MessageBox.Show("Debe seleccionar una guía valida (Falta número de lote), opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nCantidad = double.Parse(Grid1[1, fila].Value.ToString());
            }
            catch
            {
                nCantidad = 0;
            }

            try
            {
                cProveedor = t_cardname.Text;

            }
            catch
            {
                cProveedor = "";

            }

            try
            {
                cInsumo = t_itemname.Text;

            }
            catch
            {
                cInsumo = "";

            }

            try
            {
                cItemCode = t_itemcode.Text;

            }
            catch
            {
                cItemCode = "";

            }

            try
            {
                cOrdenCompra = t_numoc.Text;

            }
            catch
            {
                cOrdenCompra = "";

            }

            try
            {
                cFechaRecepcion = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            }
            catch
            {
                cFechaRecepcion = "";

            }

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                Font Font_Titulo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 8, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                //string , , cLoteProveedor;
                //string , , cItemCode;
                //string , ;

                e1.Graphics.DrawString("Num Guía: " + cNumGuia, Font_Cuerpo, br, 5, 5);
                e1.Graphics.DrawString("Num OC: " + cOrdenCompra, Font_Cuerpo, br, 150, 5);

                e1.Graphics.DrawString("Proveedor: " + cProveedor, Font_Cuerpo, br, 5, 20);

                e1.Graphics.DrawString("Fecha de Recepción: " + cFechaRecepcion, Font_Cuerpo, br, 5, 35);

                e1.Graphics.DrawString("Insumo: " + cInsumo, Font_Cuerpo, br, 5, 50);

                e1.Graphics.DrawString("Lote: " + cLote, Font_Cuerpo, br, 5, 65);

                e1.Graphics.DrawString("Lote Proveedor: " + cLoteProveedor, Font_Cuerpo, br, 150, 65);

                e1.Graphics.DrawString("Cantidad: " + nCantidad.ToString() + " Unids", Font_Cuerpo, br, 5, 80);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 90, 100);

                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 100, 130);

            };

            try
            {
                p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 500, 0, 500);

                if (p.PrinterSettings.IsValid)
                {
                    p.Print();
                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }

        }

    }

}
