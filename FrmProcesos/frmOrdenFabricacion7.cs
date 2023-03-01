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
    public partial class frmOrdenFabricacion7 : Form
    {
        public frmOrdenFabricacion7()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion7_Load(object sender, EventArgs e)
        {
            t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();
            dtp_fecha_planificacion.Value = DateTime.Now;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Referencia1 = "._.";
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

            result = MessageBox.Show("Esta Seguro de Modificar la Fecha de Cierre", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Modificar_fecha_finalizacion_Orden_Fabricacion(cDocNum, dFechaPlanificacion.ToString("yyyyMMdd"), UsuarioSap, ClaveSap);
                VariablesGlobales.glb_Referencia1 = "";

                Close();

            }

        }
    }
}
