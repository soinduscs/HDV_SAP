using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class clsOrdenFabricacion : cldOrdenFabricacion
    {
        public int vDocEntry;
        public string vItemCode;
        public string vItemName;
        //DateTime vFechaInicio;
        //DateTime vFechaFin;
        //D//ateTime vFechaCreacion;
        //DateTime vFechaLiberacion;
        //string vProceso;
        //int vOrdenAfecta;
        public double Consumos;
        public double Reportes;
        public double Rendimiento;
        //DataTable vDetalleOrdenFabricacion;
        public DataTable cResultado;

        public DataTable Consulta_OrdenesFabricacionAbiertas()
        {
            this.consultar_OrdenesFabricacionAbiertas();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public clsOrdenFabricacion(int NroOrdenFabricacion)
        {
            if (NroOrdenFabricacion > 0)
            {
                this.consultar_DatosCabeceraOrdenFabricacion(NroOrdenFabricacion);
                if (this.HayDatos)
                {
                    this.vDocEntry = Convert.ToInt32(this.Resultado.Rows[0]["DocEntry"].ToString());
                    this.vItemCode = this.Resultado.Rows[0]["ItemCode"].ToString();
                    clsProductos objProducto = new clsProductos(this.vItemCode);
                    this.vItemName = objProducto.ItemName;


                    objProducto = null;

                }
                cls_Consulta_ProcesosProductivosOrdenFabricacion(NroOrdenFabricacion);
                this.Consumos = Consulta_ConsumosProcesosProductivos() * -1;
                this.Reportes = Consulta_ReportesProcesosProductivos();
                this.Rendimiento = this.Reportes / this.Consumos ;

            }

        }

        public clsOrdenFabricacion()
        {

        }

        public DataTable cls_Consulta_ProcesosProductivosOrdenFabricacion(int NroOrdenFabricacion)
        {
            this.consultar_ProcesosProductivosOrdenFabricacion(NroOrdenFabricacion);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_pallet_existentes(string cItemCode, string cAlmacen)
        {
            this.Consulta_pallet_existentes(cItemCode, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public double Consulta_ConsumosProcesosProductivos()
        {
            double resultado;
            try
            {
                resultado = Convert.ToDouble(this.Resultado.Compute("SUM(Quantity)", "TipoDocto='ConsumoProduccion'").ToString());
            }
            catch
            {
                resultado = 0;
            }

            return resultado;

        }

        public double Consulta_ReportesProcesosProductivos()
        {

            double resultado;
            try
            {
                 resultado = Convert.ToDouble(this.Resultado.Compute("SUM(Quantity)", "TipoDocto='ReporteProduccion'").ToString());
            }
            catch
            {
                resultado = 0;
            }
           
            return resultado;
     
        }

        public DataTable cls_Consultar_OrdenFabricacion_x_DocNum(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_x_DocNum(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_x_DocNum_Insumos(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_x_DocNum_Insumos(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Insumos_Servicios(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_Insumos_Servicios(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Insumos_Servicios_Linea(int nDocNum, string cItemCode)
        {
            this.Consultar_OrdenFabricacion_Insumos_Servicios_Linea(nDocNum, cItemCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }


        public DataTable cls_Consultar_OrdenFabricacion_x_DocNum1(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_x_DocNum1(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Pesaje_DyS(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_Pesaje_DyS(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Producto_x_Lote(string cDistNumber)
        {
            this.Consultar_Producto_x_Lote(cDistNumber);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Detalle_TR(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_Detalle_TR(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Detalle_Consumos(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_Detalle_Consumos(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Origen_MP(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_Origen_MP(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_para_Cerrar(int nDocNum)
        {
            this.Consultar_OrdenFabricacion_para_Cerrar(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lotes_Asignados_x_OrdenFabricacion(int nDocNum)
        {
            this.Consultar_Lotes_Asignados_x_OrdenFabricacion(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_LotesTransferidospara_OF(int nDocNum)
        {
            this.Consultar_LotesTransferidospara_OF(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Max_DocNum()
        {
            this.Consultar_OrdenFabricacion_Max_DocNum();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lita_UProcesos(int nFieldID)
        {
            this.Consultar_Lita_UProcesos(nFieldID);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_de_OrdenFabricacion(string status, string planta, string proceso)
        {
            this.Consultar_Lista_de_OrdenFabricacion(status, planta, proceso);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_de_OrdenFabricacion1(string status)
        {
            this.Consultar_Lista_de_OrdenFabricacion1(status);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_de_fumigado()
        {
            this.Consultar_Lista_de_fumigados();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_de_OrdenFabricacion_despelonado(string status)
        {
            this.Consultar_Lista_de_OrdenFabricacion_despelonado(status);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_de_guiasinternas_dys(string status, string c_lote)
        {
            this.Consultar_Lista_de_guiasinternas_dys(status, c_lote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_informe_binsproductores(string d_accion, string d_cardcode)
        {
            this.informe_binsproductores(d_accion, d_cardcode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_xSapb1_utiles_resumen_televisor_ncc(int d_temporada, string d_fecha, string d_accion, string d_turno)
        {
            this.xSapb1_utiles_resumen_televisor_ncc(d_temporada, d_fecha, d_accion, d_turno);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_xSapb1_utiles_resumen_nivel_stock()
        {
            this.xSapb1_utiles_resumen_nivel_stock();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lotes_mp_pelon_dys()
        {
            this.Consultar_Lotes_mp_pelon_dys();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lotes_mp_pelon_dys1(string d_anho)
        {
            this.Consultar_Lotes_mp_pelon_dys1(d_anho);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_stock_ItemCode_Lote(string ItemCode)
        {
            this.Consulta_stock_ItemCode_Lote(ItemCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_stock_ItemCode_Pallet(string ItemCode, string WhsCode)
        {
            this.Consulta_stock_ItemCode_Pallet(ItemCode, WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_stock_ItemCode_Pallet_Lote(string ItemCode, string WhsCode, string FolioPallet)
        {
            this.Consulta_stock_ItemCode_Pallet_Lote(ItemCode, WhsCode, FolioPallet);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Lotes_x_ReciboProduccion(int nDocEntry)
        {
            this.Consulta_Lotes_x_ReciboProduccion(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumos_x_DocEntry(int nDocEntry)
        {
            this.Consultar_DeclaracionInsumos_x_DocEntry(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumosv2_x_DocEntry(int nDocEntry)
        {
            this.Consultar_DeclaracionInsumosv2_x_DocEntry(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumosv3_x_DocEntry(int nDocEntry)
        {
            this.Consultar_DeclaracionInsumosv3_x_DocEntry(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumos_x_FechaTurnoArea(string cFecha, int nTurno, int nArea)
        {
            this.Consultar_DeclaracionInsumos_x_FechaTurnoArea(cFecha, nTurno, nArea);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumosv2_x_FechaTurnoArea(string cFecha, int nTurno, int nArea)
        {
            this.Consultar_DeclaracionInsumosv2_x_FechaTurnoArea(cFecha, nTurno, nArea);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_DeclaracionInsumos(string FechaInicio, string FechaTermino)
        {
            this.Consultar_Lista_DeclaracionInsumos(FechaInicio, FechaTermino);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_DeclaracionInsumosv2(string FechaInicio, string FechaTermino)
        {
            this.Consultar_Lista_DeclaracionInsumosv2(FechaInicio, FechaTermino);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lista_DeclaracionInsumosv3(string FechaInicio, string FechaTermino)
        {
            this.Consultar_Lista_DeclaracionInsumosv3(FechaInicio, FechaTermino);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lotes_Asignados_para_Consumir(int nDocEntry)
        {
            this.Consultar_Lotes_Asignados_para_Consumir(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Lotes_Asignados_para_Consumir_x_of(int nLote)
        {
            this.Consultar_Lotes_Asignados_para_Consumir_x_of(nLote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Max_Linea(int nDocEntry)
        {
            this.Consultar_OrdenFabricacion_Max_Linea(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumos_Max_DocEntry()
        {
            this.Consultar_DeclaracionInsumos_Max_DocEntry();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_DeclaracionInsumosv2_Max_DocEntry()
        {
            this.Consultar_DeclaracionInsumosv2_Max_DocEntry();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_insumos_Asignados_para_Consumir(int nDocEntry)
        {
            this.Consultar_insumos_Asignados_para_Consumir(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Planifacadas(string Status)
        {
            this.Consultar_OrdenFabricacion_Planifacadas(Status);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_OrdenFabricacion_Planifacadas_con_insumos(string Status)
        {
            this.Consultar_OrdenFabricacion_Planifacadas_con_insumos(Status);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consultar_Solicitudes_Planifacadas(string Status)
        {
            this.Consultar_Solicitudes_Planifacadas(Status);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public static string Production_Orders(int d_DocEntry, int d_DocNum, string d_PostDate, string d_StartDate, string d_DueDate, string d_ItemCode, string d_ItemName, string d_UM, int d_UserSign, string d_Warehouse, double d_PlannedQty, int d_OriginNum, string d_CardCode, string d_Project, string d_Comments, string d_Status, string d_Type, string d_U_Proceso, string d_U_OrdenAfecta, string d_U_TipoOrden, string d_U_TipoFruta, string[,] d_arrDetalle, string d_usuariosap, string d_clavesap)
        { 
            cldOrdenFabricacion orden = new cldOrdenFabricacion();

            orden.DocEntry = d_DocEntry;
            orden.DocNum = d_DocNum;
            orden.PostDate = d_PostDate;
            orden.StartDate = d_StartDate;
            orden.DueDate = d_DueDate;
            orden.ItemCode = d_ItemCode;
            orden.ItemName = d_ItemName;
            orden.UM = d_UM;
            orden.UserSign = d_UserSign;
            orden.Warehouse = d_Warehouse;
            orden.PlannedQty = d_PlannedQty;
            orden.OriginNum = d_OriginNum;
            orden.CardCode = d_CardCode;
            orden.Project = d_Project;
            orden.Comments = d_Comments;
            orden.Status = d_Status;
            orden.Type = d_Type;
            orden.U_Proceso = d_U_Proceso;
            orden.U_OrdenAfecta = d_U_OrdenAfecta;
            orden.U_TipoOrden = d_U_TipoOrden;
            orden.U_TipoFruta = d_U_TipoFruta;
            orden.arrDetalle = d_arrDetalle;
            orden.UsuarioSap = d_usuariosap;
            orden.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_Orders(orden);
        }

        public static string Production_Orders_AsignaLotes(int d_DocEntry, int d_DocNum, string[,] d_arrDetalle, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion orden = new cldOrdenFabricacion();

            orden.DocEntry = d_DocEntry;
            orden.DocNum = d_DocNum;
            orden.arrDetalle = d_arrDetalle;
            orden.UsuarioSap = d_usuariosap;
            orden.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_Orders_AsignaLotes(orden);
        }

        public static String Stock_Transfer(int d_DocNum, string d_DocDate, string[,] d_arrDetalle, string[,] d_arrDetalle1, string d_CardCode , string d_CardName, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion StockTransf = new cldOrdenFabricacion();

            StockTransf.DocNum = d_DocNum;
            StockTransf.DocDate = d_DocDate;
            //StockTransf.Warehouse = d_WhsCode;
            StockTransf.arrDetalle = d_arrDetalle;
            StockTransf.arrDetalle1 = d_arrDetalle1;

            StockTransf.CardCode = d_CardCode;
            StockTransf.CardName = d_CardName;

            StockTransf.UsuarioSap = d_usuariosap;
            StockTransf.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Stock_Transfer(StockTransf);

        }

        public static String Transfer_Stock(int d_DocNum, string d_DocDate, string[,] d_arrDetalle, string[,] d_arrDetalle1, string d_CardCode, string d_CardName, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion StockTransf = new cldOrdenFabricacion();

            StockTransf.DocNum = d_DocNum;
            StockTransf.DocDate = d_DocDate;
            //StockTransf.Warehouse = d_WhsCode;
            StockTransf.arrDetalle = d_arrDetalle;
            StockTransf.arrDetalle1 = d_arrDetalle1;

            StockTransf.CardCode = d_CardCode;
            StockTransf.CardName = d_CardName;

            StockTransf.UsuarioSap = d_usuariosap;
            StockTransf.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Transfer_Stock(StockTransf);

        }

        public static String Transfer_Stock_Cerrar(string d_docentry, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion orden_fabricacion = new cldOrdenFabricacion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;
            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Transfer_Stock_Cerrar(orden_fabricacion);
        }

        public static String Ajuste_Merma_Stock(int d_DocNum, string d_DocDate, string[,] d_arrDetalle, string[,] d_arrDetalle1, string d_CardCode, string d_CardName, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion StockTransf = new cldOrdenFabricacion();

            StockTransf.DocNum = d_DocNum;
            StockTransf.DocDate = d_DocDate;
            //StockTransf.Warehouse = d_WhsCode;
            StockTransf.arrDetalle = d_arrDetalle;
            StockTransf.arrDetalle1 = d_arrDetalle1;

            StockTransf.CardCode = d_CardCode;
            StockTransf.CardName = d_CardName;

            StockTransf.UsuarioSap = d_usuariosap;
            StockTransf.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Ajuste_Merma_Stock(StockTransf);

        }

        public static string Entrada_Mercaderia_TR(string d_DocDate, int d_DocEntry, int d_LineNum, double d_CantidadKilos, string d_Warehouse, int d_CantidadBins, string d_CardCode_Productor, string d_CardName_Productor, string d_CardCode_Cliente, string d_CardName_Cliente, double d_PesoUltimaCaja, string d_SalidaProduccion, string d_usuariosap, string d_clavesap, string d_variedad, string d_itemcode_referencia, string d_turno)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.DocDate = d_DocDate;
            termination_report.DocEntry = d_DocEntry;
            termination_report.LineNum = d_LineNum;
            termination_report.Quantity = d_CantidadKilos;
            termination_report.Warehouse = d_Warehouse;
            termination_report.CantidadBins = d_CantidadBins;
            termination_report.CodeProveedor = d_CardCode_Productor;
            termination_report.NombreProveedor = d_CardName_Productor;
            termination_report.CodeCliente = d_CardCode_Cliente;
            termination_report.NombreCliente = d_CardName_Cliente;
            termination_report.PlannedQty = d_PesoUltimaCaja;
            termination_report.SalidaProduccion = d_SalidaProduccion;
            termination_report.Variedad = d_variedad;
            termination_report.ItemCode = d_itemcode_referencia;
            termination_report.Turno = d_turno;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_TR(termination_report);
        }

        public static string Production_CambiaStatus_Lote(int d_Lote, string d_bloqueado, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.Lote = d_Lote;
            termination_report.Bloqueado = d_bloqueado;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_CambiaStatus_Lote(termination_report);
        }

        public static string Production_CambiaStatus_Lote2(int d_Lote, string d_bloqueado, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.Lote = d_Lote;
            termination_report.Bloqueado = d_bloqueado;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_CambiaStatus_Lote2(termination_report);
        }

        public static string Entrada_Mercaderia_TR1(string d_DocDate, int d_DocEntry, int d_LineNum, double d_CantidadKilos, string d_Warehouse, int d_CantidadBins, string d_CardCode_Productor, string d_CardName_Productor, string d_CardCode_Cliente, string d_CardName_Cliente, double d_PesoUltimaCaja, string d_SalidaProduccion, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.DocDate = d_DocDate;
            termination_report.DocEntry = d_DocEntry;
            termination_report.LineNum = d_LineNum;
            termination_report.Quantity = d_CantidadKilos;
            termination_report.Warehouse = d_Warehouse;
            termination_report.CantidadBins = d_CantidadBins;
            termination_report.CodeProveedor = d_CardCode_Productor;
            termination_report.NombreProveedor = d_CardName_Productor;
            termination_report.CodeCliente = d_CardCode_Cliente;
            termination_report.NombreCliente = d_CardName_Cliente;
            termination_report.PlannedQty = d_PesoUltimaCaja;
            termination_report.SalidaProduccion = d_SalidaProduccion;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_TR1(termination_report);
        }

        public static string Entrada_Mercaderia_TR2(int d_lote, int d_CantidadBins, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.Lote = d_lote;
            termination_report.CantidadBins = d_CantidadBins;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_TR2(termination_report);
        }

        public static string Entrada_Mercaderia_TR3(int d_docentry_entradamercancia, int d_docentry_reciboproduccion, string d_referencia, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.DocEntry = d_docentry_entradamercancia;
            termination_report.DocEntryRef = d_docentry_reciboproduccion;
            termination_report.U_Proceso = d_referencia;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_TR3(termination_report);

        }

        public static string Entrada_Mercaderia_Nuevo_Pallet(string d_ItemCode, string d_ItemName, string d_Warehouse, string[,] d_arrDetalle, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion nuevo_Pallet = new cldOrdenFabricacion();

            nuevo_Pallet.ItemCode = d_ItemCode; //, string , string , string[,] d_arrDetalle
            nuevo_Pallet.ItemName = d_ItemName;
            nuevo_Pallet.Warehouse = d_Warehouse;
            nuevo_Pallet.arrDetalle = d_arrDetalle;

            nuevo_Pallet.UsuarioSap = d_usuariosap;
            nuevo_Pallet.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_Nuevo_Pallet(nuevo_Pallet);
        }

        public static string Crea_Nuevo_Pallet(string d_ItemCode, string d_ItemName, string d_Warehouse, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion nuevo_Pallet = new cldOrdenFabricacion();

            nuevo_Pallet.ItemCode = d_ItemCode; //, string , string , string[,] d_arrDetalle
            nuevo_Pallet.ItemName = d_ItemName;
            nuevo_Pallet.Warehouse = d_Warehouse;

            nuevo_Pallet.UsuarioSap = d_usuariosap;
            nuevo_Pallet.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Crea_Nuevo_Pallet(nuevo_Pallet);
        }

        public static string Entrada_Mercaderia_Asigna_Pallet(string d_CodigoNumeroPallet, string[,] d_arrDetalle, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.CodigoNumeroPallet = d_CodigoNumeroPallet;
            termination_report.arrDetalle = d_arrDetalle;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_Asigna_Pallet(termination_report);
        }

        public static string Entrada_Mercaderia_Borra_Pallet(string d_CodigoNumeroPallet, string[,] d_arrDetalle, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.CodigoNumeroPallet = d_CodigoNumeroPallet;
            termination_report.arrDetalle = d_arrDetalle;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Entrada_Mercaderia_Borra_Pallet(termination_report);
        }

        public static string Fumiga_Lote(string[,] d_arrDetalle, string fecha_fumigado, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.arrDetalle = d_arrDetalle;
            termination_report.fecha_proceso = fecha_fumigado;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Fumiga_Lote(termination_report);
        }

        public static string Fumiga_Lote1(string[,] d_arrDetalle, string fecha_fumigado , int d_docentry, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.arrDetalle = d_arrDetalle;
            termination_report.fecha_proceso = fecha_fumigado;
            termination_report.DocEntry = d_docentry;
            termination_report.LineNum = -1;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Fumiga_Lote1(termination_report);

        }

        public static string Fumiga_Lote_En(string[,] d_arrDetalle, string fecha_fumigado, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion termination_report = new cldOrdenFabricacion();

            termination_report.arrDetalle = d_arrDetalle;
            termination_report.fecha_proceso = fecha_fumigado;

            termination_report.UsuarioSap = d_usuariosap;
            termination_report.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Fumiga_Lote_En(termination_report);
        }

        public static string Salida_Mercaderia_CO(string d_DocDate, int d_DocEntry, int d_LineNum, double d_CantidadKilos, string d_Warehouse, int d_CantidadBins, string d_Lote, string d_CardCode_Productor, string d_CardName_Productor, string d_CardCode_Cliente, string d_CardName_Cliente, string d_mensaje, string d_usuariosap, string d_clavesap, string cSalidaProduccion, string d_Codigo_CSG)
        {

            cldOrdenFabricacion parConsumo = new cldOrdenFabricacion();

            parConsumo.DocDate = d_DocDate;
            parConsumo.DocEntry = d_DocEntry;
            parConsumo.LineNum = d_LineNum;
            parConsumo.Quantity = d_CantidadKilos;
            parConsumo.Warehouse = d_Warehouse;
            parConsumo.CantidadBins = d_CantidadBins;
            parConsumo.lote = d_Lote;
            parConsumo.CodeProveedor = d_CardCode_Productor;
            parConsumo.NombreProveedor = d_CardName_Productor;
            parConsumo.CodeCliente = d_CardCode_Cliente;
            parConsumo.NombreCliente = d_CardName_Cliente;
            parConsumo.MensajeC = d_mensaje;

            parConsumo.UsuarioSap = d_usuariosap;
            parConsumo.ClaveSap = d_clavesap;
            parConsumo.SalidaProduccion = cSalidaProduccion;
            parConsumo.Codigo_CSG = d_Codigo_CSG;

            return new cldOrdenFabricacion().Salida_Mercaderia_CO(parConsumo);
        }

        public static string Salida_Mercaderia_CO1(string d_DocDate, int d_DocEntry, int d_LineNum, double d_CantidadKilos, string d_Warehouse, int d_CantidadBins, string d_CardCode_Productor, string d_CardName_Productor, string d_CardCode_Cliente, string d_CardName_Cliente, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion parConsumo = new cldOrdenFabricacion();

            parConsumo.DocDate = d_DocDate;
            parConsumo.DocEntry = d_DocEntry;
            parConsumo.LineNum = d_LineNum;
            parConsumo.Quantity = d_CantidadKilos;
            parConsumo.Warehouse = d_Warehouse;
            parConsumo.CantidadBins = d_CantidadBins;
            parConsumo.CodeProveedor = d_CardCode_Productor;
            parConsumo.NombreProveedor = d_CardName_Productor;
            parConsumo.CodeCliente = d_CardCode_Cliente;
            parConsumo.NombreCliente = d_CardName_Cliente;

            parConsumo.UsuarioSap = d_usuariosap;
            parConsumo.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Salida_Mercaderia_CO1(parConsumo);
        }

        public static String Production_Orders_AgregaItem(string d_docentry, string d_ItemCode, string d_WhsCode, double d_Quantity, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion orden_fabricacion = new cldOrdenFabricacion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);

            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;

            orden_fabricacion.ItemCode = d_ItemCode;
            orden_fabricacion.Warehouse = d_WhsCode;
            orden_fabricacion.Quantity = d_Quantity;

            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_Orders_AgregaItem(orden_fabricacion);
        }

        public static String Production_Orders_ActualizaItem(int d_docentry, int d_LineNum , double d_Quantity, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion orden_fabricacion = new cldOrdenFabricacion();

            orden_fabricacion.DocEntry = d_docentry;
            orden_fabricacion.LineNum = d_LineNum;
            orden_fabricacion.Quantity = d_Quantity;

            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_Orders_ActualizaItem(orden_fabricacion);
        }

        public static String Production_Orders_Cerrar(string d_docentry, string d_usuariosap, string d_clavesap)
        {

            cldOrdenFabricacion orden_fabricacion = new cldOrdenFabricacion();

            orden_fabricacion.DocEntry = int.Parse(d_docentry);
            orden_fabricacion.UserSign = VariablesGlobales.glb_User_id;
            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().Production_Orders_Cerrar(orden_fabricacion);
        }

        public static string CambiaCalibre_Lote(int d_Lote, string d_Calibre, string d_usuariosap, string d_clavesap)
        {
            cldOrdenFabricacion orden_fabricacion = new cldOrdenFabricacion();

            orden_fabricacion.Lote = d_Lote;
            orden_fabricacion.Calibre = d_Calibre; 

            orden_fabricacion.UsuarioSap = d_usuariosap;
            orden_fabricacion.ClaveSap = d_clavesap;

            return new cldOrdenFabricacion().CambiaCalibre_Lote(orden_fabricacion);
        }

        public static string SAPB1_OPRODUCCION7(int d_DocEntry, int d_UserSign, string d_Status, string d_DocDate,  string d_Turno, int d_UsuAutorizador, string d_Area, string d_Comments, string d_Warehouse ,string[,] d_arrDetalle)

        {
            cldOrdenFabricacion parProduccion = new cldOrdenFabricacion();

            parProduccion.DocEntry = d_DocEntry;
            parProduccion.UserSign = d_UserSign;
            parProduccion.Status = d_Status;
            parProduccion.DocDate = d_DocDate;
            parProduccion.Turno = d_Turno;
            parProduccion.User_Autorizador = d_UsuAutorizador;
            parProduccion.Area = d_Area;
            parProduccion.Comments = d_Comments;
            parProduccion.Warehouse = d_Warehouse;
            parProduccion.arrDetalle = d_arrDetalle;

            return new cldOrdenFabricacion().SAPB1_OPRODUCCION7(parProduccion);
        }

        public static string SAPB1_OPRODUCCION7v1(int d_DocEntry, int d_UserSign, string d_Status, string d_DocDate, string d_Turno, int d_UsuAutorizador, string d_Area, string d_Comments, string d_Warehouse, string[,] d_arrDetalle)

        {
            cldOrdenFabricacion parProduccion = new cldOrdenFabricacion();

            parProduccion.DocEntry = d_DocEntry;
            parProduccion.UserSign = d_UserSign;
            parProduccion.Status = d_Status;
            parProduccion.DocDate = d_DocDate;
            parProduccion.Turno = d_Turno;
            parProduccion.User_Autorizador = d_UsuAutorizador;
            parProduccion.Area = d_Area;
            parProduccion.Comments = d_Comments;
            parProduccion.Warehouse = d_Warehouse;
            parProduccion.arrDetalle = d_arrDetalle;

            return new cldOrdenFabricacion().SAPB1_OPRODUCCION7v1(parProduccion);
        }

        public static string SAPB1_OPRODUCCION7v2(int d_DocEntry, int d_UserSign, string d_Status, string d_DocDate, string d_Turno, int d_UsuAutorizador, string d_Area, string d_Comments, string d_Warehouse, string[,] d_arrDetalle, int d_DocEntry_Ref)

        {
            cldOrdenFabricacion parProduccion = new cldOrdenFabricacion();

            parProduccion.DocEntry = d_DocEntry;
            parProduccion.UserSign = d_UserSign;
            parProduccion.Status = d_Status;
            parProduccion.DocDate = d_DocDate;
            parProduccion.Turno = d_Turno;
            parProduccion.User_Autorizador = d_UsuAutorizador;
            parProduccion.Area = d_Area;
            parProduccion.Comments = d_Comments;
            parProduccion.Warehouse = d_Warehouse;
            parProduccion.arrDetalle = d_arrDetalle;
            parProduccion.DocEntryRef = d_DocEntry_Ref; 

            return new cldOrdenFabricacion().SAPB1_OPRODUCCION7v2(parProduccion);
        }

        public static string SAPB1_OTARJA(string d_accion, int d_DocEntry, int d_UserSign, string d_turno, string d_lun, string d_mar, string d_mie, string d_jue, string d_vie)

        {
            cldOrdenFabricacion parProduccion = new cldOrdenFabricacion();

            parProduccion.accion = d_accion;
            parProduccion.DocEntry = d_DocEntry;
            parProduccion.UserSign = d_UserSign;
            parProduccion.Turno = d_turno;
            parProduccion.lun = d_lun;
            parProduccion.mar = d_mar;
            parProduccion.mie = d_mie;
            parProduccion.jue = d_jue;
            parProduccion.vie = d_vie;

            return new cldOrdenFabricacion().SAPB1_OTARJA(parProduccion);
        }


    }
}