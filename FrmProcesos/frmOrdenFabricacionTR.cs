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
using System.Threading;

namespace FrmProcesos
{
    public partial class frmOrdenFabricacionTR : Form
    {

        public frmOrdenFabricacionTR()
        {
            InitializeComponent();
            
        }

        private void frmOrdenFabricacionTR_Load(object sender, EventArgs e)
        {

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_turnos_parametros();

            cbb_turno.DataSource = objproducto1.cResultado;
            cbb_turno.ValueMember = "FldValue";
            cbb_turno.DisplayMember = "FldValue";


            lbl_operadorcracker_1.Visible = false;
            lbl_operadorcracker_2.Visible = false;
            t_cant_bins_ncc.Visible = false;

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

            cbb_Salida.Items.Clear();

            t_ItemCode_ICaja.Clear();
            t_ItemName_ICaja.Clear();
            t_warehouse_ICaja.Clear();

            t_ItemCode_IBolsa.Clear();
            t_ItemName_IBolsa.Clear();
            t_warehouse_IBolsa.Clear();

            t_ItemCode_ISaco.Clear();
            t_ItemName_ISaco.Clear();
            t_warehouse_ISaco.Clear();

            groupBox_insumos.Visible = false;

            pbox_caja_error.Visible = false;
            pbox_caja_ok.Visible = false;

            pbox_bolsa_error.Visible = false;
            pbox_bolsa_ok.Visible = false;

            pbox_saco_error.Visible = false;
            pbox_saco_ok.Visible = false;

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {

            lbl_operadorcracker_1.Visible = false;
            lbl_operadorcracker_2.Visible = false;

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                limpia_pantalla();
                
                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                Carga_fruta();

                Application.DoEvents();

                carga_detalles_tr();

                Application.DoEvents();

            }

        }

        private void limpia_pantalla()
        {

            t_DocNum.Clear();
            t_itemcode.Clear();
            t_itemname.Clear();
            t_almacen.Clear();
            t_linea.Clear();
            t_kilos.Clear();
            t_cant_cajas.Clear();
            t_peso_x_caja.Clear();
            t_ultima_caja.Clear();
            t_tipo_of.Clear();
            t_ItemCode_Cabecera.Clear();

            t_grupo.Clear();
            t_cardcode.Clear();
            t_cardname.Clear();
            t_comuna.Clear();

            t_cardcode_cliente.Clear();
            t_cardname_cliente.Clear();

            t_ItemCode_ICaja.Clear();
            t_ItemName_ICaja.Clear();
            t_warehouse_ICaja.Clear();

            t_ItemCode_IBolsa.Clear();
            t_ItemName_IBolsa.Clear();
            t_warehouse_IBolsa.Clear();

            groupBox_insumos.Visible = false;

            pbox_caja_error.Visible = false;
            pbox_caja_ok.Visible = false;

            pbox_bolsa_error.Visible = false;
            pbox_bolsa_ok.Visible = false;


        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            int nNumOF;

            nNumOF = 0;

            //btn_agrega_pallet_existente.Enabled = true;

            try
            {
                nNumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF==0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            t_unidad.Text = "";

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = nNumOF; 

            frmSel_Productos2 f2 = new frmSel_Productos2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode.Trim() != "")
            {
                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

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

                try
                {
                    t_unidad.Text = dTable1.Rows[0]["InvntryUom"].ToString();
                }
                catch
                {
                    t_unidad.Text = "";
                }

                t_almacen.Clear();
                t_linea.Clear();

                if (t_unidad.Text == "01K" && groupBox_insumos.Visible == true)
                {
                    btn_insumos_cajas.Enabled = false;
                    btn_insumos_bolsas.Enabled = false;
                    btn_insumos_sacos.Enabled = false;

                    t_ItemCode_ICaja.Text = "";
                    t_ItemCode_IBolsa.Text = "";
                    t_ItemCode_ISaco.Text = "";

                }
                else
                {
                    btn_insumos_cajas.Enabled = true;
                    btn_insumos_bolsas.Enabled = true;
                    btn_insumos_sacos.Enabled = true;

                }


                /////////////////////////////////////////
                /////////////////////////////////////////
                /// Determino el precio de costo OC

                string cItem_Code, cItem_Code_D, cWhsCode;
                string cWhsCode_D;

                int nLineId;

                cItem_Code = "";
                cWhsCode = "";

                t_kilos.Text = 0.ToString("N2");
                t_cant_cajas.Text = 1.ToString();
                t_peso_x_caja.Text = 0.ToString("N2");
                t_ultima_caja.Text = 0.ToString("N2");

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();

                objproducto.cls_Consultar_OrdenFabricacion_x_DocNum1(nNumOF);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_tipo_of.Text = dTable.Rows[0]["U_TipoFruta"].ToString();
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

                    //sql = "select ";
                    //sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,  ";
                    //sql += "t0. , t1.ItemName , t1.InvntryUom , t0.UserSign , t0. , ";
                    //sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments ,  ";
                    //sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta , ";

                    //sql += "t2.LineNum , t2.ItemCode as  , t2.BaseQty , t2.PlannedQty as PlannedQty_D , ";
                    //sql += "t3.ItemName as ItemName_D , t2.Warehouse as  , t2.IssuedQty ,  ";
                    //sql += "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t2.ItemCode and ta1.WhsCode = t2.Warehouse ) , 0 ) as OnOrder_D , ";
                    //sql += "coalesce ( t3.InvntryUom , '' ) as InvntryUom_D ";

                    try
                    {
                        cItem_Code = dTable.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        cItem_Code = "";
                    }

                    try
                    {
                        cItem_Code_D = dTable.Rows[i]["ItemCode_D"].ToString();

                    }
                    catch
                    {
                        cItem_Code_D = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["Warehouse"].ToString();

                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        cWhsCode_D = dTable.Rows[i]["Warehouse_D"].ToString();

                    }
                    catch
                    {
                        cWhsCode_D = "";
                    }

                    try
                    {
                        nLineId = Convert.ToInt32(dTable.Rows[i]["LineNum"].ToString());

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

                        if (t_itemcode.Text == cItem_Code_D.ToUpper())
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

                    if (t_itemcode.Text == "FP.NUE.SE.NCC1.XXX.X.XXX-XXX.XXX.G.0001K.01")
                    {
                        t_cant_cajas.Visible = false;
                        t_cant_bins_ncc.Visible = true;

                    }


                }

                if (t_tipo_of.Text == "Servicio")
                {

                    clsOrdenFabricacion objproducto2 = new clsOrdenFabricacion();

                    objproducto2.cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(nNumOF);

                    DataTable dTable2 = new DataTable();
                    dTable2 = objproducto2.cResultado;

                    for (int x = 0; x <= dTable2.Rows.Count - 1; x++)
                    {
                        if (cCardoCode_Prov == "")
                        {
                            try
                            {
                                cCardoCode_Prov = dTable2.Rows[x]["MnfSerial"].ToString();
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
                                cCardoCode_Cliente = dTable2.Rows[x]["LotNumber"].ToString();
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
                t_comuna.Text = cCity;

                t_cardcode_cliente.Text = cCardoCode_Cliente;
                t_cardname_cliente.Text = nCardName_Cliente;

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = 0;


        }

        private void btn_crea_recibo_Click(object sender, EventArgs e)
        {
          
            int nDocNum;

            nDocNum = 0;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            if (cbb_turno.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nDocNum == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Fabricación válida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text == "")
            {
                MessageBox.Show("Debe seleccionar una Producto válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_Salida.SelectedIndex <0)
            {
                MessageBox.Show("Debe seleccionar una Salida válida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double nQuantity;
            int nCantidadBins, nLineNum;
            string cItemCodeCabecera, cItemCodeDetalle, cTurno;

            cTurno = "N/A";

            try
            {
                cTurno = cbb_turno.SelectedValue.ToString();

            }
            catch
            {

            }

            cItemCodeCabecera = "";
            cItemCodeDetalle = "";

            try
            {
                cItemCodeCabecera = t_ItemCode_Cabecera.Text.ToUpper().Substring(0, 3);
            }
            catch
            {
                cItemCodeCabecera = "";
            }

            try
            {
                cItemCodeDetalle = t_itemcode.Text.ToUpper().Substring(0, 3);
            }
            catch
            {
                cItemCodeDetalle = "";
            }

            if (cItemCodeCabecera != cItemCodeDetalle)
            {
                MessageBox.Show("Error de Referencia, Los productos no tiene el mismo Tipo Servicio / Propio, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            try
            {
                nQuantity = Convert.ToDouble(t_kilos.Text);
            }
            catch
            {
                nQuantity = 0;
            }

            if (nQuantity == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad de kilos válidos, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nCantidadBins = int.Parse(t_cant_cajas.Text);
            }
            catch
            {
                nCantidadBins = 0;
            }

            if (nCantidadBins == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad de cajas válidos, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nLineNum = int.Parse(t_linea.Text);
            }
            catch
            {
                nLineNum = -2;
            }


            if (nLineNum == -2)
            {
                MessageBox.Show("Debe seleccionar un ítem válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar el Termination Report", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cDocDate;

            DateTime dFecha;

            dFecha = DateTime.Parse("01/01/1900");

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_lee_fecha_servidor();

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                dFecha = Convert.ToDateTime(dTable1.Rows[0]["fecha"].ToString());

            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");

            }

            //try
            //{
            //    dFecha = Convert.ToDateTime(t_fecha_contable.Text);
            //}
            //catch
            //{
            //    dFecha = DateTime.Parse("01/01/1900");
            //}

            cDocDate = dFecha.ToString("yyyyMMdd");

            string cWharehouse, cSalidaProduccion;
            string cCardCode_Productor, cCardName_Productor;
            string cCardCode_Cliente, cCardName_Cliente;

            double nPesoUltimaCaja;

            cWharehouse = t_almacen.Text;

            cCardCode_Productor = "";
            cCardName_Productor = "";
            cCardCode_Cliente = "";
            cCardName_Cliente = "";
            cSalidaProduccion = "";

            try
            {
                cSalidaProduccion = (cbb_Salida.SelectedIndex + 1).ToString();
            }
            catch
            {
                cSalidaProduccion = "";
            }

            try
            {
                cCardCode_Productor = t_cardcode.Text;
            }
            catch
            {
                cCardCode_Productor = "";
            }

            try
            {
                cCardName_Productor = t_cardname.Text;
            }
            catch
            {
                cCardName_Productor = "";
            }

            try
            {
                cCardCode_Cliente = t_cardcode_cliente.Text;
            }
            catch
            {
                cCardCode_Cliente = "";
            }

            try
            {
                cCardName_Cliente = t_cardname_cliente.Text;
            }
            catch
            {
                cCardName_Cliente = "";
            }

            try
            {
                nPesoUltimaCaja = Convert.ToDouble(t_ultima_caja.Text);
            }
            catch
            {
                nPesoUltimaCaja = 0;
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

            cErrorMensaje = "";

            //////////////////////////////////////
            // Determino la Variedad de la Fruta 
            // Recibida

            int nCantVariedades;
            string cVariedadConsumo;

            nCantVariedades = 0;
            cVariedadConsumo = "";

            clsProduccion objproducto8 = new clsProduccion();

            objproducto8.cls_Consulta_Variedad_en_Producto_de_Consumo(nDocNum);

            DataTable dTable8 = new DataTable();
            dTable8 = objproducto8.cResultado;

            for (int i = 0; i <= dTable8.Rows.Count - 1; i++)
            {
                try
                {
                    cVariedadConsumo = dTable8.Rows[i]["U_HDV_VARIEDAD"].ToString();

                }
                catch
                {
                    cVariedadConsumo = "";

                }

                nCantVariedades += 1;

            }

            if (nCantVariedades > 1)
            {
                cVariedadConsumo = "Mix";
            }

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            // Valido las Cajas 

            double nCantInsumo_Validacion, nCantInsumo_Validacion_t;
            string cLoteInsumo_Validacion;

            if (groupBox_insumos.Visible == true)
            {
                if (btn_insumos_cajas.Visible == true && btn_insumos_cajas.Enabled == true)
                {
                    if (t_ItemCode_ICaja.Text == "")
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a las Cajas, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    nCantInsumo_Validacion = 0;
                    nCantInsumo_Validacion_t = 0;

                    for (int i = 0; i <= Grid1_Cajas.RowCount - 1; i++)
                    {

                        nCantInsumo_Validacion = 0;

                        try
                        {
                            cLoteInsumo_Validacion = Grid1_Cajas[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo_Validacion = "";
                        }

                        try
                        {
                            nCantInsumo_Validacion = Convert.ToDouble(Grid1_Cajas[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo_Validacion = 0;
                        }

                        if ((nCantInsumo_Validacion > 0) && (cLoteInsumo_Validacion != ""))
                        {
                            nCantInsumo_Validacion_t += nCantInsumo_Validacion;

                        }

                    }

                    if (nCantInsumo_Validacion_t < nQuantity)
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a las Cajas, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            // Valido las bolsas

            if (groupBox_insumos.Visible == true)
            {
                if (btn_insumos_bolsas.Visible == true && btn_insumos_bolsas.Enabled == true)
                {
                    if (t_ItemCode_IBolsa.Text == "")
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a las Bolsas, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    nCantInsumo_Validacion = 0;
                    nCantInsumo_Validacion_t = 0;

                    for (int i = 0; i <= Grid1_Bolsas.RowCount - 1; i++)
                    {

                        nCantInsumo_Validacion = 0;

                        try
                        {
                            cLoteInsumo_Validacion = Grid1_Bolsas[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo_Validacion = "";
                        }

                        try
                        {
                            nCantInsumo_Validacion = Convert.ToDouble(Grid1_Bolsas[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo_Validacion = 0;
                        }

                        if ((nCantInsumo_Validacion > 0) && (cLoteInsumo_Validacion != ""))
                        {
                            nCantInsumo_Validacion_t += nCantInsumo_Validacion;

                        }

                    }

                    if (nCantInsumo_Validacion_t < nQuantity)
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a las bolsas, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            // Valido los Sacos 

            if (groupBox_insumos.Visible == true)
            {
                if (btn_insumos_sacos.Visible == true && btn_insumos_sacos.Enabled == true)
                {
                    if (t_ItemCode_ISaco.Text == "")
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a los Sacos, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    nCantInsumo_Validacion = 0;
                    nCantInsumo_Validacion_t = 0;

                    for (int i = 0; i <= Grid1_Sacos.RowCount - 1; i++)
                    {

                        nCantInsumo_Validacion = 0;

                        try
                        {
                            cLoteInsumo_Validacion = Grid1_Sacos[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo_Validacion = "";
                        }

                        try
                        {
                            nCantInsumo_Validacion = Convert.ToDouble(Grid1_Sacos[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo_Validacion = 0;
                        }

                        if ((nCantInsumo_Validacion > 0) && (cLoteInsumo_Validacion != ""))
                        {
                            nCantInsumo_Validacion_t += nCantInsumo_Validacion;

                        }

                    }

                    if (nCantInsumo_Validacion_t < nQuantity)
                    {
                        MessageBox.Show("Error en la generación del Termination Report :::::: Debe determinar los Lotes asociados a las Cajas, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }
            //////////////////////////////////////
            // Genero el avance de proceso

            String mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo,"",cTurno);

            if (mensaje == "Error de Conexión")
            {
                mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo,"", cTurno);

            }

            if (mensaje == "Error de Conexión")
            {
                Thread.Sleep(500);
                mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo,"", cTurno);

            }

            int nTerminationReportEntry;

            try
            {
                nTerminationReportEntry = int.Parse(mensaje);
                cErrorMensaje = "";

            }
            catch
            {
                nTerminationReportEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación del Termination Report :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            t_docentry_recibo.Text = nTerminationReportEntry.ToString();

            //////////////////////////////////////
            // Corrigo el AbsEntry 

            mensaje = clsRecepcion.SAPB1_RECEPCION3(nTerminationReportEntry, 59);

            //////////////////////////////////////

            MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btn_crea_recibo.Enabled = false;

            btn_agrega_pallet.Enabled = true;
            btn_agrega_pallet_existente.Enabled = true;

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            // Genero el Consumos de Insumo tipo A
            // Siempre que corresponda !!!!!

            int nLineaInsumo, nConsumoInsumoEntry;
            double nCantInsumo;
            string cLoteInsumo;

            nLineaInsumo = 0;

            if (t_ItemCode_ICaja.Text != "")
            {
                clsOrdenFabricacion objproducto4 = new clsOrdenFabricacion();
                objproducto4.cls_Consultar_OrdenFabricacion_Insumos_Servicios_Linea(nDocNum, t_ItemCode_ICaja.Text);

                DataTable dTable4 = new DataTable();
                dTable4 = objproducto4.cResultado;

                try
                {
                    nLineaInsumo = Convert.ToInt32(dTable4.Rows[0]["LineNum"].ToString());
                }
                catch
                {
                    nLineaInsumo = -1;
                }

                if (nLineaInsumo >= 0)
                {

                    for (int i = 0; i <= Grid1_Cajas.RowCount - 1; i++)
                    {

                        nCantInsumo = 0;

                        try
                        {
                            cLoteInsumo = Grid1_Cajas[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo = "";
                        }

                        try
                        {
                            nCantInsumo = Convert.ToDouble(Grid1_Cajas[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo = 0;
                        }

                        nConsumoInsumoEntry = 0; 

                        if ((nCantInsumo > 0) && (cLoteInsumo != ""))
                        {

                            mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_ICaja.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            if (mensaje == "Error de Conexión")
                            {
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_ICaja.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                Thread.Sleep(500);
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_ICaja.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            try
                            {
                                nConsumoInsumoEntry = int.Parse(mensaje);

                            }
                            catch
                            {
                                //MessageBox.Show("Error en la generación del Consumo de Insumos:::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;

                            }

                        }

                    }

                }

            }

            nLineaInsumo = 0;

            if (t_ItemCode_IBolsa.Text != "")
            {
                clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
                objproducto5.cls_Consultar_OrdenFabricacion_Insumos_Servicios_Linea(nDocNum, t_ItemCode_IBolsa.Text);

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

                try
                {
                    nLineaInsumo = Convert.ToInt32(dTable5.Rows[0]["LineNum"].ToString());
                }
                catch
                {
                    nLineaInsumo = -1;
                }

                if (nLineaInsumo >= 0)
                {

                    for (int i = 0; i <= Grid1_Bolsas.RowCount - 1; i++)
                    {

                        nCantInsumo = 0;

                        try
                        {
                            cLoteInsumo = Grid1_Bolsas[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo = "";
                        }

                        try
                        {
                            nCantInsumo = Convert.ToDouble(Grid1_Bolsas[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo = 0;
                        }

                        nConsumoInsumoEntry = 0;

                        if ((nCantInsumo > 0) && (cLoteInsumo != ""))
                        {

                            mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            if (mensaje == "Error de Conexión")
                            {
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                Thread.Sleep(500);
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            try
                            {
                                nConsumoInsumoEntry = int.Parse(mensaje);

                            }
                            catch
                            {
                                //MessageBox.Show("Error en la generación del Consumo de Insumos:::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;

                            }

                        }

                    }

                }

            }

            nLineaInsumo = 0;

            if (t_ItemCode_ISaco.Text != "")
            {
                clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
                objproducto5.cls_Consultar_OrdenFabricacion_Insumos_Servicios_Linea(nDocNum, t_ItemCode_ISaco.Text);

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

                try
                {
                    nLineaInsumo = Convert.ToInt32(dTable5.Rows[0]["LineNum"].ToString());
                }
                catch
                {
                    nLineaInsumo = -1;
                }

                if (nLineaInsumo >= 0)
                {

                    for (int i = 0; i <= Grid1_Sacos.RowCount - 1; i++)
                    {

                        nCantInsumo = 0;

                        try
                        {
                            cLoteInsumo = Grid1_Sacos[0, i].Value.ToString();
                        }
                        catch
                        {
                            cLoteInsumo = "";
                        }

                        try
                        {
                            nCantInsumo = Convert.ToDouble(Grid1_Sacos[1, i].Value.ToString());
                        }
                        catch
                        {
                            nCantInsumo = 0;
                        }

                        nConsumoInsumoEntry = 0;

                        if ((nCantInsumo > 0) && (cLoteInsumo != ""))
                        {

                            mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "","");

                            if (mensaje == "Error de Conexión")
                            {
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                Thread.Sleep(500);
                                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocNum, nLineaInsumo, nCantInsumo, t_warehouse_IBolsa.Text, 1, cLoteInsumo, "", "", "", "", "CONSUMO PARA PRODUCCION " + t_docentry_recibo.Text, UsuarioSap, ClaveSap, "", "");

                            }

                            try
                            {
                                nConsumoInsumoEntry = int.Parse(mensaje);

                            }
                            catch
                            {
                                //MessageBox.Show("Error en la generación del Consumo de Insumos:::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;

                            }

                        }

                    }

                }

            }

            //btn_imprimir.Enabled = true;

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////

            string cLote, cUMedida;
            int nParametrosCalidad;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Datos_Entrada_x_id(nTerminationReportEntry,"59","");

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            cLote = "";

            try
            {
                cLote = dTable.Rows[0]["MdAbsEntry"].ToString();
            }
            catch
            {
                cLote = "0";
            }

            try
            {
                nParametrosCalidad = int.Parse(dTable.Rows[0]["Parametros_Calidad"].ToString());
            }
            catch
            {
                nParametrosCalidad = 0;
            }

            try
            {
                cUMedida = dTable.Rows[0]["U_Medida"].ToString();
            }
            catch
            {
                cUMedida = "";
            }

            if (cUMedida == "CTN10k")
            {
                //nParametrosCalidad = 0;
            }

            if (t_cant_bins_ncc.Visible == true)
            {
                int nCant_Bins_NCC;

                try
                {
                    nCant_Bins_NCC = Convert.ToInt32(t_cant_bins_ncc.Text);

                }
                catch
                {
                    nCant_Bins_NCC = 0;

                }

                if (nCant_Bins_NCC > 1)
                {
                    mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR2(Convert.ToInt32(cLote), nCant_Bins_NCC, UsuarioSap, ClaveSap);

                }

            }

            //////////////////////////////////////
            //////////////////////////////////////
            // Dejo el lote como acceso denegado

            if (t_itemcode.Text.Substring(7,2) == "PT")
            {
                mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(cLote), "A", UsuarioSap, ClaveSap);

            }

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////

            VariablesGlobales.glb_id_calidad = 0;
            VariablesGlobales.glb_Object = "59";
            VariablesGlobales.glb_id_romana = 0;

            VariablesGlobales.glb_DocEntry = nTerminationReportEntry;
            VariablesGlobales.glb_LineId = 0;

            VariablesGlobales.glb_NumOF = int.Parse(t_DocNum.Text);
            VariablesGlobales.glb_LineNumOF = int.Parse(t_linea.Text);

            VariablesGlobales.glb_ItemCode = t_itemcode.Text;
            VariablesGlobales.glb_Lote = int.Parse(cLote);

            if (nParametrosCalidad > 0)
            {
                string cDestino;

                cDestino = "";

                clsCalidad objproducto22 = new clsCalidad();
                objproducto22.cls_Consulta_Registro_Inspeccion_x_orden(int.Parse(t_DocNum.Text));

                DataTable dTable22 = new DataTable();
                dTable22 = objproducto22.cResultado;

                try
                {
                    cDestino = dTable22.Rows[0]["Destino"].ToString();
                }
                catch
                {
                    cDestino = "Proceso Anterior";
                }

                if (cDestino == "Proceso Anterior")
                {
                    frmCalidadPP4 fv4 = new frmCalidadPP4();
                    DialogResult res4 = fv4.ShowDialog();

                }
                else
                {
                    frmCalidadPPA6 fv0 = new frmCalidadPPA6();
                    DialogResult res0 = fv0.ShowDialog();

                }


            }
            else
            {
                btn_imprimir.Enabled = true;
            }

            btn_imprimir.Enabled = true;

            if (t_tipo_fruta.Text == "Nuez C/C")
            {
                btn_imprimir.Enabled = true;

            }


        }

        private void t_kilos_Leave(object sender, EventArgs e)
        {
            Calcular_Peso_x_caja();

        }

        private void t_cant_cajas_Leave(object sender, EventArgs e)
        {
            Calcular_Peso_x_caja();

        }

        private void Calcular_Peso_x_caja()
        {
            double nCantidadKilos, nPesoxCaja, nPesoUltimaCaja;
            int nCantidadCajas;

            try
            {
                nCantidadKilos = Convert.ToDouble(t_kilos.Text);
            }
            catch
            {
                nCantidadKilos = 0;
            }

            try
            {
                nCantidadCajas = int.Parse(t_cant_cajas.Text);
            }
            catch
            {
                nCantidadCajas = 0;
            }

            nPesoxCaja = 0;
            nPesoUltimaCaja = 0;

            if (nCantidadCajas != 0)
            {
                if (nCantidadKilos != 0)
                {
                    if (nCantidadCajas == 1)
                    {
                        nPesoxCaja = nCantidadKilos;
                        nPesoUltimaCaja = nCantidadKilos;
                    }

                    if (nCantidadCajas > 1)
                    {
                        nPesoxCaja = Math.Round(nCantidadKilos / nCantidadCajas, 2);
                        nPesoUltimaCaja = Math.Round(nPesoxCaja + (nCantidadKilos - Math.Round(nPesoxCaja * nCantidadCajas, 2)), 2);

                    }

                }

            }

            t_kilos.Text = nCantidadKilos.ToString("N2");
            t_cant_cajas.Text = nCantidadCajas.ToString();

            t_peso_x_caja.Text = nPesoxCaja.ToString("N2");
            t_ultima_caja.Text = nPesoUltimaCaja.ToString("N2");

        }

        private void btn_agrega_pallet_Click(object sender, EventArgs e)
        {
            if (t_itemcode.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Producto válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar nuevo pallet", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string[,] d_arrDetalle = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            int nDocEntry, nNumeroLotes, nLote;

            try
            {
                nDocEntry = int.Parse(t_docentry_recibo.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion(); 
            objproducto.cls_Consulta_Lotes_x_ReciboProduccion(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;
                     
            nNumeroLotes = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    nLote = Convert.ToInt32(dTable.Rows[i]["MdAbsEntry"].ToString());

                }
                catch
                {
                    nLote = 0;

                }

                if (nLote>0)
                {
                    d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                    nNumeroLotes += 1;

                }

            }

            if (nNumeroLotes==0)
            {
                MessageBox.Show("No existen lotes a asginar, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cWharehouse, cItemCode, cItemName;

            cWharehouse = t_almacen.Text;
            cItemCode = t_itemcode.Text;
            cItemName = t_itemname.Text;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap, cErrorMensaje;
            int nNuevoPallet; 

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

            string mensaje = clsOrdenFabricacion.Entrada_Mercaderia_Nuevo_Pallet(cItemCode, cItemName, cWharehouse , d_arrDetalle, UsuarioSap, ClaveSap);

            //////////////////////////////////////

            try
            {
                nNuevoPallet = int.Parse(mensaje);
                cErrorMensaje = "";

                t_pallet_nuevo.Text = "P" + nNuevoPallet.ToString();

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                nNuevoPallet = 0;
                cErrorMensaje = mensaje;
                t_pallet_nuevo.Clear();

                MessageBox.Show("Error en la generación de la orden de fabricacion :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_agrega_pallet.Enabled = false;
            btn_agrega_pallet_existente.Enabled = false;

        }

        private void btn_agrega_pallet_existente_Click(object sender, EventArgs e)
        {

            if (t_itemcode.Text == "")
            {
                MessageBox.Show("Debe seleccionar una Producto válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_almacen.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Asignar este Lotes a un pallet existente", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            VariablesGlobales.glb_ItemCode = t_itemcode.Text;
            VariablesGlobales.glb_Almacen = t_almacen.Text;
            VariablesGlobales.glb_Pallet = "";

            frmSel_Pallet f2 = new frmSel_Pallet();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Pallet == "")
            {
                return;
            }

            t_pallet_existente.Text = VariablesGlobales.glb_Pallet;

            string cPalleExistente, cErrorMensaje, mensaje;

            try
            {
                cPalleExistente = t_pallet_existente.Text;
            }
            catch
            {
                cPalleExistente = "";
            }

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            string[,] d_arrDetalle = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            int nDocEntry, nNumeroLotes, nLote;

            try
            {
                nDocEntry = int.Parse(t_docentry_recibo.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consulta_Lotes_x_ReciboProduccion(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            nNumeroLotes = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    nLote = Convert.ToInt32(dTable.Rows[i]["MdAbsEntry"].ToString());

                }
                catch
                {
                    nLote = 0;

                }

                if (nLote > 0)
                {
                    d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                    nNumeroLotes += 1;

                }

            }

            if (nNumeroLotes == 0)
            {
                MessageBox.Show("No existen lotes a asginar, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            cErrorMensaje = "";

            string UsuarioSap, ClaveSap;
            //string cErrorMensaje;

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

            mensaje = clsOrdenFabricacion.Entrada_Mercaderia_Asigna_Pallet(cPalleExistente, d_arrDetalle, UsuarioSap, ClaveSap);

            try
            {
                //nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                //nOrdenFabricacionEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_agrega_pallet.Enabled = false;
            btn_agrega_pallet_existente.Enabled = false;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_docentry_recibo.Text);
            }
            catch
            {
                nDocEntry = 0;
            }


            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            VariablesGlobales.glb_DocEntry = nDocEntry;

            frmReporteProduccion f2 = new frmReporteProduccion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

            //btn_imprimir.Enabled = true;


        }

        private void Carga_fruta()
        {

            lbl_operadorcracker_1.Visible = false;
            lbl_operadorcracker_2.Visible = false;

            int nDocNum, nDocEntry, nConCascara;
            string cItemName, cSalida, cTipoProducto;
            string cTurno;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            t_tipo_fruta.Clear();
            t_ItemCode_Cabecera.Clear();
            t_code_operador.Clear();

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

            try
            {
                t_code_operador.Text = dTable.Rows[0]["Code_Operador"].ToString();

            }
            catch
            {
                t_code_operador.Clear();

            }

            lbl_operadorcracker_2.Text = "";

            try
            {
                lbl_operadorcracker_2.Text = dTable.Rows[0]["Name_Operador"].ToString();

            }
            catch
            {
                lbl_operadorcracker_2.Text = "";

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

            if (t_code_operador.Text != "")
            {
                lbl_operadorcracker_1.Visible = true;
                lbl_operadorcracker_2.Visible = true;

            }
            else
            {
                lbl_operadorcracker_1.Visible = false;
                lbl_operadorcracker_2.Visible = false;

            }

            try
            {
                cTurno = dTable.Rows[0]["U_Turno"].ToString();

            }
            catch
            {
                cTurno = "N/A";

            }

            try
            {
                cbb_turno.SelectedValue = cTurno;

            }
            catch
            {
                cbb_turno.SelectedIndex = 0;

            }

            cbb_Salida.Items.Clear();

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

                cbb_Salida.Items.Add(cSalida + " - " + cTipoProducto);

            }

            if (nDocNum != nDocEntry)
            {
                t_DocNum.Clear();
                cbb_Salida.Items.Clear();

            }

            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////
            // Esto es para Insumos 

            groupBox_insumos.Visible = false;

            t_ItemCode_ICaja.Clear();
            t_ItemName_ICaja.Clear();
            t_warehouse_ICaja.Clear();

            t_ItemCode_IBolsa.Clear();
            t_ItemName_IBolsa.Clear();
            t_warehouse_IBolsa.Clear();

            t_ItemCode_ISaco.Clear();
            t_ItemName_ISaco.Clear();
            t_warehouse_ISaco.Clear();

            groupBox_insumos.Visible = false;

            pbox_caja_error.Visible = false;
            pbox_caja_ok.Visible = false;

            pbox_bolsa_error.Visible = false;
            pbox_bolsa_ok.Visible = false;

            pbox_saco_error.Visible = false;
            pbox_saco_ok.Visible = false;

            ///////////////////////////////////////////////////

            string cItemCode_ICaja, cItemName_ICaja, cWareHouse_ICaja;
            string cItemCode_IBolsa, cItemName_IBolsa, cWareHouse_IBolsa;
            string cItemCode_ISaco, cItemName_ISaco, cWareHouse_ISaco;

            string cItemCode_I, cItemName_I, cTipoInsumo;
            string cWareHouse_I;

            cItemCode_ICaja = "";
            cItemName_ICaja = "";
            cWareHouse_ICaja = "";

            cItemCode_IBolsa = "";
            cItemName_IBolsa = "";
            cWareHouse_IBolsa = "";

            cItemCode_ISaco = "";
            cItemName_ISaco = "";
            cWareHouse_ISaco = "";

            clsOrdenFabricacion objproducto3 = new clsOrdenFabricacion();
            objproducto3.cls_Consultar_OrdenFabricacion_x_DocNum_Insumos(nDocNum);

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto3.cResultado;

            for (int i = 0; i <= dTable3.Rows.Count - 1; i++)
            {
                try
                {
                    cTipoInsumo = dTable3.Rows[i]["ItmsGrpNam"].ToString();
                }
                catch
                {
                    cTipoInsumo = "";
                }

                try
                {
                    cItemCode_I = dTable3.Rows[i]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode_I = "";
                }

                try
                {
                    cItemName_I = dTable3.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemName_I = "";
                }

                try
                {
                    cWareHouse_I = dTable3.Rows[i]["wareHouse"].ToString();
                }
                catch
                {
                    cWareHouse_I = "";
                }
                

                if (cTipoInsumo.ToUpper() == "CAJAS" || cTipoInsumo.ToUpper() == "CAJAS SERVICIOS")
                {
                    cItemCode_ICaja = cItemCode_I;
                    cItemName_ICaja = cItemName_I;
                    cWareHouse_ICaja = cWareHouse_I;

                }

                if (cTipoInsumo.ToUpper() == "BOLSAS")
                {
                    cItemCode_IBolsa = cItemCode_I;
                    cItemName_IBolsa = cItemName_I;
                    cWareHouse_IBolsa = cWareHouse_I;

                }

                if (cTipoInsumo.ToUpper() == "INSUMO SACOS")
                {
                    cItemCode_ISaco = cItemCode_I;
                    cItemName_ISaco = cItemName_I;
                    cWareHouse_ISaco = cWareHouse_I;

                }

            }

            t_ItemCode_ICaja.Text = cItemCode_ICaja;
            t_ItemName_ICaja.Text = cItemName_ICaja;
            t_warehouse_ICaja.Text = cWareHouse_ICaja;

            t_ItemCode_IBolsa.Text = cItemCode_IBolsa;
            t_ItemName_IBolsa.Text = cItemName_IBolsa;
            t_warehouse_IBolsa.Text = cWareHouse_IBolsa;

            t_ItemCode_ISaco.Text = cItemCode_ISaco;
            t_ItemName_ISaco.Text = cItemName_ISaco;
            t_warehouse_ISaco.Text = cWareHouse_ISaco;

            if ((cItemCode_ICaja != "") || (cItemCode_IBolsa != "") || (cItemCode_ISaco != ""))
            {
                groupBox_insumos.Visible = true;

                pbox_caja_error.Visible = true;
                pbox_caja_ok.Visible = false;

                pbox_bolsa_error.Visible = true;
                pbox_bolsa_ok.Visible = false;

                pbox_saco_error.Visible = true;
                pbox_saco_ok.Visible = false;

                // Cajas

                label21.Visible = true;
                btn_insumos_cajas.Visible = true;
                pbox_caja_error.Visible = true;
                pbox_caja_ok.Visible = false;

                label28.Visible = true;
                btn_insumos_bolsas.Visible = true;
                pbox_bolsa_error.Visible = true;
                pbox_bolsa_ok.Visible = false;

                label23.Visible = true;
                btn_insumos_sacos.Visible = true;
                pbox_saco_error.Visible = true;
                pbox_saco_ok.Visible = false;

            }

            if (cItemCode_ICaja == "") 
            {
                label21.Visible = false;
                btn_insumos_cajas.Visible = false;
                pbox_caja_error.Visible = false;
                pbox_caja_ok.Visible = false;

            }


            if (cItemCode_IBolsa == "")
            {
                label28.Visible = false;
                btn_insumos_bolsas.Visible = false;
                pbox_bolsa_error.Visible = false;
                pbox_bolsa_ok.Visible = false;

            }

            if (cItemCode_ISaco == "")
            {
                label23.Visible = false;
                btn_insumos_sacos.Visible = false;
                pbox_saco_error.Visible = false;
                pbox_saco_ok.Visible = false;

            }

        }

        private void t_codigo_barra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                string cCodigoBarra;

                cCodigoBarra = t_codigo_barra.Text;

                if (cCodigoBarra != "")
                {

                    int largo, nValor, nSimbolo;
                    int nSalida;

                    string cValor, cOrdenFabricacion, cSalida;

                    largo = cCodigoBarra.Length;
                    nSimbolo = largo;

                    for (int i = 0; i <= largo; i++)
                    {
                        try
                        {
                            cValor = cCodigoBarra.Substring(i, 1);
                        }
                        catch
                        {
                            cValor = "";
                        }

                        try
                        {
                            nValor = int.Parse(cValor);
                        }
                        catch
                        {
                            nValor = -1;
                        }

                        if (nValor == -1)
                        {
                            nSimbolo = i;
                            break;
                        }

                    }

                    cOrdenFabricacion = "";

                    try
                    {
                        cOrdenFabricacion = cCodigoBarra.Substring(0, nSimbolo);
                    }
                    catch
                    {

                    }

                    try
                    {
                        cSalida = cCodigoBarra.Substring(nSimbolo+1, largo-(nSimbolo+1));
                    }
                    catch
                    {
                        cSalida = "";
                    }

                    try
                    {
                        nSalida = int.Parse(cSalida);
                    }
                    catch
                    {
                        nSalida = -1;
                    }

                    t_DocNum.Text = cOrdenFabricacion;
                    cbb_Salida.Items.Clear();

                    Carga_fruta();

                    try
                    {
                        cbb_Salida.SelectedIndex = nSalida - 1;
                    }
                    catch
                    {
                        cbb_Salida.SelectedIndex = -1;
                    }

                    t_codigo_barra.Clear();

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {          


        }

        private void btn_insumos_cajas_Click(object sender, EventArgs e)
        {
            if (t_ItemCode_ICaja.Text == "")
            {
                MessageBox.Show("No se ha definido un insumo de **Caja** para esta orden de fabricación, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nCant_ReciboProduccion, nCant_Definida, nCantidad;
            string cLote;
            int nLinea;

            try
            {
                nCant_ReciboProduccion = Convert.ToDouble(t_kilos.Text); 
            }
            catch
            {
                nCant_ReciboProduccion = 0;
            }

            if (nCant_ReciboProduccion == 0)
            {
                MessageBox.Show("No se han registrado cantidades a procesar, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            nCant_Definida = 0;

            VariablesGlobales.glb_Array7 = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                VariablesGlobales.glb_Array7[0, i] = "";

            }

            VariablesGlobales.glb_Array1_ind = -1;

            nLinea = 0;

            for (int i = 0; i <= Grid1_Cajas.RowCount - 1; i++)
            {

                nCantidad = 0;

                try
                {
                    cLote = Grid1_Cajas[0, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(Grid1_Cajas[1, i].Value.ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                if ((nCantidad > 0) && (cLote != ""))
                {
                    VariablesGlobales.glb_Array7[0, nLinea] = cLote;
                    VariablesGlobales.glb_Array7[1, nLinea] = nCantidad.ToString();

                    nLinea += 1;

                    VariablesGlobales.glb_Array1_ind = nLinea;

                }

            }

            VariablesGlobales.glb_ItemCode = t_ItemCode_ICaja.Text;
            VariablesGlobales.glb_ItemName = t_ItemName_ICaja.Text;
            VariablesGlobales.glb_Almacen = t_warehouse_ICaja.Text;
            VariablesGlobales.glb_Cantidad = nCant_ReciboProduccion;

            //VariablesGlobales.glb_Array1 = d_arrDetalle;

            frmOrdenFabricacionTRA1 f2 = new frmOrdenFabricacionTRA1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Array1_ind >= 0)
            {

                Grid1_Cajas.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= VariablesGlobales.glb_Array1_ind; i++)
                {

                    try
                    {
                        cLote = VariablesGlobales.glb_Array7[0, i];
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        nCantidad = Convert.ToDouble(VariablesGlobales.glb_Array7[1, i]);
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    nCant_Definida += nCantidad;

                    if ((cLote != "") && (nCantidad > 0))
                    {
                        grilla[0] = cLote;
                        grilla[1] = nCantidad.ToString("N2");

                        Grid1_Cajas.Rows.Add(grilla);

                    }

                }

                if (nCant_ReciboProduccion <= nCant_Definida)
                {
                    pbox_caja_error.Visible = false;
                    pbox_caja_ok.Visible = true;

                }
                else
                {
                    pbox_caja_error.Visible = true;
                    pbox_caja_ok.Visible = false;

                }

            }

        }

        private void btn_insumos_bolsas_Click(object sender, EventArgs e)
        {
            if (t_ItemCode_IBolsa.Text == "")
            {
                MessageBox.Show("No se ha definido un insumo de **Bolsa** para esta orden de fabricación, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nCant_ReciboProduccion, nCant_Definida, nCantidad;
            string cLote;
            int nLinea;

            try
            {
                nCant_ReciboProduccion = Convert.ToDouble(t_kilos.Text);
            }
            catch
            {
                nCant_ReciboProduccion = 0;
            }

            if (nCant_ReciboProduccion == 0)
            {
                MessageBox.Show("No se han registrado cantidades a procesar, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            nCant_Definida = 0;

            VariablesGlobales.glb_Array7 = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                VariablesGlobales.glb_Array7[0, i] = "";

            }

            VariablesGlobales.glb_Array1_ind = -1;

            nLinea = 0;

            for (int i = 0; i <= Grid1_Bolsas.RowCount - 1; i++)
            {

                nCantidad = 0;

                try
                {
                    cLote = Grid1_Bolsas[0, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(Grid1_Bolsas[1, i].Value.ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                if ((nCantidad > 0) && (cLote != ""))
                {
                    VariablesGlobales.glb_Array7[0, nLinea] = cLote;
                    VariablesGlobales.glb_Array7[1, nLinea] = nCantidad.ToString();

                    nLinea += 1;

                    VariablesGlobales.glb_Array1_ind = nLinea;

                }

            }

            VariablesGlobales.glb_ItemCode = t_ItemCode_IBolsa.Text;
            VariablesGlobales.glb_ItemName = t_ItemName_IBolsa.Text;
            VariablesGlobales.glb_Almacen = t_warehouse_IBolsa.Text;
            VariablesGlobales.glb_Cantidad = nCant_ReciboProduccion;

            frmOrdenFabricacionTRA1 f2 = new frmOrdenFabricacionTRA1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Array1_ind >= 0)
            {

                Grid1_Bolsas.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= VariablesGlobales.glb_Array1_ind; i++)
                {

                    try
                    {
                        cLote = VariablesGlobales.glb_Array7[0, i];
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        nCantidad = Convert.ToDouble(VariablesGlobales.glb_Array7[1, i]);
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    nCant_Definida += nCantidad;

                    if ((cLote != "") && (nCantidad > 0))
                    {
                        grilla[0] = cLote;
                        grilla[1] = nCantidad.ToString("N2");

                        Grid1_Bolsas.Rows.Add(grilla);

                    }

                }

                if (nCant_ReciboProduccion <= nCant_Definida)
                {                    
                    pbox_bolsa_error.Visible = false;
                    pbox_bolsa_ok.Visible = true;

                }
                else
                {
                    pbox_bolsa_error.Visible = true;
                    pbox_bolsa_ok.Visible = false;

                }

            }


        }

        private void carga_detalles_tr()
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

            nDocNum = nDocNum * -1;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Detalle_TR(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cLine, cItemCode, cItemName;
            string cDocEntry, cLote;
            string cUM, cBodega, cHora;

            double nCantidad_TR;

            int nid_calidad;

            DateTime dFecha;

            Grid4.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = (i + 1).ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cDocEntry = dTable.Rows[i]["DocEntry"].ToString();
                }
                catch
                {
                    cDocEntry = "";

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
                    cUM = dTable.Rows[i]["unitMsr"].ToString();
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

                nCantidad_TR = 0;

                try
                {
                    nCantidad_TR = Convert.ToDouble(dTable.Rows[i]["Quantity_TR"].ToString());
                }
                catch
                {
                    nCantidad_TR = 0;
                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                }
                catch
                {
                    dFecha = DateTime.Now;
                }

                try
                {
                    nid_calidad = Convert.ToInt32(dTable.Rows[i]["id_calidad"].ToString());
                }
                catch
                {
                    nid_calidad = 0;
                }

                try
                {
                    cHora = dTable.Rows[i]["hora"].ToString();
                }
                catch
                {
                    cHora = "";
                }

                if (cHora != "")
                {
                    cHora = cHora.Substring(0, 2) + ":" + cHora.Substring(2, 2);
                }

                grilla[0] = cDocEntry;
                grilla[1] = dFecha.ToString("dd/MM/yyyy") + " " + cHora;
                grilla[2] = cLote;
                grilla[3] = cItemCode;
                grilla[4] = cItemName;
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = nCantidad_TR.ToString("N2");
                grilla[8] = nid_calidad.ToString();

                Grid4.Rows.Add(grilla);

            }

        }

        private void btn_insumos_sacos_Click(object sender, EventArgs e)
        {

            if (t_ItemCode_ISaco.Text == "")
            {
                MessageBox.Show("No se ha definido un insumo de **Caja** para esta orden de fabricación, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nCant_ReciboProduccion, nCant_Definida, nCantidad;
            string cLote;
            int nLinea;

            try
            {
                nCant_ReciboProduccion = Convert.ToDouble(t_kilos.Text);
            }
            catch
            {
                nCant_ReciboProduccion = 0;
            }

            if (nCant_ReciboProduccion == 0)
            {
                MessageBox.Show("No se han registrado cantidades a procesar, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            nCant_Definida = 0;

            VariablesGlobales.glb_Array7 = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                VariablesGlobales.glb_Array7[0, i] = "";

            }

            VariablesGlobales.glb_Array1_ind = -1;

            nLinea = 0;

            for (int i = 0; i <= Grid1_Sacos.RowCount - 1; i++)
            {

                nCantidad = 0;

                try
                {
                    cLote = Grid1_Sacos[0, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(Grid1_Sacos[1, i].Value.ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                if ((nCantidad > 0) && (cLote != ""))
                {
                    VariablesGlobales.glb_Array7[0, nLinea] = cLote;
                    VariablesGlobales.glb_Array7[1, nLinea] = nCantidad.ToString();

                    nLinea += 1;

                    VariablesGlobales.glb_Array1_ind = nLinea;

                }

            }

            VariablesGlobales.glb_ItemCode = t_ItemCode_ISaco.Text;
            VariablesGlobales.glb_ItemName = t_ItemName_ISaco.Text;
            VariablesGlobales.glb_Almacen = t_warehouse_ISaco.Text;

            VariablesGlobales.glb_Cantidad = nCant_ReciboProduccion;

            //VariablesGlobales.glb_Array1 = d_arrDetalle;

            frmOrdenFabricacionTRA1 f2 = new frmOrdenFabricacionTRA1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Array1_ind >= 0)
            {

                Grid1_Cajas.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= VariablesGlobales.glb_Array1_ind; i++)
                {

                    try
                    {
                        cLote = VariablesGlobales.glb_Array7[0, i];
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        nCantidad = Convert.ToDouble(VariablesGlobales.glb_Array7[1, i]);
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    nCant_Definida += nCantidad;

                    if ((cLote != "") && (nCantidad > 0))
                    {
                        grilla[0] = cLote;
                        grilla[1] = nCantidad.ToString("N2");

                        Grid1_Sacos.Rows.Add(grilla);

                    }

                }

                if (nCant_ReciboProduccion <= nCant_Definida)
                {
                    pbox_saco_error.Visible = false;
                    pbox_saco_ok.Visible = true;

                }
                else
                {
                    pbox_saco_error.Visible = true;
                    pbox_saco_ok.Visible = false;

                }

            }

        }

        private void t_cant_bins_ncc_Leave(object sender, EventArgs e)
        {
            int nCant_bins;

            try
            {
                nCant_bins = Convert.ToInt32(t_cant_bins_ncc.Text);
                 
            }
            catch
            {
                nCant_bins = 0;

            }

            t_cant_bins_ncc.Text = nCant_bins.ToString();

        }

        private void groupBox_insumos_Enter(object sender, EventArgs e)
        {

        }
    }

}
