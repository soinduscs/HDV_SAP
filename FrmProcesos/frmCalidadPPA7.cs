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
    public partial class frmCalidadPPA7 : Form
    {
        public frmCalidadPPA7()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA7_Load(object sender, EventArgs e)
        {

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos1();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "Code";
            cbb_procesos.DisplayMember = "U_NameAtr";

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            carga_procesos(cMatriz);

            carga_detalle(cMatriz);

        }

        private void cbb_procesos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            carga_procesos(cMatriz);

            carga_detalle(cMatriz);

        }


        private void carga_detalle(string cMatriz)
        {
            int nMatriz;

            try
            {
                nMatriz = Convert.ToInt32(cMatriz);

            }
            catch
            {
                nMatriz = 0;

            }

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRP8l(nMatriz.ToString());

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cCode_D, cNomAtributo_D, cUM_D;
            string cObject_D, cRef_Calibre;

            double nDesde_D, nHasta_D, nStandard_D;

            int nFx_Detalle, nFx_Porcentaje, nFx_Orden_X;
            int nFx_ValTala_X;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                nDesde_D = 0;
                nHasta_D = 0;
                nFx_Detalle = 0;
                nFx_Porcentaje = 0;
                cRef_Calibre = "";

                try
                {
                    cCode_D = dTable2.Rows[i]["U_CodAtr"].ToString();
                }
                catch
                {
                    cCode_D = "";
                }

                try
                {
                    cNomAtributo_D = dTable2.Rows[i]["U_NameAtr"].ToString();
                }
                catch
                {
                    cNomAtributo_D = "";
                }

                try
                {
                    cUM_D = dTable2.Rows[i]["U_UM"].ToString();
                }
                catch
                {
                    cUM_D = "";
                }

                try
                {
                    nDesde_D = double.Parse(dTable2.Rows[i]["U_Minimo"].ToString());
                }
                catch
                {
                    nDesde_D = 0;
                }

                try
                {
                    nHasta_D = double.Parse(dTable2.Rows[i]["U_Maximo"].ToString());
                }
                catch
                {
                    nHasta_D = 0;
                }

                try
                {
                    nStandard_D = double.Parse(dTable2.Rows[i]["U_Standard"].ToString());
                }
                catch
                {
                    nStandard_D = 0;
                }

                try
                {
                    cObject_D = dTable2.Rows[i]["Object"].ToString();

                }
                catch
                {
                    cObject_D = "";

                }

                try
                {
                    nFx_Detalle = Convert.ToInt32(dTable2.Rows[i]["Fx_Detalle"].ToString());

                }
                catch
                {
                    nFx_Detalle = 0;

                }

                try
                {
                    nFx_Porcentaje = Convert.ToInt32(dTable2.Rows[i]["Fx_Porcentaje"].ToString());

                }
                catch
                {
                    nFx_Porcentaje = 0;

                }

                try
                {
                    nFx_Orden_X = Convert.ToInt32(dTable2.Rows[i]["Fx_Orden_X"].ToString());

                }
                catch
                {
                    nFx_Orden_X = 0;

                }

                try
                {
                    nFx_ValTala_X = Convert.ToInt32(dTable2.Rows[i]["Fx_ValTabla_X"].ToString());

                }
                catch
                {
                    nFx_ValTala_X = 0;

                }

                try
                {
                    cRef_Calibre = dTable2.Rows[i]["Ref_Calibre"].ToString();

                }
                catch
                {
                    cRef_Calibre = "";

                }

                grilla[0] = (i + 1).ToString(); //cLineId_D.ToString();
                grilla[1] = cCode_D;
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();

                grilla[4] = nDesde_D.ToString("N2");
                grilla[5] = nHasta_D.ToString("N2");

                grilla[6] = nStandard_D.ToString("N2");
                grilla[7] = cObject_D.ToUpper();

                if (cObject_D.ToUpper() != "X")
                {

                    if (cRef_Calibre == "C")
                    {
                        Grid4.Rows.Add(grilla);

                        Grid4[8, Grid4.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png"); ;

                        if (nFx_Detalle > 0)
                        {
                            Grid4[8, Grid4.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Function).ico"); ;

                        }

                        Grid4[9, Grid4.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png"); ;

                        if (nFx_Porcentaje > 0)
                        {
                            Grid4[9, Grid4.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Function).ico"); ;

                        }

                        if (cObject_D.ToUpper() == "C")
                        {
                            for (int x = 0; x <= 7; x++)
                            {
                                try
                                {
                                    Grid4[x, Grid4.RowCount - 1].Style.BackColor = Color.LightGray;

                                }
                                catch
                                {

                                }
                            }

                        }

                    }
                    else
                    {
                        Grid2.Rows.Add(grilla);

                        Grid2[8, Grid2.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png"); ;

                        if (nFx_Detalle > 0)
                        {
                            Grid2[8, Grid2.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Function).ico"); ;

                        }

                        Grid2[9, Grid2.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png"); ;

                        if (nFx_Porcentaje > 0)
                        {
                            Grid2[9, Grid2.RowCount - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Function).ico"); ;

                        }

                        if (cObject_D.ToUpper() == "C")
                        {
                            for (int x = 0; x <= 7; x++)
                            {
                                try
                                {
                                    Grid2[x, Grid2.RowCount - 1].Style.BackColor = Color.LightGray;

                                }
                                catch
                                {

                                }
                            }

                        }

                    }


                }

                if (cObject_D.ToUpper() == "X")
                {
                    grilla[4] = nFx_Orden_X.ToString("N2");
                    grilla[5] = nFx_ValTala_X.ToString("N2");

                    Grid3.Rows.Add(grilla);

                }

            }

        }

        private void carga_procesos(string cMatriz)
        {

            // Cargo los procesos ---

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRP8(cMatriz);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];
            string cCode_D, cProceso_D;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                cCode_D = "";
                cProceso_D = "";

                try
                {
                    cCode_D = dTable2.Rows[i]["Code"].ToString();
                }
                catch
                {
                    cCode_D = "";
                }

                try
                {
                    cProceso_D = dTable2.Rows[i]["U_Proceso"].ToString();
                }
                catch
                {
                    cProceso_D = "";
                }

                grilla[0] = cCode_D;
                grilla[1] = cProceso_D;

                Grid1.Rows.Add(grilla);

            }

            // Veo si el usuario tien algun permiso ---

            int nUserid, nProceso_Autoriz;

            try
            {
                nUserid = VariablesGlobales.glb_User_id;

            }
            catch
            {
                nUserid = 0;

            }

            nProceso_Autoriz = 0;

            clsCalidad objproducto3 = new clsCalidad();
            objproducto3.cls_Consulta_ATRP8_usuario(cMatriz, nUserid);

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto3.cResultado;

            int nAsignado;

            for (int i = 0; i <= dTable3.Rows.Count - 1; i++)
            {
                try
                {
                    nAsignado = Convert.ToInt32(dTable3.Rows[i]["Code_Ref"].ToString());

                }
                catch
                {
                    nAsignado = 0;

                }

                if (nAsignado != 0)
                {
                    nProceso_Autoriz += 1;

                }

            }

            if (nProceso_Autoriz == 0)
            {
                button5.Enabled = false;
                button7.Enabled = false;
                button6.Enabled = false;

                btn_proc_Agregar.Enabled = false;
                btn_proc_quitar.Enabled = false;

                btn_propiedades.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;

                btn_propiedades1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;

            }
            else
            {
                button5.Enabled = true;
                button7.Enabled = true;
                button6.Enabled = true;

                btn_proc_Agregar.Enabled = true;
                btn_proc_quitar.Enabled = true;

                btn_propiedades.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;

                btn_propiedades1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;

            }


        }

        private void btn_proc_Agregar_Click(object sender, EventArgs e)
        {

            string cCode;

            try
            {
                cCode = cbb_procesos.SelectedValue.ToString();
            }
            catch
            {
                cCode = "";
            }

            if (cCode == "")
            {
                MessageBox.Show("Debe seleccionar una mariz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_Object = cCode;

            //////////////////////////////////////
            // Genero el avance de proceso

            frmCalidadPPA8 f2 = new frmCalidadPPA8();
            DialogResult res = f2.ShowDialog();

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            carga_procesos(cMatriz);

        }

        private void btn_proc_quitar_Click(object sender, EventArgs e)
        {
            
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCode;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cCode = Grid1[0, fila].Value.ToString();
            }
            catch
            {
                cCode = "";
            }

            if (cCode == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //////////////////////////////////////
            // Genero el avance de proceso

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de eliminar este registro", "Matriz de Procesos de Calidad", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje;

                mensaje = "";

                try
                {
                    mensaje = clsCalidad.SAPB1_ATRP8e(cCode.ToString(), "", "");
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            carga_procesos(cMatriz);

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_propiedades_Click(object sender, EventArgs e)
        {

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid2[1, fila].Value.ToString();
                cObject = Grid2[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid2[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            if (cMatriz == "460")
            {
                VariablesGlobales.glb_Referencia1 = "ALMENDRA";

            }

            if (cMatriz == "464")
            {
                VariablesGlobales.glb_Referencia1 = "NCC";

            }

            frmCalidadPPB0 f2 = new frmCalidadPPB0();
            DialogResult res = f2.ShowDialog();

            //cbb_procesos_SelectedIndexChanged(sender, e);

        }

        private void Grid2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btn_propiedades1_Click(object sender, EventArgs e)
        {

            if (Grid3.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid3[1, fila].Value.ToString();
                cObject = Grid3[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid3[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            if (cMatriz == "460")
            {
                VariablesGlobales.glb_Referencia1 = "ALMENDRA";

            }

            if (cMatriz == "464")
            {
                VariablesGlobales.glb_Referencia1 = "NCC";

            }

            frmCalidadPPB0 f2 = new frmCalidadPPB0();
            DialogResult res = f2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid2[1, fila].Value.ToString();
                cObject = Grid2[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid2[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            if (cMatriz == "460")
            {
                VariablesGlobales.glb_Referencia1 = "ALMENDRA";

            }

            if (cMatriz == "464")
            {
                VariablesGlobales.glb_Referencia1 = "NCC";

            }

            frmCalidadPPB5 f2 = new frmCalidadPPB5();
            DialogResult res = f2.ShowDialog();

            cbb_procesos_SelectedIndexChanged(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Grid3.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid3.RowCount >= 4)
            {
                MessageBox.Show("No se pueden agregar mas registros, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid3[1, fila].Value.ToString();
                cObject = Grid3[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid3[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            if (cMatriz == "460")
            {
                VariablesGlobales.glb_Referencia1 = "ALMENDRA";

            }

            if (cMatriz == "464")
            {
                VariablesGlobales.glb_Referencia1 = "NCC";

            }

            frmCalidadPPB5 f2 = new frmCalidadPPB5();
            DialogResult res = f2.ShowDialog();

            cbb_procesos_SelectedIndexChanged(sender, e);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid2[1, fila].Value.ToString();
                cObject = Grid2[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid2[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            string mensaje;

            if (cCodAtr != "")
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Eliminar este Parametro", "Matriz de Procesos ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    mensaje = "";

                    try
                    {
                        mensaje = clsCalidad.SAPB1_Eliminar_Atributo_ATRP1(cCodAtr);
                    }
                    catch
                    {
                        MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        mensaje = clsCalidad.SAPB1_Eliminar_Atributo_ATRP3(cCodAtr);
                    }
                    catch
                    {
                        MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }

            cbb_procesos_SelectedIndexChanged(sender, e);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (Grid3.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr, cObject;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

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

            try
            {
                cCodAtr = Grid3[1, fila].Value.ToString();
                cObject = Grid3[7, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";
                cObject = "";

            }

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_CodAtr = cCodAtr;
            VariablesGlobales.glb_NameAtr = Grid3[2, fila].Value.ToString();
            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_MatrizAtr = cMatriz;

            string mensaje;

            if (cCodAtr != "")
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Eliminar este Parametro", "Matriz de Procesos ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    mensaje = "";

                    try
                    {
                        mensaje = clsCalidad.SAPB1_Eliminar_Atributo_ATRP1(cCodAtr);
                    }
                    catch
                    {
                        MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        mensaje = clsCalidad.SAPB1_Eliminar_Atributo_ATRP3(cCodAtr);
                    }
                    catch
                    {
                        MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }

            frmCalidadPPA7_Load(sender, e);
            //cbb_procesos_SelectedIndexChanged(sender, e);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_MatrizAtr = cMatriz;
            VariablesGlobales.glb_NameAtr = cbb_procesos.Text;

            frmCalidadPPB6 f2 = new frmCalidadPPB6();
            DialogResult res = f2.ShowDialog();

            frmCalidadPPA7_Load(sender, e);

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_MatrizAtr = cMatriz;
            VariablesGlobales.glb_NameAtr = cbb_procesos.Text;

            if (Grid1.Rows.Count != 0 )
            {
                MessageBox.Show("La matriz tiene procesos asociados, no puede ser eliminada, opción Cancelada", "Matriz de Procesos de Calidad ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string mensaje;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Copiar la Matriz de Parametros", "Matriz de Procesos ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                mensaje = "";

                try
                {
                    mensaje = clsCalidad.Sapb1_utiles_matriz_new(Convert.ToInt32(VariablesGlobales.glb_MatrizAtr), "","D");

                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            frmCalidadPPA7_Load(sender, e);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string cMatriz;

            try
            {
                cMatriz = cbb_procesos.SelectedValue.ToString();

            }
            catch
            {
                cMatriz = "";

            }

            VariablesGlobales.glb_MatrizAtr = cMatriz;
            VariablesGlobales.glb_NameAtr = cbb_procesos.Text;

            frmCalidadPPC2 f2 = new frmCalidadPPC2();
            DialogResult res = f2.ShowDialog();

            frmCalidadPPA7_Load(sender, e);

        }
    }
}


