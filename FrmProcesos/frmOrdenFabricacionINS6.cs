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
    public partial class frmOrdenFabricacionINS6 : Form
    {
        public frmOrdenFabricacionINS6()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionINS6_Load(object sender, EventArgs e)
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

                t_estado.Text = "Procesado";
                t_cod_estado.Text = "";

                t_docentry.Text = nDocEntry.ToString();

                //Grid1.Columns[7].ReadOnly = false;

            }
            else
            {
                carga_documento(nDocEntry);

                dtp_createdate.Enabled = false;
                cbb_area.Enabled = false;
                cbb_turno.Enabled = false;
                cbb_almacen.Enabled = false;

                if (t_estado.Text == "Cerrado")
                {
                    btn_crear.Visible = false;
                    Grid1.Columns[7].ReadOnly = true;

                }
                else
                {
                    btn_crear.Visible = true;
                    

                }

            }

        }

        private void carga_documento(int nDocEntry)
        {

            t_docentry.Text = nDocEntry.ToString();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_DeclaracionInsumosv3_x_DocEntry(nDocEntry);

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
                cToWhs = dTable.Rows[0]["U_WhsCode"].ToString();
            }
            catch
            {
                cToWhs = "";
            }

            t_destino.Text = cWareHose;
            t_solicitante.Text = cToWhs;

            try
            {
                cbb_almacen.SelectedValue = cWareHose;
            }
            catch
            {

            }

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

            double nCantidad_D, nCantidad_Entregada_D;

            int nNumOF, nLote, nDocEntryRef, nDocEntrySalida;
            int nDocEntry_Transferencia, nDocEntry_Salida, nTransId_RegistroDiario;
            int Number_ojdt, nLineNum;

            DateTime dFecha_Salida, dFechaTransferencia;

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

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
                    //nCantidad_D = Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString());
                    nCantidad_D = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());

                }
                catch
                {
                    nCantidad_D = -1;
                }

                if (t_estado.Text != "Cerrado")
                {
                    try
                    {
                        nCantidad_Entregada_D = Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString());
                        //nCantidad_Entregada_D = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());

                    }
                    catch
                    {
                        nCantidad_Entregada_D = 0;

                    }

                }
                else
                {
                    try
                    {
                        nCantidad_Entregada_D = Convert.ToDouble(dTable.Rows[i]["Cant_Recibida"].ToString());
                        //nCantidad_Entregada_D = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());

                    }
                    catch
                    {
                        nCantidad_Entregada_D = 0;

                    }
                    

                }

                try
                {
                    cWareHouse_D = dTable.Rows[i]["U_WhsCode"].ToString();
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
                    nLineNum = Convert.ToInt32(dTable.Rows[i]["U_LineId_Ref"].ToString());
                }
                catch
                {
                    nLineNum = -1;
                }

                try
                {
                    dFecha_Salida = Convert.ToDateTime(dTable.Rows[i]["Fecha_Salida"].ToString());
                }
                catch
                {
                    dFecha_Salida = Convert.ToDateTime("01/01/1900");
                }

                try
                {
                    nDocEntry_Transferencia = Convert.ToInt32(dTable.Rows[i]["DocEntry_Transferencia"].ToString());

                }
                catch
                {
                    nDocEntry_Transferencia = 0;

                }

                try
                {
                    dFechaTransferencia = Convert.ToDateTime(dTable.Rows[i]["DocDate_Transferencia"].ToString());

                }
                catch
                {
                    dFechaTransferencia = Convert.ToDateTime("01/01/1900");

                }

                try
                {
                    nDocEntry_Salida = Convert.ToInt32(dTable.Rows[i]["DocEntry_Salida"].ToString());

                }
                catch
                {
                    nDocEntry_Salida = 0;

                }

                try
                {
                    nTransId_RegistroDiario = Convert.ToInt32(dTable.Rows[i]["TransId_RegistroDiario"].ToString());

                }
                catch
                {
                    nTransId_RegistroDiario = 0;

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

                    grilla[19] = nCantidad_D.ToString("N2");

                    grilla[8] = cWareHouse_D;

                    if (cDimension1 != "")
                    {
                        grilla[9] = cDimension1;

                    }

                    grilla[10] = cNota_D;
                    grilla[11] = "";
                    grilla[12] = nDocEntryRef.ToString();

                    grilla[13] = "";
                    grilla[14] = nLineNum.ToString();
                    grilla[15] = "";

                    if (cDimension2 != "")
                    {
                        grilla[16] = cDimension2;

                    }

                    if (cDimension3 != "")
                    {
                        grilla[17] = cDimension3;

                    }

                    grilla[18] = cNota_D;
                    
                    grilla[20] = "";

                    if (nDocEntry_Transferencia > 0)
                    {
                        grilla[20] = nDocEntry_Transferencia.ToString();

                    }

                    grilla[21] = "";

                    if (dFechaTransferencia.Year != 1900)
                    {
                        grilla[21] = dFechaTransferencia.ToString("dd/MM/yyyy");

                    }

                    grilla[22] = "";

                    if (nDocEntry_Salida > 0)
                    {
                        grilla[22] = nDocEntry_Salida.ToString();

                    }
                    
                    grilla[23] = "";

                    if (nDocEntry_Salida > 0)
                    {
                        grilla[23] = nTransId_RegistroDiario.ToString();

                    }

                    Grid1.Rows.Add(grilla);

                    if (t_estado.Text != "Cerrado")
                    {
                        Grid1[7, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;

                    }
                    else
                    {
                        Grid1[7, Grid1.Rows.Count - 1].Style.BackColor = Color.GreenYellow;

                    }

                    if (nDocEntry_Transferencia > 0)
                    {
                        Grid1[20, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                        Grid1[21, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                        Grid1[22, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                        Grid1[23, Grid1.Rows.Count - 1].Style.BackColor = Color.Yellow;

                    }
                    else
                    {
                        Grid1[20, Grid1.Rows.Count - 1].Style.BackColor = Color.Empty;
                        Grid1[21, Grid1.Rows.Count - 1].Style.BackColor = Color.Empty;
                        Grid1[22, Grid1.Rows.Count - 1].Style.BackColor = Color.Empty;
                        Grid1[23, Grid1.Rows.Count - 1].Style.BackColor = Color.Empty;

                    }

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
            string cWhsCode, cBodegaDestino;

            double nQuantity;

            int nLineNum, nDocEntry; 

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

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry_ref.Text);
            }
            catch
            {
                nDocEntry = -1;
            }

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cItemCode = Grid1[1, x].Value.ToString();
                cWhsCode = t_destino.Text; // Grid1[8, x].Value.ToString();
                cBodegaDestino = t_solicitante.Text; // cbb_almacen.SelectedValue.ToString();

                cDimension1 = Grid1[9, x].Value.ToString();
                cDimension2 = Grid1[16, x].Value.ToString();
                cDimension3 = Grid1[17, x].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[7, x].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                try
                {
                    nLineNum = Convert.ToInt32(Grid1[14, x].Value.ToString());
                }
                catch
                {
                    nLineNum = -1;
                }

                if (nQuantity > 0)
                {
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
                    d_arrDetalle[16, j] = nLineNum.ToString();
                    d_arrDetalle[17, j] = nDocEntry.ToString();

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

            int nAjusteMerma, nStockTransferEntry_pre;

            nStockTransferEntry = 0;
            nStockTransferEntry_pre = 0;

            String mensaje = clsOrdenFabricacion.Transfer_Stock(nDocEntry, cFecha, d_arrDetalle, d_arrDetalle1, "", "", UsuarioSap, ClaveSap);

            string cTurno, cArea;
            string cWareHose;

            try
            {
                nStockTransferEntry_pre = int.Parse(mensaje);

            }
            catch
            {
                nStockTransferEntry_pre = 0;

            }

            String mensaje2 = clsOrdenFabricacion.Transfer_Stock_Cerrar(nDocEntry.ToString(), UsuarioSap, ClaveSap);

            nAjusteMerma = 0;

            if (nStockTransferEntry_pre > 0)
            {
                String mensaje1 = clsOrdenFabricacion.Ajuste_Merma_Stock(nDocEntry, cFecha, d_arrDetalle, d_arrDetalle1, "", "", UsuarioSap, ClaveSap);

                try
                {
                    nAjusteMerma = int.Parse(mensaje1);

                }
                catch
                {
                    nAjusteMerma = 0;

                }

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

            //String mensaje1 = clsOrdenFabricacion.SAPB1_OPRODUCCION7v2(nDocEntry, VariablesGlobales.glb_User_id, t_cod_estado.Text, cFecha, cTurno, VariablesGlobales.glb_User_id, cArea, t_Comments.Text, cWareHose, d_arrDetalle, nStockTransferEntry);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

    }

}
