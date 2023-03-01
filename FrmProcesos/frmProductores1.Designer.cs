namespace FrmProcesos
{
    partial class frmProductores1
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
            this.label13 = new System.Windows.Forms.Label();
            this.t_encargado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_cardcode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t_cardname = new System.Windows.Forms.TextBox();
            this.btn_buscar1 = new System.Windows.Forms.Button();
            this.cbb_cosecha = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_kg_presupuesto = new System.Windows.Forms.TextBox();
            this.t_kg_oportunidad = new System.Windows.Forms.TextBox();
            this.t_kg_potenciales = new System.Windows.Forms.TextBox();
            this.t_has_produccion = new System.Windows.Forms.TextBox();
            this.cbb_tipocontrato = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.t_has_total = new System.Windows.Forms.TextBox();
            this.cbb_variedad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_itemcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t_itemname = new System.Windows.Forms.TextBox();
            this.btn_recibir = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 62);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 228;
            this.label13.Text = "Encargado Compras";
            // 
            // t_encargado
            // 
            this.t_encargado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_encargado.Location = new System.Drawing.Point(127, 59);
            this.t_encargado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_encargado.MaxLength = 10;
            this.t_encargado.Name = "t_encargado";
            this.t_encargado.ReadOnly = true;
            this.t_encargado.Size = new System.Drawing.Size(331, 21);
            this.t_encargado.TabIndex = 225;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 224;
            this.label1.Text = "Nombre";
            // 
            // t_cardcode
            // 
            this.t_cardcode.Location = new System.Drawing.Point(127, 13);
            this.t_cardcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardcode.MaxLength = 20;
            this.t_cardcode.Name = "t_cardcode";
            this.t_cardcode.ReadOnly = true;
            this.t_cardcode.Size = new System.Drawing.Size(125, 21);
            this.t_cardcode.TabIndex = 223;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 221;
            this.label18.Text = "Socio de Negocio";
            // 
            // t_cardname
            // 
            this.t_cardname.Location = new System.Drawing.Point(127, 36);
            this.t_cardname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_cardname.Name = "t_cardname";
            this.t_cardname.ReadOnly = true;
            this.t_cardname.Size = new System.Drawing.Size(601, 21);
            this.t_cardname.TabIndex = 222;
            // 
            // btn_buscar1
            // 
            this.btn_buscar1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar1.Image = global::FrmProcesos.Properties.Resources.boton_sap;
            this.btn_buscar1.Location = new System.Drawing.Point(546, 55);
            this.btn_buscar1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_buscar1.Name = "btn_buscar1";
            this.btn_buscar1.Size = new System.Drawing.Size(22, 21);
            this.btn_buscar1.TabIndex = 229;
            this.btn_buscar1.UseVisualStyleBackColor = false;
            this.btn_buscar1.Click += new System.EventHandler(this.btn_buscar1_Click);
            // 
            // cbb_cosecha
            // 
            this.cbb_cosecha.FormattingEnabled = true;
            this.cbb_cosecha.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.cbb_cosecha.Location = new System.Drawing.Point(78, 32);
            this.cbb_cosecha.Name = "cbb_cosecha";
            this.cbb_cosecha.Size = new System.Drawing.Size(87, 21);
            this.cbb_cosecha.TabIndex = 231;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 230;
            this.label4.Text = "Cosecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.t_kg_presupuesto);
            this.groupBox1.Controls.Add(this.t_kg_oportunidad);
            this.groupBox1.Controls.Add(this.t_kg_potenciales);
            this.groupBox1.Controls.Add(this.t_has_produccion);
            this.groupBox1.Controls.Add(this.cbb_tipocontrato);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.t_has_total);
            this.groupBox1.Controls.Add(this.cbb_variedad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.t_itemcode);
            this.groupBox1.Controls.Add(this.btn_buscar1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.t_itemname);
            this.groupBox1.Controls.Add(this.cbb_cosecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(23, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 210);
            this.groupBox1.TabIndex = 232;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos por cosecha";
            // 
            // t_kg_presupuesto
            // 
            this.t_kg_presupuesto.Location = new System.Drawing.Point(358, 137);
            this.t_kg_presupuesto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_kg_presupuesto.Name = "t_kg_presupuesto";
            this.t_kg_presupuesto.Size = new System.Drawing.Size(77, 21);
            this.t_kg_presupuesto.TabIndex = 248;
            this.t_kg_presupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_kg_oportunidad
            // 
            this.t_kg_oportunidad.Location = new System.Drawing.Point(358, 114);
            this.t_kg_oportunidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_kg_oportunidad.Name = "t_kg_oportunidad";
            this.t_kg_oportunidad.Size = new System.Drawing.Size(77, 21);
            this.t_kg_oportunidad.TabIndex = 247;
            this.t_kg_oportunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_kg_potenciales
            // 
            this.t_kg_potenciales.Location = new System.Drawing.Point(120, 160);
            this.t_kg_potenciales.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_kg_potenciales.Name = "t_kg_potenciales";
            this.t_kg_potenciales.Size = new System.Drawing.Size(77, 21);
            this.t_kg_potenciales.TabIndex = 246;
            this.t_kg_potenciales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_has_produccion
            // 
            this.t_has_produccion.Location = new System.Drawing.Point(120, 137);
            this.t_has_produccion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_has_produccion.Name = "t_has_produccion";
            this.t_has_produccion.Size = new System.Drawing.Size(77, 21);
            this.t_has_produccion.TabIndex = 245;
            this.t_has_produccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbb_tipocontrato
            // 
            this.cbb_tipocontrato.FormattingEnabled = true;
            this.cbb_tipocontrato.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.cbb_tipocontrato.Location = new System.Drawing.Point(358, 160);
            this.cbb_tipocontrato.Name = "cbb_tipocontrato";
            this.cbb_tipocontrato.Size = new System.Drawing.Size(151, 21);
            this.cbb_tipocontrato.TabIndex = 244;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 243;
            this.label10.Text = "Tipo contrato";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 242;
            this.label9.Text = "KG Presupuesto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 241;
            this.label8.Text = "KG Oportunidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 163);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 240;
            this.label7.Text = "KG Potenciales";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 239;
            this.label6.Text = "HAS en Producción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 238;
            this.label5.Text = "Cantidad HAS Total";
            // 
            // t_has_total
            // 
            this.t_has_total.Location = new System.Drawing.Point(120, 114);
            this.t_has_total.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_has_total.Name = "t_has_total";
            this.t_has_total.Size = new System.Drawing.Size(77, 21);
            this.t_has_total.TabIndex = 237;
            this.t_has_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbb_variedad
            // 
            this.cbb_variedad.FormattingEnabled = true;
            this.cbb_variedad.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.cbb_variedad.Location = new System.Drawing.Point(78, 79);
            this.cbb_variedad.Name = "cbb_variedad";
            this.cbb_variedad.Size = new System.Drawing.Size(151, 21);
            this.cbb_variedad.TabIndex = 236;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 235;
            this.label3.Text = "Variedad";
            // 
            // t_itemcode
            // 
            this.t_itemcode.Location = new System.Drawing.Point(500, 32);
            this.t_itemcode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemcode.Name = "t_itemcode";
            this.t_itemcode.ReadOnly = true;
            this.t_itemcode.Size = new System.Drawing.Size(44, 21);
            this.t_itemcode.TabIndex = 234;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 233;
            this.label2.Text = "Especie";
            // 
            // t_itemname
            // 
            this.t_itemname.Location = new System.Drawing.Point(78, 55);
            this.t_itemname.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.t_itemname.Name = "t_itemname";
            this.t_itemname.ReadOnly = true;
            this.t_itemname.Size = new System.Drawing.Size(466, 21);
            this.t_itemname.TabIndex = 232;
            // 
            // btn_recibir
            // 
            this.btn_recibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_recibir.Image = global::FrmProcesos.Properties.Resources.accept;
            this.btn_recibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_recibir.Location = new System.Drawing.Point(111, 304);
            this.btn_recibir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_recibir.Name = "btn_recibir";
            this.btn_recibir.Size = new System.Drawing.Size(96, 22);
            this.btn_recibir.TabIndex = 233;
            this.btn_recibir.Text = "  Grabar";
            this.btn_recibir.UseVisualStyleBackColor = false;
            this.btn_recibir.Click += new System.EventHandler(this.btn_recibir_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_finalizar.Location = new System.Drawing.Point(23, 304);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(74, 22);
            this.btn_finalizar.TabIndex = 234;
            this.btn_finalizar.Text = "Cancelar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // frmProductores1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 339);
            this.Controls.Add(this.btn_recibir);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.t_encargado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_cardcode);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.t_cardname);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProductores1";
            this.Text = "frmProductores1";
            this.Load += new System.EventHandler(this.frmProductores1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox t_encargado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_cardcode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t_cardname;
        private System.Windows.Forms.ComboBox cbb_cosecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_recibir;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox t_itemcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_itemname;
        private System.Windows.Forms.ComboBox cbb_variedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_kg_presupuesto;
        private System.Windows.Forms.TextBox t_kg_oportunidad;
        private System.Windows.Forms.TextBox t_kg_potenciales;
        private System.Windows.Forms.TextBox t_has_produccion;
        private System.Windows.Forms.ComboBox cbb_tipocontrato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_has_total;
    }
}