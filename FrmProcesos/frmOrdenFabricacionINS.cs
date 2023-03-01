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
    public partial class frmOrdenFabricacionINS : Form
    {
        public frmOrdenFabricacionINS()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionINS_Load(object sender, EventArgs e)
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

            my_DGVCboColumn.DataSource = objproducto2.cResultado;
            my_DGVCboColumn.Name = "Almacén";
            my_DGVCboColumn.ValueMember = "WhsCode";
            my_DGVCboColumn.DisplayMember = "WhsCode";

            Grid1.Columns.RemoveAt(7);
            Grid1.Columns.Insert(7, my_DGVCboColumn);
            Grid1.Columns[7].Width = 80;
            
            // *********************************************
            // Dimension 1

            clsProduccion objproducto4 = new clsProduccion();
            objproducto4.cls_ConsultaLista_Dimension1();

            DataGridViewComboBoxColumn my_DGVCboColumn1 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn1.DataSource = objproducto4.cResultado;
            my_DGVCboColumn1.Name = "Dimensión 1";
            my_DGVCboColumn1.ValueMember = "OcrCode";
            my_DGVCboColumn1.DisplayMember = "OcrCode";

            Grid1.Columns.RemoveAt(8);
            Grid1.Columns.Insert(8, my_DGVCboColumn1);
            Grid1.Columns[8].Width = 90;

            // *********************************************
            // Dimension 2

            clsProduccion objproducto5 = new clsProduccion();
            objproducto5.cls_ConsultaLista_Dimension2();

            DataGridViewComboBoxColumn my_DGVCboColumn2 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn2.DataSource = objproducto5.cResultado;
            my_DGVCboColumn2.Name = "Dimensión 2";
            my_DGVCboColumn2.ValueMember = "OcrCode";
            my_DGVCboColumn2.DisplayMember = "OcrCode";

            Grid1.Columns.RemoveAt(15);
            Grid1.Columns.Insert(15, my_DGVCboColumn2);
            Grid1.Columns[15].Width = 90;

            // *********************************************
            // Dimension 3

            clsProduccion objproducto6 = new clsProduccion();
            objproducto6.cls_ConsultaLista_Dimension3();

            DataGridViewComboBoxColumn my_DGVCboColumn3 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn3.DataSource = objproducto6.cResultado;
            my_DGVCboColumn3.Name = "Dimensión 3";
            my_DGVCboColumn3.ValueMember = "OcrCode";
            my_DGVCboColumn3.DisplayMember = "OcrCode";

            Grid1.Columns.RemoveAt(16);
            Grid1.Columns.Insert(16, my_DGVCboColumn3);
            Grid1.Columns[16].Width = 90;

            int nDocEntry;

            try
            {
                nDocEntry = VariablesGlobales.glb_DocEntry;
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry==0)
            {
                dtp_createdate.Value = DateTime.Now;

                t_nombre.Text = VariablesGlobales.glb_User_Name;
                t_responsable.Text = VariablesGlobales.glb_User_Code;

                t_estado.Text = "En Proceso";
                t_cod_estado.Text = "";

                t_docentry.Text = nDocEntry.ToString();

                btn_procesar_insumos.Visible = false;

            }
            else
            {
                carga_documento(nDocEntry);

                dtp_createdate.Enabled = false;
                cbb_area.Enabled = false;
                cbb_turno.Enabled = false;

                if (t_estado.Text == "Procesado")
                {
                    btn_crear.Visible = false;
                    btn_procesar_insumos.Visible = false;
                }
                else
                {
                    btn_crear.Visible = true;
                    btn_procesar_insumos.Visible = true;
                }

            }

        }


        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void tsb_agrega_productor_Click(object sender, EventArgs e)
        {
            string cToWhs = "";

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
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos1 f2 = new frmSel_Productos1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode.Trim() != "")
            {

                double nDisponible;
                string cUM;

                clsProductos objproducto1 = new clsProductos();
                objproducto1.cls_consultar_Producto_x_codigo_stock(VariablesGlobales.glb_ItemCode, cToWhs);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;              

                try
                {
                    nDisponible = Convert.ToDouble(dTable.Rows[0]["OnOrder"].ToString());
                }
                catch
                {
                    nDisponible = 0;
                }

                try
                {
                    cUM = dTable.Rows[0]["InvntryUom"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                string[] grilla;
                grilla = new string[30];

                grilla[0] = 0.ToString();
                grilla[1] = VariablesGlobales.glb_ItemCode;
                grilla[2] = VariablesGlobales.glb_ItemName;
                grilla[3] = cUM;
                grilla[4] = "";
                grilla[5] = "";
                grilla[6] = 0.ToString("N2");
                grilla[7] = cToWhs;
                grilla[8] = "";

                Grid1.Rows.Add(grilla);

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
                    cDocEntry = Grid1[11, i].Value.ToString();
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
                btn_procesar_insumos.Enabled = false;

            }

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("No Existen registros a eliminar, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Declaración de Insumos ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

            itmes_grilla();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {               

                VariablesGlobales.glb_ItemCode = "";
                VariablesGlobales.glb_ItemName = "";
                VariablesGlobales.glb_Almacen = "";
                //VariablesGlobales.glb_DocEntry = nNumOF;

                frmSel_Productos3 f3 = new frmSel_Productos3();
                DialogResult res1 = f3.ShowDialog();

                if (VariablesGlobales.glb_ItemCode.Trim() != "")
                {

                    double nDisponible;
                    string cUM;

                    clsProductos objproducto1 = new clsProductos();
                    objproducto1.cls_consultar_Producto_x_codigo_stock(VariablesGlobales.glb_ItemCode, VariablesGlobales.glb_Almacen);

                    DataTable dTable = new DataTable();
                    dTable = objproducto1.cResultado;

                    try
                    {
                        nDisponible = Convert.ToDouble(dTable.Rows[0]["OnOrder"].ToString());
                    }
                    catch
                    {
                        nDisponible = 0;
                    }

                    try
                    {
                        cUM = dTable.Rows[0]["InvntryUom"].ToString();
                    }
                    catch
                    {
                        cUM = "";
                    }

                    string[] grilla;
                    grilla = new string[30];

                    grilla[0] = 0.ToString();
                    grilla[1] = VariablesGlobales.glb_ItemCode;
                    grilla[2] = VariablesGlobales.glb_ItemName;
                    grilla[3] = cUM;
                    grilla[4] = "";
                    grilla[5] = VariablesGlobales.glb_DocEntry.ToString();
                    grilla[6] = 0.ToString("N2");
                    grilla[7] = VariablesGlobales.glb_Almacen;
                    grilla[8] = "";

                    Grid1.Rows.Add(grilla);

                }

                itmes_grilla();

            }

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int fil;
            double nCantidad;

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
                nCantidad = Convert.ToDouble(Grid1[6, fil].Value);
            }
            catch
            {
                nCantidad = 0;
            }

            Grid1[6, fil].Value = nCantidad.ToString("N");

        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {
            int fil, nNumOF;

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
                nNumOF = Convert.ToInt32(Grid1[5, fil].Value);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF == 0)
            {
                Grid1.Columns[7].ReadOnly = false;
            }
            else
            {
                Grid1.Columns[7].ReadOnly = true;
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int fil;
            string cItemCode, cManBtchNum;

            fil = 0;

            cItemCode = "";

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
                cItemCode = Grid1[1, fil].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            cManBtchNum = "N";

            clsProductos objproducto1 = new clsProductos();

            objproducto1.cls_consultar_Producto_x_codigo(cItemCode);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                cManBtchNum = dTable1.Rows[0]["ManBtchNum"].ToString();
            }
            catch
            {
                cManBtchNum = "N";
            }

            if (cManBtchNum == "N")
            {
                MessageBox.Show("El Artículo seleccionado, no permite definción de números de lote, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = cItemCode;

            try
            {
                VariablesGlobales.glb_ItemName = Grid1[2, fil].Value.ToString();
            }
            catch
            {
                VariablesGlobales.glb_ItemName = "";
            }

            try
            {
                VariablesGlobales.glb_Almacen = Grid1[7, fil].Value.ToString();
            }
            catch
            {
                VariablesGlobales.glb_Almacen = "";
            }

            VariablesGlobales.glb_Lote = 0;

            frmSel_Lotes f3 = new frmSel_Lotes();
            DialogResult res1 = f3.ShowDialog();

            if (VariablesGlobales.glb_Lote > 0)
            {
                Grid1[4, fil].Value = VariablesGlobales.glb_Lote.ToString();

            }

        }

        private void btn_crear_Click(object sender, EventArgs e)
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
                    cOcrCode_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode_D2 = Grid1[15, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D2 = "";
                }

                try
                {
                    cOcrCode_D3 = Grid1[16, i].Value.ToString();
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
                    nCantidad_D = Convert.ToDouble(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    cWareHouse_D = Grid1[7, i].Value.ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode_D2 = Grid1[15, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D2 = "";
                }

                try
                {
                    cOcrCode_D3 = Grid1[16, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D3 = "";
                }

                try
                {
                    cNota_D = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = Convert.ToInt32(Grid1[11, i].Value.ToString());
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
            objproducto.cls_Consultar_DeclaracionInsumos_x_FechaTurnoArea(cFecha, Convert.ToInt32(cTurno), Convert.ToInt32(cArea));

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

            String mensaje = clsOrdenFabricacion.SAPB1_OPRODUCCION7(nDocEntry, VariablesGlobales.glb_User_id, t_cod_estado.Text, cFecha, cTurno, 0, cArea, t_Comments.Text, cWareHose, d_arrDetalle);

            if (nDocEntry == 0)
            {
                clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
                objproducto5.cls_Consultar_DeclaracionInsumos_Max_DocEntry();

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

        private void carga_documento(int nDocEntry)
        {

            t_docentry.Text = nDocEntry.ToString();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_DeclaracionInsumos_x_DocEntry(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cTurno, cArea, cWareHose;
            string cDimension1, cDimension2, cDimension3;

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

            ////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // Detalle de Insumos

            string cItemCode_D, cItemName_D, cWareHouse_D;
            string cDimension1_ige1, cDimension2_ige1, cDimension3_ige1;
            string cNota_D, cUMed;

            double nCantidad_D;

            int nNumOF, nLote, nDocEntryRef, nDocEntrySalida;
            int Number_ojdt;

            DateTime dFecha_Salida;

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
                    nCantidad_D = Convert.ToDouble(dTable.Rows[i]["U_Cantidad"].ToString());
                }
                catch
                {
                    nCantidad_D = -1;
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
                    dFecha_Salida = Convert.ToDateTime(dTable.Rows[i]["Fecha_Salida"].ToString());
                }
                catch
                {
                    dFecha_Salida = Convert.ToDateTime("01/01/1900"); 
                }

                try
                {
                    cDimension1_ige1 = dTable.Rows[i]["OcrCode_ige1"].ToString(); //U_OcrCode
                }
                catch
                {
                    cDimension1_ige1 = "";
                }

                try
                {
                    cDimension2_ige1 = dTable.Rows[i]["OcrCode_ige2"].ToString(); //U_OcrCode2
                }
                catch
                {
                    cDimension2_ige1 = "";
                }

                try
                {
                    cDimension3_ige1 = dTable.Rows[i]["OcrCode_ige3"].ToString(); //U_OcrCode3
                }
                catch
                {
                    cDimension3_ige1 = "";
                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {

                    grilla[0] = "";
                    grilla[1] = cItemCode_D;
                    grilla[2] = cItemName_D;
                    grilla[3] = cUMed;

                    grilla[4] = "";

                    if (nLote >0)
                    {
                        grilla[4] = nLote.ToString();

                    }

                    grilla[5] = "";

                    if (nNumOF > 0)
                    {
                        grilla[5] = nNumOF.ToString();

                    }

                    grilla[6] = nCantidad_D.ToString("N2");
                    grilla[7] = cWareHouse_D;

                    if (cDimension1 != "") 
                    {
                        grilla[8] = cDimension1;

                    }
                    else
                    if (cDimension1_ige1 != "")
                    {
                        grilla[8] = cDimension1_ige1;

                    }

                    grilla[9] = cNota_D;
                    grilla[10] = "";
                    grilla[11] = nDocEntryRef.ToString();

                    grilla[12] = "";
                    grilla[13] = "";
                    grilla[14] = "";

                    if (cDimension2 != "")
                    {
                        grilla[15] = cDimension2;

                    }
                    else
                    if (cDimension2_ige1 != "")
                    {
                        grilla[15] = cDimension2_ige1;

                    }

                    if (cDimension3 != "")
                    {
                        grilla[16] = cDimension3;

                    }
                    else
                    if (cDimension3_ige1 != "")
                    {
                        grilla[16] = cDimension3_ige1;

                    }

                    grilla[17] = cNota_D;

                    if (nDocEntrySalida > 0)
                    {
                        grilla[18] = nDocEntrySalida.ToString();

                    }
                    else
                    {
                        grilla[18] = "";
                    }

                    grilla[19] = "";

                    if (dFecha_Salida.Year > 1900)
                    {
                        grilla[19] = dFecha_Salida.ToString("dd/MM/yyyy");

                    }

                    grilla[20] = "";

                    if (Number_ojdt > 0)
                    {
                        grilla[20] = Number_ojdt.ToString();

                    }

                    grilla[21] = cDimension1_ige1;
                    grilla[22] = cDimension2_ige1;
                    grilla[23] = cDimension3_ige1;

                    Grid1.Rows.Add(grilla);

                }

            }

            itmes_grilla();

        }

        private void btn_procesar_insumos_Click(object sender, EventArgs e)
        {

            string declaracion_mermas, autorizacion_mermas;

            declaracion_mermas = "";
            autorizacion_mermas = "";

            clsMaestros objproducto_r = new clsMaestros();
            objproducto_r.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable_r = new DataTable();
            dTable_r = objproducto_r.cResultado;

            try
            {
                declaracion_mermas = dTable_r.Rows[0]["Declarar_Mermas"].ToString();
            }
            catch
            {
                declaracion_mermas = "";
            }

            try
            {
                autorizacion_mermas = dTable_r.Rows[0]["Autorizar_Mermas"].ToString();
            }
            catch
            {
                autorizacion_mermas = "";
            }

            if (autorizacion_mermas != "SI")
            {
                MessageBox.Show("No tiene los permisos suficientes para realizar esta actividad, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Procesar la Declaración de Insumos", "Declaración de Insumos ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

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

            if (nDocEntry == 0)
            {
                MessageBox.Show("El registro no ha sido grabado, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            string cNota_D, cManBtchNum_D, cOcrCode_D;
            string cOcrCode2_D, cOcrCode3_D;

            double nCantidad_D, nStock_D, nCantPlanificada_D;

            int nLineId_D, j, nNumOF;
            int nLote, nNumOF_D, nLineNum_D;

            ////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // Proceso de Validación

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
                    nCantidad_D = Convert.ToDouble(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    cWareHouse_D = Grid1[7, i].Value.ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode2_D = Grid1[15, i].Value.ToString();
                }
                catch
                {
                    cOcrCode2_D = "";
                }

                try
                {
                    cOcrCode3_D = Grid1[16, i].Value.ToString();
                }
                catch
                {
                    cOcrCode3_D = "";
                }

                try
                {
                    cNota_D = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                if (cNota_D == "")
                {
                    MessageBox.Show("El Artículo " + cItemCode_D + " requiere una nota, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCode_D != "")
                {
                    
                    if (nLote == 0)
                    {
                        cManBtchNum_D = "";

                        clsProductos objproducto3 = new clsProductos();
                        objproducto3.cls_consultar_Producto_x_codigo(cItemCode_D);

                        DataTable dTable3 = new DataTable();
                        dTable3 = objproducto3.cResultado;

                        try
                        {
                            cManBtchNum_D = dTable3.Rows[0]["ManBtchNum"].ToString();
                        }
                        catch
                        {
                            cManBtchNum_D = "";
                        }

                        if (cManBtchNum_D == "Y")
                        {
                            MessageBox.Show("El Artículo " + cItemCode_D + " requiere definición de Lotes, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                    }

                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {

                    if (cOcrCode_D == "")
                    {
                        MessageBox.Show("El Artículo " + cItemCode_D + " requiere definición de Dimensión, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    nStock_D = 0;

                    clsProductos objproducto2 = new clsProductos();

                    if (nLote == 0)
                    {
                        objproducto2.cls_Consulta_stock_x_codigo_almacen(cItemCode_D, cWareHouse_D);

                    }
                    else
                    {
                        objproducto2.cls_Consulta_stock_x_codigo_almacen_y_lote2(cItemCode_D, cWareHouse_D, nLote.ToString());

                    }

                    DataTable dTable2 = new DataTable();
                    dTable2 = objproducto2.cResultado;

                    try
                    {
                        nStock_D = Convert.ToDouble(dTable2.Rows[0]["Quantity"]);
                    }
                    catch
                    {
                        nStock_D = 0;
                    }

                    Grid1[12, i].Value = nStock_D.ToString("N");

                    if (nCantidad_D > nStock_D)
                    {
                        MessageBox.Show("El Artículo " + cItemCode_D + " No tiene stock suficiente para realizar la merma requerida, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

                if (nNumOF > 0)
                {

                    Grid1[13, i].Value = "";
                    Grid1[14, i].Value = "";

                    nNumOF_D = 0;
                    nLineNum_D = 0;

                    clsOrdenFabricacion objproducto4 = new clsOrdenFabricacion();

                    objproducto4.cls_Consultar_OrdenFabricacion_Insumos_Servicios_Linea(nNumOF , cItemCode_D);

                    DataTable dTable4 = new DataTable();
                    dTable4 = objproducto4.cResultado;

                    try
                    {
                        nNumOF_D = Convert.ToInt32(dTable4.Rows[0]["DocEntry"]);
                    }
                    catch
                    {
                        nNumOF_D = -1;
                    }

                    try
                    {
                        nLineNum_D = Convert.ToInt32(dTable4.Rows[0]["LineNum"]);
                    }
                    catch
                    {
                        nLineNum_D = -1;
                    }

                    try
                    {
                        nCantPlanificada_D = Convert.ToDouble(dTable4.Rows[0]["PlannedQty"]); 
                    }
                    catch
                    {
                        nCantPlanificada_D = 0;
                    }

                    if (nNumOF_D == nNumOF)
                    {
                        if (nLineNum_D >= 0)
                        {
                            Grid1[13, i].Value = nLineNum_D.ToString();
                            Grid1[14, i].Value = nCantPlanificada_D.ToString();

                        }

                    }
                    else
                    {
                        MessageBox.Show("El Artículo " + cItemCode_D + " Esta referenciado a una Orden de Fabricación Incorrecta, opción cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        
                    }

                }

            }            

            string[,] d_arrDetalle = new string[20, 100];

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
                    nCantidad_D = Convert.ToDouble(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    cWareHouse_D = Grid1[7, i].Value.ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode2_D = Grid1[15, i].Value.ToString();
                }
                catch
                {
                    cOcrCode2_D = "";
                }

                try
                {
                    cOcrCode3_D = Grid1[16, i].Value.ToString();
                }
                catch
                {
                    cOcrCode3_D = "";
                }

                try
                {
                    cNota_D = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cNota_D = "";
                }
                
                try
                {
                    nLineNum_D = Convert.ToInt32(Grid1[13, i].Value.ToString());
                }
                catch
                {
                    nLineNum_D = -1;
                }

                try
                {
                    nCantPlanificada_D = Convert.ToDouble(Grid1[14, i].Value.ToString());
                }
                catch
                {
                    nCantPlanificada_D = 0;
                }

                if ((cItemCode_D != "") && (nCantidad_D > 0))
                {
                    d_arrDetalle[1, j] = i.ToString();
                    d_arrDetalle[2, j] = cItemCode_D;
                    d_arrDetalle[3, j] = cItemName_D;
                    d_arrDetalle[4, j] = nLote.ToString();
                    d_arrDetalle[5, j] = nNumOF.ToString();
                    d_arrDetalle[6, j] = nCantidad_D.ToString();
                    d_arrDetalle[7, j] = cWareHouse_D;
                    d_arrDetalle[8, j] = cNota_D;
                    d_arrDetalle[9, j] = nLineNum_D.ToString();
                    d_arrDetalle[10, j] = nCantPlanificada_D.ToString("N");
                    d_arrDetalle[11, j] = cOcrCode_D;
                    d_arrDetalle[12, j] = cOcrCode2_D;
                    d_arrDetalle[13, j] = cOcrCode3_D;

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
            objproducto.cls_Consultar_DeclaracionInsumos_x_FechaTurnoArea(cFecha, Convert.ToInt32(cTurno), Convert.ToInt32(cArea));

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

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

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

            // *************************************************
            // *************************************************
            // *************************************************
            // A las Mermas con OF les debo aumentar la cantidad

            for (int i = 0; i <=j; i++)
            {

                nLineId_D = -1;

                try
                {
                    nLineId_D = Convert.ToInt32(d_arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                nNumOF = 0;

                try
                {
                    nNumOF = Convert.ToInt32(d_arrDetalle[5, i]);
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(d_arrDetalle[6, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    nLineNum_D = Convert.ToInt32(d_arrDetalle[9, i]);
                }
                catch
                {
                    nLineNum_D = -1;
                }

                try
                {
                    nCantPlanificada_D = Convert.ToDouble(d_arrDetalle[10, i]);
                }
                catch
                {
                    nCantPlanificada_D = 0;
                }

                if (nNumOF > 0)
                {
                    String mensaje1 = clsOrdenFabricacion.Production_Orders_ActualizaItem(nNumOF, nLineNum_D, nCantidad_D + nCantPlanificada_D,  UsuarioSap, ClaveSap);

                }

            }

            // *************************************************
            // *************************************************
            // *************************************************
            // Genero los ajustes por mermas

            string cDocDate;
            int nSalidaMercaderiaEntry;

            cDocDate = DateTime.Now.ToString("yyyyMMdd");

            for (int i = 0; i <= j; i++)
            {

                nLineId_D = -1;

                try
                {
                    nLineId_D = Convert.ToInt32(d_arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                nNumOF = 0;

                try
                {
                    nLote = Convert.ToInt32(d_arrDetalle[4, i]);
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    nNumOF = Convert.ToInt32(d_arrDetalle[5, i]);
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(d_arrDetalle[6, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    cWareHouse_D = d_arrDetalle[7, i];
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cItemCode_D = d_arrDetalle[2, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    nLineNum_D = Convert.ToInt32(d_arrDetalle[9, i]);
                }
                catch
                {
                    nLineNum_D = -1;
                }

                try
                {
                    nCantPlanificada_D = Convert.ToDouble(d_arrDetalle[10, i]);
                }
                catch
                {
                    nCantPlanificada_D = 0;
                }

                try
                {
                    cNota_D = d_arrDetalle[17, i].ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    cOcrCode_D = d_arrDetalle[11, i];
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode2_D = d_arrDetalle[12, i];
                }
                catch
                {
                    cOcrCode2_D = "";
                }

                try
                {
                    cOcrCode3_D = d_arrDetalle[13, i];
                }
                catch
                {
                    cOcrCode3_D = "";
                }


                if (nNumOF == 0)
                {
                    if (cItemCode_D != "")
                    {

                        if (nCantidad_D > 0)
                        {

                            nSalidaMercaderiaEntry = 0;

                            try
                            {
                                nSalidaMercaderiaEntry = int.Parse(Grid1[10, nLineId_D].Value.ToString());
                            }
                            catch
                            {
                                nSalidaMercaderiaEntry = 0;
                            }

                            if (nSalidaMercaderiaEntry == 0)
                            {
                                // *************************************************
                                // *************************************************
                                // *************************************************
                                // Genero los consumos Sin OF

                                string mensaje5 = clsProductos.Salida_Productos_Ajuste_Mermas(cDocDate, cItemCode_D, nLote.ToString(), cWareHouse_D, nCantidad_D, cNota_D, cOcrCode_D, UsuarioSap, ClaveSap, cOcrCode2_D, cOcrCode3_D);
                                //Salida_Productos_Ajuste_Mermas(string d_fecha_movimiento, string d_ItemCode, string d_lote, string d_bodega, double d_quantity, string d_usuariosap, string d_clavesap)

                                try
                                {
                                    nSalidaMercaderiaEntry = int.Parse(mensaje5);

                                }
                                catch
                                {
                                    nSalidaMercaderiaEntry = 0;

                                    MessageBox.Show("Error en la generación de la merma :::::: " + mensaje5 + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Grid1[1, nLineId_D].Style.BackColor = Color.Red;

                                    return;

                                }

                                Grid1[11, nLineId_D].Value = "";

                                if (nSalidaMercaderiaEntry > 0)
                                {
                                    Grid1[11, nLineId_D].Value = nSalidaMercaderiaEntry.ToString();

                                }

                            }

                        }

                    }

                }
           
                if (nNumOF > 0)
                {
                    // *************************************************
                    // *************************************************
                    // *************************************************
                    // Genero los consumos por OF

                    nSalidaMercaderiaEntry = 0;

                    try
                    {
                        nSalidaMercaderiaEntry = int.Parse(Grid1[11, nLineId_D].Value.ToString());
                    }
                    catch
                    {
                        nSalidaMercaderiaEntry = 0;
                    }

                    if (nSalidaMercaderiaEntry == 0)
                    {
                        string cCardCode_Productor, cCardName_Productor, cCardCode_Cliente;
                        string cCardName_Cliente;

                        cCardCode_Productor = "";
                        cCardName_Productor = "";
                        cCardCode_Cliente = "";
                        cCardName_Cliente = cNota_D;

                        String mensaje2 = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nNumOF, nLineNum_D, nCantidad_D, cWareHouse_D, 0, nLote.ToString(), cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap,"", "");

                        try
                        {
                            nSalidaMercaderiaEntry = int.Parse(mensaje2);

                        }
                        catch
                        {
                            nSalidaMercaderiaEntry = 0;

                        }

                        Grid1[11, nLineId_D].Value = "";

                        if (nSalidaMercaderiaEntry > 0)
                        {
                            Grid1[11, nLineId_D].Value = nSalidaMercaderiaEntry.ToString();

                        }

                    }

                }

            }

            int nDocEntryRef;

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
                    nCantidad_D = Convert.ToDouble(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nCantidad_D = -1;
                }

                try
                {
                    cWareHouse_D = Grid1[7, i].Value.ToString();
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cOcrCode_D = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cOcrCode_D = "";
                }

                try
                {
                    cOcrCode2_D = Grid1[15, i].Value.ToString();
                }
                catch
                {
                    cOcrCode2_D = "";
                }

                try
                {
                    cOcrCode3_D = Grid1[16, i].Value.ToString();
                }
                catch
                {
                    cOcrCode3_D = "";
                }

                try
                {
                    cNota_D = Grid1[17, i].Value.ToString();
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = Convert.ToInt32(Grid1[11, i].Value.ToString());
                }
                catch
                {
                    nDocEntryRef = 0;
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
                    d_arrDetalle[11, j] = cOcrCode2_D;
                    d_arrDetalle[12, j] = cOcrCode3_D;

                    j += 1;

                }

            }

            String mensaje = clsOrdenFabricacion.SAPB1_OPRODUCCION7(nDocEntry, VariablesGlobales.glb_User_id, t_cod_estado.Text, cFecha, cTurno, VariablesGlobales.glb_User_id, cArea, t_Comments.Text, cWareHose, d_arrDetalle);

            MessageBox.Show("Proceso realizado con Exito!!", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btn_crear.Visible = false;
            btn_procesar_insumos.Visible = false;

        }

    }

}



