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
    public partial class frmOrdenVentas1 : Form
    {
        public frmOrdenVentas1()
        {
            InitializeComponent();
        }

        private void frmOrdenVentas1_Load(object sender, EventArgs e)
        {
            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;
            dtp_fecha2.Value = DateTime.Today;


        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {
            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("F2", cfecha1, cfecha2);

        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cDocNum, cCardName;
                string cItemName;
                DateTime dFechaEmision, dFechaEntrega;

                int nCantItems;

                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_OrdendeVenta_Entre_Fechas();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["DocEntry"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cDocNum = dTable.Rows[i]["DocNum"].ToString();
                    }
                    catch
                    {
                        cDocNum = "";

                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
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
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["OpenQty"].ToString());
                    }
                    catch
                    {
                        nCantItems = 0;
                    }

                    try
                    {
                        dFechaEmision = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFechaEmision = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        dFechaEntrega = Convert.ToDateTime(dTable.Rows[i]["DocDueDate"].ToString());
                    }
                    catch
                    {
                        dFechaEntrega = DateTime.Parse("01/01/1900");
                    }

                    grilla[0] = cDocEntry;
                    grilla[1] = cDocNum;
                    grilla[2] = dFechaEmision.ToString("dd/MM/yyyy");
                    grilla[3] = dFechaEntrega.ToString("dd/MM/yyyy");
                    grilla[4] = cCardName;
                    grilla[5] = cItemName;
                    grilla[6] = nCantItems.ToString("N2");

                    grilla[7] = 0.ToString("N2");
                    grilla[8] = 0.ToString("N2");
                    //grilla[9] = nCantItems.ToString("N2");

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

        private void btn_asignar_Click(object sender, EventArgs e)
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

            VariablesGlobales.glb_DocEntry = 0;

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_DocEntry = int.Parse(Grid1[1, fila].Value.ToString());

                    frmOrdenVentas f2 = new frmOrdenVentas();
                    DialogResult res = f2.ShowDialog();

                    VariablesGlobales.glb_DocEntry = 0;

                }
                catch
                {
                    VariablesGlobales.glb_DocEntry = 0;

                }

            }


        }

        private void btn_orden_Click(object sender, EventArgs e)
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

            VariablesGlobales.glb_DocEntry = 0;

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_DocEntry = int.Parse(Grid1[1, fila].Value.ToString());

                    frmOrdenVentas2 f2 = new frmOrdenVentas2();
                    DialogResult res = f2.ShowDialog();

                    VariablesGlobales.glb_DocEntry = 0;

                }
                catch
                {
                    VariablesGlobales.glb_DocEntry = 0;

                }

            }

        }

        private void btn_orden1_Click(object sender, EventArgs e)
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

            VariablesGlobales.glb_DocEntry = 0;

            if (fila >= 0)
            {
                try
                {
                    VariablesGlobales.glb_DocEntry = int.Parse(Grid1[1, fila].Value.ToString());

                    frmOrdenVentas3 f2 = new frmOrdenVentas3();
                    DialogResult res = f2.ShowDialog();

                    VariablesGlobales.glb_DocEntry = 0;

                }
                catch
                {
                    VariablesGlobales.glb_DocEntry = 0;

                }

            }


        }
    }

}
