namespace FrmProcesos
{
    partial class frmRecepcionMP9
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionMP9));
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.t_balanza = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_PesoBalanza1 = new System.Windows.Forms.TextBox();
            this.btn_quitar_b1 = new System.Windows.Forms.Button();
            this.btn_pesaje_entrada = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Grid_Peso = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.t_cant_envases1 = new System.Windows.Forms.TextBox();
            this.t_peso_total1 = new System.Windows.Forms.TextBox();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.t_lineid = new System.Windows.Forms.TextBox();
            this.t_id_romana = new System.Windows.Forms.TextBox();
            this.btn_quitar_b2 = new System.Windows.Forms.Button();
            this.t_peso_total2 = new System.Windows.Forms.TextBox();
            this.t_cant_envases2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_pesaje_entrada2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.t_balanza2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t_PesoBalanza2 = new System.Windows.Forms.TextBox();
            this.Grid2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Peso)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column7,
            this.Column3});
            this.Grid1.Location = new System.Drawing.Point(12, 142);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(615, 242);
            this.Grid1.TabIndex = 172;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Fecha / Hora";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "Peso Bruto";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 55;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Tipo Envase";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 200;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Peso Envase";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 55;
            // 
            // Column7
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "Cantidad Envases";
            this.Column7.Name = "Column7";
            this.Column7.Width = 55;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Peso Neto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.t_balanza);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.t_PesoBalanza1);
            this.panel1.Controls.Add(this.btn_quitar_b1);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 85);
            this.panel1.TabIndex = 173;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 58);
            this.label2.TabIndex = 174;
            this.label2.Text = "Balanza 1";
            // 
            // t_balanza
            // 
            this.t_balanza.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_balanza.Location = new System.Drawing.Point(519, 60);
            this.t_balanza.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_balanza.Multiline = true;
            this.t_balanza.Name = "t_balanza";
            this.t_balanza.ReadOnly = true;
            this.t_balanza.Size = new System.Drawing.Size(15, 12);
            this.t_balanza.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Peso Kgs.:";
            // 
            // t_PesoBalanza1
            // 
            this.t_PesoBalanza1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_PesoBalanza1.ForeColor = System.Drawing.Color.Green;
            this.t_PesoBalanza1.Location = new System.Drawing.Point(376, 7);
            this.t_PesoBalanza1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_PesoBalanza1.Name = "t_PesoBalanza1";
            this.t_PesoBalanza1.ReadOnly = true;
            this.t_PesoBalanza1.Size = new System.Drawing.Size(139, 65);
            this.t_PesoBalanza1.TabIndex = 0;
            this.t_PesoBalanza1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_quitar_b1
            // 
            this.btn_quitar_b1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_quitar_b1.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.btn_quitar_b1.Location = new System.Drawing.Point(557, 57);
            this.btn_quitar_b1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_quitar_b1.Name = "btn_quitar_b1";
            this.btn_quitar_b1.Size = new System.Drawing.Size(54, 22);
            this.btn_quitar_b1.TabIndex = 295;
            this.btn_quitar_b1.UseVisualStyleBackColor = false;
            this.btn_quitar_b1.Click += new System.EventHandler(this.btn_quitar_b1_Click);
            // 
            // btn_pesaje_entrada
            // 
            this.btn_pesaje_entrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_pesaje_entrada.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesaje_entrada.Location = new System.Drawing.Point(12, 100);
            this.btn_pesaje_entrada.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_pesaje_entrada.Name = "btn_pesaje_entrada";
            this.btn_pesaje_entrada.Size = new System.Drawing.Size(615, 39);
            this.btn_pesaje_entrada.TabIndex = 174;
            this.btn_pesaje_entrada.Text = "CAPTURAR PESO";
            this.btn_pesaje_entrada.UseVisualStyleBackColor = false;
            this.btn_pesaje_entrada.Click += new System.EventHandler(this.btn_pesaje_entrada_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Grid_Peso
            // 
            this.Grid_Peso.AllowUserToAddRows = false;
            this.Grid_Peso.AllowUserToDeleteRows = false;
            this.Grid_Peso.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Peso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Peso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn2,
            this.Column10});
            this.Grid_Peso.Location = new System.Drawing.Point(1287, 128);
            this.Grid_Peso.Name = "Grid_Peso";
            this.Grid_Peso.RowHeadersWidth = 20;
            this.Grid_Peso.Size = new System.Drawing.Size(240, 238);
            this.Grid_Peso.TabIndex = 290;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Peso";
            this.Column10.Name = "Column10";
            this.Column10.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 392);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 291;
            this.label3.Text = "Total:";
            // 
            // t_cant_envases1
            // 
            this.t_cant_envases1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cant_envases1.Location = new System.Drawing.Point(466, 390);
            this.t_cant_envases1.Name = "t_cant_envases1";
            this.t_cant_envases1.ReadOnly = true;
            this.t_cant_envases1.Size = new System.Drawing.Size(62, 23);
            this.t_cant_envases1.TabIndex = 292;
            this.t_cant_envases1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_peso_total1
            // 
            this.t_peso_total1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_peso_total1.Location = new System.Drawing.Point(532, 390);
            this.t_peso_total1.Name = "t_peso_total1";
            this.t_peso_total1.ReadOnly = true;
            this.t_peso_total1.Size = new System.Drawing.Size(95, 23);
            this.t_peso_total1.TabIndex = 293;
            this.t_peso_total1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(12, 422);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 296;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(359, 422);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(615, 39);
            this.button1.TabIndex = 297;
            this.button1.Text = "TERMINAR CAPTURA DE PESO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // t_lineid
            // 
            this.t_lineid.Location = new System.Drawing.Point(115, 391);
            this.t_lineid.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lineid.Name = "t_lineid";
            this.t_lineid.ReadOnly = true;
            this.t_lineid.Size = new System.Drawing.Size(30, 21);
            this.t_lineid.TabIndex = 299;
            this.t_lineid.Visible = false;
            // 
            // t_id_romana
            // 
            this.t_id_romana.Location = new System.Drawing.Point(81, 391);
            this.t_id_romana.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_id_romana.Name = "t_id_romana";
            this.t_id_romana.ReadOnly = true;
            this.t_id_romana.Size = new System.Drawing.Size(30, 21);
            this.t_id_romana.TabIndex = 298;
            this.t_id_romana.Visible = false;
            // 
            // btn_quitar_b2
            // 
            this.btn_quitar_b2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_quitar_b2.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.btn_quitar_b2.Location = new System.Drawing.Point(557, 57);
            this.btn_quitar_b2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_quitar_b2.Name = "btn_quitar_b2";
            this.btn_quitar_b2.Size = new System.Drawing.Size(54, 22);
            this.btn_quitar_b2.TabIndex = 306;
            this.btn_quitar_b2.UseVisualStyleBackColor = false;
            this.btn_quitar_b2.Click += new System.EventHandler(this.btn_quitar_b2_Click);
            // 
            // t_peso_total2
            // 
            this.t_peso_total2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_peso_total2.Location = new System.Drawing.Point(1160, 390);
            this.t_peso_total2.Name = "t_peso_total2";
            this.t_peso_total2.ReadOnly = true;
            this.t_peso_total2.Size = new System.Drawing.Size(95, 23);
            this.t_peso_total2.TabIndex = 305;
            this.t_peso_total2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_cant_envases2
            // 
            this.t_cant_envases2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cant_envases2.Location = new System.Drawing.Point(1094, 390);
            this.t_cant_envases2.Name = "t_cant_envases2";
            this.t_cant_envases2.ReadOnly = true;
            this.t_cant_envases2.Size = new System.Drawing.Size(62, 23);
            this.t_cant_envases2.TabIndex = 304;
            this.t_cant_envases2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1043, 392);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 303;
            this.label4.Text = "Total:";
            // 
            // btn_pesaje_entrada2
            // 
            this.btn_pesaje_entrada2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_pesaje_entrada2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesaje_entrada2.Location = new System.Drawing.Point(640, 100);
            this.btn_pesaje_entrada2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_pesaje_entrada2.Name = "btn_pesaje_entrada2";
            this.btn_pesaje_entrada2.Size = new System.Drawing.Size(615, 39);
            this.btn_pesaje_entrada2.TabIndex = 302;
            this.btn_pesaje_entrada2.Text = "CAPTURAR PESO";
            this.btn_pesaje_entrada2.UseVisualStyleBackColor = false;
            this.btn_pesaje_entrada2.Click += new System.EventHandler(this.btn_pesaje_entrada2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.t_balanza2);
            this.panel2.Controls.Add(this.btn_quitar_b2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.t_PesoBalanza2);
            this.panel2.Location = new System.Drawing.Point(640, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 85);
            this.panel2.TabIndex = 301;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 58);
            this.label5.TabIndex = 174;
            this.label5.Text = "Balanza 2";
            // 
            // t_balanza2
            // 
            this.t_balanza2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_balanza2.Location = new System.Drawing.Point(519, 60);
            this.t_balanza2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_balanza2.Multiline = true;
            this.t_balanza2.Name = "t_balanza2";
            this.t_balanza2.ReadOnly = true;
            this.t_balanza2.Size = new System.Drawing.Size(15, 12);
            this.t_balanza2.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Peso Kgs.:";
            // 
            // t_PesoBalanza2
            // 
            this.t_PesoBalanza2.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_PesoBalanza2.ForeColor = System.Drawing.Color.Green;
            this.t_PesoBalanza2.Location = new System.Drawing.Point(376, 7);
            this.t_PesoBalanza2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_PesoBalanza2.Name = "t_PesoBalanza2";
            this.t_PesoBalanza2.ReadOnly = true;
            this.t_PesoBalanza2.Size = new System.Drawing.Size(139, 65);
            this.t_PesoBalanza2.TabIndex = 0;
            this.t_PesoBalanza2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Grid2
            // 
            this.Grid2.AllowUserToAddRows = false;
            this.Grid2.AllowUserToDeleteRows = false;
            this.Grid2.BackgroundColor = System.Drawing.Color.White;
            this.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.Grid2.Location = new System.Drawing.Point(640, 142);
            this.Grid2.Name = "Grid2";
            this.Grid2.RowHeadersWidth = 20;
            this.Grid2.Size = new System.Drawing.Size(615, 242);
            this.Grid2.TabIndex = 300;
            this.Grid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid2_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha / Hora";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Peso Bruto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo Envase";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "Peso Envase";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 55;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.HeaderText = "Cantidad Envases";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 55;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn8.HeaderText = "Peso Neto";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // frmRecepcionMP9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 471);
            this.Controls.Add(this.t_peso_total2);
            this.Controls.Add(this.t_cant_envases2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_pesaje_entrada2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Grid2);
            this.Controls.Add(this.t_lineid);
            this.Controls.Add(this.t_id_romana);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.t_peso_total1);
            this.Controls.Add(this.t_cant_envases1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Grid_Peso);
            this.Controls.Add(this.btn_pesaje_entrada);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionMP9";
            this.Text = "Recepción de Materia Prima - Peso Automático";
            this.Load += new System.EventHandler(this.frmRecepcionMP9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Peso)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_balanza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_PesoBalanza1;
        private System.Windows.Forms.Button btn_pesaje_entrada;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView Grid_Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_cant_envases1;
        private System.Windows.Forms.TextBox t_peso_total1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_quitar_b1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox t_lineid;
        private System.Windows.Forms.TextBox t_id_romana;
        private System.Windows.Forms.Button btn_quitar_b2;
        private System.Windows.Forms.TextBox t_peso_total2;
        private System.Windows.Forms.TextBox t_cant_envases2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_pesaje_entrada2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_balanza2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_PesoBalanza2;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}