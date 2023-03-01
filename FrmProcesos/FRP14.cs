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
    public partial class FRP14 : Form
    {
        public FRP14()
        {
            InitializeComponent();
        }

        private void FRP14_Load(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes_almacen();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            ///////////////////////////////////////////////////////

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            grilla[0] = "R";
            grilla[1] = "Rojo";
            grilla[2] = 0.ToString("N");
            grilla[3] = 0.ToString("N");

            Grid1.Rows.Add(grilla);
            Grid2.Rows.Add(grilla);

            grilla[0] = "A";
            grilla[1] = "Amarillo";
            grilla[2] = 0.ToString("N");
            grilla[3] = 0.ToString("N");

            Grid1.Rows.Add(grilla);
            Grid2.Rows.Add(grilla);

            grilla[0] = "V";
            grilla[1] = "Verde";
            grilla[2] = 0.ToString("N");
            grilla[3] = 0.ToString("N");

            Grid1.Rows.Add(grilla);
            Grid2.Rows.Add(grilla);

            t_meta_mp.Text = 0.ToString("N2");
            t_meta_pt.Text = 0.ToString("N2");

            if (VariablesGlobales.glb_CardCode != "")
            {
                cbb_almacen.Visible = false;

                t_WhsCode.Text = VariablesGlobales.glb_CardCode;
                t_WhsCode.Visible = true;

                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Almacenes_x_WhsCode(VariablesGlobales.glb_CardCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                double n_meta_pt, n_meta_mp;

                double n_r_ini_pt, n_r_fin_pt, n_a_ini_pt, n_a_fin_pt, n_v_ini_pt, n_v_fin_pt;
                double n_r_ini_mp, n_r_fin_mp, n_a_ini_mp, n_a_fin_mp, n_v_ini_mp, n_v_fin_mp;

                try
                {
                    n_meta_pt = Convert.ToDouble(dTable.Rows[0]["U_Capacidad_PT"].ToString());
                }
                catch
                {
                    n_meta_pt = 0;
                }

                t_meta_pt.Text = n_meta_pt.ToString("N2");

                try
                {
                    n_r_ini_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_R_Ini"].ToString()); 

                }
                catch
                {
                    n_r_ini_pt = 0;

                }

                try
                {
                    n_r_fin_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_R_Fin"].ToString());

                }
                catch
                {
                    n_r_fin_pt = 0;

                }

                Grid1[2, 0].Value = n_r_ini_pt.ToString("N");
                Grid1[3, 0].Value = n_r_fin_pt.ToString("N");

                try
                {
                    n_a_ini_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_A_Ini"].ToString());  

                }
                catch
                {
                    n_a_ini_pt = 0;

                }

                try
                {
                    n_a_fin_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_A_Fin"].ToString());

                }
                catch
                {
                    n_a_fin_pt = 0;

                }

                Grid1[2, 1].Value = n_a_ini_pt.ToString("N");
                Grid1[3, 1].Value = n_a_fin_pt.ToString("N");

                try
                {
                    n_v_ini_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_V_Ini"].ToString());

                }
                catch
                {
                    n_v_ini_pt = 0;

                }

                try
                {
                    n_v_fin_pt = Convert.ToDouble(dTable.Rows[0]["U_PT_V_Fin"].ToString());

                }
                catch
                {
                    n_v_fin_pt = 0;

                }

                Grid1[2, 2].Value = n_v_ini_pt.ToString("N");
                Grid1[3, 2].Value = n_v_fin_pt.ToString("N");

                try
                {
                    n_meta_mp = Convert.ToDouble(dTable.Rows[0]["U_Capacidad_MP"].ToString());
                }
                catch
                {
                    n_meta_mp = 0;
                }

                t_meta_mp.Text = n_meta_mp.ToString("N2");

                try
                {
                    n_r_ini_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_R_Ini"].ToString());

                }
                catch
                {
                    n_r_ini_mp = 0;

                }

                try
                {
                    n_r_fin_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_R_Fin"].ToString());

                }
                catch
                {
                    n_r_fin_mp = 0;

                }

                Grid2[2, 0].Value = n_r_ini_mp.ToString("N");
                Grid2[3, 0].Value = n_r_fin_mp.ToString("N");

                try
                {
                    n_a_ini_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_A_Ini"].ToString());

                }
                catch
                {
                    n_a_ini_mp = 0;

                }

                try
                {
                    n_a_fin_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_A_Fin"].ToString());

                }
                catch
                {
                    n_a_fin_mp = 0;

                }

                Grid2[2, 1].Value = n_a_ini_mp.ToString("N");
                Grid2[3, 1].Value = n_a_fin_mp.ToString("N");

                try
                {
                    n_v_ini_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_V_Ini"].ToString());

                }
                catch
                {
                    n_v_ini_mp = 0;

                }

                try
                {
                    n_v_fin_mp = Convert.ToDouble(dTable.Rows[0]["U_MP_V_Fin"].ToString());

                }
                catch
                {
                    n_v_fin_mp = 0;

                }

                Grid2[2, 2].Value = n_v_ini_mp.ToString("N");
                Grid2[3, 2].Value = n_v_fin_mp.ToString("N");



            }



        }


        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            double n_r_ini_pt, n_r_fin_pt, n_a_ini_pt, n_a_fin_pt, n_v_ini_pt, n_v_fin_pt;
            double n_r_ini_mp, n_r_fin_mp, n_a_ini_mp, n_a_fin_mp, n_v_ini_mp, n_v_fin_mp;

            try
            {
                n_r_ini_pt = Convert.ToDouble(Grid1[2, 0].Value);

            }
            catch
            {
                n_r_ini_pt = 0;

            }

            try
            {
                n_r_fin_pt = Convert.ToDouble(Grid1[3, 0].Value);

            }
            catch
            {
                n_r_fin_pt = 0;

            }

            try
            {
                n_a_ini_pt = Convert.ToDouble(Grid1[2, 1].Value);

            }
            catch
            {
                n_a_ini_pt = 0;

            }

            try
            {
                n_a_fin_pt = Convert.ToDouble(Grid1[3, 1].Value);

            }
            catch
            {
                n_a_fin_pt = 0;

            }

            try
            {
                n_v_ini_pt = Convert.ToDouble(Grid1[2, 2].Value);

            }
            catch
            {
                n_v_ini_pt = 0;

            }

            try
            {
                n_v_fin_pt = Convert.ToDouble(Grid1[3, 2].Value);

            }
            catch
            {
                n_v_fin_pt = 0;

            }

            try
            {
                n_r_ini_mp = Convert.ToDouble(Grid2[2, 0].Value);

            }
            catch
            {
                n_r_ini_mp = 0;

            }

            try
            {
                n_r_fin_mp = Convert.ToDouble(Grid2[3, 0].Value);

            }
            catch
            {
                n_r_fin_mp = 0;

            }

            try
            {
                n_a_ini_mp = Convert.ToDouble(Grid2[2, 1].Value);

            }
            catch
            {
                n_a_ini_mp = 0;

            }

            try
            {
                n_a_fin_mp = Convert.ToDouble(Grid2[3, 1].Value);

            }
            catch
            {
                n_a_fin_mp = 0;

            }

            try
            {
                n_v_ini_mp = Convert.ToDouble(Grid2[2, 2].Value);

            }
            catch
            {
                n_v_ini_mp = 0;

            }

            try
            {
                n_v_fin_mp = Convert.ToDouble(Grid2[3, 2].Value);

            }
            catch
            {
                n_v_fin_mp = 0;

            }

            double n_r_rev_pt, n_a_rev_pt, n_v_rev_pt;
            double n_r_rev_mp, n_a_rev_mp, n_v_rev_mp;

            try
            {
                n_r_rev_pt = n_r_ini_pt - n_r_fin_pt;

            }
            catch
            {
                n_r_rev_pt = 0;

            }

            try
            {
                n_a_rev_pt = n_a_ini_pt - n_a_fin_pt;

            }
            catch
            {
                n_a_rev_pt = 0;

            }

            try
            {
                n_v_rev_pt = n_v_ini_pt - n_v_fin_pt;

            }
            catch
            {
                n_v_rev_pt = 0;

            }

            try
            {
                n_r_rev_mp = n_r_ini_mp - n_r_fin_mp;

            }
            catch
            {
                n_r_rev_mp = 0;

            }

            try
            {
                n_a_rev_mp = n_a_ini_mp - n_a_fin_mp;

            }
            catch
            {
                n_a_rev_mp = 0;

            }

            try
            {
                n_v_rev_mp = n_v_ini_mp - n_v_fin_mp;

            }
            catch
            {
                n_v_rev_mp = 0;

            }

            n_v_fin_pt = n_r_rev_pt + n_a_rev_pt + n_v_rev_pt;
            n_v_fin_mp = n_r_rev_mp + n_a_rev_mp + n_v_rev_mp;

            if (n_v_fin_pt < 0)
            {
                n_v_fin_pt = n_v_fin_pt * -1;

            }

            if (n_v_fin_mp < 0)
            {
                n_v_fin_mp = n_v_fin_mp * -1;

            }

            n_v_fin_pt = n_v_fin_pt + 0.4;
            n_v_fin_mp = n_v_fin_mp + 0.4;

            n_v_fin_pt = Math.Round(n_v_fin_pt , 0);
            n_v_fin_mp = Math.Round(n_v_fin_mp , 0);

            if (n_v_fin_pt != 100 )
            {
                MessageBox.Show("Registro de PT no valido", "Definición de almacenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
                //Close();

            }

            if (n_v_fin_mp != 100)
            {
                MessageBox.Show("Registro de MP no valido", "Definición de almacenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

                //Close();

            }

            string c_code, c_WhsCode;

            if (t_WhsCode.Visible == false)
            {
                c_code = "";
                c_WhsCode = cbb_almacen.Text;

                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Almacenes_x_WhsCode_new();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                int n_code;

                try
                {
                    n_code = Convert.ToInt32(dTable.Rows[0]["Code"].ToString());
                }
                catch
                {
                    n_code = 0;
                }

                n_code += 1;
                c_code = n_code.ToString();

            }
            else
            {
                c_code = "1";
                c_WhsCode = t_WhsCode.Text;

            }

            double n_capacidad_pt, n_capacidad_mp;

            n_capacidad_pt = 0;
            n_capacidad_mp = 0;

            try
            {
                n_capacidad_pt = Convert.ToDouble(t_meta_pt.Text);
            }
            catch
            {
                n_capacidad_pt = 0;
            }

            try
            {
                n_capacidad_mp = Convert.ToDouble(t_meta_mp.Text);
            }
            catch
            {
                n_capacidad_mp = 0;
            }

            //double n_r_ini_pt, n_r_fin_pt, n_a_ini_pt, n_a_fin_pt, n_v_ini_pt, n_v_fin_pt;
            //double n_r_ini_mp, n_r_fin_mp, n_a_ini_mp, n_a_fin_mp, n_v_ini_mp, n_v_fin_mp;

            try
            {
                n_r_ini_pt = Convert.ToDouble(Grid1[2, 0].Value.ToString());

            }
            catch
            {
                n_r_ini_pt = 0;

            }

            try
            {
                n_r_fin_pt = Convert.ToDouble(Grid1[3, 0].Value.ToString());

            }
            catch
            {
                n_r_fin_pt = 0;

            }

            try
            {
                n_a_ini_pt = Convert.ToDouble(Grid1[2, 1].Value.ToString());

            }
            catch
            {
                n_a_ini_pt = 0;

            }

            try
            {
                n_a_fin_pt = Convert.ToDouble(Grid1[3, 1].Value.ToString());

            }
            catch
            {
                n_a_fin_pt = 0;

            }

            try
            {
                n_v_ini_pt = Convert.ToDouble(Grid1[2, 2].Value.ToString());

            }
            catch
            {
                n_v_ini_pt = 0;

            }

            try
            {
                n_v_fin_pt = Convert.ToDouble(Grid1[3, 2].Value.ToString());

            }
            catch
            {
                n_v_fin_pt = 0;

            }

            try
            {
                n_r_ini_mp = Convert.ToDouble(Grid2[2, 0].Value.ToString());

            }
            catch
            {
                n_r_ini_mp = 0;

            }

            try
            {
                n_r_fin_mp = Convert.ToDouble(Grid2[3, 0].Value.ToString());

            }
            catch
            {
                n_r_fin_mp = 0;

            }

            try
            {
                n_a_ini_mp = Convert.ToDouble(Grid2[2, 1].Value.ToString());

            }
            catch
            {
                n_a_ini_mp = 0;

            }

            try
            {
                n_a_fin_mp = Convert.ToDouble(Grid2[3, 1].Value.ToString());

            }
            catch
            {
                n_a_fin_mp = 0;

            }

            try
            {
                n_v_ini_mp = Convert.ToDouble(Grid2[2, 2].Value.ToString());

            }
            catch
            {
                n_v_ini_mp = 0;

            }

            try
            {
                n_v_fin_mp = Convert.ToDouble(Grid2[3, 2].Value.ToString());

            }
            catch
            {
                n_v_fin_mp = 0;

            }

            if (c_code != "")
            {
                if (n_capacidad_pt > 0)
                {

                    // (string d_code, string d_whscode,double d_Capacidad_PT, double d_PT_R_Ini, double d_PT_R_Fin, double d_PT_A_Ini, double d_PT_A_Fin, double d_PT_V_Ini, double d_PT_V_Fin, double d_Capacidad_MP, double d_MP_R_Ini, double d_MP_R_Fin, double d_MP_A_Ini, double d_MP_A_Fin, double d_MP_V_Ini, double d_MP_V_Fin)
                    String mensaje1;

                    if (t_WhsCode.Visible == false)
                    {
                        mensaje1 = clsMaestros.SAPB1_OALMACEN(c_code, c_WhsCode, n_capacidad_pt, n_r_ini_pt, n_r_fin_pt, n_a_ini_pt, n_a_fin_pt, n_v_ini_pt, n_v_fin_pt, n_capacidad_mp, n_r_ini_mp, n_r_fin_mp, n_a_ini_mp, n_a_fin_mp, n_v_ini_mp, n_v_fin_mp);

                    }
                    else
                    {
                        mensaje1 = clsMaestros.SAPB1_OALMACEN_u(c_code, c_WhsCode, n_capacidad_pt, n_r_ini_pt, n_r_fin_pt, n_a_ini_pt, n_a_fin_pt, n_v_ini_pt, n_v_fin_pt, n_capacidad_mp, n_r_ini_mp, n_r_fin_mp, n_a_ini_mp, n_a_fin_mp, n_v_ini_mp, n_v_fin_mp);

                    }




                    if (mensaje1 == "Y")
                    {
                        //MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(mensaje1, "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            MessageBox.Show("Registro Grabado", "Definición de Temporadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }

        private void t_meta_pt_Leave(object sender, EventArgs e)
        {

            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_meta_pt.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_meta_pt.Text = n_valor.ToString("N2");

        }

        private void t_meta_mp_Leave(object sender, EventArgs e)
        {

            double n_valor;

            n_valor = 0;

            try
            {
                n_valor = Convert.ToDouble(t_meta_mp.Text);

            }
            catch
            {
                n_valor = 0;

            }

            t_meta_mp.Text = n_valor.ToString("N2");

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil;
            double n_Ini, n_Fin;

            fil = 0;
            n_Ini = 0; 
            n_Fin = 0;

            try
            {
                fil = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                n_Ini = Convert.ToDouble(Grid1[2, fil].Value);

            }
            catch
            {
                n_Ini = 0;

            }

            Grid1[2, fil].Value = n_Ini.ToString("N");

            try
            {
                n_Fin = Convert.ToDouble(Grid1[3, fil].Value);

            }
            catch
            {
                n_Fin = 0;

            }

            Grid1[3, fil].Value = n_Fin.ToString("N");

        }

        private void Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil;
            double n_Ini, n_Fin;

            fil = 0;
            n_Ini = 0;
            n_Fin = 0;

            try
            {
                fil = Grid2.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                n_Ini = Convert.ToDouble(Grid2[2, fil].Value);

            }
            catch
            {
                n_Ini = 0;

            }

            Grid2[2, fil].Value = n_Ini.ToString("N");

            try
            {
                n_Fin = Convert.ToDouble(Grid2[3, fil].Value);

            }
            catch
            {
                n_Fin = 0;

            }

            Grid2[3, fil].Value = n_Fin.ToString("N");

        }

    }

}
