namespace FrmProcesos
{
    partial class frmRecepcionMP5
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
            this.HDV_P03DataSet43 = new FrmProcesos.HDV_P03DataSet43();
            this.SAPB1_RECEPCION5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_RECEPCION5TableAdapter = new FrmProcesos.HDV_P03DataSet43TableAdapters.SAPB1_RECEPCION5TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_RECEPCION5BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_RECEPCION5BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.Report8v2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(747, 528);
            this.reportViewer2.TabIndex = 2;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet43
            // 
            this.HDV_P03DataSet43.DataSetName = "HDV_P03DataSet43";
            this.HDV_P03DataSet43.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_RECEPCION5BindingSource
            // 
            this.SAPB1_RECEPCION5BindingSource.DataMember = "SAPB1_RECEPCION5";
            this.SAPB1_RECEPCION5BindingSource.DataSource = this.HDV_P03DataSet43;
            // 
            // SAPB1_RECEPCION5TableAdapter
            // 
            this.SAPB1_RECEPCION5TableAdapter.ClearBeforeFill = true;
            // 
            // frmRecepcionMP5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 528);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRecepcionMP5";
            this.Text = "Vista Previa - Tarja de Recepción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecepcionMP5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_RECEPCION5BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_RECEPCION5BindingSource;
        private HDV_P03DataSet43 HDV_P03DataSet43;
        private HDV_P03DataSet43TableAdapters.SAPB1_RECEPCION5TableAdapter SAPB1_RECEPCION5TableAdapter;
    }
}