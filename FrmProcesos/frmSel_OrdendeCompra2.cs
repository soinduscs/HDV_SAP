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
    public partial class frmSel_OrdendeCompra2 : Form
    {
        public frmSel_OrdendeCompra2()
        {
            InitializeComponent();
        }

        private void frmSel_OrdendeCompra2_Load(object sender, EventArgs e)
        {

            carga_grilla();

        }

        private void carga_grilla()
        {
            string solo_MP;
            string solo_incluir_fruta_servicios;

            solo_MP = "S";
            solo_incluir_fruta_servicios = "N";

            if (chk_solo_MP.Checked == false)
            {
                solo_MP = "N";

            }

            if (chk_incluir_fruta_servicios.Checked == true)
            {
                solo_incluir_fruta_servicios = "S";

            }

            if (t_buscar.Text.Trim() != "")
            {
                solo_MP = "T";
                solo_incluir_fruta_servicios = "T";

            }

            try
            {
                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_Ordenes_de_compra_abiertas_dys(t_buscar.Text, solo_MP, solo_incluir_fruta_servicios);

                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Width = 80;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[0].HeaderText = "Número";
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[1].HeaderText = "Fecha Emisión";
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Width = 250;
                this.dataGridView1.Columns[3].HeaderText = "Productor";
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].Visible = false;
                this.dataGridView1.Columns[6].Width = 340;
                this.dataGridView1.Columns[6].HeaderText = "Especie";
                this.dataGridView1.Columns[7].Width = 340;
                this.dataGridView1.Columns[7].HeaderText = "Variedad";
                this.dataGridView1.Columns[8].Width = 65;
                this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[8].HeaderText = "Cant. Pendiente";
                this.dataGridView1.Columns[8].DefaultCellStyle.Format = "n2";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            int fila;
            string cItemName, cVariedad;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            if (fila >= 0)
            {
                try
                {
                    cItemName = dataGridView1[6, fila].Value.ToString().ToUpper();
                    cVariedad = dataGridView1[7, fila].Value.ToString().ToUpper();

                    VariablesGlobales.glb_NumOC = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardCode = dataGridView1[2, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardName = dataGridView1[3, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemCode = dataGridView1[5, fila].Value.ToString().ToUpper();
                    if (cVariedad == "")
                    {
                        VariablesGlobales.glb_ItemName = cItemName;

                    }
                    else
                    {
                        VariablesGlobales.glb_ItemName = cItemName + " - " + cVariedad;

                    }

                }
                catch
                {
                    VariablesGlobales.glb_NumOC = "";
                    VariablesGlobales.glb_CardCode = "";
                    VariablesGlobales.glb_CardName = "";
                    VariablesGlobales.glb_ItemCode = "";
                    VariablesGlobales.glb_ItemName = "";

                }

            }

            Close();

        }

    }

}

    