using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cldOrdendeCompra : GestorSql
    {

        public void Consultar_Ordenes_de_compra_abiertas(string CardName, string solo_mp , string incluir_servicios, string solo_codigo_csg, string d_codigo_csg)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';
            d_codigo_csg = '%' + d_codigo_csg.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , ";
            sql += "coalesce ( t1.U_Codigo_CSG , '' ) as U_Codigo_CSG , ";
            sql += "t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "coalesce ( t1.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";
            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry and U_HDV_VARIEDAD <> '' ";
            sql += "where t0.DocStatus not in ('C') ";
            sql += "and t1.ItemCode in (select t1.ItemCode from OITM t1 ";
            sql += "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";

            sql += "where t1.InvntItem = 'Y' ";
            //sql += "and t1.U_HDV_VARIEDAD <> '' ";
            //sql += "and len(t1.ItemCode) > 20 ";

            if (solo_mp == "S")
            {
                sql += "and t2.U_Familia in ('Materia Prima' ) ";

            }
            else
            {
                sql += "and t2.U_Familia in ('Materia Prima' , 'Semielaborado') ";

            }

            if (incluir_servicios == "N")
            {
                sql += "and t2.U_TipoFruta = 'Propia' ";

            }

            sql += " )";

            if (solo_codigo_csg == "S")
            {
                sql += "and t1.U_Codigo_CSG <> '' ";

            }

            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "and t0.CardName like '" + CardName + "' ";

            if (d_codigo_csg != "%%")
            {
                sql += "and t1.U_Codigo_CSG like '" + d_codigo_csg + "' ";

            }


            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_abiertas_dys(string CardName, string solo_mp, string incluir_servicios)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "coalesce ( t1.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";
            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry and U_HDV_VARIEDAD <> '' and t1.ItemCode = 'FS.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01'  ";
            sql += "where t0.DocStatus not in ('C') ";
            sql += "and t1.ItemCode in (select t1.ItemCode from OITM t1 ";
            sql += "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";

            sql += "where t1.InvntItem = 'Y' ";
            //sql += "and t1.U_HDV_VARIEDAD <> '' ";
            sql += "and len(t1.ItemCode) > 20 ";

            if (solo_mp == "S")
            {
                sql += "and t2.U_Familia in ('Materia Prima' ) ";

            }
            else
            {
                sql += "and t2.U_Familia in ('Materia Prima' , 'Semielaborado') ";

            }

            if (incluir_servicios == "N")
            {
                sql += "and t2.U_TipoFruta = 'Propia' ";

            }

            sql += " )";

            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "and t0.CardName like '" + CardName + "' ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_abiertas_dys1(string CardName, string solo_mp, string incluir_servicios, string solo_codigo_csg, string d_codigo_csg)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';
            d_codigo_csg = '%' + d_codigo_csg.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "coalesce ( t1.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty , ";
            sql += "coalesce ( t1.U_Codigo_CSG , '' ) as U_Codigo_CSG ";

            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry and U_HDV_VARIEDAD <> '' and t1.ItemCode = 'FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01'  ";
            sql += "where t0.DocStatus not in ('C') ";
            sql += "and t1.ItemCode in (select t1.ItemCode from OITM t1 ";
            sql += "inner join OITB t2 on t1.ItmsGrpCod = t2.ItmsGrpCod ";

            sql += "where t1.InvntItem = 'Y' ";
            //sql += "and t1.U_HDV_VARIEDAD <> '' ";
            sql += "and len(t1.ItemCode) > 20 ";
            sql += "and t2.U_TipoFruta = 'Propia' ";

            if (solo_mp == "S")
            {
                sql += "and t2.U_Familia in ('Materia Prima' ) ";

            }
            else
            {
                sql += "and t2.U_Familia in ('Materia Prima' , 'Semielaborado') ";

            }


            sql += " )";

            if (solo_codigo_csg == "S")
            {
                sql += "and t1.U_Codigo_CSG <> '' ";

            }

            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "and t0.CardName like '" + CardName + "' ";

            if (d_codigo_csg != "%%")
            {
                sql += "and t1.U_Codigo_CSG like '" + d_codigo_csg + "' ";

            }

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consultar_Ordenes_de_compra_abiertas_insumos(string CardName)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "coalesce ( t1.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";

            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";

            sql += "where t0.DocStatus not in ('C') ";
            
            sql += "and t1.ItemCode in (select t1.ItemCode from OITM t1 where t1.ItmsGrpCod in ( 236 , 135 , 185 ) and ManBtchNum = 'Y'  )  ";


            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "and t0.CardName like '" + CardName + "' ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_abiertas_bodegaje(string CardName)
        {
            string sql;

            CardName = '%' + CardName.Trim().ToUpper() + '%';

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "coalesce ( t1.U_HDV_VARIEDAD , '' ) as U_HDV_VARIEDAD , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";

            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";

            sql += "where t0.DocStatus not in ('C') ";

            sql += "and t1.ItemCode in ( 'FS.NUE.PT.NCC1.XXX.X.XXX-XXX.XXX.S.0025K.02' )  ";

            sql += "and t1.OpenQty > 0 ";

            sql += "and t0.CardName like '" + CardName + "' ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_x_numero(int NumOC, string ItemCode, int LineNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , convert ( float , t1.OpenQty ) as OpenQty , ";
            sql += "t0.DocEntry , t1.Price ,  t0.U_COMPRAPRODUCTOR , t1.U_HDV_VARIEDAD , t1.U_HDV_PRESENTACION ";

            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry and t1.ItemCode = '" + ItemCode + "' and t1.LineNum = " + LineNum + " ";

            sql += "where t0.DocNum = " + NumOC + " ";

            sql += "order by t0.DocNum , t1.LineNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_x_numero_1(int NumOC, string ItemCode, int LineNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t1.LineNum , t1.ItemCode , t1.Dscription , convert ( float , t1.OpenQty ) as OpenQty , ";
            sql += "t0.DocEntry , t1.Price ,  t0.U_COMPRAPRODUCTOR , t1.U_HDV_VARIEDAD , t1.U_HDV_PRESENTACION ";

            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry and t1.ItemCode = '" + ItemCode + "' and t1.LineNum = " + LineNum.ToString() + " ";

            sql += "where t0.DocNum = " + NumOC + " ";
            sql += "order by t0.DocNum , t1.LineNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_x_DocNum(int NumOC)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , t0.CardName , ";
            sql += "t0.U_ClienteServ , coalesce ( t1.CardName , '' ) as U_ClienteServ_Name , ";
            sql += "t0.U_COMPRAPRODUCTOR , ";
            sql += "coalesce ( ( select top 1 t4.ItemCode from POR1 t4 where t4.DocEntry = t0.DocEntry  order by t4.LineNum ) , '' ) as ItemCode_L0 ";

            sql += "from OPOR t0 ";
            sql += "left join OCRD t1 on t1.CardCode = U_ClienteServ ";

            sql += "where t0.DocNum = " + NumOC + " ";
            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_insumos(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";
            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocStatus not in ('C') ";
            sql += "and t1.ItemCode in (select t1.ItemCode from OITM t1 where t1.ItmsGrpCod in ( 185 , 236 , 135 )  ) ";

            sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";

            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Ordenes_de_compra_bodegaje(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t1.OpenQty ) as OpenQty ";
            sql += "from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocStatus not in ('C') ";
            sql += "and t1.ItemCode in ( 'FS.NUE.PT.NCC1.XXX.X.XXX-XXX.XXX.S.0025K.02' ) ";

            sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";

            sql += "and t1.ItemCode is not null ";
            sql += "and t1.OpenQty > 0 ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_entradas_insumos(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t2.Quantity ) as OpenQty , ";
            sql += "t1.BaseRef , t1.BaseLine , t0.FolioNum , t1.WhsCode ,  ";
            sql += "coalesce ( t3.DistNumber , '' ) as DistNumber , ";
            sql += "coalesce ( t3.U_FolioPallet , '' ) as U_FolioPallet , ";
            sql += "t1.WhsCode ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry, ta0.ItemCode , ta0.LocCode , ta1.MdAbsEntry , ta1.Quantity from OITL ta0 inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 20 ) t2 on t2.DocEntry =  t0.DocEntry and t2.ItemCode = t1.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "left join OBTN t3 on t3.AbsEntry = t2.MdAbsEntry ";

            sql += "where t1.ItemCode in (select t1.ItemCode from OITM t1 where t1.ItmsGrpCod in ( 185 , 236 , 135 )  ) ";
            sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";
            sql += "and t1.ItemCode is not null ";
            sql += "and t0.FolioNum is not null ";

            sql += "union all select ";

            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t2.Quantity ) as OpenQty , ";
            sql += "t1.BaseRef , t1.BaseLine , t0.FolioNum , t1.WhsCode ,  ";
            sql += "coalesce ( t3.DistNumber , '' ) as DistNumber , ";
            sql += "coalesce ( t3.U_FolioPallet , '' ) as U_FolioPallet , ";
            sql += "t1.WhsCode ";

            sql += "from OIGN t0 ";
            sql += "inner join IGN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry, ta0.ItemCode , ta0.LocCode , ta1.MdAbsEntry , ta1.Quantity from OITL ta0 inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 59 ) t2 on t2.DocEntry =  t0.DocEntry and t2.ItemCode = t1.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "left join OBTN t3 on t3.AbsEntry = t2.MdAbsEntry ";

            sql += "where t1.ItemCode in (select t1.ItemCode from OITM t1 where t1.ItmsGrpCod in ( 185 , 236 , 135 )  ) ";
            sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";
            sql += "and t1.ItemCode is not null ";
            sql += "and t0.DocNum in ( 137544 , 137552 , 148075 ) ";

            sql += "order by t0.DocNum ";
            
            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_entradas_bodegaje(string fecha1, string fecha2, string num_ov)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t2.Quantity ) as OpenQty , ";
            sql += "t1.BaseRef , t1.BaseLine , t0.FolioNum , t1.WhsCode ,  ";
            sql += "coalesce ( t3.DistNumber , '' ) as DistNumber , ";
            sql += "coalesce ( t3.U_FolioPallet , '' ) as U_FolioPallet , ";

            sql += "coalesce ( ( select top 1 ta0.Quantity from [dbo].[vista_inventario_lotes] ta0 where ta0.DistNumber = t3.DistNumber  ) , 0 ) as Stock , ";

            sql += "t1.WhsCode , coalesce ( t3.U_Codigo_CSG , '' ) as U_Codigo_CSG ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry, ta0.ItemCode , ta0.LocCode , ta1.MdAbsEntry , ta1.Quantity from OITL ta0 inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 20 ) t2 on t2.DocEntry =  t0.DocEntry and t2.ItemCode = t1.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "left join OBTN t3 on t3.AbsEntry = t2.MdAbsEntry ";

            sql += "where t1.ItemCode in ( 'FS.NUE.PT.NCC1.XXX.X.XXX-XXX.XXX.S.0025K.02' ) ";

            if (fecha1 != "")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";

            }

            if (num_ov != "")
            {
                sql += "and t3.U_Codigo_CSG  = '" + num_ov + "' ";

            }

            sql += "and t1.ItemCode is not null ";
            sql += "and t0.FolioNum is not null ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_entradas_semielaborados(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.DocDate , t0.CardCode , ";
            sql += "t0.CardName , t1.LineNum , t1.ItemCode , t1.Dscription , ";
            sql += "convert ( float , t2.Quantity ) as OpenQty , ";
            sql += "t1.BaseRef , t1.BaseLine , t0.FolioNum , t1.WhsCode ,  ";
            sql += "coalesce ( t3.DistNumber , '' ) as DistNumber , ";
            sql += "coalesce ( t3.U_FolioPallet , '' ) as U_FolioPallet , ";
            sql += "t1.WhsCode , coalesce ( t4.DocEntry , 0 ) as DocEntry_Calidad , ";
            sql += "coalesce ( t4.U_Estado , '' ) as Estado_RegInspeccion ";
             
            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry, ta0.ItemCode , ta0.LocCode , ta1.MdAbsEntry , ta1.Quantity from OITL ta0 inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry where ta0.DocType = 20 ) t2 on t2.DocEntry =  t0.DocEntry and t2.ItemCode = t1.ItemCode and t2.LocCode = t1.WhsCode ";
            sql += "left join OBTN t3 on t3.AbsEntry = t2.MdAbsEntry ";
            sql += "left join [@HDV_ORCAL] t4 on t4.U_NoLote = t2.MdAbsEntry ";

            sql += "where t1.ItemCode in (select t1.ItemCode from OITM t1 where t1.ItmsGrpCod in ( 215 , 202 , 211 )  ) ";
            sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";
            sql += "and t1.ItemCode is not null ";

            sql += "order by t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Lote_Max_Insumo()
        {
            string sql;

            sql = "select ";
            sql += "coalesce(max(DistNumber), '110000') as Folio ";
            sql += "from OBTN ";
            sql += "where DistNumber between '110000' and '114999' ";
            sql += "and len(DistNumber) = 6 ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

    }
}
