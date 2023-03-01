namespace FrmProcesos
{
    partial class frmBLoqLotes
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
            this.txtLotePallet = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btn_bloquea_lotes_calidad = new System.Windows.Forms.Button();
            this.btn_libera_lotes_calidad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLotePallet
            // 
            this.txtLotePallet.Location = new System.Drawing.Point(12, 12);
            this.txtLotePallet.Name = "txtLotePallet";
            this.txtLotePallet.Size = new System.Drawing.Size(217, 21);
            this.txtLotePallet.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(145, 465);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lote,
            this.Estado,
            this.Bodega,
            this.Kilos});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(445, 389);
            this.dataGridView1.TabIndex = 2;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote/Pallet";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
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
            // 
            // Kilos
            // 
            this.Kilos.HeaderText = "Kilos";
            this.Kilos.Name = "Kilos";
            this.Kilos.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(237, 461);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.BackColor = System.Drawing.Color.Chartreuse;
            this.btnBloquear.Location = new System.Drawing.Point(179, 465);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(109, 23);
            this.btnBloquear.TabIndex = 4;
            this.btnBloquear.Text = "&Bloquear Lote";
            this.btnBloquear.UseVisualStyleBackColor = false;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.BackColor = System.Drawing.Color.Chartreuse;
            this.btnDesbloquear.Location = new System.Drawing.Point(348, 436);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(109, 23);
            this.btnDesbloquear.TabIndex = 5;
            this.btnDesbloquear.Text = "&Liberar Lote";
            this.btnDesbloquear.UseVisualStyleBackColor = false;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btn_bloquea_lotes_calidad
            // 
            this.btn_bloquea_lotes_calidad.Location = new System.Drawing.Point(12, 436);
            this.btn_bloquea_lotes_calidad.Name = "btn_bloquea_lotes_calidad";
            this.btn_bloquea_lotes_calidad.Size = new System.Drawing.Size(127, 23);
            this.btn_bloquea_lotes_calidad.TabIndex = 6;
            this.btn_bloquea_lotes_calidad.Text = "&Bloquea Lotes";
            this.btn_bloquea_lotes_calidad.UseVisualStyleBackColor = true;
            this.btn_bloquea_lotes_calidad.Click += new System.EventHandler(this.btn_bloquea_lotes_calidad_Click);
            // 
            // btn_libera_lotes_calidad
            // 
            this.btn_libera_lotes_calidad.Location = new System.Drawing.Point(12, 465);
            this.btn_libera_lotes_calidad.Name = "btn_libera_lotes_calidad";
            this.btn_libera_lotes_calidad.Size = new System.Drawing.Size(127, 23);
            this.btn_libera_lotes_calidad.TabIndex = 7;
            this.btn_libera_lotes_calidad.Text = "Libera Lotes Cracker";
            this.btn_libera_lotes_calidad.UseVisualStyleBackColor = true;
            this.btn_libera_lotes_calidad.Click += new System.EventHandler(this.btn_libera_lotes_calidad_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Consultar Lotes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Chartreuse;
            this.button2.Location = new System.Drawing.Point(237, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Bloquear Lote";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmBLoqLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 496);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_libera_lotes_calidad);
            this.Controls.Add(this.btn_bloquea_lotes_calidad);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnBloquear);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtLotePallet);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBLoqLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado Lotes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotePallet;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btn_bloquea_lotes_calidad;
        private System.Windows.Forms.Button btn_libera_lotes_calidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}