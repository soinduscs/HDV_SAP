namespace FrmProcesos
{
    partial class frmReceta
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
            this.t_referencia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.t_tamano_producto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.t_proyecto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.t_norma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t_lprecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.t_cant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.t_costo = new System.Windows.Forms.TextBox();
            this.t_tipolmat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.t_docentry = new System.Windows.Forms.TextBox();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_Borrar = new System.Windows.Forms.Button();
            this.cbb_almacen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_agrega_productor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_eliminar = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_referencia
            // 
            this.t_referencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_referencia.Location = new System.Drawing.Point(117, 52);
            this.t_referencia.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_referencia.MaxLength = 100;
            this.t_referencia.Name = "t_referencia";
            this.t_referencia.Size = new System.Drawing.Size(394, 21);
            this.t_referencia.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Referencia";
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(13, 551);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(97, 30);
            this.btn_finalizar.TabIndex = 81;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // t_tamano_producto
            // 
            this.t_tamano_producto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_tamano_producto.Location = new System.Drawing.Point(117, 121);
            this.t_tamano_producto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_tamano_producto.MaxLength = 10;
            this.t_tamano_producto.Name = "t_tamano_producto";
            this.t_tamano_producto.ReadOnly = true;
            this.t_tamano_producto.Size = new System.Drawing.Size(105, 21);
            this.t_tamano_producto.TabIndex = 80;
            this.t_tamano_producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 124);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Tamaño producción";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "Descripción";
            // 
            // t_proyecto
            // 
            this.t_proyecto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_proyecto.Location = new System.Drawing.Point(962, 75);
            this.t_proyecto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_proyecto.MaxLength = 10;
            this.t_proyecto.Name = "t_proyecto";
            this.t_proyecto.ReadOnly = true;
            this.t_proyecto.Size = new System.Drawing.Size(105, 21);
            this.t_proyecto.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(870, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Proyecto";
            // 
            // t_norma
            // 
            this.t_norma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_norma.Location = new System.Drawing.Point(962, 52);
            this.t_norma.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_norma.MaxLength = 10;
            this.t_norma.Name = "t_norma";
            this.t_norma.ReadOnly = true;
            this.t_norma.Size = new System.Drawing.Size(105, 21);
            this.t_norma.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(870, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Norma reparto";
            // 
            // t_lprecio
            // 
            this.t_lprecio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_lprecio.Location = new System.Drawing.Point(962, 29);
            this.t_lprecio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_lprecio.MaxLength = 10;
            this.t_lprecio.Name = "t_lprecio";
            this.t_lprecio.ReadOnly = true;
            this.t_lprecio.Size = new System.Drawing.Size(105, 21);
            this.t_lprecio.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Lista de precios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(870, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Almacen:";
            // 
            // t_cant
            // 
            this.t_cant.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cant.Location = new System.Drawing.Point(694, 6);
            this.t_cant.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cant.MaxLength = 10;
            this.t_cant.Name = "t_cant";
            this.t_cant.Size = new System.Drawing.Size(62, 21);
            this.t_cant.TabIndex = 69;
            this.t_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_cant.Leave += new System.EventHandler(this.t_cant_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "X Cantidad";
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
            this.Column7,
            this.Column3,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column6});
            this.Grid1.Location = new System.Drawing.Point(3, 59);
            this.Grid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 5;
            this.Grid1.Size = new System.Drawing.Size(1046, 331);
            this.Grid1.TabIndex = 60;
            this.Grid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellEndEdit);
            // 
            // t_costo
            // 
            this.t_costo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_costo.Location = new System.Drawing.Point(117, 98);
            this.t_costo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_costo.MaxLength = 10;
            this.t_costo.Name = "t_costo";
            this.t_costo.ReadOnly = true;
            this.t_costo.Size = new System.Drawing.Size(105, 21);
            this.t_costo.TabIndex = 67;
            this.t_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_tipolmat
            // 
            this.t_tipolmat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_tipolmat.Location = new System.Drawing.Point(117, 75);
            this.t_tipolmat.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_tipolmat.MaxLength = 10;
            this.t_tipolmat.Name = "t_tipolmat";
            this.t_tipolmat.ReadOnly = true;
            this.t_tipolmat.Size = new System.Drawing.Size(105, 21);
            this.t_tipolmat.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Costo estandar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Tipo LMat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "N° Producto";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_itemcode.Location = new System.Drawing.Point(117, 6);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.MaxLength = 10;
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(394, 21);
            this.t_itemcode.TabIndex = 63;
            // 
            // t_itemname
            // 
            this.t_itemname.Location = new System.Drawing.Point(117, 29);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(394, 21);
            this.t_itemname.TabIndex = 62;
            // 
            // t_docentry
            // 
            this.t_docentry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_docentry.Location = new System.Drawing.Point(515, 6);
            this.t_docentry.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_docentry.MaxLength = 10;
            this.t_docentry.Name = "t_docentry";
            this.t_docentry.ReadOnly = true;
            this.t_docentry.Size = new System.Drawing.Size(62, 21);
            this.t_docentry.TabIndex = 84;
            this.t_docentry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.t_docentry.Visible = false;
            // 
            // btn_grabar
            // 
            this.btn_grabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_grabar.Location = new System.Drawing.Point(112, 551);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(97, 30);
            this.btn_grabar.TabIndex = 85;
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.UseVisualStyleBackColor = false;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_Borrar
            // 
            this.btn_Borrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Borrar.Location = new System.Drawing.Point(915, 551);
            this.btn_Borrar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_Borrar.Name = "btn_Borrar";
            this.btn_Borrar.Size = new System.Drawing.Size(152, 30);
            this.btn_Borrar.TabIndex = 86;
            this.btn_Borrar.Text = "Eliminar Lista de Materiales";
            this.btn_Borrar.UseVisualStyleBackColor = false;
            this.btn_Borrar.Click += new System.EventHandler(this.btn_Borrar_Click);
            // 
            // cbb_almacen
            // 
            this.cbb_almacen.FormattingEnabled = true;
            this.cbb_almacen.Location = new System.Drawing.Point(962, 6);
            this.cbb_almacen.Name = "cbb_almacen";
            this.cbb_almacen.Size = new System.Drawing.Size(105, 21);
            this.cbb_almacen.TabIndex = 87;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.Grid1);
            this.groupBox1.Location = new System.Drawing.Point(13, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 397);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_agrega_productor,
            this.toolStripSeparator1,
            this.tsb_eliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 38);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_agrega_productor
            // 
            this.tsb_agrega_productor.Image = global::FrmProcesos.Properties.Resources._16__Folder_download_;
            this.tsb_agrega_productor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_agrega_productor.Name = "tsb_agrega_productor";
            this.tsb_agrega_productor.Size = new System.Drawing.Size(98, 35);
            this.tsb_agrega_productor.Text = "Agregar Artículo";
            this.tsb_agrega_productor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_agrega_productor.Click += new System.EventHandler(this.tsb_agrega_productor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsb_eliminar
            // 
            this.tsb_eliminar.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.tsb_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_eliminar.Name = "tsb_eliminar";
            this.tsb_eliminar.Size = new System.Drawing.Size(81, 35);
            this.tsb_eliminar.Text = "Elimina Línea";
            this.tsb_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_eliminar.Click += new System.EventHandler(this.tsb_eliminar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(886, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 30);
            this.button1.TabIndex = 89;
            this.button1.Text = "Crea Orden de Fabricación";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tipo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "N°";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 260;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Descripción";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 320;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Cantidad";
            this.Column3.Name = "Column3";
            this.Column3.Width = 85;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "UM";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Almacén";
            this.Column10.Name = "Column10";
            this.Column10.Width = 110;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Metodo emisión";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 90;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Lista Precio";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 90;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Comentarios";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // frmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1086, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbb_almacen);
            this.Controls.Add(this.btn_Borrar);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.t_docentry);
            this.Controls.Add(this.t_referencia);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.t_tamano_producto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t_proyecto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t_norma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_lprecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_cant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_costo);
            this.Controls.Add(this.t_tipolmat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_itemcode);
            this.Controls.Add(this.t_itemname);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReceta";
            this.Text = "Lista de Materiales ";
            this.Load += new System.EventHandler(this.frmReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox t_referencia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_tamano_producto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_proyecto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_norma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_lprecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_cant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.TextBox t_costo;
        private System.Windows.Forms.TextBox t_tipolmat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.TextBox t_docentry;
        private System.Windows.Forms.Button btn_grabar;
        private System.Windows.Forms.Button btn_Borrar;
        private System.Windows.Forms.ComboBox cbb_almacen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_agrega_productor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_eliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}