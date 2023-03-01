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
    public partial class frmAsistencia : Form
    {
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_consulta_dependencia1_gestper();

            cbb_area.DataSource = objproducto.cResultado;
            cbb_area.ValueMember = "codigo";
            cbb_area.DisplayMember = "descripcion";

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.cls_consulta_centros_costo_gestper();

            cbb_ccosto.DataSource = objproducto2.cResultado;
            cbb_ccosto.ValueMember = "codigo";
            cbb_ccosto.DisplayMember = "descripcion";

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_consulta_lista_de_turno();

            cbb_turno.DataSource = objproducto3.cResultado;
            cbb_turno.ValueMember = "codigo";
            cbb_turno.DisplayMember = "Rango";
            cbb_turno.Text = "(Sel. Turno)";

            clsProduccion objproducto3a = new clsProduccion();
            objproducto3a.cls_consulta_lista_de_status();

            cbb_estado.DataSource = objproducto3a.cResultado;
            cbb_estado.ValueMember = "codigo";
            cbb_estado.DisplayMember = "Codigo";
            cbb_estado.Text = "(Sel. Estado)";

            clsProduccion objproducto3b = new clsProduccion();
            objproducto3b.cls_consulta_lista_de_turno();

            cbb_turno_a.DataSource = objproducto3b.cResultado;
            cbb_turno_a.ValueMember = "codigo";
            cbb_turno_a.DisplayMember = "codigo";
            cbb_turno_a.Text = "(Sel. Turno)";

            clsProduccion objproducto3c = new clsProduccion();
            objproducto3c.cls_consulta_lista_de_turno();

            cbb_turno_b.DataSource = objproducto3c.cResultado;
            cbb_turno_b.ValueMember = "codigo";
            cbb_turno_b.DisplayMember = "codigo";
            cbb_turno_b.Text = "(Sel. Turno)";

            // *********************************************
            // Lunes

            clsProduccion objproducto4 = new clsProduccion();
            objproducto4.cls_consulta_lista_de_status();

            DataGridViewComboBoxColumn my_DGVCboColumn4 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn4.DataSource = objproducto4.cResultado;
            my_DGVCboColumn4.Name = "LUN";
            my_DGVCboColumn4.ValueMember = "Codigo";
            my_DGVCboColumn4.DisplayMember = "Codigo";

            Grid1.Columns.RemoveAt(8);
            Grid1.Columns.Insert(8, my_DGVCboColumn4);
            Grid1.Columns[8].Width = 50;

            // *********************************************
            // Martes

            clsProduccion objproducto5 = new clsProduccion();
            objproducto5.cls_consulta_lista_de_status();

            DataGridViewComboBoxColumn my_DGVCboColumn5 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn5.DataSource = objproducto5.cResultado;
            my_DGVCboColumn5.Name = "MAR";
            my_DGVCboColumn5.ValueMember = "Codigo";
            my_DGVCboColumn5.DisplayMember = "Codigo";

            Grid1.Columns.RemoveAt(9);
            Grid1.Columns.Insert(9, my_DGVCboColumn5);
            Grid1.Columns[9].Width = 50;

            // *********************************************
            // Miercoles

            clsProduccion objproducto6 = new clsProduccion();
            objproducto6.cls_consulta_lista_de_status();

            DataGridViewComboBoxColumn my_DGVCboColumn6 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn6.DataSource = objproducto6.cResultado;
            my_DGVCboColumn6.Name = "MIE";
            my_DGVCboColumn6.ValueMember = "Codigo";
            my_DGVCboColumn6.DisplayMember = "Codigo";

            Grid1.Columns.RemoveAt(10);
            Grid1.Columns.Insert(10, my_DGVCboColumn6);
            Grid1.Columns[10].Width = 50;

            // *********************************************
            // Jueves

            clsProduccion objproducto7 = new clsProduccion();
            objproducto7.cls_consulta_lista_de_status();

            DataGridViewComboBoxColumn my_DGVCboColumn7 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn7.DataSource = objproducto7.cResultado;
            my_DGVCboColumn7.Name = "JUE";
            my_DGVCboColumn7.ValueMember = "Codigo";
            my_DGVCboColumn7.DisplayMember = "Codigo";

            Grid1.Columns.RemoveAt(11);
            Grid1.Columns.Insert(11, my_DGVCboColumn7);
            Grid1.Columns[11].Width = 50;

            // *********************************************
            // Viernes

            clsProduccion objproducto8 = new clsProduccion();
            objproducto8.cls_consulta_lista_de_status();

            DataGridViewComboBoxColumn my_DGVCboColumn8 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn8.DataSource = objproducto8.cResultado;
            my_DGVCboColumn8.Name = "VIE";
            my_DGVCboColumn8.ValueMember = "Codigo";
            my_DGVCboColumn8.DisplayMember = "Codigo";

            Grid1.Columns.RemoveAt(12);
            Grid1.Columns.Insert(12, my_DGVCboColumn8);
            Grid1.Columns[12].Width = 50;

            t_nombre.Text = VariablesGlobales.glb_User_Name;
            t_responsable.Text = VariablesGlobales.glb_User_Code;

            cbb_anho.SelectedIndex = 1;

            cbb_semana.Items.Clear();

            for (int i = 1; i <= 53; i++)
            {
                cbb_semana.Items.Add(i.ToString()); 

            }

            int nNumSemana;

            nNumSemana = 0;

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_consulta_numero_semana_actual();

            DataTable dTable = new DataTable();
            dTable = objproducto1.cResultado;

            try
            {
                nNumSemana = Convert.ToInt32(dTable.Rows[0]["NumSemana_Actual"].ToString());
            }
            catch
            {
                nNumSemana = 0;
            }

            cbb_semana.SelectedIndex = nNumSemana-1;




        }

        private void cbb_semana_SelectedIndexChanged(object sender, EventArgs e)
        {

            int nNumSemana, nAnho;

            t_fecha_desde.Text = "";
            t_fecha_hasta.Text = "";

            if (cbb_semana.SelectedIndex >= 0)
            {
                try
                {
                    nAnho = Convert.ToInt32(cbb_anho.Text);
                }
                catch
                {
                    nAnho = 2019;
                }

                DateTime dFechaIni, dFechaFin;

                nNumSemana = cbb_semana.SelectedIndex + 1;

                clsProduccion objproducto1 = new clsProduccion();
                objproducto1.cls_consulta_fechas_por_semana(nNumSemana, nAnho);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;

                try
                {
                    dFechaIni = Convert.ToDateTime(dTable.Rows[0]["FechaIni"].ToString());
                }
                catch
                {
                    dFechaIni = Convert.ToDateTime("01/01/1900");
                }

                try
                {
                    dFechaFin = Convert.ToDateTime(dTable.Rows[0]["FechaFin"].ToString());
                }
                catch
                {
                    dFechaFin = Convert.ToDateTime("01/01/1900");
                }

                t_fecha_desde.Text = dFechaIni.ToString("dd/MM/yyyy");
                t_fecha_hasta.Text = dFechaFin.ToString("dd/MM/yyyy");

            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {
                int nNumSemana, nAnho;
                string ccosto, cdependencia;

                if (cbb_semana.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un número de semana válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    nAnho = Convert.ToInt32(cbb_anho.Text);
                }
                catch
                {
                    nAnho = 2019;
                }

                if (cbb_ccosto.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un centro de costo válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    ccosto = cbb_ccosto.SelectedValue.ToString();

                }
                catch
                {
                    ccosto = "";

                }

                if (ccosto == "")
                {
                    MessageBox.Show("Debe seleccionar un centro de costo válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                if (cbb_area.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un área válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    cdependencia = cbb_area.SelectedValue.ToString();

                }
                catch
                {
                    cdependencia = "";

                }

                if (cdependencia == "")
                {
                    MessageBox.Show("Debe seleccionar un área válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                nNumSemana = cbb_semana.SelectedIndex + 1;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_xSapb1_utiles_muestratarjaporperiodo("",nNumSemana, nAnho, ccosto, cdependencia);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry;

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

                    grilla[0] = nDocEntry.ToString();

                    try
                    {
                        grilla[1] = dTable.Rows[i]["nom_empleado"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["rut"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["nom_cargo"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[i]["nom_dependencia1"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["nom_dependencia2"].ToString();
                    }
                    catch
                    {
                        grilla[5] = "";
                    }

                    try
                    {
                        grilla[6] = dTable.Rows[i]["Turno"].ToString();
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[8] = dTable.Rows[i]["Lu"].ToString();
                    }
                    catch
                    {
                        grilla[8] = "";
                    }

                    try
                    {
                        grilla[9] = dTable.Rows[i]["Ma"].ToString();
                    }
                    catch
                    {
                        grilla[9] = "";
                    }

                    try
                    {
                        grilla[10] = dTable.Rows[i]["Mi"].ToString();
                    }
                    catch
                    {
                        grilla[10] = "";
                    }

                    try
                    {
                        grilla[11] = dTable.Rows[i]["Ju"].ToString();
                    }
                    catch
                    {
                        grilla[11] = "";
                    }

                    try
                    {
                        grilla[12] = dTable.Rows[i]["Vi"].ToString();
                    }
                    catch
                    {
                        grilla[12] = "";
                    }

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            actualiza_grilla();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void actualiza_grilla()
        {

            string cturno, cnom_turno;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                try
                {
                    cturno = Grid1[6, x].Value.ToString();

                }
                catch
                {
                    cturno = "";

                }

                cnom_turno = "";

                if (cturno != "")
                {
                    clsProduccion objproducto = new clsProduccion();
                    objproducto.cls_consulta_lista_de_turno_x_codigo(cturno);

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        cnom_turno = dTable.Rows[0]["Rango"].ToString();
                    }
                    catch
                    {
                        cnom_turno = "";
                    }

                }

                Grid1[7, x].Value = cnom_turno;

            }


        }

        private void btn_cambia_turno_Click(object sender, EventArgs e)
        {

            string cturno;

            if (cbb_turno.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cturno = cbb_turno.SelectedValue.ToString();
            }
            catch
            {
                cturno = "";
            }

            if (cturno == "")
            {
                MessageBox.Show("Debe seleccionar un turno válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                if (Grid1.Rows[x].Selected == true)
                {
                    Grid1[6, x].Value = cturno;

                }

            }

            actualiza_grilla();

        }

        private void btn_cambiar_dia_Click(object sender, EventArgs e)
        {

            string cdia, cestado;

            if (cbb_dia.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un día válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cdia = cbb_dia.Text;
            }
            catch
            {
                cdia = "";
            }

            if (cdia == "")
            {
                MessageBox.Show("Debe seleccionar un día válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_estado.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un estado válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cestado = cbb_estado.SelectedValue.ToString();
            }
            catch
            {
                cestado = "";
            }

            if (cestado == "")
            {
                MessageBox.Show("Debe seleccionar un estado válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nCol;

            nCol = 8;

            if (cdia == "LUN")
            {
                nCol = 8;
            }

            if (cdia == "MAR")
            {
                nCol = 9;
            }

            if (cdia == "MIE")
            {
                nCol = 10;
            }

            if (cdia == "JUE")
            {
                nCol = 11;
            }

            if (cdia == "VIE")
            {
                nCol = 12;
            }

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                if (Grid1.Rows[x].Selected == true)
                {
                    Grid1[nCol, x].Value = cestado;

                }

            }


        }

        private void btn_crear_Click(object sender, EventArgs e)
        {

            int nDocEntry;
            string cTurno, cLun, cMar;
            string cMie, cJue, cVie;

            if (Grid1.RowCount <= 1)
            {
                MessageBox.Show("No existen regsitros válidos, opción cancelada", "Administración de asistencia ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    nDocEntry = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nDocEntry = -1;
                }

                try
                {
                    cTurno = Grid1[6, i].Value.ToString();
                }
                catch
                {
                    cTurno = "";
                }

                try
                {
                    cLun = Grid1[8, i].Value.ToString();
                }
                catch
                {
                    cLun = "";
                }

                try
                {
                    cMar = Grid1[9, i].Value.ToString();
                }
                catch
                {
                    cMar = "";
                }

                try
                {
                    cMie = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cMie = "";
                }

                try
                {
                    cJue = Grid1[11, i].Value.ToString();
                }
                catch
                {
                    cJue = "";
                }

                try
                {
                    cVie = Grid1[12, i].Value.ToString();
                }
                catch
                {
                    cVie = "";
                }

                try
                {
                    String mensaje = clsOrdenFabricacion.SAPB1_OTARJA("A", nDocEntry, VariablesGlobales.glb_User_id, cTurno, cLun, cMar, cMie, cJue, cVie);

                }
                catch
                {

                }

            }

            MessageBox.Show("Registro grabado con Exito!!", "Administración de asistencia ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btn_rotar_Click(object sender, EventArgs e)
        {
            string cturno_a, cturno_b;

            if (cbb_turno_a.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_turno_b.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un turno válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cturno_a = cbb_turno_a.SelectedValue.ToString();
            }
            catch
            {
                cturno_a = "";
            }

            if (cturno_a == "")
            {
                MessageBox.Show("Debe seleccionar un turno A - válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cturno_b = cbb_turno_b.SelectedValue.ToString();
            }
            catch
            {
                cturno_b = "";
            }

            if (cturno_b == "")
            {
                MessageBox.Show("Debe seleccionar un turno B - válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                if (Grid1[6, x].Value.ToString() == cturno_a.ToString())
                {
                    Grid1[6, x].Value = cturno_b;
                }
                else
                {
                    if (Grid1[6, x].Value.ToString() == cturno_b.ToString())
                    {
                        Grid1[6, x].Value = cturno_a;
                    }

                }


            }

            actualiza_grilla();

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            int nCant_filas;
            string cdependencia;

            try
            {
                nCant_filas = Grid1.RowCount - 1;

            }
           catch
            {
                nCant_filas = 0;

            }
            
            if (nCant_filas == 0)
            {
                MessageBox.Show("No existen datos para visualizar", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_area.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un área válida", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cdependencia = cbb_area.SelectedValue.ToString();

            }
            catch
            {
                cdependencia = "";

            }

            t_idrut_empleado.Clear();
            t_nombre_empleado.Clear();

            t_idrut_empleado.Text = VariablesGlobales.glb_id_rut.ToString();
            t_nombre_empleado.Text = VariablesGlobales.glb_Empleado;

            VariablesGlobales.glb_Area = cdependencia;
            VariablesGlobales.glb_id_rut = 0;
            VariablesGlobales.glb_Empleado = "";

            frmSel_Empleados f2 = new frmSel_Empleados();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Area != "")
            {

                t_idrut_empleado.Text = VariablesGlobales.glb_id_rut.ToString();
                t_nombre_empleado.Text = VariablesGlobales.glb_Empleado;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (t_idrut_empleado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un empleado válido", "Administración de asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }





        }

    }


}
