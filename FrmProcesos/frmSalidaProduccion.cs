﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmSalidaProduccion : Form
    {
        public frmSalidaProduccion()
        {
            InitializeComponent();
        }

        private void frmSalidaProduccion_Load(object sender, EventArgs e)
        {
            this.Size = new Size(680, 450);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_SalidasProduccion();

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;

                this.dataGridView1.Columns[0].HeaderText = "Tipo Fruta";
                this.dataGridView1.Columns[0].Width = 150;
                this.dataGridView1.Columns[1].HeaderText = "Salida";
                this.dataGridView1.Columns[1].Width = 50;
                this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[2].HeaderText = "Proceso";
                this.dataGridView1.Columns[2].Width = 350;
                this.dataGridView1.Columns[3].HeaderText = "Codigo";
                this.dataGridView1.Columns[3].Width = 50;
                this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            frmSalidaProduccion1 f2 = new frmSalidaProduccion1();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }

    }

}
