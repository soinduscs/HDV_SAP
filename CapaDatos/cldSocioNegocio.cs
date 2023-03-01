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
    public class cldSocioNegocio:GestorSql
    {
       
       public void Consultar_CodigoProductores()
        {
           
            this.ComandoSql = "select top 10 CardCode,CardName from OCRD  ";
            this.GestorSqlConsultar();
          ///

        }

        public void Consultar_Transportistas()
        {
            string sql;

            sql = "select ";
            sql += "CardCode , 'SAP    | ' + CardName as CardName  , '1SAP | ' + CardName as Orden ";
            sql += "from OCRD ";
            sql += "where Notes like '%TRANSPOR%' ";

            sql += "union all ";
            sql += "select Code as CardCode , 'EXTERNO | ' + Name as CardName , '2EXTERNO | ' + Name as Orden ";
            sql += "from [dbo].[@HDV_OTRD] ";

            sql += "union all ";
            sql += "select '._.' as CardCode , 'EXTERNO  ***  NUEVO TRANSPORTISTA' as CardName , '3Z' as Orden ";

            sql += "union all ";
            sql += "select '.z.' as CardCode , '(Seleccione un Transportista)' as CardName , '4Z' as Orden ";

            sql += "order by Orden , CardName ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OCRDxCardCode(string CardCode)
        {
            string sql;

            sql = "select top 1 ";
            sql += "t0.CardCode , t0.CardName , ";
            sql += "coalesce ( ( select top 1 t1.City from CRD1 t1 where t1.CardCode = t0.CardCode order by t1.Address ) , '' ) as City , ";
            sql += "t0.Password , ";
            sql += "t0.SlpCode , t1.SlpName  ";
            sql += " ";

            sql += "from OCRD t0 ";
            sql += "left join OSLP t1 on t1.SlpCode = t0.SlpCode ";
            sql += " ";

            sql += "where t0.CardCode = '" + CardCode.Trim() + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_ContactosxCardCode(string CardCode)
        {
            string sql;

            sql = "select ";
            sql += "Name , FirstName , LastName ,Cellolar , E_MailL ";
            sql += " ";

            sql += "from OCPR ";
            sql += " ";

            sql += "where CardCode = '" + CardCode.Trim() + "' ";
            sql += "order by Name ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_OCRDxCardName(string cardname, string con_oc, string solo_proveedores)
        {
            string sql;

            sql = "select top 100 ";
            sql += "t0.CardCode , t0.CardName , t0.CardType ";
            sql += "from dbo.OCRD t0 ";

            sql += "where t0.CardCode like '%'";
            sql += "and upper(t0.CardName) like '%" + cardname.ToUpper() + "%'";

            if (solo_proveedores.Trim() == "S")
            {
                sql += "and t0.CardType = 'S' ";

            }

            if (con_oc.Trim() == "S")
            {
                sql += "and t0.CardCode in ( select t2.CardCode ";
                sql += "from dbo.OPOR t2 ";
                sql += "inner join dbo.POR1 t1 on t1.DocEntry = t2.DocEntry ";
                sql += "and t1.TargetType = -1 ";
                sql += "and t1.WhsCode not in ('BASCP' , 'BPTP1' , 'BPTP2' , 'BPTP3' ) ) ";
                //sql += "where t2.[U_COMPRAPRODUCTOR] in (1 , 2 ) ) ";

            }

            sql += "order by t0.CardName ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }



    }
}
