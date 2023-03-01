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
    public partial class frmRecepcionMPC4 : Form
    {
        public frmRecepcionMPC4()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPC4_Load(object sender, EventArgs e)
        {

            int nAnho;

            nAnho = Convert.ToInt32(DateTime.Today.Year);

            cbb_anho.Items.Add((nAnho - 2).ToString());
            cbb_anho.Items.Add((nAnho - 1).ToString());
            cbb_anho.Items.Add((nAnho).ToString());
            cbb_anho.Items.Add((nAnho + 1).ToString());
            cbb_anho.Items.Add((nAnho + 2).ToString());

            cbb_anho.SelectedIndex = 2;

        }

        private void carga_grilla1()
        {

            try
            {
                DateTime dFecha;

                int nTotBins;

                double nTotKilos;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lotes_mp_pelon_dys();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["Fecha_Porteria"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[1] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[1] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["Fecha_Romana"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[2] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[2] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["fecha_Hora_recepcion"].ToString()); 
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[3] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[3] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["Tipo_Cosecha"].ToString();
                    }
                    catch
                    {
                        grilla[5] = "";
                    }

                    try
                    {
                        grilla[6] = dTable.Rows[i]["StatusLote"].ToString();
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[7] = dTable.Rows[i]["ItemCodeBins"].ToString();
                    }
                    catch
                    {
                        grilla[7] = "";
                    }

                    try
                    {
                        grilla[8] = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        grilla[8] = "";
                    }

                    try
                    {
                        nTotBins = Convert.ToInt32(dTable.Rows[i]["Bins"].ToString());
                    }
                    catch
                    {
                        nTotBins = 0;
                    }

                    grilla[9] = nTotBins.ToString("N");

                    try
                    {
                        nTotKilos = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nTotKilos = 0;
                    }

                    grilla[10] = nTotKilos.ToString("N");

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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

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

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int nLinea;

                nLinea = 1;

                oSheet.get_Range("a1", "a1").Font.Size = 16;
                oSheet.get_Range("a1", "a1").Font.Bold = true;
                oSheet.Cells[nLinea, 1] = "Informe de Lotes de D&S Disponibles";

                oSheet.get_Range("a3", "i3").Font.Bold = true;
                oSheet.get_Range("a3", "i3").Font.Bold = true;

                nLinea = 3;

                oSheet.get_Range("a" + nLinea, "i" + nLinea).Font.Bold = true;

                for (int i = 0; i <= Grid1.ColumnCount - 1; i++)
                {
                    oSheet.Cells[nLinea, i+1] = Grid1.Columns[i].HeaderText;
                }

                nLinea += 1;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("a2", "g7").Font.Bold = true;
                //oSheet.get_Range("b7", "g7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    for (int x = 0; x <= Grid1.ColumnCount - 1; x++)
                    {
                        oSheet.Cells[nLinea, x + 1] = Grid1[x, i].Value.ToString(); // Grid1.Columns[x].HeaderText;

                    }

                    nLinea += 1;

                }

                oSheet.get_Range("b1", "i" + nLinea).Font.Size = 10;
                oRng = oSheet.get_Range("b1", "i" + nLinea);
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

        private void button1_Click(object sender, EventArgs e)
        {
            carga_grilla2();

        }

        private void carga_grilla2()
        {

            try
            {
                string c_anho;

                try
                {
                    c_anho = cbb_anho.Text;
                }
                catch
                {
                    c_anho = "2022";
                }

                DateTime dFecha;

                int nTotBins;

                double nTotKilos;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lotes_mp_pelon_dys1(c_anho);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["FolioNum"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["Fecha_Porteria"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[2] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[2] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["Fecha_Romana"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[3] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[3] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["fecha_Hora_recepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;

                    }

                    grilla[4] = "";

                    if (dFecha.Year != 1900)
                    {
                        grilla[4] = dFecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        grilla[5] = "";
                    }

                    try
                    {
                        grilla[6] = dTable.Rows[i]["U_Tipo_Cosecha"].ToString();
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[7] = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        grilla[7] = "";
                    }

                    try
                    {
                        grilla[8] = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        grilla[8] = "";
                    }

                    try
                    {
                        nTotBins = Convert.ToInt32(dTable.Rows[i]["U_BINS"].ToString());
                    }
                    catch
                    {
                        nTotBins = 0;
                    }

                    grilla[9] = nTotBins.ToString();

                    try
                    {
                        nTotKilos = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nTotKilos = 0;
                    }

                    grilla[10] = nTotKilos.ToString("N");

                    try
                    {
                        nTotKilos = Convert.ToDouble(dTable.Rows[i]["es_Stock"].ToString());
                    }
                    catch
                    {
                        nTotKilos = 0;
                    }

                    grilla[11] = nTotKilos.ToString("N");

                    try
                    {
                        grilla[12] = dTable.Rows[i]["orden_consumo"].ToString();

                    }
                    catch
                    {
                        grilla[12] = "";

                    }

                    Grid2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }




    }

}
