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
    public partial class frmRecepcionMP5 : Form
    {
        public frmRecepcionMP5()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP5_Load(object sender, EventArgs e)
        {


            try
            {

                SAPB1_RECEPCION5TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");


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

                this.SAPB1_RECEPCION5TableAdapter.Fill(this.HDV_P03DataSet43.SAPB1_RECEPCION5, nEntMercaderia, nTransfStock);

                //reportViewer2.Width = 8;
                //reportViewer2.Height = 11;
                //reportViewer2.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

                //reportViewer2.LocalReport.SetParameters(parameters);
                reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);
                //reportViewer2.
                reportViewer2.RefreshReport();



            }
            catch
            {

            }

            this.reportViewer2.RefreshReport();

        }
    }
}
