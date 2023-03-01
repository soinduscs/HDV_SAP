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
    public partial class frmCalidadMPB1 : Form
    {
        public frmCalidadMPB1()
        {
            InitializeComponent();
        }

        private void frmCalidadMPB1_Load(object sender, EventArgs e)
        {

            dtp_fecha.Value = DateTime.Today;

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;

            carga_grilla("X", "", "");

        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cLineID, cItemCode;
                string cItemName_Bins, cNumOC, cNumGuia;
                string cItemName, cStatusCalidad, cMuestra;

                DateTime dFecha;

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nFila, nCantBins;
                int nDocEntry_ref;

                double nKilosNetos;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Guias_Calidad(accion, dato1, dato2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                nFila = 0;

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
                        cLineID = dTable.Rows[i]["LineId"].ToString();
                    }
                    catch
                    {
                        cLineID = "";

                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["U_NumOC"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cNumGuia = dTable.Rows[i]["U_NumGuia"].ToString();
                    }
                    catch
                    {
                        cNumGuia = "";
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
                        cItemName = dTable.Rows[i]["U_ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cItemName_Bins = dTable.Rows[i]["U_ItemCodeBins"].ToString();
                    }
                    catch
                    {
                        cItemName_Bins = "";
                    }


                    try
                    {
                        nCantBins = Convert.ToInt32(dTable.Rows[i]["U_CantidadBins"].ToString());
                    }
                    catch
                    {
                        nCantBins = 0;
                    }

                    try
                    {
                        nKilosNetos = Convert.ToInt32(dTable.Rows[i]["U_PesoNeto"].ToString());
                    }
                    catch
                    {
                        nKilosNetos = 0;
                    }

                    try
                    {
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["CantItms"].ToString());
                    }
                    catch
                    {
                        nCantItems = 0;
                    }

                    try
                    {
                        nCantRegistros = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Calidad"].ToString());
                    }
                    catch
                    {
                        nCantRegistros = 0;
                    }

                    try
                    {
                        nCantRegistroAprobados = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Aprobados"].ToString());
                    }
                    catch
                    {
                        nCantRegistroAprobados = 0;
                    }

                    try
                    {
                        nCantRegistroRechazados = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Rechazados"].ToString());
                    }
                    catch
                    {
                        nCantRegistroRechazados = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaPeso1"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        nDocEntry_ref = Convert.ToInt32(dTable.Rows[i]["DocEntry_Calidad"].ToString()); 
                    }
                    catch
                    {
                        nDocEntry_ref = 0;
                    }

                    cStatusCalidad = "";

                    if (nCantItems > 0)
                    {
                        if ((nCantRegistros + nCantRegistroAprobados) == 0)
                        {
                            cStatusCalidad = "Inspección no Registrada";
                        }
                        else
                        {
                            if (nCantRegistros > 0)
                            {
                                cStatusCalidad = "Inspección en Proceso";

                            }
                            if (nCantRegistroAprobados >= nCantItems)
                            {
                                cStatusCalidad = "Inspección Finalizada - Aprobado";

                            }
                            else
                            {
                                if (nCantRegistroRechazados >= nCantItems)
                                {
                                    cStatusCalidad = "Inspección Finalizada - Rechazado";

                                }

                            }


                        }

                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cNumOC.ToString();
                    grilla[2] = dFecha.ToString("dd/MM/yyyy");
                    grilla[3] = cItemCode;
                    grilla[4] = cItemName;
                    grilla[5] = cItemName_Bins;
                    grilla[6] = nCantBins.ToString();
                    grilla[7] = "";
                    grilla[8] = nKilosNetos.ToString("N2");
                    grilla[9] = nDocEntry_ref.ToString();

                    grilla[10] = cStatusCalidad;

                    cMuestra = "S";

                    if (accion == "X")
                    {
                        cMuestra = "N";

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            cMuestra = "S";
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            cMuestra = "S";
                        }

                    }

                    if (cNumGuia != "0")
                    {
                        cMuestra = "N";
                    }

                    if (accion == "O")
                    {
                        cMuestra = "N";

                        if (cNumOC == dato1)
                        {
                            cMuestra = "S";

                        }

                    }

                    if (cMuestra == "S")
                    {

                        Grid1.Rows.Add(grilla);

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            Grid1[10, nFila].Style.BackColor = Color.Empty;
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            Grid1[10, nFila].Style.BackColor = Color.Yellow;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                        {
                            Grid1[10, nFila].Style.BackColor = Color.Green;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                        {
                            Grid1[10, nFila].Style.BackColor = Color.Red;
                        }

                        nFila += 1;

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {
            carga_grilla("X", "", "");

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "");

            t_ultimo_boton.Text = "F1";

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

        private void btn_consultar3_Click(object sender, EventArgs e)
        {

            int num_of;
            string c_num_of;

            num_of = 0;
            c_num_of = "";

            try
            {
                num_of = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_of = 0;
            }

            c_num_of = num_of.ToString();

            carga_grilla("O", c_num_of, "");

            t_ultimo_boton.Text = "N";

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

            int fila, id_romana, nIdCalidad;
            string cItemCode;

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

            id_romana = 0;
            nIdCalidad = 0;
            cItemCode = "";

            if (fila >= 0)
            {
                try
                {
                    id_romana = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    id_romana = 0;

                }

                try
                {
                    nIdCalidad = Convert.ToInt32(Grid1[9, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nIdCalidad = 0;

                }

                try
                {
                    cItemCode = Grid1[3, fila].Value.ToString();

                }
                catch
                {
                    cItemCode = "";

                }

            }

            if (id_romana > 0)
            {

                VariablesGlobales.glb_id_romana = id_romana;
                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "100100";
                VariablesGlobales.glb_LineId = 0;
                VariablesGlobales.glb_ItemCode = cItemCode;

                frmCalidadMP f2 = new frmCalidadMP();
                DialogResult res = f2.ShowDialog();

                //frmCalidadMPA9 f2 = new frmCalidadMPA9();
                //DialogResult res = f2.ShowDialog();

            }

            if (tabControl1.SelectedTab == tabPage5)
            {
                btn_registros_pendientes_Click(sender, e);
            }

            if (tabControl1.SelectedTab == tabPage1)
            {
                btn_consultar1_Click(sender, e);
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                btn_consultar2_Click(sender, e);
            }

            if (tabControl1.SelectedTab == tabPage3)
            {
                btn_consultar3_Click(sender, e);
            }

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

    }

}
