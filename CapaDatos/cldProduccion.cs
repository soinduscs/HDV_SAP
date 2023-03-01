using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class cldProduccion : GestorSql
    {

        public string ItemCode { get; set; }
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public int UserSign { get; set; }
        public double Qauntity { get; set; }
        public string ToWH { get; set; }
        public string Referencia { get; set; }
        public int LineId { get; set; }
        public string Pallet { get; set; }
        public string Lote { get; set; }
        public string Fecha_Planificacion { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
        public double Peso { get; set; }
        public string UsuarioSap { get; set; }
        public string ClaveSap { get; set; }
        public int IdRegistro_rnd { get; set; }
        public int DocEntry_Consumo { get; set; }
        public string OrigCurr { get; set; }

        public static SAPbobsCOM.Company sbo_HDV_P03;
        public static int accesoMenuPrincipal;
        public static SAPbobsCOM.Recordset oRecordset;

        public void ConsultaLMateriales_SAP(string ItemCode)
        {

            string sql;

            sql = "select ";
            sql = sql + "t1.Father , t2.ItemName as FatherName , ";
            sql = sql + "t0.TreeType , t0.PriceList , t0.Qauntity , t0.UseFthrWhs , t0.CreateDate , ";
            sql = sql + "t0.UpdateDate , t0.Transfered , t0.DataSource , t0.UserSign , t0.SCNCounter , t0.DispCurr , ";
            sql = sql + "t0.ToWH , t0.Object , t0.LogInstac , t0.UserSign2 , t0.OcrCode ,  ";
            sql = sql + "t0.HideComp , t0.OcrCode2 , t0.OcrCode3 , t0.OcrCode4 , t0.OcrCode5 , t0.UpdateTime , ";
            sql = sql + "t0.Project , t0.PlAvgSize , t0.U_VID_InEm , t0.U_VID_QCStock ,  ";
            sql = sql + "t1.ChildNum , t1.Code , t3.ItemName as CodeName , t1.Quantity , t1.Warehouse , t1.Price , ";
            sql = sql + "t1.Currency , t1.PriceList , t1.OrigPrice , t1.OrigCurr , t1.IssueMthd , t1.Uom , ";
            sql = sql + "t1.Comment , t1.LogInstanc , t1.Object , t1.OcrCode , t1.OcrCode2 , t1.OcrCode3 , ";
            sql = sql + "t1.OcrCode4 , t1.OcrCode5 , t1.PrncpInput , t1.Project , t1.Type , t1.WipActCode , ";
            sql = sql + "t1.AddQuantit , t1.LineText ,  t1.U_IdOper , t1.U_VID_Pact  , ";
            sql = sql + "coalesce((select count(*) from ITT1 t5 where t5.Father = t0.Code ) , 0 ) as Cant_Items , ";
            sql = sql + "t4.U_Name as UserName  , ";
            sql = sql + "case when t0.TreeType = 'P' then 'Produccion' end as TipoLMat , ";
            sql = sql + "case when t1.PrncpInput = 'N' then 'Manual' end as MetodoEmision , ";
            sql = sql + "coalesce ( t3.InvntryUom , '' ) as InvntryUom_D , ";
            sql = sql + "coalesce ( ( select top 1 ta1.OnOrder from OITW ta1 where ta1.ItemCode = t2.ItemCode and ta1.WhsCode = t1.Warehouse ) , 0 ) as OnOrder_D , ";
            sql = sql + "case when t0.Qauntity <> 0 then t1.Quantity / t0.Qauntity else 0 end as Quantity_D ";

            sql = sql + "from OITT t0 ";
            sql = sql + "left join ITT1 t1 on t1.Father = t0.Code ";
            sql = sql + "left join OITM t2 on t2.ItemCode = t1.Father ";
            sql = sql + "left join OITM t3 on t3.ItemCode = t1.Code ";
            sql = sql + "left join OUSR t4 on t4.UserId = t0.UserSign ";

            sql = sql + "where t0.Code = '" + ItemCode + "' ";

            sql = sql + "order by t1.ChildNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_OFUM(int d_DocEntry)
        {

            string sql;

            sql = "select ";
            sql = sql + "t0.LineId , t0.U_DistNumber , ";
            sql = sql + "t1.ItemCode, t1.itemName , t2.U_fumigado as U_Fumigado , t2.U_fecha_fumigado ";

            sql = sql + "from [@HDV_FUM1] t0 ";
            sql = sql + "inner join OBTN t1 on t1.DistNumber = t0.U_DistNumber ";
            sql = sql + "inner join [@HDV_OFUM] t2 on t2.DocEntry = t0.DocEntry ";

            sql = sql + "where t0.DocEntry = " + d_DocEntry.ToString() + " ";

            sql = sql + "order by t0.LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_OFUM1(string d_lote)
        {

            string sql;

            sql = "select ";
            sql = sql + "t0.LineId , t0.U_DistNumber , t2.DOcEntry , ";
            sql = sql + "t1.ItemCode, t1.itemName , t1.U_Fumigado , t2.U_fecha_fumigado ";

            sql = sql + "from [@HDV_FUM1] t0 ";
            sql = sql + "inner join OBTN t1 on t1.DistNumber = t0.U_DistNumber ";
            sql = sql + "inner join [@HDV_OFUM] t2 on t2.DOcEntry = t0.DOcEntry ";

            sql = sql + "where t0.U_DistNumber = '" + d_lote.ToString() + "' ";

            sql = sql + "order by t0.LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_OFUM2(string d_fecha1, string d_fecha2)
        {

            string sql;

            sql = "select ";
            sql = sql + "t0.LineId , t0.U_DistNumber , t2.DOcEntry , ";
            sql = sql + "t1.ItemCode, t1.itemName , t1.U_Fumigado , t2.U_fecha_fumigado ";

            sql = sql + "from [@HDV_FUM1] t0 ";
            sql = sql + "inner join OBTN t1 on t1.DistNumber = t0.U_DistNumber ";
            sql = sql + "inner join [@HDV_OFUM] t2 on t2.DOcEntry = t0.DOcEntry ";

            sql = sql + "where t2.U_fecha_fumigado  between '" + d_fecha1 + "' and '" + d_fecha2 + "' ";

            sql = sql + "order by t2.DOcEntry , t0.U_DistNumber ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLMateriales(int DocEntry)
        {

            string sql;

            sql = "select ";
            sql = sql + "t0.DocEntry , t1.U_Father , t2.ItemName as FatherName , ";
            sql = sql + "'P' as TreeType , 1 as PriceList , t0.U_Qauntity as Father_Qauntity , 0 as UseFthrWhs , t0.CreateDate , ";
            sql = sql + "t0.U_ToWH as Father_ToWH  , t1.LineId , t1.U_Code , t3.ItemName as CodeName  ,  ";
            sql = sql + "t1.U_Quantity as U_Quantity_full , t1.U_Warehouse , t1.U_Price , ";
            sql = sql + "t1.U_Currency , t1.U_PriceList , t1.U_OrigPrice , t1.U_OrigCurr , ";
            sql = sql + "t3.InvntryUom , t0.U_Referencia , t0.U_Qauntity as Father_Qauntity , ";
            sql = sql + "t1.U_Quantity / t0.U_Qauntity AS U_Quantity , ";
            sql = sql + "t1.U_Quantity AS U_Quantity1 ";

            sql = sql + "from[@HDV_OLMAT] t0 ";
            sql = sql + "inner join[@HDV_LMAT1] t1 on t1.DocEntry = t0.DocEntry ";
            sql = sql + "left join OITM t2 on t2.ItemCode = t1.U_Father ";
            sql = sql + "left join OITM t3 on t3.ItemCode = t1.U_Code ";
            sql = sql + " ";
            sql = sql + "where t0.DocEntry = " + DocEntry + " ";
            sql = sql + "order by t1.LineId ";
            sql = sql + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLMateriales_Resumen(string ItemCode)
        {

            string sql;

            sql = "select ";
            sql = sql + "t0.DocEntry , t0.U_Referencia ,  t0.U_Code , t0.CreateDate , t0.UserSign  , t2.U_Name , count(*) as Cant_Items ";

            sql = sql + "from [@HDV_OLMAT] t0 ";
            sql = sql + "inner join [@HDV_LMAT1] t1 on t1.DocEntry = t0.DocEntry  ";
            sql = sql + "left join OUSR t2 on t2.UserId =  t0.UserSign   ";

            sql = sql + "where t0.U_Code = '" + ItemCode + "' ";

            sql = sql + "group by t0.DocEntry , t0.U_Referencia , t0.U_Code , t0.CreateDate , t0.UserSign  , t2.U_Name  ";

            sql = sql + "order by t0.DocEntry ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Almacenes()
        {

            string sql;

            sql = "select ";
            sql += "WhsCode , WhsName ";
            sql += "from OWHS ";
            sql += "order by WhsCode  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Almacenes_almacen()
        {

            string sql;

            sql = "select ";
            sql += "WhsCode , WhsName ";
            sql += "from OWHS ";
            sql += "where WhsCode not in ( select U_WhsCode from [dbo].[@HDV_OALMACEN] ) ";
            sql += "order by WhsCode  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_TipoCosecha()
        {

            string sql;

            sql = "select '' as TipoCosecha , '' as Nom_TipoCosecha ";
            sql += "union all ";
            sql += "select 'Manual' as TipoCosecha , 'Manual' as Nom_TipoCosecha ";
            sql += "union all ";
            sql += "select 'Mecanica' as TipoCosecha , 'Mecánica' as Nom_TipoCosecha ";
            sql += "union all ";
            sql += "select 'NoAplica' as TipoCosecha , 'No Aplica' as Nom_TipoCosecha ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_TipoFruta()
        {

            string sql;

            sql = "select Code , U_Code , LineId ";
            sql += "from [@HDV_OPROC] ";
            sql += "order by Code , LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_TipoFruta1()
        {

            string sql;

            sql = "select Code ";
            sql += "from [@HDV_OPROC] ";
            //sql += "where Code <> 'Todo Proc' ";
            sql += "group by Code ";
            //sql += "union all ";
            //sql += "select 'Todo Proceso' ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_TipoFruta2(string code)
        {

            string sql;

            sql = "select U_Code , Code , LineId ";
            sql += "from [@HDV_OPROC] ";

            sql += "where Code like '" + code +  "' " ;

            sql += "union all ";
            sql += "select ' Todo Proceso' , '' , 0 ";

            sql += "order by Code , LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void ConsultaLista_Dimension1()
        {

            string sql;

            sql = "select ";
            sql += "OcrCode , OcrName  ";
            sql += "from OOCR ";
            sql += "where DimCode = 1 ";
            sql += "and Active = 'Y' ";
            sql += "and OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() )  ";
            sql += "order by OcrCode ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Dimension2()
        {

            string sql;

            sql = "select ";
            sql += "OcrCode , OcrName  ";
            sql += "from OOCR ";
            sql += "where DimCode = 2 ";
            sql += "and Active = 'Y' ";
            sql += "and OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() )  ";
            sql += "order by OcrCode ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Dimension3()
        {

            string sql;

            sql = "select ";
            sql += "OcrCode , OcrName  ";
            sql += "from OOCR ";
            sql += "where DimCode = 3 ";
            sql += "and Active = 'Y' ";
            sql += "and OcrCode in ( select OcrCode from OCR1 where ValidTo is null union all select OcrCode from OCR1 where ValidTo <= getdate() )  ";
            sql += "order by OcrCode ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Turnos()
        {

            string sql;

            sql = "select ";
            sql += "FldValue , Descr ";
            sql += "from UFD1 ";
            sql += "where TableID = '@HDV_OINS' ";
            sql += "and FieldID = 0 ";
            sql += "order by FldValue ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_area()
        {

            string sql;

            sql = "select ";
            sql += "FldValue , Descr ";
            sql += "from UFD1 ";
            sql += "where TableID = '@HDV_OINS' ";
            sql += "and FieldID = 2 ";
            sql += "order by FldValue ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_MetodoEmision()
        {

            string sql;

            sql = "select 'M' as Code , 'Manual' as Descripcion ";
            sql += "union all ";
            sql += "select 'B' as Code , 'Notificación' as Descripcion ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Almacenes_X_Localidad(string cLocalidad)
        {

            string sql;

            sql = "select ";
            sql += "WhsCode , WhsName ";
            sql += "from OWHS ";
            sql += "where Location = '" + cLocalidad + "' ";
            sql += "order by WhsCode  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_numero_semana_actual()
        {
            string sql;

            sql = "select  DATEPART(week,getdate() ) as NumSemana_Actual ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }
        
        public void consulta_centros_costo_gestper()
        {
            string sql;

            sql = "select ";
            sql += "codigo , ltrim(rtrim(descripcion)) as descripcion ";
            sql += "from GestPer_Huertos_Valle_SA.dbo.centrocosto ";
            sql += "where substring ( codigo , 1,2) = '00' ";
            sql += "order by descripcion ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_dependencia1_gestper()
        {
            string sql;

            sql = "select ";
            sql += "codigo , ltrim(rtrim(descripcion)) as descripcion ";
            sql += "from GestPer_Huertos_Valle_SA.dbo.dependencia1 ";
            sql += "order by descripcion ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_dependencia1_gestper_v2()
        {
            string sql;

            sql = "select ";
            sql += "codigo , ltrim(rtrim(descripcion)) as descripcion ";
            sql += "from GestPer_Huertos_Valle_SA.dbo.dependencia1 ";
            sql += "union all ";
            sql += "select '%' as codigo , ' TODAS LAS AREAS' as descripcion ";
            sql += "order by descripcion ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_empleados_gestper(string c_nombre, string c_dependencia_no, string c_dependencia)
        {

            c_nombre = "%" + c_nombre.ToString() + "%";

            string sql;

            sql = "select ";
            sql += "t0.id_rut , ltrim(rtrim(t0.apellido)) + ' ' + ltrim(rtrim(t0.materno)) + ' ' + ltrim(rtrim(t0.nombre)) as nom_empleado , ";
            sql += "t0.do_dependencia1 , ltrim(rtrim(t4.descripcion)) as nom_dependencia1 ";

            sql += "from GestPer_Huertos_Valle_SA.dbo.personal t0 ";
            sql += "left join GestPer_Huertos_Valle_SA.dbo.dependencia1 t4 on t4.codigo = t0.do_dependencia1 collate SQL_Latin1_General_CP1_CI_AS ";
            sql += "left join GestPer_Huertos_Valle_SA.dbo.centrocosto t3 on t3.codigo = t0.ccosto collate SQL_Latin1_General_CP1_CI_AS ";

            sql += "where year(t0.f_finiquito) = 1900 ";
            sql += "and t0.rol = '000001' ";

            sql += "and t0.do_dependencia1 <> '" + c_dependencia_no.ToString() + "' ";
            sql += "and t0.do_dependencia1 like '" + c_dependencia.ToString() + "' ";

            sql += "and t0.id_rut in ( select t1.id_rut from GestPer_Huertos_Valle_SA.dbo.personal t1 where ( t0.apellido like '" + c_nombre.ToString() + "' or t0.materno like '" + c_nombre.ToString() + "' or t0.nombre  like '" + c_nombre.ToString() + "' ) ) ";

            sql += "order by nom_empleado ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_lista_de_turno()
        {
            string sql;

            sql = "select ";
            sql += "Codigo , ltrim(rtrim(Codigo)) + ' :: ' + Rango as Rango ";
            sql += "from [@HDV_OTURNO] ";
            sql += "order by Codigo ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_lista_de_status()
        {
            string sql;

            sql = "select ";
            sql += "Codigo ";
            sql += "from [@HDV_OSTAT] ";
            sql += "order by Codigo ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }
        public void consulta_lista_de_operadores()
        {
            string sql;

            sql = "select ";
            sql += "Code ";
            sql += "from [@HDV_OOPR] ";
            sql += "union all ";
            sql += "select ' ' as Code ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void consulta_lista_de_turno_x_codigo(string codigo)
        {
            string sql;

            sql = "select top 1 ";
            sql += "Codigo , Rango ";
            sql += "from [@HDV_OTURNO] ";
            sql += "where Codigo = '" + codigo + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }



        public void consulta_fechas_por_semana(int nNumSemana, int nAnho)
        {
            string sql;

            sql = "select dateadd(d,1, DateAdd(dayofyear, ( " + nNumSemana.ToString() + " - 1) * 7 - (datepart(dw,'01/01/" + nAnho.ToString() + "')- 1 ) , '01/01/" + nAnho.ToString() + "')) as FechaIni , dateadd(d,7, DateAdd(dayofyear, ( " + nNumSemana.ToString() + " - 1) * 7 - (datepart(dw,'01/01/" + nAnho.ToString() + "')- 1 ) , '01/01/" + nAnho.ToString() + "')) as FechaFin ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void xSapb1_utiles_muestratarjaporperiodo(string caccion, int nNumSemana, int nAnho, string ccosto, string cdependencia)
        {
            string sql;

            sql = "exec xSapb1_utiles_muestratarjaporperiodo '" + caccion + "' , " + nAnho.ToString() + " , " + nNumSemana.ToString() + "  , '" + ccosto + "' , '" + cdependencia + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void xSapb1_query_turnoscracker(int nAnho, int nMes, string carea)
        {
            string sql;

            sql = "exec xSapb1_query_turnoscracker " + nAnho.ToString() + " , " + nMes.ToString() + "  , '" + carea + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Almacenes_BM()
        {

            string sql;

            sql = "select ";
            sql += "WhsCode , WhsName ";
            sql += "from OWHS ";
            //sql += "where WhsCode like 'BM%' ";

            //sql += "union all ";

            //sql += "select ";
            //sql += "WhsCode , WhsName ";
            //sql += "from OWHS ";
            //sql += "where WhsCode like '%ACOPI' ";

            //sql += "union all ";

            //sql += "select ";
            //sql += "WhsCode , WhsName ";
            //sql += "from OWHS ";
            //sql += "where WhsCode like 'B_AU%' ";

            sql += "order by WhsCode  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Usuarios()
        {

            string sql;

            sql = "select USERID , U_NAME  ";
            sql += "from OUSR ";
            sql += "where U_NAME is not null ";
            sql += "and U_NAME not in ( '' ) ";
            sql += "order by U_NAME ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Ubicacion_Lote(string accion , string whscode, string sl1code)
        {

            string sql;

            sql = "exec SAPB1_UBICACION '" + accion + "' , '" + whscode + "' , '" + sl1code + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_PartidasAbiertas_Solicitudes()
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , coalesce ( t0.CardCode , '' ) as CardCode  , ";
            sql += "coalesce ( t0.CardName , '' ) as CardName ,  t0.Filler	,  ";
            sql += "convert ( varchar(10) , t0.DocDueDate , 105 ) as DocDate ,  ";
            sql += "t0.UserSign , t1.U_NAME ";
            sql += "from OWTQ t0 ";
            sql += "left join OUSR t1 on t1.USERID = t0.UserSign ";
            sql += "where t0.DocStatus = 'O' ";
            sql += "and t0.CANCELED = 'N' ";
            sql += "order by t0.CardName , t0.DocDueDate ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Solicitud_de_transferencia(string cDocEntry)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , coalesce ( t0.CardCode , '' ) as CardCode  , ";
            sql += "coalesce ( t0.CardName , '' ) as CardName ,  t0.Filler	,  ";
            sql += "convert ( varchar(10) , t0.DocDueDate , 105 ) as DocDate ,  ";
            sql += "t0.UserSign , t1.U_NAME ";
            sql += "from OWTQ t0 ";
            sql += "left join OUSR t1 on t1.USERID = t0.UserSign ";
            sql += "where t0.DocEntry = " + cDocEntry + " ";


            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Solicitud_de_transferencia_x_lote(string cDocEntry)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.LineNum , t0.Dscription as ItemName , t1.MdAbsEntry, t1.AllocQty + coalesce ( t2.AllocQty , 0 ) as AllocQty , t0.WhsCode , t0.FromWhsCod , t0.OcrCode ,  t0.OcrCode2 , t0.OcrCode3 , t0.ItemCode ";

            sql += "from WTQ1 t0 ";
            sql += "left join (select ta0.DocEntry, ta0.ItemCode, ta0.DocLine, ta1.MdAbsEntry, sum(ta1.AllocQty) as AllocQty from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 1250000001 ";
            sql += "group by ta0.DocEntry, ta0.ItemCode, ta0.DocLine, ta1.MdAbsEntry ) t1 on t1.DocEntry = t0.DocEntry and t1.DocLine = t0.LineNum  "; // and t1.AllocQty > 0

            sql += "left join (select ta0.BaseEntry, ta0.ItemCode, ta0.BaseLine, ta1.MdAbsEntry, sum(ta1.AllocQty) as AllocQty from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.BaseType = 1250000001 ";
            sql += "group by ta0.BaseEntry, ta0.ItemCode, ta0.BaseLine , ta1.MdAbsEntry ) t2 on t2.BaseEntry = t1.DocEntry and t2.BaseLine = t1.DocLine and t2.MdAbsEntry = t1.MdAbsEntry ";

            sql += "where t0.DocEntry = " + cDocEntry + " ";
            sql += "and t0.OpenQty > 0 ";
            sql += "order by t0.LineNum , t1.MdAbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consulta_Lote(string cLote)
        {

            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t0.itemName , t0.DistNumber , t0.AbsEntry ,  ";
            sql += "t0.Quantity - t0.QuantOut as Stock  ,  ";
            sql += "t1.WhsCode , t1.Quantity , t2.BuyUnitMsr , t3.BinCode , ";
            sql += "t0.U_FechaFumigacion , t0.U_Fumigado , ";
            sql += "t0.U_NOMBCLI , t0.U_NOMBPROD , t0.U_BINS , ";
            sql += "case when t0.Status = 0 then 'Liberado' when t0.Status = 1 then 'Acceso denegado' when t0.Status = 2 then 'Bloqueado' end as nom_status , getdate() as fecha_hoy ";

            sql += "from OBTN t0 ";
            sql += "left join OIBT t1 on t1.ItemCode = t0.ItemCode and t1.BatchNum = t0.DistNumber and t1.Quantity > 0 ";
            sql += "inner join OITM t2 on t2.ItemCode = t0.ItemCode ";
            sql += "left join ( select t1.BinAbs , t2.BinCode , t2.AbsEntry , t2.WhsCode , sum(t0.Quantity) as Quantity , ";
            sql += "t0.MdAbsEntry as DistNumber from ITL1 t0  ";
            sql += "left join OBTL t1 on t1.ITLEntry = t0.LogEntry and t1.SnBMDAbs = t0.MdAbsEntry ";
            sql += "left join OBIN t2 on t2.AbsEntry = t1.BinAbs and t2.WhsCode in ( select top 1 WhsCode from vista_inventario_lotes_completa where DistNumber = '" + cLote + "' ) ";

            sql += "where t1.BinAbs not in ( 1 , 2 ) ";
            sql += "group by t1.BinAbs , t2.BinCode , t2.AbsEntry , t2.WhsCode , t0.MdAbsEntry )  t3 on t3.DistNumber = t0.DistNumber and t3.Quantity > 0 ";
            sql += " ";
            sql += " ";

            sql += "where t0.DistNumber = '" + cLote + "' ";

            sql += "order by t1.Quantity desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Lote_en_solicitud_transferencia(string cLote)
        {

            string sql;

            sql = "select ";
            sql += "t1.DocEntry , t1.DocDate , t2.LineNum , t2.ItemCode , t0.MdAbsEntry , t2.WhsCode , t0.AllocQty ";
            sql += "from ( select ta0.DocEntry, ta0.ItemCode, ta0.DocLine, ta1.MdAbsEntry, ta1.AllocQty from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 1250000001) t0 ";
            sql += "inner join OWTQ t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join WTQ1 t2 on t2.DocEntry = t1.DocEntry and t2.ItemCode = t0.ItemCode and t2.LineNum = t0.DocLine ";
            sql += "where t0.MdAbsEntry = '" + cLote + "' ";
            sql += "and t1.DocStatus = 'O' ";
            sql += "order by t1.DocDate desc ";
            sql += "  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Lote_y_Stock(string cLote, string cAlmacen)
        {

            string sql;

            sql = "select ";
            sql += "t0.ItemCode , t0.itemName , t0.DistNumber , t0.AbsEntry ,  ";
            sql += "t0.Quantity - t0.QuantOut as Stock  , t4.WhsCode ,  ";
            sql += "t2.BuyUnitMsr , "; // t3.BinCode , t1.WhsCode , t1.Quantity , 
            sql += "t0.U_FechaFumigacion , t0.U_Fumigado , coalesce ( t4.Quantity , 0 ) as Stock_Lote , ";
            sql += "coalesce ( t4.Ubicacion , '' ) as Ubicacion  , ";

            sql += "coalesce ( t5.OF_Asignada , 0 ) as OF_Asignada ";

            sql += "from OBTN t0 ";
            //sql += "left join OIBT t1 on t1.ItemCode = t0.ItemCode and t1.BatchNum = t0.DistNumber ";
            sql += "left join OITM t2 on t2.ItemCode = t0.ItemCode ";
            sql += "left join vista_inventario_lotes_completa t4 on t4.ItemCode = t0.ItemCode and t4.DistNumber = t0.DistNumber and t4.WhsCode like '" + cAlmacen + "'  and t4.WhsCode not in ( 'LABCC' ) ";

            sql += "left join (select T0.DocEntry as OF_Asignada, T1.MdAbsEntry, sum(t1.AllocQty) as CantAsignada ";
            sql += "from OITL T0 inner join ITl1 T1 ON T1.LogEntry = T0.LogEntry Where T0.DocType = '202' ";
            sql += "and T1.MdAbsEntry = " + cLote + " group by T0.DocEntry, T1.MdAbsEntry ) t5 on t5.MdAbsEntry = t0.DistNumber and CantAsignada > 0 ";

            //sql += "left join ( select t1.BinAbs , t2.BinCode , t2.AbsEntry , ";
            //sql += "t2.WhsCode , t2.SL1Code , coalesce ( t2.SL2Code , '' ) as SL2Code ,  ";
            //sql += "t3.ItemCode , t3.itemName , t3.DistNumber , sum(t0.Quantity) as Quantity ";
            //sql += "from ITL1 t0 ";
            //sql += "inner join OBTL t1 on t1.ITLEntry = t0.LogEntry  ";
            //sql += "inner join OBIN t2 on t2.AbsEntry = t1.BinAbs ";
            //sql += "inner join OBTN t3 on t3.Quantity > t3.QuantOut and t3.AbsEntry = t0.MdAbsEntry and t3.AbsEntry = t1.SnBMDAbs ";
            //sql += "group by t1.BinAbs , t2.BinCode , t2.AbsEntry , t2.WhsCode , t2.SL1Code , t2.SL2Code , ";
            //sql += "t3.ItemCode , t3.itemName , t3.DistNumber , t3.AbsEntry ) t3 on t3.DistNumber = t0.DistNumber and t3.Quantity > 0  ";
            sql += " ";

            sql += "where t0.DistNumber = '" + cLote + "' ";
            //sql += "and t1.WhsCode = '" + cAlmacen + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Ubicaciones()
        {

            string sql;

            sql = "select AbsEntry , BinCode from OBIN where SL1Code <> 'UBICACIÓN-DE-SISTEMA' order by BinCode ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Bodegas_Ubicaciones()
        {

            string sql;

            sql = "select ";
            sql += "WhsCode  ";
            sql += "from OBIN ";
            sql += "where SL1Code <> 'UBICACIÓN-DE-SISTEMA' ";
            sql += "group by WhsCode  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pasillo_Ubicaciones_x_bodegas(string WhsCode)
        {

            string sql;

            sql = "select ";
            sql += "SL1Code ";
            sql += "from OBIN ";
            sql += "where SL1Code <> 'UBICACIÓN-DE-SISTEMA' ";
            sql += "and WhsCode = '" + WhsCode + "' ";
            sql += "group by SL1Code ";

            sql += "union all select '' as SL1Code ";

            sql += "order by SL1Code  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pasillo_Ubicaciones_x_bodegas_i(string WhsCode)
        {

            string sql;

            sql = "select ";
            sql += "SL1Code ";
            sql += "from OBIN ";
            sql += "where SL1Code <> 'UBICACIÓN-DE-SISTEMA' ";
            sql += "and WhsCode = '" + WhsCode + "' ";
            sql += "group by SL1Code ";

            sql += "UNION ALL select ' [TODAS]' ";

            sql += "order by SL1Code  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pasillo_Ubicaciones_x_bodegas_y_pasillo(string WhsCode, string Pasillo)
        {

            string sql;

            sql = "select ";
            sql += "SL2Code ";
            sql += "from OBIN ";
            sql += "where SL1Code <> 'UBICACIÓN-DE-SISTEMA' ";
            sql += "and WhsCode = '" + WhsCode + "' ";
            sql += "and SL1Code = '" + Pasillo + "' ";
            sql += "group by SL2Code  ";
            sql += "order by SL2Code  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Bodegas_Ubicaciones_x_bincode(string BinCode)
        {

            string sql;

            sql = "select * ";
            sql += "from OBIN ";
            sql += "where BinCode = '" + BinCode + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Ubicaciones_x_bincode_y_bodega(string BinCode, string WhsCode)
        {

            string sql;

            sql = "select * ";
            sql += "from OBIN ";
            sql += "where BinCode = '" + BinCode + "' ";
            sql += "and WhsCode = '" + WhsCode + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consulta_OrdendeVenta_x_DocNum(int DocNum)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.DocDueDate  , ";
            sql += "t0.CardCode , t0.CardName , t0.UserSign , t0.CardCode , ";
            sql += "t2.LineNum , t2.ItemCode , t2.Dscription , t2.Quantity , ";
            sql += "t2.WhsCode , t2.OpenQty , t3.BuyUnitMsr , ";
            sql += "coalesce ( sum(t4.AllocQty) , 0 ) as AllocQty ";
            sql += " ";

            sql += "from ORDR t0 ";
            sql += "left join RDR1 t2 on t2.DocEntry = t0.DocEntry ";
            sql += "left join OITM t3 on t3.ItemCode = t2.ItemCode ";

            sql += "left join ( select t0.DocEntry , t0.DocLine , t1.MdAbsEntry  , t1.AllocQty as AllocQty  ";
            sql += "from OITL t0 inner join ITL1 t1 on t1.LogEntry = t0.LogEntry where t0.DocType = 17 ";
            sql += "and t0.DocQty > 0 ";
            sql += "group by t0.DocEntry , t0.DocLine , t1.MdAbsEntry, t1.AllocQty ) t4 on t4.DocEntry = t0.DocEntry and t4.DocLine = t2.LineNum ";
            sql += " ";

            sql += "Where t0.DocNum = " + DocNum + " ";

            sql += "group by t0.DocEntry , t0.DocNum , t0.DocDate , t0.DocDueDate  , t0.CardCode , t0.CardName , t0.UserSign , ";
            sql += "t0.CardCode , t2.LineNum , t2.ItemCode , t2.Dscription , t2.Quantity , t2.WhsCode , t2.OpenQty , t3.BuyUnitMsr ";

            sql += "order by t2.LineNum ";
 
            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OrdendeVenta_con_Entrega_x_DocNum(int DocNum)
        {

            string sql;

            sql = "exec SAPB1_UBICACION1 " + DocNum + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OrdendeVenta_Entre_Fechas()
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDueDate , t0.DocDate ,  t0.CardCode , t0.CardName , ";
            sql += "coalesce ( ( select top 1 t1.Dscription from RDR1 t1 where t1.DocEntry = t0.DocEntry and t1.OpenQty > 0 ) , '' ) as Dscription ,  ";
            sql += "coalesce ( ( select convert (float , sum(t1.OpenQty)) from RDR1 t1 where t1.DocEntry = t0.DocEntry and t1.OpenQty > 0 ) , '' ) as OpenQty ";
            sql += "from ORDR t0 ";
            sql += "where t0.DocEntry in ( select DocEntry from RDR1 where OpenQty > 0 ) ";
            sql += "order by t0.DocNum desc ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pallet()
        {

            string sql;

            sql = "select ";
            sql += "Code , U_BarCode , DocEntry , CreateDate , U_ItemCode , U_ItemName  , U_WhsCode  ";
            sql += "from [dbo].[@HDV_PALL]  ";
            sql += "where U_ItemCode is not null ";
            sql += "order by Code  desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pallet_x_Code(string cCode)
        {

            string sql;

            sql = "select ";
            sql += "t0.Code , t0.U_BarCode , t0.DocEntry , t0.CreateDate , ";
            sql += "t0.U_ItemCode , t0.U_ItemName  , t0.U_WhsCode  , ";
            sql += "t1.LineId , t1.U_AbsEntry , t1.U_DistNumber , ";
            sql += "t2.U_FechaFumigacion , t2.U_Fumigado ";

            sql += "from [@HDV_PALL]  t0 ";
            sql += "left join  [@HDV_PAL1] t1 on t1.Code = t0.Code ";
            sql += "left join OBTN t2 on t2.AbsEntry = t1.U_AbsEntry and t2.ItemCode = t0.U_ItemCode  ";

            sql += "where t0.Code = '" + cCode + "' ";
            sql += "order by t1.LineId ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public string Borra_Lote_de_Pallet(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "delete [@HDV_PAL1] ";
            sql += "where Code = '" + parPallet.Pallet + "' ";
            sql += "and U_AbsEntry = '" + parPallet.Lote + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }


        public void Consulta_Recibo_x_DocEntry_en_Detalle(int nDocEntry)
        {
            string sql;

            sql = "select top 1 * from Vista_ProcesosProductivos where NumeroDocto = " + nDocEntry;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public string Insert_Coordinar_Orden_Fabricacion(cldProduccion parPallet)
        {
            string sql = "";

            sql = "insert [@HDV_OWOR] ( DocEntry , DocNum ,  UserSign , CreateDate )  ";
            sql += "select " + parPallet.DocEntry + " , " + parPallet.DocEntry + " , " + parPallet.UserSign + " , getdate() ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();


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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;
            ProductionOF.GetByKey(parPallet.DocEntry);
            ProductionOF.StartDate = DateTime.ParseExact(parPallet.Fecha_Planificacion, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

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

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;       

        }


        public string Modificar_fecha_finalizacion_Orden_Fabricacion(cldProduccion parPallet)
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
            sbo_HDV_P03.UserName = parPallet.UsuarioSap;
            sbo_HDV_P03.Password = parPallet.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.ProductionOrders ProductionOF;
            ProductionOF = (SAPbobsCOM.ProductionOrders)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders);

            // datos de cabecera

            ProductionOF.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotStandard;
            ProductionOF.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned;
            ProductionOF.GetByKey(parPallet.DocEntry);
            ProductionOF.DueDate = DateTime.ParseExact(parPallet.Fecha_Planificacion, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

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

            try
            {
                sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg; // NewObjectKey;       


        }

        public string Borrar_Coordinar_Orden_Fabricacion(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "delete [@HDV_OWOR] ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Modifica_Destino_Secado_RecibeMP(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "update [@HDV_OROM] ";
            sql += "set U_ItemCode = 'Recibe_MP' ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Modifica_Destino_Secado_RecibeMPv2020(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "update OWOR ";
            sql += "set U_VID_LoFa = 'Recibe_MP' ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Modifica_Destino_OC_MPv2020(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "update OWOR ";
            sql += "set U_VID_InEm = '" + parPallet.DocNum + "' ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Modifica_Destino_Secado_EnviaCliente(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "update [@HDV_OROM] ";
            sql += "set U_ItemCode = 'Envia_Clte' ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Modifica_Destino_Secado_EnviaClientev2020(cldProduccion parPallet)
        {
            string sql = "", Respuesta = "";

            sql = "update OWOR ";
            sql += "set U_VID_LoFa = 'Envia_Clte' , U_VID_InEm = '' ";
            sql += "where DocEntry = " + parPallet.DocEntry;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public void Consulta_Productos_Sin_Pallet(string cItemCode, string cAlmacen)
        {

            string sql;

            sql = "select ";
            sql += "t1.DistNumber , t1.AbsEntry , t0.BatchNum ";
            sql += "from OIBT t0 ";
            sql += "inner join OBTN t1 on t1.DistNumber = t0.BatchNum and t1.ItemCode = t0.ItemCode and t1.U_FolioPallet = '' ";
            sql += "where t0.ItemCode = '" + cItemCode + "' ";
            sql += "and t0.WhsCode = '" + cAlmacen + "' ";
            sql += "and t0.Quantity > 0 ";

            sql += "union all ";

            sql += "select ";
            sql += "t1.DistNumber , t1.AbsEntry , t0.BatchNum ";
            sql += "from OIBT t0 ";
            sql += "inner join OBTN t1 on t1.DistNumber = t0.BatchNum and t1.ItemCode = t0.ItemCode and t1.U_FolioPallet is null ";
            sql += "where t0.ItemCode = '" + cItemCode + "' ";
            sql += "and t0.WhsCode = '" + cAlmacen + "' ";
            sql += "and t0.Quantity > 0 ";

            //sql += "order by AbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Pallet_x_Code_Almacen(string cCode, string cAlmacen)
        {

            string sql;

            sql = "select ";
            sql += "t0.Code , t0.U_BarCode , t0.DocEntry , t0.CreateDate , ";
            sql += "t0.U_ItemCode , t0.U_ItemName  , t0.U_WhsCode  , ";
            sql += "t1.LineId , t1.U_AbsEntry , t1.U_DistNumber , t2.DistNumber ";

            sql += "from [@HDV_PALL]  t0 ";
            sql += "left join  [@HDV_PAL1] t1 on t1.Code = t0.Code ";
            sql += "left join OBTN t2 on t2.AbsEntry = t1.U_AbsEntry and t2.ItemCode = t0.U_ItemCode  ";

            sql += "where t0.Code = '" + cCode + "' ";
            sql += "and t0.U_WhsCode = '" + cAlmacen + "' ";
            sql += "order by t1.LineId ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Variedad_en_Producto_de_Consumo(int NumOF)
        {

            string sql;

            sql = "select ";
            sql += "t2.U_HDV_VARIEDAD ";
            sql += "from IGE1 t0 ";
            sql += "inner join OITM t1 on t1.ItemCode = t0.ItemCode and t1.ItmsGrpCod not in (select ItmsGrpCod from OITM where ItemCode in (select Code from ITT1 where len(Father) > 20 and len(Code) < 20 ) ) ";
            sql += "inner join (select ta0.DocEntry, ta1.MdAbsEntry from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 60 ) t4 on t4.DocEntry = t0.DocEntry ";
            sql += "inner join OBTN t2 on t2.AbsEntry = t4.MdAbsEntry ";
            sql += "where t0.BaseRef = " + NumOF.ToString() + " ";
            sql += "group by t2.U_HDV_VARIEDAD ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Cant_Disponible_OC(int NumOF)
        {

            string sql;

            sql = "select top 1 ";
            sql += "t0.DocNum , t1.DocEntry , t1.ItemCode , t1.Quantity , t1.OpenQty ";
            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "WHERE t0.DocNum = " + NumOF.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consulta_Ultimo_Peso_Productivo(int NumOF, string cItemCode)
        {

            string sql;

            sql = "select top 1 * ";
            sql += "from vista_ProcesosProductivos ";
            sql += "where TipoDocto = 'ReporteProduccion' ";
            sql += "and OrdenFabricacion = " + NumOF.ToString() + " ";
            sql += "and ItemCode = " + cItemCode + " ";
            sql += "order by NumeroDocto desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_EntradaMercancia_Web(int DocEntry)
        {

            string sql;

            sql = "exec SAPB1_RECEPCION6 " + DocEntry.ToString();

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public string SAPB1_RECETA(cldProduccion parProduccion)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECETA";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parProduccion.ItemCode.Length;
                ParItemCode.Value = parProduccion.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUserSign);

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

        public string SAPB1_RECETA1(cldProduccion parProduccion)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECETA1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@docentry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUserSign);

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

        public string SAPB1_RECETA2(cldProduccion parProduccion)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECETA2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parProduccion.ItemCode.Length;
                ParItemCode.Value = parProduccion.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParQauntity = new SqlParameter();
                ParQauntity.ParameterName = "@Qauntity";
                ParQauntity.SqlDbType = SqlDbType.Float;
                ParQauntity.Value = parProduccion.Qauntity;
                SqlComando.Parameters.Add(ParQauntity);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@ToWH";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parProduccion.ToWH.Length;
                ParWhsCode.Value = parProduccion.ToWH;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter ParReferencia = new SqlParameter();
                ParReferencia.ParameterName = "@Referencia";
                ParReferencia.SqlDbType = SqlDbType.VarChar;
                ParReferencia.Size = parProduccion.Referencia.Length;
                ParReferencia.Value = parProduccion.Referencia;
                SqlComando.Parameters.Add(ParReferencia);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUserId);

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

        public string SAPB1_RECETA3(cldProduccion parProduccion)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RECETA3";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@LineId";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = parProduccion.LineId;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parProduccion.ItemCode.Length;
                ParItemCode.Value = parProduccion.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParQauntity = new SqlParameter();
                ParQauntity.ParameterName = "@Qauntity";
                ParQauntity.SqlDbType = SqlDbType.Float;
                ParQauntity.Value = parProduccion.Qauntity;
                SqlComando.Parameters.Add(ParQauntity);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@ToWH";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parProduccion.ToWH.Length;
                ParWhsCode.Value = parProduccion.ToWH;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter ParOrigCurr = new SqlParameter();
                ParOrigCurr.ParameterName = "@OrigCurr";
                ParOrigCurr.SqlDbType = SqlDbType.VarChar;
                ParOrigCurr.Size = parProduccion.OrigCurr.Length;
                ParOrigCurr.Value = parProduccion.OrigCurr;
                SqlComando.Parameters.Add(ParOrigCurr);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parProduccion.UserSign;
                SqlComando.Parameters.Add(ParUserId);

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


        public string SAPB1_OBATCH(cldProduccion parProduccion)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OBATCH";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parProduccion.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocNum";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parProduccion.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlParameter ParFechaBalanza = new SqlParameter();
                ParFechaBalanza.ParameterName = "@fechabalanza";
                ParFechaBalanza.SqlDbType = SqlDbType.VarChar;
                ParFechaBalanza.Size = parProduccion.FechaRegistro.Length;
                ParFechaBalanza.Value = parProduccion.FechaRegistro;
                SqlComando.Parameters.Add(ParFechaBalanza);

                SqlParameter ParHoraBalanza = new SqlParameter();
                ParHoraBalanza.ParameterName = "@horabalanza";
                ParHoraBalanza.SqlDbType = SqlDbType.VarChar;
                ParHoraBalanza.Size = parProduccion.HoraRegistro.Length;
                ParHoraBalanza.Value = parProduccion.HoraRegistro;
                SqlComando.Parameters.Add(ParHoraBalanza);

                SqlParameter ParPeso = new SqlParameter();
                ParPeso.ParameterName = "@peso";
                ParPeso.SqlDbType = SqlDbType.Float;
                ParPeso.Value = parProduccion.Peso;
                SqlComando.Parameters.Add(ParPeso);

                SqlParameter ParRegistro_Rnd = new SqlParameter();
                ParRegistro_Rnd.ParameterName = "@registro_rnd";
                ParRegistro_Rnd.SqlDbType = SqlDbType.Int;
                ParRegistro_Rnd.Value = parProduccion.IdRegistro_rnd;
                SqlComando.Parameters.Add(ParRegistro_Rnd);

                SqlParameter ParDocEntry_Consumo = new SqlParameter();
                ParDocEntry_Consumo.ParameterName = "@DocEntry_Consumo";
                ParDocEntry_Consumo.SqlDbType = SqlDbType.Int;
                ParDocEntry_Consumo.Value = parProduccion.DocEntry_Consumo;
                SqlComando.Parameters.Add(ParDocEntry_Consumo);

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

        public void Consulta_OBATCH_x_Cadena(int d_DocEntry, int d_DocNm, string d_fecha, string d_hora, double d_peso, int d_registro_rnd)
        {

            string sql;

            sql = "select top 1 t0.* ";
            sql += "from [@HDV_OBATCH] t0 ";
            sql += "where t0.U_Registro_Rnd = " + d_registro_rnd;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OBATCH_Pendientes()
        {

            string sql;

            sql = "select t0.* ";
            sql += "from [@HDV_OBATCH] t0 ";
            sql += "where year(U_FechaConsumo) = 1900 ";
            sql += "and U_Peso > 1 ";
            sql += "order by CreateDate , CreateTime ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OBATCH_UltimoRegistro()
        {

            string sql;

            sql = "select ( select max(DocNum) as DocNum from [@HDV_OBATCH] where DocNum > 0 ) as DocNum , ( select max(DocNum) as DocNum from [@HDV_OBATCH] where DocNum < 0  ) as DocNum_N  ";
            
            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OBATCH_Ingresados(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.* , t1.CreateDate as FechaConsumo2 , t2.BaseEntry , t2.ItemCode , t2.Quantity ";
            sql += "from [@HDV_OBATCH] t0  ";
            sql += "left join OIGE t1 on t1.DocEntry = t0.U_DocEntry_Consumo ";
            sql += "left join IGE1 t2 on t2.DocEntry = t1.DocEntry ";
            sql += "where convert ( varchar(8) , t0.CreateDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";

            sql += "order by t0.CreateDate , t0.DocEntry  ";

            sql += "  ";


            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_OBATCH_OF_Pendientes(string WhsCode)
        {

            string sql;

            sql = "select ";
            sql += "T4.DocNum , T3.LineNum , T3.ItemCode , T3.PlannedQty , T3.IssuedQty , T3.wareHouse ";
            sql += "from OWOR T4 ";
            sql += "inner join WOR1 T3 ON T3.DocEntry = T4.DocEntry AND T3.ItemCode in ('FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.NUE.SE.NCC1.XXX.X.XXX-XXX.XXX.G.0001K.01' ) and T3.wareHouse = '" + WhsCode + "' and ( T3.PlannedQty - T3.IssuedQty ) > 0 ";
            sql += "left join (select t0.BaseRef, t0.ItemCode, sum(t0.Quantity) as Quantity  from OIGE t1 inner join IGE1 t0 on t0.DocEntry = t1.DocEntry group by t0.BaseRef, t0.ItemCode ) T5 on T5.ItemCode = T3.ItemCode and T5.BaseRef = T4.DocNum ";
            sql += "inner join [@HDV_OWOR] t6 on t6.DocNum = T4.DocNum  ";
            sql += "where T4.Status not in ('L' , 'C' , 'P'  ) ";
            sql += "order by T4.DocNum ";
            sql += " ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OBATCH_Lotes_Pendientes(string WWhsCode)
        {

            string sql;

            sql = "select top 1 ";
            sql += "t0.AbsEntry , t0.DistNumber , t0.Quantity , t1.MnfSerial , t1.MnfSerial , t1.U_NOMBPROD , t1.LotNumber , t1.U_NOMBCLI ";
            sql += "from vista_inventario_lotes_completa t0 ";
            sql += "inner join OBTN t1 on t1.AbsEntry = t0.AbsEntry ";
            sql += "where t0.ItemCode in ( 'FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.NUE.SE.NCC1.XXX.X.XXX-XXX.XXX.G.0001K.01'  ) ";
            sql += "and t0.WhsCode = '" + WWhsCode + "' ";
            sql += "and t0.Quantity > 0 ";
            sql += "order by t0.AbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Vista_Lotes(string DistNumber)
        {

            string sql;

            sql = "select * , ";

            sql += "coalesce ( ( select top 1 t0.DocEntry ";
            sql += "from IGN1 t0 left join (select ta0.DocEntry, ta1.MdAbsEntry from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 59 ) t4 on t4.DocEntry = t0.DocEntry ";
            sql += "inner join OBTN t5 on t5.AbsEntry = t4.MdAbsEntry ";
            sql += "where t5.DistNumber = ta0.DistNumber ";
            sql += "order by t0.DocEntry ) , 0 ) as DocEntry_EM ";

            sql += "from vista_inventario_lotes_completa ta0 ";
            sql += "left join OBTN ta1 on ta1.DistNumber = ta0.DistNumber ";
            sql += "where ta0.DistNumber = '" + DistNumber + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Vista_Lotes_x_WhsCode(string WhsCode)
        {

            string sql;

            sql = "select * , ";

            sql += "coalesce ( ( select top 1 t0.DocEntry ";
            sql += "from IGN1 t0 left join (select ta0.DocEntry, ta1.MdAbsEntry from OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 59 ) t4 on t4.DocEntry = t0.DocEntry ";
            sql += "inner join OBTN t5 on t5.AbsEntry = t4.MdAbsEntry ";
            sql += "where t5.DistNumber = ta0.DistNumber ";
            sql += "order by t0.DocEntry ) , 0 ) as DocEntry_EM ";

            sql += "from vista_inventario_lotes_completa ta0 ";
            sql += "left join OBTN ta1 on ta1.DistNumber = ta0.DistNumber ";
            sql += "where ta0.WhsCode = '" + WhsCode + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Vista_Lotes_Rechazados_x_WhsCode(string WhsCode)
        {

            string sql;

            sql = "select * ";

            sql += "from vista_inventario_lotes_completa ta0 ";
            sql += "left join OBTN ta1 on ta1.DistNumber = ta0.DistNumber ";
            sql += "where ta0.WhsCode = '" + WhsCode + "' ";
            sql += "and ta0.AnalisisCalidad = 'Rechazado' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

    }

}
