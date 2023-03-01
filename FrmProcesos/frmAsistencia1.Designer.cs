namespace FrmProcesos
{
    partial class frmAsistencia1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistencia1));
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.cbb_anho = new System.Windows.Forms.ComboBox();
            this.t_fecha_hasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_fecha_desde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_semana = new System.Windows.Forms.ComboBox();
            this.t_responsable = new System.Windows.Forms.TextBox();
            this.t_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_seleccionar.Location = new System.Drawing.Point(798, 499);
            this.btn_seleccionar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(178, 22);
            this.btn_seleccionar.TabIndex = 200;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.UseVisualStyleBackColor = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(12, 499);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 199;
            this.btn_cancelar.Text = "Cancelar";
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
            this.Column14,
            this.Column15,
            this.Column8,
            this.Column5,
            this.Column4,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column13});
            this.Grid1.Location = new System.Drawing.Point(12, 74);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(964, 417);
            this.Grid1.TabIndex = 198;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "ccosto";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "do_dependencia1";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "CENTRO COSTO";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 300;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "AREA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 300;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "LUN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "MAR";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 60;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "MIE";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "JUE";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 60;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "VIE";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_actualizar);
            this.groupBox1.Controls.Add(this.cbb_anho);
            this.groupBox1.Controls.Add(this.t_fecha_hasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.t_fecha_desde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbb_semana);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 59);
            this.groupBox1.TabIndex = 196;
            this.groupBox1.TabStop = false;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_actualizar.Image = global::FrmProcesos.Properties.Resources.action_refresh;
            this.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_actualizar.Location = new System.Drawing.Point(537, 19);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(133, 22);
            this.btn_actualizar.TabIndex = 180;
            this.btn_actualizar.Text = "  Cargar datos";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // cbb_anho
            // 
            this.cbb_anho.FormattingEnabled = true;
            this.cbb_anho.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020"});
            this.cbb_anho.Location = new System.Drawing.Point(54, 19);
            this.cbb_anho.Name = "cbb_anho";
            this.cbb_anho.Size = new System.Drawing.Size(53, 21);
            this.cbb_anho.TabIndex = 174;
            this.cbb_anho.SelectedIndexChanged += new System.EventHandler(this.cbb_anho_SelectedIndexChanged);
            // 
            // t_fecha_hasta
            // 
            this.t_fecha_hasta.Location = new System.Drawing.Point(442, 19);
            this.t_fecha_hasta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_hasta.Name = "t_fecha_hasta";
            this.t_fecha_hasta.ReadOnly = true;
            this.t_fecha_hasta.Size = new System.Drawing.Size(91, 21);
            this.t_fecha_hasta.TabIndex = 182;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 175;
            this.label3.Text = "Año:";
            // 
            // t_fecha_desde
            // 
            this.t_fecha_desde.Location = new System.Drawing.Point(347, 19);
            this.t_fecha_desde.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_desde.Name = "t_fecha_desde";
            this.t_fecha_desde.ReadOnly = true;
            this.t_fecha_desde.Size = new System.Drawing.Size(91, 21);
            this.t_fecha_desde.TabIndex = 181;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 177;
            this.label4.Text = "Semana:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 180;
            this.label6.Text = "Rango de Fechas:";
            // 
            // cbb_semana
            // 
            this.cbb_semana.FormattingEnabled = true;
            this.cbb_semana.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020"});
            this.cbb_semana.Location = new System.Drawing.Point(170, 19);
            this.cbb_semana.Name = "cbb_semana";
            this.cbb_semana.Size = new System.Drawing.Size(53, 21);
            this.cbb_semana.TabIndex = 176;
            this.cbb_semana.SelectedIndexChanged += new System.EventHandler(this.cbb_semana_SelectedIndexChanged);
            // 
            // t_responsable
            // 
            this.t_responsable.Location = new System.Drawing.Point(1001, 27);
            this.t_responsable.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_responsable.Name = "t_responsable";
            this.t_responsable.ReadOnly = true;
            this.t_responsable.Size = new System.Drawing.Size(20, 21);
            this.t_responsable.TabIndex = 195;
            this.t_responsable.Visible = false;
            // 
            // t_nombre
            // 
            this.t_nombre.Location = new System.Drawing.Point(786, 27);
            this.t_nombre.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_nombre.Name = "t_nombre";
            this.t_nombre.ReadOnly = true;
            this.t_nombre.Size = new System.Drawing.Size(211, 21);
            this.t_nombre.TabIndex = 194;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(713, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Responsable";
            // 
            // frmAsistencia1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 534);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.t_responsable);
            this.Controls.Add(this.t_nombre);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsistencia1";
            this.Text = "Administración de asistencia";
            this.Load += new System.EventHandler(this.frmAsistencia1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_anho;
        private System.Windows.Forms.TextBox t_fecha_hasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_fecha_desde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_semana;
        private System.Windows.Forms.TextBox t_responsable;
        private System.Windows.Forms.TextBox t_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}