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
    public partial class frmOrdenFabricacionINS1 : Form
    {
        public frmOrdenFabricacionINS1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionINS1_Load(object sender, EventArgs e)
        {
            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1.Value;

                string cfecha1, cfecha2;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_DeclaracionInsumos(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry;
                double nCantidad;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        grilla[2] = dTable.Rows[i]["U_AreaName"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_TurnoName"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["Nombre_Empleado"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        nCantidad = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["Cant_Items"].ToString()));
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    grilla[5] = nCantidad.ToString("N");

                    try
                    {
                        grilla[6] = dTable.Rows[i]["Status_Name"].ToString();
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[7] = dTable.Rows[i]["Nombre_Autorizador"].ToString();
                    }
                    catch
                    {
                        grilla[7] = "";
                    }                   

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_ingresar_di_Click(object sender, EventArgs e)
        {

            string declaracion_mermas, autorizacion_mermas;

            declaracion_mermas = "";
            autorizacion_mermas = "";

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                declaracion_mermas = dTable.Rows[0]["Declarar_Mermas"].ToString();
            }
            catch
            {
                declaracion_mermas = "";
            }

            try
            {
                autorizacion_mermas = dTable.Rows[0]["Autorizar_Mermas"].ToString();
            }
            catch
            {
                autorizacion_mermas = "";
            }

            if (declaracion_mermas != "SI")
            {
                MessageBox.Show("No tiene los permisos suficientes para realizar esta actividad, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = 0;

            frmOrdenFabricacionINS f2 = new frmOrdenFabricacionINS();
            DialogResult res = f2.ShowDialog();

            carga_grilla1();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            string declaracion_mermas, autorizacion_mermas;

            declaracion_mermas = "";
            autorizacion_mermas = "";

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                declaracion_mermas = dTable.Rows[0]["Declarar_Mermas"].ToString();
            }
            catch
            {
                declaracion_mermas = "";
            }

            try
            {
                autorizacion_mermas = dTable.Rows[0]["Autorizar_Mermas"].ToString();
            }
            catch
            {
                autorizacion_mermas = "";
            }

            if (declaracion_mermas != "SI")
            {
                MessageBox.Show("No tiene los permisos suficientes para realizar esta actividad, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fil, nDocEntry;

            fil = 0;

            nDocEntry = -1;

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
                nDocEntry = Convert.ToInt32(Grid1[0, fil].Value.ToString());
            }
            catch
            {
                nDocEntry = -1;
            }

            if (nDocEntry == -1)
            {
                MessageBox.Show("Debe seleccionar una línea válida, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            frmOrdenFabricacionINS f2 = new frmOrdenFabricacionINS();
            DialogResult res = f2.ShowDialog();

            carga_grilla1();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_exportar_excel_Click(object sender, EventArgs e)
        {

            Grid2.Rows.Clear();

            carga_grilla1();

            int nDocEntry;
            string cFecha, cArea, cTurno;
            string cResponsable, cEstado;

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {
                nDocEntry = 0;

                try
                {
                    nDocEntry = Convert.ToInt32(Grid1[0, j].Value.ToString());
                }
                catch
                {
                    nDocEntry = -1;
                }

                try
                {
                    cFecha = Grid1[1, j].Value.ToString();
                }
                catch
                {
                    cFecha = "";
                }

                try
                {
                    cArea = Grid1[2, j].Value.ToString();
                }
                catch
                {
                    cArea = "";
                }

                try
                {
                    cTurno = Grid1[3, j].Value.ToString();
                }
                catch
                {
                    cTurno = "";
                }

                try
                {
                    cResponsable = Grid1[4, j].Value.ToString();
                }
                catch
                {
                    cResponsable = "";
                }

                try
                {
                    cEstado = Grid1[6, j].Value.ToString();
                }
                catch
                {
                    cEstado = "";
                }

                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                // Detalle de Insumos

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_DeclaracionInsumos_x_DocEntry(nDocEntry);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                string cItemCode_D, cItemName_D, cWareHouse_D;
                string cDimension1, cDimension2, cDimension3;
                string cDimension1_ige1, cDimension2_ige1, cDimension3_ige1;
                string cNota_D, cUMed;

                double nCantidad_D;

                int nNumOF, nLote, nDocEntryRef, nDocEntrySalida;
                int Number_ojdt;

                DateTime dFecha_Salida, dFecha_Documento;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        dFecha_Documento = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFecha_Documento = Convert.ToDateTime("01/01/1900");
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

                        grilla[0] = nDocEntry.ToString();
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
                            grilla[19] = dFecha_Salida.ToString("MM/dd/yyyy");

                        }

                        grilla[20] = "";

                        if (Number_ojdt > 0)
                        {
                            grilla[20] = Number_ojdt.ToString();

                        }

                        grilla[21] = cDimension1_ige1;
                        grilla[22] = cDimension2_ige1;
                        grilla[23] = cDimension3_ige1;

                        grilla[24] = dFecha_Documento.ToString("MM/dd/yyyy");
                        grilla[25] = cArea;
                        grilla[26] = cTurno;
                        grilla[27] = cResponsable;
                        grilla[28] = cEstado;

                        Grid2.Rows.Add(grilla);

                    }

                }

            }

            ////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // Exportar Excel

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

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "s1").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Fecha";
                oSheet.Cells[1, 2] = "Área";
                oSheet.Cells[1, 3] = "Turno";
                oSheet.Cells[1, 4] = "Responsable";
                oSheet.Cells[1, 5] = "Estado";
                oSheet.Cells[1, 6] = "Código";
                oSheet.Cells[1, 7] = "Descripción";
                oSheet.Cells[1, 8] = "U.Med";
                oSheet.Cells[1, 9] = "Lote";
                oSheet.Cells[1, 10] = "Num. OF";
                oSheet.Cells[1, 11] = "Cantidad";
                oSheet.Cells[1, 12] = "Almacen";
                oSheet.Cells[1, 13] = "Dimensión 1";
                oSheet.Cells[1, 14] = "Dimensión 2";
                oSheet.Cells[1, 15] = "Dimensión 3";
                oSheet.Cells[1, 16] = "Nota";
                oSheet.Cells[1, 17] = "Salida Mercancía";
                oSheet.Cells[1, 18] = "Fecha Proceso";
                oSheet.Cells[1, 19] = "Registro en el diario";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "s1").Font.Bold = true;
                oSheet.get_Range("a1", "s1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid2.RowCount - 1; i++)
                {

                    oSheet.Cells[2 + i, 1] = Grid2[24, i].Value.ToString();
                    oSheet.Cells[2 + i, 2] = Grid2[25, i].Value.ToString();
                    oSheet.Cells[2 + i, 3] = Grid2[26, i].Value.ToString();
                    oSheet.Cells[2 + i, 4] = Grid2[27, i].Value.ToString();
                    oSheet.Cells[2 + i, 5] = Grid2[28, i].Value.ToString();
                    oSheet.Cells[2 + i, 6] = Grid2[1, i].Value.ToString();

                    oSheet.Cells[2 + i, 7] = Grid2[2, i].Value.ToString();
                    oSheet.Cells[2 + i, 8] = Grid2[3, i].Value.ToString();
                    oSheet.Cells[2 + i, 9] = Grid2[4, i].Value.ToString();
                    oSheet.Cells[2 + i, 10] = Grid2[5, i].Value.ToString();
                    oSheet.Cells[2 + i, 11] = Grid2[6, i].Value.ToString();
                    oSheet.Cells[2 + i, 12] = Grid2[7, i].Value.ToString();
                    oSheet.Cells[2 + i, 13] = Grid2[8, i].Value.ToString();
                    oSheet.Cells[2 + i, 14] = Grid2[15, i].Value.ToString();
                    oSheet.Cells[2 + i, 15] = Grid2[16, i].Value.ToString();
                    oSheet.Cells[2 + i, 16] = Grid2[9, i].Value.ToString();
                    oSheet.Cells[2 + i, 17] = Grid2[18, i].Value.ToString();
                    oSheet.Cells[2 + i, 18] = Grid2[19, i].Value.ToString();
                    oSheet.Cells[2 + i, 19] = Grid2[20, i].Value.ToString();

                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "s1");
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





    }

}
