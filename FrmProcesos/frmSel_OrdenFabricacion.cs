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
    public partial class frmSel_OrdenFabricacion : Form
    {

        string xGeneral = "";

        public frmSel_OrdenFabricacion()
        {
            InitializeComponent();
        }

        private void frmSel_OrdenFabricacion_Load(object sender, EventArgs e)
        {
            xGeneral = "";

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.Cls_ConsultaLista_TipoFruta1();

            cbb_planta.DataSource = objproducto1.cResultado;
            cbb_planta.ValueMember = "Code";
            cbb_planta.DisplayMember = "Code";
            cbb_planta.SelectedIndex = 5;

            clsProduccion objproducto2 = new clsProduccion();
            objproducto2.Cls_ConsultaLista_TipoFruta2("%");

            cbb_proceso.DataSource = objproducto2.cResultado;
            cbb_proceso.ValueMember = "U_Code";
            cbb_proceso.DisplayMember = "U_Code";
            cbb_proceso.SelectedIndex = 0;

            xGeneral = "X";

            try
            {
                carga_grilla();

            }
            catch
            {

            }

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            int fila;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            int nDocEntry;

            VariablesGlobales.glb_DocEntry = 0;

            try
            {
                nDocEntry = int.Parse(dataGridView1[0, fila].Value.ToString());
            }
            catch
            {
                nDocEntry = 0;
            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            Close();


        }

        private void carga_grilla()
        {
            if (xGeneral == "X" )
            {

                string cCode;

                try
                {
                    cCode = cbb_planta.SelectedValue.ToString();
                }
                catch
                {
                    cCode = "Todo Proceso";
                }

                if ((cCode == "Todo Proceso") || (cCode == "System.Data.DataRowView"))
                {
                    cCode = "%";
                }

                string cCode1;

                try
                {
                    cCode1 = cbb_proceso.SelectedValue.ToString();
                }
                catch
                {
                    cCode1 = " Todo Proceso";
                }

                if ((cCode1 == " Todo Proceso") || (cCode1 == "System.Data.DataRowView"))
                {
                    cCode1 = "%";
                }

                try
                {
                    this.Dock = DockStyle.Fill;

                    clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                    objproducto.cls_Consultar_Lista_de_OrdenFabricacion(VariablesGlobales.glb_Referencia1, cCode, cCode1);

                    this.dataGridView1.DataSource = objproducto.cResultado;
                    this.dataGridView1.RowHeadersWidth = 10;
                    this.dataGridView1.Columns[0].HeaderText = "Num. Orden"; // DocEntry
                    this.dataGridView1.Columns[0].Width = 90;
                    this.dataGridView1.Columns[1].Visible = false; // DocNum
                    this.dataGridView1.Columns[2].HeaderText = "Fecha Orden"; // DocEntry
                    this.dataGridView1.Columns[2].Width = 110;
                    this.dataGridView1.Columns[2].Visible = true; // PostDate
                    this.dataGridView1.Columns[3].HeaderText = "Fecha Inicio"; // DocEntry
                    this.dataGridView1.Columns[3].Width = 110;
                    this.dataGridView1.Columns[3].Visible = true; // StartDate
                    this.dataGridView1.Columns[4].HeaderText = "Fecha Finalizacion"; // DocEntry
                    this.dataGridView1.Columns[4].Width = 110;
                    this.dataGridView1.Columns[4].Visible = true; // DueDate
                    this.dataGridView1.Columns[5].HeaderText = "Num. Articulo"; // DocEntry
                    this.dataGridView1.Columns[5].Width = 260;
                    this.dataGridView1.Columns[5].Visible = true; // ItemCode
                    this.dataGridView1.Columns[6].HeaderText = "Articulo"; // DocEntry
                    this.dataGridView1.Columns[6].Width = 300;
                    this.dataGridView1.Columns[6].Visible = true; // ItemName
                    this.dataGridView1.Columns[7].Visible = false; // InvntryUom
                    this.dataGridView1.Columns[8].Visible = false; // UserSign
                    this.dataGridView1.Columns[9].HeaderText = "Almacen";
                    this.dataGridView1.Columns[9].Width = 80;
                    this.dataGridView1.Columns[9].Visible = true; // Warehouse
                    this.dataGridView1.Columns[10].Visible = false; // PlannedQty
                    this.dataGridView1.Columns[11].Visible = false; // OriginNum
                    this.dataGridView1.Columns[12].Visible = false; // CardCode
                    this.dataGridView1.Columns[13].Visible = false; // Project
                    this.dataGridView1.Columns[14].Visible = false; // Comments
                    this.dataGridView1.Columns[15].HeaderText = "Responsable";
                    this.dataGridView1.Columns[15].Width = 130;
                    this.dataGridView1.Columns[15].Visible = true; // NomResponsable
                                                                   //this.dataGridView1.Columns[16].Visible = false; // 
                                                                   //this.dataGridView1.Columns[17].Visible = false; // 

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;

            Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_seleccionar_Click(sender, e);

        }

        private void cbb_planta_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (xGeneral == "X")
            {

                string cCode;

                try
                {
                    cCode = cbb_planta.SelectedValue.ToString();
                }
                catch
                {
                    cCode = "Todo Proceso";
                }

                if ((cCode == "Todo Proceso") || (cCode == "System.Data.DataRowView"))
                {
                    cCode = "%";
                }

                clsProduccion objproducto1 = new clsProduccion();
                objproducto1.Cls_ConsultaLista_TipoFruta2(cCode);

                cbb_proceso.DataSource = objproducto1.cResultado;
                cbb_proceso.ValueMember = "U_Code";
                cbb_proceso.DisplayMember = "U_Code";
                cbb_proceso.SelectedIndex = 0;

                try
                {
                    carga_grilla();

                }
                catch
                {

                }

            }

        }

        private void cbb_proceso_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                carga_grilla();

            }
            catch
            {

            }

        }

    }

}
