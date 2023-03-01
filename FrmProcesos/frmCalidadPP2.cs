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
    public partial class frmCalidadPP2 : Form
    {
        public frmCalidadPP2()
        {
            InitializeComponent();
        }

        private void frmCalidadPP2_Load(object sender, EventArgs e)
        {

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "FldValue";
            cbb_procesos.DisplayMember = "Descr";

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string cProceso;

            try
            {
                cProceso = cbb_procesos.SelectedValue.ToString();
            }
            catch
            {
                cProceso = "";
            }

            if (cProceso == "")
            {
                return;
            }

            String mensaje = clsCalidad.SAPB1_ATRP2(cProceso, "x_x", "", 0, 0, 0);

            string cCodAtr, cNomAtr;
            double nStandard, nMinimo, nMaximo;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                cCodAtr = "";
                cNomAtr = "";

                nStandard = 0;
                nMinimo = 0;
                nMaximo = 0;

                try
                {
                    cCodAtr = Grid1[1, i].Value.ToString().Trim();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    cNomAtr = Grid1[2, i].Value.ToString().Trim();
                }
                catch
                {
                    cNomAtr = "";
                }

                try
                {
                    nStandard = Convert.ToDouble(Grid1[3, i].Value.ToString());

                }
                catch
                {
                    nStandard = 0;

                }

                try
                {
                    nMinimo = Convert.ToDouble(Grid1[4, i].Value.ToString());

                }
                catch
                {
                    nMinimo = 0;

                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid1[5, i].Value.ToString());

                }
                catch
                {
                    nMaximo = 0;

                }
               
                if (cCodAtr.Trim() != "")
                {

                    if (cNomAtr.Trim() != "")
                    {

                        mensaje = clsCalidad.SAPB1_ATRP2(cProceso, cCodAtr, cNomAtr, nStandard, nMinimo, nMaximo);

                    }

                }

            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cbb_procesos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string cProceso;

            try
            {
                cProceso = cbb_procesos.SelectedValue.ToString();
            }
            catch
            {
                cProceso = "";
            }

            if (cProceso == "")
            {
                return;
            }

            Grid1.Rows.Clear();

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos_x_items(cProceso);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cCode, cAtributo;
            double nStandar, nMinimo, nMaximo;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cCode = dTable.Rows[i]["Code"].ToString();
                }
                catch
                {
                    cCode = "";
                }

                try
                {
                    cAtributo = dTable.Rows[i]["U_NameAtr"].ToString();
                }
                catch
                {
                    cAtributo = "";
                }

                try
                {
                    nStandar = Convert.ToDouble(dTable.Rows[i]["U_StandAtr"].ToString());
                }
                catch
                {
                    nStandar = 0;
                }

                try
                {
                    nMinimo = Convert.ToDouble(dTable.Rows[i]["U_Minimo"].ToString());
                }
                catch
                {
                    nMinimo = 0;
                }

                try
                {
                    nMaximo = Convert.ToDouble(dTable.Rows[i]["U_Maximo"].ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                grilla[0] = cCode;
                grilla[1] = cCode;
                grilla[2] = cAtributo;
                grilla[3] = nStandar.ToString("N2");
                grilla[4] = nMinimo.ToString("N2");
                grilla[5] = nMaximo.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fila;

            fila = 0;

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double Standar, nMinimo, nMaximo;

            Standar = 0;
            nMinimo = 0;
            nMaximo = 0;

            try
            {
                Standar = Convert.ToDouble(Grid1[3, fila].Value.ToString());
            }
            catch
            {
                Standar = 0;

            }

            try
            {
                nMinimo = Convert.ToDouble(Grid1[4, fila].Value.ToString());

            }
            catch
            {
                nMinimo =0;

            }

            try
            {
                nMaximo = Convert.ToDouble(Grid1[5, fila].Value.ToString());

            }
            catch
            {
                nMaximo = 0;

            }

            Grid1[3, fila].Value = Standar.ToString("N2");
            Grid1[4, fila].Value = nMinimo.ToString("N2");
            Grid1[5, fila].Value = nMaximo.ToString("N2");

        }

    }

}
