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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace FrmProcesos
{
    public partial class frmOrdenFabricacion6 : Form
    {
        public frmOrdenFabricacion6()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion6_Load(object sender, EventArgs e)
        {
            t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

            t_tipofruta.Clear();
            t_presentacion.Clear();

            carga_orden_fabricacion_origen_mp();

            carga_orden_fabricacion();

            carga_detalles();

            carga_detalles_consumos();

        }


        private void carga_orden_fabricacion()
        {

            int nDocNum, nDocEntry;
            string cStatus;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
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
                t_almacen.Text = dTable.Rows[0]["Warehouse"].ToString();
            }
            catch
            {
                t_almacen.Text = "";
            }

            try
            {
                t_location.Text = dTable.Rows[0]["Location"].ToString();
            }
            catch
            {
                t_location.Text = "PAINE";
            }

            try
            {
                t_proceso.Text = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                t_proceso.Clear();
            }

            try
            {
                t_tipofruta.Text = dTable.Rows[0]["U_TipoProducto"].ToString().ToUpper();
            }
            catch
            {
                t_tipofruta.Clear();
            }

            double nPlannedQty;

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

            cStatus = "";

            try
            {
                cStatus = dTable.Rows[0]["Status"].ToString();
            }
            catch
            {
                cStatus = "";

            }

            btn_cerrar.Enabled = true;

            switch (cStatus)
            {
               
                case "C":
                    btn_cerrar.Enabled = false;
                    break;

                case "L":
                    btn_cerrar.Enabled = false;
                    break;

            }

            objproducto.cls_Consultar_OrdenFabricacion_para_Cerrar(nDocNum);

            dTable = objproducto.cResultado;

            string cLine, cItemCode, cItemName;
            string cUM, cBodega;
            double nCantidad_TR, nCantidad_Consumos;
            double nTotal_Cantidad_TR, nTotal_Cantidad_Consumos;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nTotal_Cantidad_TR = 0;
            nTotal_Cantidad_Consumos = 0;

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
                nCantidad_Consumos = 0;

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
                    nCantidad_Consumos = Convert.ToDouble(dTable.Rows[i]["Quantity_Consumo"].ToString());
                }
                catch
                {
                    nCantidad_Consumos = 0;
                }


                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = cUM;
                grilla[5] = cBodega;
                grilla[6] = nCantidad_TR.ToString("N2");
                grilla[7] = nCantidad_Consumos.ToString("N2");

                nTotal_Cantidad_TR += nCantidad_TR;
                nTotal_Cantidad_Consumos += nCantidad_Consumos;

                Grid1.Rows.Add(grilla);

            }

            grilla[0] = "";
            grilla[1] = "Artículo";
            grilla[2] = "";
            grilla[3] = "";
            grilla[4] = "";
            grilla[5] = "";
            grilla[6] = nTotal_Cantidad_TR.ToString("N2");
            grilla[7] = nTotal_Cantidad_Consumos.ToString("N2");

            Grid1.Rows.Add(grilla);

            for (int x = 0; x <= 7; x++)
            {
                Grid1[x, Grid1.RowCount-1].Style.BackColor = Color.LightGray;
            }

            if (nTotal_Cantidad_Consumos > nTotal_Cantidad_TR)
            {

                if (t_presentacion.Text != "")
                {
                    grilla[0] = "";

                    grilla[1] = "";
                    grilla[2] = "";

                    if (t_tipofruta.Text == "ALMENDRA")
                    {

                        if (t_presentacion.Text == "PELON")
                        {
                            if (t_itemcode.Text.Substring(0,2) == "FP")
                            {
                                grilla[1] = "FP.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01";
                                grilla[2] = "PELON ALMENDRAS PROPIA PT PROCESO CRACKER";
                            }
                            else
                            {
                                grilla[1] = "FS.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01";
                                grilla[2] = "PELON ALMENDRAS SERVICIO PT PROCESO CRACKER";
                            }

                        }

                        if (t_presentacion.Text == "CON CASCARA")
                        {
                            if (t_itemcode.Text.Substring(0, 2) == "FP")
                            {
                                grilla[1] = "FP.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01";
                                grilla[2] = "PELON ALMENDRAS PROPIA PT PROCESO CRACKER";
                            }
                            else
                            {
                                grilla[1] = "FS.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01";
                                grilla[2] = "PELON ALMENDRAS SERVICIO PT PROCESO CRACKER";
                            }

                        }

                        grilla[4] = "BMPPATIO";

                    }

                    if ((t_proceso.Text != "Secado") && (t_proceso.Text != "Desp & Secado"))
                    {

                        if (t_tipofruta.Text == "NUEZ")
                        {

                            if (t_presentacion.Text == "CON CASCARA")
                            {
                                if (t_itemcode.Text.Substring(0, 2) == "FP")
                                {
                                    grilla[1] = "FP.NUE.PT.XXXX.XXX.X.XXX-XXX.CAS.G.0001K.01";
                                    grilla[2] = "CASCARILLA PT PROPIA";
                                }
                                else
                                {
                                    grilla[1] = "FS.NUE.PT.XXXX.XXX.X.XXX-XXX.CAS.G.0001K.01";
                                    grilla[2] = "CASCARILLA PT SERVICIO";
                                }

                            }


                            if (t_location.Text == "PAINE")
                            {
                                grilla[4] = "BPCP1";
                            }
                            else
                            {
                                grilla[4] = "BSPPL";
                            }

                        }

                        grilla[3] = "Kg";

                        grilla[5] = (nTotal_Cantidad_Consumos - nTotal_Cantidad_TR).ToString("N2");

                        if (grilla[1] != "")
                        {
                            Grid2.Rows.Add(grilla);

                            for (int x = 0; x <= 5; x++)
                            {
                                Grid2[x, Grid2.RowCount - 1].Style.BackColor = Color.LightGray;
                            }

                        }

                    }

                }

            }

            if ((t_proceso.Text == "Secado") || (t_proceso.Text == "Desp & Secado"))
            {

                grilla[0] = "";

                grilla[1] = "FS.NUE.PT.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01";
                grilla[2] = "PELON NUEZ SERVICIO PT PROCESO DESPELONADO";
                grilla[3] = "Kg";
                grilla[4] = "BMPPATIO";
                grilla[5] = (nTotal_Cantidad_Consumos - nTotal_Cantidad_TR).ToString("N2");

                Grid2.Rows.Add(grilla);

                for (int x = 0; x <= 5; x++)
                {
                    Grid2[x, Grid2.RowCount - 1].Style.BackColor = Color.LightGray;
                }

            }


        }


        private void carga_orden_fabricacion_origen_mp()
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

            t_presentacion.Clear();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Origen_MP(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;
           
            string cLine, cItemCode, cItemName;
            string cUM, cDocNum, cVariedad;
            string cPresentacion;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];            

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["TipoDoc"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cDocNum = dTable.Rows[i]["DocNum"].ToString();
                }
                catch
                {
                    cDocNum = "";
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
                    cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                }
                catch
                {
                    cVariedad = "";

                }

                try
                {
                    cPresentacion = dTable.Rows[i]["U_HDV_PRESENTACION"].ToString();
                }
                catch
                {
                    cPresentacion = "";

                }

                grilla[0] = cLine;
                grilla[1] = cDocNum;
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = cUM;
                grilla[5] = cVariedad;
                grilla[6] = cPresentacion;

                Grid3.Rows.Add(grilla);

                if (cLine == "Entrada / Orden Compra")
                {
                    t_presentacion.Text = cPresentacion.ToUpper();
                }

            }
           

        }


        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {

            if (Grid2.Rows.Count == 0)
            {
                //MessageBox.Show("No Existen registros por asignar en la presente Orden de Fabricación, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

            }

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
                MessageBox.Show("Debe seleccionar una Orden de Fabricación Válida, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cItemCode_Insumos;
            double nQuantity_Planif_Insumos, nQuantity_Completada_Insumos;

            cItemCode_Insumos = "";
            nQuantity_Planif_Insumos = 0;
            nQuantity_Completada_Insumos = 0;

            clsOrdenFabricacion objproducto2 = new clsOrdenFabricacion();
            objproducto2.cls_Consultar_OrdenFabricacion_Insumos_Servicios(nDocNum);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                cItemCode_Insumos = "";
                nQuantity_Planif_Insumos = 0;
                nQuantity_Completada_Insumos = 0;

                try
                {
                    cItemCode_Insumos = dTable2.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemCode_Insumos = "";
                }

                try
                {
                    nQuantity_Planif_Insumos = double.Parse(dTable2.Rows[i]["PlannedQty"].ToString());
                }
                catch
                {
                    nQuantity_Planif_Insumos = 0;
                }

                try
                {
                    nQuantity_Completada_Insumos = double.Parse(dTable2.Rows[i]["IssuedQty"].ToString());
                }
                catch
                {
                    nQuantity_Completada_Insumos = 0;
                }

                if (nQuantity_Planif_Insumos > 0)
                {
                    if (nQuantity_Completada_Insumos == 0)
                    {
                        MessageBox.Show("La Orden contiene un insumo (" + cItemCode_Insumos + ") sin consumos asociados, opción cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Cerrar la Orden de Fabricación", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            String mensaje1, cDocNum;

            cDocNum = t_DocNum.Text;
            mensaje1 = "";

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            VariablesGlobales.glb_Referencia1 = "._.";

            frmOrdenFabricacion7 f2 = new frmOrdenFabricacion7();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Referencia1 == "._.")
            {
                return;
            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;

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

            if (t_presentacion.Text != "")
            {
                if (Grid2.RowCount != 0)
                {
                    string cItemCode, cItemName, cAlmacen;
                    double nCant_x_Cerrar;

                    try
                    {
                        cItemCode = Grid2[1, 0].Value.ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = Grid2[2, 0].Value.ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cAlmacen = Grid2[4, 0].Value.ToString();
                    }
                    catch
                    {
                        cAlmacen = "";
                    }

                    try
                    {
                        nCant_x_Cerrar = double.Parse(Grid2[5, 0].Value.ToString());
                    }
                    catch
                    {
                        nCant_x_Cerrar = 0;
                    }

                    int nMax_Linea = -1, nLineNum_OC;
                    string cItemCode_OC;

                    clsOrdenFabricacion objproducto5 = new clsOrdenFabricacion();
                    objproducto5.cls_Consultar_OrdenFabricacion_x_DocNum(int.Parse(cDocNum));

                    DataTable dTable5 = new DataTable();
                    dTable5 = objproducto5.cResultado;

                    cItemCode_OC = "";
                    nLineNum_OC = 0;

                    for (int i = 0; i <= dTable5.Rows.Count - 1; i++)
                    {

                        try
                        {
                            cItemCode_OC = dTable5.Rows[i]["ItemCode_D"].ToString();
                        }
                        catch
                        {
                            cItemCode_OC = "";
                        }

                        try
                        {
                            nLineNum_OC = int.Parse(dTable5.Rows[i]["LineNum"].ToString());
                        }
                        catch
                        {
                            nLineNum_OC = -1;
                        }

                        if (cItemCode == cItemCode_OC)
                        {
                            nMax_Linea = nLineNum_OC;
                            break;
                        }

                    }

                    if (nMax_Linea == -1)
                    {
                        String mensaje = clsOrdenFabricacion.Production_Orders_AgregaItem(cDocNum, cItemCode, cAlmacen, nCant_x_Cerrar * -1, UsuarioSap, ClaveSap);

                        clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                        objproducto.cls_Consultar_OrdenFabricacion_Max_Linea(int.Parse(cDocNum));

                        DataTable dTable = new DataTable();
                        dTable = objproducto.cResultado;

                        try
                        {
                            nMax_Linea = int.Parse(dTable.Rows[0]["LineNum"].ToString());
                        }
                        catch
                        {
                            nMax_Linea = -1;
                        }

                    }
                    
                    int nCantidadBins;
                    string cDocDate;
                    string cCardCode_Productor, cCardName_Productor;
                    string cCardCode_Cliente, cCardName_Cliente;

                    DateTime dFecha;

                    try
                    {
                        dFecha = DateTime.Now;
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    cDocDate = dFecha.ToString("yyyyMMdd");

                    nCantidadBins = 1;

                    cCardCode_Productor = "";
                    cCardName_Productor = "";
                    cCardCode_Cliente = "";
                    cCardName_Cliente = "";

                    int nDocEntryCierre;

                    nDocEntryCierre = 0;

                    mensaje1 = clsOrdenFabricacion.Entrada_Mercaderia_TR1(cDocDate, int.Parse(cDocNum), nMax_Linea, nCant_x_Cerrar, cAlmacen, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, 0, "", UsuarioSap, ClaveSap);

                    try
                    {
                        nDocEntryCierre = int.Parse(mensaje1);
                    }
                    catch
                    {
                        nDocEntryCierre = -1;
                        MessageBox.Show("Error en la generación del Termination Report :::::: " + mensaje1 + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (nDocEntryCierre > 0)
                    {
                        mensaje1 = "";

                    }
                    
                }

            }

            if (mensaje1 == "")
            {
                String mensaje2 = clsOrdenFabricacion.Production_Orders_Cerrar(cDocNum, UsuarioSap, ClaveSap);

                MessageBox.Show("Orden Cerrada Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }


        }

        private void carga_detalles()
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

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Detalle_TR(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cLine, cItemCode, cItemName;
            string cDocEntry, cLote;
            string cUM, cBodega;

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

                grilla[0] = cDocEntry;
                grilla[1] = dFecha.ToString("dd/MM/yyyy");
                grilla[2] = cLote;
                grilla[3] = cItemCode;
                grilla[4] = cItemName;
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = nCantidad_TR.ToString("N2");
                grilla[8] = nid_calidad.ToString();

                try
                {
                    grilla[9] = dTable.Rows[i]["Codigo_CSG"].ToString();
                }
                catch
                {
                    grilla[9] = "";
                }

                Grid4.Rows.Add(grilla);

            }

        }

        private void carga_detalles_consumos()
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

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Detalle_Consumos(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cLine, cItemCode, cItemName;
            string cDocEntry, cLote;
            string cUM, cBodega;
            double nCantidad_TR;
            DateTime dFecha;

            Grid5.Rows.Clear();

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

                grilla[0] = cDocEntry;
                grilla[1] = dFecha.ToString("dd/MM/yyyy");
                grilla[2] = cLote;
                grilla[3] = cItemCode;
                grilla[4] = cItemName;
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = nCantidad_TR.ToString("N2");

                try
                {
                    grilla[8] = dTable.Rows[i]["Codigo_CSG"].ToString();
                }
                catch
                {
                    grilla[8] = "";
                }

                Grid5.Rows.Add(grilla);

            }


        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            int nDocEntry;

            if (Grid4.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

            try
            {
                fila = Grid4.CurrentCell.RowIndex;

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

            try
            {
                nDocEntry = int.Parse(Grid4[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }


            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            VariablesGlobales.glb_Object = "";
            VariablesGlobales.glb_Lote = 0;

            frmReporteProduccion f2 = new frmReporteProduccion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }

        private void btn_exportar_excel_Click(object sender, EventArgs e)
        {

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                
                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Num. OF:";
                oSheet.Cells[1, 2] = t_DocNum.Text;

                oSheet.Cells[2, 1] = "Producto:";
                oSheet.Cells[2, 2] = t_itemname.Text;

                oSheet.Cells[3, 1] = "Tipo Fruta:";
                oSheet.Cells[3, 2] = t_tipofruta.Text;

                oSheet.Cells[4, 1] = "Proceso:";
                oSheet.Cells[4, 2] = t_proceso.Text;

                oSheet.Cells[5, 1] = "Almacen:";
                oSheet.Cells[5, 2] = t_almacen.Text;

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("b1", "b5").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int nLinea;

                nLinea = 7;
                //Add table headers going cell by cell.
                oSheet.Cells[7, 2] = "Nro";
                oSheet.Cells[7, 3] = "Descripción";
                oSheet.Cells[7, 4] = "UM";
                oSheet.Cells[7, 5] = "Almacén";
                oSheet.Cells[7, 6] = "Cant.Recibos de Producción";
                oSheet.Cells[7, 7] = "Cant.Emisiones de Producción";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("b7", "g7").Font.Bold = true;
                oSheet.get_Range("b7", "g7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    oSheet.Cells[8 + i, 2] = Grid1[2, i].Value.ToString();
                    oSheet.Cells[8 + i, 3] = Grid1[3, i].Value.ToString();
                    oSheet.Cells[8 + i, 4] = Grid1[4, i].Value.ToString();
                    oSheet.Cells[8 + i, 5] = Grid1[5, i].Value.ToString();
                    oSheet.Cells[8 + i, 6] = Grid1[6, i].Value.ToString();
                    oSheet.Cells[8 + i, 7] = Grid1[7, i].Value.ToString();

                    nLinea = 8 + i;

                }

                nLinea += 2;

                oSheet.Cells[nLinea, 2] = "Recibos de Producción";

                oSheet.get_Range("b"+ nLinea, "b"+ nLinea).Font.Bold = true;
                oSheet.get_Range("b" + nLinea, "b" + nLinea).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                nLinea += 2;

                oSheet.Cells[nLinea, 1] = "Lote";
                oSheet.Cells[nLinea, 2] = "Nro";
                oSheet.Cells[nLinea, 3] = "Descripción";
                oSheet.Cells[nLinea, 4] = "UM";
                oSheet.Cells[nLinea, 5] = "Almacén";
                oSheet.Cells[nLinea, 6] = "Cantidad";
                oSheet.Cells[nLinea, 7] = "Fecha";

                oSheet.get_Range("a" + nLinea, "g" + nLinea).Font.Bold = true;
                oSheet.get_Range("a" + nLinea, "g" + nLinea).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                nLinea += 1;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("b7", "f7").Font.Bold = true;
                //oSheet.get_Range("b7", "f7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid4.RowCount - 1; i++)
                {

                    oSheet.Cells[nLinea , 1] = Grid4[2, i].Value.ToString();
                    oSheet.Cells[nLinea , 2] = Grid4[3, i].Value.ToString();
                    oSheet.Cells[nLinea , 3] = Grid4[4, i].Value.ToString();
                    oSheet.Cells[nLinea , 4] = Grid4[5, i].Value.ToString();
                    oSheet.Cells[nLinea , 5] = Grid4[6, i].Value.ToString();
                    oSheet.Cells[nLinea , 6] = Grid4[7, i].Value.ToString();
                    oSheet.Cells[nLinea , 7] = Grid4[1, i].Value.ToString();

                    nLinea += 1;

                }

                nLinea += 2;

                oSheet.Cells[nLinea, 2] = "Consumos";

                oSheet.get_Range("b" + nLinea, "b" + nLinea).Font.Bold = true;
                oSheet.get_Range("b" + nLinea, "b" + nLinea).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                nLinea += 2;

                oSheet.Cells[nLinea, 1] = "Lote";
                oSheet.Cells[nLinea, 2] = "Nro";
                oSheet.Cells[nLinea, 3] = "Descripción";
                oSheet.Cells[nLinea, 4] = "UM";
                oSheet.Cells[nLinea, 5] = "Almacén";
                oSheet.Cells[nLinea, 6] = "Cantidad";
                oSheet.Cells[nLinea, 7] = "Fecha";

                oSheet.get_Range("a" + nLinea, "g" + nLinea).Font.Bold = true;
                oSheet.get_Range("a" + nLinea, "g" + nLinea).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                nLinea += 1;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("b7", "f7").Font.Bold = true;
                //oSheet.get_Range("b7", "f7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid5.RowCount - 1; i++)
                {

                    oSheet.Cells[nLinea , 1] = Grid5[2, i].Value.ToString();
                    oSheet.Cells[nLinea , 2] = Grid5[3, i].Value.ToString();
                    oSheet.Cells[nLinea , 3] = Grid5[4, i].Value.ToString();
                    oSheet.Cells[nLinea , 4] = Grid5[5, i].Value.ToString();
                    oSheet.Cells[nLinea , 5] = Grid5[6, i].Value.ToString();
                    oSheet.Cells[nLinea , 6] = Grid5[7, i].Value.ToString();
                    oSheet.Cells[nLinea , 7] = Grid5[1, i].Value.ToString();

                    nLinea += 1;

                }

                // -- Fill C2:C6 with a relative formula (=A2 & " " & B2).
                //oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";

                // -- Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "g1");
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                //DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void btn_registro_inspeccion_Click(object sender, EventArgs e)
        {

            if (Grid4.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad; //, nCantidadRegistros;

            //nCantidadRegistros = 0;

            string cItemCode;

            try
            {
                fila = Grid4.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            //nCantidadRegistros = 0;
            cItemCode = "";

            try
            {
                id_Recepcion = int.Parse(Grid4[0, fila].Value.ToString());
            }
            catch
            {
                id_Recepcion = 0;
            }

            try
            {
                id_NumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                id_NumOF = 0;
            }

            try
            {
                nLote = int.Parse(Grid4[2, fila].Value.ToString());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                nIdCalidad = int.Parse(Grid4[8, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                cItemCode = Grid4[3, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                //VariablesGlobales.glb_id_calidad = 0;

                if (VariablesGlobales.glb_id_calidad == 0)
                {
                   

                }
                else
                {
                    string cModeloFrm;

                    cModeloFrm = "";

                    clsCalidad objproducto = new clsCalidad();
                    objproducto.cls_Consulta_Registro_Inspeccion(nIdCalidad);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        cModeloFrm = dTable.Rows[0]["ModeloFrm"].ToString();
                    }
                    catch
                    {
                        cModeloFrm = "";
                    }

                    if (cModeloFrm == "OLD")
                    {
                        frmCalidadPP4 fv1 = new frmCalidadPP4();
                        DialogResult res1 = fv1.ShowDialog();

                    }
                    else
                    {
                        frmCalidadPPA6 fv2 = new frmCalidadPPA6();
                        DialogResult res2 = fv2.ShowDialog();

                    }

                }

            }

        }

    }

}
