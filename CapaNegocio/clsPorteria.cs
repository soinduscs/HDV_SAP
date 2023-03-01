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
    public class clsPorteria : cldPorteria 
    {

        public DataTable cResultado;
        public int IdAcceso;
        public string Productor;
        public string NombreConductor;
        //public string Patente;
        public string NombreTransportista;
        public DateTime FechaRecepcion;
        public string HoraAdmision;




        public DataTable cls_Consultar_Accesos_x_Id(int id_acceso)
        {
            this.Consultar_Accesos_x_Id(id_acceso);

            this.cResultado = this.Resultado;
            return this.cResultado;
            ///
        }

        public DataTable cls_Consultar_RI_Humedad_x_Id(int id_romana)
        {
            this.Consultar_RI_Humedad_x_Id(id_romana);

            this.cResultado = this.Resultado;
            return this.cResultado;
            ///
        }

        public DataTable cls_Consultar_EntradaMercancia_x_Folio(int id_romana)
        {
            this.Consultar_EntradaMercancia_x_Folio(id_romana);

            this.cResultado = this.Resultado;
            return this.cResultado;
            ///
        }

        public DataTable cls_Consultar_1er_pesaje_x_Folio(int id_romana)
        {
            this.Consultar_1er_pesaje_x_Folio(id_romana);

            this.cResultado = this.Resultado;
            return this.cResultado;
            ///
        }

        public clsPorteria ()
        {

        }

        public clsPorteria(int Id_Acceso)
        {
            DataTable datosacceso = new DataTable();
            datosacceso = this.cls_Consultar_Accesos_x_Id(Id_Acceso);

            try
            {
                this.IdAcceso = int.Parse(datosacceso.Rows[0]["DocEntry"].ToString());
                this.Patente = datosacceso.Rows[0]["U_Patente"].ToString();
                this.NombreConductor  = datosacceso.Rows[0]["U_Conductor"].ToString();
                this.CardName = datosacceso.Rows[0]["U_CardName"].ToString();
                this.FechaRecepcion = Convert.ToDateTime(datosacceso.Rows[0]["U_FechaAcceso"].ToString());
                this.HoraAdmision = this.FechaRecepcion.ToString("HH:mm");



            }
            catch
            {
                this.IdAcceso = 0;
            }


        }


        public DataTable cls_Consultar_Razon_de_Ingreso()
        {
            this.Consultar_Razon_de_Ingreso();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consultar_Accesos_x_Imagen(int id_acceso)
        {
            this.Consultar_Accesos_x_Imagen(id_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Accesos_x_Numero(string valor, int numero, string cardcode)
        {
            this.Consultar_Accesos_x_Numero(valor, numero, cardcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Accesos_x_Caracter(string valor, string valor1)
        {
            this.Consultar_Accesos_x_Caracter(valor, valor1);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Transporstica_Patente(string CardCodeTrans)
        {
            this.Consultar_Transporstica_Patente(CardCodeTrans);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consultar_Accesos_x_Documento(string CardCode, int DocNum)
        {
            this.Consultar_Accesos_x_Documento(CardCode, DocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Accesos_max_Id()
        {
            this.Consultar_Accesos_max_Id();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Accesos(string fecha, string con_romana, string razon_acceso)
        {
            this.Consultar_Accesos(fecha, con_romana, razon_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Accesos_Full(string fecha, string con_romana)
        {
            this.Consultar_Accesos_Full(fecha, con_romana);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_ACCESO(int d_id_acesso, string d_CardCode, string d_CardName, int d_NumGuia, string d_Patente, int d_Usr_Registro, string d_Conductor, string d_CardCode_trans, string d_CardName_trans, string d_ruta_imagen, string d_razoningreso, string d_patentecarro, string d_sellos)
        {
            cldPorteria acceso = new cldPorteria();

            acceso.id_acceso = d_id_acesso;
            acceso.CardCode = d_CardCode;
            acceso.CardName = d_CardName;
            acceso.NumGuia = d_NumGuia;
            acceso.Patente = d_Patente;
            acceso.Usr_Registro = d_Usr_Registro;
            acceso.Conductor = d_Conductor;
            acceso.CardCode_trans = d_CardCode_trans;
            acceso.CardName_trans = d_CardName_trans;
            acceso.RutaImagen = d_ruta_imagen;
            acceso.RazonIngreso = d_razoningreso;
            acceso.PatenteCarro = d_patentecarro;
            acceso.Sellos = d_sellos;

            return new cldPorteria().SAPB1_ACCESO(acceso);
        }

        public static String SAPB1_ACCESO1(int d_docentry, int d_baseentry, int d_lineid, int d_tipopesaje, string d_ruta_imagen, string d_objectx)
        {
            cldPorteria acceso = new cldPorteria();

            acceso.DocEntry = d_docentry;
            acceso.LineId = d_lineid;
            acceso.BaseEntry = d_baseentry;
            acceso.TipoImagen = d_tipopesaje; 

            acceso.RutaImagen = d_ruta_imagen;
            acceso.Objectx = d_objectx;

            return new cldPorteria().SAPB1_ACCESO1(acceso);
        }

        public static String SAPB1_ACCESO2(int d_docentry, int d_baseentry, int d_lineid, string d_objectx)
        {
            cldPorteria acceso = new cldPorteria();

            acceso.DocEntry = d_docentry;
            acceso.LineId = d_lineid;
            acceso.BaseEntry = d_baseentry;
            acceso.Objectx = d_objectx;

            return new cldPorteria().SAPB1_ACCESO2(acceso);
        }

        public DataTable cls_Consultar_Dependencias_x_UserId(int UserSign)
        {
            this.Consultar_Dependencias_x_UserId(UserSign);
            this.cResultado = this.Resultado;
            return this.cResultado;
       
        }


    }
}
