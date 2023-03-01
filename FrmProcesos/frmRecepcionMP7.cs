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
    public partial class frmRecepcionMP7 : Form
    {
        public frmRecepcionMP7()
        {
            InitializeComponent();
        }

        private void frmRecepcionMP7_Load(object sender, EventArgs e)
        {
            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha.AddDays(-1);
            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            ///////////////////////////////////////////////////////

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_lee_localidades();

            cbb_localidad.DataSource = objproducto1.cResultado;
            cbb_localidad.ValueMember = "Code";
            cbb_localidad.DisplayMember = "Location";

            //carga_grilla1();

        }


        private void carga_grilla1()
        {

            try
            {

                string DocEntry_OPDN, cDocEntry_OWTR, cNumGuia;
                string cPatente, cCardName, cNumOC;
                string cItemName, cVariedad, cItemCode;
                string cStatusCalidad;

                DateTime dFecha, dFecha1, dFecha2;

                dFecha1 = dtp_fecha1.Value;
                dFecha2 = dtp_fecha2.Value.AddDays(1);

                double nCantidad;

                int nCantRegistroRechazados, nCantRegistros, nCantRegistroAprobados;
                int nDocEntry, nDocEntryCalidad;

                string cLocalidad;

                if (cbb_localidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe Seleccionar una localidad válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cLocalidad = cbb_localidad.SelectedValue.ToString();

                if (cLocalidad=="0")
                {
                    cLocalidad = "";

                }

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Registros_recepcion_mp(dFecha1.ToString("yyyyMMdd") , dFecha2.ToString("yyyyMMdd"), cLocalidad);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

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
                        nDocEntryCalidad = int.Parse(dTable.Rows[i]["DocEntry_OCAL"].ToString());
                    }
                    catch
                    {
                        nDocEntryCalidad = 0;
                    }
                    
                    try
                    {
                        DocEntry_OPDN = dTable.Rows[i]["DocEntry_OPDN"].ToString();
                    }
                    catch
                    {
                        DocEntry_OPDN = "";

                    }

                    try
                    {
                        cDocEntry_OWTR = dTable.Rows[i]["DocEntry_OWTR"].ToString();
                    }
                    catch
                    {
                        cDocEntry_OWTR = "";

                    }

                    try
                    {
                        cNumGuia = dTable.Rows[i]["FolioNum"].ToString();

                    }
                    catch
                    {
                        cNumGuia = "";
                    }

                    try
                    {
                        cPatente = dTable.Rows[i]["U_DTE_Patente"].ToString();
                    }
                    catch
                    {
                        cPatente = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
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
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    try
                    {
                        nCantidad = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    try
                    {
                        dFecha = DateTime.Parse(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");

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
                        if (nCantRegistroAprobados == nCantRegistros)
                        {
                            cStatusCalidad = "Inspección Finalizada - Aprobado";

                        }
                        if (nCantRegistroRechazados == nCantRegistros)
                        {
                            cStatusCalidad = "Inspección Finalizada - Rechazado";

                        }

                    }

                    grilla[0] = DocEntry_OPDN.ToString();
                    grilla[1] = cDocEntry_OWTR.ToString();
                    grilla[2] = cNumGuia.ToString();
                    grilla[3] = cPatente.ToString();
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");
                    grilla[5] = cCardName.ToString();
                    grilla[6] = cNumOC.ToString();
                    grilla[7] = (cItemName + ' ' + cVariedad).ToString();
                    grilla[8] = nCantidad.ToString("N2");
                    grilla[9] = "";
                    grilla[10] = nDocEntry.ToString();
                    grilla[11] = cItemCode;
                    grilla[12] = nDocEntryCalidad.ToString();
                    grilla[13] = cStatusCalidad;

                    Grid1.Rows.Add(grilla);

                    if (cStatusCalidad == "Inspección no Registrada")
                    {
                        Grid1[13, i].Style.BackColor = Color.Empty;
                    }

                    if (cStatusCalidad == "Inspección en Proceso")
                    {
                        Grid1[13, i].Style.BackColor = Color.Yellow;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                    {
                        Grid1[13, i].Style.BackColor = Color.Green;
                    }

                    if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                    {
                        Grid1[13, i].Style.BackColor = Color.Red;
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
                    nEntMercaderia = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nEntMercaderia = 0;

                }

                try
                {
                    nTransfStock = Convert.ToInt32(Grid1[1, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    nTransfStock = 0;
                }

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

        private void btn_crear_Click(object sender, EventArgs e)
        {
            string cLocalidad;

            if (cbb_localidad.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar una localidad válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cLocalidad = cbb_localidad.SelectedValue.ToString();

            if (cLocalidad == "0")
            {
                cLocalidad = "";

            }

            VariablesGlobales.glb_Localidad = cLocalidad;

            frmRecepcionMP6 frm = new frmRecepcionMP6();
            DialogResult res = frm.ShowDialog();

            carga_grilla1();

        }

        private void btn_calidad_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana, nCantAnalisis;
            int id_calidad;
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
            id_calidad = 0;
            nCantAnalisis = 0;
            cItemCode = "";

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
                id_calidad = Convert.ToInt32(Grid1[12, fila].Value.ToString().ToUpper());

            }
            catch
            {
                id_calidad = 0;

            }

            try
            {
                nCantAnalisis = 0;  Convert.ToInt32(Grid1[13, fila].Value.ToString().ToUpper());

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

            if (id_romana > 0)
            {

                VariablesGlobales.glb_id_calidad = id_calidad;
                VariablesGlobales.glb_Object = "100501";
                VariablesGlobales.glb_id_romana = id_romana;
                VariablesGlobales.glb_LineId = 0;
                VariablesGlobales.glb_ItemCode = cItemCode;

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

                carga_grilla1();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cItemCode;

            fila = 0;
            cItemCode = "";

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
                cItemCode = Grid1[11, fila].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }

            if (cItemCode == "")
            {
                MessageBox.Show("Debe seleccionar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = cItemCode;

            frmCalidadMP3 f2 = new frmCalidadMP3();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_ItemCode = "";


        }

    }

}
