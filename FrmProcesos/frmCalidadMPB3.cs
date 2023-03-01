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
    public partial class frmCalidadMPB3 : Form
    {
        public frmCalidadMPB3()
        {
            InitializeComponent();
        }

        private void frmCalidadMPB3_Load(object sender, EventArgs e)
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

            carga_grilla("X", fecha, "");

            t_ultimo_boton.Text = "X";

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

            if (id_calidad == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

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

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cLineID, cNumGuia;
                string cPatente, cCardName, cNumOC;
                string cItemName, cStatusCalidad, cItemCode;
                string cMuestra, cPelon, cNumOFSecado;
                string cLoteSecado, cCodEstadoSecado, cEstadoSecado;
                string cDocEntry_TR, cItemCode_TR;

                DateTime dFecha;

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nIdCalidad, nFila;
                int idCalidadSecado;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Recepcion_MP_Calidad_Secado(accion, dato1, dato2);

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
                        cLineID = dTable.Rows[i]["LineNum"].ToString();
                    }
                    catch
                    {
                        cLineID = "";

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
                        cPatente = dTable.Rows[i]["MdAbsEntry"].ToString();
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
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();

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
                        cDocEntry_TR = dTable.Rows[i]["DocEntry_TR"].ToString();

                    }
                    catch
                    {
                        cDocEntry_TR = "";
                    }

                    try
                    {
                        cItemCode_TR = dTable.Rows[i]["ItemCode_TR"].ToString();

                    }
                    catch
                    {
                        cItemCode_TR = "";
                    }


                    try
                    {
                        cCodEstadoSecado = dTable.Rows[i]["estado_calidad2"].ToString();

                    }
                    catch
                    {
                        cCodEstadoSecado = "";
                    }

                    cEstadoSecado = "";

                    if (cCodEstadoSecado == "")
                    {
                        cEstadoSecado = "Inspección no Registrada";

                    }

                    if (cCodEstadoSecado == "N")
                    {
                        cEstadoSecado = "Inspección en Proceso";

                    }

                    if (cCodEstadoSecado == "A")
                    {
                        cEstadoSecado = "Inspección Finalizada - Aprobado";

                    }

                    if (cCodEstadoSecado == "Q")
                    {
                        cEstadoSecado = "Inspección Finalizada - Aprobado C/Reparos";

                    }

                    if (cCodEstadoSecado == "R")
                    {
                        cEstadoSecado = "Inspección Finalizada - Rechazado";

                    }

                    try
                    {
                        idCalidadSecado = Convert.ToInt32(dTable.Rows[i]["id_Calidad2"].ToString());

                    }
                    catch
                    {
                        idCalidadSecado = 0;
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
                    grilla[13] = cNumOFSecado;
                    grilla[14] = cLoteSecado;
                    grilla[15] = cEstadoSecado;
                    grilla[16] = idCalidadSecado.ToString();
                    grilla[17] = cDocEntry_TR;
                    grilla[18] = cItemCode_TR;

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

                        //////////////////////////////////////////////
                        //////////////////////////////////////////////

                        if (cEstadoSecado == "Inspección no Registrada")
                        {
                            Grid1[15, nFila].Style.BackColor = Color.Empty;
                        }

                        if (cEstadoSecado == "Inspección en Proceso")
                        {
                            Grid1[15, nFila].Style.BackColor = Color.Yellow;
                        }

                        if (cEstadoSecado == "Inspección Finalizada - Aprobado")
                        {
                            Grid1[15, nFila].Style.BackColor = Color.Green;
                        }

                        if (cEstadoSecado == "Inspección Finalizada - Aprobado C/Reparos")
                        {
                            Grid1[15, nFila].Style.BackColor = Color.Orange;
                        }

                        if (cEstadoSecado == "Inspección Finalizada - Rechazado")
                        {
                            Grid1[15, nFila].Style.BackColor = Color.Red;
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

            carga_grilla("N", c_num_guia, "");

            t_ultimo_boton.Text = "N";

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_docentry, id_lote;

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

            id_docentry = 0;

            try
            {
                id_docentry = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

            }
            catch
            {
                id_docentry = 0;

            }

            try
            {
                id_lote = Convert.ToInt32(Grid1[14, fila].Value.ToString().ToUpper());

            }
            catch
            {
                id_lote = 0;

            }

            String mensaje = clsCalidad.SAPB1_ORCAL9(id_docentry);

            string UsuarioSap, ClaveSap;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            mensaje = clsRecepcion.Entrada_Mercaderia_ActualizaNumGuia(id_docentry, id_lote, UsuarioSap, ClaveSap);

            MessageBox.Show("Registro Actualizado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

        }

        private void btn_calidad_secado_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nIdCalidad, nLote;
            int nDocEntry_TR;
            string cItemCode_TR;

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

            nIdCalidad = 0;
            nLote = 0;

            try
            {
                nIdCalidad = Convert.ToInt32(Grid1[16, fila].Value.ToString().ToUpper());

            }
            catch
            {
                nIdCalidad = 0;

            }

            try
            {
                nLote = Convert.ToInt32(Grid1[14, fila].Value.ToString().ToUpper());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                nDocEntry_TR = Convert.ToInt32(Grid1[17, fila].Value.ToString().ToUpper());

            }
            catch
            {
                nDocEntry_TR = 0;

            }

            try
            {
                cItemCode_TR = Grid1[18, fila].Value.ToString().ToUpper();

            }
            catch
            {
                cItemCode_TR = "";

            }

            if (nDocEntry_TR > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = nDocEntry_TR;
                VariablesGlobales.glb_LineId = 0;

                VariablesGlobales.glb_NumOF = 0;
                VariablesGlobales.glb_LineNumOF = 0;

                VariablesGlobales.glb_ItemCode = cItemCode_TR;
                VariablesGlobales.glb_Lote = nLote;


                //VariablesGlobales.glb_id_calidad = 0;

                frmCalidadPP4 fv4 = new frmCalidadPP4();
                DialogResult res4 = fv4.ShowDialog();

            }

            btn_registros_pendientes_Click(sender, e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id_docentry, id_lote, id_lote_old;

            string UsuarioSap, ClaveSap, mensaje;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                id_docentry = 0;

                try
                {
                    id_docentry = Convert.ToInt32(Grid1[0, i].Value.ToString().ToUpper());

                }
                catch
                {
                    id_docentry = 0;

                }

                try
                {
                    id_lote_old = Convert.ToInt32(Grid1[2, i].Value.ToString().ToUpper());

                }
                catch
                {
                    id_lote_old = 0;

                }

                try
                {
                    id_lote = Convert.ToInt32(Grid1[14, i].Value.ToString().ToUpper());

                }
                catch
                {
                    id_lote = 0;

                }

                //id_lote_old = 0;

                if (id_lote_old != id_lote)
                {
                    if (id_lote > 0)
                    {

                        mensaje = clsRecepcion.Entrada_Mercaderia_ActualizaNumGuia(id_docentry, id_lote, UsuarioSap, ClaveSap);

                        Grid1[2, i].Value = Grid1[14, i].Value;
                        Application.DoEvents();

                    }

                }

            }


        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            int fila;

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

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());
            }
            catch
            {
                nDocEntry = 0;
            }


            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_Referencia1 = nDocEntry.ToString();
            VariablesGlobales.glb_Referencia2 = 0.ToString();

            frmRecepcionMP5 f2 = new frmRecepcionMP5();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_Referencia2 = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            int fila;

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

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());
            }
            catch
            {
                nDocEntry = 0;
            }


            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_Referencia1 = nDocEntry.ToString();

            frmRecepcionMPB4 f2 = new frmRecepcionMPB4();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_Referencia1 = "";

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

        }
    }

}
