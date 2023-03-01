namespace FrmProcesos
{
    partial class frmPorteria
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
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_sellos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t_patente_carro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_razoningreso = new System.Windows.Forms.ComboBox();
            this.lbl_fecha_ingreso = new System.Windows.Forms.Label();
            this.t_fecha_registro = new System.Windows.Forms.TextBox();
            this.t_num_guia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_escanear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_Transportista = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.t_cardname = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_conductor = new System.Windows.Forms.TextBox();
            this.t_cardcode = new System.Windows.Forms.TextBox();
            this.t_patente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.t_cargo = new System.Windows.Forms.TextBox();
            this.t_id_romana = new System.Windows.Forms.TextBox();
            this.t_imagen = new System.Windows.Forms.TextBox();
            this.t_id_acceso = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.t_1er_grabado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_nuevo.Location = new System.Drawing.Point(161, 322);
            this.btn_nuevo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(74, 22);
            this.btn_nuevo.TabIndex = 26;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = false;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(11, 322);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 25;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(86, 322);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(74, 22);
            this.btn_ok.TabIndex = 24;
            this.btn_ok.Text = "Grabar";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.t_sellos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.t_patente_carro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbb_razoningreso);
            this.groupBox1.Controls.Add(this.lbl_fecha_ingreso);
            this.groupBox1.Controls.Add(this.t_fecha_registro);
            this.groupBox1.Controls.Add(this.t_num_guia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_escanear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbb_Transportista);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btn_buscar1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.t_cardname);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.t_conductor);
            this.groupBox1.Controls.Add(this.t_cardcode);
            this.groupBox1.Controls.Add(this.t_patente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(11, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(496, 301);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // t_sellos
            // 
            this.t_sellos.Location = new System.Drawing.Point(123, 198);
            this.t_sellos.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_sellos.MaxLength = 80;
            this.t_sellos.Name = "t_sellos";
            this.t_sellos.Size = new System.Drawing.Size(355, 21);
            this.t_sellos.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Sellos:";
            // 
            // t_patente_carro
            // 
            this.t_patente_carro.Location = new System.Drawing.Point(123, 129);
            this.t_patente_carro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_patente_carro.MaxLength = 7;
            this.t_patente_carro.Name = "t_patente_carro";
            this.t_patente_carro.Size = new System.Drawing.Size(87, 21);
            this.t_patente_carro.TabIndex = 4;
            this.t_patente_carro.Leave += new System.EventHandler(this.t_patente_carro_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Patente Carro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Razón Ingreso:";
            // 
            // cbb_razoningreso
            // 
            this.cbb_razoningreso.FormattingEnabled = true;
            this.cbb_razoningreso.Location = new System.Drawing.Point(123, 14);
            this.cbb_razoningreso.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_razoningreso.Name = "cbb_razoningreso";
            this.cbb_razoningreso.Size = new System.Drawing.Size(355, 21);
            this.cbb_razoningreso.TabIndex = 0;
            this.cbb_razoningreso.SelectedIndexChanged += new System.EventHandler(this.cbb_razoningreso_SelectedIndexChanged);
            // 
            // lbl_fecha_ingreso
            // 
            this.lbl_fecha_ingreso.AutoSize = true;
            this.lbl_fecha_ingreso.Location = new System.Drawing.Point(271, 40);
            this.lbl_fecha_ingreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fecha_ingreso.Name = "lbl_fecha_ingreso";
            this.lbl_fecha_ingreso.Size = new System.Drawing.Size(80, 13);
            this.lbl_fecha_ingreso.TabIndex = 29;
            this.lbl_fecha_ingreso.Text = "Fecha Ingreso:";
            this.lbl_fecha_ingreso.Visible = false;
            // 
            // t_fecha_registro
            // 
            this.t_fecha_registro.Location = new System.Drawing.Point(359, 37);
            this.t_fecha_registro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_fecha_registro.Name = "t_fecha_registro";
            this.t_fecha_registro.ReadOnly = true;
            this.t_fecha_registro.Size = new System.Drawing.Size(119, 21);
            this.t_fecha_registro.TabIndex = 23;
            // 
            // t_num_guia
            // 
            this.t_num_guia.Location = new System.Drawing.Point(123, 83);
            this.t_num_guia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_num_guia.MaxLength = 10;
            this.t_num_guia.Name = "t_num_guia";
            this.t_num_guia.Size = new System.Drawing.Size(87, 21);
            this.t_num_guia.TabIndex = 2;
            this.t_num_guia.Leave += new System.EventHandler(this.t_num_guia_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Guía Despacho:";
            // 
            // btn_escanear
            // 
            this.btn_escanear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_escanear.Location = new System.Drawing.Point(123, 222);
            this.btn_escanear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_escanear.Name = "btn_escanear";
            this.btn_escanear.Size = new System.Drawing.Size(130, 67);
            this.btn_escanear.TabIndex = 21;
            this.btn_escanear.Text = "Escanear Documento";
            this.btn_escanear.UseVisualStyleBackColor = false;
            this.btn_escanear.Click += new System.EventHandler(this.btn_escanear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Transportista:";
            // 
            // cbb_Transportista
            // 
            this.cbb_Transportista.FormattingEnabled = true;
            this.cbb_Transportista.Location = new System.Drawing.Point(123, 175);
            this.cbb_Transportista.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Transportista.Name = "cbb_Transportista";
            this.cbb_Transportista.Size = new System.Drawing.Size(355, 21);
            this.cbb_Transportista.TabIndex = 6;
            this.cbb_Transportista.SelectedIndexChanged += new System.EventHandler(this.cbb_Transportista_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 237);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 27);
            this.button2.TabIndex = 26;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(100, 36);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar1.TabIndex = 9;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 63);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Nombre:";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(123, 60);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(355, 21);
            this.t_cardname.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 40);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Productor:";
            // 
            // t_conductor
            // 
            this.t_conductor.Location = new System.Drawing.Point(123, 152);
            this.t_conductor.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_conductor.MaxLength = 80;
            this.t_conductor.Name = "t_conductor";
            this.t_conductor.Size = new System.Drawing.Size(355, 21);
            this.t_conductor.TabIndex = 5;
            this.t_conductor.Leave += new System.EventHandler(this.t_conductor_Leave);
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(123, 37);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 15;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.Size = new System.Drawing.Size(130, 21);
            this.t_cardcode.TabIndex = 1;
            this.t_cardcode.Leave += new System.EventHandler(this.t_cardcode_Leave);
            // 
            // t_patente
            // 
            this.t_patente.Location = new System.Drawing.Point(123, 106);
            this.t_patente.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_patente.MaxLength = 7;
            this.t_patente.Name = "t_patente";
            this.t_patente.Size = new System.Drawing.Size(87, 21);
            this.t_patente.TabIndex = 3;
            this.t_patente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_patente_KeyPress);
            this.t_patente.Leave += new System.EventHandler(this.t_patente_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patente Camión:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Conductor:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(141, 225);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(176, 237);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(53, 33);
            this.dataGridView1.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 225);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // t_cargo
            // 
            this.t_cargo.Location = new System.Drawing.Point(436, 244);
            this.t_cargo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cargo.Name = "t_cargo";
            this.t_cargo.ReadOnly = true;
            this.t_cargo.Size = new System.Drawing.Size(27, 21);
            this.t_cargo.TabIndex = 33;
            this.t_cargo.Visible = false;
            // 
            // t_id_romana
            // 
            this.t_id_romana.Location = new System.Drawing.Point(405, 244);
            this.t_id_romana.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_id_romana.Name = "t_id_romana";
            this.t_id_romana.ReadOnly = true;
            this.t_id_romana.Size = new System.Drawing.Size(27, 21);
            this.t_id_romana.TabIndex = 30;
            this.t_id_romana.Visible = false;
            // 
            // t_imagen
            // 
            this.t_imagen.Location = new System.Drawing.Point(374, 244);
            this.t_imagen.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_imagen.Name = "t_imagen";
            this.t_imagen.ReadOnly = true;
            this.t_imagen.Size = new System.Drawing.Size(27, 21);
            this.t_imagen.TabIndex = 28;
            this.t_imagen.Visible = false;
            // 
            // t_id_acceso
            // 
            this.t_id_acceso.Location = new System.Drawing.Point(343, 244);
            this.t_id_acceso.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_id_acceso.Name = "t_id_acceso";
            this.t_id_acceso.ReadOnly = true;
            this.t_id_acceso.Size = new System.Drawing.Size(27, 21);
            this.t_id_acceso.TabIndex = 24;
            this.t_id_acceso.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(445, 250);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(21, 13);
            this.linkLabel1.TabIndex = 33;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "._.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // t_1er_grabado
            // 
            this.t_1er_grabado.Location = new System.Drawing.Point(312, 244);
            this.t_1er_grabado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_1er_grabado.Name = "t_1er_grabado";
            this.t_1er_grabado.ReadOnly = true;
            this.t_1er_grabado.Size = new System.Drawing.Size(27, 21);
            this.t_1er_grabado.TabIndex = 34;
            this.t_1er_grabado.Visible = false;
            // 
            // frmPorteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 362);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.t_cargo);
            this.Controls.Add(this.t_1er_grabado);
            this.Controls.Add(this.t_id_acceso);
            this.Controls.Add(this.t_imagen);
            this.Controls.Add(this.t_id_romana);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPorteria";
            this.Text = "Controlar Acceso de Camiones";
            this.Load += new System.EventHandler(this.frmPorteria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox t_id_romana;
        private System.Windows.Forms.Label lbl_fecha_ingreso;
        private System.Windows.Forms.TextBox t_fecha_registro;
        private System.Windows.Forms.TextBox t_imagen;
        private System.Windows.Forms.TextBox t_id_acceso;
        private System.Windows.Forms.Button btn_escanear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_Transportista;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox t_cardname;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_conductor;
        private System.Windows.Forms.TextBox t_cardcode;
        private System.Windows.Forms.TextBox t_patente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_num_guia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_razoningreso;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox t_cargo;
        private System.Windows.Forms.TextBox t_1er_grabado;
        private System.Windows.Forms.TextBox t_sellos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_patente_carro;
        private System.Windows.Forms.Label label4;
    }
}