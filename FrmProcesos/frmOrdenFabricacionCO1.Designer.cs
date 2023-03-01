namespace FrmProcesos
{
    partial class frmOrdenFabricacionCO1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionCO1));
            this.t_fecha_contable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_crear = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.t_DocNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_buscar_of = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_fecha_contable
            // 
            this.t_fecha_contable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_fecha_contable.Location = new System.Drawing.Point(508, 9);
            this.t_fecha_contable.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_contable.MaxLength = 10;
            this.t_fecha_contable.Name = "t_fecha_contable";
            this.t_fecha_contable.ReadOnly = true;
            this.t_fecha_contable.Size = new System.Drawing.Size(148, 21);
            this.t_fecha_contable.TabIndex = 203;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 202;
            this.label6.Text = "Fecha de contabilización";
            // 
            // btn_crear
            // 
            this.btn_crear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_crear.Location = new System.Drawing.Point(814, 431);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(123, 22);
            this.btn_crear.TabIndex = 201;
            this.btn_crear.Text = "Generar Consumo";
            this.btn_crear.UseVisualStyleBackColor = false;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(18, 431);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 200;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column7,
            this.Column3,
            this.Column6,
            this.Column13,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(18, 40);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(919, 389);
            this.Grid1.TabIndex = 0;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // t_DocNum
            // 
            this.t_DocNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_DocNum.Location = new System.Drawing.Point(137, 10);
            this.t_DocNum.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_DocNum.MaxLength = 10;
            this.t_DocNum.Name = "t_DocNum";
            this.t_DocNum.ReadOnly = true;
            this.t_DocNum.Size = new System.Drawing.Size(76, 21);
            this.t_DocNum.TabIndex = 194;
            this.t_DocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 13);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 195;
            this.label12.Text = "Orden de Fabricación";
            // 
            // btn_buscar_of
            // 
            this.btn_buscar_of.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar_of.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar_of.Location = new System.Drawing.Point(215, 9);
            this.btn_buscar_of.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar_of.Name = "btn_buscar_of";
            this.btn_buscar_of.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar_of.TabIndex = 196;
            this.btn_buscar_of.UseVisualStyleBackColor = false;
            this.btn_buscar_of.Click += new System.EventHandler(this.btn_buscar_of_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "LogEntry";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "N°";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 220;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Descripción";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 320;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Cantidad a Consumir";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Cantidad";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // Column13
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column13.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column13.HeaderText = "Consumido";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Almacen";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // frmOrdenFabricacionCO1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(953, 470);
            this.Controls.Add(this.t_fecha_contable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.btn_buscar_of);
            this.Controls.Add(this.t_DocNum);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrdenFabricacionCO1";
            this.Text = "Emisión para Producción - Insumos";
            this.Load += new System.EventHandler(this.frmOrdenFabricacionCO1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_fecha_contable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_buscar_of;
        private System.Windows.Forms.TextBox t_DocNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}