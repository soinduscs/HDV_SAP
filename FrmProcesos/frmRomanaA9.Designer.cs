namespace FrmProcesos
{
    partial class frmRomanaA9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRomanaA9));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet44 = new FrmProcesos.HDV_P03DataSet44();
            this.SAPB1_ROMANA1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ROMANA1TableAdapter = new FrmProcesos.HDV_P03DataSet44TableAdapters.SAPB1_ROMANA1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ROMANA1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.Report7_D.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(672, 375);
            this.reportViewer2.TabIndex = 2;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet44
            // 
            this.HDV_P03DataSet44.DataSetName = "HDV_P03DataSet44";
            this.HDV_P03DataSet44.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ROMANA1BindingSource
            // 
            this.SAPB1_ROMANA1BindingSource.DataMember = "SAPB1_ROMANA1";
            this.SAPB1_ROMANA1BindingSource.DataSource = this.HDV_P03DataSet44;
            // 
            // SAPB1_ROMANA1TableAdapter
            // 
            this.SAPB1_ROMANA1TableAdapter.ClearBeforeFill = true;
            // 
            // frmRomanaA9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 375);
            this.Controls.Add(this.reportViewer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRomanaA9";
            this.Text = "Vista Previa - Guía de Traslado Interna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRomanaA9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ROMANA1BindingSource;
        private HDV_P03DataSet44 HDV_P03DataSet44;
        private HDV_P03DataSet44TableAdapters.SAPB1_ROMANA1TableAdapter SAPB1_ROMANA1TableAdapter;
    }
}