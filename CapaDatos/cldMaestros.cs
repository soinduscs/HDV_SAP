using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cldMaestros : GestorSql
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Salida { get; set; }
        public string TipoFruta { get; set; }
        public string UsuarioSap { get; set; }
        public string ClaveSap { get; set; }
        public int Cosecha { get; set; }
        public string CardCode { get; set; }
        public string ItemCode { get; set; }
        public string Variedad { get; set; }
        public float has_total { get; set; }
        public float has_produccion { get; set; }
        public float kg_potencial { get; set; }
        public float kg_oportunidad { get; set; }
        public float kg_presupuesto { get; set; }
        public string tipocontrato { get; set; }
        public string Accion { get; set; }
        public string CodProd { get; set; }
        public string CodCli { get; set; }
        public int UserSign { get; set; }
        public int DocEntry { get; set; }
        public int LineId { get; set; }
        public int DocEntry_Ref { get; set; }
        public DateTime Fecha { get; set; }
        public float Valor { get; set; }
        public string Defecto { get; set; }
        public int Orden { get; set; }
        public string Temporada { get; set; }
        public double Horas_Tot { get; set; }
        public int Dias_Semana { get; set; }
        public int Dias_Mes { get; set; }
        public string Planta { get; set; }
        public string Turno { get; set; }
        public double Meta_PT { get; set; }
        public double Meta_MP { get; set; }
        public double Rendim_PT { get; set; }
        public double Rendim_MP { get; set; }
        public string WhsCode { get; set; }
        public double Capacidad_PT { get; set; }
        public double Capacidad_MP { get; set; }
        public double PT_R_Ini { get; set; }
        public double PT_R_Fin { get; set; }
        public double PT_A_Ini { get; set; }
        public double PT_A_Fin { get; set; }
        public double PT_V_Ini { get; set; }
        public double PT_V_Fin { get; set; }
        public double MP_R_Ini { get; set; }
        public double MP_R_Fin { get; set; }
        public double MP_A_Ini { get; set; }
        public double MP_A_Fin { get; set; }
        public double MP_V_Ini { get; set; }
        public double MP_V_Fin { get; set; }

        public static SAPbobsCOM.Company sbo_HDV_P03;
        public static int accesoMenuPrincipal;
        public static SAPbobsCOM.Recordset oRecordset;

        public void lee_usuario(string user_code)
        {
            string sql;

            sql = "select top 1 ";
            sql += "t0.USER_CODE , ltrim(rtrim(t1.firstName)) + ' ' + ltrim(rtrim(t1.lastName)) as nombre , ";
            sql += "t1.branch  , t2.Name as Nom_Sucursal , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Produccion' ) , '' ) = 'Produccion'  then 'SI' else 'NO' end as Produccion , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Porteria' ) , '' ) = 'Porteria'  then 'SI' else 'NO' end as Porteria , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Romana' ) , '' ) = 'Romana'  then 'SI' else 'NO' end as Romana , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Calidad' ) , '' ) = 'Calidad'  then 'SI' else 'NO' end as Calidad , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Calidad Aprobacion' ) , '' ) = 'Calidad Aprobacion'  then 'SI' else 'NO' end as Calidad_Aprobacion , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Recepcion MP' ) , '' ) = 'Recepcion MP'  then 'SI' else 'NO' end as Recepcion_MP , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Ventas' ) , '' ) = 'Ventas'  then 'SI' else 'NO' end as Ventas , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Produccion NCC' ) , '' ) = 'Produccion NCC'  then 'SI' else 'NO' end as Produccion_NCC , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Produccion COM' ) , '' ) = 'Produccion COM'  then 'SI' else 'NO' end as Produccion_COM , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Supervisor' ) , '' ) = 'Supervisor'  then 'SI' else 'NO' end as Supervisor , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Calidad Firma PT' ) , '' ) = 'Calidad Firma PT'  then 'SI' else 'NO' end as Calidad_Firma_PT , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Declarar Mermas' ) , '' ) = 'Declarar Mermas'  then 'SI' else 'NO' end as Declarar_Mermas , ";
            sql += "case when coalesce ( ( select top 1 t3.name from HTM1 t2 inner join OHTM t3 on t3.teamID = t2.teamID where t2.empID = t1.empID and t3.name = 'Autorizar Mermas' ) , '' ) = 'Autorizar Mermas'  then 'SI' else 'NO' end as Autorizar_Mermas , ";

            sql += "t0.USERID , t0.E_Mail ";

            sql += "from OUSR t0 ";
            sql += "left join OHEM t1 on t1.userId = t0.USERID ";
            sql += "left join OUBR t2 on t2.Code = t1.branch ";

            sql += "where t0.USER_CODE = '" + user_code + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void lee_localidades()
        {
            string sql;

            sql = "SELECT Code , Location FROM OLCT ";
            sql += "union all  ";
            sql += "SELECT '' , 'PAINE' ";
            sql += "order by Code  ";
            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void lee_fecha_servidor()
        {
            string sql;

            sql = "select getdate() as fecha ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_venta_abiertas(string CardName)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "coalesce ( ( select top 1 t1.ItemCode from RDR1 t1 where t1.DocEntry = t0.DocEntry and t1.OpenQty > 0 order by LineNum ) , '' ) as ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.Dscription from RDR1 t1 where t1.DocEntry = t0.DocEntry and t1.OpenQty > 0 order by LineNum ) , '' ) as Dscription ";
            sql += "from ORDR t0 ";
            sql += "where t0.DocEntry in ( select DocEntry from RDR1 where OpenQty > 0 ) ";

            sql += "and t0.CardName like '" + CardName + "' ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_venta_x_DocNum(int nDocNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName ";
            sql += "from ORDR t0 ";
            sql += "where t0.DocNum = " + nDocNum; 

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Arbol_Integridad_Orden_Facturacion(string cFather, string cSong)
        {
            string sql;

            sql = "select top 1 ";
            sql += "t0.DocEntry ";
            sql += "from OWOR t0 ";
            sql += "where t0.Status in ('R' , 'P' ) ";
            sql += "and t0.ItemCode = '" + cSong + "' ";
            sql += "and t0.DocEntry in (select t1.DocEntry from WOR1 t1 where t1.ItemCode = '" + cFather + "' ) ";
            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Variables()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , U_HDV_TipoFruta ";
            sql += "from [@HDV_OVAR] ";
            sql += "order by U_HDV_TipoFruta , Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Variedades_combo()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , 1 as orden ";
            sql += "from [@HDV_OVAR] ";

            sql += "union all ";

            sql += "select '' as Code , '' as Name , 0 as Orden ";

            sql += "order by Orden , Name ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Calibres()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , U_HDV_TipoFruta ";
            sql += "from [@HDV_OCAL] ";
            sql += "order by U_HDV_TipoFruta , Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Temporadas(string d_tipo)
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , t0.U_Temporada , t0.U_Fecha_Ini , t0.U_Hora_Tot ,  ";
            sql += "t0.U_Meta_PT , t0.U_Meta_MP , t0.U_Rendim_PT , t0.U_Rendim_MP ";
            sql += "from [@HDV_OTEMPORADA] t0 ";
            sql += "where t0.U_Planta = '" + d_tipo + "' ";
            sql += "order by t0.U_Temporada desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Almacenes()
        {
            string sql;

            sql = "select ";
            sql += "t0.Code , t0.U_WhsCode , t0.U_Capacidad_PT , t0.U_Capacidad_MP  ";
            sql += "from [@HDV_OALMACEN] t0 ";
            sql += "order by t0.U_WhsCode ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Almacenes_x_WhsCode(string d_WhsCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.* ";
            sql += "from [@HDV_OALMACEN] t0 ";
            sql += "where t0.U_WhsCode = '" + d_WhsCode + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Almacenes_x_WhsCode_new()
        {
            string sql;

            sql = "select max(Code) as Code ";
            sql += "from [@HDV_OALMACEN] ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Temporadas_x_id(string d_code)
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , t0.U_Temporada , t0.U_Fecha_Ini , t0.U_Hora_Tot ,  ";
            sql += "t0.U_Meta_PT , t0.U_Meta_MP , t0.U_Rendim_PT , t0.U_Rendim_MP , ";
            sql += "t0.U_Dias_Semana , t0.U_Dias_Mes ";

            sql += "from[@HDV_OTEMPORADA] t0 ";
            sql += "where t0.Code = '" + d_code + "' ";
            sql += "order by t0.U_Temporada desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Temporadas_max()
        {
            string sql;

            sql = "select max(Code) as Code , max(U_Temporada) as Temporada ";

            sql += "from [@HDV_OTEMPORADA] t0 ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Temporadas1_max()
        {
            string sql;

            sql = "select max(Code) as Code ";

            sql += "from [@HDV_TEMPORADA1] t0 ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Temporadas_turnos_x_temporada(string d_temporada, string d_planta)
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , t0.U_Temporada , t0.U_Turno , t0.U_Meta_PT , t0.U_Meta_MP ";
            sql += "from[@HDV_TEMPORADA1] t0 ";
            sql += "where t0.U_Temporada = '" + d_temporada + "' ";
            sql += "and t0.U_Planta = '" + d_planta + "' ";
            sql += "order by t0.U_Turno ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_turnos_parametros()
        {
            string sql;

            sql = "select ";
            sql += "FldValue, Descr ";
            sql += "from UFD1 ";
            sql += "where TableID = 'AWOR' ";
            sql += "and FieldID = 17 ";
            sql += "and FldValue<> 'N/A' ";
            sql += "order by FldValue ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consultar_usuarios()
        {
            string sql;

            sql = "select ";
            sql += "USERID, U_NAME ";
            sql += "from OUSR ";
            sql += "WHERE Locked = 'N' ";
            sql += "AND U_NAME IS NOT NULL ";
            sql += "AND U_NAME <> '' ";
            sql += "order by U_NAME ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consultar_usuarios1()
        {
            string sql;

            sql = "exec xSapb1_utiles_listado_usuarios ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_almacen_asignado(int d_usderid)
        {
            string sql;

            sql = "select ";
            sql += "t0.WhsCode , t0.WhsName  ,  ";
            sql += "coalesce((select  U_LineNum from[@HDV_OPRM] t1 where t1.U_WhsCode = t0.WhsCode and t1.U_UserSign = " + d_usderid.ToString() + " ) , 0 ) as Asign ";
            sql += "from OWHS t0 ";
            sql += "order by t0.WhsCode , t0.WhsName ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Bins_Produccion()
        {
            string sql;

            sql = "select ";
            sql += "ItemCode , ItemName , BWeight1 , ItemName + ' (' + convert ( varchar(10) ,  CAST(BWeight1  AS money) ) + ' KG)' as ItemName2 ";
            sql += "from OITM ";
            sql += "where ItmsGrpCod = 217 ";
            sql += "and U_ValRecPr = 'S' ";

            sql += "order by ItemName ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Bins_Produccion1()
        {
            string sql;

            sql = "select ";
            sql += "ItemCode , ItemName , BWeight1 , ItemName + ' (' + convert ( varchar(10) ,  CAST(BWeight1  AS money) ) + ')' as ItemName2 ";
            sql += "from OITM ";
            sql += "where ItmsGrpCod = 217 ";
            sql += "and U_ValRecPr not in ( 'S' ) ";

            sql += "order by ItemName ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Bins_Produccion2(string d_itemcode)
        {
            string sql;

            sql = "select ";
            sql += "ItemCode , ItemName , BWeight1 , ItemName + ' (' + convert ( varchar(10) ,  CAST(BWeight1  AS money) ) + ')' as ItemName2 ";
            sql += "from OITM ";
            sql += "where ItemCode = '" + d_itemcode + "'";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consultar_Variedades()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name ";
            sql += "from [@HDV_OVAR] ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_TipoContrato()
        {
            string sql;

            sql = "select ";
            sql += "FldValue , Descr ";
            sql += "from UFD1 ";
            sql += "where TableID = 'OPOR' ";
            sql += "and FieldID = 195 ";
            sql += "order by FldValue ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Detalle_Productores_xCardCode(string cCardCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.U_Cosecha , t0.U_CardCode , t0.U_ItemCode , ";
            sql += "t0.U_Variedad , t0.U_HAS_Total , t0.U_HAS_Produccion , ";
            sql += "t0.U_KG_Potencial , t0.U_KG_Oportunidad , t0.U_KG_Presupuesto , ";
            sql += "t0.U_TipoContrato , t1.ItemName ";
            sql += "from[@HDV_OCRP] t0 ";
            sql += "inner join OITM t1 on t1.ItemCode = t0.U_ItemCode ";
            sql += "where t0.U_CardCode = '" + cCardCode + "' ";
            sql += " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Detalle_Entradas_xCardCode(string cCardCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.FolioNum , t0.DocDate , t0.DocTotal ,  ";
            sql += "t1.ItemCode , t1.Dscription as ItemName ,  ";
            sql += "t1.Quantity , t1.U_HDV_VARIEDAD , t1.U_HDV_PRESENTACION , ";
            sql += "t1.BaseRef , t0.DocEntry ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.CardCode = '" + cCardCode + "' ";

            sql += "and t0.DocEntry not in ( select U_DocEntry_Ref from [@HDV_LICC1] ) ";

            sql += "and year(t0.DocDate) = 2020 ";
            sql += "order by t0.DocDate ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_detalle_liquidacion(int nFolio)
        {
            string sql;

            sql = "select ";
            sql += "t0.FolioNum , t0.DocDate , t0.DocTotal ,  ";
            sql += "t1.ItemCode , t1.Dscription as ItemName ,  ";
            sql += "t1.Quantity , t1.U_HDV_VARIEDAD , t1.U_HDV_PRESENTACION , ";
            sql += "t1.BaseRef , t0.DocEntry ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry in ( select U_DocEntry_Ref from [@HDV_LICC1] where DocEntry = " + nFolio + " ) ";

            sql += "order by t0.DocDate ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_vencimiento_liquidacion(int nFolio)
        {
            string sql;

            sql = "select ";

            sql += "t0.DocEntry , t0.LineId , t0.U_Fecha , t0.U_Valor ";

            sql += "from [@HDV_LICC2] t0 ";

            sql += "where t0.DocEntry = " + nFolio + " ";

            sql += "order by t0.U_Fecha ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_max_liquidacion_productor()
        {
            string sql;

            sql = "select max(DocEntry) as DocEntry ";
            sql += "from[@HDV_OLICC] ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Detalle_liquidacion_xCardCode(string cCardCode)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.CreateDate , '' as Comment , sum(t2.DocTotal) as DocTotal ";
            sql += "from[@HDV_OLICC] t0 ";
            sql += "inner join[@HDV_LICC1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join OPDN t2 on t2.DocEntry = t1.U_DocEntry_Ref ";
            sql += "where t0.U_CardCode = '" + cCardCode + "' ";
            sql += "group by t0.DocEntry , t0.CreateDate ";
            sql += "order by t0.CreateDate ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Calibres_combo()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , U_HDV_TipoFruta , 1 as Orden ";
            sql += "from [@HDV_OCAL] ";
        
            sql += "union all ";

            sql += "select '' as Code , '' as Name , '' as U_HDV_TipoFruta , 0 as Orden ";

            sql += "order by Orden , Name ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Calibres_NuezMec(string cTipoFruta)
        {
            string sql;

            sql = "select ";
            sql += "Code , Name , U_HDV_TipoFruta , 1 as Orden ";
            sql += "from [@HDV_OCAL] ";
            sql += "where U_HDV_TipoFruta = '" + cTipoFruta + "' ";
            sql += "and Code not in ( 'Basura','Cascara','Cascara C/Pulpa','Descarte','Fuera de Color','Partidas','PNC','Rayadas','Rechazo F. T. Grande','Rechazo Forma Mitad','Septum C/Pulpa', 'Hongo' , 'Hongo Activo' , 'Daño Mecanico','Desecho' ) ";

            sql += "union all ";

            sql += "select '' as Code , '' as Name , '' as U_HDV_TipoFruta , 0 as Orden ";

            sql += "union all ";

            sql += "select Code , Name , U_HDV_TipoFruta , 2 as Orden ";
            sql += "from [@HDV_OCAL] ";
            sql += "where Code in ( 'Basura','Cascara','Cascara C/Pulpa','Descarte','Fuera de Color','Partidas','PNC','Rayadas','Rechazo F. T. Grande','Rechazo Forma Mitad','Septum C/Pulpa', 'Hongo' , 'Hongo Activo' , 'Daño Mecanico','Desecho' ) ";

            sql += "order by Orden , Name ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_AtributoCalidad_RI(String cFamilia)
        {
            string sql;

            sql = "select ";
            sql += "DocEntry , U_Referencia ";
            sql += "from [dbo].[@HDV_ATRP6] ";
            sql += "where U_Familia = '" + cFamilia + "' "; 
            sql += "order by U_Orden ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_AtributoCalidad_RI2(String cCodAtr, string cDocReferencia)
        {

            if (cDocReferencia == "")
            {
                cDocReferencia = "0";

            }

            string sql;

            sql = "select ";
            sql += "t0.U_CodAtr , t0.U_NameAtr , t0.U_StandAtr , ";
            sql += "t0.U_Minimo , t1.U_Minimo as U_Minimo_1 , ";
            sql += "t0.U_Maximo , t1.U_Maximo as U_Maximo_1 , ";
            sql += "t0.U_TipoDef , t0.U_Comment , t1.U_Locked , ";
            sql += "upper(t0.U_Metodo) as U_Metodo , t0.Object , ";
            sql += "t0.U_AQL , t0.U_Cualitat , t0.U_TipoMues ,  ";
            sql += "t0.U_CodEquip , t0.U_TiempoEs ";

            sql += "from [dbo].[@HDV_ATRP1] t0 ";
            sql += "left join [@HDV_ATRP3] t1 on t1.U_CodAtr = t0.U_CodAtr and  t1.DocEntry in ( select U_BaseEntry from [@HDV_ATRP6] where DocEntry = " + cDocReferencia + " ) ";

            sql += "WHERE t0.U_CodAtr = '" + cCodAtr + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_HDV_ATRP1_max_Id(String cCodAtr)
        {

            string sql;

            sql = "select max(LineId) as LineId_Max ";
            sql += "from [dbo].[@HDV_ATRP1] ";
            sql += "where substring ( U_CodAtr , 1 , 2 ) = substring ( '" + cCodAtr + "' , 1 , 2 ) ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_HDV_ATRP3_max_Id(String cCodAtr)
        {

            string sql;

            sql = "select max(LineId) as LineId_Max ";
            sql += "from [dbo].[@HDV_ATRP3] ";
            sql += "where substring ( U_CodAtr , 1 , 2 ) = substring ( '" + cCodAtr + "' , 1 , 2 ) ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Defectos()
        {
            string sql;

            sql = "select ";
            sql += "0 as U_Orden , '' as Code ";
            sql += "union all ";
            sql += "select ";
            sql += "U_Orden, Code ";
            sql += "from[@HDV_OCAL] ";
            sql += "where U_Defecto = 'SI' ";
            sql += "order by U_Orden ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_combo_pie_frm(string d_CodAtr)
        {
            string sql;

            sql = "select ";
            sql += "0 as U_Id , '' as U_Value ";
            sql += "union all ";
            sql += "select U_Id, U_Value ";
            sql += "from [@HDV_ATRPA0] ";
            sql += "where U_CodAtr = '" + d_CodAtr + "' ";
            sql += "order by U_Id ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Colores()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name ";
            sql += "from [@HDV_OCOL] ";
            sql += "union all ";
            sql += "select '' as Code , '' as Name ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Operadores_Cracker()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name ";
            sql += "from [@HDV_OOPR] ";
            //sql += "union all ";
            //sql += "select '' as Code , '' as Name ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_SalidasProduccion()
        {
            string sql;

            sql = "select ";
            sql += "U_HDV_TipoFruta , U_HDV_Salida , Name , Code ";
            sql += "from [@HDV_OGATE] ";
            sql += "order by U_HDV_TipoFruta , U_HDV_Salida ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_SalidasProduccion_Max_Code()
        {
            string sql;

            sql = "select ";
            sql += "max(convert ( int , CODE ) ) as CODE ";
            sql += "from [@HDV_OGATE] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_SalidasProduccion_Max_TipoProducto(string cTipoProducto)
        {
            string sql;

            sql = "select ";
            sql += "max(U_HDV_Salida) as U_HDV_Salida ";
            sql += "from [@HDV_OGATE] ";
            sql += "where U_HDV_TipoFruta = '" + cTipoProducto + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_SalidasProduccion_TipoProducto(string cTipoProducto)
        {
            string sql;

            sql = "select * , convert ( varchar(2) , U_HDV_Salida ) + ' - ' + Name as nom_gate ";
            sql += "from [@HDV_OGATE] ";
            sql += "where U_HDV_TipoFruta = '" + cTipoProducto + "' ";
            sql += "order by convert ( int , U_HDV_Salida ) ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_ControlProductor()
        {

            string sql;

            sql = "select ";
            sql += "t0.LotNumber , coalesce ( t2.CardName , '' )  as NomCli , t0.MnfSerial , t1.CardName as NomProd , ";
            sql += "case when coalesce ( ( select Code from [@HDV_OCRX] ta1 where ta1.U_CODPROD = t0.MnfSerial and ta1.U_CODCLI = t0.LotNumber ) , '' ) = '' then 'SI' else 'NO' end as PermiteAgrupar ";
            sql += "from OBTN t0 ";
            sql += "left join OCRD t1 on t1.CardCode = t0.MnfSerial ";
            sql += "left join OCRD t2 on t2.CardCode = t0.LotNumber ";
            sql += "where t0.U_temporada >= '2018' ";
            sql += "and t0.MnfSerial is not null ";
            sql += "and t0.ItemCode like 'FS%' ";
            sql += "and t0.LotNumber not in ( '' ) ";
            sql += "group by t0.MnfSerial , t1.CardName , t0.LotNumber , t2.CardName ";
            sql += "order by t2.CardName , t1.CardName ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public string TablaUsuario_Variedad(cldMaestros parVariedad)
        {

            string NewObjectKey; //, errMsg;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OVAR");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("Code", parVariedad.Code);
            GeneralData.SetProperty("Name", parVariedad.Name);
            GeneralData.SetProperty("U_HDV_TipoFruta", parVariedad.TipoFruta);

            try
            {
                GeneralService.Add(GeneralData);
                NewObjectKey = parVariedad.Code;
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro de variedad";
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

        public string TablaUsuario_Proceso(cldMaestros parVariedad)
        {
            string sql = "", Respuesta = "";

            sql = "insert [@HDV_OPROC] ( Code , LineId , U_Code ) ";
            sql += "select '" + parVariedad.TipoFruta + "' , '" + parVariedad.LineId.ToString() + "' , '" + parVariedad.Code + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string TablaUsuario_Calibre(cldMaestros parVariedad)
        {

            string NewObjectKey; //, errMsg;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OCAL");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("Code", parVariedad.Code);
            GeneralData.SetProperty("Name", parVariedad.Name);
            GeneralData.SetProperty("U_HDV_TipoFruta", parVariedad.TipoFruta);
            GeneralData.SetProperty("U_Defecto", parVariedad.Defecto);
            GeneralData.SetProperty("U_Orden", parVariedad.Orden);

            try
            {
                GeneralService.Add(GeneralData);
                NewObjectKey = parVariedad.Code;
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro de variedad";
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

        public string TablaUsuario_Color(cldMaestros parVariedad)
        {

            string NewObjectKey; //, errMsg;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OCOL");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("Code", parVariedad.Code);
            GeneralData.SetProperty("Name", parVariedad.Name);

            try
            {
                GeneralService.Add(GeneralData);
                NewObjectKey = parVariedad.Code;
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro de variedad";
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

        public string TablaUsuario_OperadorCracker(cldMaestros parVariedad)
        {

            string NewObjectKey; //, errMsg;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OOPR");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("Code", parVariedad.Code);
            GeneralData.SetProperty("Name", parVariedad.Name);

            try
            {
                GeneralService.Add(GeneralData);
                NewObjectKey = parVariedad.Code;
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro de variedad";
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

        public string TablaUsuario_SalidaProduccion(cldMaestros parVariedad)
        {

            string NewObjectKey;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OGATE");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("Code", parVariedad.Code);
            GeneralData.SetProperty("Name", parVariedad.Name);
            GeneralData.SetProperty("U_HDV_TipoFruta", parVariedad.TipoFruta);
            GeneralData.SetProperty("U_HDV_Salida", parVariedad.Salida);

            try
            {
                GeneralService.Add(GeneralData);
                NewObjectKey = parVariedad.Code;
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro de variedad";
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

        public string Valido_Clave(cldMaestros parVariedad)
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
            sbo_HDV_P03.UserName = parVariedad.UsuarioSap;
            sbo_HDV_P03.Password = parVariedad.ClaveSap;

            sbo_HDV_P03.Connect();

            bool goodParse = false;

            try
            {
                SAPbobsCOM.Recordset RS;
                string Query = string.Empty;
                RS = (SAPbobsCOM.Recordset)sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                Query = "SELECT MAX(CONVERT(INT,T0.[DistNumber])) FROM OBTN T0 WHERE ISNUMERIC(T0.[DistNumber]) = 1";

                RS.DoQuery(Query);
                int LoteMaximo = 0;

                while (!RS.EoF)
                {
                    goodParse = int.TryParse(RS.Fields.Item(0).Value.ToString(), out LoteMaximo);
                    RS.MoveNext();
                }

            }
            catch
            {

            }
          
            if (goodParse == true)
            {
                NewObjectKey = "S";
            }
            else
            {
                NewObjectKey = "N";
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

        public string TablaUsuario_LiqProductor(cldMaestros parLiquidacion)
        {

            string NewObjectKey; //, errMsg;
            //int errCode = 0;

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
            sbo_HDV_P03.UserName = parLiquidacion.UsuarioSap;
            sbo_HDV_P03.Password = parLiquidacion.ClaveSap;

            sbo_HDV_P03.Connect();

            SAPbobsCOM.CompanyService CompanyService;
            SAPbobsCOM.GeneralService GeneralService;
            SAPbobsCOM.GeneralData GeneralData;

            ///// add UDO data

            CompanyService = sbo_HDV_P03.GetCompanyService();

            GeneralService = CompanyService.GetGeneralService("HDV_OLICC");
            GeneralData = (SAPbobsCOM.GeneralData)GeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);
            GeneralData.SetProperty("U_CardCode", parLiquidacion.Code);
            GeneralData.SetProperty("U_CardName", parLiquidacion.Name);

            try
            {
                GeneralService.Add(GeneralData);
                //NewObjectKey = parLiquidacion.Code;
                NewObjectKey = sbo_HDV_P03.GetNewObjectKey();
            }
            catch
            {
                NewObjectKey = "Error al grabar el registro";
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


        public string Agrega_Detalle_LiqProductor(cldMaestros parLiquidacion)
        {
            string sql = "", Respuesta = "";

            sql = "insert [@HDV_LICC1] ( DocEntry , LineId , U_DocEntry_Ref ) ";
            sql += "select " + parLiquidacion.DocEntry + " , " + parLiquidacion.LineId + " , " + parLiquidacion.DocEntry_Ref;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public string Agrega_Vencimiento_LiqProductor(cldMaestros parLiquidacion)
        {
            string sql = "", Respuesta = "";

            if (parLiquidacion.LineId < 0)
            {
                sql = "delete [@HDV_LICC2] where DocEntry = " + parLiquidacion.DocEntry;

            }
            else
            {
                sql = "insert [@HDV_LICC2] ( DocEntry , LineId , U_Fecha , U_Valor ) ";
                sql += "select " + parLiquidacion.DocEntry + " , " + parLiquidacion.LineId + " , '" + parLiquidacion.Fecha.ToString("yyyyMMdd") + "' , " + parLiquidacion.Valor;

            }

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "";

            return Respuesta;
        }

        public void Consultar_utiles_informediariostock(string cPeriodo)
        {
            string sql;

            sql = "exec xSapb1_utiles_informediariostock '" + cPeriodo + "'";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public string SAPB1_OCRP(cldMaestros parMaestros)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OCRP";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCosecha = new SqlParameter();
                ParCosecha.ParameterName = "@cosecha";
                ParCosecha.SqlDbType = SqlDbType.Int;
                ParCosecha.Value = parMaestros.Cosecha;
                SqlComando.Parameters.Add(ParCosecha);

                SqlParameter ParCardCode = new SqlParameter();
                ParCardCode.ParameterName = "@cardcode";
                ParCardCode.SqlDbType = SqlDbType.VarChar;
                ParCardCode.Size = parMaestros.CardCode.Length;
                ParCardCode.Value = parMaestros.CardCode;
                SqlComando.Parameters.Add(ParCardCode);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@itemcode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parMaestros.ItemCode.Length;
                ParItemCode.Value = parMaestros.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParVariedad = new SqlParameter();
                ParVariedad.ParameterName = "@variedad";
                ParVariedad.SqlDbType = SqlDbType.VarChar;
                ParVariedad.Size = parMaestros.Variedad.Length;
                ParVariedad.Value = parMaestros.Variedad;
                SqlComando.Parameters.Add(ParVariedad);

                SqlParameter Parhas_total = new SqlParameter();
                Parhas_total.ParameterName = "@has_total";
                Parhas_total.SqlDbType = SqlDbType.Float;
                Parhas_total.Value = parMaestros.has_total;
                SqlComando.Parameters.Add(Parhas_total);

                SqlParameter Parhas_produccion = new SqlParameter();
                Parhas_produccion.ParameterName = "@has_produccion";
                Parhas_produccion.SqlDbType = SqlDbType.Float;
                Parhas_produccion.Value = parMaestros.has_produccion;
                SqlComando.Parameters.Add(Parhas_produccion);

                SqlParameter Parkg_potencial = new SqlParameter();
                Parkg_potencial.ParameterName = "@kg_potencial";
                Parkg_potencial.SqlDbType = SqlDbType.Float;
                Parkg_potencial.Value = parMaestros.kg_potencial;
                SqlComando.Parameters.Add(Parkg_potencial);

                SqlParameter Parkg_oportunidad = new SqlParameter();
                Parkg_oportunidad.ParameterName = "@kg_oportunidad";
                Parkg_oportunidad.SqlDbType = SqlDbType.Float;
                Parkg_oportunidad.Value = parMaestros.kg_oportunidad;
                SqlComando.Parameters.Add(Parkg_oportunidad);

                SqlParameter Parkg_presupuesto = new SqlParameter();
                Parkg_presupuesto.ParameterName = "@kg_presupuesto";
                Parkg_presupuesto.SqlDbType = SqlDbType.Float;
                Parkg_presupuesto.Value = parMaestros.kg_presupuesto;
                SqlComando.Parameters.Add(Parkg_presupuesto);

                SqlParameter Partipocontrato = new SqlParameter();
                Partipocontrato.ParameterName = "@tipocontrato";
                Partipocontrato.SqlDbType = SqlDbType.VarChar;
                Partipocontrato.Size = parMaestros.tipocontrato.Length;
                Partipocontrato.Value = parMaestros.tipocontrato;
                SqlComando.Parameters.Add(Partipocontrato);

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

        public string SAPB1_OTEMPORADA(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "update [@HDV_OTEMPORADA] set U_Fecha_Ini = @Fecha_Ini , U_Hora_Tot = @Hora_Tot , U_Dias_Semana = @dias_semana , U_Dias_Mes = @dias_mes , U_Meta_PT = @Meta_PT , U_Meta_MP = @Meta_MP , U_Rendim_PT = @Rendim_PT , U_Rendim_MP = @Rendim_MP where Code = @Code ";

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@Fecha_Ini", SqlDbType.VarChar).Value = parMaestros.Fecha.ToString("yyyyMMdd");
                cmd.Parameters.Add("@Hora_Tot", SqlDbType.Float).Value = parMaestros.Horas_Tot;
                cmd.Parameters.Add("@dias_semana", SqlDbType.Int).Value = parMaestros.Dias_Semana;
                cmd.Parameters.Add("@dias_mes", SqlDbType.Int).Value = parMaestros.Dias_Mes;
                cmd.Parameters.Add("@Meta_PT", SqlDbType.Float).Value = parMaestros.Meta_PT;
                cmd.Parameters.Add("@Meta_MP", SqlDbType.Float).Value = parMaestros.Meta_MP;
                cmd.Parameters.Add("@Rendim_PT", SqlDbType.Float).Value = parMaestros.Rendim_PT;
                cmd.Parameters.Add("@Rendim_MP", SqlDbType.Float).Value = parMaestros.Rendim_MP;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OTEMPORADA_I(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "insert [@HDV_OTEMPORADA] ( Code , Name , U_Temporada , U_Planta ) values ( @Code , @name , @Temporada , @planta ) ";

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = parMaestros.Name;
                cmd.Parameters.Add("@Temporada", SqlDbType.VarChar).Value = parMaestros.Temporada;
                cmd.Parameters.Add("@planta", SqlDbType.VarChar).Value = parMaestros.Planta;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OTEMPORADA_A(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "insert [@HDV_TEMPORADA1] ( Code , Name , U_Temporada , U_Planta , U_Turno  ) values ( @Code , @name , @Temporada , @planta , @turno ) ";

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = parMaestros.Name;
                cmd.Parameters.Add("@Temporada", SqlDbType.VarChar).Value = parMaestros.Temporada;
                cmd.Parameters.Add("@planta", SqlDbType.VarChar).Value = parMaestros.Planta;
                cmd.Parameters.Add("@turno", SqlDbType.VarChar).Value = parMaestros.Turno;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OTEMPORADA_B(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "delete [@HDV_OTEMPORADA] where U_Temporada = @Temporada ";
                cmd.Parameters.Add("@Temporada", SqlDbType.VarChar).Value = parMaestros.Temporada;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OTEMPORADA_C(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "delete [@HDV_TEMPORADA1] where U_Temporada = @Temporada ";
                cmd.Parameters.Add("@Temporada", SqlDbType.VarChar).Value = parMaestros.Temporada;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OALMACEN(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "insert [@HDV_OALMACEN] ( Code, Name , U_WhsCode , U_Capacidad_PT , U_Capacidad_MP , U_PT_R_Ini , U_PT_R_Fin , U_PT_A_Ini , U_PT_A_Fin , U_PT_V_Ini , U_PT_V_Fin , U_MP_R_Ini , U_MP_R_Fin , U_MP_A_Ini , U_MP_A_Fin , U_MP_V_Ini , U_MP_V_Fin ) values ( @Code, @Name , @U_WhsCode , @U_Capacidad_PT , @U_Capacidad_MP , @U_PT_R_Ini , @U_PT_R_Fin , @U_PT_A_Ini , @U_PT_A_Fin , @U_PT_V_Ini , @U_PT_V_Fin , @U_MP_R_Ini , @U_MP_R_Fin , @U_MP_A_Ini , @U_MP_A_Fin , @U_MP_V_Ini , @U_MP_V_Fin )  ";

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@U_WhsCode", SqlDbType.VarChar).Value = parMaestros.WhsCode;

                cmd.Parameters.Add("@U_Capacidad_PT", SqlDbType.Float).Value = parMaestros.Capacidad_PT;
                cmd.Parameters.Add("@U_PT_R_Ini", SqlDbType.Float).Value = parMaestros.PT_R_Ini;
                cmd.Parameters.Add("@U_PT_R_Fin", SqlDbType.Float).Value = parMaestros.PT_R_Fin;
                cmd.Parameters.Add("@U_PT_A_Ini", SqlDbType.Float).Value = parMaestros.PT_A_Ini;
                cmd.Parameters.Add("@U_PT_A_Fin", SqlDbType.Float).Value = parMaestros.PT_A_Fin;
                cmd.Parameters.Add("@U_PT_V_Ini", SqlDbType.Float).Value = parMaestros.PT_V_Ini;
                cmd.Parameters.Add("@U_PT_V_Fin", SqlDbType.Float).Value = parMaestros.PT_V_Fin;

                cmd.Parameters.Add("@U_Capacidad_MP", SqlDbType.Float).Value = parMaestros.Capacidad_MP;
                cmd.Parameters.Add("@U_MP_R_Ini", SqlDbType.Float).Value = parMaestros.MP_R_Ini;
                cmd.Parameters.Add("@U_MP_R_Fin", SqlDbType.Float).Value = parMaestros.MP_R_Fin;
                cmd.Parameters.Add("@U_MP_A_Ini", SqlDbType.Float).Value = parMaestros.MP_A_Ini;
                cmd.Parameters.Add("@U_MP_A_Fin", SqlDbType.Float).Value = parMaestros.MP_A_Fin;
                cmd.Parameters.Add("@U_MP_V_Ini", SqlDbType.Float).Value = parMaestros.MP_V_Ini;
                cmd.Parameters.Add("@U_MP_V_Fin", SqlDbType.Float).Value = parMaestros.MP_V_Fin;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OALMACEN_u(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "UPDATE [@HDV_OALMACEN] SET U_Capacidad_PT = @U_Capacidad_PT , U_Capacidad_MP = @U_Capacidad_MP , U_PT_R_Ini = @U_PT_R_Ini , U_PT_R_Fin = @U_PT_R_Fin , U_PT_A_Ini = @U_PT_A_Ini , U_PT_A_Fin = @U_PT_A_Fin , U_PT_V_Ini = @U_PT_V_Ini , U_PT_V_Fin = @U_PT_V_Fin , U_MP_R_Ini = @U_MP_R_Ini , U_MP_R_Fin = @U_MP_R_Fin , U_MP_A_Ini = @U_MP_A_Ini , U_MP_A_Fin = @U_MP_A_Fin , U_MP_V_Ini = @U_MP_V_Ini , U_MP_V_Fin = @U_MP_V_Fin where U_WhsCode = @U_WhsCode ";

                //cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                //cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@U_WhsCode", SqlDbType.VarChar).Value = parMaestros.WhsCode;

                cmd.Parameters.Add("@U_Capacidad_PT", SqlDbType.Float).Value = parMaestros.Capacidad_PT;
                cmd.Parameters.Add("@U_PT_R_Ini", SqlDbType.Float).Value = parMaestros.PT_R_Ini;
                cmd.Parameters.Add("@U_PT_R_Fin", SqlDbType.Float).Value = parMaestros.PT_R_Fin;
                cmd.Parameters.Add("@U_PT_A_Ini", SqlDbType.Float).Value = parMaestros.PT_A_Ini;
                cmd.Parameters.Add("@U_PT_A_Fin", SqlDbType.Float).Value = parMaestros.PT_A_Fin;
                cmd.Parameters.Add("@U_PT_V_Ini", SqlDbType.Float).Value = parMaestros.PT_V_Ini;
                cmd.Parameters.Add("@U_PT_V_Fin", SqlDbType.Float).Value = parMaestros.PT_V_Fin;

                cmd.Parameters.Add("@U_Capacidad_MP", SqlDbType.Float).Value = parMaestros.Capacidad_MP;
                cmd.Parameters.Add("@U_MP_R_Ini", SqlDbType.Float).Value = parMaestros.MP_R_Ini;
                cmd.Parameters.Add("@U_MP_R_Fin", SqlDbType.Float).Value = parMaestros.MP_R_Fin;
                cmd.Parameters.Add("@U_MP_A_Ini", SqlDbType.Float).Value = parMaestros.MP_A_Ini;
                cmd.Parameters.Add("@U_MP_A_Fin", SqlDbType.Float).Value = parMaestros.MP_A_Fin;
                cmd.Parameters.Add("@U_MP_V_Ini", SqlDbType.Float).Value = parMaestros.MP_V_Ini;
                cmd.Parameters.Add("@U_MP_V_Fin", SqlDbType.Float).Value = parMaestros.MP_V_Fin;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OALMACEN_e(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "delete [@HDV_OALMACEN] where Code = @Code ";
                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_TEMPORADA1(cldMaestros parMaestros)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand cmd = conn.CreateCommand();

            if (parMaestros.Code != "")
            {

                cmd.CommandText = "update [@HDV_TEMPORADA1] set U_Meta_PT = @Meta_PT , U_Meta_MP = @Meta_MP where Code = @Code ";

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = parMaestros.Code;
                cmd.Parameters.Add("@Meta_PT", SqlDbType.Float).Value = parMaestros.Meta_PT;
                cmd.Parameters.Add("@Meta_MP", SqlDbType.Float).Value = parMaestros.Meta_MP;

            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public string SAPB1_OCRX(cldMaestros parMaestros)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OCRX";
                SqlComando.CommandType = CommandType.StoredProcedure;


                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parMaestros.Accion.Length;
                ParAccion.Value = parMaestros.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParCodProd = new SqlParameter();
                ParCodProd.ParameterName = "@codprod";
                ParCodProd.SqlDbType = SqlDbType.VarChar;
                ParCodProd.Size = parMaestros.CodProd.Length;
                ParCodProd.Value = parMaestros.CodProd;
                SqlComando.Parameters.Add(ParCodProd);

                SqlParameter ParCodCli = new SqlParameter();
                ParCodCli.ParameterName = "@codcli";
                ParCodCli.SqlDbType = SqlDbType.VarChar;
                ParCodCli.Size = parMaestros.CodCli.Length;
                ParCodCli.Value = parMaestros.CodCli;
                SqlComando.Parameters.Add(ParCodCli);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parMaestros.UserSign;
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


    }

}
