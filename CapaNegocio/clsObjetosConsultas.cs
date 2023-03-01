using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class clsObjetosConsultas
    {
        public DataTable Resultado;
        public Boolean HayDatos;
        public int Filas;

       // public DataTable OrdenesAbiertas()
       // {
       ////     GestorSql objOrdenesAbiertas = new GestorSql("select DocEntry, Type, Status, PlannedQty, UserSign, Comments, PostDate, DueDate, CloseDate, RlsDate, CreateDate,  WareHouse, U_Proceso, U_TipoOrden, U_TipoFruta  from OWOR");

       //     try
       //     {
       //         this.Resultado = objOrdenesAbiertas.Resultado;

       //     }
       //     catch
       //     {

       //     }

       //     return this.Resultado;
       // }

        //public DataTable ListaProductos(string tipo_producto)
        //{

        //    string sql;
        //    sql = "select t1.ItemCode, t1.ItemName, t1.OnHand, t1.IsCommited     ,t2.U_TipoProducto  from OITM t1 left outer join OITB t2 on t1.ItmsGrpCod=t2.ItmsGrpCod where t2.U_TipoProducto<>'Otros' and t1.InvntItem='Y'";

        //    clsProductor objProductor = new CapaNegocio.clsProductor();
            


        //    GestorSql objOrdenesAbiertas = new GestorSql( sql);

        //    try
        //    {
        //        this.Resultado = objOrdenesAbiertas.Resultado;

        //    }
        //    catch
        //    {

        //    }

        //    return this.Resultado;
        //}



    }
}
