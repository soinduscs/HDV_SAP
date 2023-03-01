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
    public partial class frmCalidadPPB0 : Form
    {
        public frmCalidadPPB0()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB0_Load(object sender, EventArgs e)
        {

            groupBox6.Visible = false;

            t_codatr.Text = VariablesGlobales.glb_CodAtr;
            t_atributo.Text = VariablesGlobales.glb_NameAtr;

            txt_tipo_analisis_control.Text = VariablesGlobales.glb_Referencia1;

            cbb_TipoAnalisis.Enabled = false;
            chk_locked.Visible = false;

            if (txt_tipo_analisis_control.Text == "ALMENDRA")
            {
                cbb_TipoAnalisis.Enabled = true;
                chk_locked.Visible = true;

            }

            if (txt_tipo_analisis_control.Text == "NCC")
            {
                cbb_TipoAnalisis.Enabled = true;
                chk_locked.Visible = true;

            }

            ////////////////////////////////////////
            // Esto se hace para el tipo de Registro

            clsMaestros objproducto8 = new clsMaestros();
            objproducto8.cls_Consultar_AtributoCalidad_RI(txt_tipo_analisis_control.Text);

            cbb_TipoAnalisis.DataSource = objproducto8.cResultado;
            cbb_TipoAnalisis.ValueMember = "DocEntry";
            cbb_TipoAnalisis.DisplayMember = "U_Referencia";


            if (txt_tipo_analisis_control.Text == "")
            {
                Carga_datos();

            }

        }

        private void Carga_datos()
        {

            string cDocReferencia;

            cDocReferencia = "";

            if (cbb_TipoAnalisis.Enabled == true)
            {
                cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

            }
            else
            {
                cDocReferencia = "";

            }

            string cUM, cObject, cPorcentaje;
            string cCualitat, cFormula, cLocked;

            double nStandar;
            double nMinimo, nMinimo1;
            double nMaximo, nMaximo1;

            int nValor;

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_AtributoCalidad_RI2(t_codatr.Text, cDocReferencia);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                cUM = dTable1.Rows[0]["U_Metodo"].ToString();

            }
            catch
            {
                cUM = "";

            }

            try
            {
                nStandar = Convert.ToDouble(dTable1.Rows[0]["U_StandAtr"].ToString());

            }
            catch
            {
                nStandar = 0;

            }

            try
            {
                nMinimo = Convert.ToDouble(dTable1.Rows[0]["U_Minimo"].ToString());

            }
            catch
            {
                nMinimo = -33;

            }

            try
            {
                nMinimo1 = Convert.ToDouble(dTable1.Rows[0]["U_Minimo_1"].ToString());

            }
            catch
            {
                nMinimo1 = -33;

            }

            try
            {
                nMaximo = Convert.ToDouble(dTable1.Rows[0]["U_Maximo"].ToString());

            }
            catch
            {
                nMaximo = -33;

            }

            try
            {
                nMaximo1 = Convert.ToDouble(dTable1.Rows[0]["U_Maximo_1"].ToString());

            }
            catch
            {
                nMaximo1 = -33;

            }

            t_UM.Text = cUM;
            t_standar.Text = nStandar.ToString("N2");

            if (nMinimo1 != -33)
            {
                t_desde.Text = nMinimo1.ToString("N2");

            }
            else
            {
                t_desde.Text = nMinimo.ToString("N2");

            }

            if (nMaximo1 != -33)
            {
                t_hasta.Text = nMaximo1.ToString("N2");

            }
            else
            {
                t_hasta.Text = nMaximo.ToString("N2");

            }

            try
            {
                cObject = dTable1.Rows[0]["Object"].ToString();

            }
            catch
            {
                cObject = "";

            }

            try
            {
                cPorcentaje = dTable1.Rows[0]["U_AQL"].ToString();

            }
            catch
            {
                cPorcentaje = "";

            }

            try
            {
                cCualitat = dTable1.Rows[0]["U_Cualitat"].ToString();

            }
            catch
            {
                cCualitat = "";

            }

            try
            {
                cLocked = dTable1.Rows[0]["U_Locked"].ToString();
            }
            catch
            {
                cLocked = "X";
            }

            if (cLocked == "X")
            {
                chk_locked.Enabled = false;                    
                chk_locked.Checked = false;

            }
            else
            {
                chk_locked.Enabled = true;
                chk_locked.Checked = false;

                if (cLocked == "S")
                {
                    chk_locked.Checked = true;

                }

            }

            if (cObject == "")
            {
                cbb_comportamiento.SelectedIndex = 0;

            }

            if (cObject == "D")
            {
                // Digitado
                cbb_comportamiento.SelectedIndex = 1;

            }

            if (cObject == "C")
            {
                // Calculado
                cbb_comportamiento.SelectedIndex = 2;

            }

            if (cObject == "R")
            {
                // Resumen
                cbb_comportamiento.SelectedIndex = 3;

            }

            if (cPorcentaje == "")
            {
                comboBox1.SelectedIndex = 0;

            }

            if (cPorcentaje == "0")
            {
                // No Aplica
                comboBox1.SelectedIndex = 0;

            }

            if (cPorcentaje == "1")
            {
                // No Aplica
                comboBox1.SelectedIndex = 1;

            }

            if (cPorcentaje == "2")
            {
                // Valor Externo
                comboBox1.SelectedIndex = 2;

            }

            if (cPorcentaje == "3")
            {
                // Valor Externo
                comboBox1.SelectedIndex = 3;

            }

            try
            {
                cFormula = dTable1.Rows[0]["U_CodEquip"].ToString();

            }
            catch
            {
                cFormula = "";

            }

            try
            {
                nValor = Convert.ToInt32(dTable1.Rows[0]["U_TiempoEs"].ToString());

            }
            catch
            {
                nValor = 0;

            }

            if (cObject != "X")
            {
                groupBox4.Visible = true;
                groupBox5.Visible = false;

            }
            else
            {
                groupBox4.Visible = false;
                groupBox5.Visible = true;

                Carga_datos_2();

            }

            if (cPorcentaje == "3")
            {
                if (cFormula == "")
                {
                    cbb_operacion.SelectedIndex = 0;

                }

                if (cFormula == "/")
                {
                    cbb_operacion.SelectedIndex = 1;

                }

                if (cFormula == "*")
                {
                    cbb_operacion.SelectedIndex = 2;

                }

                t_valor_pie.Text = nValor.ToString();

            }

        }

        private void cbb_TipoAnalisis_SelectedIndexChanged(object sender, EventArgs e)

        {
            
            Carga_datos();

        }

        private void cbb_comportamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nItem;

            nItem = -1;

            try
            {
                nItem = cbb_comportamiento.SelectedIndex;

            }
            catch
            {
                nItem = -1;

            }

            if (nItem == 0)
            {
                t_comportamiento.Text = "";

            }

            if (nItem == 1)
            {
                // Digitado
                t_comportamiento.Text = "D";

            }

            if (nItem == 2)
            {
                // Calculado
                t_comportamiento.Text = "C";

            }

            if (nItem == 3)
            {
                // Resumen
                t_comportamiento.Text = "R";

            }

            if (t_comportamiento.Text == "C")
            {
                btn_detalle.Visible = true;

            }
            else
            {
                btn_detalle.Visible = false;

            }

        }

        private void btn_detalle_Click(object sender, EventArgs e)
        {

            string cDocReferencia;

            cDocReferencia = "";

            if (cbb_TipoAnalisis.Enabled == true)
            {
                cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

            }
            else
            {
                cDocReferencia = "";

            }

            VariablesGlobales.glb_CodAtr = t_codatr.Text;
            VariablesGlobales.glb_NameAtr = t_atributo.Text;
            VariablesGlobales.glb_Referencia1 = cDocReferencia;

            frmCalidadPPA9 f2 = new frmCalidadPPA9();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_CodAtr = "";
            VariablesGlobales.glb_NameAtr = "";
            VariablesGlobales.glb_Referencia1 = "";

        }

        private void btn_porcentaje_Click(object sender, EventArgs e)
        {

            int nItem;

            nItem = -1;

            try
            {
                nItem = comboBox1.SelectedIndex;

            }
            catch
            {
                nItem = -1;

            }

            if (nItem == 2)
            {
                // Valor Externo

                string cDocReferencia;

                cDocReferencia = "";

                if (cbb_TipoAnalisis.Enabled == true)
                {
                    cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

                }
                else
                {
                    cDocReferencia = "";

                }

                VariablesGlobales.glb_CodAtr = t_codatr.Text;
                VariablesGlobales.glb_NameAtr = t_atributo.Text;
                VariablesGlobales.glb_Referencia1 = cDocReferencia;

                frmCalidadPPB2 f2 = new frmCalidadPPB2();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_CodAtr = "";
                VariablesGlobales.glb_NameAtr = "";
                VariablesGlobales.glb_Referencia1 = "";

            }

            if (nItem == 3)
            {
                // Calculo fijo
                groupBox6.Visible = true;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int nItem;

            nItem = -1;

            try
            {
                nItem = comboBox1.SelectedIndex;

            }
            catch
            {
                nItem = -1;

            }

            if (nItem == 0)
            {
                t_comportamiento.Text = "";

            }

            if (nItem == 1)
            {
                // No aplica
                t_comportamiento.Text = "N";

            }

            if (nItem == 2)
            {
                // Valor Externo
                t_comportamiento.Text = "E";

            }

            if (nItem == 3)
            {
                // Valor Externo
                t_comportamiento.Text = "E";

            }

            if (t_comportamiento.Text == "E")
            {
                btn_porcentaje.Visible = true;

            }
            else
            {
                btn_porcentaje.Visible = false;

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            string cCod_Atr, cObj_Valor, cObj_Porcentaje;
            string cUM, cNom_Atr, cLocked; 

            int nItem;

            double nDesde, nHasta, nEstandar;

            //////////////////////////////////////
            // Grabo los parametros

            try
            {
                cCod_Atr = t_codatr.Text;

            }
            catch
            {
                cCod_Atr = "";
            }

            try
            {
                cNom_Atr = t_atributo.Text;

            }
            catch
            {
                cNom_Atr = "";
            }

            if (cCod_Atr == "")
            {
                MessageBox.Show("Debe seleccionar una matriz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cUM = "";
            nDesde = 0;
            nHasta = 0;
            nEstandar = 0;

            try
            {
                cUM = t_UM.Text;

            }
            catch
            {
                cUM = "";

            }

            try
            {
                nDesde = Convert.ToDouble(t_desde.Text);

            }
            catch
            {
                nDesde = 0;

            }

            try
            {
                nHasta = Convert.ToDouble(t_hasta.Text);

            }
            catch
            {
                nHasta = 0;

            }

            try
            {
                nEstandar = Convert.ToDouble(t_standar.Text);

            }
            catch
            {
                nEstandar = 0;

            }

            cLocked = "";

            if (chk_locked.Checked == true)
            {
                cLocked = "S";

            }

            string cDocReferencia;

            cDocReferencia = "";

            if (cbb_TipoAnalisis.Enabled == true)
            {
                cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

            }
            else
            {
                cDocReferencia = "";

            }

            if (cDocReferencia == "")
            {
                cDocReferencia = "0";

            }

            String mensaje;

            mensaje = "";

            try
            {
                mensaje = clsCalidad.SAPB1_Actualiza_ATRP3(cCod_Atr, Convert.ToInt32(cDocReferencia), nDesde, nHasta, cLocked);
            }
            catch
            {
                MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //////////////////////////////////////
            // Grabo las definiciones

            nItem = -1;

            try
            {
                nItem = cbb_comportamiento.SelectedIndex;

            }
            catch
            {
                nItem = -1;

            }

            cObj_Valor = "D";

            if (nItem == 0)
            {
                cObj_Valor = "D";

            }

            if (nItem == 1)
            {
                // Digitado
                cObj_Valor = "D";

            }

            if (nItem == 2)
            {
                // Calculado
                cObj_Valor = "C";

            }

            if (nItem == 3)
            {
                // Resumen
                cObj_Valor = "R";

            }

            nItem = -1;
            cObj_Porcentaje = "0";

            try
            {
                nItem = comboBox1.SelectedIndex;

            }
            catch
            {
                nItem = -1;

            }

            if (nItem == 0)
            {
                cObj_Porcentaje = "0";

            }

            if (nItem == 1)
            {
                // No aplica
                cObj_Porcentaje = "1";

            }

            if (nItem == 2)
            {
                // Valor Externo
                cObj_Porcentaje = "2";

            }

            if (nItem == 3)
            {
                // Calculo Directo
                cObj_Porcentaje = "3";

            }

            //////////////////////////////////////
            // Actualizo los registros

            mensaje = "";

            try
            {
                mensaje = clsCalidad.SAPB1_Actualiza_ATRP1(cCod_Atr, cObj_Valor, cObj_Porcentaje, cUM , nEstandar, cNom_Atr);
            }
            catch
            {
                MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cDocReferencia == "0")
            {
                try
                {
                    mensaje = clsCalidad.SAPB1_Actualiza_ATRP1_x(cCod_Atr, nDesde, nHasta);
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            Close();

        }

        private void t_desde_Leave(object sender, EventArgs e)
        {

            double nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToDouble(t_desde.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_desde.Text = nValor.ToString("N2");

        }

        private void t_hasta_Leave(object sender, EventArgs e)
        {

            double nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToDouble(t_hasta.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_hasta.Text = nValor.ToString("N2");

        }

        private void t_standar_Leave(object sender, EventArgs e)
        {

            double nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToDouble(t_standar.Text);

            }
            catch
            {
                nValor = 0;

            }

            t_standar.Text = nValor.ToString("N2");

        }

        private void Carga_datos_2()
        {

            string cCod_Atr;

            int nUbicacion;

            //////////////////////////////////////
            // Grabo los parametros

            try
            {
                cCod_Atr = t_codatr.Text;

            }
            catch
            {
                cCod_Atr = "";
            }

            if (cCod_Atr == "")
            {
                MessageBox.Show("Debe seleccionar una matriz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cDocReferencia;

            cDocReferencia = "";

            if (cbb_TipoAnalisis.Enabled == true)
            {
                cDocReferencia = cbb_TipoAnalisis.SelectedValue.ToString();

            }
            else
            {
                cDocReferencia = "";

            }

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_AtributoCalidad_RI2(t_codatr.Text, cDocReferencia);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            nUbicacion = 0;

            try
            {
                nUbicacion = Convert.ToInt32(dTable1.Rows[0]["U_TipoMues"].ToString());

            }
            catch
            {
                nUbicacion = 0;

            }

            try
            {
                cbb_UbicacionRgistro.SelectedIndex = nUbicacion;

            }
            catch
            {
                cbb_UbicacionRgistro.SelectedIndex = 0;
            }

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRPA0(t_codatr.Text);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cValue_D;
            int nId;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                nId = 0;
                cValue_D = "";

                try
                {
                    nId = Convert.ToInt32(dTable2.Rows[i]["U_Id"].ToString());
                }
                catch
                {
                    nId = 0;
                }

                try
                {
                    cValue_D = dTable2.Rows[i]["U_Value"].ToString();
                }
                catch
                {
                    cValue_D = "";
                }

                grilla[0] = nId.ToString();
                grilla[1] = cValue_D;

                Grid2.Rows.Add(grilla);

            }

        }

        private void btn_ok1_Click(object sender, EventArgs e)
        {

            string cCod_Atr;

            int nUbicacion;

            //////////////////////////////////////
            // Grabo los parametros

            try
            {
                cCod_Atr = t_codatr.Text;

            }
            catch
            {
                cCod_Atr = "";
            }

            if (cCod_Atr == "")
            {
                MessageBox.Show("Debe seleccionar una matriz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nUbicacion = 0;

            try
            {
                nUbicacion = cbb_UbicacionRgistro.SelectedIndex;

            }
            catch
            {
                nUbicacion = 0;

            }

            String mensaje;

            mensaje = "";

            try
            {
                mensaje = clsCalidad.SAPB1_Actualiza_ATRP1_y(cCod_Atr, nUbicacion);
            }
            catch
            {
                MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            string cCod_Atr;

            try
            {
                cCod_Atr = t_codatr.Text;

            }
            catch
            {
                cCod_Atr = "";
            }

            if (cCod_Atr == "")
            {
                MessageBox.Show("Debe seleccionar una matriz válida", "Variedades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_Referencia1 = "";

            frmCalidadPPB4 f2 = new frmCalidadPPB4();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Referencia1 != "_X_")
            {

                clsCalidad objproducto1 = new clsCalidad();
                objproducto1.cls_Consulta_max_ATRPA0x();

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                int nDocEntry;

                try
                {
                    nDocEntry = Convert.ToInt32(dTable1.Rows[0]["Code"].ToString());

                }
                catch
                {
                    nDocEntry = -1;

                }

                nDocEntry += 1;

                clsCalidad objproducto2 = new clsCalidad();
                objproducto2.cls_Consulta_max_ATRPA0l(cCod_Atr);

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto2.cResultado;

                int nLine;

                try
                {
                    nLine = Convert.ToInt32(dTable2.Rows[0]["U_Id"].ToString());

                }
                catch
                {
                    nLine = 0;

                }

                nLine += 1;

                string mensaje;

                mensaje = clsCalidad.U_Agregar_Linea_ATRPA0(nDocEntry, t_codatr.Text, nLine, VariablesGlobales.glb_Referencia1);

                Carga_datos_2(); 

            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            int fila, nId;
            string cCod_Atr;

            try
            {
                cCod_Atr = t_codatr.Text;

            }
            catch
            {
                cCod_Atr = "";
            }

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nId = Convert.ToInt32(Grid2[0, fila].Value.ToString());

            }
            catch
            {
                nId = 0;

            }

            string mensaje;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Matriz de Procesos de Calidad", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                mensaje = clsCalidad.U_Eliminar_Linea_ATRPA0(cCod_Atr, nId);

                Carga_datos_2();

            }

        }

        private void cbb_grabar_pie_Click(object sender, EventArgs e)
        {
            string c_formula;
            int n_Valor;

            c_formula = "";
            n_Valor = 0;

            try
            {
                c_formula = cbb_operacion.Text;

            }
            catch
            {
                c_formula = "";

            }

            try
            {
                n_Valor = Convert.ToInt32(t_valor_pie.Text);

            }
            catch
            {
                n_Valor = 0;

            }

            if (cbb_operacion.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una operación válida, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (c_formula == "")
            {
                MessageBox.Show("Debe seleccionar una operación válida, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (n_Valor == 0)
            {
                MessageBox.Show("Debe seleccionar un valor válido, opción Cancelada", "Matriz de Procesos de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de grabar el Registro?", "Matriz de Procesos de Calidad", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                String mensaje;

                mensaje = "";

                try
                {
                    mensaje = clsCalidad.SAPB1_Actualiza_ATRP1_z(t_codatr.Text, c_formula, n_Valor);
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                groupBox6.Visible = false;

                btn_ok_Click(sender, e);

            }

        }

        private void t_valor_pie_Leave(object sender, EventArgs e)
        {
            int nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToInt32(t_valor_pie.Text);
            }
            catch
            {
                nValor = 0;

            }

            t_valor_pie.Text = nValor.ToString();

        }

    }

}
