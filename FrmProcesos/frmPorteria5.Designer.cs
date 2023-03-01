namespace FrmProcesos
{
    partial class frmPorteria5
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
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet6 = new FrmProcesos.HDV_P03DataSet6();
            this.SAPB1_ACCESO1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ACCESO1TableAdapter = new FrmProcesos.HDV_P03DataSet6TableAdapters.SAPB1_ACCESO1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ACCESO1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ACCESO1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.Report6.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(614, 557);
            this.reportViewer2.TabIndex = 3;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet6
            // 
            this.HDV_P03DataSet6.DataSetName = "HDV_P03DataSet6";
            this.HDV_P03DataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ACCESO1BindingSource
            // 
            this.SAPB1_ACCESO1BindingSource.DataMember = "SAPB1_ACCESO1";
            this.SAPB1_ACCESO1BindingSource.DataSource = this.HDV_P03DataSet6;
            // 
            // SAPB1_ACCESO1TableAdapter
            // 
            this.SAPB1_ACCESO1TableAdapter.ClearBeforeFill = true;
            // 
            // frmPorteria5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 557);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPorteria5";
            this.Text = "Vista Previa - Documento de Despacho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPorteria5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ACCESO1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ACCESO1BindingSource;
        private HDV_P03DataSet6 HDV_P03DataSet6;
        private HDV_P03DataSet6TableAdapters.SAPB1_ACCESO1TableAdapter SAPB1_ACCESO1TableAdapter;
    }
}