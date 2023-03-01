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
    public class clsCalidad: cldCalidad 
    {
        public DataTable cResultado;

        public static String SAPB1_OATRP(string d_ItemCode, string d_ItemName, string d_Muestra, double d_CantMuestra, string d_Destructiva, double d_CantDestructiva, string d_Comments, string d_UserCode, int d_UserId)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.ItemCode = d_ItemCode;
            atributo.ItemName = d_ItemName;
            atributo.Muestra = d_Muestra;
            atributo.CantMuestra = d_CantMuestra;
            atributo.Destructiva = d_Destructiva;
            atributo.CantDestructiva = d_CantDestructiva;
            atributo.Comments = d_Comments;
            atributo.UserCode = d_UserCode;
            atributo.UserId = d_UserId;
            
            return new cldCalidad().SAPB1_OATRP(atributo);
        }

        public static String SAPB1_ATRP1(string d_ItemCode, string d_CodeAtr, string d_NameAtr, double d_Standard, double d_Minimo, double d_Maximo, string d_Comments)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.ItemCode = d_ItemCode;
            atributo.CodeAtr = d_CodeAtr;
            atributo.NameAtr = d_NameAtr;
            atributo.Standard = d_Standard;
            atributo.Minimo = d_Minimo;
            atributo.Maximo = d_Maximo;
            atributo.Comments = d_Comments;

            return new cldCalidad().SAPB1_ATRP1(atributo);
        }

        public static String SAPB1_ATRP2(string d_ItemCode, string d_CodeAtr, string d_NameAtr, double d_Standard, double d_Minimo, double d_Maximo)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.ItemCode = d_ItemCode;
            atributo.CodeAtr = d_CodeAtr;
            atributo.NameAtr = d_NameAtr;
            atributo.Standard = d_Standard;
            atributo.Minimo = d_Minimo;
            atributo.Maximo = d_Maximo;
            atributo.UserId = VariablesGlobales.glb_User_id;

            return new cldCalidad().SAPB1_ATRP2(atributo);
        }

        public static String SAPB1_ATRP3(string d_Code, string d_Variedad, string d_Calibre, string d_CodeAtr, double d_Minimo, double d_Maximo, string d_Locked)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_Code;
            atributo.Variedad = d_Variedad;
            atributo.CalibreNuez = d_Calibre;
            atributo.CodeAtr = d_CodeAtr;
            atributo.Minimo = d_Minimo;
            atributo.Maximo = d_Maximo;
            atributo.Locked = d_Locked;
            atributo.UserId = VariablesGlobales.glb_User_id;

            return new cldCalidad().SAPB1_ATRP3(atributo);
        }

        public static String SAPB1_ATRP4(string d_Code, string d_Variedad, string d_Calibre, string d_Comment, double d_Maximo)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_Code;
            atributo.Variedad = d_Variedad;
            atributo.CalibreNuez = d_Calibre;
            atributo.Comments = d_Comment;
            atributo.Maximo = d_Maximo;
            atributo.UserId = VariablesGlobales.glb_User_id;

            return new cldCalidad().SAPB1_ATRP4(atributo);
        }

        public static String SAPB1_ATRP8(string d_code, string d_CodeAtr, string d_NameAtr)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_code;
            atributo.CodeAtr = d_CodeAtr;
            atributo.NameAtr = d_NameAtr;

            return new cldCalidad().SAPB1_ATRP8(atributo);
        }

        public static String SAPB1_Actualiza_ATRP1(string d_CodeAtr, string d_tipo_valor, string d_tipo_porcentaje, string d_um , double d_standard, string d_namatr)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.Code = d_tipo_valor;
            atributo.AtrT1 = d_tipo_porcentaje;
            atributo.UM = d_um;
            atributo.Standard = d_standard;
            atributo.NameAtr = d_namatr;

            return new cldCalidad().Actualiza_ATRP1(atributo);
        }

        public static String SAPB1_Actualiza_ATRP1_x(string d_CodeAtr, double d_minimo, double d_maximo)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.Minimo = d_minimo;
            atributo.Maximo = d_maximo;

            return new cldCalidad().Actualiza_ATRP1_x(atributo);
        }

        public static String SAPB1_Actualiza_ATRP1_y(string d_CodeAtr, double d_ubicacion)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.Minimo = d_ubicacion;

            return new cldCalidad().Actualiza_ATRP1_y(atributo);
        }

        public static String SAPB1_Actualiza_ATRP1_z(string d_CodeAtr, string d_formula, int d_valor)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;

            atributo.Accion = d_formula;
            atributo.Minimo = d_valor;

            return new cldCalidad().Actualiza_ATRP1_z(atributo);
        }

        public static String SAPB1_Actualiza_ATRP3(string d_CodeAtr, int d_docentry,  double d_minimo, double d_maximo, string d_locked)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.DocEntry = d_docentry;
            atributo.Minimo = d_minimo;
            atributo.Maximo = d_maximo;
            atributo.Locked = d_locked;

            return new cldCalidad().Actualiza_ATRP3(atributo);
        }

        public static String SAPB1_Agregar_Atributo_ATRP1(string d_CodeAtr, string d_CodeAtrD, string d_NameAtr, int d_LineId)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.CodeAtrD = d_CodeAtrD;
            atributo.NameAtr = d_NameAtr;
            atributo.LineId = d_LineId;

            return new cldCalidad().Agregar_Atributo_ATRP1(atributo);
        }

        public static String SAPB1_Agregar_OCERNV(string d_code, string d_docnum, string d_itemcode)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_code;
            atributo.DocNum = Convert.ToInt32(d_docnum);
            atributo.ItemCode = d_itemcode;
            atributo.UserId = VariablesGlobales.glb_User_id;

            return new cldCalidad().Agregar_OCERNV(atributo);
        }

        public static String SAPB1_Actualizar_OCERNV(string d_code, string d_docnum, string d_itemcode, string d_g3v1, string d_g3v2, string d_g3v3, string d_g4v1, string d_g4v2, string d_g4v3, string d_g4v4, string d_g4v5, string d_g4v6, string d_g4v7, string d_g4v8, string d_g4v9, string d_g4v10, string d_g4v11, string d_g4v12, string d_g4v13, string d_g5v1, string d_g5v2, string d_g5v3, string d_g5v4, string d_g5v5)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_code;
            atributo.DocNum = Convert.ToInt32(d_docnum);
            atributo.UserId = VariablesGlobales.glb_User_id;
            atributo.ItemCode = d_itemcode;

            atributo.G3V1 = d_g3v1;
            atributo.G3V2 = d_g3v2;
            atributo.G3V3 = d_g3v3;

            atributo.G4V1 = d_g4v1;
            atributo.G4V2 = d_g4v2;
            atributo.G4V3 = d_g4v3;
            atributo.G4V4 = d_g4v4;
            atributo.G4V5 = d_g4v5;
            atributo.G4V6 = d_g4v6;
            atributo.G4V7 = d_g4v7;
            atributo.G4V8 = d_g4v8;
            atributo.G4V9 = d_g4v9;
            atributo.G4V10 = d_g4v10;
            atributo.G4V11 = d_g4v11;
            atributo.G4V12 = d_g4v12;
            atributo.G4V13 = d_g4v13;

            atributo.G5V1 = d_g5v1;
            atributo.G5V2 = d_g5v2;
            atributo.G5V3 = d_g5v3;
            atributo.G5V4 = d_g5v4;
            atributo.G5V5 = d_g5v5;

            return new cldCalidad().Actualizar_OCERNV(atributo);

        }

        public static String SAPB1_Eliminar_Atributo_ATRP1(string d_CodeAtr)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;

            return new cldCalidad().Eliminar_Atributo_ATRP1(atributo);
        }

        public static String Sapb1_utiles_matriz_new(int d_docentry, string d_NameAtr, string d_accion)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_docentry;
            atributo.NameAtr = d_NameAtr;
            atributo.Code = d_accion;

            return new cldCalidad().Sapb1_utiles_matriz_new(atributo);
        }

        public static String SAPB1_Agregar_Atributo_ATRP3(string d_CodeAtr, string d_CodeAtrD, string d_NameAtr, int d_LineId)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;
            atributo.CodeAtrD = d_CodeAtrD;
            atributo.NameAtr = d_NameAtr;
            atributo.LineId = d_LineId;

            return new cldCalidad().Agregar_Atributo_ATRP3(atributo);
        }

        public static String SAPB1_Eliminar_Atributo_ATRP3(string d_CodeAtr)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodeAtr;

            return new cldCalidad().Eliminar_Atributo_ATRP3(atributo);
        }

        public static String SAPB1_ATRP8e(string d_code, string d_CodeAtr, string d_NameAtr)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Code = d_code;
            atributo.CodeAtr = d_CodeAtr;
            atributo.NameAtr = d_NameAtr;

            return new cldCalidad().SAPB1_ATRP8e(atributo);
        }

        public static String SAPB1_ORCAL(int d_DocNum, string d_Accion, int d_UserId , string d_UserCode, string d_ItemCode, string d_ItemName, string d_WhsCode, string d_WhsDest , string d_NumCon, 
            string d_Lote , double d_Cantidad , double d_Bultos, double d_BultosMu , string d_FecIngr , string d_UM, double d_CoMuSize , double d_MuDeSize, string d_Comment, string d_Object_Ref , 
            int d_DocEntry_Ref, int d_LineId_Ref, string d_calibre_nuez, string d_color_nuez, int d_tipoanalisis, string d_tipo_proceso, string d_disponible, string d_U_AtrT1, string d_U_AtrT2)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;
            atributo.Accion = d_Accion;
            atributo.UserId = d_UserId;
            atributo.UserCode = d_UserCode;
            atributo.ItemCode = d_ItemCode;
            atributo.ItemName = d_ItemName;
            atributo.WhsCode = d_WhsCode;
            atributo.WhsDest = d_WhsDest;
            atributo.NumCon = d_NumCon;
            atributo.Lote = d_Lote;
            atributo.Cantidad = d_Cantidad;
            atributo.Bultos = d_Bultos;
            atributo.BultosMu = d_BultosMu;
            atributo.FechaIngreso = d_FecIngr;
            atributo.UM = d_UM;
            atributo.CantMuestra = d_CoMuSize;
            atributo.CantDestructiva = d_MuDeSize;
            atributo.Comments = d_Comment;
            atributo.Object_Ref = d_Object_Ref;
            atributo.DocEntry_Ref = d_DocEntry_Ref;
            atributo.LineId_Ref = d_LineId_Ref;
            atributo.CalibreNuez = d_calibre_nuez;
            atributo.ColorNuez = d_color_nuez;
            atributo.DocOrig = d_tipoanalisis;
            atributo.TipoProceso = d_tipo_proceso;
            atributo.Disponible = d_disponible;
            atributo.AtrT1 = d_U_AtrT1;
            atributo.AtrT2 = d_U_AtrT2;

            return new cldCalidad().SAPB1_ORCAL(atributo);

        }

        public static String SAPB1_OPRM(int d_UserId, string d_WhsCode)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.UserId = d_UserId;
            atributo.WhsCode = d_WhsCode;

            return new cldCalidad().SAPB1_OPRM(atributo);

        }

        public static String SAPB1_OFUM(int d_DocNum, string d_Accion, string d_fecha_fumigado, int d_UserId, string d_UserCode, string d_ItemCode, string d_tipofumigacion)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;
            atributo.Accion = d_Accion;
            atributo.FechaIngreso = d_fecha_fumigado;
            atributo.ItemCode = d_ItemCode;
            atributo.Estado = d_tipofumigacion;

            atributo.UserId = d_UserId;
            atributo.UserCode = d_UserCode;

            return new cldCalidad().SAPB1_OFUM(atributo);

        }

        public static String SAPB1_ORCALA2(int d_docentry_old, int d_docentry_new)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_docentry_old;
            atributo.DocEntryRef = d_docentry_new;

            return new cldCalidad().SAPB1_ORCALA2(atributo);

        }
        public static String SAPB1_OPR1(int d_DocEntry, string d_Accion, int d_Semana, int d_Anho, string d_Area, string d_Turno, string d_Operador)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.Accion = d_Accion;  
            atributo.Semana = d_Semana;
            atributo.Anho = d_Anho;
            atributo.Area = d_Area;
            atributo.Turno = d_Turno;
            atributo.Operador = d_Operador;

            return new cldCalidad().SAPB1_OPR1(atributo);

        }

        public static String SAPB1_ORCALv1(int d_DocNum, string d_Accion, int d_UserId)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;
            atributo.Accion = d_Accion;
            atributo.UserId = d_UserId;

            return new cldCalidad().SAPB1_ORCALv1(atributo);
        }

        public static String SAPB1_ROMANAv1(string d_Accion, int d_DocNum )
        {
            cldCalidad atributo = new cldCalidad();

            atributo.Accion = d_Accion;
            atributo.DocNum = d_DocNum;

            return new cldCalidad().SAPB1_ROMANAv1(atributo);
        }

        public static String SAPB1_ORCAL9(int d_DocNum)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;

            return new cldCalidad().SAPB1_ORCAL9(atributo);
        }

        public static String SAPB1_ORCAL9v1(int d_DocNum)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;

            return new cldCalidad().SAPB1_ORCAL9v1(atributo);
        }

        public static String SAPB1_RCAL1(int d_DocEntry , int d_LinId , string d_CodeAtr, string d_NameAtr, double d_Standard , double d_Minimo, double d_Maximo, double d_Medicion, 
            string d_Comments, string d_Comments2 , string d_Estado, double d_Porcentaje)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.LineId = d_LinId;
            atributo.CodeAtr = d_CodeAtr;
            atributo.NameAtr = d_NameAtr;
            atributo.Standard = d_Standard;
            atributo.Minimo = d_Minimo;
            atributo.Maximo = d_Maximo;
            atributo.Medicion = d_Medicion;
            atributo.Comments = d_Comments;
            atributo.Comments2 = d_Comments2;
            atributo.Estado = d_Estado;
            atributo.Porcentaje = d_Porcentaje;

            return new cldCalidad().SAPB1_RCAL1(atributo);
        }

        public static String SAPB1_ORCAL_II(int d_DocNum, string d_Accion, int d_UserId, string d_UserCode, string d_ItemCode, string d_ItemName, string d_WhsCode, string d_WhsDest, string d_NumCon, string d_Lote, double d_Cantidad, double d_Bultos, double d_BultosMu, string d_FecIngr, string d_UM, double d_CoMuSize, double d_MuDeSize, string d_Comment, string d_Object_Ref, int d_DocEntry_Ref, int d_LineId_Ref)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocNum = d_DocNum;
            atributo.Accion = d_Accion;
            atributo.UserId = d_UserId;
            atributo.UserCode = d_UserCode;
            atributo.ItemCode = d_ItemCode;
            atributo.ItemName = d_ItemName;
            atributo.WhsCode = d_WhsCode;
            atributo.WhsDest = d_WhsDest;
            atributo.NumCon = d_NumCon;
            atributo.Lote = d_Lote;
            atributo.Cantidad = d_Cantidad;
            atributo.Bultos = d_Bultos;
            atributo.BultosMu = d_BultosMu;
            atributo.FechaIngreso = d_FecIngr;
            atributo.UM = d_UM;
            atributo.CantMuestra = d_CoMuSize;
            atributo.CantDestructiva = d_MuDeSize;
            atributo.Comments = d_Comment;
            atributo.Object_Ref = d_Object_Ref;
            atributo.DocEntry_Ref = d_DocEntry_Ref;
            atributo.LineId_Ref = d_LineId_Ref;

            return new cldCalidad().SAPB1_ORCAL_II(atributo);

        }

        public static String U_Eliminar_Linea_ATRP5(string d_CodAtr, string d_CodAtrD, string d_DocEntry_Ref)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodAtr;
            atributo.CodeAtrD = d_CodAtrD;
            atributo.Code = d_DocEntry_Ref;

            return new cldCalidad().Eliminar_Linea_ATRP5(atributo);

        }

        public static String U_Eliminar_Linea_ATRP9(string d_CodAtr, string d_CodAtrD, string d_DocEntry_Ref)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodAtr;
            atributo.CodeAtrD = d_CodAtrD;
            atributo.Code = d_DocEntry_Ref;

            return new cldCalidad().Eliminar_Linea_ATRP9(atributo);

        }

        public static String U_Eliminar_Linea_ATRPA0(string d_CodAtr, int d_Id)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.CodeAtr = d_CodAtr;
            atributo.LineId = d_Id;

            return new cldCalidad().Eliminar_Linea_ATRPA0(atributo);

        }

        public static String U_Agregar_Linea_ATRP5(int d_DocEntry, string d_CodAtr, string d_CodAtrD, string d_DocEntry_Ref)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.CodeAtr = d_CodAtr;
            atributo.CodeAtrD = d_CodAtrD;
            atributo.Code = d_DocEntry_Ref;

            return new cldCalidad().Agregar_Linea_ATRP5(atributo);

        }

        public static String U_Actualiza_Linea_ATRP5(int d_DocEntry, string d_accion)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.Code = d_accion;

            return new cldCalidad().Actualiza_Linea_ATRP5(atributo);

        }

        public static String U_Actualiza_Linea_ATRP9(int d_DocEntry, string d_accion)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.Code = d_accion;

            return new cldCalidad().Actualiza_Linea_ATRP9(atributo);

        }

        public static String U_Agregar_Linea_ATRP9(int d_DocEntry, string d_CodAtr, string d_CodAtrD, string d_DocEntry_Ref)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.CodeAtr = d_CodAtr;
            atributo.CodeAtrD = d_CodAtrD;
            atributo.Code = d_DocEntry_Ref;

            return new cldCalidad().Agregar_Linea_ATRP9(atributo);

        }

        public static String U_Agregar_Linea_ATRPA0(int d_DocEntry, string d_CodAtr, int d_Line, string d_NameAtr)
        {

            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;
            atributo.CodeAtr = d_CodAtr;
            atributo.LineId = d_Line;
            atributo.NameAtr = d_NameAtr;

            return new cldCalidad().Agregar_Linea_ATRPA0(atributo);

        }

        public DataTable U_Actualiza_Linea_OrdenVenta_Calidad(int DocEntry, int LineNum, string usuario)
        {
            this.Actualiza_Linea_OrdenVenta_Calidad(DocEntry, LineNum, usuario);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_ORCAL_III(int d_DocEntry)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.DocEntry = d_DocEntry;

            return new cldCalidad().SAPB1_ORCAL_III(atributo);
        }

        public DataTable cls_Consulta_Guias_Calidad(string accion, string dato1, string dato2)
        {
            this.Consulta_Guias_Calidad(accion, dato1, dato2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Registros_Inspeccion(string accion, string dato1, string dato2)
        {
            this.Consulta_Registros_Inspeccion(accion, dato1, dato2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Atributos_en_Blanco(string tipo_producto)
        {
            this.Consulta_Atributos_en_Blanco(tipo_producto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Atributos_por_producto(string itemcode, string atributo_like)
        {
            this.Consulta_Atributos_por_producto(itemcode, atributo_like);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_romana9(string lote, int id_romana)
        {
            this.Consulta_romana9(lote, id_romana);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Atributos_de_Humedad(int id_Romana_Entry, int id_Romana_Id)
        {
            this.Consulta_Atributos_de_Humedad(id_Romana_Entry, id_Romana_Id);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Registro_Inspeccion(int DocEntry)
        {
            this.Consulta_Registro_Inspeccion(DocEntry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Registro_Inspeccion_x_orden(int DocNum)
        {
            this.Consulta_Registro_Inspeccion_x_orden(DocNum);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Nuevo_Registro_Inspeccion()
        {
            this.Consulta_Nuevo_Registro_Inspeccion();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Nuevo_Registro_OFUM()
        {
            this.Consulta_Nuevo_Registro_OFUM();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recepcion_MP_Calidad(string accion, string dato1, string dato2, string anhoactual)
        {
            this.Consulta_Recepcion_MP_Calidad(accion, dato1, dato2, anhoactual);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recepcion_MP_Calidad_Secado(string accion, string dato1, string dato2)
        {
            this.Consulta_Recepcion_MP_Calidad_Secado(accion, dato1, dato2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recepcion_MP_Calidad_Secado_dys(string accion, string dato1, string dato2)
        {
            this.Consulta_Recepcion_MP_Calidad_Secado_dys(accion, dato1, dato2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Partidas_dys_humedad(string d_accion , string d_dato1)
        {
            this.Consulta_Partidas_dys_humedad(d_accion, d_dato1);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recepcion_PP_Calidad(string accion, string proceso , string dato1, string dato2, string anhoactual)
        {
            this.Consulta_Recepcion_PP_Calidad(accion, proceso , dato1, dato2, anhoactual);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_consulta_utiles_resumen_Calibres(string d_accion, string d_fecha1, string d_fecha2)
        {
            this.consulta_utiles_resumen_Calibres(d_accion, d_fecha1, d_fecha2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Recepcion_PP_Calidad_V(string accion, string dato1)
        {
            this.Consulta_Recepcion_PP_Calidad_V(accion, dato1);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_OCERNV(string d_docnum, string d_itemcode)
        {
            this.Consulta_OCERNV(d_docnum, d_itemcode);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_max_OCERNV()
        {
            this.Consulta_max_OCERNV();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Sapb1_query_vistacalidad_ncc(int num_ov)
        {
            this.Sapb1_query_vistacalidad_ncc(num_ov);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_PT(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {
            this.SAPB1_INF_TRAZABILIDAD_PT(lote, accion, tipo_fruta, ciclo_estricto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_PT_CSG(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {
            this.SAPB1_INF_TRAZABILIDAD_PT_CSG(lote, accion, tipo_fruta, ciclo_estricto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_MP(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {
            this.SAPB1_INF_TRAZABILIDAD_MP(lote, accion, tipo_fruta, ciclo_estricto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_MP_CSG(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {
            this.SAPB1_INF_TRAZABILIDAD_MP_CSG(lote, accion, tipo_fruta, ciclo_estricto);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_INS(string lote, string accion)
        {
            this.SAPB1_INF_TRAZABILIDAD_INS(lote, accion);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_SAPB1_INF_TRAZABILIDAD_INS_CSG(string lote, string accion)
        {
            this.SAPB1_INF_TRAZABILIDAD_INS_CSG(lote, accion);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_historial_fumigacion(string lote)
        {
            this.Consulta_historial_fumigacion(lote);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consulta_Recepcion_PP_Calidad_R(string accion, string proceso, string dato1, string dato2)
        {
            this.Consulta_Recepcion_PP_Calidad_R(accion, proceso, dato1, dato2);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Reg_Auditoria_Registros_Inspeccion(int DocEntry, string d_Lote)
        {
            this.Consulta_Reg_Auditoria_Registros_Inspeccion(DocEntry, d_Lote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Analisis_x_Cliente(string CardCode)
        {
            this.Consulta_Analisis_x_Cliente(CardCode);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_utiles_resumendespelonado(string CardCode, string accion, int anho)
        {
            this.xSapb1_utiles_resumendespelonado(CardCode, accion, anho);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Avance_x_id(int id_docentry, int nLineId, string cLote, string c_objtype)
        {
            this.Consulta_Avance_x_id(id_docentry, nLineId, cLote, c_objtype);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_max_ATRP8()
        {
            this.Consulta_max_ATRP8();
            this.cResultado = this.Resultado;
            return this.cResultado;
        }


        public static String U_Actualiza_Bins_Produccion(string d_ItemCode, string d_accion)
        {
            cldCalidad atributo = new cldCalidad();

            atributo.ItemCode = d_ItemCode;
            atributo.Object_Ref = d_accion;

            return new cldCalidad().Actualiza_Bins_Produccion(atributo);

        }


        public DataTable cls_Consulta_Registro_Referencia_PT_Seco(int id_docentry)
        {
            this.Consulta_Registro_Referencia_PT_Seco(id_docentry);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }
        
        public DataTable cls_SAPB1_ORCAL8(int id_docentry, string cLote, string codatr, double medicion)
        {
            this.SAPB1_ORCAL8(id_docentry, cLote, codatr, medicion);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_SAPB1_ORCALA1(int id_docentry, int id_tipoanalisis)
        {
            this.SAPB1_ORCALA1(id_docentry, id_tipoanalisis);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Consumo_x_id(int id_docentry, int nLineId, string cLote)
        {
            this.Consulta_Consumo_x_id(id_docentry, nLineId, cLote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Datos_Entrada_x_id(int id_docentry, string d_object, string d_lote)
        {
            this.Consulta_Datos_Entrada_x_id(id_docentry, d_object, d_lote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_SAPB1_RECEPCION5(int id_docentry, int id_docentry_t)
        {
            this.SAPB1_RECEPCION5(id_docentry, id_docentry_t);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Atributos_PP_producto(string U_Proceso)
        {
            this.Consulta_Atributos_PP_producto(U_Proceso);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Atributos_PP_producto_V2(string U_Proceso, string U_Variedad, string U_Calibre, string U_Variedad_Fruta)
        {
            this.Consulta_Atributos_PP_producto_V2(U_Proceso, U_Variedad, U_Calibre, U_Variedad_Fruta);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_Atributos_PP_producto_V3(int docentry, string lote)
        {
            this.Consulta_Atributos_PP_producto_V3(docentry, lote);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }

        public DataTable cls_Consulta_ATRP8(string cMatriz)
        {
            this.Consulta_ATRP8(cMatriz);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP8_usuario(string cMatriz, int d_userid)
        {
            this.Consulta_ATRP8_usuario(cMatriz, d_userid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP8l(string cMatriz)
        {
            this.Consulta_ATRP8l(cMatriz);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP5l(string d_CodAtrD, string d_DocEntry_Ref)
        {
            this.Consulta_ATRP5l(d_CodAtrD, d_DocEntry_Ref);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP9l(string d_CodAtrD, string d_DocEntry_Ref)
        {
            this.Consulta_ATRP9l(d_CodAtrD, d_DocEntry_Ref);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRPA0(string d_CodAtrD)
        {
            this.Consulta_ATRPA0(d_CodAtrD);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }
        public DataTable cls_Consulta_max_ATRPA0l(string d_CodAtr)
        {
            this.Consulta_max_ATRPA0l(d_CodAtr);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_max_ATRPA0x()
        {
            this.Consulta_max_ATRPA0x();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_max_ATRP5l()
        {
            this.Consulta_max_ATRP5l();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_max_ATRP9l()
        {
            this.Consulta_max_ATRP9l();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP5l_plus(string d_Matriz, string d_CodAtrD, string d_DocEntry_Ref)
        {
            this.Consulta_ATRP5l_plus(d_Matriz, d_CodAtrD, d_DocEntry_Ref);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_ATRP9l_plus(string d_Matriz, string d_CodAtrD, string d_DocEntry_Ref)
        {
            this.Consulta_ATRP9l_plus(d_Matriz, d_CodAtrD, d_DocEntry_Ref);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Consumos_desde_OF(int nNumOF)
        {
            this.Consulta_Consumos_desde_OF(nNumOF);
            this.cResultado = this.Resultado;
            return this.cResultado;
        }
        
        public DataTable cls_ConsultaLista_Procesos()
        {
            this.ConsultaLista_Procesos();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos1()
        {
            this.ConsultaLista_Procesos1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos2()
        {
            this.ConsultaLista_Procesos2();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos_x_items(string cProceso)
        {
            this.ConsultaLista_Procesos_x_items(cProceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos_x_items_V2(string cProceso, string cVariedad, string cCalibre)
        {
            this.ConsultaLista_Procesos_x_items_V2(cProceso, cVariedad, cCalibre);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos_x_items_V3(string cProceso)
        {
            this.ConsultaLista_Procesos_x_items_V3(cProceso);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_ConsultaLista_Procesos_x_items_V4(string cProceso, string cVariedad, string cCalibre)
        {
            this.ConsultaLista_Procesos_x_items_V4(cProceso, cVariedad, cCalibre);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public static String SAPB1_ORCAL5(int d_docentry, int d_baseentry, int d_lineid, string d_ruta_imagen)
        {
            cldCalidad acceso = new cldCalidad();

            acceso.DocEntry = d_docentry;
            acceso.LineId = d_lineid;
            acceso.BaseEntry = d_baseentry;

            acceso.RutaImagen = d_ruta_imagen;

            return new cldCalidad().SAPB1_ORCAL5(acceso);
        }

        public DataTable cls_Consultar_Calidad_x_Imagen(int id_docentry, int lineid)
        {
            this.Consultar_Calidad_x_Imagen(id_docentry, lineid);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consultar_Calidad_x_Lista_Imagen(int id_docentry)
        {
            this.Consultar_Calidad_x_Lista_Imagen(id_docentry);
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lotes_Rechazados()
        {
            this.Consulta_Lotes_Rechazados();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lotes_Rechazados1()
        {
            this.Consulta_Lotes_Rechazados1();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }

        public DataTable cls_Consulta_Lotes_Proceso()
        {
            this.Consulta_Lotes_Proceso();
            this.cResultado = this.Resultado;
            return this.cResultado;

        }


    }

}
