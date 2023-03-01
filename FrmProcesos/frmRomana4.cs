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
using System.Threading;
using System.Configuration;
using System.IO;
using System.IO.Ports;

namespace FrmProcesos
{
    public partial class frmRomana4 : Form
    {
        public frmRomana4()
        {
            InitializeComponent();
        }

        private void frmRomana4_Load(object sender, EventArgs e)
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

            groupBox5.Visible = false;

            btn_nuevo_Click(sender, e);

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_lista_bins();

            DataGridViewComboBoxColumn my_DGVCboColumn = new DataGridViewComboBoxColumn();

            my_DGVCboColumn.DataSource = objproducto.cResultado;
            my_DGVCboColumn.Name = "Tipo de Envases";
            my_DGVCboColumn.ValueMember = "ItemCode";
            my_DGVCboColumn.DisplayMember = "ItemName";

            Grid1.Columns.RemoveAt(5);
            Grid1.Columns.Insert(5, my_DGVCboColumn);
            Grid1.Columns[5].Width = 240;

            if (VariablesGlobales.glb_id_acceso != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_acceso.ToString();
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                carga_datos_x_id();

                btn_pesaje_entrada.Enabled = false;
                btn_pesaje_previo.Enabled = false;
                btn_graba_bruto.Enabled = false;
                btn_graba_neto.Enabled = false;

            }

            timer1.Enabled = true;

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            t_peso_tara.Clear();

            button3.Visible = false;
            t_patente.ReadOnly = true;
            t_conductor.ReadOnly = true;
            t_num_guia.ReadOnly = true;

            btn_pesaje_entrada.Enabled = true;
            btn_sin_porteria.Enabled = true;
            btn_pesaje_previo.Enabled = true;
            btn_imprimir.Enabled = false;
            btn_ok.Enabled = true;

            tsb_agrega_oc.Enabled = true;
            tsb_agrega_productor.Enabled = true;
            tsb_define.Enabled = true;
            tsb_eliminar.Enabled = true;

            t_cardcode.Clear();
            //btn_buscar1.Visible = true;
            t_cardname.Clear();
            //btn_buscar2.Visible = true;

            t_cardcode.ReadOnly = true;
            t_num_guia.ReadOnly = true;
            t_patente.ReadOnly = true;
            t_conductor.ReadOnly = true;

            t_num_guia.Clear();
            t_CardoName_Trans.Clear();
            t_patente.Clear();
            t_conductor.Clear();

            t_cantidad_envases.Clear();
            t_peso_bruto.Clear();
            t_fecha_1er_peso.Clear();

            t_tara.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_peso_envases.Clear();

            t_observacion.Clear();

            btn_graba_neto.Enabled = false;
            lnk_ver_documento.Enabled = false;

            t_id_acceso.Clear();
            t_ref.Clear();
            t_Line_Id.Clear();
            t_id_romana.Clear();

            t_cardcode.Focus();

            Grid1.Rows.Clear();

            Grid1.Columns[5].ReadOnly = false;
            Grid1.Columns[6].ReadOnly = false;

        }

        private void btn_pesaje_entrada_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            VariablesGlobales.glb_id_acceso = 0;
            VariablesGlobales.glb_Referencia1 = "Romana";
            VariablesGlobales.glb_Razon_Ingreso = "3";

            frmPorteria3 f2 = new frmPorteria3();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_id_acceso != 0)
            {

                t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();

                carga_datos_porteria();

                //carga_datos_x_id_2do_peso();

                t_cardcode.ReadOnly = true;
                t_num_guia.ReadOnly = true;
                t_patente.ReadOnly = true;
                t_conductor.ReadOnly = true;

                lnk_ver_documento.Enabled = true;

                btn_pesaje_entrada.Enabled = false;
                btn_sin_porteria.Enabled = false;
                btn_pesaje_previo.Enabled = false;
                btn_graba_bruto.Enabled = true;

            }

            timer1.Enabled = true;

            VariablesGlobales.glb_Referencia1 = "";

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
                return;

            }

            string b, cPack, cNumero;
            int nPeso;

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

                    try
                    {
                        cPack = b.Substring(2, 1);
                    }
                    catch
                    {
                        cPack = "";
                    }

                    if (cPack == "0")
                    {
                        try
                        {
                            cNumero = b.Substring(2, 6);
                        }
                        catch
                        {
                            cNumero = "0";
                        }

                        nPeso = int.Parse(cNumero);

                    }
                    else
                    {

                    }

                    grilla[0] = i.ToString();
                    grilla[1] = b;
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
                //serialPort.DiscardInBuffer();
                mySerialPort.Close();
            }
            catch
            {

            }

            int nPesoBalanza, nPesoFinal;

            nPesoBalanza = 0;
            nPesoFinal = 0;

            for (int j = 0; j <= Grid_Peso.RowCount - 1; j++)
            {

                try
                {
                    nPesoBalanza = int.Parse(Grid_Peso[2, j].Value.ToString());
                }
                catch
                {
                    nPesoBalanza = 0;
                }

                if (nPesoBalanza > 0)
                {
                    nPesoFinal = nPesoBalanza;
                }

            }

            t_PesoBalanza.Text = nPesoFinal.ToString();

            ///////////////////////////////////////////

            Thread.Sleep(10);
            t_balanza.BackColor = Color.Empty;
            timer1.Enabled = true;

        }

        private void carga_datos_porteria()
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

            if (id_acceso == 0)
            {
                return;
            }

            clsPorteria objproducto = new clsPorteria();
            objproducto.cls_Consultar_Accesos_x_Id(id_acceso);

            DataTable dTable = new DataTable();

            dTable = objproducto.cResultado;

            string CardCode, CardName;
            string CardCode_trans, CardName_trans;
            int numguia;
            string patente, conductor;
            DateTime fecha_hora;

            CardCode = "";
            CardName = "";
            CardCode_trans = "";
            CardName_trans = "";
            numguia = 0;
            patente = "";
            conductor = "";
            fecha_hora = DateTime.Parse("01/01/1900");

            t_cardcode.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();

            try
            {
                //CardCode = dTable.Rows[0].ItemArray[1].ToString();
                CardCode = dTable.Rows[0]["U_CardCode"].ToString();
                //

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
                CardCode_trans = dTable.Rows[0].ItemArray[8].ToString();

            }
            catch
            {
                CardCode_trans = "";

            }

            try
            {
                CardName_trans = dTable.Rows[0]["U_CardName_Trans"].ToString();

            }
            catch
            {
                CardName_trans = "";

            }

            try
            {
                patente = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[7].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[4].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                fecha_hora = DateTime.Parse(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                fecha_hora = DateTime.Parse("01/01/1900");

            }

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_CardoCode_Trans.Text = CardCode_trans;
            t_CardoName_Trans.Text = CardName_trans;
            t_peso_guia.Text = "0";

            btn_buscar1.Visible = false;
            btn_buscar2.Visible = false;

            t_cardcode.ReadOnly = true;
            t_num_guia.ReadOnly = true;
            t_patente.ReadOnly = true;
            t_conductor.ReadOnly = true;

            string[] grilla;
            grilla = new string[8];

            grilla[0] = "";
            grilla[1] = CardCode.Trim().ToUpper();
            grilla[2] = CardName.Trim().ToUpper();
            grilla[3] = "";
            grilla[4] = "";
            grilla[5] = "_";
            grilla[6] = "0";
            grilla[7] = "0";

            //Grid1.Rows.Add(grilla);

            Calcula_bins();

            t_ref.Text = "S";

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                //MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            int num_guia;

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            if (num_guia == 0)
            {
                //MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                //MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                //MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            ///////////////////////////////////////////////////////////7
            // 
            // Valido los datos de la Romana **********
            // 
            // 

            string cCardCode_D, cItemCode_D, cItemCodeBis_D;
            int nCantBins_D, nCant_ItemsValidos_D, nSumaBins_D;
            int nNumOC_D;

            cCardCode_D = "";
            cItemCode_D = "";
            cItemCodeBis_D = "";
            nCantBins_D = 0;
            nCant_ItemsValidos_D = 0;
            nSumaBins_D = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC_D = Convert.ToInt32(Grid1[0, i].Value.ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                cCardCode_D = Grid1[1, i].Value.ToString().ToUpper();
                cItemCode_D = Grid1[3, i].Value.ToString().ToUpper();
                cItemCodeBis_D = Grid1[5, i].Value.ToString().ToUpper();

                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[6, i].Value);

                }
                catch
                {
                    nCantBins_D = 0;

                }

                if (cCardCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Productor válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Producto válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCodeBis_D.Trim() == "")
                {
                    //MessageBox.Show("Debe seleccionar un tipo de envase válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                if (nCantBins_D == 0)
                {
                    //MessageBox.Show("Debe ingresar una Cantidad de Bins válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;

                }

                nSumaBins_D = nSumaBins_D + nCantBins_D;
                nCant_ItemsValidos_D = +1;

            }

            if (nCant_ItemsValidos_D == 0)
            {
                //MessageBox.Show("Debe ingresar datos válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

            }

            if (cantidad_envase != nSumaBins_D)
            {
                //MessageBox.Show("La Cantidad total de Bins NO corresponde con lo definido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

            }

            string CardCode, CardName; //, ItemName;
            string CardCode_trans, CardName_trans;
            string patente, conductor, cod_envase;
            int id_romana, id_acceso;
            int UserId;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia;
            string fecha_ini, fecha_fin;

            CardCode = t_cardcode.Text.Trim();
            CardName = t_cardname.Text.Trim();
            //num_pedido_compra 
            //itemcode
            //ItemName = cbb_Producto.Text.Trim();
            //num_guia;
            patente = t_patente.Text.Trim();
            conductor = t_conductor.Text.Trim();

            cod_envase = "";

            //cantidad_envase
            CardCode_trans = t_CardoCode_Trans.Text.Trim();
            CardName_trans = t_CardoName_Trans.Text.Trim();

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
                peso_bruto = float.Parse(t_peso_bruto.Text);
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
                peso_tara = (float)Math.Round(float.Parse(t_tara.Text));
            }
            catch
            {
                peso_tara = 0;
            }

            peso_guia = 0;

            try
            {
                peso_guia = float.Parse(t_peso_guia.Text);
            }
            catch
            {
                peso_guia = 0;
            }

            if (peso_guia == 0)
            {
                //MessageBox.Show("Debe ingresar un peso de guía válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (peso_bruto == 0)
            {
                MessageBox.Show("Debe ingresar un peso total válido para la guía, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);
            }
            catch
            {
                id_acceso = 0;
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

            fecha_ini = "19000101";
            fecha_fin = "19000101";

            string UserCode;
            int nLineId;

            nLineId = 0;

            try
            {
                nLineId = int.Parse(t_Line_Id.Text);

            }
            catch
            {
                nLineId = 0;

            }


            if ((id_romana == 0) && (id_acceso == 0) && (button3.Visible == true))
            {

                String mensaje3 = clsPorteria.SAPB1_ACCESO(id_acceso, CardCode, CardName, num_guia, patente, UserId, conductor, "", "", "", "3", "", "");

                //MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje3 == "Y")
                {
                    if (id_acceso == 0)
                    {
                        int new_id_acceso;

                        new_id_acceso = 0;

                        clsPorteria objproducto2 = new clsPorteria();
                        objproducto2.cls_Consultar_Accesos_max_Id();

                        DataTable dTable2 = new DataTable();
                        dTable2 = objproducto2.cResultado;

                        try
                        {
                            new_id_acceso = Convert.ToInt32(dTable2.Rows[0].ItemArray[0].ToString());

                        }
                        catch
                        {
                            new_id_acceso = 0;
                        }

                        t_id_acceso.Text = new_id_acceso.ToString();
                        id_acceso = new_id_acceso;

                    }

                }


            }

            UserCode = VariablesGlobales.glb_User_Code;

            String mensaje = clsRomana.SAPB1_ROMANA(id_romana, CardCode, CardName, num_guia, patente, conductor, cod_envase, cantidad_envase, peso_bruto, fecha_ini, peso_tara, fecha_fin, peso_neto, t_observacion.Text.Trim(), id_acceso, CardCode_trans, CardName_trans, UserId, peso_guia, nLineId, "S");

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

            string cCardName_D, cItemName_D;
            int nPesoBis_D;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC_D = Convert.ToInt32(Grid1[0, i].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                cCardCode_D = Grid1[1, i].Value.ToString().ToUpper();
                cCardName_D = Grid1[2, i].Value.ToString().ToUpper();
                cItemCode_D = Grid1[3, i].Value.ToString().ToUpper();
                cItemName_D = Grid1[4, i].Value.ToString().ToUpper();
                cItemCodeBis_D = Grid1[5, i].Value.ToString().ToUpper();

                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[6, i].Value);

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    nPesoBis_D = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    nPesoBis_D = 0;

                }

                if (cCardCode_D.Trim() != "")
                {

                    if (cItemCode_D.Trim() != "")
                    {

                        if (cItemCodeBis_D.Trim() != "")
                        {
                            mensaje1 = clsRomana.SAPB1_ROMANA2(id_romana, i, cCardCode_D, cCardName_D, cItemCode_D, cItemName_D, cItemCodeBis_D, nCantBins_D, nNumOC_D, 0,"","",0,"");

                        }

                    }

                }

            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            carga_datos_x_id();

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
                btn_nuevo_Click(sender, e);

            }

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

                frmRomana5 f2 = new frmRomana5();
                DialogResult res = f2.ShowDialog();

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

        private void btn_graba_bruto_Click(object sender, EventArgs e)
        {

            if (t_PesoBalanza.Text == "E_")
            {
                if (VariablesGlobales.glb_User_Code.ToUpper() == "MANAGER")
                {
                    groupBox5.Visible = true;
                    //t_PesoBalanza.Text = "15610";

                }

            }


            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                t_num_guia.Text = "";
                //MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                //MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            t_peso_bruto.Text = t_PesoBalanza.Text;

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

            try
            {
                dt = Convert.ToDateTime(dTable.Rows[0].ItemArray[0].ToString());

            }
            catch
            {
                dt = DateTime.Now;

            }

            t_fecha_1er_peso.Text = dt.ToString("dd/MM/yyyy HH:mm");

        }

        private void btn_graba_neto_Click(object sender, EventArgs e)
        {

            if (t_PesoBalanza.Text == "E_")
            {
                if (VariablesGlobales.glb_User_Code.ToUpper() == "MANAGER")
                {
                    groupBox5.Visible = true;
                    //t_PesoBalanza.Text = "35860";
                }

            }

            t_peso_tara.Text = "x_x";

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_num_guia.Text.Trim() == "")
            {
                t_num_guia.Text = "";
                //MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                //MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            float peso_bruto, peso_tara, peso_neto, peso_envases;

            peso_bruto = 0;
            peso_tara = 0;
            peso_neto = 0;
            peso_envases = 0;

            try
            {
                peso_bruto = float.Parse(t_peso_bruto.Text);

            }
            catch
            {
                peso_bruto = 0;
            }

            t_tara.Text = t_PesoBalanza.Text;

            try
            {
                peso_envases = float.Parse(t_peso_envases.Text);

            }
            catch
            {
                peso_envases = 0;
            }


            try
            {
                peso_tara = float.Parse(t_tara.Text);

            }
            catch
            {
                peso_tara = 0;
            }

            peso_neto = peso_tara - (peso_bruto + peso_envases);

            t_peso_neto.Text = Convert.ToString(peso_neto);            

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_fecha_sql();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            DateTime dt;
            //string s = dt.ToString("yyyyMMddHHmmss");

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

        private void tsb_agrega_oc_Click(object sender, EventArgs e)
        {

            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_NumOC = "";
            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";
            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_OrdendeVenta f2 = new frmSel_OrdendeVenta();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                string[] grilla;
                grilla = new string[8];

                grilla[0] = VariablesGlobales.glb_NumOC.Trim();
                grilla[1] = VariablesGlobales.glb_CardCode.Trim();
                grilla[2] = VariablesGlobales.glb_CardName.Trim();
                grilla[3] = VariablesGlobales.glb_ItemCode.Trim();
                grilla[4] = VariablesGlobales.glb_ItemName.Trim();
                grilla[5] = "_";
                grilla[6] = "0";
                grilla[7] = "0";

                Grid1.Rows.Add(grilla);

            }

        }

        private void tsb_agrega_productor_Click(object sender, EventArgs e)
        {
            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {

                string cCodigoNew, cCodigoOld;
                int nExiste;

                nExiste = 0;

                cCodigoNew = VariablesGlobales.glb_CardCode.Trim().ToUpper();

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {
                    cCodigoOld = Grid1[0, i].Value.ToString().ToUpper();

                    if (cCodigoNew == cCodigoOld)
                    {
                        nExiste += 1;
                    }

                }

                if (nExiste > 1)
                {
                    DialogResult result = MessageBox.Show("El Productor seleccionado ya esta en lista asociada a la Guía, lo desea agregar?", "Despacho de Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;

                    }
                }

                string[] grilla;
                grilla = new string[8];

                grilla[0] = "";
                grilla[1] = VariablesGlobales.glb_CardCode.Trim();
                grilla[2] = VariablesGlobales.glb_CardName.Trim();
                grilla[3] = "";
                grilla[4] = "";
                grilla[5] = "_";
                grilla[6] = "0";
                grilla[7] = "0";

                Grid1.Rows.Add(grilla);

            }

        }

        private void tsb_define_Click(object sender, EventArgs e)
        {
            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nNumOC;

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
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            nNumOC = 0;

            try
            {
                nNumOC = int.Parse(Grid1[0, fila].Value.ToString());

            }
            catch
            {
                nNumOC = 0;

            }

            if (nNumOC != 0)
            {
                MessageBox.Show("Debe ingresar un Productor que no este asociado a orden de venta, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (tsb_define.Enabled == false)
            {
                return;
            }

            VariablesGlobales.glb_ItemCode = "";
            VariablesGlobales.glb_ItemName = "";

            frmSel_Productos f2 = new frmSel_Productos();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_ItemCode != "")
            {
                Grid1[3, fila].Value = VariablesGlobales.glb_ItemCode;
                Grid1[4, fila].Value = VariablesGlobales.glb_ItemName;

            }

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {
            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Despacho de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Despacho de Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil, cant_bins, peso_bins;
            string cCod_Bins;

            cant_bins = 0;
            fil = 0;
            cCod_Bins = "";
            peso_bins = 0;

            try
            {
                fil = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                cant_bins = Convert.ToInt32(Grid1[6, fil].Value);

            }
            catch
            {
                cant_bins = 0;

            }

            try
            {
                cCod_Bins = Grid1[5, fil].Value.ToString();

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

            Grid1[6, fil].Value = Convert.ToString(cant_bins);
            Grid1[7, fil].Value = Convert.ToString(peso_bins);

            Calcula_bins();

        }

        private void Calcula_bins()
        {

            int total_bins, cant_unit_bins;
            int peso_tot_bins, peso_unit_bins;

            total_bins = 0;
            cant_unit_bins = 0;
            peso_tot_bins = 0;
            peso_unit_bins = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cant_unit_bins = Convert.ToInt32(Grid1[6, i].Value);

                }
                catch
                {
                    cant_unit_bins = 0;
                }

                try
                {
                    peso_unit_bins = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    peso_unit_bins = 0;
                }

                total_bins = total_bins + cant_unit_bins;
                peso_tot_bins = peso_tot_bins + (peso_unit_bins * cant_unit_bins);

            }

            t_cantidad_envases.Text = total_bins.ToString();
            t_peso_envases.Text = peso_tot_bins.ToString("N2");

        }

        private void btn_pesaje_previo_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_id_romana = 0;
            VariablesGlobales.glb_LineId = 0;
            VariablesGlobales.glb_Razon_Ingreso = "3";

            frmRomana1 f2 = new frmRomana1();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_id_romana != 0)
            {
                t_id_romana.Text = Convert.ToString(VariablesGlobales.glb_id_romana);
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                btn_buscar1.Visible = false;
                btn_buscar2.Visible = false;

                t_cardcode.ReadOnly = true;
                t_num_guia.ReadOnly = true;
                t_patente.ReadOnly = true;
                t_conductor.ReadOnly = true;

                carga_datos_x_id();

                btn_pesaje_entrada.Enabled = false;
                btn_sin_porteria.Enabled = false;
                btn_pesaje_previo.Enabled = false;

            }

        }


        private void carga_datos_x_id()
        {

            int id_romana, nLineId;

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

            try
            {
                nLineId = int.Parse(t_Line_Id.Text);

            }
            catch
            {
                nLineId = 0;

            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor, ItemCodeBins;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia, peso_bins;
            string obs;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso;
            string CardCode_trans, CardName_trans;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            CardCode_trans = "";
            CardName_trans = "";
            ItemCodeBins = "_";
            numguia = 0;
            patente = "";
            conductor = "";
            peso_bruto = 0;
            peso_tara = 0;
            peso_neto = 0;
            peso_guia = 0;
            cant_envases = 0;
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            peso_bins = 0;

            t_cardcode.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_peso_bruto.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_cantidad_envases.Clear();
            t_observacion.Clear();
            t_fecha_1er_peso.Clear();
            t_tara.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_id_acceso.Clear();
            t_CardoName_Trans.Clear();
            t_CardoCode_Trans.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, nLineId);

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
                ItemName = dTable.Rows[0].ItemArray[4].ToString();

            }
            catch
            {
                ItemName = "";

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
                peso_bruto = float.Parse(dTable.Rows[0].ItemArray[13].ToString());

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
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());

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

            try
            {
                CardCode_trans = dTable.Rows[0].ItemArray[21].ToString();

            }
            catch
            {
                CardCode_trans = "";

            }

            try
            {
                CardName_trans = dTable.Rows[0].ItemArray[22].ToString();

            }
            catch
            {
                CardName_trans = "";

            }

            try
            {
                peso_guia = float.Parse(dTable.Rows[0].ItemArray[27].ToString());

            }
            catch
            {
                peso_guia = 0;

            }

            try
            {
                peso_bins = float.Parse(dTable.Rows[0].ItemArray[31].ToString());

            }
            catch
            {
                peso_bins = 0;

            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////
            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D;
            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D, nCantAnalisisCalidad_Total;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nCantAnalisisCalidad_Total = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nNumOC_D = 0;
                cCardCode_D = "";
                cCardName_D = "";
                cItemCode_D = "";
                cItemName_D = "";
                nCantBins_D = 0;
                n_PesoUnitBins_D = 0;
                nCantAnalisisCalidad_D = 0;

                try
                {
                    nNumOC_D = Convert.ToInt32(dTable.Rows[i]["U_NumOC"].ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                try
                {
                    cCardCode_D = dTable.Rows[i].ItemArray[28].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cCardName_D = dTable.Rows[i].ItemArray[29].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemCode_D = dTable.Rows[i].ItemArray[3].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemName_D = dTable.Rows[i].ItemArray[4].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    ItemCodeBins = dTable.Rows[i].ItemArray[12].ToString();

                }
                catch
                {
                    ItemCodeBins = "_";

                }

                try
                {
                    nCantBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[30].ToString().ToUpper());

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    n_PesoUnitBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[32].ToString().ToUpper());
                }
                catch
                {
                    n_PesoUnitBins_D = 0;
                }

                try
                {
                    nCantAnalisisCalidad_D = Convert.ToInt32(dTable.Rows[i]["Cant_Analisis_Calidad"].ToString().ToUpper());

                }
                catch
                {
                    nCantAnalisisCalidad_D = 0;

                }

                nCantAnalisisCalidad_Total = nCantAnalisisCalidad_Total + nCantAnalisisCalidad_D;

                grilla[0] = nNumOC_D.ToString();
                grilla[1] = cCardCode_D.ToUpper();
                grilla[2] = cCardName_D.ToUpper();
                grilla[3] = cItemCode_D.ToUpper();
                grilla[4] = cItemName_D.ToUpper();
                grilla[5] = ItemCodeBins;
                grilla[6] = Convert.ToString(nCantBins_D);
                grilla[7] = Convert.ToString(n_PesoUnitBins_D);
                grilla[8] = Convert.ToString(nCantAnalisisCalidad_D);

                if (cCardCode_D != "")
                {
                    Grid1.Rows.Add(grilla);

                }

            }

            Calcula_bins();

            //sql += "Patente 6, Envases 7, FechaPeso1 8, PesoBruto 9 ";
            //sql += "from db_ROMANA ";
            //sql += "where id_romana = " + id_romana + " ";

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_CardoName_Trans.Text = CardName_trans;
            t_CardoCode_Trans.Text = CardCode_trans;

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_acceso.Text = Convert.ToString(id_acceso);

            t_peso_bruto.Text = peso_bruto.ToString("N2");
            t_tara.Clear();
            t_peso_neto.Clear();

            if (peso_tara != 0)
            {
                t_tara.Text = peso_tara.ToString("N2");

            }

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

            if (peso_guia != 0)
            {
                t_peso_guia.Text = peso_guia.ToString("N2");

            }

            if (peso_bins != 0)
            {
                t_peso_envases.Text = peso_bins.ToString("N2");

            }

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_1er_peso.Text = fecha_hora1.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            if (fecha_hora2.Year != 1900)
            {
                t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            //t_conductor.Text = conductor;
            //t_conductor.Text = conductor;
            //peso_tara = 0;
            //peso_neto = 0;

            t_ref.Text = "S";

            //cbb_envase.SelectedIndex = id_envase;
            t_cantidad_envases.Text = cant_envases.ToString();
            t_observacion.Text = obs;

            btn_graba_bruto.Enabled = false;
            btn_graba_neto.Enabled = true;
            btn_buscar1.Visible = false;
            btn_buscar2.Visible = false;

            if (peso_tara != 0)
            {
                btn_imprimir.Enabled = true;

            }

            if (id_acceso > 0)
            {
                lnk_ver_documento.Enabled = true;
            }

            /////////////////////////////////////////////////////////////////
            //// Si el total de analisis es mayor que 0 no se puede modificar

            if (nCantAnalisisCalidad_Total > 0)
            {
                if (peso_neto > 0)
                {
                    btn_ok.Enabled = false;

                    tsb_agrega_oc.Enabled = false;
                    tsb_agrega_productor.Enabled = false;
                    tsb_define.Enabled = false;
                    tsb_eliminar.Enabled = false;

                    Grid1.Columns[5].ReadOnly = true;
                    Grid1.Columns[6].ReadOnly = true;

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nPesoProvisorio = 0;

            try
            {
                nPesoProvisorio = int.Parse(textBox1.Text);
            }
            catch
            {
                nPesoProvisorio = 0;
            }

            t_PesoBalanza.Text = nPesoProvisorio.ToString();

            btn_graba_bruto_Click(sender, e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nPesoProvisorio = 0;

            try
            {
                nPesoProvisorio = int.Parse(textBox1.Text);
            }
            catch
            {
                nPesoProvisorio = 0;
            }

            t_PesoBalanza.Text = nPesoProvisorio.ToString();

            btn_graba_neto_Click(sender, e);

        }

        private void btn_sin_porteria_Click(object sender, EventArgs e)
        {

            button3.Visible = true;
            t_patente.ReadOnly = false;
            t_num_guia.ReadOnly = false;
            t_conductor.ReadOnly = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            t_cardcode.Clear();
            t_cardname.Clear();

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

            }

        }

    }

}
