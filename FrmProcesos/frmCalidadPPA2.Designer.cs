namespace FrmProcesos
{
    partial class frmCalidadPPA2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPPA2));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet25 = new FrmProcesos.HDV_P03DataSet25();
            this.xSapb1_utiles_informeordenventa_calidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xSapb1_utiles_informeordenventa_calidadTableAdapter = new FrmProcesos.HDV_P03DataSet25TableAdapters.xSapb1_utiles_informeordenventa_calidadTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSapb1_utiles_informeordenventa_calidadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.xSapb1_utiles_informeordenventa_calidadBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportC6.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(1007, 430);
            this.reportViewer2.TabIndex = 16;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet25
            // 
            this.HDV_P03DataSet25.DataSetName = "HDV_P03DataSet25";
            this.HDV_P03DataSet25.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xSapb1_utiles_informeordenventa_calidadBindingSource
            // 
            this.xSapb1_utiles_informeordenventa_calidadBindingSource.DataMember = "xSapb1_utiles_informeordenventa_calidad";
            this.xSapb1_utiles_informeordenventa_calidadBindingSource.DataSource = this.HDV_P03DataSet25;
            // 
            // xSapb1_utiles_informeordenventa_calidadTableAdapter
            // 
            this.xSapb1_utiles_informeordenventa_calidadTableAdapter.ClearBeforeFill = true;
            // 
            // frmCalidadPPA2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 430);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadPPA2";
            this.Text = "Vista Previa - Certificado de Calidad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCalidadPPA2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSapb1_utiles_informeordenventa_calidadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource xSapb1_utiles_informeordenventa_calidadBindingSource;
        private HDV_P03DataSet25 HDV_P03DataSet25;
        private HDV_P03DataSet25TableAdapters.xSapb1_utiles_informeordenventa_calidadTableAdapter xSapb1_utiles_informeordenventa_calidadTableAdapter;
    }
}