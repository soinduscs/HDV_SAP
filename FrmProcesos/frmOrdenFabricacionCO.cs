using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmOrdenFabricacionCO : Form
    {
        public frmOrdenFabricacionCO()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionCO_Load(object sender, EventArgs e)
        {

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
                if (VariablesGlobales.glb_Referencia1 == "Despelonado")
                {
                    t_cantidad.ReadOnly = false;

                }
                else
                {
                    t_cantidad.ReadOnly = true;

                }

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

            int fila;

            fila = -1;

            string cItemCode, cItemName, cLote;
            string cWharehouse, cLote_D;
            string cCodProd, cCodCli;
            string cCodigoCSG_D, cCodigoCSG_Old;
            string cTipoCosecha_D, cTipoCosecha_Old, CItemCode_DyS;

            double nQuantity, nQuantityIni, nStockDisponible;

            int nLineNum, nCantidadBins, nCantidadBinsVolteados;
            int nCantidadBinsPendientes;

            nCantidadBinsPendientes = 0;
            nCantidadBins = 0;
            nStockDisponible = 0;
            cCodProd = "";
            cCodCli = "";
            cCodigoCSG_D = "";
            cTipoCosecha_D = "";

            ///////////////////////////////////////
            // Valido que todos los códigos CSG
            // sean iguales 

            try
            {
                cCodigoCSG_Old = Grid1[16, 0].Value.ToString();
            }
            catch
            {
                cCodigoCSG_Old = "_REF";

            }

            try
            {
                cItemCode = Grid1[2, 0].Value.ToString().Substring(3, 10);
            }
            catch
            {
                cItemCode = "";
            }

            if ((cItemCode == "ALM.MP.XXX") || (cItemCode == "NUE.MP.XXX"))
            {

                if (cCodigoCSG_Old != "_REF")
                {
                    for (int i = 0; i <= Grid1.Rows.Count - 1; i++)
                    {

                        try
                        {
                            cCodigoCSG_D = Grid1[16, i].Value.ToString();
                        }
                        catch
                        {
                            cCodigoCSG_D = "";
                        }

                        if (cCodigoCSG_Old != cCodigoCSG_D)
                        {
                            MessageBox.Show("Existen códigos CSG mal relacionados, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                    }

                }

            }

            ///////////////////////////////////////
            // Valido que todos los Tipo Cosecha
            // sean iguales -- Solo para D&S

            try
            {
                CItemCode_DyS = Grid1[2, 0].Value.ToString();

            }
            catch
            {
                CItemCode_DyS = "_REF";

            }

            try
            {
                cTipoCosecha_Old = Grid1[17, 0].Value.ToString();
            }
            catch
            {
                cTipoCosecha_Old = "_REF";

            }

            if (CItemCode_DyS == "FS.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                if (cTipoCosecha_Old != "_REF")
                {
                    for (int i = 0; i <= Grid1.Rows.Count - 1; i++)
                    {

                        try
                        {
                            cTipoCosecha_D = Grid1[17, i].Value.ToString();
                        }
                        catch
                        {
                            cTipoCosecha_D = "";
                        }

                        if (cTipoCosecha_Old != cTipoCosecha_D)
                        {
                            MessageBox.Show("Existen Tipos de Cosecha mal relacionados, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                    }

                }

            }

            for (int i = 0; i <= Grid1.Rows.Count - 1; i++)
            {

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                try
                {
                    cLote_D = Grid1[6, i].Value.ToString();
                }
                catch
                {
                    cLote_D = "";
                }

                try
                {
                    nCantidadBins = int.Parse(Grid1[7, i].Value.ToString());
                }
                catch
                {
                    nCantidadBins = 0;
                }

                try
                {
                    nCantidadBinsVolteados = int.Parse(Grid1[8, i].Value.ToString());
                }
                catch
                {
                    nCantidadBinsVolteados = 0;
                }

                nCantidadBinsPendientes = nCantidadBins - nCantidadBinsVolteados;

                if (t_lote.Text == cLote_D)
                {
                    fila = i;
                    break;

                }

            }

            if (fila == -1)
            {
                MessageBox.Show("El Lote ingresado no esta asociada a la Orden, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nCantidadBinsPendientes == 0)
            {
                MessageBox.Show("El Lote " + t_lote.Text + " No tiene Bins pendientes de Voltear, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nCantidadBinsPendientes < nCantBins_x_Voltear)
            {
                MessageBox.Show("El Lote " + t_lote.Text + " No tiene la cantidad de Bins pendientes que desea Voltear, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLineNum = int.Parse(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nLineNum = 0;
            }

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
                cItemName = Grid1[3, fila].Value.ToString();
            }
            catch
            {
                cItemName = "";
            }

            try
            {
                cLote = Grid1[6, fila].Value.ToString();
            }
            catch
            {
                cLote = "";
            }

            try
            {
                nQuantity = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                nQuantity = 0;
            }

            try
            {
                nQuantityIni = Convert.ToDouble(Grid1[10, fila].Value.ToString());
            }
            catch
            {
                nQuantityIni = 0;
            }

            try
            {
                nStockDisponible = Convert.ToDouble(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nStockDisponible = 0;
            }

            if (nQuantityIni == 0)
            {
                nQuantityIni = nQuantity;
            }

            try
            {
                cCodProd = Grid1[12, fila].Value.ToString();
            }
            catch
            {
                cCodProd = "";
            }

            try
            {
                cCodCli = Grid1[14, fila].Value.ToString();
            }
            catch
            {
                cCodCli = "";
            }

            if (cItemCode.Trim() != "")
            {
                if (cItemCode.Substring(0, 2) == "FS")
                {
                    if (t_ultimo_codprod.Text != "*")
                    {
                        if (t_ultimo_codprod.Text != cCodProd)
                        {
                            MessageBox.Show("Existen Consumos anteriores referidos a un Productor Diferente, Contacte al planificador, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;

                        }

                    }

                    if (t_ultimo_codcli.Text != "*")
                    {
                        if (t_ultimo_codcli.Text != cCodCli)
                        {
                            MessageBox.Show("Existen Consumos anteriores referidos a un Cliente Diferente, Contacte al planificador, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                    }

                }

            }

            double nQuantityPendiente;

            nQuantityPendiente = nQuantityIni / nCantidadBins;
            nQuantity = nQuantityPendiente;

            if (nQuantity > nStockDisponible)
            {
                nQuantity = nStockDisponible;

            }

            nCantidadBins = 1;

            try
            {
                cWharehouse = Grid1[9, fila].Value.ToString();
            }
            catch
            {
                cWharehouse = "";
            }

            string cDocDate, cCardName_Cliente, cCardCode_Cliente;
            string cCardCode_Productor, cCardName_Productor;

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

            if (nCantidadBins == 0)
            {
                MessageBox.Show("Debe seleccionar un lote válido, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            /////////////////////////////////////
            // Determino la cantidad a consumir
            // por bins

            double nPesoTotal_D, nCantTotalBins_D, nBinsYaVolteados_D;
            double nStock_D, nBins_Pendiente_D;
            int nCant_Bins_a_Voltear;
        
            try
            {
                nCant_Bins_a_Voltear = int.Parse(t_cantidad.Text);
            }
            catch
            {
                nCant_Bins_a_Voltear = 0;
            }

            if (nCant_Bins_a_Voltear == 0)
            {
                MessageBox.Show("Debe ingresar una cantidades de Bins válida, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nPesoTotal_D = Convert.ToDouble(Grid1[10, fila].Value.ToString());
            }
            catch
            {
                nPesoTotal_D = 0;
            }

            try
            {
                nCantTotalBins_D = Convert.ToDouble(Grid1[7, fila].Value.ToString());
            }
            catch
            {
                nCantTotalBins_D = 0;
            }

            try
            {
                nBinsYaVolteados_D = Convert.ToDouble(Grid1[8, fila].Value.ToString());
            }
            catch
            {
                nBinsYaVolteados_D = 0;
            }

            try
            {
                nStock_D = Convert.ToDouble(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nStock_D = 0;
            }

            nBins_Pendiente_D = nCantTotalBins_D - nBinsYaVolteados_D;

            if (nBins_Pendiente_D==0)
            {
                MessageBox.Show("No Existen Bins pendientes de Voltear, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nCant_Bins_a_Voltear > nBins_Pendiente_D)
            {
                MessageBox.Show("No puede voltear mas Bins que los pendientes, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String mensaje;

            mensaje = "";

            nQuantity = ( Math.Round(nPesoTotal_D / nCantTotalBins_D,2) * nCant_Bins_a_Voltear);

            if (nQuantity > nStock_D)
            {
                if (((nQuantity / nStock_D)-1) > 1)
                {
                    MessageBox.Show("Existe una inconsistencia entre el stock disponible y la cantidad de Bins a Voltear, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    nQuantity = nStock_D;
                }

            }

            nCantidadBins = nCant_Bins_a_Voltear;

            if (nCantTotalBins_D == (nBinsYaVolteados_D + nCantidadBins))
            {
                nQuantity = nStock_D;
            }

            mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocEntry, nLineNum, nQuantity, cWharehouse, nCantidadBins, cLote, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap, "", cCodigoCSG_D);

            if (mensaje == "Error de Conexión")
            {
                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocEntry, nLineNum, nQuantity, cWharehouse, nCantidadBins, cLote, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap, "", cCodigoCSG_D);

            }

            if (mensaje == "Error de Conexión")
            {
                Thread.Sleep(500);
                mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nDocEntry, nLineNum, nQuantity, cWharehouse, nCantidadBins, cLote, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, "CONSUMO PARA PRODUCCION ", UsuarioSap, ClaveSap, "", cCodigoCSG_D);

            }

            int nSalidaMercaderiaEntry;

            try
            {
                nSalidaMercaderiaEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Consumo realizado con existo - " + mensaje, "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_lotes_asginados();
                t_lote.Clear();

                t_lote.Focus();

            }
            catch
            {
                nSalidaMercaderiaEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación del Consumo :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                t_lote.Clear();

                t_lote.Focus();

            }

            //t_DocNum.Clear();
            
            //Grid1.Rows.Clear();

            //t_docentry_recibo.Text = nTerminationReportEntry.ToString();

        }

        private void limpia_pantalla()
        {
            t_lote.Clear();
            Grid1.Rows.Clear();

        }

        private void t_lote_Enter(object sender, EventArgs e)
        {
            //revisar_lote();
        }

        private void t_lote_Leave(object sender, EventArgs e)
        {
            //revisar_lote();
        }

        private void revisar_lote()
        {
            if (t_lote.Text == "")
            {
                return;
            }

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

            double nCantidad, nBins, nVolteados;

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

                if (t_lote.Text == cLoteM_D)
                {
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

                    Grid1.Rows.Add(grilla);

                }

            }

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
            string cNomCliente, cCodigo_CSG, cTipo_Cosecha;
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

                try
                {
                    cCodigo_CSG = dTable.Rows[i]["U_Codigo_CSG"].ToString().ToUpper();
                }
                catch
                {
                    cCodigo_CSG = "";
                }

                try
                {
                    cTipo_Cosecha = dTable.Rows[i]["U_Tipo_Cosecha"].ToString().ToUpper();
                }
                catch
                {
                    cTipo_Cosecha = "";
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
                grilla[16] = cCodigo_CSG;
                grilla[17] = cTipo_Cosecha;

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


    }


}
