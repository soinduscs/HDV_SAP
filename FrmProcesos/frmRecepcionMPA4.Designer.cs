namespace FrmProcesos
{
    partial class frmRecepcionMPA4
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_fecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ingresar_mp = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_imagenes = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Hasta:";
            // 
            // dtp_fecha2
            // 
            this.dtp_fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha2.Location = new System.Drawing.Point(204, 5);
            this.dtp_fecha2.Name = "dtp_fecha2";
            this.dtp_fecha2.Size = new System.Drawing.Size(95, 21);
            this.dtp_fecha2.TabIndex = 62;
            // 
            // dtp_fecha1
            // 
            this.dtp_fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha1.Location = new System.Drawing.Point(60, 5);
            this.dtp_fecha1.Name = "dtp_fecha1";
            this.dtp_fecha1.Size = new System.Drawing.Size(95, 21);
            this.dtp_fecha1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Desde:";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column3,
            this.Column8,
            this.Column14,
            this.Column15,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(14, 33);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(1270, 409);
            this.Grid1.TabIndex = 28;
            this.Grid1.DoubleClick += new System.EventHandler(this.Grid1_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Folio Romana";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "LineID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fecha Pesaje Final";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 110;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Productor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 275;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Orden de Fabricación";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Especie";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 280;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Kilos";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Estado Calidad";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 245;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Pesaje";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 50;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Destare";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DocEntry_Ref";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // btn_ingresar_mp
            // 
            this.btn_ingresar_mp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ingresar_mp.Location = new System.Drawing.Point(423, 448);
            this.btn_ingresar_mp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ingresar_mp.Name = "btn_ingresar_mp";
            this.btn_ingresar_mp.Size = new System.Drawing.Size(456, 27);
            this.btn_ingresar_mp.TabIndex = 29;
            this.btn_ingresar_mp.Text = "Recepción de Materia Prima por Peso Romana";
            this.btn_ingresar_mp.UseVisualStyleBackColor = false;
            this.btn_ingresar_mp.Click += new System.EventHandler(this.btn_ingresar_mp_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(14, 450);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 32;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_imagenes
            // 
            this.btn_imagenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imagenes.Image = global::FrmProcesos.Properties.Resources._16__Insert_bitmap_;
            this.btn_imagenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imagenes.Location = new System.Drawing.Point(1160, 450);
            this.btn_imagenes.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imagenes.Name = "btn_imagenes";
            this.btn_imagenes.Size = new System.Drawing.Size(98, 27);
            this.btn_imagenes.TabIndex = 80;
            this.btn_imagenes.Text = "    Imagenes";
            this.btn_imagenes.UseVisualStyleBackColor = false;
            this.btn_imagenes.Click += new System.EventHandler(this.btn_imagenes_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_actualizar.Image = global::FrmProcesos.Properties.Resources.action_refresh;
            this.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_actualizar.Location = new System.Drawing.Point(314, 5);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(89, 22);
            this.btn_actualizar.TabIndex = 55;
            this.btn_actualizar.Text = "  Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir.Location = new System.Drawing.Point(1010, 450);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(148, 27);
            this.btn_imprimir.TabIndex = 82;
            this.btn_imprimir.Text = "Imprimir Tarja";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1262, 450);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 21);
            this.button2.TabIndex = 83;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRecepcionMPA4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1307, 490);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_imagenes);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_ingresar_mp);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_fecha2);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.dtp_fecha1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRecepcionMPA4";
            this.Text = "Recepción de Materia Prima - Secador";
            this.Load += new System.EventHandler(this.frmRecepcionMPA4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_imagenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fecha2;
        private System.Windows.Forms.DateTimePicker dtp_fecha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_ingresar_mp;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button2;
    }
}