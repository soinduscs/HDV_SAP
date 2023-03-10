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
    public partial class frmCalidadPPA2 : Form
    {
        public frmCalidadPPA2()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'HDV_P03DataSet25.xSapb1_utiles_informeordenventa_calidad' Puede moverla o quitarla según sea necesario.

            int nIdImagen;

            nIdImagen = 9;

            if (VariablesGlobales.glb_Referencia1 == "0")
            {
                nIdImagen = 0;

            }

            if (VariablesGlobales.glb_Referencia1 == "1")
            {
                nIdImagen = 1;

            }

            if (VariablesGlobales.glb_Referencia1 == "2")
            {
                nIdImagen = 2;

            }

            try
            {
                xSapb1_utiles_informeordenventa_calidadTableAdapter.Connection.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

                xSapb1_utiles_informeordenventa_calidadTableAdapter.Fill(this.HDV_P03DataSet25.xSapb1_utiles_informeordenventa_calidad, "N", VariablesGlobales.glb_DocEntry, VariablesGlobales.glb_ItemCode, nIdImagen);

                reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

                reportViewer2.RefreshReport();

            }
            catch
            {

            }

            reportViewer2.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 5, 5);

            reportViewer2.RefreshReport();

        }

    }
}
