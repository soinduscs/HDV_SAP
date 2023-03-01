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
    public partial class frmOrdenFabricacion4 : Form
    {
        public frmOrdenFabricacion4()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion4_Load(object sender, EventArgs e)
        {
            t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();
            dtp_fecha_planificacion.Value = DateTime.Parse(VariablesGlobales.glb_Referencia1);

        }
        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            string cDocNum;
            DateTime dFechaPlanificacion;

            cDocNum = t_DocNum.Text;
            dFechaPlanificacion = dtp_fecha_planificacion.Value;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;           

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Realizar la coordinación de esta orden", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Insert_Coordinar_Orden_Fabricacion(cDocNum, dFechaPlanificacion.ToString("yyyyMMdd"), UsuarioSap, ClaveSap);

                MessageBox.Show("Registro Coordinado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }

        }
    }

}
