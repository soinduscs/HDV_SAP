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
    public partial class frmOrdenFabricacion2 : Form
    {
        public frmOrdenFabricacion2()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacion2_Load(object sender, EventArgs e)
        {
            carga_orden_fabricacion();

        }

        private void carga_orden_fabricacion()
        {
           
            DateTime dFecha_emision, dFecha_Planificacion;

            string cDocNum, cItemCode, cItemName;
            string cResponsable, cProceso;

            double nCantidadPlanificada, nCantidadCompletada, nCantidadSolicitada;
            double nCantidadTraslado, nCantidadAsginada;

            int nDocNum_Coordinado;

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_Planifacadas("R");

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
                    dFecha_emision = Convert.ToDateTime(dTable.Rows[i]["PostDate"].ToString());
                }
                catch
                {
                    dFecha_emision = DateTime.Parse("01/01/1900");
                }

                try
                {
                    dFecha_Planificacion = Convert.ToDateTime(dTable.Rows[i]["StartDate"].ToString());
                }
                catch
                {
                    dFecha_Planificacion = DateTime.Parse("01/01/1900");
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
                    cItemName = dTable.Rows[i]["ItemName"].ToString();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    cProceso = dTable.Rows[i]["U_Proceso"].ToString();
                }
                catch
                {
                    cProceso = "";
                }

                try
                {
                    cResponsable = dTable.Rows[i]["NomResponsable"].ToString();
                }
                catch
                {
                    cResponsable = "";
                }

                try
                {
                    nCantidadPlanificada = Convert.ToDouble(dTable.Rows[i]["PlannedQty"].ToString());
                }
                catch
                {
                    nCantidadPlanificada = 0;
                }

                try
                {
                    nCantidadCompletada = Convert.ToDouble(dTable.Rows[i]["CmpltQty"].ToString());
                }
                catch
                {
                    nCantidadCompletada = 0;
                }

                try
                {
                    nCantidadSolicitada = Convert.ToDouble(dTable.Rows[i]["Quantity_SOL"].ToString());
                }
                catch
                {
                    nCantidadSolicitada = 0;
                }

                try
                {
                    nCantidadTraslado = Convert.ToDouble(dTable.Rows[i]["Quantity_TRAS"].ToString());
                }
                catch
                {
                    nCantidadTraslado = 0;
                }

                try
                {
                    nCantidadAsginada = Convert.ToDouble(dTable.Rows[i]["OpenQty_Asignadas"].ToString());
                }
                catch
                {
                    nCantidadAsginada = 0;
                }

                try
                {
                    nDocNum_Coordinado = int.Parse(dTable.Rows[i]["DocNum_Coordinado"].ToString());
                }
                catch
                {
                    nDocNum_Coordinado = 0;
                }

                grilla[1] = cDocNum;
                grilla[2] = nDocNum_Coordinado.ToString();
                grilla[3] = dFecha_emision.ToString("dd/MM/yyyy");
                grilla[4] = dFecha_Planificacion.ToString("dd/MM/yyyy");
                grilla[5] = cItemCode;
                grilla[6] = cItemName;
                grilla[7] = cProceso;
                grilla[8] = nCantidadPlanificada.ToString("N2");
                grilla[9] = nCantidadCompletada.ToString("N2");
                grilla[10] = nCantidadSolicitada.ToString("N2");
                grilla[11] = nCantidadTraslado.ToString("N2");
                grilla[12] = nCantidadAsginada.ToString("N2");
                grilla[13] = cResponsable;

                Grid1.Rows.Add(grilla);

                if (nDocNum_Coordinado == 0)
                {
                    Grid1[0, Grid1.Rows.Count-1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                else
                {
                    Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                }

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum, cDocNum_Ref;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cDocNum_Ref = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cDocNum_Ref = "";
            }
           
            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cDocNum_Ref != "0")
            {
                MessageBox.Show("Esta Orden ya se encuentra coordinada, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            VariablesGlobales.glb_Referencia1 = Grid1[4, fila].Value.ToString();
            
            frmOrdenFabricacion4 f2 = new frmOrdenFabricacion4();
            DialogResult res = f2.ShowDialog();

            carga_orden_fabricacion();

            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            //DialogResult result;

            //result = MessageBox.Show("Esta Seguro de Realizar la coordinación de esta orden", "Orden de Fabricacion ", buttons);

            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    String mensaje = clsProduccion.Insert_Coordinar_Orden_Fabricacion(cDocNum);

            //    MessageBox.Show("Registro Coordinado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    carga_orden_fabricacion();

            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum, cDocNum_Ref;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cDocNum_Ref = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cDocNum_Ref = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cDocNum_Ref == "0")
            {
                MessageBox.Show("Esta Orden no se encuentra coordinada, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Borrar la coordinación de esta orden", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Borrar_Coordinar_Orden_Fabricacion(cDocNum);

                MessageBox.Show("Registro Borrado Exitosamente", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_orden_fabricacion();

            }

        }

        private void btn_genera_solicitud_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar la Solicitud de Transferencia", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);

            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                frmOrdenFabricacion1 f2 = new frmOrdenFabricacion1();
                DialogResult res = f2.ShowDialog();

            }


            carga_orden_fabricacion();


        }

        private void button2_Click(object sender, EventArgs e)
        {


            int fila;
            string cDocNum, cItemCode;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cItemCode = Grid1[5, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);

            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;

            }

            try
            {
                VariablesGlobales.glb_ItemCode = cItemCode; 
            }
            catch
            {
                VariablesGlobales.glb_ItemCode = "";
            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                frmOrdenFabricacion f2 = new frmOrdenFabricacion();
                DialogResult res = f2.ShowDialog();

            }

            carga_orden_fabricacion();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            carga_orden_fabricacion();

        }

        private void btn_asignar_stock_Click(object sender, EventArgs e)
        {


            int fila;
            string cDocNum;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Asignar el Stock", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);

            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                frmOrdenFabricacion5 f2 = new frmOrdenFabricacion5();
                DialogResult res = f2.ShowDialog();

            }


            carga_orden_fabricacion();

        }

        private void btn_cancelar_of_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum;

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
                cDocNum = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Cerrar esta Orden de Fabricación", "Orden de Fabricacion ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;
            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {
                frmOrdenFabricacion6 f2 = new frmOrdenFabricacion6();
                DialogResult res = f2.ShowDialog();

                
            }


            carga_orden_fabricacion();
        }
    }

}
