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
    public partial class frmInforme1 : Form
    {
        public frmInforme1()
        {
            InitializeComponent();
        }

        private void frmInforme1_Load(object sender, EventArgs e)
        {
            cbb_mes.SelectedIndex = 0;
            cbb_anho.SelectedIndex = 0;

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void carga_grilla()
        {
            string cMes, cPeriodo;
            DateTime dFechaCreacion;

            if (cbb_mes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un mes válido, opción Cancelada", "Informe de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cMes = "";

            if (cbb_mes.SelectedIndex+1 <10)
            {
                cMes = "0" + (cbb_mes.SelectedIndex + 1).ToString();
            }
            else
            {
                cMes = (cbb_mes.SelectedIndex + 1).ToString();
            }

            if (cbb_anho.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un año válido, opción Cancelada", "Informe de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cPeriodo = cbb_anho.Text + cMes;

            if (cPeriodo == "")
            {
                MessageBox.Show("Debe seleccionar un periodo válido, opción Cancelada", "Informe de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DateTime dFechaValidacion, dFechaDespacho;
            int nUltimoDia;
            double nDia28, nDia29, nDia30, nDia31;

            nUltimoDia = 0;

            dFechaValidacion = Convert.ToDateTime("01/" + cMes + "/" + cbb_anho.Text);

            dFechaValidacion = dFechaValidacion.AddMonths(1);
            dFechaValidacion = dFechaValidacion.AddDays(-1);

            nUltimoDia = Convert.ToInt32(dFechaValidacion.Day.ToString());

            try
            {

                double nQuantity;
                string cVariable;

                clsMaestros objproducto = new clsMaestros();

                objproducto.cls_Consultar_utiles_informediariostock(cPeriodo);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[50];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    for (int x = 0; x <= 40; x++)
                    {
                        grilla[x] = "";

                    }

                    try
                    {
                        grilla[0] = dTable.Rows[i]["NoLote"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["itemName"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_Calibre"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["U_HDV_COLOR"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[6] = dTable.Rows[i]["MnfSerial"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[7] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[8] = dTable.Rows[i]["LotNumber"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[9] = dTable.Rows[i]["U_NOMBCLI"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        dFechaCreacion = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFechaCreacion = Convert.ToDateTime("01/01/1900");
                    }

                    try
                    {
                        dFechaDespacho = Convert.ToDateTime(dTable.Rows[i]["Fecha_UltimoDespacho"].ToString());
                    }
                    catch
                    {
                        dFechaDespacho = Convert.ToDateTime("01/01/1900");
                    }

                    try
                    {
                        grilla[10] = dFechaCreacion.ToString("dd/MM/yyyy");
                    }
                    catch
                    {

                    }

                    try
                    {
                        grilla[11] = dTable.Rows[i]["SalUnitMsr"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["SWeight1"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    grilla[12] = nQuantity.ToString("N2");


                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["DiasStock"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    grilla[13] = nQuantity.ToString("N2");

                    for (int y = 1; y <= 31; y++)
                    {
                        if (y < 10)
                        {
                            cVariable = "inv_0" + y;
                        }
                        else
                        {
                            cVariable = "inv_" + y;
                        }

                        try
                        {
                            nQuantity = double.Parse(dTable.Rows[i][cVariable].ToString());
                        }
                        catch
                        {
                            nQuantity = 0;
                        }

                        grilla[13 + y] = nQuantity.ToString("N2");

                    }

                    nDia28 = Convert.ToDouble(grilla[41]);
                    nDia29 = Convert.ToDouble(grilla[42]);
                    nDia30 = Convert.ToDouble(grilla[43]);
                    nDia31 = Convert.ToDouble(grilla[44]);

                    grilla[45] = dFechaDespacho.ToString("dd/MM/yyyy");

                    if (nUltimoDia == 28)
                        if (nDia28 > 0)
                        {
                            grilla[45] = "";
                        }

                    if (nUltimoDia == 29)
                        if (nDia29 > 0)
                        {
                            grilla[45] = "";
                        }

                    if (nUltimoDia == 30)
                        if (nDia30 > 0)
                        {
                            grilla[45] = "";
                        }

                    if (nUltimoDia == 31)
                        if (nDia31 > 0)
                        {
                            grilla[45] = "";
                        }


                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                oSheet.get_Range("a1", "ar1").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int nLinea;

                nLinea = 1;
                //Add table headers going cell by cell.

                for (int x = 0; x <= 44; x++)
                {

                    oSheet.Cells[nLinea, x + 1] = Grid1.Columns[x].HeaderText;

                }

                nLinea += 1;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("a2", "g7").Font.Bold = true;
                //oSheet.get_Range("b7", "g7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    for (int y = 0; y <= 44; y++)
                    {
                        oSheet.Cells[nLinea, y + 1] = Grid1[y, i].Value.ToString();

                    }

                    nLinea += 1;

                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("a2", "as" + nLinea);
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
