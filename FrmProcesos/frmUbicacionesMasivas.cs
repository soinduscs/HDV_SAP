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
    public partial class frmUbicacionesMasivas : Form
    {
        public frmUbicacionesMasivas()
        {
            InitializeComponent();
        }

        private void frmUbicacionesMasivas_Load(object sender, EventArgs e)
        {
            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

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
            string line, col1, col2;
            string cComa;

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

                    col1 = line.Substring(0, 7);
                    cComa = line.Substring(7, 1);
                    col2 = line.Substring(8, line.Length-8);

                    if (cComa == ",")
                    {
                        grilla[0] = col1;
                        grilla[8] = col2;

                        Grid1.Rows.Add(grilla);

                    }

                }

                file.Close();

            }
            catch
            {

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string cLote, cItemCode, cItemCode_D;
            string cItemName, cUbicacionActual, cExiste;
            double nStock, nStock1;

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {
                cLote = Grid1[0, j].Value.ToString();

                if (cLote != "")
                {

                    clsProduccion objproducto = new clsProduccion();
                    objproducto.cls_Consulta_Lote_y_Stock(cLote, cbb_almacen.Text);

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

                    string cAbsEntry, cLote_D, cBinCode;

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
                            nStock = double.Parse(dTable.Rows[i]["Stock_Lote"].ToString()); //
                        }
                        catch
                        {
                            nStock = 0;
                        }

                        try
                        {
                            cUbicacionActual = dTable.Rows[i]["Ubicacion"].ToString();

                        }
                        catch
                        {
                            cUbicacionActual = "";

                        }

                        clsProduccion objproducto2 = new clsProduccion();
                        objproducto2.cls_Consulta_Ubicaciones_x_bincode_y_bodega(Grid1[8, j].Value.ToString(), cbb_almacen.Text);

                        DataTable dTable2 = new DataTable();
                        dTable2 = objproducto2.cResultado;

                        try
                        {
                            cBinCode = dTable2.Rows[0]["BinCode"].ToString();
                        }
                        catch
                        {
                            cBinCode = "";
                        }



                        //grilla[0] = (i + 1).ToString();
                        //grilla[1] = cAbsEntry;
                        //grilla[2] = cLote_D;

                        Grid1[1, j].Value = cItemCode;
                        Grid1[2, j].Value = cItemName;
                        Grid1[3, j].Value = cAbsEntry;
                        Grid1[4, j].Value = cLote_D;
                        Grid1[5, j].Value = cUbicacionActual;
                        Grid1[6, j].Value = nStock.ToString("N2");
                        Grid1[7, j].Value = "";
                        Grid1[9, j].Value = cBinCode;

                    }

                    cExiste = "N";

                    for (int i = 0; i <= Grid2.RowCount - 1; i++)
                    {
                        cItemCode_D = "";

                        try
                        {
                            cItemCode_D = Grid2[0, i].Value.ToString();
                        }
                        catch
                        {
                            cItemCode_D = "";
                        }

                        if (cItemCode == cItemCode_D)
                        {
                            cExiste = "S";
                            break;
                        }

                    }

                    if (cExiste == "N")
                    {
                        grilla[0] = cItemCode;
                        grilla[1] = "0";

                        Grid2.Rows.Add(grilla);

                    }

                }

            }

            for (int j = 0; j <= Grid2.RowCount - 1; j++)
            {
                cItemCode = "";

                try
                {
                    cItemCode = Grid2[0, j].Value.ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                nStock = 0;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    cItemCode_D = "";

                    try
                    {
                        cItemCode_D = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cItemCode_D = "";
                    }

                    try
                    {
                        nStock1 = float.Parse(Grid1[6, i].Value.ToString());
                    }
                    catch
                    {
                        nStock1 = 0;
                    }

                    if (cItemCode == cItemCode_D)
                    {
                        nStock += nStock1;

                    }

                }

                Grid2[1, j].Value = nStock.ToString();

            }


            //////////////////////////////////////////
            // Valido que no existan lotes repetidos

            string cError, cLote2;
            cError = "N";

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {

                cLote = Grid1[0, j].Value.ToString();

                for (int k = j + 1; k <= Grid1.RowCount - 1; k++)
                {
                    cLote2 = Grid1[0, k].Value.ToString();

                    if (cLote == cLote2)
                    {
                        Grid1[7, j].Value = "Lote Duplicado";
                        Grid1[7, k].Value = "Lote Duplicado";

                        Grid1[0, j].Style.BackColor = Color.Red;
                        Grid1[1, j].Style.BackColor = Color.Red;
                        Grid1[2, j].Style.BackColor = Color.Red;
                        Grid1[3, j].Style.BackColor = Color.Red;
                        Grid1[4, j].Style.BackColor = Color.Red;
                        Grid1[5, j].Style.BackColor = Color.Red;
                        Grid1[6, j].Style.BackColor = Color.Red;
                        Grid1[7, j].Style.BackColor = Color.Red;

                        Grid1[0, k].Style.BackColor = Color.Red;
                        Grid1[1, k].Style.BackColor = Color.Red;
                        Grid1[2, k].Style.BackColor = Color.Red;
                        Grid1[3, k].Style.BackColor = Color.Red;
                        Grid1[4, k].Style.BackColor = Color.Red;
                        Grid1[5, k].Style.BackColor = Color.Red;
                        Grid1[6, k].Style.BackColor = Color.Red;
                        Grid1[7, j].Style.BackColor = Color.Red;

                        cError = "S";

                    }

                }

            }

            //////////////////////////////////////////
            // Valido que no existan lotes sin stock

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {

                nStock = 0;

                try
                {
                    nStock = double.Parse(Grid1[6, j].Value.ToString());

                }
                catch
                {
                    nStock = 0;

                }

                if (nStock == 0)
                {
                    Grid1[7, j].Value = "Sin Stock";

                    Grid1[0, j].Style.BackColor = Color.Blue;
                    Grid1[1, j].Style.BackColor = Color.Blue;
                    Grid1[2, j].Style.BackColor = Color.Blue;
                    Grid1[3, j].Style.BackColor = Color.Blue;
                    Grid1[4, j].Style.BackColor = Color.Blue;
                    Grid1[5, j].Style.BackColor = Color.Blue;
                    Grid1[6, j].Style.BackColor = Color.Blue;
                    Grid1[7, j].Style.BackColor = Color.Blue;

                    cError = "S";

                }

            }


            //////////////////////////////////////////
            // Valido que no existan lotes sin stock
            string cBinCode1, cBinCode2;

            for (int j = 0; j <= Grid1.RowCount - 1; j++)
            {

                cBinCode1 = "";
                cBinCode2 = "";

                try
                {
                    cBinCode1 = Grid1[8, j].Value.ToString();

                }
                catch
                {
                    cBinCode1 = "";

                }

                try
                {
                    cBinCode2 = Grid1[9, j].Value.ToString();

                }
                catch
                {
                    cBinCode2 = "";

                }

                if (cBinCode1 != cBinCode2)
                {
                    Grid1[7, j].Value = "Ubicacion No válida";

                    Grid1[0, j].Style.BackColor = Color.Red;
                    Grid1[1, j].Style.BackColor = Color.Red;
                    Grid1[2, j].Style.BackColor = Color.Red;
                    Grid1[3, j].Style.BackColor = Color.Red;
                    Grid1[4, j].Style.BackColor = Color.Red;
                    Grid1[5, j].Style.BackColor = Color.Red;
                    Grid1[6, j].Style.BackColor = Color.Red;
                    Grid1[8, j].Style.BackColor = Color.Red;

                    cError = "S";

                }

            }


            if (Grid1.RowCount > 0)
            {

                button1.Enabled = false;

            }

            if (cError == "S")
            {
                btn_genera_solicitud.Enabled = false;

            }



        }

        private void btn_genera_solicitud_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            if (cbb_almacen.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Almacén de origen válido, opción Cancelada", "Carga Masiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Solicitud", "Carga Masiva", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

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


            DateTime dt;

            dt = DateTime.Now;

            string cUbicBinCode_D, cLote_D;
            string cWhsCode, cItemCode_D;
            string mensaje;

            int nNewUbicacion, nStockTransferEntry;

            float nQuantity;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            try
            {
                cWhsCode = cbb_almacen.SelectedValue.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                cItemCode_D = Grid1[1, i].Value.ToString();
                cLote_D = Grid1[3, i].Value.ToString();
                cUbicBinCode_D = Grid1[8, i].Value.ToString();

                try
                {
                    nQuantity = float.Parse(Grid1[6, i].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }


                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Bodegas_Ubicaciones_x_bincode(cUbicBinCode_D);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    nNewUbicacion = int.Parse(dTable.Rows[0]["AbsEntry"].ToString());

                }
                catch
                {
                    nNewUbicacion = 0;
                }

                if (nNewUbicacion == 0)
                {
                    //MessageBox.Show("Debe seleccionar una ubicación valida, opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    mensaje = clsRecepcion.Stock_Transfer_Ubicaciones(dt.ToString("yyyyMMdd"), cItemCode_D, int.Parse(cLote_D), nQuantity, cbb_almacen.Text, cbb_almacen.Text, nNewUbicacion,0,0, UsuarioSap, ClaveSap);

                }
                catch
                {
                    mensaje = "";
                }

                try
                {
                    nStockTransferEntry = int.Parse(mensaje);
                    //MessageBox.Show("Proceso Terminado Exitosamente", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //button1.Enabled = false;

                }
                catch
                {
                    //MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nStockTransferEntry = 0;

                }

                Grid1[6, i].Value = mensaje;

                Application.DoEvents();
                Application.DoEvents();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

    }

}
