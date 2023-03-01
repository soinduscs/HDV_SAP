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
    public partial class frmCalidadPPA8 : Form
    {
        public frmCalidadPPA8()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA8_Load(object sender, EventArgs e)
        {

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos2();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "FldValue";
            cbb_procesos.DisplayMember = "Descr";

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string cCode, cProceso;

            try
            {
                cCode = VariablesGlobales.glb_Object;

            }
            catch
            {
                cCode = "";
            }

            if (cCode == "")
            {
                MessageBox.Show("Debe seleccionar una matriz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cProceso = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cProceso = "";

            }

            if (cProceso == "")
            {
                MessageBox.Show("Debe seleccionar un proceso válido", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nCode;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_max_ATRP8();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nCode = Convert.ToInt32(dTable.Rows[0]["mCode"].ToString());
            }
            catch
            {
                nCode = 0;

            }

            nCode += 1;

            //////////////////////////////////////
            // Genero el avance de proceso

            String mensaje;

            mensaje = "";

            try
            {
                mensaje = clsCalidad.SAPB1_ATRP8(nCode.ToString(), cProceso, cCode);
            }
            catch
            {
                MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Close();

        }

    }

}
