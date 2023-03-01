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
    public partial class frmConsultaLote : Form
    {
        public frmConsultaLote()
        {
            InitializeComponent();
        }

        private void frmConsultaLote_Load(object sender, EventArgs e)
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

            clsProduccion objproducto3 = new clsProduccion();
            objproducto3.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto3.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

        }

        private void carga_grilla()
        {

            Grid1.Rows.Clear();

            try
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Vista_Lotes(txtLote.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                double nCantidad;
                DateTime dFecha;
                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nCantidad = 0;
                    }
                    
                    grilla[1] = dTable.Rows[i]["ItemCode"].ToString(); 
                    grilla[2] = dTable.Rows[i]["ItemName"].ToString();
                    grilla[3] = dTable.Rows[i]["StatusLote"].ToString(); 
                    grilla[4] = dTable.Rows[i]["WhsCode"].ToString(); 
                    grilla[5] = nCantidad.ToString("N2");
                    grilla[6] = dTable.Rows[i]["DistNumber"].ToString();
                    grilla[7] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    grilla[8] = dTable.Rows[i]["U_Temporada"].ToString();
                    grilla[9] = "0";

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Now;
                    }
                    
                    grilla[10] = dFecha.ToString("dd/MM/yyyy");
                    grilla[11] = dTable.Rows[i]["DocEntry_EM"].ToString();

                    Grid1.Rows.Add(grilla);

                    Grid1[0, Grid1.Rows.Count-1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla1()
        {

            string cWhsCode;

            try
            {
                cWhsCode = cbb_almacen.SelectedValue.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            if (cWhsCode == "")
            {
                MessageBox.Show("Debe seleccionar un Almacén válido, opción Cancelada", "Consulta por Lote ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Grid1.Rows.Clear();

            try
            {
                clsProduccion objproducto = new clsProduccion();
                objproducto.cls_Consulta_Vista_Lotes_x_WhsCode(cWhsCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                double nCantidad;
                DateTime dFecha;
                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        nCantidad = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nCantidad = 0;
                    }

                    grilla[1] = dTable.Rows[i]["ItemCode"].ToString();
                    grilla[2] = dTable.Rows[i]["ItemName"].ToString();
                    grilla[3] = dTable.Rows[i]["StatusLote"].ToString();
                    grilla[4] = dTable.Rows[i]["WhsCode"].ToString();
                    grilla[5] = nCantidad.ToString("N2");
                    grilla[6] = dTable.Rows[i]["DistNumber"].ToString();
                    grilla[7] = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    grilla[8] = dTable.Rows[i]["U_Temporada"].ToString();
                    grilla[9] = "0";

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Now;
                    }

                    grilla[10] = dFecha.ToString("dd/MM/yyyy");

                    Grid1.Rows.Add(grilla);

                    Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            carga_grilla();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir1_Click(object sender, EventArgs e)
        {
            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Consulta por Lote ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Consulta por Lote ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nCheck; //fila
            double nCantidad;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                
                try
                {
                    nCheck = Convert.ToInt32(Grid1[9, i].Value.ToString());
                }
                catch
                {
                    nCheck = 0;
                }

                try
                {
                    nCantidad = double.Parse(Grid1[5, i].Value.ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                if (nCheck==1)
                {
                    PrintDocument p = new PrintDocument();

                    p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                    {

                        Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                        Font Font_Titulo = new Font("Consolas", 10, FontStyle.Bold);
                        Font Font_Cuerpo = new Font("Consolas", 8, FontStyle.Bold);

                        SolidBrush br = new SolidBrush(Color.Black);

                        e1.Graphics.DrawString("Productor: " + Grid1[7, i].Value.ToString(), Font_Cuerpo, br, 5, 20);

                        e1.Graphics.DrawString("Cosecha: " + Grid1[8, i].Value.ToString(), Font_Cuerpo, br, 5, 35);
                        e1.Graphics.DrawString("Fecha de Elaboración: " + Grid1[10, i].Value.ToString(), Font_Cuerpo, br, 150, 35);

                        e1.Graphics.DrawString("Peso Neto: " + nCantidad.ToString() + " Kgs", Font_Cuerpo, br, 5, 50);

                        e1.Graphics.DrawString(Grid1[2, i].Value.ToString(), Font_Cuerpo, br, 5, 65);                       

                        e1.Graphics.DrawString("*" + Grid1[6, i].Value.ToString() + "* ", Font_CodigoBarra, br, 150, 100);

                        e1.Graphics.DrawString(Grid1[6, i].Value.ToString(), Font_Cuerpo, br, 160, 130);

                        //e1.Graphics.DrawString(cItemName, Font_Cuerpo, br, 0, 70);
                        //e1.Graphics.DrawString(cCardName, Font_Cuerpo, br, 0, 110);
                        //e1.Graphics.DrawString("Cantidad: 1 de 1", Font_Cuerpo, br, 0, 150);

                        //e1.Graphics.DrawString("Envase: BINS PLASTICO", Font_Cuerpo, br, 0, 115);
                        //e1.Graphics.DrawString("Guia: 1769", Font_Cuerpo, br, 0, 130);

                    };

                    try
                    {
                        p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                        p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 500, 0, 500);

                        //p.PrinterSettings.DefaultPageSettings.Margins.Top = 100;
                        //p.PrinterSettings.DefaultPageSettings.Margins.Bottom = 100;
                        //p.PrinterSettings.DefaultPageSettings.Margins.Left = 100;
                        //p.PrinterSettings.DefaultPageSettings.Margins.Right = 100;

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
            
            }

        }

        private void Grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nSel;

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
                MessageBox.Show("No Existen registros a eliminar, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nSel = int.Parse(Grid1[9, fila].Value.ToString());
            }
            catch
            {
                nSel = 0;
            }

            if (nSel==0)
            {
                Grid1[0, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_checked).ico");
                Grid1[9, fila].Value = "1";
                //C:\Users\dgarcia\Documents\Proyectos\HDV_SAP\FrmProcesos\Resources\16 (Box_unchecked).ico
                //C:\Users\dgarcia\Documents\Proyectos\HDV_SAP\FrmProcesos\Resources\16 (Box_checked).ico
            }
            else
            {
                Grid1[0, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");
                Grid1[9, fila].Value = "0";
                //C:\Users\dgarcia\Documents\Proyectos\HDV_SAP\FrmProcesos\Resources\16 (Box_unchecked).ico
                //C:\Users\dgarcia\Documents\Proyectos\HDV_SAP\FrmProcesos\Resources\16 (Box_checked).ico
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_imprimir2_Click(object sender, EventArgs e)
        {
            int nDocEntry;
            string cWhsCode;

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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
                MessageBox.Show("No Existen registros a eliminar, opción Cancelada", "Orden de fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = int.Parse(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cWhsCode = Grid1[4, fila].Value.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nDocEntry;
            VariablesGlobales.glb_Almacen = cWhsCode;

            frmOrdenFabricacionTR9_B f2 = new frmOrdenFabricacionTR9_B();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Almacen = "";
        

        }

    }

}
