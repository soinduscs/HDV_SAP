namespace FrmProcesos
{
    partial class frmCalidadMPA3_A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadMPA3_A));
            this.SAPB1_ORCAL4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet36 = new FrmProcesos.HDV_P03DataSet36();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_ORCAL4TableAdapter = new FrmProcesos.HDV_P03DataSet36TableAdapters.SAPB1_ORCAL4TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet36)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_ORCAL4BindingSource
            // 
            this.SAPB1_ORCAL4BindingSource.DataMember = "SAPB1_ORCAL4";
            this.SAPB1_ORCAL4BindingSource.DataSource = this.HDV_P03DataSet36;
            // 
            // HDV_P03DataSet36
            // 
            this.HDV_P03DataSet36.DataSetName = "HDV_P03DataSet36";
            this.HDV_P03DataSet36.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ORCAL4BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportB4_A.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(480, 343);
            this.reportViewer2.TabIndex = 11;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_ORCAL4TableAdapter
            // 
            this.SAPB1_ORCAL4TableAdapter.ClearBeforeFill = true;
            // 
            // frmCalidadMPA3_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 343);
            this.Controls.Add(this.reportViewer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadMPA3_A";
            this.Text = "Vista Previa - Registro de Inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCalidadMPA3_A_FormClosed);
            this.Load += new System.EventHandler(this.frmCalidadMPA3_A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet36)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ORCAL4BindingSource;
        private HDV_P03DataSet36 HDV_P03DataSet36;
        private HDV_P03DataSet36TableAdapters.SAPB1_ORCAL4TableAdapter SAPB1_ORCAL4TableAdapter;
    }
}