﻿
namespace FrmProcesos
{
    partial class FRP12
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRP12));
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.cbb_turno = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.Grid3 = new System.Windows.Forms.DataGridView();
            this.lbl_turno_B = new System.Windows.Forms.Label();
            this.lbl_turno_A = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(11, 699);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 177;
            this.btn_cancelar.Text = "Cerrar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column14,
            this.Column1,
            this.Column2});
            this.Grid1.Location = new System.Drawing.Point(5, 20);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(514, 116);
            this.Grid1.TabIndex = 176;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_actualizar.Image = global::FrmProcesos.Properties.Resources.action_refresh;
            this.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_actualizar.Location = new System.Drawing.Point(226, 4);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(89, 22);
            this.btn_actualizar.TabIndex = 178;
            this.btn_actualizar.Text = "  Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(11, 5);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(200, 21);
            this.dtp_fecha.TabIndex = 180;
            // 
            // cbb_turno
            // 
            this.cbb_turno.FormattingEnabled = true;
            this.cbb_turno.Items.AddRange(new object[] {
            "Turno_A",
            "Turno_B",
            "Turno_C"});
            this.cbb_turno.Location = new System.Drawing.Point(540, 601);
            this.cbb_turno.Name = "cbb_turno";
            this.cbb_turno.Size = new System.Drawing.Size(57, 21);
            this.cbb_turno.TabIndex = 279;
            this.cbb_turno.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Grid1);
            this.groupBox1.Location = new System.Drawing.Point(11, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 144);
            this.groupBox1.TabIndex = 280;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 219);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chart1.Size = new System.Drawing.Size(551, 376);
            this.chart1.TabIndex = 281;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(589, 219);
            this.chart2.Name = "chart2";
            this.chart2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chart2.Size = new System.Drawing.Size(551, 376);
            this.chart2.TabIndex = 283;
            this.chart2.Text = "chart2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Grid2);
            this.groupBox2.Location = new System.Drawing.Point(589, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 144);
            this.groupBox2.TabIndex = 282;
            this.groupBox2.TabStop = false;
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.Grid2.Location = new System.Drawing.Point(5, 20);
            this.Grid2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid2.Name = "Grid2";
            this.Grid2.ReadOnly = true;
            this.Grid2.RowHeadersWidth = 20;
            this.Grid2.Size = new System.Drawing.Size(515, 116);
            this.Grid2.TabIndex = 176;
            // 
            // Grid3
            // 
            this.Grid3.AllowUserToAddRows = false;
            this.Grid3.AllowUserToDeleteRows = false;
            this.Grid3.BackgroundColor = System.Drawing.Color.White;
            this.Grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.Grid3.Location = new System.Drawing.Point(23, 602);
            this.Grid3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid3.Name = "Grid3";
            this.Grid3.ReadOnly = true;
            this.Grid3.RowHeadersWidth = 20;
            this.Grid3.Size = new System.Drawing.Size(419, 88);
            this.Grid3.TabIndex = 284;
            // 
            // lbl_turno_B
            // 
            this.lbl_turno_B.AutoSize = true;
            this.lbl_turno_B.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_turno_B.Location = new System.Drawing.Point(755, 33);
            this.lbl_turno_B.Name = "lbl_turno_B";
            this.lbl_turno_B.Size = new System.Drawing.Size(92, 19);
            this.lbl_turno_B.TabIndex = 285;
            this.lbl_turno_B.Text = "[ Turno B]";
            // 
            // lbl_turno_A
            // 
            this.lbl_turno_A.AutoSize = true;
            this.lbl_turno_A.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_turno_A.Location = new System.Drawing.Point(180, 33);
            this.lbl_turno_A.Name = "lbl_turno_A";
            this.lbl_turno_A.Size = new System.Drawing.Size(93, 19);
            this.lbl_turno_A.TabIndex = 286;
            this.lbl_turno_A.Text = "[ Turno A]";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Producto Terminado";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 90;
            // 
            // Column14
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column14.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column14.HeaderText = "Materia Prima";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column14.Width = 90;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Acum. Semana";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Acum. Mes";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto Terminado";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Materia Prima";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Acum. Semana";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Acum. Mes";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.HeaderText = "Presupuesto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn8.HeaderText = "Real Acumulado";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // FRP12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1218, 733);
            this.Controls.Add(this.lbl_turno_A);
            this.Controls.Add(this.lbl_turno_B);
            this.Controls.Add(this.Grid3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbb_turno);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_actualizar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRP12";
            this.Text = "[FRP12] Control de Planta - NCC";
            this.Load += new System.EventHandler(this.FRP12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.ComboBox cbb_turno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.DataGridView Grid3;
        private System.Windows.Forms.Label lbl_turno_B;
        private System.Windows.Forms.Label lbl_turno_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}