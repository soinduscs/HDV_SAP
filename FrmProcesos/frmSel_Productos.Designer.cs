namespace FrmProcesos
{
    partial class frmSel_Productos
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
            this.chk_con_oc = new System.Windows.Forms.CheckBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chk_solo_mp = new System.Windows.Forms.CheckBox();
            this.chk_fruta_propia = new System.Windows.Forms.CheckBox();
            this.t_buscar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_con_oc
            // 
            this.chk_con_oc.AutoSize = true;
            this.chk_con_oc.Location = new System.Drawing.Point(639, 11);
            this.chk_con_oc.Margin = new System.Windows.Forms.Padding(4);
            this.chk_con_oc.Name = "chk_con_oc";
            this.chk_con_oc.Size = new System.Drawing.Size(205, 17);
            this.chk_con_oc.TabIndex = 33;
            this.chk_con_oc.Text = "Solo Productos con Orden de Compra";
            this.chk_con_oc.UseVisualStyleBackColor = true;
            this.chk_con_oc.CheckedChanged += new System.EventHandler(this.chk_solo_mp_CheckedChanged);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(14, 418);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 29;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_seleccionar.Location = new System.Drawing.Point(90, 418);
            this.btn_seleccionar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(88, 22);
            this.btn_seleccionar.TabIndex = 28;
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
            this.dataGridView1.Location = new System.Drawing.Point(14, 73);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(836, 341);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // chk_solo_mp
            // 
            this.chk_solo_mp.AutoSize = true;
            this.chk_solo_mp.Checked = true;
            this.chk_solo_mp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_solo_mp.Location = new System.Drawing.Point(639, 30);
            this.chk_solo_mp.Margin = new System.Windows.Forms.Padding(4);
            this.chk_solo_mp.Name = "chk_solo_mp";
            this.chk_solo_mp.Size = new System.Drawing.Size(114, 17);
            this.chk_solo_mp.TabIndex = 34;
            this.chk_solo_mp.Text = "Solo Materia Prima";
            this.chk_solo_mp.UseVisualStyleBackColor = true;
            this.chk_solo_mp.CheckedChanged += new System.EventHandler(this.chk_solo_mp_CheckedChanged_1);
            // 
            // chk_fruta_propia
            // 
            this.chk_fruta_propia.AutoSize = true;
            this.chk_fruta_propia.Location = new System.Drawing.Point(639, 50);
            this.chk_fruta_propia.Margin = new System.Windows.Forms.Padding(4);
            this.chk_fruta_propia.Name = "chk_fruta_propia";
            this.chk_fruta_propia.Size = new System.Drawing.Size(108, 17);
            this.chk_fruta_propia.TabIndex = 35;
            this.chk_fruta_propia.Text = "Solo Fruta Propia";
            this.chk_fruta_propia.UseVisualStyleBackColor = true;
            this.chk_fruta_propia.CheckedChanged += new System.EventHandler(this.chk_fruta_propia_CheckedChanged);
            // 
            // t_buscar
            // 
            this.t_buscar.Location = new System.Drawing.Point(133, 8);
            this.t_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_buscar.Name = "t_buscar";
            this.t_buscar.Size = new System.Drawing.Size(283, 21);
            this.t_buscar.TabIndex = 36;
            this.t_buscar.TextChanged += new System.EventHandler(this.t_buscar_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Buscar por Nombre:";
            // 
            // frmSel_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 457);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_buscar);
            this.Controls.Add(this.chk_fruta_propia);
            this.Controls.Add(this.chk_solo_mp);
            this.Controls.Add(this.chk_con_oc);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSel_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Productos";
            this.Load += new System.EventHandler(this.frmSel_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_con_oc;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chk_solo_mp;
        private System.Windows.Forms.CheckBox chk_fruta_propia;
        private System.Windows.Forms.TextBox t_buscar;
        private System.Windows.Forms.Label label9;
    }
}