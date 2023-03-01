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
    public partial class frmRomanaA2 : Form
    {
        public frmRomanaA2()
        {
            InitializeComponent();
        }

        private void frmRomanaA2_Load(object sender, EventArgs e)
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

            if (VariablesGlobales.glb_User_Code == "manager")
                groupBox5.Visible = true;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            cbb_bins.DataSource = objproducto.cResultado;
            cbb_bins.ValueMember = "ItemCode";
            cbb_bins.DisplayMember = "ItemName";

            timer1.Enabled = true;
            btn_imprimir.Enabled = false;

            if (VariablesGlobales.glb_id_acceso != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_acceso.ToString();

                carga_datos_x_id();

            }

            int nDocNum;

            try
            {
                nDocNum = VariablesGlobales.glb_DocEntry;

            }
            catch
            {
                nDocNum = 0;

            }

            if (nDocNum != 0)
            {
                t_DocNum.Text = nDocNum.ToString();

                Carga_fruta();
                carga_producto();

                btn_buscar_of.Visible = false;

            }

        }

        private void carga_datos_x_id()
        {
            int id_romana;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, 0);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                t_DocNum.Text = dTable.Rows[0]["U_NumOC"].ToString();

            }
            catch
            {
                t_DocNum.Text = "";

            }

            Carga_fruta();
            carga_producto();

            string cItemCode_Bins;
            double nCant_Bins;

            try
            {
                cItemCode_Bins = dTable.Rows[0]["U_ItemCodeBins"].ToString();

            }
            catch
            {
                cItemCode_Bins = "";

            }

            try
            {
                nCant_Bins = Convert.ToDouble(dTable.Rows[0]["U_CantBins_D"].ToString());

            }
            catch
            {
                nCant_Bins = 0;

            }

            if (cItemCode_Bins != "")
            {
                cbb_bins.SelectedValue = cItemCode_Bins;

            }

            if (nCant_Bins > 0)
            {
                t_cantidad_envases.Text = nCant_Bins.ToString();

            }

            Calcula_peso_bins();

            float peso_bruto, peso_tara, peso_neto;

            try
            {
                peso_bruto = float.Parse(dTable.Rows[0]["U_PesoBruto_Full"].ToString());

            }
            catch
            {
                peso_bruto = 0;

            }

            try
            {
                peso_tara = float.Parse(dTable.Rows[0].ItemArray[14].ToString());

            }
            catch
            {
                peso_tara = 0;

            }

            try
            {
                peso_neto = float.Parse(dTable.Rows[0].ItemArray[15].ToString());

            }
            catch
            {
                peso_neto = 0;

            }

            try
            {
                // cant_envases = int.Parse(dTable.Rows[0].ItemArray[7].ToString());

            }
            catch
            {
                // cant_envases = 0;

            }

            t_bruto.Clear();
            t_peso_neto.Clear();

            if (peso_tara != 0)
            {
                t_bruto.Text = peso_tara.ToString("N2");

            }

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

        }


        private void Calcula_peso_bins()
        {
            int peso_bins;
            string cCod_Bins;
            double cant_bins;

            cant_bins = 0;
            cCod_Bins = "";
            peso_bins = 0;

            try
            {
                cant_bins = Convert.ToDouble(t_cantidad_envases.Text);

            }
            catch
            {
                cant_bins = 0;

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


        }

        private void Carga_fruta()
        {

            int nDocNum, nDocEntry, nConCascara;
            string cItemName, cSalida, cTipoProducto;

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

                    //sql = "select ";
                    //sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,  ";
                    //sql += "t0. , t1.ItemName , t1.InvntryUom , t0.UserSign , t0. , ";
                    //sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments ,  ";
                    //sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta , ";

                    //sql += "t2.LineNum , t2.ItemCode as  , t2.BaseQty , t2.PlannedQty as PlannedQty_D , ";
                    //sql += "t3.ItemName as ItemName_D , t2.Warehouse as  , t2.IssuedQty ,  ";
                    //sql += "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t2.ItemCode and ta1.WhsCode = t2.Warehouse ) , 0 ) as OnOrder_D , ";
                    //sql += "coalesce ( t3.InvntryUom , '' ) as InvntryUom_D ";

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

                t_cardcode.Text = cCardoCode_Prov;
                t_cardname.Text = nCardName_Prov;
                t_comuna.Text = cCity;

                t_cardcode_cliente.Text = cCardoCode_Cliente;
                t_cardname_cliente.Text = nCardName_Cliente;

            }

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

            t_PesoBalanza.Text = nPesoFinal.ToString("N2");

            double nTaraBins, nPesoNeto;

            t_PesoBalanza.Text = nPesoFinal.ToString("N2");
            t_bruto.Text = nPesoFinal.ToString("N2");

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
            t_cantidad_envases.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();
            t_comuna.Clear();

            t_cardcode_cliente.Clear();
            t_cardname_cliente.Clear();

            t_DocNum.Clear();

            t_itemcode.Clear();
            t_itemname.Clear();
            t_cantidad_envases.Clear();
            t_almacen.Clear();

            t_bruto.Clear();
            t_peso_envases.Clear();
            t_peso_neto.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();
            t_comuna.Clear();
            t_provincia.Clear();

            t_cardcode_cliente.Clear();
            t_cardname_cliente.Clear();

            t_id_romana.Clear();
            t_ItemCode_Cabecera.Clear();
            t_tipo_fruta.Clear();

            cbb_bins.Text = "";
            t_cantidad_envases.Clear();
            t_peso_neto.Clear();

            btn_buscar_of.Enabled = true;

        }

        private void t_cantidad_envases_Leave(object sender, EventArgs e)
        {
            Calcula_peso_bins();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int nPesoProvisorio = 0;
            double cantidad_envase;

            try
            {
                nPesoProvisorio = int.Parse(textBox1.Text);
            }
            catch
            {
                nPesoProvisorio = 0;
            }

            t_bruto.Text = nPesoProvisorio.ToString();

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToDouble(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float peso_bruto, peso_neto, peso_envases;

            peso_bruto = 0;
            peso_neto = 0;
            peso_envases = 0;

            try
            {
                peso_bruto = float.Parse(t_bruto.Text);

            }
            catch
            {
                peso_bruto = 0;
            }

            try
            {
                peso_envases = float.Parse(t_peso_envases.Text);
            }
            catch
            {
                peso_envases = 0;
            }

            peso_neto = peso_bruto - peso_envases;

            t_peso_neto.Text = Convert.ToString(peso_neto);

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

            t_fecha_2do_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            t_cantidad_envases_Leave(sender, e);

            t_bruto.Focus();

            Calcula_peso_bins();

            if (t_itemname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Orden de fabricación válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int num_of;

            try
            {
                num_of = Convert.ToInt32(t_DocNum.Text);
            }
            catch
            {
                num_of = 0;
            }

            if (num_of == 0)
            {
                MessageBox.Show("Debe ingresar una Orden de fabricación válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double cantidad_envase, nPesoTotal, nPesoTara;

            try
            {
                nPesoTotal = Convert.ToDouble(t_bruto.Text);

            }
            catch
            {
                nPesoTotal = 0;

            }

            if (nPesoTotal == 0)
            {
                MessageBox.Show("Debe ingresar una tara válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nPesoTara = 0;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToDouble(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (nPesoTara > 0)
            {
                if (t_cantidad_envases.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cantidad_envase == 0)
                {
                    MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }

            ///////////////////////////////////////////////////////////7
            // 
            // Valido los datos de la Romana **********
            // 
            // 

            string cCardCode_D, cItemCode_D, cItemCodeBis_D;
            int nNumOC_D;
            double nCantBins_D, nPesoTotal_D;

            cCardCode_D = "";
            cItemCode_D = "";
            cItemCodeBis_D = "";
            nCantBins_D = 0;

            nNumOC_D = num_of;
            cCardCode_D = "";
            cItemCode_D = t_itemcode.Text;

            try
            {
                nPesoTotal_D = Convert.ToDouble(t_bruto.Text);

            }
            catch
            {
                nPesoTotal_D = 0;

            }

            try
            {
                cItemCodeBis_D = cbb_bins.SelectedValue.ToString();

            }
            catch
            {
                cItemCodeBis_D = "";

            }

            try
            {
                nCantBins_D = Convert.ToDouble(t_cantidad_envases.Text);

            }
            catch
            {
                nCantBins_D = 0;

            }

            if (cItemCode_D.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Producto válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (nPesoTotal_D > 0)
            {
                if (cItemCodeBis_D.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un tipo de envase válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nCantBins_D == 0)
                {
                    MessageBox.Show("Debe ingresar una Cantidad de Bins válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            string CardCode, CardName; //, ItemName;
            string CardCode_trans, CardName_trans;
            string patente, conductor, cod_envase;
            int id_romana; //, id_acceso;
            int UserId;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia;
            string fecha_ini, fecha_fin;

            CardCode = t_cardcode.Text.Trim();
            CardName = t_cardname.Text.Trim();

            patente = "";
            conductor = "";

            cod_envase = "";

            //cantidad_envase
            CardCode_trans = "";
            CardName_trans = "";

            UserId = VariablesGlobales.glb_User_id;

            id_romana = 0;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            peso_bruto = 0;

            try
            {
                peso_bruto = float.Parse(t_bruto.Text);
            }
            catch
            {
                peso_bruto = 0;
            }

            peso_neto = 0;

            try
            {
                peso_neto = float.Parse(t_peso_neto.Text);
            }
            catch
            {
                peso_neto = 0;
            }

            peso_tara = 0;

            try
            {
                peso_tara = float.Parse(t_peso_envases.Text);
            }
            catch
            {
                peso_tara = 0;
            }

            peso_guia = 0;

            if (peso_bruto == 0)
            {
                MessageBox.Show("Debe ingresar un peso total válido para la guía, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (peso_neto == 0)
            {
                MessageBox.Show("Existe un error en el cálculo de los Envases, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (peso_neto == peso_bruto)
            {
                MessageBox.Show("Existe un error en el cálculo de los Envases, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // 1. Preguntar quien grabo este registro
            // siempre y cuando no sea el primer registros y que no venga de la romana (x_x)

            if ((id_romana > 0) && (t_peso_tara.Text == ""))
            {

                string cUsuarioAutorizado;
                double nPesoNetoBD, nPesoNetoFormulario;

                cUsuarioAutorizado = "N";
                nPesoNetoBD = 0;
                nPesoNetoFormulario = 0;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, -1);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                int nUserId, nUsuarioDocumento;

                try
                {
                    nUsuarioDocumento = Convert.ToInt32(dTable.Rows[0]["UserSign"].ToString());

                }
                catch
                {
                    nUsuarioDocumento = 0;

                }

                try
                {
                    nPesoNetoBD = Convert.ToDouble(dTable.Rows[0]["U_PesoNeto"].ToString());

                }
                catch
                {
                    nPesoNetoBD = 0;

                }

                try
                {
                    nPesoNetoFormulario = Convert.ToDouble(t_peso_neto.Text);

                }
                catch
                {
                    nPesoNetoFormulario = 0;

                }

                if (nPesoNetoBD == nPesoNetoFormulario)
                {

                    int nIdUsuarioPrograma;
                    string cNomUsuariosHabilitados;
                    string cNomUsuario, cNombreEmpleado, cApellidoEmpleado;

                    nIdUsuarioPrograma = 0;

                    try
                    {
                        nIdUsuarioPrograma = VariablesGlobales.glb_User_id;

                    }
                    catch
                    {
                        nIdUsuarioPrograma = 0;

                    }

                    cNomUsuario = "";
                    cNomUsuariosHabilitados = "";

                    // 2. Preguntar los jefes del que grabo

                    clsPorteria objproducto1 = new clsPorteria();
                    objproducto1.cls_Consultar_Dependencias_x_UserId(nUsuarioDocumento);

                    DataTable dTable1 = new DataTable();
                    dTable = objproducto1.cResultado;

                    for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                    {

                        try
                        {
                            nUserId = Convert.ToInt32(dTable.Rows[i]["UserId"].ToString());

                        }
                        catch
                        {
                            nUserId = 0;

                        }

                        if (nUsuarioDocumento != nUserId)
                        {
                            try
                            {
                                cNombreEmpleado = dTable.Rows[i]["Nombre"].ToString();

                            }
                            catch
                            {
                                cNombreEmpleado = "";

                            }

                            try
                            {
                                cApellidoEmpleado = dTable.Rows[i]["Apellido"].ToString();

                            }
                            catch
                            {
                                cApellidoEmpleado = "";

                            }

                            cNomUsuario = cNombreEmpleado.Trim() + " " + cApellidoEmpleado.Trim();

                            cNomUsuariosHabilitados = cNomUsuariosHabilitados + cNomUsuario + ", ";

                            if (nUserId == nIdUsuarioPrograma)
                            {
                                cUsuarioAutorizado = "S";

                            }

                        }


                    }

                    if (cNomUsuariosHabilitados.Trim() != "")
                    {
                        cNomUsuariosHabilitados = cNomUsuariosHabilitados.Substring(0, cNomUsuariosHabilitados.Length - 2);

                    }

                    // 3. Si el usuario de sistema es jefe

                    if (cUsuarioAutorizado == "N")
                    {
                        MessageBox.Show("Estimado " + VariablesGlobales.glb_User_Name + " este registro solo puede ser modificado por " + cNomUsuariosHabilitados + ", Opción cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            //t_fecha_1er_peso
            //t_fecha_2do_peso

            peso_neto = peso_bruto - peso_tara;

            fecha_ini = "19000101";
            fecha_fin = "19000101";

            string UserCode, cObservacion;
            int nLineId, num_guia;

            nLineId = 0;
            num_guia = 0;
            cObservacion = "";

            UserCode = VariablesGlobales.glb_User_Code;

            String mensaje = clsRomana.SAPB1_ROMANA(id_romana, CardCode, CardName, num_guia, patente, conductor, cod_envase, Convert.ToInt32(cantidad_envase), peso_bruto, fecha_ini, peso_tara, fecha_fin, peso_neto, cObservacion, -1, CardCode_trans, CardName_trans, UserId, peso_guia, nLineId, "E");

            if (id_romana == 0)
            {
                id_romana = 0;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Nuevo_DocEntry();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    id_romana = Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());

                }
                catch
                {
                    id_romana = 0;

                }

            }

            String mensaje1 = clsRomana.SAPB1_ROMANA2(id_romana, -1, "", "", "", "", "", 0, 0, 0,"","",0,"");

            mensaje1 = clsRomana.SAPB1_ROMANA2(id_romana, 0, cCardCode_D, "", cItemCode_D, t_itemname.Text, cItemCodeBis_D, Convert.ToInt32(nCantBins_D), nNumOC_D, 0,"","",0,"");

            mensaje = clsRomana.SAPB1_ROMANA(id_romana, CardCode, CardName, num_guia, patente, conductor, cod_envase, Convert.ToInt32(cantidad_envase), peso_bruto, fecha_ini, peso_tara, fecha_fin, peso_neto, cObservacion, -1, CardCode_trans, CardName_trans, UserId, peso_guia, nLineId, "S");

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            t_id_romana.Text = id_romana.ToString();

            carga_datos_x_id();


            btn_imprimir.Enabled = true;
            btn_ok.Enabled = false;

            //Close();

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int id_romana;

            id_romana = 0;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
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

        private void frmRomanaA2_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;

        }

        private void t_cantidad_envases_TextChanged(object sender, EventArgs e)
        {
            Calcula_peso_bins();

        }

        private void cbb_bins_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcula_peso_bins();

        }
    }

}
