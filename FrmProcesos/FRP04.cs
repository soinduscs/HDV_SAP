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
    public partial class FRP04 : Form
    {
        public FRP04()
        {
            InitializeComponent();
        }

        private void FRP04_Load(object sender, EventArgs e)
        {
            carga_grilla1();
        }

        private void carga_grilla1()
        {

            try
            {
                
                Double nBins, nTotalBins;
                DateTime dFecha;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_informe_binsproductores("R", "%");

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
                        grilla[0] = dTable.Rows[i]["CardCode"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        nBins = Convert.ToDouble(dTable.Rows[i]["Cant_Registros"].ToString());
                    }
                    catch
                    {
                        nBins = 0;
                    }

                    grilla[2] = nBins.ToString();

                    try
                    {
                        nBins = Convert.ToDouble(dTable.Rows[i]["Saldo_Bins"].ToString());
                    }
                    catch
                    {
                        nBins = 0;
                    }

                    grilla[3] = nBins.ToString("N");

                    nTotalBins += nBins;

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["ult_documen"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Today;
                    }

                    grilla[4] = dFecha.ToString("dd/MM/yyyy");

                    Grid1.Rows.Add(grilla);

                }

                t_Saldo_bins.Text = nTotalBins.ToString("N");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_productor_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cCardCode, cCardName;

            cCardCode = "";
            cCardName = "";

            if (fila >= 0)
            {
                try
                {
                    cCardCode = Grid1[0, fila].Value.ToString().ToUpper();
                    cCardName = Grid1[1, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    cCardCode = "";
                    cCardName = "";

                }

            }

            if (cCardCode != "")
            {

                VariablesGlobales.glb_CardCode = cCardCode;
                VariablesGlobales.glb_CardName = cCardName;

                FRP05 f2 = new FRP05();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_CardCode = "";
                VariablesGlobales.glb_CardName = "";

            }

        }
        
    }

}
