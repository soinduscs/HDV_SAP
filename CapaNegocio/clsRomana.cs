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
    public class clsRomana : cldRomana 
    {
        public DataTable cResultado;
        /// <summary>
        /// /
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public DataTable cls_Consulta_Partidas_x_fecha(string fecha)
        {
            this.Consulta_Partidas_x_fecha(fecha);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_x_fecha1(string fecha)
        {
            this.Consulta_Partidas_x_fecha1(fecha);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_x_fecha1_dys(string fecha)
        {
            this.Consulta_Partidas_x_fecha1_dys(fecha);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas(String razon_acceso)
        {
            this.Consulta_Partidas_abiertas(razon_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas1_dys(String razon_acceso)
        {
            this.Consulta_Partidas_abiertas1_dys(razon_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas_dys(String razon_acceso, int d_anho)
        {
            this.Consulta_Partidas_abiertas_dys(razon_acceso, d_anho);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_guias_excluidas()
        {
            this.Consulta_guias_excluidas();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_guias_excluidas2()
        {
            this.Consulta_guias_excluidas2();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        
        public DataTable cls_Consulta_Partidas_abiertas_of(String razon_acceso)
        {
            this.Consulta_Partidas_abiertas_of(razon_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas_x_id(int id_romana, int nLineId)
        {
            this.Consulta_Partidas_abiertas_x_id(id_romana, nLineId);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas_x_id_exc(int id_romana)
        {
            this.Consulta_Partidas_abiertas_x_id_exc(id_romana);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas_x_id1(int DocEntry, int lineid)
        {
            this.Consulta_Partidas_abiertas_x_id1(DocEntry, lineid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_abiertas_x_id2(int DocEntry, int lineid)
        {
            this.Consulta_Partidas_abiertas_x_id2(DocEntry, lineid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Nuevo_DocEntry()
        {
            this.Consulta_Nuevo_DocEntry();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ItemCode_OC(string d_NumOC)
        {
            this.Consulta_ItemCode_OC(d_NumOC);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Detalles_Balanza(int DocEntry, int LineId, int nBalanza)
        {
            this.Consulta_Detalles_Balanza(DocEntry, LineId, nBalanza);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Detalles_Balanza1(int DocEntry, int LineId)
        {
            this.Consulta_Detalles_Balanza1(DocEntry, LineId);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_lista_bins()
        {
            this.Consulta_lista_bins();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_fecha_sql()
        {
            this.Consulta_fecha_sql();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_x_id_Detalle(int id_romana, int lineid)
        {
            this.Consulta_Partidas_x_id_Detalle(id_romana, lineid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_x_id_Entrada(int nDocEntry, int nDocType)
        {
            this.Consulta_Partidas_x_id_Entrada(nDocEntry, nDocType);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


        public static String SAPB1_ROMANA(int d_id_romana, string d_CardCode, string d_CardName, int d_NumGuia, string d_Patente, string d_conductor, string d_cod_envase,  int d_Envases, float d_PesoBruto, string d_FechaPeso1, float d_PesoTara, string d_FechaPeso2, float d_PesoNeto, string d_Obs, int d_id_acceso, string d_CardCode_trans, string d_CardName_trans, int d_Usr_registro, float d_PesoGuia, int d_LineId, string d_tipopesaje)
        {
            cldRomana romana = new cldRomana();

            romana.id_romana = d_id_romana;
            romana.CardCode = d_CardCode;
            romana.CardName = d_CardName;
            //romana.NumOC = d_NumOC;
            //romana.ItemCode = d_ItemCode;
            //romana.ItemName = d_ItemName;
            romana.NumGuia = d_NumGuia;
            romana.Patente = d_Patente;
            romana.conductor = d_conductor;
            romana.cod_envase = d_cod_envase;
            romana.Envases = d_Envases;
            romana.PesoBruto = d_PesoBruto;
            romana.FechaPeso1 = d_FechaPeso1;
            romana.PesoTara = d_PesoTara;
            romana.FechaPeso2 = d_FechaPeso2;
            romana.PesoNeto = d_PesoNeto;
            romana.Obs = d_Obs;
            romana.id_acceso = d_id_acceso;
            romana.CardCode_trans = d_CardCode_trans;
            romana.CardName_trans = d_CardName_trans;
            romana.Usr_registro = d_Usr_registro;
            romana.PesoGuia = d_PesoGuia;
            romana.LineId = d_LineId;
            romana.TipoPesaje = d_tipopesaje;

            return new cldRomana().SAPB1_ROMANA(romana);
        }

        public static String SAPB1_ROMANA2(int d_DocEntry, int d_LineId, string d_CardCode, string d_CardName, string d_ItemCode, string d_ItemName, string d_cod_envase, int d_Envases, int d_NumOC, int d_envasesvacios, string d_lote, string d_Codigo_CSG, int d_LineIdOC, string d_TipoCosecha)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_DocEntry;
            romana.LineId = d_LineId;
            romana.CardCode = d_CardCode;
            romana.CardName = d_CardName;
            romana.Codigo_CSG = d_Codigo_CSG;
            romana.ItemCode = d_ItemCode;
            romana.ItemName = d_ItemName;
            romana.cod_envase = d_cod_envase;
            romana.Envases = d_Envases;
            romana.NumOC = d_NumOC;
            romana.EnvasesVacios = d_envasesvacios;
            romana.Object = d_lote;
            romana.LineIdOC = d_LineIdOC;
            romana.TipoCosecha = d_TipoCosecha;

            return new cldRomana().SAPB1_ROMANA2(romana);
        }

        public static String SAPB1_ROMANA3(int d_docentry, float d_peso, int d_usr)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_docentry;
            romana.PesoBruto = d_peso;
            romana.Usr_registro = d_usr; 

            return new cldRomana().SAPB1_ROMANA3(romana);
        }

        public static String SAPB1_OPARAM(float d_peso, float d_peso2, string d_Bloquea, string d_Bloquea2, float d_Calidad_nue_fp, float d_Calidad_nue_fs, float d_Calidad_alm_fp, float d_Calidad_alm_fs)
        {
            cldRomana romana = new cldRomana();

            romana.PesoBruto = d_peso;
            romana.PesoNeto = d_peso2;
            romana.Bloqueo = d_Bloquea;
            romana.Bloqueo2 = d_Bloquea2;
            romana.Muestra_calidad_nue_fp = d_Calidad_nue_fp; 
            romana.Muestra_calidad_nue_fs = d_Calidad_nue_fs;
            romana.Muestra_calidad_alm_fp = d_Calidad_alm_fp;
            romana.Muestra_calidad_alm_fs = d_Calidad_alm_fs;

            return new cldRomana().SAPB1_OPARAM(romana);
        }

        public static String SAPB1_ROMANA5(int d_docentry, float d_pesotara, float d_pesoneto, int d_usr)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_docentry;
            romana.PesoTara = d_pesotara;
            romana.PesoNeto = d_pesoneto;
            romana.Usr_registro = d_usr;

            return new cldRomana().SAPB1_ROMANA5(romana);
        }

        public static String SAPB1_ROMANA9(int d_docentry)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_docentry;

            return new cldRomana().SAPB1_ROMANA9(romana);
        }

        public static String SAPB1_ROMANA7(int d_DocEntry, int d_Linea, int d_LineId, int d_idBalanza, string d_FechaPeso1, float d_PesoBruto, string d_ItemCode, float d_PesoEnvase, int d_Envases, float d_PesoNeto)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_DocEntry;            
            romana.Linea = d_Linea;
            romana.LineId = d_LineId;
            romana.idBalanza = d_idBalanza;
            romana.FechaPeso1 = d_FechaPeso1;
            romana.PesoBruto = d_PesoBruto;
            romana.ItemCode = d_ItemCode;
            romana.PesoEnvase = d_PesoEnvase;
            romana.Envases = d_Envases;
            romana.PesoNeto = d_PesoNeto;

            return new cldRomana().SAPB1_ROMANA7(romana);
        }

        public DataTable cls_Consulta_Partidas_x_id_Codigo(int DocEntry, int LineId)
        {
            this.Consulta_Partidas_x_id_Codigo(DocEntry, LineId);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consulta_Partidas_abiertas_x_id_2do_peso(int id_acceso)
        {
            this.Consulta_Partidas_abiertas_x_id_2do_peso(id_acceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_tabla_parametros()
        {
            this.Consulta_tabla_parametros();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_recepcion_mp(string c_tipo)
        {
            this.Consulta_Partidas_recepcion_mp(c_tipo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_SAPB1_ROMANA8(string c_tipo)
        {
            this.SAPB1_ROMANA8(c_tipo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_ROMANA4(int d_DocEntry, int d_LineId)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_DocEntry;
            romana.LineId = d_LineId;

            return new cldRomana().SAPB1_ROMANA4(romana);
        }

        public static String SAPB1_ROMANA4v1(int d_DocEntry, int d_LineId, int d_DocNum)
        {
            cldRomana romana = new cldRomana();

            romana.DocEntry = d_DocEntry;
            romana.LineId = d_LineId;
            romana.Linea = d_DocNum;

            return new cldRomana().SAPB1_ROMANA4v1(romana);
        }

        public DataTable cls_Consulta_Camiones_Ingresados(string fecha1, string fecha2)
        {
            this.Consulta_Camiones_Ingresados(fecha1, fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Registros_recepcion_mp(string fecha1, string fecha2, string Localidad)
        {
            this.Consulta_Registros_recepcion_mp(fecha1, fecha2, Localidad);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Imagenes_de_Romana(int BaseEntry)
        {
            this.Consulta_Imagenes_de_Romana(BaseEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Imagenes_de_entradaMP(int BaseEntry)
        {
            this.Consulta_Imagenes_de_entradaMP(BaseEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


    }
}
