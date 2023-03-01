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
    public partial class FRP19 : Form
    {
        public FRP19()
        {
            InitializeComponent();
        }

        private void FRP19_Load(object sender, EventArgs e)
        {

        }

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {

            string cAnho_actual;

            cAnho_actual = "Y";

            if (cbb_anho_actual.Checked == false)
            {
                cAnho_actual = "N";

            }

            carga_grilla("X", cAnho_actual, "");

            t_ultimo_boton.Text = "X";

        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cCardName, cItemName;
                string cStatusCalidad, cItemCode, cNumOFSecado;
                string cLoteSecado, cDocEntry_TR;

                DateTime dFecha;

                int nCant_Bins, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nIdCalidad, nFila;
                int idCalidadSecado;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Partidas_dys_humedad(accion, dato1);

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
                        cDocEntry = dTable.Rows[i]["DocNum"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
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
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    try
                    {
                        nCant_Bins = Convert.ToInt32(dTable.Rows[i]["U_BINS"].ToString());
                    }
                    catch
                    {
                        nCant_Bins = 0;
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
                        nIdCalidad = Convert.ToInt32(dTable.Rows[i]["DocEntry_RI"].ToString());

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
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cNumOFSecado = dTable.Rows[i]["OrdenAfecta"].ToString();

                    }
                    catch
                    {
                        cNumOFSecado = "";
                    }

                    try
                    {
                        cLoteSecado = dTable.Rows[i]["Lote"].ToString();

                    }
                    catch
                    {
                        cLoteSecado = "";
                    }

                    try
                    {
                        idCalidadSecado = Convert.ToInt32(dTable.Rows[i]["id_Calidad2"].ToString());

                    }
                    catch
                    {
                        idCalidadSecado = 0;
                    }

                    try
                    {
                        cDocEntry_TR = dTable.Rows[i]["DocEntry_TR"].ToString();

                    }
                    catch
                    {
                        cDocEntry_TR = "";
                    }

                    try
                    {
                        cStatusCalidad = dTable.Rows[i]["Nom_Estado_RI"].ToString();

                    }
                    catch
                    {
                        cStatusCalidad = "";
                    }
                    
                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = dFecha.ToString("dd/MM/yyyy");
                    grilla[2] = cCardName.ToString();
                    grilla[3] = cNumOFSecado;
                    grilla[4] = cLoteSecado;
                    grilla[5] = cItemName;
                    grilla[6] = nCant_Bins.ToString();
                    grilla[7] = cStatusCalidad;
                    grilla[8] = nIdCalidad.ToString();
                    grilla[9] = cItemCode;
                    grilla[10] = cDocEntry_TR;

                    Grid1.Rows.Add(grilla);

                    if (cStatusCalidad == "Inspección en Proceso")
                    {
                        Grid1[7, nFila].Style.BackColor = Color.Yellow;

                    }

                    if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                    {
                        Grid1[7, nFila].Style.BackColor = Color.Green;

                    }

                    if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                    {
                        Grid1[7, nFila].Style.BackColor = Color.Red;

                    }

                    nFila += 1;

                }

                if (nFila == 0)
                {
                    MessageBox.Show("No Existen datos en la selección consultada, opción Cancelada", "Registro de Inspección - Orden de fabricación de Secado / Control Romana", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad, nCantidadRegistros;

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

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            nCantidadRegistros = 0;
            cItemCode = "";


            try
            {
                id_NumOF = int.Parse(Grid1[3, fila].Value.ToString());
            }
            catch
            {
                id_NumOF = 0;
            }

            try
            {
                nLote = int.Parse(Grid1[4, fila].Value.ToString());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                nIdCalidad = int.Parse(Grid1[8, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                id_Recepcion = int.Parse(Grid1[10, fila].Value.ToString());

            }
            catch
            {
                id_Recepcion = 0;
            }

            try
            {
                cItemCode = Grid1[9, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = 0;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                FRP20 fv0 = new FRP20();
                DialogResult res0 = fv0.ShowDialog();

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {


            if (t_lote.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de Lote valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            carga_grilla("L", t_lote.Text, "");

            t_ultimo_boton.Text = "L";

        }
    }

}
