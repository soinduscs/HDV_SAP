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
    public class clsSocioNegocio:cldSocioNegocio
    {
        public string cCardCode;
        public string cCardName;
        public string cClaveAcceso;
        public DataTable cResultado;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable cls_Consulta_Productores()
        {
            this.Consultar_CodigoProductores();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Transportistas()
        {
            this.Consultar_Transportistas();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consultar_OCRDxCardCode(string CardCode)
        {
            this.Consultar_OCRDxCardCode(CardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_ContactosxCardCode(string CardCode)
        {
            this.Consultar_ContactosxCardCode(CardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_OCRDxCardName(string cardname, string con_oc, string solo_proveedores)
        {
            this.Consultar_OCRDxCardName(cardname, con_oc, solo_proveedores);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


    }
}
