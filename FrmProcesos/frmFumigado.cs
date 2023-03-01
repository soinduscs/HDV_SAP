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
    public partial class frmFumigado : Form
    {
        public frmFumigado()
        {
            InitializeComponent();
        }

        private void frmFumigado_Load(object sender, EventArgs e)
        {

        }

        private void t_pallet_full_Leave(object sender, EventArgs e)
        {

            if (t_pallet_full.Text.Trim() != "")
            {
                carga_pallet();

            }

        }

        private void carga_pallet()
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Pallet_x_Code(t_pallet_full.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_itemcode.Text = dTable.Rows[0]["U_ItemCode"].ToString();
            }
            catch
            {
                t_itemcode.Clear();
            }

            try
            {
                t_itemname.Text = dTable.Rows[0]["U_ItemName"].ToString();
            }
            catch
            {
                t_itemname.Clear();
            }

            try
            {
                t_whscode.Text = dTable.Rows[0]["U_WhsCode"].ToString();
            }
            catch
            {
                t_whscode.Clear();
            }

            string cLineId, cAbsEntry, cLote;
            DateTime dFecha;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLineId = dTable.Rows[i]["LineId"].ToString();
                }
                catch
                {
                    cLineId = "";
                }

                try
                {
                    cAbsEntry = dTable.Rows[i]["U_AbsEntry"].ToString();
                }
                catch
                {
                    cAbsEntry = "";
                }

                try
                {
                    cLote = dTable.Rows[i]["U_DistNumber"].ToString();
                }
                catch
                {
                    cLote = "";
                }
                // , t2.U_Fumigado
                try
                {
                    dFecha = DateTime.Parse(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                }
                catch
                {
                    dFecha = DateTime.Parse("01/01/1900");
                }

                grilla[0] = cLineId;
                grilla[1] = cAbsEntry;
                grilla[2] = cLote;

                grilla[3] = "NO";
                grilla[4] = "";


                if (dFecha.Year > 1900)
                {
                    grilla[3] = "SI";
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");

                }

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void t_lote_Leave(object sender, EventArgs e)
        {

            if (t_lote.Text.Trim() != "")
            {
                carga_lote();

            }

        }

        private void carga_lote()
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Lote(t_lote.Text);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_itemcode_l.Text = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                t_itemcode_l.Clear();
            }

            try
            {
                t_itemname_l.Text = dTable.Rows[0]["itemName"].ToString();
            }
            catch
            {
                t_itemname_l.Clear();
            }

            try
            {
                t_whscode_l.Text = dTable.Rows[0]["WhsCode"].ToString();
            }
            catch
            {
                t_whscode_l.Clear();
            }

            string cAbsEntry, cLote, cLote_D;
            string cExiste;

            DateTime dFecha;
            double nQuantity;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cAbsEntry = dTable.Rows[i]["AbsEntry"].ToString();
                }
                catch
                {
                    cAbsEntry = "";
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
                    dFecha = DateTime.Parse(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                }
                catch
                {
                    dFecha = DateTime.Parse("01/01/1900");
                }

                try
                {
                    nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString()); //
                }
                catch
                {
                    nQuantity = 0;
                }

                grilla[0] = (i+1).ToString();
                grilla[1] = cAbsEntry;
                grilla[2] = cLote;

                grilla[3] = "";
                grilla[4] = "";


                if (dFecha.Year > 1900)
                {
                    grilla[3] = "SI";
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");

                }

                if (nQuantity>0)
                {

                    cExiste = "";

                    for (int x = 0; x <= Grid1.RowCount - 1; x++)
                    {                        
                        try
                        {
                            cLote_D = Grid1[1, x].Value.ToString();
                        }
                        catch
                        {
                            cLote_D = "";
                        }

                        cExiste = "";

                        if (cAbsEntry== cLote_D)
                        {
                            cExiste = "SI";
                            break;

                        }

                    }

                    if (cExiste == "")
                    {
                        Grid1.Rows.Add(grilla);

                    }

                }

            }

        }

        private void btn_fumiga_lote_Click(object sender, EventArgs e)
        {
            int nCantRegistros;

            nCantRegistros = -1;
            
            try
            {
                nCantRegistros = Grid1.RowCount - 1;

            }
            catch
            {
                nCantRegistros = -1;

            }

            if (nCantRegistros == -1)
            {
                MessageBox.Show("No Existen regsitros a procesar, opción Cancelada", "Fumigado de Lotes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Fumigar los Lotes seleccionados", "Fumigado de Lotes ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cErrorMensaje, mensaje;

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            string[,] d_arrDetalle = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            string cFumigado, cAbsEntry;
            int nLote, nNumeroLotes;

            nNumeroLotes = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cFumigado = "";
                cAbsEntry = "";

                try
                {
                    cFumigado = Grid1[3, x].Value.ToString();
                }
                catch
                {
                    cFumigado = "";
                }

                try
                {
                    cAbsEntry = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry = "";
                }

                try
                {
                    nLote = int.Parse(cAbsEntry);
                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {
                    d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                    nNumeroLotes += 1;

                }

            }

            if (nNumeroLotes == 0)
            {
                MessageBox.Show("No existen lotes a asginar, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            cErrorMensaje = "";

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

            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            //// 
            //// borro los lotes al pallet antiguo

            mensaje = clsOrdenFabricacion.Fumiga_Lote(d_arrDetalle, "", UsuarioSap, ClaveSap);


            try
            {
                //nOrdenFabricacionEntry = int.Parse(mensaje);
                cErrorMensaje = "";

                MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                //nOrdenFabricacionEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la asignación del pallet :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btn_fumiga_lote.Enabled = false;

        }
    }

}
