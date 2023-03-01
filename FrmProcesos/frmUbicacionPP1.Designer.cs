namespace FrmProcesos
{
    partial class frmUbicacionPP1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUbicacionPP1));
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbb_ubicacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.t_ubicacion = new System.Windows.Forms.TextBox();
            this.t_WhsCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_crear = new System.Windows.Forms.Button();
            this.t_um = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_PlannedQty = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(21, 245);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 204;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbb_ubicacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(21, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 131);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(246, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 27);
            this.button1.TabIndex = 182;
            this.button1.Text = "Modifica Ubicación";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbb_ubicacion
            // 
            this.cbb_ubicacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ubicacion.FormattingEnabled = true;
            this.cbb_ubicacion.Location = new System.Drawing.Point(201, 39);
            this.cbb_ubicacion.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_ubicacion.Name = "cbb_ubicacion";
            this.cbb_ubicacion.Size = new System.Drawing.Size(268, 24);
            this.cbb_ubicacion.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 19);
            this.label6.TabIndex = 57;
            this.label6.Text = "Nueva Ubicación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 202;
            this.label5.Text = "Ubicación";
            // 
            // t_ubicacion
            // 
            this.t_ubicacion.Location = new System.Drawing.Point(92, 82);
            this.t_ubicacion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_ubicacion.Name = "t_ubicacion";
            this.t_ubicacion.ReadOnly = true;
            this.t_ubicacion.Size = new System.Drawing.Size(320, 21);
            this.t_ubicacion.TabIndex = 201;
            // 
            // t_WhsCode
            // 
            this.t_WhsCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_WhsCode.Location = new System.Drawing.Point(492, 36);
            this.t_WhsCode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_WhsCode.MaxLength = 50;
            this.t_WhsCode.Name = "t_WhsCode";
            this.t_WhsCode.ReadOnly = true;
            this.t_WhsCode.Size = new System.Drawing.Size(74, 21);
            this.t_WhsCode.TabIndex = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 199;
            this.label4.Text = "Almacen";
            // 
            // btn_crear
            // 
            this.btn_crear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_crear.Location = new System.Drawing.Point(257, 12);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(108, 22);
            this.btn_crear.TabIndex = 198;
            this.btn_crear.Text = "Consulta Pallet";
            this.btn_crear.UseVisualStyleBackColor = false;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // t_um
            // 
            this.t_um.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_um.Location = new System.Drawing.Point(492, 82);
            this.t_um.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_um.MaxLength = 50;
            this.t_um.Name = "t_um";
            this.t_um.ReadOnly = true;
            this.t_um.Size = new System.Drawing.Size(74, 21);
            this.t_um.TabIndex = 197;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 196;
            this.label3.Text = "Unidad Med.";
            // 
            // t_PlannedQty
            // 
            this.t_PlannedQty.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_PlannedQty.Location = new System.Drawing.Point(492, 59);
            this.t_PlannedQty.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_PlannedQty.MaxLength = 10;
            this.t_PlannedQty.Name = "t_PlannedQty";
            this.t_PlannedQty.ReadOnly = true;
            this.t_PlannedQty.Size = new System.Drawing.Size(74, 21);
            this.t_PlannedQty.TabIndex = 195;
            this.t_PlannedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(423, 62);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 194;
            this.label19.Text = "Cantidad ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Pallet";
            // 
            // t_lote
            // 
            this.t_lote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_lote.Location = new System.Drawing.Point(92, 13);
            this.t_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lote.MaxLength = 50;
            this.t_lote.Name = "t_lote";
            this.t_lote.Size = new System.Drawing.Size(161, 21);
            this.t_lote.TabIndex = 188;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 192;
            this.label9.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 190;
            this.label1.Text = "N° Producto";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode.Location = new System.Drawing.Point(92, 36);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 50;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(320, 21);
            this.t_itemcode.TabIndex = 189;
            // 
            // t_itemname
            // 
            this.t_itemname.Location = new System.Drawing.Point(92, 59);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(320, 21);
            this.t_itemname.TabIndex = 191;
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column3,
            this.Column9,
            this.Column5,
            this.Column1,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column2});
            this.Grid1.Location = new System.Drawing.Point(606, 39);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(507, 198);
            this.Grid1.TabIndex = 205;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Bodega";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ubicación";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Pasillo";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            this.Column9.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Posición";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 240;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Producto";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            this.Column7.Width = 280;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lote";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Cantidad";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "UM";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // frmUbicacionPP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 282);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t_ubicacion);
            this.Controls.Add(this.t_WhsCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.t_um);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_PlannedQty);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_lote);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.t_itemname);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUbicacionPP1";
            this.Text = "Modificar Ubicación";
            this.Load += new System.EventHandler(this.frmUbicacionPP1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbb_ubicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_ubicacion;
        private System.Windows.Forms.TextBox t_WhsCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.TextBox t_um;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_PlannedQty;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}