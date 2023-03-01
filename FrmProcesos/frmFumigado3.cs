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
using System.IO;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmFumigado3 : Form
    {
        public frmFumigado3()
        {
            InitializeComponent();
        }

        private void frmFumigado3_Load(object sender, EventArgs e)
        {

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                t_archivo_full.Text = openFileDialog1.FileName;
            }

            int counter = 0;
            string line;

            Grid1.Rows.Clear();

            try
            {
                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(t_archivo_full.Text);

                string[] grilla;
                grilla = new string[30];

                while ((line = file.ReadLine()) != null)
                {
                    counter++;

                    grilla[0] = line;

                    Grid1.Rows.Add(grilla);

                }

                file.Close();

            }
            catch
            {

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string cLote, cExiste, cItemCode;
            string cItemName, cFumigado;

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {
                cLote = Grid1[0, j].Value.ToString();

                cExiste = "NO";

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Lote(cLote);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    cItemCode = dTable.Rows[0]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cItemName = dTable.Rows[0]["itemName"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                string cAbsEntry, cLote_D;

                DateTime dFecha;
                double nQuantity;

                //Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cAbsEntry = dTable.Rows[i]["AbsEntry"].ToString();
                    }
                    catch
                    {
                        cAbsEntry = "";
                    }

                    try
                    {
                        cLote_D = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote_D = "";
                    }

                    try
                    {
                        dFecha = DateTime.Parse(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString()); //
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    //grilla[0] = (i + 1).ToString();
                    //grilla[1] = cAbsEntry;
                    //grilla[2] = cLote_D;

                    cFumigado = "";

                    if (dFecha.Year > 1900)
                    {
                        cFumigado = "SI";
                        //grilla[4] = dFecha.ToString("dd/MM/yyyy");

                    }

                    nQuantity = 1;

                    if (nQuantity > 0)
                    {

                        cExiste = "";

                        //for (int x = 0; x <= Grid1.RowCount - 1; x++)
                        //{
                        //    try
                        //    {
                        //        cLote_D = Grid1[1, x].Value.ToString();
                        //    }
                        //    catch
                        //    {
                        //        cLote_D = "";
                        //    }

                        //    cExiste = "";

                        //    if (cAbsEntry == cLote_D)
                        //    {
                        //        cExiste = "SI";
                        //        break;

                        //    }

                        //}

                        if (cExiste == "")
                        {
                            Grid1[1, j].Value = cItemCode;
                            Grid1[2, j].Value = cItemName;
                            Grid1[3, j].Value = cAbsEntry;
                            Grid1[4, j].Value = cLote_D;
                            Grid1[5, j].Value = cFumigado;
                            Grid1[6, j].Value = "";

                            if (dFecha.Year > 1900)
                            {
                                Grid1[6, j].Value = dFecha.ToString("dd/MM/yyyy");

                            }

                        }

                    }

                }

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_en_fumigado_Click(object sender, EventArgs e)
        {

            int nCantRegistros;

            nCantRegistros = -1;

            try
            {
                nCantRegistros = Grid1.RowCount - 1;

            }
            catch
            {
                nCantRegistros = -1;

            }

            if (nCantRegistros == -1)
            {
                MessageBox.Show("No Existen regsitros a procesar, opción Cancelada", "Fumigado de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Fumigar los Lotes seleccionados", "Fumigado de Lotes ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            VariablesGlobales.glb_fecha = Convert.ToDateTime("01/01/1900");

            frmFumigado2 f2 = new frmFumigado2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_fecha.ToString("yyyyMMdd") == "19000101")
            {
                return;

            }

            string cErrorMensaje, mensaje, fecha_fumigado;

            fecha_fumigado = VariablesGlobales.glb_fecha.ToString("yyyyMMdd");

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            string[,] d_arrDetalle = new string[2, 5000];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            string cFumigado, cAbsEntry;
            int nLote, nNumeroLotes;

            nNumeroLotes = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cFumigado = "";
                cAbsEntry = "";

                try
                {
                    cFumigado = Grid1[5, x].Value.ToString();
                }
                catch
                {
                    cFumigado = "";
                }

                try
                {
                    cAbsEntry = Grid1[3, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry = "";
                }

                try
                {
                    nLote = int.Parse(cAbsEntry);
                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {
                    d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                    nNumeroLotes += 1;

                }

            }

            if (nNumeroLotes == 0)
            {
                MessageBox.Show("No existen lotes a asginar, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            cErrorMensaje = "";

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

            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            //// 

            string UserCode, cItemCode;
            int UserId, nDocEntry_OFUM;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            mensaje = "";

            try
            {
                cItemCode = Grid1[1, 0].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }

            mensaje = clsCalidad.SAPB1_OFUM(0, "", fecha_fumigado, UserId, UserCode, cItemCode, "En");

            clsCalidad objproducto5 = new clsCalidad();
            objproducto5.cls_Consulta_Nuevo_Registro_OFUM();

            DataTable dTable5 = new DataTable();
            dTable5 = objproducto5.cResultado;

            try
            {
                nDocEntry_OFUM = Convert.ToInt32(dTable5.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nDocEntry_OFUM = 0;

            }

            try
            {
                mensaje = clsOrdenFabricacion.Fumiga_Lote1(d_arrDetalle, fecha_fumigado, nDocEntry_OFUM, UsuarioSap, ClaveSap);

            }
            catch
            {

            }

            mensaje = clsOrdenFabricacion.Fumiga_Lote_En(d_arrDetalle, fecha_fumigado, UsuarioSap, ClaveSap);

            try
            {
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_fumiga_lote.Enabled = false;
            btn_en_fumigado.Enabled = false;
            btn_buscar1.Enabled = false;
            btn_consultar3.Enabled = false;

        }

        private void btn_fumiga_lote_Click(object sender, EventArgs e)
        {

            int nCantRegistros;

            nCantRegistros = -1;

            try
            {
                nCantRegistros = Grid1.RowCount - 1;

            }
            catch
            {
                nCantRegistros = -1;

            }

            if (nCantRegistros == -1)
            {
                MessageBox.Show("No Existen regsitros a procesar, opción Cancelada", "Fumigado de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Fumigar los Lotes seleccionados", "Fumigado de Lotes ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            VariablesGlobales.glb_fecha = Convert.ToDateTime("01/01/1900");

            frmFumigado2 f2 = new frmFumigado2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_fecha.ToString("yyyyMMdd") == "19000101")
            {
                return;

            }

            string cErrorMensaje, mensaje, fecha_fumigado;

            fecha_fumigado = VariablesGlobales.glb_fecha.ToString("yyyyMMdd");

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            string[,] d_arrDetalle = new string[2, 5000];

            for (int i = 0; i <= 199; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            string cFumigado, cAbsEntry;
            int nLote, nNumeroLotes;

            nNumeroLotes = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cFumigado = "";
                cAbsEntry = "";

                try
                {
                    cFumigado = Grid1[5, x].Value.ToString();
                }
                catch
                {
                    cFumigado = "";
                }

                try
                {
                    cAbsEntry = Grid1[3, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry = "";
                }

                try
                {
                    nLote = int.Parse(cAbsEntry);
                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {
                    d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                    nNumeroLotes += 1;

                }

            }

            if (nNumeroLotes == 0)
            {
                MessageBox.Show("No existen lotes a asginar, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            cErrorMensaje = "";

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

            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            //// 

            string UserCode, cItemCode;
            int UserId, nDocEntry_OFUM;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            mensaje = "";

            try
            {
                cItemCode = Grid1[1, 0].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }

            mensaje = clsCalidad.SAPB1_OFUM(0, "", fecha_fumigado , UserId, UserCode, cItemCode,"Si");

            clsCalidad objproducto5 = new clsCalidad();
            objproducto5.cls_Consulta_Nuevo_Registro_OFUM();

            DataTable dTable5 = new DataTable();
            dTable5 = objproducto5.cResultado;

            try
            {
                nDocEntry_OFUM = Convert.ToInt32(dTable5.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nDocEntry_OFUM = 0;

            }

            try
            {
                mensaje = clsOrdenFabricacion.Fumiga_Lote1(d_arrDetalle, fecha_fumigado, nDocEntry_OFUM, UsuarioSap, ClaveSap);

            }
            catch
            {

            }

            mensaje = clsOrdenFabricacion.Fumiga_Lote(d_arrDetalle, fecha_fumigado, UsuarioSap, ClaveSap);

            try
            {
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            button1.Enabled = false;
            btn_fumiga_lote.Enabled = false;
            btn_en_fumigado.Enabled = false;

            //btn_buscar1.Enabled = false;
            //btn_consultar3.Enabled = false;

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;

            frmFumigado4 f2 = new frmFumigado4();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                t_docentry.Text = VariablesGlobales.glb_DocEntry.ToString();

                // Deshabilito los otros botones

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_OFUM(Convert.ToInt32(t_docentry.Text));

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];
                DateTime dFecha;
                
                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[0] = "";

                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        grilla[1] = "";

                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["itemName"].ToString();

                    }
                    catch
                    {
                        grilla[2] = "";

                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[3] = "";

                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[4] = "";

                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["U_Fumigado"].ToString();

                    }
                    catch
                    {
                        grilla[5] = "";

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_fecha_fumigado"].ToString());

                    }
                    catch
                    {
                        dFecha = Convert.ToDateTime("01/01/1900");

                    }

                    grilla[6] = dFecha.ToString("dd/MM/yyyy");
                    grilla[7] = t_docentry.Text;

                    Grid1.Rows.Add(grilla);

                }

                //btn_buscar1.Enabled = false;
                //btn_consultar3.Enabled = false;

                button1.Enabled = false;
                btn_fumiga_lote.Enabled = false;
                btn_en_fumigado.Enabled = false;

            }

        }

        private void btn_consultar3_Click(object sender, EventArgs e)
        {

            if (t_lote.Text != "")
            {

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_OFUM1(t_lote.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];
                DateTime dFecha;

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[0] = "";

                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        grilla[1] = "";

                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["itemName"].ToString();

                    }
                    catch
                    {
                        grilla[2] = "";

                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[3] = "";

                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["U_DistNumber"].ToString();

                    }
                    catch
                    {
                        grilla[4] = "";

                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["U_Fumigado"].ToString();

                    }
                    catch
                    {
                        grilla[5] = "";

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_fecha_fumigado"].ToString());

                    }
                    catch
                    {
                        dFecha = Convert.ToDateTime("01/01/1900");

                    }

                    grilla[6] = dFecha.ToString("dd/MM/yyyy");

                    try
                    {
                        grilla[7] = dTable.Rows[i]["DocEntry"].ToString();

                    }
                    catch
                    {
                        grilla[7] = "";

                    }

                    Grid1.Rows.Add(grilla);

                }

                //btn_buscar1.Enabled = false;
                //btn_consultar3.Enabled = false;

                button1.Enabled = false;
                btn_fumiga_lote.Enabled = false;
                btn_en_fumigado.Enabled = false;

            }

        }

        private void btn_excel_Click(object sender, EventArgs e)
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

                oSheet.get_Range("a1", "a1").Font.Size = 16;
                oSheet.get_Range("a1", "a1").Font.Bold = true;
                oSheet.Cells[1, 1] = "Fumigado de Fruta";

                oSheet.get_Range("a3", "f3").Font.Bold = true;

                oSheet.Cells[3, 1] = Grid1.Columns[0].HeaderText;
                oSheet.Cells[3, 2] = Grid1.Columns[1].HeaderText;
                oSheet.Cells[3, 3] = Grid1.Columns[2].HeaderText;
                oSheet.Cells[3, 4] = Grid1.Columns[5].HeaderText;
                oSheet.Cells[3, 5] = Grid1.Columns[6].HeaderText;
                oSheet.Cells[3, 6] = Grid1.Columns[7].HeaderText;

                nLinea = 4;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    oSheet.Cells[nLinea, 1] = Grid1[0, i].Value.ToString();
                    oSheet.Cells[nLinea, 2] = Grid1[1, i].Value.ToString();
                    oSheet.Cells[nLinea, 3] = Grid1[2, i].Value.ToString();
                    oSheet.Cells[nLinea, 4] = Grid1[5, i].Value.ToString();
                    oSheet.Cells[nLinea, 5] = Grid1[6, i].Value.ToString();
                    oSheet.Cells[nLinea, 6] = Grid1[7, i].Value.ToString();

                    nLinea += 1;

                }

                oSheet.get_Range("a4", "f" + nLinea).Font.Size = 10;
                oRng = oSheet.get_Range("a4", "f" + nLinea);
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

        private void btn_consultar2_Click(object sender, EventArgs e)
        {

            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_OFUM2(cfecha1 , cfecha2);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];
            DateTime dFecha;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    grilla[0] = dTable.Rows[i]["U_DistNumber"].ToString();

                }
                catch
                {
                    grilla[0] = "";

                }

                try
                {
                    grilla[1] = dTable.Rows[i]["ItemCode"].ToString();

                }
                catch
                {
                    grilla[1] = "";

                }

                try
                {
                    grilla[2] = dTable.Rows[i]["itemName"].ToString();

                }
                catch
                {
                    grilla[2] = "";

                }

                try
                {
                    grilla[3] = dTable.Rows[i]["U_DistNumber"].ToString();

                }
                catch
                {
                    grilla[3] = "";

                }

                try
                {
                    grilla[4] = dTable.Rows[i]["U_DistNumber"].ToString();

                }
                catch
                {
                    grilla[4] = "";

                }

                try
                {
                    grilla[5] = dTable.Rows[i]["U_Fumigado"].ToString();

                }
                catch
                {
                    grilla[5] = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable.Rows[i]["U_fecha_fumigado"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");

                }

                grilla[6] = dFecha.ToString("dd/MM/yyyy");

                try
                {
                    grilla[7] = dTable.Rows[i]["DocEntry"].ToString();

                }
                catch
                {
                    grilla[7] = "";

                }

                Grid1.Rows.Add(grilla);

            }

            button1.Enabled = false;
            btn_fumiga_lote.Enabled = false;
            btn_en_fumigado.Enabled = false;


        }
    }

}
