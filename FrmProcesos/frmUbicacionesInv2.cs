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
    public partial class frmUbicacionesInv2 : Form
    {
        public frmUbicacionesInv2()
        {
            InitializeComponent();
        }

        private void frmUbicacionesInv2_Load(object sender, EventArgs e)
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
                objproducto.cls_ConsultaLista_Ubicacion_Lote("L","","");

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
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
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


                    grilla[0] = cItemCode;
                    grilla[1] = cItemName;
                    grilla[2] = cLote;
                    grilla[3] = nQuantity.ToString("N");
                    grilla[4] = cBodega;
                    grilla[5] = cBinCode;
                    grilla[6] = cPasillo;
                    grilla[7] = cPosicion;

                    if (nQuantity>0)
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
    }
}
