
namespace FrmProcesos
{
    partial class FRP19
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRP19));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_registros_pendientes = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_consultar1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_fecha2 = new System.Windows.Forms.DateTimePicker();
            this.btn_consultar2 = new System.Windows.Forms.Button();
            this.dtp_fecha1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.t_num_guia = new System.Windows.Forms.TextBox();
            this.btn_consultar3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_consultar4 = new System.Windows.Forms.Button();
            this.t_cardcode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t_cardname = new System.Windows.Forms.TextBox();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.t_ultimo_boton = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_anho_actual = new System.Windows.Forms.CheckBox();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1198, 83);
            this.tabControl1.TabIndex = 441;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbb_anho_actual);
            this.tabPage5.Controls.Add(this.btn_registros_pendientes);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1190, 57);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Solo Registros Pendientes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_registros_pendientes
            // 
            this.btn_registros_pendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_registros_pendientes.Location = new System.Drawing.Point(28, 17);
            this.btn_registros_pendientes.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_registros_pendientes.Name = "btn_registros_pendientes";
            this.btn_registros_pendientes.Size = new System.Drawing.Size(227, 22);
            this.btn_registros_pendientes.TabIndex = 56;
            this.btn_registros_pendientes.Text = "Consultar Registros Pendientes";
            this.btn_registros_pendientes.UseVisualStyleBackColor = false;
            this.btn_registros_pendientes.Click += new System.EventHandler(this.btn_registros_pendientes_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.t_lote);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btn_consultar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1190, 57);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lote";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_consultar1
            // 
            this.btn_consultar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_consultar1.Location = new System.Drawing.Point(178, 16);
            this.btn_consultar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_consultar1.Name = "btn_consultar1";
            this.btn_consultar1.Size = new System.Drawing.Size(89, 22);
            this.btn_consultar1.TabIndex = 54;
            this.btn_consultar1.Text = "Consultar";
            this.btn_consultar1.UseVisualStyleBackColor = false;
            this.btn_consultar1.Click += new System.EventHandler(this.btn_consultar1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dtp_fecha2);
            this.tabPage2.Controls.Add(this.btn_consultar2);
            this.tabPage2.Controls.Add(this.dtp_fecha1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1190, 57);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rango de Fechas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Hasta:";
            // 
            // dtp_fecha2
            // 
            this.dtp_fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha2.Location = new System.Drawing.Point(205, 17);
            this.dtp_fecha2.Name = "dtp_fecha2";
            this.dtp_fecha2.Size = new System.Drawing.Size(95, 21);
            this.dtp_fecha2.TabIndex = 58;
            // 
            // btn_consultar2
            // 
            this.btn_consultar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_consultar2.Location = new System.Drawing.Point(317, 16);
            this.btn_consultar2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_consultar2.Name = "btn_consultar2";
            this.btn_consultar2.Size = new System.Drawing.Size(89, 22);
            this.btn_consultar2.TabIndex = 57;
            this.btn_consultar2.Text = "Consultar";
            this.btn_consultar2.UseVisualStyleBackColor = false;
            // 
            // dtp_fecha1
            // 
            this.dtp_fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha1.Location = new System.Drawing.Point(61, 17);
            this.dtp_fecha1.Name = "dtp_fecha1";
            this.dtp_fecha1.Size = new System.Drawing.Size(95, 21);
            this.dtp_fecha1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Desde:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.t_num_guia);
            this.tabPage3.Controls.Add(this.btn_consultar3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1190, 57);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Número de Guía";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // t_num_guia
            // 
            this.t_num_guia.Location = new System.Drawing.Point(104, 18);
            this.t_num_guia.Name = "t_num_guia";
            this.t_num_guia.Size = new System.Drawing.Size(80, 21);
            this.t_num_guia.TabIndex = 60;
            // 
            // btn_consultar3
            // 
            this.btn_consultar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_consultar3.Location = new System.Drawing.Point(189, 17);
            this.btn_consultar3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_consultar3.Name = "btn_consultar3";
            this.btn_consultar3.Size = new System.Drawing.Size(89, 22);
            this.btn_consultar3.TabIndex = 59;
            this.btn_consultar3.Text = "Consultar";
            this.btn_consultar3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Número de Guía:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_consultar4);
            this.tabPage4.Controls.Add(this.t_cardcode);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.t_cardname);
            this.tabPage4.Controls.Add(this.btn_buscar1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1190, 57);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Productor";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_consultar4
            // 
            this.btn_consultar4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_consultar4.Location = new System.Drawing.Point(656, 15);
            this.btn_consultar4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_consultar4.Name = "btn_consultar4";
            this.btn_consultar4.Size = new System.Drawing.Size(89, 22);
            this.btn_consultar4.TabIndex = 60;
            this.btn_consultar4.Text = "Consultar";
            this.btn_consultar4.UseVisualStyleBackColor = false;
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(98, 16);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 15;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.Size = new System.Drawing.Size(130, 21);
            this.t_cardcode.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(236, 19);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Productor:";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(288, 16);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(355, 21);
            this.t_cardname.TabIndex = 36;
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(75, 15);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar1.TabIndex = 33;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(12, 485);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 440;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(102, 485);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 22);
            this.button1.TabIndex = 439;
            this.button1.Text = "Registro de Humedad";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column5,
            this.Column14,
            this.Column15,
            this.Column7,
            this.Column10,
            this.Column8,
            this.Column21,
            this.Column2,
            this.Column3});
            this.Grid1.Location = new System.Drawing.Point(12, 106);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(1198, 371);
            this.Grid1.TabIndex = 438;
            // 
            // t_ultimo_boton
            // 
            this.t_ultimo_boton.Location = new System.Drawing.Point(563, 484);
            this.t_ultimo_boton.Name = "t_ultimo_boton";
            this.t_ultimo_boton.Size = new System.Drawing.Size(100, 21);
            this.t_ultimo_boton.TabIndex = 442;
            this.t_ultimo_boton.Text = "F1";
            this.t_ultimo_boton.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Guía Verde";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fecha Ingreso";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Productor";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 280;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "OF Secado";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 80;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Lote Secado";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Especie";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 280;
            // 
            // Column10
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column10.HeaderText = "Cant. Bins";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 60;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Estado Calidad";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 240;
            // 
            // Column21
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column21.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column21.HeaderText = "id_ri_humedad";
            this.Column21.MinimumWidth = 6;
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Visible = false;
            this.Column21.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ItemCode";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "id_docentry_tr";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // cbb_anho_actual
            // 
            this.cbb_anho_actual.AutoSize = true;
            this.cbb_anho_actual.Checked = true;
            this.cbb_anho_actual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbb_anho_actual.Location = new System.Drawing.Point(319, 21);
            this.cbb_anho_actual.Name = "cbb_anho_actual";
            this.cbb_anho_actual.Size = new System.Drawing.Size(99, 17);
            this.cbb_anho_actual.TabIndex = 57;
            this.cbb_anho_actual.Text = "Solo año actual";
            this.cbb_anho_actual.UseVisualStyleBackColor = true;
            // 
            // t_lote
            // 
            this.t_lote.Location = new System.Drawing.Point(68, 18);
            this.t_lote.Name = "t_lote";
            this.t_lote.Size = new System.Drawing.Size(80, 21);
            this.t_lote.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Lote:";
            // 
            // FRP19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1228, 531);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.t_ultimo_boton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRP19";
            this.Text = "[FRP19] Registro de Inspección - D&S / Humedad";
            this.Load += new System.EventHandler(this.FRP19_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_registros_pendientes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_consultar1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fecha2;
        private System.Windows.Forms.Button btn_consultar2;
        private System.Windows.Forms.DateTimePicker dtp_fecha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox t_num_guia;
        private System.Windows.Forms.Button btn_consultar3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_consultar4;
        private System.Windows.Forms.TextBox t_cardcode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_cardname;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox t_ultimo_boton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox cbb_anho_actual;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.Label label5;
    }
}