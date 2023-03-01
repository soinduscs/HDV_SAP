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
    public partial class frmPorteria4 : Form
    {
        public frmPorteria4()
        {
            InitializeComponent();
        }

        private void frmPorteria4_Load(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void carga_grilla()
        {
            string valor, valor1, cardcode;
            int numero;

            valor = "";
            valor1 = "";
            cardcode = "";
            numero = 0;

            valor = VariablesGlobales.glb_Busqueda_Variable;
            cardcode = VariablesGlobales.glb_CardCode; 

            if (valor == "DocNum")
            {
                numero = 0;

                try
                {
                    numero = Convert.ToInt32(VariablesGlobales.glb_Busqueda_Valor);
                }
                catch
                {
                    numero = 0;
                }
                
            }
            else
            {
                valor1 = VariablesGlobales.glb_Busqueda_Valor;

            }

            try
            {

                clsPorteria objproducto = new clsPorteria();
                
                //this.Dock = DockStyle.Fill;
                if (valor == "DocNum")
                {
                    objproducto.cls_Consultar_Accesos_x_Numero(valor, numero, cardcode);

                }

                //this.Dock = DockStyle.Fill;
                if (valor != "DocNum")
                {
                    objproducto.cls_Consultar_Accesos_x_Caracter(valor, valor1);

                }

                this.dataGridView1.DataSource = objproducto.cResultado;

                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].Visible = false;
                this.dataGridView1.Columns[2].HeaderText = "Productor";
                this.dataGridView1.Columns[2].Width = 300;
                this.dataGridView1.Columns[3].HeaderText = "Patente";
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderText = "Guía";
                this.dataGridView1.Columns[4].Width = 80;
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[5].HeaderText = "Fecha Ingreso";
                this.dataGridView1.Columns[5].Width = 120;
                this.dataGridView1.Columns[6].Visible = false;
                this.dataGridView1.Columns[7].HeaderText = "Conductor";
                this.dataGridView1.Columns[7].Width = 200;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].HeaderText = "Transportista";
                this.dataGridView1.Columns[9].Width = 300;
                this.dataGridView1.Columns[10].Visible = false;
                this.dataGridView1.Columns[11].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[13].Visible = false;

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
