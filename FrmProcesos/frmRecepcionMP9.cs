using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmRecepcionMP9 : Form
    {
        public frmRecepcionMP9()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP9_Load(object sender, EventArgs e)
        {

            t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
            t_lineid.Text = VariablesGlobales.glb_LineId.ToString();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto.cResultado;
            my_DGVCboColumn.Name = "Tipo de Envases";
            my_DGVCboColumn.ValueMember = "ItemCode";
            my_DGVCboColumn.DisplayMember = "ItemName";

            Grid1.Columns.RemoveAt(3);
            Grid1.Columns.Insert(3, my_DGVCboColumn);
            Grid1.Columns[3].Width = 240;

            DataGridViewComboBoxColumn my_DGVCboColumn1 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn1.DataSource = objproducto.cResultado;
            my_DGVCboColumn1.Name = "Tipo de Envases";
            my_DGVCboColumn1.ValueMember = "ItemCode";
            my_DGVCboColumn1.DisplayMember = "ItemName";

            Grid2.Columns.RemoveAt(3);
            Grid2.Columns.Insert(3, my_DGVCboColumn1);
            Grid2.Columns[3].Width = 240;

            Thread.Sleep(30);

            timer1.Enabled = true;

            Carga_Grilla();

        }
        
        private void balanza1()
        {
            ///////////////////////////////////////////
            ///////////////////////////////////////////
            // BALANZA 1    *
            // BALANZA 1   **
            // BALANZA 1  * *
            // BALANZA 1    *
            // BALANZA 1    *
            // BALANZA 1    *

            //t_PesoBalanza.Text = "10030";
            //return;

            t_balanza.BackColor = Color.Red;
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;

            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0;

            //int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;
            int nErr = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "COM1";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 1200;
            }

            //try
            //{
            //    //nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            //}
            //catch
            //{
            //    nBalanza_BitsDatos = 0;
            //}

            SerialPort mySerialPort = new SerialPort(cBalanza_Puerto);

            mySerialPort.BaudRate = nBalanza_Baudios;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            try
            {
                mySerialPort.Open();
                nErr = 0;
            }
            catch
            {
                nErr = 1;
            }

            if (nErr == 1)
            {
                try
                {
                    mySerialPort.Close();
                }
                catch
                {

                }

                t_PesoBalanza1.Text = "E_";
                t_balanza.BackColor = Color.Empty;

                //Thread.Sleep(300);
                return;

            }

            string b, cPack, cNumero;
            double nPeso;

            try
            {
                while (true)
                {

                    cPack = "";
                    nPeso = 0;
                    b = "";

                    try
                    {
                        b = mySerialPort.ReadExisting();
                    }
                    catch
                    {
                        b = "";
                    }

                    cPack = b;

                    if (VariablesGlobales.glb_SimboloDecimal != ".")
                    {
                        try
                        {
                            cPack = b.Replace(".", ",");
                        }
                        catch
                        {
                            cPack = b;
                        }

                    }

                    try
                    {
                        nPeso = double.Parse(cPack);
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    grilla[0] = i.ToString();
                    grilla[1] = cPack;
                    grilla[2] = nPeso.ToString();

                    Grid_Peso.Rows.Add(grilla);

                    Thread.Sleep(30);
                    i += 1;

                    if (i > 12)
                    {
                        break;
                    }

                }
            }
            catch
            {

            }

            try
            {
                //serialPort.DiscardInBuffer();
                mySerialPort.Close();
            }
            catch
            {

            }

            double nPesoBalanza;
            double nPesoFinal;

            nPesoBalanza = 0;
            nPesoFinal = 0;
            cNumero = "";

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    cNumero = Grid_Peso[2, j].Value.ToString();
                }
                catch
                {
                    cNumero = "";
                }

                try
                {
                    nPesoBalanza = double.Parse(cNumero);
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = Math.Round(nPesoBalanza, 1);
                }

            }

            t_PesoBalanza1.Text = nPesoFinal.ToString("N2");

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza.BackColor = Color.Empty;

        }

        private void balanza2()
        {

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////
            // BALANZA 2      ***
            // BALANZA 2     *   *
            // BALANZA 2    *     *
            // BALANZA 2         *
            // BALANZA 2       *
            // BALANZA 2    *******

            //t_PesoBalanza.Text = "10030";
            //return;

            t_balanza2.BackColor = Color.Red;
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;

            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0;

            //int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;
            int nErr = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza2_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "COM1";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza2_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 1200;
            }

            //try
            //{
            //    //nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            //}
            //catch
            //{
            //    nBalanza_BitsDatos = 0;
            //}

            SerialPort mySerialPort = new SerialPort(cBalanza_Puerto);

            mySerialPort.BaudRate = nBalanza_Baudios;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            try
            {
                mySerialPort.Open();
                nErr = 0;
            }
            catch
            {
                nErr = 1;
            }

            if (nErr == 1)
            {
                try
                {
                    mySerialPort.Close();
                }
                catch
                {

                }

                t_PesoBalanza2.Text = "E_";
                t_balanza2.BackColor = Color.Empty;

                //Thread.Sleep(300);
                return;

            }

            string b, cPack, cNumero;
            double nPeso;

            try
            {
                while (true)
                {

                    cPack = "";
                    nPeso = 0;
                    b = "";

                    try
                    {
                        b = mySerialPort.ReadExisting();
                    }
                    catch
                    {
                        b = "";
                    }

                    cPack = b;

                    if (VariablesGlobales.glb_SimboloDecimal != ".")
                    {
                        try
                        {
                            cPack = b.Replace(".", ",");
                        }
                        catch
                        {
                            cPack = b;
                        }

                    }

                    try
                    {
                        nPeso = double.Parse(cPack);
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    grilla[0] = i.ToString();
                    grilla[1] = cPack;
                    grilla[2] = nPeso.ToString();

                    Grid_Peso.Rows.Add(grilla);

                    Thread.Sleep(30);
                    i += 1;

                    if (i > 12)
                    {
                        break;
                    }

                }
            }
            catch
            {

            }

            try
            {
                //serialPort.DiscardInBuffer();
                mySerialPort.Close();
            }
            catch
            {

            }

            double nPesoBalanza;
            double nPesoFinal;

            nPesoBalanza = 0;
            nPesoFinal = 0;
            cNumero = "";

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    cNumero = Grid_Peso[2, j].Value.ToString();
                }
                catch
                {
                    cNumero = "";
                }

                try
                {
                    nPesoBalanza = double.Parse(cNumero);
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = Math.Round(nPesoBalanza, 1);
                }

            }

            t_PesoBalanza2.Text = nPesoFinal.ToString("N2");

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza2.BackColor = Color.Empty;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            // BALANZA 1    *
            // BALANZA 1   **
            // BALANZA 1  * *
            // BALANZA 1    *
            // BALANZA 1    *
            // BALANZA 1    *

            balanza1();
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////
            // BALANZA 2      ***
            // BALANZA 2     *   *
            // BALANZA 2    *     *
            // BALANZA 2         *
            // BALANZA 2       *
            // BALANZA 2    *******

            //t_PesoBalanza.Text = "10030";
            //return;

            balanza2();
            Application.DoEvents();

            timer1.Enabled = true;

        }

        private void btn_pesaje_entrada_Click(object sender, EventArgs e)
        {
            string[] grilla;
            grilla = new string[8];

            double dPesoBruto;

            try
            {
                dPesoBruto = Convert.ToDouble(t_PesoBalanza1.Text);
            }
            catch
            {
                dPesoBruto = 0;
            }

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            if (dPesoBruto <= 0)
            {
                MessageBox.Show("Debe ingresar un peso válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

                dPesoBruto = 425;

            }

            grilla[0] = "0";
            grilla[1] = dt.ToString("dd/MM/yyyy HH:mm");
            grilla[2] = dPesoBruto.ToString("N2");
            //grilla[3] = "";
            grilla[4] = 0.ToString("N2");
            grilla[5] = "0";
            grilla[6] = 0.ToString("N2");

            Grid1.Rows.Add(grilla);

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil, cant_bins, peso_bins;
            string cCod_Bins;
            double nPesoNeto, nPesoEnvases, nPesoBruto;

            cant_bins = 0;
            fil = 0;
            cCod_Bins = "";
            peso_bins = 0;

            nPesoNeto = 0;
            nPesoEnvases = 0;
            nPesoBruto = 0;

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
                cCod_Bins = Grid1[3, fil].Value.ToString();

            }
            catch
            {
                cCod_Bins = "";

            }

            try
            {
                nPesoNeto = Convert.ToDouble(Grid1[2, fil].Value);

            }
            catch
            {
                nPesoNeto = 0;

            }

            try
            {
                cant_bins = Convert.ToInt32(Grid1[5, fil].Value);

            }
            catch
            {
                cant_bins = 0;

            }
            
            if (cant_bins > 3)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos (No pueden ser mas de 3 envases por peso), opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cant_bins = 0;
            }

            peso_bins = 0;

            if (cCod_Bins != "")
            {

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Producto_x_codigo(cCod_Bins);

                DataTable dTable = new DataTable();

                dTable = objproducto.cResultado;

                try
                {
                    peso_bins = Convert.ToInt32(dTable.Rows[0].ItemArray[3].ToString());

                }
                catch
                {
                    peso_bins = 0;
                }

            }

            Grid1[4, fil].Value = peso_bins.ToString("N2");
            Grid1[5, fil].Value = cant_bins.ToString();

            nPesoEnvases = cant_bins * peso_bins;

            nPesoBruto = nPesoNeto - nPesoEnvases;

            if (nPesoEnvases == 0)
            {
                nPesoBruto = 0;
            }

            if (nPesoBruto < 0)
            {
                nPesoBruto = 0;
            }

            Grid1[6, fil].Value = nPesoBruto.ToString("N2"); 

            Calcula_bins();

        }

        private void Calcula_bins()
        {

            int cant_unit_bins;
            double total_bins, peso_unit_bins, peso_tot_bins;

            total_bins = 0;
            cant_unit_bins = 0;
            peso_tot_bins = 0;
            peso_unit_bins = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cant_unit_bins = Convert.ToInt32(Grid1[5, i].Value);

                }
                catch
                {
                    cant_unit_bins = 0;
                }

                try
                {
                    peso_unit_bins = Convert.ToDouble(Grid1[6, i].Value);

                }
                catch
                {
                    peso_unit_bins = 0;
                }

                total_bins += cant_unit_bins;
                peso_tot_bins += peso_unit_bins;

            }

            t_cant_envases1.Text = total_bins.ToString();
            t_peso_total1.Text = peso_tot_bins.ToString("N2");

            total_bins = 0;
            cant_unit_bins = 0;
            peso_tot_bins = 0;
            peso_unit_bins = 0;

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                try
                {
                    cant_unit_bins = Convert.ToInt32(Grid2[5, i].Value);

                }
                catch
                {
                    cant_unit_bins = 0;
                }

                try
                {
                    peso_unit_bins = Convert.ToDouble(Grid2[6, i].Value);

                }
                catch
                {
                    peso_unit_bins = 0;
                }

                total_bins += cant_unit_bins;
                peso_tot_bins += peso_unit_bins;

            }

            t_cant_envases2.Text = total_bins.ToString();
            t_peso_total2.Text = peso_tot_bins.ToString("N2");


        }

        private void btn_quitar_b1_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                return;
            }

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {
                DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Recepción de Carga - Balanza 1 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Grid1.Rows.RemoveAt(fila);

                }

            }

            Calcula_bins();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int nDocEntry, nLineId;

            nDocEntry = 0;
            nLineId = 0;

            try
            {
                nDocEntry = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            try
            {
                nLineId = Convert.ToInt32(t_lineid.Text);

            }
            catch
            {
                nLineId = 0;

            }

            /////////////////////////
            // Balanza 1 ************

            DateTime dt;
            String mensaje, cItemCode;
            int dEnvases;
            double dPesoBruto, dPesoEnvase, dPesoNeto;

            mensaje = clsRomana.SAPB1_ROMANA7(nDocEntry, -2, -2, 1, "", 0, "", 0, 0, 0);

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    dt = Convert.ToDateTime(Grid1[1, i].Value);

                }
                catch
                {
                    dt = DateTime.Now;

                }

                try
                {
                    dPesoBruto = Convert.ToDouble(Grid1[2, i].Value);
                }
                catch
                {
                    dPesoBruto = 0;
                }

                cItemCode = Grid1[3, i].Value.ToString();

                try
                {
                    dPesoEnvase = Convert.ToDouble(Grid1[4, i].Value);
                }
                catch
                {
                    dPesoEnvase = 0;
                }

                try
                {
                    dEnvases = Convert.ToInt32(Grid1[5, i].Value);
                }
                catch
                {
                    dEnvases = 0;
                }

                try
                {
                    dPesoNeto = Convert.ToDouble(Grid1[6, i].Value);
                }
                catch
                {
                    dPesoNeto = 0;
                }

                mensaje = clsRomana.SAPB1_ROMANA7(nDocEntry, -1, nLineId, 1, dt.ToString("yyyyMMdd HH:mm"), float.Parse(dPesoBruto.ToString()), cItemCode, float.Parse(dPesoEnvase.ToString()), dEnvases, float.Parse(dPesoNeto.ToString()));

            }

            /////////////////////////
            // Balanza 2 ************

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                try
                {
                    dt = Convert.ToDateTime(Grid2[1, i].Value);

                }
                catch
                {
                    dt = DateTime.Now;

                }

                try
                {
                    dPesoBruto = Convert.ToDouble(Grid2[2, i].Value);
                }
                catch
                {
                    dPesoBruto = 0;
                }

                cItemCode = Grid2[3, i].Value.ToString();

                try
                {
                    dPesoEnvase = Convert.ToDouble(Grid2[4, i].Value);
                }
                catch
                {
                    dPesoEnvase = 0;
                }

                try
                {
                    dEnvases = Convert.ToInt32(Grid2[5, i].Value);
                }
                catch
                {
                    dEnvases = 0;
                }

                try
                {
                    dPesoNeto = Convert.ToDouble(Grid2[6, i].Value);
                }
                catch
                {
                    dPesoNeto = 0;
                }

                mensaje = clsRomana.SAPB1_ROMANA7(nDocEntry, -1, nLineId, 2, dt.ToString("yyyyMMdd HH:mm"), float.Parse(dPesoBruto.ToString()), cItemCode, float.Parse(dPesoEnvase.ToString()), dEnvases, float.Parse(dPesoNeto.ToString()));

            }

            Close();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Carga_Grilla()
        {
            int nDocEntry, nLineId;

            nDocEntry = 0;
            nLineId = 0;

            try
            {
                nDocEntry = Convert.ToInt32(t_id_romana.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            try
            {
                nLineId = Convert.ToInt32(t_lineid.Text);

            }
            catch
            {
                nLineId = 0;

            }

            DateTime dt;
            string cItemCode;
            int dEnvases;
            double dPesoBruto, dPesoEnvase, dPesoNeto;

            string[] grilla;
            grilla = new string[30];

            /////////////////////////
            // Balanza 1 ************

            ///////////////////////////////////////////////////////

            clsRomana objproducto4 = new clsRomana();
            objproducto4.cls_Consulta_Detalles_Balanza(nDocEntry, nLineId, 1);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto4.cResultado;

            Grid1.Rows.Clear();

            for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            {

                try
                {
                    dt = Convert.ToDateTime(dTable1.Rows[i]["U_Fecha"].ToString());
                }
                catch
                {
                    dt = DateTime.Now;
                }

                try
                {
                    dPesoBruto = Convert.ToDouble(dTable1.Rows[i]["U_PesoBruto"].ToString());
                }
                catch
                {
                    dPesoBruto = 0;
                }

                cItemCode = dTable1.Rows[i]["U_ItemCode"].ToString();

                try
                {
                    dPesoEnvase = Convert.ToDouble(dTable1.Rows[i]["U_PesoEnvase"].ToString());
                }
                catch
                {
                    dPesoEnvase = 0;
                }

                try
                {
                    dEnvases = Convert.ToInt32(dTable1.Rows[i]["U_CantEnvases"].ToString());
                }
                catch
                {
                    dEnvases = 0;
                }

                try
                {
                    dPesoNeto = Convert.ToDouble(dTable1.Rows[i]["U_PesoNeto"].ToString());
                }
                catch
                {
                    dPesoNeto = 0;
                }

                if (cItemCode != "_")
                {

                    grilla[0] = "0";
                    grilla[1] = dt.ToString("dd/MM/yyyy HH:mm");
                    grilla[2] = dPesoBruto.ToString("N2");
                    grilla[3] = cItemCode;
                    grilla[4] = dPesoEnvase.ToString("N2");
                    grilla[5] = dEnvases.ToString();
                    grilla[6] = dPesoNeto.ToString("N2");

                    Grid1.Rows.Add(grilla);

                }

            }

            /////////////////////////
            // Balanza 2 ************

            ///////////////////////////////////////////////////////

            clsRomana objproducto5 = new clsRomana();
            objproducto5.cls_Consulta_Detalles_Balanza(nDocEntry, nLineId, 2);

            DataTable dTable5 = new DataTable();
            dTable5 = objproducto5.cResultado;

            Grid2.Rows.Clear();

            for (int i = 0; i <= dTable5.Rows.Count - 1; i++)
            {
                cItemCode = "";

                try
                {
                    dt = Convert.ToDateTime(dTable5.Rows[i]["U_Fecha"].ToString());
                }
                catch
                {
                    dt = DateTime.Now;
                }

                try
                {
                    dPesoBruto = Convert.ToDouble(dTable5.Rows[i]["U_PesoBruto"].ToString());
                }
                catch
                {
                    dPesoBruto = 0;
                }

                cItemCode = dTable5.Rows[i]["U_ItemCode"].ToString();

                try
                {
                    dPesoEnvase = Convert.ToDouble(dTable5.Rows[i]["U_PesoEnvase"].ToString());
                }
                catch
                {
                    dPesoEnvase = 0;
                }

                try
                {
                    dEnvases = Convert.ToInt32(dTable5.Rows[i]["U_CantEnvases"].ToString());
                }
                catch
                {
                    dEnvases = 0;
                }

                try
                {
                    dPesoNeto = Convert.ToDouble(dTable5.Rows[i]["U_PesoNeto"].ToString());
                }
                catch
                {
                    dPesoNeto = 0;
                }

                if (cItemCode != "_")
                {

                    grilla[0] = "0";
                    grilla[1] = dt.ToString("dd/MM/yyyy HH:mm");
                    grilla[2] = dPesoBruto.ToString("N2");
                    grilla[3] = cItemCode;
                    grilla[4] = dPesoEnvase.ToString("N2");
                    grilla[5] = dEnvases.ToString();
                    grilla[6] = dPesoNeto.ToString("N2");

                    Grid2.Rows.Add(grilla);

                }

            }

            Calcula_bins();

        }

        private void btn_pesaje_entrada2_Click(object sender, EventArgs e)
        {
            string[] grilla;
            grilla = new string[8];

            double dPesoBruto;

            try
            {
                dPesoBruto = Convert.ToDouble(t_PesoBalanza2.Text);
            }
            catch
            {
                dPesoBruto = 0;
            }

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            if (dPesoBruto <= 0)
            {
                MessageBox.Show("Debe ingresar un peso válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

                dPesoBruto = 433;

            }

            grilla[0] = "0";
            grilla[1] = dt.ToString("dd/MM/yyyy HH:mm");
            grilla[2] = dPesoBruto.ToString("N2");
            //grilla[3] = "";
            grilla[4] = 0.ToString("N2");
            grilla[5] = "0";
            grilla[6] = 0.ToString("N2");

            Grid2.Rows.Add(grilla);

        }

        private void btn_quitar_b2_Click(object sender, EventArgs e)
        {
            if (Grid2.RowCount == 0)
            {
                return;
            }

            int fila;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {
                DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Recepción de Carga - Balanza 1 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Grid2.Rows.RemoveAt(fila);

                }

            }

            Calcula_bins();

        }

        private void Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil, cant_bins, peso_bins;
            string cCod_Bins;
            double nPesoNeto, nPesoEnvases, nPesoBruto;

            cant_bins = 0;
            fil = 0;
            cCod_Bins = "";
            peso_bins = 0;

            nPesoNeto = 0;
            nPesoEnvases = 0;
            nPesoBruto = 0;

            try
            {
                fil = Grid2.CurrentCell.RowIndex;
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
                cCod_Bins = Grid2[3, fil].Value.ToString();

            }
            catch
            {
                cCod_Bins = "";

            }

            try
            {
                nPesoNeto = Convert.ToDouble(Grid2[2, fil].Value);

            }
            catch
            {
                nPesoNeto = 0;

            }

            try
            {
                cant_bins = Convert.ToInt32(Grid2[5, fil].Value);

            }
            catch
            {
                cant_bins = 0;

            }

            if (cant_bins > 3)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos (No pueden ser mas de 3 envases por peso), opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cant_bins = 0;
            }

            peso_bins = 0;

            if (cCod_Bins != "")
            {

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Producto_x_codigo(cCod_Bins);

                DataTable dTable = new DataTable();

                dTable = objproducto.cResultado;

                try
                {
                    peso_bins = Convert.ToInt32(dTable.Rows[0].ItemArray[3].ToString());

                }
                catch
                {
                    peso_bins = 0;
                }

            }

            Grid2[4, fil].Value = peso_bins.ToString("N2");
            Grid2[5, fil].Value = cant_bins.ToString();

            nPesoEnvases = cant_bins * peso_bins;

            nPesoBruto = nPesoNeto - nPesoEnvases;

            if (nPesoEnvases == 0)
            {
                nPesoBruto = 0;
            }

            if (nPesoBruto < 0)
            {
                nPesoBruto = 0;
            }

            Grid2[6, fil].Value = nPesoBruto.ToString("N2");

            Calcula_bins();
        }
    }


}
