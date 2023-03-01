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
    public partial class frmCalidadPPB7 : Form
    {
        public frmCalidadPPB7()
        {
            InitializeComponent();
        }

        private void frmCalidadPPB7_Load(object sender, EventArgs e)
        {
            t_num_guia.Text = VariablesGlobales.glb_DocEntry.ToString();

            t_G3v1.Text = "4";
            t_G3v2.Text = "2";
            t_G3v3.Text = "2";

            t_G4v1.Text = "130";
            t_G4v2.Text = "< 10";
            t_G4v3.Text = "< 10";
            t_G4v4.Text = "< 10";
            t_G4v5.Text = "< 10";
            t_G4v6.Text = ".";

            t_G4v7.Text = "";
            t_G4v8.Text = "";
            t_G4v9.Text = "";
            t_G4v10.Text = "";
            t_G4v11.Text = "";
            t_G4v12.Text = "";
            t_G4v13.Text = "";

            cbb_G5v1.SelectedIndex = 0;
            cbb_G5v2.SelectedIndex = 0;
            cbb_G5v3.SelectedIndex = 0;
            cbb_G5v4.SelectedIndex = 0;
            t_G5v5.Text = "This product should be stored in a clean, fresh and dry area, away from strong odors and contaminating products";

            string cDocNum;

            clsCalidad objproducto = new clsCalidad();

            objproducto.cls_Consulta_OCERNV(t_num_guia.Text, VariablesGlobales.glb_ItemCode);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cDocNum = dTable.Rows[0]["U_DocNum"].ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                t_code.Text = dTable.Rows[0]["Code"].ToString();
            }
            catch
            {
                t_code .Text = "";
            }

            if (cDocNum == "")
            {
                btn_grabar_Click(sender, e);

            }

            Carga_valores();

        }

        private void Carga_valores()
        {

            clsCalidad objproducto = new clsCalidad();

            objproducto.cls_Consulta_OCERNV(t_num_guia.Text, VariablesGlobales.glb_ItemCode);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_G3v1.Text = dTable.Rows[0]["U_G3V1"].ToString();
            }
            catch
            {
                t_G3v1.Text = "4";
            }

            try
            {
                t_G3v2.Text = dTable.Rows[0]["U_G3V2"].ToString();
            }
            catch
            {
                t_G3v2.Text = "2";
            }

            try
            {
                t_G3v3.Text = dTable.Rows[0]["U_G3V3"].ToString();
            }
            catch
            {
                t_G3v3.Text = "2";
            }

            try
            {
                t_G4v1.Text = dTable.Rows[0]["U_G4V1"].ToString();
            }
            catch
            {
                t_G4v1.Text = "130";
            }

            try
            {
                t_G4v2.Text = dTable.Rows[0]["U_G4V2"].ToString();
            }
            catch
            {
                t_G4v2.Text = "< 10";
            }

            try
            {
                t_G4v3.Text = dTable.Rows[0]["U_G4V3"].ToString();
            }
            catch
            {
                t_G4v3.Text = "< 10";
            }

            try
            {
                t_G4v4.Text = dTable.Rows[0]["U_G4V4"].ToString();
            }
            catch
            {
                t_G4v4.Text = "< 10";
            }

            try
            {
                t_G4v5.Text = dTable.Rows[0]["U_G4V5"].ToString();
            }
            catch
            {
                t_G4v5.Text = "< 10";
            }

            try
            {
                t_G4v6.Text = dTable.Rows[0]["U_G4V6"].ToString();
            }
            catch
            {
                t_G4v6.Text = "";
            }

            try
            {
                t_G4v7.Text = dTable.Rows[0]["U_G4V7"].ToString();
            }
            catch
            {
                t_G4v7.Text = "";
            }

            try
            {
                t_G4v8.Text = dTable.Rows[0]["U_G4V8"].ToString();
            }
            catch
            {
                t_G4v8.Text = "";
            }

            try
            {
                t_G4v9.Text = dTable.Rows[0]["U_G4V9"].ToString();
            }
            catch
            {
                t_G4v9.Text = "";
            }

            try
            {
                t_G4v10.Text = dTable.Rows[0]["U_G4V10"].ToString();
            }
            catch
            {
                t_G4v10.Text = "";
            }

            try
            {
                t_G4v11.Text = dTable.Rows[0]["U_G4V11"].ToString();
            }
            catch
            {
                t_G4v11.Text = "";
            }

            try
            {
                t_G4v12.Text = dTable.Rows[0]["U_G4V12"].ToString();
            }
            catch
            {
                t_G4v12.Text = "";
            }

            try
            {
                t_G4v13.Text = dTable.Rows[0]["U_G4V13"].ToString();
            }
            catch
            {
                t_G4v13.Text = "";
            }

            string cG5v1, cG5v2, cG5v3, cG5v4;

            try
            {
                cG5v1 = dTable.Rows[0]["U_G5V1"].ToString();
            }
            catch
            {
                cG5v1 = "";
            }

            if (cG5v1 != "")
            {
                for (int i = 0; i <= cbb_G5v1.Items.Count - 1; i++)
                {
                    cbb_G5v1.SelectedIndex = i;

                    if (cbb_G5v1.Text == cG5v1)
                    {
                        break;
                    }

                }

            }

            try
            {
                cG5v2 = dTable.Rows[0]["U_G5V2"].ToString();
            }
            catch
            {
                cG5v2 = "";
            }

            if (cG5v2 != "")
            {
                for (int i = 0; i <= cbb_G5v2.Items.Count - 1; i++)
                {
                    cbb_G5v2.SelectedIndex = i;

                    if (cbb_G5v2.Text == cG5v2)
                    {
                        break;
                    }

                }

            }

            try
            {
                cG5v3 = dTable.Rows[0]["U_G5V3"].ToString();
            }
            catch
            {
                cG5v3 = "";
            }

            if (cG5v3 != "")
            {
                for (int i = 0; i <= cbb_G5v3.Items.Count - 1; i++)
                {
                    cbb_G5v3.SelectedIndex = i;

                    if (cbb_G5v3.Text == cG5v3)
                    {
                        break;
                    }

                }

            }

            try
            {
                cG5v4 = dTable.Rows[0]["U_G5V4"].ToString();
            }
            catch
            {
                cG5v4 = "";
            }

            if (cG5v4 != "")
            {
                for (int i = 0; i <= cbb_G5v4.Items.Count - 1; i++)
                {
                    cbb_G5v4.SelectedIndex = i;

                    if (cbb_G5v4.Text == cG5v4)
                    {
                        break;
                    }

                }

            }






        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {

            string mensaje = "";

            if (t_code.Text == "")
            {
                Graba_1er_registro();

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_Consulta_OCERNV(t_num_guia.Text, VariablesGlobales.glb_ItemCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_code.Text = dTable.Rows[0]["Code"].ToString();
                }
                catch
                {
                    t_code.Text = "";
                }

            }

            if (cbb_G5v1.SelectedIndex <0)
            {
                MessageBox.Show("Debe seleccionar un valor válido, opción Cancelada", "Certificado de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_G5v2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un valor válido, opción Cancelada", "Certificado de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_G5v3.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un valor válido, opción Cancelada", "Certificado de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbb_G5v4.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un valor válido, opción Cancelada", "Certificado de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_code.Text != "")
            {

                try
                {
                    mensaje = clsCalidad.SAPB1_Actualizar_OCERNV(t_code.Text, t_num_guia.Text, VariablesGlobales.glb_ItemCode, t_G3v1.Text , t_G3v2.Text , t_G3v3.Text, t_G4v1.Text, t_G4v2.Text, t_G4v3.Text, t_G4v4.Text, t_G4v5.Text, t_G4v6.Text, t_G4v7.Text, t_G4v8.Text, t_G4v9.Text, t_G4v10.Text, t_G4v11.Text, t_G4v12.Text, t_G4v13.Text, cbb_G5v1.Text, cbb_G5v2.Text, cbb_G5v3.Text, cbb_G5v4.Text, t_G5v5.Text);
                }
                catch
                {
                    MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

        }

        private void Graba_1er_registro()            
        {
                
            string mensaje = "";
                
            if (t_code.Text == "")
                
            {
                    
                int nCode;

                    clsCalidad objproducto = new clsCalidad();

                    objproducto.cls_Consulta_max_OCERNV();

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    try
                    {
                        nCode = Convert.ToInt32(dTable.Rows[0]["Code"].ToString());
                    }
                    catch
                    {
                        nCode = 0;
                    }

                    nCode += 1;

                    try
                    {
                        mensaje = clsCalidad.SAPB1_Agregar_OCERNV(nCode.ToString(), t_num_guia.Text, VariablesGlobales.glb_ItemCode);
                    }
                    catch
                    {
                        MessageBox.Show("Error de conexión, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsCalidad objproducto1 = new clsCalidad();

                    objproducto1.cls_Consulta_OCERNV(t_num_guia.Text, VariablesGlobales.glb_ItemCode);

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto1.cResultado;

                    try
                    {
                        t_code.Text = dTable1.Rows[0]["Code"].ToString();
                    }
                    catch
                    {
                        t_code.Text = "";
                    }

                }
        
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                if (VariablesGlobales.glb_tipo_fruta == "Almendra")
                {

                    frmCalidadPPB8 f2 = new frmCalidadPPB8();
                    DialogResult res = f2.ShowDialog();

                }

                if (VariablesGlobales.glb_tipo_fruta == "Nuez")
                {

                    if (VariablesGlobales.glb_tipo_proceso != "Con Cáscara")
                    {

                        frmCalidadPPB9 f2 = new frmCalidadPPB9();
                        DialogResult res = f2.ShowDialog();

                    }
                    else
                    {

                        frmCalidadPPC1 f2 = new frmCalidadPPC1();
                        DialogResult res = f2.ShowDialog();

                    }

                }

            }

        }

    }

}
