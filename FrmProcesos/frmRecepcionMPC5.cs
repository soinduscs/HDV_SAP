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
using System.Drawing.Printing;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace FrmProcesos
{
    public partial class frmRecepcionMPC5 : Form
    {
        public frmRecepcionMPC5()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPC5_Load(object sender, EventArgs e)
        {

            cbb_seleccionar_impresora.Items.Clear();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                try
                {
                    cbb_seleccionar_impresora.Items.Add(strPrinter);
                }
                catch
                {

                }

            }

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

                string cfecha1, cfecha2, cWhsCode;
                string CNumOV;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_entradas_bodegaje(cfecha1, cfecha2, "");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry, nNumGuia, nLinea;
                string cFechaCreacion, cItemCode;
                string cProveedor, cInsumo, cNumOC;
                string cLote, cLoteProveedor;
                double nCant_Ingresada, nCant_Stock;

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
                        nNumGuia = int.Parse(dTable.Rows[i]["FolioNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;
                    }

                    try
                    {
                        nLinea = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                    }
                    catch
                    {
                        nLinea = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaCreacion = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        cProveedor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProveedor = "";
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
                        cInsumo = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cInsumo = "";
                    }

                    try
                    {
                        nCant_Ingresada = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString()));
                    }
                    catch
                    {
                        nCant_Ingresada = 0;
                    }

                    try
                    {
                        nCant_Stock = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["Stock"].ToString()));
                    }
                    catch
                    {
                        nCant_Stock = 0;
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
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
                        cLoteProveedor = dTable.Rows[i]["U_FolioPallet"].ToString();
                    }
                    catch
                    {
                        cLoteProveedor = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        CNumOV = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                    }
                    catch
                    {
                        CNumOV = "";
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nLinea.ToString("N");
                    grilla[2] = nNumGuia.ToString();
                    grilla[3] = cFechaCreacion;
                    grilla[4] = cProveedor;
                    grilla[5] = cNumOC;
                    grilla[6] = cLote;
                    grilla[7] = cLoteProveedor;
                    grilla[8] = CNumOV;
                    grilla[9] = cItemCode;
                    grilla[10] = cInsumo;
                    grilla[11] = nCant_Ingresada.ToString("N");
                    grilla[12] = nCant_Stock.ToString("N");
                    grilla[13] = nDocEntry.ToString();
                    grilla[14] = cWhsCode;

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

        private void btn_actualizar1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ingresar_mp_Click(object sender, EventArgs e)
        {

            frmRecepcionMPC6 f2 = new frmRecepcionMPC6();
            DialogResult res = f2.ShowDialog();

            carga_grilla1();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_actualizar1_Click_1(object sender, EventArgs e)
        {
            carga_grilla2();
        }

        private void carga_grilla2()
        {

            try
            {
                DateTime dfecha;

                string cNumero, cWhsCode;

                cNumero = t_numero.Text; 

                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_entradas_bodegaje("", "", cNumero);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry, nNumGuia, nLinea;
                string cFechaCreacion, cItemCode;
                string cProveedor, cInsumo, cNumOC;
                string cLote, cLoteProveedor;
                double nCant_Ingresada, nCant_Stock;

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
                        nNumGuia = int.Parse(dTable.Rows[i]["FolioNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;
                    }

                    try
                    {
                        nLinea = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                    }
                    catch
                    {
                        nLinea = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaCreacion = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        cProveedor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProveedor = "";
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
                        cInsumo = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cInsumo = "";
                    }

                    try
                    {
                        nCant_Ingresada = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString()));
                    }
                    catch
                    {
                        nCant_Ingresada = 0;
                    }

                    try
                    {
                        nCant_Stock = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["Stock"].ToString()));
                    }
                    catch
                    {
                        nCant_Stock = 0;
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
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
                        cLoteProveedor = dTable.Rows[i]["U_FolioPallet"].ToString();
                    }
                    catch
                    {
                        cLoteProveedor = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nLinea.ToString("N");
                    grilla[2] = nNumGuia.ToString();
                    grilla[3] = cFechaCreacion;
                    grilla[4] = cProveedor;
                    grilla[5] = cNumOC;
                    grilla[6] = cLote;
                    grilla[7] = cLoteProveedor;
                    grilla[8] = "20R30";
                    grilla[9] = cItemCode;
                    grilla[10] = cInsumo;
                    grilla[11] = nCant_Ingresada.ToString("N");
                    grilla[12] = nCant_Stock.ToString("N");
                    grilla[13] = nDocEntry.ToString();
                    grilla[14] = cWhsCode;

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

                int nLinea;
                double nValor;
                DateTime dFecha;

                nLinea = 1;
                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Número de Guía";
                oSheet.Cells[1, 2] = "Fecha Recepción";
                oSheet.Cells[1, 3] = "Cliente";
                oSheet.Cells[1, 4] = "Orden Compra";
                oSheet.Cells[1, 5] = "Lote Cliente";
                oSheet.Cells[1, 6] = "Num. Orden de Venta";
                oSheet.Cells[1, 7] = "Producto";
                oSheet.Cells[1, 8] = "Cantidad";
                oSheet.Cells[1, 9] = "Stock Actual";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "i1").Font.Bold = true;
                oSheet.get_Range("a1", "i1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    oSheet.Cells[2 + i, 1] = Grid1[2, i].Value.ToString();
                    
                    try
                    {
                        dFecha = Convert.ToDateTime(Grid1[3, i].Value.ToString());

                    }
                    catch
                    {
                        dFecha = DateTime.Now;
                    }

                    oSheet.Cells[2 + i, 2] = dFecha;
                    oSheet.Cells[2 + i, 3] = Grid1[4, i].Value.ToString();
                    oSheet.Cells[2 + i, 4] = Grid1[5, i].Value.ToString();
                    oSheet.Cells[2 + i, 5] = Grid1[7, i].Value.ToString();
                    oSheet.Cells[2 + i, 6] = Grid1[8, i].Value.ToString();
                    oSheet.Cells[2 + i, 7] = Grid1[10, i].Value.ToString();

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[11, i].Value.ToString()); 
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    oSheet.Cells[2 + i, 8] = nValor;

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[12, i].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    oSheet.Cells[2 + i, 9] = nValor;

                    nLinea = 2+i;
                }

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

    }

}
