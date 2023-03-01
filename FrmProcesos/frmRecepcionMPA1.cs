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
using System.Drawing.Printing;

namespace FrmProcesos
{
    public partial class frmRecepcionMPA1 : Form
    {
        public frmRecepcionMPA1()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPA1_Load(object sender, EventArgs e)
        {

            cbb_seleccionar_impresora.Items.Clear();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                try
                {
                    cbb_seleccionar_impresora.Items.Add(strPrinter);
                }
                catch
                {

                }

            }

            string cFecha = DateTime.Today.ToString("dd") + "/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha2.Value = DateTime.Today;

            cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");

            dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha;

            dtp_fecha1_1.Value = dFecha;
            dtp_fecha2_1.Value = DateTime.Today;

            carga_grilla1();
            carga_grilla2();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void carga_grilla1()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1.Value;

                string cfecha1, cfecha2, cWhsCode;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdendeCompra  objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_entradas_insumos(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                int nDocEntry, nNumGuia, nLinea;
                string cFechaCreacion, cItemCode;
                string cProveedor, cInsumo, cNumOC;
                string cLote, cLoteProveedor;
                double nCant_Pendiente;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nNumGuia = int.Parse(dTable.Rows[i]["FolioNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;
                    }

                    try
                    {
                        nLinea = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                    }
                    catch
                    {
                        nLinea = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaCreacion = dfecha.ToString("dd/MM/yyyy");
                    
                    try
                    {
                        cProveedor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProveedor = "";
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
                        cInsumo = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cInsumo = "";
                    }

                    try
                    {
                        nCant_Pendiente = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString()));
                    }
                    catch
                    {
                        nCant_Pendiente = 0;
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
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
                        cLoteProveedor = dTable.Rows[i]["U_FolioPallet"].ToString();
                    }
                    catch
                    {
                        cLoteProveedor = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nLinea.ToString("N");
                    grilla[2] = nNumGuia.ToString();
                    grilla[3] = cFechaCreacion;
                    grilla[4] = cProveedor;
                    grilla[5] = cNumOC;
                    grilla[6] = cLote;
                    grilla[7] = cLoteProveedor;
                    grilla[8] = cItemCode;
                    grilla[9] = cInsumo;
                    grilla[10] = nCant_Pendiente.ToString("N");
                    grilla[11] = nDocEntry.ToString();
                    grilla[12] = cWhsCode;

                    Grid1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla2()
        {

            try
            {
                DateTime dfecha;

                dfecha = dtp_fecha1_1.Value;

                string cfecha1, cfecha2;

                cfecha1 = dfecha.ToString("yyyyMMdd");

                dfecha = dtp_fecha2_1.Value;

                cfecha2 = dfecha.ToString("yyyyMMdd");

                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_Ordenes_de_compra_insumos(cfecha1, cfecha2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                int nDocEntry, nNumGuia, nLinea;
                string cFechaCreacion;
                string cProveedor, cInsumo;
                double nCant_Pendiente;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;

                    }

                    try
                    {
                        nNumGuia = int.Parse(dTable.Rows[i]["DocNum"].ToString());
                    }
                    catch
                    {
                        nNumGuia = 0;

                    }

                    try
                    {
                        nLinea = int.Parse(dTable.Rows[i]["LineNum"].ToString());
                    }
                    catch
                    {
                        nLinea = 0;
                    }

                    try
                    {
                        dfecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dfecha = DateTime.Parse("01/01/1900");
                    }

                    cFechaCreacion = dfecha.ToString("dd/MM/yyyy");

                    try
                    {
                        cProveedor = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cProveedor = "";
                    }

                    try
                    {
                        cInsumo = dTable.Rows[i]["Dscription"].ToString();
                    }
                    catch
                    {
                        cInsumo = "";
                    }


                    try
                    {
                        nCant_Pendiente = Convert.ToInt32(Convert.ToDouble(dTable.Rows[i]["OpenQty"].ToString()));
                    }
                    catch
                    {
                        nCant_Pendiente = 0;

                    }

                    grilla[0] = nDocEntry.ToString();
                    grilla[1] = nNumGuia.ToString();
                    grilla[2] = cFechaCreacion;
                    grilla[3] = cProveedor;
                    grilla[4] = cInsumo;
                    grilla[5] = nCant_Pendiente.ToString("N");

                    //grilla[2] = nNumGuia.ToString();

                    Grid2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_actualizar1_Click(object sender, EventArgs e)
        {

            carga_grilla2();

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Recepción de Insumos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;
            double nCantidad;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string cNumGuia, cLote, cLoteProveedor;
            string cProveedor, cInsumo, cItemCode;
            string cOrdenCompra, cFechaRecepcion;

            try
            {
                cNumGuia = Grid1[2, fila].Value.ToString();

            }
            catch
            {
                cNumGuia = "0";

            }

            try
            {
                cLote = Grid1[6, fila].Value.ToString();

            }
            catch
            {
                cLote = "0";

            }

            if (cLote=="")
            {
                cLote = "0";
            }

            try
            {
                cLoteProveedor = Grid1[7, fila].Value.ToString();

            }
            catch
            {
                cLoteProveedor = "0";

            }

            if (cNumGuia == "0")
            {
                MessageBox.Show("Debe seleccionar una guía valida, opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cLote == "0")
            {
                MessageBox.Show("Debe seleccionar una guía valida (Falta número de lote), opción Cancelada", "Recepción de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nCantidad = double.Parse(Grid1[10, fila].Value.ToString());
            }
            catch
            {
                nCantidad = 0;
            }

            try
            {
                cProveedor = Grid1[4, fila].Value.ToString();

            }
            catch
            {
                cProveedor = "";

            }

            try
            {
                cInsumo = Grid1[9, fila].Value.ToString();

            }
            catch
            {
                cInsumo = "";

            }

            try
            {
                cItemCode = Grid1[8, fila].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }

            try
            {
                cOrdenCompra = Grid1[5, fila].Value.ToString();

            }
            catch
            {
                cOrdenCompra = "";

            }

            try
            {
                cFechaRecepcion = Grid1[3, fila].Value.ToString();

            }
            catch
            {
                cFechaRecepcion = "";

            }

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                Font Font_Titulo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 8, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                //string , , cLoteProveedor;
                //string , , cItemCode;
                //string , ;

                e1.Graphics.DrawString("Num Guía: " + cNumGuia, Font_Cuerpo, br, 5, 5);
                e1.Graphics.DrawString("Num OC: " + cOrdenCompra, Font_Cuerpo, br, 150, 5);

                e1.Graphics.DrawString("Proveedor: " + cProveedor, Font_Cuerpo, br, 5, 20);

                e1.Graphics.DrawString("Fecha de Recepción: " + cFechaRecepcion, Font_Cuerpo, br, 5, 35);

                e1.Graphics.DrawString("Insumo: " + cInsumo, Font_Cuerpo, br, 5, 50);

                e1.Graphics.DrawString("Lote: " + cLote, Font_Cuerpo, br, 5, 65);

                e1.Graphics.DrawString("Lote Proveedor: " + cLoteProveedor, Font_Cuerpo, br, 150, 65);

                e1.Graphics.DrawString("Cantidad: " + nCantidad.ToString() + " Unids", Font_Cuerpo, br, 5, 80);

                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 90, 100);

                e1.Graphics.DrawString(cLote, Font_Cuerpo, br, 100, 130);

            };

            try
            {
                p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 500, 0, 500);

                if (p.PrinterSettings.IsValid)
                {
                    p.Print();
                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
            

        }

        private void btn_ingresar_mp_Click(object sender, EventArgs e)
        {

            frmRecepcionMPA2 f2 = new frmRecepcionMPA2();
            DialogResult res = f2.ShowDialog();

            carga_grilla1();
            carga_grilla2();


        }

    }

}
