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
    public class clsProductos: cldProductos
    {
       //private string _ItemCode;
        public DataTable cResultado;

        public DataTable cls_consultar_Productos(string itemname, int solo_mp, int con_oc, int fruta_propia)
        {
            this.consultar_Productos(itemname, solo_mp, con_oc, fruta_propia);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_Producto_x_codigo(string itemcode)
        {
            this.consultar_Producto_x_codigo(itemcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_Producto_x_codigo_stock(string itemcode, string almacen)
        {
            this.consultar_Producto_x_codigo_stock(itemcode, almacen);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public clsProductos()
        {
            
        }

        public clsProductos(string ItemCode)
        {
            this.ConsultarProducto(ItemCode);
        }

        public DataTable cls_consultar_Productos1(string cItemCode, string cItemName)
        {
            this.consultar_Productos1(cItemCode, cItemName);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_Productos2(int nDocNum)
        {
            this.consultar_Productos2(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_Productos3(int nDocNum)
        {
            this.consultar_Productos3(nDocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


        public DataTable cls_consultar_Productos2(string cItemCode, string cItemName)
        {
            this.consultar_Productos2(cItemCode, cItemName);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_stock_x_codigo_almacen(string cItemCode, string cAlmacen)
        {
            this.Consulta_stock_x_codigo_almacen(cItemCode, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_stock_x_codigo_almacen_y_lote(string cItemCode, string cAlmacen)
        {
            this.Consulta_stock_x_codigo_almacen_y_lote(cItemCode, cAlmacen);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_stock_x_codigo_almacen_y_lote2(string cItemCode, string cAlmacen, string cLote)
        {
            this.Consulta_stock_x_codigo_almacen_y_lote2(cItemCode, cAlmacen, cLote);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_Productos_x_Corregir()
        {
            this.consultar_Productos_x_Corregir();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String Salida_Productos_x_Corregir(string d_fecha_movimiento, string d_ItemCode, string[,] d_arrDetalle, string d_bodega, double d_quantity, string d_usuariosap, string d_clavesap)
        {

            cldProductos Salida_Productos = new cldProductos();

            Salida_Productos.DocDate = d_fecha_movimiento;
            Salida_Productos.ItemCode = d_ItemCode;
            //Salida_Productos.Lote = d_lote;
            Salida_Productos.arrDetalle = d_arrDetalle;
            Salida_Productos.WhsCode = d_bodega;
            Salida_Productos.Quantity = d_quantity;

            Salida_Productos.UsuarioSap = d_usuariosap;
            Salida_Productos.ClaveSap = d_clavesap;

            return new cldProductos().Salida_Productos_x_Corregir(Salida_Productos);
        }

        public static String Revalorizacion_Inventario(string d_fecha_movimiento, string d_ItemCode, string d_usuariosap, string d_clavesap, string d_referencia)
        {

            cldProductos Salida_Productos = new cldProductos();

            Salida_Productos.DocDate = d_fecha_movimiento;
            Salida_Productos.ItemCode = d_ItemCode;
            Salida_Productos.UsuarioSap = d_usuariosap;
            Salida_Productos.ClaveSap = d_clavesap;
            Salida_Productos.Referencia = d_referencia;

            return new cldProductos().Revalorizacion_Inventario(Salida_Productos);
        }

        public static String Salida_Productos_Ajuste_Mermas(string d_fecha_movimiento, string d_ItemCode, string d_lote, string d_bodega, double d_quantity, string d_nota, string d_ocrcode, string d_usuariosap, string d_clavesap, string d_ocrcode2, string d_ocrcode3)
        {

            cldProductos Salida_Productos = new cldProductos();

            Salida_Productos.DocDate = d_fecha_movimiento;
            Salida_Productos.ItemCode = d_ItemCode;
            Salida_Productos.Lote = d_lote;
            Salida_Productos.WhsCode = d_bodega;
            Salida_Productos.Quantity = d_quantity;
            Salida_Productos.Nota = d_nota;
            Salida_Productos.OcrCode = d_ocrcode;
            Salida_Productos.OcrCode2 = d_ocrcode2;
            Salida_Productos.OcrCode3 = d_ocrcode3;

            Salida_Productos.UsuarioSap = d_usuariosap;
            Salida_Productos.ClaveSap = d_clavesap;

            return new cldProductos().Salida_Productos_Ajuste_Mermas(Salida_Productos);
        }

        public static String Entrada_Productos_x_Corregir(string d_fecha_movimiento, string d_ItemCode, string[,] d_arrDetalle, string d_bodega, double d_quantity, string d_usuariosap, string d_clavesap)
        {

            cldProductos Entrada_Productos = new cldProductos();

            Entrada_Productos.DocDate = d_fecha_movimiento;
            Entrada_Productos.ItemCode = d_ItemCode;
            //Entrada_Productos.Lote = d_lote;
            Entrada_Productos.arrDetalle = d_arrDetalle;
            Entrada_Productos.WhsCode = d_bodega;
            Entrada_Productos.Quantity = d_quantity;

            Entrada_Productos.UsuarioSap = d_usuariosap;
            Entrada_Productos.ClaveSap = d_clavesap;

            return new cldProductos().Entrada_Productos_x_Corregir(Entrada_Productos);
        }

        public static String CierraSolicitud_Productos_x_Corregir(int d_docentry, string d_usuariosap, string d_clavesap)
        {

            cldProductos Entrada_Productos = new cldProductos();

            Entrada_Productos.DocEntry = d_docentry;

            Entrada_Productos.UsuarioSap = d_usuariosap;
            Entrada_Productos.ClaveSap = d_clavesap;

            return new cldProductos().CierraSolicitud_Productos_x_Corregir(Entrada_Productos);
        }

        public DataTable cls_consultar_bodega_area(string area)
        {
            this.consultar_bodega_area(area);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consultar_bodega_responsable(string WhsCode)
        {
            this.consultar_bodega_responsable(WhsCode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }



    }

}
