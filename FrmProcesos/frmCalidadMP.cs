using System;
using System.IO;
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
    public partial class frmCalidadMP : Form
    {
        public frmCalidadMP()
        {
            InitializeComponent();
        }

        private void frmCalidadMP_Load(object sender, EventArgs e)
        {

            Boolean exists;

            //exists = System.IO.Directory.Exists("c:\ExistingFolderName")

            exists = System.IO.Directory.Exists(@"c:\temp");

            if (exists == false)
            {
                MessageBox.Show("Debe crear la Carpeta >Temp< en el Disco C, de lo contrario la aplicación NO funcionara correctamente", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string sourceDir = @"c:\temp";

                string[] picList = Directory.GetFiles(sourceDir, "i*.png");

                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                }

                foreach (string f in picList)
                {
                    try
                    {
                        File.Delete(f);

                    }
                    catch
                    {

                    }

                }

            }

            if (VariablesGlobales.glb_Object == "100100")
            {
                Grid1.Columns[8].Visible = false;
            }
            else
            {
                Grid1.Columns[8].Visible = true;
            }

            btn_aprobar.Visible = false;
            btn_rechazar.Visible = false;
            btn_nuevo_reg.Visible = false;

            btn_aprobar.Enabled = true;
            btn_rechazar.Enabled = true;
            btn_nuevo_reg.Enabled = true;

            btn_imprimir.Visible = false;

            btn_dividir_registro.Visible = false;

            if (VariablesGlobales.glb_id_calidad == 0)
            {
                t_fecha_ingreso.Text = "";
                t_doc_entry.Text = "0";

                t_id_calidad.Text = "0";

                // Es un registro nuevo 

                // Registro de Romana

                if (VariablesGlobales.glb_Object == "100100")
                {
                    /// Registro de Humedad ****
                    /// 

                    t_id_ref.Text = VariablesGlobales.glb_id_romana.ToString();
                    t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                    t_object.Text = VariablesGlobales.glb_Object;

                    btn_aprobar.Visible = true;
                    btn_rechazar.Visible = true;

                    carga_datos_romana();

                }

                if (VariablesGlobales.glb_Object == "59") 
                {
                    /// Registro de Materia Prima ****
                    /// Desde Romana
                    /// 

                    t_id_calidad.Text = "0";
                    t_object.Text = VariablesGlobales.glb_Object;
                    t_num_guia.Text = VariablesGlobales.glb_DocEntry.ToString();

                    t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                    t_lote.Text = VariablesGlobales.glb_Lote.ToString();

                    carga_datos_produccion();
                    //carga_datos_recepcion_pt_secado();
                    //carga_datos_recepcion_mp();

                }

                if (VariablesGlobales.glb_Object == "100500")
                {
                    /// Registro de Materia Prima ****
                    /// Desde Romana
                    /// 

                    t_id_ref.Text = VariablesGlobales.glb_id_romana.ToString();
                    t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                    t_object.Text = VariablesGlobales.glb_Object;

                    carga_datos_recepcion_mp();

                }

                if ((VariablesGlobales.glb_Object == "100501") || (VariablesGlobales.glb_Object == "100502"))
                {
                    /// Registro de Materia Prima ****
                    /// Desde Ingreso Directo / Fuera de Paine / Sin Romana
                    /// 
                    t_id_ref.Text = VariablesGlobales.glb_id_romana.ToString();
                    t_lineid.Text = VariablesGlobales.glb_LineId.ToString();
                    t_object.Text = VariablesGlobales.glb_Object;

                    carga_datos_recepcion_mp_sin_romana();

                }

            }
            else
            {

                t_id_calidad.Text = VariablesGlobales.glb_id_calidad.ToString();
                t_object.Text = VariablesGlobales.glb_Object;

                carga_datos_calidad();

                if (t_object.Text == "100100")
                {
                    /// Registro de Humedad ****
                    /// 
                    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                    carga_datos_cabecera_romana();

                    btn_dividir_registro.Visible = true;

                }

                if (t_object.Text == "100500")
                {
                    /// Registro de Materia Prima ****
                    /// 
                    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                    carga_datos_cabecera_mp();

                    btn_dividir_registro.Visible = true;

                }

                if (t_object.Text == "100501")
                {
                    /// Registro de Materia Prima ****
                    /// Desde Ingreso Directo / Fuera de Paine / Sin Romana
                    /// 
                    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                    carga_datos_cabecera_mp_sin_romana();

                    btn_dividir_registro.Visible = true;

                }

                if (t_object.Text == "100502")
                {
                    /// Registro de Materia Prima ****
                    /// Desde PT Secado
                    /// 

                    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                    carga_datos_recepcion_pt_secado();

                }

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
            //// Pantalla Principal - Queda en Blanco
            ////

            t_doc_entry.Text = "";
            t_fecha_ingreso.Text = "";
            t_num_guia.Text = "";
            t_lote.Text = "";
            t_variedad.Text = "";
            t_cant_prod.Text = "";
            t_un_medida.Text = "";
            t_num_bultos.Text = "";
            t_bultos_a_muestrear.Text = "";
            t_traslado.Text = "";

            ////////////////////////////////////////////////////7
            //// Pantalla Principal - Cargo los Datos
            ////

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor, cLote;
            string obs, cTipoProducto, cEstadoRegistro;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso, line_id, line_id_ref;
            DateTime dt;
            string cContraMu, cMuestDes;
            double nCoMuSize, nMuDeSize, nBultos;
            double nBultosMu, nCantidad;
            double nPepaBrutaProm_Productor, nPepaBrutaProm_Temporada; 

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nBultos = 0;
            nBultosMu = 0;
            cEstadoRegistro = "";
            line_id_ref = 0;
            nPepaBrutaProm_Productor = 0;
            nPepaBrutaProm_Temporada = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

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
                dt = Convert.ToDateTime(dTable.Rows[0]["CreateDate"].ToString());
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
                t_WhsDest.Text = dTable.Rows[0]["U_WhsDest"].ToString();
            }
            catch
            {
                t_WhsDest.Clear();
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
                nBultos = Convert.ToDouble(dTable.Rows[0]["U_Bultos"].ToString());
            }
            catch
            {
                nBultos = 0;
            }

            try
            {
                nBultosMu = Convert.ToDouble(dTable.Rows[0]["U_BultosMu"].ToString());
            }
            catch
            {
                nBultosMu = 0;
            }

            try
            {
                cEstadoRegistro = dTable.Rows[0]["U_Estado"].ToString();
            }
            catch
            {
                cEstadoRegistro = "";

            }

            try
            {
                t_U_AtrT1.Text = dTable.Rows[0]["U_AtrT1"].ToString();
            }
            catch
            {
                t_U_AtrT1.Text = "";
            }

            t_cant_prod.Text = nCantidad.ToString("N2");
            t_num_bultos.Text = nBultos.ToString("N2");
            t_bultos_a_muestrear.Text = nBultosMu.ToString("N2");

            try
            {
                t_traslado.Text = dTable.Rows[0]["U_NumTras"].ToString();

            }
            catch
            {
                t_traslado.Text = "";

            }

            cContraMu = "";
            cMuestDes = "";
            nCoMuSize = 0;
            nMuDeSize = 0;

            chk_contramuestra.Checked = false;
            chk_destructiva.Checked = false;

            try
            {
                cContraMu = dTable.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMu = "";
            }

            if (cContraMu == "Y")
            {
                chk_contramuestra.Checked = true;
            }

            try
            {
                nCoMuSize = Convert.ToDouble(dTable.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nCoMuSize = 0;
            }

            t_cant_contra_muestra.Text = nCoMuSize.ToString("N2");

            try
            {
                cMuestDes = dTable.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestDes = "";
            }

            if (cMuestDes == "Y")
            {
                chk_destructiva.Checked = true;
            }

            try
            {
                nMuDeSize = Convert.ToDouble(dTable.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuDeSize = 0;
            }

            t_cant_muestra_destructiva.Text = nMuDeSize.ToString("N2");

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

            t_lote.Text = cLote;

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
                numguia = Convert.ToInt32(dTable.Rows[0]["U_NumDoc"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            t_num_guia.Text = Convert.ToString(numguia);

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

            t_id_acceso.Text = id_acceso.ToString();
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

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
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
                nPepaBrutaProm_Productor = Convert.ToDouble(dTable.Rows[0]["Ref_PepaBruta_Productor"].ToString());
            }
            catch
            {
                nPepaBrutaProm_Productor = 0;

            }

            try
            {
                nPepaBrutaProm_Temporada = Convert.ToDouble(dTable.Rows[0]["Ref_PepaBruta_Temporada"].ToString());
            }
            catch
            {
                nPepaBrutaProm_Temporada = 0;

            }


            t_promedio_productor.Text = nPepaBrutaProm_Productor.ToString("N2");
            t_promedio_temporada.Text = nPepaBrutaProm_Temporada.ToString("N2");

            ///////////////////////////////////////
            //// Esto es para los datos que vienen
            //// desde la Romana 

            try
            {
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                patente = dTable.Rows[0]["U_Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["U_Conductor"].ToString();

            }
            catch
            {
                conductor = "";

            }

            ////////////////////////////////////////////////////7
            //// Pantalla Principal
            ////


            //t_doc_entry.Text = nDocEntry.ToString();
            //1t_fecha_ingreso.Text = 

            //t_lote.Text = cLote;
            //t_variedad.Text = "";
            //t_cant_prod.Text = cant_envases.ToString();
            //t_un_medida.Text = cUM;
            //t_num_bultos.Text = "";
            //t_bultos_a_muestrear.Text = "";
            //t_traslado.Text = "";

            ////////////////////////////////////////////////////7
            //// Registro de Guia - Queda en Blanco
            ////

            t_cardcode_d.Clear();
            t_cardname_d.Clear();

            ////////////////////////////////////////////////////7
            //// Registro de Guia
            ////

            t_cardcode_d.Clear();
            t_cardname_d.Clear();

            //t_object.Text = CardCode;
            t_cardname.Text = CardName;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cLineId_D, cError, cGrupoAtr_D;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_old_D, cNuez_Visible;

            double nDesde_D, nHasta_D, nMedicion_D;
            double nStandar_D;

            int nFila;

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nFila = 0;
            cNuez_Visible = "";

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
                    cUM_D = dTable.Rows[i]["U_UmAtr"].ToString();

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
                grilla[10] = cGrupoAtr_old_D;

                cNuez_Visible = "SI";

                if (cCode_D.ToString() == "NU_2_001")
                {
                    label23.Visible = true;
                    cbb_nuez_material_extranho.Visible = true;

                    //label24.Visible = false;
                    //cbb_caracteristicas.Visible = false;

                    cNuez_Visible = "NO";
                    t_id_material_extranho.Text = cLineId_D.ToString();

                    if (nMedicion_D == 0)
                    {
                        cbb_nuez_material_extranho.SelectedIndex = 0;
                    }

                    if (nMedicion_D == 1)
                    {
                        cbb_nuez_material_extranho.SelectedIndex = 1;
                    }

                    if (nMedicion_D == 2)
                    {
                        cbb_nuez_material_extranho.SelectedIndex = 2;
                    }

                }

                if (cNuez_Visible == "SI")
                {
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
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");
                    }
                    else
                    {
                        if (cError == "S")
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");
                        }
                        else
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");
                        }
                    }

                    nFila = nFila + 1;

                    try
                    {
                        cGrupoAtr_D = dTable.Rows[i + 1]["GrupoAtr"].ToString();
                    }
                    catch
                    {
                        cGrupoAtr_D = "";
                    }

                    if (cGrupoAtr_old_D != cGrupoAtr_D)
                    {
                        grilla[0] = "-1";
                        grilla[1] = "";

                        try
                        {
                            if (cGrupoAtr_old_D.Substring(1, 1) == "_")
                            {
                                grilla[2] = cGrupoAtr_old_D.Substring(2, cGrupoAtr_old_D.Length - 2).ToString();

                            }
                            else
                            {
                                grilla[2] = cGrupoAtr_old_D;

                            }

                        }
                        catch
                        {
                            grilla[2] = cGrupoAtr_old_D;

                        }

                        grilla[3] = "";
                        grilla[4] = "";
                        grilla[5] = "";
                        grilla[6] = "";
                        grilla[7] = "";
                        grilla[8] = "";
                        grilla[9] = "";

                        grilla[10] = cGrupoAtr_old_D;

                        Grid1.Rows.Add(grilla);

                        try
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                        }
                        catch
                        {

                        }

                        grilla[0] = nFila.ToString();
                        grilla[1] = cGrupoAtr_old_D;
                        grilla[2] = cGrupoAtr_old_D;
                        grilla[3] = "0";

                        Grid2.Rows.Add(grilla);

                        nFila = nFila + 1;

                        if (cCode_D.Trim() != "")
                        {
                            if (cGrupoAtr_old_D == "C_DEFECTOS LEVES")
                            {
                                //////////////////////////////////////////////
                                //////////////////////////////////////////////

                                grilla[0] = "-2";
                                grilla[1] = "";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "";
                                grilla[4] = "";
                                grilla[5] = "";
                                grilla[6] = "";
                                grilla[7] = "";
                                grilla[8] = "";
                                grilla[9] = "";
                                grilla[10] = "PEPA EXPORTABLE";

                                Grid1.Rows.Add(grilla);

                                try
                                {
                                    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                                }
                                catch
                                {

                                }

                                grilla[0] = nFila.ToString();
                                grilla[1] = "PEPA EXPORTABLE";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "0";

                                Grid2.Rows.Add(grilla);

                                nFila = nFila + 1;

                            }

                        }


                    }

                    cGrupoAtr_old_D = cGrupoAtr_D;
                }

            }

            pinto_grupos();
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
                btn_aprobar.Visible = true;
                btn_rechazar.Visible = true;

                if ((t_object.Text == "100500") || (t_object.Text == "100502"))
                {
                    if (cCalidad_Aprobacion != "SI")
                    {
                        btn_aprobar.Visible = false;
                        btn_rechazar.Visible = false;

                    }

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

                btn_imprimir.Visible = true;

            }

        }

        private void carga_datos_romana()
        {

            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor;
            string obs, cTipoProducto, cUM;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso, line_id;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, 0);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0].ItemArray[2].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["U_ItemName_D1"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                t_variedad.Text = dTable.Rows[0]["U_HDV_VARIEDAD_D1"].ToString();
            }
            catch
            {
                t_variedad.Clear();
            }

            try
            {
                patente = dTable.Rows[0].ItemArray[6].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[20].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0].ItemArray[16].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0].ItemArray[17].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0].ItemArray[18].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[19].ToString());

            }
            catch
            {
                id_acceso = 0;

            }

            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_cant_prod.Text = 0.ToString("N2");
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_traslado.Text = "Pendiente";
            t_resultado.Text = "En Proceso";

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }

            cUM = "";

            if (ItemCode != "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {

                CardCode = "";
                CardName = "";
                ItemCode = "";
                ItemName = "";

                t_cardcode_d.Clear();
                t_cardname_d.Clear();

                t_itemcode_d.Clear();
                t_itemname_d.Clear();

                clsRomana objproducto1 = new clsRomana();
                objproducto1.cls_Consulta_Partidas_x_id_Detalle(id_romana, line_id);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    CardCode = dTable1.Rows[0]["U_CardCode"].ToString();

                }
                catch
                {
                    CardCode = "";

                }

                try
                {
                    CardName = dTable1.Rows[0]["U_CardName"].ToString();

                }
                catch
                {
                    CardName = "";

                }

                try
                {
                    ItemCode = dTable1.Rows[0]["U_ItemCode"].ToString();

                }
                catch
                {
                    ItemCode = "";
                }

                try
                {
                    ItemName = dTable1.Rows[0]["ItemName_D"].ToString();

                }
                catch
                {
                    ItemName = "";

                }

                try
                {
                    t_variedad.Text = dTable1.Rows[0]["U_HDV_VARIEDAD_D"].ToString();
                }
                catch
                {
                    t_variedad.Clear();
                }

                try
                {
                    cTipoProducto = dTable1.Rows[0]["U_TipoProducto"].ToString();

                }
                catch
                {
                    cTipoProducto = "";
                }

                try
                {
                    cUM = dTable1.Rows[0]["BuyUnitMsr"].ToString();
                }
                catch
                {
                    cUM = "";

                }

                try
                {
                    cant_envases = int.Parse(dTable1.Rows[0]["U_CantBins"].ToString());

                }
                catch
                {
                    cant_envases = 0;

                }


            }

            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            t_traslado.Text = "En Proceso";

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cLineId_D, cContraMuestra, cMuestraDest;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_D, cGrupoAtr_old_D;

            double nDesde_D, nHasta_D, nStandAtr_D;
            double nContraMuestra, nMuestraDest;

            clsCalidad objproducto2 = new clsCalidad();

            if (ItemCode == "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.02")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }

            if (ItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }


            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            int nFila;

            nFila = 0;

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
                    nStandAtr_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandAtr_D = 0;
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

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["GrupoAtr"].ToString();

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


                try
                {
                    cGrupoAtr_D = dTable2.Rows[i + 1]["GrupoAtr"].ToString();

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
                            grilla[2] = cGrupoAtr_old_D;

                        }

                    }

                    grilla[3] = "";
                    grilla[4] = "";
                    grilla[5] = "";
                    grilla[6] = "";
                    grilla[7] = "";

                    grilla[10] = cGrupoAtr_old_D;

                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    grilla[0] = nFila.ToString();
                    grilla[1] = cGrupoAtr_old_D;
                    grilla[2] = cGrupoAtr_old_D;
                    grilla[3] = "0";

                    Grid2.Rows.Add(grilla);

                    nFila = nFila + 1;

                }

                cGrupoAtr_old_D = cGrupoAtr_D;

            }

            pinto_grupos();
            totalizar_grupos();

        }

        private void carga_datos_recepcion_mp()
        {

            int docentry, line_id;

            try
            {
                docentry = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                docentry = 0;

            }

            if (docentry == 0)
            {
                return;
            }


            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor;
            string obs, cTipoProducto, cUM;

            DateTime fecha_hora1, fecha_hora2;

            int numguia, cant_envases;
            int id_acceso, id_DocEntry_romana, id_lineid_romana;

            double nCantProd;
            double nPepaBrutaProm_Productor, nPepaBrutaProm_Temporada;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nCantProd = 0;

            nPepaBrutaProm_Productor = 0;
            nPepaBrutaProm_Temporada = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            id_DocEntry_romana = 0;
            id_lineid_romana = 0;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id1(docentry, line_id);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

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

            try
            {
                patente = dTable.Rows[0]["U_Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["U_Conductor"].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0]["U_Obs"].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0]["U_NumGuia"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["CreateDate"].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["U_DocEntry_Acceso"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }


            try
            {
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

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

            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["U_CantidadBins"].ToString());

            }
            catch
            {
                cant_envases = 0;

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
                cUM = dTable.Rows[0]["BuyUnitMsr"].ToString();
            }
            catch
            {
                cUM = "";

            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();

            }
            catch
            {
                t_lote.Text = "";

            }

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["U_WhsCode"].ToString();

            }
            catch
            {
                t_WhsCode.Text = "";

            }

            try
            {
                nCantProd = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["U_Cantidad"].ToString()));
            }
            catch
            {
                nCantProd = 0;
            }

            try
            {
                id_DocEntry_romana = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["U_RomanaEntry"].ToString()));
            }
            catch
            {
                id_DocEntry_romana = 0;
            }


            id_lineid_romana = line_id;


            t_cant_prod.Text = nCantProd.ToString("N2");
            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_traslado.Text = "Pendiente";
            t_resultado.Text = "En Proceso";

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
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
                nPepaBrutaProm_Productor = Convert.ToDouble(dTable.Rows[0]["Ref_PepaBruta_Productor"].ToString());
            }
            catch
            {
                nPepaBrutaProm_Productor = 0;

            }

            try
            {
                nPepaBrutaProm_Temporada = Convert.ToDouble(dTable.Rows[0]["Ref_PepaBruta_Temporada"].ToString());
            }
            catch
            {
                nPepaBrutaProm_Temporada = 0;

            }


            t_promedio_productor.Text = nPepaBrutaProm_Productor.ToString("N2");
            t_promedio_temporada.Text = nPepaBrutaProm_Temporada.ToString("N2");

            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            t_traslado.Text = "En Proceso";

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string[,] registros_humedad;
            int n_registros_humedad;
            string cCodAtr_Humedad, cNuez_Visible;
            double nMedicionAtr_Humendad;

            registros_humedad = new string[30,2];
            n_registros_humedad = -1;
            cNuez_Visible = "";

            clsCalidad objproducto4 = new clsCalidad();
            objproducto4.cls_Consulta_Atributos_de_Humedad(id_DocEntry_romana, id_lineid_romana);

            DataTable dTable4 = new DataTable();
            dTable4 = objproducto4.cResultado;

            for (int i = 0; i <= dTable4.Rows.Count - 1; i++)
            {

                cCodAtr_Humedad = "";
                nMedicionAtr_Humendad = 0;

                try
                {
                    cCodAtr_Humedad = dTable4.Rows[i]["U_CodAtr"].ToString();
                }
                catch
                {
                    cCodAtr_Humedad = "";
                }

                try
                {
                    nMedicionAtr_Humendad = Double.Parse(dTable4.Rows[i]["U_Medicion"].ToString());

                }
                catch
                {
                    nMedicionAtr_Humendad = 0;

                }

                if (cCodAtr_Humedad != "")
                {
                    if (nMedicionAtr_Humendad > 0)
                    {
                        n_registros_humedad += 1;
                        registros_humedad[n_registros_humedad, 0] = cCodAtr_Humedad;
                        registros_humedad[n_registros_humedad, 1] = nMedicionAtr_Humendad.ToString();

                    }

                }

            }

            ////////////////////////////////////////////////////7
            //// Cargo los registros vacios 
            ////

            string cLineId_D, cContraMuestra, cMuestraDest;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_D, cGrupoAtr_old_D;

            double nDesde_D, nHasta_D, nStandAtr_D;
            double nContraMuestra, nMuestraDest;

            if (ItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }

            clsCalidad objproducto2 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            int nFila;

            nFila = 0;

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

                if (cCode_D.ToString() != "")
                {
                    if (cNuez_Visible == "")
                    {
                        if (cCode_D.ToString().Substring(0, 2) == "NU")
                        {
                            cNuez_Visible = "SI";
                        }
                        else
                        {
                            cNuez_Visible = "NO";
                        }

                        if (cNuez_Visible == "SI")
                        {
                            label23.Visible = true;
                            cbb_nuez_material_extranho.Visible = true;
                        }

                    }

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
                    nStandAtr_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandAtr_D = 0;
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

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["GrupoAtr"].ToString();

                }
                catch
                {
                    cGrupoAtr_D = "";

                }

                if (cGrupoAtr_D == "C_DEFECTOS LEVES")
                {
                    cGrupoAtr_D = "C_DEFECTOS LEVES";
                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");

                nMedicionAtr_Humendad = 0;

                for (int y = 0; y <= n_registros_humedad; y++)
                {
                    if (registros_humedad[y, 0] == cCode_D)
                    {
                        nMedicionAtr_Humendad = Double.Parse(registros_humedad[y, 1]);
                        break;
                    }

                }

                grilla[7] = nMedicionAtr_Humendad.ToString("N2");

                grilla[10] = cGrupoAtr_old_D;

                if (cCode_D != "NU_2_001")
                {


                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    nFila = nFila + 1;

                    try
                    {
                        cGrupoAtr_D = dTable2.Rows[i + 1]["GrupoAtr"].ToString();

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
                                grilla[2] = cGrupoAtr_old_D;

                            }

                        }

                        grilla[3] = "";
                        grilla[4] = "";
                        grilla[5] = "";
                        grilla[6] = "";
                        grilla[7] = "";

                        grilla[10] = cGrupoAtr_old_D;

                        Grid1.Rows.Add(grilla);

                        try
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                        }
                        catch
                        {

                        }

                        grilla[0] = nFila.ToString();
                        grilla[1] = cGrupoAtr_old_D;
                        grilla[2] = cGrupoAtr_old_D;
                        grilla[3] = "0";

                        Grid2.Rows.Add(grilla);

                        nFila = nFila + 1;

                        if (cCode_D.Trim() != "")
                        {
                            if (cGrupoAtr_old_D == "C_DEFECTOS LEVES")
                            {
                                //////////////////////////////////////////////
                                //////////////////////////////////////////////

                                grilla[0] = "-2";
                                grilla[1] = "";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "";
                                grilla[4] = "";
                                grilla[5] = "";
                                grilla[6] = "";
                                grilla[7] = "";
                                grilla[8] = "";
                                grilla[9] = "";
                                grilla[10] = "PEPA EXPORTABLE";

                                Grid1.Rows.Add(grilla);

                                try
                                {
                                    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                                }
                                catch
                                {

                                }

                                grilla[0] = nFila.ToString();
                                grilla[1] = "PEPA EXPORTABLE";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "0";

                                Grid2.Rows.Add(grilla);

                                nFila = nFila + 1;

                            }

                        }

                    }

                    cGrupoAtr_old_D = cGrupoAtr_D;

                }

            }

            pinto_grupos();
            totalizar_grupos();


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
                DocEntry = int.Parse(t_num_guia.Text);
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
                //t_NumOF.Text = dTable.Rows[0]["BaseEntry"].ToString();
            }
            catch
            {
                //t_NumOF.Clear();
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
                //t_tipo_proceso.Text = dTable.Rows[0]["U_Proceso"].ToString();
            }
            catch
            {
                //t_tipo_proceso.Clear();
            }

            if (t_object.Text == "20")
            {
                //t_tipo_proceso.Text = VariablesGlobales.glb_CodeProceso;

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
                //t_cardname_prod.Text = dTable.Rows[0]["U_NOMBPROD"].ToString();
            }
            catch
            {
                //t_cardname_prod.Clear();
            }

            try
            {
                //t_cardname_cliente.Text = dTable.Rows[0]["U_NOMBCLI"].ToString();
            }
            catch
            {
                //t_cardname_cliente.Clear();
            }

            try
            {
                //t_pallet.Text = dTable.Rows[0]["U_FolioPallet"].ToString();
            }
            catch
            {
                //t_pallet.Clear();
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
                //t_familia_subgrupo.Text = dTable.Rows[0]["FamGrupoProducto"].ToString();
            }
            catch
            {
                //t_familia_subgrupo.Text = "";
            }

            try
            {
                //t_familia_codsubgrupo.Text = dTable.Rows[0]["CodFamGrupoProducto"].ToString();
            }
            catch
            {
                //t_familia_codsubgrupo.Text = "";
            }

            ////////////////////////////////////////////////////7
            ////

            if (t_variedad.Text.ToUpper() == "ALMENDRA")
            {
                label24.Visible = true;
                //cbb_caracteristicas.Visible = true;

                //lbl_disponible.Visible = true;
                //cbb_disponible.Visible = true;

                //cbb_disponible.SelectedIndex = 0;

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
                //nNumOF_Referencia = int.Parse(t_NumOF.Text);
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

            ////////////////////////////////////////////////////7
            //// Cargo los registros vacios 
            ////

            string cLineId_D, cContraMuestra, cMuestraDest;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_D, cGrupoAtr_old_D, ItemCode;
            string cNuez_Visible;

            ItemCode = t_itemcode_d.Text;
            cNuez_Visible = "";

            double nDesde_D, nHasta_D, nStandAtr_D;
            double nContraMuestra, nMuestraDest;

            double nMedicionAtr_Humendad, n_registros_humedad;

            nMedicionAtr_Humendad = 0;
            n_registros_humedad = 0;

            if (ItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }

            if (ItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }

            clsCalidad objproducto2 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            string[,] registros_humedad;

            registros_humedad = new string[30, 2];
            n_registros_humedad = -1;
            cNuez_Visible = "";

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            int nFila;

            nFila = 0;

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

                if (cCode_D.ToString() != "")
                {
                    if (cNuez_Visible == "")
                    {
                        if (cCode_D.ToString().Substring(0, 2) == "NU")
                        {
                            cNuez_Visible = "SI";
                        }
                        else
                        {
                            cNuez_Visible = "NO";
                        }

                        if (cNuez_Visible == "SI")
                        {
                            label23.Visible = true;
                            cbb_nuez_material_extranho.Visible = true;
                        }

                    }

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
                    nStandAtr_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandAtr_D = 0;
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

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["GrupoAtr"].ToString();

                }
                catch
                {
                    cGrupoAtr_D = "";

                }

                if (cGrupoAtr_D == "C_DEFECTOS LEVES")
                {
                    cGrupoAtr_D = "C_DEFECTOS LEVES";
                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");

                nMedicionAtr_Humendad = 0;

                for (int y = 0; y <= n_registros_humedad; y++)
                {
                    if (registros_humedad[y, 0] == cCode_D)
                    {
                        nMedicionAtr_Humendad = Double.Parse(registros_humedad[y, 1]);
                        break;
                    }

                }

                grilla[7] = nMedicionAtr_Humendad.ToString("N2");

                grilla[10] = cGrupoAtr_old_D;

                if (cCode_D != "NU_2_001")
                {


                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    nFila = nFila + 1;

                    try
                    {
                        cGrupoAtr_D = dTable2.Rows[i + 1]["GrupoAtr"].ToString();

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
                                grilla[2] = cGrupoAtr_old_D;

                            }

                        }

                        grilla[3] = "";
                        grilla[4] = "";
                        grilla[5] = "";
                        grilla[6] = "";
                        grilla[7] = "";

                        grilla[10] = cGrupoAtr_old_D;

                        Grid1.Rows.Add(grilla);

                        try
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                        }
                        catch
                        {

                        }

                        grilla[0] = nFila.ToString();
                        grilla[1] = cGrupoAtr_old_D;
                        grilla[2] = cGrupoAtr_old_D;
                        grilla[3] = "0";

                        Grid2.Rows.Add(grilla);

                        nFila = nFila + 1;

                        if (cCode_D.Trim() != "")
                        {
                            if (cGrupoAtr_old_D == "C_DEFECTOS LEVES")
                            {
                                //////////////////////////////////////////////
                                //////////////////////////////////////////////

                                grilla[0] = "-2";
                                grilla[1] = "";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "";
                                grilla[4] = "";
                                grilla[5] = "";
                                grilla[6] = "";
                                grilla[7] = "";
                                grilla[8] = "";
                                grilla[9] = "";
                                grilla[10] = "PEPA EXPORTABLE";

                                Grid1.Rows.Add(grilla);

                                try
                                {
                                    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                                }
                                catch
                                {

                                }

                                grilla[0] = nFila.ToString();
                                grilla[1] = "PEPA EXPORTABLE";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "0";

                                Grid2.Rows.Add(grilla);

                                nFila = nFila + 1;

                            }

                        }

                    }

                    cGrupoAtr_old_D = cGrupoAtr_D;

                }

            }

            pinto_grupos();
            totalizar_grupos();

        }

        private void carga_datos_recepcion_pt_secado()
        {

            int docentry, line_id;

            try
            {
                docentry = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                docentry = 0;

            }

            if (docentry == 0)
            {
                return;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor;
            string obs, cTipoProducto, cUM;

            DateTime fecha_hora1, fecha_hora2;

            int numguia, cant_envases;
            int id_acceso, id_DocEntry_romana, id_lineid_romana;

            double nCantProd;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nCantProd = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            id_DocEntry_romana = 0;
            id_lineid_romana = 0;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id2(docentry, line_id);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0]["CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0]["ItemCode"].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["Dscription"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                patente = dTable.Rows[0]["U_DTE_Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["U_DTE_NombreChofer"].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0]["Comments"].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0]["FolioNum"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["CreateDate"].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["U_DocEntry_Acceso"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }

            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["U_BINS"].ToString());

            }
            catch
            {
                cant_envases = 0;

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
                cUM = dTable.Rows[0]["BuyUnitMsr"].ToString();
            }
            catch
            {
                cUM = "";

            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();

            }
            catch
            {
                t_lote.Text = "";

            }

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["WhsCode"].ToString();

            }
            catch
            {
                t_WhsCode.Text = "";

            }

            try
            {
                nCantProd = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["Quantity"].ToString()));
            }
            catch
            {
                nCantProd = 0;
            }

            try
            {
                id_DocEntry_romana = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["U_RomanaEntry"].ToString()));
            }
            catch
            {
                id_DocEntry_romana = 0;
            }


            id_lineid_romana = line_id;


            t_cant_prod.Text = nCantProd.ToString("N2");
            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_traslado.Text = "Pendiente";
            t_resultado.Text = "En Proceso";

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }

            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            t_traslado.Text = "En Proceso";

            //Cargo_detalle_x_producto(id_DocEntry_romana, id_lineid_romana, ItemCode);

        }

        private void Cargo_detalle_x_producto(int id_DocEntry_romana, int id_lineid_romana , string ItemCode)
        {
            
            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string[,] registros_humedad;
            int n_registros_humedad;
            string cCodAtr_Humedad, cNuez_Visible;
            double nMedicionAtr_Humendad;

            registros_humedad = new string[30, 2];
            n_registros_humedad = -1;
            cNuez_Visible = "";

            clsCalidad objproducto4 = new clsCalidad();
            objproducto4.cls_Consulta_Atributos_de_Humedad(id_DocEntry_romana, id_lineid_romana);

            DataTable dTable4 = new DataTable();
            dTable4 = objproducto4.cResultado;

            for (int i = 0; i <= dTable4.Rows.Count - 1; i++)
            {

                cCodAtr_Humedad = "";
                nMedicionAtr_Humendad = 0;

                try
                {
                    cCodAtr_Humedad = dTable4.Rows[i]["U_CodAtr"].ToString();
                }
                catch
                {
                    cCodAtr_Humedad = "";
                }

                try
                {
                    nMedicionAtr_Humendad = Double.Parse(dTable4.Rows[i]["U_Medicion"].ToString());

                }
                catch
                {
                    nMedicionAtr_Humendad = 0;

                }

                if (cCodAtr_Humedad != "")
                {
                    if (nMedicionAtr_Humendad > 0)
                    {
                        n_registros_humedad += 1;
                        registros_humedad[n_registros_humedad, 0] = cCodAtr_Humedad;
                        registros_humedad[n_registros_humedad, 1] = nMedicionAtr_Humendad.ToString();

                    }

                }

            }

            ////////////////////////////////////////////////////7
            //// Cargo los registros vacios 
            ////

            string cLineId_D, cContraMuestra, cMuestraDest;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_D, cGrupoAtr_old_D;

            double nDesde_D, nHasta_D, nStandAtr_D;
            double nContraMuestra, nMuestraDest;

            if (ItemCode == "FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01")
            {
                ItemCode = "FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01";
            }

            clsCalidad objproducto2 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            int nFila;

            nFila = 0;

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

                if (cCode_D.ToString() != "")
                {
                    if (cNuez_Visible == "")
                    {
                        if (cCode_D.ToString().Substring(0, 2) == "NU")
                        {
                            cNuez_Visible = "SI";
                        }
                        else
                        {
                            cNuez_Visible = "NO";
                        }

                        if (cNuez_Visible == "SI")
                        {
                            label23.Visible = true;
                            cbb_nuez_material_extranho.Visible = true;
                        }

                    }

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
                    nStandAtr_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandAtr_D = 0;
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

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["GrupoAtr"].ToString();

                }
                catch
                {
                    cGrupoAtr_D = "";

                }

                if (cGrupoAtr_D == "C_DEFECTOS LEVES")
                {
                    cGrupoAtr_D = "C_DEFECTOS LEVES";
                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");

                nMedicionAtr_Humendad = 0;

                for (int y = 0; y <= n_registros_humedad; y++)
                {
                    if (registros_humedad[y, 0] == cCode_D)
                    {
                        nMedicionAtr_Humendad = Double.Parse(registros_humedad[y, 1]);
                        break;
                    }

                }

                grilla[7] = nMedicionAtr_Humendad.ToString("N2");

                grilla[10] = cGrupoAtr_old_D;

                if (cCode_D != "NU_2_001")
                {


                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    nFila = nFila + 1;

                    try
                    {
                        cGrupoAtr_D = dTable2.Rows[i + 1]["GrupoAtr"].ToString();

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
                                grilla[2] = cGrupoAtr_old_D;

                            }

                        }

                        grilla[3] = "";
                        grilla[4] = "";
                        grilla[5] = "";
                        grilla[6] = "";
                        grilla[7] = "";

                        grilla[10] = cGrupoAtr_old_D;

                        Grid1.Rows.Add(grilla);

                        try
                        {
                            Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                        }
                        catch
                        {

                        }

                        grilla[0] = nFila.ToString();
                        grilla[1] = cGrupoAtr_old_D;
                        grilla[2] = cGrupoAtr_old_D;
                        grilla[3] = "0";

                        Grid2.Rows.Add(grilla);

                        nFila = nFila + 1;

                        if (cCode_D.Trim() != "")
                        {
                            if (cGrupoAtr_old_D == "C_DEFECTOS LEVES")
                            {
                                //////////////////////////////////////////////
                                //////////////////////////////////////////////

                                grilla[0] = "-2";
                                grilla[1] = "";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "";
                                grilla[4] = "";
                                grilla[5] = "";
                                grilla[6] = "";
                                grilla[7] = "";
                                grilla[8] = "";
                                grilla[9] = "";
                                grilla[10] = "PEPA EXPORTABLE";

                                Grid1.Rows.Add(grilla);

                                try
                                {
                                    Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                                }
                                catch
                                {

                                }

                                grilla[0] = nFila.ToString();
                                grilla[1] = "PEPA EXPORTABLE";
                                grilla[2] = "PEPA EXPORTABLE";
                                grilla[3] = "0";

                                Grid2.Rows.Add(grilla);

                                nFila = nFila + 1;

                            }

                        }

                    }

                    cGrupoAtr_old_D = cGrupoAtr_D;

                }

            }

            pinto_grupos();
            totalizar_grupos();

        }

        private void carga_datos_cabecera_romana()
        {

            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor;
            string obs;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso, line_id;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, 0);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0].ItemArray[2].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["U_ItemName_D1"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                t_variedad.Text = dTable.Rows[0]["U_HDV_VARIEDAD_D1"].ToString();
            }
            catch
            {
                t_variedad.Clear();
            }

            try
            {
                patente = dTable.Rows[0].ItemArray[6].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[20].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0].ItemArray[16].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                cant_envases = int.Parse(dTable.Rows[0].ItemArray[7].ToString());

            }
            catch
            {
                cant_envases = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0].ItemArray[17].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0].ItemArray[18].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[19].ToString());

            }
            catch
            {
                id_acceso = 0;

            }

            //t_object.Text = CardCode;
            t_cardname.Text = CardName;

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }

            CardCode = "";
            CardName = "";

            t_cardcode_d.Clear();
            t_cardname_d.Clear();

            clsRomana objproducto1 = new clsRomana();
            objproducto1.cls_Consulta_Partidas_x_id_Detalle(id_romana, line_id);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            try
            {
                CardCode = dTable1.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable1.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;


        }

        private void carga_datos_cabecera_mp()
        {

            int docentry, line_id;

            try
            {
                docentry = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                docentry = 0;

            }

            if (docentry == 0)
            {
                return;
            }

            try
            {
                line_id = int.Parse(t_lineid.Text);
            }
            catch
            {
                line_id = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor;
            string obs, cTipoProducto, cUM;

            DateTime fecha_hora1, fecha_hora2;

            int numguia, cant_envases;
            int id_acceso;

            double nCantProd;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nCantProd = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id1(docentry, line_id);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

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

            try
            {
                patente = dTable.Rows[0]["U_Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["U_Conductor"].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0]["U_Obs"].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0]["U_NumGuia"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["CreateDate"].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());

            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["U_DocEntry_Acceso"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }


            try
            {
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["U_CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

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

            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["U_CantidadBins"].ToString());

            }
            catch
            {
                cant_envases = 0;

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
                cUM = dTable.Rows[0]["BuyUnitMsr"].ToString();
            }
            catch
            {
                cUM = "";

            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();

            }
            catch
            {
                t_lote.Text = "";

            }

            try
            {
                //t_WhsCode.Text = dTable.Rows[0]["U_WhsCode"].ToString();

            }
            catch
            {
                //t_WhsCode.Text = "";

            }

            try
            {
                nCantProd = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["U_Cantidad"].ToString()));
            }
            catch
            {
                nCantProd = 0;
            }

            t_cant_prod.Text = nCantProd.ToString("N2");
            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }


            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            if (ItemCode != "")
            {
                t_itemcode_d.Text = ItemCode;
                t_itemname_d.Text = ItemName;

            }

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            if (t_fecha_ingreso.Text == "")
            {
                t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string cContraMuestra, cMuestraDest, cGrupoAtr_old_D;
            double nContraMuestra, nMuestraDest;

            clsCalidad objproducto2 = new clsCalidad();

            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

        }


        private void lnk_ver_documento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int id_acceso;

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);

            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso > 0)
            {

                VariablesGlobales.glb_id_acceso = id_acceso;
                VariablesGlobales.glb_Referencia2 = "N";

                frmPorteria2 f2 = new frmPorteria2();
                DialogResult res = f2.ShowDialog();

            }

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
            string cObjetc, cWhsCode, cWhsDest;
            string cNumCon;

            int nDocEntry, nNumDoc, nDocEntryRef;
            int nLineIdRef;

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
                nNumDoc = Convert.ToInt32(t_num_guia.Text);

            }
            catch
            {
                nNumDoc = 0;

            }

            try
            {
                nDocEntryRef = Convert.ToInt32(t_id_ref.Text);

            }
            catch
            {
                nDocEntryRef = 0;

            }

            cWhsCode = t_WhsCode.Text;
            cWhsDest = t_WhsDest.Text;

            string UserCode, cUM, cU_AtrT1;
            int UserId;

            double nBultos, nBultosMuestrear;
            double nCantidad, nCoMuSize, nMuDeSize;

            nCantidad = 0;
            nBultos = 0;
            nBultosMuestrear = 0;
            nCoMuSize = 0;
            nMuDeSize = 0;

            try
            {
                nCantidad = Convert.ToDouble(t_cant_prod.Text);

            }
            catch
            {
                nCantidad = 0;

            }

            try
            {
                nBultos = Convert.ToDouble(t_num_bultos.Text);
            }
            catch
            {
                nBultos = 0;
            }

            try
            {
                nBultosMuestrear = Convert.ToDouble(t_bultos_a_muestrear.Text);
            }
            catch
            {
                nBultosMuestrear = 0;
            }

            try
            {
                nCoMuSize = Convert.ToDouble(t_cant_contra_muestra.Text);
            }
            catch
            {
                nCoMuSize = 0;
            }

            try
            {
                nMuDeSize = Convert.ToDouble(t_cant_muestra_destructiva.Text);
            }
            catch
            {
                nMuDeSize = 0;
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

            try
            {
                cU_AtrT1 = t_U_AtrT1.Text;
            }
            catch
            {
                cU_AtrT1 = "";
            }

            String mensaje;

            mensaje = "";

            mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, dt.ToString("yyyyMMdd"), cUM, nCoMuSize, nMuDeSize, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef,"","",0,"","S", cU_AtrT1,"");
            
            if (mensaje != "Y")
            {
                MessageBox.Show("Error: " + mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            nLineId = 0;

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

                //if (cCodAtr== "NU_2_004")
                //{
                //    cCodAtr = cCodAtr;
                //}

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

            

            if (cbb_nuez_material_extranho.Visible == true)
            {
                int nNuez_Medicion_Material_Extranho, nLineId_Material_Extranho;

                nNuez_Medicion_Material_Extranho = 0;

                if (cbb_nuez_material_extranho.SelectedIndex == 0)
                {
                    nNuez_Medicion_Material_Extranho = 0;
                }

                if (cbb_nuez_material_extranho.SelectedIndex == 1)
                {
                    nNuez_Medicion_Material_Extranho = 1;
                }

                if (cbb_nuez_material_extranho.SelectedIndex == 2)
                {
                    nNuez_Medicion_Material_Extranho = 2;
                }

                try
                {
                    nLineId_Material_Extranho = int.Parse(t_id_material_extranho.Text);
                }
                catch
                {
                    nLineId_Material_Extranho = nLineId + 1;
                }
               
                mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId_Material_Extranho, "NU_2_001", "Material extraño", 0, 0, 0, nNuez_Medicion_Material_Extranho, "", "", "", 0);
            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VariablesGlobales.glb_id_calidad = nDocEntry;
                frmCalidadMP_Load(sender,e);

            }
            else
            {
                MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

            }
            else
            {
                if (cError == "S")
                {
                    Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\cancel.png");

                }
                else
                {
                    Grid1[9, fila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\accept.png");

                }

            }

            totalizar_grupos();

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

            if (t_object.Text == "100500")
            {
                if (VariablesGlobales.glb_tipo_usuario == "2")
                {
                    MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

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

                string UserCode, cAtrT1;
                int UserId, nStockTransferEntry;

                try
                {
                    cAtrT1 = t_U_AtrT1.Text;
                }
                catch
                {
                    cAtrT1 = "";
                }

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

                    String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "A", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref,"","",0,"","S", cAtrT1,"");

                    if (t_object.Text == "100500")
                    {

                        ///////////////////////////////////////////////////////////////
                        /// Si es materia prima debe generar una transferencia de stock
                        /// 

                        DateTime dt;
                        int nCantidadContraMuestra;
                        double nPesoLote, nPesoTotal;

                        try
                        {
                            nCantidadContraMuestra = int.Parse(Convert.ToDouble(t_cant_contra_muestra.Text).ToString());
                        }
                        catch
                        {
                            nCantidadContraMuestra = 0;
                        }

                        try
                        {
                            nPesoTotal = Convert.ToDouble(t_cant_prod.Text);
                        }
                        catch
                        {
                            nPesoTotal = 0;
                        }

                        dt = DateTime.Now;

                        string[,] d_arrDetalleBins = new string[20, 10];

                        ////////////////////////////////////////
                        // Genero la transferencia con los bins

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

                        //////////////////////////////////////////////
                        // Genero la transferencia a bodega de calidad

                        if (nCantidadContraMuestra > 0)
                        {
                            //d_arrDetalleBins[1, 0] = t_itemcode_d.Text; // ItemCode 
                            //d_arrDetalleBins[2, 0] = nCantidadContraMuestra.ToString(); //Cantidad
                            //d_arrDetalleBins[3, 0] = t_WhsCode.Text; // Almacen  
                            //d_arrDetalleBins[4, 0] = "LABCC"; // "C_NMEC_2"; // Almacen Destino
                            //d_arrDetalleBins[5, 0] = "0";
                            //d_arrDetalleBins[6, 0] = t_lote.Text; // lote

                            //mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                            //try
                            //{
                            //    nStockTransferEntry = int.Parse(mensaje);
                            //}
                            //catch
                            //{
                            //    MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    nStockTransferEntry = 0;

                            //}

                            //////////////////////////////////////
                            //////////////////////////////////////
                            // Genero la referencia con la transferencia con los bins

                            //mensaje = clsRecepcion.SAPB1_Recepcion2(nDocEntry, 0, nCantidadContraMuestra, nStockTransferEntry, "HDV_ORCAL", 0);

                        }


                        ////////////////////////////////////////////////////
                        // Genero la transferencia a bodega de materia prima
                        if (t_WhsCode.Text.Substring(1, 1) != "_")
                        {
                            nPesoTotal = 0;
                        }

                        if (nPesoTotal > 0)
                        {
                            nPesoLote = nPesoTotal - nCantidadContraMuestra;

                            d_arrDetalleBins[1, 0] = t_itemcode_d.Text; // ItemCode 
                            d_arrDetalleBins[2, 0] = nPesoLote.ToString(); //Cantidad
                            d_arrDetalleBins[3, 0] = t_WhsCode.Text; // Almacen  
                            d_arrDetalleBins[4, 0] = "BMPP1"; // "C_NMEC_2"; // Almacen Destino
                            d_arrDetalleBins[5, 0] = "0";
                            d_arrDetalleBins[6, 0] = t_lote.Text; // lote

                            //mensaje = clsRecepcion.Stock_Transfer("", "", "", dt.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                            try
                            {
                                nStockTransferEntry = int.Parse(mensaje);
                            }
                            catch
                            {
                                MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                nStockTransferEntry = 0;

                            }

                        }

                        ////////////////////////////////////////////////////
                        // Desbloquea el lote

                        //mensaje = clsRecepcion.CambiaStatus_Lote(int.Parse(t_lote.Text), 0, UsuarioSap, ClaveSap);

                    }

                    if (mensaje == "Y")
                    {
                        MessageBox.Show("Registro Aprobado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    VariablesGlobales.glb_id_calidad = nDocEntry;
                    VariablesGlobales.glb_id_romana = int.Parse(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = int.Parse(t_lineid.Text);
                    VariablesGlobales.glb_Object = t_object.Text;

                    VariablesGlobales.glb_Referencia3 = nDocEntry.ToString();

                    frmCalidadMP_Load(sender, e);

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

                    if (mensaje == "Y")
                    {
                        genera_nuevo_registro();
                    }

                }
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void genera_nuevo_registro()
        {

            t_doc_entry.Text = "0";

            btn_ok.Enabled = true;
            btn_aprobar.Enabled = true;
            btn_rechazar.Enabled = true;

            t_resultado.Clear();
            t_traslado.Clear();

            carga_datos_romana();

        }

        private void btn_nuevo_reg_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar un Nuevo Registro de Inspección", "Registro de Inspección ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                genera_nuevo_registro();
                btn_nuevo_reg.Visible = false;

            }

        }

        private void pinto_grupos()
        {

            int nLineId;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = 0;

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId = -3;
                }

                if (nLineId == -1)
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightGray;

                    }

                }

                if (nLineId == -2)
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        Grid1[x, i].Style.BackColor = Color.LightBlue;

                    }

                }


            }

        }


        private void totalizar_grupos()
        {
            int nLineId, nAtributo;
            string cAtributo, cAtributoRef, cCodAtr;

            double nSubTotal, nItems, nTotal;
            double nValor, nPorcentaje;

            double nNuez_Calibre, nNuez_TotalDahno, nNuez_AnalisisColor;
            double nNuez_Gramos100u;

            double nAlmendra_PepaBruta, nAlmendra_DefectoLeve, nAlmendra_DefectoGrave;
            double nAlmendra_PepaExportable, nAlmendra_Rendimiento, nAlmendra_OtrosDefectos;
            double nAlmendra_Partidas_Minicracker, nAlmendra_pepa_para_analisis;
            double nAlmendra_Rendimiento_Pepa, nAlmendra_PepaSuelta;

            double nCiruela_Humedad, nCiruela_DanhoSeco, nCiruela_DanhoHumedo;
            double nCiruela_Calibre;


            nNuez_Calibre = 0;
            nNuez_AnalisisColor = 0;
            nNuez_TotalDahno = 0;

            nAlmendra_PepaBruta = 0;
            nAlmendra_DefectoLeve = 0;
            nAlmendra_DefectoGrave = 0;
            nAlmendra_PepaExportable = 0;
            nAlmendra_Rendimiento = 0;
            nAlmendra_OtrosDefectos = 0;
            nAlmendra_Partidas_Minicracker = 0;
            nAlmendra_pepa_para_analisis = 0;
            nAlmendra_Rendimiento_Pepa = 0;
            nAlmendra_PepaSuelta = 0;

            nCiruela_Humedad = 0;
            nCiruela_DanhoSeco = 0;
            nCiruela_DanhoHumedo = 0;
            nCiruela_Calibre = 0;

            string[] atributo1;
            atributo1 = new string[50];

            double[] atributo2;
            atributo2 = new double[50];

            nAtributo = -1;
            cAtributoRef = "";
            cCodAtr = "";

            ///////////////////////////////////////7
            //// Determino los totales particulares

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

                if (nLineId > 0)
                {

                    if (nValor > 0)
                    {

                        if (cCodAtr.Substring(0, 2) == "CI")
                        {
                            if (cAtributoRef == "HUMEDAD")
                            {
                                nCiruela_Humedad += nValor;
                            }

                            if (cAtributoRef == "DAÑO MUESTRA SECA")
                            {
                                nCiruela_DanhoSeco += nValor;
                            }

                            if (cAtributoRef == "DAÑO MUESTRA HUMEDA")
                            {
                                nCiruela_DanhoHumedo += nValor;
                            }

                            if (cAtributoRef == "CALIBRE")
                            {
                                nCiruela_Calibre += nValor;
                            }

                        }

                        if (cCodAtr.Substring(0,2)=="NU")
                        {
                            if (cAtributoRef == "A_CALIBRE")
                            {
                                nNuez_Calibre += nValor;
                            }

                            if (cAtributoRef == "D_ANALISIS COLOR")
                            {
                                nNuez_AnalisisColor += nValor;
                            }

                            if (cAtributoRef == "C_DAÑOS INTERNOS")
                            {
                                nNuez_TotalDahno += nValor;
                            }

                        }


                        if (cCodAtr.Substring(0, 2) == "AL")
                        {
                            if (cCodAtr == "AL_2_007")
                            {
                                nAlmendra_PepaSuelta = nValor;
                            }

                            if (cCodAtr == "AL_2_008")
                            {
                                nAlmendra_PepaBruta += nValor;
                            }

                            if (cCodAtr == "AL_5_100")
                            {
                                nAlmendra_Partidas_Minicracker = nValor;
                            }

                            if (cAtributoRef == "A_RENDIMIENTO")
                            {
                                if (cCodAtr != "AL_2_009")
                                {
                                    nAlmendra_Rendimiento += nValor;

                                }

                            }

                            if (cAtributoRef == "B_DEFECTOS GRAVES")
                            {
                                nAlmendra_DefectoLeve += nValor;
                            }

                            if (cAtributoRef == "C_DEFECTOS LEVES")
                            {
                                nAlmendra_DefectoGrave += nValor;
                            }

                            if (cAtributoRef == "C_OTROS DEFECTOS")
                            {
                                nAlmendra_OtrosDefectos += nValor;
                            }

                        }

                    }

                }

            }

            try
            {
                try
                {
                    cCodAtr = Grid1[1, 0].Value.ToString();
                }
                catch
                {
                    cCodAtr = "";
                }

                if (cCodAtr.Substring(0, 2) == "AL")
                {
                    nAlmendra_Rendimiento_Pepa = nAlmendra_PepaBruta + nAlmendra_PepaSuelta;

                    nAlmendra_pepa_para_analisis = nAlmendra_Rendimiento_Pepa - nAlmendra_Partidas_Minicracker;
                    //nAlmendra_pepa_para_analisis = nAlmendra_PepaBruta - nAlmendra_Partidas_Minicracker;

                    if (nAlmendra_pepa_para_analisis < 0)
                    {
                        nAlmendra_pepa_para_analisis = 0;
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
                            cCodAtr = Grid1[1, x].Value.ToString();
                        }
                        catch
                        {
                            cCodAtr = "";
                        }

                        if (nLineId > 0)
                        {

                            if (cCodAtr == "AL_2_009")
                            {
                                Grid1[7, x].Value = nAlmendra_Rendimiento_Pepa.ToString("N2");

                            }

                            if (cCodAtr == "AL_5_110")
                            {
                                Grid1[7, x].Value = nAlmendra_pepa_para_analisis.ToString("N2");
                                break;
                            }

                        }

                    }

                }

            }
            catch
            {

            }
        
            nAlmendra_PepaExportable = nAlmendra_PepaBruta - (nAlmendra_DefectoLeve + nAlmendra_DefectoGrave + nAlmendra_OtrosDefectos);

            /////////////////////////////////////////////////7
            //// Actualizo el reigstro - Nuez - Total de daños

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
                
                if (nLineId > 0)
                {
                    if (cCodAtr == "NU_5_008")
                    {
                        Grid1[7, x].Value = nNuez_TotalDahno.ToString("N2");
                        break;
                    }

                }

            }


            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                
                try
                {
                    cAtributo = Grid2[1, i].Value.ToString();
                }
                catch
                {
                    cAtributo = "";
                }

                if (cAtributo== "C_DEFECTOS LEVES")
                {
                    cAtributo = "C_DEFECTOS LEVES";
                }

                /////////////////////////////////////7
                //// calcular el total por grupo

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

                    if (cCodAtr == "AL_2_009")
                    {
                        nValor = 0;

                    }

                    if (Grid1[1, x].Value.ToString() != "")
                    {
                        if (cAtributoRef == cAtributo)
                        {
                            if (nLineId >= 0)
                            {
                                if (nValor > 0)
                                {
                                    nSubTotal = nSubTotal + nValor;
                                }
                            }
                        }

                    }


                }

                Grid2[3, i].Value = nSubTotal.ToString();

                /////////////////////////////////////
                //// actualizo los totales por grupo

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

                    if (cAtributoRef == cAtributo)
                    {
                        if (nLineId < 0)
                        {
                            Grid1[7, x].Value = nSubTotal.ToString("N2");
                           
                        }

                    }

                    if (cAtributoRef == "PEPA EXPORTABLE")
                    {
                        if (nLineId < 0)
                        {
                            //nAlmendra_PepaExportable = nAlmendra_PepaBruta - (nAlmendra_DefectoLeve + nAlmendra_DefectoGrave + nAlmendra_OtrosDefectos);
                            nAlmendra_PepaExportable = nAlmendra_pepa_para_analisis - (nAlmendra_DefectoLeve + nAlmendra_DefectoGrave + nAlmendra_OtrosDefectos);
                            Grid1[7, x].Value = nAlmendra_PepaExportable.ToString("N2");

                        }

                    }


                }

                /////////////////////////////////////7
                //// calcular el porcentaje por linea

                for (int x = 0; x <= Grid1.RowCount - 1; x++)
                {
                    try
                    {
                        nLineId = Convert.ToInt32(Grid1[0, i].Value.ToString());
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
                        nValor = -2;
                    }

                    try
                    {
                        cCodAtr = Grid1[1, 0].Value.ToString();
                    }
                    catch
                    {
                        cCodAtr = "";
                    }

                    if (cAtributoRef == cAtributo)
                    {
                        nPorcentaje = 0;

                        if (cCodAtr.Trim() != "")
                        {
                            if (cCodAtr.Substring(0, 2) == "NU")
                            {
                                if (cAtributoRef == "B_DAÑOS EXTERNOS")
                                {
                                    if (nNuez_Calibre > 0)
                                    {
                                        nPorcentaje = nValor / nNuez_Calibre * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "C_DAÑOS INTERNOS")
                                {
                                    if (nNuez_AnalisisColor > 0)
                                    {
                                        nPorcentaje = nValor / nNuez_AnalisisColor * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if ((cAtributoRef != "B_DAÑOS EXTERNOS") && (cAtributoRef != "C_DAÑOS INTERNOS"))
                                {
                                    if (nSubTotal > 0)
                                    {
                                        nPorcentaje = nValor / nSubTotal * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (Grid1[1, x].Value.ToString() == "NU_2_002")
                                {
                                    if (nSubTotal > 0)
                                    {
                                        nPorcentaje = nValor / 10;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (Grid1[1, x].Value.ToString() == "NU_2_003")
                                {
                                    if (nSubTotal > 0)
                                    {
                                        nPorcentaje = nValor / 10;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (Grid1[1, x].Value.ToString() == "NU_2_004")
                                {
                                    nPorcentaje = 0;

                                }

                            }

                            if (cCodAtr.Substring(0, 2) == "AL")
                            {
                                if (cAtributoRef == "PEPA EXPORTABLE")
                                {
                                    if (nAlmendra_Rendimiento > 0)
                                    {
                                        nPorcentaje = nAlmendra_PepaExportable / nAlmendra_Rendimiento * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "A_TOTAL RENDIMIENTO")
                                {
                                    if (nAlmendra_PepaBruta > 0)
                                    {
                                        nPorcentaje = nValor / nAlmendra_PepaBruta * 100;
                                        //nPorcentaje = nValor / nAlmendra_pepa_para_analisis * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "B_DEFECTOS GRAVES")
                                {
                                    if (nAlmendra_PepaBruta > 0)
                                    {
                                        //nPorcentaje = nValor / nAlmendra_PepaBruta * 100;
                                        nPorcentaje = nValor / nAlmendra_pepa_para_analisis * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "C_DEFECTOS LEVES")
                                {
                                    if (nAlmendra_PepaBruta > 0)
                                    {
                                        //nPorcentaje = nValor / nAlmendra_PepaBruta * 100;
                                        nPorcentaje = nValor / nAlmendra_pepa_para_analisis * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "C_OTROS DEFECTOS")
                                {
                                    if (nAlmendra_PepaBruta > 0)
                                    {
                                        //nPorcentaje = nValor / nAlmendra_PepaBruta * 100;
                                        nPorcentaje = nValor / nAlmendra_pepa_para_analisis * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if (cAtributoRef == "D_CALIBRE")
                                {
                                    if (nAlmendra_PepaExportable > 0)
                                    {
                                        nPorcentaje = nValor / nAlmendra_PepaExportable * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                                if ((cAtributoRef != "B_DEFECTOS GRAVES") && (cAtributoRef != "C_DEFECTOS LEVES") && (cAtributoRef != "D_CALIBRE") && (cAtributoRef != "PEPA EXPORTABLE") && (cAtributoRef != "C_OTROS DEFECTOS") && (cAtributoRef != "A_TOTAL RENDIMIENTO"))
                                {
                                    if (nSubTotal > 0)
                                    {
                                        nPorcentaje = nValor / nSubTotal * 100;
                                    }
                                    else
                                    {
                                        nPorcentaje = 0;
                                    }

                                }

                            }

                        }

                        if (cCodAtr.Substring(0, 2) == "CI")
                        {
                            if (cAtributoRef == "HUMEDAD")
                            {
                                if (nCiruela_Humedad > 0)
                                {
                                    nPorcentaje = nValor / nCiruela_Humedad * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }

                            if (cAtributoRef == "DAÑO MUESTRA SECA")
                            {
                                if (nCiruela_DanhoSeco > 0)
                                {
                                    nPorcentaje = nValor / nCiruela_DanhoSeco * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }

                            if (cAtributoRef == "DAÑO MUESTRA HUMEDA")
                            {
                                if (nCiruela_DanhoHumedo > 0)
                                {
                                    nPorcentaje = nValor / nCiruela_DanhoHumedo * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }

                            if (cAtributoRef == "CALIBRE")
                            {
                                if (nCiruela_Calibre > 0)
                                {
                                    nPorcentaje = nValor / nCiruela_Calibre  * 100;
                                }
                                else
                                {
                                    nPorcentaje = 0;
                                }

                            }

                        }

                        try
                        {
                            if (cAtributo.Substring(0, 4) != "HUME")
                            {
                                if (Grid1[1, x].Value.ToString() != "NU_2_004")
                                {
                                    Grid1[8, x].Value = nPorcentaje.ToString("N2");
                                }
                                else
                                {
                                    Grid1[8, x].Value = "";
                                }

                            }
                            else
                            {
                                Grid1[8, x].Value = "";
                            }

                        }
                        catch
                        {
                            Grid1[8, x].Value = "";

                        }


                    }

                }

            }

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                nLineId = 0;

                try
                {
                    nLineId = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nLineId = -2;
                }

                try
                {
                    cAtributo = Grid1[10, i].Value.ToString();
                }
                catch
                {
                    cAtributo = "";
                }

                if (nLineId >= 0)
                {
                    cAtributoRef = "";

                    for (int x = 0; x <= nAtributo; x++)
                    {
                        if (atributo1[x] == cAtributo)
                        {
                            cAtributoRef = cAtributo;

                        }

                    }

                    if (cAtributoRef == "")
                    {
                        nAtributo = nAtributo + 1;
                        atributo1[nAtributo] = cAtributo;
                        atributo2[nAtributo] = 0;

                    }

                }

            }

            /////////////////////////////////////
            //// Calculo los valores por grupo y los actualizo

            double nNuez_Rendimiento;

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

                nSubTotal = 0;
                nItems = 0;
                nTotal = 0;
                nValor = 0;
                nNuez_Gramos100u = 0;
                nNuez_Rendimiento = 0;

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
                        nValor = -2;
                    }

                    if (cAtributoRef == cAtributo)
                    {
                        if (nLineId >= 0)
                        {
                            if (nValor > 0)
                            {
                                nSubTotal = nSubTotal + nValor;
                                nItems = nItems + 1;

                            }

                        }

                    }

                    if (Grid1[1, x].Value.ToString() == "NU_2_004")
                    {
                        try
                        {
                            nNuez_Gramos100u = Convert.ToDouble(Grid1[7, x].Value);

                        }
                        catch
                        {
                            nNuez_Gramos100u = 0;
                        }

                    }
                    

                    if (Grid1[1, x].Value.ToString() == "NU_5_009")
                    {
                        nNuez_Rendimiento = 0;

                        if (nNuez_Gramos100u != 0)
                        {
                            nNuez_Rendimiento = (nNuez_TotalDahno + nNuez_AnalisisColor) / nNuez_Gramos100u * 100;

                        }
                        else
                        {
                            nNuez_Rendimiento = 0;

                        }

                        Grid1[7, x].Value = nNuez_Rendimiento.ToString("N");

                    }

                }

                if (nSubTotal > 0)
                {
                    if (cAtributo.Trim() != "")
                    {

                        if (cAtributo.Substring(0, 4) == "HUME")
                        {

                            try
                            {
                                nTotal = nSubTotal / nItems;

                            }
                            catch
                            {
                                nTotal = 0;

                            }

                        }
                        else
                        {
                            nTotal = nSubTotal;
                        }

                    }
                    else
                    {
                        nTotal = nSubTotal;
                    }


                }

                atributo2[i] = nTotal;

            }



        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int nIdCalidad;
            string cTipoInforme;

            try
            {
                nIdCalidad = Convert.ToInt32(t_doc_entry.Text);

            }
            catch
            {
                nIdCalidad = 0;

            }

            cTipoInforme = "";

            if (t_object.Text == "100100")
            {
                cTipoInforme = "H";
            }
            else
            {
                cTipoInforme = "";
            }

            VariablesGlobales.glb_id_calidad = nIdCalidad;
            VariablesGlobales.glb_Referencia1 = cTipoInforme;

            string cCodAtr, cTipo;

            try
            {
                cCodAtr = Grid1[1, 0].Value.ToString();
            }
            catch
            {
                cCodAtr = "";
            }

            if (cCodAtr != "")
            {
                cTipo = "";

                try
                {
                    cTipo = cCodAtr.Substring(0, 2);
                }
                catch
                {
                    cTipo = "";
                }

                if (cTipo == "AL")
                {
                    //frmCalidadMP6 f2 = new frmCalidadMP6();
                    frmCalidadMPB4 f2 = new frmCalidadMPB4();
                    DialogResult res = f2.ShowDialog();

                }

                if (cTipo == "NU")
                {
                    frmCalidadMPA3_A f3 = new frmCalidadMPA3_A();
                    DialogResult res = f3.ShowDialog();

                }

                if (cTipo == "CI")
                {
                    frmCalidadMPA6 f3 = new frmCalidadMPA6();
                    DialogResult res = f3.ShowDialog();

                }

            }

        }

        private void btn_dividir_registro_Click(object sender, EventArgs e)
        {

            double nCantEnvases;

            try
            {
                nCantEnvases = Convert.ToDouble(t_num_bultos.Text);

            }
            catch
            {
                nCantEnvases = 0;
            }

            VariablesGlobales.glb_Cantidad = nCantEnvases;

            frmCalidadMP7 f2 = new frmCalidadMP7();
            DialogResult res = f2.ShowDialog();

            try
            {
                nCantEnvases = VariablesGlobales.glb_Cantidad;

            }
            catch
            {
                nCantEnvases = 0;
            }

            if (nCantEnvases > 0)
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Dividir el registro de Romana", "Registro de Inspección ", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int nId_romana, nLineId;

                    try
                    {
                        nId_romana = VariablesGlobales.glb_id_romana;
                    }
                    catch
                    {
                        nId_romana = -1;
                    }

                    try
                    {
                        nLineId = VariablesGlobales.glb_LineId;
                    }
                    catch
                    {
                        nLineId = -1;
                    }

                    if (nId_romana > 0)
                    {
                        //divido el registro de detalle de romana 

                        string mensaje1 = clsRomana.SAPB1_ROMANA2(nId_romana, nLineId, "._.", "", "", "", "", Convert.ToInt32(nCantEnvases), 0, 0,"","",0,"");

                        int new_lineid;

                        new_lineid = 0;

                        clsRomana objproducto5 = new clsRomana();
                        objproducto5.cls_Consulta_Partidas_x_id_Codigo(nId_romana, nLineId);

                        DataTable dTable5 = new DataTable();
                        dTable5 = objproducto5.cResultado;

                        try
                        {
                            new_lineid = Convert.ToInt32(dTable5.Rows[0]["LineId"].ToString());
                        }
                        catch
                        {
                            new_lineid = 0;
                        }

                        ////////////////////////////////////////////////////
                        //modifico la cantidad de bins del registro original

                        if (t_itemcode_d.Text.Trim() == "")
                        {
                            return;
                        }

                        if (Grid1.RowCount == 0)
                        {
                            return;
                        }

                        string cItemCode, cItemName, cLote;
                        string cObjetc, cWhsCode, cWhsDest;
                        string cNumCon;

                        int nDocEntry, nNumDoc, nDocEntryRef;
                        int nLineIdRef;

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
                            nNumDoc = Convert.ToInt32(t_num_guia.Text);

                        }
                        catch
                        {
                            nNumDoc = 0;

                        }

                        try
                        {
                            nDocEntryRef = Convert.ToInt32(t_id_ref.Text);

                        }
                        catch
                        {
                            nDocEntryRef = 0;

                        }

                        cWhsCode = t_WhsCode.Text;
                        cWhsDest = t_WhsDest.Text;

                        string UserCode, cUM, cAtrT1;

                        int UserId;
                        double nBultos, nBultosMuestrear;
                        double nCoMuSize, nMuDeSize, nCantidad;
                        double nPorcentaje;

                        nCantidad = 0;
                        nBultos = 0;
                        nBultosMuestrear = 0;
                        nCoMuSize = 0;
                        nMuDeSize = 0;
                        nPorcentaje = 0;

                        try
                        {
                            nCantidad = Convert.ToDouble(t_cant_prod.Text);

                        }
                        catch
                        {
                            nCantidad = 0;

                        }

                        try
                        {
                            nBultos = Convert.ToDouble(t_num_bultos.Text);
                        }
                        catch
                        {
                            nBultos = 0;
                        }

                        try
                        {
                            nBultosMuestrear = Convert.ToDouble(t_bultos_a_muestrear.Text);
                        }
                        catch
                        {
                            nBultosMuestrear = 0;
                        }

                        try
                        {
                            nCoMuSize = Convert.ToDouble(t_cant_contra_muestra.Text);
                        }
                        catch
                        {
                            nCoMuSize = 0;
                        }

                        try
                        {
                            nMuDeSize = Convert.ToDouble(t_cant_muestra_destructiva.Text);
                        }
                        catch
                        {
                            nMuDeSize = 0;
                        }

                        try
                        {
                            cAtrT1 = t_U_AtrT1.Text;
                        }
                        catch
                        {
                            cAtrT1 = "";
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

                        nBultos = nBultos - nCantEnvases;

                        ////////////////////////////////////////////////////
                        //modifico la cantidad de bins del registro original

                        String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, dt.ToString("yyyyMMdd"), cUM, nCoMuSize, nMuDeSize, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef,"","",0,"","S", cAtrT1,"");

                        //duplico el registro de inspeccion con la nueva cantidad de bins

                        nDocEntry = 0;

                        mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nCantEnvases, nBultosMuestrear, dt.ToString("yyyyMMdd"), cUM, nCoMuSize, nMuDeSize, t_Comments.Text, cObjetc, nDocEntryRef, new_lineid, "", "",0,"","S", cAtrT1,"");

                        int nLineId1;
                        string cCodAtr, cNomAtr, cComments;
                        string cComments2;
                        double nStandar, nMedicion, nMinimo;
                        double nMaximo;

                        if (nDocEntry == 0)
                        {
                            clsCalidad objproducto6 = new clsCalidad();
                            objproducto6.cls_Consulta_Nuevo_Registro_Inspeccion();

                            DataTable dTable6 = new DataTable();
                            dTable5 = objproducto6.cResultado;

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
                            nLineId1 = 0;
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
                                nLineId1 = Convert.ToInt32(Grid1[0, i].Value.ToString());
                            }
                            catch
                            {
                                nLineId1 = 0;
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

                                    mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId1, cCodAtr, cNomAtr, nStandar, nMinimo, nMaximo, nMedicion, cComments, cComments2, "", nPorcentaje);

                                }

                            }

                        }

                    }

                    Close();

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

        private void carga_datos_recepcion_mp_sin_romana()
        {

            int docentry, line_id;

            try
            {
                docentry = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                docentry = 0;

            }

            if (docentry == 0)
            {
                return;
            }


            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor;
            string obs, cTipoProducto, cUM;

            DateTime fecha_hora1, fecha_hora2;

            int numguia, cant_envases;
            int id_acceso, id_lineid_romana; //id_DocEntry_romana, 

            double nCantProd;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nCantProd = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            //id_DocEntry_romana = 0;
            id_lineid_romana = 0;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id2(docentry, line_id);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0]["CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0]["ItemCode"].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["ItemName"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                patente = dTable.Rows[0]["Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["NomConductor"].ToString();

            }
            catch
            {
                conductor = "";

            }

            obs = "";

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0]["NumGuia"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["CreateDate"].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            fecha_hora2 = DateTime.Parse("01/01/1900");

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }
            
            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["Cantidad_Bins"].ToString());

            }
            catch
            {
                cant_envases = 0;

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
                cUM = dTable.Rows[0]["BuyUnitMsr"].ToString();
            }
            catch
            {
                cUM = "";

            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();

            }
            catch
            {
                t_lote.Text = "";

            }

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["WhsCode"].ToString();

            }
            catch
            {
                t_WhsCode.Text = "";

            }

            try
            {
                nCantProd = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["Quantity"].ToString()));
            }
            catch
            {
                nCantProd = 0;
            }

            //id_DocEntry_romana = 0;
            id_lineid_romana = line_id;

            t_cant_prod.Text = nCantProd.ToString("N2");
            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_traslado.Text = "Pendiente";
            t_resultado.Text = "En Proceso";

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }


            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            t_traslado.Text = "En Proceso";

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de humedad
            ////

            string[,] registros_humedad;
            int n_registros_humedad;
            string cCodAtr_Humedad;
            double nMedicionAtr_Humendad;

            registros_humedad = new string[30, 2];
            n_registros_humedad = -1;

            clsCalidad objproducto4 = new clsCalidad();
            objproducto4.cls_Consulta_Atributos_de_Humedad(0, 0);

            DataTable dTable4 = new DataTable();
            dTable4 = objproducto4.cResultado;

            for (int i = 0; i <= dTable4.Rows.Count - 1; i++)
            {

                cCodAtr_Humedad = "";
                nMedicionAtr_Humendad = 0;

                try
                {
                    cCodAtr_Humedad = dTable4.Rows[i]["U_CodAtr"].ToString();

                }
                catch
                {
                    cCodAtr_Humedad = "";

                }


                try
                {
                    nMedicionAtr_Humendad = Double.Parse(dTable4.Rows[i]["U_Medicion"].ToString());

                }
                catch
                {
                    nMedicionAtr_Humendad = 0;

                }

                if (cCodAtr_Humedad != "")
                {
                    if (nMedicionAtr_Humendad > 0)
                    {
                        n_registros_humedad += 1;
                        registros_humedad[n_registros_humedad, 0] = cCodAtr_Humedad;
                        registros_humedad[n_registros_humedad, 1] = nMedicionAtr_Humendad.ToString();

                    }

                }

            }


            ////////////////////////////////////////////////////7
            //// Cargo los registros vacios 
            ////

            string cLineId_D, cContraMuestra, cMuestraDest;
            string cCode_D, cNomAtributo_D, cUM_D;
            string cGrupoAtr_D, cGrupoAtr_old_D;

            double nDesde_D, nHasta_D, nStandAtr_D;
            double nContraMuestra, nMuestraDest;


            clsCalidad objproducto2 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

            cGrupoAtr_old_D = "";

            try
            {
                cGrupoAtr_old_D = dTable2.Rows[0]["GrupoAtr"].ToString();

            }
            catch
            {
                cGrupoAtr_old_D = "";

            }

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            int nFila;

            nFila = 0;

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
                    nStandAtr_D = Convert.ToDouble(dTable2.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandAtr_D = 0;
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

                cGrupoAtr_D = "";

                try
                {
                    cGrupoAtr_D = dTable2.Rows[i]["GrupoAtr"].ToString();

                }
                catch
                {
                    cGrupoAtr_D = "";

                }

                if (cGrupoAtr_D == "C_DEFECTOS LEVES")
                {
                    cGrupoAtr_D = "C_DEFECTOS LEVES";
                }

                grilla[0] = cLineId_D.ToString();
                grilla[1] = cCode_D.ToString();
                grilla[2] = cNomAtributo_D.ToString();
                grilla[3] = cUM_D.ToUpper();
                grilla[4] = nStandAtr_D.ToString("N2");
                grilla[5] = nDesde_D.ToString("N2");
                grilla[6] = nHasta_D.ToString("N2");

                nMedicionAtr_Humendad = 0;

                for (int y = 0; y <= n_registros_humedad; y++)
                {
                    if (registros_humedad[y, 0] == cCode_D)
                    {
                        nMedicionAtr_Humendad = Double.Parse(registros_humedad[y, 1]);
                        break;
                    }

                }

                grilla[7] = nMedicionAtr_Humendad.ToString("N2");

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


                try
                {
                    cGrupoAtr_D = dTable2.Rows[i + 1]["GrupoAtr"].ToString();

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
                            grilla[2] = cGrupoAtr_old_D;

                        }

                    }

                    grilla[3] = "";
                    grilla[4] = "";
                    grilla[5] = "";
                    grilla[6] = "";
                    grilla[7] = "";

                    grilla[10] = cGrupoAtr_old_D;

                    Grid1.Rows.Add(grilla);

                    try
                    {
                        Grid1[9, nFila].Value = Image.FromFile(Application.StartupPath + "\\Resources\\blanco.png");

                    }
                    catch
                    {

                    }

                    grilla[0] = nFila.ToString();
                    grilla[1] = cGrupoAtr_old_D;
                    grilla[2] = cGrupoAtr_old_D;
                    grilla[3] = "0";

                    Grid2.Rows.Add(grilla);

                    nFila = nFila + 1;

                }

                cGrupoAtr_old_D = cGrupoAtr_D;

            }

            pinto_grupos();
            totalizar_grupos();


        }


        private void carga_datos_cabecera_mp_sin_romana()
        {

            int docentry, line_id;

            try
            {
                docentry = Convert.ToInt32(t_id_ref.Text);
            }
            catch
            {
                docentry = 0;

            }

            if (docentry == 0)
            {
                return;
            }


            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;
            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            string patente, conductor;
            string obs, cTipoProducto, cUM;

            DateTime fecha_hora1, fecha_hora2;

            int numguia, cant_envases;
            int id_acceso, id_lineid_romana; //id_DocEntry_romana, 

            double nCantProd;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            numguia = 0;
            patente = "";
            conductor = "";
            cant_envases = 0;
            cTipoProducto = "";
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            nCantProd = 0;

            //t_object.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_observacion.Clear();
            //t_fecha_1er_peso.Clear();
            t_fecha_peso1.Clear();
            //t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();

            //id_DocEntry_romana = 0;
            id_lineid_romana = 0;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id2(docentry, line_id);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0]["CardCode"].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0]["CardName"].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0]["ItemCode"].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0]["ItemName"].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                patente = dTable.Rows[0]["Patente"].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0]["NomConductor"].ToString();

            }
            catch
            {
                conductor = "";

            }

            obs = "";

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0]["NumGuia"].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0]["CreateDate"].ToString());

            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");

            }

            fecha_hora2 = DateTime.Parse("01/01/1900");

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                id_acceso = 0;

            }

            try
            {
                cant_envases = int.Parse(dTable.Rows[0]["Cantidad_Bins"].ToString());

            }
            catch
            {
                cant_envases = 0;

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
                cUM = dTable.Rows[0]["BuyUnitMsr"].ToString();
            }
            catch
            {
                cUM = "";

            }

            try
            {
                t_lote.Text = dTable.Rows[0]["MdAbsEntry"].ToString();

            }
            catch
            {
                t_lote.Text = "";

            }

            try
            {
                t_WhsCode.Text = dTable.Rows[0]["WhsCode"].ToString();

            }
            catch
            {
                t_WhsCode.Text = "";

            }

            try
            {
                nCantProd = Convert.ToInt32(Convert.ToDouble(dTable.Rows[0]["Quantity"].ToString()));
            }
            catch
            {
                nCantProd = 0;
            }

            //id_DocEntry_romana = 0;
            id_lineid_romana = line_id;

            t_cant_prod.Text = nCantProd.ToString("N2");
            //t_object.Text = CardCode;
            t_cardname.Text = CardName;
            t_bultos_a_muestrear.Text = 0.ToString("N2");

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_traslado.Text = "Pendiente";
            t_resultado.Text = "En Proceso";

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_peso1.Text = fecha_hora1.ToString("dd/MM/yyyy");

            }

            if (fecha_hora2.Year != 1900)
            {
                //t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_observacion.Text = obs;

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            try
            {
                line_id = Convert.ToInt32(t_lineid.Text);
            }
            catch
            {
                line_id = 0;

            }


            t_un_medida.Text = cUM;

            t_cardcode_d.Text = CardCode;
            t_cardname_d.Text = CardName;

            t_itemcode_d.Text = ItemCode;
            t_itemname_d.Text = ItemName;

            t_num_bultos.Text = cant_envases.ToString("N2");

            ////////////////////////////////////////////////////7
            ////

            clsRomana objproducto3 = new clsRomana();
            objproducto3.cls_Consulta_fecha_sql();

            DataTable dTable3 = new DataTable();
            dTable = objproducto3.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable3.Rows[0]["fecha_hora"].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_ingreso.Text = dt.ToString("dd/MM/yyyy");

            t_traslado.Text = "En Proceso";
            
            ////////////////////////////////////////////////////7
            //// Cargo los registros vacios 
            ////

            string cContraMuestra, cMuestraDest;
            double nContraMuestra, nMuestraDest;


            clsCalidad objproducto2 = new clsCalidad();
            //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
            objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "%");

            DataTable dTable2 = new DataTable();
            dTable2 = objproducto2.cResultado;

            cContraMuestra = "";
            nContraMuestra = 0;
            cMuestraDest = "";
            nMuestraDest = 0;

            try
            {
                cContraMuestra = dTable2.Rows[0]["U_ContraMu"].ToString();
            }
            catch
            {
                cContraMuestra = "";
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["U_CoMuSize"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                nContraMuestra = Convert.ToDouble(dTable2.Rows[0]["Contra_Muestra"].ToString());
            }
            catch
            {
                nContraMuestra = 0;
            }

            try
            {
                cMuestraDest = dTable2.Rows[0]["U_MuestDes"].ToString();
            }
            catch
            {
                cMuestraDest = "";
            }

            try
            {
                nMuestraDest = Convert.ToDouble(dTable2.Rows[0]["U_MuDeSize"].ToString());
            }
            catch
            {
                nMuestraDest = 0;
            }

            chk_contramuestra.Checked = false;

            if (cContraMuestra == "Y")
            {
                chk_contramuestra.Checked = true;

            }

            chk_destructiva.Checked = false;

            t_cant_contra_muestra.Text = nContraMuestra.ToString("N2");

            if (cMuestraDest == "Y")
            {
                chk_destructiva.Checked = true;

            }

            t_cant_muestra_destructiva.Text = nMuestraDest.ToString("N2");

        }

        private void lnk_imagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                VariablesGlobales.glb_LineId = 0;

                frmCalidadMPA4 f2 = new frmCalidadMPA4();
                DialogResult res = f2.ShowDialog();

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

                frmCalidadMP_Load(sender, e);

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
                int UserId;

                UserId = VariablesGlobales.glb_User_id;

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
