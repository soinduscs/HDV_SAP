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
    public class clsOrdendeCompra : cldOrdendeCompra 
    {
        public DataTable cResultado;

        public DataTable cls_Consultar_Ordenes_de_compra_abiertas(string CardName, string solo_mp, string incluir_servicios, string solo_codigo_csg, string d_codigo_csg)
        {
            this.Consultar_Ordenes_de_compra_abiertas(CardName, solo_mp, incluir_servicios, solo_codigo_csg, d_codigo_csg);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_abiertas_dys(string CardName, string solo_mp, string incluir_servicios)
        {
            this.Consultar_Ordenes_de_compra_abiertas_dys(CardName, solo_mp, incluir_servicios);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_abiertas_dys1(string CardName, string solo_mp, string incluir_servicios, string solo_codigo_csg, string d_codigo_csg)
        {
            this.Consultar_Ordenes_de_compra_abiertas_dys1(CardName, solo_mp, incluir_servicios, solo_codigo_csg, d_codigo_csg);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_abiertas_insumos(string CardName)
        {
            this.Consultar_Ordenes_de_compra_abiertas_insumos(CardName);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_abiertas_bodegaje(string CardName)
        {
            this.Consultar_Ordenes_de_compra_abiertas_bodegaje(CardName);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_x_numero(int NumOC, string ItemCode, int LineNum)
        {
            this.Consultar_Ordenes_de_compra_x_numero(NumOC, ItemCode, LineNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_x_numero_1(int NumOC, string ItemCode, int LineNum)
        {
            this.Consultar_Ordenes_de_compra_x_numero_1(NumOC, ItemCode, LineNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_x_DocNum(int NumOC)
        {
            this.Consultar_Ordenes_de_compra_x_DocNum(NumOC);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_insumos(string fecha1, string fecha2)
        {
            this.Consultar_Ordenes_de_compra_insumos(fecha1 , fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Ordenes_de_compra_bodegaje(string fecha1, string fecha2)
        {
            this.Consultar_Ordenes_de_compra_bodegaje(fecha1, fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_entradas_insumos(string fecha1, string fecha2)
        {
            this.Consultar_entradas_insumos(fecha1, fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_entradas_bodegaje(string fecha1, string fecha2, string cNumOV)
        {
            this.Consultar_entradas_bodegaje(fecha1, fecha2, cNumOV);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_entradas_semielaborados(string fecha1, string fecha2)
        {
            this.Consultar_entradas_semielaborados(fecha1, fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Lote_Max_Insumo()
        {
            this.Consultar_Lote_Max_Insumo();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


    }
}
