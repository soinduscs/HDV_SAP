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
    public partial class frmCalidadMP4 : Form
    {
        public frmCalidadMP4()
        {
            InitializeComponent();
        }

        private void frmCalidadMP4_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Today;

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;

            btn_consultar1_Click(sender, e);

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "");

            t_ultimo_boton.Text = "F1";

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
                string cObjetoRef;

                DateTime fecha;

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
                        cEstado  = "";
                    }

                    try
                    {
                        fecha = DateTime.Parse(dTable.Rows[i]["U_FecIngr"].ToString());

                    }
                    catch
                    {
                        fecha = DateTime.Parse("01/01/1900");

                    }

                    try
                    {
                        cObjetoRef = dTable.Rows[i]["U_Object_Ref"].ToString();

                    }
                    catch
                    {
                        cObjetoRef = "";

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
                    grilla[2] = fecha.ToString("dd/MM/yyyy");
                    grilla[3] = cItemName.ToString();
                    grilla[4] = cCreator.ToString();
                    grilla[5] = cStatusCalidad.ToString();
                    grilla[7] = cObjetoRef;

                    Grid1.Rows.Add(grilla);

                    if (cStatusCalidad == "Inspección en Proceso")
                    {
                        Grid1[5, i].Style.BackColor = Color.Yellow;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                    {
                        Grid1[5, i].Style.BackColor = Color.Green;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                    {
                        Grid1[5, i].Style.BackColor = Color.Red;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {
            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("F2", cfecha1, cfecha2);

            t_ultimo_boton.Text = "F2";

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_calidad;
            string cObjectRef;

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

            id_calidad = 0;

            try
            {
                id_calidad = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

            }
            catch
            {
                id_calidad = 0;

            }

            try
            {
                cObjectRef = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cObjectRef = "";
            }

            if (id_calidad > 0)
            {
                VariablesGlobales.glb_id_calidad = id_calidad;
                VariablesGlobales.glb_id_romana = 0;
                VariablesGlobales.glb_Object = cObjectRef;
                VariablesGlobales.glb_LineId = 0;

                switch (cObjectRef)
                {
                    case "100100": // Inspección de Humedad MP
                        frmCalidadMP f100 = new frmCalidadMP();
                        DialogResult res = f100.ShowDialog();
                        break;

                    case "100500": // Inspección de Materia Prima
                        frmCalidadMP f500 = new frmCalidadMP();
                        DialogResult res1 = f500.ShowDialog();
                        break;

                    case "59": // Inspección de Productos en Proceso
                        frmCalidadPP f59 = new frmCalidadPP();
                        DialogResult res2 = f59.ShowDialog();
                        break;
                }

                if (t_ultimo_boton.Text == "F1")
                {
                    btn_consultar1_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "F2")
                {
                    btn_consultar2_Click(sender, e);

                }

            }

        }

        private void dtp_fecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "");

            t_ultimo_boton.Text = "F1";


        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }
    }

}
