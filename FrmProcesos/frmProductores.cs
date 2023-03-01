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
    public partial class frmProductores : Form
    {
        public frmProductores()
        {
            InitializeComponent();
        }

        private void frmProductores_Load(object sender, EventArgs e)
        {
            //cbb_cosecha.SelectedIndex = 0;

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

                clsSocioNegocio objproducto = new clsSocioNegocio();
                objproducto.cls_Consultar_OCRDxCardCode(t_cardcode.Text.Trim());

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_encargado.Text = dTable.Rows[0]["SlpName"].ToString();
                }
                catch
                {
                    t_encargado.Text = "";
                }

                clsSocioNegocio objproducto1 = new clsSocioNegocio();
                objproducto1.cls_Consultar_ContactosxCardCode(t_cardcode.Text.Trim());

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                Grid_Contactos.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
                {                  

                    try
                    {
                        grilla[0] = dTable1.Rows[i]["Name"].ToString();

                    }
                    catch
                    {
                        grilla[0] = "";

                    }

                    try
                    {
                        grilla[1] = dTable1.Rows[i]["FirstName"].ToString();

                    }
                    catch
                    {
                        grilla[1] = "";

                    }

                    try
                    {
                        grilla[2] = dTable1.Rows[i]["LastName"].ToString();

                    }
                    catch
                    {
                        grilla[2] = "";

                    }

                    try
                    {
                        grilla[3] = dTable1.Rows[i]["Cellolar"].ToString();

                    }
                    catch
                    {
                        grilla[3] = "";

                    }

                    try
                    {
                        grilla[4] = dTable1.Rows[i]["E_MailL"].ToString();

                    }
                    catch
                    {
                        grilla[4] = "";

                    }

                    Grid_Contactos.Rows.Add(grilla);

                }

            }

            Carga_entradas_productor();

            Carga_liquidaciones_productor();

        }

        private void Carga_entradas_productor()
        {
            float nValor;
            DateTime dFecha;

            string[] grilla1;
            grilla1 = new string[30];

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_Detalle_Entradas_xCardCode(t_cardcode.Text.Trim());

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid_Entradas.Rows.Clear();

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    grilla1[1] = dTable2.Rows[i]["FolioNum"].ToString();

                }
                catch
                {
                    grilla1[1] = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable2.Rows[i]["DocDate"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");

                }

                grilla1[2] = dFecha.ToString("dd/MM/yyyy");

                try
                {
                    grilla1[3] = dTable2.Rows[i]["ItemName"].ToString();

                }
                catch
                {
                    grilla1[3] = "";

                }

                try
                {
                    grilla1[4] = dTable2.Rows[i]["U_HDV_VARIEDAD"].ToString();

                }
                catch
                {
                    grilla1[4] = "";

                }

                try
                {
                    grilla1[5] = dTable2.Rows[i]["BaseRef"].ToString();

                }
                catch
                {
                    grilla1[5] = "";

                }

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[6] = nValor.ToString("N");

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["DocTotal"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[7] = nValor.ToString("N");

                try
                {
                    grilla1[8] = dTable2.Rows[i]["DocEntry"].ToString();

                }
                catch
                {
                    grilla1[8] = "";
                }

                Grid_Entradas.Rows.Add(grilla1);

            }

        }
    
        private void Carga_liquidaciones_productor()
        {
            float nValor;
            DateTime dFecha;

            string[] grilla1;
            grilla1 = new string[30];

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_Detalle_liquidacion_xCardCode(t_cardcode.Text.Trim());

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid_Liquidacion.Rows.Clear();

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    grilla1[0] = dTable2.Rows[i]["DocEntry"].ToString();

                }
                catch
                {
                    grilla1[0] = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable2.Rows[i]["CreateDate"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");

                }

                grilla1[1] = dFecha.ToString("dd/MM/yyyy");

                try
                {
                    grilla1[2] = dTable2.Rows[i]["Comment"].ToString();

                }
                catch
                {
                    grilla1[2] = "";

                }

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["DocTotal"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[3] = nValor.ToString("N");

                Grid_Liquidacion.Rows.Add(grilla1);

            }

        }


        private void Carga_detalle_liquidacion(int nFolio)
        {
            float nValor;
            DateTime dFecha;

            string[] grilla1;
            grilla1 = new string[30];

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_detalle_liquidacion(nFolio);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid_DetLiquidacion.Rows.Clear();

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    grilla1[0] = dTable2.Rows[i]["FolioNum"].ToString();

                }
                catch
                {
                    grilla1[0] = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable2.Rows[i]["DocDate"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");

                }

                grilla1[1] = dFecha.ToString("dd/MM/yyyy");

                try
                {
                    grilla1[2] = dTable2.Rows[i]["ItemName"].ToString();

                }
                catch
                {
                    grilla1[2] = "";

                }

                try
                {
                    grilla1[3] = dTable2.Rows[i]["U_HDV_VARIEDAD"].ToString();

                }
                catch
                {
                    grilla1[3] = "";

                }

                try
                {
                    grilla1[4] = dTable2.Rows[i]["BaseRef"].ToString();

                }
                catch
                {
                    grilla1[4] = "";

                }

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[5] = nValor.ToString("N");

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["DocTotal"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[6] = nValor.ToString("N");

                try
                {
                    grilla1[7] = dTable2.Rows[i]["DocEntry"].ToString();

                }
                catch
                {
                    grilla1[7] = "";
                }

                Grid_DetLiquidacion.Rows.Add(grilla1);

            }

        }

        private void Carga_vencimiento_liquidacion(int nFolio)
        {
            float nValor;
            DateTime dFecha;

            string[] grilla1;
            grilla1 = new string[30];

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_vencimiento_liquidacion(nFolio);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid_Vencimientos.Rows.Clear();

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    grilla1[0] = dTable2.Rows[i]["DocEntry"].ToString();

                }
                catch
                {
                    grilla1[0] = "";

                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable2.Rows[i]["U_Fecha"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");

                }

                grilla1[1] = dFecha.ToString("dd/MM/yyyy");

                nValor = 0;

                try
                {
                    nValor = float.Parse(dTable2.Rows[i]["U_Valor"].ToString());
                }
                catch
                {
                    nValor = 0;
                }

                grilla1[2] = nValor.ToString("N");

                Grid_Vencimientos.Rows.Add(grilla1);

            }

        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {

            int[] arrLiquidacion = new int[1000];
            int arrLiquidacion_arr;
            Boolean bConfirmado;

            arrLiquidacion_arr = 0;

            for (int i = 0; i <= Grid_Entradas.RowCount - 1; i++)
            {

                try
                {
                    bConfirmado = Convert.ToBoolean(Grid_Entradas[0, i].Value);

                }
                catch
                {
                    bConfirmado = false;

                }

                if (bConfirmado == true)
                {
                    try
                    {
                        arrLiquidacion[arrLiquidacion_arr] = Convert.ToInt32(Grid_Entradas[8, i].Value.ToString());
                        arrLiquidacion_arr += 1;

                    }
                    catch
                    {

                    }

                }

            }

            if (arrLiquidacion_arr == 0)
            {
                MessageBox.Show("No existen lineas seleccionadas, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta segura de generar la liquidación?", "Registro de Productores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

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

            cErrorMensaje = "";

            int nDocEntry_old; 

            clsMaestros objproducto2 = new clsMaestros();
            objproducto2.cls_Consultar_max_liquidacion_productor();

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            nDocEntry_old = -1;

            try
            {
                nDocEntry_old = Convert.ToInt32( dTable2.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                nDocEntry_old = -1;

            }

            //////////////////////////////////////
            // Genero el avance de proceso

            String mensaje = clsMaestros.TablaUsuario_LiqProductor(t_cardcode.Text, t_cardname.Text, UsuarioSap, ClaveSap);

            int nNew_DocEntry;

            nNew_DocEntry = 0;

            clsMaestros objproducto3 = new clsMaestros();
            objproducto3.cls_Consultar_max_liquidacion_productor();

            DataTable dTable3 = new DataTable();
            dTable3 = objproducto3.cResultado;

            try
            {
                nNew_DocEntry = Convert.ToInt32(dTable3.Rows[0]["DocEntry"].ToString());
            }
            catch
            {
                nNew_DocEntry = -1;

            }

            if (nNew_DocEntry == nDocEntry_old)
            {
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación de la liquidación  :::::: " + cErrorMensaje + ", opción Cancelada", "Registro de Productores ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (nNew_DocEntry > 0)
            {
                int nLineId, nDocEntry_Guia;

                nLineId = 0;
                nDocEntry_Guia = 0;

                for (int i = 0; i <= arrLiquidacion_arr - 1; i++)
                {

                    try
                    {
                        nDocEntry_Guia = arrLiquidacion[i];

                    }
                    catch
                    {
                        nDocEntry_Guia = 0;

                    }

                    if (nDocEntry_Guia > 0)
                    {
                        try
                        {
                            mensaje = clsMaestros.Agrega_Detalle_LiqProductor(nNew_DocEntry, nLineId, nDocEntry_Guia);
                            nLineId += 1;
                        }
                        catch
                        {

                        }

                    }

                }

            }

            MessageBox.Show("Proceso Realizado con Exito", "Registro de Productores ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Carga_entradas_productor();

            Carga_liquidaciones_productor();


        }

        private void Grid_Liquidacion_SelectionChanged(object sender, EventArgs e)
        {
            int fila, nFolio;

            try
            {
                fila = Grid_Liquidacion.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            nFolio = 0;

            if (fila >= 0)
            {

                Grid_DetLiquidacion.Rows.Clear();

                Grid_Vencimientos.Rows.Clear();

                try
                {
                    nFolio = Convert.ToInt32(Grid_Liquidacion[0, fila].Value);

                }
                catch
                {
                    nFolio = 0;

                }

                if (nFolio > 0)
                {
                    Carga_detalle_liquidacion(nFolio);

                    Carga_vencimiento_liquidacion(nFolio);

                }

            }

        }

        private void btn_venc_agrega_Click(object sender, EventArgs e)
        {

            int fila, nFolio;

            try
            {
                fila = Grid_Liquidacion.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            nFolio = 0;

            if (fila >= 0)
            {
                try
                {
                    nFolio = Convert.ToInt32(Grid_Liquidacion[0, fila].Value);

                }
                catch
                {
                    nFolio = 0;

                }

                string[] grilla1;
                grilla1 = new string[30];

                grilla1[0] = nFolio.ToString();
                grilla1[1] = DateTime.Today.ToString("dd/MM/yyyy");
                grilla1[2] = 0.ToString("N2");

                Grid_Vencimientos.Rows.Add(grilla1);

            }

        }

        private void Grid_Vencimientos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int fila;

            try
            {
                fila = Grid_Vencimientos.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {
                DateTime dFecha;
                double nMonto;

                try
                {
                    dFecha = Convert.ToDateTime(Grid_Vencimientos[1, fila].Value);

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900"); 

                }

                try
                {
                    nMonto = Convert.ToDouble(Grid_Vencimientos[2, fila].Value);

                }
                catch
                {
                    nMonto = 0;

                }

                Grid_Vencimientos[1, fila].Value = dFecha.ToString("dd/MM/yyyy");
                Grid_Vencimientos[2, fila].Value = nMonto.ToString("N2");

            }
        }

        private void btn_venc_quitar_Click(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = Grid_Vencimientos.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {

                Grid_Vencimientos.Rows.RemoveAt(fila);

            }

        }

        private void btn_venc_grabar_Click(object sender, EventArgs e)
        {

            int fila, nFolio;
            double nMontoLiquidacion;

            try
            {
                fila = Grid_Liquidacion.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            nFolio = 0;
            nMontoLiquidacion = 0;

            if (fila >= 0)
            {
                try
                {
                    nFolio = Convert.ToInt32(Grid_Liquidacion[0, fila].Value);

                }
                catch
                {
                    nFolio = 0;

                }

                try
                {
                    nMontoLiquidacion = Convert.ToDouble(Grid_Liquidacion[3, fila].Value);

                }
                catch
                {
                    nMontoLiquidacion = 0;

                }

                if (nMontoLiquidacion == 0)
                {
                    MessageBox.Show("El monto de la liquidación es cero, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            double nMontoVencimiento, nT_MontoVencimiento;
            DateTime dFechaVencimiento;

            nMontoVencimiento = 0;
            nT_MontoVencimiento = 0;

            for (int i = 0; i <= Grid_Vencimientos.RowCount - 1; i++)
            {

                try
                {
                    dFechaVencimiento = Convert.ToDateTime(Grid_Vencimientos[1, i].Value);

                }
                catch
                {
                    MessageBox.Show("Debe ingresar una fecha de vencimiento valida, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    nMontoVencimiento = Convert.ToDouble(Grid_Vencimientos[2, i].Value);

                }
                catch
                {
                    MessageBox.Show("Debe ingresar un monto de vencimiento valida, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                nT_MontoVencimiento += nMontoVencimiento;

            }

            if (nT_MontoVencimiento != nMontoLiquidacion)
            {
                MessageBox.Show("Debe monto total no corresponde al valor de la liquidación, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta segura de grabar los vencimientos?", "Registro de Productores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;
            //string cErrorMensaje;

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

            //cErrorMensaje = "";

            string mensaje = clsMaestros.Agrega_Vencimiento_LiqProductor(nFolio, -1, DateTime.Today, 0);

            int nLineId;

            nLineId = 0;

            for (int i = 0; i <= Grid_Vencimientos.RowCount - 1; i++)
            {

                try
                {
                    dFechaVencimiento = Convert.ToDateTime(Grid_Vencimientos[1, i].Value);

                }
                catch
                {
                    MessageBox.Show("Debe ingresar una fecha de vencimiento valida, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    nMontoVencimiento = Convert.ToDouble(Grid_Vencimientos[2, i].Value);

                }
                catch
                {
                    MessageBox.Show("Debe ingresar un monto de vencimiento valida, opción Cancelada", "Registro de Productores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                try
                {
                    mensaje = clsMaestros.Agrega_Vencimiento_LiqProductor(nFolio, nLineId, dFechaVencimiento, Convert.ToSingle(nMontoVencimiento));
                    nLineId += 1;
                }
                catch
                {

                }

            }

            MessageBox.Show("Proceso Realizado con Exito", "Registro de Productores ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Carga_entradas_productor();

            Carga_liquidaciones_productor();



        }
    }

}
