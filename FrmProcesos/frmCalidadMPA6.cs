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
    public partial class frmCalidadMPA6 : Form
    {
        public frmCalidadMPA6()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA6_Load(object sender, EventArgs e)
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

            SAPB1_ORCAL6TableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

            SAPB1_ORCAL6TableAdapter.Fill(this.HDV_P03DataSet17.SAPB1_ORCAL6, nIdCalidad);

            reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

            reportViewer2.RefreshReport();

        }

    }

}
