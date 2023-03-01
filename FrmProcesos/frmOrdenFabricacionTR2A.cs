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
    public partial class frmOrdenFabricacionTR2A : Form
    {
        public frmOrdenFabricacionTR2A()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR2A_Load(object sender, EventArgs e)
        {

            int nDocEntry;

            nDocEntry = 0;

            try
            {
                nDocEntry = VariablesGlobales.glb_id_romana;
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {

                SAPB1_ACCESO2TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                this.SAPB1_ACCESO2TableAdapter.Fill(this.HDV_P03DataSet12.SAPB1_ACCESO2, VariablesGlobales.glb_NumOF , VariablesGlobales.glb_DocEntry);

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
