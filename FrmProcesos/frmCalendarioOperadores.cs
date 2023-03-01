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
    public partial class frmCalendarioOperadores : Form
    {
        public frmCalendarioOperadores()
        {
            InitializeComponent();
        }

        private void frmCalendarioOperadores_Load(object sender, EventArgs e)
        {
            cbb_anho.Items.Clear();

            DateTime fecha = DateTime.Now;

            cbb_anho.Items.Add(((fecha.Year) - 1).ToString());
            cbb_anho.Items.Add(fecha.Year.ToString());
            cbb_anho.Items.Add(((fecha.Year) + 1).ToString());

            cbb_anho.SelectedIndex = 1;
            cbb_mes.SelectedIndex = fecha.Month - 1; 

            // *********************************************
            // Almendra

            clsProduccion objproducto4 = new clsProduccion();
            objproducto4.cls_consulta_lista_de_operadores();

            DataGridViewComboBoxColumn my_DGVCboColumn4 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn4.DataSource = objproducto4.cResultado;
            my_DGVCboColumn4.Name = "Mañana";
            my_DGVCboColumn4.ValueMember = "Code";
            my_DGVCboColumn4.DisplayMember = "Code";

            Grid1.Columns.RemoveAt(2);
            Grid1.Columns.Insert(2, my_DGVCboColumn4);
            Grid1.Columns[2].Width = 110;

            DataGridViewComboBoxColumn my_DGVCboColumn5 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn5.DataSource = objproducto4.cResultado;
            my_DGVCboColumn5.Name = "Tarde";
            my_DGVCboColumn5.ValueMember = "Code";
            my_DGVCboColumn5.DisplayMember = "Code";

            Grid1.Columns.RemoveAt(3);
            Grid1.Columns.Insert(3, my_DGVCboColumn5);
            Grid1.Columns[3].Width = 110;

            DataGridViewComboBoxColumn my_DGVCboColumn6 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn6.DataSource = objproducto4.cResultado;
            my_DGVCboColumn6.Name = "Noche";
            my_DGVCboColumn6.ValueMember = "Code";
            my_DGVCboColumn6.DisplayMember = "Code";

            Grid1.Columns.RemoveAt(4);
            Grid1.Columns.Insert(4, my_DGVCboColumn6);
            Grid1.Columns[4].Width = 110;

            // *********************************************
            // Nuez

            DataGridViewComboBoxColumn my_DGVCboColumn7 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn7.DataSource = objproducto4.cResultado;
            my_DGVCboColumn7.Name = "Mañana";
            my_DGVCboColumn7.ValueMember = "Code";
            my_DGVCboColumn7.DisplayMember = "Code";

            Grid2.Columns.RemoveAt(2);
            Grid2.Columns.Insert(2, my_DGVCboColumn7);
            Grid2.Columns[2].Width = 110;

            DataGridViewComboBoxColumn my_DGVCboColumn8 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn8.DataSource = objproducto4.cResultado;
            my_DGVCboColumn8.Name = "Tarde";
            my_DGVCboColumn8.ValueMember = "Code";
            my_DGVCboColumn8.DisplayMember = "Code";

            Grid2.Columns.RemoveAt(3);
            Grid2.Columns.Insert(3, my_DGVCboColumn8);
            Grid2.Columns[3].Width = 110;

            DataGridViewComboBoxColumn my_DGVCboColumn9 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn9.DataSource = objproducto4.cResultado;
            my_DGVCboColumn9.Name = "Noche";
            my_DGVCboColumn9.ValueMember = "Code";
            my_DGVCboColumn9.DisplayMember = "Code";

            Grid2.Columns.RemoveAt(4);
            Grid2.Columns.Insert(4, my_DGVCboColumn9);
            Grid2.Columns[4].Width = 110;

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            try
            {
                int nMes, nAnho;

                if (cbb_mes.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un número de semana válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    nAnho = Convert.ToInt32(cbb_anho.Text);
                }
                catch
                {
                    nAnho = 2019;
                }

                nMes = cbb_mes.SelectedIndex + 1;

                DateTime dLunes, dDomingo; 

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_xSapb1_query_turnoscracker(nAnho, nMes, "ALM");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["semana"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        dLunes = Convert.ToDateTime(dTable.Rows[i]["lunes"].ToString());
                    }
                    catch
                    {
                        dLunes = Convert.ToDateTime("01/01/1900");
                    }

                    try
                    {
                        dDomingo = Convert.ToDateTime(dTable.Rows[i]["domingo"].ToString());
                    }
                    catch
                    {
                        dDomingo = Convert.ToDateTime("01/01/1900");
                    }

                    grilla[1] = "del " + dLunes.ToString("dd/MM/yyyy") + " al " + dDomingo.ToString("dd/MM/yyyy"); // convert. dDomingo

                    try
                    {
                        grilla[2] = dTable.Rows[i]["Turno_1"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["Turno_2"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["Turno_3"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                int nMes, nAnho;

                if (cbb_mes.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un número de semana válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    nAnho = Convert.ToInt32(cbb_anho.Text);
                }
                catch
                {
                    nAnho = 2019;
                }

                nMes = cbb_mes.SelectedIndex + 1;

                DateTime dLunes, dDomingo;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_xSapb1_query_turnoscracker(nAnho, nMes, "NUE");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["semana"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        dLunes = Convert.ToDateTime(dTable.Rows[i]["lunes"].ToString());
                    }
                    catch
                    {
                        dLunes = Convert.ToDateTime("01/01/1900");
                    }

                    try
                    {
                        dDomingo = Convert.ToDateTime(dTable.Rows[i]["domingo"].ToString());
                    }
                    catch
                    {
                        dDomingo = Convert.ToDateTime("01/01/1900");
                    }

                    grilla[1] = "del " + dLunes.ToString("dd/MM/yyyy") + " al " + dDomingo.ToString("dd/MM/yyyy"); // convert. dDomingo

                    try
                    {
                        grilla[2] = dTable.Rows[i]["Turno_1"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["Turno_2"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["Turno_3"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    Grid2.Rows.Add(grilla);

                }

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

        private void btn_ok_Click(object sender, EventArgs e)
        {

            int nMes, nAnho, nSemana;
            string cOperador, mensaje;

            if (cbb_mes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un número de semana válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nAnho = Convert.ToInt32(cbb_anho.Text);
            }
            catch
            {
                nAnho = 2019;
            }

            nMes = cbb_mes.SelectedIndex + 1;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nSemana = 0;
                cOperador = "";

                try
                {
                    nSemana = Convert.ToInt32(Grid1[0, i].Value.ToString());

                }
                catch
                {
                    nSemana = 0;

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "E", nSemana, nAnho, "ALM", "1", "");

                try
                {
                    cOperador = Grid1[2, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A" , nSemana , nAnho , "ALM" , "1" , cOperador);

                try
                {
                    cOperador = Grid1[3, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A", nSemana, nAnho, "ALM", "2", cOperador);

                try
                {
                    cOperador = Grid1[4, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A", nSemana, nAnho, "ALM", "3", cOperador);

            }


            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                nSemana = 0;
                cOperador = "";

                try
                {
                    nSemana = Convert.ToInt32(Grid2[0, i].Value.ToString());

                }
                catch
                {
                    nSemana = 0;

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "E", nSemana, nAnho, "NUE", "1", "");

                try
                {
                    cOperador = Grid2[2, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A", nSemana, nAnho, "NUE", "1", cOperador);

                try
                {
                    cOperador = Grid2[3, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A", nSemana, nAnho, "NUE", "2", cOperador);

                try
                {
                    cOperador = Grid2[4, i].Value.ToString();

                }
                catch
                {
                    cOperador = "";

                }

                mensaje = clsCalidad.SAPB1_OPR1(0, "A", nSemana, nAnho, "NUE", "3", cOperador);

            }

        }

    }

}
