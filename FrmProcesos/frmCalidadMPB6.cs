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
    public partial class frmCalidadMPB6 : Form
    {
        public frmCalidadMPB6()
        {
            InitializeComponent();
        }

        private void frmCalidadMPB6_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Today;

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;

            btn_registros_pendientes_Click(sender, e);

        }

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {

            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");
            string c_anhoactual;

            c_anhoactual = "S";

            if (chk_anhoactual.Checked == true)
                c_anhoactual = "S";
            else
                c_anhoactual = "N";

            carga_grilla("X", fecha, "", c_anhoactual);

            t_ultimo_boton.Text = "X";

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "", "S");

            t_ultimo_boton.Text = "F1";

        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {

            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("F2", cfecha1, cfecha2, "S");

            t_ultimo_boton.Text = "F2";

        }

        private void btn_consultar3_Click(object sender, EventArgs e)
        {

            int num_guia;
            string c_num_guia;

            num_guia = 0;
            c_num_guia = "";

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            c_num_guia = num_guia.ToString();

            carga_grilla("N", c_num_guia, "", "S");

            t_ultimo_boton.Text = "N";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana, nCantAnalisis;
            int id_calidad, nLineId;
            string cItemCode, cPelon;

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
            id_calidad = 0;
            nCantAnalisis = 0;
            cItemCode = "";
            cPelon = "NO";

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
                nLineId = Convert.ToInt32(Grid1[1, fila].Value.ToString());

            }
            catch
            {
                nLineId = 0;

            }

            try
            {
                id_calidad = Convert.ToInt32(Grid1[10, fila].Value.ToString().ToUpper());

            }
            catch
            {
                id_calidad = 0;

            }

            try
            {
                nCantAnalisis = Convert.ToInt32(Grid1[9, fila].Value.ToString().ToUpper());

            }
            catch
            {
                nCantAnalisis = 0;

            }

            try
            {
                cItemCode = Grid1[11, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cPelon = Grid1[12, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cPelon = "NO";
            }

            if (id_romana > 0)
            {

                VariablesGlobales.glb_id_calidad = id_calidad;
                VariablesGlobales.glb_Object = "100500";
                VariablesGlobales.glb_id_romana = id_romana;
                VariablesGlobales.glb_LineId = nLineId;
                VariablesGlobales.glb_ItemCode = cItemCode;

                if (cPelon == "NO")
                {
                    if (nCantAnalisis <= 1)
                    {
                        frmCalidadMP f2 = new frmCalidadMP();
                        DialogResult res = f2.ShowDialog();

                    }
                    else
                    {
                        frmCalidadMP9 f2 = new frmCalidadMP9();
                        DialogResult res = f2.ShowDialog();

                    }

                }
                else
                {
                    frmCalidadMPA8 f2 = new frmCalidadMPA8();
                    DialogResult res = f2.ShowDialog();

                }

                if (t_ultimo_boton.Text == "F1")
                {
                    btn_consultar1_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "F2")
                {
                    btn_consultar2_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "X")
                {
                    btn_registros_pendientes_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "N")
                {
                    btn_consultar3_Click(sender, e);

                }

            }

        }

        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(sender, e);
        }

        private void carga_grilla(string accion, string dato1, string dato2, string anhoactual)
        {

            try
            {

                string cDocEntry, cLineID, cNumGuia;
                string cPatente, cCardName, cNumOC;
                string cItemName, cStatusCalidad, cItemCode;
                string cMuestra, cPelon;

                DateTime dFecha;

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nIdCalidad, nFila;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Recepcion_MP_Calidad(accion, dato1, dato2, anhoactual);

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
                        cNumGuia = dTable.Rows[i]["U_NumGuia"].ToString();

                    }
                    catch
                    {
                        cNumGuia = "";
                    }

                    try
                    {
                        cPatente = dTable.Rows[i]["MdAbsEntry"].ToString();
                    }
                    catch
                    {
                        cPatente = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["U_CardName"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseDocNum"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
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
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["CantItems"].ToString());
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
                        nIdCalidad = Convert.ToInt32(dTable.Rows[i]["id_Calidad"].ToString());

                    }
                    catch
                    {
                        nIdCalidad = 0;

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
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["U_ItemCode"].ToString();

                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    cPelon = "NO";

                    try
                    {
                        cPelon = dTable.Rows[i]["PELON"].ToString();

                    }
                    catch
                    {
                        cPelon = "NO";

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
                            if (nCantRegistroAprobados == nCantRegistros)
                            {
                                cStatusCalidad = "Inspección Finalizada - Aprobado";

                            }
                            if (nCantRegistroRechazados == nCantItems)
                            {
                                cStatusCalidad = "Inspección Finalizada - Rechazado";

                            }

                        }

                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cLineID.ToString();
                    grilla[2] = cNumGuia.ToString();
                    grilla[3] = cPatente.ToString();
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");
                    grilla[5] = cCardName.ToString();
                    grilla[6] = cNumOC.ToString();
                    grilla[7] = cItemName.ToString();
                    grilla[8] = cStatusCalidad;
                    grilla[9] = nCantRegistros.ToString();
                    grilla[10] = nIdCalidad.ToString();
                    grilla[11] = cItemCode;
                    grilla[12] = cPelon;

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

                    if (cMuestra == "S")
                    {

                        if (cPelon == "SI")
                        {
                            Grid1.Rows.Add(grilla);

                            if (cStatusCalidad == "Inspección no Registrada")
                            {
                                Grid1[8, nFila].Style.BackColor = Color.Empty;
                            }

                            if (cStatusCalidad == "Inspección en Proceso")
                            {
                                Grid1[8, nFila].Style.BackColor = Color.Yellow;
                            }

                            if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                            {
                                Grid1[8, nFila].Style.BackColor = Color.Green;
                            }

                            if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                            {
                                Grid1[8, nFila].Style.BackColor = Color.Red;
                            }

                            nFila += 1;
                        }

                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

            string c_ItemCode;

            c_ItemCode = "";

            try
            {
                c_ItemCode = t_cardcode.Text;
            }
            catch
            {
                c_ItemCode = "";
            }


            carga_grilla("P", c_ItemCode, "", "S");

            t_ultimo_boton.Text = "P";

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }

}
