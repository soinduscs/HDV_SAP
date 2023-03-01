
namespace FrmProcesos
{
    partial class frmCalidadPPA9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPPA9));
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.t_atributo = new System.Windows.Forms.TextBox();
            this.t_codatr = new System.Windows.Forms.TextBox();
            this.t_referencia = new System.Windows.Forms.TextBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_ok1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column2,
            this.Column6,
            this.Column1});
            this.Grid2.Location = new System.Drawing.Point(9, 39);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 20;
            this.Grid2.Size = new System.Drawing.Size(590, 261);
            this.Grid2.TabIndex = 25;
            this.Grid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "LineId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Atributo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 350;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "DocEntry_Ref";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Visible = false;
            this.Column6.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Acción";
            this.Column1.Items.AddRange(new object[] {
            "",
            "+",
            "-"});
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(9, 307);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 121;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 122;
            this.label1.Text = "Atributo:";
            // 
            // t_atributo
            // 
            this.t_atributo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_atributo.Location = new System.Drawing.Point(218, 7);
            this.t_atributo.Name = "t_atributo";
            this.t_atributo.ReadOnly = true;
            this.t_atributo.Size = new System.Drawing.Size(385, 26);
            this.t_atributo.TabIndex = 123;
            // 
            // t_codatr
            // 
            this.t_codatr.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codatr.Location = new System.Drawing.Point(84, 7);
            this.t_codatr.Name = "t_codatr";
            this.t_codatr.ReadOnly = true;
            this.t_codatr.Size = new System.Drawing.Size(124, 26);
            this.t_codatr.TabIndex = 124;
            // 
            // t_referencia
            // 
            this.t_referencia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_referencia.Location = new System.Drawing.Point(156, 23);
            this.t_referencia.Name = "t_referencia";
            this.t_referencia.ReadOnly = true;
            this.t_referencia.Size = new System.Drawing.Size(24, 26);
            this.t_referencia.TabIndex = 125;
            this.t_referencia.Visible = false;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_agregar.Location = new System.Drawing.Point(394, 307);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 22);
            this.btn_agregar.TabIndex = 126;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_eliminar.Location = new System.Drawing.Point(497, 307);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(102, 22);
            this.btn_eliminar.TabIndex = 127;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_ok1
            // 
            this.btn_ok1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok1.Location = new System.Drawing.Point(84, 307);
            this.btn_ok1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok1.Name = "btn_ok1";
            this.btn_ok1.Size = new System.Drawing.Size(74, 22);
            this.btn_ok1.TabIndex = 183;
            this.btn_ok1.Text = "Grabar";
            this.btn_ok1.UseVisualStyleBackColor = false;
            this.btn_ok1.Click += new System.EventHandler(this.btn_ok1_Click);
            // 
            // frmCalidadPPA9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 348);
            this.Controls.Add(this.btn_ok1);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.t_referencia);
            this.Controls.Add(this.t_codatr);
            this.Controls.Add(this.t_atributo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.Grid2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadPPA9";
            this.Text = "Matriz de Procesos de Calidad / Detalle";
            this.Load += new System.EventHandler(this.frmCalidadPPA9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_atributo;
        private System.Windows.Forms.TextBox t_codatr;
        private System.Windows.Forms.TextBox t_referencia;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.Button btn_ok1;
    }
}