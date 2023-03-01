namespace FrmProcesos
{
    partial class frmPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPallet));
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t_pallet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_whscode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t_ubicacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_codigobarra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_quitar_lote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_itemcode
            // 
            this.t_itemcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode.Location = new System.Drawing.Point(122, 36);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 10;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(405, 21);
            this.t_itemcode.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 83;
            this.label10.Text = "Codigo Artículo";
            // 
            // t_pallet
            // 
            this.t_pallet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_pallet.Location = new System.Drawing.Point(122, 13);
            this.t_pallet.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_pallet.MaxLength = 10;
            this.t_pallet.Name = "t_pallet";
            this.t_pallet.ReadOnly = true;
            this.t_pallet.Size = new System.Drawing.Size(105, 21);
            this.t_pallet.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Codigo";
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
            this.Grid1.Location = new System.Drawing.Point(18, 157);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(509, 331);
            this.Grid1.TabIndex = 85;
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
            // t_itemname
            // 
            this.t_itemname.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemname.Location = new System.Drawing.Point(122, 59);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.MaxLength = 10;
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(405, 21);
            this.t_itemname.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Descripción Artículo";
            // 
            // t_whscode
            // 
            this.t_whscode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_whscode.Location = new System.Drawing.Point(122, 82);
            this.t_whscode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_whscode.MaxLength = 10;
            this.t_whscode.Name = "t_whscode";
            this.t_whscode.ReadOnly = true;
            this.t_whscode.Size = new System.Drawing.Size(105, 21);
            this.t_whscode.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Almacen";
            // 
            // t_ubicacion
            // 
            this.t_ubicacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_ubicacion.Location = new System.Drawing.Point(122, 105);
            this.t_ubicacion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_ubicacion.MaxLength = 10;
            this.t_ubicacion.Name = "t_ubicacion";
            this.t_ubicacion.ReadOnly = true;
            this.t_ubicacion.Size = new System.Drawing.Size(105, 21);
            this.t_ubicacion.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Ubicación";
            // 
            // t_codigobarra
            // 
            this.t_codigobarra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codigobarra.Location = new System.Drawing.Point(122, 128);
            this.t_codigobarra.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_codigobarra.MaxLength = 10;
            this.t_codigobarra.Name = "t_codigobarra";
            this.t_codigobarra.ReadOnly = true;
            this.t_codigobarra.Size = new System.Drawing.Size(105, 21);
            this.t_codigobarra.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Código de Barras";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(18, 492);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 95;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_quitar_lote
            // 
            this.btn_quitar_lote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_quitar_lote.Location = new System.Drawing.Point(306, 492);
            this.btn_quitar_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_quitar_lote.Name = "btn_quitar_lote";
            this.btn_quitar_lote.Size = new System.Drawing.Size(90, 22);
            this.btn_quitar_lote.TabIndex = 96;
            this.btn_quitar_lote.Text = "Quitar Lote";
            this.btn_quitar_lote.UseVisualStyleBackColor = false;
            this.btn_quitar_lote.Click += new System.EventHandler(this.btn_quitar_lote_Click);
            // 
            // frmPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 530);
            this.Controls.Add(this.btn_quitar_lote);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.t_codigobarra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t_ubicacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_whscode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_itemname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.t_pallet);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPallet";
            this.Text = "Maestro de Pallet";
            this.Load += new System.EventHandler(this.frmPallet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox t_pallet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_whscode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_ubicacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_codigobarra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btn_quitar_lote;
    }
}