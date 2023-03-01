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
    public partial class frmRecepcionMP4 : Form
    {
        public frmRecepcionMP4()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP4_Load(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_ConsultaLista_Almacenes();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto1.cResultado;
            my_DGVCboColumn.Name = "De Almacén";
            my_DGVCboColumn.ValueMember = "WhsCode";
            my_DGVCboColumn.DisplayMember = "WhsCode";

            Grid1.Columns.RemoveAt(3);
            Grid1.Columns.Insert(3, my_DGVCboColumn);
            Grid1.Columns[3].Width = 120;

            ///////////////////////////////////////////////////////

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.cls_ConsultaLista_Almacenes();

            DataGridViewComboBoxColumn my_DGVCboColumn1 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn1.DataSource = objproducto2.cResultado;
            my_DGVCboColumn1.Name = "Almacén Destino";
            my_DGVCboColumn1.ValueMember = "WhsCode";
            my_DGVCboColumn1.DisplayMember = "WhsCode";

            Grid1.Columns.RemoveAt(4);
            Grid1.Columns.Insert(4, my_DGVCboColumn1);
            Grid1.Columns[4].Width = 120;

            ///////////////////////////////////////////////////////

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            ///////////////////////////////////////////////////////

            clsProduccion objproducto5 = new clsProduccion();
            objproducto5.cls_ConsultaLista_TipoCosecha();

            cbb_tipo_cosecha.DataSource = objproducto5.cResultado;
            cbb_tipo_cosecha.ValueMember = "TipoCosecha";
            cbb_tipo_cosecha.DisplayMember = "Nom_TipoCosecha";

            ///////////////////////////////////////////////////////

            t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
            t_lineid.Text = VariablesGlobales.glb_LineId.ToString();

            if (VariablesGlobales.glb_Formulario_Origen == "")
            {
                label16.Visible = false;
                cbb_tipo_cosecha.Visible = false;

            }

            int nDocEntry, nLineId, nCant_Bins;
            int nNumGuia;
            double nPesoGuia, nPesoRomana;
            string cItemCode_Bins;

            nDocEntry = 0;
            nLineId = 0;
            nCant_Bins = 0;
            cItemCode_Bins = "";
            nNumGuia = 0;
            nPesoGuia = 0;
            nPesoRomana = 0;

            try
            {
                nDocEntry = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            try
            {
                nLineId = Convert.ToInt32(t_lineid.Text);

            }
            catch
            {
                nLineId = 0;

            }

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_x_id_Detalle(nDocEntry, nLineId);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_cardcode.Text = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                t_cardcode.Text = "";

            }

            try
            {
                t_cardname.Text = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                t_cardname.Text = "";

            }

            try
            {
                t_itemcode.Text = dTable.Rows[0]["U_ItemCode"].ToString();

            }
            catch
            {
                t_itemcode.Text = "";

            }

            try
            {
                t_itemname.Text = dTable.Rows[0]["U_ItemName"].ToString();

            }
            catch
            {
                t_itemname.Text = "";

            }

            try
            {
                t_numoc.Text = dTable.Rows[0]["U_NumOC"].ToString();

            }
            catch
            {
                t_numoc.Text = "";

            }

            try
            {
                cItemCode_Bins = dTable.Rows[0]["U_ItemCodeBins"].ToString();

            }
            catch
            {
                cItemCode_Bins = "";

            }

            try
            {
                nCant_Bins = Convert.ToInt32(dTable.Rows[0]["U_CantBins"].ToString());

            }
            catch
            {
                nCant_Bins = 0;

            }

            t_CantBins.Text = nCant_Bins.ToString();

            try
            {
                nNumGuia = Convert.ToInt32(dTable.Rows[0]["U_NumGuia"].ToString());

            }
            catch
            {
                nNumGuia = 0;

            }

            try
            {
                nPesoGuia = Convert.ToDouble(dTable.Rows[0]["U_PesoGuia"].ToString());

            }
            catch
            {
                nPesoGuia = 0;

            }

            try
            {
                nPesoRomana = 0; // Convert.ToDouble(dTable.Rows[0]["U_PesoNeto"].ToString());
            }
            catch
            {
                nPesoRomana = 0;
            }

            t_cant_bins.Text = nCant_Bins.ToString();
            t_num_guia.Text = nNumGuia.ToString();
            t_peso_guia.Text = nPesoGuia.ToString("N2");
            t_peso_neto.Text = nPesoRomana.ToString("N2");

            try
            {
                t_patente.Text = dTable.Rows[0]["U_Patente"].ToString();

            }
            catch
            {
                t_patente.Text = "";

            }

            try
            {
                t_conductor.Text = dTable.Rows[0]["U_Conductor"].ToString();

            }
            catch
            {
                t_conductor.Text = "";

            }

            ///////////////////////////////////////////////////////

            String cAlmacen, cTipoCosecha;

            cAlmacen = "BMPL1";
            cTipoCosecha = "";

            if (VariablesGlobales.glb_CardCode != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode;
                t_cardname.Text = VariablesGlobales.glb_CardName;
                t_numoc.Text = VariablesGlobales.glb_NumOC;
                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;
                t_codigo_CSG.Text = VariablesGlobales.glb_Codigo_CSG;
                t_lineidoc.Text = VariablesGlobales.glb_LineNumOF.ToString();
                cTipoCosecha = VariablesGlobales.glb_Tipo_Cosecha;

                try
                {
                    cAlmacen = VariablesGlobales.glb_Almacen_From;

                }
                catch
                {
                    cAlmacen = "BMPL1";

                }

            }

            if (cAlmacen == null)
            {
                cAlmacen = "";
            }

            if (cAlmacen == "")
            {
                cAlmacen = "BMPL1";
            }

            cbb_almacen.SelectedValue = cAlmacen;

            if (cTipoCosecha != "")
            {
                try
                {
                    cbb_tipo_cosecha.SelectedValue = cTipoCosecha;

                }
                catch
                {

                }

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Determino si es cliente servicio

            t_precio_unit.Clear();

            int DocNum, nLineIDOC;
            string CardCode_Serv, CardName_Serv;

            CardCode_Serv = "";
            CardName_Serv = "";

            try
            {
                DocNum = int.Parse(t_numoc.Text);
            }
            catch
            {
                DocNum = 0;
            }

            try
            {
                nLineIDOC = int.Parse(t_lineidoc.Text);
            }
            catch
            {
                nLineIDOC = 0;
            }

            if (DocNum > 0)
            {
                clsOrdendeCompra objproducto8 = new clsOrdendeCompra();
                objproducto8.cls_Consultar_Ordenes_de_compra_x_DocNum(DocNum);

                DataTable dTable8 = new DataTable();
                dTable8 = objproducto8.cResultado;

                try
                {
                    CardCode_Serv = dTable8.Rows[0]["U_ClienteServ"].ToString();

                }
                catch
                {
                    CardCode_Serv = "";

                }

                try
                {
                    CardName_Serv = dTable8.Rows[0]["U_ClienteServ_Name"].ToString();

                }
                catch
                {
                    CardName_Serv = "";

                }

                t_cardcode_clte.Text = CardCode_Serv;
                t_cardname_clte.Text = CardName_Serv;

                double nPrecioXUnidad;

                objproducto8.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text, nLineIDOC);

                DataTable dTable9 = new DataTable();
                dTable9 = objproducto8.cResultado;

                try
                {
                    nPrecioXUnidad = Convert.ToDouble(dTable9.Rows[0]["Price"].ToString());

                }
                catch
                {
                    nPrecioXUnidad = 0;

                }

                t_precio_unit.Text = nPrecioXUnidad.ToString("N2");

            }

            ///////////////////////////////////////////////////////

            clsRomana objproducto4 = new clsRomana();
            objproducto4.cls_Consulta_lista_bins();

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto4.cResultado;

            string cItemCode, cItemName;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            {
                //ItemCode , ItemName
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
                    cItemName = dTable1.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemName = "";

                }

                if (cItemCode != "_")
                {

                    grilla[0] = cItemCode;
                    grilla[1] = cItemName;
                    grilla[2] = 0.ToString();
                    grilla[3] = "B_PRODUC";
                    grilla[4] = "PAI_BINS";

                    Grid1.Rows.Add(grilla);

                }

            }

            int nMaximo, nCantBins;
            string cItemCodeBins, cBodegaOrigen, cBodegaDestino;

            try
            {
                nMaximo = VariablesGlobales.glb_Array1_ind;
            }
            catch
            {
                nMaximo = -1;
            }

            for (int x = 0; x <= nMaximo; x++)
            {

                nCantBins = 0;
                cItemCodeBins = "";
                cBodegaOrigen = "";
                cBodegaDestino = "";

                try
                {
                    nCantBins = VariablesGlobales.glb_Array1[x];

                }
                catch
                {
                    nCantBins = 0;

                }

                try
                {
                    cItemCodeBins = VariablesGlobales.glb_Array2[x];

                }
                catch
                {
                    cItemCodeBins = "";

                }

                try
                {
                    cBodegaOrigen = VariablesGlobales.glb_Array3[x];

                }
                catch
                {
                    cBodegaOrigen = "";

                }

                try
                {
                    cBodegaDestino = VariablesGlobales.glb_Array4[x];

                }
                catch
                {
                    cBodegaDestino = "";

                }

                if (nCantBins > 0)
                {
                    for (int i = 0; i <= Grid1.RowCount - 1; i++)
                    {

                        if (cItemCodeBins == Grid1[0, i].Value.ToString())
                        {
                            Grid1[2, i].Value = nCantBins.ToString();
                            Grid1[3, i].Value = cBodegaOrigen;
                            Grid1[4, i].Value = cBodegaDestino;

                        }

                    }
                }

            }


        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_LineNumOF = 0;
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_Codigo_CSG = "";

            frmSel_OrdendeCompra f2 = new frmSel_OrdendeCompra();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();
                t_numoc.Text = VariablesGlobales.glb_NumOC.Trim();
                t_itemcode.Text = VariablesGlobales.glb_ItemCode.Trim();
                t_itemname.Text = VariablesGlobales.glb_ItemName.Trim();
                t_lineidoc.Text = VariablesGlobales.glb_LineNumOF.ToString();
                t_codigo_CSG.Text = VariablesGlobales.glb_Codigo_CSG.Trim();

                int DocNum, nLineIDOC;
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

                try
                {
                    nLineIDOC = int.Parse(VariablesGlobales.glb_LineNumOF.ToString());

                }
                catch
                {
                    nLineIDOC = 0;

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

                    objproducto.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text, nLineIDOC);

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

                    t_precio_unit.Text = nPrecioXUnidad.ToString("N2");

                }

            }


        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_CardCode = "__";

            Close();
        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Debe seleccionar un almacen válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cTipoCosecha;

            try
            {
                cTipoCosecha = cbb_tipo_cosecha.SelectedValue.ToString();

            }
            catch
            {
                cTipoCosecha = "";

            }

            if (cbb_tipo_cosecha.Visible == true)
            {
                if (cTipoCosecha == "")
                {
                    MessageBox.Show("Debe seleccionar un tipo de cosecha válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            int nNumOC, nLineIdOC;

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
                MessageBox.Show("Debe seleccionar una Orden de Compra válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLineIdOC = Convert.ToInt32(t_lineidoc.Text);

            }
            catch
            {
                nLineIdOC = 0;

            }

            //if (t_codigo_CSG.Text.Trim() == "")
            //{
            //    MessageBox.Show("Debe ingresar un código CSG válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;

            //}

            if (t_codigo_CSG.Text.Trim() == "")
            {

                DialogResult result1;
                MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;

                result1 = MessageBox.Show("No ha seleccionado un código CSG válido, desea continuar", "Recepción de Matería Prima", buttons1);

                if (result1 == System.Windows.Forms.DialogResult.No)
                {
                    return;

                }

            }

            int nCant_Total_Bins, nCant_Total_Bins_D;

            nCant_Total_Bins = 0;

            try
            {
                nCant_Total_Bins = Convert.ToInt32(t_cant_bins.Text);

            }
            catch
            {
                nCant_Total_Bins = 0;

            }

            int nMaximo, nStock;

            double nCant_Bins;

            string cItemCode_Bins, cAlmacen1, cAlmacen2;
            string cItemCodeBins; 

            clsProductos objproducto4 = new clsProductos();
            DataTable dTable4 = new DataTable();

            nMaximo = 0;
            nCant_Total_Bins_D = 0;
            cItemCodeBins = "";

            int[] arrCantidad = new int[100];
            string[] arrItemCode = new string[100];
            string[] arrBodega1 = new string[100];
            string[] arrBodega2 = new string[100];
            string[] arrBodega3 = new string[100];

            //////////////////////////////////////////////////////
            // Valido el stock de los Bins

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nCant_Bins = Convert.ToDouble(Grid1[2, i].Value);

                }
                catch
                {
                    nCant_Bins = 0;
                }

                cItemCode_Bins = "";
                cAlmacen1 = "";
                cAlmacen2 = "";

                try
                {
                    cItemCode_Bins = Grid1[0, i].Value.ToString();

                }
                catch
                {
                    cItemCode_Bins = "";
                }

                try
                {
                    cAlmacen1 = Grid1[3, i].Value.ToString();

                }
                catch
                {
                    cAlmacen1 = "";

                }

                try
                {
                    cAlmacen2 = Grid1[4, i].Value.ToString();

                }
                catch
                {
                    cAlmacen2 = "";

                }

                ///////////////////////////////////////////////////////

                objproducto4.cls_Consulta_stock_x_codigo_almacen(cItemCode_Bins, cAlmacen1);

                dTable4 = objproducto4.cResultado;

                try
                {
                    nStock = Convert.ToInt32(Convert.ToDouble(dTable4.Rows[0]["OnHand"].ToString()));
                }
                catch
                {
                    nStock = 0;

                }

                Grid1[5, i].Value = nStock.ToString();

                if (nCant_Bins > 0)
                {
                    if ((cItemCode_Bins != "BATEA") && (cItemCode_Bins != "MSACGRQUILL") && (cItemCode_Bins != "APRSA11001") && (cItemCode_Bins != "MSACCH"))
                    {
                        if (nCant_Bins > nStock)
                        {
                            MessageBox.Show("El código " + cItemCode_Bins + " No registra saldo suficiente en la bodega " + cAlmacen1 + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                        cItemCodeBins = cItemCode_Bins;

                        arrCantidad[nMaximo] = Convert.ToInt32(nCant_Bins);

                        arrItemCode[nMaximo] = cItemCode_Bins;
                        arrBodega1[nMaximo] = cAlmacen1;
                        arrBodega2[nMaximo] = cAlmacen2;

                        nMaximo += 1;

                        nCant_Total_Bins_D = nCant_Total_Bins_D + Convert.ToInt32(nCant_Bins);

                    }

                }

            }

            int nCantidad_Total_Bins_Original;

            try
            {
                nCantidad_Total_Bins_Original = int.Parse(t_CantBins.Text);
                 
            }
            catch
            {
                nCantidad_Total_Bins_Original = 0;

            }
            
            if (nCantidad_Total_Bins_Original != nCant_Total_Bins_D)
            {
                DialogResult result1 = MessageBox.Show("La cantidad de envases no corresponde con el total definido previamente, lo desea modificar?", "Recepción de Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == DialogResult.No)
                {
                    return;

                }

            }

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

            result = MessageBox.Show("Esta Seguro de Generar la Recepción de la Guía", "Recepción de Matería Prima", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            int nPurchaseOrder, nBaseLineNum, nCantidadBins;
            int nLineId, nLote, nStockTransferEntry;
            int nNumGuia, nId_Romana, nMes;
            int nAnho, nRomanaEntry, nEntradaMercaderiaEntry;
            int nU_COMPRAPRODUCTOR;

            double nPesoNeto, nPesoGuia, nPrecioXUnidad;
            double nContraMuestra;

            string cCardCode, cCardName, mensaje;
            string cPatente, cConductor, cTipoLote;
            string cItemCode, cWareHouse, cItemName;
            string CardCode_Serv, CardName_Serv, cDistNumber;
            string cVARIEDAD, cPRESENTACION, cContraMuestra;

            string[,] d_arrDetalleBins = new string[20, 20];

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
                nLineIdOC = Convert.ToInt32(t_lineidoc.Text);

            }
            catch
            {
                nLineIdOC = 0;

            }

            try
            {
                cItemCode = t_itemcode.Text;

            }
            catch
            {
                cItemCode = "";
            }

            objproducto.cls_Consultar_Ordenes_de_compra_x_numero(nNumOC, cItemCode, nLineIdOC);

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
                nBaseLineNum = Convert.ToInt32(dTable.Rows[0]["LineNum"].ToString());

            }
            catch
            {
                nBaseLineNum = 0;

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
                nId_Romana = int.Parse(t_id_romana.Text);

            }
            catch
            {
                nId_Romana = 0;

            }

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            mensaje = clsRecepcion.SAPB1_Recepcion(0, nId_Romana, VariablesGlobales.glb_User_id,"");

            ////////////////////////////////////////
            // Consulto el DocEntry de la Recepción

            objproducto1.cls_Consulta_Max_RecepcionMP();

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto1.cResultado;

            try
            {
                nRomanaEntry = int.Parse(dTable3.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nRomanaEntry = 0;

            }

            t_RomanaEntry.Text = nRomanaEntry.ToString();


            try
            {
                nNumGuia = int.Parse(t_num_guia.Text);

            }
            catch
            {
                nNumGuia = 0;

            }

            try
            {
                cPatente = t_patente.Text;
            }
            catch
            {
                cPatente = "";
            }

            try
            {
                cConductor = t_conductor.Text;
            }
            catch
            {
                cConductor = "";
            }

            try
            {
                nPesoGuia = Convert.ToDouble(t_peso_guia.Text);
            }
            catch
            {
                nPesoGuia = 0;
            }

            try
            {
                nLineId = int.Parse(t_lineid.Text);

            }
            catch
            {
                nLineId = 0;

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
                nCantidadBins = int.Parse(t_CantBins.Text);

            }
            catch
            {
                nCantidadBins = 0;

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

            try
            {
                nPesoNeto = Convert.ToDouble(t_peso_neto.Text);
            }
            catch
            {
                nPesoNeto = 0;
            }

            if (nPesoNeto == 0)
            {
                MessageBox.Show("Debe ingresar un Peso de Romana válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

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

            try
            {
                nLineIdOC = Convert.ToInt32(t_lineidoc.Text);

            }
            catch
            {
                nLineIdOC = 0;

            }

            /////////////////////////////////////////
            /////////////////////////////////////////
            /// Determino el precio de costo OC

            objproducto.cls_Consultar_Ordenes_de_compra_x_numero(nNumOC, cItemCode, nLineIdOC);

            DataTable dTable6 = new DataTable();
            dTable6 = objproducto.cResultado;

            try
            {
                nPurchaseOrder = Convert.ToInt32(dTable6.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nPurchaseOrder = 0;

            }

            try
            {
                nBaseLineNum = Convert.ToInt32(dTable6.Rows[0]["LineNum"].ToString());

            }
            catch
            {
                nBaseLineNum = 0;

            }

            try
            {
                nPrecioXUnidad = Convert.ToDouble(dTable6.Rows[0]["Price"].ToString());

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

            try
            {
                cVARIEDAD = dTable.Rows[0]["U_HDV_VARIEDAD"].ToString();
            }
            catch
            {
                cVARIEDAD = "";
            }

            try
            {
                cPRESENTACION = dTable.Rows[0]["U_HDV_PRESENTACION"].ToString();
            }
            catch
            {
                cPRESENTACION = "";
            }

            nLote = 0;

            objproducto1.cls_Consulta_Ultimo_Lote();

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                nLote = Convert.ToInt32(dTable1.Rows[0]["DistNumber"].ToString());

            }
            catch
            {
                nLote = 0;

            }

            nLote += 1;

            DateTime dt;            

            dt = DateTime.Now;

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            btn_recibir.Enabled = false;
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
            // Actualizo el registro de romana

            //////////////////////////////////////
            // Primero borro el items 

            mensaje = clsRomana.SAPB1_ROMANA2(nId_Romana, -2, cCardCode, cCardName, cItemCode, cItemName, cItemCodeBins, nLineId, nNumOC, 0,"","",0,"");

            //////////////////////////////////////
            // Ahora lo creo con el nuevo valor

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 1 (2)...";
            Application.DoEvents();

            mensaje = clsRomana.SAPB1_ROMANA2(nId_Romana, nLineId, cCardCode, cCardName, cItemCode, cItemName, cItemCodeBins, nCantidadBins, nNumOC, 0,"",t_codigo_CSG.Text, nLineIdOC, cTipoCosecha);

            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Romamna 2, Proceso 2 (3)...";
            Application.DoEvents();

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

            cTipoLote = "0";

            switch (nU_COMPRAPRODUCTOR)
            {
                case 0: // No Aplica
                    cTipoLote = "6"; //No Asginado
                    break;
                case 1: // Normal
                    cTipoLote = "3"; //Minimo Garantizado
                    break;
                case 2: // Compra a Firme
                    cTipoLote = "2"; //Compra a Firme
                    break;
                case 3: // Servicio 
                    cTipoLote = "7"; //Servicio 
                    break;
            }

            if (cConductor.Length > 30)
            {
                cConductor = cConductor.Substring(0, 30);
            }

            mensaje = clsRecepcion.Entrada_Mercaderia(cCardCode, cCardName, cItemCode, nNumGuia, cPatente, cConductor, dt.ToString("yyyyMMdd"), float.Parse(nPesoNeto.ToString()), "", float.Parse(nPesoGuia.ToString()), cWareHouse, nPrecioXUnidad, nPurchaseOrder, nBaseLineNum, nLote, nCantidadBins, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "52", t_codigo_CSG.Text, cTipoCosecha);

            if (mensaje == "Error de Conexión")
            {
                mensaje = clsRecepcion.Entrada_Mercaderia(cCardCode, cCardName, cItemCode, nNumGuia, cPatente, cConductor, dt.ToString("yyyyMMdd"), float.Parse(nPesoNeto.ToString()), "", float.Parse(nPesoGuia.ToString()), cWareHouse, nPrecioXUnidad, nPurchaseOrder, nBaseLineNum, nLote, nCantidadBins, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "52", t_codigo_CSG.Text, cTipoCosecha);

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

                MessageBox.Show("Error en la generación de la entrada de mercancía :::::: " + cErrorMensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Entrada de Mercancía " + nEntradaMercaderiaEntry.ToString() + " (4)...";
            Application.DoEvents();

            if (nEntradaMercaderiaEntry == 0)
            {
                //////////////////////////////////////
                // Consulto el DocEntry Generado

                try
                {
                    nMes = int.Parse(dt.ToString("MM"));

                }
                catch
                {
                    nMes = 0;

                }

                try
                {
                    nAnho = int.Parse(dt.ToString("yyyy"));

                }
                catch
                {
                    nAnho = 0;
                }


                objproducto1.cls_Consulta_Max_EntradaMercaderia(cCardCode, nMes, nAnho);

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto1.cResultado;

                try
                {
                    nEntradaMercaderiaEntry = int.Parse(dTable2.Rows[0]["DocEntry"].ToString());

                }
                catch
                {
                    nEntradaMercaderiaEntry = 0;

                }

            }

            //////////////////////////////////////
            // Corrigo el AbsEntry 

            mensaje = clsRecepcion.SAPB1_RECEPCION3(nEntradaMercaderiaEntry, 20);

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Corrigo AbsEntry " + nEntradaMercaderiaEntry.ToString() + " (5)...";
            Application.DoEvents();

            //////////////////////////////////////
            // Obtengo el Nro de Lote

            //clsRecepcion objproducto1 = new clsRecepcion();
            objproducto1.cls_Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(nEntradaMercaderiaEntry, 0);

            DataTable dTable8 = new DataTable();
            dTable8 = objproducto1.cResultado;

            try
            {
                cDistNumber = dTable8.Rows[0]["Lote"].ToString();

            }
            catch
            {
                cDistNumber = "";

            }

            Application.DoEvents();
            t_mensaje.Text = "Grabación de registro - Recupero Lote " + cDistNumber + " (6)...";
            Application.DoEvents();

            if (cDistNumber == "")
            {
                clsRomana objproducto6 = new clsRomana();
                objproducto6.cls_Consulta_Partidas_x_id_Detalle(nId_Romana, nLineId);

                DataTable dTable7 = new DataTable();
                dTable7 = objproducto.cResultado;

                try
                {
                    nLote = int.Parse(dTable7.Rows[0]["MdAbsEntry"].ToString());

                }
                catch
                {
                    nLote = 0;

                }

                cDistNumber = nLote.ToString();
            }

            t_lote.Text = cDistNumber;

            //////////////////////////////////////////////////////////
            // Dejo el inventario en Cero siempre que sea fruta propia

            string cTipoProducto;

            cTipoProducto = "";

            //if (cItemCode == "X_X")
            if (cItemCode != "")
            {
                try
                {
                    cTipoProducto = cItemCode.Substring(0, 2);
                }
                catch
                {
                    cTipoProducto = "";
                }

                if (cTipoProducto == "FP")
                {
                    mensaje = clsProductos.Revalorizacion_Inventario(dt.ToString("yyyyMMdd"), cItemCode, UsuarioSap, ClaveSap,"52-" + t_num_guia.Text);

                }

            }

            ////////////////////////////////////////
            ////////////////////////////////////////
            // Obtengo la cantidad de contramuestra 
            // y descuento los x kilos para calidad

            clsCalidad objproducto7 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto7.cls_Consulta_Atributos_por_producto(cItemCode, "%");

            DataTable dTable9 = new DataTable();
            dTable9 = objproducto7.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;

            try
            {
                cContraMuestra = dTable9.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable9.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable9.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            if (nPesoNeto > nContraMuestra)
            {
                if (cContraMuestra == "Y")
                {
                    if (nContraMuestra > 0)
                    {
                        if (cDistNumber != "")
                        {
                            d_arrDetalleBins[1, 0] = cItemCode;
                            d_arrDetalleBins[2, 0] = nContraMuestra.ToString();
                            d_arrDetalleBins[3, 0] = cWareHouse;
                            d_arrDetalleBins[4, 0] = "LABCC"; // Almacen Destino
                            d_arrDetalleBins[5, 0] = "0";
                            d_arrDetalleBins[6, 0] = cDistNumber; // lote

                            mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                            if (mensaje == "Error de Conexión")
                            {
                                mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                            }

                            try
                            {
                                nStockTransferEntry = int.Parse(mensaje);
                            }
                            catch
                            {
                                MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                nStockTransferEntry = 0;

                            }

                            //////////////////////////////////////
                            //////////////////////////////////////

                            Application.DoEvents();
                            t_mensaje.Text = "Grabación de registro - Transferencia de Lotes " + nStockTransferEntry.ToString() + " (7)...";
                            Application.DoEvents();

                            //////////////////////////////////////
                            //////////////////////////////////////
                            // Genero la referencia con la transferencia con los bins

                            //mensaje = clsRecepcion.SAPB1_Recepcion2(nDocEntry, 0, nCantidadContraMuestra, nStockTransferEntry, "HDV_ORCAL", 0);

                        }

                    }

                }

            }

            //////////////////////////////////////
            //////////////////////////////////////

            for (int v = 0; v <= 9; v++)
            {
                d_arrDetalleBins[1, v] = "";
                d_arrDetalleBins[2, v] = "";
                d_arrDetalleBins[3, v] = "";
                d_arrDetalleBins[4, v] = "";
                d_arrDetalleBins[5, v] = "";
                d_arrDetalleBins[6, v] = "";

            }

            //////////////////////////////////////
            //////////////////////////////////////

            int nIndice = 0;
            int j = -1;

            for (int z = 0; z <= Grid1.RowCount - 1; z++)
            {
                try
                {
                    nIndice = Convert.ToInt32(Grid1[2, z].Value);

                }
                catch
                {
                    nIndice = -1;
                }

                if (nIndice > 0)
                {
                    if ((Grid1[0, z].Value.ToString() != "BATEA") && (Grid1[0, z].Value.ToString() != "MSACGRQUILL") && (Grid1[0, z].Value.ToString() != "APRSA11001") && (Grid1[0, z].Value.ToString() != "MSACCH"))
                    {
                        if (j == -1)
                        {
                            j = 0;
                        }

                        d_arrDetalleBins[1, j] = Grid1[0, z].Value.ToString(); // ItemCode 
                        d_arrDetalleBins[2, j] = Grid1[2, z].Value.ToString(); // Cantidad
                        d_arrDetalleBins[3, j] = Grid1[3, z].Value.ToString(); // Almacen  
                        d_arrDetalleBins[4, j] = Grid1[4, z].Value.ToString(); // Almacen Destino
                        d_arrDetalleBins[5, j] = "";
                        j += 1;

                    }


                }

            }

            ////////////////////////////////////////
            // Genero la transferencia con los bins

            nStockTransferEntry = 0;

            //nStockTransferEntry;

            if (j > -1)
            {
                mensaje = clsRecepcion.Stock_Transfer(cCardCode, cPatente, cConductor, dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                if (mensaje == "Error de Conexión")
                {
                    mensaje = clsRecepcion.Stock_Transfer(cCardCode, cPatente, cConductor, dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                }

                Application.DoEvents();
                t_mensaje.Text = "Grabación de registro - Genero referencia de entrada (8)...";
                Application.DoEvents();

                try
                {
                    nStockTransferEntry = int.Parse(mensaje);
                }
                catch
                {
                    nStockTransferEntry = 0;
                    cErrorMensaje = mensaje;

                    MessageBox.Show("Error en la generación de la transferencia de stock - Bins :: " + cErrorMensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la referencia con la Entrada de mercaderia

            mensaje = clsRecepcion.SAPB1_Recepcion1(nRomanaEntry, nLineId, cCardCode, cCardName, cItemCode, cItemName, float.Parse(nPesoNeto.ToString()), nEntradaMercaderiaEntry, cWareHouse, CardCode_Serv, CardName_Serv);

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la referencia con la transferencia con los bins

            if (nStockTransferEntry > 0)
            {
                mensaje = clsRecepcion.SAPB1_Recepcion2(nRomanaEntry, nLineId, nCantidadBins, nStockTransferEntry, "HDV_OPDX", 0);

            }

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            btn_recibir.Enabled = false;
            t_mensaje.Visible = false;
            t_mensaje.Clear();

            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            MessageBox.Show("Registros Grabados con Exito", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();

        }

        private void t_peso_neto_Leave(object sender, EventArgs e)
        {
            double nPesoNeto;

            try
            {
                nPesoNeto = Convert.ToDouble(t_peso_neto.Text);

            }
            catch
            {
                nPesoNeto = 0;

            }

            t_peso_neto.Text = nPesoNeto.ToString("N2");

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fila;

            fila = 0;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            double nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToDouble(Grid1[2, fila].Value.ToString());

            }
            catch
            {
                nValor = 0;

            }

            Grid1[2, fila].Value = nValor.ToString();

            Suma_envases();

        }

        private void Suma_envases()
        {

            int nCantBins, nCantBins_t;

            nCantBins = 0;
            nCantBins_t = 0;

            for (int z = 0; z <= Grid1.RowCount - 1; z++)
            {
                try
                {
                    nCantBins = Convert.ToInt32(Grid1[2, z].Value);

                }
                catch
                {
                    nCantBins = 0;
                }

                nCantBins_t += nCantBins;

            }

            t_cant_bins.Text = nCantBins_t.ToString();


        }



    }
}
