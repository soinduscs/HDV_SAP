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
    public partial class frmCalidadPP5 : Form
    {
        public frmCalidadPP5()
        {
            InitializeComponent();
        }

        private void frmCalidadPP5_Load(object sender, EventArgs e)
        {

            t_ref.Text = "1";

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos();

            cbb_procesos.DataSource = objproducto.cResultado;
            cbb_procesos.ValueMember = "FldValue";
            cbb_procesos.DisplayMember = "Descr";

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_Calibres_combo();

            cbb_calibre.DataSource = objproducto1.cResultado;
            cbb_calibre.ValueMember = "Code";
            cbb_calibre.DisplayMember = "Name";

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_Variedades_combo();

            cbb_variedad.DataSource = objproducto2.cResultado;
            cbb_variedad.ValueMember = "Code";
            cbb_variedad.DisplayMember = "Name";

            t_ref.Clear();

            Carga_datos();

        }

        private void cbb_procesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_datos();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string cProceso, cVariedad, cCalibre;

            try
            {
                cProceso = cbb_procesos.SelectedValue.ToString();
            }
            catch
            {
                cProceso = "";
            }

            if (cProceso=="Sorter 1")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "Sorter 2")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "NCC L1")
            {
                cProceso = "NCC L";
            }

            if (cProceso == "NCC L2")
            {
                cProceso = "NCC L";
            }

            try
            {
                cVariedad = cbb_variedad.SelectedValue.ToString();
            }
            catch
            {
                cVariedad = "";
            }

            try
            {
                cCalibre = cbb_calibre.SelectedValue.ToString();
            }
            catch
            {
                cCalibre = "";
            }

            if (cProceso == "")
            {
                return;
            }

            ///////////////////////////////////////
            ///////////////////////////////////////
            // Detalle

            String mensaje = clsCalidad.SAPB1_ATRP3(cProceso, cVariedad, cCalibre, "x_x", 0, 0, "");

            string cCodAtr, cLocked;
            double nMinimo, nMaximo;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                cCodAtr = "";
                cLocked = "";

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
                    cLocked = Grid1[5, i].Value.ToString().Trim();
                }
                catch
                {
                    cLocked = "";
                }

                if (cLocked != "S")
                {
                    cLocked = "";
                }

                try
                {
                    nMinimo = Convert.ToDouble(Grid1[3, i].Value.ToString());
                }
                catch
                {
                    nMinimo = 0;
                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                if (cCodAtr.Trim() != "")
                {

                    mensaje = clsCalidad.SAPB1_ATRP3(cProceso, cVariedad, cCalibre, cCodAtr, nMinimo, nMaximo, cLocked);

                }

            }

            ///////////////////////////////////////
            ///////////////////////////////////////
            // Cabecera

            mensaje = clsCalidad.SAPB1_ATRP4(cProceso, cVariedad, cCalibre, "x_x", 0);

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                cCodAtr = "";
                nMaximo = 0;

                try
                {
                    cCodAtr = Grid2[0, i].Value.ToString().Trim();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid2[1, i].Value.ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                if (cCodAtr.Trim() != "")
                {

                    mensaje = clsCalidad.SAPB1_ATRP4(cProceso, cVariedad, cCalibre, cCodAtr, nMaximo);

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

            Carga_datos();

        }

        private void cbb_variedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_datos();
        }

        private void cbb_calibre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_datos();
        }

        private void Carga_datos()
        {
            if (t_ref.Text == "1")
            {
                return;
            }

            string cProceso, cVariedad, cCalibre;

            try
            {
                cVariedad = cbb_variedad.SelectedValue.ToString();
            }
            catch
            {
                cVariedad = "";
            }

            try
            {
                cCalibre = cbb_calibre.SelectedValue.ToString();
            }
            catch
            {
                cCalibre = "";
            }

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

            if (cProceso == "Sorter 1")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "Sorter 2")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "NCC L1")
            {
                cProceso = "NCC L";
            }

            if (cProceso == "NCC L2")
            {
                cProceso = "NCC L";
            }

            Grid1.Rows.Clear();

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos_x_items_V2(cProceso, cVariedad, cCalibre);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cCode, cAtributo, cLocked;
            double nMinimo, nMaximo;
            int nCant_Lineas;

            nCant_Lineas = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cCode = dTable.Rows[i]["U_CodAtr"].ToString();
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

                try
                {
                    cLocked = dTable.Rows[i]["U_Locked"].ToString();
                }
                catch
                {
                    cLocked = "";
                }

                grilla[0] = cCode;
                grilla[1] = cCode;
                grilla[2] = cAtributo;
                grilla[3] = nMinimo.ToString("N2");
                grilla[4] = nMaximo.ToString("N2");
                grilla[5] = cLocked;

                Grid1.Rows.Add(grilla);

                if (cCode != "")
                {
                    nCant_Lineas += 1;
                }

            }

            if (nCant_Lineas == 0)
            {
                Grid1.Rows.Clear();

                clsCalidad objproducto1 = new clsCalidad();
                objproducto1.cls_ConsultaLista_Procesos_x_items(cProceso);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                Grid1.Rows.Clear();

                for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCode = dTable1.Rows[i]["Code"].ToString();
                    }
                    catch
                    {
                        cCode = "";
                    }

                    try
                    {
                        cAtributo = dTable1.Rows[i]["U_NameAtr"].ToString();
                    }
                    catch
                    {
                        cAtributo = "";
                    }

                    try
                    {
                        nMinimo = Convert.ToDouble(dTable1.Rows[i]["U_Minimo"].ToString());
                    }
                    catch
                    {
                        nMinimo = 0;
                    }

                    try
                    {
                        nMaximo = Convert.ToDouble(dTable1.Rows[i]["U_Maximo"].ToString());
                    }
                    catch
                    {
                        nMaximo = 0;
                    }

                    grilla[0] = cCode;
                    grilla[1] = cCode;
                    grilla[2] = cAtributo;
                    grilla[3] = nMinimo.ToString("N2");
                    grilla[4] = nMaximo.ToString("N2");
                    grilla[5] = "";

                    Grid1.Rows.Add(grilla);

                }

            }

            nCant_Lineas = 0;

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_ConsultaLista_Procesos_x_items_V4(cProceso, cVariedad, cCalibre);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();

            nCant_Lineas = 0;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    cCode = dTable2.Rows[i]["U_Comment"].ToString();
                }
                catch
                {
                    cCode = "";
                }                

                try
                {
                    nMaximo = Convert.ToDouble(dTable2.Rows[i]["U_Maximo"].ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                grilla[0] = cCode;               
                grilla[1] = nMaximo.ToString("N2");

                Grid2.Rows.Add(grilla);

                if (cCode != "")
                {
                    nCant_Lineas += 1;
                }

            }


            if (nCant_Lineas == 0)
            {
                Grid2.Rows.Clear();

                clsCalidad objproducto3 = new clsCalidad();
                objproducto3.cls_ConsultaLista_Procesos_x_items_V3(cProceso);

                DataTable dTable3 = new DataTable();
                dTable3 = objproducto3.cResultado;

                for (int i = 0; i <= dTable3.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCode = dTable3.Rows[i]["U_Comment"].ToString();
                    }
                    catch
                    {
                        cCode = "";
                    }

                    nMaximo = 0;

                    grilla[0] = cCode;
                    grilla[1] = nMaximo.ToString("N2");

                    Grid2.Rows.Add(grilla);

                }

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

            double nMinimo, nMaximo;
            string cLocked;

            nMinimo = 0;
            nMaximo = 0;
            cLocked = "";

            try
            {
                nMinimo = Convert.ToDouble(Grid1[3, fila].Value.ToString());
            }
            catch
            {
                nMinimo = 0;
            }

            try
            {
                nMaximo = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                nMaximo = 0;
            }

            try
            {
                cLocked = Grid1[5, fila].Value.ToString();
            }
            catch
            {
                cLocked = "";
            }

            if (cLocked != "")
            {
                if (cLocked != "S")
                {
                    cLocked = "";
                }

            }

            Grid1[3, fila].Value = nMinimo.ToString("N2");
            Grid1[4, fila].Value = nMaximo.ToString("N2");
            Grid1[5, fila].Value = cLocked;

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

            double nMaximo;

           nMaximo = 0;

            try
            {
                nMaximo = Convert.ToDouble(Grid2[1, fila].Value.ToString());
            }
            catch
            {
                nMaximo = 0;
            }

            Grid2[1, fila].Value = nMaximo.ToString("N2");

        }
    }

}
