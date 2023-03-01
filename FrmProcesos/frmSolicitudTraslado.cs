using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmSolicitudTraslado : Form
    {
        public frmSolicitudTraslado()
        {
            InitializeComponent();
        }

        private void frmSolicitudTraslado_Load(object sender, EventArgs e)
        {
            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_ConsultaLista_Almacenes();

            cbb_almacen_to.DataSource = objproducto1.cResultado;
            cbb_almacen_to.ValueMember = "WhsCode";
            cbb_almacen_to.DisplayMember = "WhsCode";

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

                    if (line != "")
                    {

                        counter++;

                        grilla[0] = line;

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
            string cItemName, cExiste;
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

                    string cAbsEntry, cLote_D;

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

                        //grilla[0] = (i + 1).ToString();
                        //grilla[1] = cAbsEntry;
                        //grilla[2] = cLote_D;

                        Grid1[1, j].Value = cItemCode;
                        Grid1[2, j].Value = cItemName;
                        Grid1[3, j].Value = cAbsEntry;
                        Grid1[4, j].Value = cLote_D;
                        Grid1[5, j].Value = nStock.ToString("N2");
                        Grid1[6, j].Value = "";

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
                        nStock1 = float.Parse(Grid1[5, i].Value.ToString());
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

                for (int k = j+1; k <= Grid1.RowCount - 1; k++)
                {                    
                    cLote2 = Grid1[0, k].Value.ToString();

                    if (cLote == cLote2)
                    {
                        Grid1[6, j].Value = "Lote Duplicado";
                        Grid1[6, k].Value = "Lote Duplicado";

                        Grid1[0, j].Style.BackColor = Color.Red;
                        Grid1[1, j].Style.BackColor = Color.Red;
                        Grid1[2, j].Style.BackColor = Color.Red;
                        Grid1[3, j].Style.BackColor = Color.Red;
                        Grid1[4, j].Style.BackColor = Color.Red;
                        Grid1[5, j].Style.BackColor = Color.Red;
                        Grid1[6, j].Style.BackColor = Color.Red;

                        Grid1[0, k].Style.BackColor = Color.Red;
                        Grid1[1, k].Style.BackColor = Color.Red;
                        Grid1[2, k].Style.BackColor = Color.Red;
                        Grid1[3, k].Style.BackColor = Color.Red;
                        Grid1[4, k].Style.BackColor = Color.Red;
                        Grid1[5, k].Style.BackColor = Color.Red;
                        Grid1[6, k].Style.BackColor = Color.Red;

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
                    nStock = double.Parse(Grid1[5, j].Value.ToString());

                }
                catch
                {
                    nStock = 0;

                }

                if (nStock == 0)
                {
                    Grid1[6, j].Value = "Sin Stock";

                    Grid1[0, j].Style.BackColor = Color.Blue; 
                    Grid1[1, j].Style.BackColor = Color.Blue;
                    Grid1[2, j].Style.BackColor = Color.Blue;
                    Grid1[3, j].Style.BackColor = Color.Blue;
                    Grid1[4, j].Style.BackColor = Color.Blue;
                    Grid1[5, j].Style.BackColor = Color.Blue;
                    Grid1[6, j].Style.BackColor = Color.Blue;
                   
                    cError = "S";

                }

            }

            if (Grid1.RowCount > 0)
            {
                cbb_almacen.Enabled = false;
                button1.Enabled = false;

            }

            if (cError == "S")
            {
                btn_genera_solicitud.Enabled = false;

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
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

            if (cbb_almacen_to.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Almacén de destino válido, opción Cancelada", "Carga Masiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Solicitud", "Carga Masiva", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            DateTime dt;

            string cFecha, cLote_D, cBodegaDestino;
            string cWhsCode, cItemCode_D, cItemName_D;

            double nQuantity;

            string[,] d_arrDetalle = new string[10, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            string[,] d_arrDetalle1 = new string[10, 200];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle1[1, i] = "";

            }

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

            try
            {
                cBodegaDestino = cbb_almacen_to.SelectedValue.ToString();
            }
            catch
            {
                cBodegaDestino = "";
            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            int j;

            j = 0;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                cItemCode_D = Grid2[0, i].Value.ToString();
                //cItemName_D = Grid1[2, i].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid2[1, i].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                d_arrDetalle[1, j] = cItemCode_D;
                d_arrDetalle[2, j] = cWhsCode;
                d_arrDetalle[3, j] = nQuantity.ToString();
                d_arrDetalle[4, j] = cBodegaDestino;

                j += 1;

            }

            j = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                cLote_D = Grid1[3, i].Value.ToString();
                cItemCode_D = Grid1[1, i].Value.ToString();
                cItemName_D = Grid1[2, i].Value.ToString();

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[5, i].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                d_arrDetalle1[1, j] = cItemCode_D;
                d_arrDetalle1[2, j] = cLote_D;
                d_arrDetalle1[3, j] = nQuantity.ToString();
                d_arrDetalle1[4, j] = cWhsCode;

                j += 1;

            }

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

            dt = DateTime.Now;

            cFecha = dt.ToString("yyyyMMdd");

            int nStockTransferEntry;

            nStockTransferEntry = 0;

            String mensaje = clsOrdenFabricacion.Stock_Transfer(0, cFecha, d_arrDetalle, d_arrDetalle1, t_CardCode.Text ,t_CardName.Text ,  UsuarioSap, ClaveSap);

            try
            {
                nStockTransferEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Solicitud Generada con Existo", "" + mensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch
            {
                nStockTransferEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la Solicitud de transferencia :::::: " + cErrorMensaje + ", opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        }

        private void btn_buscar_cliente_Click(object sender, EventArgs e)
        {

            t_CardCode.Clear();
            t_CardName.Clear();

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_CardCode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_CardName.Text = VariablesGlobales.glb_CardName;

            }


        }

    }

}
