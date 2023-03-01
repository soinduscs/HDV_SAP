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

    public class cldWebProductores : GestorSql
    {
        public cldWebProductores()
        {

        }

        public void ListarEntradasMercaderia(string idProductor)
        {

            string sql;

            sql = "exec SBO_SP_ListarEntradasMercaderia '" + idProductor + "'";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Pesaje(string docentry)
        {

            string sql;

            sql = "exec SAPB1_RECEPCION6 " + docentry;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ListarOrdenesdeCompra(string CardCode, int DocEntry)
        {

            string sql;

            sql = "exec SAPB1_RECEPCION7 '" + CardCode + "' , " + DocEntry.ToString(); 

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void ListarFacturasProveedores(string CardCode, int DocEntry)
        {

            string sql;

            sql = "exec SAPB1_RECEPCION8 '" + CardCode + "' , " + DocEntry.ToString();

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


    }
}
