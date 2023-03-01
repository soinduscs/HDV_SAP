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
    public partial class frmCalidadMP9 : Form
    {
        public frmCalidadMP9()
        {
            InitializeComponent();
        }

        private void frmCalidadMP9_Load(object sender, EventArgs e)
        {
            t_DocEntry.Text = VariablesGlobales.glb_id_romana.ToString();
            t_Object.Text = VariablesGlobales.glb_Object;

            carga_grilla("R1", t_Object.Text, t_DocEntry.Text);
        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Registros_Inspeccion(accion, dato1, dato2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                string cDocEntry, cTipoRegistro, cItemName;
                string cStatusCalidad, cEstado, cCreator;
                string cItemCode;

                DateTime fecha;
                int fila;

                fila = 0;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["DocEntry"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cTipoRegistro = dTable.Rows[i]["TipoRegistro"].ToString();
                    }
                    catch
                    {
                        cTipoRegistro = "";

                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["U_ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["U_ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cCreator = dTable.Rows[i]["Creator"].ToString();

                    }
                    catch
                    {
                        cCreator = "";
                    }

                    try
                    {
                        cEstado = dTable.Rows[i]["U_Estado"].ToString();
                    }
                    catch
                    {
                        cEstado = "";
                    }

                    try
                    {
                        fecha = DateTime.Parse(dTable.Rows[i]["U_FecIngr"].ToString());

                    }
                    catch
                    {
                        fecha = DateTime.Parse("01/01/1900");

                    }

                    cStatusCalidad = "";

                    if (cEstado == "N")
                    {
                        cStatusCalidad = "Inspección en Proceso";
                    }

                    if (cEstado == "A")
                    {
                        cStatusCalidad = "Inspección Finalizada - Aprobado";
                    }

                    if (cEstado == "R")
                    {
                        cStatusCalidad = "Inspección Finalizada - Rechazado";
                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cTipoRegistro.ToString();
                    grilla[2] = cItemName.ToString();
                    grilla[3] = fecha.ToString("dd/MM/yyyy");
                    grilla[4] = cCreator.ToString();
                    grilla[5] = cStatusCalidad.ToString();

                    if (cItemCode.ToUpper() == VariablesGlobales.glb_ItemCode.ToUpper())
                    {
                        Grid1.Rows.Add(grilla);

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            Grid1[5, fila].Style.BackColor = Color.Yellow;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                        {
                            Grid1[5, fila].Style.BackColor = Color.Green;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                        {
                            Grid1[5, fila].Style.BackColor = Color.Red;
                        }

                        fila += 1;

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nIdCalidad;

            fila = 0;
            nIdCalidad = 0;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nIdCalidad = Convert.ToInt32(Grid1[0, fila].Value.ToString());

            }
            catch
            {
                nIdCalidad = -1;

            }

            VariablesGlobales.glb_id_calidad = nIdCalidad;
            VariablesGlobales.glb_Object = t_Object.Text;
            VariablesGlobales.glb_id_romana = Convert.ToInt32(t_DocEntry.Text);

            frmCalidadMP f2 = new frmCalidadMP();
            DialogResult res = f2.ShowDialog();

            carga_grilla("R1", t_Object.Text, t_DocEntry.Text);

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }
    }
}
