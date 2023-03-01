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
    public partial class frmCalidadPPB5 : Form
    {
        public frmCalidadPPB5()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB5_Load(object sender, EventArgs e)
        {

            txt_tipo_analisis_control.Text = VariablesGlobales.glb_Referencia1;

            cbb_TipoAnalisis.Enabled = false;

            if (txt_tipo_analisis_control.Text == "ALMENDRA")
            {
                cbb_TipoAnalisis.Enabled = true;

            }

            if (txt_tipo_analisis_control.Text == "NCC")
            {
                cbb_TipoAnalisis.Enabled = true;

            }

            ////////////////////////////////////////
            // Esto se hace para el tipo de Registro

            clsMaestros objproducto8 = new clsMaestros();
            objproducto8.cls_Consultar_AtributoCalidad_RI(txt_tipo_analisis_control.Text);

            cbb_TipoAnalisis.DataSource = objproducto8.cResultado;
            cbb_TipoAnalisis.ValueMember = "DocEntry";
            cbb_TipoAnalisis.DisplayMember = "U_Referencia";

            string cDocReferencia;

            cDocReferencia = "";

            if (cbb_TipoAnalisis.Enabled == true)
            {
                cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

            }
            else
            {
                cDocReferencia = "";

            }

            t_codatr.Text = VariablesGlobales.glb_CodAtr;

            String cNew_Atr, cTrans_Atr, cRef_Atr;
            int nFila;

            cNew_Atr = t_codatr.Text.Substring(0, 8);

            for (int i = 1; i <= 10 - 1; i++)
            {
                nFila = i;
                cTrans_Atr = cNew_Atr + "." + nFila.ToString();

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_Consultar_AtributoCalidad_RI2(cTrans_Atr, cDocReferencia);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cRef_Atr = dTable1.Rows[0]["U_CodAtr"].ToString();

                }
                catch
                {
                    cRef_Atr = "";

                }

                if (cRef_Atr == "")
                {
                    cNew_Atr = cTrans_Atr;
                    break;
                }

            }

            t_codatr_new.Text = cNew_Atr;



        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (t_atributo.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nLine_Id_new;

            clsMaestros objproducto0 = new clsMaestros();
            objproducto0.cls_Consultar_HDV_ATRP1_max_Id(t_codatr.Text);

            DataTable dTable0 = new DataTable();
            dTable0 = objproducto0.cResultado;

            try
            {
                nLine_Id_new = Convert.ToInt32(dTable0.Rows[0]["LineId_Max"].ToString());

            }
            catch
            {
                nLine_Id_new = 0;

            }

            String mensaje;

            mensaje = "";

            if (nLine_Id_new > 0)
            {
                nLine_Id_new += 1;

                mensaje = "";

                try
                {
                    mensaje = clsCalidad.SAPB1_Agregar_Atributo_ATRP1(t_codatr.Text, t_codatr_new.Text, t_atributo.Text, nLine_Id_new);
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_HDV_ATRP3_max_Id(t_codatr.Text);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                nLine_Id_new = Convert.ToInt32(dTable1.Rows[0]["LineId_Max"].ToString());

            }
            catch
            {
                nLine_Id_new = 0;

            }

            if (nLine_Id_new > 0)
            {
                nLine_Id_new += 1;

                mensaje = "";

                try
                {
                    mensaje = clsCalidad.SAPB1_Agregar_Atributo_ATRP1(t_codatr.Text, t_codatr_new.Text, t_atributo.Text, nLine_Id_new);
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            Close();

        }

    }

}
