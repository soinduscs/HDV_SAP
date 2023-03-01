using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class cldRecepcion : GestorSql
    {

        public int DocEntry { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int NumGuia { get; set; }
        public string Patente { get; set; }
        public string conductor { get; set; }
        public string FechaIngreso { get; set; }
        public DateTime FechaIngreso_x { get; set; }
        public float PesoNeto { get; set; }
        public string Obs { get; set; }
        public float PesoGuia { get; set; }
        public string WareHouse { get; set; }
        public double PrecioxUnidad { get; set; }
        public int PurchaseOrder { get; set; }
        public int BaseLineNum { get; set; }
        public int Lote { get; set; }
        public int CantidadBultos { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreCliente { get; set; }
        public string[,] arrDetalle { get; set; }
        public string[,] arrDetalle1 { get; set; }
        public string CodeCliente { get; set; }
        public string TipoLote { get; set; }
        public int UserSign { get; set; }
        public int IdRomana { get; set; }
        public int LineId { get; set; }
        public float Cantidad { get; set; }
        public int BaseLine { get; set; }
        public string[,] arrDetalleBins  { get; set; }
        public string WhsCode { get; set; }
        public string ObjectRef { get; set; }
        public float CantidadVacios { get; set; }
        public string UsuarioSap { get; set; }
        public string ClaveSap { get; set; }
        public int DocType { get; set; }
        public int Accion { get; set; }
        public string FromWhsCode { get; set; }
        public string ToWhsCode { get; set; }
        public int BinAbsEntry { get; set; }
        public string Localidad { get; set; }
        public string Variedad { get; set; }
        public string Presentacion { get; set; }
        public string Comments { get; set; }
        public int DocEntry_Ref { get; set; }
        public int LineNum_Ref { get; set; }
        public string Prefijo_TipoDocumento { get; set; }
        public string Codigo_CSG { get; set; }

        public string TipoCosecha { get; set; }
        public string Num_OrdenVenta { get; set; }

        /// <summary> 
        /// ////////////////////////////////////////
        /// </summary>

        public static SAPbobsCOM.Company sbo_HDV_P03;
        public static int accesoMenuPrincipal;
        public static SAPbobsCOM.Recordset oRecordset;

        public cldRecepcion()
        {

        }

        public cldRecepcion(string d_CardCode, string d_CardName, string d_ItemCode, int d_NumGuia, string d_Patente, 
            string d_conductor,string d_FechaIngreso, float d_PesoNeto, string d_Obs, float d_PesoGuia, string d_WareHouse, 
            double d_PrecioxUnidad, int d_PurchaseOrder, int d_BaseLineNum , int d_Lote , int d_CantidadBultos, 
            string d_NombreProveedor , string d_NombreCliente, string d_TipoLote, string[,] d_arrDetalleBins)

        {
            this.CardCode = d_CardCode;
            this.CardName = d_CardName;
            this.ItemCode = d_ItemCode;
            this.NumGuia = d_NumGuia;
            this.Patente = d_Patente;
            this.conductor = d_conductor;           
            this.FechaIngreso = d_FechaIngreso;
            this.PesoNeto = d_PesoNeto;
            this.Obs = d_Obs;
            this.PesoGuia = d_PesoGuia;
            this.WareHouse = d_WareHouse;
            this.PrecioxUnidad = d_PrecioxUnidad;
            this.PurchaseOrder = d_PurchaseOrder;
            this.BaseLineNum = d_BaseLineNum;
            this.Lote = d_Lote;
            this.CantidadBultos = d_CantidadBultos;
            this.NombreProveedor = d_NombreProveedor;
            this.NombreCliente = d_NombreCliente;
            this.TipoLote = d_TipoLote;
            this.arrDetalleBins = d_arrDetalleBins;

        }

        public string Entrada_Mercaderia(cldRecepcion parRecepcion)
        {
            string NewObjectKey;
            int lRetCode;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }
            
            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!
               
                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);

            // datos de cabecera

            EntradaMercancia.CardCode = parRecepcion.CardCode;
            EntradaMercancia.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.DocDueDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.NumAtCard = null;
            EntradaMercancia.FolioPrefixString = parRecepcion.Prefijo_TipoDocumento; // "52"
            EntradaMercancia.FolioNumber = parRecepcion.NumGuia;
            EntradaMercancia.UserFields.Fields.Item("U_PESOGUIA").Value = parRecepcion.PesoGuia;
            EntradaMercancia.UserFields.Fields.Item("U_DTE_Patente").Value = parRecepcion.Patente;
            EntradaMercancia.UserFields.Fields.Item("U_DTE_NombreChofer").Value = parRecepcion.conductor;

            // datos de detalle

            EntradaMercancia.Lines.ItemCode = parRecepcion.ItemCode;
            EntradaMercancia.Lines.Quantity = parRecepcion.PesoNeto;
            EntradaMercancia.Lines.WarehouseCode = parRecepcion.WareHouse;

            // A partir del 30 de Septiembre del 2018
            // Todas las compras ingresan a costo 0
            //EntradaMercancia.Lines.UnitPrice = 0; // parRecepcion.PrecioxUnidad;

            EntradaMercancia.Lines.BaseType = 22;
            EntradaMercancia.Lines.BaseEntry = parRecepcion.PurchaseOrder;
            EntradaMercancia.Lines.BaseLine = parRecepcion.BaseLineNum;
            EntradaMercancia.Lines.UserFields.Fields.Item("U_Codigo_CSG").Value = parRecepcion.Codigo_CSG;

            // datos de lote

            EntradaMercancia.Lines.BatchNumbers.BatchNumber = parRecepcion.Lote.ToString();
            EntradaMercancia.Lines.BatchNumbers.Quantity = parRecepcion.PesoNeto; 
            EntradaMercancia.Lines.BatchNumbers.Notes = parRecepcion.Obs;
            EntradaMercancia.Lines.BatchNumbers.InternalSerialNumber = parRecepcion.CodeCliente;
            EntradaMercancia.Lines.BatchNumbers.ManufacturerSerialNumber = parRecepcion.CardCode;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = parRecepcion.TipoLote;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = parRecepcion.CantidadBultos.ToString();
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = parRecepcion.CardName;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = parRecepcion.NombreCliente;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_VARIEDAD").Value = parRecepcion.Variedad;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_Codigo_CSG").Value = parRecepcion.Codigo_CSG;
            EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_Tipo_Cosecha").Value = parRecepcion.TipoCosecha;

            //EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_PRESENTACION").Value = parRecepcion.Presentacion;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (EntradaMercancia.Add() == 0)
                {
                    errCode = 0;

                    NewObjectKey = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;


        }

        public string Entrada_Mercaderia_ActualizaNumGuia(cldRecepcion parRecepcion)
        {
            string NewObjectKey;
            int lRetCode;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }

            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);



            // datos de cabecera
            EntradaMercancia.GetByKey(parRecepcion.DocEntry);
            EntradaMercancia.FolioNumber = parRecepcion.NumGuia;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (EntradaMercancia.Update() == 0)
                {
                    errCode = 0;

                    NewObjectKey = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;

        }


        public string Devolucion_Mercaderia(cldRecepcion parRecepcion)
        {

            string NewObjectKey;
            int lRetCode;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }

            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            SAPbobsCOM.Documents DevolucionMercancia;
            DevolucionMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseReturns);

            // datos de cabecera


            DevolucionMercancia.CardCode = parRecepcion.CardCode;
            DevolucionMercancia.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            DevolucionMercancia.DocDueDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            DevolucionMercancia.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            DevolucionMercancia.NumAtCard = null;
            DevolucionMercancia.FolioPrefixString = "";
            DevolucionMercancia.FolioNumber = parRecepcion.NumGuia;
            DevolucionMercancia.UserFields.Fields.Item("U_PESOGUIA").Value = parRecepcion.PesoGuia;
            DevolucionMercancia.UserFields.Fields.Item("U_DTE_Patente").Value = parRecepcion.Patente;
            DevolucionMercancia.UserFields.Fields.Item("U_DTE_NombreChofer").Value = parRecepcion.conductor;
            DevolucionMercancia.Comments = parRecepcion.Comments;

            // datos de detalle

            DevolucionMercancia.Lines.ItemCode = parRecepcion.ItemCode;
            DevolucionMercancia.Lines.Quantity = parRecepcion.PesoNeto;
            DevolucionMercancia.Lines.WarehouseCode = parRecepcion.WareHouse;

            // A partir del 30 de Septiembre del 2018
            // Todas las compras ingresan a costo 0
            //EntradaMercancia.Lines.UnitPrice = 0; // parRecepcion.PrecioxUnidad;

            //DevolucionMercancia.Lines.BaseType = 22;
            //DevolucionMercancia.Lines.BaseEntry = parRecepcion.PurchaseOrder;
            //DevolucionMercancia.Lines.BaseLine = parRecepcion.BaseLineNum;

            // datos de lote

            DevolucionMercancia.Lines.BatchNumbers.BatchNumber = parRecepcion.Lote.ToString();
            DevolucionMercancia.Lines.BatchNumbers.Quantity = parRecepcion.PesoNeto;
            DevolucionMercancia.Lines.BatchNumbers.Notes = parRecepcion.Obs;
            DevolucionMercancia.Lines.BatchNumbers.InternalSerialNumber = parRecepcion.CodeCliente;
            DevolucionMercancia.Lines.BatchNumbers.ManufacturerSerialNumber = parRecepcion.CardCode;
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = parRecepcion.TipoLote;
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = parRecepcion.CantidadBultos.ToString();
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = parRecepcion.CardName;
            DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = parRecepcion.NombreCliente;
            //DevolucionMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_VARIEDAD").Value = parRecepcion.Variedad;
            //EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_PRESENTACION").Value = parRecepcion.Presentacion;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (DevolucionMercancia.Add() == 0)
                {
                    errCode = 0;

                    NewObjectKey = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;

        }

        public string Devolucion_Mercaderia_Cerrar(cldRecepcion parRecepcion)
        {

            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");
            sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Documents DevolucionMercancia;
            DevolucionMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseReturns);

            // datos de cabecera
            DevolucionMercancia.GetByKey(parRecepcion.DocEntry);

            DevolucionMercancia.Lines.SetCurrentLine(0);
            DevolucionMercancia.Lines.LineStatus = SAPbobsCOM.BoStatus.bost_Close;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (DevolucionMercancia.Update() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;       


        }


        public string Entrada_Mercaderia_Insumos(cldRecepcion parRecepcion)
        {
            string NewObjectKey;
            int lRetCode;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }

            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);

            // datos de cabecera

            EntradaMercancia.CardCode = parRecepcion.CardCode;
            EntradaMercancia.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.DocDueDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.NumAtCard = null;
            EntradaMercancia.FolioPrefixString = "52";
            EntradaMercancia.FolioNumber = parRecepcion.NumGuia;
            EntradaMercancia.UserFields.Fields.Item("U_PESOGUIA").Value = "";
            EntradaMercancia.UserFields.Fields.Item("U_DTE_Patente").Value = "";
            EntradaMercancia.UserFields.Fields.Item("U_DTE_NombreChofer").Value = "";

            // datos de detalle

            EntradaMercancia.Lines.ItemCode = parRecepcion.ItemCode;
            EntradaMercancia.Lines.Quantity = Convert.ToDouble(parRecepcion.arrDetalle[3, 0]); 
            EntradaMercancia.Lines.WarehouseCode = parRecepcion.WareHouse;

            // A partir del 30 de Septiembre del 2018
            // Todas las compras ingresan a costo 0
            //EntradaMercancia.Lines.UnitPrice = 0; // parRecepcion.PrecioxUnidad;

            EntradaMercancia.Lines.BaseType = 22;
            EntradaMercancia.Lines.BaseEntry = parRecepcion.PurchaseOrder;
            EntradaMercancia.Lines.BaseLine = parRecepcion.BaseLineNum;

            // datos de lote

            int nLineLote;
            string cItemCode_D, cLote, cLoteProveedor;
            double nQuantity_D;

            //string , cItemName_D, cBodega_D;
            //string cIssueMthd_D;
            //double nCantidadBase_D, nCantidadRequerida_D, nDisponible_D;

            nLineLote = 0;

            for (int x = 0; x <= 999; x++)
            {

                try
                {
                    cItemCode_D = parRecepcion.arrDetalle1[1, x];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cLote = parRecepcion.arrDetalle1[2, x];
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(parRecepcion.arrDetalle1[3, x]);
                }
                catch
                {
                    nQuantity_D = -1;
                }

                try
                {
                    cLoteProveedor = parRecepcion.arrDetalle1[4, x];
                }
                catch
                {
                    cLoteProveedor = "";
                }

                if (nQuantity_D > 0)
                {
                    if (nLineLote > 0)
                    {
                        //StockTransf.Lines.Add();
                        EntradaMercancia.Lines.BatchNumbers.Add();
                    }

                    EntradaMercancia.Lines.BatchNumbers.BatchNumber = cLote;
                    EntradaMercancia.Lines.BatchNumbers.Quantity = nQuantity_D;
                    EntradaMercancia.Lines.BatchNumbers.Notes = parRecepcion.Obs;
                    EntradaMercancia.Lines.BatchNumbers.InternalSerialNumber = parRecepcion.CodeCliente;
                    EntradaMercancia.Lines.BatchNumbers.ManufacturerSerialNumber = parRecepcion.CardCode;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "6";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = "0";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = parRecepcion.CardName;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = parRecepcion.NombreCliente;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_VARIEDAD").Value = "";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_FolioPallet").Value = cLoteProveedor;

                    nLineLote += 1;

                }

            }

            
            //EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_PRESENTACION").Value = parRecepcion.Presentacion;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (EntradaMercancia.Add() == 0)
                {
                    errCode = 0;

                    NewObjectKey = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;

        }

        public string Entrada_Mercaderia_Bodegaje(cldRecepcion parRecepcion)
        {
            string NewObjectKey;
            int lRetCode;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }

            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);

            // datos de cabecera

            EntradaMercancia.CardCode = parRecepcion.CardCode;
            EntradaMercancia.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.DocDueDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.NumAtCard = null;
            EntradaMercancia.FolioPrefixString = "52";
            EntradaMercancia.FolioNumber = parRecepcion.NumGuia;
            EntradaMercancia.UserFields.Fields.Item("U_PESOGUIA").Value = "";
            EntradaMercancia.UserFields.Fields.Item("U_DTE_Patente").Value = "";
            EntradaMercancia.UserFields.Fields.Item("U_DTE_NombreChofer").Value = "";

            // datos de detalle

            EntradaMercancia.Lines.ItemCode = parRecepcion.ItemCode;
            EntradaMercancia.Lines.Quantity = Convert.ToDouble(parRecepcion.arrDetalle[3, 0]);
            EntradaMercancia.Lines.WarehouseCode = parRecepcion.WareHouse;

            // A partir del 30 de Septiembre del 2018
            // Todas las compras ingresan a costo 0
            //EntradaMercancia.Lines.UnitPrice = 0; // parRecepcion.PrecioxUnidad;

            EntradaMercancia.Lines.BaseType = 22;
            EntradaMercancia.Lines.BaseEntry = parRecepcion.PurchaseOrder;
            EntradaMercancia.Lines.BaseLine = parRecepcion.BaseLineNum;
            EntradaMercancia.Lines.UserFields.Fields.Item("U_Codigo_CSG").Value = parRecepcion.Num_OrdenVenta;

            // datos de lote

            int nLineLote;
            string cItemCode_D, cLote, cLoteProveedor;
            double nQuantity_D;

            //string , cItemName_D, cBodega_D;
            //string cIssueMthd_D;
            //double nCantidadBase_D, nCantidadRequerida_D, nDisponible_D;

            nLineLote = 0;

            for (int x = 0; x <= 999; x++)
            {

                try
                {
                    cItemCode_D = parRecepcion.arrDetalle1[1, x];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cLote = parRecepcion.arrDetalle1[2, x];
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(parRecepcion.arrDetalle1[3, x]);
                }
                catch
                {
                    nQuantity_D = -1;
                }

                try
                {
                    cLoteProveedor = parRecepcion.arrDetalle1[4, x];
                }
                catch
                {
                    cLoteProveedor = "";
                }

                if (nQuantity_D > 0)
                {
                    if (nLineLote > 0)
                    {
                        //StockTransf.Lines.Add();
                        EntradaMercancia.Lines.BatchNumbers.Add();
                    }

                    EntradaMercancia.Lines.BatchNumbers.BatchNumber = cLote;
                    EntradaMercancia.Lines.BatchNumbers.Quantity = nQuantity_D;
                    EntradaMercancia.Lines.BatchNumbers.Notes = parRecepcion.Obs;
                    EntradaMercancia.Lines.BatchNumbers.InternalSerialNumber = parRecepcion.CodeCliente;
                    EntradaMercancia.Lines.BatchNumbers.ManufacturerSerialNumber = parRecepcion.CardCode;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "6";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = "0";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = parRecepcion.CardName;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = parRecepcion.NombreCliente;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_VARIEDAD").Value = "";
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_FolioPallet").Value = cLoteProveedor;

                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_Codigo_CSG").Value = parRecepcion.Num_OrdenVenta;
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_Tipo_Cosecha").Value = "Manual";

                    nLineLote += 1;

                }

            }


            //EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_PRESENTACION").Value = parRecepcion.Presentacion;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (EntradaMercancia.Add() == 0)
                {
                    errCode = 0;

                    NewObjectKey = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;

        }


        public string Stock_Transfer(cldRecepcion parRecepcion)
        {

            int lRetCode;
            int errCode;
            string errMsg;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;            

            lRetCode = -1;

            try
            {
                lRetCode = sbo_HDV_P03.Connect();
            }
            catch
            {
                lRetCode = -1;
            }

            if (lRetCode == 0)
            {
                ////////////////////////////
                // Conexion Exitosa 

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                errMsg = "Error de Conexión";
                return errMsg;

            }

            SAPbobsCOM.StockTransfer StockTransfer;
            StockTransfer = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oStockTransfer);
            
            // datos de cabecera

            StockTransfer.CardCode = parRecepcion.CardCode;
            StockTransfer.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            StockTransfer.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            StockTransfer.UserFields.Fields.Item("U_DTE_Patente").Value = parRecepcion.Patente;
            StockTransfer.UserFields.Fields.Item("U_DTE_NombreChofer").Value = parRecepcion.conductor;
            StockTransfer.Series = 27;

            // datos de detalle

            int nCantidadBins, nCantidadBinsVacios, nCantidadBins_t;
            int nCantRegBlancos;

            string cItemCodeBins, cFromWhsCode, cToWhsCode;
            string cLote;

            nCantRegBlancos = 0;

            for (int i = 0; i <= 19; i++)
            {

                if (nCantRegBlancos > 4)
                {
                    break;
                }

                try
                {
                    cItemCodeBins = parRecepcion.arrDetalleBins[1, i];

                }
                catch
                {
                    cItemCodeBins = "";
                }

                if (cItemCodeBins !="")
                {
                    try
                    {
                        nCantidadBins = int.Parse(parRecepcion.arrDetalleBins[2, i]);
                    }
                    catch
                    {
                        nCantidadBins = 0;
                    }

                    try
                    {
                        nCantidadBinsVacios = 0; int.Parse(parRecepcion.arrDetalleBins[5, i]);
                    }
                    catch
                    {
                        nCantidadBinsVacios = 0;
                    }

                    try
                    {
                        cFromWhsCode = parRecepcion.arrDetalleBins[3, i];
                    }
                    catch
                    {
                        cFromWhsCode = "";
                    }

                    try
                    {
                        cToWhsCode = parRecepcion.arrDetalleBins[4, i]; 
                    }
                    catch
                    {
                        cToWhsCode = "";
                    }

                    try
                    {
                        cLote = parRecepcion.arrDetalleBins[6, i];

                    }
                    catch
                    {
                        cLote = "";

                    }

                    //d_arrDetalleBins[1, i] = Grid2[1, z].Value.ToString(); // ItemCode 
                    //d_arrDetalleBins[2, i] = Grid2[2, z].Value.ToString(); //Cantidad
                    //d_arrDetalleBins[3, i] = Grid2[3, z].Value.ToString(); // Almacen  
                    //d_arrDetalleBins[4, i] = Grid2[4, z].Value.ToString(); // Almacen Destino

                    nCantidadBins_t = nCantidadBins + nCantidadBinsVacios;

                    if (nCantidadBins_t > 0)
                    {
                        if (i>0)
                        {
                            StockTransfer.Lines.Add();

                        }

                        StockTransfer.Lines.ItemCode = cItemCodeBins;
                        StockTransfer.Lines.Quantity = nCantidadBins_t;
                        StockTransfer.Lines.FromWarehouseCode = cFromWhsCode;
                        StockTransfer.Lines.WarehouseCode = cToWhsCode;
                        //StockTransfer.Lines.Price = 0.3;
                        //StockTransfer.Lines.UnitPrice = 0.3;
                        //StockTransfer.Lines.

                        if (cLote != "")
                        {
                            StockTransfer.Lines.BatchNumbers.BatchNumber = cLote;
                            StockTransfer.Lines.BatchNumbers.Quantity = nCantidadBins_t;
                            StockTransfer.Lines.BatchNumbers.Notes ="";

                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "7";
                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = nCantidadBins_t;
                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = "";
                            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = "";

                        }


                    }

                }
                else
                {
                    nCantRegBlancos += 1;
                }

            }
            
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (StockTransfer.Add() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;

        }

        public string SAPB1_Recepcion(cldRecepcion parRecepcion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECEPCION";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRecepcion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParRomanaEntry = new SqlParameter();
                ParRomanaEntry.ParameterName = "@RomanaEntry";
                ParRomanaEntry.SqlDbType = SqlDbType.Int;
                ParRomanaEntry.Value = parRecepcion.IdRomana;
                SqlComando.Parameters.Add(ParRomanaEntry);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@Localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = parRecepcion.Localidad.Length;
                ParLocalidad.Value = parRecepcion.Localidad;
                SqlComando.Parameters.Add(ParLocalidad);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@UserSign";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parRecepcion.UserSign;
                SqlComando.Parameters.Add(ParUsuario);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_Recepcion1(cldRecepcion parRecepcion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

           
            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECEPCION1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRecepcion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@LineId";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = parRecepcion.LineId;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParCardCode = new SqlParameter();
                ParCardCode.ParameterName = "@CardCode";
                ParCardCode.SqlDbType = SqlDbType.VarChar;
                ParCardCode.Size = parRecepcion.CardCode.Length;
                ParCardCode.Value = parRecepcion.CardCode;
                SqlComando.Parameters.Add(ParCardCode);

                SqlParameter ParCardName = new SqlParameter();
                ParCardName.ParameterName = "@CardName";
                ParCardName.SqlDbType = SqlDbType.VarChar;
                ParCardName.Size = parRecepcion.CardName.Length;
                ParCardName.Value = parRecepcion.CardName;
                SqlComando.Parameters.Add(ParCardName);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parRecepcion.ItemCode.Length;
                ParItemCode.Value = parRecepcion.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParItemName = new SqlParameter();
                ParItemName.ParameterName = "@ItemName";
                ParItemName.SqlDbType = SqlDbType.VarChar;
                ParItemName.Size = parRecepcion.ItemName.Length;
                ParItemName.Value = parRecepcion.ItemName;
                SqlComando.Parameters.Add(ParItemName);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = parRecepcion.Cantidad;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParBaseLine = new SqlParameter();
                ParBaseLine.ParameterName = "@BaseLine";
                ParBaseLine.SqlDbType = SqlDbType.Int;
                ParBaseLine.Value = parRecepcion.BaseLine;
                SqlComando.Parameters.Add(ParBaseLine);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@WhsCode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parRecepcion.WhsCode.Length;
                ParWhsCode.Value = parRecepcion.WhsCode;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter ParCardCodeClte = new SqlParameter();
                ParCardCodeClte.ParameterName = "@CardCodeClte";
                ParCardCodeClte.SqlDbType = SqlDbType.VarChar;
                ParCardCodeClte.Size = parRecepcion.CodeCliente.Length;
                ParCardCodeClte.Value = parRecepcion.CodeCliente;
                SqlComando.Parameters.Add(ParCardCodeClte);

                SqlParameter ParCardNameClte = new SqlParameter();
                ParCardNameClte.ParameterName = "@CardNameClte";
                ParCardNameClte.SqlDbType = SqlDbType.VarChar;
                ParCardNameClte.Size = parRecepcion.NombreCliente.Length;
                ParCardNameClte.Value = parRecepcion.NombreCliente;
                SqlComando.Parameters.Add(ParCardNameClte);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_Recepcion2(cldRecepcion parRecepcion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();


            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECEPCION2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRecepcion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@LineId";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = parRecepcion.LineId;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = parRecepcion.Cantidad;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParBaseLine = new SqlParameter();
                ParBaseLine.ParameterName = "@BaseLine";
                ParBaseLine.SqlDbType = SqlDbType.Int;
                ParBaseLine.Value = parRecepcion.BaseLine;
                SqlComando.Parameters.Add(ParBaseLine);

                SqlParameter ParObject = new SqlParameter();
                ParObject.ParameterName = "@Object";
                ParObject.SqlDbType = SqlDbType.VarChar;
                ParObject.Size = parRecepcion.ObjectRef.Length;
                ParObject.Value = parRecepcion.ObjectRef;
                SqlComando.Parameters.Add(ParObject);

                SqlParameter ParCantidadVacios = new SqlParameter();
                ParCantidadVacios.ParameterName = "@CantidadVacios";
                ParCantidadVacios.SqlDbType = SqlDbType.Int;
                ParCantidadVacios.Value = parRecepcion.CantidadVacios;
                SqlComando.Parameters.Add(ParCantidadVacios);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_RECEPCION3(cldRecepcion parRecepcion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();


            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECEPCION3";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRecepcion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParDocType = new SqlParameter();
                ParDocType.ParameterName = "@DocType";
                ParDocType.SqlDbType = SqlDbType.Int;
                ParDocType.Value = parRecepcion.DocType;
                SqlComando.Parameters.Add(ParDocType);
                
                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_RECEPCION9(cldRecepcion parRecepcion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();


            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECEPCION9";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRomanaEntry = new SqlParameter();
                ParRomanaEntry.ParameterName = "@RomanaEntry";
                ParRomanaEntry.SqlDbType = SqlDbType.Int;
                ParRomanaEntry.Value = parRecepcion.IdRomana;
                SqlComando.Parameters.Add(ParRomanaEntry);

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@TerminationReportEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRecepcion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@UserSign";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parRecepcion.UserSign;
                SqlComando.Parameters.Add(ParUsuario);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string CambiaStatus_Lote(cldRecepcion parLote)
        {
            string NewObjectKey;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parLote.UsuarioSap;
            sbo_HDV_P03.Password = parLote.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.BatchNumberDetailsService oLote;
            SAPbobsCOM.BatchNumberDetailParams oLoteParams;
            SAPbobsCOM.BatchNumberDetail oLoteDetail;

            oLote = (SAPbobsCOM.BatchNumberDetailsService)sbo_HDV_P03.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);
            oLoteDetail = (SAPbobsCOM.BatchNumberDetail)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetail);
            oLoteParams = (SAPbobsCOM.BatchNumberDetailParams)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);

            oLoteParams.DocEntry = parLote.Lote;
            oLoteDetail = oLote.Get(oLoteParams);

            if (parLote.Accion == 0)
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Released;
            }
            else
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Locked;
            }

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "";

            try
            {
                oLote.Update(oLoteDetail);
                errCode = 0;

                NewObjectKey = parLote.Lote.ToString();

            }
            catch (Exception)
            {
                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                NewObjectKey = errMsg;
            
            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return NewObjectKey;


        }

        public string Stock_Transfer_Ubicaciones_v2(cldRecepcion parRecepcion)
        {

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");
            sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer StockTransfer;
            StockTransfer = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oStockTransfer);

            //StockTransfer.CardCode = parRecepcion.CardCode;
            StockTransfer.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            StockTransfer.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            //StockTransfer.UserFields.Fields.Item("U_DTE_Patente").Value = "";
            //StockTransfer.UserFields.Fields.Item("U_DTE_NombreChofer").Value = "";
            StockTransfer.Series = 27;

            // datos de detalle

            StockTransfer.Lines.ItemCode = parRecepcion.ItemCode;
            StockTransfer.Lines.Quantity = parRecepcion.Cantidad;
            StockTransfer.Lines.FromWarehouseCode = parRecepcion.FromWhsCode;
            StockTransfer.Lines.WarehouseCode = parRecepcion.ToWhsCode;

            //if (parRecepcion.DocEntry_Ref > 0)
            //{
            //    StockTransfer.Lines.BaseType = SAPbobsCOM.InvBaseDocTypeEnum.InventoryTransferRequest;
            //    StockTransfer.Lines.BaseEntry = parRecepcion.DocEntry_Ref;
            //    StockTransfer.Lines.BaseLine = parRecepcion.LineNum_Ref;

            //}

            StockTransfer.Lines.BatchNumbers.BatchNumber = parRecepcion.Lote.ToString();
            StockTransfer.Lines.BatchNumbers.Quantity = parRecepcion.Cantidad;
            //StockTransfer.Lines.BatchNumbers.Notes = "";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = "2022";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "7";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = 1;
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = "";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = "";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_CALIBRE").Value = "";

            StockTransfer.Lines.BinAllocations.BinActionType = SAPbobsCOM.BinActionTypeEnum.batToWarehouse;
            StockTransfer.Lines.BinAllocations.BinAbsEntry = parRecepcion.BinAbsEntry;
            StockTransfer.Lines.BinAllocations.Quantity = parRecepcion.Cantidad;
            StockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (StockTransfer.Add() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;

        }


        public string Stock_Transfer_Ubicaciones(cldRecepcion parRecepcion)
        {

            //string NewObjectKey;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parRecepcion.UsuarioSap;
            sbo_HDV_P03.Password = parRecepcion.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer StockTransfer;
            StockTransfer = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oStockTransfer);

            // datos de cabecera

            StockTransfer.CardCode = parRecepcion.CardCode;
            //StockTransfer.DocDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            //StockTransfer.TaxDate = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            StockTransfer.UserFields.Fields.Item("U_DTE_Patente").Value = "";
            StockTransfer.UserFields.Fields.Item("U_DTE_NombreChofer").Value = "";
            StockTransfer.Series = 27;

            
            // datos de detalle

            StockTransfer.Lines.ItemCode = parRecepcion.ItemCode;
            StockTransfer.Lines.Quantity = parRecepcion.Cantidad;
            StockTransfer.Lines.FromWarehouseCode = parRecepcion.FromWhsCode;
            StockTransfer.Lines.WarehouseCode = parRecepcion.ToWhsCode;

            if (parRecepcion.DocEntry_Ref > 0)
            {
                StockTransfer.Lines.BaseType = SAPbobsCOM.InvBaseDocTypeEnum.InventoryTransferRequest;
                StockTransfer.Lines.BaseEntry = parRecepcion.DocEntry_Ref;
                StockTransfer.Lines.BaseLine = parRecepcion.LineNum_Ref;

            }

            StockTransfer.Lines.BatchNumbers.BatchNumber = parRecepcion.Lote.ToString();
            StockTransfer.Lines.BatchNumbers.Quantity = parRecepcion.Cantidad;
            StockTransfer.Lines.BatchNumbers.Notes = "";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.ParseExact(parRecepcion.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year.ToString();
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = "2022";
            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "7";
            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = 1;
            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = "";
            StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = "";
            //StockTransfer.Lines.BatchNumbers.UserFields.Fields.Item("U_CALIBRE").Value = "";

            StockTransfer.Lines.BinAllocations.BinActionType = SAPbobsCOM.BinActionTypeEnum.batToWarehouse;
            StockTransfer.Lines.BinAllocations.BinAbsEntry = parRecepcion.BinAbsEntry;
            StockTransfer.Lines.BinAllocations.Quantity = parRecepcion.Cantidad;
            StockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (StockTransfer.Add() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;

        }



        public string Sales_Order_Lotes(cldRecepcion parOrdenVenta)
        {

            //string NewObjectKey;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrdenVenta.UsuarioSap;
            sbo_HDV_P03.Password = parOrdenVenta.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Documents OrdenVenta;
            OrdenVenta = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);

            // datos de cabecera


            OrdenVenta.GetByKey(parOrdenVenta.DocEntry);
            OrdenVenta.Lines.SetCurrentLine(parOrdenVenta.LineId);

            //OrdenVenta.Lines.Add();
            //OrdenVenta.Lines.BaseEntry = 593;
            ////OrdenVenta.Lines.BaseType = SAPbobsCOM.bo

            //OrdenVenta.Lines.BaseLine = 0;
            //OrdenVenta.Lines.ItemCode = "AT01034028CA10";
            //OrdenVenta.Lines.Quantity = 10;
            ////OrdenVenta.Lines.FreeText = FreeText;
            ////OrdenVenta.Lines.UoMEntry = UoMEntry;
            ////OrdenVenta.Lines.Price = Price;
            ////OrdenVenta.Lines.WarehouseCode = WarehouseCode;

            OrdenVenta.Lines.BatchNumbers.Add();
            OrdenVenta.Lines.BatchNumbers.BatchNumber = parOrdenVenta.Lote.ToString();
            OrdenVenta.Lines.BatchNumbers.Quantity = parOrdenVenta.Cantidad;


            //OrdenVenta.DocNum = 5003302;
            //OrdenVenta.DocType = SAPbobsCOM.BoDocumentTypes.dDocument_Items;

            //OrdenVenta.Lines.BaseType = SAPbobsCOM.BoDocLineType.dlt_Alternative;
            ////OrdenVenta.Lines.BaseType = 17;

            ////OrdenVenta .Lines.BaseType = 17;
            ////OrdenVenta.Lines.BaseLine = 0;
            ////OrdenVenta.Lines.ItemCode = "AT01034028CA10";
            ////OrdenVenta.Lines.Quantity = 10;

            //OrdenVenta.Lines.SetCurrentLine(0);
            //OrdenVenta.Lines.BatchNumbers.Add();
            //OrdenVenta.Lines.BatchNumbers.BaseLineNumber = 0;
            //OrdenVenta.Lines.BatchNumbers.BatchNumber = "16687"; // parRecepcion.Lote.ToString();
            //OrdenVenta.Lines.BatchNumbers.Quantity = 10; // parRecepcion.Cantidad;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (OrdenVenta.Update() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;

        }

        public string Sales_Order_New_Picking(cldRecepcion parOrdenVenta)
        {

            //string NewObjectKey;

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrdenVenta.UsuarioSap;
            sbo_HDV_P03.Password = parOrdenVenta.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.PickLists oPickLists;
            oPickLists = (SAPbobsCOM.PickLists)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPickLists);

            // datos de cabecera

            oPickLists.PickDate = DateTime.ParseExact(parOrdenVenta.FechaIngreso, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            oPickLists.OwnerCode = 1;
            oPickLists.Name = "TEST";
            oPickLists.Remarks = "TEST";

            oPickLists.Lines.SetCurrentLine(0);
            oPickLists.Lines.BaseObjectType = "17"; //SAPbobsCOM.BoObjectTypes.oOrders.ToString();
            oPickLists.Lines.ReleasedQuantity = 80;
            oPickLists.Lines.OrderEntry = 591;
            oPickLists.Lines.OrderRowID = 0;

            oPickLists.Lines.Add();

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            //NewObjectKey = "";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (oPickLists.Add() == 0)
                {
                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                }

            }
            catch (Exception)
            {
                if (sbo_HDV_P03.InTransaction)
                    sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                sbo_HDV_P03.GetLastError(out errCode, out errMsg);

            }

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;

        }

        public void Consulta_Ultimo_Lote()
        {
            string sql;

            sql = "select ";
            sql += "MAX(CONVERT(INT,T0.[DistNumber])) as DistNumber ";
            sql += "FROM OBTN T0 ";
            sql += "WHERE ISNUMERIC(T0.[DistNumber]) = 1  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Max_EntradaMercaderia(string cCardCode, int nMes, int nAnho)
        {
            string sql;

            sql = "select ";
            sql += "max(DocEntry) as DocEntry ";
            sql += "from OPDN ";
            sql += "where CardCode = '" + cCardCode + "' ";
            //sql += "and MONTH(DocDate) = " + nMes + " "; 
            //sql += "and year(DocDate) = " + nAnho + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Max_RecepcionMP()
        {
            string sql;

            sql = "select ";
            sql += "max(DocEntry) as DocEntry ";
            sql += "from [@HDV_OPDX] ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consulta_Pesos_x_Guia(int nDocEntry)
        {
            string sql;

            sql = "select ";
            sql += "LineId, 'Pesaje N° ' + convert(varchar(3), LineId + 1) as Ref_LineId  ";
            sql += "from[@HDV_ROM2]  ";
            sql += "where DocEntry = " + nDocEntry + " ";
            //sql += "and U_Estado = '' ";
            sql += "order by U_FechaPeso1  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Pesos_x_Guia_Detalle(int nDocEntry, int nLineId)
        {
            string sql;

            sql = "select top 1 ";
            sql += "DocEntry , LineId , U_PesoBruto , U_PesoTara , U_PesoNeto , U_FechaPeso1 , U_FechaPeso2  ";
            sql += "from[@HDV_ROM2]  ";
            sql += "where DocEntry = " + nDocEntry + " ";
            sql += "and LineId = " + nLineId + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_EntradaMercaderia_x_DocEntry(int nDocEntry)
        {
            string sql;

            sql = "select * ";
            sql += "from OPDN ";
            sql += "where DocEntry = " + nDocEntry + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(int nDocEntry, int nDocEntry_t)
        {
            string sql;

            sql = "exec SAPB1_RECEPCION5 " + nDocEntry + " , " + nDocEntry_t;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_max_devolucion()
        {

            string sql;

            sql = "select max(DocEntry) as DocEntry from ORPD ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }



    }


}
