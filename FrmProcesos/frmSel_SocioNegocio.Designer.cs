namespace FrmProcesos
{
    partial class frmSel_SocioNegocio
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
            this.t_carga = new System.Windows.Forms.TextBox();
            this.chk_con_OC = new System.Windows.Forms.CheckBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.t_buscar = new System.Windows.Forms.TextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chk_solo_proveedores = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_carga
            // 
            this.t_carga.Location = new System.Drawing.Point(434, 440);
            this.t_carga.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_carga.Name = "t_carga";
            this.t_carga.Size = new System.Drawing.Size(46, 21);
            this.t_carga.TabIndex = 24;
            this.t_carga.Visible = false;
            // 
            // chk_con_OC
            // 
            this.chk_con_OC.AutoSize = true;
            this.chk_con_OC.Location = new System.Drawing.Point(370, 16);
            this.chk_con_OC.Margin = new System.Windows.Forms.Padding(4);
            this.chk_con_OC.Name = "chk_con_OC";
            this.chk_con_OC.Size = new System.Drawing.Size(187, 17);
            this.chk_con_OC.TabIndex = 23;
            this.chk_con_OC.Text = "Solo Proveedores con OC Vigente";
            this.chk_con_OC.UseVisualStyleBackColor = true;
            this.chk_con_OC.CheckedChanged += new System.EventHandler(this.chk_con_OC_CheckedChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_buscar.Location = new System.Drawing.Point(233, 12);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(131, 22);
            this.btn_buscar.TabIndex = 21;
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
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Buscar:";
            // 
            // t_buscar
            // 
            this.t_buscar.Location = new System.Drawing.Point(50, 12);
            this.t_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_buscar.Name = "t_buscar";
            this.t_buscar.Size = new System.Drawing.Size(179, 21);
            this.t_buscar.TabIndex = 17;
            this.t_buscar.TextChanged += new System.EventHandler(this.t_buscar_TextChanged);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(6, 440);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 20;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_seleccionar.Location = new System.Drawing.Point(84, 440);
            this.btn_seleccionar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(88, 22);
            this.btn_seleccionar.TabIndex = 19;
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
            this.dataGridView1.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(569, 375);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // chk_solo_proveedores
            // 
            this.chk_solo_proveedores.AutoSize = true;
            this.chk_solo_proveedores.Location = new System.Drawing.Point(370, 37);
            this.chk_solo_proveedores.Margin = new System.Windows.Forms.Padding(4);
            this.chk_solo_proveedores.Name = "chk_solo_proveedores";
            this.chk_solo_proveedores.Size = new System.Drawing.Size(110, 17);
            this.chk_solo_proveedores.TabIndex = 25;
            this.chk_solo_proveedores.Text = "Solo Proveedores";
            this.chk_solo_proveedores.UseVisualStyleBackColor = true;
            this.chk_solo_proveedores.CheckedChanged += new System.EventHandler(this.chk_solo_proveedores_CheckedChanged);
            // 
            // frmSel_SocioNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 481);
            this.Controls.Add(this.chk_solo_proveedores);
            this.Controls.Add(this.t_carga);
            this.Controls.Add(this.chk_con_OC);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_buscar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSel_SocioNegocio";
            this.Text = "Lista de Socios de Negocios";
            this.Load += new System.EventHandler(this.frmSocioNegocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_carga;
        private System.Windows.Forms.CheckBox chk_con_OC;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_buscar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chk_solo_proveedores;
    }
}