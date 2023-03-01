namespace FrmProcesos
{
    partial class frmConsultaLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaLote));
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.btn_consulta = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.cbb_seleccionar_impresora = new System.Windows.Forms.ComboBox();
            this.btn_imprimir1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbb_almacen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_imprimir2 = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Lote,
            this.Column1,
            this.Estado,
            this.Bodega,
            this.Kilos,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8});
            this.Grid1.Location = new System.Drawing.Point(5, 79);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(971, 365);
            this.Grid1.TabIndex = 8;
            this.Grid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellDoubleClick);
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(6, 8);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(217, 21);
            this.txtLote.TabIndex = 6;
            // 
            // btn_consulta
            // 
            this.btn_consulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_consulta.Location = new System.Drawing.Point(228, 7);
            this.btn_consulta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_consulta.Name = "btn_consulta";
            this.btn_consulta.Size = new System.Drawing.Size(142, 22);
            this.btn_consulta.TabIndex = 36;
            this.btn_consulta.Text = "Consulta Lote";
            this.btn_consulta.UseVisualStyleBackColor = false;
            this.btn_consulta.Click += new System.EventHandler(this.btn_consulta_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(5, 451);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 35;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // cbb_seleccionar_impresora
            // 
            this.cbb_seleccionar_impresora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_seleccionar_impresora.FormattingEnabled = true;
            this.cbb_seleccionar_impresora.Location = new System.Drawing.Point(410, 450);
            this.cbb_seleccionar_impresora.Name = "cbb_seleccionar_impresora";
            this.cbb_seleccionar_impresora.Size = new System.Drawing.Size(255, 24);
            this.cbb_seleccionar_impresora.TabIndex = 119;
            // 
            // btn_imprimir1
            // 
            this.btn_imprimir1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir1.Location = new System.Drawing.Point(670, 449);
            this.btn_imprimir1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir1.Name = "btn_imprimir1";
            this.btn_imprimir1.Size = new System.Drawing.Size(306, 24);
            this.btn_imprimir1.TabIndex = 118;
            this.btn_imprimir1.Text = "Imprimir Etiqueta Adhesiva";
            this.btn_imprimir1.UseVisualStyleBackColor = false;
            this.btn_imprimir1.Click += new System.EventHandler(this.btn_imprimir1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 66);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLote);
            this.tabPage1.Controls.Add(this.btn_consulta);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(963, 40);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta por Lote";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbb_almacen);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(963, 40);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta por Almacén";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbb_almacen
            // 
            this.cbb_almacen.FormattingEnabled = true;
            this.cbb_almacen.Location = new System.Drawing.Point(6, 8);
            this.cbb_almacen.Name = "cbb_almacen";
            this.cbb_almacen.Size = new System.Drawing.Size(151, 21);
            this.cbb_almacen.TabIndex = 130;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(162, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 22);
            this.button1.TabIndex = 37;
            this.button1.Text = "Consulta Lote";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_imprimir2
            // 
            this.btn_imprimir2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir2.Location = new System.Drawing.Point(671, 481);
            this.btn_imprimir2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir2.Name = "btn_imprimir2";
            this.btn_imprimir2.Size = new System.Drawing.Size(305, 24);
            this.btn_imprimir2.TabIndex = 121;
            this.btn_imprimir2.Text = "Imprimir Tarja de Pallet";
            this.btn_imprimir2.UseVisualStyleBackColor = false;
            this.btn_imprimir2.Click += new System.EventHandler(this.btn_imprimir2_Click);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Sel.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 30;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Código";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Descripción";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Bodega
            // 
            this.Bodega.HeaderText = "Bodega";
            this.Bodega.Name = "Bodega";
            this.Bodega.ReadOnly = true;
            this.Bodega.Width = 80;
            // 
            // Kilos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kilos.DefaultCellStyle = dataGridViewCellStyle1;
            this.Kilos.HeaderText = "Cantidad Disponible";
            this.Kilos.Name = "Kilos";
            this.Kilos.ReadOnly = true;
            this.Kilos.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lote";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Productor";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Temporada";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Ref";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Fecha";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "DocEntry";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // frmConsultaLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 514);
            this.Controls.Add(this.btn_imprimir2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbb_seleccionar_impresora);
            this.Controls.Add(this.btn_imprimir1);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.Grid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaLote";
            this.Text = "Consulta de Lote";
            this.Load += new System.EventHandler(this.frmConsultaLote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Button btn_consulta;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.ComboBox cbb_seleccionar_impresora;
        private System.Windows.Forms.Button btn_imprimir1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbb_almacen;
        private System.Windows.Forms.Button btn_imprimir2;
        private System.Windows.Forms.DataGridViewImageColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}