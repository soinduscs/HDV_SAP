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
    public partial class FRP16 : Form
    {
        public FRP16()
        {
            InitializeComponent();
        }

        private void FRP16_Load(object sender, EventArgs e)
        {

            carga_usuarios();

            int nUserid;

            try
            {
                nUserid = Convert.ToInt32(Grid1[0, 0].Value);

            }
            catch
            {
                nUserid = 0;

            }

            t_item.Text = nUserid.ToString();

            carga_proceso();

            t_matriz.Text = Grid3[0, 0].Value.ToString();

            carga_procesos(t_matriz.Text, Convert.ToInt32(t_item.Text));

        }

        private void carga_procesos(string cMatriz, int nuserid)
        {

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_ATRP8_usuario(cMatriz, nuserid);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];
            string cCode_D, cProceso_D;
            int nAsignado;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                try
                {
                    nAsignado = Convert.ToInt32(dTable2.Rows[i]["Code_Ref"].ToString());

                }
                catch
                {
                    nAsignado = 0;

                }

                if (nAsignado == 0)
                {
                    grilla[1] = "0";

                }
                else
                {
                    grilla[1] = "1";

                }

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

                grilla[2] = cCode_D;
                grilla[3] = cProceso_D;

                Grid2.Rows.Add(grilla);

                if (nAsignado == 0)
                {
                    Grid2[0, Grid2.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }
                else
                {
                    Grid2[0, Grid2.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");

                }



            }

        }


        private void carga_usuarios()
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_usuarios1();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    grilla[0] = dTable.Rows[i]["USERID"].ToString();
                }
                catch
                {
                    grilla[0] = "";
                }

                try
                {
                    grilla[1] = dTable.Rows[i]["U_NAME"].ToString();
                }
                catch
                {
                    grilla[1] = "";
                }

                Grid1.Rows.Add(grilla);

            }

        }

        private void carga_proceso()
        {

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_ConsultaLista_Procesos1();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid3.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    grilla[0] = dTable.Rows[i]["Code"].ToString();
                }
                catch
                {
                    grilla[0] = "";
                }

                try
                {
                    grilla[1] = dTable.Rows[i]["U_NameAtr"].ToString();
                }
                catch
                {
                    grilla[1] = "";
                }

                Grid3.Rows.Add(grilla);

            }

        }

        private void carga_almacen(int d_usersign)
        {

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_almacen_asignado(d_usersign);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid2.Rows.Clear();

            string[] grilla;
            int nAsignado;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    nAsignado = Convert.ToInt32(dTable.Rows[i]["Asign"].ToString());

                }
                catch
                {
                    nAsignado = 0;

                }

                if (nAsignado == 0)
                {
                    grilla[1] = "0";

                }
                else
                {
                    grilla[1] = "1";

                }

                try
                {
                    grilla[2] = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    grilla[2] = "";
                }

                try
                {
                    grilla[3] = dTable.Rows[i]["WhsName"].ToString();
                }
                catch
                {
                    grilla[3] = "";
                }

                Grid2.Rows.Add(grilla);

                if (nAsignado == 0)
                {
                    Grid2[0, Grid2.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }
                else
                {
                    Grid2[0, Grid2.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");

                }

            }

        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {

            int UserId;
            string cCode, cCode_ref;

            try
            {
                UserId = Convert.ToInt32(t_item.Text);
            }
            catch
            {
                UserId = 0;
            }

            String mensaje = clsCalidad.SAPB1_OPRM(UserId, "y_y");

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                cCode = "";
                cCode_ref = "";

                cCode = Grid2[1, i].Value.ToString();
                cCode_ref = Grid2[2, i].Value.ToString();

                if (cCode == "1")
                {
                    mensaje = clsCalidad.SAPB1_OPRM(UserId, cCode_ref);

                }

            }

            MessageBox.Show("Registro Grabado", "Autorización por Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btn_marca_todos_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                Grid2[0, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");
                Grid2[1, i].Value = "1";

            }

        }

        private void btn_desmarca_todos_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                Grid2[0, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");
                Grid2[1, i].Value = "0";

            }

        }

        private void Grid2_DoubleClick(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {

                string cAsignado;

                try
                {
                    cAsignado = Grid2[1, fila].Value.ToString();

                }
                catch
                {
                    cAsignado = "0";

                }

                if (cAsignado == "0")
                {
                    Grid2[1, fila].Value = "1";
                    Grid2[0, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");

                }
                else
                {
                    Grid2[1, fila].Value = "0";
                    Grid2[0, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }

            }

        }

        private void Grid3_SelectionChanged(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {

                string cAsignado;

                try
                {
                    cAsignado = Grid3[0, fila].Value.ToString();

                }
                catch
                {
                    cAsignado = "0";

                }

                carga_procesos(cAsignado, Convert.ToInt32(t_item.Text));

            }

        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
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

            if (fila >= 0)
            {

                int nUsersign;

                try
                {
                    nUsersign = Convert.ToInt32(Grid1[0, fila].Value.ToString());

                }
                catch
                {
                    nUsersign = 0;

                }

                t_item.Text = nUsersign.ToString();

                carga_procesos(t_matriz.Text, Convert.ToInt32(t_item.Text));

            }

        }




    }

}
