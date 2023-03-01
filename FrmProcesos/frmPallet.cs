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
    public partial class frmPallet : Form
    {
        public frmPallet()
        {
            InitializeComponent();
        }

        private void frmPallet_Load(object sender, EventArgs e)
        {
            t_pallet.Text = VariablesGlobales.glb_Pallet;

            carga_pallet();

        }

        private void carga_pallet()
        {

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_Pallet_x_Code(t_pallet.Text);

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

            try
            {
               t_codigobarra.Text = dTable.Rows[0]["U_BarCode"].ToString();
            }
            catch
            {
                t_codigobarra.Clear();
            }

            string cLineId, cAbsEntry, cLote;

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

                grilla[0] = cLineId;
                grilla[1] = cAbsEntry;
                grilla[2] = cLote;

                Grid1.Rows.Add(grilla);

            }

        }

        private void btn_quitar_lote_Click(object sender, EventArgs e)
        {

            int fila;
            string cLote;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Maestro de Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cLote = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cLote = "";
            }

            if (cLote == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Maestro de Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar el Lote seleccionado", "Maestro de Pallet ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.Borra_Lote_de_Pallet(t_pallet.Text , cLote);

                MessageBox.Show("Registro Eliminado Exitosamente", "Maestro de Pallet ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                carga_pallet();

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

    }

}
