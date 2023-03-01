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
    public partial class frmRecepcionMPB5 : Form
    {
        public frmRecepcionMPB5()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB5_Load(object sender, EventArgs e)
        {

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {

                int nTotBins, nSaldoBins;

                double nTotKilos, nSaldoKilos;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_de_guiasinternas_dys("R","");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["Variedad"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["TipoEnvase"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        nTotBins = Convert.ToInt32(dTable.Rows[i]["Total_Bins"].ToString());
                    }
                    catch
                    {
                        nTotBins = 0;
                    }

                    grilla[3] = nTotBins.ToString("N");

                    try
                    {
                        nSaldoBins = Convert.ToInt32(dTable.Rows[i]["Saldo_Bins"].ToString());
                    }
                    catch
                    {
                        nSaldoBins = 0;
                    }

                    grilla[4] = nSaldoBins.ToString("N");

                    try
                    {
                        nTotKilos = Convert.ToDouble(dTable.Rows[i]["Saldo_kilos"].ToString());
                    }
                    catch
                    {
                        nTotKilos = 0;
                    }

                    grilla[5] = nTotKilos.ToString("N");

                    try
                    {
                        nSaldoKilos = Convert.ToDouble(dTable.Rows[i]["Saldo_kilos"].ToString());
                    }
                    catch
                    {
                        nSaldoKilos = 0;
                    }

                    //grilla[5] = nSaldoKilos.ToString("N");

                    if (nSaldoBins > 0)
                    {
                        Grid1.Rows.Add(grilla);

                    }

                }

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

        private void btn_traslado_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_id_romana = 0;
            VariablesGlobales.glb_LineId = 0;

            frmRecepcionMPB6 f2 = new frmRecepcionMPB6();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_id_romana = 0;
            VariablesGlobales.glb_LineId = 0;

            carga_grilla1();

        }

    }

}
