namespace FrmProcesos
{
    partial class frmOrdenFabricacionTR8_A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionTR8_A));
            this.SAPB1_OPRODUCCION4v1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet33 = new FrmProcesos.HDV_P03DataSet33();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_OPRODUCCION4v1TableAdapter = new FrmProcesos.HDV_P03DataSet33TableAdapters.SAPB1_OPRODUCCION4v1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCION4v1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet33)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_OPRODUCCION4v1BindingSource
            // 
            this.SAPB1_OPRODUCCION4v1BindingSource.DataMember = "SAPB1_OPRODUCCION4v1";
            this.SAPB1_OPRODUCCION4v1BindingSource.DataSource = this.HDV_P03DataSet33;
            // 
            // HDV_P03DataSet33
            // 
            this.HDV_P03DataSet33.DataSetName = "HDV_P03DataSet33";
            this.HDV_P03DataSet33.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_OPRODUCCION4v1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportD7.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(674, 444);
            this.reportViewer2.TabIndex = 8;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_OPRODUCCION4v1TableAdapter
            // 
            this.SAPB1_OPRODUCCION4v1TableAdapter.ClearBeforeFill = true;
            // 
            // frmOrdenFabricacionTR8_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(674, 444);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenFabricacionTR8_A";
            this.Text = "Vista Previa - Tarja de Producción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTR8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_OPRODUCCION4v1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet33)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_OPRODUCCION4v1BindingSource;
        private HDV_P03DataSet33 HDV_P03DataSet33;
        private HDV_P03DataSet33TableAdapters.SAPB1_OPRODUCCION4v1TableAdapter SAPB1_OPRODUCCION4v1TableAdapter;
    }
}