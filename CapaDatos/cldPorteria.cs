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
    public class cldPorteria : GestorSql
    {

        public int id_acceso { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int NumGuia { get; set; }
        public string Patente { get; set; }
        public int Usr_Registro { get; set; }
        public string Conductor { get; set; }
        public string CardCode_trans { get; set; }
        public string CardName_trans { get; set; }
        public string RutaImagen { get; set; }
        public string RazonIngreso { get; set; }
        public string PatenteCarro { get; set; }
        public string Sellos { get; set; }
        public int DocEntry { get; set; }
        public int LineId { get; set; }
        public int BaseEntry { get; set; }
        public int TipoImagen { get; set; }
        public string Objectx { get; set; }

        public cldPorteria()

        {

        }

        public cldPorteria(int id_acceso, string d_CardCode, string d_CardName, int d_NumGuia, string d_Patente, int d_Usr_Registro, string d_Conductor, string d_CardCode_trans, string d_CardName_trans, string d_ruta_imagen, int d_id_acceso, string d_razoningreso)
        {
            this.id_acceso = id_acceso;
            this.CardCode = d_CardCode;
            this.CardName = d_CardName;
            this.NumGuia = d_NumGuia;
            this.Patente = d_Patente;
            this.Usr_Registro = d_Usr_Registro;
            this.Conductor = d_Conductor;
            this.CardCode_trans = d_CardCode_trans;
            this.CardName_trans = d_CardCode_trans;
            this.RutaImagen = d_ruta_imagen;
            this.RazonIngreso = d_razoningreso;

        }

        public string SAPB1_ACCESO(cldPorteria parAcceso)
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

            //SqlConnection SqlConexion = new SqlConnection("Data Source=172.30.126.230;Initial Catalog=HDV_PRUEBA;Integrated Security=False;user id=sa;password=SAPB1Admin;");
            ////SqlConnection SqlConexion = new SqlConnection("Persist Security Info=False;Integrated Security=SSPI;Server=172.30.126.230;Initial Catalog=HDV_PRUEBA;User Id=sa;Password=SAPB1Admin;");
            //// Persist Security Info=False;Integrated Security=SSPI;Initial Catalog=Northwind;server=(local)

            //try
            //{
            //    //SqlConexion.ConnectionString = // ConfigurationManager.AppSettings.Get("String_SAP");

            //    SqlConexion.Open();

            //    SqlCommand SqlComando = new SqlCommand();

            //    SqlComando.Connection = SqlConexion;
            //    SqlComando.CommandText = "dbo.SAPB1_ACCESO";
            //    SqlComando.CommandType = CommandType.StoredProcedure;

            //    SqlParameter Parid_acceso = new SqlParameter();
            //    Parid_acceso.ParameterName = "@id_acceso";
            //    Parid_acceso.SqlDbType = SqlDbType.Int;
            //    Parid_acceso.Value = parAcceso.id_acceso;
            //    SqlComando.Parameters.Add(Parid_acceso);

            //    SqlParameter ParCardCode = new SqlParameter();
            //    ParCardCode.ParameterName = "@CardCode";
            //    ParCardCode.SqlDbType = SqlDbType.VarChar;
            //    ParCardCode.Size = parAcceso.CardCode.Length;
            //    ParCardCode.Value = parAcceso.CardCode;
            //    SqlComando.Parameters.Add(ParCardCode);

            //    SqlParameter ParCardName = new SqlParameter();
            //    ParCardName.ParameterName = "@CardName";
            //    ParCardName.SqlDbType = SqlDbType.VarChar;
            //    ParCardName.Size = parAcceso.CardName.Length;
            //    ParCardName.Value = parAcceso.CardName;
            //    SqlComando.Parameters.Add(ParCardName);

            //    SqlParameter ParNumGuia = new SqlParameter();
            //    ParNumGuia.ParameterName = "@NumGuia";
            //    ParNumGuia.SqlDbType = SqlDbType.Int;
            //    ParNumGuia.Value = parAcceso.NumGuia;
            //    SqlComando.Parameters.Add(ParNumGuia);

            //    SqlParameter ParPatente = new SqlParameter();
            //    ParPatente.ParameterName = "@Patente";
            //    ParPatente.SqlDbType = SqlDbType.VarChar;
            //    ParPatente.Size = parAcceso.Patente.Length;
            //    ParPatente.Value = parAcceso.Patente;
            //    SqlComando.Parameters.Add(ParPatente);

            //    SqlParameter ParUsr = new SqlParameter();
            //    ParUsr.ParameterName = "@Usr_Registro";
            //    ParUsr.SqlDbType = SqlDbType.Int;
            //    ParUsr.Value = parAcceso.Usr_Registro;
            //    SqlComando.Parameters.Add(ParUsr);

            //    SqlParameter ParConductor = new SqlParameter();
            //    ParConductor.ParameterName = "@Conductor";
            //    ParConductor.SqlDbType = SqlDbType.VarChar;
            //    ParConductor.Size = parAcceso.Conductor.Length;
            //    ParConductor.Value = parAcceso.Conductor;
            //    SqlComando.Parameters.Add(ParConductor);

            //    SqlParameter ParCardCode_tans = new SqlParameter();
            //    ParCardCode_tans.ParameterName = "@CardCode_Trans";
            //    ParCardCode_tans.SqlDbType = SqlDbType.VarChar;
            //    ParCardCode_tans.Size = parAcceso.CardCode_trans.Length;
            //    ParCardCode_tans.Value = parAcceso.CardCode_trans;
            //    SqlComando.Parameters.Add(ParCardCode_tans);

            //    SqlParameter CardName_tans = new SqlParameter();
            //    CardName_tans.ParameterName = "@CardName_trans";
            //    CardName_tans.SqlDbType = SqlDbType.VarChar;
            //    CardName_tans.Size = parAcceso.CardName_trans.Length;
            //    CardName_tans.Value = parAcceso.CardName_trans;
            //    SqlComando.Parameters.Add(CardName_tans);

            //    SqlParameter ParImagen = new SqlParameter();
            //    ParImagen.ParameterName = "@imgGuia";
            //    ParImagen.SqlDbType = SqlDbType.Image;
            //    ParImagen.Value = file;
            //    SqlComando.Parameters.Add(ParImagen);

            //    SqlParameter ParRazonIngreso = new SqlParameter();
            //    ParRazonIngreso.ParameterName = "@razoningreso";
            //    ParRazonIngreso.SqlDbType = SqlDbType.VarChar;
            //    ParRazonIngreso.Size = parAcceso.RazonIngreso.Length;
            //    ParRazonIngreso.Value = parAcceso.RazonIngreso;
            //    SqlComando.Parameters.Add(ParRazonIngreso);

            //    SqlComando.ExecuteNonQuery();
            //    Respuesta = "Y";
            //}

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            try
            {
                //SqlConexion.ConnectionString = // ConfigurationManager.AppSettings.Get("String_SAP");

                SqlCommand cmd = conn.CreateCommand();


                cmd.CommandText = "exec SAPB1_ACCESO @id_acceso , @CardCode , @CardName , @Patente , @NumGuia , @Conductor , @CardCode_trans , @CardName_trans , @Usr_Registro , @imgGuia , @razoningreso , @patentecarro , @sellos ";
                
                cmd.Parameters.Add("@id_acceso", SqlDbType.Int).Value = parAcceso.id_acceso;
                cmd.Parameters.Add("@CardCode", SqlDbType.VarChar).Value = parAcceso.CardCode;
                cmd.Parameters.Add("@CardName", SqlDbType.VarChar).Value = parAcceso.CardName;
                cmd.Parameters.Add("@Patente", SqlDbType.VarChar).Value = parAcceso.Patente;
                cmd.Parameters.Add("@NumGuia", SqlDbType.Int).Value = parAcceso.NumGuia;
                cmd.Parameters.Add("@Conductor", SqlDbType.VarChar).Value = parAcceso.Conductor;
                cmd.Parameters.Add("@CardCode_trans", SqlDbType.VarChar).Value = parAcceso.CardCode_trans;
                cmd.Parameters.Add("@CardName_trans", SqlDbType.VarChar).Value = parAcceso.CardName_trans;
                cmd.Parameters.Add("@Usr_Registro", SqlDbType.Int).Value =parAcceso.Usr_Registro;
                cmd.Parameters.Add("@imgGuia", SqlDbType.Image).Value = file;
                cmd.Parameters.Add("@razoningreso", SqlDbType.VarChar).Value = parAcceso.RazonIngreso;
                cmd.Parameters.Add("@patentecarro", SqlDbType.VarChar).Value = parAcceso.PatenteCarro;
                cmd.Parameters.Add("@sellos", SqlDbType.VarChar).Value = parAcceso.Sellos;

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

        public string SAPB1_ACCESO1(cldPorteria parAcceso)
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


                cmd.CommandText = "exec SAPB1_ROMANA5 @docentry , @lineid , @baseentry , @tipopesaje , @imgGuia , @object ";

                cmd.Parameters.Add("@docentry", SqlDbType.Int).Value = 0; 
                cmd.Parameters.Add("@lineid", SqlDbType.VarChar).Value = parAcceso.LineId; 
                cmd.Parameters.Add("@baseentry", SqlDbType.VarChar).Value = parAcceso.BaseEntry;
                cmd.Parameters.Add("@tipopesaje", SqlDbType.VarChar).Value = parAcceso.TipoImagen;

                cmd.Parameters.Add("@imgGuia", SqlDbType.Image).Value = file;
                cmd.Parameters.Add("@object", SqlDbType.VarChar).Value = parAcceso.Objectx;


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


        public string SAPB1_ACCESO2(cldPorteria parAcceso)
        {

            string Respuesta = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            try
            {
                SqlCommand cmd = conn.CreateCommand();


                cmd.CommandText = "exec SAPB1_ROMANA6 @docentry , @lineid , @baseentry , @object ";

                cmd.Parameters.Add("@docentry", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@lineid", SqlDbType.VarChar).Value = parAcceso.LineId;
                cmd.Parameters.Add("@baseentry", SqlDbType.VarChar).Value = parAcceso.BaseEntry;
                cmd.Parameters.Add("@object", SqlDbType.VarChar).Value = parAcceso.Objectx;

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


        public void Consultar_Accesos_x_Id(int id_acceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            //sql += "( select top 1 ta0.U_Imagen from [@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) as U_ImgenGuia , ";
            //sql += "case when ( select top 1 ta0.U_Imagen from [@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) is null then 0 else 1 end as con_imagen  , ";
            sql += "coalesce ( ( select top 1 t1.U_DocEntry_Acceso from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "coalesce ( t0.U_RazonAcceso , '' ) as U_RazonAcceso , ";
            sql += "coalesce ( t0.U_PatenteCarro, '' ) as U_PatenteCarro , ";
            sql += "coalesce ( t0.U_Sellos , '' ) as U_Sellos ";

            sql += "from [@HDV_OACC] t0 ";

            sql += "where t0.DocEntry = " + id_acceso;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_RI_Humedad_x_Id(int id_romana)
        {
            string sql;

            sql = "select * from [@HDV_ORCAL] ";
            sql += "where U_Object_Ref = '100100' ";
            sql += "and U_NoLote = '' ";
            sql += "and U_DocEntry_Ref = " + id_romana;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_EntradaMercancia_x_Folio(int id_romana)
        {
            string sql;

            sql = "select DocEntry from OPDN where FolioPref = 'GI' and FolioNum = " + id_romana;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_1er_pesaje_x_Folio(int id_romana)
        {
            string sql;

            sql = "select year(U_FechaPeso1) as year_pesaje from [@HDV_ROM2] where DocEntry = " + id_romana;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consultar_Razon_de_Ingreso()
        {
            string sql;

            sql = "select ";
            sql += "FldValue , Descr  ";
            sql += "from UFD1 ";
            sql += "where TableID = '@HDV_OACC' ";
            sql += "order by FldValue ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_x_Imagen(int id_acceso)
        {
            string sql;

            //sql = "select U_ImgenGuia as ImgenGuia ";
            //sql += "from [@HDV_OACC] ";
            //sql += "where DocEntry = " + id_acceso;

            sql = "select U_Imagen as ImgenGuia ";
            sql += "from HDV_IMGP03.dbo.[@HDV_OIMG] ";
            sql += "where Object = '100000' ";
            sql += "and LineId = 0 ";
            sql += "and U_BaseEntry = " + id_acceso;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_x_Numero(string valor, int numero, string cardcode)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            sql += "( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) as U_ImgenGuia , ";
            //sql += "case when t0.U_ImgenGuia is null then 0 else 1 end as con_imagen , ";

            sql += "case when ( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) is null then 0 else 1 end as con_imagen  , ";

            sql += "coalesce ( ( select top 1 t1.U_DocEntry_Acceso from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "coalesce ( t0.U_RazonAcceso , '' ) as U_RazonAcceso ";

            sql += "from [@HDV_OACC] t0 ";

            if (valor == "DocNum")
            {
                sql += "where t0.DocNum = " + numero;
                sql += "and t0.U_CardCode = '" + cardcode + "' ";
            }

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_x_Caracter(string valor, string valor1)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            sql += "( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) as U_ImgenGuia , ";

            //sql += "case when t0.U_ImgenGuia is null then 0 else 1 end as con_imagen , ";
            sql += "case when ( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) is null then 0 else 1 end as con_imagen  , ";

            sql += "coalesce ( ( select top 1 t1.U_DocEntry_Acceso from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "coalesce ( t0.U_RazonAcceso , '' ) as U_RazonAcceso ";

            sql += "from [@HDV_OACC] t0 ";

            if (valor == "Patente")
            {
                sql += "where t0.U_Patente = '" + valor1 + "'";
            }

            if (valor == "CardCode")
            {
                sql += "where t0.U_CardCode = '" + valor1 + "'";
            }

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Transporstica_Patente(string CardCodeTrans)
        {
            string sql;

            sql = "select top 1 ";
            sql += "U_CardCode_Trans , U_CardName_Trans , U_Conductor , ";
            sql += "coalesce ( U_PatenteCarro , '' ) as U_PatenteCarro ";
            sql += "from [dbo].[@HDV_OACC] ";
            sql += "where U_Patente = '" + CardCodeTrans + "' ";
            sql += "order by CreateDate desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_x_Documento(string CardCode, int DocNum)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            sql += "( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) as U_ImgenGuia , ";

            //sql += "case when t0.U_ImgenGuia is null then 0 else 1 end as con_imagen , ";
            sql += "case when ( select top 1 ta0.U_Imagen from HDV_IMGP03.dbo.[@HDV_OIMG] ta0 where ta0.Object = '100000' and ta0.LineId = 0 and ta0.DocEntry = t0.DocEntry ) is null then 0 else 1 end as con_imagen  , ";

            sql += "coalesce ( ( select top 1 t1.U_DocEntry_Acceso from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "coalesce ( t0.U_RazonAcceso , '' ) as U_RazonAcceso ";

            sql += "from [@HDV_OACC] t0 ";

            sql += "where t0.U_CardCode = '" + CardCode + "' ";
            sql += "and t0.DocNum = " + DocNum.ToString();

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_max_Id()
        {
            string sql;

            sql = "select max(DocEntry) as DocEntry ";
            sql += "from [@HDV_OACC] ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos_Full(string fecha, string con_romana)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , coalesce ( t2.Descr , '' ) as U_Nom_RazonAcceso , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            sql += "coalesce ( ( select top 1 t1.DocEntry from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "t0.U_RazonAcceso  ";

            sql += "from [@HDV_OACC] t0 ";
            sql += "left join UFD1 t2 on t2.TableID = '@HDV_OACC' and t2.FldValue = t0.U_RazonAcceso ";

            sql += "where convert ( varchar(8) , t0.U_FechaAcceso , 112 ) = '" + fecha + "' ";
            if (con_romana == "S")
            {
                sql += "and t0.DocEntry not in ( select t1.U_DocEntry_Acceso from [@HDV_OROM] t1 ) ";
            }
            //sql += "and t0.U_RazonAcceso = 1 ";

            sql += "order by t0.U_FechaAcceso desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Accesos(string fecha, string con_romana, string razon_acceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , coalesce ( t2.Descr , '' ) as U_Nom_RazonAcceso , t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_Patente , t0.DocNum , t0.U_FechaAcceso , ";
            sql += "t0.UserSign , t0.U_Conductor , t0.U_CardCode_Trans , ";
            sql += "t0.U_CardName_Trans , ";
            sql += "coalesce ( ( select top 1 t1.DocEntry from [@HDV_OROM] t1 where t1.U_DocEntry_Acceso = t0.DocEntry ) , 0 ) as id_romana , ";
            sql += "t0.U_RazonAcceso  ";

            sql += "from [@HDV_OACC] t0 ";
            sql += "left join UFD1 t2 on t2.TableID = '@HDV_OACC' and t2.FldValue = t0.U_RazonAcceso ";

            sql += "where convert ( varchar(8) , t0.U_FechaAcceso , 112 ) = '" + fecha + "' ";
            if (con_romana == "S")
            {
                sql += "and t0.DocEntry not in ( select t1.U_DocEntry_Acceso from [@HDV_OROM] t1 ) ";
            }
            if (razon_acceso=="1")
            {
                sql += "and t0.U_RazonAcceso in ( 1 ) ";
            }
            else
            {
                sql += "and t0.U_RazonAcceso in ( 3 ) ";
            }

            sql += "order by t0.U_FechaAcceso desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consultar_Dependencias_x_UserId(int UserSing)
        {
            string sql;


            sql = "WITH EmpCTE (NroEmpleado, Nombre, Apellido, Cargo, NroJefe , UserId)  ";
            sql += "  ";
            sql += "AS  ";

            sql += "( SELECT empID, firstName, lastName, jobTitle, manager, UserId  ";
            sql += "FROM OHEM WHERE userId = 131  ";
            sql += "UNION ALL  ";
            sql += "SELECT e.empID, e.firstName, e.lastName, e.jobTitle, e.manager, e.UserId  ";
            sql += "FROM OHEM AS e JOIN EmpCTE AS m ON e.empID = m.NroJefe )  ";
            sql += "  ";
            sql += "SELECT * FROM EmpCTE   ";
            sql += "where UserId <> 131  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


    }
}
