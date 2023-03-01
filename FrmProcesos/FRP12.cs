using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using CapaNegocio;

namespace FrmProcesos
{
    public partial class FRP12 : Form
    {
        public FRP12()
        {
            InitializeComponent();
        }

        private void FRP12_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Now;
            cbb_turno.SelectedIndex = 0;

            carga_datos();
            carga_graficos();

        }

        private void carga_graficos()
        {

            // Carga Turno A 

            try
            {

                chart1.Series.Clear();
                //chart1.Series.Add("Series1");
                //chart1.Series["Series1"].LegendText = "Turno_A";


                //chart1.ChartAreas[0].AxisX.Interval = 1;
                //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;


                int n_temporada, n_valor1;
                string c_Fecha, c_serie;
                double n_valor;

                c_Fecha = Convert.ToDateTime(dtp_fecha.Value).ToString("yyyyMMdd");
                n_temporada = Convert.ToInt32(Convert.ToDateTime(dtp_fecha.Value).ToString("yyyy"));

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_televisor_ncc(n_temporada, c_Fecha, "B", cbb_turno.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Dictionary<string, int> dic = new Dictionary<string, int>();
                Dictionary<string, int> dic1 = new Dictionary<string, int>();

                var seriesPuntos = new Series();
                var seriesPuntos1 = new Series();

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        c_serie = dTable.Rows[i]["Fecha"].ToString();
                    }
                    catch
                    {
                        c_serie = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Kilos_Produccion"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    n_valor1 =  Convert.ToInt16(n_valor);

                    dic.Add(c_serie, n_valor1);
                    
                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Kilos_MP"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    n_valor1 = Convert.ToInt16(n_valor);

                    dic1.Add(c_serie, n_valor1);

                }

                foreach (KeyValuePair<string, int> d in dic)
                {
                    seriesPuntos.Points.AddXY(d.Key, d.Value);

                }

                seriesPuntos.Label = "#VAL";
                seriesPuntos.ChartType = SeriesChartType.Column;
                seriesPuntos["PieLabelStyle"] = "Outside";

                foreach (KeyValuePair<string, int> d in dic1)
                {
                    seriesPuntos1.Points.AddXY(d.Key, d.Value);

                }

                seriesPuntos1.Label = "#VAL";
                seriesPuntos1.ChartType = SeriesChartType.Column;
                seriesPuntos1["PieLabelStyle"] = "Outside";

                chart1.Series.Add(seriesPuntos);
                chart1.Series["Series1"].LegendText = "Producto Terminado";
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

                chart1.Series.Add(seriesPuntos1);
                chart1.Series["Series2"].LegendText = "Materia Prima";
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            // Carga Turno B 

            try
            {

                chart2.Series.Clear();

                int n_temporada, n_valor1;
                string c_Fecha, c_serie;
                double n_valor;

                c_Fecha = Convert.ToDateTime(dtp_fecha.Value).ToString("yyyyMMdd");
                n_temporada = Convert.ToInt32(Convert.ToDateTime(dtp_fecha.Value).ToString("yyyy"));

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_televisor_ncc(n_temporada, c_Fecha, "B", "Turno_B");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Dictionary<string, int> dic = new Dictionary<string, int>();
                Dictionary<string, int> dic1 = new Dictionary<string, int>();

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        c_serie = dTable.Rows[i]["Fecha"].ToString();
                    }
                    catch
                    {
                        c_serie = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Kilos_Produccion"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    n_valor1 = Convert.ToInt16(n_valor);

                    dic.Add(c_serie, n_valor1);

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Kilos_MP"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    n_valor1 = Convert.ToInt16(n_valor);

                    dic1.Add(c_serie, n_valor1);

                }

                var seriesPuntos = new Series();
                var seriesPuntos1 = new Series();

                foreach (KeyValuePair<string, int> d in dic)
                {
                    seriesPuntos.Points.AddXY(d.Key, d.Value);

                }

                seriesPuntos.Label = "#VAL";
                seriesPuntos.ChartType = SeriesChartType.Column;
                seriesPuntos["PieLabelStyle"] = "Outside";

                foreach (KeyValuePair<string, int> d in dic1)
                {
                    seriesPuntos1.Points.AddXY(d.Key, d.Value);

                }

                seriesPuntos1.Label = "#VAL";
                seriesPuntos1.ChartType = SeriesChartType.Column;
                seriesPuntos1["PieLabelStyle"] = "Outside";

                chart2.Series.Add(seriesPuntos);
                chart2.Series["Series1"].LegendText = "Producto Terminado";
                chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

                chart2.Series.Add(seriesPuntos1);
                chart2.Series["Series2"].LegendText = "Materia Prima";
                chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void carga_datos()
        {

            //groupBox1.Text = string.Concat(Enumerable.Repeat(" ", 80)) + "Turno A - " + dtp_fecha.Value.ToString("dd/MM/yyyy");
            //groupBox2.Text = string.Concat(Enumerable.Repeat(" ", 80)) + "Turno B - " + dtp_fecha.Value.ToString("dd/MM/yyyy");

            lbl_turno_A.Text = "[Turno A - " + dtp_fecha.Value.ToString("dd/MM/yyyy") + "]";
            lbl_turno_B.Text = "[Turno B - " + dtp_fecha.Value.ToString("dd/MM/yyyy") + "]";

            // Cargo Turno A

            try
            {

                int n_temporada;
                string c_Fecha;
                double n_valor;

                c_Fecha = Convert.ToDateTime(dtp_fecha.Value).ToString("yyyyMMdd");
                n_temporada = Convert.ToInt32(Convert.ToDateTime(dtp_fecha.Value).ToString("yyyy"));

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_televisor_ncc(n_temporada, c_Fecha, "A", "Turno_A"); 

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["Tipo"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Meta_PT"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i!=2)
                    {
                        grilla[1] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[1] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Meta_MP"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[2] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[2] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Acc_Semana"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[3] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[3] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Acc_Mes"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[4] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[4] = n_valor.ToString("N") + '%';

                    }

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            // Cargo Turno B

            try
            {

                int n_temporada;
                string c_Fecha;
                double n_valor;

                c_Fecha = Convert.ToDateTime(dtp_fecha.Value).ToString("yyyyMMdd");
                n_temporada = Convert.ToInt32(Convert.ToDateTime(dtp_fecha.Value).ToString("yyyy"));

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_televisor_ncc(n_temporada, c_Fecha, "A", "Turno_B");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["Tipo"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Meta_PT"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[1] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[1] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Meta_MP"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[2] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[2] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Acc_Semana"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[3] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[3] = n_valor.ToString("N") + '%';

                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Acc_Mes"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    if (i != 2)
                    {
                        grilla[4] = n_valor.ToString("N0");

                    }
                    else
                    {
                        grilla[4] = n_valor.ToString("N") + '%';

                    }

                    Grid2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            // Cargo Resumen

            try
            {

                int n_temporada;
                string c_Fecha;
                double n_valor;

                c_Fecha = Convert.ToDateTime(dtp_fecha.Value).ToString("yyyyMMdd");
                n_temporada = Convert.ToInt32(Convert.ToDateTime(dtp_fecha.Value).ToString("yyyy"));

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_xSapb1_utiles_resumen_televisor_ncc(n_temporada, c_Fecha, "C", "Turno_A");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid3.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["Tipo"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Meta_PT"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    grilla[1] = n_valor.ToString("N0");

                    try
                    {
                        n_valor = Convert.ToDouble(dTable.Rows[i]["Real_PT"].ToString());
                    }
                    catch
                    {
                        n_valor = 0;
                    }

                    grilla[2] = n_valor.ToString("N0");

                    Grid3.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_datos();

            carga_graficos();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }

}
