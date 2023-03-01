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
    public partial class frmRecepcionMPA7 : Form
    {
        public frmRecepcionMPA7()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPA7_Load(object sender, EventArgs e)
        {

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
                string cDestino_Secado, cNomDestino_Secado; 

                int nPesoBruto, nPesoTara;

                DateTime dFecha, dFecha1, dFecha2;

                dFecha1 = dtp_fecha1.Value;
                dFecha2 = dtp_fecha2.Value.AddDays(1);

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nCantRegistros_MPRecibidos;
                int nLinea;

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

                    cNomDestino_Secado = "";

                    if (cDestino_Secado == "Recibe_MP")
                    {
                        cNomDestino_Secado = "Recibir Como Materia Prima";
                    }

                    if (cDestino_Secado == "Envia_Clte")
                    {
                        cNomDestino_Secado = "Envío Directo a Cliente";
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
                    grilla[9] = "";
                    grilla[10] = cNomDestino_Secado;
                    
                    if (nPesoBruto > 0)
                    {
                        grilla[8] = "SI";

                    }

                    grilla[9] = "";

                    if (nPesoTara > 0)
                    {
                        grilla[9] = "SI";

                    }

                    if (dFecha >= dFecha1)
                    {
                        if (dFecha <= dFecha2)
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


        private void button2_Click(object sender, EventArgs e)
        {

            int fila, nDocEntry;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }           

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Destinar el lote como ** Materia Prima", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Modifica_Destino_Secado_RecibeMP(nDocEntry.ToString());

                MessageBox.Show("Registro Modificado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_grilla1();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int fila, nDocEntry;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Destinar el lote como ** Envía a Cliente", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Modifica_Destino_Secado_EnviaCliente(nDocEntry.ToString());

                MessageBox.Show("Registro Modificado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_grilla1();

            }
        }
    }

}
