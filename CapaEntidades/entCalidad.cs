using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaNegocio;

namespace CapaEntidades
{
    public class entCalidad
    {

        public static DataTable lee_CALIDAD_MPXANALIZAR()
        {
            return new negCalidad().lee_CALIDAD_MPXANALIZAR();
        }

        public static DataTable lee_CALIDAD_MPXANALIZAR1(string c_lote)
        {
            return new negCalidad().lee_CALIDAD_MPXANALIZAR1(c_lote);
        }

        public static DataTable lista_atributos_nueces_mp()
        {
            return new negCalidad().lista_atributos_nueces_mp();
        }


    }
}
