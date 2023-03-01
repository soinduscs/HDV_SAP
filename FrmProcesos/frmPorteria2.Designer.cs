namespace FrmProcesos
{
    partial class frmPorteria2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPorteria2));
            this.t_imagen = new System.Windows.Forms.TextBox();
            this.btn_escanear = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_subir_imagen = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_imagen
            // 
            this.t_imagen.Location = new System.Drawing.Point(109, 77);
            this.t_imagen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.t_imagen.Name = "t_imagen";
            this.t_imagen.ReadOnly = true;
            this.t_imagen.Size = new System.Drawing.Size(153, 18);
            this.t_imagen.TabIndex = 37;
            this.t_imagen.Visible = false;
            // 
            // btn_escanear
            // 
            this.btn_escanear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_escanear.Location = new System.Drawing.Point(62, 422);
            this.btn_escanear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_escanear.Name = "btn_escanear";
            this.btn_escanear.Size = new System.Drawing.Size(127, 19);
            this.btn_escanear.TabIndex = 36;
            this.btn_escanear.Text = "Escanear Documento";
            this.btn_escanear.UseVisualStyleBackColor = false;
            this.btn_escanear.Click += new System.EventHandler(this.btn_escanear_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(0, 422);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(62, 19);
            this.btn_cancelar.TabIndex = 35;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir.Location = new System.Drawing.Point(325, 422);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(74, 19);
            this.btn_imprimir.TabIndex = 38;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(740, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(289, 203);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 441);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // btn_subir_imagen
            // 
            this.btn_subir_imagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_subir_imagen.Location = new System.Drawing.Point(193, 422);
            this.btn_subir_imagen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_subir_imagen.Name = "btn_subir_imagen";
            this.btn_subir_imagen.Size = new System.Drawing.Size(127, 19);
            this.btn_subir_imagen.TabIndex = 54;
            this.btn_subir_imagen.Text = "Adjuntar Documento";
            this.btn_subir_imagen.UseVisualStyleBackColor = false;
            this.btn_subir_imagen.Click += new System.EventHandler(this.btn_subir_imagen_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(267, 77);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(266, 280);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(109, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(45, 30);
            this.dataGridView1.TabIndex = 61;
            // 
            // frmPorteria2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 441);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_subir_imagen);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.t_imagen);
            this.Controls.Add(this.btn_escanear);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "frmPorteria2";
            this.Text = "Control de Acceso de Camiones";
            this.Load += new System.EventHandler(this.frmPorteria2_Load);
            this.SizeChanged += new System.EventHandler(this.frmPorteria2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_imagen;
        private System.Windows.Forms.Button btn_escanear;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_subir_imagen;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}