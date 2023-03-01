namespace FrmProcesos
{
    partial class frmSolicitudTraslado1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudTraslado1));
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_genera_solicitud = new System.Windows.Forms.Button();
            this.cbb_almacen_to = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_archivo_full = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Grid3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_CardName = new System.Windows.Forms.TextBox();
            this.btn_buscar_cliente = new System.Windows.Forms.Button();
            this.t_CardCode = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column7,
            this.Column5,
            this.Column2,
            this.Column10,
            this.Column3,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(11, 39);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(1092, 359);
            this.Grid1.TabIndex = 206;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Archivo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Código";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 260;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Descripción";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 260;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "AbsEntry";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lote";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Almacén";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Stock Almacén";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Referencia";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // btn_genera_solicitud
            // 
            this.btn_genera_solicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_genera_solicitud.Location = new System.Drawing.Point(827, 425);
            this.btn_genera_solicitud.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_genera_solicitud.Name = "btn_genera_solicitud";
            this.btn_genera_solicitud.Size = new System.Drawing.Size(276, 22);
            this.btn_genera_solicitud.TabIndex = 205;
            this.btn_genera_solicitud.Text = "Genera Solicitud de Traslado";
            this.btn_genera_solicitud.UseVisualStyleBackColor = false;
            this.btn_genera_solicitud.Click += new System.EventHandler(this.btn_genera_solicitud_Click);
            // 
            // cbb_almacen_to
            // 
            this.cbb_almacen_to.FormattingEnabled = true;
            this.cbb_almacen_to.Location = new System.Drawing.Point(717, 425);
            this.cbb_almacen_to.Name = "cbb_almacen_to";
            this.cbb_almacen_to.Size = new System.Drawing.Size(105, 21);
            this.cbb_almacen_to.TabIndex = 204;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 428);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 203;
            this.label1.Text = "Destino:";
            // 
            // t_archivo_full
            // 
            this.t_archivo_full.Location = new System.Drawing.Point(11, 9);
            this.t_archivo_full.Name = "t_archivo_full";
            this.t_archivo_full.Size = new System.Drawing.Size(312, 21);
            this.t_archivo_full.TabIndex = 200;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(340, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 22);
            this.button1.TabIndex = 199;
            this.button1.Text = "Cargar Archivo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(11, 425);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 198;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column9,
            this.Column8});
            this.Grid2.Location = new System.Drawing.Point(1274, 39);
            this.Grid2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 5;
            this.Grid2.Size = new System.Drawing.Size(138, 359);
            this.Grid2.TabIndex = 207;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Almacen";
            this.Column9.Name = "Column9";
            // 
            // Column8
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column8.HeaderText = "Stock";
            this.Column8.Name = "Column8";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Grid3
            // 
            this.Grid3.AllowUserToAddRows = false;
            this.Grid3.AllowUserToDeleteRows = false;
            this.Grid3.BackgroundColor = System.Drawing.Color.White;
            this.Grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Grid3.Location = new System.Drawing.Point(1151, 39);
            this.Grid3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid3.Name = "Grid3";
            this.Grid3.RowHeadersWidth = 5;
            this.Grid3.Size = new System.Drawing.Size(119, 359);
            this.Grid3.TabIndex = 208;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // t_CardName
            // 
            this.t_CardName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_CardName.Location = new System.Drawing.Point(827, 402);
            this.t_CardName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_CardName.MaxLength = 50;
            this.t_CardName.Name = "t_CardName";
            this.t_CardName.ReadOnly = true;
            this.t_CardName.Size = new System.Drawing.Size(276, 21);
            this.t_CardName.TabIndex = 212;
            // 
            // btn_buscar_cliente
            // 
            this.btn_buscar_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar_cliente.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar_cliente.Location = new System.Drawing.Point(800, 401);
            this.btn_buscar_cliente.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar_cliente.Name = "btn_buscar_cliente";
            this.btn_buscar_cliente.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar_cliente.TabIndex = 211;
            this.btn_buscar_cliente.UseVisualStyleBackColor = false;
            this.btn_buscar_cliente.Click += new System.EventHandler(this.btn_buscar_cliente_Click);
            // 
            // t_CardCode
            // 
            this.t_CardCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_CardCode.Location = new System.Drawing.Point(717, 402);
            this.t_CardCode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_CardCode.MaxLength = 50;
            this.t_CardCode.Name = "t_CardCode";
            this.t_CardCode.ReadOnly = true;
            this.t_CardCode.Size = new System.Drawing.Size(82, 21);
            this.t_CardCode.TabIndex = 210;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(661, 405);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 209;
            this.label21.Text = "Cliente";
            // 
            // frmSolicitudTraslado1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 456);
            this.Controls.Add(this.t_CardName);
            this.Controls.Add(this.btn_buscar_cliente);
            this.Controls.Add(this.t_CardCode);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Grid3);
            this.Controls.Add(this.Grid2);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.btn_genera_solicitud);
            this.Controls.Add(this.cbb_almacen_to);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_archivo_full);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_finalizar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSolicitudTraslado1";
            this.Text = "Solicitud de Traslado / Carga Masiva";
            this.Load += new System.EventHandler(this.frmSolicitudTraslado1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_genera_solicitud;
        private System.Windows.Forms.ComboBox cbb_almacen_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_archivo_full;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView Grid3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox t_CardName;
        private System.Windows.Forms.Button btn_buscar_cliente;
        private System.Windows.Forms.TextBox t_CardCode;
        private System.Windows.Forms.Label label21;
    }
}