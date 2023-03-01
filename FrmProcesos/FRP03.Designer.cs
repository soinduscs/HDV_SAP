namespace FrmProcesos
{
    partial class FRP03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRP03));
            this.cbb_tipofruta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.t_name = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_code = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbb_tipofruta
            // 
            this.cbb_tipofruta.FormattingEnabled = true;
            this.cbb_tipofruta.Items.AddRange(new object[] {
            "Almendra",
            "Nuez ",
            "Nuez C/C"});
            this.cbb_tipofruta.Location = new System.Drawing.Point(82, 61);
            this.cbb_tipofruta.Name = "cbb_tipofruta";
            this.cbb_tipofruta.Size = new System.Drawing.Size(172, 21);
            this.cbb_tipofruta.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Tipo Fruta:";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(16, 102);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 56;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(94, 102);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 55;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Id:";
            // 
            // t_name
            // 
            this.t_name.Location = new System.Drawing.Point(82, 37);
            this.t_name.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_name.MaxLength = 100;
            this.t_name.Name = "t_name";
            this.t_name.Size = new System.Drawing.Size(39, 21);
            this.t_name.TabIndex = 51;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 53;
            this.label18.Text = "Proceso:";
            // 
            // t_code
            // 
            this.t_code.Location = new System.Drawing.Point(82, 13);
            this.t_code.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_code.MaxLength = 20;
            this.t_code.Name = "t_code";
            this.t_code.Size = new System.Drawing.Size(172, 21);
            this.t_code.TabIndex = 50;
            // 
            // FRP03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(272, 143);
            this.Controls.Add(this.cbb_tipofruta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_name);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.t_code);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRP03";
            this.Text = "[FRP03] Definición de Procesos";
            this.Load += new System.EventHandler(this.FRP03_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_tipofruta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_name;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_code;
    }
}