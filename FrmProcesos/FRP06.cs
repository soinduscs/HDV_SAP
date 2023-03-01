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
    public partial class FRP06 : Form
    {
        public FRP06()
        {
            InitializeComponent();
        }

        private void FRP06_Load(object sender, EventArgs e)
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

            carga_almacen(nUserid);

        }

        private void carga_usuarios()
        {


            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_usuarios();

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
                    Grid2[0, Grid2.Rows.Count-1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }
                else
                {
                    Grid2[0, Grid2.Rows.Count-1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");

                }

            }

        }

        private void Grid2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

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

                carga_almacen(nUsersign);

            }

        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {

            int UserId;
            string cCode, cWhsCode;

            try
            {
                UserId = Convert.ToInt32(t_item.Text);
            }
            catch
            {
                UserId = 0;
            }

            String mensaje = clsCalidad.SAPB1_OPRM(UserId, "x_x");

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                cCode = "";
                cWhsCode = "";

                cCode = Grid2[1, i].Value.ToString();
                cWhsCode = Grid2[2, i].Value.ToString();

                if (cCode == "1")
                {
                    mensaje = clsCalidad.SAPB1_OPRM(UserId, cWhsCode);

                }

            }
                
            MessageBox.Show("Registro Grabado", "Autorización por Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }

}
