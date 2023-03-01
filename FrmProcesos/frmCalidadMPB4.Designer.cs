namespace FrmProcesos
{
    partial class frmCalidadMPB4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadMPB4));
            this.SAPB1_ORCAL3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet37 = new FrmProcesos.HDV_P03DataSet37();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_ORCAL3TableAdapter = new FrmProcesos.HDV_P03DataSet37TableAdapters.SAPB1_ORCAL3TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet37)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_ORCAL3BindingSource
            // 
            this.SAPB1_ORCAL3BindingSource.DataMember = "SAPB1_ORCAL3";
            this.SAPB1_ORCAL3BindingSource.DataSource = this.HDV_P03DataSet37;
            // 
            // HDV_P03DataSet37
            // 
            this.HDV_P03DataSet37.DataSetName = "HDV_P03DataSet37";
            this.HDV_P03DataSet37.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ORCAL3BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportD3_A1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(624, 511);
            this.reportViewer2.TabIndex = 10;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_ORCAL3TableAdapter
            // 
            this.SAPB1_ORCAL3TableAdapter.ClearBeforeFill = true;
            // 
            // frmCalidadMPB4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 511);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalidadMPB4";
            this.Text = "Vista Previa - Registro de Inspección";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCalidadMPB4_FormClosed);
            this.Load += new System.EventHandler(this.frmCalidadMPB4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ORCAL3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet37)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ORCAL3BindingSource;
        private HDV_P03DataSet37 HDV_P03DataSet37;
        private HDV_P03DataSet37TableAdapters.SAPB1_ORCAL3TableAdapter SAPB1_ORCAL3TableAdapter;
    }
}