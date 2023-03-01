namespace FrmProcesos
{
    partial class frmRomana3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRomana3));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet38 = new FrmProcesos.HDV_P03DataSet38();
            this.SAPB1_ROMANA1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ROMANA1TableAdapter = new FrmProcesos.HDV_P03DataSet38TableAdapters.SAPB1_ROMANA1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ROMANA1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.Report7v1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(522, 356);
            this.reportViewer2.TabIndex = 1;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet38
            // 
            this.HDV_P03DataSet38.DataSetName = "HDV_P03DataSet38";
            this.HDV_P03DataSet38.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ROMANA1BindingSource
            // 
            this.SAPB1_ROMANA1BindingSource.DataMember = "SAPB1_ROMANA1";
            this.SAPB1_ROMANA1BindingSource.DataSource = this.HDV_P03DataSet38;
            // 
            // SAPB1_ROMANA1TableAdapter
            // 
            this.SAPB1_ROMANA1TableAdapter.ClearBeforeFill = true;
            // 
            // frmRomana3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 356);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRomana3";
            this.Text = "Vista Previa - Recepción de Carga";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRomana3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ROMANA1BindingSource;
        private HDV_P03DataSet38 HDV_P03DataSet38;
        private HDV_P03DataSet38TableAdapters.SAPB1_ROMANA1TableAdapter SAPB1_ROMANA1TableAdapter;
    }
}