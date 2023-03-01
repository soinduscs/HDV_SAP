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
    public partial class FRP10 : Form
    {
        public FRP10()
        {
            InitializeComponent();
        }

        private void FRP10_Load(object sender, EventArgs e)
        {

            this.Size = new Size(800, 380);

            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Temporadas("NCC");

                this.dataGridView1.DataSource = objproducto.cResultado;

                this.dataGridView1.RowHeadersWidth = 10;

                this.dataGridView1.Columns[0].HeaderText = "Code";
                this.dataGridView1.Columns[0].Visible = false;

                this.dataGridView1.Columns[1].HeaderText = "Name";
                this.dataGridView1.Columns[1].Visible = false;

                this.dataGridView1.Columns[2].HeaderText = "Temporada";
                this.dataGridView1.Columns[2].Width = 80;

                this.dataGridView1.Columns[3].HeaderText = "Fecha Inicio";
                this.dataGridView1.Columns[3].Width = 120;

                this.dataGridView1.Columns[4].HeaderText = "Horas";
                this.dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[4].Width = 60;
                //this.dataGridView1.Columns[4].

                this.dataGridView1.Columns[5].HeaderText = "Meta PT";
                this.dataGridView1.Columns[5].DefaultCellStyle.Format = "0,0";
                this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[5].Width = 90;

                this.dataGridView1.Columns[6].HeaderText = "Meta MP";
                this.dataGridView1.Columns[6].DefaultCellStyle.Format = "0,0";
                this.dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[6].Width = 90;

                this.dataGridView1.Columns[7].HeaderText = "Rendimiento PT";
                this.dataGridView1.Columns[7].DefaultCellStyle.Format = "0,0";
                this.dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[7].Width = 90;

                this.dataGridView1.Columns[8].HeaderText = "Rendimiento MP";
                this.dataGridView1.Columns[8].DefaultCellStyle.Format = "0,0";
                this.dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[8].Width = 90;

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
                    cCode = dataGridView1[0, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    cCode = "";

                }

            }

            if (cCode != "")
            {

                VariablesGlobales.glb_CardCode = cCode;

                FRP11 f2 = new FRP11();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_CardCode = "";

            }

            carga_grilla();

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_Temporadas_max();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            int n_Temporada, n_code;
            string c_name, c_turno;
            n_Temporada = 0;
            n_code = 0;

            try
            {
                n_Temporada = Convert.ToInt32(dTable.Rows[0]["Temporada"].ToString());
            }
            catch
            {
                n_Temporada = 2022;
            }


            try
            {
                n_code = Convert.ToInt32(dTable.Rows[0]["Code"].ToString());
            }
            catch
            {
                n_code = 0;
            }

            n_Temporada += 1;
            n_code += 1;

            c_name = "NCC" + n_code.ToString();

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de crear una nueva temporada", "Parametros", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            String mensaje1 = clsMaestros.SAPB1_OTEMPORADA_I(n_code.ToString(), c_name , n_Temporada.ToString(), "NCC");

            if (mensaje1 == "Y")
            {
                //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(mensaje1, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            VariablesGlobales.glb_CardCode = n_code.ToString();

            // Ahora proceso los detalles de temporada

            objproducto.cls_Consultar_Temporadas1_max();

            dTable = objproducto.cResultado;

            try
            {
                n_code = Convert.ToInt32(dTable.Rows[0]["Code"].ToString());
            }
            catch
            {
                n_code = 0;
            }

            objproducto.cls_Consultar_turnos_parametros();

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto.cResultado;


            for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            {

                try
                {
                    c_turno = dTable1.Rows[i]["FldValue"].ToString();
                }
                catch
                {
                    c_turno = "";
                }

                n_code += 1;
                c_name = "NCC" + n_code.ToString();

                String mensaje2 = clsMaestros.SAPB1_OTEMPORADA_A(n_code.ToString(), c_name, n_Temporada.ToString(), "NCC", c_turno);

                if (mensaje2 == "Y")
                {
                    //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensaje2, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }



            FRP11 f2 = new FRP11();
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

            string c_temporada;

            c_temporada = "";

            if (fila >= 0)
            {
                try
                {
                    c_temporada = dataGridView1[2, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    c_temporada = "";

                }

            }

            if (c_temporada != "")
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de eliminar esta temporada", "Parametros", buttons);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;

                }

                String mensaje1 = clsMaestros.SAPB1_OTEMPORADA_B(c_temporada);

                if (mensaje1 == "Y")
                {
                    //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensaje1, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                String mensaje2 = clsMaestros.SAPB1_OTEMPORADA_C(c_temporada);

                if (mensaje2 == "Y")
                {
                    //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensaje2, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

            carga_grilla();

        }
    }

}
