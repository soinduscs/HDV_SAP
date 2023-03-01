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
    public partial class frmOrdenFabricacionINS4 : Form
    {
        public frmOrdenFabricacionINS4()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionINS4_Load(object sender, EventArgs e)
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Turnos();

            cbb_turno.DataSource = objproducto.cResultado;
            cbb_turno.ValueMember = "FldValue";
            cbb_turno.DisplayMember = "Descr";

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_ConsultaLista_area();

            cbb_area.DataSource = objproducto1.cResultado;
            cbb_area.ValueMember = "FldValue";
            cbb_area.DisplayMember = "Descr";

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.cls_ConsultaLista_Almacenes();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            int nDocEntry;

            try
            {
                nDocEntry = VariablesGlobales.glb_DocEntry;
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                dtp_createdate.Value = DateTime.Now;

                t_nombre.Text = VariablesGlobales.glb_User_Name;
                t_responsable.Text = VariablesGlobales.glb_User_Code;

                t_estado.Text = "En Proceso";
                t_cod_estado.Text = "";

                t_docentry.Text = nDocEntry.ToString();

            }
            else
            {
                carga_documento(nDocEntry);

                dtp_createdate.Enabled = false;
                cbb_area.Enabled = false;
                cbb_turno.Enabled = false;
                cbb_almacen.Enabled = false;

                Grid1.Columns[8].Visible = false;
                Grid1.Focus();

                if ((t_estado.Text == "Procesado") || (t_estado.Text == "Cerrado"))
                {
                    btn_crear.Visible = false;
                    button1.Visible = false;

                    if (t_estado.Text == "Cerrado")
                    {
                        Grid1.Columns[8].Visible = Visible;

                    }

                }
                else
                {
                    btn_crear.Visible = true;
                    button1.Visible = true;

                }

            }

        }

        private void carga_documento(int nDocEntry)
        {

            t_docentry.Text = nDocEntry.ToString();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_DeclaracionInsumosv2_x_DocEntry(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cTurno, cArea, cWareHose;
            string cDimension1, cDimension2, cDimension3;
            string cToWhs;

            DateTime dFecha;

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["CreateDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Now;
            }

            dtp_createdate.Value = dFecha;

            try
            {
                cTurno = dTable.Rows[0]["U_Turno"].ToString();
            }
            catch
            {
                cTurno = "";
            }

            try
            {
                cbb_turno.SelectedValue = cTurno;
            }
            catch
            {

            }

            try
            {
                cArea = dTable.Rows[0]["U_Area"].ToString();
            }
            catch
            {
                cArea = "";
            }

            try
            {
                cbb_area.SelectedValue = cArea;
            }
            catch
            {

            }

            try
            {
                cWareHose = dTable.Rows[0]["WhsCodeCab"].ToString();
            }
            catch
            {
                cWareHose = "";
            }

            try
            {
                cbb_almacen.SelectedValue = cWareHose;
            }
            catch
            {

            }

            try
            {
                cToWhs = dTable.Rows[0]["U_WhsCode"].ToString();

            }
            catch
            {
                cToWhs = "";

            }

            t_destino.Text = cToWhs;

            try
            {
                t_estado.Text = dTable.Rows[0]["Status_Name"].ToString();
            }
            catch
            {
                t_estado.Text = "";
            }

            try
            {
                t_cod_estado.Text = dTable.Rows[0]["Status"].ToString();
            }
            catch
            {
                t_cod_estado.Text = "";
            }

            try
            {
                t_nombre.Text = dTable.Rows[0]["Nombre_Empleado"].ToString();
            }
            catch
            {
                t_nombre.Text = "";
            }

            try
            {
                t_Comments.Text = dTable.Rows[0]["U_Obs_Cab"].ToString();
            }
            catch
            {
                t_Comments.Text = "";
            }

            try
            {
                t_docentry_ref.Text = dTable.Rows[0]["U_DocEntryRef"].ToString();
            }
            catch
            {
                t_docentry_ref.Text = "";
            }

            ////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // Detalle de Insumos

            string cItemCode_D, cItemName_D, cWareHouse_D;
            string cNota_D, cUMed;

            double nCantidad_D, nCantidad_Entregada_D, nCantidad_Recibida_D;

            int nNumOF, nLote, nDocEntryRef, nDocEntrySalida;
            int Number_ojdt, nLineId;

            DateTime dFecha_Salida;

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nLineId = 0;

                try
                {
                    nLineId = Convert.ToInt32(dTable.Rows[i]["LineId"].ToString());
                }
                catch
                {
                    nLineId = 0;

                }

                try
                {
                    cItemCode_D = dTable.Rows[i]["U_ItemCode"].ToString();
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
                    cUMed = dTable.Rows[i]["InvntryUom"].ToString(); // - SalUnitMsr
                }
                catch
                {
                    cUMed = "";
                }

                try
                {
                    cDimension1 = dTable.Rows[i]["OcrCode_Ref1"].ToString(); //U_OcrCode
                }
                catch
                {
                    cDimension1 = "";
                }

                try
                {
                    cDimension2 = dTable.Rows[i]["OcrCode_Ref2"].ToString(); //U_OcrCode2
                }
                catch
                {
                    cDimension2 = "";
                }

                try
                {
                    cDimension3 = dTable.Rows[i]["OcrCode_Ref3"].ToString(); //U_OcrCode3
                }
                catch
                {
                    cDimension3 = "";
                }

                try
                {
                    nLote = Convert.ToInt32(dTable.Rows[i]["U_DistNumber"].ToString());
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    nNumOF = Convert.ToInt32(dTable.Rows[i]["U_NumOF"].ToString());
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(dTable.Rows[i]["U_Cantidad"].ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    nCantidad_Entregada_D = Convert.ToDouble(dTable.Rows[i]["U_Cant_Entregada"].ToString());

                }
                catch
                {
                    nCantidad_Entregada_D = 0;

                }

                try
                {
                    nCantidad_Recibida_D = Convert.ToDouble(dTable.Rows[i]["Cant_Recibida"].ToString());

                }
                catch
                {
                    nCantidad_Recibida_D = 0;

                }

                try
                {
                    cWareHouse_D = cWareHose; // dTable.Rows[i]["U_WhsCode"].ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cNota_D = dTable.Rows[i]["U_Obs"].ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = int.Parse(dTable.Rows[i]["U_DocEntry"].ToString());
                }
                catch
                {
                    nDocEntryRef = 0;
                }

                nDocEntrySalida = 0;

                try
                {
                    nDocEntrySalida = int.Parse(dTable.Rows[i]["U_DocEntry"].ToString());
                }
                catch
                {
                    nDocEntrySalida = 0;
                }

                Number_ojdt = 0;

                try
                {
                    Number_ojdt = int.Parse(dTable.Rows[i]["Number_ojdt"].ToString());
                }
                catch
                {
                    Number_ojdt = 0;
                }

                try
                {
                    dFecha_Salida = Convert.ToDateTime(dTable.Rows[i]["Fecha_Salida"].ToString());
                }
                catch
                {
                    dFecha_Salida = Convert.ToDateTime("01/01/1900");
                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {

                    grilla[0] = "";
                    grilla[1] = cItemCode_D;
                    grilla[2] = cItemName_D;
                    grilla[3] = cUMed;

                    grilla[4] = "";

                    if (nLote > 0)
                    {
                        grilla[4] = nLote.ToString();

                    }

                    grilla[5] = "";

                    if (nNumOF > 0)
                    {
                        grilla[5] = nNumOF.ToString();

                    }

                    grilla[6] = nCantidad_D.ToString("N2");
                    grilla[7] = nCantidad_Entregada_D.ToString("N2");
                    grilla[8] = nCantidad_Recibida_D.ToString("N2");

                    grilla[20] = nCantidad_D.ToString("N2");

                    grilla[9] = cWareHouse_D;

                    if (cDimension1 != "")
                    {
                        grilla[10] = cDimension1;

                    }

                    grilla[11] = cNota_D;
                    grilla[12] = "";
                    grilla[13] = nDocEntryRef.ToString();

                    grilla[14] = "";
                    grilla[15] = nLineId.ToString();

                    grilla[17] = "";

                    if (cDimension2 != "")
                    {
                        grilla[17] = cDimension2;

                    }

                    grilla[18] = "";

                    if (cDimension3 != "")
                    {
                        grilla[18] = cDimension3;

                    }

                    grilla[19] = cNota_D;

                    Grid1.Rows.Add(grilla);

                    Grid1[7, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                    Grid1[8, Grid1.Rows.Count - 1].Style.BackColor = Color.GreenYellow;

                }

            }

            itmes_grilla();

        }

        private void itmes_grilla()
        {

            int nLineId = 0;
            int nLineaProcesada, nLineaConData;
            string cItemCode, cDocEntry;

            nLineaProcesada = 0;
            nLineaConData = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = i + 1;

                Grid1[0, i].Value = nLineId.ToString();

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
                    cDocEntry = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cDocEntry = "";
                }

                if (cDocEntry == "")
                {
                    cDocEntry = "0";
                }

                if (cItemCode != "")
                {
                    nLineaConData += 1;

                    if ((cDocEntry != "") && (cDocEntry != "0"))
                    {
                        nLineaProcesada += 1;
                    }

                }

            }

            if (nLineaProcesada == nLineaConData)
            {
                btn_crear.Enabled = false;

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil;
            double nCantidad, nCantidad_old;

            nCantidad = 0;
            fil = 0;

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
                nCantidad_old = Convert.ToDouble(Grid1[6, fil].Value);

            }
            catch
            {
                nCantidad_old = 0;

            }

            try
            {
                nCantidad = Convert.ToDouble(Grid1[7, fil].Value);

            }
            catch
            {
                nCantidad = 0;

            }

            if (nCantidad > nCantidad_old)
            {
                nCantidad = nCantidad_old;

            }

            Grid1[7, fil].Value = nCantidad.ToString("N");

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DateTime dt;

            string cFecha, cItemCode, cLote;
            string cDimension1, cDimension2, cDimension3;
            string cWhsCode, cBodegaDestino, cLineid;

            double nQuantity;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////
            //// Genero un resumen con los registros seleccionados

            string[] grilla;
            grilla = new string[30];

            string[,] d_arrDetalle = new string[20, 1000];

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j;

            j = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cItemCode = Grid1[1, x].Value.ToString();
                cLote = Grid1[4, x].Value.ToString();
                cWhsCode = Grid1[9, x].Value.ToString();
                cBodegaDestino = t_destino.Text; // cbb_almacen.SelectedValue.ToString();
                cLineid = Grid1[15, x].Value.ToString();

                cDimension1 = Grid1[10, x].Value.ToString();
                cDimension2 = Grid1[17, x].Value.ToString();
                cDimension3 = Grid1[18, x].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[7, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                if (nQuantity >0)
                {

                    //d_arrDetalle[1, j] = cLineid;
                    //d_arrDetalle[2, j] = cItemCode;
                    //d_arrDetalle[3, j] = cLote;
                    //d_arrDetalle[4, j] = cWhsCode;
                    //d_arrDetalle[5, j] = nQuantity.ToString();
                    //d_arrDetalle[6, j] = cBodegaDestino;

                    //d_arrDetalle[10, j] = "INSUMOS TIPO B";
                    //d_arrDetalle[11, j] = cDimension1;
                    //d_arrDetalle[12, j] = cDimension2;
                    //d_arrDetalle[13, j] = cDimension3;
                    //d_arrDetalle[14, j] = t_Comments.Text;
                    //d_arrDetalle[15, j] = t_nombre.Text;

                    d_arrDetalle[1, j] = cItemCode;
                    d_arrDetalle[2, j] = cWhsCode;
                    d_arrDetalle[3, j] = nQuantity.ToString();
                    d_arrDetalle[4, j] = cBodegaDestino;

                    d_arrDetalle[10, j] = "INSUMOS TIPO B";
                    d_arrDetalle[11, j] = cDimension1;
                    d_arrDetalle[12, j] = cDimension2;
                    d_arrDetalle[13, j] = cDimension3;
                    d_arrDetalle[14, j] = t_Comments.Text;
                    d_arrDetalle[15, j] = t_nombre.Text;
                    d_arrDetalle[16, j] = cLineid;

                    j += 1;

                }

            }

            string[,] d_arrDetalle1 = new string[10, 1000];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle1[1, i] = "";

            }

            j = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cItemCode = Grid1[1, x].Value.ToString();
                cLote = Grid1[4, x].Value.ToString();

                if (cLote.Trim() != "")
                {
                    try
                    {
                        nQuantity = Convert.ToDouble(Grid1[7, x].Value.ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    cWhsCode = Grid1[7, x].Value.ToString();

                    d_arrDetalle1[1, j] = cItemCode;
                    d_arrDetalle1[2, j] = cLote;
                    d_arrDetalle1[3, j] = nQuantity.ToString();
                    d_arrDetalle1[4, j] = cWhsCode;

                    j += 1;

                }


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
            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("El registro no ha sido grabado, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la solicitud de transferencia?", "Declaración de Insumos ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            nStockTransferEntry = 0;

            String mensaje = clsOrdenFabricacion.Stock_Transfer(nDocEntry, cFecha, d_arrDetalle, d_arrDetalle1, "", "", UsuarioSap, ClaveSap);

            string cTurno, cArea;
            string cWareHose;


            if (cbb_turno.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cTurno = cbb_turno.SelectedValue.ToString();
            }
            catch
            {
                cTurno = "";
            }

            if (cTurno == "")
            {
                MessageBox.Show("Debe seleccionar un turno válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_area.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un área válida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cArea = cbb_area.SelectedValue.ToString();
            }
            catch
            {
                cArea = "";
            }

            if (cArea == "")
            {
                MessageBox.Show("Debe seleccionar un área válida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_almacen.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un almacén válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cWareHose = cbb_almacen.SelectedValue.ToString();
            }
            catch
            {
                cWareHose = "";
            }

            if (cWareHose == "")
            {
                MessageBox.Show("Debe seleccionar un almacén válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cFecha = dtp_createdate.Value.ToString("yyyyMMdd");

            try
            {
                nStockTransferEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Solicitud Generada con Exito", "Solicitud de Insumos" + mensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                nStockTransferEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la Solicitud de transferencia :::::: " + cErrorMensaje + ", opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            String mensaje1 = clsOrdenFabricacion.SAPB1_OPRODUCCION7v2(nDocEntry, VariablesGlobales.glb_User_id, t_cod_estado.Text, cFecha, cTurno, VariablesGlobales.glb_User_id, cArea, t_Comments.Text, cWareHose, d_arrDetalle, nStockTransferEntry);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nDocEntry;
            string cFecha, cTurno, cArea;
            string cWareHose;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (cbb_turno.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cTurno = cbb_turno.SelectedValue.ToString();
            }
            catch
            {
                cTurno = "";
            }

            if (cTurno == "")
            {
                MessageBox.Show("Debe seleccionar un turno válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_area.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un área válida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cArea = cbb_area.SelectedValue.ToString();
            }
            catch
            {
                cArea = "";
            }

            if (cArea == "")
            {
                MessageBox.Show("Debe seleccionar un área válida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_almacen.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un almacén válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cWareHose = cbb_almacen.SelectedValue.ToString();
            }
            catch
            {
                cWareHose = "";
            }

            if (cWareHose == "")
            {
                MessageBox.Show("Debe seleccionar un almacén válido, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cFecha = dtp_createdate.Value.ToString("yyyyMMdd");

            ////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // Detalle de Insumos

            string cItemCode_D, cItemName_D, cWareHouse_D;
            string cNota_D, cOcrCode_D, cManBtchNum_D;
            string cTipoFurta_D, cOcrCode_D2, cOcrCode_D3;

            double nCantidad_D;

            int nLineId_D, j, nNumOF;
            int nLote, nDocEntryRef;

            string[,] d_arrDetalle = new string[15, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[1, i] = "";

            }

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
                    cItemCode_D = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode_D2 = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D2 = "";
                }

                try
                {
                    cOcrCode_D3 = Grid1[18, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D3 = "";
                }

                if ((cItemCode_D != "") && (cOcrCode_D == ""))
                {
                    MessageBox.Show("Debe indicar una dimensión 1 válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((cItemCode_D != "") && (cOcrCode_D2 == ""))
                {
                    MessageBox.Show("Debe indicar una dimensión 2 válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((cItemCode_D != "") && (cOcrCode_D3 == ""))
                {
                    MessageBox.Show("Debe indicar una dimensión 3 válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

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
                    cItemCode_D = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    nLote = Convert.ToInt32(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    nNumOF = Convert.ToInt32(Grid1[5, i].Value.ToString());
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(Grid1[7, i].Value.ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    cWareHouse_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[9, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode_D2 = Grid1[16, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D2 = "";
                }

                try
                {
                    cOcrCode_D3 = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D3 = "";
                }

                try
                {
                    cNota_D = Grid1[18, i].Value.ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = Convert.ToInt32(Grid1[12, i].Value.ToString());
                }
                catch
                {
                    nDocEntryRef = 0;
                }

                if ((cItemCode_D != "") && (cWareHouse_D == ""))
                {
                    MessageBox.Show("Debe indicar un almacén válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((cItemCode_D != "") && (nCantidad_D == 0))
                {
                    MessageBox.Show("Debe indicar una cantidad válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsProductos objproducto1 = new clsProductos();
                objproducto1.cls_consultar_Producto_x_codigo_stock(cItemCode_D, cWareHouse_D);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                cManBtchNum_D = "N";
                cTipoFurta_D = "";

                try
                {
                    cManBtchNum_D = dTable1.Rows[0]["ManBtchNum"].ToString();
                }
                catch
                {
                    cManBtchNum_D = "N";
                }

                try
                {
                    cTipoFurta_D = dTable1.Rows[0]["U_TipoProducto"].ToString();
                }
                catch
                {
                    cTipoFurta_D = "";
                }

                if ((cItemCode_D != "") && (cManBtchNum_D == "Y"))
                {
                    if (nLote == 0)
                    {
                        MessageBox.Show("Debe indicar un número de lote válida [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                if ((cItemCode_D != "") && (nCantidad_D == 0))
                {
                    MessageBox.Show("Debe indicar una cantidad valida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {
                    if ((cTipoFurta_D == "Almendra") || (cTipoFurta_D == "Nuez") || (cTipoFurta_D == "Ciruela"))
                    {
                        MessageBox.Show("No puede declarar productos a mermar [Linea: " + Grid1[0, i].Value.ToString() + "], opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {
                    d_arrDetalle[1, j] = nLineId_D.ToString();
                    d_arrDetalle[2, j] = cItemCode_D;
                    d_arrDetalle[3, j] = cItemName_D;
                    d_arrDetalle[4, j] = nLote.ToString();
                    d_arrDetalle[5, j] = nNumOF.ToString();
                    d_arrDetalle[6, j] = nCantidad_D.ToString();
                    d_arrDetalle[7, j] = cWareHouse_D;
                    d_arrDetalle[8, j] = cNota_D;
                    d_arrDetalle[9, j] = nDocEntryRef.ToString();
                    d_arrDetalle[10, j] = cOcrCode_D;
                    d_arrDetalle[11, j] = cOcrCode_D2;
                    d_arrDetalle[12, j] = cOcrCode_D3;

                    j += 1;

                }

            }

            int nDocEntry_New;

            // *************************************************
            // *************************************************
            // *************************************************
            // Valido que los datos de cabecera NO Existe!!!!!!!

            nDocEntry_New = 0;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_DeclaracionInsumosv2_x_FechaTurnoArea(cFecha, Convert.ToInt32(cTurno), Convert.ToInt32(cArea));

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nDocEntry_New = Convert.ToInt32(dTable.Rows[0]["DocEntry"]);
            }
            catch
            {
                nDocEntry_New = 0;
            }

            if (nDocEntry == 0)
            {
                if (nDocEntry_New > 0)
                {
                    MessageBox.Show("La Fecha / Turno / Área ya tiene una declaración de Insumos, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            nDocEntry_New = 0;

            String mensaje = clsOrdenFabricacion.SAPB1_OPRODUCCION7v2(nDocEntry, VariablesGlobales.glb_User_id, t_cod_estado.Text, cFecha, cTurno, 0, cArea, t_Comments.Text, cWareHose, d_arrDetalle, 0);

            if (nDocEntry == 0)
            {
                clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
                objproducto5.cls_Consultar_DeclaracionInsumosv2_Max_DocEntry();

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

                try
                {
                    nDocEntry_New = int.Parse(dTable5.Rows[0]["DocEntry"].ToString());
                }
                catch
                {
                    nDocEntry_New = 0;
                }

                t_docentry.Text = nDocEntry_New.ToString();
                nDocEntry = nDocEntry_New;

            }

            MessageBox.Show("Registro grabado con Exito!!", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

    }

}
