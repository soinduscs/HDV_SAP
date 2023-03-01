namespace FrmProcesos
{
    partial class frmOrdenFabricacionTR2A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionTR2A));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HDV_P03DataSet12 = new FrmProcesos.HDV_P03DataSet12();
            this.SAPB1_ACCESO2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SAPB1_ACCESO2TableAdapter = new FrmProcesos.HDV_P03DataSet12TableAdapters.SAPB1_ACCESO2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ACCESO2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ACCESO2BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportD5.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(530, 435);
            this.reportViewer2.TabIndex = 5;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // HDV_P03DataSet12
            // 
            this.HDV_P03DataSet12.DataSetName = "HDV_P03DataSet12";
            this.HDV_P03DataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SAPB1_ACCESO2BindingSource
            // 
            this.SAPB1_ACCESO2BindingSource.DataMember = "SAPB1_ACCESO2";
            this.SAPB1_ACCESO2BindingSource.DataSource = this.HDV_P03DataSet12;
            // 
            // SAPB1_ACCESO2TableAdapter
            // 
            this.SAPB1_ACCESO2TableAdapter.ClearBeforeFill = true;
            // 
            // frmOrdenFabricacionTR2A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 435);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenFabricacionTR2A";
            this.Text = "Vista Previa - Pre Tarja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTR2A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ACCESO2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ACCESO2BindingSource;
        private HDV_P03DataSet12 HDV_P03DataSet12;
        private HDV_P03DataSet12TableAdapters.SAPB1_ACCESO2TableAdapter SAPB1_ACCESO2TableAdapter;
    }
}