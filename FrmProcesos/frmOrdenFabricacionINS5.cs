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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace FrmProcesos
{
    public partial class frmOrdenFabricacionINS5 : Form
    {
        public frmOrdenFabricacionINS5()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionINS5_Load(object sender, EventArgs e)
        {

            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1.Value;

                string cfecha1, cfecha2;
                int nDocEntryRef;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_DeclaracionInsumosv2(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry, nUserSign;
                double nCantidad;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        grilla[2] = dTable.Rows[i]["U_AreaName"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_TurnoName"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["Nombre_Empleado"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        nCantidad = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["Cant_Items"].ToString()));
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    grilla[5] = nCantidad.ToString("N");

                    try
                    {
                        grilla[6] = dTable.Rows[i]["Status_Name"].ToString();
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[7] = dTable.Rows[i]["Nombre_Autorizador"].ToString();
                    }
                    catch
                    {
                        grilla[7] = "";
                    }

                    try
                    {
                        nUserSign = Convert.ToInt32(dTable.Rows[i]["UserSign"].ToString());
                    }
                    catch
                    {
                        nUserSign = 0;
                    }

                    try
                    {
                        nDocEntryRef = Convert.ToInt32(dTable.Rows[i]["U_DocEntryRef"].ToString());

                    }
                    catch
                    {
                        nDocEntryRef = 0;

                    }

                    grilla[8] = nDocEntryRef.ToString();

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {

            string declaracion_mermas, autorizacion_mermas;

            declaracion_mermas = "";
            autorizacion_mermas = "";

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                declaracion_mermas = dTable.Rows[0]["Declarar_Mermas"].ToString();
            }
            catch
            {
                declaracion_mermas = "";
            }

            try
            {
                autorizacion_mermas = dTable.Rows[0]["Autorizar_Mermas"].ToString();
            }
            catch
            {
                autorizacion_mermas = "";
            }

            if (declaracion_mermas != "SI")
            {
                MessageBox.Show("No tiene los permisos suficientes para realizar esta actividad, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fil, nDocEntry;

            fil = 0;

            nDocEntry = -1;

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
                nDocEntry = Convert.ToInt32(Grid1[0, fil].Value.ToString());
            }
            catch
            {
                nDocEntry = -1;
            }

            if (nDocEntry == -1)
            {
                MessageBox.Show("Debe seleccionar una línea válida, opción Cancelada", "Declaración de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            //frmOrdenFabricacionINS2 f2 = new frmOrdenFabricacionINS2();
            frmOrdenFabricacionINS4 f2 = new frmOrdenFabricacionINS4();
            DialogResult res = f2.ShowDialog();

            carga_grilla1();
        }

        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_abrir_Click(sender, e);

        }

    }

}
