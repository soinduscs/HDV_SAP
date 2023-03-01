using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class cldCalidad : GestorSql
    {

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Muestra { get; set; }
        public double CantMuestra { get; set; }
        public string Destructiva { get; set; }
        public double CantDestructiva { get; set; }
        public string Comments { get; set; }
        public string UserCode { get; set; }
        public int UserId { get; set; }
        public string CodeAtr { get; set; }
        public string NameAtr { get; set; }
        public string CodeAtrD { get; set; }
        public double Standard { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }
        public string Lote { get; set; }
        public int DocEntryRef { get; set; }
        public string Object { get; set; }
        public int DocEntry { get; set; }
        public string Accion { get; set; }
        public int DocNum { get; set; }
        public string WhsCode { get; set; }
        public string WhsDest { get; set; }
        public string NumCon { get; set; }
        public double Cantidad { get; set; }
        public double Bultos { get; set; }
        public double BultosMu { get; set; }
        public string FechaIngreso { get; set; }
        public string UM { get; set; }
        public int LineId { get; set; }
        public double Medicion { get; set; }
        public string Comments2 { get; set; }
        public string Estado { get; set; }
        public string Object_Ref { get; set; }
        public int DocEntry_Ref { get; set; }
        public int LineId_Ref { get; set; }
        public string RutaImagen { get; set; }
        public int BaseEntry { get; set; }
        public string CalibreNuez { get; set; }
        public string ColorNuez { get; set; }
        public string Code { get; set; }
        public string Variedad { get; set; }
        public string Locked { get; set; }
        public int DocOrig { get; set; }
        public string TipoProceso { get; set; }
        public string Disponible { get; set; }
        public string AtrT1 { get; set; }
        public string AtrT2 { get; set; }
        public string Area { get; set; }
        public int Semana { get; set; }
        public int Anho { get; set; }
        public string Turno { get; set; }
        public string Operador { get; set; }
        public double Porcentaje { get; set; }
        public string G3V1 { get; set; }
        public string G3V2 { get; set; }
        public string G3V3 { get; set; }
        public string G4V1 { get; set; }
        public string G4V2 { get; set; }
        public string G4V3 { get; set; }
        public string G4V4 { get; set; }
        public string G4V5 { get; set; }
        public string G4V6 { get; set; }
        public string G4V7 { get; set; }
        public string G4V8 { get; set; }
        public string G4V9 { get; set; }
        public string G4V10 { get; set; }
        public string G4V11 { get; set; }
        public string G4V12 { get; set; }
        public string G4V13 { get; set; }
        public string G5V1 { get; set; }
        public string G5V2 { get; set; }
        public string G5V3 { get; set; }
        public string G5V4 { get; set; }
        public string G5V5 { get; set; }

        public cldCalidad()

        {

        }

        public cldCalidad(string d_ItemCode, string d_ItemName, string d_Muestra, double d_CantMuestra, string d_Destructiva, double d_CantDestructiva, string d_Comments, string d_CodeAtr, string d_NameAtr , double d_Standard , double d_Minimo , double d_Maximo , string c_UserCode , int n_UserId )

        {
            this.ItemCode = d_ItemCode;
            this.ItemName = d_ItemName;
            this.Muestra = d_Muestra;
            this.CantMuestra = d_CantMuestra;
            this.Destructiva = d_Destructiva; 
            this.CantDestructiva = d_CantDestructiva;
            this.Comments = d_Comments;
            this.CodeAtr = d_CodeAtr;
            this.NameAtr = d_NameAtr;
            this.Standard = d_Standard;
            this.Minimo = d_Minimo;
            this.Maximo = d_Maximo;
            this.UserCode = c_UserCode;
            this.UserId = n_UserId;

        }

        public string SAPB1_OATRP(cldCalidad parCalidad)
        {
            
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OATRP";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParItemName = new SqlParameter();
                ParItemName.ParameterName = "@ItemName";
                ParItemName.SqlDbType = SqlDbType.VarChar;
                ParItemName.Size = parCalidad.ItemName.Length;
                ParItemName.Value = parCalidad.ItemName;
                SqlComando.Parameters.Add(ParItemName);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@Comment";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = parCalidad.Comments.Length;
                ParComments.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComments);

                SqlParameter ParMuestra = new SqlParameter();
                ParMuestra.ParameterName = "@ContraMu";
                ParMuestra.SqlDbType = SqlDbType.VarChar;
                ParMuestra.Size = parCalidad.Muestra.Length;
                ParMuestra.Value = parCalidad.Muestra;
                SqlComando.Parameters.Add(ParMuestra);

                SqlParameter ParCantMuestra = new SqlParameter();
                ParCantMuestra.ParameterName = "@CoMuSize";
                ParCantMuestra.SqlDbType = SqlDbType.Float;
                ParCantMuestra.Value = parCalidad.CantMuestra;
                SqlComando.Parameters.Add(ParCantMuestra);

                SqlParameter ParDestructiva = new SqlParameter();
                ParDestructiva.ParameterName = "@MuestDes";
                ParDestructiva.SqlDbType = SqlDbType.VarChar;
                ParDestructiva.Size = parCalidad.Destructiva.Length;
                ParDestructiva.Value = parCalidad.Destructiva;
                SqlComando.Parameters.Add(ParDestructiva);

                SqlParameter ParCantDestructiva = new SqlParameter();
                ParCantDestructiva.ParameterName = "@MuDeSize";
                ParCantDestructiva.SqlDbType = SqlDbType.Float;
                ParCantDestructiva.Value = parCalidad.CantDestructiva;
                SqlComando.Parameters.Add(ParCantDestructiva);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserId);

                SqlParameter ParUserCode= new SqlParameter();
                ParUserCode.ParameterName = "@creator";
                ParUserCode.SqlDbType = SqlDbType.VarChar;
                ParUserCode.Size = parCalidad.UserCode.Length;
                ParUserCode.Value = parCalidad.UserCode;
                SqlComando.Parameters.Add(ParUserCode);



                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ATRP1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ATRP1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParCodeAtr = new SqlParameter();
                ParCodeAtr.ParameterName = "@CodAtr";
                ParCodeAtr.SqlDbType = SqlDbType.VarChar;
                ParCodeAtr.Size = parCalidad.CodeAtr.Length;
                ParCodeAtr.Value = parCalidad.CodeAtr;
                SqlComando.Parameters.Add(ParCodeAtr);

                SqlParameter ParNameAtr = new SqlParameter();
                ParNameAtr.ParameterName = "@NameAtr";
                ParNameAtr.SqlDbType = SqlDbType.VarChar;
                ParNameAtr.Size = parCalidad.NameAtr.Length;
                ParNameAtr.Value = parCalidad.NameAtr;
                SqlComando.Parameters.Add(ParNameAtr);

                SqlParameter ParStandard = new SqlParameter();
                ParStandard.ParameterName = "@StandAtr";
                ParStandard.SqlDbType = SqlDbType.Float;
                ParStandard.Value = parCalidad.Standard;
                SqlComando.Parameters.Add(ParStandard);

                SqlParameter ParMinimo = new SqlParameter();
                ParMinimo.ParameterName = "@Minimo";
                ParMinimo.SqlDbType = SqlDbType.Float;
                ParMinimo.Value = parCalidad.Minimo;
                SqlComando.Parameters.Add(ParMinimo);

                SqlParameter ParMaximo= new SqlParameter();
                ParMaximo.ParameterName = "@Maximo";
                ParMaximo.SqlDbType = SqlDbType.Float;
                ParMaximo.Value = parCalidad.Maximo;
                SqlComando.Parameters.Add(ParMaximo);

                SqlParameter ParComment = new SqlParameter();
                ParComment.ParameterName = "@Comment";
                ParComment.SqlDbType = SqlDbType.VarChar;
                ParComment.Size = parCalidad.Comments.Length;
                ParComment.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComment);


                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_ATRP2(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ATRP2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@Code";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParCodeAtr = new SqlParameter();
                ParCodeAtr.ParameterName = "@CodAtr";
                ParCodeAtr.SqlDbType = SqlDbType.VarChar;
                ParCodeAtr.Size = parCalidad.CodeAtr.Length;
                ParCodeAtr.Value = parCalidad.CodeAtr;
                SqlComando.Parameters.Add(ParCodeAtr);

                SqlParameter ParNameAtr = new SqlParameter();
                ParNameAtr.ParameterName = "@NameAtr";
                ParNameAtr.SqlDbType = SqlDbType.VarChar;
                ParNameAtr.Size = parCalidad.NameAtr.Length;
                ParNameAtr.Value = parCalidad.NameAtr;
                SqlComando.Parameters.Add(ParNameAtr);

                SqlParameter ParStandard = new SqlParameter();
                ParStandard.ParameterName = "@StandAtr";
                ParStandard.SqlDbType = SqlDbType.Float;
                ParStandard.Value = parCalidad.Standard;
                SqlComando.Parameters.Add(ParStandard);

                SqlParameter ParMinimo = new SqlParameter();
                ParMinimo.ParameterName = "@Minimo";
                ParMinimo.SqlDbType = SqlDbType.Float;
                ParMinimo.Value = parCalidad.Minimo;
                SqlComando.Parameters.Add(ParMinimo);

                SqlParameter ParMaximo = new SqlParameter();
                ParMaximo.ParameterName = "@Maximo";
                ParMaximo.SqlDbType = SqlDbType.Float;
                ParMaximo.Value = parCalidad.Maximo;
                SqlComando.Parameters.Add(ParMaximo);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserSign);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ATRP8(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "insert [@HDV_ATRP8] ( Code , Name , U_Proceso , U_Matriz ) ";
            sql += "select '" + parCalidad.Code + "' , ";
            sql += "'" + parCalidad.Code + "' , ";
            sql += "'" + parCalidad.CodeAtr + "' , ";
            sql += "'" + parCalidad.NameAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualiza_ATRP1(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [@HDV_ATRP1] ";
            sql += "set Object = '" + parCalidad.Code + "' , ";
            sql += "U_AQL = " + parCalidad.AtrT1 + " , ";
            sql += "U_Metodo = '" + parCalidad.UM + "' , ";
            sql += "U_StandAtr = " + parCalidad.Standard.ToString() + " , ";
            sql += "U_NameAtr = '" + parCalidad.NameAtr.ToString() + "' ";

            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualiza_ATRP1_x(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [@HDV_ATRP1] ";
            sql += "set U_Minimo = " + parCalidad.Minimo + " , ";
            sql += "U_Maximo = " + parCalidad.Maximo + " ";

            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualiza_ATRP1_y(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [@HDV_ATRP1] ";
            sql += "set U_TipoMues = " + parCalidad.Minimo + " ";

            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualiza_ATRP1_z(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [@HDV_ATRP1] ";
            sql += "set U_TiempoEs = " + parCalidad.Minimo + " , ";
            sql += "U_CodEquip = '" + parCalidad.Accion + "' ";

            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualiza_ATRP3(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [@HDV_ATRP3] ";
            sql += "set U_Minimo = " + parCalidad.Minimo.ToString() + " , ";
            sql += "U_Maximo = " + parCalidad.Maximo.ToString() + " , ";
            sql += "U_Locked = '" + parCalidad.Locked.ToString() + "' ";

            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";
            sql += "and DocEntry in ( select U_BaseEntry from [@HDV_ATRP6] where DocEntry = " + parCalidad.DocEntry.ToString() + " ) ";
            //sql += "and DocEntry = " + parCalidad.DocEntry.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Agregar_Atributo_ATRP1(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_ATRP1] (DocEntry, LineId, VisOrder, Object, LogInst, U_CodAtr, ";
            sql += "U_NameAtr, U_Cualitat, U_Critico, U_TipoMues, U_AQL, U_TiempoEs, U_Comment, ";
            sql += "U_CodEquip, U_Metodo, U_TipoDef, U_StandAtr, U_Minimo, U_Maximo ) ";

            sql += "select ";
            sql += "DocEntry, " + parCalidad.LineId.ToString() + " , VisOrder, Object, LogInst, '" + parCalidad.CodeAtrD + "' , ";
            sql += "'" + parCalidad.NameAtr + "', U_Cualitat, U_Critico, U_TipoMues, U_AQL, U_TiempoEs, U_Comment, ";
            sql += "U_CodEquip, U_Metodo, U_TipoDef, U_StandAtr, U_Minimo, U_Maximo ";
            sql += "from [dbo].[@HDV_ATRP1] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Agregar_OCERNV(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_OCERNV] (Code , Name , U_DocNum , U_ItemCode , U_Fecha , U_UserSign , U_G3V1 , U_G3V2 , U_G3V3 ) ";

            sql += "select ";
            sql += "'" + parCalidad.Code.ToString() + "' , '" + parCalidad.Code.ToString() + "' , '" + parCalidad.DocNum.ToString() + "' , '" + parCalidad.ItemCode + "' , getdate() , " + parCalidad.UserId.ToString() + " , '' , '' , '' ";


            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Actualizar_OCERNV(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [dbo].[@HDV_OCERNV] set ";
            sql += "U_G3V1 = '" + parCalidad.G3V1 + "' , ";
            sql += "U_G3V2 = '" + parCalidad.G3V2 + "' , ";
            sql += "U_G3V3 = '" + parCalidad.G3V3 + "' , ";

            sql += "U_G4V1 = '" + parCalidad.G4V1 + "' , ";
            sql += "U_G4V2 = '" + parCalidad.G4V2 + "' , ";
            sql += "U_G4V3 = '" + parCalidad.G4V3 + "' , ";
            sql += "U_G4V4 = '" + parCalidad.G4V4 + "' , ";
            sql += "U_G4V5 = '" + parCalidad.G4V5 + "' , ";
            sql += "U_G4V6 = '" + parCalidad.G4V6 + "' , ";
            sql += "U_G4V7 = '" + parCalidad.G4V7 + "' , ";
            sql += "U_G4V8 = '" + parCalidad.G4V8 + "' , ";
            sql += "U_G4V9 = '" + parCalidad.G4V9 + "' , ";
            sql += "U_G4V10 = '" + parCalidad.G4V10 + "' , ";
            sql += "U_G4V11 = '" + parCalidad.G4V11 + "' , ";
            sql += "U_G4V12 = '" + parCalidad.G4V12 + "' , ";
            sql += "U_G4V13 = '" + parCalidad.G4V13 + "' , ";

            sql += "U_G5V1 = '" + parCalidad.G5V1 + "' , ";
            sql += "U_G5V2 = '" + parCalidad.G5V2 + "' , ";
            sql += "U_G5V3 = '" + parCalidad.G5V3 + "' , ";
            sql += "U_G5V4 = '" + parCalidad.G5V4 + "' , ";
            sql += "U_G5V5 = '" + parCalidad.G5V5 + "'   ";

            sql += "where Code = '" + parCalidad.Code.ToString() + "' ";
            sql += "and U_DocNum = '" + parCalidad.DocNum.ToString() + "' ";
            sql += "and U_ItemCode = '" + parCalidad.ItemCode + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Eliminar_Atributo_ATRP1(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "delete [dbo].[@HDV_ATRP1] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Sapb1_utiles_matriz_new(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "exec xSapb1_utiles_matriz_new " + parCalidad.DocEntry + " , '" + parCalidad.NameAtr + "' , '" + parCalidad.Code + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Agregar_Atributo_ATRP3(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_ATRP3] ( DocEntry, LineId, VisOrder, Object, LogInst, U_CodAtr, U_Locked, U_Minimo, U_Maximo ) ";

            sql += "select ";
            sql += "DocEntry, " + parCalidad.LineId.ToString() + " , VisOrder, Object, LogInst, '" + parCalidad.CodeAtrD + "' , U_Locked, U_Minimo, U_Maximo ";
            sql += "from [dbo].[@HDV_ATRP3] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string Eliminar_Atributo_ATRP3(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "delete [dbo].[@HDV_ATRP3] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string SAPB1_ATRP8e(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "delete [@HDV_ATRP8] ";
            sql += "where Code = '" + parCalidad.Code + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            return Respuesta;
        }

        public string SAPB1_ATRP3(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ATRP3";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCode = new SqlParameter();
                ParCode.ParameterName = "@Code";
                ParCode.SqlDbType = SqlDbType.VarChar;
                ParCode.Size = parCalidad.Code.Length;
                ParCode.Value = parCalidad.Code;
                SqlComando.Parameters.Add(ParCode);

                SqlParameter ParVariedad = new SqlParameter();
                ParVariedad.ParameterName = "@Variedad";
                ParVariedad.SqlDbType = SqlDbType.VarChar;
                ParVariedad.Size = parCalidad.Variedad.Length;
                ParVariedad.Value = parCalidad.Variedad;
                SqlComando.Parameters.Add(ParVariedad);

                SqlParameter ParCalibre = new SqlParameter();
                ParCalibre.ParameterName = "@Calibre";
                ParCalibre.SqlDbType = SqlDbType.VarChar;
                ParCalibre.Size = parCalidad.CalibreNuez.Length;
                ParCalibre.Value = parCalidad.CalibreNuez;
                SqlComando.Parameters.Add(ParCalibre);

                SqlParameter ParCodeAtr = new SqlParameter();
                ParCodeAtr.ParameterName = "@CodAtr";
                ParCodeAtr.SqlDbType = SqlDbType.VarChar;
                ParCodeAtr.Size = parCalidad.CodeAtr.Length;
                ParCodeAtr.Value = parCalidad.CodeAtr;
                SqlComando.Parameters.Add(ParCodeAtr);

                SqlParameter ParMinimo = new SqlParameter();
                ParMinimo.ParameterName = "@Minimo";
                ParMinimo.SqlDbType = SqlDbType.Float;
                ParMinimo.Value = parCalidad.Minimo;
                SqlComando.Parameters.Add(ParMinimo);

                SqlParameter ParMaximo = new SqlParameter();
                ParMaximo.ParameterName = "@Maximo";
                ParMaximo.SqlDbType = SqlDbType.Float;
                ParMaximo.Value = parCalidad.Maximo;
                SqlComando.Parameters.Add(ParMaximo);

                SqlParameter ParLocked = new SqlParameter();
                ParLocked.ParameterName = "@Locked";
                ParLocked.SqlDbType = SqlDbType.VarChar;
                ParLocked.Size = parCalidad.Locked.Length;
                ParLocked.Value = parCalidad.Locked;
                SqlComando.Parameters.Add(ParLocked);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserSign);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ATRP4(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ATRP4";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCode = new SqlParameter();
                ParCode.ParameterName = "@Code";
                ParCode.SqlDbType = SqlDbType.VarChar;
                ParCode.Size = parCalidad.Code.Length;
                ParCode.Value = parCalidad.Code;
                SqlComando.Parameters.Add(ParCode);

                SqlParameter ParVariedad = new SqlParameter();
                ParVariedad.ParameterName = "@Variedad";
                ParVariedad.SqlDbType = SqlDbType.VarChar;
                ParVariedad.Size = parCalidad.Variedad.Length;
                ParVariedad.Value = parCalidad.Variedad;
                SqlComando.Parameters.Add(ParVariedad);

                SqlParameter ParCalibre = new SqlParameter();
                ParCalibre.ParameterName = "@Calibre";
                ParCalibre.SqlDbType = SqlDbType.VarChar;
                ParCalibre.Size = parCalidad.CalibreNuez.Length;
                ParCalibre.Value = parCalidad.CalibreNuez;
                SqlComando.Parameters.Add(ParCalibre);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@Comment";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = parCalidad.Comments.Length;
                ParComments.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComments);

                SqlParameter ParMaximo = new SqlParameter();
                ParMaximo.ParameterName = "@Maximo";
                ParMaximo.SqlDbType = SqlDbType.Float;
                ParMaximo.Value = parCalidad.Maximo;
                SqlComando.Parameters.Add(ParMaximo);

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserSign);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_ORCAL(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCAL";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocNum";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum; 
                SqlComando.Parameters.Add(ParDocNum);

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserId);

                SqlParameter ParUserCode = new SqlParameter();
                ParUserCode.ParameterName = "@creator";
                ParUserCode.SqlDbType = SqlDbType.VarChar;
                ParUserCode.Size = parCalidad.UserCode.Length;
                ParUserCode.Value = parCalidad.UserCode;
                SqlComando.Parameters.Add(ParUserCode);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParItemName = new SqlParameter();
                ParItemName.ParameterName = "@ItemName";
                ParItemName.SqlDbType = SqlDbType.VarChar;
                ParItemName.Size = parCalidad.ItemName.Length;
                ParItemName.Value = parCalidad.ItemName;
                SqlComando.Parameters.Add(ParItemName);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@WhsCode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parCalidad.WhsCode.Length;
                ParWhsCode.Value = parCalidad.WhsCode;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter ParWhsDest = new SqlParameter();
                ParWhsDest.ParameterName = "@WhsDest";
                ParWhsDest.SqlDbType = SqlDbType.VarChar;
                ParWhsDest.Size = parCalidad.WhsDest.Length;
                ParWhsDest.Value = parCalidad.WhsDest;
                SqlComando.Parameters.Add(ParWhsDest);

                SqlParameter ParNumCon = new SqlParameter();
                ParNumCon.ParameterName = "@NumCon";
                ParNumCon.SqlDbType = SqlDbType.VarChar;
                ParNumCon.Size = parCalidad.NumCon.Length;
                ParNumCon.Value = parCalidad.NumCon;
                SqlComando.Parameters.Add(ParNumCon);

                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.VarChar;
                ParLote.Size = parCalidad.Lote.Length;
                ParLote.Value = parCalidad.Lote;
                SqlComando.Parameters.Add(ParLote);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = parCalidad.Cantidad;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParBultos = new SqlParameter();
                ParBultos.ParameterName = "@Bultos";
                ParBultos.SqlDbType = SqlDbType.Int;
                ParBultos.Value = parCalidad.Bultos;
                SqlComando.Parameters.Add(ParBultos);

                SqlParameter ParBultosMu = new SqlParameter();
                ParBultosMu.ParameterName = "@BultosMu";
                ParBultosMu.SqlDbType = SqlDbType.Int;
                ParBultosMu.Value = parCalidad.BultosMu;
                SqlComando.Parameters.Add(ParBultosMu);

                SqlParameter ParFecIngr = new SqlParameter();
                ParFecIngr.ParameterName = "@FecIngr";
                ParFecIngr.SqlDbType = SqlDbType.VarChar;
                ParFecIngr.Size = parCalidad.FechaIngreso.Length;
                ParFecIngr.Value = parCalidad.FechaIngreso;
                SqlComando.Parameters.Add(ParFecIngr);

                SqlParameter ParUM = new SqlParameter();
                ParUM.ParameterName = "@UM";
                ParUM.SqlDbType = SqlDbType.VarChar;
                ParUM.Size = parCalidad.UM.Length;
                ParUM.Value = parCalidad.UM;
                SqlComando.Parameters.Add(ParUM);

                SqlParameter ParCoMuSize = new SqlParameter();
                ParCoMuSize.ParameterName = "@CoMuSize";
                ParCoMuSize.SqlDbType = SqlDbType.Float;
                ParCoMuSize.Value = parCalidad.CantMuestra;
                SqlComando.Parameters.Add(ParCoMuSize);

                SqlParameter ParMuDeSize = new SqlParameter();
                ParMuDeSize.ParameterName = "@MuDeSize";
                ParMuDeSize.SqlDbType = SqlDbType.Float;
                ParMuDeSize.Value = parCalidad.CantDestructiva;
                SqlComando.Parameters.Add(ParMuDeSize);

                SqlParameter ParComment = new SqlParameter();
                ParComment.ParameterName = "@Comment";
                ParComment.SqlDbType = SqlDbType.VarChar;
                ParComment.Size = parCalidad.Comments.Length;
                ParComment.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComment);

                SqlParameter ParObject_Ref = new SqlParameter();
                ParObject_Ref.ParameterName = "@Object_Ref";
                ParObject_Ref.SqlDbType = SqlDbType.VarChar;
                ParObject_Ref.Size = parCalidad.Object_Ref.Length;
                ParObject_Ref.Value = parCalidad.Object_Ref;
                SqlComando.Parameters.Add(ParObject_Ref);

                SqlParameter ParDocEntry_Ref = new SqlParameter();
                ParDocEntry_Ref.ParameterName = "@DocEntry_Ref";
                ParDocEntry_Ref.SqlDbType = SqlDbType.Int;
                ParDocEntry_Ref.Value = parCalidad.DocEntry_Ref;
                SqlComando.Parameters.Add(ParDocEntry_Ref);

                SqlParameter ParLineId_Ref = new SqlParameter();
                ParLineId_Ref.ParameterName = "@LineId_Ref";
                ParLineId_Ref.SqlDbType = SqlDbType.Int;
                ParLineId_Ref.Value = parCalidad.LineId_Ref;
                SqlComando.Parameters.Add(ParLineId_Ref);

                SqlParameter ParCalibreNuez = new SqlParameter();
                ParCalibreNuez.ParameterName = "@Calibre_Nuez";
                ParCalibreNuez.SqlDbType = SqlDbType.VarChar;
                ParCalibreNuez.Size = parCalidad.CalibreNuez.Length;
                ParCalibreNuez.Value = parCalidad.CalibreNuez;
                SqlComando.Parameters.Add(ParCalibreNuez);

                SqlParameter ParColorNuez = new SqlParameter();
                ParColorNuez.ParameterName = "@Color_Nuez";
                ParColorNuez.SqlDbType = SqlDbType.VarChar;
                ParColorNuez.Size = parCalidad.ColorNuez.Length;
                ParColorNuez.Value = parCalidad.ColorNuez;
                SqlComando.Parameters.Add(ParColorNuez);

                SqlParameter ParDocOrig = new SqlParameter();
                ParDocOrig.ParameterName = "@DocOrig";
                ParDocOrig.SqlDbType = SqlDbType.Int;
                ParDocOrig.Value = parCalidad.DocOrig;
                SqlComando.Parameters.Add(ParDocOrig);

                SqlParameter ParTipoProceso = new SqlParameter();
                ParTipoProceso.ParameterName = "@TipoProceso";
                ParTipoProceso.SqlDbType = SqlDbType.VarChar;
                ParTipoProceso.Size = parCalidad.TipoProceso.Length;
                ParTipoProceso.Value = parCalidad.TipoProceso;
                SqlComando.Parameters.Add(ParTipoProceso);

                SqlParameter ParDisponible = new SqlParameter();
                ParDisponible.ParameterName = "@Disponible";
                ParDisponible.SqlDbType = SqlDbType.VarChar;
                ParDisponible.Size = parCalidad.Disponible.Length;
                ParDisponible.Value = parCalidad.Disponible;
                SqlComando.Parameters.Add(ParDisponible);

                SqlParameter ParAtrT1  = new SqlParameter();
                ParAtrT1.ParameterName = "@AtrT1";
                ParAtrT1.SqlDbType = SqlDbType.VarChar;
                ParAtrT1.Size = parCalidad.AtrT1.Length;
                ParAtrT1.Value = parCalidad.AtrT1;
                SqlComando.Parameters.Add(ParAtrT1);

                SqlParameter ParAtrT2 = new SqlParameter();
                ParAtrT2.ParameterName = "@AtrT2";
                ParAtrT2.SqlDbType = SqlDbType.VarChar;
                ParAtrT2.Size = parCalidad.AtrT2.Length;
                ParAtrT2.Value = parCalidad.AtrT2;
                SqlComando.Parameters.Add(ParAtrT2);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_OPRM(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPRM";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUserSign = new SqlParameter();
                ParUserSign.ParameterName = "@UserSign";
                ParUserSign.SqlDbType = SqlDbType.Int;
                ParUserSign.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserSign);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@WhsCode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parCalidad.WhsCode.Length;
                ParWhsCode.Value = parCalidad.WhsCode;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_OFUM(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OFUM";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocNum";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserId);

                SqlParameter ParUserCode = new SqlParameter();
                ParUserCode.ParameterName = "@creator";
                ParUserCode.SqlDbType = SqlDbType.VarChar;
                ParUserCode.Size = parCalidad.UserCode.Length;
                ParUserCode.Value = parCalidad.UserCode;
                SqlComando.Parameters.Add(ParUserCode);

                SqlParameter Parfecha_fumigado = new SqlParameter();
                Parfecha_fumigado.ParameterName = "@fecha_fumigado";
                Parfecha_fumigado.SqlDbType = SqlDbType.VarChar;
                Parfecha_fumigado.Size = parCalidad.FechaIngreso.Length;
                Parfecha_fumigado.Value = parCalidad.FechaIngreso;
                SqlComando.Parameters.Add(Parfecha_fumigado);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParFumigado = new SqlParameter();
                ParFumigado.ParameterName = "@Fumigado";
                ParFumigado.SqlDbType = SqlDbType.VarChar;
                ParFumigado.Size = parCalidad.Estado.Length;
                ParFumigado.Value = parCalidad.Estado;
                SqlComando.Parameters.Add(ParFumigado);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }


        public string SAPB1_ORCALA2(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCALA2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Pardocentry_old = new SqlParameter();
                Pardocentry_old.ParameterName = "@docentry_old";
                Pardocentry_old.SqlDbType = SqlDbType.Int;
                Pardocentry_old.Value = parCalidad.DocEntry; 
                SqlComando.Parameters.Add(Pardocentry_old);

                SqlParameter Pardocentry_new = new SqlParameter();
                Pardocentry_new.ParameterName = "@docentry_new";
                Pardocentry_new.SqlDbType = SqlDbType.Int;
                Pardocentry_new.Value = parCalidad.DocEntryRef;
                SqlComando.Parameters.Add(Pardocentry_new);


                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_OPR1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_OPR1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parCalidad.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParSemana = new SqlParameter();
                ParSemana.ParameterName = "@Semana";
                ParSemana.SqlDbType = SqlDbType.Int;
                ParSemana.Value = parCalidad.Semana;
                SqlComando.Parameters.Add(ParSemana);

                SqlParameter ParAnho = new SqlParameter();
                ParAnho.ParameterName = "@Anho";
                ParAnho.SqlDbType = SqlDbType.Int;
                ParAnho.Value = parCalidad.Anho;
                SqlComando.Parameters.Add(ParAnho);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@Area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = parCalidad.Area.Length;
                ParArea.Value = parCalidad.Area;
                SqlComando.Parameters.Add(ParArea);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@Turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = parCalidad.Turno.Length;
                ParTurno.Value = parCalidad.Turno;
                SqlComando.Parameters.Add(ParTurno);

                SqlParameter ParOperador = new SqlParameter();
                ParOperador.ParameterName = "@Operador";
                ParOperador.SqlDbType = SqlDbType.VarChar;
                ParOperador.Size = parCalidad.Operador.Length;
                ParOperador.Value = parCalidad.Operador;
                SqlComando.Parameters.Add(ParOperador);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ORCALv1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCALv1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocEntry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserId);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ROMANAv1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANAv1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocEntry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ORCAL9(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCAL9";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocEntry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ORCAL9v1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCAL9v1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocEntry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "vv " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_RCAL1(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_RCAL1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parCalidad.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@LineId";
                ParLineId.SqlDbType = SqlDbType.Int;
                ParLineId.Value = parCalidad.LineId;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParCodeAtr = new SqlParameter();
                ParCodeAtr.ParameterName = "@CodAtr";
                ParCodeAtr.SqlDbType = SqlDbType.VarChar;
                ParCodeAtr.Size = parCalidad.CodeAtr.Length;
                ParCodeAtr.Value = parCalidad.CodeAtr;
                SqlComando.Parameters.Add(ParCodeAtr);

                SqlParameter ParNameAtr = new SqlParameter();
                ParNameAtr.ParameterName = "@NameAtr";
                ParNameAtr.SqlDbType = SqlDbType.VarChar;
                ParNameAtr.Size = parCalidad.NameAtr.Length;
                ParNameAtr.Value = parCalidad.NameAtr;
                SqlComando.Parameters.Add(ParNameAtr);

                SqlParameter ParStandard = new SqlParameter();
                ParStandard.ParameterName = "@StandAtr";
                ParStandard.SqlDbType = SqlDbType.Float;
                ParStandard.Value = parCalidad.Standard;
                SqlComando.Parameters.Add(ParStandard);

                SqlParameter ParMinimo = new SqlParameter();
                ParMinimo.ParameterName = "@Minimo";
                ParMinimo.SqlDbType = SqlDbType.Float;
                ParMinimo.Value = parCalidad.Minimo;
                SqlComando.Parameters.Add(ParMinimo);

                SqlParameter ParMaximo = new SqlParameter();
                ParMaximo.ParameterName = "@Maximo";
                ParMaximo.SqlDbType = SqlDbType.Float;
                ParMaximo.Value = parCalidad.Maximo;
                SqlComando.Parameters.Add(ParMaximo);

                SqlParameter ParMedicion = new SqlParameter();
                ParMedicion.ParameterName = "@Medicion";
                ParMedicion.SqlDbType = SqlDbType.Float;
                ParMedicion.Value = parCalidad.Medicion;
                SqlComando.Parameters.Add(ParMedicion);

                SqlParameter ParComment = new SqlParameter();
                ParComment.ParameterName = "@Comment";
                ParComment.SqlDbType = SqlDbType.VarChar;
                ParComment.Size = parCalidad.Comments.Length;
                ParComment.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComment);

                SqlParameter ParComment2 = new SqlParameter();
                ParComment2.ParameterName = "@Comment2";
                ParComment2.SqlDbType = SqlDbType.VarChar;
                ParComment2.Size = parCalidad.Comments2.Length;
                ParComment2.Value = parCalidad.Comments2;
                SqlComando.Parameters.Add(ParComment2);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = parCalidad.Estado.Length;
                ParEstado.Value = parCalidad.Estado;
                SqlComando.Parameters.Add(ParEstado);

                SqlParameter ParPorcentaje = new SqlParameter();
                ParPorcentaje.ParameterName = "@porcentaje";
                ParPorcentaje.SqlDbType = SqlDbType.Float;
                ParPorcentaje.Value = parCalidad.Porcentaje;
                SqlComando.Parameters.Add(ParPorcentaje);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ORCAL_II(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCAL";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocNum";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocNum;
                SqlComando.Parameters.Add(ParDocNum);

                SqlParameter ParAccion = new SqlParameter();
                ParAccion.ParameterName = "@Accion";
                ParAccion.SqlDbType = SqlDbType.VarChar;
                ParAccion.Size = parCalidad.Accion.Length;
                ParAccion.Value = parCalidad.Accion;
                SqlComando.Parameters.Add(ParAccion);

                SqlParameter ParUserId = new SqlParameter();
                ParUserId.ParameterName = "@UserSign";
                ParUserId.SqlDbType = SqlDbType.Int;
                ParUserId.Value = parCalidad.UserId;
                SqlComando.Parameters.Add(ParUserId);

                SqlParameter ParUserCode = new SqlParameter();
                ParUserCode.ParameterName = "@creator";
                ParUserCode.SqlDbType = SqlDbType.VarChar;
                ParUserCode.Size = parCalidad.UserCode.Length;
                ParUserCode.Value = parCalidad.UserCode;
                SqlComando.Parameters.Add(ParUserCode);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parCalidad.ItemCode.Length;
                ParItemCode.Value = parCalidad.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParItemName = new SqlParameter();
                ParItemName.ParameterName = "@ItemName";
                ParItemName.SqlDbType = SqlDbType.VarChar;
                ParItemName.Size = parCalidad.ItemName.Length;
                ParItemName.Value = parCalidad.ItemName;
                SqlComando.Parameters.Add(ParItemName);

                SqlParameter ParWhsCode = new SqlParameter();
                ParWhsCode.ParameterName = "@WhsCode";
                ParWhsCode.SqlDbType = SqlDbType.VarChar;
                ParWhsCode.Size = parCalidad.WhsCode.Length;
                ParWhsCode.Value = parCalidad.WhsCode;
                SqlComando.Parameters.Add(ParWhsCode);

                SqlParameter ParWhsDest = new SqlParameter();
                ParWhsDest.ParameterName = "@WhsDest";
                ParWhsDest.SqlDbType = SqlDbType.VarChar;
                ParWhsDest.Size = parCalidad.WhsDest.Length;
                ParWhsDest.Value = parCalidad.WhsDest;
                SqlComando.Parameters.Add(ParWhsDest);

                SqlParameter ParNumCon = new SqlParameter();
                ParNumCon.ParameterName = "@NumCon";
                ParNumCon.SqlDbType = SqlDbType.VarChar;
                ParNumCon.Size = parCalidad.NumCon.Length;
                ParNumCon.Value = parCalidad.NumCon;
                SqlComando.Parameters.Add(ParNumCon);

                SqlParameter ParLote = new SqlParameter();
                ParLote.ParameterName = "@lote";
                ParLote.SqlDbType = SqlDbType.VarChar;
                ParLote.Size = parCalidad.Lote.Length;
                ParLote.Value = parCalidad.Lote;
                SqlComando.Parameters.Add(ParLote);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = parCalidad.Cantidad;
                SqlComando.Parameters.Add(ParCantidad);

                SqlParameter ParBultos = new SqlParameter();
                ParBultos.ParameterName = "@Bultos";
                ParBultos.SqlDbType = SqlDbType.Int;
                ParBultos.Value = parCalidad.Bultos;
                SqlComando.Parameters.Add(ParBultos);

                SqlParameter ParBultosMu = new SqlParameter();
                ParBultosMu.ParameterName = "@BultosMu";
                ParBultosMu.SqlDbType = SqlDbType.Int;
                ParBultosMu.Value = parCalidad.BultosMu;
                SqlComando.Parameters.Add(ParBultosMu);

                SqlParameter ParFecIngr = new SqlParameter();
                ParFecIngr.ParameterName = "@FecIngr";
                ParFecIngr.SqlDbType = SqlDbType.VarChar;
                ParFecIngr.Size = parCalidad.FechaIngreso.Length;
                ParFecIngr.Value = parCalidad.FechaIngreso;
                SqlComando.Parameters.Add(ParFecIngr);

                SqlParameter ParUM = new SqlParameter();
                ParUM.ParameterName = "@UM";
                ParUM.SqlDbType = SqlDbType.VarChar;
                ParUM.Size = parCalidad.UM.Length;
                ParUM.Value = parCalidad.UM;
                SqlComando.Parameters.Add(ParUM);

                SqlParameter ParCoMuSize = new SqlParameter();
                ParCoMuSize.ParameterName = "@CoMuSize";
                ParCoMuSize.SqlDbType = SqlDbType.Float;
                ParCoMuSize.Value = parCalidad.CantMuestra;
                SqlComando.Parameters.Add(ParCoMuSize);

                SqlParameter ParMuDeSize = new SqlParameter();
                ParMuDeSize.ParameterName = "@MuDeSize";
                ParMuDeSize.SqlDbType = SqlDbType.Float;
                ParMuDeSize.Value = parCalidad.CantDestructiva;
                SqlComando.Parameters.Add(ParMuDeSize);

                SqlParameter ParComment = new SqlParameter();
                ParComment.ParameterName = "@Comment";
                ParComment.SqlDbType = SqlDbType.VarChar;
                ParComment.Size = parCalidad.Comments.Length;
                ParComment.Value = parCalidad.Comments;
                SqlComando.Parameters.Add(ParComment);

                SqlParameter ParObject_Ref = new SqlParameter();
                ParObject_Ref.ParameterName = "@Object_Ref";
                ParObject_Ref.SqlDbType = SqlDbType.VarChar;
                ParObject_Ref.Size = parCalidad.Object_Ref.Length;
                ParObject_Ref.Value = parCalidad.Object_Ref;
                SqlComando.Parameters.Add(ParObject_Ref);

                SqlParameter ParDocEntry_Ref = new SqlParameter();
                ParDocEntry_Ref.ParameterName = "@DocEntry_Ref";
                ParDocEntry_Ref.SqlDbType = SqlDbType.Int;
                ParDocEntry_Ref.Value = parCalidad.DocEntry_Ref;
                SqlComando.Parameters.Add(ParDocEntry_Ref);

                SqlParameter ParLineId_Ref = new SqlParameter();
                ParLineId_Ref.ParameterName = "@LineId_Ref";
                ParLineId_Ref.SqlDbType = SqlDbType.Int;
                ParLineId_Ref.Value = parCalidad.LineId_Ref;
                SqlComando.Parameters.Add(ParLineId_Ref);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public string SAPB1_ORCAL_III(cldCalidad parCalidad)
        {
            string Respuesta = "";

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ORCAL7";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@DocEntry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parCalidad.DocEntry;
                SqlComando.Parameters.Add(ParDocNum);

                SqlComando.ExecuteNonQuery();
                Respuesta = "Y";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (SqlConexion.State == ConnectionState.Open)
                {
                    SqlConexion.Close();
                }
            }

            return Respuesta;
        }

        public void Actualiza_Linea_OrdenVenta_Calidad(int DocEntry, int LineNum, string usuario)
        {

            string sql;

            sql = "Update RDR1 ";
            sql += "set U_EXP_VARIEDAD = '" + usuario + "' ";
            sql += "where DocEntry = " + DocEntry + " ";
            sql += "and LineNum = " + LineNum + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public string Eliminar_Linea_ATRP5(cldCalidad parCalidad)
        {
            if (parCalidad.Code == "")
            {
                parCalidad.Code = "0";

            }

            string Respuesta = "";

            string sql;

            sql = "delete [dbo].[@HDV_ATRP5] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";
            sql += "and U_CodAtrD = '" + parCalidad.CodeAtrD + "' ";
            sql += "and U_DocEntry_Ref = " + parCalidad.Code + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Eliminar_Linea_ATRP9(cldCalidad parCalidad)
        {

            if (parCalidad.Code == "")
            {
                parCalidad.Code = "0";

            }

            string Respuesta = "";

            string sql;

            sql = "delete [dbo].[@HDV_ATRP9] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";
            sql += "and U_CodAtrD = '" + parCalidad.CodeAtrD + "' ";
            sql += "and U_DocEntry_Ref = " + parCalidad.Code + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Eliminar_Linea_ATRPA0(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "delete [dbo].[@HDV_ATRPA0] ";
            sql += "where U_CodAtr = '" + parCalidad.CodeAtr + "' ";
            sql += "and U_Id = " + parCalidad.LineId;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Agregar_Linea_ATRP5(cldCalidad parCalidad)
        {
            if (parCalidad.Code == "")
            {
                parCalidad.Code = "0";
            }

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_ATRP5] ( DocEntry , U_CodAtr , U_CodAtrD , U_DocEntry_Ref , U_Accion ) ";
            sql += "select " + parCalidad.DocEntry.ToString() + " , ";
            sql += "'" + parCalidad.CodeAtr + "' , ";
            sql += "'" + parCalidad.CodeAtrD + "' , ";
            sql += " " + parCalidad.Code + " , '+' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Actualiza_Linea_ATRP5(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [dbo].[@HDV_ATRP5] ";
            sql += "set U_Accion = '" + parCalidad.Code + "' ";
            sql += "where DocEntry = " + parCalidad.DocEntry.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Actualiza_Linea_ATRP9(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "update [dbo].[@HDV_ATRP9] ";
            sql += "set U_Accion = '" + parCalidad.Code + "' ";
            sql += "where DocEntry = " + parCalidad.DocEntry.ToString() + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }


        public string Agregar_Linea_ATRP9(cldCalidad parCalidad)
        {
            if (parCalidad.Code == "")
            {
                parCalidad.Code = "0";
            }

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_ATRP9] ( DocEntry , U_CodAtr , U_CodAtrD , U_DocEntry_Ref, U_Accion ) ";
            sql += "select " + parCalidad.DocEntry.ToString() + " , ";
            sql += "'" + parCalidad.CodeAtr + "' , ";
            sql += "'" + parCalidad.CodeAtrD + "' , ";
            sql += " " + parCalidad.Code + " , '+' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Agregar_Linea_ATRPA0(cldCalidad parCalidad)
        {

            string Respuesta = "";

            string sql;

            sql = "insert [dbo].[@HDV_ATRPA0] ( Code , Name , U_CodAtr , U_Id , U_Value ) ";
            sql += "select '" + parCalidad.DocEntry.ToString() + "' , ";
            sql += "'" + parCalidad.DocEntry.ToString() + "' , ";
            sql += "'" + parCalidad.CodeAtr + "' , ";
            sql += " " + parCalidad.LineId + " , ";
            sql += "'" + parCalidad.NameAtr + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

            Respuesta = "Y";

            return Respuesta;

        }

        public string Actualiza_Bins_Produccion(cldCalidad parCalidad)
        {
            string Respuesta = "";

            try
            {
                string sql;

                sql = "Update OITM ";
                sql += "Set U_ValRecPr = '' ";
                sql += "where ItmsGrpCod = 217 ";
                sql += "and U_ValRecPr IS NULL ";

                this.ComandoSql = sql;
                this.GestorSqlConsultar();

            }
            catch
            {

            }

            try
            {
                string sql;

                sql = "Update OITM ";

                if (parCalidad.Object_Ref == "I")
                {
                    sql += "Set U_ValRecPr = 'S' ";

                }
                else
                {
                    sql += "Set U_ValRecPr = 'N' ";

                }

                sql += "where ItemCode = '" + parCalidad.ItemCode + "' ";

                this.ComandoSql = sql;
                this.GestorSqlConsultar();

                Respuesta = "OK";
            }
            catch
            {
                Respuesta = "ERR";
            }

            return Respuesta;

        }

        public void Consulta_Guias_Calidad(string accion , string dato1, string dato2)
        {

            string sql;
            
            sql = "select ";
            sql += "t0.DocEntry , 0 as LineId , ";
            sql += "case when t0.U_TipoPesaje = 'E' then t0.U_NumGuia else t0.DocEntry end as U_NumGuia , t0.U_Patente , ";
            sql += "t0.U_CardCode , t0.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_CardCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_CardCode_D , ";
            sql += "coalesce ( ( select top 1 t1.U_CardName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_CardName_D , ";
            sql += "coalesce ( ( select top 1 t1.U_NumOC from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , 0 ) as U_NumOC , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' )  ";
            sql += "+ coalesce ( ( select top 1 ' ' + upper(ta6.Variedad_Lote) from vista_ProcesosProductivos ta6 where ta6.OrdenAfecta = t6.U_NumOC and ta6.TipoDocto = 'ConsumoProduccion' ) , '' )  ";
            sql += " as U_ItemName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCodeBins from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCodeBins , ";

            sql += "coalesce ( ( select sum(t1.U_CantidadBins) from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry ) , '' ) as U_CantidadBins , ";


            sql += "coalesce ( ( select top 1 t1.U_FechaPeso1 from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , '' ) as U_FechaPeso1 ,  ";
            sql += "coalesce ( ( select top 1 t1.U_PesoBruto from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , 0 ) as U_PesoBruto ,  ";
            sql += "coalesce ( ( select top 1 t1.U_PesoTara from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , 0 ) as U_PesoTara ,  ";
            sql += "coalesce ( ( select top 1 t1.U_PesoNeto from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , 0 ) as U_PesoNeto ,  ";
            //sql += "t0.U_FechaPeso1 , ";
            //sql += "t0.U_PesoBruto , "; 
            //sql += "t0.U_PesoTara , ";
            //sql += "t0.U_PesoNeto , ";
            sql += "t0.U_Obs , "; // t0.U_FechaPeso1 as Fechax , ";
            sql += "coalesce ( ( select top 1 t1.U_FechaPeso1 from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , '' ) as Fechax ,  ";
            sql += "coalesce ( ( select top 1 t1.U_FechaPeso2 from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , '' ) as U_FechaPeso2 , ";

            sql += "t0.U_DocEntry_Acceso , ";
            sql += "t0.U_Conductor , t0.U_CardCode_trans , t0.U_CardName_trans , ";

            sql += "coalesce ( ( select count(*) from [@HDV_ROM1] ta2 where ta2.DocEntry = t0.DocEntry ) , 0 ) as CantItms ,  ";

            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 inner join [@HDV_ROM1] ta2 on ta2.DocEntry = t0.DocEntry ";
            sql += "where ta1.U_Object_Ref = '100100' and ta1.U_DocEntry_Ref = ta2.DocEntry and ta1.U_LineId_Ref = ta2.LineId ";
            sql += " ) , 0 ) as CantRegistros_Calidad  ,  "; // and ta1.U_ItemCode = ta2.U_ItemCode

            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 inner join [@HDV_ROM1] ta2 on ta2.DocEntry = t0.DocEntry  ";
            sql += "where ta1.U_Object_Ref = '100100' and ta1.U_Estado = 'A' and ta1.U_DocEntry_Ref = ta2.DocEntry and ta1.U_LineId_Ref = ta2.LineId  ";
            sql += " ) , 0 ) as CantRegistros_Aprobados ,  "; // and ta1.U_ItemCode = ta2.U_ItemCode

            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 inner join [@HDV_ROM1] ta2 on ta2.DocEntry = t0.DocEntry ";
            sql += "where ta1.U_Object_Ref = '100100' and ta1.U_Estado = 'R' and ta1.U_DocEntry_Ref = ta2.DocEntry and ta1.U_LineId_Ref = ta2.LineId  ";
            sql += " ) , 0 ) as CantRegistros_Rechazados ,  "; // and ta1.U_ItemCode = ta2.U_ItemCode

            sql += "coalesce ( ( select top 1 ta1.DocEntry from [@HDV_ORCAL] ta1 ";
            sql += "where ta1.U_Object_Ref = '100100' and ta1.U_DocEntry_Ref = t0.DocEntry ";
            sql += "and ta1.U_LineId_Ref = 0 ) , 0 ) as DocEntry_Calidad , t0.CreateDate ";

            sql += " ";
            sql += " ";


            sql += "from [@HDV_OROM] t0 ";
            sql += "left join ( select tb1.DocEntry , coalesce ( ( select top 1 tb2.U_NumOC from [@HDV_ROM1] tb2 where tb2.DocEntry = tb1.DocEntry order by LineId ) , 0 ) as U_NumOC from [@HDV_OROM] tb1 ) t6 on t6.DocEntry = t0.DocEntry ";

            sql += "where t0.DocEntry in ( select DocEntry from [dbo].[@HDV_ROM2] where U_PesoBruto <> 0 ) ";
            sql += "and t0.U_TipoPesaje in ( 'I' , 'E' ) ";
            sql += "and t0.DocEntry > 10200 ";

            if (accion=="F1")
            {
                sql += "and t0.DocEntry in ( select t1.DocEntry from [dbo].[@HDV_ROM2] t1 where convert ( varchar(8) , t1.U_FechaPeso1 , 112 ) = '" + dato1 + "' ) ";
                //sql += "and convert ( varchar(8) , t0.U_FechaPeso1 , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and t0.DocEntry in ( select t1.DocEntry from [dbo].[@HDV_ROM2] t1 where convert ( varchar(8) , t1.U_FechaPeso1 , 112 ) between '" + dato1 + "' and '" + dato2 + "' ) ";
                //sql += "and convert ( varchar(8) , t0.U_FechaPeso1 , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "N")
            {
                sql += "and U_NumGuia = " + dato1 + " ";

            }
           
            if (accion == "P")
            {
                sql += "and  t0.DocEntry in ( select t1.DocEntry from [@HDV_ROM1] t1 where t1.U_CardCode = '" + dato1 + "' ) ";

            }

            if (accion == "X")
            {
                //sql += "and  t0.DocEntry in ( select t1.DocEntry from [@HDV_ROM1] t1 where t1.U_CardCode = '" + dato1 + "' ) ";

            }

            //sql += "order by t0.U_FechaPeso1 desc ";
            sql += "order by t0.DocEntry desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();
            
        }

        public void Consulta_Atributos_en_Blanco(string tipo_producto)
        {

            string sql, prefijo;

            prefijo = "xx";

            if (tipo_producto== "Almendra")
            {
                prefijo = "AL";

            }

            if (tipo_producto== "Ciruela")
            {
                prefijo = "CI";

            }

            if (tipo_producto == "Nuez")
            {
                prefijo = "NU";

            }

            sql = "select ";
            sql += "Code , U_NameAtr , U_UM , 0 as Minimo , 0 as Maximo  ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "where Code like '" + prefijo + "%' ";
            sql += "order by Code ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();


        }

        public void Consulta_romana9(string lote, int id_romana)
        {

            string sql;

            sql = "exec SAPB1_ROMANA9 '" + lote + "' , " + id_romana.ToString();

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Atributos_por_producto(string itemcode, string atributo_like)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_ItemCode , t0.U_ItemName , ";
            sql += "t0.U_ContraMu , t0.U_CoMuSize , ";
            sql += "t0.U_MuestDes , t0.U_MuDeSize , t0.U_Comment , ";
            sql += "t1.LineId , t1.VisOrder , ";
            sql += "t1.U_CodAtr , t1.U_NameAtr , U_Minimo , ";
            sql += "t1.U_Maximo , t1.U_TipoDef , ";
            sql += "t2.U_UM , t1.U_StandAtr , t2.U_Comment as GrupoAtr , ";

            sql += "case when substring(t0.U_ItemCode , 1 , 2 ) = 'FP' then case when substring(t0.U_ItemCode , 4 , 3 ) = 'NUE' ";
            sql += "then coalesce((select top 1 U_Muestra_Calidad_NUE_FP from[dbo].[@HDV_OPARAM] ) , 0 ) ";
            sql += "else coalesce((select top 1 U_Muestra_Calidad_ALM_FP from[dbo].[@HDV_OPARAM]) , 0 ) end else ";
            sql += "case when substring(t0.U_ItemCode , 4 , 3 ) = 'NUE' ";
            sql += "then coalesce((select top 1 U_Muestra_Calidad_NUE_FS from[dbo].[@HDV_OPARAM] ) , 0 )  ";
            sql += "else coalesce((select top 1 U_Muestra_Calidad_ALM_FS from[dbo].[@HDV_OPARAM]) , 0 ) end end as Contra_Muestra ";


            sql += "from [@HDV_OATRP] t0 ";
            sql += "inner join [@HDV_ATRP1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join [@HDV_OMATR] t2 on t2.Code = t1.U_CodAtr ";

            sql += "where U_ItemCode = '" + itemcode + "' ";
            sql += "and t1.U_NameAtr like '" + atributo_like + "' ";
            sql += "order by t1.VisOrder ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Atributos_de_Humedad(int id_Romana_Entry, int id_Romana_Id)
        {

            string sql;

            sql = "select ";
            sql += "t1.* ";
            sql += "from [@HDV_ORCAL] t0 ";
            sql += "inner join [@HDV_RCAL1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where U_DocEntry_Ref = " + id_Romana_Entry.ToString() + " ";
            sql += "and U_LineId_Ref = " + id_Romana_Id.ToString() + " ";
            sql += "and U_Object_Ref = '100100' ";
            sql += "order by t1.U_CodAtr ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Consumos_desde_OF(int nNumOF)
        {

            string sql;

            sql = "select * ";
            //sql += "Variedad_Lote , Calibre_Lote ";
            sql += "from vista_ProcesosProductivos ";
            sql += "where OrdenAfecta = " + nNumOF.ToString() + " ";
            sql += "and TipoDocto = 'ConsumoProduccion' ";
            sql += "and Calibre_Lote <> '' ";
            sql += "order by Lote ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Atributos_PP_producto(string U_Proceso)
        {

            string sql;

            if ((U_Proceso== "NCC L1") || (U_Proceso == "NCC L2"))
            {
                U_Proceso = "NCC L";
            }

            if ((U_Proceso == "Sorter 1") || (U_Proceso == "Sorter 2"))
            {
                U_Proceso = "Sorter";
            }
            
            if (U_Proceso == "Selección Nueces M")
            {
                U_Proceso = "Selección Nueces";
            }

            if ((U_Proceso == "Blanqueado") || (U_Proceso == "Blanqueado + Calibrado") || (U_Proceso == "Lavado") || (U_Proceso == "Lavado + Calibrado") || (U_Proceso == "Calibrado"))
            {
                U_Proceso = "NCC L";
            }

            if (U_Proceso == "Partidura Manual")
            {
                U_Proceso = "Cracker Nueces";
            }

            sql = "select ";
            sql += "t0.DocEntry , t0.Code , t0.U_NameAtr , t1.U_Comment , ";
            sql += "coalesce ( t0.U_UM , '' ) as U_UM , ";
            sql += "coalesce ( t1.U_Minimo , 0 ) as U_Minimo , ";
            sql += "coalesce ( t1.U_Maximo , 0 ) as U_Maximo  ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "inner join  [@HDV_ATRP1] t1 on t1.U_CodAtr = t0.Code ";
            sql += "where substring ( t0.Code , 1 , 1 ) = 'P' ";
            sql += "and t0.U_Comment = '" + U_Proceso + "' ";
            sql += "order by t0.Code  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Atributos_PP_producto_V2(string U_Proceso, string U_Variedad, string U_Calibre, string U_Variedad_Fruta)
        {

            string sql;

            if ((U_Proceso == "NCC L1") || (U_Proceso == "NCC L2"))
            {
                U_Proceso = "NCC L";
            }

            if ((U_Proceso == "Sorter 1") || (U_Proceso == "Sorter 2"))
            {
                U_Proceso = "Sorter";
            }

            if ((U_Proceso == "Limpieza Nueces"))
            {
                U_Proceso = "Sorter";
            }

            if ((U_Proceso == "Limpieza Almendra"))
            {
                U_Proceso = "Selección Almendras";
            }

            if (U_Proceso == "Desp & Secado")
            {
                U_Proceso = "Secado";
            }

            if (U_Proceso == "Selección Manual")
            {
                U_Proceso = "Selección Mecanica";
            }


            if ((U_Proceso == "Blanqueado") || (U_Proceso == "Blanqueado + Calibrado") || (U_Proceso == "Lavado") || (U_Proceso == "Lavado + Calibrado") || (U_Proceso == "Calibrado"))
            {
                U_Proceso = "NCC L";
            }

            if (U_Proceso == "Partidura Manual")
            {
                U_Proceso = "Cracker Nueces";
            }

            if ((U_Proceso == "Agup. Sem. Elab") || (U_Proceso == "Conversion"))
            {
                if (U_Variedad_Fruta == "ALMENDRA")
                {
                    U_Proceso = "Envasado Almendras";
                }
                else
                {
                    U_Proceso = "Agup. Sem. Elab";
                }

            }

            sql = "select ";
            sql += "t0.DocEntry , t0.Code , t0.U_NameAtr , t1.U_Comment , ";
            sql += "coalesce ( t0.U_UM , '' ) as U_UM , ";
            sql += "coalesce ( t1.U_Minimo , 0 ) as U_Minimo , ";
            sql += "coalesce ( t1.U_Maximo , 0 ) as U_Maximo , ";

            sql += "coalesce ( t2.U_Minimo , -1 ) as U_Minimo1 , ";
            sql += "coalesce ( t2.U_Maximo , -1 ) as U_Maximo1 , ";
            sql += "coalesce ( t2.U_Locked , '' ) as U_Locked1 , ";

            sql += "coalesce ( t3.U_Minimo , -1 ) as U_Minimo2 , ";
            sql += "coalesce ( t3.U_Maximo , -1 ) as U_Maximo2 , ";
            sql += "coalesce ( t3.U_Locked , '' ) as U_Locked2 ";

            sql += "from [@HDV_OMATR] t0 ";
            sql += "inner join  [@HDV_ATRP1] t1 on t1.U_CodAtr = t0.Code ";

            sql += "left join  ( select t1.U_CodAtr , t1.U_Minimo , t1.U_Maximo , t1.U_Locked ";
            sql += "from [@HDV_ATRP2] t0 ";
            sql += "inner join[@HDV_ATRP3] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.U_Comment = '" + U_Proceso + "' and t0.U_HDV_VARIEDAD = '" + U_Variedad + "' and t0.U_Calibre = '" + U_Calibre + "' ) t2 on t2.U_CodAtr = t1.U_CodAtr ";

            sql += "left join  ( select t1.U_CodAtr , t1.U_Minimo , t1.U_Maximo , t1.U_Locked ";
            sql += "from [@HDV_ATRP2] t0 ";
            sql += "inner join [@HDV_ATRP3] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.U_Comment = '" + U_Proceso + "' and t0.U_HDV_VARIEDAD = '' and t0.U_Calibre = '' ) t3 on t3.U_CodAtr = t1.U_CodAtr ";


            sql += "where substring ( t0.Code , 1 , 1 ) = 'P' ";
            sql += "and t0.U_Comment = '" + U_Proceso + "' ";
            sql += "order by t0.Code  ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Atributos_PP_producto_V3(int docentry , string lote)
        {

            string sql;

            sql = "exec SAPB1_ORCAL8 " + docentry + " , '" + lote + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP8(string cMatriz)
        {

            string sql;

            sql = "select Code , U_Proceso from [dbo].[@HDV_ATRP8] where U_Matriz = '" + cMatriz + "' order by U_Proceso ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP8_usuario(string cMatriz, int nUserId)
        {

            string sql;

            sql = "select ";
            sql += "t0.Code , t0.U_Proceso , ";
            sql += "coalesce ( ( select top 1 t1.Code FROM [@HDV_OPRM] t1 where t1.U_WhsCode = t0.Code and t1.U_UserSign = " + nUserId.ToString() + " ) , 0 ) as Code_Ref ";
            sql += "from [dbo].[@HDV_ATRP8] t0 where t0.U_Matriz = '" + cMatriz + "' order by t0.U_Proceso ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }


        public void Consulta_ATRP5l(string d_CodAtrD, string d_DocEntry_Ref)
        {

            if (d_DocEntry_Ref == "")
            {
                d_DocEntry_Ref = "0";

            }

            string sql;

            sql = "select ";
            sql += "t0.* , t1.U_NameAtr ";
            sql += "from [dbo].[@HDV_ATRP5] t0 ";
            sql += "inner join [dbo].[@HDV_ATRP1] t1 on t1.U_CodAtr = t0.U_CodAtrD ";
            sql += "where t0.U_CodAtr = '" + d_CodAtrD + "' ";
            
            sql += "and t0.U_DocEntry_Ref = " + d_DocEntry_Ref + " ";

            sql += "order by t0.U_DocEntry_Ref , t0.U_CodAtrD ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP9l(string d_CodAtrD, string d_DocEntry_Ref)
        {

            if (d_DocEntry_Ref == "")
            {
                d_DocEntry_Ref = "0";

            }

            string sql;

            sql = "select ";
            sql += "t0.* , t1.U_NameAtr ";
            sql += "from [dbo].[@HDV_ATRP9] t0 ";
            sql += "inner join [dbo].[@HDV_ATRP1] t1 on t1.U_CodAtr = t0.U_CodAtrD ";
            sql += "where t0.U_CodAtr = '" + d_CodAtrD + "' ";

            sql += "and t0.U_DocEntry_Ref = " + d_DocEntry_Ref + " ";

            sql += "order by t0.U_DocEntry_Ref , t0.U_CodAtrD ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRPA0(string d_CodAtrD)
        {

            string sql;

            sql = "select ";
            sql += "t0.* ";
            sql += "from [dbo].[@HDV_ATRPA0] t0 ";
            sql += "where t0.U_CodAtr = '" + d_CodAtrD + "' ";
            sql += "order by t0.U_Id ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_ATRP5l()
        {

            string sql;

            sql = "select max(DocEntry) as DocEntry from [@HDV_ATRP5] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_ATRP9l()
        {

            string sql;

            sql = "select max(DocEntry) as DocEntry from [@HDV_ATRP9] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_ATRPA0l(string d_CodAtr)
        {

            string sql;

            sql = "select max(U_Id) as U_Id from [@HDV_ATRPA0] where U_CodAtr = '" + d_CodAtr + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_ATRPA0x()
        {

            string sql;

            sql = "select max(Code) as Code from [@HDV_ATRPA0] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP5l_plus(string cMatriz, string d_CodAtrD, string d_DocEntry_Ref)
        {
            if (d_DocEntry_Ref == "")
            {
                d_DocEntry_Ref = "0";

            }

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_NameAtr as NameMaster , ";
            sql += "t1.LineId , t1.U_CodAtr , t1.U_NameAtr , ";
            sql += "t1.U_Metodo as U_UM , t1.Object , ";
            sql += "coalesce(t1.U_Minimo , 0) as U_Minimo , ";
            sql += "coalesce(t1.U_Maximo , 0) as U_Maximo , ";
            sql += "t1.U_StandAtr as U_Standard ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "left join[@HDV_ATRP1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry = '" + cMatriz + "' ";

            //sql += "and t1.Object = 'D' ";
            sql += "and t1.U_CodAtr not in ( select t0.U_CodAtrD  from [dbo].[@HDV_ATRP5] t0 where t0.U_CodAtr = '" + d_CodAtrD + "' and t0.U_DocEntry_Ref = " + d_DocEntry_Ref + " ) ";

            sql += "order by t1.U_CodAtr , t1.U_NameAtr ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP9l_plus(string cMatriz, string d_CodAtrD, string d_DocEntry_Ref)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_NameAtr as NameMaster , ";
            sql += "t1.LineId , t1.U_CodAtr , t1.U_NameAtr , ";
            sql += "t1.U_Metodo as U_UM , t1.Object , ";
            sql += "coalesce(t1.U_Minimo , 0) as U_Minimo , ";
            sql += "coalesce(t1.U_Maximo , 0) as U_Maximo , ";
            sql += "t1.U_StandAtr as U_Standard ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "left join[@HDV_ATRP1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry = '" + cMatriz + "' ";

            //sql += "and t1.Object = 'D' ";

            sql += "order by t1.U_CodAtr , t1.U_NameAtr ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_ATRP8l(string cMatriz)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_NameAtr as NameMaster , ";
            sql += "t1.LineId , t1.U_CodAtr , t1.U_NameAtr , ";
            sql += "t1.U_Metodo as U_UM , t1.Object , ";
            sql += "coalesce(t1.U_Minimo , 0) as U_Minimo , ";
            sql += "coalesce(t1.U_Maximo , 0) as U_Maximo , ";
            sql += "t1.U_StandAtr as U_Standard , ";
            sql += "coalesce ( ( select count(*) as Cant from [dbo].[@HDV_ATRP5] t2 where t2.U_CodAtr = t1.U_CodAtr ) ,0 ) as Fx_Detalle ,  ";
            sql += "coalesce ( ( select count(*) as Cant from [dbo].[@HDV_ATRP9] t2 where t2.U_CodAtr = t1.U_CodAtr ) ,0 ) as Fx_Porcentaje , ";
            sql += "t1.U_TipoMues as Fx_Orden_X  , coalesce ( ( select count(*) as Cant from [dbo].[@HDV_ATRPA0] t2 where t2.U_CodAtr = t1.U_CodAtr ) ,0 ) as Fx_ValTabla_X , ";
            //sql += "case when t1.U_CodAtr in ( 'PQ_1_0.1', 'PQ_1_0.2', 'PQ_1_0.3', 'PQ_1_001', 'PQ_1_002', 'PT_1_0.1', 'PT_1_0.2', 'PT_1_0.3', 'PT_1_001', 'PT_1_002', 'PO_1_001', 'PO_1_002', 'PO_1_003', 'PO_1_004', 'PO_1_005', 'PO_1_006', 'PO_1_007', 'PO_1_100' ) then 'C' else '' end as Ref_Calibre  ";
            sql += "case when t1.U_TipoDef = 'A' then 'C' else '' end as Ref_Calibre  ";

            sql += "from [@HDV_OMATR] t0 ";
            sql += "left join [@HDV_ATRP1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocEntry = '" + cMatriz + "' ";
            sql += "order by t1.U_CodAtr , t1.U_NameAtr ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Registro_Inspeccion(int DocEntry)
        {
            string sql;

            sql = "exec SAPB1_ORCAL1 " + DocEntry + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Registro_Inspeccion_x_orden(int DocNum)
        {
            string sql;

            sql = "exec SAPB1_ORCAL1v1 " + DocNum + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Nuevo_Registro_Inspeccion()
        {
            string sql;

            sql = "select max(DocEntry) as DocEntry from [@HDV_ORCAL] ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Nuevo_Registro_OFUM()
        {
            string sql;

            sql = "select top 1 DocEntry as DocEntry from [@HDV_OFUM] order by LogInst  desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Registros_Inspeccion(string accion, string dato1, string dato2)
        {

            string sql;

            sql = "select ";
            sql += "case when t0.U_Object_Ref = '100100' then 'Inspección de Humedad MP'  ";
            sql += "     when t0.U_Object_Ref = '100500' then 'Inspección de Materia Prima'  ";
            sql += "     when t0.U_Object_Ref = '59' then 'Inspección de Productos en Proceso' end as TipoRegistro , ";
            sql += " ";

            sql += "t0.DocEntry , t0.U_ItemCode , t0.U_ItemName ,  ";
            sql += "t0.Creator , t0.U_WhsCode , t0.U_WhsDest , ";
            sql += "t0.U_NumTras , t0.U_NumCon , t0.U_NoLote , ";
            sql += "t0.U_Cantidad , t0.U_Bultos , t0.U_BultosMu ,  ";
            sql += "t0.U_FecIngr , t0.U_UM , t0.U_NoDoc ,  ";
            sql += "t0.U_Estado , t0.U_ContraMu , t0.U_CoMuSize ,  ";
            sql += "t0.U_MuestDes , t0.U_MuDeSize , t0.U_Comment ,  ";
            sql += "t0.U_Object_Ref , t0.U_DocEntry_Ref  ";

            sql += "from [dbo].[@HDV_ORCAL] t0 ";

            sql += " ";
            sql += " ";
            sql += " ";
            sql += " ";


            if (accion == "F1")
            {
                sql += "where convert ( varchar(8) , t0.U_FecIngr , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "where convert ( varchar(8) , t0.U_FecIngr , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "R1")
            {
                sql += "where U_Object_Ref = '" + dato1 + "' and U_DocEntry_Ref = " + dato2 + " ";

            }

            sql += "order by t0.U_FecIngr desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Recepcion_MP_Calidad(string accion, string dato1, string dato2, string c_anhoactual)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry  , t1.U_NumGuia , t2.DocEntry , t2.LineId ,  ";
            //sql += "t0.DocEntry  , t3.FolioNum as U_NumGuia , t2.DocEntry , t2.LineId ,  ";
            sql += "t2.U_ItemCode , t2.U_ItemName , t2.U_BaseObject ,  ";
            sql += "t2.U_BaseLine , t2.U_CardCode , t2.U_CardName , t2.U_Cantidad ,  ";
            sql += "t4.MdAbsEntry  , t5.BaseDocNum , t0.CreateDate , t0.U_RomanaEntry , ";

            sql += "1 as CantItems , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100500' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineId ) , 0 ) as CantRegistros_Calidad ,  ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100500' and ta1.U_Estado = 'A' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineId ) , 0 ) as CantRegistros_Aprobados , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100500' and ta1.U_Estado = 'R' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineId ) , 0 ) as CantRegistros_Rechazados , ";
            sql += "coalesce ( ( select top 1 ta1.DocEntry from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100500' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineId ) , 0 ) as id_Calidad  , ";
            sql += "case when t2.U_ItemCode in ( 'FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.02' , 'FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.02' , 'FS.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.03' , 'FS.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.NUE.SE.DESP.XXX.X.XXX-XXX.XXX.G.0001K.01'  ) then 'SI' else 'NO' end as PELON ";

            sql += "from [@HDV_OPDX] t0 ";
            sql += "inner join [@HDV_OROM] t1 on t1.DocEntry = t0.U_RomanaEntry and t1.U_TipoPesaje = 'E' ";
            sql += "inner join [@HDV_PDX1] t2 on t2.DocEntry = t0.DocEntry  ";
            sql += "inner join OPDN t3 on t3.DocEntry = t2.U_BaseLine  ";
            sql += "left join ( select ta0.DocEntry , ta1.MdAbsEntry  ";
            sql += "FROM OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry ";
            sql += "WHERE ta0.DocType = 20 ) t4 on t4.DocEntry = t3.DocEntry   ";
            sql += "inner join PDN1 t5 on t5.DocEntry = t3.DocEntry ";

            sql += "where t0.DocEntry = t0.DocEntry ";

            if (accion == "F1")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "N")
            {
                sql += "and t1.U_NumGuia = " + dato1 + " ";

            }

            if (accion == "P")
            {
                sql += "and  t2.U_CardCode = '" + dato1 + "' ";

            }

            if (accion == "X")
            {
                if (c_anhoactual == "S")
                {
                    sql += "and year(t0.CreateDate) = year(getdate()) ";

                }
                //sql += "and  t2.U_CardCode = '" + dato1 + "' ";

            }

            sql += "order by t0.CreateDate desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();
            

        }

        public void Consulta_Recepcion_MP_Calidad_Secado(string accion, string dato1, string dato2)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry  , t0.FolioNum , t2.DocEntry , t2.LineNum ,  t2.ItemCode , t2.Dscription as ItemName ,  ";
            sql += "t0.CardCode , t0.CardName , t2.Quantity ,  t4.MdAbsEntry  , 1 as CantItems , t0.CreateDate , t2.BaseRef , ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Calidad ,   ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_Estado = 'A' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Aprobados ,  ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_Estado = 'R' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Rechazados ,  ";
            sql += "coalesce((select top 1 ta1.DocEntry from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as id_Calidad , ";
            sql += "t0.U_DTE_Booking , t6.OrdenAfecta , t6.Lote , ";
            sql += "coalesce ( ( select top 1 ta3.DocEntry from [@HDV_ORCAL] ta3 where ta3.U_NoLote = t6.Lote order by ta3.DocEntry desc ) , 0 ) as id_Calidad2 , ";
            sql += "coalesce ( ( select top 1 ta3.U_Estado from [@HDV_ORCAL] ta3 where ta3.U_NoLote = t6.Lote order by ta3.DocEntry desc ) , '' ) as estado_calidad2 , ";
            sql += "t6.NumeroDocto as DocEntry_TR , t6.ItemCode as ItemCode_TR ";
            sql += " ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t2 on t2.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry , ta1.MdAbsEntry FROM OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry WHERE ta0.DocType = 20 ) t4 on t4.DocEntry = t2.DocEntry ";
            sql += "inner join PDN1 t5 on t5.DocEntry = t2.DocEntry ";
            sql += "left join  vista_ProcesosProductivos t6 on t6.NumeroDocto = t0.U_DTE_Booking and t6.TipoDocto = 'ReporteProduccion' ";

            sql += "where t0.DocEntry = t0.DocEntry ";
            sql += "and t0.U_DTE_Booking <> '' ";
            sql += "and year(t0.DocDate) <= 2020 ";

            if (accion == "F1")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "N")
            {
                sql += "and t0.FolioNum = " + dato1 + " ";

            }

            if (accion == "P")
            {
                sql += "and t0.CardCode = '" + dato1 + "' ";

            }

            if (accion == "X")
            {
                //sql += "and  t2.U_CardCode = '" + dato1 + "' ";
                sql += "and year ( t0.CreateDate ) = 2020 ";

            }


            sql += "order by t0.CreateDate desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();


        }

        public void Consulta_Partidas_dys_humedad(string d_accion , string d_valor)
        {
            string sql;

            sql = "exec xSapb1_utiles_resumen_dys '" + d_accion + "' , '" + d_valor + "'";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Recepcion_MP_Calidad_Secado_dys(string accion, string dato1, string dato2)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry  , t0.FolioNum , t2.DocEntry , t2.LineNum ,  t2.ItemCode , t2.Dscription as ItemName ,  ";
            sql += "t0.CardCode , t0.CardName , t2.Quantity ,  t4.MdAbsEntry  , 1 as CantItems , t0.CreateDate , t2.BaseRef , ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Calidad ,   ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_Estado = 'A' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Aprobados ,  ";
            sql += "coalesce((select count(*) from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_Estado = 'R' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as CantRegistros_Rechazados ,  ";
            sql += "coalesce((select top 1 ta1.DocEntry from[@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100502' and ta1.U_DocEntry_Ref = t2.DocEntry and ta1.U_LineId_Ref = t2.LineNum) , 0 ) as id_Calidad , ";
            sql += "t0.U_DTE_Booking , t6.OrdenAfecta , t6.Lote , ";
            sql += "coalesce ( ( select top 1 ta3.DocEntry from [@HDV_ORCAL] ta3 where ta3.U_NoLote = t6.Lote order by ta3.DocEntry desc ) , 0 ) as id_Calidad2 , ";
            sql += "coalesce ( ( select top 1 ta3.U_Estado from [@HDV_ORCAL] ta3 where ta3.U_NoLote = t6.Lote order by ta3.DocEntry desc ) , '' ) as estado_calidad2 , ";
            sql += "t6.NumeroDocto as DocEntry_TR , t6.ItemCode as ItemCode_TR , UPPER ( t2.U_HDV_VARIEDAD ) as Variedad_pdn1 , ";
            sql += "t7.U_CantidadBins * coalesce ( (select case when ta1.U_CantidadBins = 0 then 0 else ta1.U_PesoGuia / ta1.U_CantidadBins end from [@HDV_OROM] ta1 where ta1.DocEntry =  t0.FolioNum ) , 0 ) as Peso_GT ";
            sql += " ";

            sql += "from OPDN t0 ";
            sql += "inner join PDN1 t2 on t2.DocEntry = t0.DocEntry ";
            sql += "left join ( select ta0.DocEntry , ta1.MdAbsEntry FROM OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry WHERE ta0.DocType = 20 ) t4 on t4.DocEntry = t2.DocEntry ";
            sql += "inner join PDN1 t5 on t5.DocEntry = t2.DocEntry ";
            //sql += "left join  vista_ProcesosProductivos t6 on t6.NumeroDocto = t0.U_DTE_Booking and t6.TipoDocto = 'ReporteProduccion' ";
            //sql += "inner join  vista_ProcesosProductivos t6 on t6.ItemCode like 'FS.NUE%' and year(t6.DocDate) >= year(getdate()) and t6.TipoDocto = 'ReporteProduccion' "; // and t6.Lote = t0.FolioNum ";
            sql += "inner join  vista_ProcesosProductivos t6 on t6.ItemCode like 'FS.NUE%' and t6.TipoDocto = 'ReporteProduccion' "; // and t6.Lote = t0.FolioNum ";
            sql += "inner join [@HDV_ROM1] t7 with (nolock) on t7.Object = t6.Lote and t7.U_OPDN_DocEntry = t0.DocEntry "; 

            sql += "where t0.DocEntry = t0.DocEntry ";
            //sql += "and t0.U_DTE_Booking <> '' ";
            
            //sql += "and year(t0.DocDate) >= year(getdate()) ";

            if (accion == "F1")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and convert ( varchar(8) , t0.CreateDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "N")
            {
                sql += "and t0.FolioNum = " + dato1 + " ";

            }

            if (accion == "P")
            {
                sql += "and t0.CardCode = '" + dato1 + "' ";

            }

            if (accion == "X")
            {
                //sql += "and  t2.U_CardCode = '" + dato1 + "' ";
                //sql += "and year ( t0.CreateDate ) = 2020 ";
                sql += "and year(t0.DocDate) >= year(getdate())-1 ";

            }

            sql += "order by t0.CreateDate desc , t0.DocNum ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();


        }

        public void Consulta_Recepcion_PP_Calidad(string accion, string cProceso, string dato1, string dato2, string anhoactual)
        {

            string sql;

            sql = "select  ";
            sql += "t1.DocEntry , t1.LineNum , t1.BaseEntry , t1.BaseLine ,  ";
            sql += "t0.DocDate , t1.ItemCode , t1.Dscription , t1.Quantity ,  ";
            sql += "t1.WhsCode , t0.Comments , t1.ObjType , t4.MdAbsEntry ,   ";
            sql += "t5.MnfSerial as CodProd , t5.U_NOMBPROD , ";
            sql += "t5.LotNumber as CodCli , t5.U_NOMBCLI , t5.U_Calibre , t5.U_HDV_COLOR  , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_NoLote = t4.MdAbsEntry  ) , 0 ) as Cant_Registros , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'A' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Aprobado , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'R' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Rechazado , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'Q' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Reparos , ";
            //sql += "coalesce ( ( select top 1 ta0.DocEntry from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_NoLote = t4.MdAbsEntry  order by ta0.DocEntry desc ) , 0 ) as id_Calidad ";
            sql += "t8.DocEntry as id_Calidad , t8.U_Estado ";

            sql += "from OIGN t0  ";
            sql += "inner join IGN1 t1 on t1.DocEntry = t0.DocEntry  ";
            //sql += "inner join ( select ta0.DocEntry , ta1.MdAbsEntry FROM OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry WHERE ta0.DocType = 59 ) t4 on t4.DocEntry = t1.DocEntry  ";
            sql += "inner join ( select NumeroDocto as DocEntry , Lote as MdAbsEntry from vista_ProcesosProductivos where TipoDocto = 'ReporteProduccion' ) t4 on t4.DocEntry = t1.DocEntry  ";
                           
            sql += "inner join OBTN t5 on t5.DistNumber =  t4.MdAbsEntry  ";
            sql += "inner join OWOR t7 on t7.DocEntry =  t1.BaseEntry and t7.U_Proceso like '" + cProceso + "' ";

            sql += "left join [@HDV_ORCAL] t8 on t8.U_NoLote = t5.DistNumber and t8.U_WhsCode = t1.WhsCode ";

            sql += "where t1.ItemCode not in ( 'FP.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FS.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.ALM.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FS.ALM.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01'  ) ";

            if ((accion != "N") && (accion != "L"))
            {
                if (anhoactual == "S")
                {
                    sql += "and year ( t0.DocDate ) = year(getdate())  ";

                }

            }


            if (accion == "F1")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "R2")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";
                sql += "and t8.U_Estado = 'R' ";

            }

            if (accion == "N")
            {
                sql += "and t1.BaseEntry = " + dato1 + " ";

            }

            if (accion == "P")
            {
                sql += "and t5.MnfSerial = '" + dato1 + "' ";

            }

            if (accion == "L")
            {
                sql += "and t5.DistNumber = '" + dato1 + "' ";

            }

            if (accion == "X")
            {
                if (anhoactual == "S")
                {
                    sql += "and year(t0.DocDate) = year(getdate()) ";

                }

                sql += "and t1.DocEntry not in ( select ta0.U_DocEntry_Ref from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_Estado in ( 'A' , 'R' , 'Q' ) ) ";

            }

            sql += "order by t1.BaseEntry ,  t4.MdAbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void consulta_utiles_resumen_Calibres(string d_accion , string d_fecha1, string d_fecha2)
        {

            string sql;

            sql = "exec xSapb1_utiles_resumen_Calibres '" + d_accion + "' , '" + d_fecha1 + "' , '" + d_fecha2 + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Recepcion_PP_Calidad_V(string accion, string dato1)
        {

            string sql;

            sql = "exec xSapb1_utiles_informeordenventa_calidad '" + accion + "' , " + dato1 + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_OCERNV(string d_docnum, string d_itemcode)
        {

            string sql;

            sql = "SELECT top 1 * from [dbo].[@HDV_OCERNV] where U_DocNum = " + d_docnum + " and U_ItemCode = '" + d_itemcode + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_OCERNV()
        {

            string sql;

            sql = "SELECT max(convert(int, Code)) as Code from [dbo].[@HDV_OCERNV] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Sapb1_query_vistacalidad_ncc(int num_ov)
        {

            string sql;

            sql = "exec xSapb1_query_vistacalidad_ncc '' , " + num_ov + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_PT(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_PT '" + lote + "' , '" + accion + "' , '" + tipo_fruta + "' , '" + ciclo_estricto + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_PT_CSG(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_PT_CSG '" + lote + "' , '" + accion + "' , '" + tipo_fruta + "' , '" + ciclo_estricto + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_MP(string lote, string accion , string tipo_fruta, string ciclo_estricto)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_MP '" + lote + "' , '" + accion + "' , '" + tipo_fruta + "' , '" + ciclo_estricto + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_MP_CSG(string lote, string accion, string tipo_fruta, string ciclo_estricto)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_MP_CSG '" + lote + "' , '" + accion + "' , '" + tipo_fruta + "' , '" + ciclo_estricto + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_INS(string lote, string accion)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_INS '" + lote + "' , '" + accion + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_INF_TRAZABILIDAD_INS_CSG(string lote, string accion)
        {

            string sql;

            sql = "exec SAPB1_INF_TRAZABILIDAD_INS_CSG '" + lote + "' , '" + accion + "' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_historial_fumigacion(string lote)
        {

            string sql;

            sql = "select * from [@HDV_OFUMI] where DistNumber = '" + lote + "' order by LineId Desc ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Recepcion_PP_Calidad_R(string accion, string cProceso, string dato1, string dato2)
        {

            string sql;

            sql = "select  ";
            sql += "t1.DocEntry , t1.LineNum , t1.BaseEntry , t1.BaseLine ,  ";
            sql += "t0.DocDate , t1.ItemCode , t1.Dscription , t1.Quantity ,  ";
            sql += "t1.WhsCode , t0.Comments , t1.ObjType , t4.MdAbsEntry ,   ";
            sql += "t5.MnfSerial as CodProd , t5.U_NOMBPROD , ";
            sql += "t5.LotNumber as CodCli , t5.U_NOMBCLI , t5.U_Calibre , t5.U_HDV_COLOR  , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_NoLote = t4.MdAbsEntry  ) , 0 ) as Cant_Registros , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'A' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Aprobado , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'R' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Rechazado , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_Estado = 'Q' and ta0.U_NoLote = t4.MdAbsEntry and ta0.DocEntry = t8.DocEntry ) , 0 ) as Cant_Reparos , ";
            //sql += "coalesce ( ( select top 1 ta0.DocEntry from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_DocEntry_Ref = t1.DocEntry and ta0.U_LineId_Ref = t1.LineNum and ta0.U_NoLote = t4.MdAbsEntry  order by ta0.DocEntry desc ) , 0 ) as id_Calidad ";
            sql += "t8.DocEntry as id_Calidad , t8.U_Estado ";

            sql += "from OIGN t0  ";
            sql += "inner join IGN1 t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "inner join ( select ta0.DocEntry , ta1.MdAbsEntry  ";
            sql += "FROM OITL ta0 INNER JOIN ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry   ";
            sql += "WHERE ta0.DocType = 59 ) t4 on t4.DocEntry = t1.DocEntry  ";
            sql += "inner join OBTN t5 on t5.AbsEntry =  t4.MdAbsEntry  ";
            sql += "inner join OWOR t7 on t7.DocEntry =  t1.BaseEntry and t7.U_Proceso like '" + cProceso + "' ";

            sql += "inner join vista_lotescalidad t8 on t8.NoLote = t5.DistNumber and t8.U_WhsCode = t1.WhsCode ";

            sql += "where t1.ItemCode not in ( 'FP.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FS.ALM.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.ALM.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FS.ALM.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01'  ) ";
            sql += "and year ( t0.DocDate ) >= 2018  ";

            if (accion == "F1")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) = '" + dato1 + "' ";

            }

            if (accion == "F2")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";

            }

            if (accion == "R2")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) between '" + dato1 + "' and '" + dato2 + "' ";
                sql += "and t8.AnalisisCalidad = 'Rechazado'  ";

            }

            if (accion == "N")
            {
                sql += "and t1.BaseEntry = " + dato1 + " ";

            }

            if (accion == "P")
            {
                sql += "and t5.MnfSerial = '" + dato1 + "' ";

            }

            if (accion == "X")
            {
                sql += "and convert ( varchar(8) , t0.DocDate , 112 ) >= '" + dato1 + "' ";
                sql += "and t1.DocEntry not in ( select ta0.U_DocEntry_Ref from [@HDV_ORCAL] ta0 where ta0.U_Object_Ref = '59' and ta0.U_Estado in ( 'A' , 'R' , 'Q' ) ) ";

            }

            sql += "order by t1.BaseEntry ,  t4.MdAbsEntry ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Reg_Auditoria_Registros_Inspeccion(int DocEntry, string d_Lote)
        {

            string sql;

            if (d_Lote == "0")
            {
                sql = "select ";
                sql += "t0.DocEntry, t0.LineId, t0.U_UserId,  ";
                sql += "t1.U_NAME ,  ";
                sql += "t0.U_Fecha, t0.U_Accion ";
                sql += "from [@HDV_RCAL2] t0 ";
                sql += "left join OUSR t1 on t1.USERID = t0.U_UserId ";
                sql += "Where t0.DocEntry = " + DocEntry + " ";
                //sql += "Where t0.U_Lote = '" + d_Lote + "' ";

                //sql += "order by t0.LineId ";

                sql += "union all  ";

            }
            else
            {
                sql = "select ";
                sql += "t0.DocEntry, t0.LineId, t0.U_UserId,  ";
                sql += "t1.U_NAME ,  ";
                sql += "t0.U_Fecha, t0.U_Accion ";
                sql += "from [@HDV_RCAL2] t0 ";
                sql += "left join OUSR t1 on t1.USERID = t0.U_UserId ";
                //sql += "Where t0.DocEntry = " + DocEntry + " ";
                sql += "Where t0.U_Lote = '" + d_Lote + "' ";

                //sql += "order by t0.LineId ";

                sql += "union all  ";

            }

            sql += "select ";
            sql += "t3.U_DocEntry_Acceso , 0 , t3.UserSign , t2.U_NAME , ";
            sql += "coalesce((select top 1 t4.U_FechaPeso1 from[@HDV_ROM2] t4 where t4.DocEntry = t3.DocEntry order by t4.U_FechaPeso1) , '' ) as Fecha_Creacion , 'Ingreso a Romana' ";
            sql += "from [@HDV_ORCAL] t0 ";
            sql += "inner join [@HDV_OACC] t1 on t1.DocEntry = t0.U_DocEntry_Ref ";
            sql += "inner join [@HDV_OROM] t3 on t3.U_DocEntry_Acceso = t1.DocEntry ";
            sql += "left join OUSR t2 on t2.USERID = t3.UserSign ";
            sql += "where t0.DocEntry =  " + DocEntry + " ";
            sql += "and t0.U_Object_Ref = '100100' ";

            sql += "union all ";

            sql += "select ";
            sql += "t1.DocEntry , 0 , t1.UserSign , t2.U_NAME ,  t0.CreateDate , 'Ingreso a Porteria'  ";
            sql += "from [@HDV_ORCAL] t0 ";
            sql += "inner join [@HDV_OACC] t1 on t1.DocEntry = t0.U_DocEntry_Ref ";
            sql += "left join OUSR t2 on t2.USERID = t1.UserSign  ";
            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.U_Object_Ref = '100100' ";

            sql += "order by U_Fecha ";

            sql += " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Analisis_x_Cliente(string CardCode)
        {

            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.UserSign , t3.U_NAME , t2.U_NumGuia , ";
            sql += "t1.U_CardCode , t1.U_CardName , t2.U_Patente , ";
            sql += "t2.U_Conductor , t0.CreateDate , t0.CreateTime , t1.U_NumOC , ";
            sql += "t0.U_ItemCode , t0.U_ItemName ,  ";
            sql += "t0.U_FecIngr , t0.U_TipResul , t0.U_DocEntry_Ref , t0.U_LineId_Ref , t2.U_PesoGuia ";
            sql += "from[@HDV_ORCAL] t0 ";
            sql += "inner join[@HDV_ROM1] t1 on t1.DocEntry = t0.U_DocEntry_Ref and t1.LineId = t0.U_LineId_Ref ";
            sql += "inner join[@HDV_OROM] t2 on t2.DocEntry = t1.DocEntry ";
            sql += "left join OUSR t3 on t3.USERID = t0.UserSign ";
            sql += "where U_Object_Ref = '100100' ";
            sql += "and t1.U_CardCode = '" + CardCode + "' ";
            sql += "order by t0.U_FecIngr ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void xSapb1_utiles_resumendespelonado(string CardCode, string accion, int anho)
        {

            string sql;

            sql = "exec xSapb1_utiles_resumendespelonado '" + CardCode + "' , '" + accion + "', " + anho;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Avance_x_id(int id_docentry, int nLineId, string cLote, string c_objtype)
        {
            string sql;

            sql = "exec SAPB1_AVANCE " + id_docentry + " , " + nLineId + " , '" + cLote + "' , " + c_objtype + " ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_max_ATRP8()
        {
            string sql;

            sql = "select max(convert(int,Code)) as mCode from [dbo].[@HDV_ATRP8] ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Registro_Referencia_PT_Seco(int id_docentry)
        {
            string sql;

            sql = "select ";
            sql += "t1.DocEntry , U_DocEntry_Ref ";
            sql += "from[@HDV_ORCAL] t0 ";
            sql += "inner join OPDN t1 on t1.U_DTE_Booking = t0.U_DocEntry_Ref ";
            sql += "WHERE t0.DocEntry = " + id_docentry;


            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_ORCAL8(int id_docentry, string cLote, string codatr, double medicion)
        {

            string sql;
            string cMedicion;

            try
            {
                cMedicion = medicion.ToString();
            }
            catch
            {
                cMedicion = "0";
            }

            cMedicion = cMedicion.Replace(",", ".");

            sql = "exec SAPB1_ORCAL8v1 " + id_docentry + " , '" + cLote + "' , '" + codatr + "' , " + cMedicion;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_ORCALA1(int id_docentry, int id_tipoanalisis)
        {
            string sql;

            sql = "exec SAPB1_ORCALA1 " + id_docentry + " , " + id_tipoanalisis;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void SAPB1_RECEPCION5(int id_docentry, int id_docentry_t)
        {
            string sql;

            sql = "exec SAPB1_RECEPCION5 " + id_docentry + " , " + id_docentry_t;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Consumo_x_id(int id_docentry, int nLineId, string cLote)
        {
            string sql;

            sql = "exec SAPB1_CONSUMO " + id_docentry + " , " + nLineId + " , '" + cLote + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Datos_Entrada_x_id(int id_docentry, string d_object, string d_lote)
        {
            string sql;

            sql = "exec SAPB1_OPRODUCCION " + id_docentry + " , '' , '" + d_object + "' , '" + d_lote + "'";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos()
        {

            string sql;

            sql = "select ";
            sql += "FldValue , Descr ";
            sql += "from UFD1 ";
            sql += "Where TableID = 'OWOR' ";
            sql += "and FieldID = 8 ";
            sql += "order by IndexID ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos1()
        {

            string sql;

            sql = "select ";
            sql += "t0.Code , t1.U_NameAtr  ";
            sql += "from [dbo].[@HDV_ATRP7] t0 ";
            sql += "inner join [@HDV_OMATR] t1 on t1.DocEntry = t0.Code ";
            sql += "where t0.Code <> 461 ";

            sql += "order by t0.Code ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos2()
        {

            string sql;

            sql = "select ";
            sql += "FldValue , Descr ";
            sql += "from UFD1 ";
            sql += "Where TableID = 'OWOR' ";
            sql += "and FieldID = 8 ";
            sql += "and FldValue NOT IN ( select U_Proceso from [@HDV_ATRP8] ) ";
            sql += "order by IndexID ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos_x_items(string cProceso)
        {

            string sql;

            sql = "select ";
            sql += "t0.Code , t0.U_NameAtr , ";
            sql += "coalesce ( t1.U_StandAtr , 0 ) as U_StandAtr , ";
            sql += "coalesce ( t1.U_Minimo , 0 ) as U_Minimo ,  ";
            sql += "coalesce ( t1.U_Maximo , 0 ) as U_Maximo ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "left join [@HDV_ATRP1] t1 on t1.U_CodAtr = t0.Code ";
            sql += "where t0.U_Comment = '" + cProceso + "' ";
            sql += "order by t0.Code ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos_x_items_V2(string cProceso, string cVariedad, string cCalibre)
        {

            string sql;

            sql = "select ";
            sql += "t1.* , t2.U_NameAtr ";
            sql += "from [@HDV_ATRP2] t0 ";
            sql += "inner join [@HDV_ATRP3] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "left join [@HDV_OMATR] t2 on t2.Code = t1.U_CodAtr ";
            sql += "where t0.U_Comment = '" + cProceso + "' ";
            sql += "and t0.U_HDV_VARIEDAD = '" + cVariedad + "' ";
            sql += "and t0.U_Calibre = '" + cCalibre + "' ";
            sql += "order by t1.U_CodAtr ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos_x_items_V3(string cProceso)
        {
            if (cProceso == "Desp & Secado")
                cProceso = "Secado";

            string sql;

            sql = "select ";
            sql += "t1.U_Comment ";
            sql += "from [@HDV_OMATR] t0 ";
            sql += "left join [@HDV_ATRP1] t1 on t1.U_CodAtr = t0.Code ";
            sql += "where t0.U_Comment = '" + cProceso + "' ";
            sql += "group by t1.U_Comment ";
            sql += "order by t1.U_Comment ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void ConsultaLista_Procesos_x_items_V4(string cProceso, string cVariedad, string cCalibre)
        {

            string sql;

            sql = "select ";
            sql += "t1.* ";
            sql += "from [@HDV_ATRP2] t0 ";
            sql += "inner join [@HDV_ATRP4] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.U_Comment = '" + cProceso + "' ";
            sql += "and t0.U_HDV_VARIEDAD = '" + cVariedad + "' ";
            sql += "and t0.U_Calibre = '" + cCalibre + "' ";
            sql += "order by t1.U_Comment ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public string SAPB1_ORCAL5(cldCalidad parAcceso)
        {

            System.IO.FileStream file;

            try
            {
                file = System.IO.File.OpenRead(parAcceso.RutaImagen);

            }
            catch
            {
                file = System.IO.File.OpenRead("C:/Temp/sheet_white.png");
            }

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            try
            {
                SqlCommand cmd = conn.CreateCommand();


                cmd.CommandText = "exec SAPB1_ORCAL5 @docentry , @lineid , @baseentry , @imgGuia ";

                cmd.Parameters.Add("@docentry", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@lineid", SqlDbType.VarChar).Value = parAcceso.LineId;
                cmd.Parameters.Add("@baseentry", SqlDbType.VarChar).Value = parAcceso.BaseEntry;

                cmd.Parameters.Add("@imgGuia", SqlDbType.Image).Value = file;

                conn.Open();
                cmd.ExecuteNonQuery();

                Respuesta = "Y";
            }

            catch (SqlException ex)
            {
                if (ex.Number == 8152)
                {
                    //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
                }
                else if (ex.Number == 2627)
                {
                    //Respuesta = "Ya existe un cliente con ese Nombre";
                }
                else if (ex.Number == 515)
                {
                    //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
                }
                else
                {
                    Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
                }
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return Respuesta;
        }

        public void Consultar_Calidad_x_Imagen(int id_docentry, int LineId)
        {
            string sql;

            sql = "select top 1 U_Imagen ";
            sql += "from HDV_IMGP03.dbo.[@HDV_OIMG] ";
            sql += "where Object = '100200' ";
            sql += "and U_BaseEntry = " + id_docentry + " ";
            sql += "and LineId = " + LineId;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Calidad_x_Lista_Imagen(int BaseEntry)
        {
            string sql;

            sql = "select ";
            sql += "U_BaseEntry , '' as TipoPesaje , VisOrder , ";
            sql += "LineId , ";
            sql += "convert ( varchar(12) , U_CreateDate , 105 ) + ' ' + convert ( varchar(5) , U_CreateDate , 108 ) as CreateDate , U_Imagen ";
            sql += "from HDV_IMGP03.dbo.[@HDV_OIMG] ";
            sql += "where Object = '100200' ";
            sql += "and U_BaseEntry = " + BaseEntry.ToString() + " ";
            sql += "order by TipoPesaje , LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Lotes_Rechazados()
        {

            string sql;

            sql = "select top 500 t0.* ";
            sql += "from vista_inventario_lotes_completa t0 ";
            sql += "where t0.Quantity > 0 ";
            sql += "and t0.AnalisisCalidad = 'Rechazado' ";
            sql += "and t0.StatusLote = 'Liberado' ";
            //sql += "and t0.StatusLote = 'Bloqueado' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Lotes_Proceso()
        {

            string sql;

            sql = "select  * ";
            sql += "from OBTN ";
            //sql += "where DistNumber in (select Lote from vista_ProcesosProductivos ";
            //sql += "where OrdenAfecta = 18404 and TipoDocto = 'ReporteProduccion'  ) ";
            sql += "where DistNumber in ( '3759358', '3759361', '3759367', '3759376', '3759378', '3759404', '3759420', '3759424', '3759431', '3759439', '3759449', '3759452', '3759455', '3759457', '3759461', '3759462' )";
            sql += "and Status != 0 ";

            //sql = "select top 500 t0.* ";
            //sql += "from vista_inventario_lotes_completa t0 ";
            //sql += "where t0.DistNumber in ( '3633362','3568606','3626262','3665740','3665619','3665635','3657052','3672568','3665599','3641254','3665704','3671188','3672044','3675321','3671779','3676098','3713391','3644844','3644502','3650398','3650055','3646815','3654000','3665886','3649631','3650069','3648656','3648296','3646614','3653991','3646842','3647785','3650027','3647945','3651101','3644325','3644351','3567589','3643496','3646540','3647833','3643550','3643704','3646126','3654013','3643002','3652419','3649732','3570196','3649595','3644992','3649552','3645227','3649613','3645135','3648014' )  ";
            //sql += "where t0.DistNumber in ( '3731346','3731359','3731370','3731379','3731381','3731387','3731393','3731399','3731402','3731426','3731440','3731450','3731476','3731479','3731268','3731283','3731263','3731295','3731336','3731277','3731251','3731332','3731266','3731080','3731102','3731122','3731124','3731148','3731163','3731165','3731167','3731171','3731179','3731185','3731199','3731202','3731211','3731225','3731232','3731239','3731243','3731278','3731327' )  ";
            //sql += "where t0.DistNumber in ( '3725802','3725839','3726056','3726091','3726110','3726145','3726184','3726229','3726251','3726301','3726319','3726357','3726374','3726386','3726387','3727461','3727529','3727564','3727583','3727593','3727892','3727903','3727907','3727926','3727943','3726805' )   ";
            //sql += "and t0.StatusLote = 'Bloqueado' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Lotes_Rechazados1()
        {

            string sql;

            sql = "select top 500 t0.* ";
            sql += "from vista_inventario_lotes_completa t0 ";
            sql += "where t0.Quantity > 0 ";
            sql += "and t0.AnalisisCalidad = 'Aprobado con Reparos' ";
            sql += "and t0.StatusLote = 'Bloqueado' ";
            sql += "and t0.ItemCode in ( 'FP.ALM.SE.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.NUE.PT.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FP.NUE.SE.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' , 'FS.ALM.SE.CRA1.XXX.X.XXX-XXX.XXX.G.0001K.01' )  ";


            sql = "select top 50 t1.* ";
            sql += "from[@HDV_ORCAL] t0 ";
            sql += "inner join OBTN t1 on t1.DistNumber = t0.U_NoLote ";
            sql += "where t0.U_Estado = 'A' ";
            sql += "and t1.Status = 1 ";

            //sql += "and t0.StatusLote = 'Bloqueado' ";

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

    }

}
