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
    public partial class frmRomana2 : Form
    {
        public frmRomana2()
        {
            InitializeComponent();
        }

        private void frmRomana2_Load(object sender, EventArgs e)
        {
            t_menu.Text = VariablesGlobales.glb_Referencia1;

            dtp_fecha.Value = DateTime.Today;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana, nLineId;
            string cTipoPesaje;

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
            cTipoPesaje = "PESAJE DE ENTRADA";

            if (fila >= 0)
            {
                try
                {
                    cTipoPesaje = dataGridView1[0, fila].Value.ToString().ToUpper();
                }
                catch
                {
                    cTipoPesaje = "PESAJE DE ENTRADA";
                }

                try
                {
                    id_romana = Convert.ToInt32(dataGridView1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    id_romana = 0;

                }

                try
                {
                    nLineId = Convert.ToInt32(dataGridView1[24, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nLineId = 0;

                }


            }

            VariablesGlobales.glb_id_acceso = id_romana;
            VariablesGlobales.glb_LineId = nLineId;

            if (t_menu.Text == "Menu")
            {
                if (cTipoPesaje == "PESAJE DE ENTRADA")
                {
                    frmRomana f2 = new frmRomana();
                    DialogResult res = f2.ShowDialog();

                }
                else
                {
                    frmRomana4 f21 = new frmRomana4();
                    DialogResult res = f21.ShowDialog();

                }

                carga_grilla();

            }

            if (t_menu.Text == "Romana")
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

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_x_fecha(fecha);

                //this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Visible = true; //CardName
                this.dataGridView1.Columns[0].HeaderText = "Tipo de Pesaje";
                this.dataGridView1.Columns[0].Width = 120;


                this.dataGridView1.Columns[1].Visible = false; //id_romana
                this.dataGridView1.Columns[2].Visible = false; //CardCode

                this.dataGridView1.Columns[3].Visible = true; //CardName
                this.dataGridView1.Columns[3].HeaderText = "Productor";
                this.dataGridView1.Columns[3].Width = 300;

                this.dataGridView1.Columns[4].Visible = false; //ItemCode
                this.dataGridView1.Columns[5].Visible = false; //ItemName

                this.dataGridView1.Columns[6].Visible = true; //NumGuia
                this.dataGridView1.Columns[6].HeaderText = "Guía";
                this.dataGridView1.Columns[6].Width = 80;
                this.dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns[7].Visible = true; //Patente
                this.dataGridView1.Columns[7].HeaderText = "Patente";

                this.dataGridView1.Columns[8].Visible = false; //Envases

                this.dataGridView1.Columns[9].Visible = true; //FechaPeso1
                this.dataGridView1.Columns[9].HeaderText = "Fecha Ingreso";
                this.dataGridView1.Columns[9].Width = 120;

                this.dataGridView1.Columns[10].Visible = false; 
                this.dataGridView1.Columns[10].HeaderText = "Transportista";
                this.dataGridView1.Columns[10].Width = 300;

                this.dataGridView1.Columns[11].Visible = false; //Patente
                this.dataGridView1.Columns[12].Visible = false; //NumOC
                this.dataGridView1.Columns[13].Visible = false; //id_envase

                this.dataGridView1.Columns[14].Visible = true; //PesoBruto
                this.dataGridView1.Columns[14].HeaderText = "Peso Bruto";
                this.dataGridView1.Columns[14].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[14].Width = 90;

                this.dataGridView1.Columns[15].Visible = true; //PesoTara
                this.dataGridView1.Columns[15].HeaderText = "Peso Tara";
                this.dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[15].Width = 90;

                this.dataGridView1.Columns[16].Visible = true; //PesoNeto
                this.dataGridView1.Columns[16].HeaderText = "Peso Neto";
                this.dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[16].Width = 90;

                this.dataGridView1.Columns[17].Visible = false; //Obs
                this.dataGridView1.Columns[18].Visible = false; //FechaPeso1
                this.dataGridView1.Columns[19].Visible = false; //FechaPeso2
                this.dataGridView1.Columns[20].Visible = false; //id_acceso

                this.dataGridView1.Columns[21].Visible = true; //Conductor
                this.dataGridView1.Columns[21].HeaderText = "Conductor";
                this.dataGridView1.Columns[21].Width = 200;

                this.dataGridView1.Columns[22].Visible = false; //CardCode_trans
                this.dataGridView1.Columns[23].Visible = false; //CardName_trans

                this.dataGridView1.Columns[24].Visible = false; 
                this.dataGridView1.Columns[24].HeaderText = "LineId";
                this.dataGridView1.Columns[24].Width = 80;

                this.dataGridView1.Columns[25].Visible = true; 
                this.dataGridView1.Columns[25].HeaderText = "# Pesaje";
                this.dataGridView1.Columns[25].Width = 80;

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
