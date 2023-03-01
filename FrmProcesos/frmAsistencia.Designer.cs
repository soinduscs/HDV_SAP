namespace FrmProcesos
{
    partial class frmAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistencia));
            this.t_responsable = new System.Windows.Forms.TextBox();
            this.t_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_area = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_anho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_semana = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_ccosto = new System.Windows.Forms.ComboBox();
            this.t_fecha_desde = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t_fecha_hasta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbb_turno = new System.Windows.Forms.ComboBox();
            this.btn_cambia_turno = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbb_dia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_cambiar_dia = new System.Windows.Forms.Button();
            this.cbb_estado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_crear = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbb_turno_b = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_rotar = new System.Windows.Forms.Button();
            this.cbb_turno_a = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.t_idrut_empleado = new System.Windows.Forms.TextBox();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.t_nombre_empleado = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_responsable
            // 
            this.t_responsable.Location = new System.Drawing.Point(1211, 26);
            this.t_responsable.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_responsable.Name = "t_responsable";
            this.t_responsable.ReadOnly = true;
            this.t_responsable.Size = new System.Drawing.Size(20, 21);
            this.t_responsable.TabIndex = 173;
            this.t_responsable.Visible = false;
            // 
            // t_nombre
            // 
            this.t_nombre.Location = new System.Drawing.Point(996, 25);
            this.t_nombre.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_nombre.Name = "t_nombre";
            this.t_nombre.ReadOnly = true;
            this.t_nombre.Size = new System.Drawing.Size(211, 21);
            this.t_nombre.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(914, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "Responsable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 170;
            this.label1.Text = "Área:";
            // 
            // cbb_area
            // 
            this.cbb_area.FormattingEnabled = true;
            this.cbb_area.Location = new System.Drawing.Point(100, 45);
            this.cbb_area.Name = "cbb_area";
            this.cbb_area.Size = new System.Drawing.Size(151, 21);
            this.cbb_area.TabIndex = 169;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 175;
            this.label3.Text = "Año:";
            // 
            // cbb_anho
            // 
            this.cbb_anho.FormattingEnabled = true;
            this.cbb_anho.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020"});
            this.cbb_anho.Location = new System.Drawing.Point(71, 19);
            this.cbb_anho.Name = "cbb_anho";
            this.cbb_anho.Size = new System.Drawing.Size(53, 21);
            this.cbb_anho.TabIndex = 174;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 177;
            this.label4.Text = "Semana:";
            // 
            // cbb_semana
            // 
            this.cbb_semana.FormattingEnabled = true;
            this.cbb_semana.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020"});
            this.cbb_semana.Location = new System.Drawing.Point(71, 45);
            this.cbb_semana.Name = "cbb_semana";
            this.cbb_semana.Size = new System.Drawing.Size(53, 21);
            this.cbb_semana.TabIndex = 176;
            this.cbb_semana.SelectedIndexChanged += new System.EventHandler(this.cbb_semana_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 179;
            this.label5.Text = "Centro Costo:";
            // 
            // cbb_ccosto
            // 
            this.cbb_ccosto.FormattingEnabled = true;
            this.cbb_ccosto.Location = new System.Drawing.Point(100, 19);
            this.cbb_ccosto.Name = "cbb_ccosto";
            this.cbb_ccosto.Size = new System.Drawing.Size(151, 21);
            this.cbb_ccosto.TabIndex = 178;
            // 
            // t_fecha_desde
            // 
            this.t_fecha_desde.Location = new System.Drawing.Point(242, 19);
            this.t_fecha_desde.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_desde.Name = "t_fecha_desde";
            this.t_fecha_desde.ReadOnly = true;
            this.t_fecha_desde.Size = new System.Drawing.Size(91, 21);
            this.t_fecha_desde.TabIndex = 181;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 180;
            this.label6.Text = "Rango de Fechas:";
            // 
            // t_fecha_hasta
            // 
            this.t_fecha_hasta.Location = new System.Drawing.Point(337, 19);
            this.t_fecha_hasta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_hasta.Name = "t_fecha_hasta";
            this.t_fecha_hasta.ReadOnly = true;
            this.t_fecha_hasta.Size = new System.Drawing.Size(91, 21);
            this.t_fecha_hasta.TabIndex = 182;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_anho);
            this.groupBox1.Controls.Add(this.t_fecha_hasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.t_fecha_desde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbb_semana);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 85);
            this.groupBox1.TabIndex = 183;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_actualizar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbb_ccosto);
            this.groupBox2.Controls.Add(this.cbb_area);
            this.groupBox2.Location = new System.Drawing.Point(458, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 85);
            this.groupBox2.TabIndex = 184;
            this.groupBox2.TabStop = false;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_actualizar.Image = global::FrmProcesos.Properties.Resources.action_refresh;
            this.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_actualizar.Location = new System.Drawing.Point(279, 17);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(133, 22);
            this.btn_actualizar.TabIndex = 180;
            this.btn_actualizar.Text = "  Cargar datos";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column11,
            this.Column12,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column13});
            this.Grid1.Location = new System.Drawing.Point(12, 100);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(1277, 417);
            this.Grid1.TabIndex = 185;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DocEntry";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "NOMBRE";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 280;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "RUT";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CARGO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 180;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "AREA DE TRABAJO";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 180;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "TIPO DE CONTRATO";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 90;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "TURNO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 55;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "HORARIO ACTUAL";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "LUN";
            this.Column4.Name = "Column4";
            this.Column4.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "MAR";
            this.Column7.Name = "Column7";
            this.Column7.Width = 40;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "MIE";
            this.Column9.Name = "Column9";
            this.Column9.Width = 40;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "JUE";
            this.Column10.Name = "Column10";
            this.Column10.Width = 40;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "VIE";
            this.Column13.Name = "Column13";
            this.Column13.Width = 40;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cancelar.Location = new System.Drawing.Point(12, 525);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(74, 22);
            this.btn_cancelar.TabIndex = 186;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 188;
            this.label7.Text = "Turno:";
            // 
            // cbb_turno
            // 
            this.cbb_turno.FormattingEnabled = true;
            this.cbb_turno.Location = new System.Drawing.Point(51, 21);
            this.cbb_turno.Name = "cbb_turno";
            this.cbb_turno.Size = new System.Drawing.Size(151, 21);
            this.cbb_turno.TabIndex = 187;
            // 
            // btn_cambia_turno
            // 
            this.btn_cambia_turno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cambia_turno.Image = global::FrmProcesos.Properties.Resources._16__Convert_;
            this.btn_cambia_turno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cambia_turno.Location = new System.Drawing.Point(206, 21);
            this.btn_cambia_turno.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cambia_turno.Name = "btn_cambia_turno";
            this.btn_cambia_turno.Size = new System.Drawing.Size(112, 22);
            this.btn_cambia_turno.TabIndex = 181;
            this.btn_cambia_turno.Text = "     Cambiar Turno";
            this.btn_cambia_turno.UseVisualStyleBackColor = false;
            this.btn_cambia_turno.Click += new System.EventHandler(this.btn_cambia_turno_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cambia_turno);
            this.groupBox3.Controls.Add(this.cbb_turno);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 54);
            this.groupBox3.TabIndex = 189;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar Turno";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbb_dia);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btn_cambiar_dia);
            this.groupBox4.Controls.Add(this.cbb_estado);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 54);
            this.groupBox4.TabIndex = 190;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Asignar Estado x día";
            // 
            // cbb_dia
            // 
            this.cbb_dia.FormattingEnabled = true;
            this.cbb_dia.Items.AddRange(new object[] {
            "",
            "LUN",
            "MAR",
            "MIE",
            "JUE",
            "VIE"});
            this.cbb_dia.Location = new System.Drawing.Point(50, 21);
            this.cbb_dia.Name = "cbb_dia";
            this.cbb_dia.Size = new System.Drawing.Size(64, 21);
            this.cbb_dia.TabIndex = 189;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 190;
            this.label9.Text = "Día:";
            // 
            // btn_cambiar_dia
            // 
            this.btn_cambiar_dia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_cambiar_dia.Image = global::FrmProcesos.Properties.Resources._16__Convert_;
            this.btn_cambiar_dia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cambiar_dia.Location = new System.Drawing.Point(240, 21);
            this.btn_cambiar_dia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cambiar_dia.Name = "btn_cambiar_dia";
            this.btn_cambiar_dia.Size = new System.Drawing.Size(110, 22);
            this.btn_cambiar_dia.TabIndex = 181;
            this.btn_cambiar_dia.Text = "  Cambiar Día";
            this.btn_cambiar_dia.UseVisualStyleBackColor = false;
            this.btn_cambiar_dia.Click += new System.EventHandler(this.btn_cambiar_dia_Click);
            // 
            // cbb_estado
            // 
            this.cbb_estado.FormattingEnabled = true;
            this.cbb_estado.Location = new System.Drawing.Point(171, 21);
            this.cbb_estado.Name = "cbb_estado";
            this.cbb_estado.Size = new System.Drawing.Size(64, 21);
            this.cbb_estado.TabIndex = 187;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 188;
            this.label8.Text = "Estado:";
            // 
            // btn_crear
            // 
            this.btn_crear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_crear.Location = new System.Drawing.Point(87, 525);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(90, 22);
            this.btn_crear.TabIndex = 191;
            this.btn_crear.Text = "Grabar";
            this.btn_crear.UseVisualStyleBackColor = false;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbb_turno_b);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.btn_rotar);
            this.groupBox5.Controls.Add(this.cbb_turno_a);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(360, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 54);
            this.groupBox5.TabIndex = 190;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rotar Turno";
            // 
            // cbb_turno_b
            // 
            this.cbb_turno_b.FormattingEnabled = true;
            this.cbb_turno_b.Location = new System.Drawing.Point(167, 21);
            this.cbb_turno_b.Name = "cbb_turno_b";
            this.cbb_turno_b.Size = new System.Drawing.Size(61, 21);
            this.cbb_turno_b.TabIndex = 189;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(125, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 190;
            this.label11.Text = "Turno:";
            // 
            // btn_rotar
            // 
            this.btn_rotar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_rotar.Image = global::FrmProcesos.Properties.Resources._16__Convert_;
            this.btn_rotar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rotar.Location = new System.Drawing.Point(242, 21);
            this.btn_rotar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_rotar.Name = "btn_rotar";
            this.btn_rotar.Size = new System.Drawing.Size(110, 22);
            this.btn_rotar.TabIndex = 181;
            this.btn_rotar.Text = "    Rotar Turno";
            this.btn_rotar.UseVisualStyleBackColor = false;
            this.btn_rotar.Click += new System.EventHandler(this.btn_rotar_Click);
            // 
            // cbb_turno_a
            // 
            this.cbb_turno_a.FormattingEnabled = true;
            this.cbb_turno_a.Location = new System.Drawing.Point(57, 21);
            this.cbb_turno_a.Name = "cbb_turno_a";
            this.cbb_turno_a.Size = new System.Drawing.Size(61, 21);
            this.cbb_turno_a.TabIndex = 187;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 188;
            this.label10.Text = "Turno:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(194, 525);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 104);
            this.tabControl1.TabIndex = 192;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1087, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Turnos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1087, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Estado por día";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1087, 78);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Empleados";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.t_idrut_empleado);
            this.groupBox6.Controls.Add(this.btn_buscar1);
            this.groupBox6.Controls.Add(this.t_nombre_empleado);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Location = new System.Drawing.Point(6, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(649, 58);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Agregar Empleado al área";
            // 
            // t_idrut_empleado
            // 
            this.t_idrut_empleado.Location = new System.Drawing.Point(493, 20);
            this.t_idrut_empleado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_idrut_empleado.Name = "t_idrut_empleado";
            this.t_idrut_empleado.ReadOnly = true;
            this.t_idrut_empleado.Size = new System.Drawing.Size(15, 21);
            this.t_idrut_empleado.TabIndex = 186;
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(85, 20);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar1.TabIndex = 185;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // t_nombre_empleado
            // 
            this.t_nombre_empleado.Location = new System.Drawing.Point(108, 21);
            this.t_nombre_empleado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_nombre_empleado.Name = "t_nombre_empleado";
            this.t_nombre_empleado.ReadOnly = true;
            this.t_nombre_empleado.Size = new System.Drawing.Size(381, 21);
            this.t_nombre_empleado.TabIndex = 184;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 183;
            this.label12.Text = "Empleado:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Image = global::FrmProcesos.Properties.Resources._16__Convert_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(512, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 22);
            this.button1.TabIndex = 182;
            this.button1.Text = "    Agregar Empleado";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1315, 646);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.t_responsable);
            this.Controls.Add(this.t_nombre);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsistencia";
            this.Text = "Administración de asistencia";
            this.Load += new System.EventHandler(this.frmAsistencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_responsable;
        private System.Windows.Forms.TextBox t_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_area;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_anho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_semana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbb_ccosto;
        private System.Windows.Forms.TextBox t_fecha_desde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_fecha_hasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbb_turno;
        private System.Windows.Forms.Button btn_cambia_turno;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbb_dia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_cambiar_dia;
        private System.Windows.Forms.ComboBox cbb_estado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbb_turno_b;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_rotar;
        private System.Windows.Forms.ComboBox cbb_turno_a;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox t_nombre_empleado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.TextBox t_idrut_empleado;
    }
}