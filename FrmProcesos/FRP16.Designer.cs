﻿
namespace FrmProcesos
{
    partial class FRP16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRP16));
            this.t_item = new System.Windows.Forms.TextBox();
            this.btn_desmarca_todos = new System.Windows.Forms.Button();
            this.btn_marca_todos = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_matriz = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // t_item
            // 
            this.t_item.Location = new System.Drawing.Point(563, 413);
            this.t_item.Name = "t_item";
            this.t_item.Size = new System.Drawing.Size(74, 21);
            this.t_item.TabIndex = 201;
            this.t_item.Visible = false;
            // 
            // btn_desmarca_todos
            // 
            this.btn_desmarca_todos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_desmarca_todos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_desmarca_todos.Location = new System.Drawing.Point(388, 414);
            this.btn_desmarca_todos.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_desmarca_todos.Name = "btn_desmarca_todos";
            this.btn_desmarca_todos.Size = new System.Drawing.Size(120, 22);
            this.btn_desmarca_todos.TabIndex = 200;
            this.btn_desmarca_todos.Text = "Desmarca Todos  ";
            this.btn_desmarca_todos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_desmarca_todos.UseVisualStyleBackColor = false;
            this.btn_desmarca_todos.Click += new System.EventHandler(this.btn_desmarca_todos_Click);
            // 
            // btn_marca_todos
            // 
            this.btn_marca_todos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_marca_todos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_marca_todos.Location = new System.Drawing.Point(281, 414);
            this.btn_marca_todos.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_marca_todos.Name = "btn_marca_todos";
            this.btn_marca_todos.Size = new System.Drawing.Size(103, 22);
            this.btn_marca_todos.TabIndex = 199;
            this.btn_marca_todos.Text = "Marca Todos  ";
            this.btn_marca_todos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_marca_todos.UseVisualStyleBackColor = false;
            this.btn_marca_todos.Click += new System.EventHandler(this.btn_marca_todos_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(7, 414);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 198;
            this.btn_cancelar.Text = "Cerrar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_grabar
            // 
            this.btn_grabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_grabar.Location = new System.Drawing.Point(85, 414);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(75, 22);
            this.btn_grabar.TabIndex = 197;
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.UseVisualStyleBackColor = false;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.dataGridViewTextBoxColumn2});
            this.Grid2.Location = new System.Drawing.Point(281, 232);
            this.Grid2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 5;
            this.Grid2.Size = new System.Drawing.Size(570, 174);
            this.Grid2.TabIndex = 196;
            this.Grid2.DoubleClick += new System.EventHandler(this.Grid2_DoubleClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sel.";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Código";
            this.Column3.Name = "Column3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Proceso";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5});
            this.Grid1.Location = new System.Drawing.Point(7, 7);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(257, 399);
            this.Grid1.TabIndex = 195;
            this.Grid1.SelectionChanged += new System.EventHandler(this.Grid1_SelectionChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "UserSign";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Usuario";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Grid3
            // 
            this.Grid3.AllowUserToAddRows = false;
            this.Grid3.AllowUserToDeleteRows = false;
            this.Grid3.BackgroundColor = System.Drawing.Color.White;
            this.Grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.Grid3.Location = new System.Drawing.Point(281, 7);
            this.Grid3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid3.Name = "Grid3";
            this.Grid3.RowHeadersWidth = 5;
            this.Grid3.Size = new System.Drawing.Size(570, 217);
            this.Grid3.TabIndex = 202;
            this.Grid3.SelectionChanged += new System.EventHandler(this.Grid3_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Código";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Proceso";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // t_matriz
            // 
            this.t_matriz.Location = new System.Drawing.Point(643, 415);
            this.t_matriz.Name = "t_matriz";
            this.t_matriz.Size = new System.Drawing.Size(74, 21);
            this.t_matriz.TabIndex = 203;
            this.t_matriz.Visible = false;
            // 
            // FRP16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(876, 448);
            this.Controls.Add(this.t_matriz);
            this.Controls.Add(this.Grid3);
            this.Controls.Add(this.t_item);
            this.Controls.Add(this.btn_desmarca_todos);
            this.Controls.Add(this.btn_marca_todos);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.Grid2);
            this.Controls.Add(this.Grid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRP16";
            this.Text = "[FRP16] Autorización por Proceso";
            this.Load += new System.EventHandler(this.FRP16_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_item;
        private System.Windows.Forms.Button btn_desmarca_todos;
        private System.Windows.Forms.Button btn_marca_todos;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_grabar;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView Grid3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox t_matriz;
    }
}