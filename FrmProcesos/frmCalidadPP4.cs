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
    public partial class frmCalidadPP4 : Form
    {
        public frmCalidadPP4()
        {
            InitializeComponent();
        }

        private void frmCalidadPP4_Load(object sender, EventArgs e)
        {

            t_carga_combo.Text = "";

            btn_aprobado.Visible = false;
            btn_aprobar.Visible = false;
            btn_rechazar.Visible = false;
            btn_aprobar_con_reparos.Visible = false;

            btn_nuevo_reg.Visible = false;
            btn_imprimir.Visible = false;
            btn_excel.Visible = false;

            label19.Visible = false;
            t_resultado_previo.Visible = false;

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            lbl_sellado_bolsas.Visible = false;
            cbb_sellado_bolsas.Visible = false;

            if (VariablesGlobales.glb_id_calidad == 0)
            {
                t_id_calidad.Text = "0";
                t_object.Text = VariablesGlobales.glb_Object;
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_lote.Text = VariablesGlobales.glb_Lote.ToString();

                label19.Visible = true;
                t_resultado_previo.Visible = true;

                carga_datos_produccion();

                totalizar_porcentaje_x_grupo("");

                lnk_liberar_finalizacion.Visible = false;
                lnk_borrar_ri.Visible = false;

            }
            else
            {
                t_id_calidad.Text = VariablesGlobales.glb_id_calidad.ToString();
                t_id_recepcion.Text = VariablesGlobales.glb_DocEntry.ToString();
                t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                t_object.Text = VariablesGlobales.glb_Object;

                carga_datos_calidad();

                lnk_liberar_finalizacion.Visible = true;
                lnk_borrar_ri.Visible = true;

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

            if (cTipoGrupo != "PP")
            {
                this.Size = new Size(823, 733);
            }
            else
            {
                this.Size = new Size(1135, 733);
            }

            string cTipoFruta_Combo;

            cTipoFruta_Combo = "";

            cbb_calibre.Visible = false;

            if ((t_tipo_proceso.Text == "NCC L1") || (t_tipo_proceso.Text == "NCC L2") || (t_tipo_proceso.Text == "Calibrado") || (t_tipo_proceso.Text == "Blanqueado + Calibrado") || (t_tipo_proceso.Text == "Blanqueado") || (t_tipo_proceso.Text == "Lavado") || (t_tipo_proceso.Text == "Lavado + Calibrado"))
            {
                cTipoFruta_Combo = "Nuez C/C";
            }

            //Partidura Manual
            if ((t_tipo_proceso.Text == "Cracker Nueces") || (t_tipo_proceso.Text == "Sorter 1") || (t_tipo_proceso.Text == "Sorter 2") || (t_tipo_proceso.Text == "Selección Mecanica") || (t_tipo_proceso.Text == "Secado") || (t_tipo_proceso.Text == "Desp & Secado") || (t_tipo_proceso.Text == "Conversion") )
            {
                cTipoFruta_Combo = "Nuez";

            }

            if (cTipoFruta_Combo != "Nuez")
            {
                if ((t_tipo_proceso.Text == "Agup. Sem. Elab") || (t_tipo_proceso.Text == "Limpieza Nueces") || (t_tipo_proceso.Text == "Selección Manual") || (t_tipo_proceso.Text == "Partidura Manual"))
                {
                    cTipoFruta_Combo = "Nuez";

                }

            }

            if ((t_tipo_proceso.Text == "Calibrado Ciruelas") || (t_tipo_proceso.Text == "PT Sin Carozo"))
            {
                cTipoFruta_Combo = "Ciruela";
            }

            if (cTipoFruta_Combo != "")
            {

                //////////////////////////////////////
                // Esto se hace para el Calibre 

                cbb_calibre.Visible = true;
                label11.Visible = true;

                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consultar_Calibres_NuezMec(cTipoFruta_Combo);

                cbb_calibre.DataSource = objproducto.cResultado;
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

            ///////////////////////////////////////
            ///////////////////////////////////////
            // Detalle

            string cProceso, cVariedad, cCalibre;

            try
            {
                cProceso = t_tipo_proceso.Text;
            }
            catch
            {
                cProceso = "";
            }

            if (cProceso == "Sorter 1")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "Sorter 2")
            {
                cProceso = "Sorter";
            }

            if (cProceso == "NCC L1")
            {
                cProceso = "NCC L";
            }

            if (cProceso == "NCC L2")
            {
                cProceso = "NCC L";
            }

            cVariedad = "";
            cCalibre = "";

            int nCant_Lineas;
            double nMaximo;
            string cCode;

            string[] grilla;
            grilla = new string[30];

            nCant_Lineas = 0;
            cVariedad = t_variedad_mp.Text;
            cCalibre = t_calibre_mp.Text;
            //cVariedad = "Carmel";

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_ConsultaLista_Procesos_x_items_V4(cProceso, cVariedad, cCalibre);

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid4.Rows.Clear();

            nCant_Lineas = 0;

            for (int i = 0; i <= dTable2.Rows.Count - 1; i++)
            {

                try
                {
                    cCode = dTable2.Rows[i]["U_Comment"].ToString();
                }
                catch
                {
                    cCode = "";
                }

                try
                {
                    nMaximo = Convert.ToDouble(dTable2.Rows[i]["U_Maximo"].ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                grilla[0] = cCode;
                grilla[1] = nMaximo.ToString("N2");

                Grid4.Rows.Add(grilla);

                if (cCode != "")
                {
                    nCant_Lineas += 1;
                }

            }

            if (nCant_Lineas == 0)
            {
            
                clsCalidad objproducto8 = new clsCalidad();
                objproducto8.cls_ConsultaLista_Procesos_x_items_V4(cProceso, cVariedad, "");

                DataTable dTable8 = new DataTable();
                dTable8 = objproducto8.cResultado;

                Grid4.Rows.Clear();

                nCant_Lineas = 0;

                for (int i = 0; i <= dTable8.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCode = dTable8.Rows[i]["U_Comment"].ToString();
                    }
                    catch
                    {
                        cCode = "";
                    }

                    try
                    {
                        nMaximo = Convert.ToDouble(dTable8.Rows[i]["U_Maximo"].ToString());
                    }
                    catch
                    {
                        nMaximo = 0;
                    }

                    grilla[0] = cCode;
                    grilla[1] = nMaximo.ToString("N2");

                    Grid4.Rows.Add(grilla);

                    if (cCode != "")
                    {
                        nCant_Lineas += 1;
                    }

                }

            }

            if (nCant_Lineas == 0)
            {
                
                clsCalidad objproducto3 = new clsCalidad();
                objproducto3.cls_ConsultaLista_Procesos_x_items_V3(cProceso);

                DataTable dTable3 = new DataTable();
                dTable3 = objproducto3.cResultado;

                Grid4.Rows.Clear();

                for (int i = 0; i <= dTable3.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCode = dTable3.Rows[i]["U_Comment"].ToString();
                    }
                    catch
                    {
                        cCode = "";
                    }

                    nMaximo = 0;

                    grilla[0] = cCode;
                    grilla[1] = nMaximo.ToString("N2");

                    Grid4.Rows.Add(grilla);

                }

            }

            ///////////////////////////////////////
            ///////////////////////////////////////

            Calcula_Resultado_Previo_Analisis();

            ///////////////////////////////////////
            ///////////////////////////////////////
            // Combo de sellado

            lbl_sellado_bolsas.Visible = false;
            cbb_sellado_bolsas.Visible = false;

            try
            {
                cTipoGrupo = Grid1[1, 0].Value.ToString().Substring(0, 2);
            }
            catch
            {
                cTipoGrupo = "";
            }

            if (cTipoGrupo == "PE")
            {

                lbl_sellado_bolsas.Visible = true;
                cbb_sellado_bolsas.Visible = true;

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
            objproducto.cls_Consulta_Avance_x_id(DocEntry, LineId, t_lote.Text, t_object.Text);

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

            if (t_object.Text == "20")
            {
                t_tipo_proceso.Text = VariablesGlobales.glb_CodeProceso;

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

                lbl_disponible.Visible = true;
                cbb_disponible.Visible = true;

                cbb_disponible.SelectedIndex = 0;

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

            string cCode_D, cNomAtributo_D, cUM_D;
            string cLineId_D, cGrupoAtr_D, cGrupoAtr_old_D;
            string cLocked1, cLocked2;

            //int nStandAtr_D;
            double nHasta_D, nDesde_D;
            double nHasta_D1, nDesde_D1;
            double nHasta_D2, nDesde_D2;

            cCalibre_Referencia = "";

            clsCalidad objproducto2 = new clsCalidad();
            objproducto2.cls_Consulta_Atributos_PP_producto_V2(t_tipo_proceso.Text, cVariedad_Referencia, cCalibre_Referencia, t_variedad.Text.ToUpper());

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            Grid1.Rows.Clear();
            Grid3.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            cGrupoAtr_old_D = "";
            //nStandAtr_D = 0;

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
                //nStandAtr_D = 0;
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
                    cUM_D = dTable2.Rows[i]["U_UM"].ToString();
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

                grilla[0] = (i+1).ToString(); //cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
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

                grilla[7] = 0.ToString("N2");
                grilla[8] = 0.ToString("N2");

                grilla[10] = cGrupoAtr_D;

                Grid3.Rows.Add(grilla);

            }

            determino_totales_en_grupos();

            pinto_grupos();

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
            string cDisponible;

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
            t_status_lote.Text = "";

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

            try
            {
                cDisponible = dTable.Rows[0]["HDV_Disponible"].ToString();
            }
            catch
            {
                cDisponible = "";
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

                lbl_disponible.Visible = true;
                cbb_disponible.Visible = true;

                if (cDisponible == "Si")
                {
                    cbb_disponible.SelectedIndex = 0;
                }
                else
                {
                    cbb_disponible.SelectedIndex = 1;
                }

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cCode_D, cNomAtributo_D, cUM_D;
            string cLineId_D, cGrupoAtr_old_D;
            string cLocked1, cLocked2;

            double nMedicion_D, nStandar_D;

            //int nStandAtr_D;
            double nHasta_D, nDesde_D;
            double nHasta_D1, nDesde_D1;
            double nHasta_D2, nDesde_D2;

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
                    cLocked1 = dTable.Rows[i]["U_Locked1"].ToString();
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
                    cLocked2 = dTable.Rows[i]["U_Locked2"].ToString();
                }
                catch
                {
                    cLocked2 = "";
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
                                //-6 - PNC 5 
                                //-7 - Hongo 7
                                //-8 - Pierna de Aire
                                //-9 - Gemelas 9

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
                                //-6 - PNC 6
                                //-7 - Hongo 7 
                                //-8 - Pierna de Aire
                                //-9 - Gemelas 9

                                cbb_caracteristicas.SelectedIndex = Convert.ToInt32(nMedicion_D) * -1;
                                nMedicion_D = 0;

                            }
                        }
                    }

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

                if (nDocEntry > 0)
                {
                    grilla[5] = nDesde_D.ToString("N2");
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

                grilla[7] = nMedicion_D.ToString("N2");
                grilla[8] = nMedicion_D.ToString("N2");

                grilla[10] = cGrupoAtr_old_D;

                if (cCode_D == "PE_7_006")
                {
                    cbb_sellado_bolsas.SelectedIndex = 0;

                    if (nMedicion_D == 1)
                    {
                        cbb_sellado_bolsas.SelectedIndex = 1;

                    }

                }
                else
                {
                    Grid3.Rows.Add(grilla);

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
            //// Calculo los totales por grupo

            determino_totales_en_grupos();

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
                    totalizar_grupos(cCodAtr);
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
                    totalizar_porcentaje_x_grupo(cCodAtr);
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

            totalizar_grupos("");

            //////////////////////////////////////////////////
            //// Valido si tiene permisos para aprobar

            t_resultado.Text = "En Proceso";
            t_resultado.BackColor = Color.Yellow;

            string TipoProducto;

            TipoProducto = "S";

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
                    }
                    else
                    {
                        btn_aprobado.Visible = true;
                        btn_rechazar.Visible = true;
                        btn_aprobar_con_reparos.Visible = true;

                        if (t_tipo_proceso.Text == "Secado")
                        {
                            btn_aprobar_con_reparos.Visible = false;
                        }

                    }

                    label19.Visible = true;
                    t_resultado_previo.Visible = true;

                }

            }

            if (cEstadoRegistro == "A")
            {
                t_resultado.Text = "Aprobado";
                t_resultado.BackColor = Color.Green;

                btn_ok.Enabled = false;

                btn_aprobar.Enabled = false;
                btn_aprobado.Enabled = false;
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

            if (cEstadoRegistro == "R")
            {
                t_resultado.Text = "Rechazado";
                t_resultado.BackColor = Color.Red;

                btn_ok.Enabled = false;

                btn_aprobar.Enabled = false;
                btn_aprobado.Enabled = false;
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

        private void determino_totales_en_grupos()
        {

            int nFila;

            double nStandAtr_D, nDesde_D, nHasta_D;
            double nMedicion_D;

            string cGrupoAtr_old_D, cGrupoAtr_D, cCaptionGrupo_D;
            //string cError;

            string[] grilla;

            grilla = new string[30];

            cGrupoAtr_old_D = "";
            //cError = "";

            try
            {
                cGrupoAtr_old_D = Grid3[10, 0].Value.ToString();
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
                    cGrupoAtr_D = Grid3[10, i].Value.ToString();
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

                if (grilla[1] == "PA_1_002" || grilla[1] == "PB_1_002" || grilla[1] == "PD_1_002")
                {
                    grilla[4] = "";
                    grilla[5] = "";
                    grilla[6] = "";
                    grilla[7] = "";

                }
                else
                {
                    grilla[4] = nStandAtr_D.ToString("N2");
                    grilla[5] = nDesde_D.ToString("N2");
                    grilla[6] = nHasta_D.ToString("N2");
                    grilla[7] = nMedicion_D.ToString("N2");

                }

                if (grilla[1] == "PA_1_001" || grilla[1] == "PA_1_002" || grilla[1] == "PB_1_001" || grilla[1] == "PB_1_002" || grilla[1] == "PD_1_001" || grilla[1] == "PD_1_002")
                {
                    grilla[8] = "";
                }
                else
                {
                    grilla[8] = 0.ToString("N2");
                }

                grilla[10] = cGrupoAtr_old_D;

                Grid1.Rows.Add(grilla);

                //cError = "";

                //if (nMedicion_D < nDesde_D)
                //{
                //    cError = "S";
                //}

                //if (nMedicion_D > nHasta_D)
                //{
                //    cError = "S";
                //}
                
                //if (nMedicion_D == 0)
                //{
                //    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                //}
                //else
                //{
                //    if (cError == "S")
                //    {
                //        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                //    }
                //    else
                //    {
                //        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                //    }

                //}if (nDesde_D == nHasta_D)
                //{
                //    //cError = "";
                //}

                Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                if (nMedicion_D > 0)
                {
                    if (nMedicion_D <= nDesde_D)
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                    }

                }

                if (nMedicion_D > 0)
                {
                    if ((nMedicion_D > nDesde_D) && (nMedicion_D <= nHasta_D))
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\bullet_error.png");
                    }

                }

                if (nMedicion_D > nHasta_D)
                {
                    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                }

                nFila = nFila + 1;

                try
                {
                    cGrupoAtr_D = Grid3[10, i + 1].Value.ToString();
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
                    grilla[8] = "";

                    grilla[10] = cGrupoAtr_old_D;

                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

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

            grilla[0] = "-1.1";
            grilla[1] = "";
            grilla[2] = "Total Registro de Inspección";
            grilla[3] = "";
            grilla[4] = "";
            grilla[5] = "";
            grilla[6] = "";
            grilla[7] = "";
            grilla[8] = "";

            grilla[10] = cGrupoAtr_old_D;

            Grid1.Rows.Add(grilla);

            try
            {
                Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

            }
            catch
            {

            }

            ////////////////////////////////////////////////////
            //// Para el grupo PP genero un resumen adicional

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
                Grid2.Rows.Clear();

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "EL";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "L";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "LA";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "A";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "Amarillas Claras";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "Amarillas Oscuras";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

                grilla[0] = "-2";
                grilla[1] = "";
                grilla[2] = "Color Claro";
                grilla[3] = 0.ToString("N2");

                Grid2.Rows.Add(grilla);

            }

        }

        private void pinto_grupos()
        {

            double nLineId;
            string cCodAtributo;
            double nStandard;

            ///////////////////////////////////////////////////////
            ////////// Pinto los totales generales

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
                    cCodAtributo = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cCodAtributo = "";
                }

                if (nLineId == -1)
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightGray;
                    }

                }

                if (nLineId == -1.1)
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightBlue;
                    }

                }

                if (cCodAtributo == "PB_1_002")
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.Yellow;
                    }

                }

                try
                {
                    nStandard = double.Parse(Grid1[4, i].Value.ToString());
                }
                catch
                {
                    nStandard = 0;
                }

                if (nStandard == 0)
                {
                    if (cCodAtributo != "")
                    {
                        if (Grid1[1, i].Style.BackColor == Color.Orange)
                        {
                            Grid1[1, i].Style.BackColor = Color.Empty;
                            Grid1[2, i].Style.BackColor = Color.Empty;

                        }
                    }
                }

                if (nStandard == 1)
                {
                    Grid1[1, i].Style.BackColor = Color.Orange;
                    Grid1[2, i].Style.BackColor = Color.Orange;
                }

            }

            ///////////////////////////////////////////////////////
            ////////// Pinto los porcentajes

            int nColor_x;
            string cCodAtributoGeneral;

            nColor_x = 0;

            try
            {
                cCodAtributoGeneral = Grid1[10, 0].Value.ToString();
            }
            catch
            {
                cCodAtributoGeneral = "";
            }

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

                if (cCodAtributoGeneral != Grid1[10, i].Value.ToString())
                {
                    cCodAtributoGeneral = Grid1[10, i].Value.ToString();
                    nColor_x += 1;

                }

                if (nLineId >= 0)
                {
                    if (nColor_x == 0)
                    {
                        Grid1[8, i].Style.BackColor = Color.Yellow;
                    }

                    if (nColor_x == 1)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightSalmon;
                    }

                    if (nColor_x == 2)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightPink;
                    }

                    if (nColor_x == 3)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightGreen;
                    }

                    if (nColor_x == 4)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightBlue;
                    }

                    if (nColor_x == 5)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightCoral;
                    }

                    if (nColor_x == 6)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightGray;
                    }

                    if (nColor_x == 7)
                    {
                        Grid1[8, i].Style.BackColor = Color.LightSteelBlue;
                    }

                }

            }


            ////////////////////////////////////////////////////////////
            ////////// Pinto los Atributos relevantes para la aprobacion

            //for (int i = 0; i <= Grid1.RowCount - 1; i++)
            //{
            //    nLineId = 0;

            //    try
            //    {
            //        cCodAtributoGeneral = Grid1[1, i].Value.ToString();
            //    }
            //    catch
            //    {
            //        cCodAtributoGeneral = "";
            //    }

            //    if ((cCodAtributoGeneral == "PC_3_006") || (cCodAtributoGeneral == "PC_3_007") || (cCodAtributoGeneral == "PC_5_001") || (cCodAtributoGeneral == "PC_5_002"))
            //    {
            //        Grid1[1, i].Style.BackColor = Color.Yellow;
            //        Grid1[2, i].Style.BackColor = Color.Yellow;
            //    }

            //}

        }

        private void totalizar_porcentaje_x_grupo(string cGrupoAtr)
        {
            string cTipoGrupo;

            try
            {
                cTipoGrupo = Grid1[1, 0].Value.ToString().Substring(0, 2);
            }
            catch
            {
                cTipoGrupo = "";
            }

            double nTotalGrupo, nValor, nPorcentaje;
            int nLineId;
            string cAtributoRef, cCodAtr, cSinPorcentaje;
            double nSubtotalColor, nTotalGrupo2;

            double nMP_Nuez_Calibre, nMP_Nuez_AColor;

            ////////////////////////////////////////////////////
            //// Calculo los valores por grupo y los actualizo

            nTotalGrupo = 0;
            nTotalGrupo2 = 0;
            nSubtotalColor = 0;
            cSinPorcentaje = "";

            nMP_Nuez_Calibre = 0;
            nMP_Nuez_AColor = 0;


            if (cTipoGrupo == "PB" || cTipoGrupo == "PA" || cTipoGrupo == "PD" || cTipoGrupo == "PE" || cTipoGrupo == "PF" || cTipoGrupo == "PL" || cTipoGrupo == "PK")
            {

                if (cTipoGrupo != "PE")
                {
                    ///////////////////////////////////////////////////////
                    //// Para este grupo se calcula sobre el total general

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

                        if (nLineId < -1)
                        {
                            try
                            {
                                nTotalGrupo = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nTotalGrupo = 0;
                            }

                            break;

                        }

                    }
                }
                else
                {
                    ///////////////////////////////////////////////////////
                    //// Para este grupo se calcula sobre el total general

                    nTotalGrupo = 0;
                    nTotalGrupo2 = 0;

                    for (int x = 0; x <= Grid1.RowCount - 1; x++)
                    {

                        try
                        {
                            nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        try
                        {
                            cAtributoRef = Grid1[10, x].Value.ToString();
                        }
                        catch
                        {
                            cAtributoRef = "";
                        }

                        try
                        {
                            nLineId = Convert.ToInt32(Grid1[0, x].Value.ToString());
                        }
                        catch
                        {
                            nLineId = -2;
                        }

                        if ((nValor > 0) && (nLineId == -1))
                        {
                            if ((cAtributoRef == "% Mitades") || (cAtributoRef == "% Cuartos") || (cAtributoRef == "% Cuartillos"))
                            {
                                try
                                {
                                    nTotalGrupo += nValor;
                                }
                                catch
                                {
                                    nTotalGrupo = 0;
                                }

                            }

                            if (cAtributoRef == "Total de Daños")
                            {
                                try
                                {
                                    nTotalGrupo2 += nValor;
                                }
                                catch
                                {
                                    nTotalGrupo2 = 0;
                                }

                            }


                            //if (cGrupoAtr != "Total de Daños")
                            //{
                            //    if ((cAtributoRef == "% Mitades") || (cAtributoRef == "% Cuartos") || (cAtributoRef == "% Cuartillos"))
                            //    {
                            //        try
                            //        {
                            //            nTotalGrupo += nValor;
                            //        }
                            //        catch
                            //        {
                            //            nTotalGrupo = 0;
                            //        }

                            //    }

                            //}
                            //else
                            //{
                            //    try
                            //    {
                            //        nTotalGrupo += nValor;
                            //    }
                            //    catch
                            //    {
                            //        nTotalGrupo = 0;
                            //    }

                            //}


                        }

                    }

                }

                ///////////////////////////////////////////////////////
                //// Para este grupo se calcula sobre el total general

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
                        cCodAtr = Grid1[1, x].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (Grid1[1, x].Value.ToString() == "PE_6_004")
                        Grid1[1, x].Value = Grid1[1, x].Value.ToString();


                    // if (nLineId >= 0)
                    {
                        try
                        {
                            nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        nPorcentaje = 0;

                        if (cTipoGrupo != "PE")
                        {

                            if (nTotalGrupo > 0)
                            {
                                nPorcentaje = nValor / nTotalGrupo * 100;
                            }
                            else
                            {
                                nPorcentaje = 0;
                            }

                        }
                        else
                        {

                            if ((cAtributoRef == "% Mitades") || (cAtributoRef == "% Cuartos") || (cAtributoRef == "% Cuartillos"))
                            {
                                if (nTotalGrupo > 0)
                                {
                                    nPorcentaje = nValor / nTotalGrupo * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }

                            if (cAtributoRef == "Total de Daños")
                            {
                                if (nTotalGrupo > 0)
                                {
                                    nPorcentaje = nValor / (nTotalGrupo+ nTotalGrupo2) * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }


                        }

                        cSinPorcentaje = "";

                        if (cCodAtr == "PA_1_001" || cCodAtr == "PA_1_002" || cCodAtr == "PA_1_002.5")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PB_1_001" || cCodAtr == "PB_1_002")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PD_1_001" || cCodAtr == "PD_1_002")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PE_1_001" || cCodAtr == "PE_1_002" || cCodAtr == "PE_2_001" || cCodAtr == "PE_2_002" || cCodAtr == "PE_2_003" || cCodAtr == "PE_3_001")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PE_7_001" || cCodAtr == "PE_7_002" || cCodAtr == "PE_7_003" || cCodAtr == "PE_7_004" || cCodAtr == "PE_7_005" || cCodAtr == "PE_7_006")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PM_1_001" || cCodAtr == "PM_1_002" || cCodAtr == "PM_1_003" || cCodAtr == "PM_1_004" || cCodAtr == "PM_1_005" || cCodAtr == "PM_1_006" || cCodAtr == "PM_2_002" || cCodAtr == "PM_2_003" || cCodAtr == "PM_2_004")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cSinPorcentaje == "X")
                        {
                            Grid1[8, x].Value = "";
                        }
                        else
                        {
                            Grid1[8, x].Value = nPorcentaje.ToString("N2");
                        }

                    }

                }

            }

            if (cTipoGrupo == "PC" || cTipoGrupo == "PF" || cTipoGrupo == "PG" || cTipoGrupo == "PH" || cTipoGrupo == "PM")
            {
                ////////////////////////////////////////////////////////
                //// Para este grupo se calcula sobre el total del sub grupo

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
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    try
                    {
                        cCodAtr = Grid1[1, x].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    if (nLineId == -1)
                    {
                        if (cAtributoRef == "Total de Color")
                        {                            
                            try
                            {
                                nSubtotalColor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nSubtotalColor = 0;
                            }

                        }

                        if (cAtributoRef == cGrupoAtr)
                        {
                            try
                            {
                                nTotalGrupo = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nTotalGrupo = 0;
                            }

                            break;

                        }

                    }

                }

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
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (nLineId >= 0)
                    {
                        if (cGrupoAtr == cAtributoRef)
                        {
                            try
                            {
                                nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nValor = 0;
                            }

                            try
                            {
                                cCodAtr = Grid1[1, x].Value.ToString();
                            }
                            catch
                            {
                                cCodAtr = "";
                            }

                            if (cCodAtr != "")
                            {
                                if ((cCodAtr.Substring(0,4) == "PC_5") || (cCodAtr.Substring(0, 4) == "PH_5"))
                                {
                                    nTotalGrupo = nSubtotalColor;
                                }

                            }

                            nPorcentaje = 0;

                            if (nTotalGrupo > 0)
                            {
                                nPorcentaje = nValor / nTotalGrupo * 100;
                            }
                            else
                            {
                                nPorcentaje = 0;
                            }

                            Grid1[8, x].Value = nPorcentaje.ToString("N2");

                        }

                    }

                }

                ////////////////////////////////////////////////////////
                //// Determino un registro adicional para estos valores

                double nNCC_ExtraLight, nNCC_Light;
                double nNCC_LightAmbar, nNCC_Ambar;

                int nNCC_ExtraLight_Pos, nNCC_Light_Pos;
                int nNCC_LightAmbar_Pos, nNCC_Ambar_Pos;

                nNCC_ExtraLight = 0;
                nNCC_Light = 0;
                nNCC_LightAmbar = 0;
                nNCC_Ambar = 0;
                nMP_Nuez_Calibre = 0;
                nMP_Nuez_AColor = 0;

                nNCC_ExtraLight_Pos = -1;
                nNCC_Light_Pos = -1;
                nNCC_LightAmbar_Pos = -1;
                nNCC_Ambar_Pos = -1;

                for (int x = 0; x <= Grid1.RowCount - 1; x++)
                {

                    try
                    {
                        cCodAtr = Grid1[1, x].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[8, x].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    if (cCodAtr == "PM_3_001" || cCodAtr == "PM_3_002" || cCodAtr == "PM_3_003" || cCodAtr == "PM_3_004" || cCodAtr == "PM_3_005" || cCodAtr == "PM_3_006" || cCodAtr == "PM_3_007")
                    {
                        try
                        {
                            nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        nMP_Nuez_Calibre += nValor;

                    }

                    if (cCodAtr == "PM_5_001" || cCodAtr == "PM_5_002" || cCodAtr == "PM_5_003" || cCodAtr == "PM_5_004" || cCodAtr == "PM_5_005" || cCodAtr == "PM_5_006" || cCodAtr == "PM_5_008")
                    {
                        try
                        {
                            nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        nMP_Nuez_AColor += nValor;

                    }

                    if (cCodAtr == "PF_5_001" || cCodAtr == "PF_5_002" || cCodAtr == "PF_5_003" || cCodAtr == "PF_5_004")
                    {
                        if (cCodAtr == "PF_5_001")
                        {
                            nNCC_ExtraLight = nValor;
                            nNCC_ExtraLight_Pos = x;

                        }

                        if (cCodAtr == "PF_5_002")
                        {
                            nNCC_Light = nValor;
                            nNCC_Light_Pos = x;

                        }

                        if (cCodAtr == "PF_5_003")
                        {
                            nNCC_LightAmbar = nValor;
                            nNCC_LightAmbar_Pos = x;

                        }

                        if (cCodAtr == "PF_5_004")
                        {
                            nNCC_Ambar = nValor;
                            nNCC_Ambar_Pos = x;

                        }

                    }

                    if (cCodAtr == "PG_5_001" || cCodAtr == "PG_5_002" || cCodAtr == "PG_5_003" || cCodAtr == "PG_5_004")
                    {
                        if (cCodAtr == "PG_5_001")
                        {
                            nNCC_ExtraLight = nValor;
                            nNCC_ExtraLight_Pos = x;

                        }

                        if (cCodAtr == "PG_5_002")
                        {
                            nNCC_Light = nValor;
                            nNCC_Light_Pos = x;

                        }

                        if (cCodAtr == "PG_5_003")
                        {
                            nNCC_LightAmbar = nValor;
                            nNCC_LightAmbar_Pos = x;

                        }

                        if (cCodAtr == "PG_5_004")
                        {
                            nNCC_Ambar = nValor;
                            nNCC_Ambar_Pos = x;

                        }

                    }

                }

                if ((nNCC_ExtraLight + nNCC_Light) >= 80)
                {
                    ////////////////////////////////////////////////////////
                    //// si es mayor a 80% indicar como error

                    Grid1[9, nNCC_ExtraLight_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    if (nNCC_ExtraLight > 0)
                    {
                        Grid1[9, nNCC_ExtraLight_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                        Grid1[7, nNCC_ExtraLight_Pos].Style.BackColor = Color.Red;
                    }

                    Grid1[9, nNCC_Light_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    if (nNCC_Light > 0)
                    {
                        Grid1[9, nNCC_Light_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                        Grid1[7, nNCC_Light_Pos].Style.BackColor = Color.Red;
                    }

                }
                else
                {
                    if (nNCC_ExtraLight_Pos != -1)
                    {

                        Grid1[9, nNCC_ExtraLight_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                        Grid1[7, nNCC_ExtraLight_Pos].Style.BackColor = Color.Empty;

                        if (nNCC_ExtraLight > 0)
                        {
                            Grid1[9, nNCC_ExtraLight_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                        }

                        Grid1[9, nNCC_Light_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                        Grid1[7, nNCC_Light_Pos].Style.BackColor = Color.Empty;

                        if (nNCC_Light > 0)
                        {
                            Grid1[9, nNCC_Light_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                        }

                    }

                }

                if ((nNCC_LightAmbar + nNCC_Ambar) >= 20)
                {
                    ////////////////////////////////////////////////////////
                    //// si es mayor a 20% indicar como error

                    Grid1[9, nNCC_LightAmbar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    if (nNCC_LightAmbar > 0)
                    {
                        Grid1[9, nNCC_LightAmbar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                        Grid1[7, nNCC_LightAmbar_Pos].Style.BackColor = Color.Red;
                    }

                    Grid1[9, nNCC_Ambar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    if (nNCC_Ambar > 0)
                    {
                        Grid1[9, nNCC_Ambar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                        Grid1[7, nNCC_Ambar_Pos].Style.BackColor = Color.Red;
                    }

                }
                else
                {

                    if (nNCC_LightAmbar_Pos != -1)
                    {
                        Grid1[9, nNCC_LightAmbar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                        Grid1[7, nNCC_LightAmbar_Pos].Style.BackColor = Color.Empty;

                        if (nNCC_LightAmbar > 0)
                        {
                            Grid1[9, nNCC_LightAmbar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                        }

                        Grid1[9, nNCC_Ambar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                        Grid1[7, nNCC_Ambar_Pos].Style.BackColor = Color.Empty;

                        if (nNCC_Ambar > 0)
                        {
                            Grid1[9, nNCC_Ambar_Pos].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                        }

                    }

                }

            }

            if (cTipoGrupo == "PM")
            {
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
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (nLineId >= 0)
                    {
                        if (cAtributoRef == "Daños Externos" || cAtributoRef == "Daños Internos")
                        {
                            try
                            {
                                nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nValor = 0;
                            }

                            nPorcentaje = 0;

                            if (cAtributoRef == "Daños Externos")
                            {
                                if (nMP_Nuez_Calibre > 0)
                                {
                                    nPorcentaje = nValor / nMP_Nuez_Calibre * 100;

                                }

                            }

                            if (cAtributoRef == "Daños Internos")
                            {
                                if (nMP_Nuez_AColor > 0)
                                {
                                    nPorcentaje = nValor / nMP_Nuez_AColor * 100;

                                }

                            }

                            Grid1[8, x].Value = nPorcentaje.ToString("N2");

                        }

                    }

                }

            }

            if (cTipoGrupo == "PP")
            {
                ////////////////////////////////////////////////////////
                //// Para este grupo se calcula sobre el total del grupo

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
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (nLineId == -1)
                    {
                        if (cAtributoRef == cGrupoAtr)
                        {
                            try
                            {
                                nTotalGrupo = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nTotalGrupo = 0;
                            }

                            break;

                        }

                    }

                }

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
                        cAtributoRef = Grid1[10, x].Value.ToString();
                    }
                    catch
                    {
                        cAtributoRef = "";
                    }

                    if (nLineId >= 0)
                    {
                        if (cGrupoAtr == cAtributoRef)
                        {
                            try
                            {
                                nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                            }
                            catch
                            {
                                nValor = 0;
                            }

                            nPorcentaje = 0;

                            if (nTotalGrupo > 0)
                            {
                                nPorcentaje = nValor / nTotalGrupo * 100;
                            }
                            else
                            {
                                nPorcentaje = 0;
                            }

                            Grid1[8, x].Value = nPorcentaje.ToString("N2");

                        }

                    }

                }

                ////////////////////////////////////////////////////////
                //// Calculo el total general 

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

                    if (nLineId < -1)
                    {
                        try
                        {
                            nTotalGrupo = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nTotalGrupo = 0;
                        }

                        break;

                    }

                }

                ////////////////////////////////////////////////////////
                //// Calculo el porcentaje por cada total

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

                    if (nLineId == -1)
                    {
                        try
                        {
                            nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        nPorcentaje = 0;

                        if (nTotalGrupo > 0)
                        {
                            nPorcentaje = nValor / nTotalGrupo * 100;
                        }
                        else
                        {
                            nPorcentaje = 0;
                        }

                        Grid1[8, x].Value = nPorcentaje.ToString("N2");

                    }

                }

                ////////////////////////////////////////////////////////
                //// Calculo los porcentajes adicionales de seleccion

                double nEL, nTot_EL;
                double nL, nTot_L;
                double nLA, nTot_LA;
                double nA, nTot_A;
                double nAmarilloClaro, nTot_AmarilloClaro;
                double nAmarilloOscuro, nTot_AmarilloOscuro;

                nEL = 0;
                nTot_EL = 0;
                nL = 0;
                nTot_L = 0;
                nLA = 0;
                nTot_LA = 0;
                nA = 0;
                nTot_A = 0;
                nAmarilloClaro = 0;
                nTot_AmarilloClaro = 0;
                nAmarilloOscuro = 0;
                nTot_AmarilloOscuro = 0;

                for (int x = 0; x <= Grid1.RowCount - 1; x++)
                {

                    try
                    {
                        cCodAtr = Grid1[1, x].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    try
                    {
                        nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                    }
                    catch
                    {
                        nValor = 0;
                    }

                    if (cCodAtr == "PP_1_001" || cCodAtr == "PP_1_002" || cCodAtr == "PP_2_001" || cCodAtr == "PP_3_001")
                    {
                        if (cCodAtr != "PP_3_001")
                        {
                            nEL += nValor;
                        }
                        else
                        {
                            nEL += (nValor * 0.8);
                        }

                    }

                    if (cCodAtr == "PP_1_003" || cCodAtr == "PP_2_002" || cCodAtr == "PP_3_001")
                    {
                        if (cCodAtr != "PP_3_001")
                        {
                            nL += nValor;
                        }
                        else
                        {
                            nL += (nValor * 0.2);
                        }

                    }

                    if (cCodAtr == "PP_1_004" || cCodAtr == "PP_2_003" || cCodAtr == "PP_3_002")
                    {
                        if (cCodAtr != "PP_3_002")
                        {
                            nLA += nValor;
                        }
                        else
                        {
                            nLA += (nValor * 0.8);
                        }

                    }

                    if (cCodAtr == "PP_1_005" || cCodAtr == "PP_2_004" || cCodAtr == "PP_3_002")
                    {
                        if (cCodAtr != "PP_3_002")
                        {
                            nA += nValor;
                        }
                        else
                        {
                            nA += (nValor * 0.2);
                        }

                    }

                    if (cCodAtr == "PP_1_006" || cCodAtr == "PP_2_005" || cCodAtr == "PP_3_003")
                    {
                        nAmarilloClaro += nValor;

                    }

                    if (cCodAtr == "PP_1_007" || cCodAtr == "PP_2_006" || cCodAtr == "PP_3_004")
                    {
                        nAmarilloOscuro += nValor;

                    }

                }

                if (nEL > 0 && nTotalGrupo > 0)
                {
                    nTot_EL = nEL / nTotalGrupo * 100;
                }

                if (nL > 0 && nTotalGrupo > 0)
                {
                    nTot_L = nL / nTotalGrupo * 100;
                }

                if (nLA > 0 && nTotalGrupo > 0)
                {
                    nTot_LA = nLA / nTotalGrupo * 100;
                }

                if (nA > 0 && nTotalGrupo > 0)
                {
                    nTot_A = nA / nTotalGrupo * 100;
                }

                if (nAmarilloClaro > 0 && nTotalGrupo > 0)
                {
                    nTot_AmarilloClaro = nAmarilloClaro / nTotalGrupo * 100;
                }

                if (nAmarilloOscuro > 0 && nTotalGrupo > 0)
                {
                    nTot_AmarilloOscuro = nAmarilloOscuro / nTotalGrupo * 100;
                }

                ////////////////////////////////////////////////////////
                //// Lleno la grilla de resumen

                for (int x = 0; x <= Grid2.RowCount - 1; x++)
                {

                    try
                    {
                        cCodAtr = Grid2[2, x].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    if (cCodAtr == "EL")
                    {
                        Grid2[3, x].Value = nTot_EL.ToString("N2");
                    }

                    if (cCodAtr == "L")
                    {
                        Grid2[3, x].Value = nTot_L.ToString("N2");
                    }

                    if (cCodAtr == "LA")
                    {
                        Grid2[3, x].Value = nTot_LA.ToString("N2");
                    }

                    if (cCodAtr == "A")
                    {
                        Grid2[3, x].Value = nTot_A.ToString("N2");
                    }

                    if (cCodAtr == "Amarillas Claras")
                    {
                        Grid2[3, x].Value = nTot_AmarilloClaro.ToString("N2");
                    }

                    if (cCodAtr == "Amarillas Oscuras")
                    {
                        Grid2[3, x].Value = nTot_AmarilloOscuro.ToString("N2");
                    }

                }

            }

        }

        private void totalizar_grupos(string cGrupoAtr)
        {
            Int32 nLineId;
            string cAtributoRef, cCodAtr, cSinPorcentaje;
            string cCumpleCiclo;
            double nSubTotal, nValor;
            
            /////////////////////////////////////////////////////
            //// Calculo el valor total del grupo y lo actualizo

            nSubTotal = 0;            

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
                    cCodAtr = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    cAtributoRef = Grid1[10, x].Value.ToString();
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
                    cCumpleCiclo = "N";

                    // Esto es para el ciclo normal

                    if (cGrupoAtr == cAtributoRef)
                    {
                        cCumpleCiclo = "S";
                    }

                    // Esto es para Nuez Mec. - Total Muestra 

                    if (cGrupoAtr == "Total de Muestra")
                    {
                        //if (cAtributoRef == "% Mitades")
                        //{
                        //    cCumpleCiclo = "S";
                        //}

                        //if (cAtributoRef == "% Cuartos")
                        //{
                        //    cCumpleCiclo = "S";
                        //}

                        //if (cAtributoRef == "% Cuartillos")
                        //{
                        //    cCumpleCiclo = "S";
                        //}

                    }

                    if (cCumpleCiclo == "S")
                    {
                        cSinPorcentaje = "";

                        if (cCodAtr == "PE_1_001" || cCodAtr == "PE_1_002" || cCodAtr == "PE_2_001" || cCodAtr == "PE_2_002" || cCodAtr == "PE_2_003" || cCodAtr == "PE_3_001")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PE_7_001" || cCodAtr == "PE_7_002" || cCodAtr == "PE_7_003" || cCodAtr == "PE_7_004" || cCodAtr == "PE_7_005" || cCodAtr == "PE_7_006")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PA_1_001" || cCodAtr == "PA_1_002" || cCodAtr == "PA_1_002.5" || cCodAtr == "PB_1_001" || cCodAtr == "PB_1_002" || cCodAtr == "PD_1_001" || cCodAtr == "PD_1_002")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cCodAtr == "PM_1_001" || cCodAtr == "PM_1_002" || cCodAtr == "PM_1_003" || cCodAtr == "PM_1_004" || cCodAtr == "PM_1_005" || cCodAtr == "PM_1_006" || cCodAtr == "PM_2_002" || cCodAtr == "PM_2_003" || cCodAtr == "PM_2_004")
                        {
                            cSinPorcentaje = "X";
                        }

                        if (cSinPorcentaje == "X")
                        {
                            //nSubTotal = nSubTotal;
                        }
                        else
                        {
                            nSubTotal += nValor;
                        }

                    }

                }

            }

            ////////////////////////////////////////////////////
            //// Actualizo el total x grupo

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
                    cAtributoRef = Grid1[10, x].Value.ToString();
                }
                catch
                {
                    cAtributoRef = "";
                }

                if (nLineId < 0)
                {
                    if (cGrupoAtr == cAtributoRef)
                    {
                        try
                        {
                            Grid1[7, x].Value = nSubTotal.ToString("N2");
                        }
                        catch
                        {
                            Grid1[7, x].Value = 0.ToString("N2");
                        }

                        break;

                    }

                }

            }

            ////////////////////////////////////////////////////
            //// Calculo el total general de todos los grupos

            nSubTotal = 0;            

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
                    cAtributoRef = Grid1[10, x].Value.ToString();
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
                    nValor = 0;
                }

                if (nLineId == -1)
                {
                    if (Grid1[1, 0].Value.ToString().Substring(0, 2) == "PC")
                    {
                        if (Grid1[1, x].Value.ToString() == "")
                        {
                            if ((cAtributoRef == "Total de Color") || (cAtributoRef == "Total de Daños"))
                            {
                                nSubTotal += nValor;

                            }                            

                        }

                    }
                    else
                    {
                        nSubTotal += nValor;

                    }

                }

            }

            ////////////////////////////////////////////////////
            //// Actualizo el total final

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


                if (nLineId < -1)
                {
                    try
                    {
                        Grid1[7, x].Value = nSubTotal.ToString("N2");
                    }
                    catch
                    {
                        Grid1[7, x].Value = 0.ToString("N2");
                    }

                }

            }

            ////////////////////////////////////////////////////
            //// Determino el Calibre para algunos Analisis

            Calcula_Resultado_Previo_Analisis();

            ////////////////////////////////////////////////////
            //// Primero veo si el grupo corresponde

            try
            {
                cCodAtr = Grid1[1, 0].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            if (cCodAtr == "")
            {
                return;
            }

            nLineId = -1;

            if (cCodAtr.Substring(0, 2) == "PA" || cCodAtr.Substring(0, 2) == "PB" || cCodAtr.Substring(0, 2) == "PD")
            {
                nLineId = 0;
            }

            if (nLineId == -1)
            {
                return;
            }

            cAtributoRef = "";

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                try
                {
                    cCodAtr = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                }
                catch
                {
                    nValor = -2;
                }

                if (cCodAtr == "PA_1_001" || cCodAtr == "PB_1_001" || cCodAtr == "PD_1_001")
                {
                    cAtributoRef = "";

                    if (cbb_caracteristicas.Visible == true)
                    {
                        if (cbb_caracteristicas.SelectedIndex > 0)
                        {
                            nValor = 0;
                            Grid1[7, x].Value = "";
                        }

                    }

                    if (t_familia_codsubgrupo.Text != "PP")
                    {
                        nValor = 0;
                        Grid1[7, x].Value = "";
                    }

                    if (nValor > 0 && nValor <= 20)
                    {
                        cAtributoRef = "18-20";
                    }

                    if (nValor > 20 && nValor <= 22)
                    {
                        cAtributoRef = "20-22";
                    }

                    if (nValor >= 22.1 && nValor <= 25)
                    {
                        cAtributoRef = "23-25";
                    }

                    if (nValor > 25 && nValor <= 27)
                    {
                        cAtributoRef = "25-27";
                    }

                    if (nValor > 27 && nValor <= 30)
                    {
                        cAtributoRef = "27-30";
                    }

                    if (nValor > 30 && nValor <= 34)
                    {
                        cAtributoRef = "30-34";
                    }

                    if (nValor > 34 && nValor <= 40)
                    {
                        cAtributoRef = "34-40";
                    }

                    if (nValor > 40)
                    {
                        cAtributoRef = "40+";
                    }

                }

                if (cCodAtr == "PA_1_002" || cCodAtr == "PB_1_002" || cCodAtr == "PD_1_002")
                {
                    Grid1[7, x].Value = cAtributoRef;
                    break;
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
            string cGrupoAtr;

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

            try
            {
                cGrupoAtr = Grid1[10, fila].Value.ToString();
            }
            catch
            {
                cGrupoAtr = "";
            }

            Grid1[7, fila].Value = nValor.ToString("N2");

            Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

            if (nValor > 0)
            {
                if (nValor <= nMinimo)
                {
                    Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                }

            }

            if (nValor > 0)
            {
                if ((nValor > nMinimo) && (nValor <= nMaximo))
                {
                    Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\bullet_error.png");
                }

            }

            if (nValor > nMaximo) 
            {
                Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
            }

            //if (nMinimo == nMaximo)
            //{
            //    //cError = "";
            //}

            //if (nValor == 0)
            //{
            //    Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

            //}
            //else
            //{
            //    if (cError == "S")
            //    {
            //        Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
            //    }
            //    else
            //    {
            //        Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
            //    }
            //}

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            totalizar_grupos(cGrupoAtr);

            //////////////////////////////////////
            //// Calculo el porcentaje del item

            totalizar_porcentaje_x_grupo(cGrupoAtr);

            ////////////////////////////////////////////////////
            //// Determino el Calibre para algunos Analisis

            Calcula_Resultado_Previo_Analisis();

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

                if (cCodAtr != "" && cCodAtr != "PB_1_002")
                {
                    Grid1.Columns[7].ReadOnly = false;
                }
                else
                {
                    Grid1.Columns[7].ReadOnly = true;
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
            string cDisponible;

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

            string cCalibreNuez, cColorNuez;

            cCalibreNuez = "";
            cColorNuez = "";

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

            string UserCode, cUM;
            int UserId;
            double nCantidad;

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
            cDisponible = "S";

            if (cbb_disponible.Visible == true)
            {
                if (cbb_disponible.SelectedIndex == 0)
                {
                    cDisponible = "S";
                }

                if (cbb_disponible.SelectedIndex == 1)
                {
                    cDisponible = "N";
                }

            }
            else
            {
                cDisponible = "S";
            }
            
            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(t_fecha_ingreso.Text);

            }
            catch
            {
                dt = DateTime.Now;

            }

            String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "N", UserId, UserCode, cItemCode, cItemName, cWhsCode, "", cNumCon, cLote, nCantidad, 0, 0, dt.ToString("yyyyMMdd"), cUM, 0, 0, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef, cCalibreNuez, cColorNuez,0, t_tipo_proceso.Text, cDisponible,"","");

            int nLineId;
            string cCodAtr, cNomAtr, cComments;
            string cComments2;
            double nStandar, nMedicion, nMinimo;
            double nMaximo, nPorcentaje;

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
                cComments = "";
                cComments2 = "";
                nPorcentaje = 0;

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

                if (cCodAtr == "PE_7_003")
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
                            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "", nPorcentaje);
                            //mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, -1, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "");

                        }

                    }

                }

            }

            ////////////////////////////////////
            ////////////////////////////////////
            // Esto es para Seleccion Nueces

            string cTipoGrupo;

            try
            {
                cTipoGrupo = Grid1[1, 0].Value.ToString().Substring(0, 2);
            }
            catch
            {
                cTipoGrupo = "";
            }

            if (cTipoGrupo == "PE")
            {

                int nSelladoBolsas;

                nSelladoBolsas = 0;

                if (cbb_sellado_bolsas.SelectedIndex == 1)
                {
                    nSelladoBolsas = 1;

                }

                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, Grid1.RowCount-1 , "PE_7_006", "Sellado de Bolsa", 0, 0, 0, nSelladoBolsas, "Selección Nueces", "Selección Nueces", "",0);

            }


            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            VariablesGlobales.glb_id_calidad = nDocEntry;

            frmCalidadPP4_Load(sender, e);

        }

        private void Calcula_Resultado_Previo_Analisis()
        {
            ////////////////////////////////////////////////////
            //// Propongo el estado segun sea el caso 

            double nMinimo, nMaximo, nValor;
            double nStardar;
            int nValores, nAprobados, nAprReparos;
            int nRechazado;

            string cCodAtr;

            nValores = 0;
            nAprobados = 0;
            nAprReparos = 0;
            nRechazado = 0;

            for (int x = 0; x <= Grid1.RowCount - 1; x++)
            {

                try
                {
                    cCodAtr = Grid1[1, x].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                try
                {
                    nStardar = Convert.ToDouble(Grid1[4, x].Value.ToString());
                }
                catch
                {
                    nStardar = 0;
                }

                try
                {
                    nMinimo = Convert.ToDouble(Grid1[5, x].Value.ToString());
                }
                catch
                {
                    nMinimo = 0;
                }

                try
                {
                    nMaximo = Convert.ToDouble(Grid1[6, x].Value.ToString());
                }
                catch
                {
                    nMaximo = 0;
                }

                try
                {
                    nValor = Convert.ToDouble(Grid1[7, x].Value.ToString());
                }
                catch
                {
                    nValor = 0;
                }

                if (cCodAtr != "")
                {

                    if ((cCodAtr.Substring(3, 5) != "1_001") && (cCodAtr.Substring(3, 5) != "1_002"))
                    {
                        if (nValor > 0)
                        {
                            nValores += 1;

                            if (nValor > 0)
                            {
                                if (nValor <= nMinimo)
                                {
                                    nAprobados += 1;
                                }

                            }

                            if (nValor > 0)
                            {
                                if ((nValor > nMinimo) && (nValor <= nMaximo))
                                {
                                    nAprReparos += 1;
                                }

                                if (nValor > nMaximo)
                                {
                                    nAprReparos += 1;
                                }

                            }

                            if (nStardar == 1)
                            {
                                if (nValor > nMaximo)
                                {
                                    nRechazado += 1;
                                }

                            }

                        }
                    }

                }

            }

            string cCode_TotalGrupo, cDesAtr;
            double nCode_TotalGrupo;

            cCode_TotalGrupo = "";
            nCode_TotalGrupo = 0;

            for (int x = 0; x <= Grid4.RowCount - 1; x++)
            {
                try
                {
                    cCode_TotalGrupo = Grid4[0, x].Value.ToString();
                }
                catch
                {
                    cCode_TotalGrupo = "";
                }

                try
                {
                    nCode_TotalGrupo = Convert.ToDouble(Grid4[1, x].Value.ToString());
                }
                catch
                {
                    nCode_TotalGrupo = 0;
                }

                if (nCode_TotalGrupo > 0)
                {
                    for (int y = 0; y <= Grid1.RowCount - 1; y++)
                    {

                        try
                        {
                            cCodAtr = Grid1[1, y].Value.ToString();
                        }
                        catch
                        {
                            cCodAtr = "";
                        }

                        try
                        {
                            cDesAtr = Grid1[2, y].Value.ToString();
                        }
                        catch
                        {
                            cDesAtr = "";
                        }

                        try
                        {
                            nValor = Convert.ToDouble(Grid1[8, y].Value.ToString());
                        }
                        catch
                        {
                            nValor = 0;
                        }

                        if ((cCodAtr == "") && (cCode_TotalGrupo == cDesAtr))
                        {

                            if (nCode_TotalGrupo > 0)
                            {
                                if (nValor > nCode_TotalGrupo)
                                {
                                    nRechazado += 1;
                                }

                            }

                            break;
                        }

                    }
                }

            }

            string cResultado;

            cResultado = "Aprobado";

            t_resultado_previo.BackColor = Color.Green;
            
            if (nValores > 0)
            {
                if (nRechazado > 0)
                {
                    cResultado = "Rechazado";
                    t_resultado_previo.BackColor = Color.Red;

                }
                else
                {

                    if (t_tipo_proceso.Text == "Envasado Almendras")
                    {
                        if (nAprReparos > 0)
                        {
                            nAprobados = nAprReparos;
                            nAprReparos = 0;
                        }

                    }

                    if (nAprReparos > 0)
                    {
                        cResultado = "Aprobado con Reparos";
                        t_resultado_previo.BackColor = Color.Orange;

                    }
                    else
                    {
                        if (nAprobados > 0)
                        {
                            cResultado = "Aprobado";
                            t_resultado_previo.BackColor = Color.Green;

                        }

                    }
                }               

            }

            t_resultado_previo.Text = cResultado;

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            int nDocEntry;
            string cObject , cLote;

            try
            {
                nDocEntry = int.Parse(t_id_recepcion.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cObject = t_object.Text;
            }
            catch
            {
                cObject = "";
            }

            try
            {
                cLote = t_lote.Text;
            }
            catch
            {
                cLote = "";
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Imprime_etiqueta_adhesiva();

            VariablesGlobales.glb_DocEntry = nDocEntry;
            VariablesGlobales.glb_Object = cObject;
            VariablesGlobales.glb_Lote = Convert.ToInt32(cLote); 

            frmReporteProduccion f2 = new frmReporteProduccion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Object = "";
            VariablesGlobales.glb_Lote = 0;

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


        private void btn_nuevo_reg_Click(object sender, EventArgs e)
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

            nDocEntry = nDocEntry * -1;

            t_id_calidad.Text = nDocEntry.ToString();

            t_resultado_previo.Text = "En Proceso";
            t_resultado_previo.BackColor = Color.White;

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            carga_datos_calidad();

            totalizar_porcentaje_x_grupo("");

            ////////////////////////////////////////////////////
            //// Determino el Calibre para algunos Analisis

            Calcula_Resultado_Previo_Analisis();

            t_doc_entry.Text = "0";

            btn_aprobar.Enabled = true;
            btn_aprobado.Enabled = true;
            btn_aprobar_con_reparos.Enabled = true;
            btn_rechazar.Enabled = true;

            btn_aprobar.Visible = false;
            btn_aprobado.Visible = false;
            btn_aprobar_con_reparos.Visible = false;
            btn_rechazar.Visible = false;

            btn_imprimir.Visible = false;
            btn_nuevo_reg.Visible = false;

            t_resultado.Text = "En Proceso";
            t_resultado.BackColor = Color.White;

            label19.Visible = true;

            t_resultado_previo.Visible = true;
            //t_resultado_previo.Text = "En Proceso";
            //t_resultado_previo.BackColor = Color.White;

            btn_ok.Enabled = true;

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
                if ((cCodAtr.Substring(0, 2).ToUpper() == "PA") || (cCodAtr.Substring(0, 2).ToUpper() == "PB") || (cCodAtr.Substring(0, 2).ToUpper() == "PD"))
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

                            if ((cCodAtr == "PA_1_002") || (cCodAtr == "PB_1_002") || (cCodAtr == "PD_1_002"))
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

            string cCalibreNuez, cColorNuez, cDisponible;

            cCalibreNuez = "";
            cColorNuez = "";
            cDisponible = "S";

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

            if (cbb_disponible.Visible == true)
            {
                if (cbb_disponible.SelectedIndex == 1)
                {
                    cDisponible = "N";

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

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Finalizar el Registro de Inspección", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ////////////////////////////////////////////////
                    /// Finalizado el registro de Inspección
                    /// 

                    mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, cEstado_de_Finalizacion, UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, cCalibreNuez, cColorNuez,0, t_tipo_proceso.Text, cDisponible,"","");

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
                        if (t_tipo_proceso.Text != "Prelimpia & Cracker")
                        {
                            mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

                        }

                    }
                    else
                    {
                        if (t_status_lote.Text != "Liberado")
                        {
                            mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(t_lote.Text), "N", UsuarioSap, ClaveSap);

                        }

                    }

                    try
                    {
                        if (cCodAtr.Substring(0, 2).ToUpper() == "PM")
                        {
                            int nDocEntry_ref;

                            nDocEntry_ref = 0;

                            clsCalidad objproducto = new clsCalidad();
                            objproducto.cls_Consulta_Registro_Referencia_PT_Seco(nDocEntry);

                            DataTable dTable = new DataTable();
                            dTable = objproducto.cResultado;

                            try
                            {
                                nDocEntry_ref = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());
                            }
                            catch
                            {
                                nDocEntry_ref = 0;
                            }

                            if (nDocEntry_ref > 0)
                            {
                                String mensaje_pt_seco = clsCalidad.SAPB1_ORCAL9(nDocEntry_ref);

                            }

                        }

                    }
                    catch
                    {

                    }

                    frmCalidadPP4_Load(sender, e);

                    //carga_datos_calidad();

                }
            }


        }

        private void btn_aprobado_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            aprobacion_directa("A");

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

            if (t_status_lote.Text != "Liberado")
            {

                string mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

            }

            frmCalidadPP4_Load(sender, e);

        }

        private void btn_aprobar_con_reparos_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            aprobacion_directa("Q");

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

            if (t_status_lote.Text != "Liberado")
            {

                string mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(t_lote.Text), "N", UsuarioSap, ClaveSap);

            }

            frmCalidadPP4_Load(sender, e);

        }

        private void btn_rechazar_Click(object sender, EventArgs e)
        {

            btn_ok_Click(sender, e);

            aprobacion_directa("R");

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

            if (t_tipo_proceso.Text != "Prelimpia & Cracker")
            {

                string mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(t_lote.Text), "Y", UsuarioSap, ClaveSap);

            }

            frmCalidadPP4_Load(sender, e);

        }

        private void aprobacion_directa(string estado)
        {

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
                if ((cCodAtr.Substring(0, 2).ToUpper() == "PA") || (cCodAtr.Substring(0, 2).ToUpper() == "PB") || (cCodAtr.Substring(0, 2).ToUpper() == "PD"))
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

                            if ((cCodAtr == "PA_1_002") || (cCodAtr == "PB_1_002") || (cCodAtr == "PD_1_002"))
                            {
                                if (cCalibre.Trim() == "")
                                {
                                    MessageBox.Show("Debe registras un Calibre válido, Opción Cancelada", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                break;
                            }

                        }

                    }

                }

            }

            string cCalibreNuez, cColorNuez, cDisponible;

            cCalibreNuez = "";
            cColorNuez = "";
            cDisponible = "S";

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

            if (cbb_disponible.Visible == true)
            {
                if (cbb_disponible.SelectedIndex == 1)
                {
                    cDisponible = "N";

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

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Finalizar el Registro de Inspección", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ////////////////////////////////////////////////
                    /// Grabo el registro de calidad
                    /// 

                    string mensaje;

                    mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, estado, UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, cCalibreNuez, cColorNuez,0, t_tipo_proceso.Text, cDisponible,"","");

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
                  
                }
            }

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

                oSheet.get_Range("b" + nLinea, "i"+ nLinea).Font.Bold = true;

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
                int UserId = VariablesGlobales.glb_User_id;

                mensaje = clsCalidad.SAPB1_ORCALv1(nDocEntry, "L", UserId);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Actualizado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                frmCalidadPP4_Load(sender, e);

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
    }

}
