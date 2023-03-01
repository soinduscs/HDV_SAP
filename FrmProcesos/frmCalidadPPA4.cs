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
    public partial class frmCalidadPPA4 : Form
    {
        public frmCalidadPPA4()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA4_Load(object sender, EventArgs e)
        {

            carga_grilla1("X","","");


        }

        private void carga_grilla1(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cNumOF, cCajon;
                string cLote, cItemCode, cItemName;
                string cStatusCalidad, cBodega, cMuestra;

                double nPesoBruto;

                DateTime dFecha, dFecha1, dFecha2;

                dFecha1 = dtp_fecha1.Value;
                dFecha2 = dtp_fecha2.Value.AddDays(1);

                int nIdCalidad, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nCantRegistros_MPRecibidos;
                int nLinea;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_SAPB1_ROMANA8("C");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                nLinea = 0;

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["NumeroDocto"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cNumOF = dTable.Rows[i]["OrdenAfecta"].ToString();
                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cLote = dTable.Rows[i]["Lote"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCajon = dTable.Rows[i]["Cajon"].ToString();
                    }
                    catch
                    {
                        cCajon = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cBodega = dTable.Rows[i]["LocCode"].ToString();
                    }
                    catch
                    {
                        cBodega = "";
                    }

                    try
                    {
                        nPesoBruto = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nPesoBruto = 0;
                    }

                    try
                    {
                        nIdCalidad = Convert.ToInt32(dTable.Rows[i]["id_calidad"].ToString());
                    }
                    catch
                    {
                        nIdCalidad = 0;
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
                        nCantRegistros_MPRecibidos = Convert.ToInt32(dTable.Rows[i]["CantRegistros_MPRecibidos"].ToString());
                    }
                    catch
                    {
                        nCantRegistros_MPRecibidos = 0;
                    }

                    cStatusCalidad = "";

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

                        if (nCantRegistroAprobados >= nCantRegistros)
                        {
                            cStatusCalidad = "Inspección de Humedad Finalizada - Aprobada";

                        }
                        else
                        {
                            if (nCantRegistroRechazados >= nCantRegistros)
                            {
                                cStatusCalidad = "Inspección de Humedad Finalizada - Rechazada";

                            }

                        }

                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cNumOF.ToString();
                    grilla[2] = dFecha.ToString("dd/MM/yyyy");
                    grilla[3] = cLote.ToString();
                    grilla[4] = cCajon.ToString();
                    grilla[5] = cItemCode.ToString();
                    grilla[6] = cItemName.ToString();
                    grilla[7] = cBodega.ToString();
                    grilla[8] = nPesoBruto.ToString("N2");
                    grilla[9] = nIdCalidad.ToString();
                    grilla[10] = cStatusCalidad;

                    cMuestra = "N";

                    if (accion == "X")
                    {
                        ////////////////////////////////////////
                        // Solo Reg Pendientes

                        if (nIdCalidad == 0)
                        {
                            cMuestra = "S";

                        }
                        else
                        {
                            if (cStatusCalidad == "Inspección no Registrada")
                            {
                                cMuestra = "S";
                            }

                            if (cStatusCalidad == "Inspección en Proceso")
                            {
                                cMuestra = "S";
                            }

                        }

                    }

                    if (accion == "F1")
                    {
                        ////////////////////////////////////////
                        // Solo Reg Pendientes

                        if (dFecha.ToString("yyyyMMdd") == dato1)
                        {
                            cMuestra = "S";

                        }

                    }

                    if (accion == "F2")
                    {
                        ////////////////////////////////////////
                        // Solo Reg Pendientes

                        dFecha1 = Convert.ToDateTime(dato1);
                        dFecha2 = Convert.ToDateTime(dato2);

                        if (dFecha >= dFecha1)
                        {
                            if (dFecha <= dFecha2)
                            {
                                cMuestra = "S";

                            }

                        }

                    }

                    if (accion == "O")
                    {
                        ////////////////////////////////////////
                        // Solo Reg Pendientes

                        if (cNumOF == dato1)
                        {
                            cMuestra = "S";

                        }

                    }


                    if (cMuestra == "S")
                    {
                        Grid1.Rows.Add(grilla);

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            Grid1[10, nLinea].Style.BackColor = Color.Empty;
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            Grid1[10, nLinea].Style.BackColor = Color.Yellow;
                        }

                        if (cStatusCalidad == "Inspección de Humedad Finalizada - Aprobada")
                        {
                            Grid1[10, nLinea].Style.BackColor = Color.LightGreen;
                        }

                        if (cStatusCalidad == "Inspección de Humedad Finalizada - Rechazada")
                        {
                            Grid1[10, nLinea].Style.BackColor = Color.Red;
                        }

                        nLinea = nLinea + 1;

                    }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana, id_calidad;
            string cLote;

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
            cLote = "";
            id_calidad = 0;

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
                    cLote = Grid1[3, fila].Value.ToString();

                }
                catch
                {
                    cLote = "";

                }

                try
                {
                    id_calidad = Convert.ToInt32(Grid1[9, fila].Value.ToString().ToUpper());
                }
                catch
                {
                    id_calidad = 0;
                }

            }

            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;
                VariablesGlobales.glb_id_acceso = id_romana;
                VariablesGlobales.glb_DocEntry = id_romana;
                VariablesGlobales.glb_LineId = 0;
                VariablesGlobales.glb_Lote = int.Parse(cLote);
                VariablesGlobales.glb_id_calidad = id_calidad;
                VariablesGlobales.glb_Object = "60";
                VariablesGlobales.glb_Razon_Ingreso = "C";

                frmCalidadPPA3 f2 = new frmCalidadPPA3();
                DialogResult res = f2.ShowDialog();

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

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {

            carga_grilla1("X", "", "");

        }

        private void Grid1_DoubleClick_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla1("F1", fecha, "");

        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {
            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            carga_grilla1("F2", fecha1.ToString("dd/MM/yyyy"), fecha2.ToString("dd/MM/yyyy"));

        }

        private void btn_consultar3_Click(object sender, EventArgs e)
        {
            int nNumOF;

            try
            {
                nNumOF = Convert.ToInt32(t_num_of.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF > 0)
            {
                carga_grilla1("O", t_num_of.Text, "");

            }

        }
    }

}
