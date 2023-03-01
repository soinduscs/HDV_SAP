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
    public partial class frmOrdenFabricacionTR9_B : Form
    {
        public frmOrdenFabricacionTR9_B()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR9_B_Load(object sender, EventArgs e)
        {

            try
            {

                SAPB1_OPRODUCCIONTableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                int nEntMercaderia;
                string cWhsCode;

                nEntMercaderia = 0;
                cWhsCode = "";

                try
                {
                    nEntMercaderia = VariablesGlobales.glb_DocEntry;
                }
                catch
                {
                    nEntMercaderia = 0;
                }

                try
                {
                    cWhsCode = VariablesGlobales.glb_Almacen;
                }
                catch
                {
                    cWhsCode = "";
                }

                SAPB1_OPRODUCCIONTableAdapter.Fill(this.HDV_P03DataSet20.SAPB1_OPRODUCCION, nEntMercaderia, cWhsCode);
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
