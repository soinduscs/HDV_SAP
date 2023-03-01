namespace FrmProcesos
{
    partial class frmProductores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.Grid_Entradas = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.t_encargado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_cardcode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_cardname = new System.Windows.Forms.TextBox();
            this.Grid_Contactos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_recibir = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_venc_grabar = new System.Windows.Forms.Button();
            this.btn_venc_quitar = new System.Windows.Forms.Button();
            this.btn_venc_agrega = new System.Windows.Forms.Button();
            this.Grid_DetLiquidacion = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Vencimientos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Liquidacion = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Entradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Contactos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_DetLiquidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Vencimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Liquidacion)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(12, 500);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 222;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // Grid_Entradas
            // 
            this.Grid_Entradas.AllowUserToAddRows = false;
            this.Grid_Entradas.AllowUserToDeleteRows = false;
            this.Grid_Entradas.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Entradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Entradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column8,
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column4});
            this.Grid_Entradas.Location = new System.Drawing.Point(7, 6);
            this.Grid_Entradas.Name = "Grid_Entradas";
            this.Grid_Entradas.RowHeadersWidth = 20;
            this.Grid_Entradas.Size = new System.Drawing.Size(798, 312);
            this.Grid_Entradas.TabIndex = 190;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Sel.";
            this.Column10.Name = "Column10";
            this.Column10.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Guía";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 60;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fecha Recepción";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Especie";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 220;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Variedad";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Num OC";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column5
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "Cantidad ";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.HeaderText = "Monto";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DocEntry";
            this.Column4.Name = "Column4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 66);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 216;
            this.label13.Text = "Encargado Compras";
            // 
            // t_encargado
            // 
            this.t_encargado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_encargado.Location = new System.Drawing.Point(127, 63);
            this.t_encargado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_encargado.MaxLength = 10;
            this.t_encargado.Name = "t_encargado";
            this.t_encargado.ReadOnly = true;
            this.t_encargado.Size = new System.Drawing.Size(361, 21);
            this.t_encargado.TabIndex = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "Nombre";
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(127, 17);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 20;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.ReadOnly = true;
            this.t_cardcode.Size = new System.Drawing.Size(119, 21);
            this.t_cardcode.TabIndex = 198;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 194;
            this.label18.Text = "Socio de Negocio";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(127, 40);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(601, 21);
            this.t_cardname.TabIndex = 196;
            // 
            // Grid_Contactos
            // 
            this.Grid_Contactos.AllowUserToAddRows = false;
            this.Grid_Contactos.AllowUserToDeleteRows = false;
            this.Grid_Contactos.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Contactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Contactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column7});
            this.Grid_Contactos.Location = new System.Drawing.Point(6, 6);
            this.Grid_Contactos.Name = "Grid_Contactos";
            this.Grid_Contactos.ReadOnly = true;
            this.Grid_Contactos.RowHeadersWidth = 20;
            this.Grid_Contactos.Size = new System.Drawing.Size(798, 110);
            this.Grid_Contactos.TabIndex = 191;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id. Contacto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Teléfono";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Correo electronico";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 402);
            this.tabControl1.TabIndex = 229;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_recibir);
            this.tabPage1.Controls.Add(this.Grid_Entradas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entradas Vigentes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_recibir
            // 
            this.btn_recibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_recibir.Image = global::FrmProcesos.Properties.Resources.accept;
            this.btn_recibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_recibir.Location = new System.Drawing.Point(7, 325);
            this.btn_recibir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_recibir.Name = "btn_recibir";
            this.btn_recibir.Size = new System.Drawing.Size(798, 24);
            this.btn_recibir.TabIndex = 221;
            this.btn_recibir.Text = "Genera Liquidación";
            this.btn_recibir.UseVisualStyleBackColor = false;
            this.btn_recibir.Click += new System.EventHandler(this.btn_recibir_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_venc_grabar);
            this.tabPage2.Controls.Add(this.btn_venc_quitar);
            this.tabPage2.Controls.Add(this.btn_venc_agrega);
            this.tabPage2.Controls.Add(this.Grid_DetLiquidacion);
            this.tabPage2.Controls.Add(this.Grid_Vencimientos);
            this.tabPage2.Controls.Add(this.Grid_Liquidacion);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(811, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Liquidaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_venc_grabar
            // 
            this.btn_venc_grabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_venc_grabar.Image = global::FrmProcesos.Properties.Resources._16__Save_;
            this.btn_venc_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_venc_grabar.Location = new System.Drawing.Point(782, 58);
            this.btn_venc_grabar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_venc_grabar.Name = "btn_venc_grabar";
            this.btn_venc_grabar.Size = new System.Drawing.Size(27, 24);
            this.btn_venc_grabar.TabIndex = 225;
            this.btn_venc_grabar.UseVisualStyleBackColor = false;
            this.btn_venc_grabar.Click += new System.EventHandler(this.btn_venc_grabar_Click);
            // 
            // btn_venc_quitar
            // 
            this.btn_venc_quitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_venc_quitar.Image = global::FrmProcesos.Properties.Resources._16__Delete_over_;
            this.btn_venc_quitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_venc_quitar.Location = new System.Drawing.Point(782, 32);
            this.btn_venc_quitar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_venc_quitar.Name = "btn_venc_quitar";
            this.btn_venc_quitar.Size = new System.Drawing.Size(27, 24);
            this.btn_venc_quitar.TabIndex = 224;
            this.btn_venc_quitar.UseVisualStyleBackColor = false;
            this.btn_venc_quitar.Click += new System.EventHandler(this.btn_venc_quitar_Click);
            // 
            // btn_venc_agrega
            // 
            this.btn_venc_agrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_venc_agrega.Image = global::FrmProcesos.Properties.Resources._16__Plus_;
            this.btn_venc_agrega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_venc_agrega.Location = new System.Drawing.Point(782, 6);
            this.btn_venc_agrega.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_venc_agrega.Name = "btn_venc_agrega";
            this.btn_venc_agrega.Size = new System.Drawing.Size(27, 24);
            this.btn_venc_agrega.TabIndex = 223;
            this.btn_venc_agrega.UseVisualStyleBackColor = false;
            this.btn_venc_agrega.Click += new System.EventHandler(this.btn_venc_agrega_Click);
            // 
            // Grid_DetLiquidacion
            // 
            this.Grid_DetLiquidacion.AllowUserToAddRows = false;
            this.Grid_DetLiquidacion.AllowUserToDeleteRows = false;
            this.Grid_DetLiquidacion.BackgroundColor = System.Drawing.Color.White;
            this.Grid_DetLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_DetLiquidacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.Grid_DetLiquidacion.Location = new System.Drawing.Point(7, 188);
            this.Grid_DetLiquidacion.Name = "Grid_DetLiquidacion";
            this.Grid_DetLiquidacion.RowHeadersWidth = 20;
            this.Grid_DetLiquidacion.Size = new System.Drawing.Size(798, 182);
            this.Grid_DetLiquidacion.TabIndex = 193;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Guía";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Fecha Recepción";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 70;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Especie";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 220;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Variedad";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn16.Width = 120;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Num OC";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 80;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn18.HeaderText = "Cantidad ";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn19.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // Grid_Vencimientos
            // 
            this.Grid_Vencimientos.AllowUserToAddRows = false;
            this.Grid_Vencimientos.AllowUserToDeleteRows = false;
            this.Grid_Vencimientos.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Vencimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn12});
            this.Grid_Vencimientos.Location = new System.Drawing.Point(494, 6);
            this.Grid_Vencimientos.Name = "Grid_Vencimientos";
            this.Grid_Vencimientos.RowHeadersWidth = 20;
            this.Grid_Vencimientos.Size = new System.Drawing.Size(283, 176);
            this.Grid_Vencimientos.TabIndex = 192;
            this.Grid_Vencimientos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Vencimientos_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Folio";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Fecha Vencimiento";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn12.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 90;
            // 
            // Grid_Liquidacion
            // 
            this.Grid_Liquidacion.AllowUserToAddRows = false;
            this.Grid_Liquidacion.AllowUserToDeleteRows = false;
            this.Grid_Liquidacion.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Liquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Liquidacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn11});
            this.Grid_Liquidacion.Location = new System.Drawing.Point(6, 6);
            this.Grid_Liquidacion.Name = "Grid_Liquidacion";
            this.Grid_Liquidacion.RowHeadersWidth = 20;
            this.Grid_Liquidacion.Size = new System.Drawing.Size(482, 176);
            this.Grid_Liquidacion.TabIndex = 191;
            this.Grid_Liquidacion.SelectionChanged += new System.EventHandler(this.Grid_Liquidacion_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Folio";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Fecha Liquidación";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Comentario";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 220;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn11.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Grid_Contactos);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(811, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Contactos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(247, 17);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 21);
            this.btn_buscar1.TabIndex = 220;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // frmProductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 531);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_buscar1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.t_encargado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_cardcode);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.t_cardname);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProductores";
            this.Text = "Registro de Productores";
            this.Load += new System.EventHandler(this.frmProductores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Entradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Contactos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_DetLiquidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Vencimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Liquidacion)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button btn_recibir;
        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.DataGridView Grid_Entradas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox t_encargado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_cardcode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_cardname;
        private System.Windows.Forms.DataGridView Grid_Contactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView Grid_DetLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridView Grid_Vencimientos;
        private System.Windows.Forms.DataGridView Grid_Liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btn_venc_agrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Button btn_venc_grabar;
        private System.Windows.Forms.Button btn_venc_quitar;
    }
}