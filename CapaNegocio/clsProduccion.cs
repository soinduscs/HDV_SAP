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
    public class clsProduccion : cldProduccion
    {
        public DataTable cResultado;

        public DataTable cls_ConsultaLMateriales_SAP(string itemcode)
        {
            this.ConsultaLMateriales_SAP(itemcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_OFUM(int d_docentry)
        {
            this.Consulta_OFUM(d_docentry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_OFUM1(string d_lote)
        {
            this.Consulta_OFUM1(d_lote);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_OFUM2(string d_fecha1, string d_fecha2)
        {
            this.Consulta_OFUM2(d_fecha1, d_fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLMateriales(int DocEntry)
        {
            this.ConsultaLMateriales(DocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLMateriales_Resumen(string itemcode)
        {
            this.ConsultaLMateriales_Resumen(itemcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_RECETA(string d_ItemCode, int d_UserSign)
        {

            cldProduccion receta = new cldProduccion();

            receta.ItemCode = d_ItemCode;
            receta.UserSign = d_UserSign;

            return new cldProduccion().SAPB1_RECETA(receta);
        }

        public DataTable cls_ConsultaLista_Almacenes()
        {
            this.ConsultaLista_Almacenes();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Almacenes_almacen()
        {
            this.ConsultaLista_Almacenes_almacen();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_TipoCosecha()
        {
            this.ConsultaLista_TipoCosecha();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable Cls_ConsultaLista_TipoFruta()
        {
            this.ConsultaLista_TipoFruta();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable Cls_ConsultaLista_TipoFruta1()
        {
            this.ConsultaLista_TipoFruta1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable Cls_ConsultaLista_TipoFruta2(string Code)
        {
            this.ConsultaLista_TipoFruta2(Code);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Dimension1()
        {
            this.ConsultaLista_Dimension1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Dimension2()
        {
            this.ConsultaLista_Dimension2();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Dimension3()
        {
            this.ConsultaLista_Dimension3();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Turnos()
        {
            this.ConsultaLista_Turnos();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_area()
        {
            this.ConsultaLista_area();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_numero_semana_actual()
        {
            this.consulta_numero_semana_actual();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_centros_costo_gestper()
        {
            this.consulta_centros_costo_gestper();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_dependencia1_gestper()
        {
            this.consulta_dependencia1_gestper();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_dependencia1_gestper_v2()
        {
            this.consulta_dependencia1_gestper_v2();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_empleados_gestper(string c_nombre, string c_dependencia_no, string c_dependencia)
        {
            this.consulta_empleados_gestper(c_nombre, c_dependencia_no, c_dependencia);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_lista_de_turno()
        {
            this.consulta_lista_de_turno();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_lista_de_status()
        {
            this.consulta_lista_de_status();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_lista_de_operadores()
        {
            this.consulta_lista_de_operadores();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_lista_de_turno_x_codigo(string codigo)
        {
            this.consulta_lista_de_turno_x_codigo(codigo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_fechas_por_semana(int nNumSemana, int nAnho)
        {
            this.consulta_fechas_por_semana(nNumSemana, nAnho);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_xSapb1_utiles_muestratarjaporperiodo(string caccion, int nNumSemana, int nAnho, string ccosto, string cdependencia)
        {
            this.xSapb1_utiles_muestratarjaporperiodo(caccion, nNumSemana, nAnho, ccosto, cdependencia);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_xSapb1_query_turnoscracker(int nAnho, int nMes, string carea)
        {
            this.xSapb1_query_turnoscracker(nAnho, nMes, carea);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_MetodoEmision()
        {
            this.ConsultaLista_MetodoEmision();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Almacenes_X_Localidad(string cLocalidad)
        {
            this.ConsultaLista_Almacenes_X_Localidad(cLocalidad);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Almacenes_BM()
        {
            this.ConsultaLista_Almacenes_BM();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Productos_Sin_Pallet(string cItemCode, string cAlmacen)
        {
            this.Consulta_Productos_Sin_Pallet(cItemCode, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recibo_x_DocEntry_en_Detalle(int nDocEntry)
        {
            this.Consulta_Recibo_x_DocEntry_en_Detalle(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Variedad_en_Producto_de_Consumo(int NumOF)
        {
            this.Consulta_Variedad_en_Producto_de_Consumo(NumOF);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Cant_Disponible_OC(int NumOF)
        {
            this.Consulta_Cant_Disponible_OC(NumOF);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Ultimo_Peso_Productivo(int NumOF, string cItemCode)
        {
            this.Consulta_Ultimo_Peso_Productivo(NumOF, cItemCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_RECETA2(int d_DocEntry, string  d_ItemCode, double d_Qauntity , string d_ToWH , string d_referencia, int d_UserSign)
        {

            cldProduccion receta = new cldProduccion();

            receta.DocEntry = d_DocEntry;
            receta.ItemCode = d_ItemCode;
            receta.Qauntity = d_Qauntity;
            receta.ToWH = d_ToWH;
            receta.Referencia = d_referencia;
            receta.UserSign = d_UserSign;

            return new cldProduccion().SAPB1_RECETA2(receta);
        }

        public static String SAPB1_RECETA3(int d_DocEntry, int d_LineId , string d_ItemCode, double d_Qauntity, string d_ToWH, string d_OrigCurr, int d_UserSign)
        {

            cldProduccion receta = new cldProduccion();

            receta.DocEntry = d_DocEntry;
            receta.LineId = d_LineId;
            receta.ItemCode = d_ItemCode;
            receta.Qauntity = d_Qauntity;
            receta.ToWH = d_ToWH;
            receta.OrigCurr = d_OrigCurr;

            receta.UserSign = d_UserSign;

            return new cldProduccion().SAPB1_RECETA3(receta);
        }

        public DataTable cls_ConsultaLista_Usuarios()
        {
            this.ConsultaLista_Usuarios();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Ubicacion_Lote(string accion, string whscode, string sl1code)
        {
            this.ConsultaLista_Ubicacion_Lote(accion, whscode, sl1code);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Solicitud_de_transferencia(string cDocEntry)
        {
            this.Consulta_Solicitud_de_transferencia(cDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consulta_Solicitud_de_transferencia_x_lote(string cDocEntry)
        {
            this.Consulta_Solicitud_de_transferencia_x_lote(cDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_PartidasAbiertas_Solicitudes()
        {
            this.ConsultaLista_PartidasAbiertas_Solicitudes();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lote(string cLote)
        {
            this.Consulta_Lote(cLote);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lote_en_solicitud_transferencia(string cLote)
        {
            this.Consulta_Lote_en_solicitud_transferencia(cLote);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lote_y_Stock(string cLote, string cAlmacen)
        {
            this.Consulta_Lote_y_Stock(cLote, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Ubicaciones()
        {
            this.Consulta_Ubicaciones();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Bodegas_Ubicaciones()
        {
            this.Consulta_Bodegas_Ubicaciones();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Pasillo_Ubicaciones_x_bodegas(string WhsCode)
        {
            this.Consulta_Pasillo_Ubicaciones_x_bodegas(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Pasillo_Ubicaciones_x_bodegas_i(string WhsCode)
        {
            this.Consulta_Pasillo_Ubicaciones_x_bodegas_i(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Ubicaciones_x_bincode_y_bodega(string BinCode, string WhsCode)
        {
            this.Consulta_Ubicaciones_x_bincode_y_bodega(BinCode, WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Pasillo_Ubicaciones_x_bodegas_y_pasillo(string WhsCode, string Pasillo)
        {
            this.Consulta_Pasillo_Ubicaciones_x_bodegas_y_pasillo(WhsCode, Pasillo);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Bodegas_Ubicaciones_x_bincode(string BinCode)
        {
            this.Consulta_Bodegas_Ubicaciones_x_bincode(BinCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_OrdendeVenta_x_DocNum(int DocNum)
        {
            this.Consulta_OrdendeVenta_x_DocNum(DocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OrdendeVenta_con_Entrega_x_DocNum(int DocNum)
        {
            this.Consulta_OrdendeVenta_con_Entrega_x_DocNum(DocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OrdendeVenta_Entre_Fechas()
        {
            this.Consulta_OrdendeVenta_Entre_Fechas();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Pallet()
        {
            this.Consulta_Pallet();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Pallet_x_Code(string cCode)
        {
            this.Consulta_Pallet_x_Code(cCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Pallet_x_Code_Almacen(string cCode, string cAlmacen)
        {
            this.Consulta_Pallet_x_Code_Almacen(cCode, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_EntradaMercancia_Web(int DocEntry)
        {
            this.Consulta_EntradaMercancia_Web(DocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }


        public static String Borra_Lote_de_Pallet(string d_Pallet, string d_Lote)
        {

            cldProduccion pallet = new cldProduccion();

            pallet.Pallet = d_Pallet;
            pallet.Lote = d_Lote;
        
            return new cldProduccion().Borra_Lote_de_Pallet(pallet);
        }

        public DataTable cls_Consulta_OBATCH_x_Cadena(int d_DocEntry, int d_DocNm, string d_fecha, string d_hora, double d_peso, int d_registro_rnd)
        {
            this.Consulta_OBATCH_x_Cadena(d_DocEntry, d_DocNm, d_fecha, d_hora, d_peso, d_registro_rnd);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OBATCH_Pendientes()
        {
            this.Consulta_OBATCH_Pendientes();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OBATCH_UltimoRegistro()
        {
            this.Consulta_OBATCH_UltimoRegistro();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OBATCH_Lotes_Pendientes(string WhsCode)
        {
            this.Consulta_OBATCH_Lotes_Pendientes(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OBATCH_Ingresados(string fecha1, string fecha2)
        {
            this.Consulta_OBATCH_Ingresados(fecha1, fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Vista_Lotes(string DistNumber)
        {
            this.Consulta_Vista_Lotes(DistNumber);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Vista_Lotes_x_WhsCode(string WhsCode)
        {
            this.Consulta_Vista_Lotes_x_WhsCode(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Vista_Lotes_Rechazados_x_WhsCode(string WhsCode)
        {
            this.Consulta_Vista_Lotes_Rechazados_x_WhsCode(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_OBATCH_OF_Pendientes(string WhsCode)
        {
            this.Consulta_OBATCH_OF_Pendientes(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public static String Insert_Coordinar_Orden_Fabricacion(string d_docentry, string d_fecha_planificacion, string d_usuariosap, string d_clavesap)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.Fecha_Planificacion = d_fecha_planificacion; 

            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldProduccion().Insert_Coordinar_Orden_Fabricacion(orden_fabricacion);
        }

        public static String Modificar_fecha_finalizacion_Orden_Fabricacion(string d_docentry, string d_fecha_planificacion, string d_usuariosap, string d_clavesap)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.Fecha_Planificacion = d_fecha_planificacion;

            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldProduccion().Modificar_fecha_finalizacion_Orden_Fabricacion(orden_fabricacion);
        }

        public static String Borrar_Coordinar_Orden_Fabricacion(string d_docentry)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Borrar_Coordinar_Orden_Fabricacion(orden_fabricacion);
        }

        public static String Modifica_Destino_Secado_RecibeMP(string d_docentry)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Modifica_Destino_Secado_RecibeMP(orden_fabricacion);
        }

        public static String Modifica_Destino_Secado_RecibeMPv2020(string d_docentry)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Modifica_Destino_Secado_RecibeMPv2020(orden_fabricacion);
        }

        public static String Modifica_Destino_OC_MPv2020(string d_docentry, string d_numoc)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.DocNum = int.Parse(d_numoc);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Modifica_Destino_OC_MPv2020(orden_fabricacion);
        }

        public static String Modifica_Destino_Secado_EnviaCliente(string d_docentry)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Modifica_Destino_Secado_EnviaCliente(orden_fabricacion);
        }

        public static String Modifica_Destino_Secado_EnviaClientev2020(string d_docentry)
        {

            cldProduccion orden_fabricacion = new cldProduccion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            return new cldProduccion().Modifica_Destino_Secado_EnviaClientev2020(orden_fabricacion);
        }

        public static String SAPB1_OBATCH(int d_DocEntry, int d_DocNm, string d_fecha, string d_hora, double d_peso, int d_registro_rnd, int d_docentry_consumo)
        {

            cldProduccion pesaje = new cldProduccion();

            pesaje.DocEntry = d_DocEntry;
            pesaje.DocNum = d_DocNm;
            pesaje.FechaRegistro = d_fecha;
            pesaje.HoraRegistro = d_hora;
            pesaje.Peso = d_peso;
            pesaje.IdRegistro_rnd = d_registro_rnd;
            pesaje.DocEntry_Consumo = d_docentry_consumo;

            return new cldProduccion().SAPB1_OBATCH(pesaje);
        }


    }

}
