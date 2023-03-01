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
    public partial class frmRecepcionMPA4 : Form
    {
        public frmRecepcionMPA4()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPA4_Load(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_Referencia3 == "Recibe_MP")
            {
                btn_ingresar_mp.Text = "Genera Recibo de Producción como Materia Prima / Orden de Compra";

            }

            if (VariablesGlobales.glb_Referencia3 == "Envia_Clte")
            {
                btn_ingresar_mp.Text = "Genera Recibo de Producción como PT Pelón";

            }

            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha.AddDays(-1);
            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {

                string cDocEntry, cLineID, cNumOC;
                string cItemName, cStatusCalidad, cProductor;
                string cDestino_Secado;

                int nPesoBruto, nPesoTara;

                DateTime dFecha, dFecha1, dFecha2;

                dFecha1 = dtp_fecha1.Value;
                dFecha2 = dtp_fecha2.Value.AddDays(1);

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nCantRegistros_MPRecibidos;
                int nLinea, idEntradaSecado;

                double nPesoNeto;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_recepcion_mp("S");

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
                        cProductor = dTable.Rows[i]["U_CardName"].ToString();
                    }
                    catch
                    {
                        cProductor = "";
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

                    try
                    {
                        nPesoNeto = Convert.ToDouble(dTable.Rows[i]["U_PesoNeto"].ToString());
                    }
                    catch
                    {
                        nPesoNeto = 0;
                    }

                    try
                    {
                        cDestino_Secado = dTable.Rows[i]["Destino_Secado"].ToString();
                    }
                    catch
                    {
                        cDestino_Secado = "";
                    }

                    try
                    {
                        idEntradaSecado = Convert.ToInt32(dTable.Rows[i]["DocEntry_EntradaSecado"].ToString());
                    }
                    catch
                    {
                        idEntradaSecado = 0;
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
                    grilla[2] = dFecha.ToString("dd/MM/yyyy HH:mm");
                    grilla[3] = cProductor.ToString();
                    grilla[4] = cNumOC.ToString();
                    grilla[5] = cItemName.ToString();
                    grilla[6] = nPesoNeto.ToString("N0");
                    grilla[7] = cStatusCalidad;

                    grilla[8] = "";

                    if (nPesoBruto > 0)
                    {
                        grilla[8] = "SI";

                    }

                    grilla[9] = "";
                    grilla[10] = idEntradaSecado.ToString();

                    if (nPesoTara > 0)
                    {
                        grilla[9] = "SI";

                    }

                    if (dFecha >= dFecha1)
                    {
                        if (dFecha <= dFecha2)
                        {

                            if (cDestino_Secado == VariablesGlobales.glb_Referencia3)
                            {
                                Grid1.Rows.Add(grilla);

                                if (cStatusCalidad == "Inspección no Registrada")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.Empty;
                                }

                                if (cStatusCalidad == "Inspección en Proceso")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.Yellow;
                                }

                                if (cStatusCalidad == "Inspección de Humedad Finalizada - Aprobada")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.LightGreen;
                                }

                                if (cStatusCalidad == "Inspección de Humedad Finalizada - Rechazada")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.Red;
                                }

                                if (cStatusCalidad == "Productos Parcialmente Recepcionados")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.LightBlue;
                                }

                                if (cStatusCalidad == "Productos Completamente Recepcionados")
                                {
                                    Grid1[7, nLinea].Style.BackColor = Color.LightBlue;
                                }

                                nLinea = nLinea + 1;
                            }

                        }

                    }

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
                cStatusCalidad = Grid1[7, fila].Value.ToString();
            }
            catch
            {
                cStatusCalidad = "";
            }

            try
            {
                cDestare = Grid1[9, fila].Value.ToString();
            }
            catch
            {
                cDestare = "";
            }

            VariablesGlobales.glb_Referencia1 = "";

            if (cStatusCalidad != "Inspección de Humedad Finalizada - Aprobada")
            {
                if (cStatusCalidad.Substring(0, 6) != "Productos")
                {
                    MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    VariablesGlobales.glb_Referencia1 = "F";
                    return;

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
                VariablesGlobales.glb_id_acceso = id_romana;

                if (VariablesGlobales.glb_Referencia3 == "Recibe_MP")
                {
                    frmRecepcionMPA8 f3 = new frmRecepcionMPA8();
                    DialogResult res = f3.ShowDialog();

                }

                if (VariablesGlobales.glb_Referencia3 == "Envia_Clte")
                {
                    frmRecepcionMPA5 f2 = new frmRecepcionMPA5();
                    DialogResult res = f2.ShowDialog();

                }

                carga_grilla1();

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

            int fila, nEntMercaderia, nTransfStock;

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

            nEntMercaderia = 0;
            nTransfStock = 0;

            if (fila >= 0)
            {
                try
                {
                    nEntMercaderia = Convert.ToInt32(Grid1[10, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nEntMercaderia = 0;

                }

                nTransfStock = 0;

                if (nEntMercaderia == 0)
                {
                    MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nTransfStock == 0)
                {
                    //MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                VariablesGlobales.glb_Referencia1 = nEntMercaderia.ToString();
                VariablesGlobales.glb_Referencia2 = nTransfStock.ToString();

                frmRecepcionMP5 f2 = new frmRecepcionMP5();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_Referencia1 = "";
                VariablesGlobales.glb_Referencia2 = "";

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string cSupervisor = "NO";

            VariablesGlobales.glb_User_Code_Autorizacion = "";

            frmLoginSupervisor f5 = new frmLoginSupervisor();
            DialogResult res5 = f5.ShowDialog();

            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
            {
                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                }
                catch
                {
                    cSupervisor = "NO";

                }

            }

            if (cSupervisor == "NO")
            {
                return;
            }

            frmRecepcionMPA9 f2 = new frmRecepcionMPA9();
            DialogResult res = f2.ShowDialog();

        }

    }

}
