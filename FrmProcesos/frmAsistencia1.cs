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
    public partial class frmAsistencia1 : Form
    {
        public frmAsistencia1()
        {
            InitializeComponent();
        }

        private void frmAsistencia1_Load(object sender, EventArgs e)
        {
            cbb_anho.SelectedIndex = 1;

            cbb_semana.Items.Clear();

            for (int i = 1; i <= 53; i++)
            {
                cbb_semana.Items.Add(i.ToString());

            }

            int nNumSemana;

            nNumSemana = 0;

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_consulta_numero_semana_actual();

            DataTable dTable = new DataTable();
            dTable = objproducto1.cResultado;

            try
            {
                nNumSemana = Convert.ToInt32(dTable.Rows[0]["NumSemana_Actual"].ToString());
            }
            catch
            {
                nNumSemana = 0;
            }

            cbb_semana.SelectedIndex = nNumSemana - 1;


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            try
            {
                int nNumSemana, nAnho;

                if (cbb_semana.SelectedIndex < 0)
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

                nNumSemana = cbb_semana.SelectedIndex + 1;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_xSapb1_utiles_muestratarjaporperiodo( "R" , nNumSemana, nAnho, "", "");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nLun, nMar, nMie, nJue, nVie;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["ccosto"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["do_dependencia1"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["nom_ccosto"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["nom_dependencia1"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    nLun = 0;
                    nMar = 0;
                    nMie = 0;
                    nJue = 0;
                    nVie = 0;

                    try
                    {
                        nLun = Int32.Parse(dTable.Rows[i]["dia_Lu"].ToString());
                    }
                    catch
                    {
                        nLun = 0;
                    }

                    try
                    {
                        nMar = Int32.Parse(dTable.Rows[i]["dia_Ma"].ToString());
                    }
                    catch
                    {
                        nMar = 0;
                    }

                    try
                    {
                        nMie = Int32.Parse(dTable.Rows[i]["dia_Mi"].ToString());
                    }
                    catch
                    {
                        nMie = 0;
                    }

                    try
                    {
                        nJue = Int32.Parse(dTable.Rows[i]["dia_Ju"].ToString());
                    }
                    catch
                    {
                        nJue = 0;
                    }

                    try
                    {
                        nVie = Int32.Parse(dTable.Rows[i]["dia_Vi"].ToString());
                    }
                    catch
                    {
                        nVie = 0;
                    }

                    grilla[4] = "Lu";
                    grilla[5] = "Ma";
                    grilla[6] = "Mi";
                    grilla[7] = "Ju";
                    grilla[8] = "Vi";

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbb_semana_SelectedIndexChanged(object sender, EventArgs e)
        {
            carga_rango_de_fechas();

        }

        private void carga_rango_de_fechas()
        {

            int nNumSemana, nAnho;

            t_fecha_desde.Text = "";
            t_fecha_hasta.Text = "";

            if (cbb_semana.SelectedIndex >= 0)
            {
                try
                {
                    nAnho = Convert.ToInt32(cbb_anho.Text);
                }
                catch
                {
                    nAnho = 2019;
                }

                DateTime dFechaIni, dFechaFin;

                nNumSemana = cbb_semana.SelectedIndex + 1;

                clsProduccion objproducto1 = new clsProduccion();
                objproducto1.cls_consulta_fechas_por_semana(nNumSemana, nAnho);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;

                try
                {
                    dFechaIni = Convert.ToDateTime(dTable.Rows[0]["FechaIni"].ToString());
                }
                catch
                {
                    dFechaIni = Convert.ToDateTime("01/01/1900");
                }

                try
                {
                    dFechaFin = Convert.ToDateTime(dTable.Rows[0]["FechaFin"].ToString());
                }
                catch
                {
                    dFechaFin = Convert.ToDateTime("01/01/1900");
                }

                t_fecha_desde.Text = dFechaIni.ToString("dd/MM/yyyy");
                t_fecha_hasta.Text = dFechaFin.ToString("dd/MM/yyyy");

            }

        }

        private void cbb_anho_SelectedIndexChanged(object sender, EventArgs e)
        {
            carga_rango_de_fechas();

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {

        }
    }

}
