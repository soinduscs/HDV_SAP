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
    public partial class frmOrdenFabricacion1 : Form
    {
        public frmOrdenFabricacion1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion1_Load(object sender, EventArgs e)
        {

            t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();
            t_ref.Text = "";

            carga_orden_fabricacion();

            t_ref.Text = "1";

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

            try
            {
                t_cliente_of.Text = dTable.Rows[0]["CardCode"].ToString();
            }
            catch
            {
                t_cliente_of.Text = "";

            }

            try
            {
                t_nom_cliente_of.Text = dTable.Rows[0]["Nom_Cliente"].ToString();
            }
            catch
            {
                t_nom_cliente_of.Text = "";

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
            
                if (nCantidadRequerida>0)
                {
                    Grid1.Rows.Add(grilla);

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

            string cItemCode, cItemCode_D;

            try
            {
                cItemCode = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            t_itemcode_D.Text = cItemCode;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consulta_stock_ItemCode_Lote(cItemCode);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            int nIdCalidad, nDocEntry_Ref, nLineId_Ref;

            string cLote, cAlmacen, cValido;
            string cLote_D, cFumigado, cNomProductor;
            string cNomCliente, cTipoLote, cColor;
            string cVariedad, cCalibre, cExiste;
            string cClasificacion;
            string cCodCliente, cCodProductor, cAgrupaLotes;

            /////////////////////
            /////////////////////
            // Filtro de Calibres

            string[] arr_calibres;
            arr_calibres = new string[500];
            int ind_calibres;

            // Filtro de Variedades

            string[] arr_variedades;
            arr_variedades = new string[500];
            int ind_variedades;

            // Filtro de productores

            string[] arr_productores;
            arr_productores = new string[500];
            int ind_productores;

            // Filtro de Almacenes

            string[] arr_almacenes;
            arr_almacenes = new string[500];
            int ind_almacenes;

            // Filtro de Colores

            string[] arr_colores;
            arr_colores = new string[500];
            int ind_colores;

            // Filtro de Clasificacion

            string[] arr_clasificacion;
            arr_clasificacion = new string[500];
            int ind_clasificacion;

            /////////////////////
            /////////////////////

            DateTime dFechaFumigado;

            double nStock, nAllocQty;

            Grid2.Rows.Clear();
            fx_Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            ind_calibres = -1;
            ind_variedades = -1;
            ind_productores = -1;
            ind_almacenes = -1;
            ind_colores = -1;
            ind_clasificacion = -1;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

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

                nAllocQty = 0;

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

                try
                {
                   cColor = dTable.Rows[i]["U_Color"].ToString();
                }
                catch
                {
                    cColor = "";
                }

                try
                {
                    cCodCliente = dTable.Rows[i]["CodCliente"].ToString();

                }
                catch
                {
                    cCodCliente = "";

                }

                try
                {
                    cAgrupaLotes = dTable.Rows[i]["AgrupaLotes"].ToString();

                }
                catch
                {
                    cAgrupaLotes = "";

                }

                try
                {
                    cCodProductor = dTable.Rows[i]["CodProductor"].ToString();

                }
                catch
                {
                    cCodProductor = "";

                }
                
                try
                {
                    cClasificacion = dTable.Rows[i]["U_HDV_CLASIFICACION"].ToString();
                    
                }
                catch
                {
                    cClasificacion = "";

                }

                grilla[0] = cItemCode;
                grilla[1] = cLote;
                grilla[2] = nStock.ToString("N2");
                grilla[3] = cAlmacen;
                grilla[4] = cFumigado;

                if (dFechaFumigado.Year != 1900)
                {
                    grilla[5] = dFechaFumigado.ToString("dd/MM/yyyy");
                }
                else
                {
                    grilla[5] = "";
                }

                grilla[6] = nIdCalidad.ToString();
                grilla[7] = nDocEntry_Ref.ToString();
                grilla[8] = nLineId_Ref.ToString();

                grilla[9] = cTipoLote;
                grilla[10] = "";
                grilla[11] = cNomProductor;
                grilla[12] = cNomCliente;
                grilla[14] = cVariedad;
                grilla[15] = cCalibre;
                grilla[16] = cColor;

                grilla[17] = cCodCliente;
                grilla[18] = cAgrupaLotes;
                grilla[19] = cCodProductor;
                grilla[20] = cClasificacion;

                if (dFechaFumigado.Year != 1900)
                {
                    grilla[13] = dFechaFumigado.ToString("dd/MM/yy");
                }
                else
                {
                    grilla[13] = "";
                }

                if (nAllocQty==0)
                {
                    cValido = "SI";

                    for (int x = 0; x <= Grid3.RowCount - 1; x++)
                    {

                        cLote_D = Grid3[1, x].Value.ToString();

                        if (cLote == cLote_D)
                        {
                            cValido = "NO";
                        }

                    }

                    if (cValido == "SI")
                    {

                        /////////////////////
                        /////////////////////
                        // Filtro de Calibres

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_calibres; x1++)
                        {
                            if (arr_calibres[x1] == cCalibre)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_calibres += 1;
                            arr_calibres[ind_calibres] = cCalibre;
                        }

                        // Filtro de Variedades

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_variedades; x1++)
                        {
                            if (arr_variedades[x1] == cVariedad)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_variedades += 1;
                            arr_variedades[ind_variedades] = cVariedad;
                        }

                        // Filtro de productores

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_productores; x1++)
                        {
                            if (arr_productores[x1] == cNomProductor)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_productores += 1;
                            arr_productores[ind_productores] = cNomProductor;
                        }

                        // Filtro de Almacenes

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_almacenes; x1++)
                        {
                            if (arr_almacenes[x1] == cAlmacen)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_almacenes += 1;
                            arr_almacenes[ind_almacenes] = cAlmacen;
                        }

                        // Filtro de Colores

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_colores; x1++)
                        {
                            if (arr_colores[x1] == cColor)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_colores += 1;
                            arr_colores[ind_colores] = cColor;
                        }

                        // Filtro de clasificacion

                        cExiste = "N";

                        for (int x1 = 0; x1 <= ind_clasificacion; x1++)
                        {
                            if (arr_clasificacion[x1] == cClasificacion)
                            {
                                cExiste = "S";
                                break;
                            }
                        }

                        if (cExiste == "N")
                        {
                            ind_clasificacion += 1;
                            arr_clasificacion[ind_clasificacion] = cClasificacion;
                        }

                        /////////////////////
                        /////////////////////

                        Grid2.Rows.Add(grilla);
                        fx_Grid2.Rows.Add(grilla);

                    }

                }

            }

            /////////////////////
            /////////////////////
            // Cargo Filtros

            cbb_fx_calibre.Items.Clear();

            for (int x1 = 0; x1 <= ind_calibres; x1++)
            {
                cbb_fx_calibre.Items.Add(arr_calibres[x1]);

            }

            cbb_fx_variedad.Items.Clear();

            for (int x1 = 0; x1 <= ind_variedades; x1++)
            {
                cbb_fx_variedad.Items.Add(arr_variedades[x1]);

            }

            cbb_fx_productor.Items.Clear();

            for (int x1 = 0; x1 <= ind_productores; x1++)
            {
                cbb_fx_productor.Items.Add(arr_productores[x1]);

            }

            cbb_fx_almacen.Items.Clear();

            for (int x1 = 0; x1 <= ind_almacenes; x1++)
            {
                cbb_fx_almacen.Items.Add(arr_almacenes[x1]);

            }

            cbb_fx_color.Items.Clear();

            for (int x1 = 0; x1 <= ind_colores; x1++)
            {
                cbb_fx_color.Items.Add(arr_colores[x1]);

            }

            cbb_fx_clasificacion.Items.Clear();

            for (int x1 = 0; x1 <= ind_clasificacion; x1++)
            {
                cbb_fx_clasificacion.Items.Add(arr_clasificacion[x1]);

            }

            cbb_fx_calibre.Text = "(Sel. Calibre)";
            cbb_fx_variedad.Text = "(Sel. Variedad)";
            cbb_fx_productor.Text = "(Sel. Productor)";
            cbb_fx_almacen.Text = "(Sel. Almacén)";
            cbb_fx_color.Text = "(Sel. Color)";
            cbb_fx_clasificacion.Text = "(Sel. Clasificación)";

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

                if (cItemCode_D== t_itemcode_D.Text)
                {
                    cLote = Grid3[1, x].Value.ToString();
                    cAgrupaLotes = Grid3[5, x].Value.ToString();
                    cCodProductor = Grid3[6, x].Value.ToString();

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
                    grilla[1] = cLote;
                    grilla[2] = nStock.ToString("N2");
                    grilla[3] = cAlmacen;
                    grilla[4] = cAgrupaLotes;
                    grilla[5] = cCodProductor;

                    Grid4.Rows.Add(grilla);

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

            string cItemCode;

            try
            {
                cItemCode = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            if (t_itemcode_D.Text != cItemCode)
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

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

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

            string cItemCode, cLote, cWhsCode;
            string cItemCode_D, cBodegaDestino, cPermiteAgrupar;
            string cCardCode_OF, cCardCode_Lote, cAgrupaLotes;
            string cCodProductor, cCodProductor_Sel;

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

            try
            {
                cCardCode_OF = t_cliente_of.Text;

            }
            catch
            {
                cCardCode_OF = "";

            }

            nFila = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cItemCode_D = "";

                try
                {
                    cItemCode_D = Grid1[2, x].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                if (cItemCode_D== cItemCode)
                {
                    nFila = x;

                }

            }

            try
            {
                nCantidadRequerida = Convert.ToDouble(Grid1[4, nFila].Value.ToString());
            }
            catch
            {
                nCantidadRequerida = 0;
            }

            try
            {
                nCantidadSolicitada = Convert.ToDouble(Grid1[5, nFila].Value.ToString());
            }
            catch
            {
                nCantidadSolicitada = 0;
            }

            try
            {
                cBodegaDestino = Grid1[7, nFila].Value.ToString();
            }
            catch
            {
                cBodegaDestino = "";
            }

            Suma_items();

            if (cItemCode != "")
            {
                if (cItemCode.Substring(0,2)=="FS" )
                {
                    // ************************************************************
                    // Valido que los items de servicio solo sean del mismo cliente

                    for (int x = 0; x <= Grid2.RowCount - 1; x++)
                    {

                        if (Grid2.Rows[x].Selected == true)
                        {
                            cLote = Grid2[1, x].Value.ToString();
                            cAgrupaLotes = Grid2[18, x].Value.ToString();

                            cCardCode_Lote = Grid2[17, x].Value.ToString();

                            if (cCardCode_OF != cCardCode_Lote)
                            {
                                MessageBox.Show("Relación NO Válida, el cliente de la orden de fabricación es diferente al cliente del Lote **** ", "Sistema Útiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }

                        }

                    }

                    // ********************************************************
                    // Valido que los items de servicio se puedan agrupar si/no

                    cPermiteAgrupar = "";

                    // Valido lo que hay YA seleccionado

                    for (int x = 0; x <= Grid4.RowCount - 1; x++)
                    {

                        cAgrupaLotes = Grid4[4, x].Value.ToString();

                        if (cAgrupaLotes == "NO")
                        {
                            cPermiteAgrupar = "NO";

                        }

                    }

                    // Valido si permite agrupar // 

                    for (int x = 0; x <= Grid2.RowCount - 1; x++)
                    {

                        if (Grid2.Rows[x].Selected == true)
                        {
                            cAgrupaLotes = Grid2[18, x].Value.ToString();

                            if (cPermiteAgrupar != "")
                            {
                                if (cPermiteAgrupar != cAgrupaLotes)
                                {
                                    MessageBox.Show("Relación NO Válida, el Lote previamente seleccionado NO permite la agrupación de Lotes **** ", "Sistema Útiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }

                            }

                        }

                    }

                    // Valido si NO permite agrupar que sea el mismo productor 

                    if (cPermiteAgrupar == "NO")
                    {

                        for (int x = 0; x <= Grid2.RowCount - 1; x++)
                        {

                            if (Grid2.Rows[x].Selected == true)
                            {
                                cCodProductor_Sel = Grid2[19, x].Value.ToString();

                                if (cCodProductor_Sel != "")
                                {

                                    for (int i = 0; i <= Grid4.RowCount - 1; i++)
                                    {

                                        cCodProductor = Grid4[5, i].Value.ToString();

                                        if (cCodProductor != cCodProductor_Sel)
                                        {
                                            MessageBox.Show("Relación NO Válida, el Lote previamente seleccionado NO permite la agrupación de Lotes **** ", "Sistema Útiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            for (int x = 0; x <= Grid2.RowCount - 1; x++)
            {

                if (Grid2.Rows[x].Selected == true)
                {
                    cLote = Grid2[1, x].Value.ToString();
                    cAgrupaLotes = Grid2[18, x].Value.ToString();
                    cCodProductor = Grid2[19, x].Value.ToString();

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

                            if ((nCantidadRequerida - nCantidadSolicitada)<= nStock)
                            {
                                nDifStock = (nCantidadRequerida-nCantidadSolicitada);
                                nStock = nStock - nDifStock;

                            }
                            else
                            {
                                nDifStock = nStock;
                                nStock = 0;
                            }
                            
                        }

                        grilla[0] = cItemCode;
                        grilla[1] = cLote;
                        grilla[2] = nDifStock.ToString("N2");
                        grilla[3] = cWhsCode;
                        grilla[4] = cBodegaDestino;
                        grilla[5] = cAgrupaLotes;
                        grilla[6] = cCodProductor;

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

            string cFiltroAplicado;

            cFiltroAplicado = "N";

            if (cbb_fx_calibre.SelectedIndex >= 0)
            {
                cFiltroAplicado = "S";
            }

            if (cbb_fx_productor.SelectedIndex >= 0)
            {
                cFiltroAplicado = "S";
            }

            if (cbb_fx_variedad.SelectedIndex >= 0)
            {
                cFiltroAplicado = "S";
            }

            try
            {
                if (cFiltroAplicado == "S")
                {
                    aplica_filtro_lotes();
                }
                else
                {
                    carga_lotes();
                }

            }
            catch
            {

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
                    cItemCode = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    nCantidadRequerida = Convert.ToDouble(Grid1[4, i].Value.ToString());
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

                    if (cItemCode== cItemCode_D)
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

                Grid1[5, i].Value = nCantidadSolicitada_t.ToString("N2");

            }

        }


        private void btn_quitar_Click(object sender, EventArgs e)
        {
            if (Grid4.RowCount == 0)
            {

                return;
            }

            string cItemCode, cLote;
            string cItemCode_D, cLote_D;
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
                cLote = Grid4[1, fila].Value.ToString();

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    cItemCode_D = Grid3[0, x].Value.ToString();
                    cLote_D = Grid3[1, x].Value.ToString();

                    if (cItemCode==cItemCode_D)
                    {
                        if (cLote == cLote_D)
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

                string cFiltroAplicado;

                cFiltroAplicado = "N";

                if (cbb_fx_calibre.SelectedIndex >= 0)
                {
                    cFiltroAplicado = "S";
                }

                if (cbb_fx_productor.SelectedIndex >= 0)
                {
                    cFiltroAplicado = "S";
                }

                if (cbb_fx_variedad.SelectedIndex >= 0)
                {
                    cFiltroAplicado = "S";
                }

                try
                {
                    if (cFiltroAplicado == "S")
                    {
                        aplica_filtro_lotes();
                    }
                    else
                    {
                        carga_lotes();
                    }

                }
                catch
                {

                }

                try
                {
                    if (cFiltroAplicado == "S")
                    {
                        aplica_filtro_lotes();
                    }
                    else
                    {
                        carga_lotes();
                    }

                }
                catch
                {

                }

                Suma_items();

            }


        }

        private void btn_crear_Click(object sender, EventArgs e)
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

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DateTime dt;

            string cFecha, cItemCode, cLote;
            string cWhsCode, cItemCode_D, cWhsCode_D;
            string cExiste, cBodegaDestino;

            double nQuantity, nQuantity_t;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Genero un resumen con los registros seleccionados

            Final1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int x = 0; x <= Grid3.RowCount - 1; x++)
            {
                cItemCode = Grid3[0, x].Value.ToString();
                cWhsCode = Grid3[3, x].Value.ToString();
                cBodegaDestino = Grid3[4, x].Value.ToString();

                cExiste = "NO";

                for (int i = 0; i <= Final1.RowCount - 1; i++)
                {
                    cItemCode_D = Final1[0, i].Value.ToString();
                    cWhsCode_D = Final1[1, i].Value.ToString();

                    if (cItemCode == cItemCode_D)
                    {
                        if (cWhsCode == cWhsCode_D)
                        {
                            cExiste = "SI";

                        }

                    }

                }

                if (cExiste == "NO")
                {
                    grilla[0] = cItemCode;
                    grilla[1] = cWhsCode;
                    grilla[2] = 0.ToString("N2");
                    grilla[3] = cBodegaDestino;

                    Final1.Rows.Add(grilla);

                }

            }


            for (int i = 0; i <= Final1.RowCount - 1; i++)
            {
                cItemCode = Final1[0, i].Value.ToString();
                cWhsCode = Final1[1, i].Value.ToString();
                nQuantity_t = 0;

                for (int x = 0; x <= Grid3.RowCount - 1; x++)
                {
                    cItemCode_D = Grid3[0, x].Value.ToString();
                    cWhsCode_D = Grid3[3, x].Value.ToString();

                    try
                    {
                        nQuantity = Convert.ToDouble(Grid3[2, x].Value.ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    if (cItemCode == cItemCode_D)
                    {
                        if (cWhsCode == cWhsCode_D)
                        {
                            nQuantity_t = nQuantity_t + nQuantity;

                        }

                    }

                }

                Final1[2, i].Value = nQuantity_t.ToString("N2");

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Paso las grillas a tablas 

            string[,] d_arrDetalle = new string[10, 1000];

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j;

            j = 0;

            for (int x = 0; x <= Final1.RowCount - 1; x++)
            {
                cItemCode = Final1[0, x].Value.ToString();
                cWhsCode = Final1[1, x].Value.ToString();
                cBodegaDestino = Final1[3, x].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Final1[2, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                d_arrDetalle[1, j] = cItemCode;
                d_arrDetalle[2, j] = cWhsCode;
                d_arrDetalle[3, j] = nQuantity.ToString();
                d_arrDetalle[4, j] = cBodegaDestino;

                j += 1;

            }

            string[,] d_arrDetalle1 = new string[10, 1000];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle1[1, i] = "";

            }

            j = 0;

            for (int x = 0; x <= Grid3.RowCount - 1; x++)
            {
                cItemCode = Grid3[0, x].Value.ToString();
                cLote = Grid3[1, x].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid3[2, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                cWhsCode = Grid3[3, x].Value.ToString();

                d_arrDetalle1[1, j] = cItemCode;
                d_arrDetalle1[2, j] = cLote;
                d_arrDetalle1[3, j] = nQuantity.ToString();
                d_arrDetalle1[4, j] = cWhsCode;

                j += 1;

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

            dt = DateTime.Now;

            cFecha = dt.ToString("yyyyMMdd");

            int nStockTransferEntry;

            nStockTransferEntry = 0;

            String mensaje = clsOrdenFabricacion.Stock_Transfer(int.Parse(t_DocNum.Text), cFecha, d_arrDetalle, d_arrDetalle1,"","", UsuarioSap, ClaveSap);

            try
            {
                nStockTransferEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Solicitud Generada con Existo", "Orden de fabricacion, Folio " + mensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch
            {
                nStockTransferEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la Solicitud de transferencia :::::: " + cErrorMensaje + ", opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void button1_Click(object sender, EventArgs e)
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

            if (fila >= 0)
            {
                int nIdCalidad, nDocEntry_Ref, nLineId_Ref;

                nIdCalidad = 0;
                nDocEntry_Ref = 0;
                nLineId_Ref = 0;

                try
                {
                    nIdCalidad = int.Parse(Grid2[6, fila].Value.ToString());
                }
                catch
                {
                    nIdCalidad = 0;
                }

                try
                {
                    nDocEntry_Ref = int.Parse(Grid2[7, fila].Value.ToString());
                }
                catch
                {
                    nDocEntry_Ref = 0;
                }

                try
                {
                    nLineId_Ref = int.Parse(Grid2[8, fila].Value.ToString());
                }
                catch
                {
                    nLineId_Ref = 0;
                }

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "100500";
                VariablesGlobales.glb_id_romana = nDocEntry_Ref;  
                VariablesGlobales.glb_LineId = nLineId_Ref;
                VariablesGlobales.glb_ItemCode = t_itemcode.Text;

                frmCalidadMP f2 = new frmCalidadMP();
                DialogResult res = f2.ShowDialog();


            }

        }

        private void cbb_fx_productor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();

        }

        private void cbb_fx_calibre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();

        }

        private void cbb_fx_variedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();
           
        }

        private void aplica_filtro_lotes()
        {
            if (t_ref.Text == "")
            {
                return;
            }

            Grid2.Rows.Clear();

            string cMuestra, cCalibre, cProductor;
            string cVariedad, cLote, cWhsCode;
            string cColor, cClasificacion;

            cCalibre = "._.";
            cVariedad = "._.";
            cProductor = "._.";
            cWhsCode = "._.";
            cColor = "._.";
            cClasificacion = "._.";

            if (cbb_fx_calibre.SelectedIndex >= 0)
            {
                cCalibre = cbb_fx_calibre.Text;
            }

            if (cbb_fx_productor.SelectedIndex >= 0)
            {
                cProductor = cbb_fx_productor.Text;
            }

            if (cbb_fx_variedad.SelectedIndex >= 0)
            {
                cVariedad = cbb_fx_variedad.Text;
            }

            if (cbb_fx_almacen.SelectedIndex >= 0)
            {
                cWhsCode = cbb_fx_almacen.Text;
            }

            if (cbb_fx_color.SelectedIndex >= 0)
            {
                cColor = cbb_fx_color.Text;
            }

            if (cbb_fx_clasificacion.SelectedIndex >= 0)
            {
                cClasificacion = cbb_fx_clasificacion.Text;
            }

            string[] grilla;
            grilla = new string[30];

            cMuestra = "S";

            for (int i = 0; i <= fx_Grid2.RowCount - 1; i++)
            {
                cMuestra = "S";

                if (cWhsCode.Trim() != "._.")
                {
                    if (cWhsCode.Trim() != fx_Grid2[3, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }
                    else
                    {
                        //cMuestra = "N";
                    }

                }

                if (cProductor.Trim() != "._.")
                {
                    if (cProductor.Trim() != fx_Grid2[11, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }
                    else
                    {
                        //cMuestra = "N";
                    }

                }

                if ((cVariedad.Trim() != "._.") && (cMuestra != "N"))
                {
                    if (cVariedad.Trim() != fx_Grid2[14, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }
                    else
                    {
                        //cMuestra = "N";
                    }

                }

                if ((cCalibre.Trim() != "._.") && (cMuestra != "N"))
                {
                    if (cCalibre.Trim() != fx_Grid2[15, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }
                    else
                    {
                        //cMuestra = "N";
                    }

                }

                if (cColor.Trim() != "._.")
                {
                    if (cColor.Trim() != fx_Grid2[16, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }
                    
                }

                if (cClasificacion.Trim() != "._.")
                {
                    if (cClasificacion.Trim() != fx_Grid2[20, i].Value.ToString().Trim())
                    {
                        cMuestra = "N";
                    }

                }

                if (cMuestra != "N")
                {
                    for (int x = 0; x <= Grid3.RowCount - 1; x++)
                    {
                        cLote = Grid3[1, x].Value.ToString();
                        if (cLote == fx_Grid2[1, i].Value.ToString())
                        {
                            cMuestra = "N";
                            break;
                        }

                    }

                }

                if (cMuestra == "S")
                {
                    grilla[0] = fx_Grid2[0, i].Value.ToString();
                    grilla[1] = fx_Grid2[1, i].Value.ToString();
                    grilla[2] = fx_Grid2[2, i].Value.ToString();
                    grilla[3] = fx_Grid2[3, i].Value.ToString();
                    grilla[4] = fx_Grid2[4, i].Value.ToString();
                    grilla[5] = fx_Grid2[5, i].Value.ToString();
                    grilla[6] = fx_Grid2[6, i].Value.ToString();
                    grilla[7] = fx_Grid2[7, i].Value.ToString();
                    grilla[8] = fx_Grid2[8, i].Value.ToString();
                    grilla[9] = fx_Grid2[9, i].Value.ToString();
                    grilla[10] = fx_Grid2[10, i].Value.ToString();
                    grilla[11] = fx_Grid2[11, i].Value.ToString();
                    grilla[12] = fx_Grid2[12, i].Value.ToString();
                    grilla[13] = fx_Grid2[13, i].Value.ToString();
                    grilla[14] = fx_Grid2[14, i].Value.ToString();
                    grilla[15] = fx_Grid2[15, i].Value.ToString();
                    grilla[16] = fx_Grid2[16, i].Value.ToString();
                    grilla[17] = fx_Grid2[17, i].Value.ToString();
                    grilla[18] = fx_Grid2[18, i].Value.ToString();
                    grilla[20] = fx_Grid2[20, i].Value.ToString();

                    Grid2.Rows.Add(grilla);

                }

            }


            string cItemCode_D, cAlmacen, cItemCode;
            double nStock;

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
                cItemCode = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
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

                if (cItemCode_D == t_itemcode_D.Text)
                {
                    cLote = Grid3[1, x].Value.ToString();

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
                    grilla[1] = cLote;
                    grilla[2] = nStock.ToString("N2");
                    grilla[3] = cAlmacen;

                    Grid4.Rows.Add(grilla);

                }

            }

        }

        private void btn_quitar_filtro_Click(object sender, EventArgs e)
        {
            try
            {
                carga_lotes();

            }
            catch
            {

            }

        }

        private void cbb_fx_almacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();
        }

        private void cbb_fx_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();

        }

        private void cbb_fx_clasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_ref.Text == "")
            {
                return;
            }

            aplica_filtro_lotes();

        }

    }

}
