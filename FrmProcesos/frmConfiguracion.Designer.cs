namespace FrmProcesos
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.t_puerto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_baudios = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_bits_datos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cbb_seleccionar_impresora = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // t_puerto
            // 
            this.t_puerto.Location = new System.Drawing.Point(92, 16);
            this.t_puerto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_puerto.MaxLength = 10;
            this.t_puerto.Name = "t_puerto";
            this.t_puerto.Size = new System.Drawing.Size(75, 21);
            this.t_puerto.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 19);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "Puerto:";
            // 
            // t_baudios
            // 
            this.t_baudios.Location = new System.Drawing.Point(92, 45);
            this.t_baudios.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_baudios.MaxLength = 10;
            this.t_baudios.Name = "t_baudios";
            this.t_baudios.Size = new System.Drawing.Size(75, 21);
            this.t_baudios.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Baudios:";
            // 
            // t_bits_datos
            // 
            this.t_bits_datos.Location = new System.Drawing.Point(92, 74);
            this.t_bits_datos.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_bits_datos.MaxLength = 10;
            this.t_bits_datos.Name = "t_bits_datos";
            this.t_bits_datos.Size = new System.Drawing.Size(75, 21);
            this.t_bits_datos.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Bits de Datos:";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(14, 118);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 34;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(92, 118);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 33;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cbb_seleccionar_impresora
            // 
            this.cbb_seleccionar_impresora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_seleccionar_impresora.FormattingEnabled = true;
            this.cbb_seleccionar_impresora.Location = new System.Drawing.Point(12, 159);
            this.cbb_seleccionar_impresora.Name = "cbb_seleccionar_impresora";
            this.cbb_seleccionar_impresora.Size = new System.Drawing.Size(285, 24);
            this.cbb_seleccionar_impresora.TabIndex = 118;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(325, 215);
            this.Controls.Add(this.cbb_seleccionar_impresora);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.t_bits_datos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_baudios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_puerto);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguracion";
            this.Text = "Configuración de Balanza";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_puerto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_baudios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_bits_datos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.ComboBox cbb_seleccionar_impresora;
    }
}