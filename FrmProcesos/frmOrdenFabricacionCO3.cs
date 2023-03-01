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
    public partial class frmOrdenFabricacionCO3 : Form
    {
        public frmOrdenFabricacionCO3()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionCO3_Load(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();

            Grid2.Rows.Clear();

            Grid3.Rows.Clear();

            string produccion_ncc;

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                produccion_ncc = dTable1.Rows[0]["Produccion_NCC"].ToString();

            }
            catch
            {
                produccion_ncc = "NO";

            }

            if (produccion_ncc == "NO")
            {
                t_cantidad.ReadOnly = true;
            }
            else
            {
                t_cantidad.ReadOnly = false;
            }

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


        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                limpia_pantalla();

                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                carga_lotes_asginados();

                carga_1er_lotes_productor();

                t_cantidad.Text = "1";
                t_lote.Focus();

            }
        }

        private void limpia_pantalla()
        {
            t_lote.Clear();
            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

        }


        private void carga_lotes_asginados()
        {

            if (t_DocNum.Text == "")
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_Lotes_Asignados_para_Consumir(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cItemCode, cItemName, cLote_D;
            string cLoteM_D, cAlmacen;
            string cCodProductor, cNomProductor, cCodCliente;
            string cNomCliente;
            double nCantidad, nBins, nVolteados;
            double nCantidadIni;

            int DocLine;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    DocLine = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                }
                catch
                {
                    DocLine = 0;
                }

                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString().ToUpper();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cItemName = dTable.Rows[i]["ItemName"].ToString().ToUpper();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["AllocQty"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                try
                {
                    cLote_D = dTable.Rows[i]["MdAbsEntry"].ToString().ToUpper();
                }
                catch
                {
                    cLote_D = "";
                }

                try
                {
                    cLoteM_D = dTable.Rows[i]["DistNumber"].ToString().ToUpper();
                }
                catch
                {
                    cLoteM_D = "";
                }

                try
                {
                    nBins = Convert.ToDouble(dTable.Rows[i]["Bins"].ToString());
                }
                catch
                {
                    nBins = 0;
                }

                try
                {
                    nVolteados = Convert.ToDouble(dTable.Rows[i]["Volteados"].ToString());
                }
                catch
                {
                    nVolteados = 0;
                }

                try
                {
                    cAlmacen = dTable.Rows[i]["LocCode"].ToString().ToUpper();
                }
                catch
                {
                    cAlmacen = "";
                }

                try
                {
                    nCantidadIni = Convert.ToDouble(dTable.Rows[i]["QuantityIni"].ToString());
                }
                catch
                {
                    nCantidadIni = 0;
                }

                if (nCantidadIni <= 0)
                {
                    nVolteados = nBins;
                }

                try
                {
                    cCodProductor = dTable.Rows[i]["MnfSerial"].ToString().ToUpper();
                }
                catch
                {
                    cCodProductor = "";
                }

                try
                {
                    cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString().ToUpper();
                }
                catch
                {
                    cNomProductor = "";
                }

                try
                {
                    cCodCliente = dTable.Rows[i]["LotNumber"].ToString().ToUpper();
                }
                catch
                {
                    cCodCliente = "";
                }

                try
                {
                    cNomCliente = dTable.Rows[i]["U_NOMBCLI"].ToString().ToUpper();
                }
                catch
                {
                    cNomCliente = "";
                }

                grilla[0] = DocLine.ToString();
                grilla[1] = "";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidad.ToString("N2");
                grilla[5] = cLote_D;
                grilla[6] = cLoteM_D;
                grilla[7] = nBins.ToString();
                grilla[8] = nVolteados.ToString();
                grilla[9] = cAlmacen;
                grilla[10] = nCantidad.ToString("N2");
                grilla[11] = nCantidadIni.ToString("N2");

                grilla[12] = cCodProductor;
                grilla[13] = cNomProductor;
                grilla[14] = cCodCliente;
                grilla[15] = cNomCliente;

                if (nCantidad > 0)
                {
                    Grid1.Rows.Add(grilla);

                }

            }

        }


        private void carga_1er_lotes_productor()
        {

            if (t_DocNum.Text == "")
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Detalle_Consumos(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cCodProductor, cCodCliente;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cCodProductor = dTable.Rows[i]["MnfSerial"].ToString().ToUpper();
                }
                catch
                {
                    cCodProductor = "";
                }

                try
                {
                    cCodCliente = dTable.Rows[i]["LotNumber"].ToString().ToUpper();
                }
                catch
                {
                    cCodCliente = "";
                }

                if (t_ultimo_codprod.Text == "")
                {
                    t_ultimo_codprod.Text = cCodProductor;

                }

                if (t_ultimo_codcli.Text == "")
                {
                    t_ultimo_codcli.Text = cCodCliente;

                }

            }

            if (t_ultimo_codprod.Text == "")
            {
                t_ultimo_codprod.Text = "*";

            }

            if (t_ultimo_codcli.Text == "")
            {
                t_ultimo_codcli.Text = "*";

            }

        }

        private void t_DocNum_Leave(object sender, EventArgs e)
        {

            int nDocNum, nDocEntry;

            if (t_DocNum.Text == "")
            {
                t_lote.Clear();
                Grid1.Rows.Clear();
                return;
            }

            try
            {
                nDocNum = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocNum = -1;
            }

            t_lote.Clear();
            Grid1.Rows.Clear();

            if (nDocNum == -1)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            if (nDocEntry == -1)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            carga_lotes_asginados();
            carga_1er_lotes_productor();

            t_lote.Focus();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {

            if (t_lote.Text != "")
            {
                if (Grid3.RowCount > 0)
                {
                    MessageBox.Show("Ya selecciono un Lote y se le asignaron Cajones", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            int fila, nLote;
            string cWhsCode;

            Grid2.Rows.Clear();

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_Lote = 0;
            nLote = 0;
            cWhsCode = "";

            if (fila >= 0)
            {
                try
                {
                    nLote = Convert.ToInt32(Grid1[6, fila].Value);
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    cWhsCode = Grid1[9, fila].Value.ToString();

                }
                catch
                {
                    cWhsCode = "";

                }

            }

            if (nLote == 0)
            {
                return;

            }


            for (int y = 0; y <= Grid1.RowCount-1; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    Grid1[x, y].Style.BackColor = Color.Empty;
                }

            }

            for (int x = 0; x <= 15; x++)
            {
                Grid1[x, fila].Style.BackColor = Color.Yellow;
            }

            t_lote.Text = nLote.ToString();

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Vista_Lotes(nLote.ToString());

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string[] grilla;
            grilla = new string[30];

            string cItemCode, cItemName, cLote_D;
            string cLoteM_D, cAlmacen;
            string cCodProductor, cNomProductor, cCodCliente;
            string cNomCliente;
            double nCantidad, nCantidadIni;
            int DocLine, nBins;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    DocLine = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                }
                catch
                {
                    DocLine = 0;
                }

                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString().ToUpper();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cItemName = dTable.Rows[i]["ItemName"].ToString().ToUpper();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                try
                {
                    cLote_D = dTable.Rows[i]["MdAbsEntry"].ToString().ToUpper();
                }
                catch
                {
                    cLote_D = "";
                }

                try
                {
                    cLoteM_D = dTable.Rows[i]["DistNumber"].ToString().ToUpper();
                }
                catch
                {
                    cLoteM_D = "";
                }
               
                try
                {
                    cAlmacen = dTable.Rows[i]["WhsCode"].ToString().ToUpper();
                }
                catch
                {
                    cAlmacen = "";
                }

                try
                {
                    nCantidadIni = Convert.ToDouble(dTable.Rows[i]["QuantityIni"].ToString());
                }
                catch
                {
                    nCantidadIni = 0;
                }

               
                try
                {
                    cCodProductor = dTable.Rows[i]["MnfSerial"].ToString().ToUpper();
                }
                catch
                {
                    cCodProductor = "";
                }

                try
                {
                    cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString().ToUpper();
                }
                catch
                {
                    cNomProductor = "";
                }

                try
                {
                    cCodCliente = dTable.Rows[i]["LotNumber"].ToString().ToUpper();
                }
                catch
                {
                    cCodCliente = "";
                }

                try
                {
                    cNomCliente = dTable.Rows[i]["U_NOMBCLI"].ToString().ToUpper();
                }
                catch
                {
                    cNomCliente = "";
                }

                try
                {
                    nBins = Convert.ToInt32(dTable.Rows[i]["Bins"].ToString());

                }
                catch
                {
                    nBins = 0;

                }

                grilla[0] = DocLine.ToString();
                grilla[1] = "";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = cLote_D;
                grilla[5] = cLoteM_D;
                grilla[6] = nCantidad.ToString("N2");
                grilla[7] = 0.ToString("N2");
                grilla[8] = nBins.ToString();
                //grilla[8] = nVolteados.ToString();
                grilla[9] = cAlmacen;
                grilla[10] = nCantidad.ToString("N2");
                grilla[11] = nCantidadIni.ToString("N2");

                grilla[12] = cCodProductor;
                grilla[13] = cNomProductor;
                grilla[14] = cCodCliente;
                grilla[15] = cNomCliente;

                if (cWhsCode == cAlmacen)
                {
                    Grid2.Rows.Add(grilla);

                    for (int x = 0; x <= 15; x++)
                    {
                        Grid2[x, 0].Style.BackColor = Color.Yellow;
                    }

                }

            }

        }

        private void tsb_agrega_oc_Click(object sender, EventArgs e)
        {
            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("Debe seleccionar un ítem válido, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string[] grilla;
            grilla = new string[30];

            grilla[0] = "";
            grilla[1] = "";
            grilla[2] = "";
            grilla[3] = "";
            grilla[4] = "0";
            grilla[5] = "";

            Grid3.Rows.Add(grilla);

            Calcula_Peso_en_Cajones();

        }


        private void tsb_eliminar_Click(object sender, EventArgs e)
        {
            int fila;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Emisión para Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid3.Rows.RemoveAt(fila);

            }

            Calcula_Peso_en_Cajones();

        }

        private void Grid3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calcula_Peso_en_Cajones();
            

        }

        private void Calcula_Peso_en_Cajones()
        {

            int nItem, nNumCajon;
            string cPasillo, cCajon;
            double nPeso_Meta, nStock_Disponible, nStock_Aplicado;
            double nPeso_Aplicado;

            nItem = 0;
            nPeso_Meta = 0;
            nStock_Aplicado = 0;
            nPeso_Aplicado = 0;

            try
            {
                nStock_Disponible = Convert .ToDouble(Grid2[6, 0].Value);

            }
            catch
            {
                nStock_Disponible = 0;

            }

            for (int i = 0; i <= Grid3.RowCount - 1; i++)
            {
                nItem += 1;
                cCajon = "";

                try
                {
                    cPasillo = Grid3[1, i].Value.ToString();
                }
                catch
                {
                    cPasillo = "";
                }

                try
                {
                    nNumCajon = Convert.ToInt32(Grid3[2, i].Value);
                }
                catch
                {
                    nNumCajon = 0;
                }

                try
                {
                    nPeso_Meta = Convert.ToDouble(Grid3[4, i].Value);
                }
                catch
                {
                    nPeso_Meta = 0;
                }

                //nPeso_Meta = 0;

                nPeso_Aplicado = 0;
                cCajon = "";

                if (cPasillo != "")
                {
                    if (nNumCajon > 0)
                    {
                        cCajon = cPasillo + nNumCajon.ToString();

                        //if (cPasillo == "A")
                        //{
                        //    id_cajon += 100;

                        //}

                        //if (cPasillo == "B")
                        //{
                        //    id_cajon += 200;

                        //}

                        //if (cPasillo == "C")
                        //{
                        //    id_cajon += 300;

                        //}

                        //nPeso_Meta = 4000;

                        if (nNumCajon == 11)
                        {
                            //nPeso_Meta = 2000;
                        }

                        if (nNumCajon == 12)
                        {
                            //nPeso_Meta = 2000;
                        }


                        if (nStock_Disponible > nPeso_Meta)
                        {
                            nPeso_Aplicado = nPeso_Meta;
                            nStock_Aplicado += nPeso_Meta;
                            nStock_Disponible -= nPeso_Meta;

                        }
                        else
                        {
                            nPeso_Aplicado = nStock_Disponible;
                            nStock_Aplicado += nStock_Disponible;
                            nStock_Disponible -= nStock_Disponible;

                        }

                    }

                }

                Grid3[0, i].Value = nItem.ToString();
                Grid3[3, i].Value = cCajon;
                Grid3[4, i].Value = nPeso_Aplicado.ToString("N2");
                Grid3[5, i].Value = "";

            }

            Grid2[7, 0].Value = nStock_Aplicado.ToString("N2");

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid3.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocEntry, nCantBins_x_Voltear;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            try
            {
                nCantBins_x_Voltear = int.Parse(t_cantidad.Text);
            }
            catch
            {
                nCantBins_x_Voltear = 0;
            }

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Fabricación válida, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nCantBins_x_Voltear == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad de bins válida, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_lote.Text == "")
            {
                MessageBox.Show("Debe seleccionar un lotes válido, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar el Consumo", "Emisión para Producción ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cItemCode, cItemName, cLote;
            string cWharehouse, cLote_D;
            string cCodProd, cCodCli;

            double nQuantity; //, nStockDisponible;

            int nLineNum, nCantidadBins;

            //nCantidadBinsPendientes = 0;
            nCantidadBins = 0;
            //nStockDisponible = 0;
            cCodProd = "";
            cCodCli = "";

            try
            {
                cLote_D = t_lote.Text;
            }
            catch
            {
                cLote_D = "";
            }

            if (cLote_D == "")
            {
                MessageBox.Show("El Lote ingresado no esta asociada a la Orden, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLineNum = int.Parse(Grid2[0, 0].Value.ToString());
            }
            catch
            {
                nLineNum = 0;
            }

            try
            {
                cItemCode = Grid2[2, 0].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cItemName = Grid2[3, 0].Value.ToString();
            }
            catch
            {
                cItemName = "";
            }

            try
            {
                cLote = Grid2[5, 0].Value.ToString();
            }
            catch
            {
                cLote = "";
            }
      
            try
            {
                cCodProd = Grid2[12, 0].Value.ToString();
            }
            catch
            {
                cCodProd = "";
            }

            try
            {
                cCodCli = Grid2[14, 0].Value.ToString();
            }
            catch
            {
                cCodCli = "";
            }

            try
            {
                cWharehouse = Grid2[9, 0].Value.ToString();
            }
            catch
            {
                cWharehouse = "";
            }

            string cDocDate, cCardName_Cliente, cCardCode_Cliente;
            string cCardCode_Productor, cCardName_Productor;

            DateTime dFecha;

            try
            {
                dFecha = Convert.ToDateTime(t_fecha_contable.Text);
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDocDate = dFecha.ToString("yyyyMMdd");

            cCardCode_Productor = "";
            cCardName_Productor = "";
            cCardCode_Cliente = "";
            cCardName_Cliente = "";

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

            if (cLote == "")
            {
                MessageBox.Show("Debe seleccionar un lote válido, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            /////////////////////////////////////
            // Determino la cantidad a consumir
            // por bins

            string cCajon;

            String mensaje;

            mensaje = "";

            for (int i = 0; i <= Grid3.RowCount - 1; i++)
            {

                cCajon = "";
                nQuantity = 0;
                nCantidadBins = 1;

                try
                {
                    cCajon = Grid3[3, i].Value.ToString();
                }
                catch
                {
                    cCajon = "";
                }

                try
                {
                    nQuantity = Convert.ToDouble(Grid3[4, i].Value);
                }
                catch
                {
                    nQuantity = 0;
                }

                if (cCajon != "")
                {
                    if (nQuantity > 0)
                    {
                        mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocEntry, nLineNum, nQuantity, cWharehouse, nCantidadBins, cLote, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap, cCajon, "");

                        int nSalidaMercaderiaEntry;

                        try
                        {
                            nSalidaMercaderiaEntry = int.Parse(mensaje);
                            cErrorMensaje = "";

                            Grid3[5, i].Value = mensaje;

                        }
                        catch
                        {
                            nSalidaMercaderiaEntry = 0;
                            cErrorMensaje = mensaje;

                            Grid3[5, i].Value = "ERROR: " + cErrorMensaje;

                        }

                    }

                }

            }

            tsb_agrega_oc.Enabled = false;
            tsb_eliminar.Enabled = false;
            btn_crear.Enabled = false;

            MessageBox.Show("Consumo realizado con existo", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

    }

}
