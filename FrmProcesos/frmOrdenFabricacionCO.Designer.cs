namespace FrmProcesos
{
    partial class frmOrdenFabricacionCO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t_DocNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_buscar_of = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.btn_crear = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.t_fecha_contable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_cantidad = new System.Windows.Forms.TextBox();
            this.t_ultimo_codprod = new System.Windows.Forms.TextBox();
            this.t_ultimo_codcli = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_DocNum
            // 
            this.t_DocNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_DocNum.Location = new System.Drawing.Point(137, 10);
            this.t_DocNum.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_DocNum.MaxLength = 10;
            this.t_DocNum.Name = "t_DocNum";
            this.t_DocNum.Size = new System.Drawing.Size(76, 21);
            this.t_DocNum.TabIndex = 173;
            this.t_DocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_DocNum.Leave += new System.EventHandler(this.t_DocNum_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 13);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 174;
            this.label12.Text = "Orden de Fabricación";
            // 
            // btn_buscar_of
            // 
            this.btn_buscar_of.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar_of.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar_of.Location = new System.Drawing.Point(214, 9);
            this.btn_buscar_of.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar_of.Name = "btn_buscar_of";
            this.btn_buscar_of.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar_of.TabIndex = 175;
            this.btn_buscar_of.UseVisualStyleBackColor = false;
            this.btn_buscar_of.Click += new System.EventHandler(this.btn_buscar_of_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 177;
            this.label1.Text = "Lote";
            // 
            // t_lote
            // 
            this.t_lote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_lote.Location = new System.Drawing.Point(137, 34);
            this.t_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lote.MaxLength = 10;
            this.t_lote.Name = "t_lote";
            this.t_lote.Size = new System.Drawing.Size(135, 21);
            this.t_lote.TabIndex = 176;
            this.t_lote.Enter += new System.EventHandler(this.t_lote_Enter);
            this.t_lote.Leave += new System.EventHandler(this.t_lote_Leave);
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
            this.Column13,
            this.Column8,
            this.Column14,
            this.Column10,
            this.Column4,
            this.Column6,
            this.Column9,
            this.Column11,
            this.Column12,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18});
            this.Grid1.Location = new System.Drawing.Point(18, 63);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(1435, 366);
            this.Grid1.TabIndex = 178;
            // 
            // btn_crear
            // 
            this.btn_crear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_crear.Location = new System.Drawing.Point(406, 34);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(129, 22);
            this.btn_crear.TabIndex = 180;
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
            this.btn_finalizar.TabIndex = 179;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // t_fecha_contable
            // 
            this.t_fecha_contable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_fecha_contable.Location = new System.Drawing.Point(668, 10);
            this.t_fecha_contable.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_contable.MaxLength = 10;
            this.t_fecha_contable.Name = "t_fecha_contable";
            this.t_fecha_contable.ReadOnly = true;
            this.t_fecha_contable.Size = new System.Drawing.Size(148, 21);
            this.t_fecha_contable.TabIndex = 193;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(541, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 192;
            this.label6.Text = "Fecha de contabilización";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 194;
            this.label2.Text = "Cant. de Bins";
            // 
            // t_cantidad
            // 
            this.t_cantidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cantidad.Location = new System.Drawing.Point(352, 34);
            this.t_cantidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cantidad.MaxLength = 10;
            this.t_cantidad.Name = "t_cantidad";
            this.t_cantidad.Size = new System.Drawing.Size(31, 21);
            this.t_cantidad.TabIndex = 195;
            this.t_cantidad.Text = "1";
            this.t_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_ultimo_codprod
            // 
            this.t_ultimo_codprod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_ultimo_codprod.Location = new System.Drawing.Point(976, 10);
            this.t_ultimo_codprod.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_ultimo_codprod.MaxLength = 10;
            this.t_ultimo_codprod.Name = "t_ultimo_codprod";
            this.t_ultimo_codprod.Size = new System.Drawing.Size(56, 21);
            this.t_ultimo_codprod.TabIndex = 196;
            this.t_ultimo_codprod.Visible = false;
            // 
            // t_ultimo_codcli
            // 
            this.t_ultimo_codcli.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_ultimo_codcli.Location = new System.Drawing.Point(1036, 10);
            this.t_ultimo_codcli.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_ultimo_codcli.MaxLength = 10;
            this.t_ultimo_codcli.Name = "t_ultimo_codcli";
            this.t_ultimo_codcli.Size = new System.Drawing.Size(56, 21);
            this.t_ultimo_codcli.TabIndex = 197;
            this.t_ultimo_codcli.Visible = false;
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
            this.Column2.Width = 250;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Descripción";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 250;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Cantidad Asignada";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "MAbsEntry";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            this.Column13.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lote";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // Column14
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column14.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column14.HeaderText = "Bins";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 70;
            // 
            // Column10
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column10.HeaderText = "Volteados";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Almacen";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column6
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "Total Lote";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column9
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column9.HeaderText = "Saldo Lote";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "CodProd";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Productor";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 180;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "CodCli";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Cliente";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 180;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Código CSG";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 80;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Tipo Cosecha";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 90;
            // 
            // frmOrdenFabricacionCO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1467, 466);
            this.Controls.Add(this.t_ultimo_codcli);
            this.Controls.Add(this.t_ultimo_codprod);
            this.Controls.Add(this.t_cantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_fecha_contable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_lote);
            this.Controls.Add(this.btn_buscar_of);
            this.Controls.Add(this.t_DocNum);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOrdenFabricacionCO";
            this.Text = "Emisión para Producción";
            this.Load += new System.EventHandler(this.frmOrdenFabricacionCO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar_of;
        private System.Windows.Forms.TextBox t_DocNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_fecha_contable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_cantidad;
        private System.Windows.Forms.TextBox t_ultimo_codprod;
        private System.Windows.Forms.TextBox t_ultimo_codcli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
    }
}