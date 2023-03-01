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
    public partial class frmPorteria5 : Form
    {
        public frmPorteria5()
        {
            InitializeComponent();
        }

        private void frmPorteria5_Load(object sender, EventArgs e)
        {
            
            try
            {

                SAPB1_ACCESO1TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                int nDocEntry;

                nDocEntry = 0;

                try
                {
                    nDocEntry = VariablesGlobales.glb_DocEntry;
                }
                catch
                {
                    nDocEntry = 0;
                }

                //nDocEntry = 1;

                this.SAPB1_ACCESO1TableAdapter.Fill(this.HDV_P03DataSet6.SAPB1_ACCESO1, nDocEntry);

                reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

                reportViewer2.RefreshReport();

            }
            catch
            {

            }

            this.reportViewer2.RefreshReport();



        }
    }
}
