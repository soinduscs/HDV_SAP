namespace FrmProcesos
{
    partial class frmCalidadMPA6
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadMPA6));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet17 = new FrmProcesos.HDV_P03DataSet17();
            this.SAPB1_ORCAL6BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ORCAL6TableAdapter = new FrmProcesos.HDV_P03DataSet17TableAdapters.SAPB1_ORCAL6TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL6BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.SAPB1_ORCAL6BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportB6.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(775, 514);
            this.reportViewer2.TabIndex = 11;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet17
            // 
            this.HDV_P03DataSet17.DataSetName = "HDV_P03DataSet17";
            this.HDV_P03DataSet17.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ORCAL6BindingSource
            // 
            this.SAPB1_ORCAL6BindingSource.DataMember = "SAPB1_ORCAL6";
            this.SAPB1_ORCAL6BindingSource.DataSource = this.HDV_P03DataSet17;
            // 
            // SAPB1_ORCAL6TableAdapter
            // 
            this.SAPB1_ORCAL6TableAdapter.ClearBeforeFill = true;
            // 
            // frmCalidadMPA6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(775, 514);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadMPA6";
            this.Text = "Vista Previa - Registro de Inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCalidadMPA6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL6BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ORCAL6BindingSource;
        private HDV_P03DataSet17 HDV_P03DataSet17;
        private HDV_P03DataSet17TableAdapters.SAPB1_ORCAL6TableAdapter SAPB1_ORCAL6TableAdapter;
    }
}