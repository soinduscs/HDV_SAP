namespace FrmProcesos
{
    partial class frmOrdenFabricacionTR7_A1
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
            this.HDV_P03DataSet13 = new FrmProcesos.HDV_P03DataSet13();
            this.SAPB1_OPRODUCCION4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_OPRODUCCION4TableAdapter = new FrmProcesos.HDV_P03DataSet13TableAdapters.SAPB1_OPRODUCCION4TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCION4BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_OPRODUCCION4BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportA9.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(284, 261);
            this.reportViewer2.TabIndex = 8;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet13
            // 
            this.HDV_P03DataSet13.DataSetName = "HDV_P03DataSet13";
            this.HDV_P03DataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_OPRODUCCION4BindingSource
            // 
            this.SAPB1_OPRODUCCION4BindingSource.DataMember = "SAPB1_OPRODUCCION4";
            this.SAPB1_OPRODUCCION4BindingSource.DataSource = this.HDV_P03DataSet13;
            // 
            // SAPB1_OPRODUCCION4TableAdapter
            // 
            this.SAPB1_OPRODUCCION4TableAdapter.ClearBeforeFill = true;
            // 
            // frmOrdenFabricacionTR7_A1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer2);
            this.Name = "frmOrdenFabricacionTR7_A1";
            this.Text = "frmOrdenFabricacionTR7_A1";
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTR7_A1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCION4BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_OPRODUCCION4BindingSource;
        private HDV_P03DataSet13 HDV_P03DataSet13;
        private HDV_P03DataSet13TableAdapters.SAPB1_OPRODUCCION4TableAdapter SAPB1_OPRODUCCION4TableAdapter;
    }
}