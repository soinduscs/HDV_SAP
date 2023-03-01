using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SAPbobsCOM;

namespace CapaDatos
{
    public class cldOrdenFabricacion : GestorSql
    {

        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public string PostDate { get; set; }
        public string StartDate { get; set; }
        public string Bloqueado { get; set; }
        public string DueDate { get; set; }
        public string DocDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UM { get; set; }
        public int UserSign { get; set; }
        public string Warehouse { get; set; }
        public double PlannedQty { get; set; }
        public int OriginNum { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public string U_Proceso { get; set; }
        public string U_OrdenAfecta { get; set; }
        public string U_TipoOrden { get; set; }
        public string U_TipoFruta { get; set; }
        public int LineNum { get; set; }
        public string ItemCode_D { get; set; }
        public string ItemName_D { get; set; }
        public double BaseQty { get; set; }
        public double PlannedQty_D { get; set; }
        public string Warehouse_D { get; set; }
        public double IssuedQty { get; set; }
        public string lote { get; set; }
        public double Quantity { get; set; }
        public string UsuarioSap { get; set; }
        public string ClaveSap { get; set; }
        public string[,] arrDetalle { get; set; }
        public string[,] arrDetalle1 { get; set; }
        public string CodigoNumeroPallet { get; set; }
        public int CantidadBins { get; set; }
        public string CodeProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string CodeCliente { get; set; }
        public string NombreCliente { get; set; }
        public string SalidaProduccion { get; set; }
        public string Codigo_CSG { get; set; }

        public string Conexion_SAP { get; set; }
        public int Lote { get; set; }
        public string Calibre { get; set; }
        public string Variedad { get; set; }
        public string Turno { get; set; }
        public string Area { get; set; }
        public int User_Autorizador { get; set; }
        public int DocEntryRef { get; set; }
        public string ccosto { get; set; }
        public string lun { get; set; }
        public string mar { get; set; }
        public string mie { get; set; }
        public string jue { get; set; }
        public string vie { get; set; }
        public string accion { get; set; }
        public string MensajeC { get; set; }

        public string fecha_proceso { get; set; }

        public static SAPbobsCOM.Company sbo_HDV_P03;
        public static int accesoMenuPrincipal;
        public static SAPbobsCOM.Recordset oRecordset;

        public void consultar_OrdenesFabricacionAbiertas()
        {

            this.ComandoSql = "select DocEntry, DueDate  from OWOR where status='R'";
            this.GestorSqlConsultar();


        }

        public void consultar_DatosCabeceraOrdenFabricacion(int NroOrdenFabricacion)
        {

            this.ComandoSql = "select Docentry, ItemCode from OWOR where DocEntry=" + NroOrdenFabricacion.ToString();
            this.GestorSqlConsultar();


        }

        public void consultar_ProcesosProductivosOrdenFabricacion(int NroOrdenFabricacion)
        {

            this.ComandoSql = "select * from  vista_ProcesosProductivos where OrdenFabricacion=" + NroOrdenFabricacion.ToString();
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_x_DocNum(int nDocNum)
        {
            string sql;

            sql = "exec xSapb1_query_ordenfabricacion " + nDocNum + " ";

            //sql = "select ";
            //sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate , ";
            //sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse , ";
            //sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments , ";
            //sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta , ";
            //sql += "t2.LineNum , t2.ItemCode as ItemCode_D , t2.BaseQty , t2.PlannedQty as PlannedQty_D , ";
            //sql += "t3.ItemName as ItemName_D , t2.Warehouse as Warehouse_D , t2.IssuedQty , ";
            //sql += "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t2.ItemCode and ta1.WhsCode = t2.Warehouse ) , 0 ) as OnOrder_D , ";
            //sql += "coalesce ( t3.InvntryUom , '' ) as InvntryUom_D , t4.U_TipoProducto , ";
            //sql += "coalesce ( t5.OpenQty , 0 ) as OpenQty_SOL , coalesce ( t7.CardName , '' ) as Nom_Cliente , ";
            //sql += "coalesce ( t9.Location , 'PAINE' ) as Location , getdate() as fecha_actual ";

            //sql += "from OWOR t0 ";
            //sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            //sql += "left join WOR1 t2 on t2.DocEntry = t0.DocEntry and t2.IssueType = 'M' ";
            //sql += "left join OITM t3 on t3.ItemCode = t2.ItemCode ";
            //sql += "left join OITB t4 on t4.ItmsGrpCod = t1.ItmsGrpCod ";
            //sql += "left join ( select substring ( t0.Comments , 47 , 4 ) as Ref_OF , sum(t1.Quantity) as Quantity , sum(t1.OpenQty) as  OpenQty from OWTQ t0 inner join WTQ1 t1 on t1.DocEntry = t0.DocEntry  group by substring ( t0.Comments , 47 , 4 )   ) t5 on t5.Ref_OF = convert ( varchar(4) , t0.DocNum )  ";
            //sql += "left join OCRD t7 on t7.CardCode = t0.CardCode ";
            //sql += "left join OWHS t8 on t8.WhsCode = t0.Warehouse ";
            //sql += "left join OLCT t9 on t9.Code = t8.Location  ";

            //sql += "Where t0.DocNum = " + nDocNum + " ";
            //sql += "order by t2.LineNum ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_x_DocNum_Insumos(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t2.ItemCode , t3.ItemName , t4.ItmsGrpNam , t2.wareHouse , t2.PlannedQty - t2.IssuedQty as porCompletar  ";
            sql += "from OWOR t0 ";
            sql += "inner join OITM t1 on t1.ItemCode = t0.ItemCode and t1.ItmsGrpCod in ( select ItmsGrpCod  from OITB where U_familia = 'Producto Terminado' ) ";
            sql += "inner join WOR1 t2 on t2.DocEntry = t0.DocEntry and t2.IssueType = 'M' ";
            sql += "inner join OITM t3 on t3.ItemCode = t2.ItemCode and t3.ManBtchNum = 'Y' ";
            sql += "inner join OITB t4 on t4.ItmsGrpCod = t3.ItmsGrpCod and t4.ItmsGrpCod in ( 236 , 185 , 135 , 255 ) ";

            sql += "Where t0.DocNum = " + nDocNum + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Insumos_Servicios(int nDocNum)
        {
            string sql;

            sql = "select t1.ItemCode , t2.ItemName ,  t1.PlannedQty , IssuedQty ";

            sql += "from OWOR t0 ";
            sql += "inner join WOR1 t1 on t1.DocEntry = t0.DocEntry and t1.IssueType = 'M' ";
            sql += "inner join OITM t2 on t2.ItemCode = t1.ItemCode and t2.ItmsGrpCod = 255 ";
            sql += "Where t0.DocNum = " + nDocNum.ToString()  + " ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Insumos_Servicios_Linea(int nDocNum, string cItemCode)
        {
            string sql;

            sql = "select t1.* ";

            sql += "from OWOR t0 ";
            sql += "inner join WOR1 t1 on t1.DocEntry = t0.DocEntry and t1.IssueType = 'M' ";
            sql += "Where t0.DocNum = " + nDocNum.ToString() + " ";
            sql += "and t1.ItemCode = '" + cItemCode + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Detalle_Linea(int nDocNum, string cItemCode)
        {
            string sql;

            sql = "select t1.* ";
            sql += "from OWOR t0 ";
            sql += "inner join WOR1 t1 on t1.DocEntry = t0.DocEntry and t1.IssueType = 'M' ";
            sql += "Where t0.DocNum = " + nDocNum.ToString() + " ";
            sql += "and t1.ItemCode = '" + cItemCode + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_x_DocNum1(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate , ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse , ";
            sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments , ";
            sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta , ";
            sql += "t2.LineNum , t2.ItemCode as ItemCode_D , t2.BaseQty , t2.PlannedQty as PlannedQty_D , ";
            sql += "t3.ItemName as ItemName_D , t2.Warehouse as Warehouse_D , t2.IssuedQty , ";
            sql += "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t2.ItemCode and ta1.WhsCode = t2.Warehouse ) , 0 ) as OnOrder_D , ";
            sql += "coalesce ( t3.InvntryUom , '' ) as InvntryUom_D , t4.U_TipoProducto , ";
            sql += "coalesce ( t5.OpenQty , 0 ) as OpenQty_SOL  ";
            sql += " ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join WOR1 t2 on t2.DocEntry = t0.DocEntry and t2.IssueType = 'M' and t2.PlannedQty < 0 ";
            sql += "left join OITM t3 on t3.ItemCode = t2.ItemCode ";
            sql += "left join OITB t4 on t4.ItmsGrpCod = t1.ItmsGrpCod ";
            sql += "left join ( select substring ( t0.Comments , 47 , 4 ) as Ref_OF , sum(t1.Quantity) as Quantity , sum(t1.OpenQty) as  OpenQty from OWTQ t0 inner join WTQ1 t1 on t1.DocEntry = t0.DocEntry  group by substring ( t0.Comments , 47 , 4 )   ) t5 on t5.Ref_OF = convert ( varchar(4) , t0.DocNum )  ";
            sql += " ";

            sql += "Where t0.DocNum = " + nDocNum + " ";
            sql += "order by t2.LineNum ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Pesaje_DyS(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t2.U_FechaPeso2 , t1.U_ItemCode , t1.U_ItemName , ";
            sql += "t1.U_CantidadBins , t2.U_PesoBruto , t2.U_PesoTara , t2.U_PesoNeto  ";
            sql += "from[@HDV_OROM] t0 ";
            sql += "inner join[@HDV_ROM1] t1 on t1.DocEntry = t0.DocEntry and t1.U_NumOC = " + nDocNum + " ";
            sql += "inner join[@HDV_ROM2] t2 on t2.DocEntry = t1.DocEntry and t2.U_Estado not in ( 'R' ) ";
            //sql += "inner join[@HDV_ROM2] t2 on t2.DocEntry = t1.DocEntry ";
            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Producto_x_Lote(string cDistNumber)
        {
            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t1.ItemName ";
            sql += "from OBTN t0  ";
            sql += "inner join OITM t1 on t1.ItemCode = t0.ItemCode  ";
            sql += "where t0.DistNumber = '" + cDistNumber + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Origen_MP(int nDocNum)
        {
            string sql;

            sql = "select 'Recibo de Producción' as TipoDoc ,  t0.DocNum , ";
            sql += "t1.ItemCode , t1.Dscription , t1.unitMsr ,t0.DocDate , t1.U_HDV_PRESENTACION , t1.U_HDV_VARIEDAD ";
            sql += "from OIGN t0 ";
            sql += "inner join IGN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry in (select t1.DocEntry from ITL1 t0 ";
            sql += "inner join OITL t1 on t1.LogEntry = t0.LogEntry ";
            sql += "where t0.MdAbsEntry in (select t1.MdAbsEntry ";
            sql += "from OITL t0 ";
            sql += "inner join ITL1 t1 on t1.LogEntry = t0.LogEntry ";
            sql += "inner join IGE1 t2 on t2.BaseRef = " + nDocNum + " ";
            sql += "Where t0.DocType = 60 ";
            sql += "and t0.DocEntry = t2.DocEntry ) ";
            sql += "and t1.DocType = 59 )  ";
            sql += "and t1.BaseType = 202 ";

            sql += "union all ";

            sql += "select 'Entrada / Ajuste' as TipoDoc ,  t0.DocNum , ";
            sql += "t1.ItemCode , t1.Dscription , t1.unitMsr ,t0.DocDate , t1.U_HDV_PRESENTACION , t1.U_HDV_VARIEDAD ";
            sql += "from OIGN t0 ";
            sql += "inner join IGN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry in (select t1.DocEntry from ITL1 t0 ";
            sql += "inner join OITL t1 on t1.LogEntry = t0.LogEntry ";
            sql += "where t0.MdAbsEntry in (select t1.MdAbsEntry ";
            sql += "from OITL t0 ";
            sql += "inner join ITL1 t1 on t1.LogEntry = t0.LogEntry ";
            sql += "inner join IGE1 t2 on t2.BaseRef = " + nDocNum + " ";
            sql += "Where t0.DocType = 60 ";
            sql += "and t0.DocEntry = t2.DocEntry ) ";
            sql += "and t1.DocType = 59 )  ";
            sql += "and t1.BaseType <> 202 ";

            sql += "union all ";

            sql += "select 'Entrada / Orden Compra' as TipoDoc ,  t2.DocNum , ";
            sql += "t3.ItemCode , t3.Dscription , t3.unitMsr ,t2.DocDate , t3.U_HDV_PRESENTACION , t3.U_HDV_VARIEDAD ";
            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join OPOR t2 on t2.DocNum = t1.BaseRef ";
            sql += "inner join POR1 t3 on t3.DocEntry = t2.DocEntry ";
            sql += "where t0.DocEntry in (select t1.DocEntry from ITL1 t0 ";
            sql += "inner join OITL t1 on t1.LogEntry = t0.LogEntry ";
            sql += "where t0.MdAbsEntry in (select t1.MdAbsEntry from OITL t0 ";
            sql += "inner join ITL1 t1 on t1.LogEntry = t0.LogEntry ";
            sql += "inner join IGE1 t2 on t2.BaseRef = " + nDocNum + " ";
            sql += "Where t0.DocType = 60 ";
            sql += "and t0.DocEntry = t2.DocEntry )  ";
            sql += "and t1.DocType = 20 )  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_para_Cerrar(int nDocNum)
        {
            string sql;

            sql = "exec xSapb1_utiles_resumenordenfabricaicon " + nDocNum;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Detalle_TR(int nDocNum)
        {
            string sql;

            sql = "exec xSapb1_utiles_resumenordenfabricaicon2 " + nDocNum;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Detalle_Consumos(int nDocNum)
        {
            string sql;

            sql = "exec xSapb1_utiles_resumenordenfabricaicon1 " + nDocNum;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_LotesTransferidospara_OF(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t4.ItemCode , t4.ItemName , t1.WhsCode  , t4.AbsEntry , t4.U_NOMBPROD , t4.U_NOMBCLI , t4.U_Fumigado , t4.U_FechaFumigacion , t2.AllocQty ,  ";
            sql += "t4.DistNumber , t4.U_Calibre , t4.U_HDV_VARIEDAD ,  coalesce((select top 1 ta3.Quantity from vista_inventario_lotes_completa ta3  where ta3.ItemCode = t2.ItemCode and ta3.DistNumber = t2.MdAbsEntry and ta3.WhsCode = t1.WhsCode ) , 0 ) as Stock_Lote_WhsCode  ";
            sql += "from OWTR t0 ";
            sql += "inner join WTR1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join ( select t2.ItemCode , t3.MdAbsEntry , t2.DocLine  , t2.DocEntry , sum(t3.AllocQty) as AllocQty ";
            sql += "from OITL t2 inner join ITL1 t3 on t3.LogEntry = t2.LogEntry where t2.DocType = '1250000001' group by t2.ItemCode , t3.MdAbsEntry , t2.DocLine  , t2.DocEntry ) as t2 on t2.ItemCode = t1.ItemCode and t2.DocLine = t1.BaseLine and t2.DocEntry = t1.BaseEntry ";
            sql += "left join OBTN t4 on t4.AbsEntry = t2.MdAbsEntry  ";
            sql += "where substring (t0.Comments , 47, 5 ) = '" + nDocNum + "' ";
            sql += "and t2.MdAbsEntry not in ( select T1.MdAbsEntry FROM OITL T0  INNER JOIN ITl1 T1 ON T1.LogEntry = T0.LogEntry Where T0.DocType = '202' and T0.DocEntry = '" + nDocNum + "' )  ";
            sql += "order by t2.MdAbsEntry  ";
            sql += " ";
            sql += " ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lotes_Asignados_x_OrdenFabricacion(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t1.MdAbsEntry , t2.MnfSerial , t2.U_NOMBPROD , t2.LotNumber , t2.U_NOMBCLI ";
            sql += "from OITL t0  ";
            sql += "inner join ITL1 t1 on t1.LogEntry = t0.LogEntry ";
            sql += "inner join OBTN t2 on t2.AbsEntry = t1.MdAbsEntry ";
            sql += "Where t0.DocType = '202' ";
            sql += "and t0.DocEntry = " + nDocNum + " ";
            sql += "order by t1.MdAbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Max_DocNum()
        {
            string sql;

            sql = "select max(DocNum) + 1 as DocNum ";
            sql += "from OWOR ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_pallet_existentes(string cItemCode, string cAlmacen)
        {
            string sql;

            sql = "select ";
            sql += "Code , CreateDate , U_ItemCode , U_ItemName , U_WhsCode ";
            sql += "from [@HDV_PALL] ";
            sql += "where U_ItemCode = '" + cItemCode + "' ";
            sql += "and U_WhsCode = '" + cAlmacen + "' ";
            sql += "order by CreateDate ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lita_UProcesos(int nFieldID)
        {
            string sql;

            sql = "select ";
            sql += "FldValue, Descr ";
            sql += "from UFD1 ";
            sql += "Where TableID = 'OWOR' ";
            sql += "and FieldID = " + nFieldID + ' ';
            sql += "order by IndexID ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consultar_Lista_de_OrdenFabricacion(string status, string planta, string proceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,  ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse , ";
            sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments , ";
            sql += "t2.U_NAME as NomResponsable ";
            //sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta ";

            sql += " ";
            sql += " ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign ";
            sql += "where t0.Status like '" + status + "' ";
            sql += "and t0.U_Proceso in ( select U_Code  from [@HDV_OPROC] ";
            sql += "where Code like '" + planta + "' ";
            sql += "and U_Code like '" + proceso + "' ) ";

            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            //            sql += "and t0.U_Proceso in ( 'Desp & Secado' , 'Despelonado' , 'Secado' ) ";

        }

        public void Consultar_Lista_de_OrdenFabricacion1(string status)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,  ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse , ";
            sql += "t0.PlannedQty , t0.OriginNum ,  "; // t0.CardCode , t0.Project , t0.Comments ,
            sql += "t2.U_NAME as NomResponsable , t0.U_Proceso , ";
            //sql += "t0.Status , t0.Type , t0.U_Proceso, t0.U_OrdenAfecta, t0.U_TipoOrden , t0.U_TipoFruta ";

            sql += "case when t0.U_VID_LoFa = 'Recibe_MP' then 'Recibir Como Materia Prima' ";
            sql += "     when t0.U_VID_LoFa = 'Envia_Clte' then 'Envío Directo a Cliente' ";
            sql += "     when t0.U_VID_LoFa = '' then 'Por Deinir' end as DestinoSecado ";
            sql += " ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign ";
            sql += "where t0.Status like '" + status + "' ";
            //sql += "where t0.Status like '%' ";
            sql += "and t0.U_Proceso in ( 'Desp & Secado' , 'Despelonado' , 'Secado' ) ";
            sql += " ";

            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


        }

        public void Consultar_Lista_de_fumigados()
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.U_fumigado , t0.U_fecha_fumigado , ";
            sql += "coalesce((select count(*) from[@HDV_FUM1] t1 where t1.DocEntry = t0.DocEntry) , 0 ) as Cant_Det , ";
            sql += "t0.UserSign , t2.U_NAME ";

            sql += "from [@HDV_OFUM] t0 ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign ";

            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


        }


        public void Consultar_Lista_de_OrdenFabricacion_despelonado(string status)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,  ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse , ";
            sql += "t0.PlannedQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments , ";
            sql += "t2.U_NAME as NomResponsable , t3.CardName , t0.U_VID_LoFa , t0.CmpltQty , ";
            sql += "t0.U_VID_InEm as Num_OC , t4.CardName as CardName_OC ";
            sql += " ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign ";
            sql += "left join OCRD t3 on t3.CardCode = t0.CardCode ";
            sql += "left join OPOR t4 on t4.DocNum = t0.U_VID_InEm ";
            sql += " ";

            sql += "where t0.Status like '" + status + "' ";
            sql += "and t0.U_Proceso in ( 'Desp & Secado' , 'Despelonado' , 'Secado' ) ";

            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


        }

        public void Consultar_Lotes_mp_pelon_dys()
        {
            string sql;

            sql = "select T0.* , a.DocEntry ,  ";

            sql += "convert(datetime, a.DocDate + ' ' + ";
            sql += "CASE WHEN len(a.DocTime) = 1 THEN '00:0' + substring(CONVERT(varchar(4), a.DocTime), 1, 1) ";
            sql += "WHEN len(a.DocTime) = 2 THEN '00:' + substring(CONVERT(varchar(4), a.DocTime), 1, 2) ";
            sql += "WHEN len(a.DocTime) = 3 THEN '0' + substring(CONVERT(varchar(4), a.DocTime), 1, 1) + ':' + substring(CONVERT(varchar(4), a.DocTime), 2, 2) ";
            sql += "WHEN len(a.DocTime) = 4 THEN substring(CONVERT(varchar(4), a.DocTime), 1, 2) + ':' + substring(CONVERT(varchar(4), a.DocTime), 3, 2) END) AS fecha_Hora_recepcion , ";   
            sql += "coalesce((select top 1 h.U_ItemCodeBins from[@HDV_ROM1] h where h.DocEntry = d.DocEntry_Romana and h.U_ItemCode = t0.ItemCode and h.U_ItemCodeBins <> '') , '' ) as ItemCodeBins , ";
            sql += "coalesce ( d.Fecha_Porteria , '' ) as Fecha_Porteria  ,  coalesce ( d.Fecha_Romana , '' ) as Fecha_Romana , coalesce ( d.Fecha_Calidad_Aprobacion_MP , '' ) as Fecha_Calidad_Aprobacion_MP ";

            sql += "from vista_inventario_lotes_completa t0 ";
            sql += "LEFT JOIN dbo.PDN1 AS b WITH(nolock) ON b.ItemCode = t0.ItemCode ";
            sql += "LEFT JOIN dbo.OPDN AS a WITH(nolock) ON b.DocEntry = a.DocEntry ";
            sql += "LEFT JOIN(SELECT MIN(b.LogEntry) AS LogEntry, MIN(b.ItemCode) AS ItemCode, MIN(c.DistNumber) AS BatchNum, MIN(b.LocCode) AS WhsCode, MIN(b.ItemName) ";
            sql += "          AS ItemName, MIN(b.ApplyType) AS BaseType, MIN(b.ApplyEntry) AS BaseEntry, MIN(b.AppDocNum) AS BaseNum, MIN(b.ApplyLine) AS BaseLinNum, ";
            sql += "                                                   MIN(b.DocDate) AS DocDate, (CASE WHEN ABS(SUM(a.Quantity)) = 0 THEN SUM(a.AllocQty) ELSE ABS(SUM(a.Quantity)) END) AS Quantity, ";
            sql += "                                                   MIN(b.CardCode) AS CardCode, MIN(b.CardName) AS CardName, (CASE WHEN SUM(a.Quantity) > 0 THEN 0 WHEN SUM(a.Quantity) ";
            sql += "                                                   < 0 THEN 1 ELSE 2 END) AS Direction, MIN(b.CreateDate) AS CreateDate, MIN(b.BaseType) AS BsDocType, MIN(b.BaseEntry) AS BsDocEntry, ";
            sql += "                                                   MIN(b.BaseLine) AS BsDocLine, 'N' AS DataSource, NULL AS UserSign ";
            sql += "                            FROM dbo.ITL1 AS a WITH(nolock) INNER JOIN ";
            sql += "                                                   dbo.OITL AS b WITH(nolock) ON a.LogEntry = b.LogEntry INNER JOIN ";
            sql += "                                                   dbo.OBTN AS c WITH(nolock) ON a.ItemCode = c.ItemCode AND a.SysNumber = c.SysNumber ";
            sql += "                            GROUP BY b.ItemCode, a.SysNumber, b.ApplyType, b.ApplyEntry, b.ApplyLine, b.LocCode, b.StockEff ";
            sql += "                            HAVING(SUM(b.DocQty) <> 0) OR ";
            sql += "                                             (SUM(b.DefinedQty) <> 0) OR ";
            sql += "                                             (SUM(b.DocQty) = 0) AND(b.StockEff = 2) AND(MIN(b.BaseType) <> 17) AND(MIN(b.BaseType) <> 13)) AS c ON a.DocEntry = c.BaseEntry AND ";
            sql += "                      c.BaseType = 20 ";
            sql += "left join vista_Seguimiento_Recepcion d on d.DocEntry_Recepcion = a.DocEntry ";
            sql += "where t0.ItemCode = 'FS.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01' ";
            sql += "and convert(varchar(100) , c.BatchNum ) = t0.DistNumber ";
            sql += "order by d.Fecha_Romana , t0.CreateDate  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


        }

        public void Consultar_Lotes_mp_pelon_dys1(string d_Anho)
        {
            string sql;

            sql = "select ";
            sql += "a.FolioNum , a.CardName ,  f.DistNumber , f.U_BINS , b.BaseRef , b.Quantity , ";
            sql += "f.U_HDV_VARIEDAD , f.U_Tipo_Cosecha , b.WhsCode , ";
            sql += "convert(datetime, a.DocDate + ' ' + ";
            sql += "CASE WHEN len(a.DocTime) = 1 THEN '00:0' + substring(CONVERT(varchar(4), a.DocTime), 1, 1) ";
            sql += "WHEN len(a.DocTime) = 2 THEN '00:' + substring(CONVERT(varchar(4), a.DocTime), 1, 2) ";
            sql += "WHEN len(a.DocTime) = 3 THEN '0' + substring(CONVERT(varchar(4), a.DocTime), 1, 1) + ':' + substring(CONVERT(varchar(4), a.DocTime), 2, 2) ";
            sql += "WHEN len(a.DocTime) = 4 THEN substring(CONVERT(varchar(4), a.DocTime), 1, 2) + ':' + substring(CONVERT(varchar(4), a.DocTime), 3, 2) END) AS fecha_Hora_recepcion, ";

            sql += "coalesce ( (select top 1 h.U_ItemCodeBins from[@HDV_ROM1] h where h.DocEntry = d.DocEntry_Romana and h.U_ItemCode = f.ItemCode and h.U_ItemCodeBins <> '' ) , '' ) as ItemCodeBins , ";
            sql += "coalesce((select top 1 j.Kilos from vista_inventario_lotes_completa j where j.ItemCode = f.ItemCode and j.DistNumber = f.DistNumber) , 0 ) as en_Stock , ";

            sql += "coalesce ( (select top 1 h.OrdenAfecta from vista_ProcesosProductivos h where h.Lote = f.DistNumber and TipoDocto = 'ConsumoProduccion' ) , 0 ) as orden_consumo , ";
            sql += "coalesce ( d.Fecha_Porteria , '' ) as Fecha_Porteria  ,  coalesce ( d.Fecha_Romana , '' ) as Fecha_Romana , coalesce ( d.Fecha_Calidad_Aprobacion_MP , '' ) as Fecha_Calidad_Aprobacion_MP ";

            sql += "from dbo.PDN1 AS b WITH(nolock) ";
            sql += "LEFT JOIN dbo.OPDN AS a WITH(nolock) ON b.DocEntry = a.DocEntry ";
            sql += "LEFT JOIN(SELECT MIN(b.LogEntry) AS LogEntry, MIN(b.ItemCode) AS ItemCode, MIN(c.DistNumber) AS BatchNum, MIN(b.LocCode) AS WhsCode, MIN(b.ItemName) ";
            sql += "          AS ItemName, MIN(b.ApplyType) AS BaseType, MIN(b.ApplyEntry) AS BaseEntry, MIN(b.AppDocNum) AS BaseNum, MIN(b.ApplyLine) AS BaseLinNum, ";
            sql += "                                                   MIN(b.DocDate) AS DocDate, (CASE WHEN ABS(SUM(a.Quantity)) = 0 THEN SUM(a.AllocQty) ELSE ABS(SUM(a.Quantity)) END) AS Quantity, ";
            sql += "                                                   MIN(b.CardCode) AS CardCode, MIN(b.CardName) AS CardName, (CASE WHEN SUM(a.Quantity) > 0 THEN 0 WHEN SUM(a.Quantity) ";
            sql += "                                                   < 0 THEN 1 ELSE 2 END) AS Direction, MIN(b.CreateDate) AS CreateDate, MIN(b.BaseType) AS BsDocType, MIN(b.BaseEntry) AS BsDocEntry, ";
            sql += "                                                   MIN(b.BaseLine) AS BsDocLine, 'N' AS DataSource, NULL AS UserSign ";
            sql += "                            FROM dbo.ITL1 AS a WITH(nolock) INNER JOIN ";
            sql += "                                                   dbo.OITL AS b WITH(nolock) ON a.LogEntry = b.LogEntry INNER JOIN ";
            sql += "                                                   dbo.OBTN AS c WITH(nolock) ON a.ItemCode = c.ItemCode AND a.SysNumber = c.SysNumber ";
            sql += "                            GROUP BY b.ItemCode, a.SysNumber, b.ApplyType, b.ApplyEntry, b.ApplyLine, b.LocCode, b.StockEff ";
            sql += "                            HAVING(SUM(b.DocQty) <> 0) OR ";
            sql += "                                             (SUM(b.DefinedQty) <> 0) OR ";
            sql += "                                             (SUM(b.DocQty) = 0) AND(b.StockEff = 2) AND(MIN(b.BaseType) <> 17) AND(MIN(b.BaseType) <> 13)) AS c ON a.DocEntry = c.BaseEntry AND ";
            sql += "                      c.BaseType = 20 ";
            sql += "left join OBTN f on f.ItemCode = b.ItemCode and f.DistNumber = convert(varchar(100), c.BatchNum) ";
            sql += "left join vista_Seguimiento_Recepcion d on d.DocEntry_Recepcion = a.DocEntry ";

            sql += "where b.ItemCode = 'FS.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01' ";

            sql += "and year(a.CreateDate ) = " + d_Anho + " ";
            //sql += "order by a.CreateDate ";
            sql += "order by d.Fecha_Romana , a.CreateDate  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


        }



        public void Consultar_Lista_de_guiasinternas_dys(string status, string c_lote)
        {
            string sql;

            sql = "";

            if (status=="R")
            {
                sql = "select ";
                sql += "t4.CardName , t0.Variedad_Lote as Variedad , t2.U_ItemCode_Referencia , t7.ItemName as TipoEnvase , ";
                sql += "sum(t1.Kilos) as Saldo_kilos , ";
                sql += "sum(t1.Bins) as Total_Bins , ";
                sql += "sum(t1.Bins - (t2.U_VOLTEADOS + coalesce ( t6.Bins_traslado , 0 ))) as Saldo_Bins ";

                sql += "from vista_ProcesosProductivos t0 ";
                sql += "inner join vista_inventario_lotes_completa t1 on t1.ItemCode = t0.ItemCode and t1.DistNumber = t0.Lote and t1.Kilos > 0 and t1.U_temporada >= 2021 ";
                sql += "inner join OBTN t2 on t2.ItemCode = t1.ItemCode and t2.DistNumber = t1.DistNumber ";
                sql += "inner join OWOR t3 with (nolock) on t3.DocNum = t0.OrdenAfecta and t3.U_VID_InEm <> ''  "; // and t3.U_VID_LoFa = 'Recibe_MP' ";
                sql += "left join OPOR t4 with (nolock) on t4.DocNum = t3.U_VID_InEm ";
                sql += "left join POR1 t5 with (nolock) on t5.DocEntry = t4.DocEntry ";
                sql += "left join ( select Object as Lote , sum(U_CantidadBins) as Bins_traslado from [@HDV_ROM1] ";
                sql += "where Object not in ( '0' ) and U_Det_Vigente != 'N' group by Object ) t6 on t6.Lote = t0.Lote ";
                sql += "left join OITM t7 with (nolock) on t7.ItemCode = t2.U_ItemCode_Referencia ";

                sql += "where t0.TipoDocto = 'ReporteProduccion' ";
                sql += "and t0.ItemCode = 'FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01' ";
                //sql += "and t0.OrdenAfecta in (select DocNum from OWOR where U_VID_LoFa = 'Recibe_MP' )  ";

                sql += "group by t4.CardName , t0.Variedad_Lote  , t2.U_ItemCode_Referencia , t7.ItemName ";
                sql += "order by t4.CardName ";

            }

            if (status == "L")
            {

                sql = "select ";
                sql += "t3.U_VID_InEm as NumOC , ";
                sql += "t4.CardCode , t4.CardName , t4.DocDate , t2.U_ItemCode_Referencia , ";
                sql += "t5.ItemCode , t5.Dscription as ItemName , t8.ItemName as TipoEnvase , ";
                sql += "t0.Lote , t0.OrdenAfecta , t5.U_HDV_VARIEDAD as Variedad , ";
                sql += "t0.Quantity as Kilos_totales , t1.Bins as Total_bins , ";
                sql += "round ( t0.Quantity / t1.Bins , 2 ) as Kilos_x_bins , ";
                sql += "(t1.Bins - (t2.U_VOLTEADOS + coalesce ( t6.Bins_traslado , 0 ))) as Saldo_Bins , t1.Kilos as Kilos_pendientes , ";
                sql += "coalesce ( t0.U_Codigo_CSG , '' ) as U_Codigo_CSG ";

                sql += "from vista_ProcesosProductivos t0 ";
                sql += "join vista_inventario_lotes_completa t1 on t1.ItemCode = t0.ItemCode and t1.DistNumber = t0.Lote and t1.Kilos > 0 and t1.U_temporada >= 2021 ";
                sql += "inner join OBTN t2 with (nolock) on t2.ItemCode = t1.ItemCode and t2.DistNumber = t1.DistNumber ";
                sql += "inner join OWOR t3 with (nolock) on t3.DocNum = t0.OrdenAfecta and t3.U_VID_InEm  <> ''  "; // and t3.U_VID_LoFa = 'Recibe_MP' ";
                sql += "left join OPOR t4 with (nolock) on t4.DocNum = t3.U_VID_InEm  ";
                sql += "left join POR1 t5 with (nolock) on t5.DocEntry = t4.DocEntry and t5.U_HDV_VARIEDAD = t0.Variedad_Lote ";

                sql += "left join ( select Object as Lote , sum(U_CantidadBins) as Bins_traslado from [@HDV_ROM1] ";
                sql += "where Object not in ( '0' ) and U_Det_Vigente != 'N' group by Object ) t6 on t6.Lote = t0.Lote ";

                sql += "left join OITM t8 with (nolock) on t8.ItemCode = t2.U_ItemCode_Referencia ";

                sql += "where t0.TipoDocto = 'ReporteProduccion' ";
                sql += "and t0.ItemCode = 'FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01' ";
                //sql += "and t0.OrdenAfecta in (select DocNum from OWOR where U_VID_LoFa = 'Recibe_MP' )  ";

                sql += "order by t0.U_NOMBPROD ";

            }

            if (status == "D")
            {

                sql = "select ";
                sql += "t3.U_VID_InEm as NumOC , ";
                sql += "t4.CardCode , t4.CardName , t4.DocDate , ";
                sql += "t5.ItemCode , t5.Dscription as ItemName , ";
                sql += "t0.Lote , t0.OrdenAfecta , t5.U_HDV_VARIEDAD as Variedad , ";
                sql += "t0.Quantity as Kilos_totales , t1.Bins as Total_bins , ";
                sql += "round ( t0.Quantity / t1.Bins , 2 ) as Kilos_x_bins , ";
                sql += "(t1.Bins - (t2.U_VOLTEADOS + coalesce ( t7.Bins_traslado , 0 )) ) as Saldo_Bins , t1.Kilos as Kilos_pendientes , ";
                sql += "t2.U_ItemCode_Referencia , convert ( int , t6.BWeight1 ) as PesoInt , ";
                sql += "coalesce ( t2.U_Codigo_CSG , '' ) as U_Codigo_CSG ";

                sql += "from vista_ProcesosProductivos t0 ";
                sql += "join vista_inventario_lotes_completa t1 on t1.ItemCode = t0.ItemCode and t1.DistNumber = t0.Lote and t1.Kilos > 0 and t1.U_temporada >= 2021 ";
                sql += "inner join OBTN t2 with (nolock) on t2.ItemCode = t1.ItemCode and t2.DistNumber = t1.DistNumber ";
                sql += "inner join OWOR t3 with (nolock) on t3.DocNum = t0.OrdenAfecta "; // and t3.U_VID_LoFa = 'Recibe_MP' ";
                sql += "left join OPOR t4 with (nolock) on t4.DocNum = t3.U_VID_InEm  ";
                sql += "left join POR1 t5 with (nolock) on t5.DocEntry = t4.DocEntry and t5.U_HDV_VARIEDAD = t2.U_HDV_VARIEDAD ";
                sql += "left join OITM t6 with (nolock) on t6.ItemCode = t2.U_ItemCode_Referencia ";
                sql += "left join ( select Object as Lote , sum(U_CantidadBins) as Bins_traslado from [@HDV_ROM1] ";

                sql += "where Object not in ( '0' ) and U_Det_Vigente != 'N' group by Object ) t7 on t7.Lote = t0.Lote ";

                sql += "where t0.TipoDocto = 'ReporteProduccion' ";
                sql += "and t0.ItemCode = 'FS.NUE.PT.SECA.XXX.X.XXX-XXX.XXX.G.0001K.01' ";
                //sql += "and t0.OrdenAfecta in (select DocNum from OWOR where U_VID_LoFa = 'Recibe_MP' )  ";
                sql += "and t0.Lote = '" + c_lote + "' ";

            }

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void informe_binsproductores(string d_accion, string d_cardcode)
        {
            string sql;

            sql = "exec xSapb1_utiles_informe_binsproductores '" + d_accion + "' , '" + d_cardcode + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void xSapb1_utiles_resumen_televisor_ncc(int d_temporada, string d_fecha , string d_accion, string d_turno)
        {
            string sql;

            sql = "exec xSapb1_utiles_resumen_televisor_ncc " + d_temporada + " , '" + d_fecha + "' , '" + d_accion + "' , '" + d_turno + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void xSapb1_utiles_resumen_nivel_stock()
        {
            string sql;

            sql = "exec xSapb1_utiles_resumen_nivel_stock ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_stock_ItemCode_Lote(string ItemCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t0.DistNumber , t0.AbsEntry , ";
            sql += "t0.InDate , t1.Quantity , t1.WhsCode , t1.Quantity as AllocQty , "; //t2.AllocQty 

            //sql += "coalesce ( ( select sum(ta0.AllocQty) from ITL1 ta0 ";
            //sql += "inner join OITL ta1 on ta1.LogEntry = ta0.LogEntry and ta1.LocCode = t1.WhsCode ";
            //sql += "Where ta0.ItemCode = t0.ItemCode and ta0.MdAbsEntry = t0.DistNumber ";
            //sql += "group by ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry ) , 0 ) as AllocQty , ";

            sql += "t0.U_Fumigado , t0.U_FechaFumigacion , ";
            sql += "coalesce ( ( select top 1 ta0.DocEntry from [@HDV_ORCAL] ta0 where ta0.U_NoLote = t0.DistNumber ) , 0 ) as id_calidad , ";
            sql += "coalesce ( ( select top 1 ta0.U_DocEntry_Ref from [@HDV_ORCAL] ta0 where ta0.U_NoLote = t0.DistNumber order by ta0.DocEntry  ) , 0 ) as U_DocEntry_Ref , ";
            sql += "coalesce ( ( select top 1 ta0.U_LineId_Ref from [@HDV_ORCAL] ta0 where ta0.U_NoLote = t0.DistNumber order by ta0.DocEntry  ) , 0 ) as U_LineId_Ref , ";
            sql += "t0.U_NOMBPROD , t0.U_NOMBCLI , coalesce ( t4.Descr , '' ) as nom_tipoLote , ";
            sql += "coalesce ( t0.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "coalesce ( t0.U_Calibre , '' ) as U_Calibre , ";
            sql += "coalesce ( t0.U_HDV_COLOR , '' ) as U_Color , t0.ItemName , coalesce ( t0.LotNumber , '' )  as CodCliente , ";
            sql += "case when t5.Code is null then 'SI' else 'NO' end as AgrupaLotes , coalesce ( t0.MnfSerial , '' )  as CodProductor , ";
            sql += "coalesce ( t0.U_HDV_CLASIFICACION , '' ) as U_HDV_CLASIFICACION ";

            sql += "from OBTN t0 ";
            sql += "inner join vista_inventario_lotes_completa t1 on t1.ItemCode = t0.ItemCode and t1.DistNumber = convert(varchar(20),t0.AbsEntry) and t1.Quantity > 0  ";

            //sql += "inner join ( select ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry , sum(ta0.Quantity) as Quantity , sum(ta0.AllocQty) as AllocQty ";
            //sql += "from ITL1 ta0 inner join OITL ta1 on ta1.LogEntry = ta0.LogEntry ";
            //sql += "group by ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry ) t2 on t2.ItemCode = t0.ItemCode and t2.LocCode = t1.WhsCode ";
            //sql += "and t2.MdAbsEntry = t0.AbsEntry and t2.AllocQty = 0 ";

            sql += "left join UFD1 t4 on t4.TableID = 'OBTN' and t4.FieldID = 1 and t4.FldValue = t0.U_tipoLote  ";
            sql += "left join [@HDV_OCRX] t5 on t5.U_CODCLI = t0.LotNumber and t5.U_CODPROD = t0.MnfSerial ";


            sql += "where t0.Status = 0 ";
            sql += "and t1.WhsCode  not in ( 'LABCC' , 'RCALIDAD' ) ";
            sql += "and t0.ItemCode = '" + ItemCode + "' ";
            sql += "order by t0.InDate desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_stock_ItemCode_Pallet(string ItemCode, string WhsCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t0.U_FolioPallet , sum(t1.Quantity) as Quantity , t1.WhsCode , sum(t2.AllocQty) as AllocQty ";

            sql += "from OBTN t0 ";
            sql += "inner join OBTQ t1 on t1.ItemCode = t0.ItemCode and t1.MdAbsEntry = t0.AbsEntry and t1.Quantity > 0  ";

            sql += "inner join ( select ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry , sum(ta0.Quantity) as Quantity , sum(ta0.AllocQty) as AllocQty ";
            sql += "from ITL1 ta0 inner join OITL ta1 on ta1.LogEntry = ta0.LogEntry ";
            sql += "group by ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry ) t2 on t2.ItemCode = t0.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "and t2.MdAbsEntry = t0.AbsEntry and t2.AllocQty = 0 ";

            sql += "where t0.Status = 0 ";
            sql += "and t1.WhsCode = '" + WhsCode + "' ";
            sql += "and t0.ItemCode = '" + ItemCode + "' ";

            sql += "group by t0.ItemCode , t0.U_FolioPallet , t1.WhsCode  ";

            sql += "order by t0.U_FolioPallet ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_stock_ItemCode_Pallet_Lote(string ItemCode, string WhsCode, string FolioPallet)
        {
            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t0.U_FolioPallet , t0.DistNumber , t0.AbsEntry ,  ";
            sql += "t1.Quantity , t1.WhsCode , t2.AllocQty  ";

            sql += "from OBTN t0 ";
            sql += "inner join OBTQ t1 on t1.ItemCode = t0.ItemCode and t1.MdAbsEntry = t0.AbsEntry and t1.Quantity > 0  ";

            sql += "inner join ( select ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry , sum(ta0.Quantity) as Quantity , sum(ta0.AllocQty) as AllocQty ";
            sql += "from ITL1 ta0 inner join OITL ta1 on ta1.LogEntry = ta0.LogEntry ";
            sql += "group by ta0.ItemCode , ta1.LocCode  , ta0.MdAbsEntry ) t2 on t2.ItemCode = t0.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "and t2.MdAbsEntry = t0.AbsEntry and t2.AllocQty = 0 ";

            sql += "where t0.Status = 0 ";
            sql += "and t1.WhsCode = '" + WhsCode + "' ";
            sql += "and t0.ItemCode = '" + ItemCode + "' ";
            sql += "and t0.U_FolioPallet = '" + FolioPallet + "' ";

            sql += "order by t0.DistNumber ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Lotes_x_ReciboProduccion(int nDocEntry)
        {
            string sql;

            sql = "select ta1.* ";
            sql += "from OITL ta0 ";
            sql += "inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry ";
            sql += "where ta0.DocType = 59 ";
            sql += "and ta0.DocEntry = " + nDocEntry.ToString();

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lotes_Asignados_para_Consumir(int nDocEntry)
        {
            string sql;

            sql = "select ";
            sql += "T0.ItemCode, T0.ItemName,  sum(T1.AllocQty) as AllocQty  , T1.MdAbsEntry, T2.DistNumber, ";
            sql += "T2.[U_BINS][Bins], T2.[U_VOLTEADOS][Volteados], T2.MnfSerial, T2.LotNumber, ";
            sql += "T0.LocCode , t3.LineNum  , coalesce ( ( select top 1 ta1.Quantity from OBTQ ta1 where ta1.ItemCode = T0.ItemCode and ta1.WhsCode = T0.LocCode and  convert ( varchar(20) , ta1.MdAbsEntry ) = T2.DistNumber ) , 0 ) as QuantityIni , ";
            sql += "T2.U_NOMBPROD , T2.U_NOMBCLI , coalesce ( T2.U_Codigo_CSG , '' ) as U_Codigo_CSG , coalesce ( T2.U_Tipo_Cosecha , '' ) as U_Tipo_Cosecha ";

            sql += "FROM OITL T0 ";
            sql += "INNER JOIN ITl1 T1 ON T1.LogEntry = T0.LogEntry ";
            sql += "INNER JOIN OBTN T2 ON T2.AbsEntry = T1.MdAbsEntry ";
            sql += "INNER JOIN WOR1 T3 ON T3.DocEntry = T0.DocEntry AND T3.ItemCode = T0.ItemCode and T3.PlannedQty > 0 and t3.LineNum = t0.DocLine  ";

            sql += "Where T0.DocType = '202' ";
            sql += "and T0.DocEntry = " + nDocEntry + " ";
            //sql += "and T2.DistNumber = '3556612' ";
            //sql += "AND T1.AllocQty > 0 ";

            sql += "group by T0.ItemCode, T0.ItemName, T1.MdAbsEntry, T2.DistNumber, T2.[U_BINS], T2.[U_VOLTEADOS], T2.MnfSerial, T2.LotNumber, T0.LocCode , t3.LineNum , T2.U_NOMBPROD , T2.U_NOMBCLI , T2.U_Codigo_CSG , T2.U_Tipo_Cosecha ";

            sql += "order by t1.MdAbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lotes_Asignados_para_Consumir_x_of(int nLote)
        {
            string sql;

            sql = "select ";
            sql += "T0.DocEntry , T0.ItemCode, T0.ItemName,  sum(T1.AllocQty) as AllocQty  , T1.MdAbsEntry, T2.DistNumber, ";
            sql += "T2.[U_BINS][Bins], T2.[U_VOLTEADOS][Volteados], T2.MnfSerial, T2.LotNumber, ";
            sql += "T0.LocCode , t3.LineNum  , coalesce ( ( select top 1 ta1.Quantity from OBTQ ta1 where ta1.ItemCode = T0.ItemCode and ta1.WhsCode = T0.LocCode and  convert ( varchar(20) , ta1.MdAbsEntry ) = T2.DistNumber ) , 0 ) as QuantityIni , ";
            sql += "T2.U_NOMBPROD , T2.U_NOMBCLI , t3.StartDate ";

            sql += "FROM OITL T0 ";
            sql += "INNER JOIN ITl1 T1 ON T1.LogEntry = T0.LogEntry ";
            sql += "INNER JOIN OBTN T2 ON T2.AbsEntry = T1.MdAbsEntry ";
            sql += "INNER JOIN WOR1 T3 ON T3.DocEntry = T0.DocEntry AND T3.ItemCode = T0.ItemCode and T3.PlannedQty > 0 and t3.LineNum = t0.DocLine  ";

            sql += "Where T0.DocType = '202' ";
            sql += "and T2.DistNumber = '" + nLote.ToString() + "' ";
            //sql += "and T2.DistNumber = '3556612' ";
            //sql += "AND T1.AllocQty > 0 ";

            sql += "group by T0.DocEntry , T0.ItemCode, T0.ItemName, T1.MdAbsEntry, T2.DistNumber, T2.[U_BINS], T2.[U_VOLTEADOS], T2.MnfSerial, T2.LotNumber, T0.LocCode , t3.LineNum , T2.U_NOMBPROD , T2.U_NOMBCLI , t3.StartDate ";

            sql += "order by t1.MdAbsEntry , t3.StartDate desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consultar_insumos_Asignados_para_Consumir(int nDocEntry)
        {
            string sql;

            sql = "select ";
            sql += "t3.LineNum , t3.ItemCode , t0.ItemName , ";
            sql += "t3.PlannedQty , t3.IssuedQty , t3.wareHouse  ";

            sql += "from WOR1 t3  ";
            sql += "inner join OITM t0 on t0.ItemCode = t3.ItemCode  ";
            sql += "inner join OITB t1 on t1.ItmsGrpCod = t0.ItmsGrpCod and t1.U_Familia in ( 'Insumos' , 'n/a' )  ";

            sql += "Where t3.DocEntry = " + nDocEntry + " ";
            sql += "and t3.PlannedQty > 0 ";
            sql += "and substring(t3.ItemCode, 1, 5) <> 'PROC_' ";
            sql += "order by t3.LineNum ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Planifacadas(string status)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,   ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse ,  ";
            sql += "t0.PlannedQty , t0.CmpltQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments ,  ";
            sql += "t2.U_NAME as NomResponsable ,  ";
            sql += "t3.Ref_OF as Ref_OF_SOL ,  t0.DocNum as DocNum_SOL ,  t3.Quantity as Quantity_SOL ,  t3.OpenQty as OpenQty_SOL , "; // t3.DocNum as DocNum_SOL
            sql += "t4.Ref_OF as Ref_OF_TRAS , t0.DocNum as DocNum_TRAS , t4.Quantity as Quantity_TRAS , t4.OpenQty as OpenQty_TRAS , "; // t4.DocNum as DocNum_TRAS
            sql += "coalesce ( ( select top 1 ta1.DocNum from [@HDV_OWOR] ta1 where ta1.DocNum = t0.DocNum ) , 0 ) as DocNum_Coordinado , ";
            sql += "coalesce ( t5.Cantidades_Asignadas , 0 ) as OpenQty_Asignadas , t0.U_Proceso ";
            sql += " ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign  ";
            sql += "left join ( select substring ( t0.Comments , 47 , 5 ) as Ref_OF , sum(t1.Quantity) as Quantity , "; // t0.DocEntry , t0.DocNum , t0.DocDate , 
            sql += "sum(t1.OpenQty) as  OpenQty  ";

            sql += "from OWTQ t0 ";
            sql += "inner join WTQ1 t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "group by substring ( t0.Comments , 47 , 5 )   ) t3 on t3.Ref_OF = convert ( varchar(5) , t0.DocNum ) "; // , t0.DocEntry , t0.DocNum , t0.DocDate

            sql += "left join ( select substring ( t0.Comments , 47 , 5 ) as Ref_OF , sum(t1.Quantity) as Quantity , sum(t1.OpenQty) as  OpenQty "; // t0.DocEntry , t0.DocNum , t0.DocDate  , 
            sql += "from OWTR t0  ";
            sql += "inner join WTR1 t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "group by substring ( t0.Comments , 47 , 5 )  ) t4 on t4.Ref_OF = convert ( varchar(5) , t0.DocNum ) "; // , t0.DocEntry , t0.DocNum , t0.DocDate 

            sql += "left join ( select T0.DocEntry , SUM(t1.AllocQty)  as Cantidades_Asignadas ";
            sql += "from OITL T0 inner join ITl1 T1 ON T1.LogEntry = T0.LogEntry Where T0.DocType = '202' group by T0.DocEntry ) t5 on t5.DocEntry = t0.DocEntry ";
            sql += " ";

            sql += "where t0.Status like '" + status + "' ";
            sql += "order by t0.DocEntry desc ";
            sql += " ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Planifacadas_con_insumos(string status)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.PostDate , t0.StartDate , t0.DueDate ,   ";
            sql += "t0.ItemCode , t1.ItemName , t1.InvntryUom , t0.UserSign , t0.Warehouse ,  ";
            sql += "t0.PlannedQty , t0.CmpltQty , t0.OriginNum , t0.CardCode , t0.Project , t0.Comments ,  ";
            sql += "t2.U_NAME as NomResponsable ,  ";
            sql += "t3.Ref_OF as Ref_OF_SOL ,  t0.DocNum as DocNum_SOL ,  t3.Quantity as Quantity_SOL ,  t3.OpenQty as OpenQty_SOL , ";
            sql += "t4.Ref_OF as Ref_OF_TRAS , t0.DocNum as DocNum_TRAS , t4.Quantity as Quantity_TRAS , t4.OpenQty as OpenQty_TRAS , "; 
            sql += "coalesce ( ( select top 1 ta1.DocNum from [@HDV_OWOR] ta1 where ta1.DocNum = t0.DocNum ) , 0 ) as DocNum_Coordinado , ";
            sql += "coalesce ( t5.Cantidades_Asignadas , 0 ) as OpenQty_Asignadas , t0.U_Proceso , ";
            sql += "t6.ItemCode as ItemCode_I , t7.ItemName as ItemName_I , t6.PlannedQty as PlannedQty_I  , ";
            sql += "t6.IssuedQty as IssuedQty_I , coalesce ( t8.OnHand , 0 ) as OnHand_I , t6.WareHouse  ";

            sql += "from OWOR t0 ";
            sql += "left join OITM t1 on t1.ItemCode = t0.ItemCode ";
            sql += "left join OUSR t2 on t2.USERID = t0.UserSign  ";
            sql += "left join ( select substring ( t0.Comments , 47 , 4 ) as Ref_OF , sum(t1.Quantity) as Quantity , ";  
            sql += "sum(t1.OpenQty) as  OpenQty  ";

            sql += "from OWTQ t0 ";
            sql += "inner join WTQ1 t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "group by substring ( t0.Comments , 47 , 4 )   ) t3 on t3.Ref_OF = convert ( varchar(4) , t0.DocNum ) "; 

            sql += "left join ( select substring ( t0.Comments , 47 , 4 ) as Ref_OF , sum(t1.Quantity) as Quantity , sum(t1.OpenQty) as  OpenQty "; 
            sql += "from OWTR t0  ";
            sql += "inner join WTR1 t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "group by substring ( t0.Comments , 47 , 4 )  ) t4 on t4.Ref_OF = convert ( varchar(4) , t0.DocNum ) "; 

            sql += "left join ( select T0.DocEntry , SUM(t1.AllocQty)  as Cantidades_Asignadas ";
            sql += "from OITL T0 inner join ITl1 T1 ON T1.LogEntry = T0.LogEntry Where T0.DocType = '202' group by T0.DocEntry ) t5 on t5.DocEntry = t0.DocEntry ";

            sql += "inner join WOR1 t6 on t6.ItemCode in ( select ItemCode from OITM where ItmsGrpCod = '236' and ManBtchNum = 'Y' ) and t6.DocEntry = t0.DocEntry ";
            sql += "inner join OITM t7 on t7.ItemCode = t6.ItemCode ";
            sql += "left join OITW t8 on t8.ItemCode = t7.ItemCode and t8.WhsCode = t6.wareHouse ";
            sql += " ";

            sql += "where t0.Status like '" + status + "' ";
            sql += "order by t0.DocEntry desc ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Solicitudes_Planifacadas(string status)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.UserSign , t2.U_NAME ,  ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , t1.Quantity , t1.OpenQty , ";
            sql += "t0.ToWhsCode , t1.WhsCode , t1.FromWhsCod , ";
            sql += "substring(t0.Comments, 47, 4) as Ref_OF , t1.WhsCode , t1.FromWhsCod , ";
            sql += "t1.LineNum , t3.MdAbsEntry , t4.DistNumber  ";
            sql += " ";
            sql += " ";

            sql += "from OWTQ t0 ";
            sql += "inner join WTQ1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join OUSR t2 on t2.USERID = t0.UserSign ";

            sql += "inner join (select ta0.DocEntry, ta0.ApplyLine, ta1.ItemCode, ta1.MdAbsEntry ";
            sql += "from OITL ta0 ";
            sql += "inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry ";
            sql += "where ta0.DocType = 1250000001 ) t3 on t3.DocEntry = t0.DocEntry  and t3.ApplyLine = t1.LineNum and t3.ItemCode = t1.ItemCode ";
            sql += "left join OBTN t4 on t4.AbsEntry = T3.MdAbsEntry ";
            sql += " ";
            sql += " ";
            sql += " ";

            sql += "where substring(t0.Comments, 47, 4) in (select convert(varchar(4), DocNum) from[@HDV_OWOR] )   ";
            sql += "order by t0.DocEntry ";
            //sql += "where t0.Status like '" + status + "' ";

            sql += " ";
            sql += " ";
            sql += " ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OrdenFabricacion_Max_Linea(int nDocEntry)
        {
            string sql;

            sql = "select max(LineNum) as LineNum ";
            sql += "from WOR1 ";
            sql += "where DocEntry = " + nDocEntry + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumos_Max_DocEntry()
        {
            string sql;

            sql = "select coalesce ( max(DocEntry) , 0 ) as DocEntry ";
            sql += "from [@HDV_OINS] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumosv2_Max_DocEntry()
        {
            string sql;

            sql = "select coalesce ( max(DocEntry) , 0 ) as DocEntry ";
            sql += "from [@HDV_OINSS] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumos_x_DocEntry(int nDocEntry)
        {
            string sql;

            sql = "select "; 
            sql += "t0.DocEntry , t0.DocNum , t0.UserSign , t0.Status , t0.CreateDate , t0.U_Turno , t0.U_Autorizador , t0.U_Area , t0.U_Obs as U_Obs_Cab , ";
            sql += "t0.U_WhsCode as WhsCodeCab ,  t1.* , t2.ItemName , coalesce ( t3.U_NAME , '' ) as UserSign_Name , coalesce ( t4.U_NAME , '' ) as Autorizador_Name , ";
            sql += "case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then 'Procesado' end as Status_Name , ";
            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , t2.InvntryUom , ";
            sql += "coalesce ( t7.DocDate , '' ) as Fecha_Salida , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 1 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode ) , '' ) as OcrCode_Ref1 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 2 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode2 ) , '' ) as OcrCode_Ref2 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 3 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode3 ) , '' ) as OcrCode_Ref3 , ";

            sql += "coalesce ( ( select top 1 ta2.OcrCode from IGE1 ta2 where ta2.DocEntry = t7.DocEntry ) , '' ) as OcrCode_ige1 , ";
            sql += "coalesce ( ( select top 1 ta2.OcrCode2 from IGE1 ta2 where ta2.DocEntry = t7.DocEntry ) , '' ) as OcrCode_ige2 , ";
            sql += "coalesce ( ( select top 1 ta2.OcrCode3 from IGE1 ta2 where ta2.DocEntry = t7.DocEntry ) , '' ) as OcrCode_ige3 , ";
            sql += "coalesce ( ( select top 1 ta2.Number from OJDT ta2 where ta2.BaseRef = t1.U_DocEntry ) , '' ) as Number_ojdt ";
            sql += " ";

            sql += "from [@HDV_OINS] t0 ";
            sql += "left join [@HDV_INS1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join OITM t2 on t2.ItemCode = t1.U_ItemCode ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OUSR t4 on t4.USERID = t0.U_Autorizador ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID  ";
            sql += "left join OIGE t7 on t7.DocEntry = t1.U_DocEntry ";

            sql += "where t0.DocEntry = " + nDocEntry + " ";
            sql += "order by t1.LineId ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumosv2_x_DocEntry(int nDocEntry)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.UserSign , t0.Status , t0.CreateDate , t0.U_Turno , t0.U_Autorizador , t0.U_Area , t0.U_Obs as U_Obs_Cab , ";
            sql += "t0.U_WhsCode as WhsCodeCab ,  t1.* , t2.ItemName , coalesce ( t3.U_NAME , '' ) as UserSign_Name , coalesce ( t4.U_NAME , '' ) as Autorizador_Name , ";
            sql += "case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then case when coalesce ( ta0.DocStatus , '' ) = 'C' then 'Cerrado' else 'Procesado' end end as Status_Name , ";

            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , t2.InvntryUom , ";
            sql += "coalesce ( t7.DocDate , '' ) as Fecha_Salida , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 1 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode ) , '' ) as OcrCode_Ref1 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 2 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode2 ) , '' ) as OcrCode_Ref2 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 3 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode3 ) , '' ) as OcrCode_Ref3  , ";

            sql += "coalesce ( t0.U_DocEntryRef , 0 ) as U_DocEntryRef , ta1.Quantity - ta1.OpenQty as Cant_Recibida ";
            sql += " ";

            sql += "from [@HDV_OINSS] t0 ";
            sql += "left join [@HDV_INSS1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join OITM t2 on t2.ItemCode = t1.U_ItemCode ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OUSR t4 on t4.USERID = t0.U_Autorizador ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID  ";
            sql += "left join OIGE t7 on t7.DocEntry = t1.U_DocEntry ";
            sql += "left join OWTQ ta0 on ta0.DocEntry = t0.U_DocEntryRef ";
            sql += "left join WTQ1 ta1 on ta1.DocEntry = ta0.DocEntry and ta1.LineNum = t1.U_LineId_Ref  ";
            sql += " ";

            sql += "where t0.DocEntry = " + nDocEntry + " ";
            sql += "order by t1.LineId ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumosv3_x_DocEntry(int nDocEntry)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.UserSign , t0.Status , t0.CreateDate , t0.U_Turno , t0.U_Autorizador , t0.U_Area , t0.U_Obs as U_Obs_Cab , ";
            sql += "t0.U_WhsCode as WhsCodeCab ,  t1.* , t2.ItemName , coalesce ( t3.U_NAME , '' ) as UserSign_Name , coalesce ( t4.U_NAME , '' ) as Autorizador_Name , ";
            sql += "case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then case when coalesce ( ta0.DocStatus , '' ) = 'C' then 'Cerrado' else 'Procesado' end end as Status_Name , ";
            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , t2.InvntryUom , ";
            sql += "coalesce ( t7.DocDate , '' ) as Fecha_Salida , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 1 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode ) , '' ) as OcrCode_Ref1 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 2 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode2 ) , '' ) as OcrCode_Ref2 , ";

            sql += "coalesce ( ( select ta1.OcrCode from OOCR ta1 where ta1.DimCode = 3 and ta1.Active = 'Y' ";
            sql += "and ta1.OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() ) ";
            sql += "and ta1.OcrCode = t1.U_OcrCode3 ) , '' ) as OcrCode_Ref3  , ";

            sql += "coalesce ( t0.U_DocEntryRef , 0 ) as U_DocEntryRef , ta1.Quantity , ta1.OpenQty , ";

            sql += "coalesce ( ( select sum(tb1.Quantity) from WTR1 tb1 where tb1.BaseEntry = ta1.DocEntry and tb1.BaseLine = ta1.LineNum ) , 0 ) as Cant_Recibida ,  ";

            sql += "ta2.DocNum as DocEntry_Transferencia , ta2.LineNum as LineNum_Transferencia , ta2.ItemCode as ItemCode_Transferencia , ta2.Quantity as Quantity_Transferencia ,  ";
            sql += "ta2.DocDate as DocDate_Transferencia , ta3.DocEntry as DocEntry_Salida , ta4.TransId as TransId_RegistroDiario ";
            sql += " ";

            sql += "from [@HDV_OINSS] t0 ";
            sql += "left join [@HDV_INSS1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join OITM t2 on t2.ItemCode = t1.U_ItemCode ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OUSR t4 on t4.USERID = t0.U_Autorizador ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID  ";
            sql += "left join OIGE t7 on t7.DocEntry = t1.U_DocEntry ";

            sql += "inner join OWTQ ta0 on ta0.DocEntry = t0.U_DocEntryRef ";
            sql += "inner join WTQ1 ta1 on ta1.DocEntry = ta0.DocEntry and ta1.LineNum = t1.U_LineId_Ref and ta1.ItemCode = t1.U_ItemCode ";

            sql += "left join (select ta1.DocNum , ta1.DocEntry, ta2.BaseRef, ta2.LineNum, ta2.BaseLine, ta2.ItemCode, ta2.Quantity, ta2.DocDate  from OWTR ta1 ";
            sql += "inner join WTR1 ta2 on ta2.DocEntry = ta1.DocEntry where ta1.CANCELED = 'N' ) ta2 on ta2.BaseRef = t0.U_DocEntryRef and ta2.BaseLine = t1.U_LineId_Ref ";

            sql += "left join (select ta1.DocEntry, ta1.Comments, ta2.LineNum, ta2.ItemCode, ta2.Quantity from OIGE ta1 ";
            sql += "inner join IGE1 ta2 on ta2.DocEntry = ta1.DocEntry where ta1.CANCELED = 'N' ) ta3 on ta3.Comments like '%solicitud #' + convert(varchar(6), coalesce(t0.U_DocEntryRef, 0)) and ta3.ItemCode = ta2.ItemCode ";

            sql += "left join (select TransId, Ref1, RefDate from OJDT) ta4 on ta4.Ref1 = convert(varchar(15), ta3.DocEntry) ";
            sql += " ";

            sql += "where t0.DocEntry = " + nDocEntry + " ";
            sql += "order by t1.LineId ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consultar_DeclaracionInsumos_x_FechaTurnoArea(string cFecha, int nTurno, int nArea)
        {
            string sql;

            sql = "select t0.* ";

            sql += "from [@HDV_OINS] t0 ";
            sql += "where t0.CreateDate = '" + cFecha  + "' ";
            sql += "and t0.U_Turno = " + nTurno.ToString() + " ";
            sql += "and t0.U_Area = " + nArea.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_DeclaracionInsumosv2_x_FechaTurnoArea(string cFecha, int nTurno, int nArea)
        {
            string sql;

            sql = "select t0.* ";

            sql += "from [@HDV_OINSS] t0 ";
            sql += "where t0.CreateDate = '" + cFecha + "' ";
            sql += "and t0.U_Turno = " + nTurno.ToString() + " ";
            sql += "and t0.U_Area = " + nArea.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lista_DeclaracionInsumos(string FechaInicio , string FechaTermino)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.CreateDate , ";
            sql += "t0.Status , case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then 'Procesado' end as Status_Name ,  ";
            sql += "t0.UserSign , coalesce ( t3.U_Name , '' ) as UserSignName , ";
            sql += "t0.U_Turno , coalesce ( t1.Descr , '' ) as U_TurnoName , ";
            sql += "t0.U_Area , coalesce ( t2.Descr , '' ) as U_AreaName , ";
            sql += "coalesce ( ( select count(*) from [@HDV_INS1] t5 where t5.DocEntry = t0.DocEntry ) , 0 ) as Cant_Items , ";
            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , ";
            sql += "t0.U_Autorizador , ";
            sql += "coalesce ( t6.firstName , '' ) + ' ' + coalesce ( t6.lastName , '' ) as Nombre_Autorizador ";

            sql += "from [@HDV_OINS] t0 ";
            sql += "left join UFD1 t1 on t1.TableID = '@HDV_OINS' and t1.FieldID = 0 and t1.FldValue = t0.U_Turno ";
            sql += "left join UFD1 t2 on t2.TableID = '@HDV_OINS' and t2.FieldID = 2 and t2.FldValue = t0.U_Area  ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID ";
            sql += "left join OHEM t6 on t6.USERID = t0.U_Autorizador ";

            sql += "where t0.CreateDate between '" + FechaInicio + "' and '" + FechaTermino + "'  ";
            sql += "order by t0.CreateDate , t2.Descr , t1.Descr  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lista_DeclaracionInsumosv2(string FechaInicio, string FechaTermino)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.CreateDate , t0.Status , ";
            sql += "case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then case when coalesce ( ta0.DocStatus , '' ) = 'C' then 'Cerrado' else 'Procesado' end end as Status_Name ,  ";
            sql += "t0.UserSign , coalesce ( t3.U_Name , '' ) as UserSignName , ";
            sql += "t0.U_Turno , coalesce ( t1.Descr , '' ) as U_TurnoName , ";
            sql += "t0.U_Area , coalesce ( t2.Descr , '' ) as U_AreaName , ";
            sql += "coalesce ( ( select count(*) from [@HDV_INSS1] t5 where t5.DocEntry = t0.DocEntry ) , 0 ) as Cant_Items , ";
            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , ";
            sql += "t0.U_Autorizador , ";
            sql += "coalesce ( t6.firstName , '' ) + ' ' + coalesce ( t6.lastName , '' ) as Nombre_Autorizador , ";
            sql += "coalesce (  t0.U_DocEntryRef , 0 ) as U_DocEntryRef ";

            sql += "from [@HDV_OINSS] t0 ";
            sql += "left join UFD1 t1 on t1.TableID = '@HDV_OINS' and t1.FieldID = 0 and t1.FldValue = t0.U_Turno ";
            sql += "left join UFD1 t2 on t2.TableID = '@HDV_OINS' and t2.FieldID = 2 and t2.FldValue = t0.U_Area  ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID ";
            sql += "left join OHEM t6 on t6.USERID = t0.U_Autorizador ";
            sql += "left join OWTQ ta0 on ta0.DocEntry = t0.U_DocEntryRef ";

            sql += "where t0.CreateDate between '" + FechaInicio + "' and '" + FechaTermino + "'  ";
            sql += "order by t0.CreateDate , t2.Descr , t1.Descr  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Lista_DeclaracionInsumosv3(string FechaInicio, string FechaTermino)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.CreateDate , t0.Status , ";
            sql += "case when t0.Status = '' then 'En Proceso' when t0.Status = 'P' then case when coalesce ( ta0.DocStatus , '' ) = 'C' then 'Cerrado' else 'Procesado' end end as Status_Name ,  ";
            sql += "t0.UserSign , coalesce ( t3.U_Name , '' ) as UserSignName , ";
            sql += "t0.U_Turno , coalesce ( t1.Descr , '' ) as U_TurnoName , ";
            sql += "t0.U_Area , coalesce ( t2.Descr , '' ) as U_AreaName , ";
            sql += "coalesce ( ( select count(*) from [@HDV_INSS1] t5 where t5.DocEntry = t0.DocEntry ) , 0 ) as Cant_Items , ";
            sql += "coalesce ( t5.firstName , '' ) + ' ' + coalesce ( t5.lastName , '' ) as Nombre_Empleado , ";
            sql += "t0.U_Autorizador , ";
            sql += "coalesce ( t6.firstName , '' ) + ' ' + coalesce ( t6.lastName , '' ) as Nombre_Autorizador , ";
            sql += "coalesce (  t0.U_DocEntryRef , 0 ) as U_DocEntryRef , ";
            sql += "coalesce ( ( select count(*) from WTQ1 ta1 where ta1.DocEntry = ta0.DocEntry ) , 0 ) as Cant_OWTQ  ";

            sql += "from [@HDV_OINSS] t0 ";
            sql += "left join UFD1 t1 on t1.TableID = '@HDV_OINS' and t1.FieldID = 0 and t1.FldValue = t0.U_Turno ";
            sql += "left join UFD1 t2 on t2.TableID = '@HDV_OINS' and t2.FieldID = 2 and t2.FldValue = t0.U_Area  ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "left join OHEM t5 on t5.USERID = t3.USERID ";
            sql += "left join OHEM t6 on t6.USERID = t0.U_Autorizador ";
            sql += "inner join OWTQ ta0 on ta0.DocEntry = t0.U_DocEntryRef ";
            sql += " ";

            sql += "where t0.CreateDate between '" + FechaInicio + "' and '" + FechaTermino + "'  ";
            sql += "order by t0.CreateDate , t2.Descr , t1.Descr  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public string Salida_Mercaderia_CO(cldOrdenFabricacion parConsumo)
        {
            string NewObjectKey;

            int lRetCode;

            int errCode;
            string errMsg;

            bool connected = false;

            errCode = -1; errMsg = string.Empty;

            Company oCompany = new Company();

            oCompany.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");

            try
            {
                if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                    oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2012;
                else
                    oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2014;

                oCompany.UseTrusted = false;
                oCompany.DbUserName = "sa";
                oCompany.DbPassword = "SAPB1Admin";
                oCompany.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");
                oCompany.UserName = parConsumo.UsuarioSap;
                oCompany.Password = parConsumo.ClaveSap;
                oCompany.language = BoSuppLangs.ln_Spanish_La;
                oCompany.AddonIdentifier = string.Empty;

                oCompany.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

                lRetCode = -1;

                try
                {
                    lRetCode = oCompany.Connect();
                }
                catch
                {
                    lRetCode = -1;
                }

                if (lRetCode == 0)
                {
                    ////////////////////////////
                    // Conexion Exitosa 
                    connected = true;

                }
                else
                {
                    ////////////////////////////
                    // Error en Conexion !!!!!

                    NewObjectKey = "Error de Conexión";
                    return NewObjectKey;

                }

                ///// crear los lotes para las cajas
                /////                    

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;

            }

            if (connected == false)
            {
                NewObjectKey = errMsg;
                return NewObjectKey;

            }

            SAPbobsCOM.Documents SalidaMercancia;
            SalidaMercancia = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);

            SalidaMercancia.Series = 26;
            SalidaMercancia.DocDate = DateTime.ParseExact(parConsumo.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            //SalidaMercancia.TaxDate = DateTime.ParseExact(fecha, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            if ((parConsumo.CodeCliente == "") && (parConsumo.NombreCliente != ""))
            {
                SalidaMercancia.Comments = parConsumo.NombreCliente;
                SalidaMercancia.JournalMemo = parConsumo.NombreCliente;

            }
            else
            {
                SalidaMercancia.Comments = parConsumo.MensajeC;
                SalidaMercancia.JournalMemo = parConsumo.MensajeC;

            }

            SalidaMercancia.UserFields.Fields.Item("U_Salida_Produccion").Value = parConsumo.SalidaProduccion;

            //SalidaMercancia.Lines.ItemCode = RS.Fields.Item("ItemCode").Value.ToString();
            SalidaMercancia.Lines.Quantity = parConsumo.Quantity;
            SalidaMercancia.Lines.BaseType = 202;
            SalidaMercancia.Lines.BaseEntry = parConsumo.DocEntry;
            SalidaMercancia.Lines.BaseLine = parConsumo.LineNum;
            SalidaMercancia.Lines.WarehouseCode = parConsumo.Warehouse;

            SalidaMercancia.Lines.UserFields.Fields.Item("U_Codigo_CSG").Value = parConsumo.Codigo_CSG;

            //SalidaProduccion

            //SalidaMercancia.Lines.Price = 1.1;
            //SalidaMercancia.Lines.UnitPrice = 1.1;

            //SalidaMercancia.Lines

            SalidaMercancia.Lines.BatchNumbers.BatchNumber = parConsumo.lote;
            SalidaMercancia.Lines.BatchNumbers.Quantity = parConsumo.Quantity;

            errMsg = "";
            errCode = 0;
            NewObjectKey = "s";

            try
            {
                oCompany.StartTransaction();

                if (SalidaMercancia.Add() == 0)
                {
                    errCode = 0;

                    NewObjectKey = oCompany.GetNewObjectKey();

                    if (oCompany.InTransaction)
                        oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                else
                {
                    oCompany.GetLastError(out errCode, out errMsg);

                    if (oCompany.InTransaction)
                        oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    NewObjectKey = errMsg;

                }

            }
            catch (Exception)
            {
                if (oCompany.InTransaction)
                    oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                oCompany.GetLastError(out errCode, out errMsg);

                NewObjectKey = errMsg;

            }

            string sql;

            if (errMsg == "")
            {

                sql = "update OBTN ";
                sql += "set [U_VOLTEADOS] = 0 ";
                sql += "where DistNumber = '" + parConsumo.lote + "' ";
                sql += "and [U_VOLTEADOS] is null ";

                this.ComandoSql = sql;
                this.GestorSqlConsultar();

                sql = "update OBTN ";
                sql += "set [U_VOLTEADOS] = [U_VOLTEADOS] + " + parConsumo.CantidadBins + " ";
                sql += "where DistNumber = '" + parConsumo.lote + "' ";
                sql += "and [U_BINS] >= [U_VOLTEADOS] + " + parConsumo.CantidadBins + " ";

                this.ComandoSql = sql;
                this.GestorSqlConsultar();

            }

            try
            {
                oCompany.Disconnect();
            }
            catch
            {

            }

            return NewObjectKey;

        }

        public string Salida_Mercaderia_CO1(cldOrdenFabricacion parConsumo)
        {

            string NewObjectKey;

            sbo_HDV_P03 = new SAPbobsCOM.Company();
            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";
            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parConsumo.UsuarioSap;
            sbo_HDV_P03.Password = parConsumo.ClaveSap;

            sbo_HDV_P03.Connect();

            ///// crear los lotes para las cajas
            ///// 
            
            SAPbobsCOM.Documents SalidaMercancia;
            SalidaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);

            SalidaMercancia.Series = 26;
            SalidaMercancia.DocDate = DateTime.ParseExact(parConsumo.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            //SalidaMercancia.TaxDate = DateTime.ParseExact(fecha, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            SalidaMercancia.Comments = "CONSUMO PARA PRODUCCION";
            SalidaMercancia.JournalMemo = "CONSUMO PARA PRODUCCION";

            //SalidaMercancia.Lines.ItemCode = RS.Fields.Item("ItemCode").Value.ToString();
            SalidaMercancia.Lines.Quantity = parConsumo.Quantity;
            SalidaMercancia.Lines.BaseType = 202;
            SalidaMercancia.Lines.BaseEntry = parConsumo.DocEntry;
            SalidaMercancia.Lines.BaseLine = parConsumo.LineNum;
            SalidaMercancia.Lines.WarehouseCode = parConsumo.Warehouse;
            //SalidaMercancia.Lines.Price = 1.1;
            //SalidaMercancia.Lines.UnitPrice = 1.1;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

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

            return NewObjectKey;

        }


        public string Production_Orders(cldOrdenFabricacion parOrden)
        {

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;
            ProductionOF.ItemNo = parOrden.ItemCode;
            ProductionOF.PlannedQuantity = parOrden.PlannedQty;
            
            ProductionOF.Warehouse = parOrden.Warehouse;
            ProductionOF.StartDate = DateTime.ParseExact(parOrden.StartDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            ProductionOF.PostingDate = DateTime.ParseExact(parOrden.PostDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            ProductionOF.DueDate = DateTime.ParseExact(parOrden.DueDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            ProductionOF.CustomerCode = parOrden.CardCode;

            //ProductionOF. .UserSignature = parOrden.UserSign; 

            /// +++++++++++++++++++++ En Caso que exista orden de venta se debe tener DocEntry y CardCode

            if (parOrden.OriginNum != 0)
            {
                ProductionOF.ProductionOrderOrigin = SAPbobsCOM.BoProductionOrderOriginEnum.bopooSalesOrder;
                ProductionOF.ProductionOrderOriginEntry = parOrden.OriginNum;
                ProductionOF.CustomerCode = parOrden.CardCode;

            }
            else
            {
                ProductionOF.ProductionOrderOrigin = SAPbobsCOM.BoProductionOrderOriginEnum.bopooManual;

            }

            /// +++++++++++++++++++++

            //ProductionOF.DistributionRule = "Dimension 1";
            //ProductionOF.Project = "Codigo de Proyecto";

            ProductionOF.Remarks = parOrden.Comments;
            //ProductionOF.JournalRemarks = "Comentario de la derecha // Glosa contable";

            ProductionOF.UserFields.Fields.Item("U_Proceso").Value = parOrden.U_Proceso;
            ProductionOF.UserFields.Fields.Item("U_OrdenAfecta").Value = parOrden.U_OrdenAfecta;
            ProductionOF.UserFields.Fields.Item("U_TipoOrden").Value = parOrden.U_TipoOrden;
            ProductionOF.UserFields.Fields.Item("U_TipoFruta").Value = parOrden.U_TipoFruta;

            int nLineId_D;
            string cItemCode_D, cItemName_D, cBodega_D;
            string cIssueMthd_D;
            double nCantidadBase_D, nCantidadRequerida_D, nDisponible_D;

            for (int i = 0; i <= 99; i++)
            {

                try
                {
                    nLineId_D = int.Parse(parOrden.arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = parOrden.arrDetalle[2, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = parOrden.arrDetalle[3, i];
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    nCantidadBase_D = Convert.ToDouble(parOrden.arrDetalle[4, i]);
                }
                catch
                {
                    nCantidadBase_D = 0;
                }

                try
                {
                    nCantidadRequerida_D = Convert.ToDouble(parOrden.arrDetalle[5, i]);
                }
                catch
                {
                    nCantidadRequerida_D = 0;
                }

                try
                {
                    cBodega_D = parOrden.arrDetalle[6, i];
                }
                catch
                {
                    cBodega_D = "";
                }

                try
                {
                    cIssueMthd_D = parOrden.arrDetalle[8, i];
                }
                catch
                {
                    cIssueMthd_D = "";
                }

                try
                {
                    nDisponible_D = Convert.ToDouble(parOrden.arrDetalle[7, i]);
                }
                catch
                {
                    nDisponible_D = 0;
                }

                if (nLineId_D >= 0)
                {
                    if (cItemCode_D != "")
                    {
                        if (i > 0)
                        {
                            ProductionOF.Lines.Add();

                        }

                        ProductionOF.Lines.ItemType = SAPbobsCOM.ProductionItemType.pit_Item;
                        ProductionOF.Lines.ItemNo = cItemCode_D;
                        ProductionOF.Lines.BaseQuantity = nCantidadBase_D;
                        ProductionOF.Lines.PlannedQuantity = nCantidadRequerida_D;
                        //ProductionOF.Lines.AdditionalQuantity = 0; no obligatorio
                        ProductionOF.Lines.Warehouse = cBodega_D;

                        if (cIssueMthd_D != "B")
                        {
                            ProductionOF.Lines.ProductionOrderIssueType = SAPbobsCOM.BoIssueMethod.im_Manual;
                        }
                        else
                        {
                            ProductionOF.Lines.ProductionOrderIssueType = SAPbobsCOM.BoIssueMethod.im_Backflush;
                        }

                        ProductionOF.Lines.WipAccount = "1108434"; //Cuenta contable wip

                    }

                }

            }


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

                if (ProductionOF.Add() == 0)
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

            return errMsg; // NewObjectKey;           

        }

        public string Production_Orders_AsignaLotes(cldOrdenFabricacion parOrden)
        {

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;

            try
            {

            }
            catch
            {

            }

            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;
            ProductionOF.GetByKey(parOrden.DocEntry);

            /// +++++++++++++++++++++ En Caso que exista orden de venta se debe tener DocEntry y CardCode


            int nLineId_D;
            string cItemCode_D, cItemName_D, cBodega_D;
            string cLote_D;

            double nCantidad_D;

            for (int i = 0; i <= 99; i++)
            {

                //d_arrDetalle[1, j] = nLineId_D.ToString();
                //d_arrDetalle[2, j] = cItemCode_D;
                //d_arrDetalle[3, j] = cItemName_D;
                //d_arrDetalle[4, j] = nCantidadTransferida_D.ToString();
                //d_arrDetalle[5, j] = "";
                //d_arrDetalle[6, j] = cBodega_D;
                //d_arrDetalle[7, j] = cLote_D;
                //d_arrDetalle[8, j] = "";

                try
                {
                    nLineId_D = int.Parse(parOrden.arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = parOrden.arrDetalle[2, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = parOrden.arrDetalle[3, i];
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(parOrden.arrDetalle[4, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    cBodega_D = parOrden.arrDetalle[6, i];
                }
                catch
                {
                    cBodega_D = "";
                }

                try
                {
                    cLote_D = parOrden.arrDetalle[7, i];
                }
                catch
                {
                    cLote_D = "";
                }

                if (nLineId_D >= 0)
                {
                    if (cItemCode_D != "")
                    {

                        ProductionOF.Lines.SetCurrentLine(nLineId_D);

                        ProductionOF.Lines.ItemType = SAPbobsCOM.ProductionItemType.pit_Item;
                        ProductionOF.Lines.ItemNo = cItemCode_D;
                        ProductionOF.Lines.Warehouse = cBodega_D;

                        ProductionOF.Lines.BatchNumbers.Add();

                        ProductionOF.Lines.BatchNumbers.BatchNumber = cLote_D;
                        ProductionOF.Lines.BatchNumbers.Quantity = nCantidad_D;

                    }

                }

            }


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

                if (ProductionOF.Update() == 0)
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

            return errMsg; // NewObjectKey;           

        }

        public string Production_Orders_AgregaItem(cldOrdenFabricacion parOrden)
        {

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP"); 
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.GetByKey(parOrden.DocEntry);
            //ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            //ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;

            /// +++++++++++++++++++++ En Caso que exista orden de venta se debe tener DocEntry y CardCode
           
            double nCantidad;

            try
            {
                nCantidad = parOrden.Quantity;
            }
            catch
            {
                nCantidad = 0;
            }

            ProductionOF.Lines.Add();
            ProductionOF.Lines.ItemType = SAPbobsCOM.ProductionItemType.pit_Item;
            ProductionOF.Lines.ItemNo = parOrden.ItemCode; 
            //ProductionOF.Lines.BaseQuantity = nCantidad;
            ProductionOF.Lines.PlannedQuantity = nCantidad;
            //ProductionOF.Lines.AdditionalQuantity = 0; no obligatorio
            ProductionOF.Lines.Warehouse = parOrden.Warehouse;
            ProductionOF.Lines.ProductionOrderIssueType = SAPbobsCOM.BoIssueMethod.im_Manual;
            ProductionOF.Lines.WipAccount = "1108434"; //Cuenta contable wip

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

                if (ProductionOF.Update() == 0)
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

            return errMsg; // NewObjectKey;           

        }

        public string Production_Orders_ActualizaItem(cldOrdenFabricacion parOrden)
        {

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.GetByKey(parOrden.DocEntry);
            //ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            //ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;

            /// +++++++++++++++++++++ En Caso que exista orden de venta se debe tener DocEntry y CardCode

            double nCantidad;

            try
            {
                nCantidad = parOrden.Quantity;
            }
            catch
            {
                nCantidad = 0;
            }

            ProductionOF.Lines.SetCurrentLine(parOrden.LineNum);
            ProductionOF.Lines.PlannedQuantity = nCantidad;

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

                if (ProductionOF.Update() == 0)
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

            return errMsg; // NewObjectKey;           

        }

        public string Production_CambiaStatus_Lote(cldOrdenFabricacion parOrden)
        {

            string NewObjectKey;

            int errCode;
            string errMsg;

            bool connected = false;

            errCode = -1; errMsg = string.Empty;

            Company oCompany = new Company();

            oCompany.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");

            try
            {

                if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                    oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2012;
                else
                    oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2014;

                oCompany.UseTrusted = false;
                oCompany.DbUserName = "sa";
                oCompany.DbPassword = "SAPB1Admin";
                oCompany.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");
                oCompany.UserName = parOrden.UsuarioSap;
                oCompany.Password = parOrden.ClaveSap;
                oCompany.language = BoSuppLangs.ln_Spanish_La;
                oCompany.AddonIdentifier = string.Empty;

                oCompany.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

                errCode = oCompany.Connect();

                if (errCode != 0)
                    oCompany.GetLastError(out errCode, out errMsg);
                else
                    connected = true;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;

            }

            if (connected == false)
            {
                NewObjectKey = errMsg;
                return NewObjectKey;

            }

            string c_estado;

            try
            {
                c_estado = parOrden.Bloqueado;
            }
            catch
            {
                c_estado = "Y";
            }

            SAPbobsCOM.BatchNumberDetailsService oLote;
            SAPbobsCOM.BatchNumberDetailParams oLoteParams;
            SAPbobsCOM.BatchNumberDetail oLoteDetail;
            oLote = (SAPbobsCOM.BatchNumberDetailsService)oCompany.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);
            oLoteDetail = (SAPbobsCOM.BatchNumberDetail)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetail);
            oLoteParams = (SAPbobsCOM.BatchNumberDetailParams)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);

            oLoteParams.DocEntry = Convert.ToInt32(parOrden.Lote);
            oLoteDetail = oLote.Get(oLoteParams);

            if (c_estado == "N")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Released;
            }

            if (c_estado == "Y")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Locked;
            }

            if (c_estado == "A")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_NotAccessible;
            }

            try
            {
                oLote.Update(oLoteDetail);
            }
            catch (Exception)
            {

            }

            NewObjectKey = "";

            return NewObjectKey;

        }


        public string Production_CambiaStatus_Lote2(cldOrdenFabricacion parOrden)
        {

            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////

            sbo_HDV_P03 = new SAPbobsCOM.Company();

            sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");
            sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000";

            sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("Servidor_SAP") == "2012")
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            sbo_HDV_P03.DbUserName = "sa";
            sbo_HDV_P03.DbPassword = "SAPB1Admin";
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            int lRetCode;
            string NewObjectKey;
            bool connected = false;

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
                connected = true;

            }
            else
            {
                ////////////////////////////
                // Error en Conexion !!!!!

                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            if (connected == false)
            {
                NewObjectKey = "Error de Conexión";
                return NewObjectKey;

            }

            string c_estado;

            try
            {
                c_estado = parOrden.Bloqueado;
            }
            catch
            {
                c_estado = "Y";
            }

            SAPbobsCOM.BatchNumberDetailsService oLote;
            SAPbobsCOM.BatchNumberDetailParams oLoteParams;
            SAPbobsCOM.BatchNumberDetail oLoteDetail;

            oLote = (SAPbobsCOM.BatchNumberDetailsService)sbo_HDV_P03.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);
            oLoteDetail = (SAPbobsCOM.BatchNumberDetail)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetail);
            oLoteParams = (SAPbobsCOM.BatchNumberDetailParams)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);

            oLoteParams.DocEntry = Convert.ToInt32(parOrden.Lote);
            oLoteDetail = oLote.Get(oLoteParams);

            if (c_estado == "N")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Released;
            }

            if (c_estado == "Y")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Locked;
            }

            if (c_estado == "A")
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_NotAccessible;
            }

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

                try
                {
                    oLote.Update(oLoteDetail);

                    errCode = 0;

                    //NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
                    errMsg = sbo_HDV_P03.GetNewObjectKey();

                    if (sbo_HDV_P03.InTransaction)
                        sbo_HDV_P03.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);

                }
                catch
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

            return errMsg; // NewObjectKey;       

        }

        public string Production_Orders_Cerrar(cldOrdenFabricacion parOrden)
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
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera
            ProductionOF.GetByKey(parOrden.DocEntry);
            ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposClosed;

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

                if (ProductionOF.Update() == 0)
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

            return errMsg; // NewObjectKey;       


        }

        public string Stock_Transfer(cldOrdenFabricacion parStockTransf)
        {

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
            sbo_HDV_P03.UserName = parStockTransf.UsuarioSap;
            sbo_HDV_P03.Password = parStockTransf.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer StockTransf;
            StockTransf = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);

            // datos de cabecera

            StockTransf.DocDate = DateTime.ParseExact(parStockTransf.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            string cOrigendeSolicitud, cJrMemo, cSolicitante;

            cOrigendeSolicitud = "";
            cJrMemo = "";
            cSolicitante = "";

            try
            {
                cOrigendeSolicitud = parStockTransf.arrDetalle[10, 0];

            }
            catch
            {
                cOrigendeSolicitud = "";

            }

            try
            {
                cJrMemo = parStockTransf.arrDetalle[14, 0];

            }
            catch
            {
                cJrMemo = "";

            }

            try
            {
                cSolicitante = parStockTransf.arrDetalle[15, 0];

            }
            catch
            {
                cSolicitante = "";

            }

            if (cOrigendeSolicitud == "INSUMOS TIPO B")
            {
                StockTransf.Comments = "Solicitud de Insumos Tipo B, Solicitado por:" + cSolicitante + ", solicitud #" + parStockTransf.DocNum;
                StockTransf.JournalMemo = cJrMemo;

            }
            else
            {
                StockTransf.Comments = "Transferir solicitud para Órdenes fabricación " + parStockTransf.DocNum;

            }

            StockTransf.CardCode = parStockTransf.CardCode;
            StockTransf.CardName = parStockTransf.CardName;

            string cItemCode, cLote, cWhsCode;
            string cFromWhs, cItemCode_D, cWhsCode_D;
            string cDimension1, cDimension2, cDimension3;

            double nQuantity, nQuantity_D;

            int nLinea, nLineLote;

            //cFromWhs = parStockTransf.Warehouse;
            nLinea = 0;

            try
            {
                cWhsCode = parStockTransf.arrDetalle[2, 0];
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                cFromWhs = parStockTransf.arrDetalle[4, 0];
            }
            catch
            {
                cFromWhs = "";
            }

            int nCodigosenBlanco;

            nCodigosenBlanco = 0;

            StockTransf.FromWarehouse = cWhsCode;
            StockTransf.ToWarehouse = cFromWhs;

            for (int i = 0; i <= 999; i++)
            {

                try
                {
                    cItemCode = parStockTransf.arrDetalle[1, i];
                }
                catch
                {
                    cItemCode = "";
                }

                if (cItemCode == "")
                {
                    nCodigosenBlanco += 1;

                }

                if (nCodigosenBlanco == 3)
                {
                    break;

                }

                try
                {
                    cWhsCode = parStockTransf.arrDetalle[2, i];
                }
                catch
                {
                    cWhsCode = "";
                }

                try
                {
                    nQuantity = Convert.ToDouble(parStockTransf.arrDetalle[3, i]);
                }
                catch
                {
                    nQuantity = -1;
                }

                try
                {
                    cFromWhs = parStockTransf.arrDetalle[4, i];
                }
                catch
                {
                    cFromWhs = "";
                }

                cDimension1 = "";
                cDimension2 = "";
                cDimension3 = "";

                try
                {
                    cDimension1 = parStockTransf.arrDetalle[11, 0];

                }
                catch
                {
                    cDimension1 = "";

                }

                try
                {
                    cDimension2 = parStockTransf.arrDetalle[12, 0];

                }
                catch
                {
                    cDimension2 = "";

                }

                try
                {
                    cDimension3 = parStockTransf.arrDetalle[13, 0];

                }
                catch
                {
                    cDimension3 = "";

                }

                if (nQuantity > 0)
                {
                    if (cItemCode != "")
                    {
                        if (nLinea > 0)
                        {
                            StockTransf.Lines.Add();
                            // StockTransf.Lines.BatchNumbers.Add();
                        }

                        StockTransf.Lines.ItemCode = cItemCode;
                        StockTransf.Lines.Quantity = nQuantity;
                        StockTransf.Lines.FromWarehouseCode = cWhsCode;
                        StockTransf.Lines.WarehouseCode = cFromWhs;

                        StockTransf.Lines.DistributionRule = cDimension1;
                        StockTransf.Lines.DistributionRule2 = cDimension2;
                        StockTransf.Lines.DistributionRule3 = cDimension3;

                        nLinea += 1;

                        nLineLote = 0;

                        int nCodigosenBlanco_D;

                        nCodigosenBlanco_D = 0;

                        for (int x = 0; x <= 999; x++)
                        {

                            try
                            {
                                cItemCode_D = parStockTransf.arrDetalle1[1, x];
                            }
                            catch
                            {
                                cItemCode_D = "";
                            }

                            if (cItemCode_D == "")
                            {
                                nCodigosenBlanco_D += 1;
                            }

                            if (nCodigosenBlanco_D == 3)
                            {
                                break;

                            }

                            try
                            {
                                cLote = parStockTransf.arrDetalle1[2, x];
                            }
                            catch
                            {
                                cLote = "";
                            }

                            try
                            {
                                nQuantity_D = Convert.ToDouble(parStockTransf.arrDetalle1[3, x]);
                            }
                            catch
                            {
                                nQuantity_D = -1;
                            }

                            try
                            {
                                cWhsCode_D = parStockTransf.arrDetalle1[4, x];
                            }
                            catch
                            {
                                cWhsCode_D = "";
                            }

                            if (nQuantity_D > 0)
                            {
                                if (cItemCode == cItemCode_D)
                                {
                                    if (cWhsCode == cWhsCode_D)
                                    {

                                        if (nLineLote > 0)
                                        {
                                            //StockTransf.Lines.Add();
                                            StockTransf.Lines.BatchNumbers.Add();
                                        }

                                        StockTransf.Lines.BatchNumbers.BatchNumber = cLote;
                                        StockTransf.Lines.BatchNumbers.Quantity = nQuantity_D;

                                        nLineLote += 1;

                                    }


                                }

                            }

                        }

                    }

                }

            }

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

                if (StockTransf.Add() == 0)
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

        public string Transfer_Stock(cldOrdenFabricacion parStockTransf)
        {

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
            sbo_HDV_P03.UserName = parStockTransf.UsuarioSap;
            sbo_HDV_P03.Password = parStockTransf.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer StockTransf;
            StockTransf = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oStockTransfer);

            // datos de cabecera

            StockTransf.DocDate = DateTime.ParseExact(parStockTransf.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            string cOrigendeSolicitud, cJrMemo, cSolicitante;

            cOrigendeSolicitud = "";
            cJrMemo = "";
            cSolicitante = "";

            try
            {
                cOrigendeSolicitud = parStockTransf.arrDetalle[10, 0];

            }
            catch
            {
                cOrigendeSolicitud = "";

            }

            try
            {
                cJrMemo = parStockTransf.arrDetalle[14, 0];

            }
            catch
            {
                cJrMemo = "";

            }

            try
            {
                cSolicitante = parStockTransf.arrDetalle[15, 0];

            }
            catch
            {
                cSolicitante = "";

            }

            if (cOrigendeSolicitud == "INSUMOS TIPO B")
            {
                StockTransf.Comments = "Solicitud de Insumos Tipo B, Solicitado por:" + cSolicitante + ", solicitud #" + parStockTransf.DocNum;
                StockTransf.JournalMemo = cJrMemo;

            }
            else
            {
                StockTransf.Comments = "Transferir solicitud para Órdenes fabricación " + parStockTransf.DocNum;

            }

            StockTransf.CardCode = parStockTransf.CardCode;
            StockTransf.CardName = parStockTransf.CardName;

            string cItemCode, cLote, cWhsCode;
            string cFromWhs, cItemCode_D, cWhsCode_D;
            string cDimension1, cDimension2, cDimension3;

            double nQuantity, nQuantity_D;

            int nLinea, nLineLote;
            int nBaseEntry, nBaseLine;

            //cFromWhs = parStockTransf.Warehouse;
            nLinea = 0;

            try
            {
                cWhsCode = parStockTransf.arrDetalle[2, 0];
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                cFromWhs = parStockTransf.arrDetalle[4, 0];
            }
            catch
            {
                cFromWhs = "";
            }

            int nCodigosenBlanco;
            int nCodigosenBlanco_Det;

            nCodigosenBlanco = 0;

            StockTransf.FromWarehouse = cWhsCode.Trim();
            StockTransf.ToWarehouse = cFromWhs.Trim();

            for (int i = 0; i <= 999; i++)
            {

                try
                {
                    cItemCode = parStockTransf.arrDetalle[1, i];
                }
                catch
                {
                    cItemCode = "";
                }

                if (cItemCode == "")
                {
                    nCodigosenBlanco += 1;

                }

                if (nCodigosenBlanco == 3)
                {
                    break;

                }

                try
                {
                    cWhsCode = parStockTransf.arrDetalle[2, i];
                }
                catch
                {
                    cWhsCode = "";
                }

                try
                {
                    nQuantity = Convert.ToDouble(parStockTransf.arrDetalle[3, i]);
                }
                catch
                {
                    nQuantity = -1;
                }

                try
                {
                    cFromWhs = parStockTransf.arrDetalle[4, i];
                }
                catch
                {
                    cFromWhs = "";
                }

                cDimension1 = "";
                cDimension2 = "";
                cDimension3 = "";

                try
                {
                    cDimension1 = parStockTransf.arrDetalle[11, 0];

                }
                catch
                {
                    cDimension1 = "";

                }

                try
                {
                    cDimension2 = parStockTransf.arrDetalle[12, 0];

                }
                catch
                {
                    cDimension2 = "";

                }

                try
                {
                    cDimension3 = parStockTransf.arrDetalle[13, 0];

                }
                catch
                {
                    cDimension3 = "";

                }

                try
                {
                    nBaseEntry = Convert.ToInt32(parStockTransf.arrDetalle[17, i]);
                }
                catch
                {
                    nBaseEntry = -1;
                }

                try
                {
                    nBaseLine = Convert.ToInt32(parStockTransf.arrDetalle[16, i]);
                }
                catch
                {
                    nBaseLine = -1;
                }

                if (nQuantity > 0)
                {
                    if (cItemCode != "")
                    {
                        if (nLinea > 0)
                        {
                            StockTransf.Lines.Add();
                            // StockTransf.Lines.BatchNumbers.Add();
                        }

                        //17969

                        if (nBaseEntry > 0)
                        {
                            StockTransf.Lines.BaseEntry = nBaseEntry;
                            StockTransf.Lines.BaseLine = nBaseLine;
                            StockTransf.Lines.BaseType = InvBaseDocTypeEnum.InventoryTransferRequest;

                        }

                        StockTransf.Lines.ItemCode = cItemCode;
                        StockTransf.Lines.Quantity = nQuantity;
                        StockTransf.Lines.FromWarehouseCode = cWhsCode.Trim();
                        StockTransf.Lines.WarehouseCode = cFromWhs.Trim();

                        StockTransf.Lines.DistributionRule = cDimension1;
                        StockTransf.Lines.DistributionRule2 = cDimension2;
                        StockTransf.Lines.DistributionRule3 = cDimension3;

                        nLinea += 1;

                        nLineLote = 0;
                        nCodigosenBlanco_Det = 0;

                        for (int x = 0; x <= 999; x++)
                        {

                            try
                            {
                                cItemCode_D = parStockTransf.arrDetalle1[1, x];
                            }
                            catch
                            {
                                cItemCode_D = "";
                            }

                            try
                            {
                                cLote = parStockTransf.arrDetalle1[2, x];
                            }
                            catch
                            {
                                cLote = "";
                            }

                            if (cItemCode_D == "")
                            {
                                nCodigosenBlanco_Det += 1;

                            }

                            if  (nCodigosenBlanco_Det == 3)
                            {
                                break;

                            }

                            try
                            {
                                nQuantity_D = Convert.ToDouble(parStockTransf.arrDetalle1[3, x]);
                            }
                            catch
                            {
                                nQuantity_D = -1;
                            }

                            try
                            {
                                cWhsCode_D = parStockTransf.arrDetalle1[4, x];
                            }
                            catch
                            {
                                cWhsCode_D = "";
                            }

                            if (nQuantity_D > 0)
                            {
                                if (cItemCode == cItemCode_D)
                                {
                                    if (cWhsCode == cWhsCode_D)
                                    {

                                        if (nLineLote > 0)
                                        {
                                            //StockTransf.Lines.Add();
                                            StockTransf.Lines.BatchNumbers.Add();
                                        }

                                        //StockTransf.Lines.BatchNumbers.BaseLineNumber = 0; 
                                        StockTransf.Lines.BatchNumbers.BatchNumber = cLote;
                                        StockTransf.Lines.BatchNumbers.Quantity = nQuantity_D;

                                        nLineLote += 1;

                                    }


                                }

                            }

                        }

                    }

                }

            }

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

                if (StockTransf.Add() == 0)
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

        public string Transfer_Stock_Cerrar(cldOrdenFabricacion parOrden)
        {

            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////

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
            sbo_HDV_P03.UserName = parOrden.UsuarioSap;
            sbo_HDV_P03.Password = parOrden.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.StockTransfer Solicitud_Transfer;
            Solicitud_Transfer = (SAPbobsCOM.StockTransfer)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);

            Solicitud_Transfer.GetByKey(parOrden.DocEntry);
            Solicitud_Transfer.Close();

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

                if (Solicitud_Transfer.Update() == 0)
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

            return errMsg; // NewObjectKey;       

        }

        public string Ajuste_Merma_Stock(cldOrdenFabricacion parStockTransf)
        {

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
            sbo_HDV_P03.UserName = parStockTransf.UsuarioSap;
            sbo_HDV_P03.Password = parStockTransf.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Documents StockTransf;
            StockTransf = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);

            // datos de cabecera

            StockTransf.DocDate = DateTime.ParseExact(parStockTransf.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            string cOrigendeSolicitud, cJrMemo, cSolicitante;

            cOrigendeSolicitud = "";
            cJrMemo = "";
            cSolicitante = "";

            try
            {
                cOrigendeSolicitud = parStockTransf.arrDetalle[10, 0];

            }
            catch
            {
                cOrigendeSolicitud = "";

            }

            try
            {
                cJrMemo = parStockTransf.arrDetalle[14, 0];

            }
            catch
            {
                cJrMemo = "";

            }

            try
            {
                cSolicitante = parStockTransf.arrDetalle[15, 0];

            }
            catch
            {
                cSolicitante = "";

            }

            if (cOrigendeSolicitud == "INSUMOS TIPO B")
            {
                StockTransf.Comments = "Solicitud de Insumos Tipo B, Solicitado por:" + cSolicitante + ", solicitud #" + parStockTransf.DocNum;
                StockTransf.JournalMemo = cJrMemo;

            }
            else
            {
                StockTransf.Comments = "Transferir solicitud para Órdenes fabricación " + parStockTransf.DocNum;

            }

            StockTransf.CardCode = parStockTransf.CardCode;
            StockTransf.CardName = parStockTransf.CardName;

            string cItemCode, cLote, cWhsCode;
            string cFromWhs, cItemCode_D, cWhsCode_D;
            string cDimension1, cDimension2, cDimension3;

            double nQuantity, nQuantity_D;

            int nLinea, nLineLote;
            int nBaseEntry, nBaseLine;

            //cFromWhs = parStockTransf.Warehouse;
            nLinea = 0;

            try
            {
                cWhsCode = parStockTransf.arrDetalle[2, 0];
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                cFromWhs = parStockTransf.arrDetalle[4, 0];
            }
            catch
            {
                cFromWhs = "";
            }

            int nCodigosenBlanco;

            nCodigosenBlanco = 0;

            //StockTransf.FromWarehouse = cWhsCode;
            //StockTransf.ToWarehouse = cFromWhs;

            for (int i = 0; i <= 999; i++)
            {

                try
                {
                    cItemCode = parStockTransf.arrDetalle[1, i];
                }
                catch
                {
                    cItemCode = "";
                }

                if (cItemCode == "")
                {
                    nCodigosenBlanco += 1;

                }

                if (nCodigosenBlanco == 3)
                {
                    break;

                }

                try
                {
                    cWhsCode = parStockTransf.arrDetalle[2, i];
                }
                catch
                {
                    cWhsCode = "";
                }

                try
                {
                    nQuantity = Convert.ToDouble(parStockTransf.arrDetalle[3, i]);
                }
                catch
                {
                    nQuantity = -1;
                }

                try
                {
                    cFromWhs = parStockTransf.arrDetalle[4, i];
                }
                catch
                {
                    cFromWhs = "";
                }

                cDimension1 = "";
                cDimension2 = "";
                cDimension3 = "";

                try
                {
                    cDimension1 = parStockTransf.arrDetalle[11, 0];

                }
                catch
                {
                    cDimension1 = "";

                }

                try
                {
                    cDimension2 = parStockTransf.arrDetalle[12, 0];

                }
                catch
                {
                    cDimension2 = "";

                }

                try
                {
                    cDimension3 = parStockTransf.arrDetalle[13, 0];

                }
                catch
                {
                    cDimension3 = "";

                }

                try
                {
                    nBaseEntry = Convert.ToInt32(parStockTransf.arrDetalle[17, i]);
                }
                catch
                {
                    nBaseEntry = -1;
                }

                try
                {
                    nBaseLine = Convert.ToInt32(parStockTransf.arrDetalle[16, i]);
                }
                catch
                {
                    nBaseLine = -1;
                }

                if (nQuantity > 0)
                {
                    if (cItemCode != "")
                    {
                        if (nLinea > 0)
                        {
                            StockTransf.Lines.Add();
                            // StockTransf.Lines.BatchNumbers.Add();
                        }

                        //17969                      

                        StockTransf.Lines.ItemCode = cItemCode;
                        StockTransf.Lines.Quantity = nQuantity;
                        //StockTransf.Lines.FromWarehouseCode = cWhsCode;
                        StockTransf.Lines.WarehouseCode = cFromWhs;

                        //StockTransf.Lines.DistributionRule = cDimension1;
                        //StockTransf.Lines.DistributionRule2 = cDimension2;
                        //StockTransf.Lines.DistributionRule3 = cDimension3;

                        nLinea += 1;

                        nLineLote = 0;

                        for (int x = 0; x <= 999; x++)
                        {

                            try
                            {
                                cItemCode_D = parStockTransf.arrDetalle1[1, x];
                            }
                            catch
                            {
                                cItemCode_D = "";
                            }

                            try
                            {
                                cLote = parStockTransf.arrDetalle1[2, x];
                            }
                            catch
                            {
                                cLote = "";
                            }

                            try
                            {
                                nQuantity_D = Convert.ToDouble(parStockTransf.arrDetalle1[3, x]);
                            }
                            catch
                            {
                                nQuantity_D = -1;
                            }

                            try
                            {
                                cWhsCode_D = parStockTransf.arrDetalle1[4, x];
                            }
                            catch
                            {
                                cWhsCode_D = "";
                            }

                            if (nQuantity_D > 0)
                            {
                                if (cItemCode == cItemCode_D)
                                {
                                    if (cWhsCode == cWhsCode_D)
                                    {

                                        if (nLineLote > 0)
                                        {
                                            //StockTransf.Lines.Add();
                                            StockTransf.Lines.BatchNumbers.Add();
                                        }

                                        StockTransf.Lines.BatchNumbers.BatchNumber = cLote;
                                        StockTransf.Lines.BatchNumbers.Quantity = nQuantity_D;

                                        nLineLote += 1;

                                    }


                                }

                            }

                        }

                    }

                }

            }

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

                if (StockTransf.Add() == 0)
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

        public string Entrada_Mercaderia_TR(cldOrdenFabricacion parTermination)
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
            sbo_HDV_P03.UserName = parTermination.UsuarioSap;
            sbo_HDV_P03.Password = parTermination.ClaveSap;

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

            ///// crear los lotes para las cajas
            ///// 

            SAPbobsCOM.Recordset RS;
            string Query = string.Empty;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            bool goodParse = false;

            Query = "SELECT MAX(CONVERT(INT,T0.[DistNumber])) FROM OBTN T0 WHERE ISNUMERIC(T0.[DistNumber]) = 1";

            RS.DoQuery(Query);
            int LoteMaximo = 0;
            string cItemCode;

            while (!RS.EoF)
            {
                goodParse = int.TryParse(RS.Fields.Item(0).Value.ToString(), out LoteMaximo);
                RS.MoveNext();
            }

            LoteMaximo += 1;

            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry);

            //// datos de cabecera
            cItemCode = parTermination.ItemCode;

            EntradaMercancia.DocDate = DateTime.ParseExact(parTermination.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.Reference2 = "";
            EntradaMercancia.Comments = "Terminacion Report";
            EntradaMercancia.JournalMemo = "Terminacion Report";
            EntradaMercancia.UserFields.Fields.Item("U_Salida_Produccion").Value = parTermination.SalidaProduccion;
            EntradaMercancia.UserFields.Fields.Item("U_Turno").Value = parTermination.Turno;

            EntradaMercancia.Lines.BaseType = 202;
            EntradaMercancia.Lines.BaseEntry = parTermination.DocEntry;

            if (parTermination.LineNum != -1)
            {

                Query = "select Costo = [dbo].[fx_CostoOrdenFabricacion](" + parTermination.DocEntry + ")";

                RS.DoQuery(Query);
                double nPriceCost_OF = 0;

                while (!RS.EoF)
                {
                    goodParse = double.TryParse(RS.Fields.Item(0).Value.ToString(), out nPriceCost_OF);
                    RS.MoveNext();
                }

                Query = "select ItemCode from WOR1 ";
                Query += "Where DocEntry = " + parTermination.DocEntry + " ";
                Query += "and LineNum = " + parTermination.LineNum + " ";
                //Costo = [dbo].[fx_CostoOrdenFabricacion](" + parTermination.DocEntry + ")";

                RS.DoQuery(Query);

                while (!RS.EoF)
                {
                    cItemCode = RS.Fields.Item(0).Value.ToString();
                    RS.MoveNext();
                }

                EntradaMercancia.Lines.BaseLine = parTermination.LineNum;                

                if (cItemCode == "FP.ALM.SE.CRA1.PIE.X.XXX-XXX.XXX.G.0001K.01") 
                {
                    nPriceCost_OF = 0;
                }

                if (cItemCode == "FS.ALM.SE.CRA1.PIE.X.XXX-XXX.XXX.G.0001K.01")
                {
                    nPriceCost_OF = 0;
                }

                if (cItemCode == "FP.NUE.SE.NCC1.XXX.X.XXX-XXX.XXX.G.0001K.01")
                {
                    nPriceCost_OF = 0;
                }

                nPriceCost_OF = 0;

                if (nPriceCost_OF > 0)
                {
                    EntradaMercancia.Lines.UnitPrice = nPriceCost_OF;
                }
                
            }

            EntradaMercancia.Lines.Quantity = parTermination.Quantity;            
            EntradaMercancia.Lines.WarehouseCode = parTermination.Warehouse;

            int nBinsTR = parTermination.CantidadBins;

            if (parTermination.CantidadBins <= -1)
            {
                parTermination.CantidadBins = 1;

            }

            string[] Lotes = new string[parTermination.CantidadBins];
            
            Random rnd = new Random();
            int nTransitorio; 

            for (int i = 1; i <= parTermination.CantidadBins; i++)
            {
                /////////////////////////////////////////////////
                // obtenemos el numero de lote maximo
                if (i > 1)
                {
                    EntradaMercancia.Lines.BatchNumbers.Add();
                }

                nTransitorio = rnd.Next(1,15);
                EntradaMercancia.Lines.BatchNumbers.BatchNumber = (LoteMaximo + nTransitorio).ToString();

                if (i != parTermination.CantidadBins) //peso de la ultima caja
                {
                    EntradaMercancia.Lines.BatchNumbers.Quantity = Math.Round(parTermination.Quantity / parTermination.CantidadBins, 2);
                }
                else
                {
                    EntradaMercancia.Lines.BatchNumbers.Quantity = parTermination.Quantity;
                }

                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_FolioPallet").Value = "";
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_tipoLote").Value = "5";
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_ItemCode_Referencia").Value = parTermination.ItemCode;

                if (nBinsTR > -1)
                {
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = "1";

                }
                else
                {
                    EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_BINS").Value = (nBinsTR * -1).ToString();

                }

                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_VOLTEADOS").Value = "0";
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_temporada").Value = DateTime.Now.Year.ToString();
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_HDV_VARIEDAD").Value = parTermination.Variedad;

                EntradaMercancia.Lines.BatchNumbers.ManufacturerSerialNumber = parTermination.CodeProveedor;
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBPROD").Value = parTermination.NombreProveedor;

                EntradaMercancia.Lines.BatchNumbers.InternalSerialNumber = parTermination.CodeCliente;
                EntradaMercancia.Lines.BatchNumbers.UserFields.Fields.Item("U_NOMBCLI").Value = parTermination.NombreCliente;

                Lotes[i - 1] = (LoteMaximo + i).ToString();

            }

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

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

            //sbo_HDV_P03.Disconnect();
            return NewObjectKey;

        }

        public string Entrada_Mercaderia_TR1(cldOrdenFabricacion parTermination)
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
            sbo_HDV_P03.UserName = parTermination.UsuarioSap;
            sbo_HDV_P03.Password = parTermination.ClaveSap;

            sbo_HDV_P03.Connect();

            ///// crear los lotes para las cajas
            ///// 

            SAPbobsCOM.Recordset RS;
            string Query = string.Empty;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            bool goodParse = false;
                        
            SAPbobsCOM.Documents EntradaMercancia;
            EntradaMercancia = (SAPbobsCOM.Documents)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry);

            //// datos de cabecera

            EntradaMercancia.DocDate = DateTime.ParseExact(parTermination.DocDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            EntradaMercancia.Reference2 = "";
            EntradaMercancia.Comments = "Terminacion Report";
            EntradaMercancia.JournalMemo = "Terminacion Report";
            EntradaMercancia.UserFields.Fields.Item("U_Salida_Produccion").Value = parTermination.SalidaProduccion;

            EntradaMercancia.Lines.BaseType = 202;
            EntradaMercancia.Lines.BaseEntry = parTermination.DocEntry;

            Query = "select Costo = [dbo].[fx_CostoOrdenFabricacion](" + parTermination.DocEntry + ")";

            RS.DoQuery(Query);
            double nPriceCost_OF = 0;

            while (!RS.EoF)
            {
                goodParse = double.TryParse(RS.Fields.Item(0).Value.ToString(), out nPriceCost_OF);
                RS.MoveNext();
            }

            EntradaMercancia.Lines.BaseLine = parTermination.LineNum;
            //EntradaMercancia.Lines.UnitPrice = 0;
            EntradaMercancia.Lines.Quantity = parTermination.Quantity;
            EntradaMercancia.Lines.WarehouseCode = parTermination.Warehouse;
            
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

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

            return NewObjectKey;

        }

        public string Entrada_Mercaderia_TR2(cldOrdenFabricacion parTermination)
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
            sbo_HDV_P03.UserName = parTermination.UsuarioSap;
            sbo_HDV_P03.Password = parTermination.ClaveSap;

            try
            {
                sbo_HDV_P03.Connect();

            }
            catch
            {
                sbo_HDV_P03.Disconnect();

            }

           
            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            NewObjectKey = "s";

            string sql;

            sql = "update OBTN ";
            sql += "set [U_BINS] = " + parTermination.CantidadBins + " ";
            sql += "where DistNumber = '" + parTermination.Lote + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return NewObjectKey;

        }

        public string Entrada_Mercaderia_TR3(cldOrdenFabricacion parTermination)
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
            sbo_HDV_P03.UserName = parTermination.UsuarioSap;
            sbo_HDV_P03.Password = parTermination.ClaveSap;

            try
            {
                sbo_HDV_P03.Connect();

            }
            catch
            {
                sbo_HDV_P03.Disconnect();

            }


            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 

            NewObjectKey = "s";

            string sql;

            sql = "update OPDN ";
            sql += "set [U_DTE_Booking] = " + parTermination.DocEntryRef + " , ";
            sql += "[U_DTE_OPERADOR] = '" + parTermination.U_Proceso + "' ";

            sql += "where DocEntry = '" + parTermination.DocEntry + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return NewObjectKey;

        }


        public string Entrada_Mercaderia_Nuevo_Pallet(cldOrdenFabricacion parPallet)
        {

            string NewObjectKey, errMsg;
            int errCode = 0;

            NewObjectKey = "";

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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            bool goodParse = false;
            string Query = string.Empty;
            Int64 MaximoNumeroPallet = 0;

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;
            SAPbobsCOM.GeneralDataCollection Sons;
            SAPbobsCOM.GeneralData Son;

            SAPbobsCOM.GeneralDataParams GeneralParams;

            Query = "SELECT ISNULL(MAX(CONVERT(INT,[U_BarCode])),70000000) FROM [@HDV_PALL]";

            RS.DoQuery(Query);

            //////////////////////////////////
            /// obtener odigo maximo de pallet

            goodParse = Int64.TryParse(RS.Fields.Item(0).Value.ToString(), out MaximoNumeroPallet);

            if (goodParse)
            {

                CodigoNumeroPallet = (++MaximoNumeroPallet).ToString();

                ///// add UDO data

                CompanyService = sbo_HDV_P03.GetCompanyService();

                GeneralService = CompanyService.GetGeneralService("HDV_PALL");
                GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                GeneralData.SetProperty("Code", "P" + CodigoNumeroPallet);
                GeneralData.SetProperty("Name", "P" + CodigoNumeroPallet);
                GeneralData.SetProperty("U_BarCode", CodigoNumeroPallet);
                GeneralData.SetProperty("U_ItemCode", parPallet.ItemCode);
                GeneralData.SetProperty("U_ItemName", parPallet.ItemName);
                GeneralData.SetProperty("U_WhsCode", parPallet.Warehouse);
                GeneralData.SetProperty("U_BinCode", "");

                try
                {
                    GeneralService.Add(GeneralData);

                }
                catch
                {
                    NewObjectKey = "Error al obtener el numero maximo de pallet.";
                    return NewObjectKey;
                }

            }
            else
            {
                NewObjectKey = "Error al obtener el numero maximo de pallet.";
                return NewObjectKey;
            }

            int nLote;
            string sql;

            //Get a handle to the SM_MOR UDO
            CompanyService = sbo_HDV_P03.GetCompanyService();
            GeneralService = CompanyService.GetGeneralService("HDV_PALL");

            //Get UDO record
            GeneralParams = (SAPbobsCOM.GeneralDataParams)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
            GeneralParams.SetProperty("Code", "P" + CodigoNumeroPallet);
            GeneralData = GeneralService.GetByParams(GeneralParams);

            Sons = GeneralData.Child("HDV_PAL1");

            for (int i = 0; i <= 100; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {
                    try
                    {
                        Son = Sons.Add();
                        Son.SetProperty("U_AbsEntry", nLote.ToString());
                        Son.SetProperty("U_DistNumber", nLote.ToString());
                        // Son.SetProperty("U_DistNumber", nLote.ToString());

                        NewObjectKey = CodigoNumeroPallet;

                    }
                    catch
                    {
                        sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                        NewObjectKey = errMsg;
                        return NewObjectKey;

                    }

                    GeneralService.Update(GeneralData);

                    sql = "update OBTN ";
                    sql += "set U_FolioPallet = '" + "P" + CodigoNumeroPallet + "' ";
                    sql += "where DistNumber = '" + nLote.ToString() + "' ";

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                }

            }

            return NewObjectKey;

        }

        public string Crea_Nuevo_Pallet(cldOrdenFabricacion parPallet)
        {

            string NewObjectKey;

            NewObjectKey = "";

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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            bool goodParse = false;
            string Query = string.Empty;
            Int64 MaximoNumeroPallet = 0;

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;
            //SAPbobsCOM.GeneralDataCollection Sons;
            //SAPbobsCOM.GeneralData Son;

            SAPbobsCOM.GeneralDataParams GeneralParams;

            Query = "SELECT ISNULL(MAX(CONVERT(INT,[U_BarCode])),70000000) FROM [@HDV_PALL]";

            RS.DoQuery(Query);

            //////////////////////////////////
            /// obtener odigo maximo de pallet

            goodParse = Int64.TryParse(RS.Fields.Item(0).Value.ToString(), out MaximoNumeroPallet);

            if (goodParse)
            {

                CodigoNumeroPallet = (++MaximoNumeroPallet).ToString();

                ///// add UDO data

                CompanyService = sbo_HDV_P03.GetCompanyService();

                GeneralService = CompanyService.GetGeneralService("HDV_PALL");
                GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
                GeneralData.SetProperty("Code", "P" + CodigoNumeroPallet);
                GeneralData.SetProperty("Name", "P" + CodigoNumeroPallet);
                GeneralData.SetProperty("U_BarCode", CodigoNumeroPallet);
                GeneralData.SetProperty("U_ItemCode", parPallet.ItemCode);
                GeneralData.SetProperty("U_ItemName", parPallet.ItemName);
                GeneralData.SetProperty("U_WhsCode", parPallet.Warehouse);
                GeneralData.SetProperty("U_BinCode", "");

                try
                {
                    GeneralService.Add(GeneralData);

                }
                catch
                {
                    NewObjectKey = "Error al obtener el numero maximo de pallet.";
                    return NewObjectKey;
                }

            }
            else
            {
                NewObjectKey = "Error al obtener el numero maximo de pallet.";
                return NewObjectKey;
            }

            


            //Get a handle to the SM_MOR UDO
            CompanyService = sbo_HDV_P03.GetCompanyService();
            GeneralService = CompanyService.GetGeneralService("HDV_PALL");

            //Get UDO record
            GeneralParams = (SAPbobsCOM.GeneralDataParams)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
            GeneralParams.SetProperty("Code", "P" + CodigoNumeroPallet);
            GeneralData = GeneralService.GetByParams(GeneralParams);

            //Sons = GeneralData.Child("HDV_PAL1");

            if (NewObjectKey=="")
            {
                Query = "select top 1 U_BarCode from [@HDV_PALL] order by CreateDate desc , CreateTime desc ";

                RS.DoQuery(Query);

                while (!RS.EoF)
                {
                    NewObjectKey =RS.Fields.Item(0).Value.ToString();
                    RS.MoveNext();

                }

            }


            return NewObjectKey;

        }

        public string Entrada_Mercaderia_Asigna_Pallet(cldOrdenFabricacion parPallet)
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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;
            SAPbobsCOM.GeneralDataCollection Sons;
            SAPbobsCOM.GeneralData Son;

            SAPbobsCOM.GeneralDataParams GeneralParams;

            int nLote, errCode;
            string errMsg, sql, cDistNumber;

            NewObjectKey = "";

            //Get a handle to the SM_MOR UDO
            CompanyService = sbo_HDV_P03.GetCompanyService();
            GeneralService = CompanyService.GetGeneralService("HDV_PALL");

            //Get UDO record
            GeneralParams = (SAPbobsCOM.GeneralDataParams)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);
            GeneralParams.SetProperty("Code", parPallet.CodigoNumeroPallet);
            GeneralData = GeneralService.GetByParams(GeneralParams);

            Sons = GeneralData.Child("HDV_PAL1");

            for (int i = 0; i <= 100; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    cDistNumber = parPallet.arrDetalle[2, i];
                }
                catch
                {
                    cDistNumber = "";
                }

                if (nLote > 0)
                {
                    if (cDistNumber=="")
                    {
                        cDistNumber = nLote.ToString();
                    }

                    try
                    {
                        Son = Sons.Add();
                        Son.SetProperty("U_AbsEntry", nLote.ToString());
                        Son.SetProperty("U_DistNumber", cDistNumber);
                        // Son.SetProperty("U_DistNumber", nLote.ToString());
                    }
                    catch
                    {
                        sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                        NewObjectKey = errMsg;
                        return NewObjectKey;

                    }

                    GeneralService.Update(GeneralData);

                    sql = "update OBTN ";
                    sql += "set U_FolioPallet = '" + parPallet.CodigoNumeroPallet + "' ";
                    sql += "where AbsEntry = '" + nLote.ToString() + "' ";

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                }

            }

            return NewObjectKey;

        }

        public string Entrada_Mercaderia_Borra_Pallet(cldOrdenFabricacion parPallet)
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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            int nLote, LineId;
            string sql, Query;

            NewObjectKey = "";

            for (int i = 0; i <= 100; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {
                    LineId = -1;

                    Query = "select top 1 LineId ";
                    Query += "from [@HDV_PAL1] ";
                    Query += "Where Code = '" + parPallet.CodigoNumeroPallet + "' ";
                    Query += "and U_AbsEntry = '" + nLote.ToString() + "' ";

                    RS.DoQuery(Query);

                    while (!RS.EoF)
                    {
                        LineId = int.Parse(RS.Fields.Item(0).Value.ToString());
                        RS.MoveNext();

                    }

                    if (LineId >= 0)
                    {
                        sql = "delete [@HDV_PAL1] ";
                        sql += "Where Code = '" + parPallet.CodigoNumeroPallet + "' ";
                        sql += "and U_AbsEntry = '" + nLote.ToString() + "' ";

                        this.ComandoSql = sql;
                        this.GestorSqlConsultar();

                        sql = "update OBTN ";
                        sql += "set U_FolioPallet = '" + parPallet.CodigoNumeroPallet + "' ";
                        sql += "where AbsEntry = '" + nLote.ToString() + "' ";

                        this.ComandoSql = sql;
                        this.GestorSqlConsultar();

                    }
                   
                }

            }

            return NewObjectKey;

        }

        public string Fumiga_Lote(cldOrdenFabricacion parPallet)
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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string Query = string.Empty;

            int nLote, nLineId, nLineaBlanco;
            string sql, fecha_fumigado;

            try
            {
                fecha_fumigado = parPallet.fecha_proceso;

            }
            catch
            {
                fecha_fumigado = "";

            }

            NewObjectKey = "";
            nLineaBlanco = 0;

            for (int i = 0; i <= 5000; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {

                    if (fecha_fumigado != "")
                    {
                        sql = "update OBTN ";
                        sql += "set U_Fumigado = 'Si' , U_FechaFumigacion = '" + fecha_fumigado + "' ";
                        sql += "where DistNumber = '" + nLote.ToString() + "' ";

                    }
                    else
                    {
                        sql = "update OBTN ";
                        sql += "set U_Fumigado = 'Si' , U_FechaFumigacion = getdate() ";
                        sql += "where DistNumber = '" + nLote.ToString() + "' ";

                    }

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                    ///// crear los lotes para las cajas
                    ///// 

                    nLineId = -1;

                    Query = "select max(LineId) as LineId from [@HDV_OFUMI] where DistNumber = '" + nLote.ToString() + "' ";

                    RS.DoQuery(Query);

                    if (!RS.EoF) 
                    {
                        nLineId = int.Parse(RS.Fields.Item(0).Value.ToString());
                    }

                    nLineId += 1;

                    if (fecha_fumigado != "")
                    {
                        sql = "insert [@HDV_OFUMI] ( DistNumber, LineId, U_Fumigado, U_FechaFumigacion, U_Referencia ) ";
                        sql += "values ( '" + nLote.ToString() + "' , " + nLineId + " , 'Si' ,  '" + fecha_fumigado + "' , '' ) ";

                    }
                    else
                    {
                        sql = "insert [@HDV_OFUMI] ( DistNumber, LineId, U_Fumigado, U_FechaFumigacion, U_Referencia ) ";
                        sql += "values ( '" + nLote.ToString() + "' , " + nLineId + " , 'Si' ,  getdate() , '' ) ";

                    }

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                }

                if (nLote == 0)
                {
                    nLineaBlanco += 1;
                }

                if (nLineaBlanco == 5)
                {
                    break;
                }

            }

            return NewObjectKey;

        }

        public string Fumiga_Lote1(cldOrdenFabricacion parPallet)
        {

            int nLote, nLineaBlanco;

            nLineaBlanco = 0;

            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");

            for (int i = 0; i <= 5000; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {

                    try
                    {
                        SqlConexion.Open();

                        SqlCommand SqlComando = new SqlCommand();
                        SqlComando.Connection = SqlConexion;
                        SqlComando.CommandText = "dbo.SAPB1_FUM1";
                        SqlComando.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParDocentry = new SqlParameter();
                        ParDocentry.ParameterName = "@DocEntry";
                        ParDocentry.SqlDbType = SqlDbType.Int;
                        ParDocentry.Value = parPallet.DocEntry;
                        SqlComando.Parameters.Add(ParDocentry);

                        SqlParameter ParLineId = new SqlParameter();
                        ParLineId.ParameterName = "@LineId";
                        ParLineId.SqlDbType = SqlDbType.Int;
                        ParLineId.Value = parPallet.LineNum;
                        SqlComando.Parameters.Add(ParLineId);

                        SqlParameter ParLote = new SqlParameter();
                        ParLote.ParameterName = "@Lote";
                        ParLote.SqlDbType = SqlDbType.Int;
                        ParLote.Value = nLote;
                        SqlComando.Parameters.Add(ParLote);

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

                }

                ///// crear los lotes para las cajas
                ///// 

                //sql = "insert [@HDV_FUM1] ( DocEntry , LineId , U_DistNumber ) ";
                //sql += "values ( " + parPallet.DocEntry.ToString() + " , " + nLineId + " , '" + nLote.ToString() + "' ) ";

                if (nLote == 0)
                {
                    nLineaBlanco += 1;
                }

                if (nLineaBlanco == 5)
                {
                    break;
                }


            }

            return Respuesta;

        }

        public string Fumiga_Lote_En(cldOrdenFabricacion parPallet)
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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.Recordset RS;
            RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string Query = string.Empty;

            int nLote, nLineId, nLineaBlanco;

            string sql, fecha_fumigado;

            try
            {
                fecha_fumigado = parPallet.fecha_proceso;

            }
            catch
            {
                fecha_fumigado = "";

            }

            NewObjectKey = "";
            nLineaBlanco = 0;

            for (int i = 0; i <= 5000; i++)
            {

                try
                {
                    nLote = int.Parse(parPallet.arrDetalle[1, i]);

                }
                catch
                {
                    nLote = 0;
                }

                if (nLote > 0)
                {

                    if (fecha_fumigado != "")
                    {
                        sql = "update OBTN ";
                        sql += "set U_Fumigado = 'En' , U_FechaFumigacion = '" + fecha_fumigado + "' ";
                        sql += "where DistNumber = '" + nLote.ToString() + "' ";

                    }
                    else
                    {
                        sql = "update OBTN ";
                        sql += "set U_Fumigado = 'En' , U_FechaFumigacion = getdate() ";
                        sql += "where DistNumber = '" + nLote.ToString() + "' ";

                    }

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                    ///// crear los lotes para las cajas
                    ///// 

                    nLineId = -1;

                    Query = "select max(LineId) as LineId from [@HDV_OFUMI] where DistNumber = '" + nLote.ToString() + "' ";

                    RS.DoQuery(Query);

                    if (!RS.EoF)
                    {
                        nLineId = int.Parse(RS.Fields.Item(0).Value.ToString());
                    }

                    nLineId += 1;

                    if (fecha_fumigado != "")
                    {
                        sql = "insert [@HDV_OFUMI] ( DistNumber, LineId, U_Fumigado, U_FechaFumigacion, U_Referencia ) ";
                        sql += "values ( '" + nLote.ToString() + "' , " + nLineId + " , 'En' ,  '" + fecha_fumigado + "' , '' ) ";

                    }
                    else
                    {
                        sql = "insert [@HDV_OFUMI] ( DistNumber, LineId, U_Fumigado, U_FechaFumigacion, U_Referencia ) ";
                        sql += "values ( '" + nLote.ToString() + "' , " + nLineId + " , 'En' ,  getdate() , '' ) ";

                    }

                    this.ComandoSql = sql;
                    this.GestorSqlConsultar();

                }

                if (nLote == 0)
                {
                    nLineaBlanco += 1;
                }

                if (nLineaBlanco == 5)
                {
                    break;
                }

            }

            return NewObjectKey;

        }

        public string CambiaCalibre_Lote(cldOrdenFabricacion parLote)
        {
            string NewObjectKey;

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
            sbo_HDV_P03.UserName = parLote.UsuarioSap;
            sbo_HDV_P03.Password = parLote.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.BatchNumberDetailsService oLote;
            SAPbobsCOM.BatchNumberDetailParams oLoteParams;
            SAPbobsCOM.BatchNumberDetail oLoteDetail;

            try
            {
                oLote = (SAPbobsCOM.BatchNumberDetailsService)sbo_HDV_P03.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);

            }
            catch
            {
                errMsg = "Error de Conexión!!!!";

                NewObjectKey = errMsg;

                return NewObjectKey;

            }

            try
            {
                oLoteDetail = (SAPbobsCOM.BatchNumberDetail)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetail);

            }
            catch
            {
                errMsg = "Error de Conexión!!!!";

                NewObjectKey = errMsg;

                return NewObjectKey;

            }

            try
            {
                oLoteParams = (SAPbobsCOM.BatchNumberDetailParams)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);
            }
            catch
            {
                errMsg = "Error de Conexión!!!!";

                NewObjectKey = errMsg;

                return NewObjectKey;

            }

            oLoteParams.DocEntry = parLote.Lote;
            oLoteDetail = oLote.Get(oLoteParams);

            //oLoteDetail.UserFields.Item("U_VOLTEADOS").Value = 1; 
            oLoteDetail.UserFields.Item("U_Calibre").Value = parLote.Calibre;

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////
            // iniciamos transaccion 


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

            sbo_HDV_P03 = null;

            return NewObjectKey;


        }

        public string SAPB1_OTARJA(cldOrdenFabricacion parProduccion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OTARJA";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parProduccion.accion.Length;
                ParAccion.Value = parProduccion.accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = parProduccion.Turno.Length;
                ParTurno.Value = parProduccion.Turno;
                SqlComando.Parameters.Add(ParTurno);

                SqlParameter ParLun = new SqlParameter();
                ParLun.ParameterName = "@lun";
                ParLun.SqlDbType = SqlDbType.VarChar;
                ParLun.Size = parProduccion.lun.Length;
                ParLun.Value = parProduccion.lun;
                SqlComando.Parameters.Add(ParLun);

                SqlParameter ParMar = new SqlParameter();
                ParMar.ParameterName = "@mar";
                ParMar.SqlDbType = SqlDbType.VarChar;
                ParMar.Size = parProduccion.mar.Length;
                ParMar.Value = parProduccion.mar;
                SqlComando.Parameters.Add(ParMar);

                SqlParameter ParMie= new SqlParameter();
                ParMie.ParameterName = "@mie";
                ParMie.SqlDbType = SqlDbType.VarChar;
                ParMie.Size = parProduccion.mie.Length;
                ParMie.Value = parProduccion.mie;
                SqlComando.Parameters.Add(ParMie);

                SqlParameter ParJue = new SqlParameter();
                ParJue.ParameterName = "@jue";
                ParJue.SqlDbType = SqlDbType.VarChar;
                ParJue.Size = parProduccion.jue.Length;
                ParJue.Value = parProduccion.jue;
                SqlComando.Parameters.Add(ParJue);

                SqlParameter ParVie = new SqlParameter();
                ParVie.ParameterName = "@vie";
                ParVie.SqlDbType = SqlDbType.VarChar;
                ParVie.Size = parProduccion.vie.Length;
                ParVie.Value = parProduccion.vie;
                SqlComando.Parameters.Add(ParVie);

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

        public string SAPB1_OPRODUCCION7(cldOrdenFabricacion parProduccion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION7";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUsuario);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = parProduccion.Status.Length;
                ParEstado.Value = parProduccion.Status;
                SqlComando.Parameters.Add(ParEstado);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha_creacion";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Size = parProduccion.DocDate.Length;
                ParFecha.Value = parProduccion.DocDate;
                SqlComando.Parameters.Add(ParFecha);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = parProduccion.Turno.Length;
                ParTurno.Value = parProduccion.Turno;
                SqlComando.Parameters.Add(ParTurno);

                SqlParameter ParUsu_autorizador = new SqlParameter();
                ParUsu_autorizador.ParameterName = "@usu_autorizador";
                ParUsu_autorizador.SqlDbType = SqlDbType.Int;
                ParUsu_autorizador.Value = parProduccion.User_Autorizador;
                SqlComando.Parameters.Add(ParUsu_autorizador);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = parProduccion.Area.Length;
                ParArea.Value = parProduccion.Area;
                SqlComando.Parameters.Add(ParArea);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = parProduccion.Comments.Length;
                ParObs.Value = parProduccion.Comments;
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parProduccion.Warehouse.Length;
                ParWhsCode.Value = parProduccion.Warehouse;
                SqlComando.Parameters.Add(ParWhsCode);

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

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Grabo los detalles 

            int nLineId_D, nNumOF, nLote;
            int nDocEntryRef;
            string cItemCode_D, cItemName_D, cWareHouse_D;
            string cNota_D, cOrcCode_D, cOrcCode2_D;
            string cOrcCode3_D;
            double nCantidad_D;

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Borro los registros

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@lineid";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = -1;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@itemcode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = "".Length;
                ParItemCode.Value = "";
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.Int;
                ParLote.Value = 0;
                SqlComando.Parameters.Add(ParLote);

                SqlParameter ParNumOf = new SqlParameter();
                ParNumOf.ParameterName = "@numof";
                ParNumOf.SqlDbType = SqlDbType.Int;
                ParNumOf.Value = 0;
                SqlComando.Parameters.Add(ParNumOf);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = 0;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = "".Length;
                ParObs.Value = "";
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = "".Length;
                ParWhsCode.Value = "";
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter Pardocentryref = new SqlParameter();
                Pardocentryref.ParameterName = "@docentry_ref";
                Pardocentryref.SqlDbType = SqlDbType.Int;
                Pardocentryref.Value = 0;
                SqlComando.Parameters.Add(Pardocentryref);

                SqlParameter ParOcrCode = new SqlParameter();
                ParOcrCode.ParameterName = "@ocrcode";
                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                ParOcrCode.Size = "".Length;
                ParOcrCode.Value = "";
                SqlComando.Parameters.Add(ParOcrCode);

                SqlParameter ParOcrCode2 = new SqlParameter();
                ParOcrCode2.ParameterName = "@ocrcode2";
                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                ParOcrCode2.Size = "".Length;
                ParOcrCode2.Value = "";
                SqlComando.Parameters.Add(ParOcrCode2);

                SqlParameter ParOcrCode3 = new SqlParameter();
                ParOcrCode3.ParameterName = "@ocrcode3";
                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                ParOcrCode3.Size = "".Length;
                ParOcrCode3.Value = "";
                SqlComando.Parameters.Add(ParOcrCode3);

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


            for (int i = 0; i <= 99; i++)
            {

                try
                {
                    nLineId_D = int.Parse(parProduccion.arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = parProduccion.arrDetalle[2, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = parProduccion.arrDetalle[3, i];
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    nLote = Convert.ToInt32(parProduccion.arrDetalle[4, i]);
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    nNumOF = Convert.ToInt32(parProduccion.arrDetalle[5, i]);
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(parProduccion.arrDetalle[6, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    cWareHouse_D = parProduccion.arrDetalle[7, i];
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cNota_D = parProduccion.arrDetalle[8, i];
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = int.Parse(parProduccion.arrDetalle[9, i]);
                }
                catch
                {
                    nDocEntryRef = 0;
                }
                
                try
                {
                    cOrcCode_D = parProduccion.arrDetalle[10, i];
                }
                catch
                {
                    cOrcCode_D = "";
                }

                try
                {
                    cOrcCode2_D = parProduccion.arrDetalle[11, i];
                }
                catch
                {
                    cOrcCode2_D = "";
                }

                try
                {
                    cOrcCode3_D = parProduccion.arrDetalle[12, i];
                }
                catch
                {
                    cOrcCode3_D = "";
                }


                if (nLineId_D >= 0)
                {

                    if (cItemCode_D != "")
                    {

                        if (nCantidad_D > 0)
                        {
                            try
                            {
                                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                                SqlConexion.Open();

                                SqlCommand SqlComando = new SqlCommand();
                                SqlComando.Connection = SqlConexion;
                                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8";
                                SqlComando.CommandType = CommandType.StoredProcedure;

                                SqlParameter Parid_docentry = new SqlParameter();
                                Parid_docentry.ParameterName = "@id_docentry";
                                Parid_docentry.SqlDbType = SqlDbType.Int;
                                Parid_docentry.Value = parProduccion.DocEntry;
                                SqlComando.Parameters.Add(Parid_docentry);

                                SqlParameter ParLineId = new SqlParameter();
                                ParLineId.ParameterName = "@lineid";
                                ParLineId.SqlDbType = SqlDbType.Int;
                                ParLineId.Value = nLineId_D;
                                SqlComando.Parameters.Add(ParLineId);

                                SqlParameter ParItemCode = new SqlParameter();
                                ParItemCode.ParameterName = "@itemcode";
                                ParItemCode.SqlDbType = SqlDbType.VarChar;
                                ParItemCode.Size = cItemCode_D.Length;
                                ParItemCode.Value = cItemCode_D;
                                SqlComando.Parameters.Add(ParItemCode);

                                SqlParameter ParLote = new SqlParameter();
                                ParLote.ParameterName = "@lote";
                                ParLote.SqlDbType = SqlDbType.Int;
                                ParLote.Value = nLote;
                                SqlComando.Parameters.Add(ParLote);

                                SqlParameter ParNumOf = new SqlParameter();
                                ParNumOf.ParameterName = "@numof";
                                ParNumOf.SqlDbType = SqlDbType.Int;
                                ParNumOf.Value = nNumOF;
                                SqlComando.Parameters.Add(ParNumOf);

                                SqlParameter ParCantidad = new SqlParameter();
                                ParCantidad.ParameterName = "@cantidad";
                                ParCantidad.SqlDbType = SqlDbType.Float;
                                ParCantidad.Value = nCantidad_D;
                                SqlComando.Parameters.Add(ParCantidad);

                                SqlParameter ParObs = new SqlParameter();
                                ParObs.ParameterName = "@obs";
                                ParObs.SqlDbType = SqlDbType.VarChar;
                                ParObs.Size = cNota_D.Length;
                                ParObs.Value = cNota_D;
                                SqlComando.Parameters.Add(ParObs);

                                SqlParameter ParWhsCode = new SqlParameter();
                                ParWhsCode.ParameterName = "@whscode";
                                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                                ParWhsCode.Size = cWareHouse_D.Length;
                                ParWhsCode.Value = cWareHouse_D;
                                SqlComando.Parameters.Add(ParWhsCode);

                                SqlParameter Pardocentryref = new SqlParameter();
                                Pardocentryref.ParameterName = "@docentry_ref";
                                Pardocentryref.SqlDbType = SqlDbType.Int;
                                Pardocentryref.Value = nDocEntryRef;
                                SqlComando.Parameters.Add(Pardocentryref);

                                SqlParameter ParOcrCode = new SqlParameter();
                                ParOcrCode.ParameterName = "@ocrcode";
                                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode.Size = cOrcCode_D.Length;
                                ParOcrCode.Value = cOrcCode_D;
                                SqlComando.Parameters.Add(ParOcrCode);

                                SqlParameter ParOcrCode2 = new SqlParameter();
                                ParOcrCode2.ParameterName = "@ocrcode2";
                                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode2.Size = cOrcCode2_D.Length;
                                ParOcrCode2.Value = cOrcCode2_D;
                                SqlComando.Parameters.Add(ParOcrCode2);

                                SqlParameter ParOcrCode3 = new SqlParameter();
                                ParOcrCode3.ParameterName = "@ocrcode3";
                                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode3.Size = cOrcCode3_D.Length;
                                ParOcrCode3.Value = cOrcCode3_D;
                                SqlComando.Parameters.Add(ParOcrCode3);

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

                        }

                    }

                }

            }

            return Respuesta;
        }

        public string SAPB1_OPRODUCCION7v1(cldOrdenFabricacion parProduccion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION7v1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUsuario);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = parProduccion.Status.Length;
                ParEstado.Value = parProduccion.Status;
                SqlComando.Parameters.Add(ParEstado);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha_creacion";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Size = parProduccion.DocDate.Length;
                ParFecha.Value = parProduccion.DocDate;
                SqlComando.Parameters.Add(ParFecha);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = parProduccion.Turno.Length;
                ParTurno.Value = parProduccion.Turno;
                SqlComando.Parameters.Add(ParTurno);

                SqlParameter ParUsu_autorizador = new SqlParameter();
                ParUsu_autorizador.ParameterName = "@usu_autorizador";
                ParUsu_autorizador.SqlDbType = SqlDbType.Int;
                ParUsu_autorizador.Value = parProduccion.User_Autorizador;
                SqlComando.Parameters.Add(ParUsu_autorizador);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = parProduccion.Area.Length;
                ParArea.Value = parProduccion.Area;
                SqlComando.Parameters.Add(ParArea);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = parProduccion.Comments.Length;
                ParObs.Value = parProduccion.Comments;
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parProduccion.Warehouse.Length;
                ParWhsCode.Value = parProduccion.Warehouse;
                SqlComando.Parameters.Add(ParWhsCode);

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

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Grabo los detalles 

            int nLineId_D, nNumOF, nLote;
            int nDocEntryRef;
            string cItemCode_D, cItemName_D, cWareHouse_D;
            string cNota_D, cOrcCode_D, cOrcCode2_D;
            string cOrcCode3_D;
            double nCantidad_D;

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Borro los registros

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8v1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@lineid";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = -1;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@itemcode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = "".Length;
                ParItemCode.Value = "";
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.Int;
                ParLote.Value = 0;
                SqlComando.Parameters.Add(ParLote);

                SqlParameter ParNumOf = new SqlParameter();
                ParNumOf.ParameterName = "@numof";
                ParNumOf.SqlDbType = SqlDbType.Int;
                ParNumOf.Value = 0;
                SqlComando.Parameters.Add(ParNumOf);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = 0;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = "".Length;
                ParObs.Value = "";
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = "".Length;
                ParWhsCode.Value = "";
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter Pardocentryref = new SqlParameter();
                Pardocentryref.ParameterName = "@docentry_ref";
                Pardocentryref.SqlDbType = SqlDbType.Int;
                Pardocentryref.Value = 0;
                SqlComando.Parameters.Add(Pardocentryref);

                SqlParameter ParOcrCode = new SqlParameter();
                ParOcrCode.ParameterName = "@ocrcode";
                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                ParOcrCode.Size = "".Length;
                ParOcrCode.Value = "";
                SqlComando.Parameters.Add(ParOcrCode);

                SqlParameter ParOcrCode2 = new SqlParameter();
                ParOcrCode2.ParameterName = "@ocrcode2";
                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                ParOcrCode2.Size = "".Length;
                ParOcrCode2.Value = "";
                SqlComando.Parameters.Add(ParOcrCode2);

                SqlParameter ParOcrCode3 = new SqlParameter();
                ParOcrCode3.ParameterName = "@ocrcode3";
                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                ParOcrCode3.Size = "".Length;
                ParOcrCode3.Value = "";
                SqlComando.Parameters.Add(ParOcrCode3);

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

            int nLineas_en_Blanco;

            nLineas_en_Blanco = 0;

            for (int i = 0; i <= 99; i++)
            {

                try
                {
                    nLineId_D = int.Parse(parProduccion.arrDetalle[1, i]);
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = parProduccion.arrDetalle[2, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cItemName_D = parProduccion.arrDetalle[3, i];
                }
                catch
                {
                    cItemName_D = "";
                }

                try
                {
                    nLote = Convert.ToInt32(parProduccion.arrDetalle[4, i]);
                }
                catch
                {
                    nLote = 0;
                }

                try
                {
                    nNumOF = Convert.ToInt32(parProduccion.arrDetalle[5, i]);
                }
                catch
                {
                    nNumOF = 0;
                }

                try
                {
                    nCantidad_D = Convert.ToDouble(parProduccion.arrDetalle[6, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    cWareHouse_D = parProduccion.arrDetalle[7, i];
                }
                catch
                {
                    cWareHouse_D = "";
                }

                try
                {
                    cNota_D = parProduccion.arrDetalle[8, i];
                }
                catch
                {
                    cNota_D = "";
                }

                try
                {
                    nDocEntryRef = int.Parse(parProduccion.arrDetalle[9, i]);
                }
                catch
                {
                    nDocEntryRef = 0;
                }

                try
                {
                    cOrcCode_D = parProduccion.arrDetalle[10, i];
                }
                catch
                {
                    cOrcCode_D = "";
                }

                try
                {
                    cOrcCode2_D = parProduccion.arrDetalle[11, i];
                }
                catch
                {
                    cOrcCode2_D = "";
                }

                try
                {
                    cOrcCode3_D = parProduccion.arrDetalle[12, i];
                }
                catch
                {
                    cOrcCode3_D = "";
                }

                if (cItemCode_D == "")
                {
                    nLineas_en_Blanco += 1;

                }

                if (nLineas_en_Blanco == 3)
                {
                    break;

                }

                if (nLineId_D >= 0)
                {

                    if (cItemCode_D != "")
                    {

                        if (nCantidad_D > 0)
                        {
                            try
                            {
                                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                                SqlConexion.Open();

                                SqlCommand SqlComando = new SqlCommand();
                                SqlComando.Connection = SqlConexion;
                                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8v1";
                                SqlComando.CommandType = CommandType.StoredProcedure;

                                SqlParameter Parid_docentry = new SqlParameter();
                                Parid_docentry.ParameterName = "@id_docentry";
                                Parid_docentry.SqlDbType = SqlDbType.Int;
                                Parid_docentry.Value = parProduccion.DocEntry;
                                SqlComando.Parameters.Add(Parid_docentry);

                                SqlParameter ParLineId = new SqlParameter();
                                ParLineId.ParameterName = "@lineid";
                                ParLineId.SqlDbType = SqlDbType.Int;
                                ParLineId.Value = nLineId_D;
                                SqlComando.Parameters.Add(ParLineId);

                                SqlParameter ParItemCode = new SqlParameter();
                                ParItemCode.ParameterName = "@itemcode";
                                ParItemCode.SqlDbType = SqlDbType.VarChar;
                                ParItemCode.Size = cItemCode_D.Length;
                                ParItemCode.Value = cItemCode_D;
                                SqlComando.Parameters.Add(ParItemCode);

                                SqlParameter ParLote = new SqlParameter();
                                ParLote.ParameterName = "@lote";
                                ParLote.SqlDbType = SqlDbType.Int;
                                ParLote.Value = nLote;
                                SqlComando.Parameters.Add(ParLote);

                                SqlParameter ParNumOf = new SqlParameter();
                                ParNumOf.ParameterName = "@numof";
                                ParNumOf.SqlDbType = SqlDbType.Int;
                                ParNumOf.Value = nNumOF;
                                SqlComando.Parameters.Add(ParNumOf);

                                SqlParameter ParCantidad = new SqlParameter();
                                ParCantidad.ParameterName = "@cantidad";
                                ParCantidad.SqlDbType = SqlDbType.Float;
                                ParCantidad.Value = nCantidad_D;
                                SqlComando.Parameters.Add(ParCantidad);

                                SqlParameter ParObs = new SqlParameter();
                                ParObs.ParameterName = "@obs";
                                ParObs.SqlDbType = SqlDbType.VarChar;
                                ParObs.Size = cNota_D.Length;
                                ParObs.Value = cNota_D;
                                SqlComando.Parameters.Add(ParObs);

                                SqlParameter ParWhsCode = new SqlParameter();
                                ParWhsCode.ParameterName = "@whscode";
                                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                                ParWhsCode.Size = cWareHouse_D.Length;
                                ParWhsCode.Value = cWareHouse_D;
                                SqlComando.Parameters.Add(ParWhsCode);

                                SqlParameter Pardocentryref = new SqlParameter();
                                Pardocentryref.ParameterName = "@docentry_ref";
                                Pardocentryref.SqlDbType = SqlDbType.Int;
                                Pardocentryref.Value = nDocEntryRef;
                                SqlComando.Parameters.Add(Pardocentryref);

                                SqlParameter ParOcrCode = new SqlParameter();
                                ParOcrCode.ParameterName = "@ocrcode";
                                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode.Size = cOrcCode_D.Length;
                                ParOcrCode.Value = cOrcCode_D;
                                SqlComando.Parameters.Add(ParOcrCode);

                                SqlParameter ParOcrCode2 = new SqlParameter();
                                ParOcrCode2.ParameterName = "@ocrcode2";
                                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode2.Size = cOrcCode2_D.Length;
                                ParOcrCode2.Value = cOrcCode2_D;
                                SqlComando.Parameters.Add(ParOcrCode2);

                                SqlParameter ParOcrCode3 = new SqlParameter();
                                ParOcrCode3.ParameterName = "@ocrcode3";
                                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode3.Size = cOrcCode3_D.Length;
                                ParOcrCode3.Value = cOrcCode3_D;
                                SqlComando.Parameters.Add(ParOcrCode3);

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

                        }

                    }

                }

            }

            return Respuesta;
        }

        public string SAPB1_OPRODUCCION7v2(cldOrdenFabricacion parProduccion)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION7v2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUsuario);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = parProduccion.Status.Length;
                ParEstado.Value = parProduccion.Status;
                SqlComando.Parameters.Add(ParEstado);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha_creacion";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Size = parProduccion.DocDate.Length;
                ParFecha.Value = parProduccion.DocDate;
                SqlComando.Parameters.Add(ParFecha);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = parProduccion.Turno.Length;
                ParTurno.Value = parProduccion.Turno;
                SqlComando.Parameters.Add(ParTurno);

                SqlParameter ParUsu_autorizador = new SqlParameter();
                ParUsu_autorizador.ParameterName = "@usu_autorizador";
                ParUsu_autorizador.SqlDbType = SqlDbType.Int;
                ParUsu_autorizador.Value = parProduccion.User_Autorizador;
                SqlComando.Parameters.Add(ParUsu_autorizador);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = parProduccion.Area.Length;
                ParArea.Value = parProduccion.Area;
                SqlComando.Parameters.Add(ParArea);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = parProduccion.Comments.Length;
                ParObs.Value = parProduccion.Comments;
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parProduccion.Warehouse.Length;
                ParWhsCode.Value = parProduccion.Warehouse;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter Parid_docentryref = new SqlParameter();
                Parid_docentryref.ParameterName = "@id_docentry_ref";
                Parid_docentryref.SqlDbType = SqlDbType.Int;
                Parid_docentryref.Value = parProduccion.DocEntryRef; 
                SqlComando.Parameters.Add(Parid_docentryref);

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

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Grabo los detalles 

            int nLineId_D, nNumOF, nLote;
            int nDocEntryRef;
            //string cItemCode_D, cItemName_D, cWareHouse_D;
            string cItemCode_D, cWareHouse_D;
            string cNota_D, cOrcCode_D, cOrcCode2_D;
            string cOrcCode3_D;
            double nCantidad_D;

            //cItemName_D = "";

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // Borro los registros

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8v2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_docentry = new SqlParameter();
                Parid_docentry.ParameterName = "@id_docentry";
                Parid_docentry.SqlDbType = SqlDbType.Int;
                Parid_docentry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(Parid_docentry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@lineid";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = -1;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@itemcode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = "".Length;
                ParItemCode.Value = "";
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.Int;
                ParLote.Value = 0;
                SqlComando.Parameters.Add(ParLote);

                SqlParameter ParNumOf = new SqlParameter();
                ParNumOf.ParameterName = "@numof";
                ParNumOf.SqlDbType = SqlDbType.Int;
                ParNumOf.Value = 0;
                SqlComando.Parameters.Add(ParNumOf);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = 0;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = "".Length;
                ParObs.Value = "";
                SqlComando.Parameters.Add(ParObs);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@whscode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = "".Length;
                ParWhsCode.Value = "";
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter Pardocentryref = new SqlParameter();
                Pardocentryref.ParameterName = "@docentry_ref";
                Pardocentryref.SqlDbType = SqlDbType.Int;
                Pardocentryref.Value = 0;
                SqlComando.Parameters.Add(Pardocentryref);

                SqlParameter ParOcrCode = new SqlParameter();
                ParOcrCode.ParameterName = "@ocrcode";
                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                ParOcrCode.Size = "".Length;
                ParOcrCode.Value = "";
                SqlComando.Parameters.Add(ParOcrCode);

                SqlParameter ParOcrCode2 = new SqlParameter();
                ParOcrCode2.ParameterName = "@ocrcode2";
                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                ParOcrCode2.Size = "".Length;
                ParOcrCode2.Value = "";
                SqlComando.Parameters.Add(ParOcrCode2);

                SqlParameter ParOcrCode3 = new SqlParameter();
                ParOcrCode3.ParameterName = "@ocrcode3";
                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                ParOcrCode3.Size = "".Length;
                ParOcrCode3.Value = "";
                SqlComando.Parameters.Add(ParOcrCode3);

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

            int nNegativos;

            nNegativos = 0;

            for (int i = 0; i <= 99; i++)
            {

                try
                {
                    nLineId_D = int.Parse(parProduccion.arrDetalle[16, i]); 
                }
                catch
                {
                    nLineId_D = -1;
                }

                try
                {
                    cItemCode_D = parProduccion.arrDetalle[1, i];
                }
                catch
                {
                    cItemCode_D = "";
                }

                //cItemName_D = "";
                nLote = 0;
                nNumOF = 0;

                try
                {
                    nCantidad_D = Convert.ToDouble(parProduccion.arrDetalle[3, i]);
                }
                catch
                {
                    nCantidad_D = 0;
                }

                try
                {
                    cWareHouse_D = parProduccion.arrDetalle[2, i];
                }
                catch
                {
                    cWareHouse_D = "";
                }

                cNota_D = "";
                nDocEntryRef = 0;

                cOrcCode_D = "";
                cOrcCode2_D = "";
                cOrcCode3_D = "";

                if (nLineId_D == -1)
                {
                    nNegativos += 1;

                    if (nNegativos > 5)
                    {
                        break;
                    }

                }

                if (nLineId_D >= 0)
                {

                    if (cItemCode_D != "")
                    {

                        if (nCantidad_D > 0)
                        {
                            try
                            {
                                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                                SqlConexion.Open();

                                SqlCommand SqlComando = new SqlCommand();
                                SqlComando.Connection = SqlConexion;
                                SqlComando.CommandText = "dbo.SAPB1_OPRODUCCION8v2";
                                SqlComando.CommandType = CommandType.StoredProcedure;

                                SqlParameter Parid_docentry = new SqlParameter();
                                Parid_docentry.ParameterName = "@id_docentry";
                                Parid_docentry.SqlDbType = SqlDbType.Int;
                                Parid_docentry.Value = parProduccion.DocEntry;
                                SqlComando.Parameters.Add(Parid_docentry);

                                SqlParameter ParLineId = new SqlParameter();
                                ParLineId.ParameterName = "@lineid";
                                ParLineId.SqlDbType = SqlDbType.Int;
                                ParLineId.Value = nLineId_D;
                                SqlComando.Parameters.Add(ParLineId);

                                SqlParameter ParItemCode = new SqlParameter();
                                ParItemCode.ParameterName = "@itemcode";
                                ParItemCode.SqlDbType = SqlDbType.VarChar;
                                ParItemCode.Size = cItemCode_D.Length;
                                ParItemCode.Value = cItemCode_D;
                                SqlComando.Parameters.Add(ParItemCode);

                                SqlParameter ParLote = new SqlParameter();
                                ParLote.ParameterName = "@lote";
                                ParLote.SqlDbType = SqlDbType.Int;
                                ParLote.Value = nLote;
                                SqlComando.Parameters.Add(ParLote);

                                SqlParameter ParNumOf = new SqlParameter();
                                ParNumOf.ParameterName = "@numof";
                                ParNumOf.SqlDbType = SqlDbType.Int;
                                ParNumOf.Value = nNumOF;
                                SqlComando.Parameters.Add(ParNumOf);

                                SqlParameter ParCantidad = new SqlParameter();
                                ParCantidad.ParameterName = "@cantidad";
                                ParCantidad.SqlDbType = SqlDbType.Float;
                                ParCantidad.Value = nCantidad_D;
                                SqlComando.Parameters.Add(ParCantidad);

                                SqlParameter ParObs = new SqlParameter();
                                ParObs.ParameterName = "@obs";
                                ParObs.SqlDbType = SqlDbType.VarChar;
                                ParObs.Size = cNota_D.Length;
                                ParObs.Value = cNota_D;
                                SqlComando.Parameters.Add(ParObs);

                                SqlParameter ParWhsCode = new SqlParameter();
                                ParWhsCode.ParameterName = "@whscode";
                                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                                ParWhsCode.Size = cWareHouse_D.Length;
                                ParWhsCode.Value = cWareHouse_D;
                                SqlComando.Parameters.Add(ParWhsCode);

                                SqlParameter Pardocentryref = new SqlParameter();
                                Pardocentryref.ParameterName = "@docentry_ref";
                                Pardocentryref.SqlDbType = SqlDbType.Int;
                                Pardocentryref.Value = nDocEntryRef;
                                SqlComando.Parameters.Add(Pardocentryref);

                                SqlParameter ParOcrCode = new SqlParameter();
                                ParOcrCode.ParameterName = "@ocrcode";
                                ParOcrCode.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode.Size = cOrcCode_D.Length;
                                ParOcrCode.Value = cOrcCode_D;
                                SqlComando.Parameters.Add(ParOcrCode);

                                SqlParameter ParOcrCode2 = new SqlParameter();
                                ParOcrCode2.ParameterName = "@ocrcode2";
                                ParOcrCode2.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode2.Size = cOrcCode2_D.Length;
                                ParOcrCode2.Value = cOrcCode2_D;
                                SqlComando.Parameters.Add(ParOcrCode2);

                                SqlParameter ParOcrCode3 = new SqlParameter();
                                ParOcrCode3.ParameterName = "@ocrcode3";
                                ParOcrCode3.SqlDbType = SqlDbType.VarChar;
                                ParOcrCode3.Size = cOrcCode3_D.Length;
                                ParOcrCode3.Value = cOrcCode3_D;
                                SqlComando.Parameters.Add(ParOcrCode3);

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

                        }

                    }

                }

            }

            return Respuesta;
        }

    }

}
