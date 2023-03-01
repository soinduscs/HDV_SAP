using System;
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
    public partial class frmSel_SocioNegocio : Form
    {
        public frmSel_SocioNegocio()
        {
            InitializeComponent();
        }

        private void frmSocioNegocio_Load(object sender, EventArgs e)
        {
            this.Size = new Size(610, 520);

            t_carga.Text = "";

            carga_grilla();

            t_carga.Text = "S";

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (t_buscar.Text.Trim() == "")
            {
                return;
            }

            int fila;
            int control;
            string texto_seek;

            fila = 0;
            control = 0;
            texto_seek = "";

            if (dataGridView1.RowCount > 0)
            {

                for (fila = 0; fila < dataGridView1.RowCount - 1; fila++)
                {
                    dataGridView1.Rows[fila].Selected = false;
                }

                for (fila = 0; fila < dataGridView1.RowCount - 1; fila++)
                {
                    texto_seek = dataGridView1[1, fila].Value.ToString().ToUpper();

                    try
                    {
                        if (texto_seek.IndexOf(t_buscar.Text.Trim().ToUpper()) > -1)
                        {
                            control = 1;
                            break;
                        }

                    }
                    catch
                    {
                        control = 0;
                    }

                }
                if (control == 1)
                {
                    dataGridView1.Rows[fila].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = fila;
                    //dataGridView1.Focus();

                }

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

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_CardCode = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardName = dataGridView1[1, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_CardCode = "";
                    VariablesGlobales.glb_CardName = "";

                }

            }

            Close();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            Close();
        }

        private void carga_grilla()
        {
            string solo_con_oc;
            string solo_proveedores;

            solo_con_oc = "";
            solo_proveedores = "N";

            if (chk_con_OC.Checked == true)
            {
                solo_con_oc = "S";
            }

            if (chk_solo_proveedores.Checked == true)
            {
                solo_proveedores = "S";
            }

            try
            {

                clsSocioNegocio objproducto = new clsSocioNegocio();
                objproducto.cls_Consultar_OCRDxCardName(t_buscar.Text.Trim(), solo_con_oc.Trim(), solo_proveedores.Trim()); 

                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo SN";
                this.dataGridView1.Columns[1].Width = 400;
                this.dataGridView1.Columns[1].HeaderText = "Nombre SN";
                this.dataGridView1.Columns[2].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }

        private void chk_con_OC_CheckedChanged(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void chk_solo_proveedores_CheckedChanged(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void t_buscar_TextChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }
    }
}
