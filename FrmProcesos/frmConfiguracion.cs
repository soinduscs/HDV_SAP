using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Printing;

namespace FrmProcesos
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 0;
            }

            try
            {
                nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            }
            catch
            {
                nBalanza_BitsDatos = 0;
            }

            t_puerto.Text = cBalanza_Puerto;
            t_baudios.Text = nBalanza_Baudios.ToString();
            t_bits_datos.Text = nBalanza_BitsDatos.ToString();

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

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            
            int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;

            try
            {
                nBalanza_Baudios = int.Parse(t_baudios.Text);
            }
            catch
            {
                nBalanza_Baudios = 0;
            }

            try
            {
                nBalanza_BitsDatos = int.Parse(t_bits_datos.Text);
            }
            catch
            {
                nBalanza_BitsDatos = 0;
            }

            if (t_puerto.Text == "")
            {
                MessageBox.Show("Debe ingresar un Puerto válido, opción Cancelada", "Configuración de Balanza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nBalanza_Baudios == 0)
            {
                MessageBox.Show("Debe ingresar un registro de baudios válidos, opción Cancelada", "Configuración de Balanza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nBalanza_BitsDatos == 0)
            {
                MessageBox.Show("Debe ingresar un registro de bits válidos, opción Cancelada", "Configuración de Balanza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //ConfigurationManager.AppSettings.Set("Balanza_Puerto",  t_puerto.Text);
            //ConfigurationManager.AppSettings.GetValues("").w
            ////t_baudios.Text = nBalanza_Baudios.ToString();
            //t_bits_datos.Text = nBalanza_BitsDatos.ToString();

            //cBalanza_Puerto = t_puerto.Text;





        }
    }
}
