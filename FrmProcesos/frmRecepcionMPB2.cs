using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmRecepcionMPB2 : Form
    {
        public frmRecepcionMPB2()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB2_Load(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes_BM();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            ///////////////////////////////////////////////////////

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                dt = DateTime.Now;
            }

            t_fecha_contable.Text = dt.ToString("dd/MM/yyyy HH:mm");

            clsRomana objproducto1 = new clsRomana();
            objproducto1.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            cbb_bins.DataSource = objproducto1.cResultado;
            cbb_bins.ValueMember = "ItemCode";
            cbb_bins.DisplayMember = "ItemName";

            if (VariablesGlobales.glb_id_acceso != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_acceso.ToString();

                carga_datos_x_id();

            }

        }

        private void carga_datos_x_id()
        {
            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, 0);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_DocNum.Text = dTable.Rows[0]["U_NumOC"].ToString();

            }
            catch
            {
                t_DocNum.Text = "";

            }

            Carga_fruta();
            carga_producto();

            string cItemCode_Bins;
            double nCant_Bins;

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
                nCant_Bins = Convert.ToDouble(dTable.Rows[0]["U_CantBins_D"].ToString());

            }
            catch
            {
                nCant_Bins = 0;

            }

            if (cItemCode_Bins != "")
            {
                cbb_bins.SelectedValue = cItemCode_Bins;

            }

            if (nCant_Bins > 0)
            {
                t_cantidad_envases.Text = nCant_Bins.ToString("N");

            }

            Calcula_peso_bins();

            float peso_bruto, peso_tara, peso_neto;

            try
            {
                peso_bruto = float.Parse(dTable.Rows[0]["U_PesoBruto_Full"].ToString());

            }
            catch
            {
                peso_bruto = 0;

            }

            try
            {
                peso_tara = float.Parse(dTable.Rows[0].ItemArray[14].ToString());

            }
            catch
            {
                peso_tara = 0;

            }

            try
            {
                peso_neto = float.Parse(dTable.Rows[0].ItemArray[15].ToString());

            }
            catch
            {
                peso_neto = 0;

            }

            try
            {
                // cant_envases = int.Parse(dTable.Rows[0].ItemArray[7].ToString());

            }
            catch
            {
                // cant_envases = 0;

            }

            t_peso_bruto.Text = peso_bruto.ToString("N2");
            t_tara.Clear();
            t_peso_neto.Clear();

            if (peso_tara != 0)
            {
                t_tara.Text = peso_tara.ToString("N2");

            }

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

        }

        private void Carga_fruta()
        {

            int nDocNum, nDocEntry, nConCascara;
            string cItemName, cSalida, cTipoProducto;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            t_tipo_fruta.Clear();

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
                t_ItemCode_Cabecera.Text = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                t_ItemCode_Cabecera.Text = "";
            }

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
            }

            try
            {
                t_tipo_fruta.Text = dTable.Rows[0]["U_TipoProducto"].ToString();
            }
            catch
            {
                t_tipo_fruta.Text = "";
            }

            nConCascara = -1;

            try
            {
                nConCascara = cItemName.ToUpper().IndexOf("C/C");
            }
            catch
            {
                nConCascara = -1;
            }

            if (nConCascara == -1)
            {
                try
                {
                    nConCascara = cItemName.ToUpper().IndexOf("CON CASCARA");
                }
                catch
                {
                    nConCascara = -1;
                }

            }

            if (t_tipo_fruta.Text == "Nuez")
            {
                if (nConCascara >= 0)
                {
                    t_tipo_fruta.Text = "Nuez C/C";
                }
                else
                {
                    t_tipo_fruta.Text = "Nuez S/C";
                }

            }

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_SalidasProduccion_TipoProducto(t_tipo_fruta.Text);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            {
                try
                {
                    cSalida = dTable1.Rows[i]["U_HDV_Salida"].ToString();
                }
                catch
                {
                    cSalida = "";
                }

                try
                {
                    cTipoProducto = dTable1.Rows[i]["Name"].ToString();
                }
                catch
                {
                    cTipoProducto = "";

                }

            }

            if (nDocNum != nDocEntry)
            {
                t_DocNum.Clear();

            }

        }

        private void carga_producto()
        {
            int nNumOF;
            string cItemCode, cItemName;

            nNumOF = 0;
            cItemCode = "";
            cItemName = "";

            try
            {
                nNumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsProductos objproducto = new clsProductos();
            objproducto.cls_consultar_Productos2(nNumOF);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cItemCode = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
            }

            if (cItemCode != "")
            {
                t_itemcode.Text = cItemCode;
                t_itemname.Text = cItemName;

                t_grupo.Clear();

                clsProductos objproducto1 = new clsProductos();

                objproducto1.cls_consultar_Producto_x_codigo(t_itemcode.Text);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    t_grupo.Text = dTable1.Rows[0]["ItmsGrpNam"].ToString();
                }
                catch
                {
                    t_grupo.Clear();
                }

                t_almacen.Clear();
                t_linea.Clear();

                /////////////////////////////////////////
                /////////////////////////////////////////
                /// Determino el precio de costo OC

                string cItem_Code, cItem_Code_D, cWhsCode;
                string cWhsCode_D;

                int nLineId;

                cItem_Code = "";
                cWhsCode = "";

                t_cant_cajas.Text = 1.ToString();

                clsOrdenFabricacion objproducto2 = new clsOrdenFabricacion();

                objproducto2.cls_Consultar_OrdenFabricacion_x_DocNum1(nNumOF);

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto2.cResultado;

                try
                {
                    t_tipo_of.Text = dTable2.Rows[0]["U_TipoFruta"].ToString();
                }
                catch
                {
                    t_tipo_of.Clear();
                }

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {
                    cItem_Code = "";
                    cItem_Code_D = "";
                    cWhsCode = "";
                    cWhsCode_D = "";
                    nLineId = 0;

                    try
                    {
                        cItem_Code = dTable2.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        cItem_Code = "";
                    }

                    try
                    {
                        cItem_Code_D = dTable2.Rows[i]["ItemCode_D"].ToString();

                    }
                    catch
                    {
                        cItem_Code_D = "";
                    }

                    try
                    {
                        cWhsCode = dTable2.Rows[i]["Warehouse"].ToString();

                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        cWhsCode_D = dTable2.Rows[i]["Warehouse_D"].ToString();

                    }
                    catch
                    {
                        cWhsCode_D = "";
                    }

                    try
                    {
                        nLineId = Convert.ToInt32(dTable2.Rows[i]["LineNum"].ToString());

                    }
                    catch
                    {
                        nLineId = 0;
                    }

                    if (t_linea.Text == "")
                    {
                        if (t_itemcode.Text == cItem_Code)
                        {
                            t_almacen.Text = cWhsCode;
                            t_linea.Text = "-1";

                        }

                        if (t_itemcode.Text == cItem_Code_D)
                        {
                            t_almacen.Text = cWhsCode_D;
                            t_linea.Text = nLineId.ToString();

                        }

                    }


                }

                string cCardoCode_Prov, nCardName_Prov;
                string cCardoCode_Cliente, nCardName_Cliente;
                string cCity;

                cCardoCode_Prov = "";
                nCardName_Prov = "";
                cCardoCode_Cliente = "";
                nCardName_Cliente = "";
                cCity = "";

                if (t_tipo_of.Text == "Propia")
                {

                    int nCantProductores_FrutaPropia;
                    string cCardCode_Prov_FrutaPropia;

                    nCantProductores_FrutaPropia = 0;
                    cCardCode_Prov_FrutaPropia = "";

                    clsOrdenFabricacion objproducto9 = new clsOrdenFabricacion();

                    objproducto9.cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(nNumOF);

                    DataTable dTable9 = new DataTable();
                    dTable9 = objproducto9.cResultado;

                    for (int x = 0; x <= dTable9.Rows.Count - 1; x++)
                    {

                        try
                        {
                            cCardCode_Prov_FrutaPropia = dTable9.Rows[x]["MnfSerial"].ToString();
                        }
                        catch
                        {
                            cCardCode_Prov_FrutaPropia = "";
                        }

                        if (cCardCode_Prov_FrutaPropia.Trim() != "")
                        {
                            cCardoCode_Prov = cCardCode_Prov_FrutaPropia.Trim();
                        }

                        nCantProductores_FrutaPropia += 1;

                    }

                    if (nCantProductores_FrutaPropia == 0)
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    if (nCantProductores_FrutaPropia > 1)
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    if (cCardoCode_Prov == "")
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    //cCardoCode_Prov = "P96854230";
                    nCardName_Prov = "";
                    cCity = "";
                    cCardoCode_Cliente = "";
                    nCardName_Cliente = "";

                }

                if (t_tipo_of.Text == "Servicio")
                {
                    clsOrdenFabricacion objproducto4 = new clsOrdenFabricacion();

                    objproducto4.cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(nNumOF);

                    DataTable dTable4 = new DataTable();
                    dTable4 = objproducto4.cResultado;

                    for (int x = 0; x <= dTable4.Rows.Count - 1; x++)
                    {
                        if (cCardoCode_Prov == "")
                        {
                            try
                            {
                                cCardoCode_Prov = dTable4.Rows[x]["MnfSerial"].ToString();
                            }
                            catch
                            {
                                cCardoCode_Prov = "";
                            }

                        }


                        if (cCardoCode_Cliente == "")
                        {
                            try
                            {
                                cCardoCode_Cliente = dTable4.Rows[x]["LotNumber"].ToString();
                            }
                            catch
                            {
                                cCardoCode_Cliente = "";
                            }

                        }

                    }

                }

                if (cCardoCode_Prov != "")
                {
                    nCardName_Prov = "";
                    cCity = "";

                    clsSocioNegocio objproducto3 = new clsSocioNegocio();

                    objproducto3.cls_Consultar_OCRDxCardCode(cCardoCode_Prov);

                    DataTable dTable3 = new DataTable();
                    dTable3 = objproducto3.cResultado;

                    try
                    {
                        nCardName_Prov = dTable3.Rows[0]["CardName"].ToString();
                    }
                    catch
                    {
                        nCardName_Prov = "";
                    }

                    try
                    {
                        cCity = dTable3.Rows[0]["City"].ToString();
                    }
                    catch
                    {
                        cCity = "";
                    }

                }

                if (cCardoCode_Cliente != "")
                {
                    nCardName_Cliente = "";

                    clsSocioNegocio objproducto3 = new clsSocioNegocio();

                    objproducto3.cls_Consultar_OCRDxCardCode(cCardoCode_Cliente);

                    DataTable dTable3 = new DataTable();
                    dTable3 = objproducto3.cResultado;

                    try
                    {
                        nCardName_Cliente = dTable3.Rows[0]["CardName"].ToString();
                    }
                    catch
                    {
                        nCardName_Cliente = "";
                    }

                }

                t_cardcode.Text = cCardoCode_Prov;
                t_cardname.Text = nCardName_Prov;
                //t_comuna.Text = cCity;

                t_cardcode_clte.Text = cCardoCode_Cliente;
                t_cardname_clte.Text = nCardName_Cliente;

            }

        }

        private void Calcula_peso_bins()
        {
            int peso_bins;
            string cCod_Bins;
            double cant_bins;

            cant_bins = 0;
            cCod_Bins = "";
            peso_bins = 0;

            try
            {
                cant_bins = Convert.ToDouble(t_cantidad_envases.Text);

            }
            catch
            {
                cant_bins = 0;

            }

            t_cantidad_envases.Text = cant_bins.ToString("N");

            try
            {
                cCod_Bins = cbb_bins.SelectedValue.ToString();

            }
            catch
            {
                cCod_Bins = "";

            }

            peso_bins = 0;


            if (cCod_Bins != "")
            {

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Producto_x_codigo(cCod_Bins);

                DataTable dTable = new DataTable();

                dTable = objproducto.cResultado;

                try
                {
                    peso_bins = Convert.ToInt32(dTable.Rows[0].ItemArray[3].ToString());

                }
                catch
                {
                    peso_bins = 0;
                }

            }

            t_peso_envases.Text = (cant_bins * peso_bins).ToString("N2");

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_crea_recibo_Click(object sender, EventArgs e)
        {

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_LineId = 0;

            frmSel_OrdendeCompra f2 = new frmSel_OrdendeCompra();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

                t_numoc.Text = VariablesGlobales.glb_NumOC.Trim();

                //t_itemcode.Text = VariablesGlobales.glb_ItemCode.Trim();
                //t_itemname.Text = VariablesGlobales.glb_ItemName.Trim();

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
    }

}
