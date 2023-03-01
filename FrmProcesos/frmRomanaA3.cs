using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmRomanaA3 : Form
    {
        public frmRomanaA3()
        {
            InitializeComponent();
        }

        private void frmRomanaA3_Load(object sender, EventArgs e)
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

            Grid1.Rows.Clear();

            ///////////////////////////////////////////////////////

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                dt = DateTime.Now;
            }

            t_fecha_contable.Text = dt.ToString("dd/MM/yyyy HH:mm");

            toolStrip1.Enabled = false;
            //btn_nuevo.Enabled = false;

            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////
            ///////////////////////////////////////

        }

        private void btn_buscar_of_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Referencia1 = "R";

            frmSel_OrdenFabricacion1 f2 = new frmSel_OrdenFabricacion1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_DocEntry != 0)
            {
                limpia_pantalla();

                t_DocNum.Text = VariablesGlobales.glb_DocEntry.ToString();

                Carga_fruta();
                carga_producto();

                carga_pesajes();

            }

        }

        private void limpia_pantalla()
        {

            t_DocNum.Clear();
            t_itemcode.Clear();
            t_itemname.Clear();
            t_almacen.Clear();
            t_cant_cajas.Clear();
            t_ItemCode_Cabecera.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();
            //t_comuna.Clear();

            //t_cardcode_cliente.Clear();
            //t_cardname_cliente.Clear();

            t_DocNum.Clear();

            t_itemcode.Clear();
            t_itemname.Clear();
            t_almacen.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();
            //t_comuna.Clear();
            //t_provincia.Clear();

            //t_cardcode_cliente.Clear();
            //t_cardname_cliente.Clear();

            t_id_romana.Clear();
            t_ItemCode_Cabecera.Clear();
            t_tipo_fruta.Clear();

            btn_buscar_of.Enabled = true;

            Grid1.Rows.Clear();

        }

        private void Carga_fruta()
        {

            int nDocNum, nDocEntry, nConCascara;
            string cItemName, cSalida, cTipoProducto;
            string cDestino_Secado, cNum_OC; 

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            t_tipo_fruta.Clear();

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
            objproducto.cls_Consultar_OrdenFabricacion_x_DocNum(nDocNum);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                nDocEntry = int.Parse(dTable.Rows[0]["DocEntry"].ToString());
            }
            catch
            {
                nDocEntry = -1;
            }

            try
            {
                t_ItemCode_Cabecera.Text = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                t_ItemCode_Cabecera.Text = "";
            }

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
            }

            try
            {
                t_tipo_fruta.Text = dTable.Rows[0]["U_TipoProducto"].ToString();
            }
            catch
            {
                t_tipo_fruta.Text = "";
            }

            try
            {
                t_nombre_cliente_of.Text = dTable.Rows[0]["Nom_Cliente"].ToString();
            }
            catch
            {
                t_nombre_cliente_of.Text = "";
            }

            nConCascara = -1;

            try
            {
                nConCascara = cItemName.ToUpper().IndexOf("C/C");
            }
            catch
            {
                nConCascara = -1;
            }

            if (nConCascara == -1)
            {
                try
                {
                    nConCascara = cItemName.ToUpper().IndexOf("CON CASCARA");
                }
                catch
                {
                    nConCascara = -1;
                }

            }

            try
            {
                cDestino_Secado = dTable.Rows[0]["Destino_Secado"].ToString();
            }
            catch
            {
                cDestino_Secado = "";
            }

            try
            {
                cNum_OC = dTable.Rows[0]["Num_OC"].ToString();
            }
            catch
            {
                cNum_OC = "";
            }

            if (t_tipo_fruta.Text == "Nuez")
            {
                if (nConCascara >= 0)
                {
                    t_tipo_fruta.Text = "Nuez C/C";
                }
                else
                {
                    t_tipo_fruta.Text = "Nuez S/C";
                }

            }

            groupBox3.Visible = false;
            t_numoc.Text = "";

            if (cDestino_Secado == "Recibe_MP")
            {
                groupBox3.Visible = true;

                t_numoc.Text = cNum_OC;

                Carga_Datos_OC();

            }


            if (cDestino_Secado == "")
            {
                btn_ok.Enabled = false;
                btn_nuevo.Enabled = false;

                MessageBox.Show("La OF no tiene un ** Destino ** válido, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                btn_ok.Enabled = true;
                btn_nuevo.Enabled = true;

            }

            clsMaestros objproducto1 = new clsMaestros();
            objproducto1.cls_Consultar_SalidasProduccion_TipoProducto(t_tipo_fruta.Text);

            DataTable dTable1 = new DataTable();
            dTable1 = objproducto1.cResultado;

            for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
            {
                try
                {
                    cSalida = dTable1.Rows[i]["U_HDV_Salida"].ToString();
                }
                catch
                {
                    cSalida = "";
                }

                try
                {
                    cTipoProducto = dTable1.Rows[i]["Name"].ToString();
                }
                catch
                {
                    cTipoProducto = "";

                }

            }

            if (nDocNum != nDocEntry)
            {
                t_DocNum.Clear();

            }

        }

        private void carga_producto()
        {
            int nNumOF;
            string cItemCode, cItemName;

            nNumOF = 0;
            cItemCode = "";
            cItemName = "";

            try
            {
                nNumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsProductos objproducto = new clsProductos();
            objproducto.cls_consultar_Productos2(nNumOF);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cItemCode = dTable.Rows[0]["ItemCode"].ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cItemName = dTable.Rows[0]["ItemName"].ToString();
            }
            catch
            {
                cItemName = "";
            }

            if (cItemCode != "")
            {
                t_itemcode.Text = cItemCode;
                t_itemname.Text = cItemName;

                t_grupo.Clear();

                clsProductos objproducto1 = new clsProductos();

                objproducto1.cls_consultar_Producto_x_codigo(t_itemcode.Text);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    t_grupo.Text = dTable1.Rows[0]["ItmsGrpNam"].ToString();
                }
                catch
                {
                    t_grupo.Clear();
                }

                t_almacen.Clear();
                t_linea.Clear();

                /////////////////////////////////////////
                /////////////////////////////////////////
                /// Determino el precio de costo OC

                string cItem_Code, cItem_Code_D, cWhsCode;
                string cWhsCode_D;

                int nLineId;

                cItem_Code = "";
                cWhsCode = "";

                t_cant_cajas.Text = 1.ToString();

                clsOrdenFabricacion objproducto2 = new clsOrdenFabricacion();

                objproducto2.cls_Consultar_OrdenFabricacion_x_DocNum1(nNumOF);

                DataTable dTable2 = new DataTable();
                dTable2 = objproducto2.cResultado;

                try
                {
                    t_tipo_of.Text = dTable2.Rows[0]["U_TipoFruta"].ToString();
                }
                catch
                {
                    t_tipo_of.Clear();
                }

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {
                    cItem_Code = "";
                    cItem_Code_D = "";
                    cWhsCode = "";
                    cWhsCode_D = "";
                    nLineId = 0;

                    try
                    {
                        cItem_Code = dTable2.Rows[i]["ItemCode"].ToString();

                    }
                    catch
                    {
                        cItem_Code = "";
                    }

                    try
                    {
                        cItem_Code_D = dTable2.Rows[i]["ItemCode_D"].ToString();

                    }
                    catch
                    {
                        cItem_Code_D = "";
                    }

                    try
                    {
                        cWhsCode = dTable2.Rows[i]["Warehouse"].ToString();

                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        cWhsCode_D = dTable2.Rows[i]["Warehouse_D"].ToString();

                    }
                    catch
                    {
                        cWhsCode_D = "";
                    }

                    try
                    {
                        nLineId = Convert.ToInt32(dTable2.Rows[i]["LineNum"].ToString());

                    }
                    catch
                    {
                        nLineId = 0;
                    }

                    if (t_linea.Text == "")
                    {
                        if (t_itemcode.Text == cItem_Code)
                        {
                            t_almacen.Text = cWhsCode;
                            t_linea.Text = "-1";

                        }

                        if (t_itemcode.Text == cItem_Code_D)
                        {
                            t_almacen.Text = cWhsCode_D;
                            t_linea.Text = nLineId.ToString();

                        }

                    }


                }

                string cCardoCode_Prov, nCardName_Prov;
                string cCardoCode_Cliente, nCardName_Cliente;
                string cCity;

                cCardoCode_Prov = "";
                nCardName_Prov = "";
                cCardoCode_Cliente = "";
                nCardName_Cliente = "";
                cCity = "";

                if (t_tipo_of.Text == "Propia")
                {

                    int nCantProductores_FrutaPropia;
                    string cCardCode_Prov_FrutaPropia;

                    nCantProductores_FrutaPropia = 0;
                    cCardCode_Prov_FrutaPropia = "";

                    clsOrdenFabricacion objproducto9 = new clsOrdenFabricacion();

                    objproducto9.cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(nNumOF);

                    DataTable dTable9 = new DataTable();
                    dTable9 = objproducto9.cResultado;

                    for (int x = 0; x <= dTable9.Rows.Count - 1; x++)
                    {

                        try
                        {
                            cCardCode_Prov_FrutaPropia = dTable9.Rows[x]["MnfSerial"].ToString();
                        }
                        catch
                        {
                            cCardCode_Prov_FrutaPropia = "";
                        }

                        if (cCardCode_Prov_FrutaPropia.Trim() != "")
                        {
                            cCardoCode_Prov = cCardCode_Prov_FrutaPropia.Trim();
                        }

                        nCantProductores_FrutaPropia += 1;

                    }

                    if (nCantProductores_FrutaPropia == 0)
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    if (nCantProductores_FrutaPropia > 1)
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    if (cCardoCode_Prov == "")
                    {
                        cCardoCode_Prov = "P76687970";
                    }

                    //cCardoCode_Prov = "P96854230";
                    nCardName_Prov = "";
                    cCity = "";
                    cCardoCode_Cliente = "";
                    nCardName_Cliente = "";

                }

                if (t_tipo_of.Text == "Servicio")
                {
                    clsOrdenFabricacion objproducto4 = new clsOrdenFabricacion();

                    objproducto4.cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(nNumOF);

                    DataTable dTable4 = new DataTable();
                    dTable4 = objproducto4.cResultado;

                    for (int x = 0; x <= dTable4.Rows.Count - 1; x++)
                    {
                        if (cCardoCode_Prov == "")
                        {
                            try
                            {
                                cCardoCode_Prov = dTable4.Rows[x]["MnfSerial"].ToString();
                            }
                            catch
                            {
                                cCardoCode_Prov = "";
                            }

                        }


                        if (cCardoCode_Cliente == "")
                        {
                            try
                            {
                                cCardoCode_Cliente = dTable4.Rows[x]["LotNumber"].ToString();
                            }
                            catch
                            {
                                cCardoCode_Cliente = "";
                            }

                        }

                    }

                }

                if (cCardoCode_Prov != "")
                {
                    nCardName_Prov = "";
                    cCity = "";

                    clsSocioNegocio objproducto3 = new clsSocioNegocio();

                    objproducto3.cls_Consultar_OCRDxCardCode(cCardoCode_Prov);

                    DataTable dTable3 = new DataTable();
                    dTable3 = objproducto3.cResultado;

                    try
                    {
                        nCardName_Prov = dTable3.Rows[0]["CardName"].ToString();
                    }
                    catch
                    {
                        nCardName_Prov = "";
                    }

                    try
                    {
                        cCity = dTable3.Rows[0]["City"].ToString();
                    }
                    catch
                    {
                        cCity = "";
                    }

                }

                if (cCardoCode_Cliente != "")
                {
                    nCardName_Cliente = "";

                    clsSocioNegocio objproducto3 = new clsSocioNegocio();

                    objproducto3.cls_Consultar_OCRDxCardCode(cCardoCode_Cliente);

                    DataTable dTable3 = new DataTable();
                    dTable3 = objproducto3.cResultado;

                    try
                    {
                        nCardName_Cliente = dTable3.Rows[0]["CardName"].ToString();
                    }
                    catch
                    {
                        nCardName_Cliente = "";
                    }

                }

                //t_cardcode.Text = cCardoCode_Prov;
                //t_cardname.Text = nCardName_Prov;

                //t_comuna.Text = cCity;

                //t_cardcode_cliente.Text = cCardoCode_Cliente;
                //t_cardname_cliente.Text = nCardName_Cliente;

            }

        }

        private void carga_pesajes()
        {
            int nNumOF, id_pesaje;
            DateTime dFecha;
            string cItemCode, cItemName;
            float nCantEnvases, nPesoBruto, nPesoEnvases;
            float nt_CantEnvases, nt_PesoBruto, nt_PesoEnvases;
            float nPesoNeto, nt_PesoNeto;

            nNumOF = 0;

            try
            {
                nNumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF == 0)
            {
                return;

            }

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            clsOrdenFabricacion objproducto = new clsOrdenFabricacion();

            objproducto.cls_Consultar_OrdenFabricacion_Pesaje_DyS(nNumOF);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            nt_CantEnvases = 0;
            nt_PesoBruto = 0;
            nt_PesoEnvases = 0;
            nt_PesoNeto = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                id_pesaje = 0;
                cItemCode = "";
                cItemName = "";

                nCantEnvases = 0;
                nPesoBruto = 0;
                nPesoEnvases = 0;
                nPesoNeto = 0;

                try
                {
                    id_pesaje = Convert.ToInt32(dTable.Rows[i]["DocEntry"].ToString());

                }
                catch
                {
                    id_pesaje = 0;
                }

                try
                {
                    dFecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaPeso2"].ToString());

                }
                catch
                {
                    dFecha = Convert.ToDateTime("01/01/1900");
                }

                try
                {
                    cItemCode = dTable.Rows[i]["U_ItemCode"].ToString();

                }
                catch
                {
                    cItemCode = "";
                }

                try
                {
                    cItemName = dTable.Rows[i]["U_ItemName"].ToString();

                }
                catch
                {
                    cItemName = "";
                }

                try
                {
                    nCantEnvases = Convert.ToInt32(dTable.Rows[i]["U_CantidadBins"].ToString());

                }
                catch
                {
                    nCantEnvases = 0;
                }

                try
                {
                    nPesoBruto = Convert.ToInt32(dTable.Rows[i]["U_PesoBruto"].ToString());

                }
                catch
                {
                    nPesoBruto = 0;
                }

                try
                {
                    nPesoEnvases = Convert.ToInt32(dTable.Rows[i]["U_PesoTara"].ToString());

                }
                catch
                {
                    nPesoEnvases = 0;
                }

                try
                {
                    nPesoNeto = Convert.ToInt32(dTable.Rows[i]["U_PesoNeto"].ToString());

                }
                catch
                {
                    nPesoNeto = 0;
                }

                nPesoNeto = nPesoBruto - nPesoEnvases;
                if (nPesoNeto < 0)
                {
                    nPesoNeto = 0;

                }

                grilla[0] = id_pesaje.ToString();
                grilla[1] = dFecha.ToString("dd/MM/yyyy") + " " + dFecha.ToString("hh:mm");
                grilla[2] = cItemName;
                grilla[3] = nCantEnvases.ToString();
                grilla[4] = nPesoBruto.ToString("N2");
                grilla[5] = nPesoEnvases.ToString("N2");
                grilla[6] = nPesoNeto.ToString("N2");

                Grid1.Rows.Add(grilla);

                nt_CantEnvases += nCantEnvases;
                nt_PesoBruto += nPesoBruto;
                nt_PesoEnvases += nPesoEnvases;
                nt_PesoNeto += nPesoNeto;

            }

            t_cant_envases.Text = nt_CantEnvases.ToString("N2");
            t_peso_bruto.Text = nt_PesoBruto.ToString("N2");
            t_peso_envases.Text = nt_PesoEnvases.ToString("N2");
            t_peso_neto.Text = nt_PesoNeto.ToString("N2");


        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            int nNumOF;

            nNumOF = 0;

            try
            {
                nNumOF = int.Parse(t_DocNum.Text);
            }
            catch
            {
                nNumOF = 0;
            }

            if (nNumOF == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Producción válida, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_DocEntry = nNumOF;

            frmRomanaA2 f2 = new frmRomanaA2();
            DialogResult res = f2.ShowDialog();

            carga_pesajes();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            int nDocNum, nNumOC;
            string cAlmacenCabecera;

            nDocNum = 0;
            nNumOC = 0;

            try
            {
                nDocNum = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nDocNum = 0;
            }

            if (t_codigo_CSG.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un código CSG válida, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_tipo_usuario == "2")
            {
                MessageBox.Show("Su licencia NO permite realizar esta actividad, contacte al administrador del sistema", "Sistema Utiles **** ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nDocNum == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Fabricación válida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nNumOC = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                nNumOC = 0;
            }

            if (nNumOC == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Compra válida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cAlmacenCabecera = t_almacen.Text; 

            }
            catch
            {
                cAlmacenCabecera = "";

            }

            if (cAlmacenCabecera == "")
            {
                MessageBox.Show("Debe seleccionar un almacen válido, opción Cancelada", "Recepción de Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (t_itemcode.Text == "")
            {
                MessageBox.Show("Debe seleccionar una Producto válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double nPesoBruto, nPesoNeto;

            try
            {
                nPesoBruto = Convert.ToDouble(t_peso_bruto.Text);
            }
            catch
            {
                nPesoBruto = 0;
            }

            try
            {
                nPesoNeto = Convert.ToDouble(t_peso_neto.Text);
            }
            catch
            {
                nPesoNeto = 0;
            }

            if (nPesoNeto == 0)
            {
                MessageBox.Show("No se puede ingresar un recibo con valor cero, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nPesoBruto == nPesoNeto)
            {
                MessageBox.Show("Existe un error en el cálculo de los Envases, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            double nQuantity;
            int nCantidadBins, nLineNum;

            try
            {
                nQuantity = Convert.ToDouble(t_peso_neto.Text);
            }
            catch
            {
                nQuantity = 0;
            }

            if (nQuantity <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad de kilos válidos, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nCantidadBins = int.Parse(t_cant_cajas.Text);
            }
            catch
            {
                nCantidadBins = 0;
            }

            if (nCantidadBins == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad de cajas válidos, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nLineNum = int.Parse(t_linea.Text);
            }
            catch
            {
                nLineNum = -2;
            }


            if (nLineNum == -2)
            {
                MessageBox.Show("Debe seleccionar un ítem válido, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cItemCodeCabecera, cItemCodeDetalle;

            cItemCodeCabecera = "";
            cItemCodeDetalle = "";

            try
            {
                cItemCodeCabecera = t_ItemCode_Cabecera.Text.ToUpper().Substring(0, 3);
            }
            catch
            {
                cItemCodeCabecera = "";
            }

            try
            {
                cItemCodeDetalle = t_itemcode.Text.ToUpper().Substring(0, 3);
            }
            catch
            {
                cItemCodeDetalle = "";
            }

            if (cItemCodeCabecera != cItemCodeDetalle)
            {
                MessageBox.Show("Error de Referencia, Los productos no tiene el mismo Tipo Servicio / Propio, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (groupBox3.Visible == true)
            {
                if (t_numoc.Text == "")
                {
                    MessageBox.Show("Error de Referencia, debe seleccionar una orden de compra valida, opción cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Generar el Termination Report", "Termination Report ", buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;

            }

            string cDocDate;

            DateTime dFecha;

            try
            {
                dFecha = Convert.ToDateTime(t_fecha_contable.Text);
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDocDate = dFecha.ToString("yyyyMMdd");

            string cWharehouse, cSalidaProduccion;
            string cCardCode_Productor, cCardName_Productor;
            string cCardCode_Cliente, cCardName_Cliente;

            double nPesoUltimaCaja;

            cWharehouse = t_almacen.Text;

            cCardCode_Productor = "";
            cCardName_Productor = "";
            cCardCode_Cliente = "";
            cCardName_Cliente = "";
            cSalidaProduccion = "";

            try
            {
                cCardCode_Productor = t_cardcode.Text;
            }
            catch
            {
                cCardCode_Productor = "";
            }

            try
            {
                cCardName_Productor = t_cardname.Text;
            }
            catch
            {
                cCardName_Productor = "";
            }

            try
            {
                cCardCode_Cliente = t_cardcode_clte.Text;
            }
            catch
            {
                cCardCode_Cliente = "";
            }

            try
            {
                cCardName_Cliente = t_cardname_clte.Text;
            }
            catch
            {
                cCardName_Cliente = "";
            }

            nPesoUltimaCaja = 0;

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;
            string cErrorMensaje;

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

            cErrorMensaje = "";

            t_mensaje.Visible = true;
            Application.DoEvents();
            Application.DoEvents();

            //////////////////////////////////////
            // Determino la Variedad de la Fruta 
            // Recibida

            int nCantVariedades;
            double nCantidadBins1;
            string cVariedadConsumo;

            nCantVariedades = 0;
            cVariedadConsumo = "";

            clsProduccion objproducto8 = new clsProduccion();

            objproducto8.cls_Consulta_Variedad_en_Producto_de_Consumo(nDocNum);

            DataTable dTable8 = new DataTable();
            dTable8 = objproducto8.cResultado;

            for (int i = 0; i <= dTable8.Rows.Count - 1; i++)
            {
                try
                {
                    cVariedadConsumo = dTable8.Rows[i]["U_HDV_VARIEDAD"].ToString();

                }
                catch
                {
                    cVariedadConsumo = "";

                }

                nCantVariedades += 1;

            }

            if (nCantVariedades > 1)
            {
                cVariedadConsumo = "Mix";
            }

            try
            {
                nCantidadBins1 = Convert.ToDouble(t_cant_envases.Text);
            }
            catch
            {
                nCantidadBins1 = 0;
            }

            nCantidadBins = Convert.ToInt32(nCantidadBins1 * -1);

            //////////////////////////////////////////////////////
            // Valido la cantidad de unidades disponibles en la OC

            if (groupBox3.Visible == true)
            {
                double nQuantity_Pend_OC;
                int nDocNum_OC;

                nDocNum_OC = 0;

                try
                {
                    nDocNum_OC = Convert.ToInt32(t_numoc.Text);

                }
                catch
                {
                    nDocNum_OC = 0;
                }

                nQuantity_Pend_OC = 0;

                clsProduccion objproducto8a = new clsProduccion();

                objproducto8a.cls_Consulta_Cant_Disponible_OC(nDocNum_OC);

                DataTable dTable8a = new DataTable();
                dTable8a = objproducto8a.cResultado;

                try
                {
                    nQuantity_Pend_OC = Convert.ToDouble(dTable8a.Rows[0]["OpenQty"].ToString());

                }
                catch
                {
                    nQuantity_Pend_OC = 0;

                }

                if (nQuantity_Pend_OC < 0)
                {
                    nQuantity_Pend_OC = 0;
                }

                if (nQuantity_Pend_OC <= nQuantity)
                {
                    MessageBox.Show("La OC no tiene la cantidad suficiente para generar la recepción de materia prima:::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            /////////////////////////////////////////////////////            
            // Levanto el Splash para que el usuario espeeeeeeere

            Splash sp = new Splash();
            sp.ShowDialog();

            /////////////////////////////////////////////////////

            //////////////////////////////////////
            // Genero el avance de proceso

            t_mensaje.Text = "Genero Recibo Producción (1)";
            Application.DoEvents();
            Application.DoEvents();

            String mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo,"", "N/A");

            int nTerminationReportEntry;

            try
            {
                nTerminationReportEntry = int.Parse(mensaje);
                cErrorMensaje = "";

            }
            catch
            {
                nTerminationReportEntry = 0;
                cErrorMensaje = mensaje;

                MessageBox.Show("Error en la generación del Termination Report :::::: " + cErrorMensaje + ", opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            t_docentry_recibo.Text = nTerminationReportEntry.ToString();

            t_mensaje.Text = "Corrigo AbsEntry (2)";
            Application.DoEvents();
            Application.DoEvents();

            //////////////////////////////////////
            // Corrigo el AbsEntry 

            mensaje = clsRecepcion.SAPB1_RECEPCION3(nTerminationReportEntry, 59);

            //////////////////////////////////////
            // Obtengo el Nro de Lote

            string cDistNumber;

            objproducto8.cls_Consulta_Recibo_x_DocEntry_en_Detalle(nTerminationReportEntry);

            DataTable dTable9 = new DataTable();
            dTable9 = objproducto8.cResultado;

            try
            {
                cDistNumber = dTable9.Rows[0]["Lote"].ToString();

            }
            catch
            {
                cDistNumber = "";

            }

            int nRomanaEntry, nId_Pesaje;

            clsRecepcion objproducto1 = new clsRecepcion();

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nId_Pesaje = Convert.ToInt32(Grid1[0, i].Value.ToString());
                }
                catch
                {
                    nId_Pesaje = 0;
                }

                if (nId_Pesaje != 0)
                {
                    t_mensaje.Text = "Genero Marca de Recepción (4)";
                    Application.DoEvents();
                    Application.DoEvents();

                    try
                    {
                        mensaje = clsRecepcion.SAPB1_Recepcion(0, nId_Pesaje, VariablesGlobales.glb_User_id, "");

                    }
                    catch
                    {

                    }

                    t_mensaje.Text = "Genero Marca de Recepción (4.1)";

                    Application.DoEvents();
                    Application.DoEvents();

                    ////////////////////////////////////////
                    // Consulto el DocEntry de la Recepción

                    nRomanaEntry = 0;

                    try
                    {
                        clsRecepcion objproducto2 = new clsRecepcion();

                        objproducto2.cls_Consulta_Max_RecepcionMP();

                        DataTable dTable5 = new DataTable();
                        dTable5 = objproducto2.cResultado;

                        try
                        {
                            nRomanaEntry = int.Parse(dTable5.Rows[0]["DocEntry"].ToString());

                        }
                        catch
                        {
                            nRomanaEntry = 0;

                        }

                        Application.DoEvents();
                        Application.DoEvents();

                        Grid1[7, i].Value = nRomanaEntry.ToString();

                    }
                    catch
                    {

                    }

                    t_mensaje.Text = "Genero Marca de Recepción (4.2)";

                    Application.DoEvents();
                    Application.DoEvents();

                    //////////////////////////////////////
                    //////////////////////////////////////
                    // Genero la referencia con la Entrada de mercaderia

                    if (nRomanaEntry > 0)
                    {
                        try
                        {
                            mensaje = clsRecepcion.SAPB1_Recepcion1(nRomanaEntry, 0, t_cardcode.Text, t_cardname.Text, t_itemcode.Text, t_itemname.Text, float.Parse(0.ToString()), nTerminationReportEntry, "", t_cardcode_clte.Text, t_cardname_clte.Text);

                            Application.DoEvents();
                            Application.DoEvents();

                        }
                        catch
                        {

                        }

                    }

                    t_mensaje.Text = "Genero Marca de Recepción (4.3)";

                    Application.DoEvents();
                    Application.DoEvents();

                    try
                    {
                        mensaje = clsRecepcion.SAPB1_Recepcion9(nId_Pesaje, nTerminationReportEntry, VariablesGlobales.glb_User_id);

                    }
                    catch
                    {

                    }

                }

            }

            if (groupBox3.Visible == true)
            {

                t_mensaje.Text = "Genero Devolución al Productor (3)";
                Application.DoEvents();
                Application.DoEvents();

                mensaje = clsRecepcion.Devolucion_Mercaderia(t_cardcode.Text, t_cardname.Text, t_itemcode.Text, 0, "", "", dFecha.ToString("yyyyMMdd"), float.Parse(nQuantity.ToString()), "", 0, t_almacen.Text, 0, 0, 0, Convert.ToInt32(cDistNumber), Convert.ToInt32(nCantidadBins1), "", "", "6", UsuarioSap, ClaveSap, "Devol. Proceso Secado - OF:" + t_DocNum.Text + " - TR:" + nTerminationReportEntry.ToString());

                //////////////////////////////////////
                //////////////////////////////////////
                //////////////////////////////////////
                //////////////////////////////////////

                string cLote;
                int nParametrosCalidad;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Datos_Entrada_x_id(nTerminationReportEntry, "59", "");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                cLote = "";

                try
                {
                    cLote = dTable.Rows[0]["MdAbsEntry"].ToString();
                }
                catch
                {
                    cLote = "0";
                }

                try
                {
                    nParametrosCalidad = int.Parse(dTable.Rows[0]["Parametros_Calidad"].ToString());
                }
                catch
                {
                    nParametrosCalidad = 0;
                }

                Application.DoEvents();
                Application.DoEvents();

                //////////////////////////////////////////////////////////////
                // Corrigo el AbsEntry y le pongo la cantidad de Bins Correcta

                if (nCantidadBins1 > 1)
                {
                    mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR2(Convert.ToInt32(cLote), Convert.ToInt32(nCantidadBins1), UsuarioSap, ClaveSap);

                }

                //////////////////////////////////////////////////////////////
                // Genero la entrada de mercancia para el producto de la OC

                string cPatente, cConductor;
                string CardCode_Serv, CardName_Serv;
                string cItemCode_L0, cVARIEDAD, cPRESENTACION;
                string cTipoLote;

                int nPurchaseOrder, nBaseLineNum, nU_COMPRAPRODUCTOR;
                int nLote, nNumGuia, nEntradaMercaderiaEntry;

                double nPrecioXUnidad;

                string[,] d_arrDetalleBins = new string[20, 20];

                clsOrdendeCompra objproducto3 = new clsOrdendeCompra();
                clsRecepcion objproducto4 = new clsRecepcion();

                nNumGuia = Convert.ToInt32(cLote);
                cPatente = "";
                cConductor = "";
                cItemCode_L0 = "";
                CardCode_Serv = "";
                CardName_Serv = "";
                nPurchaseOrder = 0;
                nPrecioXUnidad = 0;
                nU_COMPRAPRODUCTOR = 0;
                cVARIEDAD = "";
                cPRESENTACION = "";
                cTipoLote = "";

                /////////////////////////////////////////
                /////////////////////////////////////////
                /// Determino el Cliente servicio

                t_mensaje.Text = "Valido datos de Orden de Compra (5)";
                Application.DoEvents();
                Application.DoEvents();

                int nNumOC_Ref;

                try
                {
                    nNumOC_Ref = Convert.ToInt32(t_numoc.Text);

                }
                catch
                {
                    nNumOC_Ref = 0;

                }

                if (nNumOC_Ref > 0)
                {

                    objproducto3.cls_Consultar_Ordenes_de_compra_x_DocNum(nNumOC_Ref);

                    DataTable dTable3 = new DataTable();
                    dTable3 = objproducto3.cResultado;

                    try
                    {
                        CardCode_Serv = dTable3.Rows[0]["U_ClienteServ"].ToString();

                    }
                    catch
                    {
                        CardCode_Serv = "";

                    }

                    try
                    {
                        CardName_Serv = dTable3.Rows[0]["U_ClienteServ_Name"].ToString();

                    }
                    catch
                    {
                        CardName_Serv = "";

                    }

                    try
                    {
                        cItemCode_L0 = dTable3.Rows[0]["ItemCode_L0"].ToString();
                    }
                    catch
                    {
                        cItemCode_L0 = "";
                    }

                    /////////////////////////////////////////
                    /////////////////////////////////////////
                    /// Determino el precio de costo OC

                    objproducto3.cls_Consultar_Ordenes_de_compra_x_numero(nNumOC_Ref, cItemCode_L0,0);

                    DataTable dTable4 = new DataTable();
                    dTable4 = objproducto3.cResultado;

                    try
                    {
                        nPurchaseOrder = Convert.ToInt32(dTable4.Rows[0]["DocEntry"].ToString());

                    }
                    catch
                    {
                        nPurchaseOrder = 0;

                    }

                    try
                    {
                        nBaseLineNum = Convert.ToInt32(dTable4.Rows[0]["LineNum"].ToString());
                    }
                    catch
                    {
                        nBaseLineNum = 0;
                    }

                    try
                    {
                        nPrecioXUnidad = Convert.ToDouble(dTable4.Rows[0]["Price"].ToString());
                    }
                    catch
                    {
                        nPrecioXUnidad = 0;
                    }

                    try
                    {
                        nU_COMPRAPRODUCTOR = int.Parse(dTable4.Rows[0]["U_COMPRAPRODUCTOR"].ToString());
                    }
                    catch
                    {
                        nU_COMPRAPRODUCTOR = 0;
                    }

                    try
                    {
                        cVARIEDAD = dTable4.Rows[0]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVARIEDAD = "";
                    }

                    try
                    {
                        cPRESENTACION = dTable4.Rows[0]["U_HDV_PRESENTACION"].ToString();
                    }
                    catch
                    {
                        cPRESENTACION = "";
                    }

                    nLote = 0;

                    objproducto1.cls_Consulta_Ultimo_Lote();

                    DataTable dTable1 = new DataTable();
                    dTable1 = objproducto1.cResultado;

                    try
                    {
                        nLote = Convert.ToInt32(dTable1.Rows[0]["DistNumber"].ToString());

                    }
                    catch
                    {
                        nLote = 0;

                    }

                    nLote += 1;

                    cTipoLote = "0";

                    switch (nU_COMPRAPRODUCTOR)
                    {
                        case 0: // No Aplica
                            cTipoLote = "6"; //No Asginado
                            break;
                        case 1: // Normal
                            cTipoLote = "3"; //Minimo Garantizado
                            break;
                        case 2: // Compra a Firme
                            cTipoLote = "2"; //Compra a Firme
                            break;
                        case 3: // Servicio 
                            cTipoLote = "7"; //Servicio 
                            break;
                    }

                    if (nCantidadBins < 0)
                    {
                        nCantidadBins = nCantidadBins * -1;
                    }

                    t_mensaje.Text = "Genero entrada de mercancia (6)";
                    Application.DoEvents();
                    Application.DoEvents();

                    mensaje = clsRecepcion.Entrada_Mercaderia(t_cardcode.Text, t_cardname.Text, cItemCode_L0, nNumGuia, cPatente, cConductor, dFecha.ToString("yyyyMMdd"), float.Parse(nQuantity.ToString()), "", 0, cAlmacenCabecera, nPrecioXUnidad, nPurchaseOrder, 0, nLote, nCantidadBins, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "52", t_codigo_CSG.Text,"");

                    if (mensaje == "Error de Conexión")
                    {
                        mensaje = clsRecepcion.Entrada_Mercaderia(t_cardcode.Text, t_cardname.Text, cItemCode_L0, nNumGuia, cPatente, cConductor, dFecha.ToString("yyyyMMdd"), float.Parse(nQuantity.ToString()), "", 0, cAlmacenCabecera, nPrecioXUnidad, nPurchaseOrder, 0, nLote, nCantidadBins, CardCode_Serv, CardName_Serv, cTipoLote, UsuarioSap, ClaveSap, cVARIEDAD, cPRESENTACION, "52", t_codigo_CSG.Text,"");

                    }

                    try
                    {
                        nEntradaMercaderiaEntry = int.Parse(mensaje);
                        cErrorMensaje = "";

                    }
                    catch
                    {
                        nEntradaMercaderiaEntry = 0;
                        cErrorMensaje = mensaje;

                        MessageBox.Show("Error en la generación de la entrada de mercancía :::::: " + cErrorMensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;

                    }

                    t_docentry_entrada.Text = nEntradaMercaderiaEntry.ToString();
                    t_docentry_mp.Text = nEntradaMercaderiaEntry.ToString();

                    t_mensaje.Text = "Corrigo AbsEntry entrada de mercancia (7)";
                    Application.DoEvents();
                    Application.DoEvents();

                    //////////////////////////////////////
                    // Corrigo el AbsEntry 

                    mensaje = clsRecepcion.SAPB1_RECEPCION3(nEntradaMercaderiaEntry, 20);

                    Application.DoEvents();
                    //t_mensaje.Text = "Grabación de registro - Corrigo AbsEntry " + nEntradaMercaderiaEntry.ToString() + " (5)...";
                    Application.DoEvents();

                    //////////////////////////////////////
                    // Obtengo el Nro de Lote

                    objproducto4.cls_Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(nEntradaMercaderiaEntry, 0);

                    DataTable dTable_9 = new DataTable();
                    dTable_9 = objproducto4.cResultado;

                    try
                    {
                        cDistNumber = dTable_9.Rows[0]["Lote"].ToString();

                    }
                    catch
                    {
                        cDistNumber = "";

                    }

                    Application.DoEvents();
                    //t_mensaje.Text = "Grabación de registro - Recupero Lote " + cDistNumber + " (6)...";
                    Application.DoEvents();

                    //////////////////////////////////////////////////////////
                    // Dejo el inventario en Cero siempre que sea fruta propia

                    string cTipoProducto;

                    cTipoProducto = "";

                    if (cItemCode_L0 != "")
                    {
                        try
                        {
                            cTipoProducto = cItemCode_L0.Substring(0, 2);
                        }
                        catch
                        {
                            cTipoProducto = "";
                        }

                        if (cTipoProducto == "FP")
                        {
                            t_mensaje.Text = "Revalorización de Inventario (8)...";

                            Application.DoEvents();
                            Application.DoEvents();

                            mensaje = "";

                            try
                            {
                                mensaje = clsProductos.Revalorizacion_Inventario(dFecha.ToString("yyyyMMdd"), cItemCode_L0, UsuarioSap, ClaveSap, "SEC-OF" + t_DocNum.Text);

                            }
                            catch
                            {

                            }

                            if (mensaje == "Error de Conexión")
                            {
                                try
                                {
                                    mensaje = clsProductos.Revalorizacion_Inventario(dFecha.ToString("yyyyMMdd"), cItemCode_L0, UsuarioSap, ClaveSap, "SEC-OF" + t_DocNum.Text);
                                }
                                catch
                                {

                                }

                            }

                        }

                    }

                    t_mensaje.Text = "Genero vinculo entre Entrada de mercancia y Recibo de producción (9)...";
                    Application.DoEvents();
                    Application.DoEvents();

                    string cReferencia_Lote_Servicio;

                    cReferencia_Lote_Servicio = t_DocNum.Text + "-" + cLote;

                    mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR3(nEntradaMercaderiaEntry, nTerminationReportEntry, cReferencia_Lote_Servicio, UsuarioSap, ClaveSap);

                    Application.DoEvents();
                    Application.DoEvents();

                    string cContraMuestra;
                    double nContraMuestra;
                    int nStockTransferEntry;

                    ////////////////////////////////////////
                    ////////////////////////////////////////
                    // Obtengo la cantidad de contramuestra 
                    // y descuento los x kilos para calidad

                    clsCalidad objproducto7 = new clsCalidad();
                    //objproducto2.cls_Consulta_Atributos_por_producto(ItemCode, "Hume%");
                    objproducto7.cls_Consulta_Atributos_por_producto(cItemCode_L0, "%");

                    DataTable dTable7 = new DataTable();
                    dTable7 = objproducto7.cResultado;

                    cContraMuestra = "";
                    nContraMuestra = 0;

                    try
                    {
                        cContraMuestra = dTable7.Rows[0]["U_ContraMu"].ToString();
                    }
                    catch
                    {
                        cContraMuestra = "";
                    }

                    try
                    {
                        nContraMuestra = Convert.ToDouble(dTable7.Rows[0]["U_CoMuSize"].ToString());
                    }
                    catch
                    {
                        nContraMuestra = 0;
                    }

                    try
                    {
                        nContraMuestra = Convert.ToDouble(dTable7.Rows[0]["Contra_Muestra"].ToString());
                    }
                    catch
                    {
                        nContraMuestra = 0;
                    }

                    t_mensaje.Text = "Saco lo kilos de la contra muestra (10)...";

                    Application.DoEvents();
                    Application.DoEvents();

                    if (nQuantity > nContraMuestra)
                    {
                        if (cContraMuestra == "Y")
                        {
                            if (nContraMuestra > 0)
                            {
                                if (cDistNumber != "")
                                {
                                    d_arrDetalleBins[1, 0] = cItemCode_L0;
                                    d_arrDetalleBins[2, 0] = nContraMuestra.ToString();
                                    d_arrDetalleBins[3, 0] = cAlmacenCabecera;
                                    d_arrDetalleBins[4, 0] = "LABCC"; // Almacen Destino
                                    d_arrDetalleBins[5, 0] = "0";
                                    d_arrDetalleBins[6, 0] = cDistNumber; // lote

                                    mensaje = clsRecepcion.Stock_Transfer("", "", "", dFecha.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                                    if (mensaje == "Error de Conexión")
                                    {
                                        mensaje = clsRecepcion.Stock_Transfer("", "", "", dFecha.ToString("yyyyMMdd"), d_arrDetalleBins, UsuarioSap, ClaveSap);

                                    }

                                    try
                                    {
                                        nStockTransferEntry = int.Parse(mensaje);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error en la generación de la transferencia de stock - :: " + mensaje + ", opción Cancelada", "Recepción de Matería Prima ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        nStockTransferEntry = 0;

                                    }

                                    //////////////////////////////////////
                                    //////////////////////////////////////

                                    Application.DoEvents();
                                    //t_mensaje.Text = "Grabación de registro - Transferencia de Lotes " + nStockTransferEntry.ToString() + " (7)...";
                                    Application.DoEvents();

                                    //////////////////////////////////////
                                    //////////////////////////////////////
                                    // Genero la referencia con la transferencia con los bins

                                }

                            }

                        }

                    }

                    //mensaje = clsRecepcion.SAPB1_Recepcion1(nRomanaEntry, nLineId, cCardCode, cCardName, cItemCode, cItemName, float.Parse(nPesoNeto.ToString()), nEntradaMercaderiaEntry, cWareHouse, CardCode_Serv, CardName_Serv);

                }

                //////////////////////////////////////
                //////////////////////////////////////
                // Genero la referencia con la Entrada de mercaderia

                //////////////////////////////////////

            }

            MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.DoEvents();

            btn_ok.Enabled = false;
            t_mensaje.Visible = false;

            toolStrip1.Enabled = true;

            Application.DoEvents();

            //VariablesGlobales.glb_id_calidad = 0;
            //VariablesGlobales.glb_Object = "59";
            //VariablesGlobales.glb_id_romana = 0;

            //VariablesGlobales.glb_DocEntry = nTerminationReportEntry;
            //VariablesGlobales.glb_LineId = 0;

            //VariablesGlobales.glb_NumOF = int.Parse(t_DocNum.Text);
            //VariablesGlobales.glb_LineNumOF = int.Parse(t_linea.Text);

            //VariablesGlobales.glb_ItemCode = t_itemcode.Text;
            //VariablesGlobales.glb_Lote = int.Parse(cLote);

            //if (nParametrosCalidad > 0)
            //{
            //    frmCalidadPP4 f2 = new frmCalidadPP4();
            //    DialogResult res = f2.ShowDialog();

            //}
            //else
            //{
            //    btn_imprimir.Enabled = true;
            //}

            toolStrip1.Enabled = true;
            btn_nuevo.Enabled = false;

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";
            VariablesGlobales.glb_LineId = 0;

            frmSel_OrdendeCompra f2 = new frmSel_OrdendeCompra();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                t_numoc.Text = VariablesGlobales.glb_NumOC.Trim();

                Carga_Datos_OC();

            }

        }

        private void  Carga_Datos_OC()
        {

            int DocNum;

            try
            {
                DocNum = int.Parse(t_numoc.Text);
            }
            catch
            {
                DocNum = 0;
            }

            if (DocNum > 0)
            {
                clsOrdendeCompra objproducto = new clsOrdendeCompra();
                objproducto.cls_Consultar_Ordenes_de_compra_x_DocNum(DocNum);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    t_cardcode.Text = dTable.Rows[0]["CardCode"].ToString();

                }
                catch
                {
                    t_cardcode.Text = "";
                }

                try
                {
                    t_cardname.Text = dTable.Rows[0]["CardName"].ToString();

                }
                catch
                {
                    t_cardname.Text = "";

                }

                try
                {
                    t_cardcode_clte.Text = dTable.Rows[0]["U_ClienteServ"].ToString();

                }
                catch
                {
                    t_cardcode_clte.Text = "";

                }

                try
                {
                    t_cardname_clte.Text = dTable.Rows[0]["U_ClienteServ_Name"].ToString();

                }
                catch
                {
                    t_cardname_clte.Text = "";

                }

                try
                {
                    t_itemcode.Text = dTable.Rows[0]["ItemCode_L0"].ToString();

                }
                catch
                {
                    t_itemcode.Text = "";
                }

                double nPrecioXUnidad;

                objproducto.cls_Consultar_Ordenes_de_compra_x_numero(DocNum, t_itemcode.Text,0);

                DataTable dTable9 = new DataTable();
                dTable9 = objproducto.cResultado;

                try
                {
                    nPrecioXUnidad = Convert.ToDouble(dTable9.Rows[0]["Price"].ToString());

                }
                catch
                {
                    nPrecioXUnidad = 0;

                }

                try
                {
                    t_line_ref.Text = Convert.ToString(dTable9.Rows[0]["LineNum"].ToString());

                }
                catch
                {
                    t_line_ref.Text = "0";

                }

            }

        }


        private void btn_ticket_pesaje_Click(object sender, EventArgs e)
        {


            int fila;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            int id_romana;

            try
            {
                id_romana = int.Parse(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                id_romana = 0;
            }

            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmRomanaA4 f2 = new frmRomanaA4();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void imprimirTarjeDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int nDocEntry, nDocEntry_TR_Secado, nDocEntry_EM_MPrima;

            nDocEntry_TR_Secado = 0;
            nDocEntry_EM_MPrima = 0;

            try
            {
                nDocEntry_TR_Secado = int.Parse(t_docentry_recibo.Text);
            }
            catch
            {
                nDocEntry_TR_Secado = 0;
            }

            try
            {
                nDocEntry_EM_MPrima = int.Parse(t_docentry_mp.Text);
            }
            catch
            {
                nDocEntry_EM_MPrima = 0;
            }

            if (nDocEntry_EM_MPrima != 0)
            {
                nDocEntry = nDocEntry_EM_MPrima;
            }
            else
            {
                nDocEntry = nDocEntry_TR_Secado;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("No se ha generado el recibo de producción, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (nDocEntry_EM_MPrima != 0)
            {
                nDocEntry = nDocEntry_EM_MPrima;

                VariablesGlobales.glb_Referencia1 = nDocEntry.ToString();
                VariablesGlobales.glb_Referencia2 = 0.ToString();

                frmRecepcionMP5 f2 = new frmRecepcionMP5();
                DialogResult res = f2.ShowDialog();

                VariablesGlobales.glb_Referencia1 = "";
                VariablesGlobales.glb_Referencia2 = "";

            }
            else
            {
                nDocEntry = nDocEntry_TR_Secado;

                VariablesGlobales.glb_DocEntry = nDocEntry;

                frmReporteProduccion f1 = new frmReporteProduccion();
                DialogResult res1 = f1.ShowDialog();

                VariablesGlobales.glb_DocEntry = 0;

            }

        }

        private void imprimirGuíaDeTrasladoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int nDocEntry;

            try
            {
                nDocEntry = int.Parse(t_docentry_recibo.Text);
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

            VariablesGlobales.glb_Referencia1 = nDocEntry.ToString();

            frmRecepcionMPB4 f2 = new frmRecepcionMPB4();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_Referencia1 = "";

        }

    }

}
