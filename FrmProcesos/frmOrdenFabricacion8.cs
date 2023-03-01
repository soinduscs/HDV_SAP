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
    public partial class frmOrdenFabricacion8 : Form
    {
        public frmOrdenFabricacion8()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion8_Load(object sender, EventArgs e)
        {
            carga_orden_fabricacion();
        }

        private void carga_orden_fabricacion()
        {

            DateTime dFecha_emision, dFecha_Planificacion;

            string cDocNum, cItemCode, cItemName;
            string cResponsable, cProceso, cItemName_I;
            string cWareHouse;

            double nCantidadPlanificada, nCantidadCompletada;

            double nInsumoRequerido, nInsumoCompletado, nInsumoStock;

            int nDocNum_Coordinado;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Planifacadas_con_insumos("R");

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cDocNum = dTable.Rows[i]["DocNum"].ToString();
                }
                catch
                {
                    cDocNum = "";

                }

                try
                {
                    dFecha_emision = Convert.ToDateTime(dTable.Rows[i]["PostDate"].ToString());
                }
                catch
                {
                    dFecha_emision = DateTime.Parse("01/01/1900");
                }

                try
                {
                    dFecha_Planificacion = Convert.ToDateTime(dTable.Rows[i]["StartDate"].ToString());
                }
                catch
                {
                    dFecha_Planificacion = DateTime.Parse("01/01/1900");
                }


                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    cProceso = dTable.Rows[i]["U_Proceso"].ToString();
                }
                catch
                {
                    cProceso = "";
                }

                try
                {
                    cResponsable = dTable.Rows[i]["NomResponsable"].ToString();
                }
                catch
                {
                    cResponsable = "";
                }

                try
                {
                    nCantidadPlanificada = Convert.ToDouble(dTable.Rows[i]["PlannedQty"].ToString());
                }
                catch
                {
                    nCantidadPlanificada = 0;
                }

                try
                {
                    nCantidadCompletada = Convert.ToDouble(dTable.Rows[i]["CmpltQty"].ToString());
                }
                catch
                {
                    nCantidadCompletada = 0;
                }

                try
                {
                    cItemName_I = dTable.Rows[i]["ItemName_I"].ToString();
                }
                catch
                {
                    cItemName_I = "";
                }

                try
                {
                    nInsumoRequerido = Convert.ToDouble(dTable.Rows[i]["PlannedQty_I"].ToString());
                }
                catch
                {
                    nInsumoRequerido = 0;
                }

                try
                {
                    nInsumoCompletado = Convert.ToDouble(dTable.Rows[i]["IssuedQty_I"].ToString());
                }
                catch
                {
                    nInsumoCompletado = 0;
                }

                try
                {
                    nInsumoStock = Convert.ToDouble(dTable.Rows[i]["OnHand_I"].ToString());
                }
                catch
                {
                    nInsumoStock = 0;
                }

                try
                {
                    nDocNum_Coordinado = int.Parse(dTable.Rows[i]["DocNum_Coordinado"].ToString());
                }
                catch
                {
                    nDocNum_Coordinado = 0;
                }

                try
                {
                    cWareHouse = dTable.Rows[i]["WareHouse"].ToString();
                }
                catch
                {
                    cWareHouse = "";
                }

                grilla[1] = cDocNum;
                grilla[2] = nDocNum_Coordinado.ToString();
                grilla[3] = dFecha_emision.ToString("dd/MM/yyyy");
                grilla[4] = dFecha_Planificacion.ToString("dd/MM/yyyy");
                grilla[5] = cItemCode;
                grilla[6] = cItemName;
                grilla[7] = cProceso;
                grilla[8] = nCantidadPlanificada.ToString("N2");
                grilla[9] = nCantidadCompletada.ToString("N2");
                grilla[10] = cItemName_I;
                grilla[11] = nInsumoRequerido.ToString("N2");
                grilla[12] = nInsumoCompletado.ToString("N2");
                grilla[13] = nInsumoStock.ToString("N2");
                grilla[14] = cWareHouse;
                grilla[15] = cResponsable;

                Grid1.Rows.Add(grilla);

                if (nDocNum_Coordinado == 0)
                {
                    Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                else
                {
                    Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            carga_orden_fabricacion();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
