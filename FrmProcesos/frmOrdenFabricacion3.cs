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
    public partial class frmOrdenFabricacion3 : Form
    {
        public frmOrdenFabricacion3()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion3_Load(object sender, EventArgs e)
        {
            carga_orden_fabricacion();
        }

        private void carga_orden_fabricacion()
        {

            DateTime dFecha_emision;

            string cDocNum, cItemCode, cItemName;
            string cResponsable, cWhsCode, cFromWhsCode;
            string cLote;

            double nCantidadPlanificada, nCantidadPendiente;

            int nDocNum_Coordinado;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_Solicitudes_Planifacadas("R");

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

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
                    dFecha_emision = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                }
                catch
                {
                    dFecha_emision = DateTime.Parse("01/01/1900");
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
                    cLote = dTable.Rows[i]["DistNumber"].ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    cResponsable = dTable.Rows[i]["U_NAME"].ToString();
                }
                catch
                {
                    cResponsable = "";
                }

                try
                {
                    nCantidadPlanificada = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nCantidadPlanificada = 0;
                }

                try
                {
                    nCantidadPendiente = Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString());
                }
                catch
                {
                    nCantidadPendiente = 0;
                }

                try
                {
                    nDocNum_Coordinado = int.Parse(dTable.Rows[i]["Ref_OF"].ToString());
                }
                catch
                {
                    nDocNum_Coordinado = 0;
                }

                try
                {
                    cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                }
                catch
                {
                    cWhsCode = "";
                }

                try
                {
                    cFromWhsCode = dTable.Rows[i]["FromWhsCod"].ToString();
                }
                catch
                {
                    cFromWhsCode = "";
                }

                grilla[0] = cDocNum;
                grilla[1] = dFecha_emision.ToString("dd/MM/yyyy");
                grilla[2] = nDocNum_Coordinado.ToString();
                grilla[3] = cItemCode;
                grilla[4] = cItemName;
                grilla[5] = cLote;
                grilla[6] = cResponsable;
                grilla[7] = nCantidadPlanificada.ToString("N2");
                grilla[8] = nCantidadPendiente.ToString("N2");
                grilla[9] = cFromWhsCode;
                grilla[10] = cWhsCode;

                if (nCantidadPendiente>0)
                {
                    Grid1.Rows.Add(grilla);

                }

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}
