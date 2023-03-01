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
    public  class clsMaestros : cldMaestros 
    {
        public DataTable cResultado;

        public string idProductor { get; set; }
        public String NombreProductor { get; set; }
        public String Contacto { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }
        //public int DocEntry { get; set; }
        //public int LineId { get; set; }
        //public int DocEntry_Ref { get; set; }

        public DataTable cls_lee_usuario(string user_code)
        {
            this.lee_usuario(user_code);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_lee_fecha_servidor()
        {
            this.lee_fecha_servidor();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_lee_localidades()
        {
            this.lee_localidades();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_venta_abiertas(string CardName)
        {
            this.Consultar_Ordenes_de_venta_abiertas(CardName);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_venta_x_DocNum(int nDocNum)
        {
            this.Consultar_Ordenes_de_venta_x_DocNum(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Arbol_Integridad_Orden_Facturacion(string cFather, string cSong)
        {
            this.Consultar_Arbol_Integridad_Orden_Facturacion(cFather, cSong);
            this.cResultado = this.Resultado;
            return this.cResultado;

        } 
        
        public DataTable cls_Consultar_Variables()
        {
            this.Consultar_Variables();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Variedades()
        {
            this.Consultar_Variedades();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_TipoContrato()
        {
            this.Consultar_TipoContrato();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Detalle_Productores_xCardCode(string cCardCode)
        {
            this.Consultar_Detalle_Productores_xCardCode(cCardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Detalle_Entradas_xCardCode(string cCardCode)
        {
            this.Consultar_Detalle_Entradas_xCardCode(cCardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_detalle_liquidacion(int nFolio)
        {
            this.Consultar_detalle_liquidacion(nFolio);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_vencimiento_liquidacion(int nFolio)
        {
            this.Consultar_vencimiento_liquidacion(nFolio);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Detalle_liquidacion_xCardCode(string cCardCode)
        {
            this.Consultar_Detalle_liquidacion_xCardCode(cCardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_max_liquidacion_productor()
        {
            this.Consultar_max_liquidacion_productor();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Variedades_combo()
        {
            this.Consultar_Variedades_combo();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Calibres()
        {
            this.Consultar_Calibres();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Temporadas(string d_tipo)
        {
            this.Consultar_Temporadas(d_tipo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Almacenes()
        {
            this.Consultar_Almacenes();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Almacenes_x_WhsCode(string d_WhsCode)
        {
            this.Consultar_Almacenes_x_WhsCode(d_WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Almacenes_x_WhsCode_new()
        {
            this.Consultar_Almacenes_x_WhsCode_new();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Temporadas_x_id(string d_code)
        {
            this.Consultar_Temporadas_x_id(d_code);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Temporadas_max()
        {
            this.Consultar_Temporadas_max();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Temporadas1_max()
        {
            this.Consultar_Temporadas1_max();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Temporadas_turnos_x_temporada(string d_temporada, string d_planta)
        {
            this.Consultar_Temporadas_turnos_x_temporada(d_temporada, d_planta);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_turnos_parametros()
        {
            this.Consultar_turnos_parametros();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_usuarios()
        {
            this.Consultar_usuarios();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_usuarios1()
        {
            this.Consultar_usuarios1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_almacen_asignado(int d_usderid)
        {
            this.Consultar_almacen_asignado(d_usderid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Bins_Produccion()
        {
            this.Consultar_Bins_Produccion();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Bins_Produccion1()
        {
            this.Consultar_Bins_Produccion1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Bins_Produccion2(string d_itemcode)
        {
            this.Consultar_Bins_Produccion2(d_itemcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_utiles_informediariostock(string cPeriodo)
        {
            this.Consultar_utiles_informediariostock(cPeriodo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Calibres_NuezMec(string cTipoFruta)
        {
            this.Consultar_Calibres_NuezMec(cTipoFruta);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_AtributoCalidad_RI(String cFamilia)
        {
            this.Consultar_AtributoCalidad_RI(cFamilia);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_AtributoCalidad_RI2(String cCodAtr, string cDocReferencia)
        {
            this.Consultar_AtributoCalidad_RI2(cCodAtr, cDocReferencia);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_HDV_ATRP1_max_Id(String cCodAtr)
        {
            this.Consultar_HDV_ATRP1_max_Id(cCodAtr);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_HDV_ATRP3_max_Id(String cCodAtr)
        {
            this.Consultar_HDV_ATRP3_max_Id(cCodAtr);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Defectos()
        {
            this.Consultar_Defectos();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_combo_pie_frm(string d_CodAtr)
        {
            this.Consulta_combo_pie_frm(d_CodAtr);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Calibres_combo()
        {
            this.Consultar_Calibres_combo();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Colores()
        {
            this.Consultar_Colores();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Operadores_Cracker()
        {
            this.Consultar_Operadores_Cracker();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_SalidasProduccion()
        {
            this.Consultar_SalidasProduccion();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_SalidasProduccion_Max_Code()
        {
            this.Consultar_SalidasProduccion_Max_Code(); 
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_SalidasProduccion_Max_TipoProducto(string cTipoProducto)
        {
            this.Consultar_SalidasProduccion_Max_TipoProducto(cTipoProducto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consultar_SalidasProduccion_TipoProducto(string cTipoProducto)
        {
            this.Consultar_SalidasProduccion_TipoProducto(cTipoProducto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ControlProductor()
        {
            this.Consulta_ControlProductor();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static string TablaUsuario_Variedad(string d_Code, string d_Name, string d_TipoFruta, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.Name = d_Name;
            tipo_variedad.TipoFruta = d_TipoFruta;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;
            
            return new cldMaestros().TablaUsuario_Variedad(tipo_variedad);
        }

        public static string TablaUsuario_LiqProductor(string d_Code, string d_Name, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.Name = d_Name;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_LiqProductor(tipo_variedad);
        }

        public static string Agrega_Detalle_LiqProductor(int d_DocEntry, int d_LineId, int d_DocEntry_Ref)
        {

            cldMaestros referencia = new cldMaestros();

            referencia.DocEntry = d_DocEntry;
            referencia.LineId = d_LineId;
            referencia.DocEntry_Ref = d_DocEntry_Ref;

            return new cldMaestros().Agrega_Detalle_LiqProductor(referencia);
        }

        public static string Agrega_Vencimiento_LiqProductor(int d_DocEntry, int d_LineId, DateTime d_fecha , float d_valor)
        {

            cldMaestros referencia = new cldMaestros();

            referencia.DocEntry = d_DocEntry;
            referencia.LineId = d_LineId;

            referencia.Fecha = d_fecha;
            referencia.Valor = d_valor;

            return new cldMaestros().Agrega_Vencimiento_LiqProductor(referencia);
        }

        public static string TablaUsuario_Proceso(string d_Code, int d_Id, string d_TipoFruta, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.LineId = d_Id;
            tipo_variedad.TipoFruta = d_TipoFruta;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_Proceso(tipo_variedad);
        }

        public static string TablaUsuario_Calibre(string d_Code, string d_Name, string d_TipoFruta, string d_defecto, int d_orden, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.Name = d_Name;
            tipo_variedad.TipoFruta = d_TipoFruta;
            tipo_variedad.Defecto = d_defecto;
            tipo_variedad.Orden = d_orden;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_Calibre(tipo_variedad);
        }

        public static string TablaUsuario_Color(string d_Code, string d_Name, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.Name = d_Name;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_Color(tipo_variedad);
        }

        public static string TablaUsuario_OperadorCracker(string d_Code, string d_Name, string d_usuariosap, string d_clavesap)
        {

            cldMaestros operador_cracker = new cldMaestros();

            operador_cracker.Code = d_Code;
            operador_cracker.Name = d_Name;

            operador_cracker.UsuarioSap = d_usuariosap;
            operador_cracker.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_OperadorCracker(operador_cracker);
        }

        public static string TablaUsuario_SalidaProduccion(string d_Code, string d_Salida, string d_Name, string d_TipoFruta, string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.Code = d_Code;
            tipo_variedad.Name = d_Name;
            tipo_variedad.Salida = d_Salida;
            tipo_variedad.TipoFruta = d_TipoFruta;

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().TablaUsuario_SalidaProduccion(tipo_variedad);
        }

        public static string Valido_Clave(string d_usuariosap, string d_clavesap)
        {

            cldMaestros tipo_variedad = new cldMaestros();

            tipo_variedad.UsuarioSap = d_usuariosap;
            tipo_variedad.ClaveSap = d_clavesap;

            return new cldMaestros().Valido_Clave(tipo_variedad);
        }

        public static string SAPB1_OCRP(int d_Cosecha, string d_CardCode , string d_ItemCode, string d_Variedad ,float  d_has_total , float d_has_produccion , float d_kg_potencial , float d_kg_oportunidad , float d_kg_presupuesto, string d_tipocontrato , string d_usuariosap, string d_clavesap)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Cosecha = d_Cosecha;
            parMaestros.CardCode = d_CardCode;
            parMaestros.ItemCode = d_ItemCode;
            parMaestros.Variedad = d_Variedad;
            parMaestros.has_total = d_has_total;
            parMaestros.has_produccion = d_has_produccion;
            parMaestros.kg_potencial = d_kg_potencial;
            parMaestros.kg_oportunidad = d_kg_oportunidad;
            parMaestros.kg_presupuesto = d_kg_presupuesto;
            parMaestros.tipocontrato = d_tipocontrato;

            parMaestros.UsuarioSap = d_usuariosap;
            parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OCRP(parMaestros);
        }

        public static string SAPB1_OCRX(string d_accion, string d_codcli , string d_codprod, int d_usersign, string d_usuariosap, string d_clavesap)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Accion = d_accion;
            parMaestros.CodProd = d_codprod;
            parMaestros.CodCli = d_codcli;
            parMaestros.UserSign = d_usersign;

            parMaestros.UsuarioSap = d_usuariosap;
            parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OCRX(parMaestros);
        }


        public static string SAPB1_OTEMPORADA(string d_code, string d_temporada, DateTime d_fecha_ini, double d_Hora_Tot, int d_dias_semana, int d_dias_mes, double d_Meta_PT, double d_Meta_MP, double d_Rendim_PT, double d_Rendim_MP)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.Temporada  = d_temporada;
            parMaestros.Fecha = d_fecha_ini;
            parMaestros.Horas_Tot = d_Hora_Tot;
            parMaestros.Dias_Semana = d_dias_semana;
            parMaestros.Dias_Mes = d_dias_mes;
            parMaestros.Meta_PT = d_Meta_PT;
            parMaestros.Meta_MP = d_Meta_MP;
            parMaestros.Rendim_PT = d_Rendim_PT;
            parMaestros.Rendim_MP = d_Rendim_MP;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OTEMPORADA(parMaestros);
        }

        public static string SAPB1_OTEMPORADA_A(string d_code, string d_name, string d_temporada, string d_planta, string d_turno)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.Name = d_name;
            parMaestros.Temporada = d_temporada;
            parMaestros.Planta = d_planta;
            parMaestros.Turno = d_turno;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OTEMPORADA_A(parMaestros);
        }

        public static string SAPB1_OTEMPORADA_B(string d_temporada)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Temporada = d_temporada;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OTEMPORADA_B(parMaestros);
        }

        public static string SAPB1_OTEMPORADA_C(string d_temporada)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Temporada = d_temporada;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OTEMPORADA_C(parMaestros);
        }

        public static string SAPB1_OTEMPORADA_I(string d_code, string d_name, string d_temporada, string d_planta)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.Name = d_name;
            parMaestros.Temporada = d_temporada;
            parMaestros.Planta = d_planta;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OTEMPORADA_I(parMaestros);
        }


        public static string SAPB1_OALMACEN(string d_code, string d_whscode,double d_Capacidad_PT, double d_PT_R_Ini, double d_PT_R_Fin, double d_PT_A_Ini, double d_PT_A_Fin, double d_PT_V_Ini, double d_PT_V_Fin, double d_Capacidad_MP, double d_MP_R_Ini, double d_MP_R_Fin, double d_MP_A_Ini, double d_MP_A_Fin, double d_MP_V_Ini, double d_MP_V_Fin)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.WhsCode = d_whscode;
            parMaestros.Capacidad_PT = d_Capacidad_PT;
            parMaestros.PT_R_Ini = d_PT_R_Ini;
            parMaestros.PT_R_Fin = d_PT_R_Fin;
            parMaestros.PT_A_Ini = d_PT_A_Ini;
            parMaestros.PT_A_Fin = d_PT_A_Fin;
            parMaestros.PT_V_Ini = d_PT_V_Ini;
            parMaestros.PT_V_Fin = d_PT_V_Fin;

            parMaestros.Capacidad_MP = d_Capacidad_MP;
            parMaestros.MP_R_Ini = d_MP_R_Ini;
            parMaestros.MP_R_Fin = d_MP_R_Fin;
            parMaestros.MP_A_Ini = d_MP_A_Ini;
            parMaestros.MP_A_Fin = d_MP_A_Fin;
            parMaestros.MP_V_Ini = d_MP_V_Ini;
            parMaestros.MP_V_Fin = d_MP_V_Fin;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OALMACEN(parMaestros);

        }

        public static string SAPB1_OALMACEN_u(string d_code, string d_whscode, double d_Capacidad_PT, double d_PT_R_Ini, double d_PT_R_Fin, double d_PT_A_Ini, double d_PT_A_Fin, double d_PT_V_Ini, double d_PT_V_Fin, double d_Capacidad_MP, double d_MP_R_Ini, double d_MP_R_Fin, double d_MP_A_Ini, double d_MP_A_Fin, double d_MP_V_Ini, double d_MP_V_Fin)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.WhsCode = d_whscode;
            parMaestros.Capacidad_PT = d_Capacidad_PT;
            parMaestros.PT_R_Ini = d_PT_R_Ini;
            parMaestros.PT_R_Fin = d_PT_R_Fin;
            parMaestros.PT_A_Ini = d_PT_A_Ini;
            parMaestros.PT_A_Fin = d_PT_A_Fin;
            parMaestros.PT_V_Ini = d_PT_V_Ini;
            parMaestros.PT_V_Fin = d_PT_V_Fin;

            parMaestros.Capacidad_MP = d_Capacidad_MP;
            parMaestros.MP_R_Ini = d_MP_R_Ini;
            parMaestros.MP_R_Fin = d_MP_R_Fin;
            parMaestros.MP_A_Ini = d_MP_A_Ini;
            parMaestros.MP_A_Fin = d_MP_A_Fin;
            parMaestros.MP_V_Ini = d_MP_V_Ini;
            parMaestros.MP_V_Fin = d_MP_V_Fin;

            //parMaestros.UsuarioSap = d_usuariosap;
            //parMaestros.ClaveSap = d_clavesap;

            return new cldMaestros().SAPB1_OALMACEN_u(parMaestros);

        }

        public static string SAPB1_OALMACEN_e(string d_code)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;

            return new cldMaestros().SAPB1_OALMACEN_e(parMaestros);

        }

        public static string SAPB1_TEMPORADA1(string d_code, double d_Meta_PT, double d_Meta_MP)
        {

            cldMaestros parMaestros = new cldMaestros();

            parMaestros.Code = d_code;
            parMaestros.Meta_PT = d_Meta_PT;
            parMaestros.Meta_MP = d_Meta_MP;

            return new cldMaestros().SAPB1_TEMPORADA1(parMaestros);
        }



    }

}
