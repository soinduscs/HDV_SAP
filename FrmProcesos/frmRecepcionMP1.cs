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
    public partial class frmRecepcionMP1 : Form
    {
        public frmRecepcionMP1()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP1_Load(object sender, EventArgs e)
        {

            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha.AddDays(-1);
            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1_1.Value = dFecha;
            dtp_fecha2_1.Value = DateTime.Today;

            carga_grilla1();

            carga_grilla2();


        }

        private void carga_grilla1()
        {

            try
            {

                string cDocEntry, cLineID, cNumGuia;
                string cPatente, cCardName, cNumOC;
                string cItemName, cStatusCalidad;
                int nPesoBruto, nPesoTara;

                DateTime dFecha, dFecha1, dFecha2;

                dFecha1 = dtp_fecha1.Value;
                dFecha2 = dtp_fecha2.Value.AddDays(1);                

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nCantRegistros_MPRecibidos;
                int nLinea;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_recepcion_mp("C");

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
                        cPatente = dTable.Rows[i]["U_Patente"].ToString();
                    }
                    catch
                    {
                        cPatente = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["U_CardName_D"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
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
                        cItemName = dTable.Rows[i]["U_ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
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
                        nCantRegistros_MPRecibidos = Convert.ToInt32(dTable.Rows[i]["CantRegistros_MPRecibidos"].ToString());
                    }
                    catch
                    {
                        nCantRegistros_MPRecibidos = 0;
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
                        nPesoBruto = int.Parse(dTable.Rows[i]["U_PesoBruto"].ToString());
                    }
                    catch
                    {
                        nPesoBruto = 0;
                    }

                    try
                    {
                        nPesoTara = int.Parse(dTable.Rows[i]["U_PesoTara"].ToString());
                    }
                    catch
                    {
                        nPesoTara = 0;
                    }


                    cStatusCalidad = "";

                    if (nCantItems > 0)
                    {
                        if (nCantRegistros_MPRecibidos > 0)
                        {
                            cStatusCalidad = "Productos Parcialmente Recepcionados";

                            if (nCantRegistros_MPRecibidos == nCantItems)
                            {
                                cStatusCalidad = "Productos Completamente Recepcionados";

                            }

                        }
                        else
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
                                    cStatusCalidad = "Inspección de Humedad Finalizada - Aprobada";

                                }
                                else
                                {
                                    if (nCantRegistroRechazados >= nCantItems)
                                    {
                                        cStatusCalidad = "Inspección de Humedad Finalizada - Rechazada";

                                    }

                                }


                            }

                        }

                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cLineID.ToString();
                    grilla[2] = cNumGuia.ToString();
                    grilla[3] = cPatente.ToString();
                    grilla[4] = dFecha.ToString("dd/MM/yyyy HH:mm");
                    grilla[5] = cCardName.ToString();
                    grilla[6] = cNumOC.ToString();
                    grilla[7] = cItemName.ToString();
                    grilla[8] = cStatusCalidad;

                    grilla[9] = "";

                    if (nPesoBruto>0)
                    {
                        grilla[9] = "SI";

                    }

                    grilla[10] = "";

                    if (nPesoTara > 0)
                    {
                        grilla[10] = "SI";

                    }


                    if (dFecha>=dFecha1)
                    {
                        if (dFecha <= dFecha2)
                        {
                            Grid1.Rows.Add(grilla);

                            if (cStatusCalidad == "Inspección no Registrada")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.Empty;
                            }

                            if (cStatusCalidad == "Inspección en Proceso")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.Yellow;
                            }

                            if (cStatusCalidad == "Inspección de Humedad Finalizada - Aprobada")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.LightGreen;
                            }

                            if (cStatusCalidad == "Inspección de Humedad Finalizada - Rechazada")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.Red;
                            }

                            if (cStatusCalidad == "Productos Parcialmente Recepcionados")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.LightBlue;
                            }

                            if (cStatusCalidad == "Productos Completamente Recepcionados")
                            {
                                Grid1[8, nLinea].Style.BackColor = Color.LightBlue;
                            }

                            nLinea = nLinea + 1;

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla2()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1_1.Value;

                string cfecha1, cfecha2;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2_1.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Camiones_Ingresados(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                int nDocEntry, nNumGuia;
                string cPatente, cConductor, cFechaPorteria;
                string cProductor, cEspecie, cFechaPesaje;
                string cFechaDestare, cFechaRecepcion, cFechaHumedad;

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
                        nNumGuia = int.Parse(dTable.Rows[i]["DocNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;

                    }

                    try
                    {
                        cPatente = dTable.Rows[i]["U_Patente"].ToString();

                    }
                    catch
                    {
                        cPatente = "";
                    }

                    try
                    {
                        cConductor = dTable.Rows[i]["U_Conductor"].ToString();
                    }
                    catch
                    {
                        cConductor = "";
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaPorteria = dfecha.ToString("dd/MM/yyyy HH:mm");

                    try
                    {
                        cProductor = dTable.Rows[i]["U_Productor_Romana"].ToString();
                    }
                    catch
                    {
                        cProductor = "";
                    }

                    try
                    {
                        cEspecie = dTable.Rows[i]["U_ItemName_Romana"].ToString();
                    }
                    catch
                    {
                        cEspecie = "";
                    }

                    cFechaPesaje = "";
                    cFechaDestare = "";
                    cFechaRecepcion = "";
                    cFechaHumedad = ""; 

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaPeso1"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    if (dfecha.Year > 2000)
                    {
                        cFechaPesaje = dfecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaPeso2"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    if (dfecha.Year > 2000)
                    {
                        cFechaDestare = dfecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    if (dfecha.Year > 2000)
                    {
                        cFechaRecepcion = dfecha.ToString("dd/MM/yyyy HH:mm");

                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaHumedad"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    if (dfecha.Year > 2000)
                    {
                        cFechaHumedad = dfecha.ToString("dd/MM/yyyy HH:mm");
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nNumGuia.ToString();
                    grilla[2] = cPatente;
                    grilla[3] = cConductor;
                    grilla[4] = cFechaPorteria;
                    grilla[5] = cProductor;
                    grilla[6] = cEspecie;
                    grilla[7] = cFechaPesaje;
                    grilla[8] = cFechaDestare;
                    grilla[9] = cFechaRecepcion;
                    grilla[10] = cFechaHumedad;

                    Grid2.Rows.Add(grilla);

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

        private void btn_ingresar_mp_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana;
            string cStatusCalidad, cDestare;

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

            }

            try
            {
                cStatusCalidad = Grid1[8, fila].Value.ToString();
            }
            catch
            {
                cStatusCalidad = "";
            }

            try
            {
                cDestare = Grid1[10, fila].Value.ToString();
            }
            catch
            {
                cDestare = "";
            }

            VariablesGlobales.glb_Referencia1 = "";

            if (cStatusCalidad != "Inspección de Humedad Finalizada - Aprobada")
            {
                if (cStatusCalidad.Substring(0,9) != "Productos")
                {
                    MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    VariablesGlobales.glb_Referencia1 = "F";
                    //return;

                }

            }
            else
            {
                if (cDestare == "SI")
                {
                    VariablesGlobales.glb_Referencia1 = "Y";
                }
                else
                {
                    VariablesGlobales.glb_Referencia1 = "F";
                }
                
            }

            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmRecepcionMP2 f2 = new frmRecepcionMP2();
                DialogResult res = f2.ShowDialog();

                carga_grilla1();
                carga_grilla2();

            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();
            carga_grilla2();

        }

        private void btn_actualizar1_Click(object sender, EventArgs e)
        {
            carga_grilla1();
            carga_grilla2();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            btn_ingresar_mp_Click(sender, e);

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana;
            //string cStatusCalidad, cDestare;

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

            }
            
            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmRomana3 f2 = new frmRomana3();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void btn_imagenes_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana;
            //string cStatusCalidad, cDestare;

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

            }

            if (id_romana > 0)
            {

                VariablesGlobales.glb_id_romana1 = id_romana;

                frmRecepcionMPA3 f2 = new frmRecepcionMPA3();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_id_romana1 = 0;

            }


        }

    }

}
