namespace FrmProcesos
{
    partial class frmCalidadMP6
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
            this.HDV_P03DataSet14 = new FrmProcesos.HDV_P03DataSet14();
            this.SAPB1_ORCAL3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ORCAL3TableAdapter = new FrmProcesos.HDV_P03DataSet14TableAdapters.SAPB1_ORCAL3TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ORCAL3BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportB3.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(602, 328);
            this.reportViewer2.TabIndex = 9;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet14
            // 
            this.HDV_P03DataSet14.DataSetName = "HDV_P03DataSet14";
            this.HDV_P03DataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ORCAL3BindingSource
            // 
            this.SAPB1_ORCAL3BindingSource.DataMember = "SAPB1_ORCAL3";
            this.SAPB1_ORCAL3BindingSource.DataSource = this.HDV_P03DataSet14;
            // 
            // SAPB1_ORCAL3TableAdapter
            // 
            this.SAPB1_ORCAL3TableAdapter.ClearBeforeFill = true;
            // 
            // frmCalidadMP6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 328);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCalidadMP6";
            this.Text = "Vista Previa - Registro de Inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCalidadMP6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL3BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ORCAL3BindingSource;
        private HDV_P03DataSet14 HDV_P03DataSet14;
        private HDV_P03DataSet14TableAdapters.SAPB1_ORCAL3TableAdapter SAPB1_ORCAL3TableAdapter;
    }
}