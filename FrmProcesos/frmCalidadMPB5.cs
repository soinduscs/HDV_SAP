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
using Excel = Microsoft.Office.Interop.Excel;

namespace FrmProcesos
{
    public partial class frmCalidadMPB5 : Form
    {
        public frmCalidadMPB5()
        {
            InitializeComponent();
        }

        private void frmCalidadMPB5_Load(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

                t_cardcode.Focus();

            }

        }

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            string cCardCode;

            cCardCode = "";

            try
            {
                cCardCode = t_cardcode.Text;
            }
            catch
            {
                cCardCode = "";
            }

            carga_grilla_consumo(cCardCode);

            Application.DoEvents();

            carga_grilla_recibos(cCardCode);

            Application.DoEvents();

            carga_grilla_datos_excel();


        }

        private void carga_grilla_consumo(string cCardCode)
        {

            try
            {

                string cDocEntry, cNumGuia, cLote;
                string cVariedad;

                DateTime dFecha;

                int nCantBins;
                double nConsumo;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_utiles_resumendespelonado(cCardCode,"I",2020);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["numof"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cNumGuia = dTable.Rows[i]["FolioNum"].ToString();

                    }
                    catch
                    {
                        cNumGuia = "";
                    }

                    try
                    {
                        cLote = dTable.Rows[i]["lote"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        nCantBins = Convert.ToInt32(dTable.Rows[i]["CantidadBins"].ToString());
                    }
                    catch
                    {
                        nCantBins = 0;
                    }

                    try
                    {
                        nConsumo = Convert.ToDouble(dTable.Rows[i]["consumos"].ToString());
                    }
                    catch
                    {
                        nConsumo = 0;
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["Variedad"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }
                   
                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cNumGuia.ToString();
                    grilla[2] = cLote.ToString();
                    grilla[3] = dFecha.ToString("dd/MM/yyyy");
                    grilla[4] = nCantBins.ToString();
                    grilla[5] = nConsumo.ToString("N2");                    
                    grilla[6] = cVariedad;

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla_recibos(string cCardCode)
        {

            try
            {

                string cDocEntry, cLote, cVariedad;

                DateTime dFecha;

                int nCantBins;
                double nRecibos, nRendimiento;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_utiles_resumendespelonado(cCardCode, "E",2020);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["numof"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cLote = dTable.Rows[i]["lote"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }


                    try
                    {
                        nCantBins = Convert.ToInt32(dTable.Rows[i]["U_BINS"].ToString());
                    }
                    catch
                    {
                        nCantBins = 0;
                    }

                    try
                    {
                        nRecibos = Convert.ToDouble(dTable.Rows[i]["recibos"].ToString());
                    }
                    catch
                    {
                        nRecibos = 0;
                    }


                    try
                    {
                        nRendimiento = Convert.ToDouble(dTable.Rows[i]["rendimiento"].ToString());
                    }
                    catch
                    {
                        nRendimiento = 0;
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["Variedad"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }
                   
                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cLote.ToString();
                    grilla[2] = dFecha.ToString("dd/MM/yyyy");
                    grilla[3] = nCantBins.ToString();
                    grilla[4] = nRecibos.ToString("N2");
                    grilla[5] = nRendimiento.ToString("N2");
                    grilla[6] = cVariedad;

                    Grid2.Rows.Add(grilla);

                    try
                    {
                        t_variedad_pt.Text = dTable.Rows[i]["Variedad"].ToString();

                    }
                    catch
                    {

                    } 
                   

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla_datos_excel()
        {

            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cDocEntry, cDocEntry_f, cAgregar;
            int nItems, nConsumo, nRecibos;

            try
            {

                for (int i = 0; i <= Grid1.Rows.Count; i++)
                {

                    try
                    {
                        cDocEntry = Grid1[0, i].Value.ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    cAgregar = "S";

                    for (int x = 0; x <= Grid3.Rows.Count; x++)
                    {

                        try
                        {
                            cDocEntry_f = Grid3[0, x].Value.ToString();
                        }
                        catch
                        {
                            cDocEntry_f = "";

                        }

                        if (cDocEntry == cDocEntry_f)
                        {
                            cAgregar = "N";
                            break;

                        }

                    }

                    if (cAgregar == "S")
                    {
                        grilla[0] = cDocEntry.ToString();
                        grilla[1] = "0";
                        grilla[2] = "0";

                        Grid3.Rows.Add(grilla);

                    }

                }

                for (int x = 0; x <= Grid3.Rows.Count-1; x++)
                {

                    try
                    {
                        cDocEntry_f = Grid3[0, x].Value.ToString();
                    }
                    catch
                    {
                        cDocEntry_f = "";

                    }

                    nItems = 0;

                    for (int i = 0; i <= Grid1.Rows.Count; i++)
                    {

                        try
                        {
                            cDocEntry = Grid1[0, i].Value.ToString();
                        }
                        catch
                        {
                            cDocEntry = "";

                        }

                        if (cDocEntry == cDocEntry_f)
                        {
                            nItems += 1;

                        }

                    }

                    Grid3[1, x].Value = nItems.ToString();

                    nItems = 0;

                    for (int i = 0; i <= Grid2.Rows.Count; i++)
                    {

                        try
                        {
                            cDocEntry = Grid2[0, i].Value.ToString();
                        }
                        catch
                        {
                            cDocEntry = "";

                        }

                        if (cDocEntry == cDocEntry_f)
                        {
                            nItems += 1;

                        }

                    }

                    Grid3[2, x].Value = nItems.ToString();

                }

                for (int i = 0; i <= Grid3.Rows.Count-1; i++)
                {

                    try
                    {
                        cDocEntry = Grid3[0, i].Value.ToString();

                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        nConsumo = Convert.ToInt32(Grid3[1, i].Value.ToString());

                    }
                    catch
                    {
                        nConsumo = 0;

                    }

                    try
                    {
                        nRecibos = Convert.ToInt32(Grid3[2, i].Value.ToString());

                    }
                    catch
                    {
                        nRecibos = 0;

                    }

                    if (nConsumo >= nRecibos)
                    {
                        nItems = nConsumo;

                    }
                    else
                    {
                        nItems = nRecibos;

                    }

                    Grid3[3, i].Value = nItems.ToString();

                }

                int nLineID;

                nLineID = 0;

                for (int i = 0; i <= Grid3.Rows.Count-1; i++)
                {

                    try
                    {
                        cDocEntry = Grid3[0, i].Value.ToString();

                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        nItems = Convert.ToInt32(Grid3[3, i].Value.ToString());

                    }
                    catch
                    {
                        nItems = 0;

                    }

                    Grid3[4, i].Value = nLineID.ToString();

                    for (int x = 0; x <= nItems; x++)
                    {

                        grilla[0] = cDocEntry.ToString();
                        grilla[1] = "";
                        grilla[2] = "";

                        Grid4.Rows.Add(grilla);

                        nLineID += 1;

                    }

                }

                int nLineID_r; 

                for (int i = 0; i <= Grid3.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = Grid3[0, i].Value.ToString();

                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        nLineID = Convert.ToInt32(Grid3[4, i].Value.ToString());

                    }
                    catch
                    {
                        nLineID = 0;

                    }

                    nLineID_r = nLineID;

                    for (int x = 0; x <= Grid1.Rows.Count - 1; x++)
                    {

                        try
                        {
                            cDocEntry_f = Grid1[0, x].Value.ToString();

                        }
                        catch
                        {
                            cDocEntry_f = "";

                        }

                        if (cDocEntry == cDocEntry_f)
                        {
                            Grid4[1, nLineID_r].Value = Grid1[1, x].Value.ToString();
                            Grid4[2, nLineID_r].Value = Grid1[2, x].Value.ToString();
                            Grid4[3, nLineID_r].Value = Grid1[3, x].Value.ToString();
                            Grid4[4, nLineID_r].Value = Grid1[4, x].Value.ToString();
                            Grid4[5, nLineID_r].Value = Grid1[5, x].Value.ToString();
                            Grid4[6, nLineID_r].Value = Grid1[6, x].Value.ToString();

                            nLineID_r += 1;
                        }

                    }

                    nLineID_r = nLineID;

                    for (int x = 0; x <= Grid2.Rows.Count - 1; x++)
                    {

                        try
                        {
                            cDocEntry_f = Grid2[0, x].Value.ToString();

                        }
                        catch
                        {
                            cDocEntry_f = "";

                        }

                        if (cDocEntry == cDocEntry_f)
                        {
                            Grid4[7, nLineID_r].Value = Grid2[1, x].Value.ToString();
                            Grid4[8, nLineID_r].Value = Grid2[2, x].Value.ToString();
                            Grid4[9, nLineID_r].Value = Grid2[3, x].Value.ToString();
                            Grid4[10, nLineID_r].Value = Grid2[4, x].Value.ToString();
                            Grid4[11, nLineID_r].Value = Grid2[5, x].Value.ToString();
                            Grid4[12, nLineID_r].Value = Grid2[6, x].Value.ToString();

                            nLineID_r += 1;
                        }

                    }


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
            //Excel.Range oRng;

            DateTime dFEcha;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Productor:";
                oSheet.Cells[1, 2] = t_cardname.Text;

                oSheet.Cells[2, 1] = "Variedad:";
                oSheet.Cells[2, 2] = t_variedad_pt.Text;

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("b1", "b2").Font.Bold = true; 
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int nLinea;
                string cLoteMP, cLotePT;

                oSheet.Cells[4, 1] = "Consumos de Materia prima";
                oSheet.Cells[4, 7] = "Recibos de Producción";

                nLinea = 5;
                //Add table headers going cell by cell.
                oSheet.Cells[5, 1] = "OF";
                oSheet.Cells[5, 2] = "N°Guía";
                oSheet.Cells[5, 3] = "Lote MP";
                oSheet.Cells[5, 4] = "Fecha Ingreso";
                oSheet.Cells[5, 5] = "N°Bins";
                oSheet.Cells[5, 6] = "Kilos Ingresados";
                oSheet.Cells[5, 7] = "Variedad";

                oSheet.Cells[5, 8] = "OF";
                oSheet.Cells[5, 9] = "Lotes";
                oSheet.Cells[5, 10] = "Fecha Ingreso";
                oSheet.Cells[5, 11] = "N°Bins";
                oSheet.Cells[5, 12] = "Kilos Secos";
                oSheet.Cells[5, 13] = "Rendimiento";
                oSheet.Cells[5, 14] = "Variedad";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a4", "n5").Font.Bold = true;
                oSheet.get_Range("a4", "n5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid4.RowCount - 1; i++)
                {

                    try
                    {
                        cLoteMP = Grid4[2, i].Value.ToString();
                    }
                    catch
                    {
                        cLoteMP = "";
                    }

                    try
                    {
                        cLotePT = Grid4[7, i].Value.ToString();
                    }
                    catch
                    {
                        cLotePT = "";
                    }

                    if (cLoteMP != "")
                    {
                        try
                        {
                            oSheet.Cells[6 + i, 1] = Grid4[0, i].Value.ToString();

                        }
                        catch
                        {

                        }

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 2] = Grid4[1, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 3] = Grid4[2, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        dFEcha = Convert.ToDateTime(Grid4[3, i].Value.ToString());

                    }
                    catch
                    {
                        dFEcha = Convert.ToDateTime("01/01/1900");

                    }

                    oSheet.Cells[6 + i, 4] = "";

                    if (dFEcha.Year != 1900)
                    {
                        try
                        {
                            oSheet.Cells[6 + i, 4] = dFEcha.ToString("MM/dd/yyyy");

                        }
                        catch
                        {

                        }

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 5] = Grid4[4, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 6] = Grid4[5, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 7] = Grid4[6, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    if (cLotePT != "")
                    {
                        try
                        {
                            oSheet.Cells[6 + i, 8] = Grid4[0, i].Value.ToString();

                        }
                        catch
                        {

                        }

                    }

                    if (cLotePT != "")
                    {
                        try
                        {
                            oSheet.Cells[6 + i, 9] = Grid4[7, i].Value.ToString();

                        }
                        catch
                        {

                        }

                    }

                    try
                    {
                        dFEcha = Convert.ToDateTime(Grid4[8, i].Value.ToString());

                    }
                    catch
                    {
                        dFEcha = Convert.ToDateTime("01/01/1900");

                    }

                    oSheet.Cells[6 + i, 10] = "";

                    if (dFEcha.Year != 1900)
                    {
                        try
                        {
                            oSheet.Cells[6 + i, 10] = dFEcha.ToString("MM/dd/yyyy");

                        }
                        catch
                        {

                        }

                    }



                    try
                    {
                        oSheet.Cells[6 + i, 11] = Grid4[9, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 12] = Grid4[10, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 13] = Grid4[11, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    try
                    {
                        oSheet.Cells[6 + i, 14] = Grid4[12, i].Value.ToString();

                    }
                    catch
                    {

                    }

                    nLinea = 8 + i;

                }

                oSheet.get_Range("b" + nLinea, "b" + nLinea).Font.Bold = true;
                oSheet.get_Range("b" + nLinea, "b" + nLinea).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                nLinea += 2;

                //oRng = oSheet.get_Range("A1", "g1");
                //oRng.EntireColumn.AutoFit();

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
