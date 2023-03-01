namespace FrmProcesos
{
    partial class frmFumigado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFumigado));
            this.t_whscode = new System.Windows.Forms.TextBox();
            this.t_pallet_full = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_fumiga_lote = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_whscode_l = new System.Windows.Forms.TextBox();
            this.t_itemcode_l = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.t_itemname_l = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_whscode
            // 
            this.t_whscode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_whscode.Location = new System.Drawing.Point(126, 76);
            this.t_whscode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_whscode.MaxLength = 10;
            this.t_whscode.Name = "t_whscode";
            this.t_whscode.ReadOnly = true;
            this.t_whscode.Size = new System.Drawing.Size(105, 21);
            this.t_whscode.TabIndex = 193;
            // 
            // t_pallet_full
            // 
            this.t_pallet_full.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_pallet_full.Location = new System.Drawing.Point(126, 7);
            this.t_pallet_full.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_pallet_full.MaxLength = 10;
            this.t_pallet_full.Name = "t_pallet_full";
            this.t_pallet_full.Size = new System.Drawing.Size(105, 21);
            this.t_pallet_full.TabIndex = 0;
            this.t_pallet_full.Leave += new System.EventHandler(this.t_pallet_full_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 192;
            this.label4.Text = "Pallet";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(10, 438);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 191;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 190;
            this.label2.Text = "Almacen";
            // 
            // t_itemname
            // 
            this.t_itemname.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemname.Location = new System.Drawing.Point(126, 53);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.MaxLength = 10;
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(405, 21);
            this.t_itemname.TabIndex = 189;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 188;
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
            this.Column2,
            this.Column3,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(10, 149);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(558, 282);
            this.Grid1.TabIndex = 187;
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
            this.Column5.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lote";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fumigado";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha Fumigación";
            this.Column4.Name = "Column4";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode.Location = new System.Drawing.Point(126, 30);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 10;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(405, 21);
            this.t_itemcode.TabIndex = 186;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 185;
            this.label10.Text = "Codigo Artículo";
            // 
            // btn_fumiga_lote
            // 
            this.btn_fumiga_lote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_fumiga_lote.Location = new System.Drawing.Point(399, 438);
            this.btn_fumiga_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_fumiga_lote.Name = "btn_fumiga_lote";
            this.btn_fumiga_lote.Size = new System.Drawing.Size(169, 22);
            this.btn_fumiga_lote.TabIndex = 194;
            this.btn_fumiga_lote.Text = "Fumiga Lotes ";
            this.btn_fumiga_lote.UseVisualStyleBackColor = false;
            this.btn_fumiga_lote.Click += new System.EventHandler(this.btn_fumiga_lote_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(10, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 135);
            this.tabControl1.TabIndex = 195;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.t_pallet_full);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.t_whscode);
            this.tabPage1.Controls.Add(this.t_itemcode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.t_itemname);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(550, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Selección de Lotes por Pallet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.t_lote);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.t_whscode_l);
            this.tabPage2.Controls.Add(this.t_itemcode_l);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.t_itemname_l);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(550, 109);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selección de Lotes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // t_lote
            // 
            this.t_lote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_lote.Location = new System.Drawing.Point(126, 7);
            this.t_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lote.MaxLength = 10;
            this.t_lote.Name = "t_lote";
            this.t_lote.Size = new System.Drawing.Size(105, 21);
            this.t_lote.TabIndex = 194;
            this.t_lote.Leave += new System.EventHandler(this.t_lote_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 195;
            this.label3.Text = "Codigo Artículo";
            // 
            // t_whscode_l
            // 
            this.t_whscode_l.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_whscode_l.Location = new System.Drawing.Point(126, 76);
            this.t_whscode_l.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_whscode_l.MaxLength = 10;
            this.t_whscode_l.Name = "t_whscode_l";
            this.t_whscode_l.ReadOnly = true;
            this.t_whscode_l.Size = new System.Drawing.Size(105, 21);
            this.t_whscode_l.TabIndex = 201;
            // 
            // t_itemcode_l
            // 
            this.t_itemcode_l.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode_l.Location = new System.Drawing.Point(126, 30);
            this.t_itemcode_l.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode_l.MaxLength = 10;
            this.t_itemcode_l.Name = "t_itemcode_l";
            this.t_itemcode_l.ReadOnly = true;
            this.t_itemcode_l.Size = new System.Drawing.Size(405, 21);
            this.t_itemcode_l.TabIndex = 196;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 197;
            this.label5.Text = "Descripción Artículo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 200;
            this.label6.Text = "Lote";
            // 
            // t_itemname_l
            // 
            this.t_itemname_l.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemname_l.Location = new System.Drawing.Point(126, 53);
            this.t_itemname_l.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname_l.MaxLength = 10;
            this.t_itemname_l.Name = "t_itemname_l";
            this.t_itemname_l.ReadOnly = true;
            this.t_itemname_l.Size = new System.Drawing.Size(405, 21);
            this.t_itemname_l.TabIndex = 198;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 199;
            this.label7.Text = "Almacen";
            // 
            // frmFumigado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(579, 483);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_fumiga_lote);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.Grid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFumigado";
            this.Text = "Fumigado de Fruta";
            this.Load += new System.EventHandler(this.frmFumigado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox t_whscode;
        private System.Windows.Forms.TextBox t_pallet_full;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_fumiga_lote;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_whscode_l;
        private System.Windows.Forms.TextBox t_itemcode_l;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_itemname_l;
        private System.Windows.Forms.Label label7;
    }
}