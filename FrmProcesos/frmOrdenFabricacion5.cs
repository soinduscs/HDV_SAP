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
    public partial class frmOrdenFabricacion5 : Form
    {
        public frmOrdenFabricacion5()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion5_Load(object sender, EventArgs e)
        {
            t_lotes_bodega.Clear();

            t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

            carga_orden_fabricacion();

            carga_lotes();

        }

        private void carga_orden_fabricacion()
        {

            int nDocNum, nDocEntry;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_x_DocNum(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nDocEntry = int.Parse(dTable.Rows[0]["DocEntry"].ToString());
            }
            catch
            {
                nDocEntry = -1;
            }

            try
            {
                t_itemcode.Text = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                t_itemcode.Clear();
            }

            try
            {
                t_itemname.Text = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                t_itemname.Clear();
            }

            try
            {
                t_um.Text = dTable.Rows[0]["InvntryUom"].ToString();
            }
            catch
            {
                t_um.Clear();
            }

            try
            {
                t_almacen.Text = dTable.Rows[0]["Warehouse"].ToString();
            }
            catch
            {
                t_almacen.Text = "";

            }

            double nPlannedQty;

            try
            {
                nPlannedQty = Convert.ToDouble(dTable.Rows[0]["PlannedQty"].ToString());

            }
            catch
            {
                nPlannedQty = 0;

            }

            try
            {
                t_PlannedQty.Text = nPlannedQty.ToString("N2");

            }
            catch
            {
                t_PlannedQty.Clear();

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega;
            double nCantidadRequerida;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["LineNum"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode_D"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["ItemName_D"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidadRequerida = Convert.ToDouble(dTable.Rows[i]["PlannedQty_D"].ToString());
                }
                catch
                {
                    nCantidadRequerida = 0;
                }

                try
                {
                    cUM = dTable.Rows[i]["InvntryUom_D"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                try
                {
                    cBodega = dTable.Rows[i]["Warehouse_D"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidadRequerida.ToString("N2");
                grilla[5] = 0.ToString("N2");
                grilla[6] = cUM;
                grilla[7] = cBodega;
                grilla[8] = "";

                if (nCantidadRequerida > 0)
                {
                    Grid1.Rows.Add(grilla);

                }

            }

        }

        private void carga_lotes()
        {

            int nDocNum;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_LotesTransferidospara_OF(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            int nLineId_Ref, nLineId;

            string cItemCode, cLote, cAlmacen;
            string cFumigado, cItemCode_D;
            string cCalibre, cVARIEDAD;

           DateTime dFechaFumigado;

            double nStock, nStockLoteWhsCode;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    //cLote = dTable.Rows[i]["MdAbsEntry"].ToString();
                    cLote = dTable.Rows[i]["DistNumber"].ToString();
                    
                }
                catch
                {
                    cLote = "";

                }

                try
                {
                    cAlmacen = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    cAlmacen = "";

                }

                try
                {
                    nStock = Convert.ToDouble(dTable.Rows[i]["AllocQty"].ToString());
                }
                catch
                {
                    nStock = 0;
                }

                try
                {
                    nStockLoteWhsCode = Convert.ToDouble(dTable.Rows[i]["Stock_Lote_WhsCode"].ToString());
                }
                catch
                {
                    nStockLoteWhsCode = 0;
                }

                try
                {
                    cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();
                }
                catch
                {
                    cFumigado = "No";
                }

                try
                {
                    dFechaFumigado = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                }
                catch
                {
                    dFechaFumigado = Convert.ToDateTime("01/01/1900");
                }

                nLineId_Ref = 0;

                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cCalibre = dTable.Rows[i]["U_Calibre"].ToString();
                }
                catch
                {
                    cCalibre = "";
                }

                try
                {
                    cVARIEDAD = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                }
                catch
                {
                    cVARIEDAD = "";
                }

                /////////////////////////////////////////7
                /////////////////////////////////////////7

                try
                {
                    grilla[1] = dTable.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    grilla[1] = "";
                }
                
                grilla[0] = cItemCode;
                grilla[2] = cLote;
                grilla[3] = nStock.ToString("N2");
                grilla[4] = cAlmacen;
                grilla[5] = cFumigado;

                if (dFechaFumigado.Year != 1900)
                {
                    grilla[6] = dFechaFumigado.ToString("dd/MM/yyyy");
                }
                else
                {
                    grilla[6] = "";
                }

                grilla[7] = "";

                try
                {
                    grilla[8] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                }
                catch
                {
                    grilla[8] = "";
                }

                try
                {
                    grilla[9] = dTable.Rows[i]["U_NOMBCLI"].ToString();
                }
                catch
                {
                    grilla[9] = "";
                }

                nLineId = -1;

                for (int x = 0; x <= Grid1.RowCount -1; x++)
                {
                    try
                    {
                        cItemCode_D = Grid1[2, x].Value.ToString();
                    }
                    catch
                    {
                        cItemCode_D = "";
                    }

                    try
                    {
                        nLineId_Ref = int.Parse(Grid1[0, x].Value.ToString());
                    }
                    catch
                    {
                        nLineId_Ref = -1;
                    }

                    if (cItemCode_D == cItemCode)
                    {
                        nLineId = nLineId_Ref;
                        break;

                    }

                }

                grilla[10] = nLineId.ToString();
                grilla[11] = cCalibre;
                grilla[12] = cVARIEDAD;

                if (nLineId != -1)
                {
                    if (nStockLoteWhsCode > 0)
                    {
                        Grid2.Rows.Add(grilla);

                    }

                }

            }

        }



        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {

            if (Grid2.Rows.Count == 0)
            {
                MessageBox.Show("No Existen registros por asignar en la presente Orden de Fabricación, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocNum;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            if (nDocNum == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Fabricación Válida, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Asignar los productos transferidos a la Orden de Fabricación", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;
            string cErrorMensaje;

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

            string[,] d_arrDetalle = new string[10, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            string cItemCode_D, cItemName_D;
            string cBodega_D, cLote_D;

            double nCantidadTransferida_D, nCantidadOF;

            try
            {
                nCantidadOF = double.Parse(Grid1[4, 0].Value.ToString());
            }
            catch
            {
                nCantidadOF = 0;

            }

            int nLineId_D, j;

            j = 0;

            if (t_lotes_bodega.Text == "")
            {
                for (int i = 0; i <= Grid2.RowCount - 1; i++)
                {

                    try
                    {
                        cItemCode_D = Grid2[0, i].Value.ToString();
                    }
                    catch
                    {
                        cItemCode_D = "";
                    }

                    try
                    {
                        cItemName_D = Grid2[1, i].Value.ToString();
                    }
                    catch
                    {
                        cItemName_D = "";
                    }

                    try
                    {
                        cLote_D = Grid2[2, i].Value.ToString();
                    }
                    catch
                    {
                        cLote_D = "";
                    }

                    try
                    {
                        cBodega_D = Grid2[4, i].Value.ToString();
                    }
                    catch
                    {
                        cBodega_D = "";
                    }

                    try
                    {
                        nCantidadTransferida_D = Convert.ToDouble(Grid2[3, i].Value.ToString());
                    }
                    catch
                    {
                        nCantidadTransferida_D = -1;
                    }

                    nLineId_D = -1;

                    try
                    {
                        nLineId_D = Convert.ToInt32(Grid2[10, i].Value.ToString());
                    }
                    catch
                    {
                        nLineId_D = -1;
                    }

                    ///////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////

                    d_arrDetalle[1, j] = nLineId_D.ToString();
                    d_arrDetalle[2, j] = cItemCode_D;
                    d_arrDetalle[3, j] = cItemName_D;
                    d_arrDetalle[4, j] = nCantidadTransferida_D.ToString();
                    d_arrDetalle[5, j] = "";
                    d_arrDetalle[6, j] = cBodega_D;
                    d_arrDetalle[7, j] = cLote_D;
                    d_arrDetalle[8, j] = "";

                    j += 1;

                }

            }
            else
            {

                int fila;

                try
                {
                    fila = Grid2.CurrentCell.RowIndex;

                }
                catch
                {
                    fila = -1;
                }

                try
                {
                    cItemCode_D = Grid2[0, fila].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = Grid2[1, fila].Value.ToString();
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    cLote_D = Grid2[2, fila].Value.ToString();
                }
                catch
                {
                    cLote_D = "";
                }

                try
                {
                    cBodega_D = Grid2[4, fila].Value.ToString();
                }
                catch
                {
                    cBodega_D = "";
                }

                try
                {
                    nCantidadTransferida_D = Convert.ToDouble(Grid2[3, fila].Value.ToString());
                }
                catch
                {
                    nCantidadTransferida_D = -1;
                }

                if (nCantidadOF < nCantidadTransferida_D)
                {
                    nCantidadTransferida_D = nCantidadOF;

                }
                    //nCantidadTransferida_D

                nLineId_D = -1;

                try
                {
                    nLineId_D = Convert.ToInt32(Grid2[0, fila].Value.ToString());
                }
                catch
                {
                    nLineId_D = -1;
                }

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////

                d_arrDetalle[1, j] = nLineId_D.ToString();
                d_arrDetalle[2, j] = cItemCode_D;
                d_arrDetalle[3, j] = cItemName_D;
                d_arrDetalle[4, j] = nCantidadTransferida_D.ToString();
                d_arrDetalle[5, j] = "";
                d_arrDetalle[6, j] = cBodega_D;
                d_arrDetalle[7, j] = cLote_D;
                d_arrDetalle[8, j] = "";

                j += 1;

            }

            int nOrdenFabricacionEntry;

            nOrdenFabricacionEntry = 0;

            String mensaje = clsOrdenFabricacion.Production_Orders_AsignaLotes(nDocNum, nDocNum, d_arrDetalle, UsuarioSap, ClaveSap);

            try
            {
                nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Lotes Asignados exitosamente", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_crear.Enabled = false;
                btn_crear.Visible = false;

            }
            catch
            {
                nOrdenFabricacionEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la orden de fabricacion :::::: " + cErrorMensaje + ", opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void btn_cargar_lotes_en_stock_Click(object sender, EventArgs e)
        {

            string cItemCode;

            int nIdCalidad, nDocEntry_Ref, nLineId_Ref;

            string cLote, cAlmacen, cItemCode_D;
            string cFumigado, cNomProductor, cItemName_D;
            string cNomCliente, cTipoLote;
            string cVariedad, cCalibre, cWhsCode;

            DateTime dFechaFumigado;

            double nStock, nAllocQty;

            cItemCode = Grid1[2, 0].Value.ToString();
            cWhsCode = Grid1[7, 0].Value.ToString();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consulta_stock_ItemCode_Lote(cItemCode);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;
           
            /////////////////////
            /////////////////////

            Grid2.Rows.Clear();
            
            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                try
                {
                    cItemCode_D = dTable.Rows[i]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = dTable.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    cLote = dTable.Rows[i]["DistNumber"].ToString();
                }
                catch
                {
                    cLote = "";

                }

                try
                {
                    cAlmacen = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    cAlmacen = "";

                }

                try
                {
                    nStock = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nStock = 0;
                }

                try
                {
                    nAllocQty = Convert.ToDouble(dTable.Rows[i]["AllocQty"].ToString());
                }
                catch
                {
                    nAllocQty = 0;
                }

                try
                {
                    cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();
                }
                catch
                {
                    cFumigado = "No";
                }

                try
                {
                    dFechaFumigado = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                }
                catch
                {
                    dFechaFumigado = Convert.ToDateTime("01/01/1900");
                }

                nIdCalidad = 0;
                nDocEntry_Ref = 0;
                nLineId_Ref = 0;

                try
                {
                    nIdCalidad = int.Parse(dTable.Rows[i]["id_calidad"].ToString());
                }
                catch
                {
                    nIdCalidad = 0;
                }

                try
                {
                    nDocEntry_Ref = int.Parse(dTable.Rows[i]["U_DocEntry_Ref"].ToString());
                }
                catch
                {
                    nDocEntry_Ref = 0;
                }

                try
                {
                    nLineId_Ref = int.Parse(dTable.Rows[i]["U_LineId_Ref"].ToString());
                }
                catch
                {
                    nLineId_Ref = 0;
                }

                try
                {
                    cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                }
                catch
                {
                    cNomProductor = "";
                }

                try
                {
                    cNomCliente = dTable.Rows[i]["U_NOMBCLI"].ToString();
                }
                catch
                {
                    cNomCliente = "";
                }

                try
                {
                    cTipoLote = dTable.Rows[i]["nom_tipoLote"].ToString();
                }
                catch
                {
                    cTipoLote = "";
                }

                try
                {
                    cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                }
                catch
                {
                    cVariedad = "";
                }

                try
                {
                    cCalibre = dTable.Rows[i]["U_Calibre"].ToString();
                }
                catch
                {
                    cCalibre = "";
                }


                /////////////////////////////////////////////////

                grilla[0] = cItemCode_D;
                grilla[1] = cItemName_D;

                grilla[2] = cLote;
                grilla[3] = nStock.ToString("N2");
                grilla[4] = cAlmacen;
                grilla[5] = cFumigado;

                if (dFechaFumigado.Year != 1900)
                {
                    grilla[6] = dFechaFumigado.ToString("dd/MM/yyyy");
                }
                else
                {
                    grilla[6] = "";
                }

                grilla[7] = "";
                grilla[8] = cNomProductor;
                grilla[9] = cNomCliente;

                grilla[11] = cCalibre;
                grilla[12] = cVariedad;

                ////////////////////////////////////////////

                if (nStock > 0)
                {
                    if (cWhsCode == cAlmacen)
                    {
                        Grid2.Rows.Add(grilla);

                    }

                }

            }

            t_lotes_bodega.Text = "Lotes_Bodega";
            btn_cargar_lotes_en_stock.Enabled = false;

        }


    }

}
