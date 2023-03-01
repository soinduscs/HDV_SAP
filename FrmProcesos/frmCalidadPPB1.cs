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
    public partial class frmCalidadPPB1 : Form
    {
        public frmCalidadPPB1()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB1_Load(object sender, EventArgs e)
        {

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRP5l_plus(VariablesGlobales.glb_MatrizAtr, VariablesGlobales.glb_CodAtr, VariablesGlobales.glb_Referencia1);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cCode_D, cNomAtributo_D, cUM_D;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";

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

                grilla[0] = cCode_D;
                grilla[1] = cNomAtributo_D.ToString();
                grilla[2] = cUM_D.ToUpper();

                Grid2.Rows.Add(grilla);

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
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
                cCodAtr = Grid2[0, fila].Value.ToString();

            }
            catch
            {
                cCodAtr = "";

            }

            VariablesGlobales.glb_CodAtrD = cCodAtr;

            Close();

        }

    }

}
