namespace FrmProcesos
{
    partial class frmPallet2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPallet2));
            this.btn_genera_pallet = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t_pallet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.cbb_almacen = new System.Windows.Forms.ComboBox();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.t_pallet_nuevo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_agrega_pallet = new System.Windows.Forms.Button();
            this.btn_devuelve = new System.Windows.Forms.Button();
            this.btn_pasar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_genera_pallet
            // 
            this.btn_genera_pallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_genera_pallet.Location = new System.Drawing.Point(560, 421);
            this.btn_genera_pallet.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_genera_pallet.Name = "btn_genera_pallet";
            this.btn_genera_pallet.Size = new System.Drawing.Size(169, 22);
            this.btn_genera_pallet.TabIndex = 111;
            this.btn_genera_pallet.Text = "Graba Detalle de Lotes ";
            this.btn_genera_pallet.UseVisualStyleBackColor = false;
            this.btn_genera_pallet.Click += new System.EventHandler(this.btn_genera_pallet_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(16, 421);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 110;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Almacen";
            // 
            // t_itemname
            // 
            this.t_itemname.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemname.Location = new System.Drawing.Point(120, 36);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.MaxLength = 10;
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(405, 21);
            this.t_itemname.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Descripción Artículo";
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
            this.Column2});
            this.Grid1.Location = new System.Drawing.Point(16, 86);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(509, 331);
            this.Grid1.TabIndex = 101;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "AbsEntry";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 180;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lote";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // t_itemcode
            // 
            this.t_itemcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode.Location = new System.Drawing.Point(120, 13);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 10;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(382, 21);
            this.t_itemcode.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Codigo Artículo";
            // 
            // t_pallet
            // 
            this.t_pallet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_pallet.Location = new System.Drawing.Point(64, 8);
            this.t_pallet.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_pallet.MaxLength = 10;
            this.t_pallet.Name = "t_pallet";
            this.t_pallet.ReadOnly = true;
            this.t_pallet.Size = new System.Drawing.Size(129, 21);
            this.t_pallet.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Pallet";
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(503, 12);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar1.TabIndex = 117;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // cbb_almacen
            // 
            this.cbb_almacen.FormattingEnabled = true;
            this.cbb_almacen.Location = new System.Drawing.Point(120, 59);
            this.cbb_almacen.Name = "cbb_almacen";
            this.cbb_almacen.Size = new System.Drawing.Size(105, 21);
            this.cbb_almacen.TabIndex = 118;
            this.cbb_almacen.SelectedIndexChanged += new System.EventHandler(this.cbb_almacen_SelectedIndexChanged);
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.Grid2.Location = new System.Drawing.Point(560, 86);
            this.Grid2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 5;
            this.Grid2.Size = new System.Drawing.Size(509, 331);
            this.Grid2.TabIndex = 119;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Origen";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "AbsEntry";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Lote";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(560, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(509, 74);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.t_pallet);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(501, 48);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pallet Existente";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.button1.Location = new System.Drawing.Point(195, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 118;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.t_pallet_nuevo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btn_agrega_pallet);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(501, 48);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nuevo Folio de Pallet";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // t_pallet_nuevo
            // 
            this.t_pallet_nuevo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_pallet_nuevo.Location = new System.Drawing.Point(243, 8);
            this.t_pallet_nuevo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_pallet_nuevo.MaxLength = 10;
            this.t_pallet_nuevo.Name = "t_pallet_nuevo";
            this.t_pallet_nuevo.ReadOnly = true;
            this.t_pallet_nuevo.Size = new System.Drawing.Size(129, 21);
            this.t_pallet_nuevo.TabIndex = 232;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 231;
            this.label3.Text = "Pallet";
            // 
            // btn_agrega_pallet
            // 
            this.btn_agrega_pallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_agrega_pallet.Location = new System.Drawing.Point(25, 8);
            this.btn_agrega_pallet.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_agrega_pallet.Name = "btn_agrega_pallet";
            this.btn_agrega_pallet.Size = new System.Drawing.Size(167, 22);
            this.btn_agrega_pallet.TabIndex = 230;
            this.btn_agrega_pallet.Text = "Agregar a nuevo pallet";
            this.btn_agrega_pallet.UseVisualStyleBackColor = false;
            this.btn_agrega_pallet.Click += new System.EventHandler(this.btn_agrega_pallet_Click);
            // 
            // btn_devuelve
            // 
            this.btn_devuelve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_devuelve.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.btn_devuelve.Location = new System.Drawing.Point(529, 230);
            this.btn_devuelve.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_devuelve.Name = "btn_devuelve";
            this.btn_devuelve.Size = new System.Drawing.Size(27, 22);
            this.btn_devuelve.TabIndex = 166;
            this.btn_devuelve.UseVisualStyleBackColor = false;
            this.btn_devuelve.Click += new System.EventHandler(this.btn_devuelve_Click);
            // 
            // btn_pasar
            // 
            this.btn_pasar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_pasar.Image = global::FrmProcesos.Properties.Resources._16__Play_;
            this.btn_pasar.Location = new System.Drawing.Point(529, 204);
            this.btn_pasar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_pasar.Name = "btn_pasar";
            this.btn_pasar.Size = new System.Drawing.Size(27, 22);
            this.btn_pasar.TabIndex = 165;
            this.btn_pasar.UseVisualStyleBackColor = false;
            this.btn_pasar.Click += new System.EventHandler(this.btn_pasar_Click);
            // 
            // frmPallet2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1089, 459);
            this.Controls.Add(this.btn_devuelve);
            this.Controls.Add(this.btn_pasar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Grid2);
            this.Controls.Add(this.cbb_almacen);
            this.Controls.Add(this.btn_buscar1);
            this.Controls.Add(this.btn_genera_pallet);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_itemname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPallet2";
            this.Text = "Palletizado - Lote";
            this.Load += new System.EventHandler(this.frmPallet2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_genera_pallet;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox t_pallet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.ComboBox cbb_almacen;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btn_devuelve;
        private System.Windows.Forms.Button btn_pasar;
        private System.Windows.Forms.TextBox t_pallet_nuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_agrega_pallet;
    }
}