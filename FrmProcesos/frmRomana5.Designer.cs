﻿namespace FrmProcesos
{
    partial class frmRomana5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRomana5));
            this.SAPB1_ROMANA1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HDV_P03DataSet21 = new FrmProcesos.HDV_P03DataSet21();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SAPB1_ROMANA1TableAdapter = new FrmProcesos.HDV_P03DataSet21TableAdapters.SAPB1_ROMANA1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet21)).BeginInit();
            this.SuspendLayout();
            // 
            // SAPB1_ROMANA1BindingSource
            // 
            this.SAPB1_ROMANA1BindingSource.DataMember = "SAPB1_ROMANA1";
            this.SAPB1_ROMANA1BindingSource.DataSource = this.HDV_P03DataSet21;
            // 
            // HDV_P03DataSet21
            // 
            this.HDV_P03DataSet21.DataSetName = "HDV_P03DataSet21";
            this.HDV_P03DataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SAPB1_ROMANA1BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FrmProcesos.Reportes.ReportB9.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewer2.Size = new System.Drawing.Size(445, 329);
            this.reportViewer2.TabIndex = 2;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // SAPB1_ROMANA1TableAdapter
            // 
            this.SAPB1_ROMANA1TableAdapter.ClearBeforeFill = true;
            // 
            // frmRomana5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 329);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRomana5";
            this.Text = "Vista Previa - Ticket de Pesaje";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRomana5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAPB1_ROMANA1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDV_P03DataSet21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource SAPB1_ROMANA1BindingSource;
        private HDV_P03DataSet21 HDV_P03DataSet21;
        private HDV_P03DataSet21TableAdapters.SAPB1_ROMANA1TableAdapter SAPB1_ROMANA1TableAdapter;
    }
}