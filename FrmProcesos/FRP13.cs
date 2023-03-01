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
    public partial class FRP13 : Form
    {
        public FRP13()
        {
            InitializeComponent();
        }

        private void FRP13_Load(object sender, EventArgs e)
        {

            this.Size = new Size(430, 520);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Almacenes();

                this.dataGridView1.DataSource = objproducto.cResultado;

                this.dataGridView1.RowHeadersWidth = 10;

                this.dataGridView1.Columns[0].HeaderText = "Code";
                this.dataGridView1.Columns[0].Visible = false;

                this.dataGridView1.Columns[1].HeaderText = "Almacen";
                this.dataGridView1.Columns[1].Width = 80;

                this.dataGridView1.Columns[2].HeaderText = "Capacidad Prod. Terminados";
                this.dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[2].Width = 120;

                this.dataGridView1.Columns[3].HeaderText = "Capacidad Materia Prima";
                this.dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[3].Width = 120;

                //this.dataGridView1.Columns[6].HeaderText = "Meta MP";
                //this.dataGridView1.Columns[6].DefaultCellStyle.Format = "0,0";
                //this.dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns[6].Width = 90;

                //this.dataGridView1.Columns[7].HeaderText = "Rendimiento PT";
                //this.dataGridView1.Columns[7].DefaultCellStyle.Format = "0,0";
                //this.dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns[7].Width = 90;

                //this.dataGridView1.Columns[8].HeaderText = "Rendimiento MP";
                //this.dataGridView1.Columns[8].DefaultCellStyle.Format = "0,0";
                //this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns[8].Width = 90;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cCode;

            cCode = "";

            if (fila >= 0)
            {
                try
                {
                    cCode = dataGridView1[1, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    cCode = "";

                }

            }

            if (cCode != "")
            {

                VariablesGlobales.glb_CardCode = cCode;

                FRP14 f2 = new FRP14();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_CardCode = "";

            }

            carga_grilla();

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_CardCode = "";

            FRP14 f2 = new FRP14();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_CardCode = "";

            carga_grilla();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string c_code;

            c_code = "";

            if (fila >= 0)
            {
                try
                {
                    c_code = dataGridView1[0, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    c_code = "";

                }

            }

            if (c_code != "")
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de eliminar este almacen", "Parametros", buttons);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;

                }

                String mensaje1 = clsMaestros.SAPB1_OALMACEN_e(c_code);

                if (mensaje1 == "Y")
                {
                    //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensaje1, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            carga_grilla();

        }

    }

}
