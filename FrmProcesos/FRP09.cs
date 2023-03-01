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
    public partial class FRP09 : Form
    {
        public FRP09()
        {
            InitializeComponent();
        }

        private void FRP09_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_guias_excluidas2();

                //this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Estado";
                this.dataGridView1.Columns[0].Width = 140;
                this.dataGridView1.Columns[1].Visible = false;
                this.dataGridView1.Columns[2].HeaderText = "Productor";
                this.dataGridView1.Columns[2].Width = 210;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderText = "Artículo";
                this.dataGridView1.Columns[4].Width = 230;

                this.dataGridView1.Columns[5].HeaderText = "Folio";
                this.dataGridView1.Columns[5].Width = 60;
                this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[6].HeaderText = "Lote";
                this.dataGridView1.Columns[6].Width = 70;
                this.dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[7].HeaderText = "Cant. Bins";
                this.dataGridView1.Columns[7].Width = 50;
                this.dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[8].HeaderText = "Orden";
                this.dataGridView1.Columns[8].Width = 60;
                this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[9].HeaderText = "Fecha/Hora";
                this.dataGridView1.Columns[9].Width = 110;

                this.dataGridView1.Columns[10].Visible = false;
                this.dataGridView1.Columns[11].Visible = false;

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana, nLineId;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            id_romana = 0;
            nLineId = 0;

            if (fila >= 0)
            {
                try
                {
                    id_romana = Convert.ToInt32(dataGridView1[5, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    id_romana = 0;

                }

                string mensaje;

                try
                {
                    mensaje = clsRomana.SAPB1_ROMANA9(id_romana);

                }
                catch
                {

                }

            }

            Close();

        }

    }

}
