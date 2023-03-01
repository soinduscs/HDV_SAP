using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaNegocio;

namespace CapaEntidades
{
    public class entSocioNegocio
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int GroupCode { get; set; }
        public string Rut { get; set; }
        public string Clave { get; set; }

        public static DataTable ListaTCRD_Transportistas()
        {
            return new negSocioNegocio().ListaTCRD_Transportistas();
        }

        public static String SAPB1_TRANSP(string d_CardCode, string d_CardName, int d_Usr_registro)
        {
            negSocioNegocio transp = new negSocioNegocio();

            transp.CardCode = d_CardCode;
            transp.CardName = d_CardName;
            transp.Usr_registro = d_Usr_registro;

            return new negSocioNegocio().SAPB1_TRANSP(transp);
        }



    }


}
