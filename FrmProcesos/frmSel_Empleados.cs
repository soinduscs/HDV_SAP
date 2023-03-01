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
    public partial class frmSel_Empleados : Form
    {
        public frmSel_Empleados()
        {
            InitializeComponent();
        }

        private void frmSel_Empleados_Load(object sender, EventArgs e)
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_consulta_dependencia1_gestper_v2();

            cbb_area.DataSource = objproducto.cResultado;
            cbb_area.ValueMember = "codigo";
            cbb_area.DisplayMember = "descripcion";

            cbb_area.SelectedIndex = 0;

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_rut = 0;
            VariablesGlobales.glb_Empleado = "";

            Close();

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {

            int fila, n_idrut;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            VariablesGlobales.glb_id_rut = 0;
            VariablesGlobales.glb_Empleado = "";

            try
            {
                n_idrut = Convert.ToInt32(dataGridView1[0, fila].Value.ToString());
            }
            catch
            {
                n_idrut = 0;
            }

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_id_rut = n_idrut;
                    VariablesGlobales.glb_Empleado = dataGridView1[1, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_id_rut = 0;
                    VariablesGlobales.glb_Empleado = "";

                }

            }

            Close();

        }

        private void carga_grilla()
        {

            string cdependencia, cdependencia_no, cnombre;

            cdependencia_no = VariablesGlobales.glb_Area;

            if (cbb_area.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un área válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cdependencia = cbb_area.SelectedValue.ToString();

            }
            catch
            {
                cdependencia = "";

            }

            if (cdependencia == "")
            {
                MessageBox.Show("Debe seleccionar un área válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cnombre = t_buscar1.Text;

            }
            catch
            {
                cnombre = "";

            }

            try
            {
                this.Dock = DockStyle.Fill;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_consulta_empleados_gestper(cnombre, cdependencia_no, cdependencia);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].HeaderText = "Codigo Empleado";
                this.dataGridView1.Columns[1].HeaderText = "Nombre Empleado";
                this.dataGridView1.Columns[1].Width = 350;
                this.dataGridView1.Columns[2].HeaderText = "Codigo Area";
                this.dataGridView1.Columns[3].HeaderText = "Área";
                this.dataGridView1.Columns[3].Width = 250;

                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[2].Visible = false;
                //this.dataGridView1.Columns[4].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void t_buscar1_TextChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void cbb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            carga_grilla();

        }

    }

}
