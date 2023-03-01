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
    public partial class frmCalidadMPA8 : Form
    {
        public frmCalidadMPA8()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA8_Load(object sender, EventArgs e)
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

            btn_aprobar.Visible = false;
            btn_rechazar.Visible = false;

            if (VariablesGlobales.glb_id_calidad == 0)
            {
                t_fecha_ingreso.Text = "";
                t_doc_entry.Text = "0";

                t_id_calidad.Text = "0";

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

            }
            else
            {

                t_id_calidad.Text = VariablesGlobales.glb_id_calidad.ToString();
                t_object.Text = VariablesGlobales.glb_Object;

                carga_datos_calidad();

                if (t_object.Text == "100500")
                {
                    /// Registro de Materia Prima ****
                    /// 
                    VariablesGlobales.glb_id_romana = Convert.ToInt32(t_id_ref.Text);
                    VariablesGlobales.glb_LineId = Convert.ToInt32(t_lineid.Text);

                    carga_datos_cabecera_mp();

                }

            }

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

            cbb_NP_1_001.SelectedIndex = 0;
            cbb_NP_1_010.SelectedIndex = 0;
            cbb_NP_1_015.SelectedIndex = 0;
            cbb_NP_1_020.SelectedIndex = 0;
            cbb_NP_1_025.SelectedIndex = 0;
            cbb_NP_1_030.SelectedIndex = 0;

            t_NP_1_001.Text = "0";
            t_NP_1_005.Text = "0";
            t_NP_1_010.Text = "0";
            t_NP_1_015.Text = "0";
            t_NP_1_020.Text = "0";
            t_NP_1_025.Text = "0";
            t_NP_1_030.Text = "0";
            t_NP_1_035.Text = "0";
            t_NP_1_040.Text = "0";
            t_NP_1_045.Text = "0";
            t_NP_1_050.Text = "0";

            string cLineId_D, cCode_D;
            double nStandar_D;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                cCode_D = "";
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
                    nStandar_D = Convert.ToDouble(dTable.Rows[i]["U_StandAtr"].ToString());

                }
                catch
                {
                    nStandar_D = 0;
                }

                if  (cCode_D == "NP_1_001")
                {
                    cbb_NP_1_001.SelectedIndex = 0;

                    t_NP_1_001.Text = nStandar_D.ToString();

                    if (t_NP_1_001.Text == "")
                    {
                        cbb_NP_1_001.SelectedIndex = 0;

                    }

                    if (t_NP_1_001.Text == "1")
                    {
                        cbb_NP_1_001.SelectedIndex = 1;

                    }

                    if (t_NP_1_001.Text == "2")
                    {
                        cbb_NP_1_001.SelectedIndex = 2;

                    }

                    if (t_NP_1_001.Text == "3")
                    {
                        cbb_NP_1_001.SelectedIndex = 3;

                    }

                }

                if (cCode_D == "NP_1_005")
                {

                    t_NP_1_005.Text = nStandar_D.ToString();

                }

                if (cCode_D == "NP_1_010")
                {
                    cbb_NP_1_010.SelectedIndex = 0;

                    t_NP_1_010.Text = nStandar_D.ToString();

                    if (t_NP_1_010.Text == "")
                    {
                        cbb_NP_1_010.SelectedIndex = 0;

                    }

                    if (t_NP_1_010.Text == "1")
                    {
                        cbb_NP_1_010.SelectedIndex = 1;

                    }

                    if (t_NP_1_010.Text == "2")
                    {
                        cbb_NP_1_010.SelectedIndex = 2;

                    }

                    if (t_NP_1_010.Text == "3")
                    {
                        cbb_NP_1_010.SelectedIndex = 3;

                    }

                }

                if (cCode_D == "NP_1_015")
                {
                    cbb_NP_1_015.SelectedIndex = 0;

                    t_NP_1_015.Text = nStandar_D.ToString();

                    if (t_NP_1_015.Text == "")
                    {
                        cbb_NP_1_015.SelectedIndex = 0;

                    }

                    if (t_NP_1_015.Text == "1")
                    {
                        cbb_NP_1_015.SelectedIndex = 1;

                    }

                    if (t_NP_1_015.Text == "2")
                    {
                        cbb_NP_1_015.SelectedIndex = 2;

                    }

                    if (t_NP_1_015.Text == "3")
                    {
                        cbb_NP_1_015.SelectedIndex = 3;

                    }

                }

                if (cCode_D == "NP_1_020")
                {
                    cbb_NP_1_020.SelectedIndex = 0;

                    t_NP_1_020.Text = nStandar_D.ToString();

                    if (t_NP_1_020.Text == "")
                    {
                        cbb_NP_1_020.SelectedIndex = 0;

                    }

                    if (t_NP_1_020.Text == "1")
                    {
                        cbb_NP_1_020.SelectedIndex = 1;

                    }

                    if (t_NP_1_020.Text == "2")
                    {
                        cbb_NP_1_020.SelectedIndex = 2;

                    }

                    if (t_NP_1_020.Text == "3")
                    {
                        cbb_NP_1_020.SelectedIndex = 3;

                    }

                }

                if (cCode_D == "NP_1_025")
                {
                    cbb_NP_1_025.SelectedIndex = 0;

                    t_NP_1_025.Text = nStandar_D.ToString();

                    if (t_NP_1_025.Text == "")
                    {
                        cbb_NP_1_025.SelectedIndex = 0;

                    }

                    if (t_NP_1_025.Text == "1")
                    {
                        cbb_NP_1_025.SelectedIndex = 1;

                    }

                    if (t_NP_1_025.Text == "2")
                    {
                        cbb_NP_1_025.SelectedIndex = 2;

                    }

                    if (t_NP_1_025.Text == "3")
                    {
                        cbb_NP_1_025.SelectedIndex = 3;

                    }

                }

                if (cCode_D == "NP_1_030")
                {
                    cbb_NP_1_030.SelectedIndex = 0;

                    t_NP_1_030.Text = nStandar_D.ToString();

                    if (t_NP_1_030.Text == "")
                    {
                        cbb_NP_1_030.SelectedIndex = 0;

                    }

                    if (t_NP_1_030.Text == "1")
                    {
                        cbb_NP_1_030.SelectedIndex = 1;

                    }

                    if (t_NP_1_030.Text == "2")
                    {
                        cbb_NP_1_030.SelectedIndex = 2;

                    }

                }

                if (cCode_D == "NP_1_035")
                {

                    t_NP_1_035.Text = nStandar_D.ToString();

                }

                if (cCode_D == "NP_1_040")
                {

                    t_NP_1_040.Text = nStandar_D.ToString();

                }

                if (cCode_D == "NP_1_045")
                {

                    t_NP_1_045.Text = nStandar_D.ToString();

                }

                if (cCode_D == "NP_1_050")
                {

                    t_NP_1_050.Text = nStandar_D.ToString();

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
            //// Valido si tiene permisos para aprobar

            t_resultado.Text = "En Proceso";

            if (cEstadoRegistro == "N")
            {
                btn_aprobar.Visible = true;
                btn_rechazar.Visible = true;

                if (t_object.Text == "100500")
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

            string UserCode, cUM;
            int UserId;
            double nBultos, nBultosMuestrear;
            double nCantidad, nCoMuSize, nMuDeSize;
            double nPelon, nPelonSuelto;

            nCantidad = 0;
            nBultos = 0;
            nBultosMuestrear = 0;
            nCoMuSize = 0;
            nMuDeSize = 0;
            nPelon = 0;
            nPelonSuelto = 0;

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

            String mensaje;

            mensaje = "";

            mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, dt.ToString("yyyyMMdd"), cUM, nCoMuSize, nMuDeSize, t_Comments.Text, cObjetc, nDocEntryRef, nLineIdRef, "", "",0,"", "S","","");

            if (mensaje != "Y")
            {
                MessageBox.Show("Error: " + mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nLineId;
            string cCodAtr; //, cNomAtr;
            //string cComments2;
            double nStandar; //, nMedicion, nMinimo;
            //double nMaximo;

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

            nLineId = 1;
            cCodAtr = "NP_1_001";

            try
            {
                nStandar = cbb_NP_1_001.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);


            nLineId = 2;
            cCodAtr = "NP_1_005";

            try
            {
                nStandar = Convert.ToDouble(t_NP_1_005.Text);
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 3;
            cCodAtr = "NP_1_010";

            try
            {
                nStandar = cbb_NP_1_010.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 4;
            cCodAtr = "NP_1_015";

            try
            {
                nStandar = cbb_NP_1_015.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 5;
            cCodAtr = "NP_1_020";

            try
            {
                nStandar = cbb_NP_1_020.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 6;
            cCodAtr = "NP_1_025";

            try
            {
                nStandar = cbb_NP_1_025.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 7;
            cCodAtr = "NP_1_030";

            try
            {
                nStandar = cbb_NP_1_030.SelectedIndex;
            }
            catch
            {
                nStandar = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nStandar, 0, 0, 0, "", "", "",0);

            nLineId = 8;
            cCodAtr = "NP_1_035";

            try
            {
                nPelon = Convert.ToDouble(t_NP_1_035.Text);
            }
            catch
            {
                nPelon = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nPelon, 0, 0, 0, "", "", "",0);

            nLineId = 9;
            cCodAtr = "NP_1_040";

            try
            {
                nPelonSuelto = Convert.ToDouble(t_NP_1_040.Text);
            }
            catch
            {
                nPelonSuelto = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nPelonSuelto, 0, 0, 0, "", "", "",0);

            nLineId = 10;
            cCodAtr = "NP_1_045";

            try
            {
                nPelonSuelto = Convert.ToDouble(t_NP_1_045.Text);
            }
            catch
            {
                nPelonSuelto = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nPelonSuelto, 0, 0, 0, "", "", "",0);

            nLineId = 11;
            cCodAtr = "NP_1_050";

            try
            {
                nPelonSuelto = Convert.ToDouble(t_NP_1_050.Text);
            }
            catch
            {
                nPelonSuelto = 0;
            }

            mensaje = clsCalidad.SAPB1_RCAL1(nDocEntry, nLineId, cCodAtr, "", nPelonSuelto, 0, 0, 0, "", "", "",0);


            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VariablesGlobales.glb_id_calidad = nDocEntry;
                frmCalidadMPA8_Load(sender, e);

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

                string UserCode;
                int UserId, nStockTransferEntry;

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

                    String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "A", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, "", "",0,"","S","","");

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

                    frmCalidadMPA8_Load(sender, e);

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

                    String mensaje = clsCalidad.SAPB1_ORCAL(nDocEntry, "R", UserId, UserCode, cItemCode, cItemName, cWhsCode, cWhsDest, cNumCon, cLote, nCantidad, nBultos, nBultosMuestrear, cFecha, cUM, nCoMuSize, nMuDeSize, Comments, cObjetc, nDocEntryRef, nLineId_Ref, "", "",0,"", "S","","");

                    if (mensaje == "Y")
                    {
                        MessageBox.Show("Registro Rechazado", "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Registro de Inspección ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    carga_datos_calidad();

                }
            }


        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_doc_entry.Text);
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

            VariablesGlobales.glb_DocEntry = nDocEntry;

            frmCalidadMPB2 f2 = new frmCalidadMPB2();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

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

                frmCalidadMPA8_Load(sender, e);

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
