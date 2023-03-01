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
    public partial class frmPallet2 : Form
    {
        public frmPallet2()
        {
            InitializeComponent();

        }

        private void frmPallet2_Load(object sender, EventArgs e)
        {
            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos1 f2 = new frmSel_Productos1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode != "")
            {
                Grid1.Rows.Clear();

                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

            }

        }

        private void cbb_almacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_itemname.Text != "")
            {
                carga_lotes_almacen();

            }


        }

        private void carga_lotes_almacen()
        {
            string cToWhs = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un artículo válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Productos_Sin_Pallet(t_itemcode.Text.Trim(), cToWhs);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cAbsEntry, cLote;

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

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

                grilla[0] = (i+1).ToString();
                grilla[1] = cAbsEntry;
                grilla[2] = cLote;

                Grid1.Rows.Add(grilla);

            }


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cToWhs = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un artículo válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = t_itemcode.Text.Trim();
            VariablesGlobales.glb_Almacen = cToWhs;
            VariablesGlobales.glb_Pallet = "";

            frmSel_Pallet f2 = new frmSel_Pallet();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_Pallet != "")
            {
                t_pallet.Text = VariablesGlobales.glb_Pallet;

                Grid2.Rows.Clear();

                carga_lotes_en_pallet();

                button1.Enabled = false;
                btn_agrega_pallet.Visible = false;
                t_pallet_nuevo.Clear();

            }


        }

        private void carga_lotes_en_pallet()
        {
            string cToWhs = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un artículo válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_pallet.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un folio de Pallet válida, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Pallet_x_Code_Almacen(t_pallet.Text.Trim(), cToWhs);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            string cAbsEntry, cLote;

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

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
                    cLote = dTable.Rows[i]["DistNumber"].ToString();
                }
                catch
                {
                    cLote = "";

                }

                if (cAbsEntry != "")
                {
                    grilla[0] = (i + 1).ToString();
                    grilla[1] = "E";
                    grilla[2] = cAbsEntry;
                    grilla[3] = cLote;

                    Grid2.Rows.Add(grilla);

                    Grid2[1, i].Style.BackColor = Color.LightGray;
                    Grid2[2, i].Style.BackColor = Color.LightGray;

                }

            }

        }

        private void btn_pasar_Click(object sender, EventArgs e)
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

            string cAbsEntry, cLote;
            string cAbsEntry_D, cLote_D;

            int nFila;

            try
            {
                cAbsEntry = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cAbsEntry = "";
            }

            try
            {
                cLote = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cLote = "";
            }

            nFila = 0;

            for (int x = 0; x <= Grid2.RowCount - 1; x++)
            {
                cAbsEntry_D = "";
                cLote_D = "";

                try
                {
                    cAbsEntry_D = Grid2[2, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry_D = "";
                }

                try
                {
                    cLote_D = Grid2[3, x].Value.ToString();
                }
                catch
                {
                    cLote_D = "";
                }

                if (cAbsEntry_D == cAbsEntry)
                {
                    nFila = x;
                    break;
                }

            }

            if (nFila>0)
            {

            }

            string[] grilla;
            grilla = new string[30];

            grilla[0] = (Grid2.Rows.Count + 1).ToString();
            grilla[1] = "";
            grilla[2] = cAbsEntry;
            grilla[3] = cLote;

            Grid2.Rows.Add(grilla);

            try
            {
                Grid1.Rows.RemoveAt(fila);

            }
            catch
            {

            }

            Grid1.ClearSelection();

        }

        private void btn_devuelve_Click(object sender, EventArgs e)
        {

            int fila;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            string cAbsEntry, cLote, cOrigen;
            string cAbsEntry_D, cLote_D;

            int nFila;

            try
            {
                cOrigen = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cOrigen = "";
            }

            try
            {
                cAbsEntry = Grid2[2, fila].Value.ToString();
            }
            catch
            {
                cAbsEntry = "";
            }

            try
            {
                cLote = Grid2[3, fila].Value.ToString();
            }
            catch
            {
                cLote = "";
            }

            if (cOrigen=="E")
            {
                MessageBox.Show("El Lote seleccionado existia previamente en esta folio de pallet, no se puede quitar por esta instancia, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            nFila = -1;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {
                cAbsEntry_D = "";
                cLote_D = "";

                try
                {
                    cAbsEntry_D = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry_D = "";
                }

                try
                {
                    cLote_D = Grid1[2, x].Value.ToString();
                }
                catch
                {
                    cLote_D = "";
                }

                if (cAbsEntry_D == cAbsEntry)
                {
                    nFila = x;
                    break;
                }

            }

            if (nFila == -1)
            {
                ////////////////////////////////////
                // Lo Agrego siempre que no este 

                string[] grilla;
                grilla = new string[30];

                grilla[0] = (Grid1.Rows.Count + 1).ToString();
                grilla[1] = cAbsEntry;
                grilla[2] = cLote;

                Grid1.Rows.Add(grilla);

            }

            ////////////////////////////////////
            // Lo borro desde la lista de lotes

            try
            {
                Grid2.Rows.RemoveAt(fila);

            }
            catch
            {

            }

            Grid2.ClearSelection();

        }

        private void btn_agrega_pallet_Click(object sender, EventArgs e)
        {
            string cToWhs = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un artículo válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar nuevo pallet", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string[,] d_arrDetalle = new string[2, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }
           
            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap, cErrorMensaje;
            int nNuevoPallet;

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

            string mensaje = clsOrdenFabricacion.Crea_Nuevo_Pallet(t_itemcode.Text, t_itemname.Text , cToWhs, UsuarioSap, ClaveSap);

            //////////////////////////////////////

            try
            {
                nNuevoPallet = int.Parse(mensaje);
                cErrorMensaje = "";

                t_pallet_nuevo.Text = "P" + nNuevoPallet.ToString();

            }
            catch
            {
                nNuevoPallet = 0;
                cErrorMensaje = mensaje;
                t_pallet_nuevo.Clear();

                MessageBox.Show("Error en la generación de la orden de fabricacion :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            t_pallet.Clear();
            button1.Visible = false;
            btn_agrega_pallet.Enabled = false;

        }

        private void btn_genera_pallet_Click(object sender, EventArgs e)
        {
            string cToWhs = "";

            try
            {
                cToWhs = cbb_almacen.SelectedValue.ToString();

            }
            catch
            {
                cToWhs = "";

            }

            if (cToWhs == "")
            {
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente un artículo válido, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Asignar este Lotes al pallet seleccionado", "Gestión de Pallet ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cPalleExistente, cErrorMensaje, mensaje;

            try
            {
                cPalleExistente = t_pallet.Text;
            }
            catch
            {
                cPalleExistente = "";
            }

            if (cPalleExistente=="")
            {
                try
                {
                    cPalleExistente = t_pallet_nuevo.Text;
                }
                catch
                {
                    cPalleExistente = "";
                }

            }

            if (cPalleExistente == "")
            {
                MessageBox.Show("Debe Seleccionar seleccionar previamente un folio de pallet, opción Cancelada", "Gestión de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ///////////////////////////////////////////////////////
            //// Cargo el detalle de lotes asociados a la recepcion
            ////

            string[,] d_arrDetalle = new string[3, 100];

            for (int i = 0; i <= 99; i++)
            {
                d_arrDetalle[0, i] = "";

            }

            string cOrigen, cAbsEntry, cDistNumber;
            int nLote, nNumeroLotes;

            nNumeroLotes = 0;

            for (int x = 0; x <= Grid2.RowCount - 1; x++)
            {
                cOrigen = "";
                cAbsEntry = "";

                try
                {
                    cOrigen = Grid2[1, x].Value.ToString();
                }
                catch
                {
                    cOrigen = "";
                }

                try
                {
                    cAbsEntry = Grid2[2, x].Value.ToString();
                }
                catch
                {
                    cAbsEntry = "";
                }

                try
                {
                    cDistNumber = Grid2[3, x].Value.ToString();
                }
                catch
                {
                    cDistNumber = "";
                }
                
                try
                {
                    nLote = int.Parse(cAbsEntry);
                }
                catch
                {
                    nLote = 0;
                }

                if (cOrigen == "")
                {
                    if (nLote > 0)
                    {
                        d_arrDetalle[1, nNumeroLotes] = nLote.ToString();
                        d_arrDetalle[2, nNumeroLotes] = cDistNumber;
                        nNumeroLotes += 1;

                    }

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

            mensaje = clsOrdenFabricacion.Entrada_Mercaderia_Asigna_Pallet(cPalleExistente, d_arrDetalle, UsuarioSap, ClaveSap);

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

            btn_genera_pallet.Enabled = false;

        }

    }

}
