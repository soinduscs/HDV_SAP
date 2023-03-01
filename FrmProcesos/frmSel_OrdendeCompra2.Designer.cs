namespace FrmProcesos
{
    partial class frmSel_OrdendeCompra2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSel_OrdendeCompra2));
            this.chk_solo_MP = new System.Windows.Forms.CheckBox();
            this.chk_incluir_fruta_servicios = new System.Windows.Forms.CheckBox();
            this.t_carga = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.t_buscar = new System.Windows.Forms.TextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_solo_MP
            // 
            this.chk_solo_MP.AutoSize = true;
            this.chk_solo_MP.Checked = true;
            this.chk_solo_MP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_solo_MP.Location = new System.Drawing.Point(567, 13);
            this.chk_solo_MP.Margin = new System.Windows.Forms.Padding(4);
            this.chk_solo_MP.Name = "chk_solo_MP";
            this.chk_solo_MP.Size = new System.Drawing.Size(146, 17);
            this.chk_solo_MP.TabIndex = 44;
            this.chk_solo_MP.Text = "Incluir Solo Materia Prima";
            this.chk_solo_MP.UseVisualStyleBackColor = true;
            // 
            // chk_incluir_fruta_servicios
            // 
            this.chk_incluir_fruta_servicios.AutoSize = true;
            this.chk_incluir_fruta_servicios.Checked = true;
            this.chk_incluir_fruta_servicios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_incluir_fruta_servicios.Location = new System.Drawing.Point(721, 14);
            this.chk_incluir_fruta_servicios.Margin = new System.Windows.Forms.Padding(4);
            this.chk_incluir_fruta_servicios.Name = "chk_incluir_fruta_servicios";
            this.chk_incluir_fruta_servicios.Size = new System.Drawing.Size(144, 17);
            this.chk_incluir_fruta_servicios.TabIndex = 43;
            this.chk_incluir_fruta_servicios.Text = "Incluir Fruta de Servicios";
            this.chk_incluir_fruta_servicios.UseVisualStyleBackColor = true;
            // 
            // t_carga
            // 
            this.t_carga.Location = new System.Drawing.Point(434, 440);
            this.t_carga.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_carga.Name = "t_carga";
            this.t_carga.Size = new System.Drawing.Size(46, 21);
            this.t_carga.TabIndex = 42;
            this.t_carga.Visible = false;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_buscar.Location = new System.Drawing.Point(399, 12);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(156, 22);
            this.btn_buscar.TabIndex = 40;
            this.btn_buscar.Text = "Busqueda en Nombre";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Buscar por Nombre:";
            // 
            // t_buscar
            // 
            this.t_buscar.Location = new System.Drawing.Point(109, 12);
            this.t_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_buscar.Name = "t_buscar";
            this.t_buscar.Size = new System.Drawing.Size(283, 21);
            this.t_buscar.TabIndex = 36;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(6, 440);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 39;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_seleccionar.Location = new System.Drawing.Point(82, 440);
            this.btn_seleccionar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(88, 22);
            this.btn_seleccionar.TabIndex = 38;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.UseVisualStyleBackColor = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 42);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(878, 395);
            this.dataGridView1.TabIndex = 37;
            // 
            // frmSel_OrdendeCompra2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 474);
            this.Controls.Add(this.chk_solo_MP);
            this.Controls.Add(this.chk_incluir_fruta_servicios);
            this.Controls.Add(this.t_carga);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_buscar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSel_OrdendeCompra2";
            this.Text = "Lista de Ordenes de Compra";
            this.Load += new System.EventHandler(this.frmSel_OrdendeCompra2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_solo_MP;
        private System.Windows.Forms.CheckBox chk_incluir_fruta_servicios;
        private System.Windows.Forms.TextBox t_carga;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_buscar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}