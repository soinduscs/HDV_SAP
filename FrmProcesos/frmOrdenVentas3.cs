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
    public partial class frmOrdenVentas3 : Form
    {
        public frmOrdenVentas3()
        {
            InitializeComponent();
        }

        private void frmOrdenVentas3_Load(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                carga_orden_venta();

            }

        }

        private void carga_orden_venta()
        {
            int nDocNum;
            DateTime dFecha;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }


            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_OrdendeVenta_con_Entrega_x_DocNum(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_DocEntry.Text = dTable.Rows[0]["DocEntry"].ToString();
            }
            catch
            {
                t_DocEntry.Clear();
            }

            try
            {
                t_cardcode.Text = dTable.Rows[0]["CardCode"].ToString();
            }
            catch
            {
                t_cardcode.Clear();
            }

            try
            {
                t_cardname.Text = dTable.Rows[0]["CardName"].ToString();
            }
            catch
            {
                t_cardname.Clear();
            }

            try
            {
                dFecha = Convert.ToDateTime(dTable.Rows[0]["DocDueDate"].ToString());
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            try
            {
                t_fecha_entrega.Text = dFecha.ToString("dd/MM/yyyy");
            }
            catch
            {
                t_fecha_entrega.Text = "";

            }

            try
            {
                //t_Estado.Text = nPlannedQty.ToString("N2");

            }
            catch
            {
                t_Estado.Clear();

            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega, cUbicacion;
            double nCantidadOV, nCantidadRequerida, nCantidadYaAsignada;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["LineNum"].ToString();
                }
                catch
                {
                    cLine = "";

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
                    cItemName = dTable.Rows[i]["Dscription"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidadOV = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nCantidadOV = 0;
                }

                try
                {
                    nCantidadYaAsignada = Convert.ToDouble(dTable.Rows[i]["AllocQty"].ToString());
                }
                catch
                {
                    nCantidadYaAsignada = 0;
                }

                nCantidadRequerida = nCantidadOV - nCantidadYaAsignada;

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
                    cBodega = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cUbicacion = dTable.Rows[i]["BinCode"].ToString();
                }
                catch
                {
                    cUbicacion = "";
                }

                

                grilla[0] = cLine;
                grilla[1] = cItemCode;
                grilla[2] = cItemName;
                grilla[3] = cUM;
                grilla[4] = cBodega;
                grilla[5] = nCantidadYaAsignada.ToString("N2");
                //grilla[4] = 0.ToString("N2");
                grilla[6] = cUbicacion;

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}
