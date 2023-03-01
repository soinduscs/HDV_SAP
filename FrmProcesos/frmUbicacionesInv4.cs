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
    public partial class frmUbicacionesInv4 : Form
    {
        public frmUbicacionesInv4()
        {
            InitializeComponent();
        }

        private void frmUbicacionesInv4_Load(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void carga_grilla()
        {

            try
            {

                string cBodega, cBinCode, cPasillo;
                string cPosicion, cItemCode, cItemName;
                string cLote;
                double nQuantity;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_ConsultaLista_Ubicacion_Lote("P","","");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cBodega = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cBodega = "";

                    }

                    try
                    {
                        cBinCode = dTable.Rows[i]["BinCode"].ToString();
                    }
                    catch
                    {
                        cBinCode = "";

                    }

                    try
                    {
                        cPasillo = dTable.Rows[i]["SL1Code"].ToString();
                    }
                    catch
                    {
                        cPasillo = "";

                    }

                    try
                    {
                        cPosicion = dTable.Rows[i]["SL2Code"].ToString();
                    }
                    catch
                    {
                        cPosicion = "";

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
                        cItemName = dTable.Rows[i]["itemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";

                    }

                    try
                    {
                        cLote = dTable.Rows[i]["FolioPallet"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        nQuantity = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }


                    grilla[0] = cBodega;
                    grilla[1] = cBinCode;
                    grilla[2] = cPasillo;
                    grilla[3] = cPosicion;
                    grilla[4] = cItemCode;
                    grilla[5] = cItemName;
                    grilla[6] = cLote;
                    grilla[7] = nQuantity.ToString("N");

                    Grid1.Rows.Add(grilla);

                }

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

        private void btn_lotes_Click(object sender, EventArgs e)
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

            VariablesGlobales.glb_Pallet = "";

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_Pallet = Grid1[6, fila].Value.ToString().ToUpper();

                }
                catch
                {
                    VariablesGlobales.glb_Pallet = "";

                }

                if (VariablesGlobales.glb_Pallet != "")
                {
                    frmUbicacionesInv3 f2 = new frmUbicacionesInv3();
                    DialogResult res = f2.ShowDialog();

                }


            }

        }

    }

}
