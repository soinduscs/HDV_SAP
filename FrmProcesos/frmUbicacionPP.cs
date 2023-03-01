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
    public partial class frmUbicacionPP : Form
    {
        public frmUbicacionPP()
        {
            InitializeComponent();
        }

        private void frmUbicacionPP_Load(object sender, EventArgs e)
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

        private void btn_crear_Click(object sender, EventArgs e)
        {

            string cLote;

            try
            {
                cLote = t_lote.Text;
            }
            catch
            {
                cLote = "";
            }

            if (cLote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Ubicación de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {

                double nQuantity;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Lote(cLote);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {
                    try
                    {
                        nQuantity = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    if (nQuantity>0)
                    {
                        try
                        {
                            t_WhsCode.Text = dTable.Rows[i]["WhsCode"].ToString();
                        }
                        catch
                        {
                            t_WhsCode.Clear();
                        }

                        try
                        {
                            t_itemcode.Text = dTable.Rows[i]["ItemCode"].ToString();
                        }
                        catch
                        {
                            t_itemcode.Clear(); 
                        }

                        try
                        {
                            t_itemname.Text = dTable.Rows[i]["itemName"].ToString();
                        }
                        catch
                        {
                            t_itemname.Clear();
                        }

                        try
                        {
                            t_PlannedQty.Text = nQuantity.ToString("N2");
                        }
                        catch
                        {
                            t_PlannedQty.Text = 0.ToString("N2");

                        }

                        try
                        {
                            t_um.Text = dTable.Rows[i]["BuyUnitMsr"].ToString();
                        }
                        catch
                        {
                            t_um.Clear();
                        }

                        try
                        {
                            t_ubicacion.Text = dTable.Rows[i]["BinCode"].ToString(); 
                        }
                        catch
                        {
                            t_ubicacion.Clear();
                        }
                    }


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

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de cambiar la ubicación de este lote", "Ubicación de Lotes ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            //mensaje = clsRecepcion.Sales_Order_Lotes(dt.ToString("yyyyMMdd"), t_itemcode.Text, int.Parse(t_lote.Text), nQuantity, "BPTP1", "BPTP1", UsuarioSap, ClaveSap);

            mensaje = clsRecepcion.Stock_Transfer_Ubicaciones(dt.ToString("yyyyMMdd"), t_itemcode.Text, int.Parse(t_lote.Text), nQuantity, "BASP1", "BASP1", nNewUbicacion, 0, 0, UsuarioSap, ClaveSap);

            try
            {
                nStockTransferEntry = int.Parse(mensaje);
                MessageBox.Show("Proceso Terminado Exitosamente", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;

            }
            catch
            {
                MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Ubicación de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nStockTransferEntry = 0;

            }



        }


    }

}
