using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaNegocio;

namespace CapaEntidades
{
    public class entOItem
    {
        public static DataTable ListaOITM()
        {
            return new negOItem().ListaOITM();
        }

        public static DataTable buscar_usuario(string variable)
        {
            return new negOItem().busca_usractivo(variable);
        }

        public static DataTable oitm_en_orden_de_compra(string num_pedido)
        {
            return new negOItem().oitm_en_orden_de_compra(num_pedido);
        }

    }
}
