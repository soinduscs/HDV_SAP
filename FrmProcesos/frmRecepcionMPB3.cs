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
    public partial class frmRecepcionMPB3 : Form
    {
        public frmRecepcionMPB3()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB3_Load(object sender, EventArgs e)
        {

            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {

                string cDocEntry, cNum_OC, cProductor_OC;
                string cItemName, cProductor; // cStatusCalidad, 
                string cDestino_Secado, cNomDestino_Secado;

                DateTime dFecha;

                int nLinea;

                double nCantPlanificada, nCantCompletada;

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_de_OrdenFabricacion_despelonado("R");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                nLinea = 0;

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
                        cProductor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProductor = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        nCantPlanificada = Convert.ToDouble(dTable.Rows[i]["PlannedQty"].ToString());
                    }
                    catch
                    {
                        nCantPlanificada = 0;
                    }

                    try
                    {
                        nCantCompletada = Convert.ToDouble(dTable.Rows[i]["CmpltQty"].ToString());
                    }
                    catch
                    {
                        nCantCompletada = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["PostDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cDestino_Secado = dTable.Rows[i]["U_VID_LoFa"].ToString();
                    }
                    catch
                    {
                        cDestino_Secado = "";
                    }

                    cNum_OC = "";
                    cProductor_OC = "";

                    try
                    {
                        cNum_OC = dTable.Rows[i]["Num_OC"].ToString();
                    }
                    catch
                    {
                        cNum_OC = "";
                    }

                    try
                    {
                        cProductor_OC = dTable.Rows[i]["CardName_OC"].ToString();
                    }
                    catch
                    {
                        cProductor_OC = "";
                    }

                    cNomDestino_Secado = "";

                    if (cDestino_Secado == "Recibe_MP")
                    {
                        cNomDestino_Secado = "Recibir Como Materia Prima";
                    }

                    if (cDestino_Secado == "Envia_Clte")
                    {
                        cNomDestino_Secado = "Envío Directo a Cliente";
                    }


                    //cStatusCalidad = "";

                    //if (nCantPlanificada > 0)
                    //{
                    //    if (nCantCompletada > 0)
                    //    {
                    //        cStatusCalidad = "Productos Parcialmente Recepcionados";

                    //        if (nCantCompletada == nCantPlanificada)
                    //        {
                    //            cStatusCalidad = "Productos Completamente Recepcionados";

                    //        }

                    //    }

                    //}

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = dFecha.ToString("dd/MM/yyyy");
                    grilla[2] = cProductor.ToString();
                    grilla[3] = cItemName.ToString();
                    grilla[4] = nCantPlanificada.ToString("N");
                    grilla[5] = nCantCompletada.ToString("N");
                    grilla[6] = cNomDestino_Secado;
                    grilla[7] = cNum_OC;
                    grilla[8] = cProductor_OC;

                    Grid1.Rows.Add(grilla);                   

                    Grid1[6, nLinea].Style.BackColor = Color.Empty;

                    if (cDestino_Secado == "Recibe_MP")
                    {
                        Grid1[6, nLinea].Style.BackColor = Color.LightGreen;
                    }

                    if (cDestino_Secado == "Envia_Clte")
                    {
                        Grid1[6, nLinea].Style.BackColor = Color.LightBlue;
                    }
                    
                    nLinea = nLinea + 1;

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

        private void button2_Click(object sender, EventArgs e)
        {

            int fila, nDocEntry;
            string cNum_OC; 

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Destinar la OF como ** Materia Prima", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Modifica_Destino_Secado_RecibeMPv2020(nDocEntry.ToString());

                //////////////////////////////////////////////
                //////////////////////////////////////////////
                //////////////////////////////////////////////

                cNum_OC = "";

                VariablesGlobales.glb_CardCode = "";
                VariablesGlobales.glb_CardName = "";
                VariablesGlobales.glb_NumOC = "";
                VariablesGlobales.glb_ItemCode = "";
                VariablesGlobales.glb_ItemName = "";
                VariablesGlobales.glb_LineId = 0;

                frmSel_OrdendeCompra3 f2 = new frmSel_OrdendeCompra3();
                DialogResult res = f2.ShowDialog();

                if (VariablesGlobales.glb_NumOC.Trim() != "")
                {
                    cNum_OC = VariablesGlobales.glb_NumOC.Trim();

                    String mensaje1 = clsProduccion.Modifica_Destino_OC_MPv2020(nDocEntry.ToString(), cNum_OC);

                }

                MessageBox.Show("Registro Modificado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_grilla1();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int fila, nDocEntry;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Destinar la OF como ** Envía a Cliente", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Modifica_Destino_Secado_EnviaClientev2020(nDocEntry.ToString());

                MessageBox.Show("Registro Modificado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_grilla1();

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_definir_oc_Click(object sender, EventArgs e)
        {
            int fila, nDocEntry;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string cNum_OC, cNomDestino_Secado;

            try
            {
                cNomDestino_Secado = Grid1[6, fila].Value.ToString();
            }
            catch
            {
                cNomDestino_Secado = "";
            }

            cNum_OC = "";

            if (cNomDestino_Secado != "Recibir Como Materia Prima")
            {
                MessageBox.Show("La OF debe estar definida como **Recibir Como Materia Prima**, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_LineId = 0;

            frmSel_OrdendeCompra2 f2 = new frmSel_OrdendeCompra2();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                cNum_OC = VariablesGlobales.glb_NumOC.Trim();

            }

            if (cNum_OC != "")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de asignar una OC a esta OF", "Orden de Fabricacion ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    String mensaje = clsProduccion.Modifica_Destino_OC_MPv2020(nDocEntry.ToString(), cNum_OC);

                    MessageBox.Show("Registro Modificado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carga_grilla1();

                }

            }

        }

    }

}
