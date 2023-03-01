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
using System.Drawing.Printing;
using System.IO;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmCalidadPPA6 : Form
    {
        public frmCalidadPPA6()
        {
            InitializeComponent();
        }

        private void frmCalidadPPA6_Load(object sender, EventArgs e)
        {
            carga_inicial();

        }

        private void carga_inicial()
        {

            try
            {
                cbb_caracteristicas.Items.Clear();

            }
            catch
            {

            }

            clsMaestros objproducto8 = new clsMaestros();
            objproducto8.cls_Consultar_Defectos();

            cbb_caracteristicas.DataSource = objproducto8.cResultado;
            cbb_caracteristicas.ValueMember = "U_Orden";
            cbb_caracteristicas.DisplayMember = "Code";

            t_carga_combo.Text = "";

            btn_aprobado.Visible = false;
            btn_aprobar.Visible = false;
            btn_rechazar_ri.Visible = false;
            btn_rechazar.Visible = false;
            btn_aprobar_con_reparos.Visible = false;

            btn_nuevo_reg.Visible = false;
            btn_imprimir.Visible = false;
            btn_excel.Visible = false;

            label19.Visible = false;
            t_resultado_previo.Visible = false;

            lbl_TipoAnalisis.Visible = false;
            cbb_TipoAnalisis.Visible = false;

            Grid1.Rows.Clear();
            Grid3.Rows.Clear();

            //lbl_sellado_bolsas.Visible = false;
            cbb_sellado_bolsas.Visible = false;

            txt_tipo_analisis_control.Text = "X";

            if (VariablesGlobales.glb_id_calidad == 0)
            {
                t_id_calidad.Text = "0";
                t_object.Text = VariablesGlobales.glb_Object;
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_lote.Text = VariablesGlobales.glb_Lote.ToString();

                label19.Visible = true;
                t_resultado_previo.Visible = true;
                btn_rechazar_ri.Visible = false;

                carga_datos_produccion();

                Application.DoEvents();
                Application.DoEvents();

                grabar();

                //totalizar_porcentaje_x_grupo("");
                //carga_datos_calidad();

            }
            else
            {
                t_id_calidad.Text = VariablesGlobales.glb_id_calidad.ToString();
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_object.Text = VariablesGlobales.glb_Object;

                carga_datos_calidad();

            }
            
            txt_tipo_analisis_control.Text = "";

        }

        private void carga_datos_produccion()
        {

            ////////////////////////////////////////
            // Esto se hace para el tipo de Registro

            cbb_TipoAnalisis.Visible = true;

            clsMaestros objproducto8 = new clsMaestros();
            objproducto8.cls_Consultar_AtributoCalidad_RI("");

            cbb_TipoAnalisis.DataSource = objproducto8.cResultado;
            cbb_TipoAnalisis.ValueMember = "DocEntry";
            cbb_TipoAnalisis.DisplayMember = "U_Referencia";

            ///////////////////////////////////////////////////////

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

            try
            {
                t_variedad.Text = dTable.Rows[0]["HDV_Variedad"].ToString();
            }
            catch
            {
                t_variedad.Text = "";
            }

            t_cant_prod.Text = nQuantity.ToString("N2");

            t_resultado.Text = "En Proceso";

            try
            {
                t_familia_subgrupo.Text = dTable.Rows[0]["FamGrupoProducto"].ToString();
            }
            catch
            {
                t_familia_subgrupo.Text = "";
            }

            try
            {
                t_familia_codsubgrupo.Text = dTable.Rows[0]["CodFamGrupoProducto"].ToString();
            }
            catch
            {
                t_familia_codsubgrupo.Text = "";
            }

            ////////////////////////////////////////////////////7
            ////

            if (t_variedad.Text.ToUpper() == "ALMENDRA")
            {
                label24.Visible = true;
                cbb_caracteristicas.Visible = true;

            }

            ////////////////////////////////////////////////////7
            ////////////////////////////////////////////////////7
            //// Determino el Consumo

            int nNumOF_Referencia;
            string cVariedad_Referencia, cCalibre_Referencia;

            nNumOF_Referencia = 0;
            cVariedad_Referencia = "";
            cCalibre_Referencia = "";

            try
            {
                nNumOF_Referencia = int.Parse(t_NumOF.Text);
            }
            catch
            {
                nNumOF_Referencia = 0;
            }

            if (nNumOF_Referencia != 0)
            {
                //
                clsCalidad objproducto2a = new clsCalidad();
                objproducto2a.cls_Consulta_Consumos_desde_OF(nNumOF_Referencia);

                DataTable dTable2a = new DataTable();
                dTable2a = objproducto2a.cResultado;

                cVariedad_Referencia = "";
                cCalibre_Referencia = "";

                try
                {
                    cVariedad_Referencia = dTable2a.Rows[0]["Variedad_Lote"].ToString();
                }
                catch
                {
                    cVariedad_Referencia = "";
                }

                try
                {
                    cCalibre_Referencia = dTable2a.Rows[0]["Calibre_Lote"].ToString();
                }
                catch
                {
                    cCalibre_Referencia = "";
                }

            }

            t_variedad_mp.Text = cVariedad_Referencia;
            t_calibre_mp.Text = cCalibre_Referencia;

            if (cVariedad_Referencia == "Carmel")
            {
                cbb_TipoAnalisis.SelectedValue = 6;

            }

            string cCode_D, cNomAtributo_D, cUM_D;
            string cLineId_D, cTipoDato;
            string cLocked1, cLocked2;

            //int nStandAtr_D;
            double nHasta_D, nDesde_D;
            double nHasta_D1, nDesde_D1;
            double nHasta_D2, nDesde_D2;
            double nStandard; 

            cCalibre_Referencia = "";

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_Atributos_PP_producto_V3(0, t_lote.Text);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];


            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {
                cCode_D = "";
                cNomAtributo_D = "";
                cUM_D = "";
                //nStandAtr_D = 0;
                nDesde_D = 0;
                nHasta_D = 0;
                cLineId_D = "";
                cTipoDato = "";
                nStandard = 0;

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
                    nDesde_D = double.Parse(dTable2.Rows[i]["U_Minimo"].ToString());
                }
                catch
                {
                    nDesde_D = 0;
                }

                try
                {
                    nHasta_D = double.Parse(dTable2.Rows[i]["U_Maximo"].ToString());
                }
                catch
                {
                    nHasta_D = 0;
                }

                try
                {
                    cTipoDato = dTable2.Rows[i]["Object"].ToString();
                }
                catch
                {
                    cTipoDato = "";
                }

                try
                {
                    nStandard = double.Parse(dTable2.Rows[i]["U_Standard"].ToString());
                }
                catch
                {
                    nStandard = 0;
                }

                nHasta_D1 = 0;
                nDesde_D1 = 0;
                cLocked1 = "";

                try
                {
                    nDesde_D1 = double.Parse(dTable2.Rows[i]["U_Minimo1"].ToString());
                }
                catch
                {
                    nDesde_D1 = -1;
                }

                try
                {
                    nHasta_D1 = double.Parse(dTable2.Rows[i]["U_Maximo1"].ToString());
                }
                catch
                {
                    nHasta_D1 = -1;
                }

                try
                {
                    cLocked1 = dTable2.Rows[i]["U_Locked1"].ToString();
                }
                catch
                {
                    cLocked1 = "";
                }

                nHasta_D2 = 0;
                nDesde_D2 = 0;
                cLocked2 = "";

                try
                {
                    nDesde_D2 = double.Parse(dTable2.Rows[i]["U_Minimo2"].ToString());
                }
                catch
                {
                    nDesde_D2 = -1;
                }

                try
                {
                    nHasta_D2 = double.Parse(dTable2.Rows[i]["U_Maximo2"].ToString());
                }
                catch
                {
                    nHasta_D2 = -1;
                }

                try
                {
                    cLocked2 = dTable2.Rows[i]["U_Locked2"].ToString();
                }
                catch
                {
                    cLocked2 = "";
                }

                grilla[0] = (i + 1).ToString(); //cLineId_D.ToString();
                grilla[1] = cCode_D;
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = "0";

                if (nDesde_D1 != -1)
                {
                    grilla[5] = nDesde_D1.ToString("N2");
                    grilla[6] = nHasta_D1.ToString("N2");

                    if (cLocked1 == "S")
                    {
                        grilla[4] = "1";
                    }

                }
                else
                {
                    if (nDesde_D2 != -1)
                    {
                        grilla[5] = nDesde_D2.ToString("N2");
                        grilla[6] = nHasta_D2.ToString("N2");

                        if (cLocked2 == "S")
                        {
                            grilla[4] = "1";
                        }

                    }
                    else
                    {
                        grilla[5] = nDesde_D.ToString("N2");
                        grilla[6] = nHasta_D.ToString("N2");
                    }
                }

                grilla[7] = nStandard.ToString("N2");
                grilla[8] = 0.ToString("N2");

                grilla[10] = cTipoDato;

                Grid1.Rows.Add(grilla);

            }

            Application.DoEvents();

            //determino_totales_en_grupos();

            pinto_grupos();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grabar()
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
            string cRegistroNuevo;

            int nDocEntry, nDocEntryRef, nLineIdRef;
            
            cItemCode = t_itemcode_d.Text;
            cItemName = t_itemname_d.Text;
            cObjetc = t_object.Text;
            cLote = t_lote.Text;
            cRegistroNuevo = "";

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                cRegistroNuevo = "SI";

            }
            else
            {
                cRegistroNuevo = "NO";

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

            string cCalibreNuez, cColorNuez;
            int nTipoAnalisis;

            cCalibreNuez = "";
            cColorNuez = "";
            nTipoAnalisis = 0;

            if (cbb_calibre.Visible == true)
            {
                try
                {
                    cCalibreNuez = cbb_calibre.SelectedValue.ToString();
                }
                catch
                {
                    cCalibreNuez = "";
                }

            }

            if (cbb_color.Visible == true)
            {
                try
                {
                    cColorNuez = cbb_color.SelectedValue.ToString();
                }
                catch
                {
                    cColorNuez = "";
                }

            }

            if (cbb_TipoAnalisis.Visible == true)
            {
                try
                {
                    nTipoAnalisis = Convert.ToInt32(cbb_TipoAnalisis.SelectedValue.ToString());
                }
                catch
                {
                    nTipoAnalisis = 0;
                }

                if (nTipoAnalisis == 0)
                {
                    if (nDocEntry != 0)
                    {
                        MessageBox.Show("Debe seleccionar un tipo de analisis válido, opción Cancelada", "Registro de Inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

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

            String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "N", UserId, UserCode, cItemCode, cItemName, cWhsCode, "", cNumCon, cLote, nCantidad, 0, 0, dt.ToString("yyyyMMdd"), cUM, 0, 0, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef, cCalibreNuez, cColorNuez, nTipoAnalisis,"","S","","");

            int nLineId;
            string cCodAtr, cNomAtr; //, cComments;
            //string cComments2;
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

            int nCaracteristica_descarte;

            nCaracteristica_descarte = 0;

            if (cbb_caracteristicas.SelectedIndex >= 0)
            {
                try
                {
                    nCaracteristica_descarte = cbb_caracteristicas.SelectedIndex;
                }
                catch
                {
                    nCaracteristica_descarte = 0;
                }

                nCaracteristica_descarte = nCaracteristica_descarte * -1;
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
                nPorcentaje = 0;
                //cComments = "";
                //cComments2 = "";

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

                if (cCodAtr == "PQ_9_099")
                {
                    cCodAtr = Grid1[1, i].Value.ToString();

                }

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
                    nMinimo = -1;

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
                
                if (t_variedad.Text.ToUpper() == "ALMENDRA")
                {
                    if (cCodAtr.Trim() != "")
                    {
                        if (cCodAtr.Substring(3, 5) == "1_001")
                        {
                            if (nCaracteristica_descarte < 0)
                            {
                                //-1 - Descarte 1
                                //-2 - Rayadas  2
                                //-3 - Partidas 3
                                //-4 - Fuera de Color 4
                                //-5 - Pelon 5
                                //-6 - PNC
                                //-7 - Hongo
                                //-8 - Pierna de Aire
                                //-9 - Gemelas
                                //-10 - Deshidratadas

                                nMedicion = nCaracteristica_descarte;

                            }
                        }

                    }

                }

                if (cCodAtr.Trim() != "")
                {

                    if (cNomAtr.Trim() != "")
                    {

                        if (t_doc_entry.Text != "")
                        {

                        }
                        else
                        {

                        }

                        if (cCodAtr != "PE_7_006")
                        {
                            if (cRegistroNuevo == "SI")
                            {
                                if (cCodAtr != "P__9_099")
                                {
                                    mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, "", "", "", nPorcentaje);

                                }

                                //mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -1, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "");

                            }

                        }

                        if (t_variedad.Text.ToUpper() == "ALMENDRA")
                        {
                            if (cCodAtr.Trim() != "")
                            {
                                if (cCodAtr.Substring(3, 5) == "1_001")
                                {
                                    if (nCaracteristica_descarte < 0)
                                    {
                                        //-1 - Descarte 1
                                        //-2 - Rayadas  2
                                        //-3 - Partidas 3
                                        //-4 - Fuera de Color 4
                                        //-5 - Pelon 5
                                        //-6 - PNC
                                        //-7 - Hongo
                                        //-8 - Pierna de Aire
                                        //-9 - Gemelas
                                        //-10 - Deshidratadas

                                        nMedicion = nCaracteristica_descarte;

                                        mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -3, cCodAtr, Grid1[2, i].Value.ToString(), 0, 0, 0, nMedicion, "", "", "",0);

                                    }
                                }

                            }

                        }

                    }

                }

            }

            ////////////////////////////////////
            ////////////////////////////////////
            // Pie de registros

            string cPie_de_formulario, cPie_de_formulario_Name;
            int nPie_de_formulario;


            if (lbl_pos_1.Visible == true)
            {
                cPie_de_formulario = t_pos_1.Text;
                cPie_de_formulario_Name = lbl_pos_1.Text;

                try
                {
                    nPie_de_formulario = cbb_POS_1.SelectedIndex;

                }
                catch
                {
                    nPie_de_formulario = 0;

                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -3, cPie_de_formulario, cPie_de_formulario_Name, 0, 0, 0, nPie_de_formulario, "", "", "", 0);

            }

            if (lbl_pos_2.Visible == true)
            {
                cPie_de_formulario = t_pos_2.Text;
                cPie_de_formulario_Name = lbl_pos_2.Text;

                try
                {
                    nPie_de_formulario = cbb_POS_2.SelectedIndex;

                }
                catch
                {
                    nPie_de_formulario = 0;

                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -3, cPie_de_formulario, cPie_de_formulario_Name, 0, 0, 0, nPie_de_formulario, "", "", "", 0);

            }

            if (lbl_pos_3.Visible == true)
            {
                cPie_de_formulario = t_pos_3.Text;
                cPie_de_formulario_Name = lbl_pos_3.Text;

                try
                {
                    nPie_de_formulario = cbb_POS_3.SelectedIndex;

                }
                catch
                {
                    nPie_de_formulario = 0;

                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -3, cPie_de_formulario, cPie_de_formulario_Name, 0, 0, 0, nPie_de_formulario, "", "", "", 0);

            }

            if (lbl_pos_4.Visible == true)
            {
                cPie_de_formulario = t_pos_4.Text;
                cPie_de_formulario_Name = lbl_pos_4.Text;

                try
                {
                    nPie_de_formulario = cbb_POS_4.SelectedIndex;

                }
                catch
                {
                    nPie_de_formulario = 0;

                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -3, cPie_de_formulario, cPie_de_formulario_Name, 0, 0, 0, nPie_de_formulario, "", "", "", 0);

            }

            ////////////////////////////////////
            ////////////////////////////////////


            if (cbb_PNC.Visible == true)
            {
                string cPNC_Valor;

                cPNC_Valor = "0";

                try
                {
                    cPNC_Valor = cbb_PNC.SelectedIndex.ToString();

                }
                catch
                {
                    cPNC_Valor = "0";
                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -5, cPNC_Valor, "", 0, 0, 0, 0, "", "", "", 0);

            }

            if (mensaje == "Y")
            {
                //MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            VariablesGlobales.glb_id_calidad = nDocEntry;

            carga_inicial();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            grabar();

            string cCodAtr;
            double nMinimo, nMedicion;

            // *************************************
            // Esto es solo para NCC 

            try
            {
                cCodAtr = Grid1[1, 0].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            if (cCodAtr.Substring(0,2).ToString() =="PO")
            {
                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    cCodAtr = "";
                    nMinimo = 0;
                    nMedicion = 0;

                    try
                    {
                        cCodAtr = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nMinimo = Convert.ToDouble(Grid1[5, i].Value.ToString());

                    }
                    catch
                    {
                        nMinimo = -1;

                    }

                    try
                    {
                        nMedicion = Convert.ToDouble(Grid1[7, i].Value.ToString());

                    }
                    catch
                    {
                        nMedicion = 0;

                    }

                    if (cCodAtr == "PO_1_100")
                    {
                        if (nMinimo != nMedicion)
                        {
                            MessageBox.Show("Error de integridad, la muestra debe ser sobre 100 Unidades", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                }

            }

            // *************************************
            // Esto es solo para NMEC 

            if (cCodAtr.Substring(0, 2).ToString() == "PU")
            {
                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    cCodAtr = "";
                    nMinimo = 0;
                    nMedicion = 0;

                    try
                    {
                        cCodAtr = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nMinimo = Convert.ToDouble(Grid1[5, i].Value.ToString());

                    }
                    catch
                    {
                        nMinimo = -1;

                    }

                    try
                    {
                        nMedicion = Convert.ToDouble(Grid1[7, i].Value.ToString());

                    }
                    catch
                    {
                        nMedicion = 0;

                    }

                    if (cCodAtr == "PU_2_100")
                    {
                        if (nMedicion != 1000)
                        {
                            MessageBox.Show("Error de integridad [PU_2_100 - Total Forma], la muestra debe ser sobre 1000 Gramos", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                    if (cCodAtr == "PU_7_110")
                    {
                        if (nMedicion != 1000)
                        {
                            MessageBox.Show("Error de integridad [PU_7_110 - Total Registro de Inspección], la muestra debe ser sobre 1000 Gramos", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                }

            }


            MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            carga_inicial();

        }

        private void pinto_grupos()
        {

            double nLineId, nValor, nMinimo;
            double nMaximo, nPorcentaje;

            int nResultado_Aprobado, nResultado_Rechazado; 

            string cTipoDato, cCodAtr, cLocked;

            ///////////////////////////////////////////////////////
            ////////// Pinto los totales generales
            ////////// 
            ////////// Y
            ////////// 
            ////////// Determino el resultado preliminar

            nResultado_Aprobado = 0;
            nResultado_Rechazado = 0;

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
                    cCodAtr = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    nValor = Convert.ToDouble(Grid1[7, i].Value.ToString());
                }
                catch
                {
                    nValor = 0;
                }

                try
                {
                    nMinimo = Convert.ToDouble(Grid1[5, i].Value.ToString());

                }
                catch
                {
                    nMinimo = -1;

                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid1[6, i].Value.ToString());

                }
                catch
                {
                    nMaximo = -1;

                }

                try
                {
                    nPorcentaje = Convert.ToDouble(Grid1[8, i].Value.ToString());

                }
                catch
                {
                    nPorcentaje = -1;

                }

                try
                {
                    cTipoDato = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cTipoDato = "";
                }

                try
                {
                    cLocked = Grid1[11, i].Value.ToString();
                }
                catch
                {
                    cLocked = "";
                }

                if (cTipoDato == "R")
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.Yellow;
                    }

                }

                if (cTipoDato == "D")
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.Empty;
                    }

                }

                if (cLocked == "S")
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.Orange;
                    }

                }

                if (cTipoDato == "C")
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightGray;
                    }

                    if (cLocked == "S")
                    {
                        Grid1[1, i].Style.BackColor = Color.Orange;

                    }

                }

                Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                if (nMinimo >= 0)
                {

                    if (cTipoDato == "D")
                    {
                        if (nValor > 0)
                        {
                            if (nValor <= nMinimo)
                            {
                                Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                            }

                        }

                        if (nValor > 0)
                        {
                            if (nValor > nMinimo)
                            {
                                Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                                if (cLocked == "S")
                                {
                                    nResultado_Rechazado += 1;

                                }

                            }

                        }

                    }

                    if (cTipoDato == "C")
                    {
                        if (nValor > 0)
                        {
                            if (nValor <= nMinimo)
                            {
                                Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                                nResultado_Aprobado += 1;

                            }

                        }

                        if (nValor > 0)
                        {
                            if (nValor > nMinimo)
                            {
                                Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                                if (cLocked == "S")
                                {
                                    nResultado_Rechazado += 1;

                                }

                            }

                        }

                        if (cCodAtr == "PO_1_100")
                        {
                            if (nValor > 0)
                            {
                                if (nValor != nMinimo)
                                {
                                    Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                                    if (cLocked == "S")
                                    {
                                        nResultado_Rechazado += 1;

                                    }

                                }
                                else
                                {
                                    Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                                    nResultado_Aprobado += 1;

                                }

                            }

                        }


                    }


                    if (nValor > nMaximo)
                    {
                        //Grid1[9, i].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                    }

                }


            }

            if (cbb_POS_1.SelectedIndex == 2)
            {
                //nResultado_Rechazado += 1;

            }

            if (cbb_POS_2.SelectedIndex == 2)
            {
                //nResultado_Rechazado += 1;

            }

            if (cbb_POS_3.SelectedIndex == 2)
            {
                //nResultado_Rechazado += 1;

            }

            string cResultado;

            cResultado = "Aprobado";

            t_resultado_previo.BackColor = Color.Green;

            if ((nResultado_Rechazado + nResultado_Aprobado)  > 0)
            {
                if (nResultado_Rechazado > 0)
                {
                    cResultado = "Rechazado";
                    t_resultado_previo.BackColor = Color.Red;

                }
                else
                {
                    cResultado = "Aprobado";
                    t_resultado_previo.BackColor = Color.Green;

                }

            }

            t_resultado_previo.Text = cResultado;

        }

        private void cambios_calidad_2021()
        {

            ///////////////////////////////////////////////////////
            ////////// Segun los cambios del 2021 
            ////////// ahora se generan cambios por
            ////////// programacion 
            ////////// 

            string cCodAtr;
            double nValor;

            if (t_tipo_proceso.Text == "Sorter 1")
            {

                ////////// ******************************
                ////////// Dato de calibre

                string cCalibre_NuezSorter;
                double nMitades_S, nLarge_S, nMedium_S;

                nMitades_S = 0;
                nLarge_S = 0;
                nMedium_S = 0;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cCodAtr = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[8, i].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    if (cCodAtr == "PS_3_001")
                    {
                        nMitades_S = nValor;
                    }

                    if (cCodAtr == "PS_3_002")
                    {
                        nLarge_S = nValor;
                    }

                    if (cCodAtr == "PS_3_003")
                    {
                        nMedium_S = nValor;
                    }

                }

                //////////////////////////////////

                cCalibre_NuezSorter = "";

                if ((nMitades_S + nLarge_S + nMedium_S) == 0)
                {
                    cbb_calibre.Enabled = true;
                }
                else
                {
                    cbb_calibre.Enabled = false;

                    if (nMitades_S > 60)
                    {
                        cCalibre_NuezSorter = "Mitades";

                    }
                    else
                    {
                        if (nLarge_S > nMedium_S)
                        {
                            cCalibre_NuezSorter = "Large Pieces";

                        }
                        else
                        {
                            cCalibre_NuezSorter = "Medium Pieces";

                        }

                    }

                }

                if (cCalibre_NuezSorter != "")
                {
                    cbb_calibre.SelectedValue = cCalibre_NuezSorter;
                }

                ////////// ******************************
                ////////// Dato de Color

                string cColor_NuezSorter;
                double nExtraLight_S, nLight_S, nLightAmbar_S;
                double nAmbar_S, nAmarillas_S, nValorMayor_S;

                nExtraLight_S = 0;
                nLight_S = 0;
                nLightAmbar_S = 0;
                nAmbar_S = 0;
                nAmarillas_S = 0;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cCodAtr = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[8, i].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    if (cCodAtr == "PS_4_001")
                    {
                        nExtraLight_S = nValor;
                    }

                    if (cCodAtr == "PS_4_002")
                    {
                        nLight_S = nValor;
                    }

                    if (cCodAtr == "PS_4_003")
                    {
                        nLightAmbar_S = nValor;
                    }

                    if (cCodAtr == "PS_4_004")
                    {
                        nAmbar_S = nValor;
                    }

                    if (cCodAtr == "PS_4_005")
                    {
                        nAmarillas_S = nValor;
                    }

                }

                //////////////////////////////////

                cColor_NuezSorter = "";

                nValorMayor_S = nExtraLight_S;

                if (nLight_S > nValorMayor_S)
                {
                    nValorMayor_S = nLight_S;
                }

                if (nLightAmbar_S > nValorMayor_S)
                {
                    nValorMayor_S = nLightAmbar_S;
                }

                if (nAmbar_S > nValorMayor_S)
                {
                    nValorMayor_S = nAmbar_S;
                }

                if (nAmarillas_S > nValorMayor_S)
                {
                    nValorMayor_S = nAmarillas_S;
                }

                if (nValorMayor_S == 0)
                {
                    cbb_color.Enabled = true;
                }
                else
                {
                    cbb_color.Enabled = false;

                    if (nValorMayor_S == nAmarillas_S)
                    {
                        if (t_itemname_d.Text.Substring(0,12) != "PRE-ENVASADO")
                        {
                            cColor_NuezSorter = "Rechazo Color 4";

                        }
                        else
                        {
                            cColor_NuezSorter = "Amarilla";

                        }

                    }

                    if (nValorMayor_S == nAmbar_S)
                    {
                        if (t_itemcode_d.Text.Substring(0, 12) == "PRE-ENVASADO")
                        {
                            cColor_NuezSorter = "Rechazo Color 3";

                        }
                        else
                        {
                            cColor_NuezSorter = "Ambar";

                        }

                    }

                    if (nValorMayor_S == nLightAmbar_S)
                    {
                        if (t_itemcode_d.Text.Substring(0, 12) == "PRE-ENVASADO")
                        {
                            cColor_NuezSorter = "Rechazo Color 2";

                        }
                        else
                        {
                            cColor_NuezSorter = "Light Ambar";

                        }

                    }

                    if (nValorMayor_S == nLight_S)
                    {
                        if (t_itemcode_d.Text.Substring(0, 12) == "PRE-ENVASADO")
                        {
                            cColor_NuezSorter = "Rechazo Color 1";

                        }
                        else
                        {
                            cColor_NuezSorter = "Light";

                        }

                    }

                    if (nValorMayor_S == nExtraLight_S)
                    {
                        cColor_NuezSorter = "Extra Light Light";

                    }

                }

                if (cColor_NuezSorter != "")
                {
                    cbb_color.SelectedValue = cColor_NuezSorter;
                }


            }

            if (t_tipo_proceso.Text == "Cracker Nueces")
            {
                string cCalibre_NuezCracker;
                double nMitades, nLarge, nMedium;

                nMitades = 0;
                nLarge = 0;
                nMedium = 0;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        cCodAtr = Grid1[1, i].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[8, i].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    if (cCodAtr == "PS_3_001")
                    {
                        nMitades = nValor;
                    }

                    if (cCodAtr == "PS_3_002")
                    {
                        nLarge = nValor;
                    }

                    if (cCodAtr == "PS_3_003")
                    {
                        nMedium = nValor;
                    }

                }

                //////////////////////////////////

                cCalibre_NuezCracker = "";

                if ((nMitades+nLarge+nMedium) == 0)
                {
                    cbb_calibre.Enabled = true;
                }
                else
                {
                    cbb_calibre.Enabled = false;

                    if (nMitades > 60)
                    {
                        cCalibre_NuezCracker = "Mitades";

                    }
                    else
                    {
                        if (nLarge> nMedium)
                        {
                            cCalibre_NuezCracker = "Large Pieces";

                        }
                        else
                        {
                            cCalibre_NuezCracker = "Medium Pieces";

                        }

                    }

                }

                if (cCalibre_NuezCracker != "")
                {
                    cbb_calibre.SelectedValue = cCalibre_NuezCracker;
                }

            }

        }


        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {
            int fila;
            string cTipoDato, cCodAtr;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            cTipoDato = "";

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

                try
                {
                    cTipoDato = Grid1[10, fila].Value.ToString().ToUpper();
                }
                catch
                {
                    cTipoDato = "";
                }

                if (cTipoDato == "D")
                {
                    Grid1.Columns[7].ReadOnly = false;
                }
                else
                {
                    Grid1.Columns[7].ReadOnly = true;
                }

            }
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
            string cCodAtr;
            int nDocEntry;

            nMinimo = 0;
            nMaximo = 0;
            nValor = 0;

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
                Standar = Convert.ToDouble(Grid1[4, fila].Value.ToString());
            }
            catch
            {
                Standar = 0;
            }

            try
            {
                nValor = Convert.ToDouble(Grid1[7, fila].Value.ToString());
            }
            catch
            {
                nValor = 0;
            }

            try
            {
                cCodAtr = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            //totalizar_grupos(cGrupoAtr);

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            //totalizar_porcentaje_x_grupo(cGrupoAtr);

            ////////////////////////////////////////////////////
            //// Determino el Calibre para algunos Analisis

            //Calcula_Resultado_Previo_Analisis();

            string cCodAtr_D, cCodAtr_G, cCodAtr_old_D;
            string cTipoDato;
            double nValor_D, nPorcentaje_D;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_SAPB1_ORCAL8(nDocEntry, "", cCodAtr,  nValor);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                cCodAtr_D = "";
                nValor_D = 0;

                try
                {
                    cCodAtr_D = dTable.Rows[i]["U_CodAtr"].ToString();
                }
                catch
                {
                    cCodAtr_D = "";
                }

                try
                {
                    //cCodAtr_D = cCodAtr_D.Substring(0, 8);
                }
                catch
                {
                    //cCodAtr_D = "";
                }

                try
                {
                    nValor_D = Convert.ToDouble(dTable.Rows[i]["U_Medicion"].ToString());
                }
                catch
                {
                    nValor_D = 0;
                }

                try
                {
                    nPorcentaje_D = Convert.ToDouble(dTable.Rows[i]["U_Porcentaje"].ToString());
                }
                catch
                {
                    nPorcentaje_D = 0;
                }

                for (int j = 0; j <= Grid1.RowCount - 1; j++)
                {
                    cCodAtr_G = "";

                    try
                    {
                        cCodAtr_G = Grid1[1, j].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr_G = "";
                    }

                    try
                    {
                        cTipoDato = Grid1[10, j].Value.ToString();
                    }
                    catch
                    {
                        cTipoDato = "";
                    }


                    if (cCodAtr_G == cCodAtr_D)
                    {

                        try
                        {
                            nMinimo = Convert.ToDouble(Grid1[5, j].Value.ToString());

                        }
                        catch
                        {
                            nMinimo = -1;

                        }

                        try
                        {
                            nMaximo = Convert.ToDouble(Grid1[6, j].Value.ToString());

                        }
                        catch
                        {
                            nMaximo = -1;

                        }

                        if (nValor_D >= 0)
                        {
                            Grid1[7, j].Value = nValor_D.ToString("N2");

                        }
                        else
                        {
                            cCodAtr_old_D = nValor_D.ToString("N2");

                            if (cCodAtr_old_D != "-40.00")
                            {
                                cCodAtr_old_D = cCodAtr_old_D.Replace("-", "");
                                cCodAtr_old_D = cCodAtr_old_D.Replace(".", "-");

                            }
                            else
                            {
                                cCodAtr_old_D = "40+";

                            }

                            Grid1[7, j].Value = cCodAtr_old_D;
                        }

                        //Grid1[7, j].Value = nValor_D.ToString("N2");
                        Grid1[8, j].Value = "";

                        if (nPorcentaje_D != -1)
                        {
                            Grid1[9, j].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                            Grid1[8, j].Value = nPorcentaje_D.ToString("N2");

                        }
                        else
                        {
                            Grid1[9, j].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                            Grid1[8, j].Value = "";

                        }

                        if (nPorcentaje_D < -1)
                        {

                            Grid1[8, j].Value = Grid1[8, j].Value.ToString().Replace("-", "");
                            Grid1[8, j].Value = Grid1[8, j].Value.ToString().Replace(".", "-");
                            Grid1[8, j].Value = Grid1[8, j].Value.ToString().Replace(",", "-");

                        }

                        break;

                    }

                }

            }

            pinto_grupos();

            cambios_calidad_2021();

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

                try
                {
                    VariablesGlobales.glb_Lote = Convert.ToInt32(t_lote.Text);

                }
                catch
                {
                    VariablesGlobales.glb_Lote = 0;

                }

                frmCalidadMPA1 f2 = new frmCalidadMPA1();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_id_calidad = 0;
                VariablesGlobales.glb_Lote = 0;

            }

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
            //// Genero un pre ingreso para validar que es?
            ////

            string cTipoAnalisis_Familia, cPNC; 

            clsCalidad objproducto_1 = new clsCalidad();
            objproducto_1.cls_Consulta_Registro_Inspeccion(nDocEntry);

            DataTable dTable_1 = new DataTable();
            dTable_1 = objproducto_1.cResultado;

            try
            {
                t_variedad.Text = dTable_1.Rows[0]["HDV_Variedad"].ToString();
            }
            catch
            {
                t_variedad.Text = "";
            }

            cTipoAnalisis_Familia = "Almendra";

            cbb_TipoAnalisis.Visible = false;

            if (t_variedad.Text.ToUpper() == "ALMENDRA")
            {
                cTipoAnalisis_Familia = "Almendra";
                //lbl_TipoAnalisis.Visible = true;
                cbb_TipoAnalisis.Visible = true;

            }
            else
            {
                cTipoAnalisis_Familia = "NCC";

            }

            ////////////////////////////////////////
            // Esto se hace para el tipo de Registro

            clsMaestros objproducto8 = new clsMaestros();
            objproducto8.cls_Consultar_AtributoCalidad_RI(cTipoAnalisis_Familia);

            cbb_TipoAnalisis.DataSource = objproducto8.cResultado;
            cbb_TipoAnalisis.ValueMember = "DocEntry";
            cbb_TipoAnalisis.DisplayMember = "U_Referencia";


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
            string cTipoFruta_Combo, cTipoMuestra_D;

            int id_acceso, line_id, line_id_ref;
            int cant_envases, nTipoAnalisis, id_MotivoBloqueo;

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
            t_status_lote.Text = "";
            nTipoAnalisis = 0;
            id_MotivoBloqueo = 0;

            t_cardname_prod.Clear();
            t_cardname_cliente.Clear();
            t_pallet.Clear();
            t_observacion.Clear();

            int nDocEntry_ref;

            if (nDocEntry >= 0)
            {
                nDocEntry_ref = nDocEntry;
            }
            else
            {
                nDocEntry_ref = nDocEntry * -1;
            }

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Registro_Inspeccion(nDocEntry_ref);

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

            try
            {
                nTipoAnalisis = Convert.ToInt32(dTable.Rows[0]["CodTipoAnalisis"].ToString());
            }
            catch
            {
                nTipoAnalisis = 1;
            }

            try
            {
                cPNC = dTable.Rows[0]["U_AtrT2"].ToString();

            }
            catch
            {
                cPNC = "";

            }

            if (cPNC == "")
            {
                cPNC = "0";

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

            try
            {
                t_familia_subgrupo.Text = dTable.Rows[0]["FamGrupoProducto"].ToString();
            }
            catch
            {
                t_familia_subgrupo.Text = "";
            }

            try
            {
                t_familia_codsubgrupo.Text = dTable.Rows[0]["CodFamGrupoProducto"].ToString();
            }
            catch
            {
                t_familia_codsubgrupo.Text = "";
            }

            try
            {
                t_calibre_nuez.Text = dTable.Rows[0]["U_Calibre_Nuez"].ToString();
            }
            catch
            {
                t_calibre_nuez.Clear();
            }

            try
            {
                t_color_nuez.Text = dTable.Rows[0]["U_Color_Nuez"].ToString();
            }
            catch
            {
                t_color_nuez.Clear();
            }

            try
            {
                t_status_lote.Text = dTable.Rows[0]["nom_status_lote"].ToString();
            }
            catch
            {
                t_status_lote.Clear();
            }

            try
            {
                id_MotivoBloqueo = Convert.ToInt32(dTable.Rows[0]["id_MotivoBloqueo"].ToString());
                
            }
            catch
            {
                id_MotivoBloqueo = 0;

            }

            if (id_MotivoBloqueo > 0)
            {
                cbb_bloqueo.SelectedIndex = id_MotivoBloqueo;

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

            try
            {
                t_variedad.Text = dTable.Rows[0]["HDV_Variedad"].ToString();
            }
            catch
            {
                t_variedad.Text = "";
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
            ////

            if (t_variedad.Text.ToUpper() == "ALMENDRA")
            {
                label24.Visible = true;
                cbb_caracteristicas.Visible = true;

                //lbl_sellado_bolsas.Visible = true;
                //cbb_sellado_bolsas.Visible = true;

            }

            if (t_variedad.Text.ToUpper() == "NUEZ")
            {
                label24.Visible = false;
                cbb_caracteristicas.Visible = false;
                cbb_TipoAnalisis.Visible = false;

                cTipoFruta_Combo = "Nuez";

                if ((t_tipo_proceso.Text == "NCC L1") || (t_tipo_proceso.Text == "NCC L2") || (t_tipo_proceso.Text == "Calibrado") || (t_tipo_proceso.Text == "Blanqueado + Calibrado") || (t_tipo_proceso.Text == "Blanqueado") || (t_tipo_proceso.Text == "Lavado") || (t_tipo_proceso.Text == "Lavado + Calibrado"))
                {
                    cTipoFruta_Combo = "Nuez C/C";
                }

                if ((t_tipo_proceso.Text == "NCC L1") || (t_tipo_proceso.Text == "NCC L2"))
                {
                    cbb_TipoAnalisis.Visible = true;
                }

                if (cTipoFruta_Combo != "")
                {

                    //////////////////////////////////////
                    // Esto se hace para el Calibre 

                    cbb_calibre.Visible = true;
                    label11.Visible = true;

                    clsMaestros objproducto3 = new clsMaestros();
                    objproducto3.cls_Consultar_Calibres_NuezMec(cTipoFruta_Combo);

                    cbb_calibre.DataSource = objproducto3.cResultado;
                    cbb_calibre.ValueMember = "Code";
                    cbb_calibre.DisplayMember = "Name";

                    if (t_calibre_nuez.Text != "")
                    {
                        try
                        {
                            cbb_calibre.SelectedValue = t_calibre_nuez.Text;
                        }
                        catch
                        {
                            cbb_calibre.Text = "";
                        }
                    }
                    else
                    {
                        cbb_calibre.Text = "";
                    }

                    //////////////////////////////////////
                    // Esto se hace para el Color

                    if (cTipoFruta_Combo == "Nuez")
                    {

                        cbb_color.Visible = true;
                        label18.Visible = true;

                        clsMaestros objproducto1 = new clsMaestros();
                        objproducto1.cls_Consultar_Colores();

                        cbb_color.DataSource = objproducto1.cResultado;
                        cbb_color.ValueMember = "Code";
                        cbb_color.DisplayMember = "Name";

                        if (t_color_nuez.Text != "")
                        {
                            try
                            {
                                cbb_color.SelectedValue = t_color_nuez.Text;
                            }
                            catch
                            {
                                cbb_color.Text = "";
                            }
                        }
                        else
                        {
                            cbb_color.Text = "";
                        }

                    }

                }

                t_carga_combo.Text = "C";

            }

            ////////////////////////////////////////////////////7
            //// Cambio para el proceso de Nuez Cracker
            ////

            //

            if (t_tipo_proceso.Text == "Cracker Nueces")
            {
                cbb_calibre.Enabled = false;

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cCode_D, cNomAtributo_D, cUM_D;
            string cLineId_D, cCodAtr_old_D, cTipoDato;
            string cLocked1, cLocked2, cGrupo_D;

            double nMedicion_D, nStandar_D, nPorcentaje_D;

            //int nStandAtr_D;
            double nHasta_D, nDesde_D;
            double nHasta_D1, nDesde_D1;
            double nHasta_D2, nDesde_D2;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            cGrupo_D = "";

            try
            {
                cCode_D = dTable.Rows[0]["U_CodAtr"].ToString();

            }
            catch
            {
                cCode_D = "";

            }

            if (cCode_D != "")
            {
                cGrupo_D = cCode_D.Substring(0, 2);
            }

            lbl_pos_4.Visible = false;
            cbb_POS_4.Visible = false;

            if (cGrupo_D == "PQ")
            {
                //lbl_pos_1.Visible = true;
                //cbb_PQ_9_099.Visible = true;

                //lbl_pos_2.Visible = true;
                //cbb_PQ_9_100.Visible = true;

                //lbl_pos_3.Visible = true;
                //cbb_PQ_9_101.Visible = true;

                Grid1.Columns[6].Visible = false;

            }

            if (cGrupo_D == "PT")
            {
                //lbl_pos_1.Visible = true;
                //cbb_PQ_9_099.Visible = true;

                //lbl_pos_2.Visible = true;
                //cbb_PQ_9_100.Visible = true;

                //lbl_pos_3.Visible = true;
                //cbb_PQ_9_101.Visible = true;

                //lbl_pos_4.Visible = true;
                //cbb_PQ_9_102.Visible = true;

                Grid1.Columns[6].Visible = false;
                cbb_TipoAnalisis.Visible = false;

            }

            if (cGrupo_D == "PR")
            {
                //lbl_pos_1.Visible = false;
                //cbb_PQ_9_099.Visible = false;

                //lbl_pos_2.Visible = false;
                //cbb_PQ_9_100.Visible = false;

                //lbl_pos_3.Visible = false;
                //cbb_PQ_9_101.Visible = false;

                Grid1.Columns[6].Visible = false;


            }

            if (cGrupo_D == "PS")
            {
                //lbl_pos_1.Visible = false;
                //cbb_PQ_9_099.Visible = false;

                //lbl_pos_2.Visible = false;
                //cbb_PQ_9_100.Visible = false;

                //lbl_pos_3.Visible = false;
                //cbb_PQ_9_101.Visible = false;

                Grid1.Columns[6].Visible = false;

            }

            if (cGrupo_D == "PO")
            {
                //lbl_pos_1.Visible = false;
                //cbb_PQ_9_099.Visible = false;

                //lbl_pos_2.Visible = false;
                //cbb_PQ_9_100.Visible = false;

                //lbl_pos_3.Visible = false;
                //cbb_PQ_9_101.Visible = false;

                Grid1.Columns[6].Visible = false;

            }

            if (cGrupo_D == "PU")
            {
                //lbl_pos_1.Visible = false;
                //cbb_PQ_9_099.Visible = false;

                //lbl_pos_2.Visible = false;
                //cbb_PQ_9_100.Visible = false;

                //lbl_pos_3.Visible = false;
                //cbb_PQ_9_101.Visible = false;

                Grid1.Columns[6].Visible = false;

            }

            try
            {

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
                    cTipoMuestra_D = "";

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
                        cUM_D = dTable.Rows[i]["U_UM1"].ToString();

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
                        //nPorcentaje_D = Convert.ToDouble(dTable.Rows[i]["U_Porcentaje2"].ToString());
                        nPorcentaje_D = Convert.ToDouble(dTable.Rows[i]["U_Porcentaje3"].ToString());
                    }
                    catch
                    {
                        nPorcentaje_D = 0;
                    }

                    nHasta_D1 = 0;
                    nDesde_D1 = 0;
                    cLocked1 = "";

                    try
                    {
                        nDesde_D1 = double.Parse(dTable.Rows[i]["U_Minimo1"].ToString());
                    }
                    catch
                    {
                        nDesde_D1 = -1;
                    }

                    try
                    {
                        nHasta_D1 = double.Parse(dTable.Rows[i]["U_Maximo1"].ToString());
                    }
                    catch
                    {
                        nHasta_D1 = -1;
                    }

                    try
                    {
                        cLocked1 = dTable.Rows[i]["U_Locked2"].ToString();
                    }
                    catch
                    {
                        cLocked1 = "";
                    }

                    nHasta_D2 = 0;
                    nDesde_D2 = 0;
                    cLocked2 = "";

                    try
                    {
                        nDesde_D2 = double.Parse(dTable.Rows[i]["U_Minimo2"].ToString());
                    }
                    catch
                    {
                        nDesde_D2 = -1;
                    }

                    try
                    {
                        nHasta_D2 = double.Parse(dTable.Rows[i]["U_Maximo2"].ToString());
                    }
                    catch
                    {
                        nHasta_D2 = -1;
                    }

                    try
                    {
                        cLocked2 = dTable.Rows[i]["U_Locked3"].ToString();
                    }
                    catch
                    {
                        cLocked2 = "";
                    }

                    try
                    {
                        cTipoDato = dTable.Rows[i]["TipoDato"].ToString();
                    }
                    catch
                    {
                        cTipoDato = "";
                    }

                    try
                    {
                        cTipoMuestra_D = dTable.Rows[i]["U_TipoMues_D"].ToString();

                    }
                    catch
                    {
                        cTipoMuestra_D = "";

                    }

                    if (cCode_D.Trim() != "")
                    {
                        if (cCode_D.Substring(0, 1) == "AL")
                        {
                            if (cCode_D.Substring(3, 5) == "1_001")
                            {
                                if (nMedicion_D < 0)
                                {
                                    //-1 - Descarte 1
                                    //-2 - Rayadas  2
                                    //-3 - Partidas 3
                                    //-4 - Fuera de Color 4
                                    //-5 - Pelon 5 
                                    //-6 - PNC
                                    //-7 - Hongo

                                    cbb_caracteristicas.SelectedIndex = Convert.ToInt32(nMedicion_D) * -1;
                                    nMedicion_D = 0;

                                }
                            }

                        }

                    }

                    if (t_variedad.Text.Substring(0, 2).ToUpper() == "AL")
                    {
                        if (cCode_D != "")
                        {
                            if (cCode_D.Substring(3, 5) == "1_001")
                            {
                                if (nMedicion_D < 0)
                                {
                                    //-1 - Descarte 1
                                    //-2 - Rayadas  2
                                    //-3 - Partidas 3
                                    //-4 - Fuera de Color 4
                                    //-5 - Pelon 5 
                                    //-6 - PNC
                                    //-7 - Hongo

                                    cbb_caracteristicas.SelectedIndex = Convert.ToInt32(nMedicion_D) * -1;
                                    nMedicion_D = 0;

                                }
                            }
                        }

                    }

                    grilla[0] = cLineId_D.ToString();
                    grilla[1] = cCode_D.ToString();
                    grilla[2] = cNomAtributo_D.ToString();
                    grilla[3] = cUM_D.ToUpper();
                    grilla[4] = nStandar_D.ToString("N2");

                    if (nDocEntry > 0)
                    {
                        if (nDesde_D >= 0)
                        {
                            grilla[5] = nDesde_D.ToString("N2");
                        }
                        else
                        {
                            grilla[5] = "Sin Limite";
                        }

                        grilla[6] = nHasta_D.ToString("N2");

                    }
                    else
                    {
                        if (nDesde_D1 != -1)
                        {
                            grilla[5] = nDesde_D1.ToString("N2");
                            grilla[6] = nHasta_D1.ToString("N2");

                            if (cLocked1 == "S")
                            {
                                grilla[4] = "1";
                            }

                        }
                        else
                        {
                            if (nDesde_D2 != -1)
                            {
                                grilla[5] = nDesde_D2.ToString("N2");
                                grilla[6] = nHasta_D2.ToString("N2");

                                if (cLocked2 == "S")
                                {
                                    grilla[4] = "1";
                                }

                            }
                            else
                            {
                                grilla[5] = nDesde_D.ToString("N2");
                                grilla[6] = nHasta_D.ToString("N2");
                            }
                        }

                    }

                    if (nMedicion_D >= 0)
                    {
                        grilla[7] = nMedicion_D.ToString("N2");

                    }
                    else
                    {

                        cCodAtr_old_D = nMedicion_D.ToString("N2");
                        
                        if ((cCodAtr_old_D != "-40.00") && (cCodAtr_old_D != "-40,00"))
                        {
                            cCodAtr_old_D = cCodAtr_old_D.Replace("-", "");
                            cCodAtr_old_D = cCodAtr_old_D.Replace(".", "-");
                            cCodAtr_old_D = cCodAtr_old_D.Replace(",", "-");

                        }
                        else
                        {
                            cCodAtr_old_D = "40+";

                        }

                        grilla[7] = cCodAtr_old_D;
                    }

                    grilla[8] = "";

                    if ((cTipoDato == "D") || (cTipoDato == "C"))
                    {
                        if (nPorcentaje_D != -1)
                        {
                            grilla[8] = nPorcentaje_D.ToString("N2");

                        }

                        if (nPorcentaje_D < -1)
                        {
                            grilla[8] = nPorcentaje_D.ToString("N2");

                            grilla[8] = grilla[8].Replace("-", "");
                            grilla[8] = grilla[8].Replace(".", "-");
                            grilla[8] = grilla[8].Replace(",", "-");

                        }

                    }

                    grilla[10] = cTipoDato;
                    grilla[11] = cLocked2;

                    if (cTipoDato != "X")
                    {
                        Grid1.Rows.Add(grilla);

                    }

                    if (cCode_D == "PE_7_006")
                    {
                        cbb_sellado_bolsas.SelectedIndex = 0;

                        if (nMedicion_D == 1)
                        {
                            cbb_sellado_bolsas.SelectedIndex = 1;

                        }

                    }

                    // ***************************************************
                    // Combo Box - PQ

                    if (cTipoDato == "X")
                    {

                        if (cTipoMuestra_D == "1")
                        {
                            t_pos_1.Text = cCode_D.ToString();
                            lbl_pos_1.Visible = true;
                            lbl_pos_1.Text = cNomAtributo_D.ToString();
                            cbb_POS_1.Visible = true;
                            t_pos_1v.Text = nMedicion_D.ToString();

                        }

                        if (cTipoMuestra_D == "2")
                        {
                            t_pos_2.Text = cCode_D.ToString();
                            lbl_pos_2.Visible = true;
                            lbl_pos_2.Text = cNomAtributo_D.ToString();
                            cbb_POS_2.Visible = true;
                            t_pos_2v.Text = nMedicion_D.ToString();

                        }

                        if (cTipoMuestra_D == "3")
                        {
                            t_pos_3.Text = cCode_D.ToString();
                            lbl_pos_3.Visible = true;
                            lbl_pos_3.Text = cNomAtributo_D.ToString();
                            cbb_POS_3.Visible = true;
                            t_pos_3v.Text = nMedicion_D.ToString();

                        }

                        if (cTipoMuestra_D == "4")
                        {
                            t_pos_4.Text = cCode_D.ToString();
                            lbl_pos_4.Visible = true;
                            lbl_pos_4.Text = cNomAtributo_D.ToString();
                            cbb_POS_4.Visible = true;
                            t_pos_4v.Text = nMedicion_D.ToString();

                        }

                    }

                    if (cGrupo_D == "PQ")
                    {
                        if (cCode_D.Substring(0, 4) == "PQ_9")
                        {
                            if (cCode_D == "PQ_9_099")
                            {
                                //t_PQ_9_099.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_1.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_1.SelectedIndex = 0;

                                //}

                            }

                            if (cCode_D == "PQ_9_100")
                            {
                                //t_PQ_9_100.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_2.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_2.SelectedIndex = 0;

                                //}

                            }

                            if (cCode_D == "PQ_9_101")
                            {
                                //t_PQ_9_101.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_3.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_3.SelectedIndex = 0;

                                //}

                            }

                        }

                    }

                    // ***************************************************
                    // Combo Box - PT

                    if (cGrupo_D == "PT")
                    {
                        // Larva Viva
                        //    Variedad Correspondiente
                        // Piedra
                        // Terron
                        if (cCode_D.Substring(0, 4) == "PT_4")
                        {
                            if (cCode_D == "PT_4_001") // Larva Viva
                            {
                                //t_PQ_9_099.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_1.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_1.SelectedIndex = 0;

                                //}

                            }

                            if (cCode_D == "PT_4_004") // Terron
                            {
                                //t_PQ_9_100.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_2.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_2.SelectedIndex = 0;

                                //}

                            }

                            if (cCode_D == "PT_4_003") // Piedra
                            {
                                //t_PQ_9_101.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_3.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_3.SelectedIndex = 0;

                                //}

                            }

                            if (cCode_D == "PT_4_002") // Variedad Correspondiente
                            {
                                //t_PQ_9_102.Text = nMedicion_D.ToString();

                                //try
                                //{
                                //    cbb_POS_4.SelectedIndex = Convert.ToInt32(nMedicion_D.ToString());

                                //}
                                //catch
                                //{
                                //    cbb_POS_4.SelectedIndex = 0;

                                //}

                            }

                        }

                    }

                    // **********************************************

                }

            }

            catch
            {

            }

            if (t_pos_1.Text !="")
            {

                int nPos_1v;

                clsMaestros objproducto_pv1 = new clsMaestros();
                objproducto_pv1.cls_Consulta_combo_pie_frm(t_pos_1.Text);

                cbb_POS_1.DataSource = objproducto_pv1.cResultado;
                cbb_POS_1.ValueMember = "U_Id";
                cbb_POS_1.DisplayMember = "U_Value";

                nPos_1v = 0;

                try
                {
                    nPos_1v = Convert.ToInt32(t_pos_1v.Text);

                }
                catch
                {
                    nPos_1v = 0;
                }

                try
                {
                    cbb_POS_1.SelectedValue = nPos_1v;
                }
                catch
                {

                }

            }

            if (t_pos_2.Text != "")
            {

                int nPos_2v;

                clsMaestros objproducto_pv2 = new clsMaestros();
                objproducto_pv2.cls_Consulta_combo_pie_frm(t_pos_2.Text);

                cbb_POS_2.DataSource = objproducto_pv2.cResultado;
                cbb_POS_2.ValueMember = "U_Id";
                cbb_POS_2.DisplayMember = "U_Value";

                nPos_2v = 0;

                try
                {
                    nPos_2v = Convert.ToInt32(t_pos_2v.Text);

                }
                catch
                {
                    nPos_2v = 0;
                }

                try
                {
                    cbb_POS_2.SelectedValue = nPos_2v;
                }
                catch
                {

                }

            }

            if (t_pos_3.Text != "")
            {

                int nPos_3v;

                clsMaestros objproducto_pv3 = new clsMaestros();
                objproducto_pv3.cls_Consulta_combo_pie_frm(t_pos_3.Text);

                cbb_POS_3.DataSource = objproducto_pv3.cResultado;
                cbb_POS_3.ValueMember = "U_Id";
                cbb_POS_3.DisplayMember = "U_Value";

                nPos_3v = 0;

                try
                {
                    nPos_3v = Convert.ToInt32(t_pos_3v.Text);

                }
                catch
                {
                    nPos_3v = 0;
                }

                try
                {
                    cbb_POS_3.SelectedValue = nPos_3v;
                }
                catch
                {

                }

            }

            if (t_pos_4.Text != "")
            {

                int nPos_4v;

                clsMaestros objproducto_pv4 = new clsMaestros();
                objproducto_pv4.cls_Consulta_combo_pie_frm(t_pos_4.Text);

                cbb_POS_4.DataSource = objproducto_pv4.cResultado;
                cbb_POS_4.ValueMember = "U_Id";
                cbb_POS_4.DisplayMember = "U_Value";

                nPos_4v = 0;

                try
                {
                    nPos_4v = Convert.ToInt32(t_pos_4v.Text);

                }
                catch
                {
                    nPos_4v = 0;
                }

                try
                {
                    cbb_POS_4.SelectedValue = nPos_4v;
                }
                catch
                {

                }

            }

            ////////////////////////////////////////////////////7
            ////////////////////////////////////////////////////7
            //// Determino el Consumo

            int nNumOF_Referencia;
            string cVariedad_Referencia, cCalibre_Referencia;

            nNumOF_Referencia = 0;
            cVariedad_Referencia = "";
            cCalibre_Referencia = "";

            try
            {
                nNumOF_Referencia = int.Parse(t_NumOF.Text);
            }
            catch
            {
                nNumOF_Referencia = 0;
            }

            if (nNumOF_Referencia != 0)
            {
                //
                clsCalidad objproducto2a = new clsCalidad();
                objproducto2a.cls_Consulta_Consumos_desde_OF(nNumOF_Referencia);

                DataTable dTable2a = new DataTable();
                dTable2a = objproducto2a.cResultado;

                cVariedad_Referencia = "";
                cCalibre_Referencia = "";

                try
                {
                    cVariedad_Referencia = dTable2a.Rows[0]["Variedad_Lote"].ToString();
                }
                catch
                {
                    cVariedad_Referencia = "";
                }

                try
                {
                    cCalibre_Referencia = dTable2a.Rows[0]["Calibre_Lote"].ToString();
                }
                catch
                {
                    cCalibre_Referencia = "";
                }

            }

            t_variedad_mp.Text = cVariedad_Referencia;
            t_calibre_mp.Text = cCalibre_Referencia;

            //////////////////////////////////////
            //// Cargo el Combo de Tipo de Analisis

            try
            {
                cbb_TipoAnalisis.SelectedValue = nTipoAnalisis;
            }
            catch
            {
                cbb_TipoAnalisis.SelectedValue = 0;
            }
            
            //////////////////////////////////////
            //// Calculo los totales por grupo

            //determino_totales_en_grupos();

            pinto_grupos();

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            string cCodAtr, cCodAtr_Sub;

            cCodAtr = "";
            cCodAtr_Sub = "";

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                cCodAtr = "";

                try
                {
                    cCodAtr = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                if (cCodAtr != cCodAtr_Sub)
                {
                    //totalizar_grupos(cCodAtr);
                    cCodAtr_Sub = cCodAtr;
                }

            }

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            cCodAtr = "";
            cCodAtr_Sub = "";

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                cCodAtr = "";

                try
                {
                    cCodAtr = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                if (cCodAtr != cCodAtr_Sub)
                {
                    //totalizar_porcentaje_x_grupo(cCodAtr);
                    cCodAtr_Sub = cCodAtr;
                }

            }

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
            //// ???? **** --- +++ ** 9 6 

            //totalizar_grupos("");

            //////////////////////////////////////////////////
            //// Valido si tiene permisos para aprobar

            t_resultado.Text = "En Proceso";
            t_resultado.BackColor = Color.Yellow;

            string TipoProducto;

            TipoProducto = "F";

            if (t_familia_subgrupo.Text != "Producto Terminado")
            {
                TipoProducto = "S";
            }
            else
            {
                if (t_variedad.Text != "Almendra")
                {
                    TipoProducto = "F";
                }
            }

            if (t_tipo_proceso.Text == "Secado")
            {
                TipoProducto = "F";
            }

            if ((t_tipo_proceso.Text == "NCC L2") || (t_tipo_proceso.Text == "NCC L1") || (t_tipo_proceso.Text == "Calibrado"))
            {
                if (t_variedad.Text == "Nuez")
                {
                    //TipoProducto = "S";
                    //TipoProducto = "F";

                }
            }

            if (cEstadoRegistro == "N")
            {
                if (cCalidad_Aprobacion == "SI")
                {
                    if (TipoProducto == "S")
                    {
                        btn_aprobar.Visible = true;
                        btn_rechazar_ri.Visible = true;

                    }
                    else
                    {
                        btn_aprobar.Visible = false;
                        btn_rechazar_ri.Visible = false;

                        btn_aprobado.Visible = true;
                        btn_rechazar.Visible = true;
                        btn_aprobar_con_reparos.Visible = true;

                        //btn_rechazar_ri.Visible = false;

                        if ((t_tipo_proceso.Text == "Secado") || (t_tipo_proceso.Text == "Selección Mecanica"))
                        {
                            btn_aprobar_con_reparos.Visible = false;
                        }

                    }

                    label19.Visible = true;
                    t_resultado_previo.Visible = true;

                }

            }

            if (cbb_caracteristicas.Visible == true)
            {
                string cCaractetistica_PNC;

                try
                {
                    cCaractetistica_PNC = cbb_caracteristicas.Text.ToString();
                }
                catch
                {
                    cCaractetistica_PNC = "";

                }

                if (cCaractetistica_PNC =="PNC")
                {
                    cbb_caracteristicas.Size = new System.Drawing.Size(50, 21);
                    cbb_PNC.Visible = true;

                    int nPNC;

                    nPNC = 0;

                    try
                    {
                        nPNC = Convert.ToInt32(cPNC);

                    }
                    catch
                    {
                        nPNC = 0;

                    }

                    cbb_PNC.SelectedIndex = nPNC;

                }

            }

            if (cEstadoRegistro == "A")
            {
                t_resultado.Text = "Aprobado";
                t_resultado.BackColor = Color.Green;

                btn_ok.Enabled = false;

                btn_aprobar.Enabled = false;
                btn_rechazar_ri.Visible = false;

                btn_aprobado.Enabled = false;
                btn_rechazar.Enabled = false;
                btn_aprobar_con_reparos.Enabled = false;

                btn_aprobar.Visible = false;
                btn_rechazar.Visible = false;
                btn_aprobar_con_reparos.Visible = false;
                btn_rechazar_ri.Visible = false;

                //////////////////////////////////////////////////////////////

                btn_imprimir.Visible = true;
                btn_nuevo_reg.Visible = true;
                btn_excel.Visible = true;

            }

            if (cEstadoRegistro == "R")
            {
                t_resultado.Text = "Rechazado";
                t_resultado.BackColor = Color.Red;

                btn_ok.Enabled = false;

                btn_aprobar.Enabled = false;
                btn_aprobado.Enabled = false;
                btn_rechazar_ri.Visible = false;

                btn_rechazar.Enabled = false;
                btn_aprobar_con_reparos.Enabled = false;

                btn_aprobar.Visible = false;
                btn_rechazar.Visible = false;
                btn_aprobar_con_reparos.Visible = false;

                //////////////////////////////////////////////////////////////

                btn_imprimir.Visible = true;
                btn_nuevo_reg.Visible = true;
                btn_excel.Visible = true;

            }

            if (cEstadoRegistro == "Q")
            {
                t_resultado.Text = "Aprobado con Reparos";
                t_resultado.BackColor = Color.Orange;

                btn_ok.Enabled = false;

                btn_aprobar.Enabled = false;
                btn_aprobado.Enabled = false;
                btn_rechazar_ri.Visible = false;

                btn_rechazar.Enabled = false;
                btn_aprobar_con_reparos.Enabled = false;

                btn_aprobar.Visible = false;
                btn_rechazar.Visible = false;
                btn_aprobar_con_reparos.Visible = false;

                //////////////////////////////////////////////////////////////

                btn_imprimir.Visible = true;
                btn_nuevo_reg.Visible = true;
                btn_excel.Visible = true;

            }

        }

        private void btn_aprobar_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            if (cbb_bloqueo.SelectedIndex > 0)
            {
                MessageBox.Show("Se ha seleccionado un motivo de bloqueo, solo puede bloquear el RI, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            string cCodAtr, cCalibre;

            cCodAtr = "";
            cCalibre = "";

            try
            {
                cCodAtr = Grid1[1, 1].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            if (cCodAtr != "")
            {
                if ((cCodAtr.Substring(0, 2).ToUpper() == "PA") || (cCodAtr.Substring(0, 2).ToUpper() == "PB") || (cCodAtr.Substring(0, 2).ToUpper() == "PD") || (cCodAtr.Substring(0, 2).ToUpper() == "PQ") )
                {
                    for (int i = 0; i <= Grid1.RowCount - 1; i++)
                    {
                        cCodAtr = "";
                        cCalibre = "";

                        try
                        {
                            cCodAtr = Grid1[1, i].Value.ToString();
                        }
                        catch
                        {
                            cCodAtr = "";
                        }

                        try
                        {
                            cCalibre = Grid1[7, i].Value.ToString();
                        }
                        catch
                        {
                            cCalibre = "";
                        }

                        if (t_familia_codsubgrupo.Text == "PP")
                        {
                            if (cbb_caracteristicas.SelectedIndex > 0)
                            {
                                cCalibre = cbb_caracteristicas.Text;
                            }

                            if ((cCodAtr == "PA_1_002") || (cCodAtr == "PB_1_002") || (cCodAtr == "PD_1_002") || (cCodAtr == "PQ_1_002"))
                            {
                                if (cCalibre.Trim() == "")
                                {
                                    MessageBox.Show("Debe registrar un Calibre válido, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                break;
                            }

                        }

                    }

                }

            }

            string cCalibreNuez, cColorNuez;
            int nTipoAnalisis;

            cCalibreNuez = "";
            cColorNuez = "";
            nTipoAnalisis = 0;

            if (cbb_calibre.Visible == true)
            {
                try
                {
                    cCalibreNuez = cbb_calibre.SelectedValue.ToString();
                }
                catch
                {
                    cCalibreNuez = "";
                }

            }

            if (cbb_color.Visible == true)
            {
                try
                {
                    cColorNuez = cbb_color.SelectedValue.ToString();
                }
                catch
                {
                    cColorNuez = "";
                }

            }

            if (cbb_TipoAnalisis.Visible == true)
            {
                try
                {
                    nTipoAnalisis = Convert.ToInt32(cbb_TipoAnalisis.SelectedValue.ToString());
                }
                catch
                {
                    nTipoAnalisis = 0;
                }

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

                ////////////////////////////////////////////////
                /// Determino el resultado del registro 
                /// 

                string mensaje, cEstado_de_Finalizacion;

                cEstado_de_Finalizacion = "";

                if (btn_aprobado.Visible == false)
                {
                    if (t_resultado_previo.Text == "Aprobado")
                    {
                        cEstado_de_Finalizacion = "A";

                    }

                    if (t_resultado_previo.Text == "Rechazado")
                    {
                        cEstado_de_Finalizacion = "R";

                    }

                    if (t_resultado_previo.Text == "Aprobado con Reparos")
                    {
                        cEstado_de_Finalizacion = "Q";

                    }

                }
                else
                {
                    if (t_resultado_previo_extra.Text == "Aprobado")
                    {
                        cEstado_de_Finalizacion = "A";

                    }

                    if (t_resultado_previo_extra.Text == "Rechazado")
                    {
                        cEstado_de_Finalizacion = "R";

                    }

                    if (t_resultado_previo_extra.Text == "Aprobado con Reparos")
                    {
                        cEstado_de_Finalizacion = "Q";

                    }

                }

                if (cEstado_de_Finalizacion == "")
                {
                    MessageBox.Show("No existe un Resultado Preliminar Válido, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////

                string UsuarioSap, ClaveSap;

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

                ///////////////////////////////////////////////////
                // Validaciones para Finalizar

                if (t_itemcode_d.Text != "")
                {

                    if (t_itemcode_d.Text.Substring(3, 3) == "NUE")
                    {

                        string cCodigoValidacion_SE;

                        cCodigoValidacion_SE = "";

                        //////////////////////////////////////////////////////
                        // NUEZ - Valido que se defina un calibre para cracker 

                        if (t_tipo_proceso.Text != "")
                        {

                            if (t_tipo_proceso.Text.Substring(0, 3) != "NCC")
                            {

                                if (t_tipo_proceso.Text.Substring(0, 7) == "Cracker")
                                {

                                    try
                                    {
                                        cCodigoValidacion_SE = cbb_calibre.SelectedValue.ToString();
                                    }
                                    catch
                                    {
                                        cCodigoValidacion_SE = "";
                                    }

                                    if (cCodigoValidacion_SE == "")
                                    {
                                        MessageBox.Show("Debe seleccionar un Calibre válido, opción Cancelada", "Registro de inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }

                                    t_resultado_previo.Text = "Aprobado";
                                    cEstado_de_Finalizacion = "A";

                                }

                                if (t_tipo_proceso.Text.Substring(0, 6) == "Sorter")
                                {
                                    try
                                    {
                                        cCodigoValidacion_SE = cbb_color.SelectedValue.ToString();
                                    }
                                    catch
                                    {
                                        cCodigoValidacion_SE = "";
                                    }

                                    if (cCodigoValidacion_SE == "")
                                    {
                                        MessageBox.Show("Debe seleccionar un Color válido, opción Cancelada", "Registro de inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }

                                    t_resultado_previo.Text = "Aprobado";
                                    cEstado_de_Finalizacion = "A";

                                }

                            }

                        }

                    }

                    ////////////////////////////////////////////////////////////
                    // ALMENDRAS - Valido que el calibre sea el mismo del código

                    if (t_itemcode_d.Text.Substring(3, 6) == "ALM.PT")
                    {

                        string cCalibre_PT;

                        cCalibre_PT = t_itemname_d.Text.Substring(t_itemname_d.Text.Length - 5 , 5);

                        if (cCalibre_PT == "CCIÓN")
                        {
                            cCalibre_PT = cCalibre;

                        }

                        if (cCalibre_PT == "L 40+")
                        {
                            cCalibre_PT = "40+";

                        }

                        if (cCalibre_PT != "")
                        {

                            try
                            {
                                if (cCalibre_PT.Substring(2) == "40+")
                                {
                                    cCalibre_PT = "40+";

                                }

                            }
                            catch
                            {

                            }

                            try
                            {
                                if (cCalibre_PT.Substring(2) == "40 +")
                                {
                                    cCalibre_PT = "40+";

                                }

                            }
                            catch
                            {

                            }


                        }

                        if (cCalibre_PT != cCalibre)
                        {

                            MessageBox.Show("El calibre no corresponde al producto, el calibre correcto es: " + cCalibre_PT + ", opción Cancelada", "Registro de inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            string cSupervisor = "NO";

                            VariablesGlobales.glb_User_Code_Autorizacion = "";

                            frmLoginSupervisor f5 = new frmLoginSupervisor();
                            DialogResult res5 = f5.ShowDialog();

                            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
                            {
                                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Registro de inspección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }

                            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
                            {

                                clsMaestros objproducto1 = new clsMaestros();
                                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                                DataTable dTable1 = new DataTable();
                                dTable1 = objproducto1.cResultado;

                                try
                                {
                                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                                }
                                catch
                                {
                                    cSupervisor = "NO";

                                }

                            }

                            if (cSupervisor == "NO")
                            {
                                return;
                            }

                        }

                    }

                }

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Finalizar el Registro de Inspección", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ////////////////////////////////////////////////
                    /// Finalizado el registro de Inspección
                    /// 

                    VariablesGlobales.glb_id_calidad = nDocEntry;
                    VariablesGlobales.glb_id_romana = 0;
                    VariablesGlobales.glb_LineId = int.Parse(t_lineid.Text);
                    VariablesGlobales.glb_Object = t_object.Text;

                    string cAplica;

                    cAplica = "Y";

                    if (t_resultado_previo.Text == "Rechazado")
                    {

                        cAplica = "N";

                        if (t_tipo_proceso.Text != "Prelimpia & Cracker")
                        {

                            mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap , ClaveSap);

                            if (mensaje == "Error de Conexión")
                            {
                                Thread.Sleep(300);

                                mensaje = "";
                                mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                Thread.Sleep(500);

                                mensaje = "";
                                mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                MessageBox.Show(mensaje, "ERROR: No se ha podido cambiar el estado del lote", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                if (mensaje != "")
                                {
                                    MessageBox.Show(mensaje, "ERROR: No se ha podido cambiar el estado del lote", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }

                            }

                            if (mensaje == "")
                            {
                                cAplica = "Y";

                            }

                        }

                    }
                    else
                    {
                        if (t_status_lote.Text != "Liberado")
                        {
                            try
                            {
                                mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "N", UsuarioSap, ClaveSap);

                                if (mensaje == "Error de Conexión")
                                {
                                    Thread.Sleep(300);

                                    mensaje = "";
                                    mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "N", UsuarioSap, ClaveSap);

                                }

                                if (mensaje == "Error de Conexión")
                                {
                                    Thread.Sleep(500);

                                    mensaje = "";
                                    mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "N", UsuarioSap, ClaveSap);

                                }

                                if (mensaje == "Error de Conexión")
                                {
                                    MessageBox.Show(mensaje, "ERROR: No se ha podido cambiar el estado del lote", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    if (mensaje != "")
                                    {
                                        MessageBox.Show(mensaje, "ERROR: No se ha podido cambiar el estado del lote", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }

                                }

                                if (mensaje == "")
                                {
                                    cAplica = "Y";

                                }

                            }
                            catch
                            {

                            }

                        }

                    }

                    if (cAplica == "Y")
                    {

                        mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, cEstado_de_Finalizacion, UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, cCalibreNuez, cColorNuez, nTipoAnalisis, "", "S", "", "");

                        if (mensaje == "Y")
                        {
                            MessageBox.Show("Registro Finalizado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    frmCalidadPPA6_Load(sender, e);

                    //carga_datos_calidad();

                }

            }

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int nLinea;

                nLinea = 1;

                oSheet.get_Range("c1", "c1").Font.Size = 16;
                oSheet.get_Range("c1", "c1").Font.Bold = true;
                oSheet.Cells[nLinea, 3] = "Registro de Inspección";

                oSheet.get_Range("c4", "c8").Font.Bold = true;
                oSheet.get_Range("f4", "f8").Font.Bold = true;

                nLinea += 3;
                oSheet.Cells[nLinea, 2] = "Especie:";
                oSheet.Cells[nLinea, 3] = t_itemname_d.Text;

                oSheet.Cells[nLinea, 5] = "Variedad:";
                oSheet.Cells[nLinea, 6] = t_variedad.Text;

                nLinea += 1;
                oSheet.Cells[nLinea, 2] = "Lote:";
                oSheet.Cells[nLinea, 3] = t_lote.Text;

                oSheet.Cells[nLinea, 5] = "Proceso:";
                oSheet.Cells[nLinea, 6] = t_tipo_proceso.Text;

                nLinea += 1;
                oSheet.Cells[nLinea, 2] = "Cantidad:";
                oSheet.Cells[nLinea, 3] = t_cant_prod.Text;

                oSheet.Cells[nLinea, 5] = "Bodega:";
                oSheet.Cells[nLinea, 6] = t_WhsCode.Text;

                nLinea += 1;
                oSheet.Cells[nLinea, 2] = "Calibre:";
                oSheet.Cells[nLinea, 3] = cbb_calibre.Text;

                oSheet.Cells[nLinea, 5] = "Color:";
                oSheet.Cells[nLinea, 6] = cbb_color.Text;

                nLinea += 1;
                oSheet.Cells[nLinea, 2] = "Resultado:";
                oSheet.Cells[nLinea, 3] = t_resultado.Text;

                nLinea = 10;
                //Add table headers going cell by cell.

                oSheet.get_Range("b" + nLinea, "i" + nLinea).Font.Bold = true;

                oSheet.Cells[nLinea, 2] = Grid1.Columns[1].HeaderText;
                oSheet.Cells[nLinea, 3] = Grid1.Columns[2].HeaderText;
                oSheet.Cells[nLinea, 4] = Grid1.Columns[3].HeaderText;
                oSheet.Cells[nLinea, 5] = Grid1.Columns[5].HeaderText;
                oSheet.Cells[nLinea, 6] = Grid1.Columns[6].HeaderText;
                oSheet.Cells[nLinea, 7] = Grid1.Columns[7].HeaderText;
                oSheet.Cells[nLinea, 8] = Grid1.Columns[8].HeaderText;

                nLinea += 1;

                //Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("a2", "g7").Font.Bold = true;
                //oSheet.get_Range("b7", "g7").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    oSheet.Cells[nLinea, 2] = Grid1[1, i].Value.ToString();
                    oSheet.Cells[nLinea, 3] = Grid1[2, i].Value.ToString();
                    oSheet.Cells[nLinea, 4] = Grid1[3, i].Value.ToString();
                    oSheet.Cells[nLinea, 5] = Grid1[5, i].Value.ToString();
                    oSheet.Cells[nLinea, 6] = Grid1[6, i].Value.ToString();
                    oSheet.Cells[nLinea, 7] = Grid1[7, i].Value.ToString();
                    oSheet.Cells[nLinea, 8] = Grid1[8, i].Value.ToString();

                    nLinea += 1;

                }

                oSheet.get_Range("b1", "i" + nLinea).Font.Size = 10;
                oRng = oSheet.get_Range("b1", "i" + nLinea);
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                //DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
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
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Imprime_etiqueta_adhesiva();

            VariablesGlobales.glb_DocEntry = nDocEntry;

            frmReporteProduccion f2 = new frmReporteProduccion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }
        private void Imprime_etiqueta_adhesiva()
        {
            string cImpresoraEtiqueta;

            cImpresoraEtiqueta = "";

            try
            {
                cImpresoraEtiqueta = ConfigurationManager.AppSettings.Get("Print_Etiquetado");
            }
            catch
            {
                cImpresoraEtiqueta = "";

            }

            //cImpresoraEtiqueta = "\\scl-hdv-disp9" & "\" & "ZDesigner GK420t";

            if (cImpresoraEtiqueta == "")
            {
                return;
            }

            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                Font Font_CodigoBarra = new Font("Code 3 de 9", 44);
                Font Font_Titulo = new Font("Consolas", 12, FontStyle.Bold);
                Font Font_Cuerpo = new Font("Consolas", 40, FontStyle.Bold);

                SolidBrush br = new SolidBrush(Color.Black);

                e1.Graphics.DrawString("OF: " + t_NumOF.Text, Font_Titulo, br, 65, 30);

                e1.Graphics.DrawString("*" + t_lote.Text + "* ", Font_CodigoBarra, br, 62, 50);

                e1.Graphics.DrawString(t_lote.Text, Font_Cuerpo, br, 65, 110);

            };

            try
            {
                p.PrinterSettings.PrinterName = cImpresoraEtiqueta;
                p.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 500, 0, 500);

                if (p.PrinterSettings.IsValid)
                {
                    p.Print();
                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }

        }

        private void cbb_TipoAnalisis_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txt_tipo_analisis_control.Text != "")
            {
                return;
            }

            if (Grid1.RowCount == 0)
            {
                return;
            }

            int nTipoAnalisis, nTipoAnalisis_Actual;

            try
            {
                nTipoAnalisis = Convert.ToInt32(cbb_TipoAnalisis.SelectedValue.ToString());
            }
            catch
            {
                nTipoAnalisis = 0;
            }

            ////////////////////////////

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

            nTipoAnalisis_Actual = 0;

            clsCalidad objproducto = new clsCalidad();
            objproducto.cls_Consulta_Registro_Inspeccion(nDocEntry);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nTipoAnalisis_Actual = Convert.ToInt32(dTable.Rows[0]["CodTipoAnalisis"].ToString());
            }
            catch
            {
                nTipoAnalisis_Actual = 0;
            }

            if (cbb_TipoAnalisis.Visible == true)
            {

                if (nTipoAnalisis != nTipoAnalisis_Actual)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show("Esta Seguro de modificar el Tipo de Análisis", "Registro de Inspección ", buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        txt_tipo_analisis_control.Text = "X";

                        clsCalidad objproducto1 = new clsCalidad();
                        objproducto1.cls_SAPB1_ORCALA1(nDocEntry, nTipoAnalisis);

                        carga_datos_calidad();

                        txt_tipo_analisis_control.Text = "";

                    }

                }

            }


        }

        private void lnk_liberar_finalizacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string cSupervisor = "NO";

            VariablesGlobales.glb_User_Code_Autorizacion = "";

            frmLoginSupervisor f5 = new frmLoginSupervisor();
            DialogResult res5 = f5.ShowDialog();

            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
            {
                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                }
                catch
                {
                    cSupervisor = "NO";

                }

            }

            if (cSupervisor == "NO")
            {
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("El Registro de inspección NO ha sido grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de liberar el Registro de Inspección", "Registro de Inspección ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string mensaje;
                int UserId;

                UserId = VariablesGlobales.glb_User_id;

                mensaje = clsCalidad.SAPB1_ORCALv1(nDocEntry, "L", UserId);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Actualizado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                carga_inicial();

            }

        }

        private void lnk_borrar_ri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string cSupervisor = "NO";

            VariablesGlobales.glb_User_Code_Autorizacion = "";

            frmLoginSupervisor f5 = new frmLoginSupervisor();
            DialogResult res5 = f5.ShowDialog();

            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
            {
                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                }
                catch
                {
                    cSupervisor = "NO";

                }

            }

            if (cSupervisor == "NO")
            {
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("El Registro de inspección NO ha sido grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar el Registro de Inspección", "Registro de Inspección ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string mensaje;
                int UserId = VariablesGlobales.glb_User_id;

                mensaje = clsCalidad.SAPB1_ORCALv1(nDocEntry, "E", UserId);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Eliminado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Close();

            }

        }

        private void cbb_PQ_9_099_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////
            //// Calculo los totales por grupo

            //determino_totales_en_grupos();

            pinto_grupos();

        }

        private void cbb_PQ_9_100_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////
            //// Calculo los totales por grupo

            //determino_totales_en_grupos();

            pinto_grupos();

        }

        private void cbb_PQ_9_101_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////
            //// Calculo los totales por grupo

            //determino_totales_en_grupos();

            pinto_grupos();

        }

        private void btn_nuevo_reg_Click(object sender, EventArgs e)
        {
            int nDocEntry_Old, nDocEntry_New; 

            t_carga_combo.Text = "";

            btn_aprobado.Visible = false;
            btn_aprobar.Visible = false;
            btn_rechazar_ri.Visible = false;

            btn_rechazar.Visible = false;
            btn_aprobar_con_reparos.Visible = false;

            btn_nuevo_reg.Visible = false;
            btn_imprimir.Visible = false;
            btn_excel.Visible = false;

            label19.Visible = false;
            t_resultado_previo.Visible = false;

            lbl_TipoAnalisis.Visible = false;
            cbb_TipoAnalisis.Visible = false;

            try
            {
                nDocEntry_Old = Convert.ToInt32(t_id_calidad.Text);

            }
            catch
            {
                nDocEntry_Old = 0;

            }

            //Grid1.Rows.Clear();
            Grid3.Rows.Clear();
            //Grid4.Rows.Clear();

            //lbl_sellado_bolsas.Visible = false;
            cbb_sellado_bolsas.Visible = false;

            txt_tipo_analisis_control.Text = "X";

            VariablesGlobales.glb_id_calidad = 0;

            t_id_calidad.Text = "0";
            t_doc_entry.Text = "0";

            t_object.Text = VariablesGlobales.glb_Object;
            t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
            t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
            t_lote.Text = VariablesGlobales.glb_Lote.ToString();

            label19.Visible = true;
            t_resultado_previo.Visible = true;

            //carga_datos_produccion();

            Application.DoEvents();
            Application.DoEvents();

            grabar();

            Application.DoEvents();
            Application.DoEvents();

            try
            {
                nDocEntry_New = Convert.ToInt32(t_id_calidad.Text);

            }
            catch
            {
                nDocEntry_New = 0;

            }

            String mensaje = clsCalidad.SAPB1_ORCALA2(nDocEntry_Old, nDocEntry_New);

            txt_tipo_analisis_control.Text = "X";

            carga_datos_calidad();

            txt_tipo_analisis_control.Text = "";

            btn_ok.Enabled = true;
            btn_aprobar.Enabled = true;

        }

        private void btn_rechazar_ri_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            if (cbb_bloqueo.SelectedIndex <= 0)
            {
                MessageBox.Show("Esta bloqueando el RI y no ha seleccionado un motivo, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                nDocEntry = 0;

            }

            string cCodAtr, cCalibre;

            cCodAtr = "";
            cCalibre = "";

            try
            {
                cCodAtr = Grid1[1, 1].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            if (cCodAtr != "")
            {
                if ((cCodAtr.Substring(0, 2).ToUpper() == "PA") || (cCodAtr.Substring(0, 2).ToUpper() == "PB") || (cCodAtr.Substring(0, 2).ToUpper() == "PD") || (cCodAtr.Substring(0, 2).ToUpper() == "PQ"))
                {
                    for (int i = 0; i <= Grid1.RowCount - 1; i++)
                    {
                        cCodAtr = "";
                        cCalibre = "";

                        try
                        {
                            cCodAtr = Grid1[1, i].Value.ToString();
                        }
                        catch
                        {
                            cCodAtr = "";
                        }

                        try
                        {
                            cCalibre = Grid1[7, i].Value.ToString();
                        }
                        catch
                        {
                            cCalibre = "";
                        }

                        if (t_familia_codsubgrupo.Text == "PP")
                        {
                            if (cbb_caracteristicas.SelectedIndex >= 0)
                            {
                                cCalibre = cbb_caracteristicas.Text;
                            }

                            if ((cCodAtr == "PA_1_002") || (cCodAtr == "PB_1_002") || (cCodAtr == "PD_1_002") || (cCodAtr == "PQ_1_002"))
                            {
                                if (cCalibre.Trim() == "")
                                {
                                    MessageBox.Show("Debe registrar un Calibre válido, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                break;
                            }

                        }

                    }

                }

            }

            string cItemCode, cItemName, cWhsCode;
            string cWhsDest, cNumCon, cLote;
            string cFecha, cUM, Comments;
            string cObjetc, UserCode, cMotivoBloqueo;
            string mensaje;

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
            cMotivoBloqueo = "";

            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            string cCalibreNuez, cColorNuez;
            int nTipoAnalisis;

            cCalibreNuez = "";
            cColorNuez = "";
            nTipoAnalisis = 0;

            if (cbb_calibre.Visible == true)
            {
                try
                {
                    cCalibreNuez = cbb_calibre.SelectedValue.ToString();
                }
                catch
                {
                    cCalibreNuez = "";
                }

            }

            if (cbb_color.Visible == true)
            {
                try
                {
                    cColorNuez = cbb_color.SelectedValue.ToString();
                }
                catch
                {
                    cColorNuez = "";
                }

            }

            if (cbb_TipoAnalisis.Visible == true)
            {
                try
                {
                    nTipoAnalisis = Convert.ToInt32(cbb_TipoAnalisis.SelectedValue.ToString());
                }
                catch
                {
                    nTipoAnalisis = 0;
                }

            }

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;

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

            try
            {
                cMotivoBloqueo = cbb_bloqueo.Text;

            }
            catch
            {
                cMotivoBloqueo = "";

            }
            
            t_resultado_previo.Text = "Rechazado";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Bloquear el Registro de Inspección", "Registro de Inspección ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                ////////////////////////////////////////////////
                /// Finalizado el registro de Inspección
                /// 

                mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "R", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, cCalibreNuez, cColorNuez, nTipoAnalisis, "", "S", "", cMotivoBloqueo);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Finalizado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                VariablesGlobales.glb_id_calidad = nDocEntry;
                VariablesGlobales.glb_id_romana = 0;
                VariablesGlobales.glb_LineId = int.Parse(t_lineid.Text);
                VariablesGlobales.glb_Object = t_object.Text;

                if (t_resultado_previo.Text == "Rechazado")
                {
                    //if (t_tipo_proceso.Text != "Prelimpia & Cracker")
                    {
                        mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                        if (mensaje == "Error de Conexión")
                        {
                            mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                        }

                        if (mensaje == "Error de Conexión")
                        {
                            Thread.Sleep(500);
                            mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote2(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                        }

                    }

                }

            }

            frmCalidadPPA6_Load(sender, e);

        }

        private void cbb_caracteristicas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Grid1.RowCount > 3)
            {
                string cCaracteristica;

                cCaracteristica = "";

                try
                {
                    cCaracteristica = cbb_caracteristicas.Text.ToString();

                }
                catch
                {
                    cCaracteristica = "";

                }

                if (cCaracteristica == "PNC")
                {
                    cbb_caracteristicas.Size = new System.Drawing.Size(50, 21);
                    cbb_PNC.Visible = true; 

                }
                else
                {
                    cbb_caracteristicas.Size = new System.Drawing.Size(177, 21);
                    cbb_PNC.Visible = false;

                }

            }

        }

        private void btn_aprobado_Click(object sender, EventArgs e)
        {

            t_resultado_previo_extra.Text = "Aprobado";
            t_resultado_previo.Text = "Aprobado";

            btn_aprobar_Click(sender, e);

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            carga_inicial();

        }

        private void btn_aprobar_con_reparos_Click(object sender, EventArgs e)
        {

            t_resultado_previo_extra.Text = "Aprobado con Reparos";
            t_resultado_previo.Text = "Aprobado con Reparos";

            btn_aprobar_Click(sender, e);

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            carga_inicial();

        }

        private void btn_rechazar_Click(object sender, EventArgs e)
        {

            t_resultado_previo_extra.Text = "Rechazado";
            t_resultado_previo.Text = "Rechazado";

            btn_aprobar_Click(sender, e);

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            carga_inicial();

        }

    }

}
