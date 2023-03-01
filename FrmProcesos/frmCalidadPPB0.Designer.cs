
namespace FrmProcesos
{
    partial class frmCalidadPPB0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalidadPPB0));
            this.t_codatr = new System.Windows.Forms.TextBox();
            this.t_atributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_TipoAnalisis = new System.Windows.Forms.ComboBox();
            this.lbl_TipoAnalisis = new System.Windows.Forms.Label();
            this.txt_tipo_analisis_control = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_standar = new System.Windows.Forms.TextBox();
            this.t_hasta = new System.Windows.Forms.TextBox();
            this.t_desde = new System.Windows.Forms.TextBox();
            this.t_UM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.t_comportamiento = new System.Windows.Forms.TextBox();
            this.btn_detalle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_comportamiento = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_porcentaje = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_ok1 = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbb_UbicacionRgistro = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.t_valor_pie = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbb_operacion = new System.Windows.Forms.ComboBox();
            this.cbb_grabar_pie = new System.Windows.Forms.Button();
            this.chk_locked = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_codatr
            // 
            this.t_codatr.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_codatr.Location = new System.Drawing.Point(90, 12);
            this.t_codatr.Name = "t_codatr";
            this.t_codatr.ReadOnly = true;
            this.t_codatr.Size = new System.Drawing.Size(124, 30);
            this.t_codatr.TabIndex = 127;
            // 
            // t_atributo
            // 
            this.t_atributo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_atributo.Location = new System.Drawing.Point(220, 12);
            this.t_atributo.Name = "t_atributo";
            this.t_atributo.Size = new System.Drawing.Size(430, 30);
            this.t_atributo.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 125;
            this.label1.Text = "Atributo:";
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
            this.cbb_TipoAnalisis.Location = new System.Drawing.Point(220, 50);
            this.cbb_TipoAnalisis.Name = "cbb_TipoAnalisis";
            this.cbb_TipoAnalisis.Size = new System.Drawing.Size(246, 32);
            this.cbb_TipoAnalisis.TabIndex = 128;
            this.cbb_TipoAnalisis.SelectedIndexChanged += new System.EventHandler(this.cbb_TipoAnalisis_SelectedIndexChanged);
            // 
            // lbl_TipoAnalisis
            // 
            this.lbl_TipoAnalisis.AutoSize = true;
            this.lbl_TipoAnalisis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TipoAnalisis.Location = new System.Drawing.Point(86, 53);
            this.lbl_TipoAnalisis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TipoAnalisis.Name = "lbl_TipoAnalisis";
            this.lbl_TipoAnalisis.Size = new System.Drawing.Size(143, 24);
            this.lbl_TipoAnalisis.TabIndex = 129;
            this.lbl_TipoAnalisis.Text = "Tipo Análisis:";
            // 
            // txt_tipo_analisis_control
            // 
            this.txt_tipo_analisis_control.Location = new System.Drawing.Point(472, 50);
            this.txt_tipo_analisis_control.Name = "txt_tipo_analisis_control";
            this.txt_tipo_analisis_control.Size = new System.Drawing.Size(23, 24);
            this.txt_tipo_analisis_control.TabIndex = 176;
            this.txt_tipo_analisis_control.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_locked);
            this.groupBox1.Controls.Add(this.t_standar);
            this.groupBox1.Controls.Add(this.t_hasta);
            this.groupBox1.Controls.Add(this.t_desde);
            this.groupBox1.Controls.Add(this.t_UM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 71);
            this.groupBox1.TabIndex = 177;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // t_standar
            // 
            this.t_standar.Location = new System.Drawing.Point(405, 26);
            this.t_standar.MaxLength = 10;
            this.t_standar.Name = "t_standar";
            this.t_standar.Size = new System.Drawing.Size(71, 24);
            this.t_standar.TabIndex = 7;
            this.t_standar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_standar.Leave += new System.EventHandler(this.t_standar_Leave);
            // 
            // t_hasta
            // 
            this.t_hasta.Location = new System.Drawing.Point(267, 26);
            this.t_hasta.MaxLength = 10;
            this.t_hasta.Name = "t_hasta";
            this.t_hasta.Size = new System.Drawing.Size(71, 24);
            this.t_hasta.TabIndex = 6;
            this.t_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_hasta.Leave += new System.EventHandler(this.t_hasta_Leave);
            // 
            // t_desde
            // 
            this.t_desde.Location = new System.Drawing.Point(144, 26);
            this.t_desde.MaxLength = 10;
            this.t_desde.Name = "t_desde";
            this.t_desde.Size = new System.Drawing.Size(71, 24);
            this.t_desde.TabIndex = 5;
            this.t_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_desde.Leave += new System.EventHandler(this.t_desde_Leave);
            // 
            // t_UM
            // 
            this.t_UM.Location = new System.Drawing.Point(45, 26);
            this.t_UM.MaxLength = 10;
            this.t_UM.Name = "t_UM";
            this.t_UM.Size = new System.Drawing.Size(47, 24);
            this.t_UM.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Estandar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "UM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.t_comportamiento);
            this.groupBox2.Controls.Add(this.btn_detalle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbb_comportamiento);
            this.groupBox2.Location = new System.Drawing.Point(16, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 76);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Definición - Columna VALOR";
            // 
            // t_comportamiento
            // 
            this.t_comportamiento.Location = new System.Drawing.Point(474, 29);
            this.t_comportamiento.Name = "t_comportamiento";
            this.t_comportamiento.Size = new System.Drawing.Size(23, 24);
            this.t_comportamiento.TabIndex = 180;
            this.t_comportamiento.Visible = false;
            // 
            // btn_detalle
            // 
            this.btn_detalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_detalle.Location = new System.Drawing.Point(340, 29);
            this.btn_detalle.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_detalle.Name = "btn_detalle";
            this.btn_detalle.Size = new System.Drawing.Size(129, 22);
            this.btn_detalle.TabIndex = 179;
            this.btn_detalle.Text = "Detalle de Valor";
            this.btn_detalle.UseVisualStyleBackColor = false;
            this.btn_detalle.Click += new System.EventHandler(this.btn_detalle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 130;
            this.label6.Text = "Comportamiento";
            // 
            // cbb_comportamiento
            // 
            this.cbb_comportamiento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbb_comportamiento.FormattingEnabled = true;
            this.cbb_comportamiento.Items.AddRange(new object[] {
            "",
            "Digitación",
            "Calculado",
            "Resumen"});
            this.cbb_comportamiento.Location = new System.Drawing.Point(139, 29);
            this.cbb_comportamiento.Name = "cbb_comportamiento";
            this.cbb_comportamiento.Size = new System.Drawing.Size(194, 25);
            this.cbb_comportamiento.TabIndex = 129;
            this.cbb_comportamiento.SelectedIndexChanged += new System.EventHandler(this.cbb_comportamiento_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_porcentaje);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(16, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 79);
            this.groupBox3.TabIndex = 179;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Definición - Columna PORCENTAJE";
            // 
            // btn_porcentaje
            // 
            this.btn_porcentaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_porcentaje.Location = new System.Drawing.Point(340, 33);
            this.btn_porcentaje.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_porcentaje.Name = "btn_porcentaje";
            this.btn_porcentaje.Size = new System.Drawing.Size(129, 22);
            this.btn_porcentaje.TabIndex = 180;
            this.btn_porcentaje.Text = "Detalle de Valor";
            this.btn_porcentaje.UseVisualStyleBackColor = false;
            this.btn_porcentaje.Click += new System.EventHandler(this.btn_porcentaje_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "No aplica",
            "Valor Externo",
            "Calculo Fijo"});
            this.comboBox1.Location = new System.Drawing.Point(139, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 25);
            this.comboBox1.TabIndex = 132;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 131;
            this.label7.Text = "Comportamiento";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(15, 429);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 180;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(16, 275);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 181;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.btn_ok);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(15, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 328);
            this.groupBox4.TabIndex = 182;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de Parametros";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_ok1);
            this.groupBox5.Controls.Add(this.btn_eliminar);
            this.groupBox5.Controls.Add(this.btn_agregar);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.Grid2);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cbb_UbicacionRgistro);
            this.groupBox5.Location = new System.Drawing.Point(15, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(635, 328);
            this.groupBox5.TabIndex = 183;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Valor de Pie de Registro";
            // 
            // btn_ok1
            // 
            this.btn_ok1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok1.Location = new System.Drawing.Point(43, 275);
            this.btn_ok1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok1.Name = "btn_ok1";
            this.btn_ok1.Size = new System.Drawing.Size(74, 22);
            this.btn_ok1.TabIndex = 182;
            this.btn_ok1.Text = "Grabar";
            this.btn_ok1.UseVisualStyleBackColor = false;
            this.btn_ok1.Click += new System.EventHandler(this.btn_ok1_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_eliminar.Location = new System.Drawing.Point(231, 187);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(102, 22);
            this.btn_eliminar.TabIndex = 137;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_agregar.Location = new System.Drawing.Point(128, 187);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 22);
            this.btn_agregar.TabIndex = 136;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 134;
            this.label9.Text = "Valores";
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column2});
            this.Grid2.Location = new System.Drawing.Point(128, 64);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 20;
            this.Grid2.Size = new System.Drawing.Size(330, 116);
            this.Grid2.TabIndex = 133;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Atributo";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 17);
            this.label8.TabIndex = 132;
            this.label8.Text = "Ubicación Pie de Registro";
            // 
            // cbb_UbicacionRgistro
            // 
            this.cbb_UbicacionRgistro.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbb_UbicacionRgistro.FormattingEnabled = true;
            this.cbb_UbicacionRgistro.Items.AddRange(new object[] {
            "",
            "Primero",
            "Segundo",
            "Tercero",
            "Cuarto"});
            this.cbb_UbicacionRgistro.Location = new System.Drawing.Point(173, 27);
            this.cbb_UbicacionRgistro.Name = "cbb_UbicacionRgistro";
            this.cbb_UbicacionRgistro.Size = new System.Drawing.Size(107, 25);
            this.cbb_UbicacionRgistro.TabIndex = 131;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.t_valor_pie);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.cbb_operacion);
            this.groupBox6.Controls.Add(this.cbb_grabar_pie);
            this.groupBox6.Location = new System.Drawing.Point(15, 94);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(612, 303);
            this.groupBox6.TabIndex = 184;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "% Matriz de Procesos de Calidad / % - Pie";
            this.groupBox6.Visible = false;
            // 
            // t_valor_pie
            // 
            this.t_valor_pie.Location = new System.Drawing.Point(147, 61);
            this.t_valor_pie.Name = "t_valor_pie";
            this.t_valor_pie.Size = new System.Drawing.Size(86, 24);
            this.t_valor_pie.TabIndex = 187;
            this.t_valor_pie.Text = "0";
            this.t_valor_pie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_valor_pie.Leave += new System.EventHandler(this.t_valor_pie_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 17);
            this.label11.TabIndex = 186;
            this.label11.Text = "Valor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 185;
            this.label10.Text = "Operación:";
            // 
            // cbb_operacion
            // 
            this.cbb_operacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbb_operacion.FormattingEnabled = true;
            this.cbb_operacion.Items.AddRange(new object[] {
            "",
            "/",
            "*"});
            this.cbb_operacion.Location = new System.Drawing.Point(147, 30);
            this.cbb_operacion.Name = "cbb_operacion";
            this.cbb_operacion.Size = new System.Drawing.Size(86, 25);
            this.cbb_operacion.TabIndex = 184;
            // 
            // cbb_grabar_pie
            // 
            this.cbb_grabar_pie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cbb_grabar_pie.Location = new System.Drawing.Point(46, 107);
            this.cbb_grabar_pie.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbb_grabar_pie.Name = "cbb_grabar_pie";
            this.cbb_grabar_pie.Size = new System.Drawing.Size(74, 22);
            this.cbb_grabar_pie.TabIndex = 183;
            this.cbb_grabar_pie.Text = "Grabar";
            this.cbb_grabar_pie.UseVisualStyleBackColor = false;
            this.cbb_grabar_pie.Click += new System.EventHandler(this.cbb_grabar_pie_Click);
            // 
            // chk_locked
            // 
            this.chk_locked.AutoSize = true;
            this.chk_locked.Location = new System.Drawing.Point(492, 28);
            this.chk_locked.Name = "chk_locked";
            this.chk_locked.Size = new System.Drawing.Size(83, 21);
            this.chk_locked.TabIndex = 185;
            this.chk_locked.Text = "Bloquear";
            this.chk_locked.UseVisualStyleBackColor = true;
            // 
            // frmCalidadPPB0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 465);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.txt_tipo_analisis_control);
            this.Controls.Add(this.lbl_TipoAnalisis);
            this.Controls.Add(this.cbb_TipoAnalisis);
            this.Controls.Add(this.t_codatr);
            this.Controls.Add(this.t_atributo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalidadPPB0";
            this.Text = "Matriz de Procesos de Calidad / Propiedades";
            this.Load += new System.EventHandler(this.frmCalidadPPB0_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_codatr;
        private System.Windows.Forms.TextBox t_atributo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_TipoAnalisis;
        private System.Windows.Forms.Label lbl_TipoAnalisis;
        private System.Windows.Forms.TextBox txt_tipo_analisis_control;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_standar;
        private System.Windows.Forms.TextBox t_hasta;
        private System.Windows.Forms.TextBox t_desde;
        private System.Windows.Forms.TextBox t_UM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_comportamiento;
        private System.Windows.Forms.Button btn_detalle;
        private System.Windows.Forms.TextBox t_comportamiento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_porcentaje;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbb_UbicacionRgistro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btn_ok1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbb_operacion;
        private System.Windows.Forms.Button cbb_grabar_pie;
        private System.Windows.Forms.TextBox t_valor_pie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_locked;
    }
}