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
    public partial class FRP11 : Form
    {
        public FRP11()
        {
            InitializeComponent();
        }

        private void FRP11_Load(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_CardCode != "")
            {
                t_code.Text = VariablesGlobales.glb_CardCode;

                carga_datos(t_code.Text);

                carga_grilla();
            }
            else
            {

            }

        }

        private void carga_grilla()
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_Temporadas_turnos_x_temporada(t_temporada.Text, "NCC");

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            double n_meta_pt, n_meta_mp;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    grilla[0] = dTable.Rows[i]["Code"].ToString();
                }
                catch
                {
                    grilla[0] = "";
                }

                try
                {
                    grilla[1] = dTable.Rows[i]["U_Turno"].ToString();
                }
                catch
                {
                    grilla[1] = "";
                }

                n_meta_pt = 0;
                n_meta_mp = 0;

                try
                {
                    n_meta_pt = Convert.ToDouble(dTable.Rows[i]["U_Meta_PT"].ToString());
                }
                catch
                {
                    n_meta_pt = 0;

                }

                grilla[2] = n_meta_pt.ToString("N");

                try
                {
                    n_meta_mp = Convert.ToDouble(dTable.Rows[i]["U_Meta_MP"].ToString());
                }
                catch
                {
                    n_meta_mp = 0;

                }

                grilla[3] = n_meta_mp.ToString("N");

                Grid1.Rows.Add(grilla);

            }

        }

        private void carga_datos(string c_code)
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_Temporadas_x_id(c_code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            double n_horas;
            double n_meta_pt, n_meta_mp;
            double n_rendim_pt, n_rendim_mp;
            int n_dias_semana, n_dias_mes;

            n_horas = 0;
            n_meta_pt = 0; 
            n_meta_mp = 0;
            n_rendim_pt = 0;
            n_rendim_mp = 0;
            n_dias_semana = 0;
            n_dias_mes = 0;

            try
            {
                t_temporada.Text = dTable.Rows[0]["U_Temporada"].ToString();
            }
            catch
            {
                t_temporada.Text = "";
            }

            try
            {
                dtp_fecha_ini.Value = Convert.ToDateTime(dTable.Rows[0]["U_Fecha_Ini"].ToString());
            }
            catch
            {
                //dtp_fecha_ini.Value = DateTime.Now();

            }

            try
            {
                n_horas = Convert.ToDouble(dTable.Rows[0]["U_Hora_Tot"].ToString());
            }
            catch
            {
                n_horas = 0;

            }

            t_horas_tot.Text = n_horas.ToString("N2");

            try
            {
                n_dias_semana = Convert.ToInt16(dTable.Rows[0]["U_Dias_Semana"].ToString());
            }
            catch
            {
                n_dias_semana = 0;

            }

            t_dias_semana.Text = n_dias_semana.ToString("0");

            try
            {
                n_dias_mes = Convert.ToInt16(dTable.Rows[0]["U_Dias_Mes"].ToString());
            }
            catch
            {
                n_dias_mes = 0;

            }

            t_dias_mes.Text = n_dias_mes.ToString("0");

            try
            {
                n_meta_pt = Convert.ToDouble(dTable.Rows[0]["U_Meta_PT"].ToString());
            }
            catch
            {
                n_meta_pt = 0;

            }

            t_meta_pt.Text = n_meta_pt.ToString("0,0");

            try
            {
                n_meta_mp = Convert.ToDouble(dTable.Rows[0]["U_Meta_MP"].ToString());
            }
            catch
            {
                n_meta_mp = 0;

            }

            t_meta_mp.Text = n_meta_mp.ToString("0,0");

            try
            {
                n_rendim_pt = Convert.ToDouble(dTable.Rows[0]["U_Rendim_PT"].ToString());
            }
            catch
            {
                n_rendim_pt = 0;

            }

            t_rendimiento_pt.Text = n_rendim_pt.ToString("0,0");

            try
            {
                n_rendim_mp = Convert.ToDouble(dTable.Rows[0]["U_Rendim_MP"].ToString());
            }
            catch
            {
                n_rendim_mp = 0;

            }

            t_rendimiento_mp.Text = n_rendim_mp.ToString("0,0");


        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            string c_code;
            int n_dias_semana, n_dias_mes;
            double n_horas, n_Meta_PT, n_Meta_MP;
            double n_Rendim_PT, n_Rendim_MP;

            try
            {
                c_code = t_code.Text;
            }
            catch
            {
                c_code = "";
            }

            n_horas = 0;
            n_Meta_PT = 0;
            n_Meta_MP = 0;
            n_Rendim_PT = 0;
            n_Rendim_MP = 0;
            n_dias_semana = 0;
            n_dias_mes = 0;

            try
            {
                n_horas = Convert.ToDouble(t_horas_tot.Text);
            }
            catch
            {
                n_horas = 0;
            }

            try
            {
                n_dias_semana = Convert.ToInt16(t_dias_semana.Text);
            }
            catch
            {
                n_dias_semana = 0;
            }

            try
            {
                n_dias_mes = Convert.ToInt16(t_dias_mes.Text);
            }
            catch
            {
                n_dias_mes = 0;
            }

            try
            {
                n_Meta_PT = Convert.ToDouble(t_meta_pt.Text);
            }
            catch
            {
                n_Meta_PT = 0;
            }

            try
            {
               n_Meta_MP  = Convert.ToDouble(t_meta_mp.Text);
            }
            catch
            {
                n_Meta_MP = 0;
            }

            try
            {
                n_Rendim_PT = Convert.ToDouble(t_rendimiento_pt.Text);
            }
            catch
            {
                n_Rendim_PT = 0;
            }

            try
            {
                n_Rendim_MP = Convert.ToDouble(t_rendimiento_mp.Text);
            }
            catch
            {
                n_Rendim_MP = 0;
            }

            if (c_code != "")
            {
                if (n_horas > 0)
                {

                    String mensaje1 = clsMaestros.SAPB1_OTEMPORADA(c_code, t_temporada.Text , dtp_fecha_ini.Value, n_horas, n_dias_semana, n_dias_mes, n_Meta_PT, n_Meta_MP, n_Rendim_PT, n_Rendim_MP);

                    if (mensaje1 == "Y")
                    {
                        //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(mensaje1, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            Double n_turno_meta_pt, n_turno_meta_mp;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    c_code = Grid1[0, i].Value.ToString();

                }
                catch
                {
                    c_code = "0";

                }

                try
                {
                    n_turno_meta_pt = Convert.ToDouble(Grid1[2, i].Value.ToString());

                }
                catch
                {
                    n_turno_meta_pt = 0;

                }

                try
                {
                    n_turno_meta_mp = Convert.ToDouble(Grid1[3, i].Value.ToString());

                }
                catch
                {
                    n_turno_meta_mp = 0;

                }

                String mensaje2 = clsMaestros.SAPB1_TEMPORADA1(c_code, n_turno_meta_pt, n_turno_meta_mp);

                if (mensaje2 == "Y")
                {
                    //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensaje2, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void t_horas_tot_Leave(object sender, EventArgs e)
        {
            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_horas_tot.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_horas_tot.Text = n_valor.ToString("N2");

        }

        private void t_meta_pt_Leave(object sender, EventArgs e)
        {
            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_meta_pt.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_meta_pt.Text = n_valor.ToString("0,0");

        }

        private void t_meta_mp_Leave(object sender, EventArgs e)
        {
            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_meta_mp.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_meta_mp.Text = n_valor.ToString("0,0");

        }

        private void t_rendimiento_pt_Leave(object sender, EventArgs e)
        {
            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_rendimiento_pt.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_rendimiento_pt.Text = n_valor.ToString("0,0");

        }

        private void t_rendimiento_mp_Leave(object sender, EventArgs e)
        {
            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_rendimiento_mp.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_rendimiento_mp.Text = n_valor.ToString("0,0");

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil;
            double n_Meta_PT, n_Meta_MP;

            fil = 0;
            n_Meta_PT = 0;
            n_Meta_MP = 0;

            try
            {
                fil = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                n_Meta_PT = Convert.ToDouble(Grid1[2, fil].Value);

            }
            catch
            {
                n_Meta_PT = 0;

            }

            Grid1[2, fil].Value = n_Meta_PT.ToString("N");

            try
            {
                n_Meta_MP = Convert.ToDouble(Grid1[3, fil].Value);

            }
            catch
            {
                n_Meta_MP = 0;

            }

            Grid1[3, fil].Value = n_Meta_MP.ToString("N");

        }

        private void t_dias_semana_Leave(object sender, EventArgs e)
        {
            int n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToInt16(t_dias_semana.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_dias_semana.Text = n_valor.ToString("0");

        }

        private void t_dias_mes_Leave(object sender, EventArgs e)
        {
            int n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToInt16(t_dias_mes.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_dias_mes.Text = n_valor.ToString("0");

        }
    }

}

