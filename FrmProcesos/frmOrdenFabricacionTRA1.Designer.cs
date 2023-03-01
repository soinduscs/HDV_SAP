namespace FrmProcesos
{
    partial class frmOrdenFabricacionTRA1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionTRA1));
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.t_almacen = new System.Windows.Forms.TextBox();
            this.t_total = new System.Windows.Forms.TextBox();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.t_total_tr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(3, 241);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 122;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(79, 241);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 121;
            this.btn_ok.Text = "Aplicar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column3,
            this.Column4});
            this.Grid1.Location = new System.Drawing.Point(3, 32);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(358, 206);
            this.Grid1.TabIndex = 0;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lote";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 120;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Stock Disponible";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Cantidad a Consumir";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 90;
            // 
            // t_itemcode
            // 
            this.t_itemcode.Location = new System.Drawing.Point(3, 270);
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.Size = new System.Drawing.Size(49, 21);
            this.t_itemcode.TabIndex = 123;
            this.t_itemcode.Visible = false;
            // 
            // t_almacen
            // 
            this.t_almacen.Location = new System.Drawing.Point(54, 270);
            this.t_almacen.Name = "t_almacen";
            this.t_almacen.Size = new System.Drawing.Size(49, 21);
            this.t_almacen.TabIndex = 124;
            this.t_almacen.Visible = false;
            // 
            // t_total
            // 
            this.t_total.Location = new System.Drawing.Point(227, 241);
            this.t_total.Name = "t_total";
            this.t_total.ReadOnly = true;
            this.t_total.Size = new System.Drawing.Size(78, 21);
            this.t_total.TabIndex = 125;
            this.t_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_itemname
            // 
            this.t_itemname.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemname.Location = new System.Drawing.Point(3, 2);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(358, 27);
            this.t_itemname.TabIndex = 126;
            // 
            // t_total_tr
            // 
            this.t_total_tr.Location = new System.Drawing.Point(104, 270);
            this.t_total_tr.Name = "t_total_tr";
            this.t_total_tr.ReadOnly = true;
            this.t_total_tr.Size = new System.Drawing.Size(43, 21);
            this.t_total_tr.TabIndex = 127;
            this.t_total_tr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_total_tr.Visible = false;
            // 
            // frmOrdenFabricacionTRA1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(372, 288);
            this.Controls.Add(this.t_total_tr);
            this.Controls.Add(this.t_itemname);
            this.Controls.Add(this.t_total);
            this.Controls.Add(this.t_almacen);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.Grid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenFabricacionTRA1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termination Report / Selección de Insumos";
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTRA1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.TextBox t_almacen;
        private System.Windows.Forms.TextBox t_total;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.TextBox t_total_tr;
    }
}