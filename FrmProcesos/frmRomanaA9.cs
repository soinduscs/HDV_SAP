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
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmRomanaA9 : Form
    {
        public frmRomanaA9()
        {
            InitializeComponent();
        }

        private void frmRomanaA9_Load(object sender, EventArgs e)
        {
            int id_romana;

            id_romana = 0;

            try
            {
                id_romana = VariablesGlobales.glb_id_romana;

            }
            catch
            {
                id_romana = 0;
            }

            try
            {
                SAPB1_ROMANA1TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                this.SAPB1_ROMANA1TableAdapter.Fill(this.HDV_P03DataSet44.SAPB1_ROMANA1, id_romana, 0);

                reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

                reportViewer2.RefreshReport();

            }
            catch
            {

            }

            reportViewer2.RefreshReport();

        }
    }
}
