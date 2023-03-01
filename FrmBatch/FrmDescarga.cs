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

using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FrmBatch
{
    public partial class FrmDescarga : Form
    {
        public FrmDescarga()
        {
            InitializeComponent();
        }

        private void FrmDescarga_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////
            // Cargo los datos desde las Balanza

            Application.DoEvents();

            Thread.Sleep(2000);

            txt_resultado.Clear();

            try
            {
                carga_datos_indicador();

            }
            catch
            {

            }

            Application.DoEvents();

            Thread.Sleep(2000);

            txt_resultado1.Clear();

            ////////////////////////////////////////////
            // Genero los consumos de las OF disponibles

            try
            {
                Relaciona_Pesos_con_Lotes("SILOP001");
            }
            catch
            {

            }

            Application.DoEvents();

            Thread.Sleep(2000);

            txt_resultado1.Clear();

            ////////////////////////////////////////////
            // Genero los consumos de las OF disponibles

            try
            {
                Relaciona_Pesos_con_Lotes("SILOP002");
            }
            catch
            {

            }

            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////
            // Cargo los datos desde las Balanza

            txt_resultado.Clear();

            try
            {
                carga_datos_indicador();

            }
            catch
            {

            }

        }


        protected void carga_datos_indicador()
        {

            int n_Ultimo_Id_Balanza, n_Ultimo_Id_BD, n_Ultimo_Id_BD_Neg;

            n_Ultimo_Id_Balanza = 0;
            n_Ultimo_Id_BD = 0;
            n_Ultimo_Id_BD_Neg = 0;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_OBATCH_UltimoRegistro();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                n_Ultimo_Id_BD = int.Parse(dTable.Rows[0]["DocNum"].ToString());
            }
            catch
            {
                n_Ultimo_Id_BD = 0;
            }

            try
            {
                n_Ultimo_Id_BD_Neg = int.Parse(dTable.Rows[0]["DocNum_N"].ToString());
            }
            catch
            {
                n_Ultimo_Id_BD_Neg = 0;
            }

            TcpClient client;
            NetworkStream networkStream;
            System.IO.StreamReader streamReader;
            System.IO.StreamWriter streamWriter;
            string outputString;

            client = new TcpClient("172.30.128.107", 10001);
            client.ReceiveTimeout = 5000;
            networkStream = client.GetStream();
            streamReader = new System.IO.StreamReader(networkStream);
            streamWriter = new System.IO.StreamWriter(networkStream);

            string[] grilla;
            grilla = new string[8];

            streamWriter.WriteLine("DB.DATA.2#0");     //Ask for equipment identification
            streamWriter.Flush();

            string[,] d_arrBalanza = new string[2500, 5];
            string cBalanza;
            int nBalanza, registro_rnd;
           

            Random rnd = new Random();

            registro_rnd = 0;

            nBalanza = 0;

            try
            {
                while ((outputString = streamReader.ReadLine()) != null)
                {

                    System.Threading.Thread.Sleep(1);

                    cBalanza = "";

                    try
                    {
                        cBalanza = outputString;
                    }
                    catch
                    {
                        cBalanza = "";
                    }

                    if (cBalanza.IndexOf("|") > 0)
                    {
                        if (cBalanza != "")
                        {
                            registro_rnd = rnd.Next(10000, 99999);

                            d_arrBalanza[nBalanza, 0] = nBalanza.ToString();
                            d_arrBalanza[nBalanza, 1] = cBalanza;
                            d_arrBalanza[nBalanza, 2] = registro_rnd.ToString();

                            nBalanza += 1;

                            txt_resultado.Text = "Registros # " + nBalanza.ToString();
                            Application.DoEvents();

                        }

                    }


                }

            }
            catch
            {

            }

            /////////////////////////////////////////
            // se borran los datos desde el indicador

            try
            {
                //streamWriter.WriteLine("DB.CLEAR.2#0");     //Ask for equipment identification
                //streamWriter.Flush();
            }
            catch
            {

            }

            try
            {
                //streamWriter.Close();
            }
            catch
            {

            }

            /////////////////////////////////////////
            // proceso de grabado

            txt_resultado.Clear();
            int nCantidad_RegistrosCargados;

            nCantidad_RegistrosCargados = 0;

            if (nBalanza > 0)
            {

                int nPipe, nPipeAnterior, nIdBalanza;
                double nPesoBalanza;

                string cId, cValor, cFecha;
                string cFechaBalanza, cHoraBalanza, mensaje;

                for (int i = 0; i <= nBalanza - 1; i++)
                {
                    registro_rnd = 0;

                    try
                    {
                        cBalanza = d_arrBalanza[i, 1];
                    }
                    catch
                    {
                        cBalanza = "";
                    }

                    try
                    {
                        registro_rnd = int.Parse(d_arrBalanza[i, 2]);
                    }
                    catch
                    {
                        registro_rnd = 0;
                    }

                    if (cBalanza != "")
                    {
                        //////////////////////////////////////
                        // Ciclo de extraccion

                        nPipe = 0;
                        nPipeAnterior = 0;

                        cId = "";
                        cValor = "";
                        cFecha = "";

                        for (int x = 0; x <= cBalanza.Length - 1; x++)
                        {
                            if (cBalanza.Substring(x, 1) == "|")
                            {

                                //////////////////////
                                // Id - Linea
                                if (nPipe == 0)
                                {
                                    cId = cBalanza.Substring(nPipeAnterior, x);
                                }

                                //////////////////////
                                // Valor
                                if (nPipe == 1)
                                {
                                    try
                                    {
                                        cValor = cBalanza.Substring(nPipeAnterior + 1, 6);
                                    }
                                    catch
                                    {
                                        cValor = "-2";
                                    }

                                    try
                                    {
                                        cFecha = cBalanza.Substring(x + 1, cBalanza.Length - (x + 1));
                                    }
                                    catch
                                    {
                                        cFecha = "";
                                    }

                                    break;

                                }

                                nPipe += 1;
                                nPipeAnterior = x;

                            }

                        }

                        nIdBalanza = 0;
                        nPesoBalanza = 0;
                        cFechaBalanza = "";
                        cHoraBalanza = "";

                        if (cId != "")
                        {
                            try
                            {
                                nIdBalanza = int.Parse(cId);
                            }
                            catch
                            {
                                nIdBalanza = -1;
                            }

                            try
                            {
                                nPesoBalanza = double.Parse(cValor);
                            }
                            catch
                            {
                                nPesoBalanza = -1;
                            }

                            if (nPesoBalanza > 100)
                            {
                                nPesoBalanza = nPesoBalanza / 1000;
                            }

                            try
                            {
                                cFechaBalanza = cFecha.Substring(4, 4) + cFecha.Substring(0, 2) + cFecha.Substring(2, 2);
                            }
                            catch
                            {
                                cFechaBalanza = "";
                            }

                            try
                            {
                                cHoraBalanza = cFecha.Substring(9, 2) + cFecha.Substring(11, 2);
                            }
                            catch
                            {
                                cHoraBalanza = "";
                            }

                            if (nIdBalanza < 0)
                            {
                                //nIdBalanza = nIdBalanza * -1;
                            }

                            if (nIdBalanza != 0)
                            {

                                n_Ultimo_Id_Balanza = nIdBalanza;

                                try
                                {
                                    mensaje = clsProduccion.SAPB1_OBATCH(0, nIdBalanza, cFechaBalanza, cHoraBalanza, nPesoBalanza, registro_rnd, 0);
                                    nCantidad_RegistrosCargados += 1;

                                    txt_resultado.Text = "Registros # " + nIdBalanza.ToString();
                                    Application.DoEvents();

                                }
                                catch
                                {

                                }

                            }

                        }

                    }

                }

                ///////////////////////////////////////
                // Valido Que la grabación fue completa

                int nDocEntry_BD;

                for (int i2 = 0; i2 <= nBalanza - 1; i2++)
                {
                    try
                    {
                        cBalanza = d_arrBalanza[i2, 1];
                    }
                    catch
                    {
                        cBalanza = "";
                    }

                    try
                    {
                        registro_rnd = int.Parse(d_arrBalanza[i2, 2]);
                    }
                    catch
                    {
                        registro_rnd = 0;
                    }

                    if (cBalanza != "")
                    {
                        //////////////////////////////////////
                        // Ciclo de extraccion

                        nPipe = 0;
                        nPipeAnterior = 0;

                        cId = "";
                        cValor = "";
                        cFecha = "";

                        for (int x = 0; x <= cBalanza.Length - 1; x++)
                        {
                            if (cBalanza.Substring(x, 1) == "|")
                            {

                                //////////////////////
                                // Id - Linea
                                if (nPipe == 0)
                                {
                                    cId = cBalanza.Substring(nPipeAnterior, x);
                                }

                                //////////////////////
                                // Valor
                                if (nPipe == 1)
                                {
                                    cValor = cBalanza.Substring(nPipeAnterior + 1, 6);
                                    cFecha = cBalanza.Substring(x + 1, cBalanza.Length - (x + 1));
                                    break;

                                }

                                nPipe += 1;
                                nPipeAnterior = x;

                            }

                        }

                        nIdBalanza = 0;
                        nPesoBalanza = 0;
                        cFechaBalanza = "";
                        cHoraBalanza = "";

                        if (cId != "")
                        {
                            try
                            {
                                nIdBalanza = int.Parse(cId);
                            }
                            catch
                            {
                                nIdBalanza = -1;
                            }

                            try
                            {
                                nPesoBalanza = double.Parse(cValor);
                            }
                            catch
                            {
                                nPesoBalanza = -1;
                            }

                            try
                            {
                                cFechaBalanza = cFecha.Substring(4, 4) + cFecha.Substring(0, 2) + cFecha.Substring(2, 2);
                            }
                            catch
                            {
                                cFechaBalanza = "";
                            }

                            try
                            {
                                cHoraBalanza = cFecha.Substring(9, 2) + cFecha.Substring(11, 2);
                            }
                            catch
                            {
                                cHoraBalanza = "";
                            }

                            if (nIdBalanza > 0)
                            {

                                clsProduccion objproducto1 = new clsProduccion();
                                objproducto1.cls_Consulta_OBATCH_x_Cadena(0, nIdBalanza, cFechaBalanza, cHoraBalanza, nPesoBalanza, registro_rnd);

                                DataTable dTable1 = new DataTable();
                                dTable1 = objproducto1.cResultado;

                                nDocEntry_BD = 0;

                                try
                                {
                                    nDocEntry_BD = int.Parse(dTable1.Rows[0]["DocEntry"].ToString());
                                }
                                catch
                                {
                                    nDocEntry_BD = 0;
                                }

                                if (nDocEntry_BD == 0)
                                {
                                    ///////////////////////////////////
                                    // No habia grabado el registro asi 
                                    // que lo grabo de nuevo

                                    try
                                    {
                                        mensaje = clsProduccion.SAPB1_OBATCH(0, nIdBalanza, cFechaBalanza, cHoraBalanza, nPesoBalanza, registro_rnd, 0);
                                    }
                                    catch
                                    {

                                    }

                                }

                            }

                        }

                    }

                }

            }

            /////////////////////////////////////////
            // se borran los datos desde el indicador

            if (n_Ultimo_Id_Balanza>0)
            {
                if (n_Ultimo_Id_Balanza == n_Ultimo_Id_BD)
                {
                    try
                    {
                        streamWriter.WriteLine("DB.CLEAR.2#0");     //Ask for equipment identification
                        streamWriter.Flush();
                    }
                    catch
                    {

                    }

                }

            }
            else
            {
                if (n_Ultimo_Id_Balanza == n_Ultimo_Id_BD_Neg)
                {
                    try
                    {
                        streamWriter.WriteLine("DB.CLEAR.2#0");     //Ask for equipment identification
                        streamWriter.Flush();
                    }
                    catch
                    {

                    }

                }

            }


            try
            {
                streamWriter.Close();
            }
            catch
            {

            }

            pbox_descagar.Visible = true;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_resultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_resultado1.Clear();

            ////////////////////////////////////////////
            // Genero los consumos de las OF disponibles

            try
            {
                Relaciona_Pesos_con_Lotes("SILOP001");
            }
            catch
            {

            }

        }

        protected void Relaciona_Pesos_con_Lotes(string cWhsCode)
        {

            string cDocDate;

            DateTime dFecha;

            try
            {
                dFecha = DateTime.Today;
            }
            catch
            {
                dFecha = DateTime.Parse("01/01/1900");
            }

            cDocDate = dFecha.ToString("yyyyMMdd");

            string UsuarioSap, ClaveSap;

            try
            {
                UsuarioSap = ConfigurationManager.AppSettings.Get("UsuarioManager");
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = ConfigurationManager.AppSettings.Get("ClaveManager");
            }
            catch
            {
                ClaveSap = "";
            }

            int nDocEntry, nNumOF, nSalidaMercaderiaEntry;
            int nLineNum;

            double nPeso, nPeso_a_Consumir;
            double nStockLote, nPeso_Meta, nQuantity_Planificada;
            double nQuantity_Consumida, nQuantity_Pendiente;

            string cWareHouse, cNoLote, cAbsEntry;
            string mensaje, cCardCode_Productor, cCardName_Productor;
            string cCardCode_Cliente, cCardName_Cliente;
            string mensaje_error;

            int nCargaBatch_RegistrosActualizados;

            nCargaBatch_RegistrosActualizados = 0;

            clsProduccion objproducto = new clsProduccion();
            objproducto.cls_Consulta_OBATCH_Pendientes();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

                nDocEntry = 0;
                nPeso = 0;
                nNumOF = 0;

                try
                {
                    nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                }
                catch
                {
                    nDocEntry = 0;
                }

                try
                {
                    nPeso = double.Parse(dTable.Rows[i]["U_Peso"].ToString());
                }
                catch
                {
                    nPeso = 0;
                }

                if ((nDocEntry > 0) && (nPeso > 1))
                {

                    while (nPeso > 1)
                    {

                        nPeso_a_Consumir = 0;
                        nStockLote = 0;

                        clsProduccion objproducto1 = new clsProduccion();
                        objproducto1.cls_Consulta_OBATCH_Lotes_Pendientes(cWhsCode);

                        DataTable dTable1 = new DataTable();
                        dTable1 = objproducto1.cResultado;

                        try
                        {
                            cAbsEntry = dTable1.Rows[0]["AbsEntry"].ToString();
                        }
                        catch
                        {
                            cAbsEntry = "";
                        }

                        try
                        {
                            cNoLote = dTable1.Rows[0]["DistNumber"].ToString();
                        }
                        catch
                        {
                            cNoLote = "";
                        }

                        try
                        {
                            nStockLote = double.Parse(dTable1.Rows[0]["Quantity"].ToString());
                        }
                        catch
                        {
                            nStockLote = 0;
                        }

                        try
                        {
                            cCardCode_Productor = dTable1.Rows[0]["MnfSerial"].ToString();
                        }
                        catch
                        {
                            cCardCode_Productor = "";
                        }

                        try
                        {
                            cCardName_Productor = dTable1.Rows[0]["U_NOMBPROD"].ToString();
                        }
                        catch
                        {
                            cCardName_Productor = "";
                        }

                        try
                        {
                            cCardCode_Cliente = dTable1.Rows[0]["LotNumber"].ToString();
                        }
                        catch
                        {
                            cCardCode_Cliente = "";
                        }

                        try
                        {
                            cCardName_Cliente = dTable1.Rows[0]["U_NOMBCLI"].ToString();
                        }
                        catch
                        {
                            cCardName_Cliente = "";
                        }

                        nPeso_a_Consumir = 0;

                        if (nPeso <= nStockLote)
                        {
                            nPeso_a_Consumir = nPeso;
                        }
                        else
                        {
                            nPeso_a_Consumir = nStockLote;
                        }

                        nPeso -= nPeso_a_Consumir;

                        if (nPeso < 0)
                        {
                            nPeso = 0;
                        }

                        nPeso_Meta = nPeso_a_Consumir;

                        while (nPeso_Meta > 0)
                        {
                            clsProduccion objproducto2 = new clsProduccion();
                            objproducto2.cls_Consulta_OBATCH_OF_Pendientes(cWhsCode);

                            DataTable dTable2 = new DataTable();
                            dTable2 = objproducto2.cResultado;

                            try
                            {
                                nNumOF = int.Parse(dTable2.Rows[0]["DocNum"].ToString());
                            }
                            catch
                            {
                                nNumOF = 0;
                            }

                            try
                            {
                                nLineNum = int.Parse(dTable2.Rows[0]["LineNum"].ToString());
                            }
                            catch
                            {
                                nLineNum = -1;
                            }

                            try
                            {
                                nQuantity_Planificada = double.Parse(dTable2.Rows[0]["PlannedQty"].ToString());
                            }
                            catch
                            {
                                nQuantity_Planificada = 0;
                            }

                            try
                            {
                                nQuantity_Consumida = double.Parse(dTable2.Rows[0]["IssuedQty"].ToString());
                            }
                            catch
                            {
                                nQuantity_Consumida = 0;
                            }

                            cWareHouse = "";

                            try
                            {
                                cWareHouse = dTable2.Rows[0]["wareHouse"].ToString();
                            }
                            catch
                            {
                                cWareHouse = "";
                            }

                            nQuantity_Pendiente = nQuantity_Planificada - nQuantity_Consumida;

                            if (nPeso_Meta <= nQuantity_Pendiente)
                            {
                                nPeso_a_Consumir = nPeso_Meta;
                            }
                            else
                            {
                                nPeso_a_Consumir = nQuantity_Pendiente;
                            }

                            nPeso_Meta -= nPeso_a_Consumir;

                            ////////////////////////////////////////
                            // Realizo el consumo en la OF

                            ///////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////

                            nSalidaMercaderiaEntry = 0;
                            mensaje = "";

                            if (nPeso_a_Consumir > 0)
                            {
                                try
                                {
                                    //mensaje = clsOrdenFabricacion.Salida_Mercaderia_CO(cDocDate, nNumOF, nLineNum, nPeso_a_Consumir, cWareHouse, 1, cNoLote, cCardCode_Productor, cCardName_Productor, cCardCode_Cliente, cCardName_Cliente, UsuarioSap, ClaveSap);
                                    nCargaBatch_RegistrosActualizados += 1;
                                }
                                catch
                                {
                                    //clsCorreo oMail = new clsCorreo("dgarcia@huertosdelvalle.cl", "Error Conexion balanza batch", "Lamaplicacion nperdio conectividad", 1, "");
                                    mensaje = "Error de Conexion";
                                }

                            }

                            nSalidaMercaderiaEntry = -1;

                            try
                            {
                                nSalidaMercaderiaEntry = int.Parse(mensaje);
                            }
                            catch
                            {
                                nSalidaMercaderiaEntry = -1;

                                mensaje_error = "Se ha generado un error en el consumo batch número: " + nDocEntry + ", ";
                                mensaje_error += "aplicaddo a la orden de fabricación " + nNumOF + ". ";
                                mensaje_error += "error vinculado: " + mensaje;

                                return;

                                //clsCorreo oMail = new clsCorreo("dgarcia@huertosdelvalle.cl", "Error en Emisión de Producción (Consumo) balanza batch", mensaje_error, 1, "");

                            }

                            ////////////////////////////////////////
                            // Marco el registro de Peso 
                            // como Aplicado

                            if (nSalidaMercaderiaEntry > 0)
                            {

                                try
                                {
                                    mensaje = clsProduccion.SAPB1_OBATCH(nDocEntry, 1, "", "", 0, 0, nSalidaMercaderiaEntry);
                                }
                                catch
                                {

                                }

                            }

                            txt_resultado1.Text = nNumOF.ToString() + " - " + nSalidaMercaderiaEntry.ToString();
                            Application.DoEvents();

                        }

                    }

                }


            }

            txt_resultado1.Text = nCargaBatch_RegistrosActualizados.ToString();
            pbox_silo1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_resultado1.Clear();

            ////////////////////////////////////////////
            // Genero los consumos de las OF disponibles

            try
            {
                Relaciona_Pesos_con_Lotes("SILOP002");
            }
            catch
            {

            }

        }
    }
}
