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
    public partial class frmRecepcionMPB4 : Form
    {
        public frmRecepcionMPB4()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB4_Load(object sender, EventArgs e)
        {

            try
            {

                SAPB1_RECEPCION6TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                int nEntMercaderia, nTransfStock;

                nEntMercaderia = 0;
                nTransfStock = 0;

                try
                {
                    nEntMercaderia = int.Parse(VariablesGlobales.glb_Referencia1);
                }
                catch
                {
                    nEntMercaderia = 0;
                }

                try
                {
                    nTransfStock = int.Parse(VariablesGlobales.glb_Referencia2);
                }
                catch
                {
                    nTransfStock = 0;
                }

                this.SAPB1_RECEPCION6TableAdapter.Fill(this.HDV_P03DataSet34.SAPB1_RECEPCION6, nEntMercaderia);

                reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
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
