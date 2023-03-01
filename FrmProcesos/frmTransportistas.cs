using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using System.IO.Ports;
using System.Threading;

namespace FrmProcesos
{
    public partial class frmTransportistas : Form
    {
        public frmTransportistas()
        {
            InitializeComponent();
        }

        private void frmTransportistas_Load(object sender, EventArgs e)
        {
            this.Size = new Size(300, 380);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = entSocioNegocio.ListaTCRD_Transportistas();
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo";
                this.dataGridView1.Columns[0].Width = 80;
                this.dataGridView1.Columns[1].HeaderText = "Transportista";
                this.dataGridView1.Columns[1].Width = 250;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            frmTransportistas1 f2 = new frmTransportistas1();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            int nBaudio;

            try
            {
                nBaudio = int.Parse(textBox1.Text);
            }
            catch
            {
                nBaudio = 1200;
            } 

            //Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;
            string b, c;

            SerialPort mySerialPort = new SerialPort("COM1");

            mySerialPort.BaudRate = 1200;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;
            //mySerialPort.DtrEnable = 
           

            mySerialPort.Open();

          

            while (true)
            {
                b = (string)mySerialPort.ReadExisting();
                c = ""; // (string)mySerialPort.ReadLine();

                grilla[0] = i.ToString();
                grilla[1] = b;
                grilla[2] = c;

                //Grid_Peso.Rows.Add(grilla);

                Thread.Sleep(50);

                i += 1;

                if (i > 100)
                {
                    break;
                }

            }

            mySerialPort.Close();
        }
    }
}
