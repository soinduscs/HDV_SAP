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
    public partial class frmOrdenFabricacion : Form
    {
        public frmOrdenFabricacion()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion_Load(object sender, EventArgs e)
        {

            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_itemname.Text = VariablesGlobales.glb_ItemName;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.cls_ConsultaLista_Usuarios();

            cbb_usersign.DataSource = objproducto2.cResultado;
            cbb_usersign.ValueMember = "USERID";
            cbb_usersign.DisplayMember = "U_NAME";

            try
            {
                cbb_usersign.SelectedValue = VariablesGlobales.glb_User_id;
            }
            catch
            {

            }

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_ConsultaLista_Almacenes();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto1.cResultado;
            my_DGVCboColumn.Name = "Almacén";
            my_DGVCboColumn.ValueMember = "WhsCode";
            my_DGVCboColumn.DisplayMember = "WhsCode";

            Grid1.Columns.RemoveAt(9);
            Grid1.Columns.Insert(9, my_DGVCboColumn);
            Grid1.Columns[9].Width = 80;

            clsOrdenFabricacion objproducto3 = new clsOrdenFabricacion();
            objproducto3.cls_Consultar_Lita_UProcesos(8);

            cbb_u_proceso.DataSource = objproducto3.cResultado;
            cbb_u_proceso.ValueMember = "FldValue";
            cbb_u_proceso.DisplayMember = "FldValue";

            clsOrdenFabricacion objproducto4 = new clsOrdenFabricacion();
            objproducto4.cls_Consultar_Lita_UProcesos(10);

            cbb_u_tipoorden.DataSource = objproducto4.cResultado;
            cbb_u_tipoorden.ValueMember = "FldValue";
            cbb_u_tipoorden.DisplayMember = "FldValue";

            clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
            objproducto5.cls_Consultar_Lita_UProcesos(11);

            cbb_u_tipofruta.DataSource = objproducto5.cResultado;
            cbb_u_tipofruta.ValueMember = "FldValue";
            cbb_u_tipofruta.DisplayMember = "FldValue";

            clsOrdenFabricacion objproducto6 = new clsOrdenFabricacion();
            objproducto6.cls_Consultar_Lita_UProcesos(14);

            cbb_env_cajas.DataSource = objproducto6.cResultado;
            cbb_env_cajas.ValueMember = "FldValue";
            cbb_env_cajas.DisplayMember = "FldValue";

            clsOrdenFabricacion objproducto7 = new clsOrdenFabricacion();
            objproducto7.cls_Consultar_Lita_UProcesos(15);

            cbb_env_pallet.DataSource = objproducto7.cResultado;
            cbb_env_pallet.ValueMember = "FldValue";
            cbb_env_pallet.DisplayMember = "FldValue";

            clsOrdenFabricacion objproducto8 = new clsOrdenFabricacion();
            objproducto8.cls_Consultar_Lita_UProcesos(15);

            cbb_env_cantidad.DataSource = objproducto8.cResultado;
            cbb_env_cantidad.ValueMember = "FldValue";
            cbb_env_cantidad.DisplayMember = "FldValue";
        
            nueva_orden();

            int nDocEntry, nDocEntry_new;
            int nDocEntryReceta;
            string cItemCode;

            try
            {
                nDocEntry_new = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocEntry_new = 0;
            }

            try
            {
                nDocEntry = VariablesGlobales.glb_DocEntry;
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                nDocEntryReceta = VariablesGlobales.glb_Receta;
            }
            catch
            {
                nDocEntryReceta = 0;
            }

            VariablesGlobales.glb_Receta = 0;

            try
            {
                cItemCode = VariablesGlobales.glb_ItemCode;
            }
            catch
            {
                cItemCode = "";
            }

            if (nDocEntryReceta > 0)
            {
                nDocEntry = nDocEntryReceta;
            }

            if (nDocEntry>0)
            {
                if (cItemCode != "")
                {
                    t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                    t_itemname.Text = VariablesGlobales.glb_ItemName;

                    if  (nDocEntryReceta > 0)
                    {
                        ///////////////////////////
                        // Este es una receta nueva

                        carga_recetas_desde_repositorio(nDocEntry);

                    }
                    else
                    {
                        ///////////////////////////
                        // cargo la OF 

                        Grid1.Rows.Clear();

                        t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                        carga_orden_fabricacion();

                        if (t_itemname.Text != "")
                        {
                            btn_crear.Enabled = false;
                            btn_genera_solicitud.Enabled = true;

                        }

                    }

                }

            }

        }

        private void itmes_grilla()
        {

            int nLineId = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = i + 1;

                Grid1[0, i].Value = nLineId.ToString();

            }

        }

        private void tsb_agrega_productor_Click(object sender, EventArgs e)
        {

            string cToWhs = "";
            string cUM = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos f2 = new frmSel_Productos();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode.Trim() != "")
            {

                double nDisponible;

                clsProductos objproducto1 = new clsProductos();
                objproducto1.cls_consultar_Producto_x_codigo_stock(VariablesGlobales.glb_ItemCode, cToWhs);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;

                try
                {
                    cUM = dTable.Rows[0]["InvntryUom"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                try
                {
                    nDisponible = Convert.ToDouble(dTable.Rows[0]["OnOrder"].ToString());
                }
                catch
                {
                    nDisponible = 0;
                }

                string[] grilla;
                grilla = new string[30];

                grilla[0] = 0.ToString();
                grilla[1] = "Artículo";
                grilla[2] = VariablesGlobales.glb_ItemCode;
                grilla[3] = VariablesGlobales.glb_ItemName;
                grilla[4] = 0.ToString("N2");
                grilla[5] = 0.ToString("N2");
                grilla[6] = 0.ToString("N2");
                grilla[7] = nDisponible.ToString("N2");
                grilla[8] = cUM;
                grilla[9] = cToWhs;
                grilla[10] = "";
                grilla[11] = 0.ToString();

                Grid1.Rows.Add(grilla);

            }

            itmes_grilla();

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una orden de fabricacion valida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("No Existen registros a eliminar, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Orden de fabricacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

            itmes_grilla();

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_ListaMateriales f2 = new frmSel_ListaMateriales();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode != "")
            {
                Grid1.Rows.Clear();

                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

                carga_recetas_sap();

            }

        }

        private void t_DocNum_Leave(object sender, EventArgs e)
        {

            int nDocNum;

            try
            {
                nDocNum = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            t_DocNum.Text = nDocNum.ToString();

            carga_orden_fabricacion();

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

            string cUserSign, cType, cStatus;
            string cAlmacen, cU_Proceso, cU_TipoFruta;
            string cU_TipoOrden;

            double nPlannedQty;

            DateTime dFecha;

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

            if (nDocEntry == nDocNum)
            {
                t_itemcode.ReadOnly = true;
            }
            else
            {
                t_itemcode.ReadOnly = false;
                return;
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
                dFecha = Convert.ToDateTime(dTable.Rows[0]["PostDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            dtp_postdate.Value = dFecha;

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["StartDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            dtp_startdate.Value = dFecha;

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["DueDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            dtp_duedate.Value = dFecha;

            try
            {
                cUserSign = dTable.Rows[0]["UserSign"].ToString();
            }
            catch
            {
                cUserSign = "";
            }

            try
            {
                cbb_usersign.SelectedValue = cUserSign;
            }
            catch
            {
                cbb_usersign.Text = "(Seleccione Usuario)";
            }

            cType = "";

            try
            {
                cType = dTable.Rows[0]["Type"].ToString();
            }
            catch
            {
                cType = "";

            }

            //0. Especial
            //1. Estandar
            //2. Desmontar

            switch (cType)
            {
                case "P":
                    cbb_type.SelectedIndex = 0;
                    break;

                case "S":
                    cbb_type.SelectedIndex = 1;
                    break;

                case "D":
                    cbb_type.SelectedIndex = 2;
                    break;

                default:
                    cbb_type.SelectedIndex = 1;
                    break;

            }

            cStatus = "";

            try
            {
                cStatus = dTable.Rows[0]["Status"].ToString();
            }
            catch
            {
                cStatus = "";

            }

            //0. Planif.
            //1. Liberada

            switch (cStatus)
            {
                case "P":
                    cbb_status.SelectedIndex = 0;
                    break;

                case "R":
                    cbb_status.SelectedIndex = 1;
                    break;

                case "C":
                    cbb_status.Text = "Cerrado";
                    break;

                case "L":
                    cbb_status.Text = "Cerrado";
                    break;

                default:
                    cbb_status.SelectedIndex = 0;
                    break;

            }

            try
            {
                cAlmacen = dTable.Rows[0]["Warehouse"].ToString();
            }
            catch
            {
                cAlmacen = "";

            }

            try
            {
                cbb_almacen.SelectedValue = cAlmacen;
            }
            catch
            {

            }

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
                t_OriginNum.Text = dTable.Rows[0]["OriginNum"].ToString();
            }
            catch
            {
                t_OriginNum.Clear();
            }

            try
            {
                t_CardCode.Text = dTable.Rows[0]["CardCode"].ToString();
            }
            catch
            {
                t_CardCode.Clear();
            }

            try
            {
                t_CardCode_productor.Text = dTable.Rows[0]["CardCode_Productor"].ToString();
            }
            catch
            {
                t_CardCode_productor.Clear();
            }

            try
            {
                t_Project.Text = dTable.Rows[0]["Project"].ToString();
            }
            catch
            {
                t_Project.Clear();
            }

            try
            {
                t_Comments.Text = dTable.Rows[0]["Comments"].ToString();
            }
            catch
            {
                t_Comments.Clear();
            }

            try
            {
                t_u_ordenafecta.Text = dTable.Rows[0]["U_OrdenAfecta"].ToString();
            }
            catch
            {
                t_u_ordenafecta.Clear();
            }

            try
            {
                cU_Proceso = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                cU_Proceso = "";
            }

            try
            {
                cbb_u_proceso.SelectedValue = cU_Proceso;
            }
            catch
            {

            }

            try
            {
                cbb_env_cajas.SelectedValue = dTable.Rows[0]["Env_Caja"].ToString();
            }
            catch
            {
                cbb_env_cajas.SelectedValue = "";
            }

            try
            {
                cbb_env_pallet.SelectedValue = dTable.Rows[0]["Env_Pallet"].ToString();
            }
            catch
            {
                cbb_env_pallet.SelectedValue = "";
            }

            try
            {
                cbb_env_cantidad.SelectedValue = dTable.Rows[0]["Env_Cantidad"].ToString();
            }
            catch
            {
                cbb_env_cantidad.SelectedValue = "";
            }

            try
            {
                cU_TipoOrden = dTable.Rows[0]["U_TipoOrden"].ToString();
            }
            catch
            {
                cU_TipoOrden = "";
            }

            try
            {
                cbb_u_tipoorden.SelectedValue = cU_TipoOrden;
            }
            catch
            {

            }

            try
            {
                cU_TipoFruta = dTable.Rows[0]["U_TipoFruta"].ToString();
            }
            catch
            {
                cU_TipoFruta = "";
            }

            try
            {
                cbb_u_tipofruta.SelectedValue = cU_TipoFruta;
            }
            catch
            {

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega;
            double nCantidadBase, nCantidadRequerida, nConsumido;
            double nDisponible;

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
                    nCantidadBase = Convert.ToDouble(dTable.Rows[i]["BaseQty"].ToString());
                }
                catch
                {
                    nCantidadBase = 0;
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
                    nConsumido = Convert.ToDouble(dTable.Rows[i]["IssuedQty"].ToString());
                }
                catch
                {
                    nConsumido = 0;
                }

                try
                {
                    nDisponible = Convert.ToDouble(dTable.Rows[i]["OnOrder_D"].ToString());
                }
                catch
                {
                    nDisponible = 0;
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
                grilla[4] = nCantidadBase.ToString("N2");
                grilla[5] = nCantidadRequerida.ToString("N2");
                grilla[6] = nConsumido.ToString("N2");
                grilla[7] = nDisponible.ToString("N2");
                grilla[8] = cUM;
                grilla[9] = cBodega;
                grilla[10] = "";
                grilla[11] = nCantidadBase.ToString();

                Grid1.Rows.Add(grilla);

            }

            itmes_grilla();

            if (Grid1.Rows.Count >0)
            {
                btn_crear.Enabled = false;

            }

            if (t_itemname.Text != "")
            {
                btn_crear.Enabled = false;
                btn_genera_solicitud.Enabled = true;

                tsb_agrega_productor.Enabled = false;
                tsb_eliminar.Enabled = false;

            }

            if (cStatus == "C" || cStatus == "L")
            {
                deshabilita_textos();

                if (cbb_status.Text == "Cerrado")
                {
                    btn_genera_solicitud.Enabled = false;
                    //btn_resumen.Enabled = true;

                }


            }


        }


        private void deshabilita_textos()
        {
            cbb_type.Enabled = false;
            cbb_status.Enabled = false;
            cbb_almacen.Enabled = false;
            cbb_usersign.Enabled = false;
            cbb_u_proceso.Enabled = false;
            cbb_u_tipofruta.Enabled = false;
            cbb_u_tipoorden.Enabled = false;
            cbb_env_cajas.Enabled = false;
            cbb_env_cantidad.Enabled = false;
            cbb_env_pallet.Enabled = false;

            t_itemcode.ReadOnly = true;
            t_itemname.ReadOnly = true;
            t_PlannedQty.ReadOnly = true;
            t_DocNum.ReadOnly = true;
            t_u_ordenafecta.ReadOnly = true;
            t_Comments.ReadOnly = true;

            dtp_duedate.Enabled = false;
            dtp_postdate.Enabled = false;
            dtp_startdate.Enabled = false;

            btn_buscar1.Visible = false;
            btn_buscar_pedido.Visible = false;
            btn_buscar_cliente.Visible = false;
            btn_buscar1_norma.Visible = false;
            btn_buscar1_proyecto.Visible = false;

            tsb_agrega_productor.Enabled = false;
            tsb_eliminar.Enabled = false;

            btn_crear.Enabled = false;

            deshabilita_grilla();

        }

        private void deshabilita_grilla()
        {

            Grid1.Columns[4].ReadOnly = true;
            Grid1.Columns[9].ReadOnly = true;

        }

        private void habilita_textos()
        {
            cbb_type.Enabled = true;
            cbb_status.Enabled = true;
            cbb_almacen.Enabled = true;
            cbb_usersign.Enabled = true;
            cbb_u_proceso.Enabled = true;
            cbb_u_tipofruta.Enabled = true;
            cbb_u_tipoorden.Enabled = true;
            cbb_env_cajas.Enabled = true;
            cbb_env_cantidad.Enabled = true;
            cbb_env_pallet.Enabled = true;

            t_itemcode.ReadOnly = false;
            t_itemname.ReadOnly = false;
            t_PlannedQty.ReadOnly = false;
            t_DocNum.ReadOnly = false;
            t_u_ordenafecta.ReadOnly = false;
            t_Comments.ReadOnly = false;

            dtp_duedate.Enabled = true;
            dtp_postdate.Enabled = true;
            dtp_startdate.Enabled = true;

            btn_buscar1.Visible = true;
            btn_buscar_pedido.Visible = true;
            btn_buscar_cliente.Visible = true;
            btn_buscar1_norma.Visible = true;
            btn_buscar1_proyecto.Visible = true;

            tsb_agrega_productor.Enabled = true;
            tsb_eliminar.Enabled = true;

            btn_crear.Enabled = true;

            habilita_grilla();

        }

        private void habilita_grilla()
        {

            Grid1.Columns[4].ReadOnly = false;
            Grid1.Columns[9].ReadOnly = false;

        }

        private void t_PlannedQty_Leave(object sender, EventArgs e)
        {

            double nCantidadPlanificada, nCantidadBase, nCantidadRequerida;
            string cItemCode;

            try
            {
                nCantidadPlanificada = Convert.ToDouble(t_PlannedQty.Text);
            }
            catch
            {
                nCantidadPlanificada = 0;
            }

            t_PlannedQty.Text = nCantidadPlanificada.ToString("N2");

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
                    nCantidadBase = Convert.ToDouble(Grid1[11, i].Value.ToString());
                }
                catch
                {
                    nCantidadBase = 0;
                }

                nCantidadRequerida = nCantidadPlanificada * nCantidadBase;

                Grid1[5, i].Value = nCantidadRequerida.ToString("N2");

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_crear_Click(object sender, EventArgs e)
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

            if (nDocNum > 0)
            {
                int nDocNum_x;

                nDocNum_x = 0;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_OrdenFabricacion_x_DocNum(nDocNum);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    nDocNum_x = int.Parse(dTable.Rows[0]["DocNum"].ToString());
                }
                catch
                {
                    nDocNum_x = 0;
                }

                if (nDocNum_x == nDocNum)
                {
                    MessageBox.Show("La Orden de Fabricación Ya fue creada, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Orden de Fabricación", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cItemCode, cItemName, cUM;
            string cPostDate, cStartDate, cDueDate;

            cItemCode = t_itemcode.Text;
            cItemName = t_itemname.Text;
            cUM = t_um.Text;

            DateTime dFecha;

            try
            {
                dFecha = dtp_postdate.Value;
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cPostDate = dFecha.ToString("yyyyMMdd");

            try
            {
                dFecha = dtp_startdate.Value;
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cStartDate = dFecha.ToString("yyyyMMdd");

            try
            {
                dFecha = dtp_duedate.Value;
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDueDate = dFecha.ToString("yyyyMMdd");

            string cUserSign, cType, cStatus;
            string cAlmacen, cU_Proceso, cU_TipoFruta;
            string cU_TipoOrden;

            double nPlannedQty;

            try
            {
                cUserSign = cbb_usersign.SelectedValue.ToString();
            }
            catch
            {
                cUserSign = "";
            }

            if (cUserSign == "")
            {
                MessageBox.Show("Debe seleccionar un usuario válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //0. [P] Especial
            //1. [S] Estandar
            //2. [D] Desmontar

            cType = "";

            switch (cbb_type.SelectedIndex)
            {
                case 0:
                    cType = "P";
                    break;
                case 1:
                    cType = "S";
                    break;
                case 2:
                    cType = "D";
                    break;
                default:
                    cType = "";
                    break;
            }

            if (cType == "")
            {
                MessageBox.Show("Debe seleccionar un tipo válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            switch (cType)
            {
                case "P":
                    cbb_type.SelectedIndex = 0;
                    break;

                case "S":
                    cbb_type.SelectedIndex = 1;
                    break;

                case "D":
                    cbb_type.SelectedIndex = 2;
                    break;

                default:
                    cbb_type.SelectedIndex = 1;
                    break;

            }

            //0. [P] Planif.
            //1. [R] Liberada

            cStatus = "";

            switch (cbb_status.SelectedIndex)
            {
                case 0:
                    cStatus = "P";
                    break;
                case 1:
                    cStatus = "R";
                    break;
                default:
                    cStatus = "";
                    break;
            }

            if (cStatus == "")
            {
                MessageBox.Show("Debe seleccionar un estado válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MessageBox.Show("Debe seleccionar un almacen válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nPlannedQty = Convert.ToDouble(t_PlannedQty.Text);
            }
            catch
            {
                nPlannedQty = 0;
            }

            if (nPlannedQty == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad planificada válida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cOriginNum, cCardCode, cProject;
            string cComments, cU_ordenafecta;

            try
            {
                cOriginNum = t_OriginNum.Text;
            }
            catch
            {
                cOriginNum = "";
            }

            try
            {
                cCardCode = t_CardCode.Text;
            }
            catch
            {
                cCardCode = "";
            }

            try
            {
                cProject = t_Project.Text;
            }
            catch
            {
                cProject = "";
            }

            try
            {
                cComments = t_Comments.Text;
            }
            catch
            {
                cComments = "";
            }

            try
            {
                cU_ordenafecta = t_u_ordenafecta.Text;
            }
            catch
            {
                cU_ordenafecta = "";
            }

            if (cU_ordenafecta == "")
            {
                MessageBox.Show("Debe ingresar una orden afecta válida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cU_Proceso = cbb_u_proceso.SelectedValue.ToString();
            }
            catch
            {
                cU_Proceso = "";
            }

            if (cU_Proceso == "")
            {
                MessageBox.Show("Debe seleccionar un proceso válida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cU_TipoOrden = cbb_u_tipoorden.SelectedValue.ToString();
            }
            catch
            {
                cU_TipoOrden = "";
            }

            if (cU_TipoOrden == "")
            {
                MessageBox.Show("Debe seleccionar un tipo de orden válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cU_TipoFruta = cbb_u_tipofruta.SelectedValue.ToString();
            }
            catch
            {
                cU_TipoFruta = "";
            }

            if (cU_TipoFruta == "")
            {
                MessageBox.Show("Debe seleccionar un tipo de fruta válida, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////////////////////////////////////////////////////////

            int DocEnytr_OrdendeVenta;

            try
            {
                DocEnytr_OrdendeVenta = int.Parse(cOriginNum);
            }
            catch
            {
                DocEnytr_OrdendeVenta = 0;
            }

            //DocEnytr_OrdendeVenta = 22;

            if (DocEnytr_OrdendeVenta > 0)
            {

                clsMaestros objproducto5 = new clsMaestros();
                objproducto5.cls_Consultar_Ordenes_de_venta_x_DocNum(DocEnytr_OrdendeVenta);

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

                try
                {
                    DocEnytr_OrdendeVenta = int.Parse(dTable5.Rows[0]["DocEntry"].ToString());
                }
                catch
                {
                    DocEnytr_OrdendeVenta = 0;
                }
                
            }
            else
            {
                DocEnytr_OrdendeVenta = 0;
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

            string cItemCode_D, cItemName_D, cUM_D;
            string cBodega_D, cIssueMthd_D;

            double nCantidadBase_D, nCantidadRequerida_D, nConsumido_D;
            double nDisponible_D;

            int nLineId_D, j;

            j = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId_D = 0;

                try
                {
                    nLineId_D = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = Grid1[3, i].Value.ToString();
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    cUM_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cUM_D = "";
                }

                try
                {
                    cBodega_D = Grid1[9, i].Value.ToString();
                }
                catch
                {
                    cBodega_D = "";
                }

                try
                {
                    nCantidadBase_D = Convert.ToDouble(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nCantidadBase_D = -1;
                }

                try
                {
                    nCantidadRequerida_D = Convert.ToDouble(Grid1[5, i].Value.ToString());
                }
                catch
                {
                    nCantidadRequerida_D = -1;
                }

                try
                {
                    nConsumido_D = Convert.ToDouble(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nConsumido_D = -1;
                }

                try
                {
                    nDisponible_D = Convert.ToDouble(Grid1[7, i].Value.ToString());
                }
                catch
                {
                    nDisponible_D = -1;
                }

                try
                {
                    cIssueMthd_D = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cIssueMthd_D = "M";
                }

                d_arrDetalle[1, j] = nLineId_D.ToString();
                d_arrDetalle[2, j] = cItemCode_D;
                d_arrDetalle[3, j] = cItemName_D;
                d_arrDetalle[4, j] = nCantidadBase_D.ToString();
                d_arrDetalle[5, j] = nCantidadRequerida_D.ToString();
                d_arrDetalle[6, j] = cBodega_D;
                d_arrDetalle[7, j] = nDisponible_D.ToString();
                d_arrDetalle[8, j] = cIssueMthd_D;

                j += 1;

            }

            //////////////////////////////////
            //////////////////////////////////
            // Validación de arbol de sistema

            int nDocEntry_Arbol;
            string cItemCode_Father, cItemCode_Son;

            nDocEntry_Arbol = 0;
            cItemCode_Father = ""; cItemCode_Son = "";

            try
            {
                cItemCode_Father = t_itemcode.Text;
            }
            catch
            {
                cItemCode_Father = "";
            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                
                try
                {
                    cItemCode_D = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                if (cItemCode_D != "")
                {
                    cItemCode_Son = cItemCode_D;

                    clsMaestros objproducto9 = new clsMaestros();
                    objproducto9.cls_Consultar_Arbol_Integridad_Orden_Facturacion(cItemCode_Father, cItemCode_D);

                    DataTable dTable9 = new DataTable();
                    dTable9 = objproducto9.cResultado;

                    try
                    {
                        nDocEntry_Arbol = int.Parse(dTable9.Rows[0]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Arbol = 0;
                    }

                    if (nDocEntry_Arbol > 0)
                    {
                        MessageBox.Show("Existe un Problema de Referencia entre los productos (Materia Prima - Producto Terminado) con la Orden: " + nDocEntry_Arbol.ToString() + ", opción cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            int nOrdenFabricacionEntry;

            nOrdenFabricacionEntry = 0;

            String mensaje = clsOrdenFabricacion.Production_Orders(nDocNum, nDocNum, cPostDate, cStartDate, cDueDate, cItemCode, cItemName, cUM, int.Parse(cUserSign), cAlmacen, nPlannedQty, DocEnytr_OrdendeVenta, cCardCode, cProject, cComments, cStatus, cType, cU_Proceso, cU_ordenafecta, cU_TipoOrden, cU_TipoFruta, d_arrDetalle, UsuarioSap, ClaveSap);

            try
            {
                nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Orden generada exitosamente", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_crear.Enabled = false;
                btn_genera_solicitud.Enabled = true;

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

        private void btn_buscar_cliente_Click(object sender, EventArgs e)
        {
            t_CardCode.Clear();

            VariablesGlobales.glb_CardCode = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_CardCode.Text = VariablesGlobales.glb_CardCode.Trim();

            }


        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, col;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                col = Grid1.CurrentCell.ColumnIndex;
            }
            catch
            {
                col = -1;
            }

            string cItemCode;
            double nCantidadBase, nCantidadPlanificada, nCantidadRequerida;

            try
            {
                cItemCode = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }


            try
            {
                nCantidadPlanificada = Convert.ToDouble(t_PlannedQty.Text);
            }
            catch
            {
                nCantidadPlanificada = 0;
            }

            if (col == 4)
            {
                try
                {
                    nCantidadBase = Convert.ToDouble(Grid1[4, fila].Value.ToString());
                }
                catch
                {
                    nCantidadBase = 0;
                }

                Grid1[4, fila].Value = nCantidadBase.ToString("N2");
                Grid1[11, fila].Value = nCantidadBase.ToString();

            }

            if (col == 5)
            {
                try
                {
                    nCantidadRequerida = Convert.ToDouble(Grid1[5, fila].Value.ToString());
                }
                catch
                {
                    nCantidadRequerida = 0;
                }


                try
                {
                    nCantidadBase = nCantidadRequerida / nCantidadPlanificada;

                }
                catch
                {
                    nCantidadBase = 0;

                }

                Grid1[4, fila].Value = nCantidadBase.ToString("N2");
                Grid1[11, fila].Value = nCantidadBase.ToString();

            }


            try
            {
                nCantidadBase = Convert.ToDouble(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nCantidadBase = 0;
            }

            try
            {
                nCantidadRequerida = nCantidadPlanificada * nCantidadBase;

            }
            catch
            {
                nCantidadRequerida = 0;

            }

            Grid1[5, fila].Value = nCantidadRequerida.ToString("N2");

        }

        private void carga_recetas_sap()
        {

            if (t_itemname.Text == "")
            {
                return;
            }

            string cAlmacen;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales_SAP(t_itemcode.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_PlannedQty.Text = 1.ToString("N2"); // Convert.ToDouble(dTable.Rows[0]["Quantity"].ToString()).ToString("N2");
            }
            catch
            {
                t_PlannedQty.Clear();
            }

            try
            {
                cAlmacen = dTable.Rows[0]["ToWH"].ToString();
            }
            catch
            {
                cAlmacen = "";
            }

            try
            {
                cbb_almacen.SelectedValue = cAlmacen;
            }
            catch
            {

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega, cIssueMthd;
            double nCantidad, nConsumido, nDisponible;
            double nCantidadPlanificada, nCantidadRequerida;

            try
            {
                nCantidadPlanificada = Convert.ToDouble(t_PlannedQty.Text);
            }
            catch
            {
                nCantidadPlanificada = 0;
            }

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["ChildNum"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cItemCode = dTable.Rows[i]["Code"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["CodeName"].ToString();
                }
                catch
                {
                    cItemName = "";

                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity_D"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                nCantidadRequerida = nCantidad * nCantidadPlanificada;

                try
                {
                    nConsumido = 0;
                }
                catch
                {
                    nConsumido = 0;
                }

                try
                {
                    nDisponible = Convert.ToDouble(dTable.Rows[i]["OnOrder_D"].ToString());
                }
                catch
                {
                    nDisponible = 0;
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
                    cBodega = dTable.Rows[i]["Warehouse"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cIssueMthd = dTable.Rows[i]["IssueMthd"].ToString();
                }
                catch
                {
                    cIssueMthd = "M";
                }

                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidad.ToString("N2");
                grilla[5] = nCantidadRequerida.ToString("N2");
                grilla[6] = nConsumido.ToString("N2");
                grilla[7] = nDisponible.ToString("N2");
                grilla[8] = cUM;
                grilla[9] = cBodega;
                grilla[10] = "";
                grilla[11] = nCantidad.ToString();
                grilla[12] = cIssueMthd;

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "%";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                Grid1.Rows.Clear();

                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                carga_orden_fabricacion();

            }

        }

        private void btn_buscar_pedido_Click(object sender, EventArgs e)
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

                t_CardCode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_OriginNum.Text = VariablesGlobales.glb_NumOC.Trim();

            }
        }

        private void btn_genera_solicitud_Click(object sender, EventArgs e)
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

            if (nDocNum == 0)
            {
                MessageBox.Show("La Orden de Fabricación NO ha sido creada, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.Rows.Count == 0)
            {
                MessageBox.Show("La Orden de Fabricación NO ha sido creada, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_itemname.Text == "")
            {
                MessageBox.Show("La Orden de Fabricación NO ha sido creada, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Solicitud de Transferencia", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(t_DocNum.Text);

            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                frmOrdenFabricacion1 f2 = new frmOrdenFabricacion1();
                DialogResult res = f2.ShowDialog();

            }


        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            nueva_orden();

            habilita_textos();

        }

        private void nueva_orden()
        {

            btn_crear.Enabled = true;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Max_DocNum();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            int nDocNum;

            try
            {
                nDocNum = int.Parse(dTable.Rows[0]["DocNum"].ToString());
            }
            catch
            {
                nDocNum = 0;
            }

            t_DocNum.Text = nDocNum.ToString();

            try
            {
                cbb_usersign.SelectedValue = VariablesGlobales.glb_User_id;
            }
            catch
            {

            }

            DateTime dFecha;

            dFecha = DateTime.Now;

            dtp_postdate.Value = dFecha;
            dtp_startdate.Value = dFecha;
            dtp_duedate.Value = dFecha;

            t_itemcode.Clear();
            t_itemname.Clear();
            t_um.Clear();

            //0. Especial
            //1. Estandar
            //2. Desmontar

            cbb_type.SelectedIndex = 1;

            //0. Planif.
            //1. Liberada

            cbb_status.SelectedIndex = 0;

            t_PlannedQty.Clear();
            t_OriginNum.Clear();
            t_CardCode.Clear();
            t_Project.Clear();
            t_Comments.Clear();
            t_u_ordenafecta.Clear();

            cbb_almacen.SelectedValue = "";
            cbb_u_proceso.SelectedValue = "";
            cbb_u_tipoorden.SelectedValue = "";
            cbb_u_tipofruta.SelectedValue = "";
            cbb_env_cajas.SelectedValue = "";
            cbb_env_cantidad.SelectedValue = "";
            cbb_env_pallet.SelectedValue = "";

            btn_resumen.Enabled = true;

            Grid1.Rows.Clear();


        }

        private void carga_recetas_desde_repositorio(int nDocEntry)
        {

            string cAlmacen;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_PlannedQty.Text = Convert.ToDouble(dTable.Rows[0]["Father_Qauntity"].ToString()).ToString("N2");
            }
            catch
            {
                t_PlannedQty.Clear();
            }

            try
            {
                cAlmacen = dTable.Rows[0]["Father_ToWH"].ToString();
            }
            catch
            {
                cAlmacen = "";
            }

            try
            {
                cbb_almacen.SelectedValue = cAlmacen;
            }
            catch
            {

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega, cOrigCurr;
            double nCantidad, nConsumido, nDisponible;
            double nCantidadPlanificada, nCantidadRequerida;

            try
            {
                nCantidadPlanificada = Convert.ToDouble(t_PlannedQty.Text);
            }
            catch
            {
                nCantidadPlanificada = 0;
            }

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["LineId"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cItemCode = dTable.Rows[i]["U_Code"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["CodeName"].ToString();
                }
                catch
                {
                    cItemName = "";

                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["U_Quantity"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                nCantidadRequerida = nCantidad * nCantidadPlanificada;

                try
                {
                    nConsumido = 0;
                }
                catch
                {
                    nConsumido = 0;
                }

                try
                {
                    nDisponible = Convert.ToDouble(dTable.Rows[i]["OnOrder_D"].ToString());
                }
                catch
                {
                    nDisponible = 0;
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
                    cBodega = dTable.Rows[i]["U_Warehouse"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cOrigCurr = dTable.Rows[i]["U_OrigCurr"].ToString();
                }
                catch
                {
                    cOrigCurr = "";
                }

                if (cOrigCurr == "")
                {
                    cOrigCurr = "M";
                }

                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidad.ToString("N2");
                grilla[5] = nCantidadRequerida.ToString("N2");
                grilla[6] = nConsumido.ToString("N2");
                grilla[7] = nDisponible.ToString("N2");
                grilla[8] = cUM;
                grilla[9] = cBodega;
                grilla[10] = "";
                grilla[11] = nCantidad.ToString();
                grilla[12] = cOrigCurr;

                Grid1.Rows.Add(grilla);

            }

        }

        private void t_itemcode_Leave(object sender, EventArgs e)
        {

            string cItemName;

            cItemName = "";

            clsProductos objproducto1 = new clsProductos();
            objproducto1.cls_consultar_Producto_x_codigo(t_itemcode.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto1.cResultado;

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
            }


        }

        private void btn_resumen_Click(object sender, EventArgs e)
        {

            string cDocNum;

            try
            {
                cDocNum = t_DocNum.Text;
            }
            catch
            {
                cDocNum = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;
            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {
                frmOrdenFabricacion6 f2 = new frmOrdenFabricacion6();
                DialogResult res = f2.ShowDialog();


            }


        }
    }


}

