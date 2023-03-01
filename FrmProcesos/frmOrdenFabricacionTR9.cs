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
using System.Threading;

namespace FrmProcesos
{
    public partial class frmOrdenFabricacionTR9 : Form
    {
        public frmOrdenFabricacionTR9()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR9_Load(object sender, EventArgs e)
        {

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_turnos_parametros();

            cbb_turno.DataSource = objproducto2.cResultado;
            cbb_turno.ValueMember = "FldValue";
            cbb_turno.DisplayMember = "FldValue";

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

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_Bins_Produccion();

            cbb_bins.DataSource = objproducto1.cResultado;
            cbb_bins.ValueMember = "ItemCode";
            cbb_bins.DisplayMember = "ItemName2";

            cbb_Salida.Items.Clear();

            //clsRomana objproducto1 = new clsRomana();
            //objproducto1.cls_Consulta_lista_bins();

            //cbb_bins.DataSource = objproducto1.cResultado;
            //cbb_bins.ValueMember = "ItemCode";
            //cbb_bins.DisplayMember = "ItemName";
            cbb_bins.Text = "(Seleccione Tipo de Bins)";

            timer1.Enabled = true;

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
                        cSalida = cCodigoBarra.Substring(nSimbolo + 1, largo - (nSimbolo + 1));
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

        private void Carga_producto()
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

            if (nNumOF == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = nNumOF;

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

            if (nNumOF == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = nNumOF;

            frmSel_Productos2 f2 = new frmSel_Productos2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode.Trim() != "")
            {
                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

                Carga_producto();

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = 0;

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
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

            if (cbb_Salida.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una Salida válida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double nQuantity;
            int nCantidadBins, nLineNum;
            string cTurno;

            cTurno = "N/A";

            try
            {
                cTurno = cbb_turno.SelectedValue.ToString();

            }
            catch
            {

            }

            try
            {
                nQuantity = Convert.ToDouble(t_kilos_real.Text);
            }
            catch
            {
                nQuantity = 0;
            }

            if (nQuantity <= 0)
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

            string cItemCodeCabecera, cItemCodeDetalle;

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
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar el Termination Report", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            /////////////////////////////
            /////////////////////////////
            /////////////////////////////
            // Valido el peso de los Bins

            double nPesoMaximoBins;

            nPesoMaximoBins = 500;

            if (t_tipo_fruta.Text == "Nuez C/C")
            {
                nPesoMaximoBins = 450;
            }

            if (t_tipo_fruta.Text == "Nuez S/C")
            {
                nPesoMaximoBins = 450;
            }

            if (t_tipo_fruta.Text == "Almendra")
            {
                nPesoMaximoBins = 550;
            }

            string cSupervisor;

            cSupervisor = "NO";

            if (nQuantity > nPesoMaximoBins)
            {

                MessageBoxButtons buttons_1 = MessageBoxButtons.YesNo;

                DialogResult result_1;

                result_1 = MessageBox.Show("El Peso del Bins Excede el promedio máximo posible, requiere autorización de supervisor, está Seguro de continuar", "Termination Report ", buttons_1);

                if (result_1 == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                cSupervisor = "NO";

                VariablesGlobales.glb_User_Code_Autorizacion = "";

                frmLoginSupervisor f5 = new frmLoginSupervisor();
                DialogResult res5 = f5.ShowDialog();

                if (VariablesGlobales.glb_User_Code_Autorizacion != "")
                {

                    clsMaestros objproducto1 = new clsMaestros();
                    objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto1.cResultado;

                    try
                    {
                        cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                    }
                    catch
                    {
                        cSupervisor = "NO";

                    }

                }

                if (cSupervisor == "NO")
                {
                    return;
                }


            }

            double nPesoAnteriorBins;

            clsProduccion objproducto3 = new clsProduccion();

            objproducto3.cls_Consulta_Ultimo_Peso_Productivo(nDocNum, t_itemcode.Text);

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto3.cResultado;

            nPesoAnteriorBins = 0;

            try
            {
                nPesoAnteriorBins = double.Parse(dTable3.Rows[0]["Quantity"].ToString());
            }
            catch
            {
                nPesoAnteriorBins = 0;
            }

            if (nPesoAnteriorBins > 0)
            {
                if (nPesoAnteriorBins == nQuantity)
                {
                    MessageBoxButtons buttons_2 = MessageBoxButtons.YesNo;

                    DialogResult result_2;

                    result_2 = MessageBox.Show("El Peso del Bins es identico al anterior, requiere autorización de supervisor, está Seguro de continuar", "Termination Report ", buttons_2);

                    if (result_2 == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    cSupervisor = "NO";

                    VariablesGlobales.glb_User_Code_Autorizacion = "";

                    frmLoginSupervisor f6 = new frmLoginSupervisor();
                    DialogResult res6 = f6.ShowDialog();

                    if (VariablesGlobales.glb_User_Code_Autorizacion != "")
                    {

                        clsMaestros objproducto2 = new clsMaestros();
                        objproducto2.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                        DataTable dTable2 = new DataTable();
                        dTable2 = objproducto2.cResultado;

                        try
                        {
                            cSupervisor = dTable2.Rows[0]["Supervisor"].ToString();

                        }
                        catch
                        {
                            cSupervisor = "NO";

                        }

                    }

                    if (cSupervisor == "NO")
                    {
                        return;
                    }

                }

            }

            /////////////////////////////
            /////////////////////////////
            /////////////////////////////
            // Continuo con el proceso 
            // de grabación

            /////////////////////////////////////////////////////
            // Levanto el Splash para que el usuario espeeeeeeere

            timer1.Enabled = false;

            Splash sp = new Splash();
            sp.ShowDialog();

            /////////////////////////////////////////////////////

            string cDocDate;

            DateTime dFecha;

            dFecha = DateTime.Parse("01/01/1900");

            clsMaestros objproducto5 = new clsMaestros();
            objproducto5.cls_lee_fecha_servidor();

            DataTable dTable5 = new DataTable();
            dTable5 = objproducto5.cResultado;

            try
            {
                dFecha = Convert.ToDateTime(dTable5.Rows[0]["fecha"].ToString());

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

            t_mensaje.Visible = true;
            Application.DoEvents();
            btn_crea_recibo.Enabled = false;


            t_mensaje.Text = "Proceso: (1) Carga Variedad Producto";
            Application.DoEvents();

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

            timer1.Enabled = false;
            lbl_peso_final.Text = nQuantity.ToString("N2");

            //////////////////////////////////////
            // Genero el avance de proceso

            t_mensaje.Text = "Proceso: (2) Genera Entrada TR // SAP";
            Application.DoEvents();

            String mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo,"", cTurno);

            if (mensaje == "Error de Conexión")
            {
                Thread.Sleep(500);
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

            t_mensaje.Text = "Proceso: (3) Corrigo AbsEntry // SAP";
            Application.DoEvents();

            mensaje = clsRecepcion.SAPB1_RECEPCION3(nTerminationReportEntry, 59);

            //////////////////////////////////////

            MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btn_crea_recibo.Enabled = false;

            btn_agrega_pallet.Enabled = true;
            btn_agrega_pallet_existente.Enabled = true;

            //btn_imprimir.Enabled = true;

            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////
            //////////////////////////////////////

            string cLote;
            int nParametrosCalidad;

            t_mensaje.Text = "Proceso: (4) Consulto datos de entrada";
            Application.DoEvents();

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

            //////////////////////////////////////
            //////////////////////////////////////
            // Dejo el lote como acceso denegado

            if (t_itemcode.Text.Substring(7, 2) == "PT")
            {
                mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(cLote), "A", UsuarioSap, ClaveSap);

            }

            t_mensaje.Visible = false;
            Application.DoEvents();

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

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            ///////////////////////////////////////////
            ///////////////////////////////////////////

            //t_PesoBalanza.Text = "10030";
            //return;

            t_balanza.BackColor = Color.Red;
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;

            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0;

            //int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;
            int nErr = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "COM1";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 1200;
            }

            //try
            //{
            //    //nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            //}
            //catch
            //{
            //    nBalanza_BitsDatos = 0;
            //}

            SerialPort mySerialPort = new SerialPort(cBalanza_Puerto);

            mySerialPort.BaudRate = nBalanza_Baudios;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            try
            {
                mySerialPort.Open();
                nErr = 0;
            }
            catch
            {
                nErr = 1;
            }

            if (nErr == 1)
            {
                try
                {
                    mySerialPort.Close();
                }
                catch
                {

                }

                t_kilos.Text = "E_";
                t_balanza.BackColor = Color.Empty;

                //Thread.Sleep(300);
                timer1.Enabled = true;
                return;

            }

            string b, cPack, cNumero;
            double nPeso;

            try
            {
                while (true)
                {

                    cPack = "";
                    nPeso = 0;
                    b = "";

                    try
                    {
                        b = mySerialPort.ReadExisting();
                    }
                    catch
                    {
                        b = "";
                    }

                    //try
                    //{
                    //    cPack = b.Substring(2, 1);
                    //}
                    //catch
                    //{
                    //    cPack = "";
                    //}

                    //if (cPack == "0")
                    //{
                    //    try
                    //    {
                    //        cNumero = b.Substring(2, 6);
                    //    }
                    //    catch
                    //    {
                    //        cNumero = "0";
                    //    }

                    //    nPeso = int.Parse(cNumero);

                    //}
                    //else
                    //{
                    //}
                    //VariablesGlobales.glb_SeparadorMiles = cSeparadorMiles;

                    cPack = b;

                    if (VariablesGlobales.glb_SimboloDecimal != ".")
                    {
                        try
                        {
                            cPack = b.Replace(".", ",");
                        }
                        catch
                        {
                            cPack = b;
                        }

                    }

                    try
                    {
                        nPeso = double.Parse(cPack);
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    grilla[0] = i.ToString();
                    grilla[1] = cPack;
                    grilla[2] = nPeso.ToString();

                    Grid_Peso.Rows.Add(grilla);

                    Thread.Sleep(30);
                    i += 1;

                    if (i > 12)
                    {
                        break;
                    }

                }
            }
            catch
            {

            }

            try
            {
                //serialPort.DiscardInBuffer();
                mySerialPort.Close();
            }
            catch
            {

            }

            double nPesoBalanza;
            double nPesoFinal;
            
            nPesoBalanza = 0;
            nPesoFinal = 0;
            cNumero = "";

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    cNumero = Grid_Peso[2, j].Value.ToString();
                }
                catch
                {
                    cNumero = "";
                }

                try
                {
                    nPesoBalanza = double.Parse(cNumero);
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = Math.Round(nPesoBalanza,1);
                }

            }

            t_kilos.Text = nPesoFinal.ToString("N2");

            double nTaraBins;
            int nTipoBins;
            string cItemCodeBins;

            try
            {
                nTipoBins = cbb_bins.SelectedIndex;
            }
            catch
            {
                nTipoBins = -1;
            }
                
            nTaraBins = 0;

            // ******************************
            // Lista nueva
            //

            cItemCodeBins = "";

            try
            {
                cItemCodeBins = cbb_bins.SelectedValue.ToString();
            }
            catch
            {
                cItemCodeBins = "";
            }

            if (cItemCodeBins != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_Consultar_Bins_Produccion2(cItemCodeBins);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;

                try
                {
                    nTaraBins = Convert.ToDouble(dTable.Rows[0]["BWeight1"].ToString());
                }
                catch
                {
                    nTaraBins = -1;
                }

            }

            t_kilos.Text = nPesoFinal.ToString();
            t_kilos_real.Text = "0";

            if (nTaraBins > 0)
            {
                t_kilos_real.Text = (nPesoFinal - nTaraBins).ToString();
            }

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza.BackColor = Color.Empty;
            timer1.Enabled = true;

        }

        private void frmOrdenFabricacionTR9_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;

        }

        private void cbb_bins_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_Salida_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((t_tipo_fruta.Text == "Almendra") || (t_DocNum.Text != ""))
            {
                if (t_itemcode.Text == "")
                {
                    string cSalida;

                    try
                    {
                        cSalida = (cbb_Salida.SelectedIndex + 1).ToString();

                    }
                    catch
                    {
                        cSalida = "";

                    }

                    if (cSalida =="8")
                    {

                        int nDocNum;
                        string cItem_Code_D, cItemName_D;

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

                        for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                        {
                            cItem_Code_D = "";
                            cItemName_D = "";

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
                                cItemName_D = dTable.Rows[i]["ItemName_D"].ToString();

                            }
                            catch
                            {
                                cItemName_D = "";
                            }


                            if ((cItem_Code_D == "FP.ALM.SE.CRA1.PIE.X.XXX-XXX.XXX.G.0001K.01") || (cItem_Code_D == "FS.ALM.SE.CRA1.PIE.X.XXX-XXX.XXX.G.0001K.01"))
                            {

                                t_itemcode.Text = cItem_Code_D;
                                t_itemname.Text = cItemName_D;

                                Carga_producto();

                                cbb_bins.Focus();

                            }

                        }

                    }

                }

            }

        }

    }

}
