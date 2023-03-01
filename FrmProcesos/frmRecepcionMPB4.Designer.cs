namespace FrmProcesos
{
    partial class frmRecepcionMPB4
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
            this.SAPB1_RECEPCION6BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet34 = new FrmProcesos.HDV_P03DataSet34();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_RECEPCION6TableAdapter = new FrmProcesos.HDV_P03DataSet34TableAdapters.SAPB1_RECEPCION6TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_RECEPCION6BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet34)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_RECEPCION6BindingSource
            // 
            this.SAPB1_RECEPCION6BindingSource.DataMember = "SAPB1_RECEPCION6";
            this.SAPB1_RECEPCION6BindingSource.DataSource = this.HDV_P03DataSet34;
            // 
            // HDV_P03DataSet34
            // 
            this.HDV_P03DataSet34.DataSetName = "HDV_P03DataSet34";
            this.HDV_P03DataSet34.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_RECEPCION6BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.Report9.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(548, 463);
            this.reportViewer2.TabIndex = 3;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_RECEPCION6TableAdapter
            // 
            this.SAPB1_RECEPCION6TableAdapter.ClearBeforeFill = true;
            // 
            // frmRecepcionMPB4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 463);
            this.Controls.Add(this.reportViewer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRecepcionMPB4";
            this.Text = "Vista Previa - Guía de Traslado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecepcionMPB4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_RECEPCION6BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet34)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_RECEPCION6BindingSource;
        private HDV_P03DataSet34 HDV_P03DataSet34;
        private HDV_P03DataSet34TableAdapters.SAPB1_RECEPCION6TableAdapter SAPB1_RECEPCION6TableAdapter;
    }
}