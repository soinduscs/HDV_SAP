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
    public partial class frmCalidadPP : Form
    {
        public frmCalidadPP()
        {
            InitializeComponent();
        }

        private void frmCalidadPP_Load(object sender, EventArgs e)
        {

            btn_aprobar.Visible = false;
            btn_rechazar.Visible = false;
            btn_nuevo_reg.Visible = false;

            btn_imprimir.Visible = false;

            if (VariablesGlobales.glb_id_calidad == 0)
            {
                t_id_calidad.Text = "0";
                t_object.Text = VariablesGlobales.glb_Object;
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_lote.Text = VariablesGlobales.glb_Lote.ToString();

                carga_datos_produccion();

            }
            else
            {

                t_id_calidad.Text = VariablesGlobales.glb_id_calidad.ToString();
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_object.Text = VariablesGlobales.glb_Object;

                carga_datos_calidad();

                //if (t_object.Text == "100100")
                //{

                //    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                //    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                //    carga_datos_cabecera_romana();

                //    btn_dividir_registro.Visible = true;

                //}

                //if (t_object.Text == "100500")
                //{

                //    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                //    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                //    carga_datos_cabecera_mp();

                //    btn_dividir_registro.Visible = true;

                //}



            }

        }

        private void carga_datos_produccion()
        {

            DateTime dt;

            dt = DateTime.Now;

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy HH:mm");

            ///////////////////////////////////////////////////////

            int DocEntry, LineId;
            double nQuantity;

            try
            {
                DocEntry = int.Parse(t_id_recepcion.Text);
            }
            catch
            {
                DocEntry = 0;
            }

            try
            {
                LineId = int.Parse(t_lineid.Text);
            }
            catch
            {
                LineId = 0;
            }

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Avance_x_id(DocEntry, LineId, t_lote.Text,"59");

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_itemcode_d.Text = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                t_itemcode_d.Clear();
            }

            try
            {
               t_itemname_d.Text = dTable.Rows[0]["Dscription"].ToString();
            }
            catch
            {
                t_itemname_d.Clear();
            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();
            }
            catch
            {
                t_lote.Clear();
            }

            try
            {
                t_NumOF.Text = dTable.Rows[0]["BaseEntry"].ToString();
            }
            catch
            {
                t_NumOF.Clear();
            }

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["WhsCode"].ToString();
            }
            catch
            {
                t_WhsCode.Clear();
            }

            try
            {
                t_tipo_proceso.Text = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                t_tipo_proceso.Clear();
            }

            try
            {
                t_observacion.Text = dTable.Rows[0]["Comments"].ToString();
            }
            catch
            {
                t_observacion.Clear();
            }

            try
            {
                t_cardname_prod.Text = dTable.Rows[0]["U_NOMBPROD"].ToString();
            }
            catch
            {
                t_cardname_prod.Clear();
            }

            try
            {
                t_cardname_cliente.Text = dTable.Rows[0]["U_NOMBCLI"].ToString();
            }
            catch
            {
                t_cardname_cliente.Clear();
            }

            try
            {
                t_pallet.Text = dTable.Rows[0]["U_FolioPallet"].ToString();
            }
            catch
            {
                t_pallet.Clear();
            }

            try
            {
                t_un_medida.Text = dTable.Rows[0]["unitMsr"].ToString();
            }
            catch
            {
                t_un_medida.Clear();
            }

            try
            {
                nQuantity = Convert.ToDouble(dTable.Rows[0]["Quantity"].ToString());
            }
            catch
            {
                nQuantity = 0;
            }

            t_cant_prod.Text = nQuantity.ToString("N2");

            t_resultado.Text = "En Proceso";

            string cCode_D, cNomAtributo_D , cUM_D;
            string cLineId_D, cGrupoAtr_D, cGrupoAtr_old_D;

            int nStandAtr_D, nDesde_D, nHasta_D;

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_Atributos_PP_producto(t_tipo_proceso.Text);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid1.Rows.Clear();
            Grid3.Rows.Clear();

            string[] grilla;
            grilla = new string[30];
            
            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["U_Comment"].ToString();
            }
            catch
            {
                cGrupoAtr_old_D = "";
            }

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                cUM_D = "";
                nStandAtr_D = 0;
                nDesde_D = 0;
                nHasta_D = 0;
                cLineId_D = "";

                try
                {
                    cLineId_D = dTable2.Rows[i]["DocEntry"].ToString();
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
                    cUM_D = "";
                }
                catch
                {
                    cUM_D = "";
                }

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["U_Comment"].ToString();
                }
                catch
                {
                    cGrupoAtr_D = "";
                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");
                grilla[7] = 0.ToString("N2");
                grilla[9] = cGrupoAtr_D;

                Grid3.Rows.Add(grilla);
                
            }
           
            determino_totales_en_grupos();

            pinto_grupos();

            determino_grupos();

            totalizar_grupos();

        }

        private void determino_totales_en_grupos()
        {

            int nFila;

            double nStandAtr_D, nDesde_D, nHasta_D;
            double nMedicion_D;

            string cGrupoAtr_old_D, cGrupoAtr_D, cCaptionGrupo_D;
            string cError;

            string[] grilla;

            grilla = new string[30];

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = Grid3[9, 0].Value.ToString();
            }
            catch
            {
                cGrupoAtr_old_D = "";
            }

            nFila = 0;

            for (int i = 0; i <= Grid3.RowCount - 1; i++)
            {
                cGrupoAtr_D = "";
                nStandAtr_D = 0;
                nDesde_D = 0;
                nHasta_D = 0;
                nMedicion_D = 0;

                try
                {
                    cGrupoAtr_D = Grid3[9, i].Value.ToString();
                }
                catch
                {
                    cGrupoAtr_D = "";
                }
                
                try
                {
                    nStandAtr_D = Convert.ToDouble(Grid3[4, i].Value.ToString());
                }
                catch
                {
                    nStandAtr_D = 0;
                }

                try
                {
                    nDesde_D = Convert.ToDouble(Grid3[5, i].Value.ToString());
                }
                catch
                {
                    nDesde_D = 0;
                }

                try
                {
                    nHasta_D = Convert.ToDouble(Grid3[6, i].Value.ToString());
                }
                catch
                {
                    nHasta_D = 0;
                }

                try
                {
                    nMedicion_D = Convert.ToDouble(Grid3[7, i].Value.ToString());
                }
                catch
                {
                    nMedicion_D = 0;
                }

                grilla[0] = Grid3[0, i].Value.ToString();
                grilla[1] = Grid3[1, i].Value.ToString();
                grilla[2] = Grid3[2, i].Value.ToString();
                grilla[3] = Grid3[3, i].Value.ToString();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");
                grilla[7] = nMedicion_D.ToString("N2");

                grilla[9] = cGrupoAtr_old_D;

                Grid1.Rows.Add(grilla);

                cError = "";

                if (nMedicion_D < nDesde_D)
                {
                    cError = "S";
                }

                if (nMedicion_D > nHasta_D)
                {
                    cError = "S";
                }

                if (nDesde_D == nHasta_D)
                {
                    cError = "";
                }

                if (nMedicion_D == 0)
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                }
                else
                {
                    if (cError == "S")
                    {
                        Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                    }
                    else
                    {
                        Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                    }

                }

                nFila = nFila + 1;

                try
                {
                    cGrupoAtr_D = Grid3[9, i+1].Value.ToString();
                }
                catch
                {
                    cGrupoAtr_D = "";
                }

                if (cGrupoAtr_old_D != cGrupoAtr_D)
                {
                    grilla[0] = "-1";
                    grilla[1] = "";
                    grilla[2] = "";

                    if (cGrupoAtr_old_D.Trim() != "")
                    {
                        if (cGrupoAtr_old_D.Substring(1, 1) == "_")
                        {
                            grilla[2] = cGrupoAtr_old_D.Substring(2, cGrupoAtr_old_D.Length - 2).ToString();

                        }
                        else
                        {

                            cCaptionGrupo_D = cGrupoAtr_old_D;

                            try
                            {
                                cCaptionGrupo_D = cGrupoAtr_old_D.Substring(0, 8);
                            }
                            catch
                            {

                            }

                            if (cCaptionGrupo_D != "No Total")
                            {
                                grilla[2] = cGrupoAtr_old_D;
                            }
                            else
                            {
                                grilla[2] = "";
                            }

                        }

                    }

                    grilla[3] = "";
                    grilla[4] = "";
                    grilla[5] = "";
                    grilla[6] = "";
                    grilla[7] = "";

                    grilla[9] = cGrupoAtr_old_D;

                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    nFila = nFila + 1;

                }

                cGrupoAtr_old_D = cGrupoAtr_D;

            }

            string cTipoGrupo;

            try
            {
                cTipoGrupo = Grid1[1, 0].Value.ToString().Substring(0, 2);
            }
            catch
            {
                cTipoGrupo = "";
            }

            if (cTipoGrupo == "PP")
            {

                grilla[1] = "";
                grilla[3] = "";
                grilla[4] = "";
                grilla[5] = "";
                grilla[6] = "";
                grilla[7] = 0.ToString("N2");

                /////////////////////////////////
                //// Total de Forma

                grilla[0] = "-1.1";
                grilla[2] = "Total de Forma";
                grilla[9] = "Total de Forma";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Gramos Totales

                grilla[0] = "-1.2";
                grilla[2] = "Gramos Totales";
                grilla[9] = "Gramos Totales";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.3";

                /////////////////////////////////
                //// EL

                grilla[2] = "EL";
                grilla[9] = "EL";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// L

                grilla[2] = "L";
                grilla[9] = "L";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// LA

                grilla[2] = "LA";
                grilla[9] = "LA";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// A

                grilla[2] = "A";
                grilla[9] = "A";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Amarillas Clara

                grilla[2] = "Amarillas Clara";
                grilla[9] = "Amarillas Clara";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Amarillas Oscuras

                grilla[2] = "Amarillas Oscuras";
                grilla[9] = "Amarillas Oscuras";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Color Claro

                grilla[2] = "Color Claro";
                grilla[9] = "Color Claro";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }


            }

            if (cTipoGrupo == "PA")
            {

                grilla[1] = "";
                grilla[3] = "%";
                grilla[4] = "";
                grilla[5] = "";
                grilla[6] = "";
                grilla[7] = 0.ToString("N2");

                grilla[0] = "-1.1";

                /////////////////////////////////
                //// Total Muestra

                grilla[2] = "Total Muestra";
                grilla[9] = "Total Muestra";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.2";

                /////////////////////////////////
                //// Pepa Sana

                grilla[2] = "Pepa Sana";
                grilla[9] = "Pepa Sana";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Pelón Suelto

                grilla[2] = "Pelón Suelto";
                grilla[9] = "Pelón Suelto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Canuto

                grilla[2] = "Canuto";
                grilla[9] = "Canuto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Impurezas

                grilla[2] = "Impurezas";
                grilla[9] = "Impurezas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Gemelas

                grilla[2] = "Gemelas";
                grilla[9] = "Gemelas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// M. Variedad

                grilla[2] = "M. Variedad";
                grilla[9] = "M. Variedad";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Astilladas y Rayadas leve 

                grilla[2] = "Astilladas y Rayadas leve";
                grilla[9] = "Astilladas y Rayadas leve";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Partidas y Rotas 

                grilla[2] = "Partidas y Rotas";
                grilla[9] = "Partidas y Rotas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.3";

                /////////////////////////////////
                //// Astilladas y Rayadas Graves 

                grilla[2] = "Astilladas y Rayadas Graves";
                grilla[9] = "Astilladas y Rayadas Graves";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Goma

                grilla[2] = "Goma";
                grilla[9] = "Goma";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Rugosidad

                grilla[2] = "Rugosidad";
                grilla[9] = "Rugosidad";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Pepa manchada

                grilla[2] = "Pepa manchada";
                grilla[9] = "Pepa manchada";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Fuera de color

                grilla[2] = "Fuera de color";
                grilla[9] = "Fuera de color";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Punto Goma

                grilla[2] = "Punto Goma";
                grilla[9] = "Punto Goma";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Deshidratada

                grilla[2] = "Deshidratada";
                grilla[9] = "Deshidratada";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.4";

                /////////////////////////////////
                //// Total Otros Defectos 

                grilla[2] = "Total Otros Defectos t.";
                grilla[9] = "Total Otros Defectos t.";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.5";

                /////////////////////////////////
                //// Daño por insecto

                grilla[2] = "Daño por insecto";
                grilla[9] = "Daño por insecto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Hongo inactivo

                grilla[2] = "Hongo inactivo";
                grilla[9] = "Hongo inactivo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Hongo activo

                grilla[2] = "Hongo activo";
                grilla[9] = "Hongo activo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Rancidez

                grilla[2] = "Rancidez";
                grilla[9] = "Rancidez";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.6";

                /////////////////////////////////
                //// Total Daños Serios

                grilla[2] = "Total Daños Serios t.";
                grilla[9] = "Total Daños Serios t.";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.7";

                /////////////////////////////////
                //// Total Muestra

                grilla[2] = "Total Muestra t.";
                grilla[9] = "Total Muestra t.";
                
                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

            }

            if (cTipoGrupo == "PB")
            {

                grilla[1] = "";
                grilla[3] = "%";
                grilla[4] = "";
                grilla[5] = "";
                grilla[6] = "";
                grilla[7] = 0.ToString("N2");

                grilla[0] = "-1.1";

                /////////////////////////////////
                //// Total Muestra

                grilla[2] = "Total Muestras";
                grilla[9] = "Total Muestras";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.2";

                /////////////////////////////////
                //// Pepa Sana

                grilla[2] = "Pepa Sana";
                grilla[9] = "Pepa Sana";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Pelón Suelto

                grilla[2] = "Pelón Suelto";
                grilla[9] = "Pelón Suelto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Canuto

                grilla[2] = "Canuto";
                grilla[9] = "Canuto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Impurezas

                grilla[2] = "Impurezas";
                grilla[9] = "Impurezas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Gemelas

                grilla[2] = "Gemelas";
                grilla[9] = "Gemelas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Partidas y Rotas

                grilla[2] = "Partidas y Rotas";
                grilla[9] = "Partidas y Rotas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// M. Variedad

                grilla[2] = "M.Variedad";
                grilla[9] = "M.Variedad";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Astilladas y Rayadas leve 

                grilla[2] = "Astilladas y Rayadas Leve (3, 2 - 6, 4mm)";
                grilla[9] = "Astilladas y Rayadas Leve (3, 2 - 6, 4mm)";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }
               
                grilla[0] = "-1.3";

                /////////////////////////////////
                //// Astilladas y Rayadas Graves 

                grilla[2] = "Astilladas y Rayadas Grave (> 6, 4mm)";
                grilla[9] = "Astilladas y Rayadas Grave (> 6, 4mm)";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Deshidratada Grave

                grilla[2] = "Deshidratada Grave";
                grilla[9] = "Deshidratada Grave";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Deshidratada Leve

                grilla[2] = "Deshidratada Leve";
                grilla[9] = "Deshidratada Leve";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Goma

                grilla[2] = "Goma";
                grilla[9] = "Goma";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Rugosidad

                grilla[2] = "Pto.Goma";
                grilla[9] = "Pto.Goma";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Pepa manchada

                grilla[2] = "Fuera de Color";
                grilla[9] = "Fuera de Color";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Fuera de color

                grilla[2] = "Mancha";
                grilla[9] = "Mancha";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.4";

                /////////////////////////////////
                //// Suma de defectos

                grilla[2] = "Suma de Defectos t.";
                grilla[9] = "Suma de Defectos t.";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.5";

                /////////////////////////////////
                //// Daño insecto

                grilla[2] = "Daño insecto";
                grilla[9] = "Daño insecto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }
               
                /////////////////////////////////
                //// Hongo Inactivo

                grilla[2] = "Hongo Inactivo";
                grilla[9] = "Hongo Inactivo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }
                
                /////////////////////////////////
                //// Hongo Activo

                grilla[2] = "Hongo Activo";
                grilla[9] = "Hongo Activo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Rancidez

                grilla[2] = "Rancidez";
                grilla[9] = "Rancidez";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.6";

                /////////////////////////////////
                //// Suma de defectos serios

                grilla[2] = "Suma de Defectos Serios t.";
                grilla[9] = "Suma de Defectos Serios t.";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.7";

                /////////////////////////////////
                //// Total

                grilla[2] = "Total Muestras t.";
                grilla[9] = "Total Muestras t.";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                

            }


            if (cTipoGrupo == "PC")
            {

                grilla[1] = "";
                grilla[3] = "";
                grilla[4] = "";
                grilla[5] = "";
                grilla[6] = "";
                grilla[7] = 0.ToString("N2");

                grilla[0] = "-1.1";

                /////////////////////////////////
                //// Mitades

                grilla[2] = "Mitades";
                grilla[9] = "Mitades";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Large Pieces

                grilla[2] = "Large Pieces";
                grilla[9] = "Large Pieces";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Medium

                grilla[2] = "Medium";
                grilla[9] = "Medium";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.2";

                /////////////////////////////////
                //// Extra Light

                grilla[2] = "Extra Light";
                grilla[9] = "Extra Light";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Light

                grilla[2] = "Light";
                grilla[9] = "Light";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Light Ambar

                grilla[2] = "Light Ambar";
                grilla[9] = "Light Ambar";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Ambar

                grilla[2] = "Ambar";
                grilla[9] = "Ambar";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Amarillas Claras

                grilla[2] = "Amarillas Claras";
                grilla[9] = "Amarillas Claras";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Amarillas Oscuras

                grilla[2] = "Amarillas Oscuras";
                grilla[9] = "Amarillas Oscuras";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                grilla[0] = "-1.3";

                /////////////////////////////////
                //// Planas

                grilla[2] = "Planas";
                grilla[9] = "Planas";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Mancha

                grilla[2] = "Mancha";
                grilla[9] = "Mancha";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Mancha Anaranjada

                grilla[2] = "Mancha Anaranjada";
                grilla[9] = "Mancha Anaranjada";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Reseca Grave 

                grilla[2] = "Reseca Grave";
                grilla[9] = "Reseca Grave";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Reseca Leve

                grilla[2] = "Reseca Leve";
                grilla[9] = "Reseca Leve";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Daño por Insecto

                grilla[2] = "Daño por Insecto";
                grilla[9] = "Daño por Insecto";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Hongo Activo

                grilla[2] = "Hongo Activo";
                grilla[9] = "Hongo Activo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Hongo Inactivo

                grilla[2] = "Hongo Inactivo";
                grilla[9] = "Hongo Inactivo";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }

                /////////////////////////////////
                //// Rancidez

                grilla[2] = "Rancidez";
                grilla[9] = "Rancidez";

                Grid1.Rows.Add(grilla);

                try
                {
                    Grid1[8, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                }
                catch
                {

                }


            }


        }


        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (t_itemcode_d.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Registro de Inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar una Producto válido, opción Cancelada", "Registro de Inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cItemCode, cItemName, cLote;
            string cObjetc, cWhsCode, cNumCon;

            int nDocEntry, nDocEntryRef, nLineIdRef;

            cItemCode = t_itemcode_d.Text;
            cItemName = t_itemname_d.Text;
            cObjetc = t_object.Text;
            cLote = t_lote.Text;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                nLineIdRef = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                nLineIdRef = 0;
            }

            try
            {
                nDocEntryRef = Convert.ToInt32(t_id_recepcion.Text);
            }
            catch
            {
                nDocEntryRef = 0;
            }

            cWhsCode = t_WhsCode.Text;

            string UserCode, cUM;
            int UserId;
            double nCantidad, nPorcentaje;

            nCantidad = 0;

            try
            {
                nCantidad = Convert.ToDouble(t_cant_prod.Text);

            }
            catch
            {
                nCantidad = 0;

            }

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            cNumCon = "";
            cLote = t_lote.Text;
            cUM = t_un_medida.Text;

            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(t_fecha_ingreso.Text);

            }
            catch
            {
                dt = DateTime.Now;

            }

            String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "", UserId, UserCode, cItemCode, cItemName, cWhsCode, "", cNumCon, cLote, nCantidad, 0, 0, dt.ToString("yyyyMMdd"), cUM, 0, 0, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef,"","",0,"","S","","");

            int nLineId;
            string cCodAtr, cNomAtr, cComments;
            string cComments2;
            double nStandar, nMedicion, nMinimo;
            double nMaximo;

            if (nDocEntry == 0)
            {
                clsCalidad objproducto5 = new clsCalidad();
                objproducto5.cls_Consulta_Nuevo_Registro_Inspeccion();

                DataTable dTable5 = new DataTable();
                dTable5 = objproducto5.cResultado;

                t_doc_entry.Text = dTable5.Rows[0]["DocEntry"].ToString();

                try
                {
                    nDocEntry = Convert.ToInt32(t_doc_entry.Text);
                }
                catch
                {
                    nDocEntry = 0;

                }


            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = 0;
                cCodAtr = "";
                cNomAtr = "";
                nStandar = 0;
                nMinimo = 0;
                nMaximo = 0;
                nMedicion = 0;
                cComments = "";
                cComments2 = "";

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId = 0;
                }


                cCodAtr = Grid1[1, i].Value.ToString();
                cNomAtr = Grid1[2, i].Value.ToString();

                try
                {
                    nStandar = Convert.ToDouble(Grid1[4, i].Value.ToString());

                }
                catch
                {
                    nStandar = 0;

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

                try
                {
                    nMedicion = Convert.ToDouble(Grid1[7, i].Value.ToString());

                }
                catch
                {
                    nMedicion = 0;

                }

                try
                {
                    nPorcentaje = Convert.ToDouble(Grid1[8, i].Value.ToString());

                }
                catch
                {
                    nPorcentaje = 0;

                }
               
                if (cCodAtr.Trim() != "")
                {

                    if (cNomAtr.Trim() != "")
                    {

                        mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "", nPorcentaje);

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

        private void btn_aprobar_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            if (nDocEntry > 0)
            {
                string cItemCode, cItemName, cWhsCode;
                string cWhsDest, cNumCon, cLote;
                string cFecha, cUM, Comments;
                string cObjetc, UserCode;

                double nCantidad, nCoMuSize, nMuDeSize;
                double nBultosMuestrear;

                int nDocEntryRef, nBultos, nLineId_Ref;
                int UserId;

                cItemCode = "";
                cItemName = "";
                cWhsCode = "";
                cWhsDest = "";
                cNumCon = "";
                cLote = "";
                cFecha = "";
                cUM = "";
                Comments = "";
                cObjetc = "";
                nCantidad = 0;
                nBultos = 0;
                nCoMuSize = 0;
                nMuDeSize = 0;
                nDocEntryRef = 0;
                nLineId_Ref = 0;
                nBultosMuestrear = 0;


                UserCode = VariablesGlobales.glb_User_Code;
                UserId = VariablesGlobales.glb_User_id;

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Aprobar el Registro de Inspección", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ////////////////////////////////////////////////
                    /// Grabo el registro de calidad
                    /// 

                    String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "A", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref,"","",0,"","","","");

                    if (mensaje == "Y")
                    {
                        MessageBox.Show("Registro Aprobado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    VariablesGlobales.glb_id_calidad = nDocEntry;
                    VariablesGlobales.glb_id_romana = 0;
                    VariablesGlobales.glb_LineId = int.Parse(t_lineid.Text);
                    VariablesGlobales.glb_Object = t_object.Text;

                    frmCalidadPP_Load(sender, e);

                    //carga_datos_calidad();

                }
            }

        }

        private void btn_rechazar_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            if (nDocEntry > 0)
            {
                string cItemCode, cItemName, cWhsCode;
                string cWhsDest, cNumCon, cLote;
                string cFecha, cUM, Comments;
                string cObjetc;
                double nCantidad, nCoMuSize;
                double nMuDeSize;
                int nDocEntryRef, nBultos, nLineId_Ref;
                double nBultosMuestrear;

                cItemCode = "";
                cItemName = "";
                cWhsCode = "";
                cWhsDest = "";
                cNumCon = "";
                cLote = "";
                cFecha = "";
                cUM = "";
                Comments = "";
                cObjetc = "";
                nCantidad = 0;
                nBultos = 0;
                nCoMuSize = 0;
                nMuDeSize = 0;
                nDocEntryRef = 0;
                nLineId_Ref = 0;
                nBultosMuestrear = 0;

                string UserCode;
                int UserId;

                UserCode = VariablesGlobales.glb_User_Code;
                UserId = VariablesGlobales.glb_User_id;

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Rechazar el Registro de Inspección", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "R", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref,"","",0,"","S","","");

                    if (mensaje == "Y")
                    {
                        MessageBox.Show("Registro Rechazado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    carga_datos_calidad();

                    result = MessageBox.Show("Desea Generar un nuevo Registro de Inspección", "Registro de Inspección ", buttons);
                    
                }
            }

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_id_recepcion.Text);
            }
            catch
            {
                nDocEntry = 0;
            }


            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nDocEntry;

            frmOrdenFabricacionTR1_A f2 = new frmOrdenFabricacionTR1_A();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }

        private void btn_nuevo_reg_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int id_acceso;

            try
            {
                id_acceso = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso > 0)
            {

                VariablesGlobales.glb_id_calidad = id_acceso;

                frmCalidadMPA1 f2 = new frmCalidadMPA1();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_id_calidad = 0;

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pinto_grupos()
        {

            double nLineId;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = 0;

                try
                {
                    nLineId = Convert.ToDouble(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId = -2;
                }

                if (nLineId == -1)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightGray;
                    }

                }

                if (nLineId == -1.1)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightBlue;
                    }

                }

                if (nLineId == -1.2)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightGreen;
                    }

                }

                if (nLineId == -1.3)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightSalmon;
                    }

                }

                if (nLineId == -1.4)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightPink;
                    }

                }

                if (nLineId == -1.5)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightCoral;
                    }

                }

                if (nLineId == -1.6)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightSeaGreen;
                    }

                }

                if (nLineId == -1.7)
                {
                    for (int x = 0; x <= 7; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightSlateGray;
                    }

                }

            }

        }

        private void determino_grupos()
        {
            double nLineId;

            int nAtributo;
            string cAtributo, cAtributoRef;

            string[] atributo1;
            atributo1 = new string[50];

            double[] atributo2;
            atributo2 = new double[50];

            nAtributo = -1;
            cAtributoRef = "";

            /////////////////////////////////////7
            //// Determino los grupos a calcular

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = 0;

                try
                {
                    nLineId = Convert.ToDouble(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId = -2;
                }

                try
                {
                    cAtributo = Grid1[9, i].Value.ToString();
                }
                catch
                {
                    cAtributo = "";
                }

                if (nLineId <= -1)
                {
                    cAtributoRef = "";

                    for (int x = 0; x <= nAtributo; x++)
                    {
                        if (atributo1[x] == cAtributo)
                        {
                            cAtributoRef = cAtributo;
                            break;

                        }

                    }

                    if (cAtributoRef == "")
                    {
                        nAtributo = nAtributo + 1;
                        atributo1[nAtributo] = cAtributo;
                        atributo2[nAtributo] = i;

                    }

                }

            }

            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];


            for (int i = 0; i <= nAtributo; i++)
            {
               
                grilla[0] = atributo1[i];
                grilla[1] = atributo2[i].ToString();

                Grid2.Rows.Add(grilla);

            }
            

        }


        private void totalizar_grupos()
        {
            int nLineId, nAtributo;
            string cAtributo, cAtributoRef;

            string[] atributo1;
            atributo1 = new string[100];

            double[] atributo2;
            atributo2 = new double[100];

            nAtributo = -1;
            cAtributoRef = "";

            string cTipoGrupo;

            try
            {
                cTipoGrupo = Grid1[1, 0].Value.ToString().Substring(0, 2);
            }
            catch
            {
                cTipoGrupo = "";
            }

            /////////////////////////////////////7
            //// Determino los grupos a calcular

            //for (int i = 0; i <= Grid1.RowCount - 1; i++)
            //{
            //    nLineId = 0;

            //    try
            //    {
            //        nLineId = Convert.ToInt32(Grid1[0, i].Value.ToString());
            //    }
            //    catch
            //    {
            //        nLineId = -2;
            //    }

            //    try
            //    {
            //        cAtributo = Grid1[9, i].Value.ToString();
            //    }
            //    catch
            //    {
            //        cAtributo = "";
            //    }

            //    if (nLineId >= 0)
            //    {
            //        cAtributoRef = "";

            //        for (int x = 0; x <= nAtributo; x++)
            //        {
            //            if (atributo1[x] == cAtributo)
            //            {
            //                cAtributoRef = cAtributo;
            //                break;

            //            }

            //        }

            //        if (cAtributoRef == "")
            //        {
            //            nAtributo = nAtributo + 1;
            //            atributo1[nAtributo] = cAtributo;
            //            atributo2[nAtributo] = 0;

            //        }

            //    }

            //}


            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {

                try
                {
                    atributo1[i] = Grid2[0, i].Value.ToString();
                }
                catch
                {
                    atributo1[i] = "";
                }

                atributo2[i] = 0;
                nAtributo = i;

            }

            double nTotal; // nSubTotal, nItems, ;
            double nValor;

            /////////////////////////////////////
            //// Calculo los valores por grupo y los actualizo

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, x].Value.ToString());
                }
                catch
                {
                    nLineId = -2;
                }

                try
                {
                    cAtributoRef = Grid1[9, x].Value.ToString();
                }
                catch
                {
                    cAtributoRef = "";
                }

                try
                {
                    nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                }
                catch
                {
                    nValor = -2;
                }

                if (nLineId >= 0)
                {

                    if (nValor > 0)
                    {

                        for (int i = 0; i <= nAtributo; i++)
                        {

                            cAtributo = "";

                            try
                            {
                                cAtributo = atributo1[i];
                            }
                            catch
                            {
                                cAtributo = "";
                            }


                            if (cAtributoRef == cAtributo)
                            {

                                //nSubTotal = 0;
                                //nItems = 0;
                                //nTotal = 0;
                                //nValor = 0;

                                atributo2[i] += nValor;
                                break;

                            }

                        }

                        //nSubTotal = nSubTotal + nValor;
                        //nItems = nItems + 1;

                    }

                }


            }

            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////
            //// Determino los Totales PA - Seleccion Almendras

            string cAtributo_Ref;

            if (cTipoGrupo == "PA")
            {

                double nPA_TotalMuestra, nPA_TotalOtrosDefectos, nPA_TotalDanosSerios;
                double nPA_TotalUnidades, nPA_TotalMuestasT;

                nPA_TotalMuestra = 0;
                nPA_TotalOtrosDefectos = 0;
                nPA_TotalDanosSerios = 0;
                nPA_TotalUnidades = 0;
                nPA_TotalMuestasT = 0;

                for (int i = 0; i <= nAtributo; i++)
                {

                    try
                    {
                        nTotal = atributo2[i];
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    nPA_TotalMuestra += nTotal;

                }

                nAtributo += 1;

                atributo1[nAtributo] = "Total Muestra";
                atributo2[nAtributo] = nPA_TotalMuestra;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cAtributo = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cAtributo = "";
                    }

                    try
                    {
                        nTotal = Convert.ToDouble(Grid1[7, i].Value.ToString());
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    switch (cAtributo)
                    {
                        case "PA_1_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pepa Sana";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pelón Suelto";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Canuto";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Impurezas";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_007":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Gemelas";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_008":
                            nAtributo += 1;
                            atributo1[nAtributo] = "M. Variedad";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_009":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Astilladas y Rayadas leve";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_1_010":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Partidas y Rotas";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalUnidades += atributo2[nAtributo];
                            break;

                        case "PA_2_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Astilladas y Rayadas Graves";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Goma";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Rugosidad";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pepa manchada";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Fuera de color";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Punto Goma";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_2_007":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Deshidratada";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalOtrosDefectos += atributo2[nAtributo];
                            break;

                        case "PA_3_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Daño por insecto";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalDanosSerios += atributo2[nAtributo];
                            break;
                            
                        case "PA_3_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo inactivo";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalDanosSerios += atributo2[nAtributo];
                            break;

                        case "PA_3_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo activo";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalDanosSerios += atributo2[nAtributo];
                            break;

                        case "PA_3_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Rancidez";

                            if (nPA_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPA_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPA_TotalDanosSerios += atributo2[nAtributo];
                            break;

                    }

                }

                nAtributo += 1;
                atributo1[nAtributo] = "Total Otros Defectos t.";
                atributo2[nAtributo] = nPA_TotalOtrosDefectos;

                nAtributo += 1;
                atributo1[nAtributo] = "Total Daños Serios t.";
                atributo2[nAtributo] = nPA_TotalDanosSerios;

                nPA_TotalMuestasT = nPA_TotalOtrosDefectos + nPA_TotalDanosSerios + nPA_TotalUnidades;

                nAtributo += 1;
                atributo1[nAtributo] = "Total Muestra t.";
                atributo2[nAtributo] = nPA_TotalMuestasT;

            }

            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////
            //// Determino los Totales PB - Cracker

            if (cTipoGrupo == "PB")
            {

                double nPB_TotalMuestra, nPB_TotalSumaMuestras, nPA_TotalSumaDefectos;
                double nPA_TotalSumaDefectosSerios, nPB_TotalUnidades;

                nPB_TotalMuestra = 0;
                nPB_TotalSumaMuestras = 0;
                nPA_TotalSumaDefectos = 0;
                nPA_TotalSumaDefectosSerios = 0;
                nPB_TotalUnidades = 0;

                for (int i = 0; i <= nAtributo; i++)
                {

                    try
                    {
                        nTotal = atributo2[i];
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    nPB_TotalMuestra += nTotal;

                }

                //nAtributo += 1;
                //atributo1[nAtributo] = "Total Muestra";
                //atributo2[nAtributo] = nPB_TotalMuestra;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cAtributo = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cAtributo = "";
                    }

                    try
                    {
                        nTotal = Convert.ToDouble(Grid1[7, i].Value.ToString());
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    switch (cAtributo)
                    {
                        case "PB_1_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pepa Sana";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pelón Suelto";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Canuto";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Impurezas";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_007":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Gemelas";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_008":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Partidas y Rotas";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_009":
                            nAtributo += 1;
                            atributo1[nAtributo] = "M.Variedad";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_1_010":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Astilladas y Rayadas Leve (3, 2 - 6, 4mm)";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPB_TotalSumaMuestras += atributo2[nAtributo];
                            break;

                        case "PB_2_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Astilladas y Rayadas Grave (> 6, 4mm)";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Deshidratada Grave";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Deshidratada Leve";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Goma";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Pto.Goma";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Fuera de Color";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_2_007":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Mancha";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectos += atributo2[nAtributo];
                            break;

                        case "PB_3_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Daño insecto";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectosSerios += atributo2[nAtributo];
                            break;

                        case "PB_3_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo Inactivo";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectosSerios += atributo2[nAtributo];
                            break;

                        case "PB_3_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo Activo";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectosSerios += atributo2[nAtributo];
                            break;

                        case "PB_3_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Rancidez";

                            if (nPB_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPB_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            nPB_TotalUnidades += atributo2[nAtributo];
                            nPA_TotalSumaDefectosSerios += atributo2[nAtributo];
                            break;
                        
                    }

                }

                nAtributo += 1;
                atributo1[nAtributo] = "Total Muestras";
                atributo2[nAtributo] = nPB_TotalMuestra;  

                nAtributo += 1;
                atributo1[nAtributo] = "Suma de Defectos t.";
                atributo2[nAtributo] = nPA_TotalSumaDefectos;

                nAtributo += 1;
                atributo1[nAtributo] = "Suma de Defectos Serios t.";
                atributo2[nAtributo] = nPA_TotalSumaDefectosSerios;

                nAtributo += 1;
                atributo1[nAtributo] = "Total Muestras t.";
                atributo2[nAtributo] = nPB_TotalSumaMuestras + nPA_TotalSumaDefectos + nPA_TotalSumaDefectosSerios;

            }

            if (cTipoGrupo == "PP") //Planilla de Seleccion Almendras
            {
                ///////////////////////////////////////
                //// Determino los Totales A
                
                double nTotaldeForma, nGramosTotales;

                double nPP_EL, nPP_L, nPP_LA;
                double nPP_A, nPP_AmarillasClara, nPP_AmarillasOscuras;
                double nPP_ColorClaro;

                nTotaldeForma = 0;
                nGramosTotales = 0;
               
                for (int i = 0; i <= nAtributo; i++)
                {
                    try
                    {
                        cAtributo_Ref = atributo1[i];
                    }
                    catch
                    {
                        cAtributo_Ref = "";
                    }

                    try
                    {
                        nTotal = atributo2[i];
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    if (cAtributo_Ref == "% de Mitades")
                    {
                        nTotaldeForma += nTotal;
                        nGramosTotales += nTotal;
                    }

                    if (cAtributo_Ref == "% de Cuartos")
                    {
                        nTotaldeForma += nTotal;
                        nGramosTotales += nTotal;
                    }

                    if (cAtributo_Ref == "% de Cuartillos")
                    {
                        nTotaldeForma += nTotal;
                        nGramosTotales += nTotal;
                    }

                    if (cAtributo_Ref == "% Daños")
                    {
                        nGramosTotales += nTotal;
                    }


                }

                nAtributo += 1;

                atributo1[nAtributo] = "Total de Forma";
                atributo2[nAtributo] = nTotaldeForma;

                nAtributo += 1;

                atributo1[nAtributo] = "Gramos Totales";
                atributo2[nAtributo] = nGramosTotales;


                for (int i = 0; i <= nAtributo; i++)
                {
                    try
                    {
                        cAtributo_Ref = atributo1[i];
                    }
                    catch
                    {
                        cAtributo_Ref = "";
                    }

                    try
                    {
                        nTotal = atributo2[i];
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    if ((cAtributo_Ref == "% de Mitades") || (cAtributo_Ref == "% de Cuartos") || (cAtributo_Ref == "% de Cuartillos"))
                    {
                        nValor = 0;

                        if (nTotaldeForma > 0)
                        {
                            nValor = (nTotal / nTotaldeForma) * 100;

                        }

                        atributo2[i] = nValor;
                    }


                    if (cAtributo_Ref == "% Daños")
                    {
                        nValor = 0;

                        if (nGramosTotales > 0)
                        {
                            nValor = (nTotal / nGramosTotales) * 100;

                        }

                        atributo2[i] = nValor;
                    }

                }

                nPP_EL = 0;
                nPP_L = 0;
                nPP_LA = 0;
                nPP_A = 0;
                nPP_AmarillasClara = 0;
                nPP_AmarillasOscuras = 0;
                nPP_ColorClaro = 0;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cAtributo = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cAtributo = "";
                    }

                    try
                    {
                        nTotal = Convert.ToDouble(Grid1[7, i].Value.ToString());
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    switch (cAtributo)
                    {
                        case "PP_1_001":
                            nPP_EL += nTotal;
                            break;

                        case "PP_1_002":
                            nPP_EL += nTotal;
                            break;

                        case "PP_2_001":
                            nPP_EL += nTotal;
                            break;

                        case "PP_3_001":
                            nPP_EL += (nTotal*0.8);
                            nPP_L += (nTotal*0.2);
                            break;

                        case "PP_1_003":
                            nPP_L += nTotal;
                            break;

                        case "PP_2_002":
                            nPP_L += nTotal;
                            break;

                        case "PP_1_004":
                            nPP_LA += nTotal;
                            break;

                        case "PP_2_003":
                            nPP_LA += nTotal;
                            break;

                        case "PP_3_002":
                            nPP_LA += (nTotal * 0.8);
                            nPP_A += (nTotal * 0.2);
                            break;

                        case "PP_1_005":
                            nPP_A += nTotal;
                            break;

                        case "PP_2_004":
                            nPP_A += nTotal;
                            break;

                        case "PP_1_006":
                            nPP_AmarillasClara += nTotal;
                            break;

                        case "PP_2_005":
                            nPP_AmarillasClara += nTotal;
                            break;

                        case "PP_3_003":
                            nPP_AmarillasClara += nTotal;
                            break;

                        case "PP_1_007":
                            nPP_AmarillasOscuras += nTotal;
                            break;

                        case "PP_2_006":
                            nPP_AmarillasOscuras += nTotal;
                            break;

                        case "PP_3_004":
                            nPP_AmarillasOscuras += nTotal;
                            break;
                            
                    }

                }

                nPP_ColorClaro = 0;

                nAtributo += 1;
                atributo1[nAtributo] = "EL";

                if (nTotaldeForma>0)
                    atributo2[nAtributo] = ((nPP_EL) / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nPP_ColorClaro += atributo2[nAtributo];

                nAtributo += 1;
                atributo1[nAtributo] = "L";

                if (nTotaldeForma > 0)
                    atributo2[nAtributo] = ((nPP_L) / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nPP_ColorClaro += atributo2[nAtributo];

                nAtributo += 1;
                atributo1[nAtributo] = "LA";

                if (nTotaldeForma > 0)
                    atributo2[nAtributo] = ((nPP_LA) / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nAtributo += 1;
                atributo1[nAtributo] = "A";

                if (nTotaldeForma > 0)
                    atributo2[nAtributo] = ((nPP_A) / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nAtributo += 1;
                atributo1[nAtributo] = "Amarillas Clara";

                if (nTotaldeForma > 0)
                    atributo2[nAtributo] = (nPP_AmarillasClara / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nPP_ColorClaro += atributo2[nAtributo];

                nAtributo += 1;
                atributo1[nAtributo] = "Amarillas Oscuras";

                if (nTotaldeForma > 0)
                    atributo2[nAtributo] = (nPP_AmarillasOscuras / nTotaldeForma) * 100;
                else
                    atributo2[nAtributo] = 0;

                nAtributo += 1;
                atributo1[nAtributo] = "Color Claro";
                atributo2[nAtributo] = nPP_ColorClaro;


            }

            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////
            //// Determino los Totales PB - Cracker

            if (cTipoGrupo == "PC")
            {

                double nPC_TotalUnidades, nPC_TotalForma, nPC_TotalColor;
                double nPC_TotalMuestra; 

                nPC_TotalUnidades = 0;
                nPC_TotalForma = 0;
                nPC_TotalColor = 0;
                nPC_TotalMuestra = 0;

                for (int i = 0; i <= nAtributo; i++)
                {
                    try
                    {
                        cAtributo_Ref = atributo1[i];
                    }
                    catch
                    {
                        cAtributo_Ref = "";
                    }

                    try
                    {
                        nTotal = atributo2[i];
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    if (cAtributo_Ref == "Total Unidades")
                    {
                        nPC_TotalUnidades += nTotal;
                    }

                    if (cAtributo_Ref == "Total de Forma")
                    {
                        nPC_TotalForma += nTotal;                        
                    }

                    if (cAtributo_Ref == "Total de color")
                    {
                        nPC_TotalColor += nTotal;                        
                    }

                    if (cAtributo_Ref == "Total Muestra")
                    {
                        nPC_TotalMuestra += nTotal;
                    }


                }

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cAtributo = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cAtributo = "";
                    }

                    try
                    {
                        nTotal = Convert.ToDouble(Grid1[7, i].Value.ToString());
                    }
                    catch
                    {
                        nTotal = 0;
                    }

                    switch (cAtributo)
                    {
                      
                        case "PC_2_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Mitades";

                            if (nPC_TotalForma > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalForma) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_2_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Large Pieces";

                            if (nPC_TotalForma > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalForma) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_2_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Medium";

                            if (nPC_TotalForma > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalForma) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_3_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Extra Light";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;


                        case "PC_3_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Light";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_3_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Light Ambar";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_3_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Ambar";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_3_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Amarillas Claras";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_3_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Amarillas Oscuras";

                            if (nPC_TotalColor > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalColor) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_001":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Planas";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_002":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Mancha";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_003":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Mancha Anaranjada";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;
 
                        case "PC_4_004":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Reseca Grave";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_005":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Reseca Leve";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_006":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Daño por Insecto";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_007":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo Activo";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_008":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Hongo Inactivo";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                        case "PC_4_009":
                            nAtributo += 1;
                            atributo1[nAtributo] = "Rancidez";

                            if (nPC_TotalMuestra > 0)
                                atributo2[nAtributo] = (nTotal / nPC_TotalMuestra) * 100;
                            else
                                atributo2[nAtributo] = 0;

                            break;

                    }

                }

                //nAtributo += 1;
                //atributo1[nAtributo] = "Total de Forma";
                //atributo2[nAtributo] = nPC_TotalForma;


            }


            ///////////////////////////////////////
            //// actualizo los valores en la grilla

            for (int i = 0; i <= nAtributo; i++)
            {

                cAtributo = "";
                nTotal = 0;

                try
                {
                    cAtributo = atributo1[i];
                }
                catch
                {
                    cAtributo = "";
                }

                try
                {
                    nTotal = atributo2[i];
                }
                catch
                {
                    nTotal = 0;
                }

                nLineId = 0;

                for (int x = 0; x <= Grid2.RowCount - 1; x++)
                {

                    try
                    {
                        cAtributoRef = Grid2[0, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (cAtributoRef == cAtributo)
                    {
                        try
                        {
                            nLineId = int.Parse(Grid2[1, x].Value.ToString());
                        }
                        catch
                        {
                            nLineId = -1;
                        }

                        break;
                    }

                }

                if (nLineId>=0)
                    Grid1[7, nLineId].Value = nTotal.ToString("N2");

            }


            //for (int x = 0; x <= Grid1.RowCount - 1; x++)
            //{

            //    try
            //    {
            //        nLineId = Convert.ToInt32(Grid1[0, x].Value.ToString());
            //    }
            //    catch
            //    {
            //        nLineId = -2;
            //    }

            //    try
            //    {
            //        cAtributoRef = Grid1[9, x].Value.ToString();
            //    }
            //    catch
            //    {
            //        cAtributoRef = "";
            //    }

            //    if (nLineId < 0)
            //    {

            //        for (int i = 0; i <= nAtributo; i++)
            //        {

            //            cAtributo = "";
            //            nTotal = 0;

            //            try
            //            {
            //                cAtributo = atributo1[i];
            //            }
            //            catch
            //            {
            //                cAtributo = "";
            //            }

            //            try
            //            {
            //                nTotal = atributo2[i];
            //            }
            //            catch
            //            {
            //                nTotal = 0;
            //            }

            //            if (cAtributoRef == cAtributo)
            //            {
            //                Grid1[7, x].Value = nTotal.ToString("N2");
            //                break;

            //            }

            //        }

            //    }

            //}

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double Standar, nMinimo, nMaximo;
            double nValor;
            string cError;

            nMinimo = 0;
            nMaximo = 0;
            nValor = 0;

            try
            {
                Standar = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                Standar = 0;

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

            try
            {
                nValor = Convert.ToDouble(Grid1[7, fila].Value.ToString());

            }
            catch
            {
                nValor = 0;

            }

            Grid1[7, fila].Value = nValor.ToString("N2");

            cError = "";

            if (nValor < nMinimo)
            {
                cError = "S";
            }

            if (nValor > nMaximo)
            {
                cError = "S";
            }

            if (nMinimo == nMaximo)
            {
                cError = "";

            }

            if (nValor == 0)
            {
                Grid1[8, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

            }
            else
            {
                if (cError == "S")
                {
                    Grid1[8, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                }
                else
                {
                    Grid1[8, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                }

            }

            totalizar_grupos();
        }


        private void carga_datos_calidad()
        {

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_id_calidad.Text);
            }
            catch
            {
                nDocEntry = 0;

            }

            if (nDocEntry == 0)
            {
                return;
            }

            ////////////////////////////////////////////////////7
            //// Pantalla Principal - Queda en Blanco
            ////

            t_doc_entry.Text = "";
            t_fecha_ingreso.Text = "";
            t_lote.Text = "";
            t_variedad.Text = "";
            t_cant_prod.Text = "";
            t_un_medida.Text = "";

            ////////////////////////////////////////////////////7
            //// Pantalla Principal - Cargo los Datos
            ////

            string CardCode, CardName_prod, CardName_cliente;
            string ItemCode, ItemName, cLote;
            string obs, cTipoProducto, cEstadoRegistro;

            int id_acceso, line_id, line_id_ref;
            int cant_envases;

            DateTime fecha_hora1, fecha_hora2, dt;

            double nCantidad;

            CardCode = "";
            CardName_prod = "";
            CardName_cliente = "";
            ItemCode = "";
            ItemName = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            cEstadoRegistro = "";
            line_id_ref = 0;

            t_cardname_prod.Clear();
            t_cardname_cliente.Clear();
            t_pallet.Clear();
            t_observacion.Clear();

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Registro_Inspeccion(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_doc_entry.Text = dTable.Rows[0]["DocEntry"].ToString();

            }
            catch
            {
                t_doc_entry.Clear();

            }

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0]["U_FecIngr"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["U_WhsCode"].ToString();

            }
            catch
            {
                t_WhsCode.Clear();
            }

            try
            {
                t_un_medida.Text = dTable.Rows[0]["U_UM"].ToString();
            }
            catch
            {
                t_un_medida.Clear();
            }

            nCantidad = 0;

            try
            {
                nCantidad = Convert.ToDouble(dTable.Rows[0]["U_Cantidad"].ToString());
            }
            catch
            {
                nCantidad = 0;

            }

            try
            {
                cEstadoRegistro = dTable.Rows[0]["U_Estado"].ToString();
            }
            catch
            {
                cEstadoRegistro = "";

            }

            t_cant_prod.Text = nCantidad.ToString("N2");

            try
            {
                ItemCode = dTable.Rows[0]["U_ItemCode"].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["U_ItemName"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            try
            {
                cLote = dTable.Rows[0]["U_NoLote"].ToString();

            }
            catch
            {
                cLote = "";

            }

            try
            {
                t_NumOF.Text = dTable.Rows[0]["NumOF"].ToString();
            }
            catch
            {
                t_NumOF.Clear();
            }

            try
            {
                obs = dTable.Rows[0]["U_Comment"].ToString();

            }
            catch
            {
                obs = "";

            }

            t_Comments.Text = obs;
            
            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["CantEnvases"].ToString());

            }
            catch
            {
                cant_envases = 0;
            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["Fecha1"].ToString());
            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");
            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["Fecha2"].ToString());
            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");
            }

            try
            {
                cTipoProducto = dTable.Rows[0]["U_TipoProducto"].ToString();
            }
            catch
            {
                cTipoProducto = "";
            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["U_DocEntry_Ref"].ToString());
            }
            catch
            {
                id_acceso = 0;
            }

            try
            {
                line_id_ref = Convert.ToInt32(dTable.Rows[0]["U_LineId_Ref"].ToString());
            }
            catch
            {
                line_id_ref = 0;
            }

            t_id_ref.Text = id_acceso.ToString();
            t_lineid.Text = line_id_ref.ToString();

            try
            {
                t_object.Text = dTable.Rows[0]["U_Object_Ref"].ToString();
            }
            catch
            {
                t_object.Text = "";
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }

            ///////////////////////////////////////
            //// Esto es para los datos que vienen
            //// desde la Romana 

            try
            {
                CardCode = dTable.Rows[0]["COD_PRODUCTOR"].ToString();
            }
            catch
            {
                CardCode = "";
            }

            try
            {
                CardName_prod = dTable.Rows[0]["NAME_PRODUCTOR"].ToString();
            }
            catch
            {
                CardName_prod = "";
            }
            
            try
            {
                CardName_cliente = dTable.Rows[0]["NAME_CLIENTE"].ToString();
            }
            catch
            {
                CardName_cliente = "";
            }

            try
            {
                t_pallet.Text = dTable.Rows[0]["FolioPallet"].ToString();
            }
            catch
            {
                t_pallet.Clear();
            }

            try
            {
                t_tipo_proceso.Text = dTable.Rows[0]["Proceso_OF"].ToString();
            }
            catch
            {
                t_tipo_proceso.Clear();
            }
                      
            ////////////////////////////////////////////////////7
            //// Registro de Guia
            ////

            //t_object.Text = CardCode;
            t_cardname_prod.Text = CardName_prod;
            t_cardname_cliente.Text = CardName_cliente;

            t_lote.Text = cLote;

            t_observacion.Text = obs;

            ////////////////////////////////////////////////////7
            //// Registro de Guia

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cCode_D, cNomAtributo_D, cUM_D;
            string cLineId_D, cGrupoAtr_old_D;

            double nDesde_D, nHasta_D, nMedicion_D;
            double nStandar_D;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];
            
            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                cUM_D = "";
                nDesde_D = 0;
                nHasta_D = 0;
                nMedicion_D = 0;
                nStandar_D = 0;
                cLineId_D = "";

                try
                {
                    cLineId_D = dTable.Rows[i]["LineId"].ToString();

                }
                catch
                {
                    cLineId_D = "";

                }

                try
                {
                    cCode_D = dTable.Rows[i]["U_CodAtr"].ToString();

                }
                catch
                {
                    cCode_D = "";

                }

                try
                {
                    cNomAtributo_D = dTable.Rows[i]["U_NameAtr"].ToString();

                }
                catch
                {
                    cNomAtributo_D = "";

                }

                try
                {
                    cUM_D = dTable.Rows[i]["U_UM"].ToString();

                }
                catch
                {
                    cUM_D = "";

                }

                try
                {
                    nStandar_D = Convert.ToDouble(dTable.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandar_D = 0;
                }

                try
                {
                    nDesde_D = Convert.ToDouble(dTable.Rows[i]["U_Minimo"].ToString());

                }
                catch
                {
                    nDesde_D = 0;
                }

                try
                {
                    nHasta_D = Convert.ToDouble(dTable.Rows[i]["U_Maximo"].ToString());

                }
                catch
                {
                    nHasta_D = 0;
                }

                try
                {
                    nMedicion_D = Convert.ToDouble(dTable.Rows[i]["U_Medicion"].ToString());

                }
                catch
                {
                    nMedicion_D = 0;
                }

                try
                {
                    cGrupoAtr_old_D = dTable.Rows[i]["GrupoAtr"].ToString();

                }
                catch
                {
                    cGrupoAtr_old_D = "";

                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandar_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");
                grilla[7] = nMedicion_D.ToString("N2");
                grilla[9] = cGrupoAtr_old_D;

                Grid3.Rows.Add(grilla);
               
            }


            determino_totales_en_grupos();

            pinto_grupos();

            determino_grupos();

            totalizar_grupos();


            //////////////////////////////////////////////////
            //// Valido si tiene permisos para aprobar


            string cCalidad_Aprobacion;

            clsMaestros objproducto6 = new clsMaestros();
            objproducto6.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable6 = new DataTable();
            dTable6 = objproducto6.cResultado;

            try
            {
                cCalidad_Aprobacion = dTable6.Rows[0]["Calidad_Aprobacion"].ToString();

            }
            catch
            {
                cCalidad_Aprobacion = "";

            }

            //////////////////////////////////////////////////
            //// Valido si tiene permisos para aprobar

            t_resultado.Text = "En Proceso";

            if (cEstadoRegistro == "N")
            {
                if (cCalidad_Aprobacion == "SI")
                {
                    btn_aprobar.Visible = true;
                    btn_rechazar.Visible = true;

                }

            }

            if (cEstadoRegistro == "A")
            {
                t_resultado.Text = "Aprobado";
                btn_ok.Enabled = false;
                btn_aprobar.Enabled = false;
                btn_rechazar.Enabled = false;

                btn_aprobar.Visible = false;
                btn_rechazar.Visible = false;
                btn_nuevo_reg.Visible = false;

                btn_imprimir.Visible = true;

            }

            if (cEstadoRegistro == "R")
            {
                t_resultado.Text = "Rechazado";
                btn_ok.Enabled = false;
                btn_aprobar.Enabled = false;
                btn_rechazar.Enabled = false;

                btn_aprobar.Visible = false;
                btn_rechazar.Visible = false;
                btn_nuevo_reg.Visible = true;

            }

        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {
            int fila;
            string cCodAtr;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            cCodAtr = "";

            if (fila >= 0)
            {
                try
                {
                    cCodAtr = Grid1[1, fila].Value.ToString().ToUpper();
                }
                catch
                {
                    cCodAtr = "";
                }

                if (cCodAtr != "")
                {
                    Grid1.Columns[7].ReadOnly = false;
                }
                else
                {
                    Grid1.Columns[7].ReadOnly = true;
                }

            }


        }
    }
}
