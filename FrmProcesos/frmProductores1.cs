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
    public partial class frmProductores1 : Form
    {
        public frmProductores1()
        {
            InitializeComponent();
        }

        private void frmProductores1_Load(object sender, EventArgs e)
        {

            t_cardcode.Text = VariablesGlobales.glb_CardCode;
            t_cardname.Text = VariablesGlobales.glb_CardName;
            t_encargado.Text = VariablesGlobales.glb_Referencia1;
            
            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_Consultar_Variedades();

            cbb_variedad.DataSource = objproducto.cResultado;
            cbb_variedad.ValueMember = "Code";
            cbb_variedad.DisplayMember = "Name";

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_TipoContrato();

            cbb_tipocontrato.DataSource = objproducto1.cResultado;
            cbb_tipocontrato.ValueMember = "FldValue";
            cbb_tipocontrato.DisplayMember = "Descr";

            cbb_cosecha.SelectedIndex = 0;
            cbb_variedad.Text = "";
            cbb_tipocontrato.Text = "";


        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos f2 = new frmSel_Productos();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode != "")
            {
                t_itemcode.Text = VariablesGlobales.glb_ItemCode;
                t_itemname.Text = VariablesGlobales.glb_ItemName;

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_recibir_Click(object sender, EventArgs e)
        {
            int nCosecha;
            float nHas_Total, nHas_Produccion, nKg_Potenciales;
            float nKg_Oportunidad, nKg_Presupuesto;
            string cCardCode, cItemCode, cVariedad;
            string cTipoContrato;

            try
            {
                cCardCode = t_cardcode.Text;
            }
            catch
            {
                cCardCode = "";
            }

            try
            {
                nCosecha = int.Parse(cbb_cosecha.Text);
            }
            catch
            {
                nCosecha = 0;
            }

            try
            {
                nHas_Total = float.Parse(t_has_total.Text);
            }
            catch
            {
                nHas_Total = 0;
            }

            try
            {
                nHas_Produccion = float.Parse(t_has_produccion.Text);
            }
            catch
            {
                nHas_Produccion = 0;
            }

            try
            {
                nKg_Potenciales = float.Parse(t_kg_potenciales.Text);
            }
            catch
            {
                nKg_Potenciales = 0;
            }

            try
            {
                nKg_Oportunidad = float.Parse(t_kg_oportunidad.Text);
            }
            catch
            {
                nKg_Oportunidad = 0;
            }

            try
            {
                nKg_Presupuesto = float.Parse(t_kg_presupuesto.Text);
            }
            catch
            {
                nKg_Presupuesto = 0;
            }

            try
            {
                cItemCode = t_itemcode.Text;
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cVariedad = cbb_variedad.Text;
            }
            catch
            {
                cVariedad = "";
            }

            try
            {
                cTipoContrato = cbb_tipocontrato.SelectedValue.ToString();
            }
            catch
            {
                cTipoContrato = "0";
            }

            string mensaje = clsMaestros.SAPB1_OCRP(nCosecha, cCardCode, cItemCode, cVariedad, nHas_Total, nHas_Produccion, nKg_Potenciales, nKg_Oportunidad, nKg_Presupuesto, cTipoContrato, "", "");


        }

    }

}
