namespace FrmProcesos
{
    partial class frmOrdenFabricacionTR2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenFabricacionTR2));
            this.cbb_Salida = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.t_DocNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_buscar_of = new System.Windows.Forms.Button();
            this.t_tipo_fruta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbb_Salida
            // 
            this.cbb_Salida.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Salida.FormattingEnabled = true;
            this.cbb_Salida.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbb_Salida.Location = new System.Drawing.Point(177, 37);
            this.cbb_Salida.Name = "cbb_Salida";
            this.cbb_Salida.Size = new System.Drawing.Size(497, 27);
            this.cbb_Salida.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(11, 40);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 19);
            this.label21.TabIndex = 239;
            this.label21.Text = "Puerta de Salida";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(15, 69);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 247;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir.Location = new System.Drawing.Point(177, 69);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(102, 22);
            this.btn_imprimir.TabIndex = 246;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // t_DocNum
            // 
            this.t_DocNum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_DocNum.Location = new System.Drawing.Point(177, 7);
            this.t_DocNum.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_DocNum.MaxLength = 10;
            this.t_DocNum.Name = "t_DocNum";
            this.t_DocNum.Size = new System.Drawing.Size(76, 27);
            this.t_DocNum.TabIndex = 0;
            this.t_DocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_DocNum.Leave += new System.EventHandler(this.t_DocNum_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 19);
            this.label12.TabIndex = 244;
            this.label12.Text = "Orden de Fabricación";
            // 
            // btn_buscar_of
            // 
            this.btn_buscar_of.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar_of.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar_of.Location = new System.Drawing.Point(255, 7);
            this.btn_buscar_of.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar_of.Name = "btn_buscar_of";
            this.btn_buscar_of.Size = new System.Drawing.Size(23, 27);
            this.btn_buscar_of.TabIndex = 245;
            this.btn_buscar_of.UseVisualStyleBackColor = false;
            this.btn_buscar_of.Click += new System.EventHandler(this.btn_buscar_of_Click);
            // 
            // t_tipo_fruta
            // 
            this.t_tipo_fruta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_tipo_fruta.Location = new System.Drawing.Point(390, 69);
            this.t_tipo_fruta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_tipo_fruta.MaxLength = 10;
            this.t_tipo_fruta.Name = "t_tipo_fruta";
            this.t_tipo_fruta.Size = new System.Drawing.Size(29, 27);
            this.t_tipo_fruta.TabIndex = 248;
            this.t_tipo_fruta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_tipo_fruta.Visible = false;
            // 
            // frmOrdenFabricacionTR2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 109);
            this.Controls.Add(this.t_tipo_fruta);
            this.Controls.Add(this.cbb_Salida);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_buscar_of);
            this.Controls.Add(this.t_DocNum);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrdenFabricacionTR2";
            this.Text = "Termination Report / Salida de Producción";
            this.Load += new System.EventHandler(this.frmOrdenFabricacionTR2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbb_Salida;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_buscar_of;
        private System.Windows.Forms.TextBox t_DocNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox t_tipo_fruta;
    }
}