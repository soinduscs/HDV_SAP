using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace FrmProcesos
{
    public partial class frmPorteria1 : Form
    {
        public frmPorteria1()
        {
            InitializeComponent();
        }

        private void frmPorteria1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1070, 510);
            dtp_fecha.Value = DateTime.Today;

            //carga_grilla();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana;

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

            }

            VariablesGlobales.glb_id_acceso = id_romana;

            if (VariablesGlobales.glb_Referencia1 == "Menu")
            {
                frmPorteria f2 = new frmPorteria();
                DialogResult res = f2.ShowDialog();

                carga_grilla();

            }

            if (VariablesGlobales.glb_Referencia1 == "Romana")
            {
                Close();

            }


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void carga_grilla()
        {
            string fecha;

            fecha = dtp_fecha.Value.ToString("yyyyMMdd");

            try
            {

                clsPorteria objproducto = new clsPorteria();
                objproducto.cls_Consultar_Accesos_Full(fecha, "N");

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderText = "Razón de Ingreso";
                this.dataGridView1.Columns[1].Width = 220;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].HeaderText = "Productor";
                this.dataGridView1.Columns[3].Width = 300;
                this.dataGridView1.Columns[4].HeaderText = "Patente";
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].HeaderText = "Guía";
                this.dataGridView1.Columns[5].Width = 80;
                this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[6].HeaderText = "Fecha Ingreso";
                this.dataGridView1.Columns[6].Width = 110;
                this.dataGridView1.Columns[7].Visible = false;
                this.dataGridView1.Columns[8].HeaderText = "Conductor";
                this.dataGridView1.Columns[8].Width = 200;
                this.dataGridView1.Columns[9].Visible = false;
                this.dataGridView1.Columns[10].HeaderText = "Transportista";
                this.dataGridView1.Columns[10].Width = 300;
                this.dataGridView1.Columns[11].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

        private void dtp_fecha_ValueChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }
    }
}
