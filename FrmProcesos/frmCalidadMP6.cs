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
    public partial class frmCalidadMP6 : Form
    {
        public frmCalidadMP6()
        {
            InitializeComponent();
        }

        private void frmCalidadMP6_Load(object sender, EventArgs e)
        {

            int nIdCalidad;
            string cTipoInforme;

            nIdCalidad = 0;
            cTipoInforme = "";

            try
            {
                nIdCalidad = VariablesGlobales.glb_id_calidad;

            }
            catch
            {
                nIdCalidad = 0;

            }

            try
            {
                cTipoInforme = VariablesGlobales.glb_Referencia1;

            }
            catch
            {
                cTipoInforme = "";

            }

            SAPB1_ORCAL3TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

            SAPB1_ORCAL3TableAdapter.Fill(this.HDV_P03DataSet14.SAPB1_ORCAL3, nIdCalidad);

            reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

            reportViewer2.RefreshReport();

        }
    }
}
