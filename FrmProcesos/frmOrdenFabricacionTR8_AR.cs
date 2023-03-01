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
    public partial class frmOrdenFabricacionTR8_AR : Form
    {
        public frmOrdenFabricacionTR8_AR()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTR8_AR_Load(object sender, EventArgs e)
        {
            try
            {

                SAPB1_OPRODUCCIONTableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");


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

                string cObjeto;

                try
                {
                    cObjeto = VariablesGlobales.glb_Object;
                }
                catch
                {
                    cObjeto = "";
                }

                string cLote;

                try
                {
                    cLote = VariablesGlobales.glb_Lote.ToString();
                }
                catch
                {
                    cLote = "";
                }

                SAPB1_OPRODUCCIONTableAdapter.Fill(this.HDV_P03DataSet11.SAPB1_OPRODUCCION, nEntMercaderia, cObjeto, cLote);

                //SAPB1_OPRODUCCIONTableAdapter.Fill(this.HDV_P03DataSet11.SAPB1_OPRODUCCION, nEntMercaderia);
                reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);
                reportViewer2.RefreshReport();

            }
            catch
            {

            }

            this.reportViewer2.RefreshReport();


        }

        private void SAPB1_OPRODUCCIONBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
