using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaNegocio;

namespace CapaEntidades
{
    public class entOportunidad
    {
        public static DataTable opor_pendientes_x_cardcode(string cardcode)
        {
            return new negOportunidad().opor_pendientes_x_cardcode(cardcode);
        }

    }
}
