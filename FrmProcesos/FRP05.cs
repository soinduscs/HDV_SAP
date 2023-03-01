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
    public partial class FRP05 : Form
    {
        public FRP05()
        {
            InitializeComponent();
        }

        private void FRP05_Load(object sender, EventArgs e)
        {

            t_CardCode.Text = VariablesGlobales.glb_CardCode;
            t_cardname.Text = VariablesGlobales.glb_CardName;

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {
                int nFolio;
                Double nBins, nTotalBins;
                DateTime dFecha;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_informe_binsproductores("D", t_CardCode.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                nTotalBins = 0;

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nFolio = Convert.ToInt32(dTable.Rows[i]["DocNum"].ToString());
                    }
                    catch
                    {
                        nFolio = 0;
                    }

                    grilla[0] = nFolio.ToString();

                    try
                    {
                        grilla[1] = dTable.Rows[i]["Documento"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["TipoDocumento"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;
                    }

                    grilla[3] = dFecha.ToString("dd/MM/yyyy");

                    try
                    {
                        grilla[4] = dTable.Rows[i]["FromWhsCod"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        grilla[5] = "";
                    }

                    try
                    {
                        nBins = Convert.ToDouble(dTable.Rows[i]["Cantidad"].ToString());
                    }
                    catch
                    {
                        nBins = 0;
                    }

                    grilla[6] = nBins.ToString("N");

                    try
                    {
                        grilla[7] = dTable.Rows[i]["Comments"].ToString();
                    }
                    catch
                    {
                        grilla[7] = "";
                    }

                    nTotalBins += nBins;

                    Grid1.Rows.Add(grilla);

                }

                t_Saldo_bins.Text = nTotalBins.ToString("N");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}
