
namespace FrmProcesos
{
    partial class frmRecepcionMPC6
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
            this.cbb_seleccionar_impresora = new System.Windows.Forms.ComboBox();
            this.t_cantidad_total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_agrega_oc = new System.Windows.Forms.ToolStripButton();
            this.tsb_agrega_productor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_eliminar = new System.Windows.Forms.ToolStripButton();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.t_mensaje = new System.Windows.Forms.TextBox();
            this.t_RomanaEntry = new System.Windows.Forms.TextBox();
            this.t_CantBins = new System.Windows.Forms.TextBox();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.cbb_almacen = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.t_num_guia = new System.Windows.Forms.TextBox();
            this.t_lineid = new System.Windows.Forms.TextBox();
            this.t_line_ref = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
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
            this.btn_recibir = new System.Windows.Forms.Button();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.t_num_ov = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_seleccionar_impresora
            // 
            this.cbb_seleccionar_impresora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_seleccionar_impresora.FormattingEnabled = true;
            this.cbb_seleccionar_impresora.Location = new System.Drawing.Point(25, 424);
            this.cbb_seleccionar_impresora.Name = "cbb_seleccionar_impresora";
            this.cbb_seleccionar_impresora.Size = new System.Drawing.Size(255, 27);
            this.cbb_seleccionar_impresora.TabIndex = 261;
            this.cbb_seleccionar_impresora.Visible = false;
            // 
            // t_cantidad_total
            // 
            this.t_cantidad_total.Location = new System.Drawing.Point(425, 424);
            this.t_cantidad_total.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cantidad_total.MaxLength = 80;
            this.t_cantidad_total.Name = "t_cantidad_total";
            this.t_cantidad_total.ReadOnly = true;
            this.t_cantidad_total.Size = new System.Drawing.Size(71, 23);
            this.t_cantidad_total.TabIndex = 258;
            this.t_cantidad_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 427);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 17);
            this.label10.TabIndex = 259;
            this.label10.Text = "Total Unidades Recibidas:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.Grid1);
            this.groupBox1.Location = new System.Drawing.Point(25, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 175);
            this.groupBox1.TabIndex = 260;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Recepciones";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_agrega_oc,
            this.tsb_agrega_productor,
            this.toolStripSeparator1,
            this.tsb_eliminar});
            this.toolStrip1.Location = new System.Drawing.Point(361, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(107, 153);
            this.toolStrip1.TabIndex = 191;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_agrega_oc
            // 
            this.tsb_agrega_oc.Image = global::FrmProcesos.Properties.Resources._16__Build_;
            this.tsb_agrega_oc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_agrega_oc.Name = "tsb_agrega_oc";
            this.tsb_agrega_oc.Size = new System.Drawing.Size(104, 44);
            this.tsb_agrega_oc.Text = "Agregar Bulto";
            this.tsb_agrega_oc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_agrega_oc.ToolTipText = "Agregar Orden de Compra ";
            this.tsb_agrega_oc.Click += new System.EventHandler(this.tsb_agrega_oc_Click);
            // 
            // tsb_agrega_productor
            // 
            this.tsb_agrega_productor.Enabled = false;
            this.tsb_agrega_productor.Image = global::FrmProcesos.Properties.Resources._16__Barcode_;
            this.tsb_agrega_productor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_agrega_productor.Name = "tsb_agrega_productor";
            this.tsb_agrega_productor.Size = new System.Drawing.Size(104, 44);
            this.tsb_agrega_productor.Text = "Imprimir";
            this.tsb_agrega_productor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // tsb_eliminar
            // 
            this.tsb_eliminar.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.tsb_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_eliminar.Name = "tsb_eliminar";
            this.tsb_eliminar.Size = new System.Drawing.Size(106, 44);
            this.tsb_eliminar.Text = "Eliminar Bulto";
            this.tsb_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_eliminar.Click += new System.EventHandler(this.tsb_eliminar_Click);
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
            this.Grid1.Location = new System.Drawing.Point(10, 20);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 20;
            this.Grid1.Size = new System.Drawing.Size(370, 144);
            this.Grid1.TabIndex = 190;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // t_mensaje
            // 
            this.t_mensaje.BackColor = System.Drawing.Color.DodgerBlue;
            this.t_mensaje.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_mensaje.Location = new System.Drawing.Point(25, 392);
            this.t_mensaje.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_mensaje.MaxLength = 20;
            this.t_mensaje.Name = "t_mensaje";
            this.t_mensaje.ReadOnly = true;
            this.t_mensaje.Size = new System.Drawing.Size(471, 21);
            this.t_mensaje.TabIndex = 257;
            this.t_mensaje.Visible = false;
            // 
            // t_RomanaEntry
            // 
            this.t_RomanaEntry.Location = new System.Drawing.Point(373, 339);
            this.t_RomanaEntry.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_RomanaEntry.Name = "t_RomanaEntry";
            this.t_RomanaEntry.Size = new System.Drawing.Size(48, 23);
            this.t_RomanaEntry.TabIndex = 256;
            this.t_RomanaEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_RomanaEntry.Visible = false;
            // 
            // t_CantBins
            // 
            this.t_CantBins.Location = new System.Drawing.Point(321, 339);
            this.t_CantBins.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_CantBins.Name = "t_CantBins";
            this.t_CantBins.Size = new System.Drawing.Size(48, 23);
            this.t_CantBins.TabIndex = 255;
            this.t_CantBins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_CantBins.Visible = false;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(25, 462);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 254;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // cbb_almacen
            // 
            this.cbb_almacen.FormattingEnabled = true;
            this.cbb_almacen.Location = new System.Drawing.Point(133, 192);
            this.cbb_almacen.Name = "cbb_almacen";
            this.cbb_almacen.Size = new System.Drawing.Size(151, 24);
            this.cbb_almacen.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 195);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 250;
            this.label13.Text = "Almacen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 218);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 232;
            this.label7.Text = "Guía Despacho:";
            // 
            // t_num_guia
            // 
            this.t_num_guia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_num_guia.Location = new System.Drawing.Point(133, 215);
            this.t_num_guia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_num_guia.MaxLength = 10;
            this.t_num_guia.Name = "t_num_guia";
            this.t_num_guia.Size = new System.Drawing.Size(126, 24);
            this.t_num_guia.TabIndex = 11;
            // 
            // t_lineid
            // 
            this.t_lineid.Location = new System.Drawing.Point(348, 15);
            this.t_lineid.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lineid.Name = "t_lineid";
            this.t_lineid.ReadOnly = true;
            this.t_lineid.Size = new System.Drawing.Size(30, 23);
            this.t_lineid.TabIndex = 249;
            this.t_lineid.Visible = false;
            // 
            // t_line_ref
            // 
            this.t_line_ref.Location = new System.Drawing.Point(466, 187);
            this.t_line_ref.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_line_ref.Name = "t_line_ref";
            this.t_line_ref.ReadOnly = true;
            this.t_line_ref.Size = new System.Drawing.Size(30, 23);
            this.t_line_ref.TabIndex = 248;
            this.t_line_ref.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(425, 339);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBox6.MaxLength = 20;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(46, 23);
            this.textBox6.TabIndex = 247;
            this.textBox6.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 167);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 246;
            this.label8.Text = "Descripción";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Location = new System.Drawing.Point(133, 141);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 20;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(363, 23);
            this.t_itemcode.TabIndex = 245;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 243;
            this.label9.Text = "Codigo Articulo";
            // 
            // t_itemname
            // 
            this.t_itemname.Location = new System.Drawing.Point(133, 164);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(363, 23);
            this.t_itemname.TabIndex = 244;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 242;
            this.label4.Text = "Nombre";
            // 
            // t_cardcode_clte
            // 
            this.t_cardcode_clte.Location = new System.Drawing.Point(133, 84);
            this.t_cardcode_clte.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode_clte.MaxLength = 20;
            this.t_cardcode_clte.Name = "t_cardcode_clte";
            this.t_cardcode_clte.ReadOnly = true;
            this.t_cardcode_clte.Size = new System.Drawing.Size(151, 23);
            this.t_cardcode_clte.TabIndex = 241;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 239;
            this.label5.Text = "Cliente";
            // 
            // t_cardname_clte
            // 
            this.t_cardname_clte.Location = new System.Drawing.Point(133, 107);
            this.t_cardname_clte.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname_clte.Name = "t_cardname_clte";
            this.t_cardname_clte.ReadOnly = true;
            this.t_cardname_clte.Size = new System.Drawing.Size(363, 23);
            this.t_cardname_clte.TabIndex = 240;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 238;
            this.label3.Text = "Pedido";
            // 
            // t_numoc
            // 
            this.t_numoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_numoc.Location = new System.Drawing.Point(133, 61);
            this.t_numoc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_numoc.MaxLength = 10;
            this.t_numoc.Name = "t_numoc";
            this.t_numoc.ReadOnly = true;
            this.t_numoc.Size = new System.Drawing.Size(151, 24);
            this.t_numoc.TabIndex = 237;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 236;
            this.label1.Text = "Nombre";
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(133, 15);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 20;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.ReadOnly = true;
            this.t_cardcode.Size = new System.Drawing.Size(151, 23);
            this.t_cardcode.TabIndex = 235;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 18);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 17);
            this.label18.TabIndex = 233;
            this.label18.Text = "Cliente";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(133, 38);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(363, 23);
            this.t_cardname.TabIndex = 234;
            // 
            // btn_recibir
            // 
            this.btn_recibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_recibir.Image = global::FrmProcesos.Properties.Resources.accept;
            this.btn_recibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_recibir.Location = new System.Drawing.Point(313, 454);
            this.btn_recibir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_recibir.Name = "btn_recibir";
            this.btn_recibir.Size = new System.Drawing.Size(183, 30);
            this.btn_recibir.TabIndex = 253;
            this.btn_recibir.Text = "  Genera Recepción";
            this.btn_recibir.UseVisualStyleBackColor = false;
            this.btn_recibir.Click += new System.EventHandler(this.btn_recibir_Click);
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(285, 61);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 21);
            this.btn_buscar1.TabIndex = 252;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 263;
            this.label2.Text = "Órden de Venta:";
            // 
            // t_num_ov
            // 
            this.t_num_ov.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_num_ov.Location = new System.Drawing.Point(375, 214);
            this.t_num_ov.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_num_ov.MaxLength = 10;
            this.t_num_ov.Name = "t_num_ov";
            this.t_num_ov.Size = new System.Drawing.Size(124, 24);
            this.t_num_ov.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 20;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Cantidad";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lote";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Lote Cliente";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 150;
            // 
            // frmRecepcionMPC6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 503);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_num_ov);
            this.Controls.Add(this.cbb_seleccionar_impresora);
            this.Controls.Add(this.t_cantidad_total);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.t_mensaje);
            this.Controls.Add(this.t_RomanaEntry);
            this.Controls.Add(this.t_CantBins);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_recibir);
            this.Controls.Add(this.btn_buscar1);
            this.Controls.Add(this.cbb_almacen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t_num_guia);
            this.Controls.Add(this.t_lineid);
            this.Controls.Add(this.t_line_ref);
            this.Controls.Add(this.textBox6);
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
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRecepcionMPC6";
            this.Text = "Recepción de Material Externo";
            this.Load += new System.EventHandler(this.frmRecepcionMPC6_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_seleccionar_impresora;
        private System.Windows.Forms.TextBox t_cantidad_total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_agrega_oc;
        private System.Windows.Forms.ToolStripButton tsb_agrega_productor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_eliminar;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox t_mensaje;
        private System.Windows.Forms.TextBox t_RomanaEntry;
        private System.Windows.Forms.TextBox t_CantBins;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_recibir;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.ComboBox cbb_almacen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_num_guia;
        private System.Windows.Forms.TextBox t_lineid;
        private System.Windows.Forms.TextBox t_line_ref;
        private System.Windows.Forms.TextBox textBox6;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_num_ov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}