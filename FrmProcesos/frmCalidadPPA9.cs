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
    public partial class frmCalidadPPA9 : Form
    {
        public frmCalidadPPA9()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA9_Load(object sender, EventArgs e)
        {

            t_codatr.Text = VariablesGlobales.glb_CodAtr;
            t_atributo.Text = VariablesGlobales.glb_NameAtr;
            t_referencia.Text = VariablesGlobales.glb_Referencia1;

            carga_detalle();

        }

        private void carga_detalle()
        {

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRP5l(t_codatr.Text, t_referencia.Text);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cCode_D, cNomAtributo_D, c_Accion_D;

            int nDocEntry, nDocEntry_Ref;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                nDocEntry = 0;
                nDocEntry_Ref = 0;
                c_Accion_D = "";

                try
                {
                    cCode_D = dTable2.Rows[i]["U_CodAtrD"].ToString();
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
                    nDocEntry = int.Parse(dTable2.Rows[i]["DocEntry"].ToString());
                }
                catch
                {
                    nDocEntry = 0;
                }

                try
                {
                    nDocEntry_Ref = int.Parse(dTable2.Rows[i]["U_DocEntry_Ref"].ToString());
                }
                catch
                {
                    nDocEntry_Ref = 0;
                }

                try
                {
                    c_Accion_D = dTable2.Rows[i]["U_Accion"].ToString();

                }
                catch
                {
                    c_Accion_D = "";

                }

                grilla[0] = nDocEntry.ToString(); 
                grilla[1] = cCode_D;
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = nDocEntry_Ref.ToString();
                grilla[4] = c_Accion_D;

                Grid2.Rows.Add(grilla);


            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_CodAtr = t_codatr.Text;
            VariablesGlobales.glb_CodAtrD = "";

            frmCalidadPPB1 f2 = new frmCalidadPPB1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CodAtrD != "")
            {
                string cMatriz;

                try
                {
                    cMatriz = t_referencia.Text;

                }
                catch
                {
                    cMatriz = "";

                }

                clsCalidad objproducto2 = new clsCalidad();
                objproducto2.cls_Consulta_max_ATRP5l();

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto2.cResultado;

                int nDocEntry;

                try
                {
                    nDocEntry = Convert.ToInt32(dTable2.Rows[0]["DocEntry"].ToString());

                }
                catch
                {
                    nDocEntry = 0;

                }

                nDocEntry += 1;

                string mensaje;

                mensaje = clsCalidad.U_Agregar_Linea_ATRP5(nDocEntry, t_codatr.Text, VariablesGlobales.glb_CodAtrD, cMatriz);

            }

            carga_detalle();

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            if (Grid2.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            string cCodAtr;

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
                cCodAtr = Grid2[1, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";

            }

            string cMatriz;

            try
            {
                cMatriz = t_referencia.Text;

            }
            catch
            {
                cMatriz = "";

            }

            string mensaje;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Matriz de Procesos de Calidad", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                mensaje = clsCalidad.U_Eliminar_Linea_ATRP5(t_codatr.Text, cCodAtr, cMatriz);

                carga_detalle();

            }

        }

        private void Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fila;

            fila = 0;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cAccion, cDocEntry;

            cAccion = "";
            cDocEntry = "0";

            try
            {
                cDocEntry = Grid2[0, fila].Value.ToString();

            }
            catch
            {
                cDocEntry = "0";

            }

            try
            {
                cAccion = Grid2[4, fila].Value.ToString();

            }
            catch
            {
                cAccion = "";

            }

            string mensaje;

            mensaje = clsCalidad.U_Actualiza_Linea_ATRP5(Convert.ToInt32(cDocEntry), cAccion);


        }

        private void btn_ok1_Click(object sender, EventArgs e)
        {
            Close();

        }
    }

}
