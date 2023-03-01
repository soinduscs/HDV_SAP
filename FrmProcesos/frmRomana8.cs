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
    public partial class frmRomana8 : Form
    {
        public frmRomana8()
        {
            InitializeComponent();
        }

        private void frmRomana8_Load(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_romana = 0;

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_abiertas_of(VariablesGlobales.glb_Razon_Ingreso);

                //this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Visible = false;

                this.dataGridView1.Columns[1].HeaderText = "Num. OF";
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[2].Visible = false;

                this.dataGridView1.Columns[3].HeaderText = "Artículo";
                this.dataGridView1.Columns[3].Width = 300;

                this.dataGridView1.Columns[4].HeaderText = "Peso Tara";
                this.dataGridView1.Columns[4].Width = 90;
                this.dataGridView1.Columns[4].DefaultCellStyle.Format = "n2";
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[5].HeaderText = "Fecha/Hora";
                this.dataGridView1.Columns[5].Width = 110;

                this.dataGridView1.Columns[6].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                    id_romana = Convert.ToInt32(dataGridView1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    id_romana = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(dataGridView1[10, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;

                }


            }

            VariablesGlobales.glb_id_romana = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            Close();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

    }
}
