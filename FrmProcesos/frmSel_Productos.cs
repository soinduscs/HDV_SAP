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
    public partial class frmSel_Productos : Form
    {
        public frmSel_Productos()
        {
            InitializeComponent();
        }

        private void frmSel_Productos_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {
            int solo_mp, con_oc, fruta_propia;

            solo_mp = 0;
            con_oc = 0;
            fruta_propia = 0;

            if (chk_con_oc.Checked == true)
            {
                con_oc = 1;
            }

            if (chk_solo_mp.Checked == true)
            {
                solo_mp = 1;
            }

            if (chk_fruta_propia.Checked == true)
            {
                fruta_propia = 1;
            }


            try
            {
                this.Dock = DockStyle.Fill;

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Productos(t_buscar.Text, solo_mp, con_oc, fruta_propia);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo SN";
                this.dataGridView1.Columns[0].Width = 300;
                this.dataGridView1.Columns[1].HeaderText = "Nombre SN";
                this.dataGridView1.Columns[1].Width = 400;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].Visible = false;
                //this.dataGridView1.Columns[4].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_ItemCode = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemName = dataGridView1[1, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_ItemCode = "";
                    VariablesGlobales.glb_ItemName = "";

                }

            }

            Close();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            Close();

        }

        private void chk_solo_mp_CheckedChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void chk_solo_mp_CheckedChanged_1(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void chk_fruta_propia_CheckedChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }

        private void t_buscar_TextChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }
    }
}
