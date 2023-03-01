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
    public partial class frmBinsProduccion1 : Form
    {
        public frmBinsProduccion1()
        {
            InitializeComponent();
        }

        private void frmBinsProduccion1_Load(object sender, EventArgs e)
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_Bins_Produccion1();

            cbb_bins.DataSource = objproducto.cResultado;
            cbb_bins.ValueMember = "ItemCode";
            cbb_bins.DisplayMember = "ItemName2";


        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            string cItemCode, mensaje;

            cItemCode = "";

            try
            {
                cItemCode = cbb_bins.SelectedValue.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            if (cItemCode == "")
            {
                MessageBox.Show("Debe seleccionar un bins válido", "Bins de Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                mensaje = clsCalidad.U_Actualiza_Bins_Produccion(cItemCode, "I");

            }
            catch
            {

            }

            Close();

        }
    }
}
