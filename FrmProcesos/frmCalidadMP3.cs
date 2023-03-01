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
    public partial class frmCalidadMP3 : Form
    {
        public frmCalidadMP3()
        {
            InitializeComponent();
        }

        private void frmCalidadMP3_Load(object sender, EventArgs e)
        {

            string cItemCode;

            cItemCode = VariablesGlobales.glb_ItemCode;

            t_itemcode_d.Text = cItemCode;
            t_itemname_d.Clear();

            clsProductos objproducto = new clsProductos();
            objproducto.cls_consultar_Producto_x_codigo(cItemCode);

            DataTable dTable = new DataTable();

            dTable = objproducto.cResultado;

            try
            {
                t_itemname_d.Text = dTable.Rows[0]["ItemName"].ToString();

            }
            catch
            {
                t_itemname_d.Clear();
            }

            try
            {
                t_tipofruta.Text = dTable.Rows[0]["U_TipoProducto"].ToString();
            }
            catch
            {
                t_tipofruta.Clear();
            }


            ////////////////////////////////////////////////////7
            //// Cargo el detalle asociado al producto
            ////

            string cMuestra, cDestruir, cComments;
            double nCantMuestra, nCantDestruir;

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_Atributos_por_producto(cItemCode,"%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            try
            {
                cItemCode = dTable2.Rows[0]["ItemCode"].ToString();

            }
            catch
            {
                cItemCode = "";

            }

            try
            {
                cMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();

            }
            catch
            {
                cMuestra = "";

            }

            try
            {
                cDestruir = dTable2.Rows[0]["U_MuestDes"].ToString();

            }
            catch
            {
                cDestruir = "";

            }

            try
            {
                cComments = dTable2.Rows[0]["U_Comment"].ToString();

            }
            catch
            {
                cComments = "";

            }

            try
            {
                nCantMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());

            }
            catch
            {
                nCantMuestra = 0;

            }

            try
            {
                nCantMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nCantMuestra = 0;
            }

            try
            {
                nCantDestruir = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());

            }
            catch
            {
                nCantDestruir = 0;

            }

            chk_contramuestra.Checked = false;

            if (cMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            t_cant_contra_muestra.Text = nCantMuestra.ToString("N2");

            if (cDestruir=="Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nCantDestruir.ToString("N2");

            t_observacion.Text = cComments;

            string cLineId_D;
            string cCode_D, cNomAtributo_D, cUM_D;
            double nDesde_D, nHasta_D, nStandar_D;
            int nFilas;

            nFilas = 0;

            try
            {
                nFilas = dTable2.Rows.Count;
            }
            catch
            {
                nFilas = 0;
            }

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[9];

            if (nFilas>0)
            {
                for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
                {
                    cCode_D = "";
                    cNomAtributo_D = "";
                    cUM_D = "";
                    nStandar_D = 0;
                    nDesde_D = 0;
                    nHasta_D = 0;
                    cLineId_D = "";

                    try
                    {
                        cLineId_D = dTable2.Rows[i]["LineId"].ToString();

                    }
                    catch
                    {
                        cLineId_D = "";

                    }

                    try
                    {
                        cCode_D = dTable2.Rows[i]["U_CodAtr"].ToString();

                    }
                    catch
                    {
                        cCode_D = "";

                    }

                    try
                    {
                        cNomAtributo_D = dTable2.Rows[i]["U_NameAtr"].ToString();

                    }
                    catch
                    {
                        cNomAtributo_D = "";

                    }

                    try
                    {
                        cUM_D = dTable2.Rows[i]["U_UM"].ToString();

                    }
                    catch
                    {
                        cUM_D = "";

                    }

                    try
                    {
                        nStandar_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                    }
                    catch
                    {
                        nStandar_D = 0;
                    }

                    try
                    {
                        nDesde_D = Convert.ToDouble(dTable2.Rows[i]["U_Minimo"].ToString());

                    }
                    catch
                    {
                        nDesde_D = 0;
                    }

                    try
                    {
                        nHasta_D = Convert.ToDouble(dTable2.Rows[i]["U_Maximo"].ToString());

                    }
                    catch
                    {
                        nHasta_D = 0;
                    }


                    grilla[0] = cLineId_D.ToString();
                    grilla[1] = cCode_D.ToString();
                    grilla[2] = cNomAtributo_D.ToString();
                    grilla[3] = cUM_D.ToUpper();
                    grilla[4] = nStandar_D.ToString("N2");
                    grilla[5] = nDesde_D.ToString("N2");
                    grilla[6] = nHasta_D.ToString("N2");

                    Grid1.Rows.Add(grilla);

                }

            }

            if (Grid1.RowCount > 1)
            {
                btn_trae_matriz.Enabled = false;

            }
            else
            {
                btn_trae_matriz.Enabled = true;

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            string cItemCode, cItemName, cMuestra;
            string cDestructiva, cComment;
            double nCantMuestra, nCantDestructiva;

            cItemCode = t_itemcode_d.Text;
            cItemName = t_itemname_d.Text;
            cComment = t_observacion.Text;

            cMuestra = "N";
            cDestructiva = "N";

            nCantMuestra = 0;
            nCantDestructiva = 0;

            if (chk_contramuestra.Checked == true)
            {
                cMuestra = "Y";

            }

            cDestructiva = "N";

            if (chk_destructiva.Checked == true)
            {
                cDestructiva = "Y";

            }

            try
            {
                nCantMuestra = Convert.ToDouble(t_cant_contra_muestra.Text);

            }
            catch
            {
                nCantMuestra = 0;

            }

            try
            {
                nCantDestructiva = Convert.ToDouble(t_cant_muestra_destructiva.Text);

            }
            catch
            {
                nCantDestructiva = 0;

            }

            if (cMuestra == "N")
            {
               if (nCantMuestra > 0)
                {
                    MessageBox.Show("Debe seleccionar Contra Muestra para registrar Cantidades, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            if (cMuestra == "Y")
            {
                if (nCantMuestra == 0)
                {
                    MessageBox.Show("Debe registrar Cantidades si desea seleccionar Contra Muestra, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            if (cDestructiva == "N")
            {
                if (nCantDestructiva > 0)
                {
                    MessageBox.Show("Debe seleccionar Muestra Destructiva para registrar Cantidades, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            if (cDestructiva == "Y")
            {
                if (nCantDestructiva == 0)
                {
                    MessageBox.Show("Debe registrar Cantidades si desea seleccionar Muestra Destructiva, opción Cancelada", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            string UserCode;
            int UserId;

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            String mensaje = clsCalidad.SAPB1_OATRP(cItemCode, cItemName, cMuestra,  nCantMuestra , cDestructiva, nCantDestructiva, cComment, UserCode, UserId);

            string cCodAtr, cNomAtr, cComments;
            double nStandard, nMinimo, nMaximo; 

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                cCodAtr = "";
                cNomAtr = "";
                nStandard = 0;
                nMinimo = 0;
                nMaximo = 0;

                cCodAtr = Grid1[1, i].Value.ToString();
                cNomAtr = Grid1[2, i].Value.ToString();

                try
                {
                    nStandard = Convert.ToDouble(Grid1[4, i].Value.ToString());

                }
                catch
                {
                    nStandard = 0;

                }

                try
                {
                    nMinimo = Convert.ToDouble(Grid1[5, i].Value.ToString());

                }
                catch
                {
                    nMinimo = 0;

                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid1[6, i].Value.ToString());

                }
                catch
                {
                    nMaximo = 0;

                }

                cComments = "";

                if (cCodAtr.Trim() != "")
                {

                    if (cNomAtr.Trim() != "")
                    {

                        mensaje = clsCalidad.SAPB1_ATRP1(cItemCode, cCodAtr, cNomAtr , nStandard , nMinimo , nMaximo , cComments);

                    }

                }

            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_trae_matriz_Click(object sender, EventArgs e)
        {

            string cTipoFruta;

            cTipoFruta = "";

            try
            {
                cTipoFruta = t_tipofruta.Text;

            }
            catch
            {
                cTipoFruta = "";
            }

            if (cTipoFruta == "n/a")
            {
                MessageBox.Show("El tipo de fruta no permite realizar esta actividad", "Atributos por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cTipoFruta = "";
            }

            if (cTipoFruta=="")
            {
                return;
            }

                ////////////////////////////////////////////////////7
                //// Cargo el detalle asociado al producto
                ////

            string cLineId_D;
            string cCode_D, cNomAtributo_D, cUM_D;
            double nDesde_D, nHasta_D;

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_Atributos_en_Blanco(cTipoFruta);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[9];

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                cUM_D = "";
                nDesde_D = 0;
                nHasta_D = 0;
                cLineId_D = "";

                // ,  ,  , 0 as Minimo , 0 as Maximo

                try
                {
                    cLineId_D = "0";

                }
                catch
                {
                    cLineId_D = "";

                }

                try
                {
                    cCode_D = dTable2.Rows[i]["Code"].ToString();

                }
                catch
                {
                    cCode_D = "";

                }

                try
                {
                    cNomAtributo_D = dTable2.Rows[i]["U_NameAtr"].ToString();

                }
                catch
                {
                    cNomAtributo_D = "";

                }

                try
                {
                    cUM_D = dTable2.Rows[i]["U_UM"].ToString();

                }
                catch
                {
                    cUM_D = "";

                }

                nDesde_D = 0;
                nHasta_D = 0;

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nDesde_D.ToString("N2");
                grilla[5] = nHasta_D.ToString("N2");
                grilla[6] = 0.ToString("N2");

                Grid1.Rows.Add(grilla);

            }

            t_cant_contra_muestra.Text = 0.ToString("N2");
            t_cant_muestra_destructiva.Text = 0.ToString("N2");

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fila;
            string cCodeAtr;

            fila = 0;
            cCodeAtr = "";

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                cCodeAtr = Grid1[1, fila].Value.ToString();

            }
            catch
            {
                cCodeAtr = "";

            }

            if (cCodeAtr == "")
            {
                MessageBox.Show("Debe seleccionar un ítem válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nMinimo, nMaximo, nStandard;

            nStandard = 0;
            nMinimo = 0;
            nMaximo = 0;

            try
            {
                nStandard = Convert.ToDouble(Grid1[4, fila].Value.ToString());

            }
            catch
            {
                nStandard = 0;

            }

            try
            {
                nMinimo = Convert.ToDouble(Grid1[5, fila].Value.ToString());

            }
            catch
            {
                nMinimo = -1;

            }

            try
            {
                nMaximo = Convert.ToDouble(Grid1[6, fila].Value.ToString());

            }
            catch
            {
                nMaximo = -1;

            }


            Grid1[4, fila].Value = nStandard.ToString("N2");
            Grid1[5, fila].Value = nMinimo.ToString("N2");
            Grid1[6, fila].Value = nMaximo.ToString("N2");


        }

        private void t_cant_contra_muestra_Leave(object sender, EventArgs e)
        {
            double cantidad;

            try
            {
                cantidad = Convert.ToDouble(t_cant_contra_muestra.Text);

            }
            catch
            {
                cantidad = 0;

            }

            t_cant_contra_muestra.Text = cantidad.ToString("N2");

        }

        private void t_cant_muestra_destructiva_Leave(object sender, EventArgs e)
        {

            double cantidad;

            try
            {
                cantidad = Convert.ToDouble(t_cant_muestra_destructiva.Text);

            }
            catch
            {
                cantidad = 0;

            }

            t_cant_muestra_destructiva.Text = cantidad.ToString("N2");

        }

    }

}
