namespace FrmProcesos
{
    partial class frmCalidadMP3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t_cant_contra_muestra = new System.Windows.Forms.TextBox();
            this.t_variedad = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t_itemcode_d = new System.Windows.Forms.TextBox();
            this.t_itemname_d = new System.Windows.Forms.TextBox();
            this.t_tipofruta = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.chk_contramuestra = new System.Windows.Forms.CheckBox();
            this.chk_destructiva = new System.Windows.Forms.CheckBox();
            this.t_cant_muestra_destructiva = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.t_observacion = new System.Windows.Forms.TextBox();
            this.btn_trae_matriz = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_cant_contra_muestra
            // 
            this.t_cant_contra_muestra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cant_contra_muestra.Location = new System.Drawing.Point(589, 9);
            this.t_cant_contra_muestra.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cant_contra_muestra.MaxLength = 10;
            this.t_cant_contra_muestra.Name = "t_cant_contra_muestra";
            this.t_cant_contra_muestra.Size = new System.Drawing.Size(67, 21);
            this.t_cant_contra_muestra.TabIndex = 42;
            this.t_cant_contra_muestra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_cant_contra_muestra.Leave += new System.EventHandler(this.t_cant_contra_muestra_Leave);
            // 
            // t_variedad
            // 
            this.t_variedad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_variedad.Location = new System.Drawing.Point(71, 60);
            this.t_variedad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_variedad.MaxLength = 10;
            this.t_variedad.Name = "t_variedad";
            this.t_variedad.ReadOnly = true;
            this.t_variedad.Size = new System.Drawing.Size(193, 21);
            this.t_variedad.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 63);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Variedad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Especie:";
            // 
            // t_itemcode_d
            // 
            this.t_itemcode_d.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode_d.Location = new System.Drawing.Point(71, 9);
            this.t_itemcode_d.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode_d.MaxLength = 10;
            this.t_itemcode_d.Name = "t_itemcode_d";
            this.t_itemcode_d.ReadOnly = true;
            this.t_itemcode_d.Size = new System.Drawing.Size(349, 21);
            this.t_itemcode_d.TabIndex = 24;
            // 
            // t_itemname_d
            // 
            this.t_itemname_d.Location = new System.Drawing.Point(71, 34);
            this.t_itemname_d.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname_d.Name = "t_itemname_d";
            this.t_itemname_d.ReadOnly = true;
            this.t_itemname_d.Size = new System.Drawing.Size(349, 21);
            this.t_itemname_d.TabIndex = 23;
            // 
            // t_tipofruta
            // 
            this.t_tipofruta.Location = new System.Drawing.Point(294, 60);
            this.t_tipofruta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_tipofruta.MaxLength = 15;
            this.t_tipofruta.Name = "t_tipofruta";
            this.t_tipofruta.ReadOnly = true;
            this.t_tipofruta.Size = new System.Drawing.Size(126, 21);
            this.t_tipofruta.TabIndex = 68;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Grid1);
            this.groupBox3.Location = new System.Drawing.Point(14, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 287);
            this.groupBox3.TabIndex = 64;
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
            this.Column1,
            this.Column6,
            this.Column3,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(5, 20);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(780, 261);
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
            this.Column8.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Atributo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "UM";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 40;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Standard";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 80;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Desde";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Hasta";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 80;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(14, 439);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 66;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(89, 439);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 65;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chk_contramuestra
            // 
            this.chk_contramuestra.AutoSize = true;
            this.chk_contramuestra.Location = new System.Drawing.Point(459, 11);
            this.chk_contramuestra.Name = "chk_contramuestra";
            this.chk_contramuestra.Size = new System.Drawing.Size(101, 17);
            this.chk_contramuestra.TabIndex = 74;
            this.chk_contramuestra.Text = "Contra Muestra";
            this.chk_contramuestra.UseVisualStyleBackColor = true;
            // 
            // chk_destructiva
            // 
            this.chk_destructiva.AutoSize = true;
            this.chk_destructiva.Location = new System.Drawing.Point(459, 36);
            this.chk_destructiva.Name = "chk_destructiva";
            this.chk_destructiva.Size = new System.Drawing.Size(123, 17);
            this.chk_destructiva.TabIndex = 75;
            this.chk_destructiva.Text = "Muestra Destructiva";
            this.chk_destructiva.UseVisualStyleBackColor = true;
            // 
            // t_cant_muestra_destructiva
            // 
            this.t_cant_muestra_destructiva.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cant_muestra_destructiva.Location = new System.Drawing.Point(589, 34);
            this.t_cant_muestra_destructiva.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cant_muestra_destructiva.MaxLength = 10;
            this.t_cant_muestra_destructiva.Name = "t_cant_muestra_destructiva";
            this.t_cant_muestra_destructiva.Size = new System.Drawing.Size(67, 21);
            this.t_cant_muestra_destructiva.TabIndex = 76;
            this.t_cant_muestra_destructiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_cant_muestra_destructiva.Leave += new System.EventHandler(this.t_cant_muestra_destructiva_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 382);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 77;
            this.label16.Text = "Comentario:";
            // 
            // t_observacion
            // 
            this.t_observacion.Location = new System.Drawing.Point(81, 379);
            this.t_observacion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_observacion.MaxLength = 200;
            this.t_observacion.Multiline = true;
            this.t_observacion.Name = "t_observacion";
            this.t_observacion.Size = new System.Drawing.Size(388, 52);
            this.t_observacion.TabIndex = 78;
            // 
            // btn_trae_matriz
            // 
            this.btn_trae_matriz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_trae_matriz.Location = new System.Drawing.Point(459, 58);
            this.btn_trae_matriz.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_trae_matriz.Name = "btn_trae_matriz";
            this.btn_trae_matriz.Size = new System.Drawing.Size(197, 22);
            this.btn_trae_matriz.TabIndex = 79;
            this.btn_trae_matriz.Text = "Carga Atributos Base";
            this.btn_trae_matriz.UseVisualStyleBackColor = false;
            this.btn_trae_matriz.Click += new System.EventHandler(this.btn_trae_matriz_Click);
            // 
            // frmCalidadMP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 481);
            this.Controls.Add(this.btn_trae_matriz);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.t_observacion);
            this.Controls.Add(this.t_cant_muestra_destructiva);
            this.Controls.Add(this.chk_destructiva);
            this.Controls.Add(this.chk_contramuestra);
            this.Controls.Add(this.t_cant_contra_muestra);
            this.Controls.Add(this.t_variedad);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.t_tipofruta);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_itemcode_d);
            this.Controls.Add(this.t_itemname_d);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCalidadMP3";
            this.Text = "Registro de Inspección  ";
            this.Load += new System.EventHandler(this.frmCalidadMP3_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox t_cant_contra_muestra;
        private System.Windows.Forms.TextBox t_variedad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_itemcode_d;
        private System.Windows.Forms.TextBox t_itemname_d;
        private System.Windows.Forms.TextBox t_tipofruta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox chk_contramuestra;
        private System.Windows.Forms.CheckBox chk_destructiva;
        private System.Windows.Forms.TextBox t_cant_muestra_destructiva;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox t_observacion;
        private System.Windows.Forms.Button btn_trae_matriz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}