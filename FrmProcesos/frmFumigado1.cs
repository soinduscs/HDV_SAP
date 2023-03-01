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
    public partial class frmFumigado1 : Form
    {
        public frmFumigado1()
        {
            InitializeComponent();
        }

        private void frmFumigado1_Load(object sender, EventArgs e)
        {

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

            if ( VariablesGlobales.glb_fecha.ToString("yyyyMMdd") == "19000101")
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
            //// borro los lotes al pallet antiguo

            mensaje = clsOrdenFabricacion.Fumiga_Lote(d_arrDetalle, fecha_fumigado, UsuarioSap, ClaveSap);


            try
            {
                //nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                //nOrdenFabricacionEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_fumiga_lote.Enabled = false;
            btn_en_fumigado.Enabled = false;

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

            result = MessageBox.Show("Esta Seguro de ingresar los Lotes seleccionados a Fumigar", "Fumigado de Lotes ", buttons);

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
            //// borro los lotes al pallet antiguo

            mensaje = clsOrdenFabricacion.Fumiga_Lote_En(d_arrDetalle, fecha_fumigado, UsuarioSap, ClaveSap);

            try
            {
                //nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                //nOrdenFabricacionEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_fumiga_lote.Enabled = false;
            btn_en_fumigado.Enabled = false;

        }

    }

}
