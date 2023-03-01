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
    public partial class frmOrdenFabricacionTrz2 : Form
    {
        public frmOrdenFabricacionTrz2()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTrz2_Load(object sender, EventArgs e)
        {

            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_descripcion.Text = VariablesGlobales.glb_ItemName;
            t_lote.Text = VariablesGlobales.glb_Lote.ToString();

            carga_grilla();

        }

        private void carga_grilla()
        {

            Grid1.Rows.Clear();

            string clote;

            try
            {
                clote = t_lote.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_Consulta_historial_fumigacion(clote);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                string ctipo, creferencia;
                DateTime dFecha;
                 
                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        ctipo = dTable.Rows[i]["U_Fumigado"].ToString();
                    }
                    catch
                    {
                        ctipo = "";
                    }

                    try
                    {
                        creferencia = dTable.Rows[i]["U_Referencia"].ToString();
                    }
                    catch
                    {
                        creferencia = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    grilla[0] = ctipo;

                    if (dFecha.ToString("yyyy") == "1900")
                    {
                        grilla[1] = "";
                    }
                    else
                    {
                        grilla[1] = dFecha.ToString("dd/MM/yyyy");
                    }

                    grilla[2] = creferencia;

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
