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
    public partial class frmOrdenVentas : Form
    {
        public frmOrdenVentas()
        {
            InitializeComponent();
        }

        private void frmOrdenVentas_Load(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_DocEntry != 0)
            { 
                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                carga_orden_venta();

            }

        }

        private void Suma_items()
        {
            string cItemCode, cItemCode_D;
            double nCantidadRequerida, nCantidadSolicitada, nCantidadSolicitada_t;

            nCantidadRequerida = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cItemCode = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    nCantidadRequerida = Convert.ToDouble(Grid1[3, i].Value.ToString());
                }
                catch
                {
                    nCantidadRequerida = 0;
                }

                nCantidadSolicitada_t = 0;

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    cItemCode_D = "";

                    try
                    {
                        cItemCode_D = Grid3[0, x].Value.ToString();
                    }
                    catch
                    {
                        cItemCode_D = "";
                    }

                    if (cItemCode == cItemCode_D)
                    {

                        try
                        {
                            nCantidadSolicitada = Convert.ToDouble(Grid3[2, x].Value.ToString());
                        }
                        catch
                        {
                            nCantidadSolicitada = 0;
                        }

                        nCantidadSolicitada_t += nCantidadSolicitada;

                    }

                }

                Grid1[4, i].Value = nCantidadSolicitada_t.ToString("N2");

            }

        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {

            if (Grid4.RowCount == 0)
            {
                return;
            }

            string cItemCode, cPallet;
            string cItemCode_D, cPallet_D;
            int fila;

            try
            {
                fila = Grid4.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {
                cItemCode = Grid4[0, fila].Value.ToString();
                cPallet = Grid4[1, fila].Value.ToString();

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    cItemCode_D = Grid3[0, x].Value.ToString();
                    cPallet_D = Grid3[1, x].Value.ToString();

                    if (cItemCode == cItemCode_D)
                    {
                        if (cPallet == cPallet_D)
                        {
                            try
                            {
                                Grid3.Rows.RemoveAt(x);

                            }
                            catch
                            {

                            }

                        }

                    }

                }

                try
                {
                    carga_lotes();

                }
                catch
                {

                }

                Suma_items();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_OrdendeVenta f2 = new frmSel_OrdendeVenta();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_DocNum.Text = VariablesGlobales.glb_NumOC;
                t_cardcode.Text = VariablesGlobales.glb_CardCode;
                t_cardname.Text = VariablesGlobales.glb_CardName;

                carga_orden_venta();

            }

        }

        private void carga_orden_venta()
        {
            int nDocNum;
            DateTime dFecha;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }


            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_OrdendeVenta_x_DocNum(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_DocEntry.Text = dTable.Rows[0]["DocEntry"].ToString();
            }
            catch
            {
                t_DocEntry.Clear();
            }

            try
            {
                t_cardcode.Text = dTable.Rows[0]["CardCode"].ToString();
            }
            catch
            {
                t_cardcode.Clear();
            }

            try
            {
                t_cardname.Text = dTable.Rows[0]["CardName"].ToString();
            }
            catch
            {
                t_cardname.Clear();
            }

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["DocDueDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }
            
            try
            {
                t_fecha_entrega.Text = dFecha.ToString("dd/MM/yyyy");
            }
            catch
            {
                t_fecha_entrega.Text = "";

            }

            try
            {
                //t_Estado.Text = nPlannedQty.ToString("N2");

            }
            catch
            {
                t_Estado.Clear();

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega;
            double nCantidadOV, nCantidadRequerida, nCantidadYaAsignada;

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
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["Dscription"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidadOV = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nCantidadOV = 0;
                }

                try
                {
                    nCantidadYaAsignada = Convert.ToDouble(dTable.Rows[i]["AllocQty"].ToString());
                }
                catch
                {
                    nCantidadYaAsignada = 0;
                }

                nCantidadRequerida = nCantidadOV - nCantidadYaAsignada;

                try
                {
                    cUM = dTable.Rows[i]["BuyUnitMsr"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                try
                {
                    cBodega = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                grilla[0] = cLine;               
                grilla[1] = cItemCode;
                grilla[2] = cItemName;
                grilla[3] = nCantidadRequerida.ToString("N2");
                grilla[4] = 0.ToString("N2");
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = "";

                if (nCantidadRequerida > 0)
                {
                    Grid1.Rows.Add(grilla);

                }

            }

        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }
           
            try
            {
                t_itemcode_d.Text = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                t_itemcode_d.Clear();
            }

            try
            {
               t_whscode_d.Text = Grid1[6, fila].Value.ToString();
            }
            catch
            {
                t_whscode_d.Clear();
            }

            if (t_itemcode_d.Text != "")
            {

                try
                {
                    carga_lotes();

                }
                catch
                {

                }

            }

        }

        private void carga_lotes()
        {

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            string cItemCode, cItemCode_D, cWhsCode;

            try
            {
                cItemCode = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cWhsCode = Grid1[6, fila].Value.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            //t_itemcode_D.Text = cItemCode;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consulta_stock_ItemCode_Pallet(cItemCode, cWhsCode);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cPallet, cAlmacen, cValido;
            string cPallet_D;

            double nStock, nAllocQty;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cPallet = dTable.Rows[i]["U_FolioPallet"].ToString();
                }
                catch
                {
                    cPallet = "";
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

                

                grilla[0] = cItemCode;
                grilla[1] = cPallet;
                grilla[2] = nStock.ToString("N2");
                grilla[3] = cAlmacen;
               
                if (nAllocQty == 0)
                {
                    if (cPallet  != "")
                    {
                        cValido = "SI";

                        for (int x = 0; x <= Grid3.RowCount - 1; x++)
                        {
                            cPallet_D = Grid3[1, x].Value.ToString();

                            if (cPallet == cPallet_D)
                            {
                                cValido = "NO";
                                break;
                            }

                        }

                        if (cValido == "SI")
                        {
                            Grid2.Rows.Add(grilla);

                        }

                    }

                }

            }

            Grid4.Rows.Clear();

            for (int x = 0; x <= Grid3.RowCount - 1; x++)
            {
                try
                {
                    cItemCode_D = Grid3[0, x].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                if (cItemCode_D == t_itemcode_d.Text)
                {
                    cPallet = Grid3[1, x].Value.ToString();

                    try
                    {
                        nStock = Convert.ToDouble(Grid3[2, x].Value.ToString());

                    }
                    catch
                    {
                        nStock = 0;
                    }

                    cAlmacen = Grid3[3, x].Value.ToString();

                    grilla[0] = cItemCode;
                    grilla[1] = cPallet;
                    grilla[2] = nStock.ToString("N2");
                    grilla[3] = cAlmacen;

                    Grid4.Rows.Add(grilla);

                }

            }

        }

        private void btn_pasar_Click(object sender, EventArgs e)
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

            string cItemCode, cPallet, cWhsCode;
            string cItemCode_D, cBodegaDestino;

            int nFila;

            double nStock, nCantidadRequerida, nCantidadSolicitada;
            double nDifStock;

            try
            {
                cItemCode = Grid2[0, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            nFila = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cItemCode_D = "";

                try
                {
                    cItemCode_D = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                if (cItemCode_D == cItemCode)
                {
                    nFila = x;

                }

            }

            try
            {
                nCantidadRequerida = Convert.ToDouble(Grid1[3, nFila].Value.ToString());
            }
            catch
            {
                nCantidadRequerida = 0;
            }

            try
            {
                nCantidadSolicitada = Convert.ToDouble(Grid1[4, nFila].Value.ToString());
            }
            catch
            {
                nCantidadSolicitada = 0;
            }

            try
            {
                cBodegaDestino = Grid1[5, nFila].Value.ToString();
            }
            catch
            {
                cBodegaDestino = "";
            }

            Suma_items();

            for (int x = 0; x <= Grid2.RowCount - 1; x++)
            {

                if (Grid2.Rows[x].Selected == true)
                {
                    cPallet = Grid2[1, x].Value.ToString();

                    try
                    {
                        nStock = Convert.ToDouble(Grid2[2, x].Value.ToString());

                    }
                    catch
                    {
                        nStock = 0;
                    }

                    if (nCantidadSolicitada < nCantidadRequerida)
                    {
                        cWhsCode = Grid2[3, x].Value.ToString();

                        string[] grilla;
                        grilla = new string[30];

                        if ((nCantidadSolicitada + nStock) < nCantidadRequerida)
                        {
                            nDifStock = nStock;
                            nStock = 0;
                        }
                        else
                        {
                            nDifStock = 0;

                            if ((nCantidadRequerida - nCantidadSolicitada) <= nStock)
                            {
                                nDifStock = (nCantidadRequerida - nCantidadSolicitada);
                                nStock = nStock - nDifStock;

                            }
                            else
                            {
                                nDifStock = nStock;
                                nStock = 0;
                            }

                        }

                        grilla[0] = cItemCode;
                        grilla[1] = cPallet;
                        grilla[2] = nDifStock.ToString("N2");
                        grilla[3] = cWhsCode;
                        grilla[4] = cBodegaDestino;

                        Grid3.Rows.Add(grilla);

                        if (nStock > 0)
                        {
                            Grid2[2, x].Value = nStock.ToString("N2");
                        }

                        try
                        {
                            //Grid2.Rows.RemoveAt(x);

                        }
                        catch
                        {

                        }

                    }

                    Suma_items();

                }

            }


            for (int i = 0; i <= Grid3.RowCount - 1; i++)
            {
                cItemCode_D = "";

                try
                {
                    cItemCode_D = Grid3[1, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                for (int x = 0; x <= Grid2.RowCount - 1; x++)
                {
                    cItemCode = "";

                    try
                    {
                        cItemCode = Grid2[1, x].Value.ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    if (cItemCode_D == cItemCode)
                    {

                        Grid2.Rows.RemoveAt(x);

                    }

                }

            }

            Grid2.ClearSelection();

            try
            {
                carga_lotes();

            }
            catch
            {

            }

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            string cItemCode, cItemCode_D, cPallet;
            string cWhsCode, cLineNum, cLote;

            double nCantidadRequerida, nCantidadSolicitada, nCantidadSolicitada_t;
            double nCantidadLote, nCantidadxAplicar;

            string[] grilla;
            grilla = new string[30];

            Final1.Rows.Clear();

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cLineNum = Grid1[0, i].Value.ToString();
                }
                catch
                {
                    cLineNum = "";
                }

                try
                {
                    cItemCode = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    nCantidadRequerida = Convert.ToDouble(Grid1[3, i].Value.ToString());
                }
                catch
                {
                    nCantidadRequerida = 0;
                }

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    cItemCode_D = "";

                    try
                    {
                        cItemCode_D = Grid3[0, x].Value.ToString();
                    }
                    catch
                    {
                        cItemCode_D = "";
                    }

                    try
                    {
                        cWhsCode = Grid3[3, x].Value.ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    if (cItemCode == cItemCode_D)
                    {
                        try
                        {
                            cPallet = Grid3[1, x].Value.ToString();
                        }
                        catch
                        {
                            cPallet = "";
                        }

                        try
                        {
                            nCantidadSolicitada = Convert.ToDouble(Grid3[2, x].Value.ToString());
                        }
                        catch
                        {
                            nCantidadSolicitada = 0;
                        }

                        nCantidadSolicitada_t = 0;

                        clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                        objproducto.cls_Consulta_stock_ItemCode_Pallet_Lote(cItemCode, cWhsCode, cPallet);

                        DataTable dTable = new DataTable();
                        dTable = objproducto.cResultado;

                        Grid2.Rows.Clear();


                        for (int z = 0; z <= dTable.Rows.Count - 1; z++)
                        {

                            try
                            {
                                cLote = dTable.Rows[z]["DistNumber"].ToString();
                            }
                            catch
                            {
                                cLote = "";
                            }

                            try
                            {
                                nCantidadLote = double.Parse(dTable.Rows[z]["Quantity"].ToString());
                            }
                            catch
                            {
                                nCantidadLote = 0;
                            }

                            nCantidadxAplicar = 0;

                            if (nCantidadSolicitada > (nCantidadSolicitada_t + nCantidadLote))
                            {
                                nCantidadxAplicar = nCantidadLote;
                            }
                            else
                            {
                                nCantidadxAplicar = nCantidadSolicitada - nCantidadSolicitada_t;
                            }

                            grilla[0] = cLineNum;
                            grilla[1] = cItemCode;
                            grilla[2] = cWhsCode;
                            grilla[3] = cPallet;
                            grilla[4] = cLote;
                            grilla[5] = nCantidadxAplicar.ToString("N2");

                            Final1.Rows.Add(grilla);

                            nCantidadSolicitada_t += nCantidadxAplicar;

                            if (nCantidadSolicitada == nCantidadSolicitada_t)
                            {
                                break;
                            }

                        }

                    }

                }
            }

            if (Final1.Rows.Count == 0)
            {
                MessageBox.Show("No Existen regsitros a procesar, opción Cancelada", "Orden de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro aplicar los lotes seleccionados", "Orden de Venta", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            ////////////////////////////////////////
            // Genero la transferencia con los bins

            string UsuarioSap, ClaveSap;

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


            string mensaje;
            int nDocEntry, nNewDocEntry, nLineId;
            double nQuantity;

            try
            {
                nDocEntry = int.Parse(t_DocEntry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            for (int x = 0; x <= Final1.RowCount - 1; x++)
            {
                cLote = "";
                nQuantity = 0;
                nLineId = 0;

                try
                {
                    nLineId = int.Parse(Final1[0, x].Value.ToString());
                }
                catch
                {
                    nLineId = 0;
                }

                try
                {
                    cLote = Final1[4, x].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity = double.Parse(Final1[5, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                mensaje = clsRecepcion.Sales_Order_Lotes(nDocEntry, nLineId, int.Parse(cLote), float.Parse(nQuantity.ToString("N2")), UsuarioSap, ClaveSap);

                try
                {
                    nNewDocEntry = int.Parse(mensaje);
                }
                catch
                {
                    MessageBox.Show("Error al asignar el Folio Pallet / Lote - :: " + mensaje + ", opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nNewDocEntry = 0;
                    return;
                }


            }

            MessageBox.Show("Proceso Terminado Exitosamente", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            ////////////////////////////////////////
            // Genero la transferencia con los bins

            string UsuarioSap, ClaveSap;

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

            DateTime dt;

            dt = DateTime.Now;

            string mensaje;

            mensaje = clsRecepcion.Sales_Order_New_Picking(dt.ToString("yyyyMMdd"), UsuarioSap, ClaveSap);


        }
    }

}
