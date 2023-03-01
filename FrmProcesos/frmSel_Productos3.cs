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
    public partial class frmSel_Productos3 : Form
    {
        public frmSel_Productos3()
        {
            InitializeComponent();
        }

        private void frmSel_Productos3_Load(object sender, EventArgs e)
        {

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            this.Text = "Lista de Productos Asociados a Orden de Fabricación: " + VariablesGlobales.glb_DocEntry.ToString();

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                this.Dock = DockStyle.Fill;

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Productos3(VariablesGlobales.glb_DocEntry);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo SN";
                this.dataGridView1.Columns[0].Width = 300;
                this.dataGridView1.Columns[1].HeaderText = "Nombre SN";
                this.dataGridView1.Columns[1].Width = 400;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].HeaderText = "Almacén";
                this.dataGridView1.Columns[5].Width = 80;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
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
            VariablesGlobales.glb_Almacen = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_ItemCode = dataGridView1[0, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_ItemName = dataGridView1[1, fila].Value.ToString().ToUpper();
                    VariablesGlobales.glb_Almacen = dataGridView1[5, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_ItemCode = "";
                    VariablesGlobales.glb_ItemName = "";
                    VariablesGlobales.glb_Almacen = "";

                }

            }

            Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btn_seleccionar_Click(sender, e);
        }
    }
}
