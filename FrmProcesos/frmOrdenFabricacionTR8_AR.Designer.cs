namespace FrmProcesos
{
    partial class frmOrdenFabricacionTR8_AR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionTR8_AR));
            this.SAPB1_OPRODUCCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet11 = new FrmProcesos.HDV_P03DataSet11();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_OPRODUCCIONTableAdapter = new FrmProcesos.HDV_P03DataSet11TableAdapters.SAPB1_OPRODUCCIONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_OPRODUCCIONBindingSource
            // 
            this.SAPB1_OPRODUCCIONBindingSource.DataMember = "SAPB1_OPRODUCCION";
            this.SAPB1_OPRODUCCIONBindingSource.DataSource = this.HDV_P03DataSet11;
            this.SAPB1_OPRODUCCIONBindingSource.CurrentChanged += new System.EventHandler(this.SAPB1_OPRODUCCIONBindingSource_CurrentChanged);
            // 
            // HDV_P03DataSet11
            // 
            this.HDV_P03DataSet11.DataSetName = "HDV_P03DataSet11";
            this.HDV_P03DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_OPRODUCCIONBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportA7_AR.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(819, 528);
            this.reportViewer2.TabIndex = 9;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_OPRODUCCIONTableAdapter
            // 
            this.SAPB1_OPRODUCCIONTableAdapter.ClearBeforeFill = true;
            // 
            // frmOrdenFabricacionTR8_AR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 528);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrdenFabricacionTR8_AR";
            this.Text = "Vista Previa - Tarja de Producción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTR8_AR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_OPRODUCCIONBindingSource;
        private HDV_P03DataSet11 HDV_P03DataSet11;
        private HDV_P03DataSet11TableAdapters.SAPB1_OPRODUCCIONTableAdapter SAPB1_OPRODUCCIONTableAdapter;
    }
}