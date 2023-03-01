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
    public class cldProductos : GestorSql
    {
        public string ItemName;

        public string ItemCode { get; set; }
        public string Lote { get; set; }
        public string WhsCode { get; set; }
        public double Quantity { get; set; }
        public string UsuarioSap { get; set; }
        public string ClaveSap { get; set; }
        public string DocDate { get; set; }
        public string[,] arrDetalle { get; set; }
        public int DocEntry{ get; set; }
        public string Nota { get; set; }
        public string OcrCode { get; set; }
        public string OcrCode2 { get; set; }
        public string OcrCode3 { get; set; }
        public string Referencia { get; set; }

        public static SAPbobsCOM.Company sbo_HDV_P03;
        public static int accesoMenuPrincipal;
        public static SAPbobsCOM.Recordset oRecordset;


        public void consultar_Productos(string itemname, int solo_mp, int con_oc, int fruta_propia)
        {
            string sql;
            ////
            sql = "select ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.OnHand ,";
            sql = sql + "t1.IsCommited ,t2.U_TipoProducto ";
            sql = sql + "from OITM t1 ";
            sql = sql + "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";
            sql = sql + "where t1.InvntItem = 'Y' ";
            sql = sql + "and len(t1.ItemCode) > 20 ";
            sql = sql + "and upper(t1.ItemName) like '%" + itemname.ToUpper() + "%'";

            if (solo_mp == 1)
            {
                sql = sql + "and t2.U_Familia = 'Materia Prima' ";

            }

            if (solo_mp == 0)
            {
                sql = sql + "and t2.U_Familia in ( 'Materia Prima' , 'Semielaborado')  ";

            }

            if (con_oc == 1)
            {
                sql = sql + "and t1.ItemCode in ( select t1.ItemCode from OPOR t0 ";
                sql = sql + "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";
                sql = sql + "where t0.DocStatus not in ('C') ";
                sql = sql + "and t1.ItemCode is not null ) ";

            }

            if (fruta_propia == 1)
            {
                sql = sql + "and t2.U_TipoFruta = 'Propia' ";

            }

            sql = sql + "order by t1.ItemName";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public  void ConsultarProducto (string ItemCode)
        {
            this.ItemCode = ItemCode;
            this.ComandoSql = "select ItemName from OITM where itemCode='" + this.ItemCode + "'";
            this.GestorSqlConsultar();
            if (this.HayDatos)
            {
                this.ItemName = this.Resultado.Rows[0]["ItemName"].ToString();
            }
            else
            {
                this.ItemName = "Articulo no encontrado";
            }
        }

        public void consultar_Producto_x_codigo(string itemcode)
        {
            string sql;
            //

            sql = "select top 1 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.BWeight1 , ";
            sql = sql + "convert ( int , t1.BWeight1 ) as PesoInt , t2.U_TipoProducto , ";
            sql = sql + "t1.InvntryUom , coalesce ( t2.ItmsGrpNam , '' ) as ItmsGrpNam , ";
            sql = sql + "t1.ManBtchNum , t1.ManBtchNum ";
            sql = sql + "from OITM t1 ";
            sql = sql + "left join OITB t2 on t2.ItmsGrpCod = t1.ItmsGrpCod ";

            sql = sql + "where t1.ItemCode = '" + itemcode + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Producto_x_codigo_stock(string itemcode, string almacen)
        {
            string sql;

            sql = "select top 1 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.BWeight1 , ";
            sql = sql + "convert ( int , t1.BWeight1 ) as PesoInt , t1.U_TipoFruta , InvntryUom , ";
            sql = sql + "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t1.ItemCode and ta1.WhsCode = '" + almacen + "' ) , 0 ) as OnOrder , ";
            sql = sql + "t1.ManBtchNum , t2.U_TipoProducto ";

            sql = sql + "from OITM t1 ";
            sql = sql + "left join OITB t2 on t2.ItmsGrpCod = t1.ItmsGrpCod ";

            sql = sql + "where t1.ItemCode = '" + itemcode + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Productos1(string cItemCode, string cItemName)
        {
            string sql;

            sql = "select top 1000 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.OnHand ,";
            sql = sql + "t1.IsCommited ,t2.U_TipoProducto ";
            sql = sql + "from OITM t1 ";
            sql = sql + "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";
            sql = sql + "where t1.ItemCode like '%" + cItemCode + "%' ";
            sql = sql + "and t1.ItemName like '%" + cItemName + "%' ";
            //sql = sql + "and t1.InvntItem = 'Y'
            sql = sql + "order by t1.ItemName";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Productos2(int nDocNum)
        {
            string sql;

            sql = "select top 1000 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.OnHand ,";
            sql = sql + "t1.IsCommited ,t2.U_TipoProducto ";
            sql = sql + "from OITM t1 ";
            sql = sql + "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";
            sql = sql + "where t1.ItemCode in ( select ItemCode from OWOR where DocNum = " + nDocNum + " ";
            sql = sql + "union all select ItemCode from WOR1 where DocEntry = " + nDocNum + "and BaseQty < 0 ) ";
            sql = sql + "order by t1.ItemName";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Productos3(int nDocNum)
        {
            string sql;

            sql = "select top 1000 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.OnHand ,";
            sql = sql + "t1.IsCommited ,t2.U_TipoProducto , t3.wareHouse  ";
            sql = sql + "from OITM t1 ";
            sql = sql + "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";
            sql = sql + "inner join WOR1 t3 on t3.DocEntry = " + nDocNum + " and t3.ItemCode = t1.ItemCode and BaseQty > 0 and t3.IssueType = 'M' ";
            sql = sql + "order by t1.ItemName";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Productos2(string cItemCode, string cItemName)
        {
            string sql;

            sql = "select top 1000 ";
            sql = sql + "t1.ItemCode, t1.ItemName, t1.OnHand ,";
            sql = sql + "t1.IsCommited ,t2.U_TipoProducto ";
            sql = sql + "from OITM t1 ";
            sql = sql + "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";
            sql = sql + "where t1.InvntItem = 'Y' ";
            sql = sql + "and t1.ItemCode like '%" + cItemCode + "%' ";
            sql = sql + "and t1.ItemName like '%" + cItemName + "%' ";
            sql = sql + "and t1.ItemCode in ( select Code from OITT ) ";
            sql = sql + "order by t1.ItemName";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_stock_x_codigo_almacen(string cItemCode, string cAlmacen)
        {
            string sql;

            sql = "select top 1 * , OnHand as Quantity ";
            sql += "from OITW ";
            sql += "where itemCode = '" + cItemCode + "' ";
            sql += "and WhsCode = '" + cAlmacen + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_stock_x_codigo_almacen_y_lote(string cItemCode, string cAlmacen)
        {
            string sql;

            sql = "select BatchNum, Quantity, U_FolioPallet ";
            sql += "from OIBT ";
            sql += "where itemCode = '" + cItemCode + "' ";
            sql += "and WhsCode = '" + cAlmacen + "' ";
            sql += "and Quantity > 0 ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_stock_x_codigo_almacen_y_lote2(string cItemCode, string cAlmacen, string cLote)
        {
            string sql;

            sql = "select DistNumber, Quantity ";
            sql += "from vista_inventario_lotes_completa ";
            sql += "where itemCode = '" + cItemCode + "' ";
            sql += "and WhsCode = '" + cAlmacen + "' ";
            sql += "and DistNumber = '" + cLote + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_Productos_x_Corregir()
        {
            string sql;
            ////
            sql = "select ";
            sql = sql + "t0.* , coalesce ( t1.IsCommited , 0 ) as IsCommited ,  ";
            sql = sql + "coalesce ( ( select top 1 ta0.DocEntry from OITL ta0  ";
            sql = sql + "inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry and ta1.MdAbsEntry = t0.DistNumber  ";
            sql = sql + "inner join OWTQ ta2 on ta2.DocEntry = ta0.DocEntry and ta2.DocStatus = 'O' ";
            sql = sql + "where ta0.DocType = 1250000001 ) , 0 ) as DocEntry , t2.AvgPrice ";
            sql = sql + "from vista_inventario_lotes_completa t0 ";
            sql = sql + "left join OIBT t1 on t1.ItemCode = t0.ItemCode and t1.BatchNum = t0.DistNumber and t1.WhsCode = t0.WhsCode  ";
            sql = sql + "inner join OITM t2 on t2.ItemCode = t0.ItemCode  ";

            sql = sql + "Where t0.ItemCode = 'FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01' ";
            //sql = sql + "Where t0.ItemCode = 'FP.NUE.PT.XXXX.XXX.X.LPX-XXX.XLL.C.0010K.01' ";
            //sql = sql + "Where t0.ItemCode = 'FP.NUE.PT.XXXX.XXX.X.XXX-XXX.INC.C.0010K.01' ";
            sql = sql + "and t0.DistNumber not in ( 'LABCC' , 'LABCA' )  ";

            sql = sql + "order by t0.ItemCode , t0.WhsCode , t0.AbsEntry  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public string Salida_Productos_x_Corregir(cldProductos parVariables)
        {

            string NewObjectKey;
            string cItemCode, cLote;
            double nQuantity_D;
            int nLineLote;

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
            sbo_HDV_P03.UserName = parVariables.UsuarioSap;
            sbo_HDV_P03.Password = parVariables.ClaveSap;

            sbo_HDV_P03.Connect();           

            SAPbobsCOM.Documents SalidaMercancia;
            SalidaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);

            //// datos de cabecera
            cItemCode = parVariables.ItemCode;

            SalidaMercancia.DocDate = DateTime.ParseExact(parVariables.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            SalidaMercancia.Reference2 = "";
            SalidaMercancia.Comments = "Ajuste por Correccion de Costos";
            SalidaMercancia.JournalMemo = "Ajuste por Correccion de Costos";

            //SalidaMercancia.Lines.BaseType = 202;

            SalidaMercancia.Lines.ItemCode = cItemCode;
            SalidaMercancia.Lines.Quantity = parVariables.Quantity;
            SalidaMercancia.Lines.WarehouseCode = parVariables.WhsCode;
            SalidaMercancia.Lines.UnitPrice = 0;

            nLineLote = 0;

            for (int x = 0; x <= 999; x++)
            {
               
                try
                {
                    cLote = parVariables.arrDetalle[2, x];
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(parVariables.arrDetalle[3, x]);
                }
                catch
                {
                    nQuantity_D = -1;
                }
              
                if (nQuantity_D > 0)
                {
                    if (nLineLote > 0)
                    {
                        //StockTransf.Lines.Add();
                        SalidaMercancia.Lines.BatchNumbers.Add();
                    }

                    SalidaMercancia.Lines.BatchNumbers.BatchNumber = cLote;
                    SalidaMercancia.Lines.BatchNumbers.Quantity = nQuantity_D;

                    nLineLote += 1;

                }

            }

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (SalidaMercancia.Add() == 0)
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

        public string Revalorizacion_Inventario(cldProductos parVariables)
        {

            string NewObjectKey;
            string cItemCode;

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
            sbo_HDV_P03.UserName = parVariables.UsuarioSap;
            sbo_HDV_P03.Password = parVariables.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.MaterialRevaluation Revalorizacion;
            Revalorizacion = (SAPbobsCOM.MaterialRevaluation)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oMaterialRevaluation);

            //// datos de cabecera
            cItemCode = parVariables.ItemCode;

            Revalorizacion.DocDate = DateTime.ParseExact(parVariables.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            Revalorizacion.TaxDate = DateTime.ParseExact(parVariables.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            Revalorizacion.Reference2 = parVariables.Referencia;
            Revalorizacion.Comments = "Ajuste por Correccion de Costos";
            Revalorizacion.JournalMemo = "Ajuste por Correccion de Costos";

            Revalorizacion.Lines.ItemCode = cItemCode;

            string cCuentaContable;

            cCuentaContable = "1108905";

            if (cItemCode.Substring(0, 2) == "BO")
            {
                cCuentaContable = "1108921";

            }

            if (cItemCode.Substring(0, 2) == "AP")
            {
                cCuentaContable = "1108922";

            }

            if (cItemCode.Substring(0, 2) == "SA")
            {
                cCuentaContable = "1108923";

            }

            if (cItemCode.Substring(3,3) == "NUE")
            {
                cCuentaContable = "1108905";

            }

            if (cItemCode.Substring(3, 3) == "ALM")
            {
                cCuentaContable = "1108904";

            }

            if (cItemCode.Substring(3, 3) == "CIR")
            {
                cCuentaContable = "1108906";

            }

            Revalorizacion.Lines.RevaluationDecrementAccount = cCuentaContable;
            Revalorizacion.Lines.RevaluationIncrementAccount = cCuentaContable;
            Revalorizacion.Lines.Price = 0;

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (Revalorizacion.Add() == 0)
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

        public string Salida_Productos_Ajuste_Mermas(cldProductos parVariables)
        {

            string NewObjectKey;
            string cItemCode, cLote;

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
            sbo_HDV_P03.UserName = parVariables.UsuarioSap;
            sbo_HDV_P03.Password = parVariables.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Documents SalidaMercancia;
            SalidaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);

            //// datos de cabecera
            cItemCode = parVariables.ItemCode;

            SalidaMercancia.DocDate = DateTime.ParseExact(parVariables.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            SalidaMercancia.Reference2 = "";
            SalidaMercancia.Comments = "AJUSTE DE INSUMOS TIPO B";
            SalidaMercancia.JournalMemo = "AJUSTE DE INSUMOS TIPO B";

            //SalidaMercancia.Lines.BaseType = 202;

            SalidaMercancia.Lines.ItemCode = cItemCode;
            SalidaMercancia.Lines.Quantity = parVariables.Quantity;
            SalidaMercancia.Lines.WarehouseCode = parVariables.WhsCode;
            SalidaMercancia.Lines.UnitPrice = 0;
            SalidaMercancia.Lines.CostingCode = parVariables.OcrCode;
            SalidaMercancia.Lines.CostingCode2 = parVariables.OcrCode2;
            SalidaMercancia.Lines.CostingCode3 = parVariables.OcrCode3;

            //SalidaMercancia.Lines.COGSAccountCode = "5103901";
            //SalidaMercancia.Lines.COGSCostingCode = "CSERALM";

            cLote = "";

            try
            {
                cLote = parVariables.Lote;
            }
            catch
            {
                cLote = "";
            }

            if (cLote == "0")
            {
                cLote = "";
            }

            if (cLote != "")
            {
                SalidaMercancia.Lines.BatchNumbers.BatchNumber = cLote;
                SalidaMercancia.Lines.BatchNumbers.Quantity = parVariables.Quantity;

            }

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (SalidaMercancia.Add() == 0)
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

        public string Entrada_Productos_x_Corregir(cldProductos parVariables)
        {

            string NewObjectKey;
            string cItemCode, cLote;
            double nQuantity_D;
            int nLineLote;

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
            sbo_HDV_P03.UserName = parVariables.UsuarioSap;
            sbo_HDV_P03.Password = parVariables.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry);

            //// datos de cabecera
            cItemCode = parVariables.ItemCode;

            EntradaMercancia.DocDate = DateTime.ParseExact(parVariables.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.Reference2 = "";
            EntradaMercancia.Comments = "Ajuste por Correccion de Costos";
            EntradaMercancia.JournalMemo = "Ajuste por Correccion de Costos";

            //SalidaMercancia.Lines.BaseType = 202;

            EntradaMercancia.Lines.ItemCode = cItemCode;
            EntradaMercancia.Lines.Quantity = parVariables.Quantity;
            EntradaMercancia.Lines.WarehouseCode = parVariables.WhsCode;
            EntradaMercancia.Lines.UnitPrice = 0; // aca se coloca el costo nuevo 

            nLineLote = 0;

            for (int x = 0; x <= 999; x++)
            {

                try
                {
                    cLote = parVariables.arrDetalle[2, x];
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(parVariables.arrDetalle[3, x]);
                }
                catch
                {
                    nQuantity_D = -1;
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

                    nLineLote += 1;

                }

            }

            //EntradaMercancia.Lines.BatchNumbers.BatchNumber = parVariables.Lote;
            //EntradaMercancia.Lines.BatchNumbers.Quantity = parVariables.Quantity;

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

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


        public string CierraSolicitud_Productos_x_Corregir(cldProductos parVariables)
        {

            string NewObjectKey;
            string cItemCode;

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
            sbo_HDV_P03.UserName = parVariables.UsuarioSap;
            sbo_HDV_P03.Password = parVariables.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer SolicitudTransferMercancia;
            SolicitudTransferMercancia = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);

            //(SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);

            //// datos de cabecera
            cItemCode = parVariables.ItemCode;

            SolicitudTransferMercancia.GetByKey(parVariables.DocEntry);

            SolicitudTransferMercancia.Close();

            int errCode;
            string errMsg;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

            try
            {

                sbo_HDV_P03.StartTransaction();

                if (SolicitudTransferMercancia.Update() == 0)
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

        public void consultar_bodega_area(string area)
        {
            string sql;
            //

            sql = "select top 1 * ";
            sql = sql + "from OWHS ";
            sql = sql + "where TaxOffice = '" + area + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consultar_bodega_responsable(string WhsCode)
        {
            string sql;
            //

            sql = "select top 1  ";
            sql = sql + "t0.WhsCode , t0.WhsName , t0.GlblLocNum , ";
            sql = sql + "t1.USER_CODE , t1.U_NAME , t1.E_Mail ";
            sql = sql + "from OWHS t0 ";
            sql = sql + "left join OUSR t1 on t1.USERID = t0.GlblLocNum ";
            sql = sql + "where t0.WhsCode = '" + WhsCode + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


    }


}
