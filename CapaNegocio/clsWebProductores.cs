using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class clsWebProductores : cldWebProductores 
    {
        public DataTable cResultado;

        public DataTable cls_ListarEntradasMercaderia(string idProductor)
        {
            this.ListarEntradasMercaderia(idProductor);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Pesaje(string docentry)
        {
            this.Consultar_Pesaje(docentry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ListarOrdenesdeCompra(string CardCode, int DocEntry)
        {
            this.ListarOrdenesdeCompra(CardCode, DocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ListarFacturasProveedores(string CardCode, int DocEntry)
        {
            this.ListarFacturasProveedores(CardCode, DocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        

    }
}
