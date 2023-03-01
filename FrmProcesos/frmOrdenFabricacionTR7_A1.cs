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
    public partial class frmOrdenFabricacionTR7_A1 : Form
    {
        public frmOrdenFabricacionTR7_A1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR7_A1_Load(object sender, EventArgs e)
        {

            try
            {

                SAPB1_OPRODUCCION4TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");


                int nEntMercaderia;

                nEntMercaderia = 0;

                try
                {
                    nEntMercaderia = VariablesGlobales.glb_DocEntry;
                }
                catch
                {
                    nEntMercaderia = 0;
                }

                SAPB1_OPRODUCCION4TableAdapter.Fill(this.HDV_P03DataSet13.SAPB1_OPRODUCCION4, nEntMercaderia);
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
