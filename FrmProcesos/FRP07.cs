using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmProcesos
{
    public partial class FRP07 : Form
    {
        public FRP07()
        {
            InitializeComponent();
        }

        private void FRP07_Load(object sender, EventArgs e)
        {

            float nPorcentajeDesviacion, nValor;
            string cBloqueo;

            clsRomana objproducto1 = new clsRomana();
            objproducto1.cls_Consulta_tabla_parametros();

            DataTable dTable = new DataTable();
            dTable = objproducto1.cResultado;

            try
            {
                nPorcentajeDesviacion = float.Parse(dTable.Rows[0]["U_Por_Tolerancia_Romana"].ToString());

            }
            catch
            {
                nPorcentajeDesviacion = 0;

            }

            t_porcentaje_desviacion.Text = nPorcentajeDesviacion.ToString("N");

            try
            {
                nPorcentajeDesviacion = float.Parse(dTable.Rows[0]["U_Por_Tolerancia_Romana2"].ToString());

            }
            catch
            {
                nPorcentajeDesviacion = 0;

            }

            t_porcentaje_desviacion2.Text = nPorcentajeDesviacion.ToString("N");

            try
            {
                cBloqueo = dTable.Rows[0]["U_Tolerancia_de_Bloqueo"].ToString();

            }
            catch
            {
                cBloqueo = "";

            }

            if (cBloqueo == "Y")
            {
                chk_de_bloqueo.Checked = true;

            }
            else
            {
                chk_de_bloqueo.Checked = false;

            }

            try
            {
                cBloqueo = dTable.Rows[0]["U_Tolerancia_de_Bloqueo2"].ToString();

            }
            catch
            {
                cBloqueo = "";

            }

            if (cBloqueo == "Y")
            {
                chk_de_bloqueo2.Checked = true;

            }
            else
            {
                chk_de_bloqueo2.Checked = false;

            }

            try
            {
                nValor = float.Parse(dTable.Rows[0]["U_Muestra_Calidad_NUE_FP"].ToString());

            }
            catch
            {
                nValor = 0;

            }

            t_nue_fp.Text = nValor.ToString();

            try
            {
                nValor = float.Parse(dTable.Rows[0]["U_Muestra_Calidad_NUE_FS"].ToString());

            }
            catch
            {
                nValor = 0;

            }

            t_nue_fs.Text = nValor.ToString();

            try
            {
                nValor = float.Parse(dTable.Rows[0]["U_Muestra_Calidad_ALM_FP"].ToString());

            }
            catch
            {
                nValor = 0;

            }

            t_alm_fp.Text = nValor.ToString();

            try
            {
                nValor = float.Parse(dTable.Rows[0]["U_Muestra_Calidad_ALM_FS"].ToString());

            }
            catch
            {
                nValor = 0;

            }

            t_alm_fs.Text = nValor.ToString();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            float nPesoNetoBD, nPesoNetoBD2;
            float nCalidad_nue_fp, nCalidad_nue_fs;
            float nCalidad_alm_fp, nCalidad_alm_fs;
            string mensaje2, cBloquea, cBloquea2;

            nPesoNetoBD = 0;
            mensaje2 = "";
            cBloquea = "N";
            cBloquea2 = "N";
            nCalidad_nue_fp = 0;
            nCalidad_nue_fs = 0;
            nCalidad_alm_fp = 0;
            nCalidad_alm_fs = 0;

            try
            {
                nPesoNetoBD = float.Parse(t_porcentaje_desviacion.Text);

            }
            catch
            {
                nPesoNetoBD = 0;

            }

            try
            {
                nPesoNetoBD2 = float.Parse(t_porcentaje_desviacion2.Text);

            }
            catch
            {
                nPesoNetoBD2 = 0;

            }

            if (chk_de_bloqueo.Checked == true)
            {
                cBloquea = "Y";

            }

            if (chk_de_bloqueo2.Checked == true)
            {
                cBloquea2 = "Y";

            }

            try
            {
                nCalidad_nue_fp = float.Parse(t_nue_fp.Text);

            }
            catch
            {
                nCalidad_nue_fp = 0;

            }
            
            try
            {
                nCalidad_nue_fs = float.Parse(t_nue_fs.Text);

            }
            catch
            {
                nCalidad_nue_fs = 0;

            }

            try
            {
                nCalidad_alm_fp = float.Parse(t_alm_fp.Text);

            }
            catch
            {
                nCalidad_alm_fp = 0;

            }

            try
            {
                nCalidad_alm_fs = float.Parse(t_alm_fs.Text);

            }
            catch
            {
                nCalidad_alm_fs = 0;

            }

            if (nPesoNetoBD > 0)
            {
                mensaje2 = clsRomana.SAPB1_OPARAM(nPesoNetoBD, nPesoNetoBD2, cBloquea, cBloquea2, nCalidad_nue_fp, nCalidad_nue_fs, nCalidad_alm_fp, nCalidad_alm_fs);

                MessageBox.Show("Registro Grabado", "Configuración General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }

        }

        private void t_porcentaje_desviacion_Leave(object sender, EventArgs e)
        {
            double nPorcentajeTolerancia;

            try
            {
                nPorcentajeTolerancia = Convert.ToDouble(t_porcentaje_desviacion.Text);

            }
            catch
            {
                nPorcentajeTolerancia = 0;

            }

            t_porcentaje_desviacion.Text = nPorcentajeTolerancia.ToString("N");

        }

        private void t_porcentaje_desviacion2_Leave(object sender, EventArgs e)
        {

            double nPorcentajeTolerancia;

            try
            {
                nPorcentajeTolerancia = Convert.ToDouble(t_porcentaje_desviacion2.Text);

            }
            catch
            {
                nPorcentajeTolerancia = 0;

            }

            t_porcentaje_desviacion2.Text = nPorcentajeTolerancia.ToString("N");

        }

        private void t_nue_fp_Leave(object sender, EventArgs e)
        {

            double nValor;

            try
            {
                nValor = Convert.ToDouble(t_nue_fp.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_nue_fp.Text = nValor.ToString();

        }

        private void t_nue_fs_Leave(object sender, EventArgs e)
        {

            double nValor;

            try
            {
                nValor = Convert.ToDouble(t_nue_fs.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_nue_fs.Text = nValor.ToString();

        }

        private void t_alm_fp_Leave(object sender, EventArgs e)
        {

            double nValor;

            try
            {
                nValor = Convert.ToDouble(t_alm_fp.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_alm_fp.Text = nValor.ToString();

        }

        private void t_alm_fs_Leave(object sender, EventArgs e)
        {

            double nValor;

            try
            {
                nValor = Convert.ToDouble(t_alm_fs.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_alm_fs.Text = nValor.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FRP08 f2 = new FRP08();
            DialogResult res = f2.ShowDialog();

        }

    }

}
