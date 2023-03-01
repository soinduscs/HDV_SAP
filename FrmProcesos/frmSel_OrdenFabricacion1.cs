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
    public partial class frmSel_OrdenFabricacion1 : Form
    {
        public frmSel_OrdenFabricacion1()
        {
            InitializeComponent();
        }

        private void frmSel_OrdenFabricacion1_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                this.Dock = DockStyle.Fill;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_de_OrdenFabricacion1(VariablesGlobales.glb_Referencia1);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Num. Orden"; // DocEntry
                this.dataGridView1.Columns[0].Width = 60;
                this.dataGridView1.Columns[1].Visible = false; // DocNum
                this.dataGridView1.Columns[2].HeaderText = "Fecha Orden"; // DocEntry
                this.dataGridView1.Columns[2].Width = 70;
                this.dataGridView1.Columns[2].Visible = true; // PostDate
                this.dataGridView1.Columns[3].HeaderText = "Fecha Inicio"; // DocEntry
                this.dataGridView1.Columns[3].Width = 70;
                this.dataGridView1.Columns[3].Visible = true; // StartDate
                this.dataGridView1.Columns[4].HeaderText = "Fecha Finalizacion"; // DocEntry
                this.dataGridView1.Columns[4].Width = 70;
                this.dataGridView1.Columns[4].Visible = true; // DueDate
                this.dataGridView1.Columns[5].HeaderText = "Num. Articulo"; // DocEntry
                this.dataGridView1.Columns[5].Width = 260;
                this.dataGridView1.Columns[5].Visible = true; // ItemCode
                this.dataGridView1.Columns[6].HeaderText = "Articulo"; // DocEntry
                this.dataGridView1.Columns[6].Width = 250;
                this.dataGridView1.Columns[6].Visible = true; // ItemName
                this.dataGridView1.Columns[7].Visible = false; // InvntryUom
                this.dataGridView1.Columns[8].Visible = false; // UserSign
                this.dataGridView1.Columns[9].Visible = false;
                this.dataGridView1.Columns[10].Visible = false;  
                this.dataGridView1.Columns[11].Visible = false;  
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[13].HeaderText = "Proceso";
                this.dataGridView1.Columns[13].Width = 130;
                this.dataGridView1.Columns[13].Visible = true;
                this.dataGridView1.Columns[14].HeaderText = "Destino";
                this.dataGridView1.Columns[14].Width = 150;
                this.dataGridView1.Columns[14].Visible = true;

                //this.dataGridView1.Columns[16].Visible = false; // 
                //this.dataGridView1.Columns[17].Visible = false; // 

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;

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

            int nDocEntry;

            VariablesGlobales.glb_DocEntry = 0;

            try
            {
                nDocEntry = int.Parse(dataGridView1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }
    }
}
