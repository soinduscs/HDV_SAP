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
    public partial class frmBinsProduccion : Form
    {
        public frmBinsProduccion()
        {
            InitializeComponent();
        }

        private void frmBinsProduccion_Load(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void carga_grilla()
        {

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Bins_Produccion();

                this.Grid1.DataSource = objproducto.cResultado;
                this.Grid1.RowHeadersWidth = 10;
                this.Grid1.Columns[0].HeaderText = "Código";
                this.Grid1.Columns[0].Width = 130;
                this.Grid1.Columns[1].Visible = false;
                this.Grid1.Columns[2].Visible = false;
                this.Grid1.Columns[3].HeaderText = "Descripción";
                this.Grid1.Columns[3].Width = 350;

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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            frmBinsProduccion1 f2 = new frmBinsProduccion1();
            DialogResult res = f2.ShowDialog();

            carga_grilla();

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

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

            string cItemCode;

            cItemCode = "";

            if (fila >= 0)
            {
                try
                {
                    cItemCode = Grid1[0, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    cItemCode = "";

                }

            }

            if (cItemCode != "")
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de desvincular este Registro", "Definición de Bins en Termination Reports", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    string mensaje;

                    try
                    {
                        mensaje = clsCalidad.U_Actualiza_Bins_Produccion(cItemCode, "E");

                    }
                    catch
                    {

                    }


                }

                carga_grilla();

            }

        }
        
    }

}
