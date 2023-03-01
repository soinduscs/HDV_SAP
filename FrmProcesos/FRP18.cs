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
    public partial class FRP18 : Form
    {
        public FRP18()
        {
            InitializeComponent();
        }

        private void FRP18_Load(object sender, EventArgs e)
        {

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;

            Grid1.Rows.Clear();


        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {

            try
            {

                string cNumOV, cCliente, cProducto;
                string cCalibre, cSalida;
                DateTime fecha1, fecha2;

                fecha1 = dtp_fecha1.Value;
                fecha2 = dtp_fecha2.Value;

                string cfecha1 = fecha1.ToString("yyyyMMdd");
                string cfecha2 = fecha2.ToString("yyyyMMdd");

                double nKilos, nPorcentaje;

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_consulta_utiles_resumen_Calibres("R", cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cNumOV = dTable.Rows[i]["Num_OV"].ToString();
                    }
                    catch
                    {
                        cNumOV = "";

                    }

                    try
                    {
                        cCliente = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cCliente = "";

                    }

                    try
                    {
                        cProducto = dTable.Rows[i]["U_ItemCode"].ToString();
                    }
                    catch
                    {
                        cProducto = "";

                    }

                    try
                    {
                        cCalibre = dTable.Rows[i]["Calibre_Lote"].ToString();
                    }
                    catch
                    {
                        cCalibre = "";

                    }

                    try
                    {
                        cSalida = dTable.Rows[i]["Name"].ToString();
                    }
                    catch
                    {
                        cSalida = "";

                    }

                    try
                    {
                        nKilos = double.Parse(dTable.Rows[i]["Kilos_Produccion"].ToString());
                    }
                    catch
                    {
                        nKilos = 0;
                    }

                    try
                    {
                        nPorcentaje = double.Parse(dTable.Rows[i]["Porcentaje_puerta"].ToString());
                    }
                    catch
                    {
                        nPorcentaje = 0;
                    }

                    grilla[0] = cNumOV; 
                    grilla[1] = cCliente;
                    grilla[2] = cProducto;
                    grilla[3] = cCalibre;
                    grilla[4] = cSalida;
                    grilla[5] = nKilos.ToString("N2");
                    grilla[6] = nPorcentaje.ToString("N2");

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                string cNumOV, cCliente, cProducto;
                string cCalibre, cSalida, cLote;
                DateTime fecha1, fecha2;

                fecha1 = dtp_fecha1.Value;
                fecha2 = dtp_fecha2.Value;

                string cfecha1 = fecha1.ToString("yyyyMMdd");
                string cfecha2 = fecha2.ToString("yyyyMMdd");

                double nKilos;

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_consulta_utiles_resumen_Calibres("D", cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cNumOV = dTable.Rows[i]["Num_OV"].ToString();
                    }
                    catch
                    {
                        cNumOV = "";

                    }

                    try
                    {
                        cCliente = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cCliente = "";

                    }

                    try
                    {
                        cProducto = dTable.Rows[i]["U_ItemCode"].ToString();
                    }
                    catch
                    {
                        cProducto = "";

                    }

                    try
                    {
                        cCalibre = dTable.Rows[i]["Calibre_Lote"].ToString();
                    }
                    catch
                    {
                        cCalibre = "";

                    }

                    try
                    {
                        cSalida = dTable.Rows[i]["Name"].ToString();
                    }
                    catch
                    {
                        cSalida = "";

                    }

                    try
                    {
                        cLote = dTable.Rows[i]["U_Lote"].ToString();
                    }
                    catch
                    {
                        cLote = "";

                    }

                    try
                    {
                        nKilos = double.Parse(dTable.Rows[i]["Kilos_Produccion"].ToString());
                    }
                    catch
                    {
                        nKilos = 0;
                    }

                    grilla[0] = cNumOV;
                    grilla[1] = cCliente;
                    grilla[2] = cProducto;
                    grilla[3] = cCalibre;
                    grilla[4] = cSalida;
                    grilla[5] = cLote;
                    grilla[6] = nKilos.ToString("N2");

                    Grid2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
