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
    public class clsRecepcion : cldRecepcion
    {
        public DataTable cResultado;
        public DataTable cls_Consulta_Ultimo_Lote()
        {
            this.Consulta_Ultimo_Lote();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static string Entrada_Mercaderia(string d_CardCode, string d_CardName, string d_ItemCode, int d_NumGuia, string d_Patente, string d_conductor, string d_FechaIngreso, float d_PesoNeto, string d_Obs, float d_PesoGuia, string d_WareHouse, double d_PrecioxUnidad, int d_PurchaseOrder, int d_BaseLineNum, int d_Lote, int d_CantidadBultos, string d_CodeCliente, string d_NombreCliente, string d_TipoLote, string d_usuariosap, string d_clavesap, string d_variedad, string d_presentacion, string d_prefijo_tipodocumento, string d_Codigo_CSG, string d_TipoCosecha)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.CardCode = d_CardCode;
            recepcion.CardName = d_CardName;
            recepcion.ItemCode = d_ItemCode;
            recepcion.NumGuia = d_NumGuia;
            recepcion.Patente = d_Patente;
            recepcion.conductor = d_conductor;
            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.PesoNeto = d_PesoNeto;
            recepcion.Obs = d_Obs;
            recepcion.PesoGuia = d_PesoGuia;
            recepcion.WareHouse = d_WareHouse;
            recepcion.PrecioxUnidad = d_PrecioxUnidad;
            recepcion.PurchaseOrder = d_PurchaseOrder;
            recepcion.BaseLineNum = d_BaseLineNum;
            recepcion.Lote = d_Lote;
            recepcion.CantidadBultos = d_CantidadBultos;
            //recepcion.NombreProveedor = d_NombreProveedor;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.TipoLote = d_TipoLote;
            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;
            recepcion.CodeCliente = d_CodeCliente;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.Variedad = d_variedad;
            recepcion.Presentacion = d_presentacion;
            recepcion.Prefijo_TipoDocumento = d_prefijo_tipodocumento;
            recepcion.Codigo_CSG = d_Codigo_CSG;
            recepcion.TipoCosecha = d_TipoCosecha;

            return new cldRecepcion().Entrada_Mercaderia(recepcion);
        }

        public static string Entrada_Mercaderia_ActualizaNumGuia(int d_DocEntry, int d_NumGuia, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = d_DocEntry;
            recepcion.NumGuia = d_NumGuia;
            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Entrada_Mercaderia_ActualizaNumGuia(recepcion);
        }

        public static string Devolucion_Mercaderia(string d_CardCode, string d_CardName, string d_ItemCode, int d_NumGuia, string d_Patente, string d_conductor, string d_FechaIngreso, float d_PesoNeto, string d_Obs, float d_PesoGuia, string d_WareHouse, double d_PrecioxUnidad, int d_PurchaseOrder, int d_BaseLineNum, int d_Lote, int d_CantidadBultos, string d_CodeCliente, string d_NombreCliente, string d_TipoLote, string d_usuariosap, string d_clavesap, string d_comments)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.CardCode = d_CardCode;
            recepcion.CardName = d_CardName;
            recepcion.ItemCode = d_ItemCode;
            recepcion.NumGuia = d_NumGuia;
            recepcion.Patente = d_Patente;
            recepcion.conductor = d_conductor;
            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.PesoNeto = d_PesoNeto;
            recepcion.Obs = d_Obs;
            recepcion.PesoGuia = d_PesoGuia;
            recepcion.WareHouse = d_WareHouse;
            recepcion.PrecioxUnidad = d_PrecioxUnidad;
            recepcion.PurchaseOrder = d_PurchaseOrder;
            recepcion.BaseLineNum = d_BaseLineNum;
            recepcion.Lote = d_Lote;
            recepcion.CantidadBultos = d_CantidadBultos;
            //recepcion.NombreProveedor = d_NombreProveedor;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.TipoLote = d_TipoLote;
            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;
            recepcion.CodeCliente = d_CodeCliente;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.Comments = d_comments;

            return new cldRecepcion().Devolucion_Mercaderia(recepcion);
        }

        public static string Devolucion_Mercaderia_Cerrar(string d_docentry, string d_usuariosap, string d_clavesap)
        {

            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = int.Parse(d_docentry);
            recepcion.UserSign = VariablesGlobales.glb_User_id;
            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Devolucion_Mercaderia_Cerrar(recepcion);
        }


        public static string Entrada_Mercaderia_Insumos(string d_CardCode, string d_CardName, string d_ItemCode, int d_NumGuia, string d_FechaIngreso, string d_Obs, string d_WareHouse, int d_PurchaseOrder, int d_BaseLineNum, int d_CantidadBultos, string d_CodeCliente, string d_NombreCliente, string d_TipoLote, string[,] d_arrDetalle, string[,] d_arrDetalle1, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.CardCode = d_CardCode;
            recepcion.CardName = d_CardName;
            recepcion.ItemCode = d_ItemCode;
            recepcion.NumGuia = d_NumGuia;
            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.Obs = d_Obs;
            recepcion.WareHouse = d_WareHouse;
            recepcion.PurchaseOrder = d_PurchaseOrder;
            recepcion.BaseLineNum = d_BaseLineNum;
            recepcion.CantidadBultos = d_CantidadBultos;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.TipoLote = d_TipoLote;
            recepcion.CodeCliente = d_CodeCliente;
            recepcion.NombreCliente = d_NombreCliente;

            recepcion.arrDetalle = d_arrDetalle;
            recepcion.arrDetalle1 = d_arrDetalle1;

            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Entrada_Mercaderia_Insumos(recepcion);
        }

        public static string Entrada_Mercaderia_Bodegaje(string d_CardCode, string d_CardName, string d_ItemCode, int d_NumGuia, string d_FechaIngreso, string d_Obs, string d_WareHouse, int d_PurchaseOrder, int d_BaseLineNum, int d_CantidadBultos, string d_CodeCliente, string d_NombreCliente, string d_TipoLote, string[,] d_arrDetalle, string[,] d_arrDetalle1, string d_num_ov, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.CardCode = d_CardCode;
            recepcion.CardName = d_CardName;
            recepcion.ItemCode = d_ItemCode;
            recepcion.NumGuia = d_NumGuia;
            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.Obs = d_Obs;
            recepcion.WareHouse = d_WareHouse;
            recepcion.PurchaseOrder = d_PurchaseOrder;
            recepcion.BaseLineNum = d_BaseLineNum;
            recepcion.CantidadBultos = d_CantidadBultos;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.TipoLote = d_TipoLote;
            recepcion.CodeCliente = d_CodeCliente;
            recepcion.NombreCliente = d_NombreCliente;
            recepcion.Num_OrdenVenta = d_num_ov;

            recepcion.arrDetalle = d_arrDetalle;
            recepcion.arrDetalle1 = d_arrDetalle1;

            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Entrada_Mercaderia_Bodegaje(recepcion);
        }

        public static String Stock_Transfer(string d_CardCode, string d_Patente, string d_conductor, string d_FechaIngreso, string[,] d_arrDetalleBins, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.CardCode = d_CardCode;
            recepcion.Patente = d_Patente;
            recepcion.conductor = d_conductor;
            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.arrDetalleBins = d_arrDetalleBins;
            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Stock_Transfer(recepcion);
        }

        public static String SAPB1_Recepcion(int d_DocEntry, int d_IdRomana, int d_UserSign, string d_localidad)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = d_DocEntry;
            recepcion.IdRomana = d_IdRomana;
            recepcion.UserSign = d_UserSign;
            recepcion.Localidad = d_localidad;

            return new cldRecepcion().SAPB1_Recepcion(recepcion);
        }

        public static String SAPB1_Recepcion1(int d_DocEntry, int d_LineId, string d_CardCode, string d_CardName, string d_ItemCode, string d_ItemName, float d_Cantidad, int d_BaseLine, string d_WhsCode, string d_CardCodeClte, string d_CardNameClte)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = d_DocEntry;
            recepcion.LineId = d_LineId;
            recepcion.CardCode = d_CardCode;
            recepcion.CardName = d_CardName;
            recepcion.ItemCode = d_ItemCode;
            recepcion.ItemName = d_ItemName;
            recepcion.Cantidad = d_Cantidad;
            recepcion.BaseLine = d_BaseLine;
            recepcion.WhsCode = d_WhsCode;
            recepcion.CodeCliente = d_CardCodeClte;  
            recepcion.NombreCliente = d_CardNameClte;

            return new cldRecepcion().SAPB1_Recepcion1(recepcion);
        }

        public static String SAPB1_Recepcion2(int d_DocEntry, int d_LineId, float d_Cantidad, int d_BaseLine, string d_ObjectRef,int d_CantidadVacios)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = d_DocEntry;
            recepcion.LineId = d_LineId;
            recepcion.Cantidad = d_Cantidad;
            recepcion.BaseLine = d_BaseLine;
            recepcion.ObjectRef = d_ObjectRef;
            recepcion.CantidadVacios = d_CantidadVacios;

            return new cldRecepcion().SAPB1_Recepcion2(recepcion);
        }

        public static String SAPB1_Recepcion9(int d_IdRomana, int d_DocEntry, int d_UserSign)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.IdRomana = d_IdRomana;
            recepcion.DocEntry = d_DocEntry;
            recepcion.UserSign = d_UserSign;

            return new cldRecepcion().SAPB1_RECEPCION9(recepcion);
        }

        public DataTable cls_Consulta_Max_EntradaMercaderia(string cCardCode, int nMes, int nAnho)
        {
            this.Consulta_Max_EntradaMercaderia(cCardCode, nMes, nAnho);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Max_RecepcionMP()
        {
            this.Consulta_Max_RecepcionMP();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_EntradaMercaderia_x_DocEntry(int nDocEntry)
        {
            this.Consulta_EntradaMercaderia_x_DocEntry(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_max_devolucion()
        {
            this.Consulta_max_devolucion();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(int nDocEntry, int nDocEntry_t)
        {
            this.Consulta_EntradaMercaderia_x_DocEntry_en_Detalle(nDocEntry, nDocEntry_t);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_RECEPCION3(int d_DocEntry, int d_DocType)
        {
            cldRecepcion recepcion = new cldRecepcion();

            recepcion.DocEntry = d_DocEntry;
            recepcion.DocType = d_DocType;

            return new cldRecepcion().SAPB1_RECEPCION3(recepcion);
        }

        public DataTable cls_Consulta_Pesos_x_Guia(int nDocEntry)
        {
            this.Consulta_Pesos_x_Guia(nDocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Pesos_x_Guia_Detalle(int nDocEntry, int nLineId)
        {
            this.Consulta_Pesos_x_Guia_Detalle(nDocEntry, nLineId);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static string CambiaStatus_Lote(int d_Lote, int d_Accion, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion parLote = new cldRecepcion();

            parLote.Lote = d_Lote;
            parLote.Accion = d_Accion; //1=bloquea - 0=liberado

            parLote.UsuarioSap = d_usuariosap;
            parLote.ClaveSap = d_clavesap;

            return new cldRecepcion().CambiaStatus_Lote(parLote);
        }

        public static String Stock_Transfer_Ubicaciones(string d_FechaIngreso, string d_ItemCode, int d_Lote, float d_Quantity, string d_FromWhsCode , string d_ToWhsCode, int d_BinAbsEntry, int d_DocEntry_ref, int d_LineNum_ref , string d_usuariosap, string d_clavesap)
        {

            cldRecepcion recepcion = new cldRecepcion();

            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.ItemCode = d_ItemCode;
            recepcion.Lote = d_Lote;
            recepcion.Cantidad = d_Quantity;
            recepcion.FromWhsCode = d_FromWhsCode;
            recepcion.ToWhsCode = d_ToWhsCode;
            recepcion.BinAbsEntry = d_BinAbsEntry;

            recepcion.DocEntry_Ref = d_DocEntry_ref; 
            recepcion.LineNum_Ref = d_LineNum_ref;

            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Stock_Transfer_Ubicaciones(recepcion);


        }

        public static String Stock_Transfer_Ubicaciones_v2(string d_FechaIngreso, string d_ItemCode, int d_Lote, float d_Quantity, string d_FromWhsCode, string d_ToWhsCode, int d_BinAbsEntry, int d_DocEntry_ref, int d_LineNum_ref, string d_usuariosap, string d_clavesap)
        {

            cldRecepcion recepcion = new cldRecepcion();

            recepcion.FechaIngreso = d_FechaIngreso;
            recepcion.ItemCode = d_ItemCode;
            recepcion.Lote = d_Lote;
            recepcion.Cantidad = d_Quantity;
            recepcion.FromWhsCode = d_FromWhsCode;
            recepcion.ToWhsCode = d_ToWhsCode;
            recepcion.BinAbsEntry = d_BinAbsEntry;

            recepcion.DocEntry_Ref = d_DocEntry_ref;
            recepcion.LineNum_Ref = d_LineNum_ref;

            recepcion.UsuarioSap = d_usuariosap;
            recepcion.ClaveSap = d_clavesap;

            return new cldRecepcion().Stock_Transfer_Ubicaciones_v2(recepcion);

        }

        public static String Sales_Order_Lotes(int d_docentry, int d_lineid, int d_lote, float d_quantity, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion oOrdenVenta = new cldRecepcion();

            oOrdenVenta.DocEntry = d_docentry;
            oOrdenVenta.LineId = d_lineid;
            oOrdenVenta.Lote = d_lote;
            oOrdenVenta.Cantidad = d_quantity;

            oOrdenVenta.UsuarioSap = d_usuariosap;
            oOrdenVenta.ClaveSap = d_clavesap;

            return new cldRecepcion().Sales_Order_Lotes(oOrdenVenta);
        }

        public static String Sales_Order_New_Picking(string d_FechaIngreso, string d_usuariosap, string d_clavesap)
        {
            cldRecepcion oOrdenVenta = new cldRecepcion();

            oOrdenVenta.FechaIngreso = d_FechaIngreso;

            oOrdenVenta.UsuarioSap = d_usuariosap;
            oOrdenVenta.ClaveSap = d_clavesap;

            return new cldRecepcion().Sales_Order_New_Picking(oOrdenVenta);
        }


    }

}
