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
    public partial class frmOrdenFabricacionCO1 : Form
    {
        public frmOrdenFabricacionCO1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionCO1_Load(object sender, EventArgs e)
        {
            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                dt = DateTime.Now;
            }

            t_fecha_contable.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion f2 = new frmSel_OrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                limpia_pantalla();

                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                carga_insumos_en_orden();

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void carga_insumos_en_orden()
        {

            if (t_DocNum.Text == "")
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de fabricación válida", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_insumos_Asignados_para_Consumir(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            string cItemCode, cItemName, cAlmacen;

            double nCantidadOF, nCantidadConsumida;

            int DocLine;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    DocLine = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                }
                catch
                {
                    DocLine = 0;
                }

                try
                {
                    cItemCode = dTable.Rows[i]["ItemCode"].ToString().ToUpper();
                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cItemName = dTable.Rows[i]["ItemName"].ToString().ToUpper();
                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantidadOF = Convert.ToDouble(dTable.Rows[i]["PlannedQty"].ToString());
                }
                catch
                {
                    nCantidadOF = 0;
                }

                try
                {
                    nCantidadConsumida = Convert.ToDouble(dTable.Rows[i]["IssuedQty"].ToString());
                }
                catch
                {
                    nCantidadConsumida = 0;
                }

                try
                {
                    cAlmacen = dTable.Rows[i]["wareHouse"].ToString().ToUpper();
                }
                catch
                {
                    cAlmacen = "";
                }
                
                grilla[0] = DocLine.ToString();
                grilla[1] = "";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = 0.ToString("N2");
                grilla[5] = nCantidadOF.ToString("N2");
                grilla[6] = nCantidadConsumida.ToString("N2");
                grilla[7] = cAlmacen;

                Grid1.Rows.Add(grilla);

            }

        }

        private void limpia_pantalla()
        {            
            Grid1.Rows.Clear();

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_DocNum.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Fabricación válida, opción Cancelada", "Emisión para Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar el Consumo", "Emisión para Producción ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            //int fila;
            //fila = -1;

            string cItemCode, cItemName, cWharehouse;
            string cDocDate, cCardName_Cliente, cCardCode_Cliente;
            string cCardCode_Productor, cCardName_Productor;

            string UsuarioSap, ClaveSap;
            string cErrorMensaje;

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

            DateTime dFecha;

            double nQuantity;

            int nLineNum, nCantidadBins;

            try
            {
                dFecha = Convert.ToDateTime(t_fecha_contable.Text);
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDocDate = dFecha.ToString("yyyyMMdd");


            for (int i = 0; i <= Grid1.Rows.Count - 1; i++)
            {

                try
                {
                    nQuantity = Convert.ToDouble(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                if (nQuantity >0)
                {
                    
                    try
                    {
                        nLineNum = int.Parse(Grid1[0, i].Value.ToString());
                    }
                    catch
                    {
                        nLineNum = 0;
                    }

                    try
                    {
                        cItemCode = Grid1[2, i].Value.ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = Grid1[3, i].Value.ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        nQuantity = Convert.ToDouble(Grid1[4, i].Value.ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        cWharehouse = Grid1[7, i].Value.ToString();
                    }
                    catch
                    {
                        cWharehouse = "";
                    }


                    nCantidadBins = 1;

                    cCardCode_Productor = "";
                    cCardName_Productor = "";
                    cCardCode_Cliente = "";
                    cCardName_Cliente = "";

                    ///////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////

                    cErrorMensaje = "";

                    String mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO1(cDocDate, nDocEntry, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, UsuarioSap, ClaveSap);

                    int nSalidaMercaderiaEntry;

                    try
                    {
                        nSalidaMercaderiaEntry = int.Parse(mensaje);
                        cErrorMensaje = "";

                        MessageBox.Show("Item: " + nLineNum + " - Consumo realizado con existo - Folio " + mensaje + "", "Emisión para Producción ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        nSalidaMercaderiaEntry = 0;
                        cErrorMensaje = mensaje;

                        MessageBox.Show("Item: " + nLineNum + " - Error en la generación del Consumo :::::: " + cErrorMensaje + ". ", "Emisión para Producción ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            t_DocNum.Clear();
            Grid1.Rows.Clear();


        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fila;

            fila = 0;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nCantidad, nCantidadOF, nConsumido;

            nCantidad = 0;
            nCantidadOF = 0;
            nConsumido = 0;

            try
            {
                nCantidad = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                nCantidad = 0;

            }

            try
            {
                nCantidadOF = Convert.ToDouble(Grid1[5, fila].Value.ToString());

            }
            catch
            {
                nCantidadOF = 0;

            }

            try
            {
                nConsumido = Convert.ToDouble(Grid1[6, fila].Value.ToString());

            }
            catch
            {
                nConsumido = 0;

            }

            if (nCantidad > (nCantidadOF - nConsumido))
                nCantidad = 0;

            Grid1[4, fila].Value = nCantidad.ToString("N2");

            


        }

    }

}
