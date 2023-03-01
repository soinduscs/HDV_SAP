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
    public partial class frmRecepcionMPC2 : Form
    {
        public frmRecepcionMPC2()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPC2_Load(object sender, EventArgs e)
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
            Grid1.Columns[3].Visible = false;

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
            Grid1.Columns[4].Visible = false;

            ///////////////////////////////////////////////////////

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes_BM();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            ///////////////////////////////////////////////////////

            t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
            t_lineid.Text = VariablesGlobales.glb_LineId.ToString();

            int nDocEntry, nLineId, nCant_Bins;
            int nNumGuia;
            double nPesoGuia, nPesoRomana, nPesoPromedio;
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
                nCant_Bins = VariablesGlobales.glb_Array1[0];

            }
            catch
            {
                nCant_Bins = 0;

            }

            if (nCant_Bins == 0)
            {
                try
                {
                    nCant_Bins = Convert.ToInt32(dTable.Rows[0]["U_CantBins"].ToString());

                }
                catch
                {
                    nCant_Bins = 0;

                }

            }

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
                nPesoRomana = Convert.ToDouble(dTable.Rows[0]["U_PesoNeto"].ToString());
            }
            catch
            {
                nPesoRomana = 0;
            }

            try
            {
                nPesoPromedio = Math.Round(nPesoRomana / nCant_Bins, 2);

            }
            catch
            {
                nPesoPromedio = 0;

            }

            t_cant_bins.Text = nCant_Bins.ToString();
            t_num_guia.Text = nNumGuia.ToString();
            t_peso_guia.Text = nPesoGuia.ToString("N2");
            t_peso_neto.Text = nPesoRomana.ToString("N2");
            t_peso_promedio.Text = nPesoPromedio.ToString("N2");

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

            try
            {
                t_CodigoCSG.Text = dTable.Rows[0]["U_Codigo_CSG"].ToString();

            }
            catch
            {
                t_CodigoCSG.Text = "";

            }

            try
            {
                t_linenumoc.Text = dTable.Rows[0]["U_LineIDOC"].ToString();

            }
            catch
            {
                t_linenumoc.Text = "-1";

            }

            ///////////////////////////////////////////////////////

            String cAlmacen;

            cAlmacen = "BMPL1";

            if (VariablesGlobales.glb_CardCode != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode;
                t_cardname.Text = VariablesGlobales.glb_CardName;
                t_numoc.Text = VariablesGlobales.glb_NumOC;
                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

                try
                {
                    cAlmacen = VariablesGlobales.glb_Almacen;
                }
                catch
                {
                    cAlmacen = "BMPL1";
                }

            }

            if (cAlmacen == "")
            {
                cAlmacen = "BMPL1";
            }

            cbb_almacen.SelectedValue = cAlmacen;


            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Determino si es cliente servicio

            t_precio_unit.Clear();

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
                clsOrdendeCompra objproducto5 = new clsOrdendeCompra();
                objproducto5.cls_Consultar_Ordenes_de_compra_x_DocNum(DocNum);

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

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

                t_cardcode_clte.Text = CardCode_Serv;
                t_cardname_clte.Text = CardName_Serv;

                double nPrecioXUnidad;

                objproducto5.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text,0);

                DataTable dTable9 = new DataTable();
                dTable9 = objproducto5.cResultado;

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
                    grilla[5] = 0.ToString();

                    Grid1.Rows.Add(grilla);

                }

            }

            int nMaximo, nCantBins, nCantBinsVacios;
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
                nCantBinsVacios = 0;

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
                    nCantBinsVacios = VariablesGlobales.glb_Array6[x];

                }
                catch
                {
                    nCantBinsVacios = 0;

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
                            Grid1[5, i].Value = nCantBinsVacios.ToString();

                        }

                    }
                }

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {
            string cAlmacen = "", cAlmacenCabecera = "";

            try
            {
                cAlmacenCabecera = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cAlmacenCabecera = "";

            }

            if (t_CodigoCSG.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Código CSG válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cAlmacenCabecera == "")
            {
                MessageBox.Show("Debe seleccionar un almacen válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Debe seleccionar una Orden de Compra válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

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

            int nMaximo;
            double nCant_Bins, nCant_BinsVacios, nPesoPromedio;
            string cItemCode_Bins, cAlmacen1, cAlmacen2;

            nMaximo = 0;
            nCant_Total_Bins_D = 0;
            nCant_BinsVacios = 0;

            int[] arrCantidad = new int[100];
            int[] arrCantidadVacios = new int[100];
            string[] arrItemCode = new string[100];
            string[] arrBodega1 = new string[100];
            string[] arrBodega2 = new string[100];
            string[] arrBodega3 = new string[100];

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

                try
                {
                    nCant_BinsVacios = Convert.ToDouble(Grid1[5, i].Value);
                }
                catch
                {
                    nCant_BinsVacios = 0;
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

                if (nCant_Bins > 0)
                {
                    arrCantidad[nMaximo] = Convert.ToInt32(nCant_Bins);
                    arrCantidadVacios[nMaximo] = Convert.ToInt32(nCant_BinsVacios);

                    arrItemCode[nMaximo] = cItemCode_Bins;

                    arrBodega1[nMaximo] = cAlmacen1;
                    arrBodega2[nMaximo] = cAlmacen2;

                    nMaximo += 1;

                    nCant_Total_Bins_D = nCant_Total_Bins_D + Convert.ToInt32(nCant_Bins);

                }

            }

            if (nCant_Total_Bins != nCant_Total_Bins_D)
            {
                DialogResult result = MessageBox.Show("La cantidad de envases no corresponde con el total definido previamente, lo desea modificar?", "Recepción de Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;

                }

            }

            clsProductos objproducto4 = new clsProductos();

            int nStock;

            VariablesGlobales.glb_Array1_ind = nMaximo - 1;

            for (int i = 0; i <= nMaximo - 1; i++)
            {

                nStock = 0;
                cAlmacen = "";

                try
                {
                    cItemCode_Bins = arrItemCode[i];

                }
                catch
                {
                    cItemCode_Bins = "";

                }

                try
                {
                    cAlmacen = arrBodega1[i];

                }
                catch
                {
                    cAlmacen = "";

                }

                ///////////////////////////////////////////////////////
                objproducto4.cls_Consulta_stock_x_codigo_almacen(cItemCode_Bins, cAlmacen);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto4.cResultado;

                try
                {
                    nStock = Convert.ToInt32(Convert.ToDouble(dTable1.Rows[0]["OnHand"].ToString()));
                }
                catch
                {
                    nStock = 0;

                }

                VariablesGlobales.glb_Array1[i] = arrCantidad[i];
                VariablesGlobales.glb_Array2[i] = arrItemCode[i];
                VariablesGlobales.glb_Array3[i] = arrBodega1[i];
                VariablesGlobales.glb_Array4[i] = arrBodega2[i];
                VariablesGlobales.glb_Array5[i] = nStock.ToString();
                VariablesGlobales.glb_Array6[i] = arrCantidadVacios[i];

            }

            nPesoPromedio = 0;

            try
            {
                nPesoPromedio = Convert.ToDouble(t_peso_promedio.Text);

            }
            catch
            {
                nPesoPromedio = 0;
            }

            //if (nPesoPromedio >= 500)
            //{
            //    MessageBox.Show("El peso por Bins supera el peso maxima establecido, contacte al administrador, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;

            //}

            VariablesGlobales.glb_CardCode = t_cardcode.Text;
            VariablesGlobales.glb_CardName = t_cardname.Text;
            VariablesGlobales.glb_NumOC = t_numoc.Text;
            VariablesGlobales.glb_ItemCode = t_itemcode.Text;
            VariablesGlobales.glb_ItemName = t_itemname.Text;
            VariablesGlobales.glb_Almacen = cAlmacen;
            VariablesGlobales.glb_Almacen_From = cAlmacenCabecera;
            VariablesGlobales.glb_Codigo_CSG = t_CodigoCSG.Text;
            VariablesGlobales.glb_LineNumOF = Convert.ToInt32(t_linenumoc.Text);

            Close();

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
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_Codigo_CSG = "";
            VariablesGlobales.glb_LineNumOF = 0;

            frmSel_OrdendeCompra3 f2 = new frmSel_OrdendeCompra3();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();
                t_numoc.Text = VariablesGlobales.glb_NumOC.Trim();
                t_itemcode.Text = VariablesGlobales.glb_ItemCode.Trim();
                t_itemname.Text = VariablesGlobales.glb_ItemName.Trim();
                t_CodigoCSG.Text = VariablesGlobales.glb_Codigo_CSG.Trim();
                t_linenumoc.Text = VariablesGlobales.glb_LineNumOF.ToString();

                int DocNum, LinNum;
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
                    LinNum = 0;

                }
                catch
                {
                    LinNum = VariablesGlobales.glb_LineNumOF;

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

                    objproducto.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text, LinNum);

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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void t_peso_guia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void t_peso_neto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }
    }

}
