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
    public partial class frmUbicacionPP1 : Form
    {
        public frmUbicacionPP1()
        {
            InitializeComponent();
        }

        private void frmUbicacionPP1_Load(object sender, EventArgs e)
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Ubicaciones();

            this.cbb_ubicacion.DataSource = objproducto.cResultado;
            this.cbb_ubicacion.ValueMember = "AbsEntry";
            this.cbb_ubicacion.DisplayMember = "BinCode";

            try
            {
                cbb_ubicacion.SelectedIndex = 0;

            }
            catch
            {

            }

        }

        private void carga_grilla()
        {

            try
            {

                string cBodega, cBinCode, cPasillo;
                string cPosicion, cItemCode, cItemName;
                string cLote, cUM;
                double nQuantity_Stock, nQuantity_Ubicacion, nQuantity_Total;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_ConsultaLista_Ubicacion_Lote("D", t_lote.Text,"");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                nQuantity_Total = 0;

                t_itemcode.Clear();
                t_itemname.Clear();
                t_ubicacion.Clear();
                t_WhsCode.Clear();
                t_um.Clear();
                t_PlannedQty.Clear();

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
                        cUM = dTable.Rows[i]["BuyUnitMsr"].ToString();
                    }
                    catch
                    {
                        cUM = "";
                    }

                    try
                    {
                        nQuantity_Stock = Convert.ToDouble(dTable.Rows[i]["Quantity_Stock"].ToString());
                    }
                    catch
                    {
                        nQuantity_Stock = 0;
                    }

                    try
                    {
                        nQuantity_Ubicacion = Convert.ToDouble(dTable.Rows[i]["Quantity_Ubicacion"].ToString());
                    }
                    catch
                    {
                        nQuantity_Ubicacion = 0;
                    }

                    grilla[0] = cBodega;
                    grilla[1] = cBinCode;
                    grilla[2] = cPasillo;
                    grilla[3] = cPosicion;
                    grilla[4] = cItemCode;
                    grilla[5] = cItemName;
                    grilla[6] = cLote;
                    grilla[7] = nQuantity_Ubicacion.ToString("N");

                    if (t_itemcode.Text == "")
                    {
                        t_itemcode.Text = cItemCode;
                        t_itemname.Text = cItemName;
                        t_ubicacion.Text = cBinCode;
                        t_WhsCode.Text = cBodega;
                        t_um.Text = cUM;

                    }

                    if (nQuantity_Stock == nQuantity_Ubicacion)
                    {
                        Grid1.Rows.Add(grilla);

                        nQuantity_Total += nQuantity_Ubicacion;

                        


                    }

                }

                t_PlannedQty.Text = nQuantity_Total.ToString("N");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            carga_grilla();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string mensaje;
            int nStockTransferEntry, nNewUbicacion;
            float nQuantity;
            DateTime dt;

            dt = DateTime.Now;

            try
            {
                nNewUbicacion = int.Parse(cbb_ubicacion.SelectedValue.ToString());
            }
            catch
            {
                nNewUbicacion = 0;
            }

            if (nNewUbicacion == 0)
            {
                MessageBox.Show("Debe seleccionar una ubicación valida, opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ////////////////////////////////////////
            // Genero la transferencia con los bins

            string UsuarioSap, ClaveSap;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            try
            {
                nQuantity = float.Parse(t_PlannedQty.Text);
            }
            catch
            {
                nQuantity = 0;
            }

            if (nQuantity == 0)
            {
                MessageBox.Show("Debe seleccionar un lote con stock opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_WhsCode.Text != "BPTP1")
            {
                MessageBox.Show("El Artículo NO se encuentra en la bodega BPTP1, opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de cambiar la ubicación de este lote", "Ubicación de Lotes ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cBodega, cItemCode, cLote;
            float nQuantity_Ubicacion;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    cBodega = Grid1[0, i].Value.ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cItemCode = Grid1[4, i].Value.ToString();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cLote = Grid1[6, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_Ubicacion = float.Parse(Grid1[7, i].Value.ToString());
                }
                catch
                {
                    nQuantity_Ubicacion = 0;
                }

                mensaje = clsRecepcion.Stock_Transfer_Ubicaciones(dt.ToString("yyyyMMdd"), cItemCode, int.Parse(cLote), nQuantity_Ubicacion, "BPTP1", "BPTP1", nNewUbicacion, 0,0, UsuarioSap, ClaveSap);

                try
                {
                    nStockTransferEntry = int.Parse(mensaje);

                }
                catch
                {
                    MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nStockTransferEntry = 0;
                    return;

                }

            }

            MessageBox.Show("Proceso Terminado Exitosamente", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Enabled = false;

            //mensaje = clsRecepcion.Sales_Order_Lotes(dt.ToString("yyyyMMdd"), t_itemcode.Text, int.Parse(t_lote.Text), nQuantity, "BPTP1", "BPTP1", UsuarioSap, ClaveSap);

        }

    }

}
