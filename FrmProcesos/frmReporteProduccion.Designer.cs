namespace FrmProcesos
{
    partial class frmReporteProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteProduccion));
            this.cbb_seleccionar_impresora = new System.Windows.Forms.ComboBox();
            this.btn_imprimir1 = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.t_docentry = new System.Windows.Forms.TextBox();
            this.btn_imprimir2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_cantidad_etiquetas = new System.Windows.Forms.ComboBox();
            this.dtp_nueva_fecha = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.t_object = new System.Windows.Forms.TextBox();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.t_total_bins = new System.Windows.Forms.TextBox();
            this.T_Proceso = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_seleccionar_impresora
            // 
            this.cbb_seleccionar_impresora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_seleccionar_impresora.FormattingEnabled = true;
            this.cbb_seleccionar_impresora.Location = new System.Drawing.Point(11, 18);
            this.cbb_seleccionar_impresora.Name = "cbb_seleccionar_impresora";
            this.cbb_seleccionar_impresora.Size = new System.Drawing.Size(285, 27);
            this.cbb_seleccionar_impresora.TabIndex = 117;
            // 
            // btn_imprimir1
            // 
            this.btn_imprimir1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_imprimir1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir1.Location = new System.Drawing.Point(301, 18);
            this.btn_imprimir1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir1.Name = "btn_imprimir1";
            this.btn_imprimir1.Size = new System.Drawing.Size(192, 24);
            this.btn_imprimir1.TabIndex = 116;
            this.btn_imprimir1.Text = "Etiqueta Adhesiva";
            this.btn_imprimir1.UseVisualStyleBackColor = false;
            this.btn_imprimir1.Click += new System.EventHandler(this.btn_imprimir1_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(12, 131);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 118;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // t_docentry
            // 
            this.t_docentry.Location = new System.Drawing.Point(91, 133);
            this.t_docentry.Name = "t_docentry";
            this.t_docentry.Size = new System.Drawing.Size(100, 24);
            this.t_docentry.TabIndex = 119;
            this.t_docentry.Visible = false;
            // 
            // btn_imprimir2
            // 
            this.btn_imprimir2.BackColor = System.Drawing.Color.Lime;
            this.btn_imprimir2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir2.Location = new System.Drawing.Point(301, 18);
            this.btn_imprimir2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_imprimir2.Name = "btn_imprimir2";
            this.btn_imprimir2.Size = new System.Drawing.Size(306, 24);
            this.btn_imprimir2.TabIndex = 120;
            this.btn_imprimir2.Text = "Imprimir Tarja de Pallet";
            this.btn_imprimir2.UseVisualStyleBackColor = false;
            this.btn_imprimir2.Click += new System.EventHandler(this.btn_imprimir2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 112);
            this.tabControl1.TabIndex = 121;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbb_cantidad_etiquetas);
            this.tabPage1.Controls.Add(this.dtp_nueva_fecha);
            this.tabPage1.Controls.Add(this.cbb_seleccionar_impresora);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.btn_imprimir1);
            this.tabPage1.ImageKey = "(ninguno)";
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(617, 82);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Etiqueta Adhesiva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 21);
            this.label1.TabIndex = 124;
            this.label1.Text = "Cantidad de Etiquetas:";
            // 
            // cbb_cantidad_etiquetas
            // 
            this.cbb_cantidad_etiquetas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_cantidad_etiquetas.FormattingEnabled = true;
            this.cbb_cantidad_etiquetas.Location = new System.Drawing.Point(445, 47);
            this.cbb_cantidad_etiquetas.Name = "cbb_cantidad_etiquetas";
            this.cbb_cantidad_etiquetas.Size = new System.Drawing.Size(75, 27);
            this.cbb_cantidad_etiquetas.TabIndex = 123;
            // 
            // dtp_nueva_fecha
            // 
            this.dtp_nueva_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_nueva_fecha.Location = new System.Drawing.Point(174, 48);
            this.dtp_nueva_fecha.Name = "dtp_nueva_fecha";
            this.dtp_nueva_fecha.Size = new System.Drawing.Size(122, 24);
            this.dtp_nueva_fecha.TabIndex = 122;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(173, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Modificar Fecha Emisión";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_imprimir2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(617, 82);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tarja de Pallet";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // t_object
            // 
            this.t_object.Location = new System.Drawing.Point(197, 133);
            this.t_object.Name = "t_object";
            this.t_object.Size = new System.Drawing.Size(100, 24);
            this.t_object.TabIndex = 122;
            this.t_object.Visible = false;
            // 
            // t_lote
            // 
            this.t_lote.Location = new System.Drawing.Point(303, 133);
            this.t_lote.Name = "t_lote";
            this.t_lote.Size = new System.Drawing.Size(100, 24);
            this.t_lote.TabIndex = 123;
            this.t_lote.Visible = false;
            // 
            // t_total_bins
            // 
            this.t_total_bins.Location = new System.Drawing.Point(409, 132);
            this.t_total_bins.Name = "t_total_bins";
            this.t_total_bins.Size = new System.Drawing.Size(100, 24);
            this.t_total_bins.TabIndex = 124;
            this.t_total_bins.Visible = false;
            // 
            // T_Proceso
            // 
            this.T_Proceso.Location = new System.Drawing.Point(515, 133);
            this.T_Proceso.Name = "T_Proceso";
            this.T_Proceso.Size = new System.Drawing.Size(100, 24);
            this.T_Proceso.TabIndex = 125;
            this.T_Proceso.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(497, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 24);
            this.button1.TabIndex = 125;
            this.button1.Text = "Lote";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReporteProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 172);
            this.Controls.Add(this.T_Proceso);
            this.Controls.Add(this.t_total_bins);
            this.Controls.Add(this.t_lote);
            this.Controls.Add(this.t_object);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.t_docentry);
            this.Controls.Add(this.btn_finalizar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteProduccion";
            this.Text = "Reporte de Producción";
            this.Load += new System.EventHandler(this.frmReporteProduccion_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_seleccionar_impresora;
        private System.Windows.Forms.Button btn_imprimir1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_docentry;
        private System.Windows.Forms.Button btn_imprimir2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtp_nueva_fecha;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbb_cantidad_etiquetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_object;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.TextBox t_total_bins;
        private System.Windows.Forms.TextBox T_Proceso;
        private System.Windows.Forms.Button button1;
    }
}