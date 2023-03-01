
namespace FrmProcesos
{
    partial class FRP11
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRP11));
            this.t_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.t_temporada = new System.Windows.Forms.TextBox();
            this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_meta_mp = new System.Windows.Forms.TextBox();
            this.t_meta_pt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.t_rendimiento_mp = new System.Windows.Forms.TextBox();
            this.t_rendimiento_pt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t_horas_tot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_dias_semana = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.t_dias_mes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_code
            // 
            this.t_code.Location = new System.Drawing.Point(252, 6);
            this.t_code.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_code.MaxLength = 100;
            this.t_code.Name = "t_code";
            this.t_code.Size = new System.Drawing.Size(51, 21);
            this.t_code.TabIndex = 64;
            this.t_code.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "PT:";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(14, 368);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 60;
            this.btn_finalizar.Text = "Cerrar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(92, 368);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 59;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fecha Inicio:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 9);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "Temporada:";
            // 
            // t_temporada
            // 
            this.t_temporada.Location = new System.Drawing.Point(125, 6);
            this.t_temporada.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_temporada.MaxLength = 20;
            this.t_temporada.Name = "t_temporada";
            this.t_temporada.ReadOnly = true;
            this.t_temporada.Size = new System.Drawing.Size(123, 21);
            this.t_temporada.TabIndex = 54;
            // 
            // dtp_fecha_ini
            // 
            this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_ini.Location = new System.Drawing.Point(125, 30);
            this.dtp_fecha_ini.Name = "dtp_fecha_ini";
            this.dtp_fecha_ini.Size = new System.Drawing.Size(123, 21);
            this.dtp_fecha_ini.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.t_meta_mp);
            this.groupBox1.Controls.Add(this.t_meta_pt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meta Productiva";
            // 
            // t_meta_mp
            // 
            this.t_meta_mp.Location = new System.Drawing.Point(69, 53);
            this.t_meta_mp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_meta_mp.MaxLength = 100;
            this.t_meta_mp.Name = "t_meta_mp";
            this.t_meta_mp.Size = new System.Drawing.Size(84, 21);
            this.t_meta_mp.TabIndex = 1;
            this.t_meta_mp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_meta_mp.Leave += new System.EventHandler(this.t_meta_mp_Leave);
            // 
            // t_meta_pt
            // 
            this.t_meta_pt.Location = new System.Drawing.Point(69, 29);
            this.t_meta_pt.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_meta_pt.MaxLength = 100;
            this.t_meta_pt.Name = "t_meta_pt";
            this.t_meta_pt.Size = new System.Drawing.Size(84, 21);
            this.t_meta_pt.TabIndex = 0;
            this.t_meta_pt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_meta_pt.Leave += new System.EventHandler(this.t_meta_pt_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "MP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.t_rendimiento_mp);
            this.groupBox2.Controls.Add(this.t_rendimiento_pt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(185, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 91);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rendimiento";
            // 
            // t_rendimiento_mp
            // 
            this.t_rendimiento_mp.Location = new System.Drawing.Point(65, 53);
            this.t_rendimiento_mp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_rendimiento_mp.MaxLength = 100;
            this.t_rendimiento_mp.Name = "t_rendimiento_mp";
            this.t_rendimiento_mp.Size = new System.Drawing.Size(85, 21);
            this.t_rendimiento_mp.TabIndex = 1;
            this.t_rendimiento_mp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_rendimiento_mp.Leave += new System.EventHandler(this.t_rendimiento_mp_Leave);
            // 
            // t_rendimiento_pt
            // 
            this.t_rendimiento_pt.Location = new System.Drawing.Point(65, 29);
            this.t_rendimiento_pt.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_rendimiento_pt.MaxLength = 100;
            this.t_rendimiento_pt.Name = "t_rendimiento_pt";
            this.t_rendimiento_pt.Size = new System.Drawing.Size(85, 21);
            this.t_rendimiento_pt.TabIndex = 0;
            this.t_rendimiento_pt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_rendimiento_pt.Leave += new System.EventHandler(this.t_rendimiento_pt_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "MP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "PT:";
            // 
            // t_horas_tot
            // 
            this.t_horas_tot.Location = new System.Drawing.Point(125, 56);
            this.t_horas_tot.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_horas_tot.MaxLength = 100;
            this.t_horas_tot.Name = "t_horas_tot";
            this.t_horas_tot.Size = new System.Drawing.Size(65, 21);
            this.t_horas_tot.TabIndex = 1;
            this.t_horas_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_horas_tot.Leave += new System.EventHandler(this.t_horas_tot_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Horas Totales:";
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3});
            this.Grid1.Location = new System.Drawing.Point(14, 233);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(338, 118);
            this.Grid1.TabIndex = 6;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Turno";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Meta PT";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Meta MP";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // t_dias_semana
            // 
            this.t_dias_semana.Location = new System.Drawing.Point(125, 80);
            this.t_dias_semana.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_dias_semana.MaxLength = 100;
            this.t_dias_semana.Name = "t_dias_semana";
            this.t_dias_semana.Size = new System.Drawing.Size(65, 21);
            this.t_dias_semana.TabIndex = 2;
            this.t_dias_semana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_dias_semana.Leave += new System.EventHandler(this.t_dias_semana_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 190;
            this.label7.Text = "Días habiles semana:";
            // 
            // t_dias_mes
            // 
            this.t_dias_mes.Location = new System.Drawing.Point(125, 105);
            this.t_dias_mes.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_dias_mes.MaxLength = 100;
            this.t_dias_mes.Name = "t_dias_mes";
            this.t_dias_mes.Size = new System.Drawing.Size(65, 21);
            this.t_dias_mes.TabIndex = 3;
            this.t_dias_mes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_dias_mes.Leave += new System.EventHandler(this.t_dias_mes_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 192;
            this.label8.Text = "Días habiles mes:";
            // 
            // FRP11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(372, 398);
            this.Controls.Add(this.t_dias_mes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.t_dias_semana);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.t_horas_tot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp_fecha_ini);
            this.Controls.Add(this.t_code);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.t_temporada);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRP11";
            this.Text = "[FRP11] Definición de Temporadas";
            this.Load += new System.EventHandler(this.FRP11_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox t_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_temporada;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_meta_mp;
        private System.Windows.Forms.TextBox t_meta_pt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t_rendimiento_mp;
        private System.Windows.Forms.TextBox t_rendimiento_pt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_horas_tot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox t_dias_semana;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_dias_mes;
        private System.Windows.Forms.Label label8;
    }
}