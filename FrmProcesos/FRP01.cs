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
    public partial class FRP01 : Form
    {
        public FRP01()
        {
            InitializeComponent();
        }

        private void FRP01_Load(object sender, EventArgs e)
        {
            dtp_nueva_fecha.Enabled = false;
            cbb_seleccionar_impresora.Items.Clear();
            dtp_nueva_fecha.Value = DateTime.Today;
            T_Proceso.Clear();

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

            int nEntMercaderia, nTransfStock;

            nEntMercaderia = 0;
            nTransfStock = 0;

            try
            {
                nEntMercaderia = int.Parse(VariablesGlobales.glb_Referencia1);
            }
            catch
            {
                nEntMercaderia = 0;
            }

            try
            {
                nTransfStock = int.Parse(VariablesGlobales.glb_Referencia2);
            }
            catch
            {
                nTransfStock = 0;
            }

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_SAPB1_RECEPCION5(nEntMercaderia, nTransfStock);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            double nNumEtiquetas;
            //string cImpresion;

            t_EntMercaderia.Text = nEntMercaderia.ToString();
            t_nTransfStock.Text = nTransfStock.ToString();

            try
            {
                t_lote.Text = dTable.Rows[0]["Lote"].ToString();
            }
            catch
            {
                t_lote.Text = "";
            }

            //cImpresion = "";

            nNumEtiquetas = 1;

            try
            {
                nNumEtiquetas = double.Parse(dTable.Rows[0]["Bins"].ToString());
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            cbb_cantidad_etiquetas.Items.Clear();
            t_total_bins.Text = nNumEtiquetas.ToString();

            if (nNumEtiquetas > 0)
            {
                for (int i = 0; i <= nNumEtiquetas - 1; i++)
                {
                    cbb_cantidad_etiquetas.Items.Add((i + 1).ToString());

                }

                try
                {
                    cbb_cantidad_etiquetas.SelectedIndex = Convert.ToInt32(nNumEtiquetas) - 1;

                }
                catch
                {

                }

            }


        }

        private void btn_imprimir1_Click(object sender, EventArgs e)
        {

            if (cbb_seleccionar_impresora.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una impresora válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_cantidad_etiquetas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad de etiquetas válida, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nEntMercaderia, nTransfStock, nNumEtiquetas;
            int nQuantity, nDocNum;

            string cLote, cNuevo_ItemName1, cCardCode;
            string cCardName, cTipoFruta, cCodigo_CSG;
            string cCampo, cTipoCosecha;

            DateTime dFechaCreacion;

            double nPeso_x_bins;

            nEntMercaderia = 0;
            nTransfStock = 0;

            try
            {
                nEntMercaderia = int.Parse(t_EntMercaderia.Text);
            }
            catch
            {
                nEntMercaderia = 0;
            }

            try
            {
                nTransfStock = int.Parse(t_nTransfStock.Text);
            }
            catch
            {
                nTransfStock = 0;
            }

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_SAPB1_RECEPCION5(nEntMercaderia, nTransfStock);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cLote = dTable.Rows[0]["Lote"].ToString();
            }
            catch
            {
                cLote = "";
            }

            try
            {
                cNuevo_ItemName1 = dTable.Rows[0]["Dscription"].ToString();
            }
            catch
            {
                cNuevo_ItemName1 = "";
            }

            try
            {
                cCardCode = dTable.Rows[0]["CardCode"].ToString();
            }
            catch
            {
                cCardCode = "";
            }

            try
            {
                cCardName = dTable.Rows[0]["CardName"].ToString();
            }
            catch
            {
                cCardName = "";
            }

            try
            {
                cTipoFruta = dTable.Rows[0]["TipoFruta"].ToString();
            }
            catch
            {
                cTipoFruta = "";
            }
           
            try
            {
                nDocNum = Int32.Parse(dTable.Rows[0]["DocNum"].ToString());
            }
            catch
            {
                nDocNum = 1;
            }

            nNumEtiquetas = 1;

            try
            {
                nNumEtiquetas = Int32.Parse(dTable.Rows[0]["Bins"].ToString());
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            nQuantity = nNumEtiquetas;

            try
            {
                nPeso_x_bins = Math.Round(double.Parse(dTable.Rows[0]["Promedio"].ToString()),0);
            }
            catch
            {
                nPeso_x_bins = 0;
            }

            try
            {
                nNumEtiquetas = Convert.ToInt32(cbb_cantidad_etiquetas.Text);
            }
            catch
            {
                nNumEtiquetas = 1;
            }

            try
            {
                dFechaCreacion = DateTime.Parse(dTable.Rows[0]["DocDate"].ToString());
            }
            catch
            {
                dFechaCreacion = DateTime.Parse("01/01/1900");
            }

            try
            {
                cCodigo_CSG = dTable.Rows[0]["U_Codigo_CSG"].ToString();

            }
            catch
            {
                cCodigo_CSG = "";

            }

            try
            {
                cCampo = dTable.Rows[0]["U_NOMBCLI"].ToString();

            }
            catch
            {
                cCampo = "";

            }

            try
            {
                cTipoCosecha = dTable.Rows[0]["U_Tipo_Cosecha"].ToString();

            }
            catch
            {
                cTipoCosecha = "";

            }

            for (int i = 0; i <= nNumEtiquetas - 1; i++)
            {
                etiqueta_adhesiva2(cLote, cNuevo_ItemName1, cCardCode, cCardName, nDocNum, i + 1, Convert.ToInt32(t_total_bins.Text), nPeso_x_bins, dFechaCreacion, cTipoFruta, "", "", "", cCodigo_CSG, cCampo, cTipoCosecha);
            }

        }

        private void etiqueta_adhesiva2(string cLote, string cItemName, string cCardCode, string cCardName, int nDocNum, int nFolio1, int nFolio2, double nPesoUnit, DateTime dFechaCreacion, string c_tipoFruta, string cComunaRes, string cProvinciaRes, string cNombreRes, String cCodigo_CSG, string cCampo, string cTipoCosecha)
        {

            //////////////////////////////////////
            // Etiqueta de D&S 

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 18);
                Font Font_Titulo = new Font("Consolas", 16, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 10, FontStyle.Bold);
                Font Font_Titulo_S = new Font("Consolas", 20, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                //e1.Graphics.DrawString("Despeloado & SecadoProductor: " + cCardName, Font_Cuerpo, br, 5, 20);

                e1.Graphics.DrawString(c_tipoFruta.ToUpper(), Font_Titulo_S, br, 10, 20);

                e1.Graphics.DrawString("****************************", Font_Cuerpo, br, 10, 50);

                e1.Graphics.DrawString("Lote :" + cLote, Font_Titulo, br, 10, 70);
                e1.Graphics.DrawString(nFolio1.ToString() + " / " + nFolio2.ToString(), Font_Titulo, br, 280, 70);

                e1.Graphics.DrawString("Fecha R.: " + dFechaCreacion.ToString("dd/MM/yy"), Font_Cuerpo, br, 10, 100);

                e1.Graphics.DrawString("************************************************************", Font_Cuerpo, br, 10, 120);

                e1.Graphics.DrawString(cItemName, Font_Titulo, br, 10, 130);

                e1.Graphics.DrawString("************************************************************", Font_Cuerpo, br, 10, 160);

                e1.Graphics.DrawString("Productor: " + cCardName, Font_Titulo, br, 10, 170);
                e1.Graphics.DrawString("Campo: " + cCampo, Font_Titulo, br, 10, 200);

                e1.Graphics.DrawString("Guía: " + nDocNum.ToString(), Font_Cuerpo, br, 10, 240);
                e1.Graphics.DrawString("Código CSG: " + cCodigo_CSG.ToString(), Font_Titulo, br, 180, 240);

                e1.Graphics.DrawString("Tipo Cosecha: " + cTipoCosecha.ToString(), Font_Titulo, br, 180, 280);

                e1.Graphics.DrawString("PESO: " + nPesoUnit.ToString(), Font_Titulo_S, br, 10, 320);
                e1.Graphics.DrawString("*" + cLote + "* ", Font_CodigoBarra, br, 260, 320);

            };

            try
            {
                p.PrinterSettings.PrinterName = cbb_seleccionar_impresora.Text;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 50, 0, 50);
                //p.PrinterSettings.Copies = 20;               

                if (p.PrinterSettings.IsValid)
                {

                    for (int i = 0; i <= nFolio2 - 1; i++)
                    {


                    }

                    //p.PrintPage

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


        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

    }

}
