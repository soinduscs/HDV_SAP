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
    public partial class frmSel_OrdendeCompra : Form
    {
        public frmSel_OrdendeCompra()
        {
            InitializeComponent();
        }

        private void frmSel_OrdendeCompra_Load(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_CardName != "")
            {
                t_buscar.Text = VariablesGlobales.glb_CardName;
            }
                        
            carga_grilla();

        }

        private void carga_grilla()
        {
            string solo_MP;
            string solo_incluir_fruta_servicios;
            string solo_codigos_csg;

            solo_MP = "S";
            solo_incluir_fruta_servicios = "N";
            solo_codigos_csg = "N";

            if (chk_solo_MP.Checked == false)
            {
                solo_MP = "N";
            }

            if (chk_incluir_fruta_servicios.Checked == true)
            {
                solo_incluir_fruta_servicios = "S";
            }

            if (chk_codigo_csg.Checked == true)
            {
                solo_codigos_csg = "S";

            }

            if (t_buscar.Text.Trim() != "")
            {
                solo_MP = "T";
                solo_incluir_fruta_servicios = "T";

            }

            try
            {
                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_Ordenes_de_compra_abiertas(t_buscar.Text , solo_MP, solo_incluir_fruta_servicios, solo_codigos_csg , t_codigo_csg.Text);

                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Width = 60;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[0].HeaderText = "Número";
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[1].HeaderText = "Fecha Emisión";

                this.dataGridView1.Columns[2].Width = 120;
                this.dataGridView1.Columns[2].HeaderText = "Código CSG";

                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].Width = 250;
                this.dataGridView1.Columns[4].HeaderText = "Productor";
                this.dataGridView1.Columns[5].Visible = false;
                this.dataGridView1.Columns[6].Visible = false;
                this.dataGridView1.Columns[7].Width = 210;
                this.dataGridView1.Columns[7].HeaderText = "Especie";

                this.dataGridView1.Columns[8].Width = 120;
                this.dataGridView1.Columns[8].HeaderText = "Variedad";
                this.dataGridView1.Columns[9].Width = 65;
                this.dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[9].HeaderText = "Cant. Pendiente";
                this.dataGridView1.Columns[9].DefaultCellStyle.Format = "n2";

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

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {

            int fila, nLineId;
            string cItemName, cVariedad, cCodigo_CSG; 

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
            VariablesGlobales.glb_Codigo_CSG = "";
            VariablesGlobales.glb_LineId = -1;

            if (fila >= 0)
            {
                try
                {
                    cCodigo_CSG = dataGridView1[2, fila].Value.ToString().ToUpper();

                    cItemName = dataGridView1[7, fila].Value.ToString().ToUpper();
                    cVariedad = dataGridView1[8, fila].Value.ToString().ToUpper();

                    try
                    {
                        nLineId = Convert.ToInt32(dataGridView1[5, fila].Value.ToString());

                    }
                    catch
                    {
                        nLineId = 0;

                    }

                    VariablesGlobales.glb_NumOC = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardCode = dataGridView1[3, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_CardName = dataGridView1[4, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemCode = dataGridView1[6, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_Codigo_CSG = cCodigo_CSG;
                    VariablesGlobales.glb_LineId = nLineId;
                    VariablesGlobales.glb_LineNumOF = nLineId;

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
                    VariablesGlobales.glb_Codigo_CSG = "";
                    VariablesGlobales.glb_LineId = -1;
                    VariablesGlobales.glb_LineNumOF = -1;

                }

            }

            Close();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void chk_solo_proveedores_CheckedChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void chk_solo_MP_CheckedChanged(object sender, EventArgs e)
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
