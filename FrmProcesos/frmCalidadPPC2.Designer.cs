﻿
namespace FrmProcesos
{
    partial class frmCalidadPPC2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPPC2));
            this.t_codatr_new = new System.Windows.Forms.TextBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.t_atributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_atributo2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // t_codatr_new
            // 
            this.t_codatr_new.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codatr_new.Location = new System.Drawing.Point(300, 93);
            this.t_codatr_new.Name = "t_codatr_new";
            this.t_codatr_new.ReadOnly = true;
            this.t_codatr_new.Size = new System.Drawing.Size(124, 26);
            this.t_codatr_new.TabIndex = 208;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_agregar.Location = new System.Drawing.Point(168, 93);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 22);
            this.btn_agregar.TabIndex = 205;
            this.btn_agregar.Text = "Modificar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(90, 93);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 207;
            this.btn_finalizar.Text = "Cerrar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // t_atributo
            // 
            this.t_atributo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_atributo.Location = new System.Drawing.Point(192, 12);
            this.t_atributo.MaxLength = 100;
            this.t_atributo.Name = "t_atributo";
            this.t_atributo.ReadOnly = true;
            this.t_atributo.Size = new System.Drawing.Size(430, 26);
            this.t_atributo.TabIndex = 204;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 206;
            this.label1.Text = "Nombre Original:";
            // 
            // t_atributo2
            // 
            this.t_atributo2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_atributo2.Location = new System.Drawing.Point(192, 45);
            this.t_atributo2.MaxLength = 100;
            this.t_atributo2.Name = "t_atributo2";
            this.t_atributo2.Size = new System.Drawing.Size(430, 26);
            this.t_atributo2.TabIndex = 209;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 210;
            this.label2.Text = "Nuevo Nombre Matriz:";
            // 
            // frmCalidadPPC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 153);
            this.Controls.Add(this.t_atributo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_codatr_new);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.t_atributo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalidadPPC2";
            this.Text = "Matriz de Procesos de Calidad / Renombrar Matriz";
            this.Load += new System.EventHandler(this.frmCalidadPPC2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_codatr_new;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_atributo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_atributo2;
        private System.Windows.Forms.Label label2;
    }
}