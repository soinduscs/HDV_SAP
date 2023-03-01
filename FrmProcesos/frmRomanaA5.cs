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
    public partial class frmRomanaA5 : Form
    {
        public frmRomanaA5()
        {
            InitializeComponent();
        }

        private void frmRomanaA5_Load(object sender, EventArgs e)
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

            //Grid1.Rows.Clear();

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

            btn_ticket_pesaje.Enabled = false;

            clsRomana objproducto1 = new clsRomana();
            objproducto1.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            cbb_bins.DataSource = objproducto1.cResultado;
            cbb_bins.ValueMember = "ItemCode";
            cbb_bins.DisplayMember = "ItemName";

            timer1.Enabled = true;

            if (VariablesGlobales.glb_User_Code == "MANAGER")
                groupBox5.Visible = true;

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

            //Grid1.Rows.Clear();

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

                MessageBox.Show("La OF no tiene un ** Destino ** válido, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                btn_ok.Enabled = true;

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


        private void Carga_Datos_OC()
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

        private void Calcula_peso_bins()
        {
            int peso_bins;
            string cCod_Bins;
            double cant_bins, peso_x_bins, peso_bruto;

            cant_bins = 0;
            cCod_Bins = "";
            peso_bins = 0;
            peso_x_bins = 0;
            peso_bruto = 0;

            try
            {
                cant_bins = Convert.ToDouble(t_cantidad_envases.Text);

            }
            catch
            {
                cant_bins = 0;

            }

            try
            {
                peso_bruto = Convert.ToDouble(t_PesoBalanza.Text);

            }
            catch
            {
                peso_bruto = 0;

            }

            t_cantidad_envases.Text = cant_bins.ToString();

            try
            {
                cCod_Bins = cbb_bins.SelectedValue.ToString();

            }
            catch
            {
                cCod_Bins = "";

            }

            peso_bins = 0;


            if (cCod_Bins != "")
            {

                clsProductos objproducto = new clsProductos();
                objproducto.cls_consultar_Producto_x_codigo(cCod_Bins);

                DataTable dTable = new DataTable();

                dTable = objproducto.cResultado;

                try
                {
                    peso_bins = Convert.ToInt32(dTable.Rows[0].ItemArray[3].ToString());

                }
                catch
                {
                    peso_bins = 0;
                }

            }

            t_peso_envases.Text = (cant_bins * peso_bins).ToString("N2");

            if (cant_bins != 0)
            {
                t_peso_bins.Text = Math.Round((peso_bruto - (cant_bins * peso_bins)) / cant_bins, 2).ToString("N2");
            }
            else
            {
                t_peso_bins.Text = "0";
            }
            
            
            //peso_x_bins

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            ///////////////////////////////////////////
            ///////////////////////////////////////////

            //t_PesoBalanza.Text = "10030";
            //return;

            t_balanza.BackColor = Color.Red;
            Application.DoEvents();

            ///////////////////////////////////////////
            ///////////////////////////////////////////
            ///////////////////////////////////////////          

            Grid_Peso.Rows.Clear();

            string[] grilla;
            grilla = new string[8];
            int i = 0;

            string cBalanza_Puerto = "";
            int nBalanza_Baudios = 0;

            //int nBalanza_Baudios = 0, nBalanza_BitsDatos = 0;
            int nErr = 0;

            try
            {
                cBalanza_Puerto = ConfigurationManager.AppSettings.Get("Balanza_Puerto");
            }
            catch
            {
                cBalanza_Puerto = "COM1";
            }

            try
            {
                nBalanza_Baudios = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_Baudios"));
            }
            catch
            {
                nBalanza_Baudios = 1200;
            }

            //try
            //{
            //    //nBalanza_BitsDatos = int.Parse(ConfigurationManager.AppSettings.Get("Balanza_BitsDatos"));
            //}
            //catch
            //{
            //    nBalanza_BitsDatos = 0;
            //}

            SerialPort mySerialPort = new SerialPort(cBalanza_Puerto);

            mySerialPort.BaudRate = nBalanza_Baudios;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;

            try
            {
                mySerialPort.Open();
                nErr = 0;
            }
            catch
            {
                nErr = 1;
            }

            if (nErr == 1)
            {
                try
                {
                    mySerialPort.Close();
                }
                catch
                {

                }

                t_PesoBalanza.Text = "E_";
                t_balanza.BackColor = Color.Empty;

                //Thread.Sleep(300);
                timer1.Enabled = true;
                // return;

            }

            string b, cPack, cNumero;
            double nPeso;

            try
            {
                while (true)
                {

                    cPack = "";
                    nPeso = 0;
                    b = "";

                    try
                    {
                        b = mySerialPort.ReadExisting();
                    }
                    catch
                    {
                        b = "";
                    }

                    cPack = b;

                    if (VariablesGlobales.glb_SimboloDecimal != ".")
                    {
                        try
                        {
                            cPack = b.Replace(".", ",");
                        }
                        catch
                        {
                            cPack = b;
                        }

                    }

                    try
                    {
                        nPeso = double.Parse(cPack);
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    grilla[0] = i.ToString();
                    grilla[1] = cPack;
                    grilla[2] = nPeso.ToString();

                    Grid_Peso.Rows.Add(grilla);

                    Thread.Sleep(30);
                    i += 1;

                    if (i > 12)
                    {
                        break;
                    }

                }
            }
            catch
            {

            }

            try
            {
                mySerialPort.Close();

            }
            catch
            {

            }

            double nPesoBalanza;
            double nPesoFinal;

            nPesoBalanza = 0;
            nPesoFinal = 0;
            cNumero = "";

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    cNumero = Grid_Peso[2, j].Value.ToString();
                }
                catch
                {
                    cNumero = "";
                }

                try
                {
                    nPesoBalanza = double.Parse(cNumero);
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = Math.Round(nPesoBalanza, 1);
                }

            }

            if (groupBox5.Visible == true)
            {
                if (nPesoFinal ==0)
                {
                    try
                    {
                        nPesoFinal = double.Parse(textBox1.Text); 

                    }
                    catch
                    {
                        nPesoFinal = 0;
                    }

                }

            }

            t_PesoBalanza.Text = nPesoFinal.ToString("N");

            double nTaraBins, nPesoNeto;

            t_PesoBalanza.Text = nPesoFinal.ToString("N");
            t_peso_bruto.Text = nPesoFinal.ToString("N2");

            try
            {
                nTaraBins = Convert.ToDouble(t_peso_envases.Text);
            }
            catch
            {
                nTaraBins = 0;

            }

            nPesoNeto = nPesoFinal - nTaraBins;

            if (nPesoNeto < 0)
            {
                nPesoNeto = 0;

            }

            t_peso_neto.Text = nPesoNeto.ToString("N2");

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza.BackColor = Color.Empty;
            timer1.Enabled = true;

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cbb_bins_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcula_peso_bins();

        }

        private void t_cantidad_envases_TextChanged(object sender, EventArgs e)
        {
            Calcula_peso_bins();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            int nDocNum, nNumOC;
            string cAlmacenCabecera, cItemCode_Bins;

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

            btn_ok.Enabled = false;
            Application.DoEvents();

            string cDocDate;

            DateTime dFecha;

            dFecha = DateTime.Parse("01/01/1900");

            clsMaestros objproducto5 = new clsMaestros();
            objproducto5.cls_lee_fecha_servidor();

            DataTable dTable5 = new DataTable();
            dTable5 = objproducto5.cResultado;

            try
            {
                dFecha = Convert.ToDateTime(dTable5.Rows[0]["fecha"].ToString());

            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");

            }

            //try
            //{
            //    dFecha = Convert.ToDateTime(t_fecha_contable.Text);
            //}
            //catch
            //{
            //    dFecha = DateTime.Parse("01/01/1900");
            //}

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

            cItemCode_Bins = "";

            try
            {
                cItemCode_Bins = cbb_bins.SelectedValue.ToString();

            }
            catch
            {
                cItemCode_Bins = "";

            }

            if (cItemCode_Bins == "")
            {
                MessageBox.Show("Debe seleccionar un tipo de bins válido, opción Cancelada", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btn_ok.Enabled = true;
                Application.DoEvents();

                return;

            }

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
                nCantidadBins1 = Convert.ToDouble(t_cantidad_envases.Text);
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

                    btn_ok.Enabled = true;
                    Application.DoEvents();

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

            String mensaje = clsOrdenFabricacion.Entrada_Mercaderia_TR(cDocDate, nDocNum, nLineNum, nQuantity, cWharehouse, nCantidadBins, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, nPesoUltimaCaja, cSalidaProduccion, UsuarioSap, ClaveSap, cVariedadConsumo, cItemCode_Bins, "N/A");

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

                btn_ok.Enabled = true;
                Application.DoEvents();

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

            //int nRomanaEntry, nId_Pesaje;

            clsRecepcion objproducto1 = new clsRecepcion();

            //////////////////////////////////////
            //////////////////////////////////////
            // Genero la Entrada de mercaderia

            if (groupBox3.Visible == true)
            {

                t_mensaje.Text = "Genero Devolución al Productor (3)";
                Application.DoEvents();
                Application.DoEvents();

                // mensaje = clsRecepcion.Devolucion_Mercaderia(t_cardcode.Text, t_cardname.Text, t_itemcode.Text, 0, "", "", dFecha.ToString("yyyyMMdd"), float.Parse(nQuantity.ToString()), "", 0, t_almacen.Text, 0, 0, 0, Convert.ToInt32(cDistNumber), Convert.ToInt32(nCantidadBins1), "", "", "6", UsuarioSap, ClaveSap, "Devol. Proceso Secado - OF:" + t_DocNum.Text + " - TR:" + nTerminationReportEntry.ToString());

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

            }

            MessageBox.Show("Proceso Realizado con Exito", "Termination Report ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.DoEvents();

            btn_ok.Enabled = false;
            t_mensaje.Visible = false;

            btn_ticket_pesaje.Enabled = true;

            Application.DoEvents();

        }

        private void btn_ticket_pesaje_Click(object sender, EventArgs e)
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

            VariablesGlobales.glb_DocEntry = nDocEntry;
            VariablesGlobales.glb_Object = "";
            VariablesGlobales.glb_Lote = 0;

            frmReporteProduccion f2 = new frmReporteProduccion();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_Object = "";
            VariablesGlobales.glb_Lote = 0;

        }

    }

}
