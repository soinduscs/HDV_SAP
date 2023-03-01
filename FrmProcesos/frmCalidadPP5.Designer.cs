namespace FrmProcesos
{
    partial class frmCalidadPP5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPP5));
            this.cbb_procesos = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_variedad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_calibre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_ref = new System.Windows.Forms.TextBox();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_procesos
            // 
            this.cbb_procesos.FormattingEnabled = true;
            this.cbb_procesos.Location = new System.Drawing.Point(69, 9);
            this.cbb_procesos.Name = "cbb_procesos";
            this.cbb_procesos.Size = new System.Drawing.Size(213, 21);
            this.cbb_procesos.TabIndex = 120;
            this.cbb_procesos.SelectedIndexChanged += new System.EventHandler(this.cbb_procesos_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Grid2);
            this.groupBox3.Controls.Add(this.Grid1);
            this.groupBox3.Location = new System.Drawing.Point(14, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 507);
            this.groupBox3.TabIndex = 117;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Atr. Cuantitativos ";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.Grid1.Location = new System.Drawing.Point(5, 20);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(680, 363);
            this.Grid1.TabIndex = 23;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "LineId";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Código";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 110;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Atributo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Rango Aprobado";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Rango Aprob. con Reparos";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Locked";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 60;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(14, 550);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 119;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(90, 550);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 118;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Proceso:";
            // 
            // cbb_variedad
            // 
            this.cbb_variedad.FormattingEnabled = true;
            this.cbb_variedad.Location = new System.Drawing.Point(343, 9);
            this.cbb_variedad.Name = "cbb_variedad";
            this.cbb_variedad.Size = new System.Drawing.Size(104, 21);
            this.cbb_variedad.TabIndex = 122;
            this.cbb_variedad.SelectedIndexChanged += new System.EventHandler(this.cbb_variedad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Variedad:";
            // 
            // cbb_calibre
            // 
            this.cbb_calibre.FormattingEnabled = true;
            this.cbb_calibre.Location = new System.Drawing.Point(500, 9);
            this.cbb_calibre.Name = "cbb_calibre";
            this.cbb_calibre.Size = new System.Drawing.Size(214, 21);
            this.cbb_calibre.TabIndex = 124;
            this.cbb_calibre.SelectedIndexChanged += new System.EventHandler(this.cbb_calibre_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Calibre:";
            // 
            // t_ref
            // 
            this.t_ref.Location = new System.Drawing.Point(671, 550);
            this.t_ref.Name = "t_ref";
            this.t_ref.Size = new System.Drawing.Size(43, 21);
            this.t_ref.TabIndex = 125;
            this.t_ref.Visible = false;
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.Grid2.Location = new System.Drawing.Point(5, 389);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 20;
            this.Grid2.Size = new System.Drawing.Size(680, 112);
            this.Grid2.TabIndex = 24;
            this.Grid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Atributo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "Rango Maximo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // frmCalidadPP5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 588);
            this.Controls.Add(this.t_ref);
            this.Controls.Add(this.cbb_calibre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_variedad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_procesos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalidadPP5";
            this.Text = "Registro de Inspección  ";
            this.Load += new System.EventHandler(this.frmCalidadPP5_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_procesos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_variedad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_calibre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}