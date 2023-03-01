
namespace FrmProcesos
{
    partial class frmCalidadPPB5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPPB5));
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.t_codatr = new System.Windows.Forms.TextBox();
            this.t_atributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tipo_analisis_control = new System.Windows.Forms.TextBox();
            this.cbb_TipoAnalisis = new System.Windows.Forms.ComboBox();
            this.t_codatr_new = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_agregar.Location = new System.Drawing.Point(166, 79);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 22);
            this.btn_agregar.TabIndex = 136;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(88, 79);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 190;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // t_codatr
            // 
            this.t_codatr.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codatr.Location = new System.Drawing.Point(456, 18);
            this.t_codatr.Name = "t_codatr";
            this.t_codatr.ReadOnly = true;
            this.t_codatr.Size = new System.Drawing.Size(124, 26);
            this.t_codatr.TabIndex = 186;
            // 
            // t_atributo
            // 
            this.t_atributo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_atributo.Location = new System.Drawing.Point(150, 46);
            this.t_atributo.MaxLength = 100;
            this.t_atributo.Name = "t_atributo";
            this.t_atributo.Size = new System.Drawing.Size(430, 26);
            this.t_atributo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 184;
            this.label1.Text = "Nombre Atributo:";
            // 
            // txt_tipo_analisis_control
            // 
            this.txt_tipo_analisis_control.Location = new System.Drawing.Point(295, 80);
            this.txt_tipo_analisis_control.Name = "txt_tipo_analisis_control";
            this.txt_tipo_analisis_control.Size = new System.Drawing.Size(23, 21);
            this.txt_tipo_analisis_control.TabIndex = 192;
            this.txt_tipo_analisis_control.Visible = false;
            // 
            // cbb_TipoAnalisis
            // 
            this.cbb_TipoAnalisis.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbb_TipoAnalisis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TipoAnalisis.FormattingEnabled = true;
            this.cbb_TipoAnalisis.Items.AddRange(new object[] {
            "",
            "Descarte",
            "Rayadas",
            "Partidas",
            "Fuera de Color"});
            this.cbb_TipoAnalisis.Location = new System.Drawing.Point(324, 79);
            this.cbb_TipoAnalisis.Name = "cbb_TipoAnalisis";
            this.cbb_TipoAnalisis.Size = new System.Drawing.Size(246, 27);
            this.cbb_TipoAnalisis.TabIndex = 191;
            this.cbb_TipoAnalisis.Visible = false;
            // 
            // t_codatr_new
            // 
            this.t_codatr_new.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codatr_new.Location = new System.Drawing.Point(150, 16);
            this.t_codatr_new.Name = "t_codatr_new";
            this.t_codatr_new.ReadOnly = true;
            this.t_codatr_new.Size = new System.Drawing.Size(124, 26);
            this.t_codatr_new.TabIndex = 193;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 194;
            this.label2.Text = "Nuevo Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 195;
            this.label3.Text = "Código Origen:";
            // 
            // frmCalidadPPB5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 128);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_codatr_new);
            this.Controls.Add(this.txt_tipo_analisis_control);
            this.Controls.Add(this.cbb_TipoAnalisis);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.t_codatr);
            this.Controls.Add(this.t_atributo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadPPB5";
            this.Text = "Matriz de Procesos de Calidad / Propiedades";
            this.Load += new System.EventHandler(this.frmCalidadPPB5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_codatr;
        private System.Windows.Forms.TextBox t_atributo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tipo_analisis_control;
        private System.Windows.Forms.ComboBox cbb_TipoAnalisis;
        private System.Windows.Forms.TextBox t_codatr_new;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}