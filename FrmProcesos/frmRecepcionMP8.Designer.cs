namespace FrmProcesos
{
    partial class frmRecepcionMP8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionMP8));
            this.t_RomanaEntry = new System.Windows.Forms.TextBox();
            this.t_CantBins = new System.Windows.Forms.TextBox();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.cbb_almacen = new System.Windows.Forms.ComboBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_lote = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.t_conductor = new System.Windows.Forms.TextBox();
            this.t_peso_guia = new System.Windows.Forms.TextBox();
            this.t_patente = new System.Windows.Forms.TextBox();
            this.t_peso_neto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.t_precio_unit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.t_num_guia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.t_lineid = new System.Windows.Forms.TextBox();
            this.t_id_romana = new System.Windows.Forms.TextBox();
            this.t_cant_bins = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_cardcode_clte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t_cardname_clte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_numoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_cardcode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_cardname = new System.Windows.Forms.TextBox();
            this.btn_peso = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_recibir = new System.Windows.Forms.Button();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.t_mensaje = new System.Windows.Forms.TextBox();
            this.t_codigo_CSG = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_RomanaEntry
            // 
            this.t_RomanaEntry.Location = new System.Drawing.Point(660, 503);
            this.t_RomanaEntry.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_RomanaEntry.Name = "t_RomanaEntry";
            this.t_RomanaEntry.Size = new System.Drawing.Size(48, 21);
            this.t_RomanaEntry.TabIndex = 178;
            this.t_RomanaEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_RomanaEntry.Visible = false;
            // 
            // t_CantBins
            // 
            this.t_CantBins.Location = new System.Drawing.Point(608, 503);
            this.t_CantBins.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_CantBins.Name = "t_CantBins";
            this.t_CantBins.Size = new System.Drawing.Size(48, 21);
            this.t_CantBins.TabIndex = 177;
            this.t_CantBins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_CantBins.Visible = false;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(23, 503);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 175;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // cbb_almacen
            // 
            this.cbb_almacen.FormattingEnabled = true;
            this.cbb_almacen.Location = new System.Drawing.Point(124, 258);
            this.cbb_almacen.Name = "cbb_almacen";
            this.cbb_almacen.Size = new System.Drawing.Size(151, 21);
            this.cbb_almacen.TabIndex = 172;
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.BackgroundColor = System.Drawing.Color.White;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column3});
            this.Grid1.Location = new System.Drawing.Point(23, 316);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(810, 180);
            this.Grid1.TabIndex = 171;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numero de artículo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción del artículo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 300;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Cantidad";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Almacen";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Almacen destino";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Stock";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // t_lote
            // 
            this.t_lote.Location = new System.Drawing.Point(124, 281);
            this.t_lote.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lote.MaxLength = 20;
            this.t_lote.Name = "t_lote";
            this.t_lote.ReadOnly = true;
            this.t_lote.Size = new System.Drawing.Size(151, 21);
            this.t_lote.TabIndex = 170;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 284);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 169;
            this.label14.Text = "Lote";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(501, 215);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 147;
            this.label20.Text = "Peso Guía";
            // 
            // t_conductor
            // 
            this.t_conductor.Location = new System.Drawing.Point(588, 281);
            this.t_conductor.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_conductor.MaxLength = 80;
            this.t_conductor.Name = "t_conductor";
            this.t_conductor.ReadOnly = true;
            this.t_conductor.Size = new System.Drawing.Size(245, 21);
            this.t_conductor.TabIndex = 141;
            // 
            // t_peso_guia
            // 
            this.t_peso_guia.Location = new System.Drawing.Point(588, 212);
            this.t_peso_guia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_peso_guia.MaxLength = 10;
            this.t_peso_guia.Name = "t_peso_guia";
            this.t_peso_guia.ReadOnly = true;
            this.t_peso_guia.Size = new System.Drawing.Size(126, 21);
            this.t_peso_guia.TabIndex = 138;
            this.t_peso_guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_patente
            // 
            this.t_patente.Location = new System.Drawing.Point(588, 258);
            this.t_patente.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_patente.MaxLength = 15;
            this.t_patente.Name = "t_patente";
            this.t_patente.ReadOnly = true;
            this.t_patente.Size = new System.Drawing.Size(126, 21);
            this.t_patente.TabIndex = 140;
            // 
            // t_peso_neto
            // 
            this.t_peso_neto.Location = new System.Drawing.Point(588, 189);
            this.t_peso_neto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_peso_neto.Name = "t_peso_neto";
            this.t_peso_neto.ReadOnly = true;
            this.t_peso_neto.Size = new System.Drawing.Size(93, 21);
            this.t_peso_neto.TabIndex = 145;
            this.t_peso_neto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 136;
            this.label2.Text = "Patente:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 261);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 168;
            this.label13.Text = "Almacen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 139;
            this.label6.Text = "Conductor:";
            // 
            // t_precio_unit
            // 
            this.t_precio_unit.Location = new System.Drawing.Point(124, 235);
            this.t_precio_unit.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_precio_unit.MaxLength = 20;
            this.t_precio_unit.Name = "t_precio_unit";
            this.t_precio_unit.ReadOnly = true;
            this.t_precio_unit.Size = new System.Drawing.Size(151, 21);
            this.t_precio_unit.TabIndex = 167;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 142;
            this.label7.Text = "Guía Despacho:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(501, 192);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 144;
            this.label19.Text = "Peso Romana";
            // 
            // t_num_guia
            // 
            this.t_num_guia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_num_guia.Location = new System.Drawing.Point(588, 143);
            this.t_num_guia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_num_guia.MaxLength = 10;
            this.t_num_guia.Name = "t_num_guia";
            this.t_num_guia.ReadOnly = true;
            this.t_num_guia.Size = new System.Drawing.Size(126, 21);
            this.t_num_guia.TabIndex = 137;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 238);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 166;
            this.label12.Text = "Precio unitario USD";
            // 
            // t_lineid
            // 
            this.t_lineid.Location = new System.Drawing.Point(339, 17);
            this.t_lineid.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lineid.Name = "t_lineid";
            this.t_lineid.ReadOnly = true;
            this.t_lineid.Size = new System.Drawing.Size(30, 21);
            this.t_lineid.TabIndex = 165;
            this.t_lineid.Visible = false;
            // 
            // t_id_romana
            // 
            this.t_id_romana.Location = new System.Drawing.Point(305, 17);
            this.t_id_romana.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_id_romana.Name = "t_id_romana";
            this.t_id_romana.ReadOnly = true;
            this.t_id_romana.Size = new System.Drawing.Size(30, 21);
            this.t_id_romana.TabIndex = 164;
            this.t_id_romana.Visible = false;
            // 
            // t_cant_bins
            // 
            this.t_cant_bins.Location = new System.Drawing.Point(124, 212);
            this.t_cant_bins.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cant_bins.MaxLength = 20;
            this.t_cant_bins.Name = "t_cant_bins";
            this.t_cant_bins.ReadOnly = true;
            this.t_cant_bins.Size = new System.Drawing.Size(151, 21);
            this.t_cant_bins.TabIndex = 163;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 215);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 162;
            this.label11.Text = "Cantidad Envases";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(124, 143);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBox6.MaxLength = 20;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(151, 21);
            this.textBox6.TabIndex = 161;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 160;
            this.label10.Text = "Lista de Precios";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 159;
            this.label8.Text = "Descripción";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Location = new System.Drawing.Point(124, 166);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 20;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(363, 21);
            this.t_itemcode.TabIndex = 158;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 156;
            this.label9.Text = "Codigo Articulo";
            // 
            // t_itemname
            // 
            this.t_itemname.Location = new System.Drawing.Point(124, 189);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(363, 21);
            this.t_itemname.TabIndex = 157;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 155;
            this.label4.Text = "Nombre";
            // 
            // t_cardcode_clte
            // 
            this.t_cardcode_clte.Location = new System.Drawing.Point(124, 86);
            this.t_cardcode_clte.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode_clte.MaxLength = 20;
            this.t_cardcode_clte.Name = "t_cardcode_clte";
            this.t_cardcode_clte.ReadOnly = true;
            this.t_cardcode_clte.Size = new System.Drawing.Size(151, 21);
            this.t_cardcode_clte.TabIndex = 154;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 152;
            this.label5.Text = "Cliente";
            // 
            // t_cardname_clte
            // 
            this.t_cardname_clte.Location = new System.Drawing.Point(124, 109);
            this.t_cardname_clte.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname_clte.Name = "t_cardname_clte";
            this.t_cardname_clte.ReadOnly = true;
            this.t_cardname_clte.Size = new System.Drawing.Size(363, 21);
            this.t_cardname_clte.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 151;
            this.label3.Text = "Pedido";
            // 
            // t_numoc
            // 
            this.t_numoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_numoc.Location = new System.Drawing.Point(124, 63);
            this.t_numoc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_numoc.MaxLength = 10;
            this.t_numoc.Name = "t_numoc";
            this.t_numoc.ReadOnly = true;
            this.t_numoc.Size = new System.Drawing.Size(151, 21);
            this.t_numoc.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 149;
            this.label1.Text = "Nombre";
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(124, 17);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 20;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.ReadOnly = true;
            this.t_cardcode.Size = new System.Drawing.Size(151, 21);
            this.t_cardcode.TabIndex = 148;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 143;
            this.label18.Text = "Proveedor";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(124, 40);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(363, 21);
            this.t_cardname.TabIndex = 146;
            // 
            // btn_peso
            // 
            this.btn_peso.BackColor = System.Drawing.SystemColors.Control;
            this.btn_peso.Image = global::FrmProcesos.Properties.Resources._16__Sum_;
            this.btn_peso.Location = new System.Drawing.Point(682, 189);
            this.btn_peso.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_peso.Name = "btn_peso";
            this.btn_peso.Size = new System.Drawing.Size(32, 21);
            this.btn_peso.TabIndex = 179;
            this.btn_peso.UseVisualStyleBackColor = false;
            this.btn_peso.Click += new System.EventHandler(this.btn_peso_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar.Location = new System.Drawing.Point(276, 17);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 21);
            this.btn_buscar.TabIndex = 176;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_recibir
            // 
            this.btn_recibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_recibir.Image = global::FrmProcesos.Properties.Resources.accept;
            this.btn_recibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_recibir.Location = new System.Drawing.Point(336, 503);
            this.btn_recibir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_recibir.Name = "btn_recibir";
            this.btn_recibir.Size = new System.Drawing.Size(183, 30);
            this.btn_recibir.TabIndex = 174;
            this.btn_recibir.Text = "  Genera Recepción";
            this.btn_recibir.UseVisualStyleBackColor = false;
            this.btn_recibir.Click += new System.EventHandler(this.btn_recibir_Click);
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(276, 63);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 21);
            this.btn_buscar1.TabIndex = 173;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // t_mensaje
            // 
            this.t_mensaje.BackColor = System.Drawing.Color.DodgerBlue;
            this.t_mensaje.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_mensaje.Location = new System.Drawing.Point(23, 533);
            this.t_mensaje.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_mensaje.MaxLength = 20;
            this.t_mensaje.Name = "t_mensaje";
            this.t_mensaje.ReadOnly = true;
            this.t_mensaje.Size = new System.Drawing.Size(252, 18);
            this.t_mensaje.TabIndex = 180;
            this.t_mensaje.Visible = false;
            // 
            // t_codigo_CSG
            // 
            this.t_codigo_CSG.Location = new System.Drawing.Point(588, 166);
            this.t_codigo_CSG.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_codigo_CSG.MaxLength = 20;
            this.t_codigo_CSG.Name = "t_codigo_CSG";
            this.t_codigo_CSG.Size = new System.Drawing.Size(126, 21);
            this.t_codigo_CSG.TabIndex = 187;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(501, 169);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 186;
            this.label15.Text = "Código CSG";
            // 
            // frmRecepcionMP8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 555);
            this.Controls.Add(this.t_codigo_CSG);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.t_mensaje);
            this.Controls.Add(this.btn_peso);
            this.Controls.Add(this.t_RomanaEntry);
            this.Controls.Add(this.t_CantBins);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_recibir);
            this.Controls.Add(this.btn_buscar1);
            this.Controls.Add(this.cbb_almacen);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.t_lote);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.t_conductor);
            this.Controls.Add(this.t_peso_guia);
            this.Controls.Add(this.t_patente);
            this.Controls.Add(this.t_peso_neto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_precio_unit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.t_num_guia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.t_lineid);
            this.Controls.Add(this.t_id_romana);
            this.Controls.Add(this.t_cant_bins);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_itemname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t_cardcode_clte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t_cardname_clte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_numoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_cardcode);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.t_cardname);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionMP8";
            this.Text = "Recepción de Materia Prima - Peso Automático";
            this.Load += new System.EventHandler(this.frmRecepcionMP8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_RomanaEntry;
        private System.Windows.Forms.TextBox t_CantBins;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_recibir;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.ComboBox cbb_almacen;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox t_lote;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox t_conductor;
        private System.Windows.Forms.TextBox t_peso_guia;
        private System.Windows.Forms.TextBox t_patente;
        private System.Windows.Forms.TextBox t_peso_neto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_precio_unit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox t_num_guia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox t_lineid;
        private System.Windows.Forms.TextBox t_id_romana;
        private System.Windows.Forms.TextBox t_cant_bins;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_cardcode_clte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_cardname_clte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_numoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_cardcode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_cardname;
        private System.Windows.Forms.Button btn_peso;
        private System.Windows.Forms.TextBox t_mensaje;
        private System.Windows.Forms.TextBox t_codigo_CSG;
        private System.Windows.Forms.Label label15;
    }
}