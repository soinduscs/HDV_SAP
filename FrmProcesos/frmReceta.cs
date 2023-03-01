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
    public partial class frmReceta : Form
    {
        public frmReceta()
        {
            InitializeComponent();
        }

        private void frmReceta_Load(object sender, EventArgs e)
        {
            t_itemcode.Text = VariablesGlobales.glb_ItemCode;
            t_itemname.Text = VariablesGlobales.glb_ItemName;
            t_docentry.Text = Convert.ToString(VariablesGlobales.glb_id_LMateriales);

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLista_Almacenes();

            cbb_almacen.DataSource = objproducto.cResultado;
            cbb_almacen.ValueMember = "WhsCode";
            cbb_almacen.DisplayMember = "WhsCode";

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.cls_ConsultaLista_Almacenes();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto1.cResultado;
            my_DGVCboColumn.Name = "Almacén";
            my_DGVCboColumn.ValueMember = "WhsCode";
            my_DGVCboColumn.DisplayMember = "WhsCode";

            Grid1.Columns.RemoveAt(6);
            Grid1.Columns.Insert(6, my_DGVCboColumn);
            Grid1.Columns[6].Width = 80;

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.cls_ConsultaLista_MetodoEmision();

            DataGridViewComboBoxColumn my_DGVCboColumn1 = new DataGridViewComboBoxColumn();

            my_DGVCboColumn1.DataSource = objproducto2.cResultado;
            my_DGVCboColumn1.Name = "Metodo emisión";
            my_DGVCboColumn1.ValueMember = "Code";
            my_DGVCboColumn1.DisplayMember = "Descripcion";

            Grid1.Columns.RemoveAt(7);
            Grid1.Columns.Insert(7, my_DGVCboColumn1);
            Grid1.Columns[7].Width = 110;

            carga_recetas();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void carga_recetas()
        {

            if (t_itemname.Text == "")
            {
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            string cToHws;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_ConsultaLMateriales(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_tipolmat.Text = dTable.Rows[0]["TipoLMat"].ToString();
            }
            catch
            {
                t_tipolmat.Clear();
            }

            try
            {
                t_costo.Text = dTable.Rows[0][""].ToString();
            }
            catch
            {
                t_costo.Clear();
            }

            try
            {
                t_tamano_producto.Text = Convert.ToDouble(dTable.Rows[0]["PIAvgSize"].ToString()).ToString("N2");
            }
            catch
            {
                t_tamano_producto.Clear();
            }

            try
            {
                t_cant.Text = Convert.ToDouble(dTable.Rows[0]["Father_Qauntity"].ToString()).ToString("N2");
            }
            catch
            {
                t_cant.Clear();
            }

            cToHws = "";

            try
            {
                cToHws = dTable.Rows[0]["Father_ToWH"].ToString();
            }
            catch
            {
                cToHws = "";
            }

            try
            {
                cbb_almacen.SelectedValue = cToHws;
            }
            catch
            {
                cbb_almacen.SelectedIndex = 0;
            }

            try
            {
                t_norma.Text = dTable.Rows[0][""].ToString();
            }
            catch
            {
                t_norma.Clear();
            }

            try
            {
                t_proyecto.Text = dTable.Rows[0]["Project"].ToString();
            }
            catch
            {
                t_proyecto.Clear();
            }

            try
            {
                t_referencia.Text = dTable.Rows[0]["U_Referencia"].ToString();
            }
            catch
            {
                t_referencia.Clear();
            }

            string cLine, cItemCode, cItemName;
            string cUM, cBodega, cListaPre;
            string cMetodoEmision;
            double nCantidad, nPrecio;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                try
                {
                    cLine = dTable.Rows[i]["LineId"].ToString();
                }
                catch
                {
                    cLine = "";

                }

                try
                {
                    cItemCode = dTable.Rows[i]["U_Code"].ToString();
                }
                catch
                {
                    cItemCode = "";

                }

                try
                {
                    cItemName = dTable.Rows[i]["CodeName"].ToString();
                }
                catch
                {
                    cItemName = "";

                }

                try
                {
                    nCantidad = Convert.ToDouble(dTable.Rows[i]["U_Quantity1"].ToString());
                }
                catch
                {
                    nCantidad = 0;
                }

                try
                {
                    cUM = dTable.Rows[i]["InvntryUom"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                try
                {
                    cBodega = dTable.Rows[i]["U_Warehouse"].ToString();
                }
                catch
                {
                    cBodega = "";
                }

                try
                {
                    cListaPre = dTable.Rows[i][""].ToString();
                }
                catch
                {
                    cListaPre = "";
                }

                try
                {
                    nPrecio = Convert.ToDouble(dTable.Rows[i]["U_Price"].ToString());
                }
                catch
                {
                    nPrecio = 0;
                }

                try
                {
                    cMetodoEmision = dTable.Rows[i]["U_OrigCurr"].ToString();
                }
                catch
                {
                    cMetodoEmision = "";
                }

                if (cMetodoEmision == "")
                {
                    cMetodoEmision = "M";

                }

                grilla[0] = cLine;
                grilla[1] = "Artículo";
                grilla[2] = cItemCode;
                grilla[3] = cItemName;
                grilla[4] = nCantidad.ToString("N4");
                grilla[5] = cUM;
                grilla[6] = cBodega;
                grilla[7] = cMetodoEmision;
                grilla[8] = cListaPre;
                grilla[9] = nPrecio.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

            itmes_grilla();

        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_referencia.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Referencia válida, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cItemCode, cItemName, cToWhs;
            double nXCantidad;
            int nDocEntry;

            cItemCode = t_itemcode.Text;
            cItemName = t_itemname.Text;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            try
            {
                nXCantidad = Convert.ToDouble(t_cant.Text);
            }
            catch
            {
                nXCantidad = 0;
            }

            cToWhs = "";

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
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string UserCode, cItemCode_D, cUM_D;
            string cNameCode_D, cOrigCurr;
            int UserId, nLine_D;
            double nCant_D;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            String mensaje = clsProduccion.SAPB1_RECETA2(nDocEntry, cItemCode, nXCantidad, cToWhs, t_referencia.Text, UserId);

            mensaje = clsProduccion.SAPB1_RECETA3(nDocEntry, -1, "", 0, "", "", UserId);

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLine_D = 0;

                try
                {
                    nLine_D = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLine_D = 0;
                }

                nLine_D = nLine_D - 1;

                cItemCode_D = Grid1[2, i].Value.ToString();
                cNameCode_D = Grid1[3, i].Value.ToString();

                try
                {
                    nCant_D = Convert.ToDouble(Grid1[4, i].Value.ToString());

                }
                catch
                {
                    nCant_D = 0;

                }

                cUM_D = Grid1[5, i].Value.ToString();

                try
                {
                    cToWhs = Grid1[6, i].Value.ToString();
                }
                catch
                {
                    cToWhs = "";
                }

                cOrigCurr = "";

                try
                {
                    cOrigCurr = Grid1[7, i].Value.ToString();

                }
                catch
                {
                    cOrigCurr = "M";

                }

                if (cOrigCurr == "")
                {
                    cOrigCurr = "M";
                }

                if (cItemCode_D.Trim() != "")
                {

                    if (nCant_D != 0)
                    {

                        mensaje = clsProduccion.SAPB1_RECETA3(nDocEntry, nLine_D, cItemCode_D, nCant_D, cToWhs, cOrigCurr, UserId);

                        //mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "");

                    }

                }

            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void t_cant_Leave(object sender, EventArgs e)
        {
            double nXCantidad;

            try
            {
                nXCantidad = Convert.ToDouble(t_cant.Text);

            }
            catch
            {
                nXCantidad = 0;

            }

            t_cant.Text = nXCantidad.ToString("N2");

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Lista de Materiales ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

            itmes_grilla();

        }

        private void tsb_agrega_productor_Click(object sender, EventArgs e)
        {

            string cToWhs = "";
            string cUM = "";

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
                MessageBox.Show("Debe seleccionar un Almacen válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos1 f2 = new frmSel_Productos1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode.Trim() != "")
            {

                clsProductos objproducto1 = new clsProductos();
                objproducto1.cls_consultar_Producto_x_codigo(VariablesGlobales.glb_ItemCode);

                DataTable dTable = new DataTable();
                dTable = objproducto1.cResultado;

                try
                {
                    cUM = dTable.Rows[0]["InvntryUom"].ToString();
                }
                catch
                {
                    cUM = "";
                }

                string[] grilla;
                grilla = new string[30];

                grilla[0] = "0";
                grilla[1] = "Artículo";
                grilla[2] = VariablesGlobales.glb_ItemCode;
                grilla[3] = VariablesGlobales.glb_ItemName;
                grilla[4] = 0.ToString("N4");
                grilla[5] = cUM;
                grilla[6] = cToWhs;
                grilla[7] = "M";
                grilla[8] = "";
                grilla[9] = 0.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

            itmes_grilla();

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nValor;

            nValor = 0;

            try
            {
                nValor = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                nValor = 0;

            }

            Grid1[4, fila].Value = nValor.ToString("N4");


        }

        private void itmes_grilla()
        {

            int nLineId = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = i + 1;

                Grid1[0, i].Value = nLineId.ToString();

            }

        }

        private void btn_Borrar_Click(object sender, EventArgs e)
        {

            string UserCode;
            int UserId, nDocEntry;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Opción No valida, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar esta Lista de Materiales", "Lista de Materiales ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                String mensaje = clsProduccion.SAPB1_RECETA3(nDocEntry, -1, "", 0, "", "", UserId);

                mensaje = clsProduccion.SAPB1_RECETA2(nDocEntry, "._.", 0, "", t_referencia.Text, UserId);

                MessageBox.Show("Registro Eliminado Exitosamente", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (t_itemcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_referencia.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Referencia válida, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_docentry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Lista de Materiales ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_ItemCode = t_itemcode.Text;
            VariablesGlobales.glb_ItemName = t_itemname.Text;
            VariablesGlobales.glb_Receta = nDocEntry;
            VariablesGlobales.glb_DocEntry = 0;

            frmOrdenFabricacion f2 = new frmOrdenFabricacion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Receta = 0;

        }
    
    }




}
