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
    public class cldRomana : GestorSql
    {

        public int id_romana { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int NumOC { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int NumGuia { get; set; }
        public string Patente { get; set; }
        public string conductor { get; set; }
        public string cod_envase { get; set; }
        public int Envases { get; set; }
        public float PesoBruto { get; set; }
        public string FechaPeso1 { get; set; }
        public float PesoTara { get; set; }
        public string FechaPeso2 { get; set; }
        public float PesoNeto { get; set; }
        public float PesoEnvase { get; set; }
        
        public string Obs { get; set; }
        public int id_acceso { get; set; }
        public string CardCode_trans { get; set; }
        public string CardName_trans { get; set; }
        public int Usr_registro { get; set; }
        public float PesoGuia { get; set; }
        public int DocEntry { get; set; }
        public int LineId { get; set; }
        public int idBalanza { get; set; }        
        public int Linea { get; set; }
        public int EnvasesVacios { get; set; }
        public string TipoPesaje { get; set; }
        public string Object { get; set; }
        public string Codigo_CSG { get; set; }
        public int LineIdOC { get; set; }
        public string TipoCosecha { get; set; }
        public string Bloqueo { get; set; }
        public string Bloqueo2 { get; set; }
        public float Muestra_calidad_nue_fp { get; set; }
        public float Muestra_calidad_nue_fs { get; set; }
        public float Muestra_calidad_alm_fp { get; set; }
        public float Muestra_calidad_alm_fs { get; set; }
        public cldRomana()
        {

        }

        public cldRomana(int d_id_romana, string d_CardCode, string d_CardName, int d_NumOC,
            string d_ItemCode, string d_ItemName, int d_NumGuia, string d_Patente, string d_conductor,
            string d_cod_envase, int d_Envases, float d_PesoBruto, string d_FechaPeso1, float d_PesoTara,
            string d_FechaPeso2, float d_PesoNeto, string d_Obs, int d_id_acceso, string d_CardCode_trans,
            string d_CardName_trans, int d_Usr_registro, float d_PesoGuia, int d_DocEntry, int d_LineId, 
            string d_TipoPesaje)

        {
            this.id_romana = d_id_romana;
            this.CardCode = d_CardCode;
            this.CardName = d_CardName;
            this.NumOC = d_NumOC;
            this.ItemCode = d_ItemCode;
            this.ItemName = d_ItemName;
            this.NumGuia = d_NumGuia;
            this.Patente = d_Patente;
            this.conductor = d_conductor;
            this.cod_envase = d_cod_envase;
            this.Envases = d_Envases;
            this.PesoBruto = d_PesoBruto;
            this.FechaPeso1 = d_FechaPeso1;
            this.PesoTara = d_PesoTara;
            this.FechaPeso2 = d_FechaPeso2;
            this.PesoNeto = d_PesoNeto;
            this.Obs = d_Obs;
            this.id_acceso = d_id_acceso;
            this.CardCode_trans = d_CardCode_trans;
            this.CardName_trans = d_CardName_trans;
            this.Usr_registro = d_Usr_registro;
            this.PesoGuia = d_PesoBruto;
            this.DocEntry = d_DocEntry;
            this.LineId = d_LineId;
            this.TipoPesaje = d_TipoPesaje;

        }

        public string SAPB1_ROMANA(cldRomana parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANA";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_romana = new SqlParameter();
                Parid_romana.ParameterName = "@id_romana";
                Parid_romana.SqlDbType = SqlDbType.Int;
                Parid_romana.Value = parRomana.id_romana;
                SqlComando.Parameters.Add(Parid_romana);

                SqlParameter ParCardCode = new SqlParameter();
                ParCardCode.ParameterName = "@CardCode";
                ParCardCode.SqlDbType = SqlDbType.VarChar;
                ParCardCode.Size = parRomana.CardCode.Length;
                ParCardCode.Value = parRomana.CardCode;
                SqlComando.Parameters.Add(ParCardCode);

                SqlParameter ParCardName = new SqlParameter();
                ParCardName.ParameterName = "@CardName";
                ParCardName.SqlDbType = SqlDbType.VarChar;
                ParCardName.Size = parRomana.CardName.Length;
                ParCardName.Value = parRomana.CardName;
                SqlComando.Parameters.Add(ParCardName);

                SqlParameter ParNumGuia = new SqlParameter();
                ParNumGuia.ParameterName = "@NumGuia";
                ParNumGuia.SqlDbType = SqlDbType.Int;
                ParNumGuia.Value = parRomana.NumGuia;
                SqlComando.Parameters.Add(ParNumGuia);

                SqlParameter ParPatente = new SqlParameter();
                ParPatente.ParameterName = "@Patente";
                ParPatente.SqlDbType = SqlDbType.VarChar;
                ParPatente.Size = parRomana.Patente.Length;
                ParPatente.Value = parRomana.Patente;
                SqlComando.Parameters.Add(ParPatente);

                SqlParameter ParConductor = new SqlParameter();
                ParConductor.ParameterName = "@conductor";
                ParConductor.SqlDbType = SqlDbType.VarChar;
                ParConductor.Size = parRomana.conductor.Length;
                ParConductor.Value = parRomana.conductor;
                SqlComando.Parameters.Add(ParConductor);

                SqlParameter Parid_envase = new SqlParameter();
                Parid_envase.ParameterName = "@cod_envase";
                Parid_envase.SqlDbType = SqlDbType.VarChar;
                Parid_envase.Size = parRomana.conductor.Length;
                Parid_envase.Value = parRomana.cod_envase;
                SqlComando.Parameters.Add(Parid_envase);

                SqlParameter ParEnvases = new SqlParameter();
                ParEnvases.ParameterName = "@Envases";
                ParEnvases.SqlDbType = SqlDbType.Int;
                ParEnvases.Value = parRomana.Envases;
                SqlComando.Parameters.Add(ParEnvases);

                SqlParameter ParPesoBruto = new SqlParameter();
                ParPesoBruto.ParameterName = "@PesoBruto";
                ParPesoBruto.SqlDbType = SqlDbType.Float;
                ParPesoBruto.Value = parRomana.PesoBruto;
                SqlComando.Parameters.Add(ParPesoBruto);

                SqlParameter ParFechaPeso1 = new SqlParameter();
                ParFechaPeso1.ParameterName = "@FechaPeso1";
                ParFechaPeso1.SqlDbType = SqlDbType.VarChar;
                ParFechaPeso1.Size = parRomana.FechaPeso1.Length;
                ParFechaPeso1.Value = parRomana.FechaPeso1;
                SqlComando.Parameters.Add(ParFechaPeso1);

                SqlParameter ParPesoTara = new SqlParameter();
                ParPesoTara.ParameterName = "@PesoTara";
                ParPesoTara.SqlDbType = SqlDbType.Float;
                ParPesoTara.Value = parRomana.PesoTara;
                SqlComando.Parameters.Add(ParPesoTara);

                SqlParameter ParFechaPeso2 = new SqlParameter();
                ParFechaPeso2.ParameterName = "@FechaPeso2";
                ParFechaPeso2.SqlDbType = SqlDbType.VarChar;
                ParFechaPeso2.Size = parRomana.FechaPeso2.Length;
                ParFechaPeso2.Value = parRomana.FechaPeso2;
                SqlComando.Parameters.Add(ParFechaPeso2);

                SqlParameter ParPesoNeto = new SqlParameter();
                ParPesoNeto.ParameterName = "@PesoNeto";
                ParPesoNeto.SqlDbType = SqlDbType.Float;
                ParPesoNeto.Value = parRomana.PesoNeto;
                SqlComando.Parameters.Add(ParPesoNeto);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@Obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = parRomana.Obs.Length;
                ParObs.Value = parRomana.Obs;
                SqlComando.Parameters.Add(ParObs);

                SqlParameter Parid_acceso = new SqlParameter();
                Parid_acceso.ParameterName = "@id_acceso";
                Parid_acceso.SqlDbType = SqlDbType.Int;
                Parid_acceso.Value = parRomana.id_acceso;
                SqlComando.Parameters.Add(Parid_acceso);

                SqlParameter ParCardCode_trans = new SqlParameter();
                ParCardCode_trans.ParameterName = "@CardCode_trans";
                ParCardCode_trans.SqlDbType = SqlDbType.VarChar;
                ParCardCode_trans.Size = parRomana.CardCode_trans.Length;
                ParCardCode_trans.Value = parRomana.CardCode_trans;
                SqlComando.Parameters.Add(ParCardCode_trans);

                SqlParameter ParCardName_trans = new SqlParameter();
                ParCardName_trans.ParameterName = "@CardName_trans";
                ParCardName_trans.SqlDbType = SqlDbType.VarChar;
                ParCardName_trans.Size = parRomana.CardName_trans.Length;
                ParCardName_trans.Value = parRomana.CardName_trans;
                SqlComando.Parameters.Add(ParCardName_trans);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usr_Registro";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parRomana.Usr_registro;
                SqlComando.Parameters.Add(ParUsuario);

                SqlParameter ParPesoGuia = new SqlParameter();
                ParPesoGuia.ParameterName = "@Pesoguia";
                ParPesoGuia.SqlDbType = SqlDbType.Float;
                ParPesoGuia.Value = parRomana.PesoGuia;
                SqlComando.Parameters.Add(ParPesoGuia);

                SqlParameter ParLineId = new SqlParameter();
                ParLineId.ParameterName = "@LineId";
                ParLineId.SqlDbType = SqlDbType.Float;
                ParLineId.Value = parRomana.LineId;
                SqlComando.Parameters.Add(ParLineId);

                SqlParameter ParTipoPesaje = new SqlParameter();
                ParTipoPesaje.ParameterName = "@TipoPesaje";
                ParTipoPesaje.SqlDbType = SqlDbType.VarChar;
                ParTipoPesaje.Size = parRomana.TipoPesaje.Length;
                ParTipoPesaje.Value = parRomana.TipoPesaje;
                SqlComando.Parameters.Add(ParTipoPesaje);

                //@TipoPesaje


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

        public string SAPB1_ROMANA2(cldRomana parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANA2";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRomana.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter PadLineId = new SqlParameter();
                PadLineId.ParameterName = "@Linea";
                PadLineId.SqlDbType = SqlDbType.Int;
                PadLineId.Value = parRomana.LineId;
                SqlComando.Parameters.Add(PadLineId);

                SqlParameter ParCardCode = new SqlParameter();
                ParCardCode.ParameterName = "@CardCode";
                ParCardCode.SqlDbType = SqlDbType.VarChar;
                ParCardCode.Size = parRomana.CardCode.Length;
                ParCardCode.Value = parRomana.CardCode;
                SqlComando.Parameters.Add(ParCardCode);

                SqlParameter ParCardName = new SqlParameter();
                ParCardName.ParameterName = "@CardName";
                ParCardName.SqlDbType = SqlDbType.VarChar;
                ParCardName.Size = parRomana.CardName.Length;
                ParCardName.Value = parRomana.CardName;
                SqlComando.Parameters.Add(ParCardName);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parRomana.ItemCode.Length;
                ParItemCode.Value = parRomana.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParItemName = new SqlParameter();
                ParItemName.ParameterName = "@ItemName";
                ParItemName.SqlDbType = SqlDbType.VarChar;
                ParItemName.Size = parRomana.ItemName.Length;
                ParItemName.Value = parRomana.ItemName;
                SqlComando.Parameters.Add(ParItemName);

                SqlParameter ParItemCodeBins = new SqlParameter();
                ParItemCodeBins.ParameterName = "@ItemCodeBins";
                ParItemCodeBins.SqlDbType = SqlDbType.VarChar;
                ParItemCodeBins.Size = parRomana.cod_envase.Length;
                ParItemCodeBins.Value = parRomana.cod_envase;
                SqlComando.Parameters.Add(ParItemCodeBins);

                SqlParameter ParEnvases = new SqlParameter();
                ParEnvases.ParameterName = "@Envases";
                ParEnvases.SqlDbType = SqlDbType.Int;
                ParEnvases.Value = parRomana.Envases;
                SqlComando.Parameters.Add(ParEnvases);

                SqlParameter ParNumOC = new SqlParameter();
                ParNumOC.ParameterName = "@NumOC";
                ParNumOC.SqlDbType = SqlDbType.Int;
                ParNumOC.Value = parRomana.NumOC;
                SqlComando.Parameters.Add(ParNumOC);

                SqlParameter ParEnvasesVacios = new SqlParameter();
                ParEnvasesVacios.ParameterName = "@EnvasesVacios";
                ParEnvasesVacios.SqlDbType = SqlDbType.Int;
                ParEnvasesVacios.Value = parRomana.EnvasesVacios;
                SqlComando.Parameters.Add(ParEnvasesVacios);

                SqlParameter ParObject = new SqlParameter();
                ParObject.ParameterName = "@Object";
                ParObject.Size = parRomana.Object.Length;
                ParObject.Value = parRomana.Object;
                SqlComando.Parameters.Add(ParObject);

                SqlParameter ParCodigo_CSG = new SqlParameter();
                ParCodigo_CSG.ParameterName = "@Codigo_CSG";
                ParCodigo_CSG.SqlDbType = SqlDbType.VarChar;
                ParCodigo_CSG.Size = parRomana.Codigo_CSG.Length;
                ParCodigo_CSG.Value = parRomana.Codigo_CSG;
                SqlComando.Parameters.Add(ParCodigo_CSG);

                SqlParameter PadLineIdOC = new SqlParameter();
                PadLineIdOC.ParameterName = "@LineIdOC";
                PadLineIdOC.SqlDbType = SqlDbType.Int;
                PadLineIdOC.Value = parRomana.LineIdOC;
                SqlComando.Parameters.Add(PadLineIdOC);

                SqlParameter ParTipoCosecha = new SqlParameter();
                ParTipoCosecha.ParameterName = "@TipoCosecha";
                ParTipoCosecha.SqlDbType = SqlDbType.VarChar;
                ParTipoCosecha.Size = parRomana.TipoCosecha.Length;
                ParTipoCosecha.Value = parRomana.TipoCosecha;
                SqlComando.Parameters.Add(ParTipoCosecha);

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

        public string SAPB1_ROMANA4(cldRomana parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANA4";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@id_romana";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRomana.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter PadLineId = new SqlParameter();
                PadLineId.ParameterName = "@LineId";
                PadLineId.SqlDbType = SqlDbType.Int;
                PadLineId.Value = parRomana.LineId;
                SqlComando.Parameters.Add(PadLineId);

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

        public string SAPB1_ROMANA4v1(cldRomana parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANA4v1";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@id_romana";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRomana.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter PadLineId = new SqlParameter();
                PadLineId.ParameterName = "@LineId";
                PadLineId.SqlDbType = SqlDbType.Int;
                PadLineId.Value = parRomana.LineId;
                SqlComando.Parameters.Add(PadLineId);

                SqlParameter ParDocNum = new SqlParameter();
                ParDocNum.ParameterName = "@docentry";
                ParDocNum.SqlDbType = SqlDbType.Int;
                ParDocNum.Value = parRomana.Linea;
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
        public string SAPB1_ROMANA3(cldRomana parRomana)
        {
            string sql;
            string Respuesta = "";

            sql = "update [@HDV_ROM2] ";
            sql += "set U_PesoBruto = " + parRomana.PesoBruto.ToString() + " , U_FechaPeso1 = getdate(), U_Usr_Peso1 = " + parRomana.Usr_registro.ToString() + " ";
            sql += "where DocEntry = " + parRomana.DocEntry.ToString();

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = sql;
                SqlComando.CommandType = CommandType.Text;

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


        public string SAPB1_OPARAM(cldRomana parRomana)
        {

            string Respuesta = "";
            string sql;

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            try
            {
                SqlCommand cmd = conn.CreateCommand();

                sql = "update [@HDV_OPARAM] set ";
                sql += "U_Por_Tolerancia_Romana = @val1 , ";
                sql += "U_Por_Tolerancia_Romana2 = @val2 , ";
                sql += "U_Tolerancia_de_Bloqueo = @val3 , ";
                sql += "U_Tolerancia_de_Bloqueo2 = @val4 , ";
                sql += "U_Muestra_Calidad_NUE_FP = @val5 , ";
                sql += "U_Muestra_Calidad_NUE_FS = @val6 , ";
                sql += "U_Muestra_Calidad_ALM_FP = @val7 , ";
                sql += "U_Muestra_Calidad_ALM_FS = @val8  ";

                cmd.CommandText = sql; // "exec SAPB1_ORCAL5 @docentry , @lineid , @baseentry , @imgGuia ";

                cmd.Parameters.Add("@val1", SqlDbType.Int).Value = parRomana.PesoBruto;
                cmd.Parameters.Add("@val2", SqlDbType.Int).Value = parRomana.PesoNeto;
                cmd.Parameters.Add("@val3", SqlDbType.Char).Value = parRomana.Bloqueo;
                cmd.Parameters.Add("@val4", SqlDbType.Char).Value = parRomana.Bloqueo2;
                cmd.Parameters.Add("@val5", SqlDbType.Int).Value = parRomana.Muestra_calidad_nue_fp;
                cmd.Parameters.Add("@val6", SqlDbType.Int).Value = parRomana.Muestra_calidad_nue_fs;
                cmd.Parameters.Add("@val7", SqlDbType.Int).Value = parRomana.Muestra_calidad_alm_fp;
                cmd.Parameters.Add("@val8", SqlDbType.Int).Value = parRomana.Muestra_calidad_alm_fs;

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

            //string sql;
            //string Respuesta = "";

            //sql = "update [@HDV_OPARAM] set ";
            //sql += "U_Por_Tolerancia_Romana = " + parRomana.PesoBruto.ToString("N") + " , ";
            //sql += "U_Por_Tolerancia_Romana2 = " + parRomana.PesoNeto.ToString("N") + " , ";
            //sql += "U_Tolerancia_de_Bloqueo = '" + parRomana.Bloqueo + "' , ";
            //sql += "U_Tolerancia_de_Bloqueo2 = '" + parRomana.Bloqueo2 + "' , ";
            //sql += "U_Muestra_Calidad_NUE_FP = " + parRomana.Muestra_calidad_nue_fp.ToString("N") + " , ";
            //sql += "U_Muestra_Calidad_NUE_FS = " + parRomana.Muestra_calidad_nue_fs.ToString("N") + " , ";
            //sql += "U_Muestra_Calidad_ALM_FP = " + parRomana.Muestra_calidad_alm_fp.ToString("N") + " , ";
            //sql += "U_Muestra_Calidad_ALM_FS = " + parRomana.Muestra_calidad_alm_fs.ToString("N") + "  ";

            //SqlConnection SqlConexion = new SqlConnection();

            //try
            //{
            //    SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
            //    SqlConexion.Open();

            //    SqlCommand SqlComando = new SqlCommand();
            //    SqlComando.Connection = SqlConexion;
            //    SqlComando.CommandText = sql;
            //    SqlComando.CommandType = CommandType.Text;

            //    SqlComando.ExecuteNonQuery();
            //    Respuesta = "Y";

            //}

            //catch (SqlException ex)
            //{
            //    if (ex.Number == 8152)
            //    {
            //        //Respuesta = "Has introducido demasiados caracteres en uno de los campos";
            //    }
            //    else if (ex.Number == 2627)
            //    {
            //        //Respuesta = "Ya existe un cliente con ese Nombre";
            //    }
            //    else if (ex.Number == 515)
            //    {
            //        //Respuesta = "Sólo puedes dejar vacíos los campos Nombre de Contacto, Región, País, Teléfono, Fax y Email";
            //    }
            //    else
            //    {
            //        Respuesta = "Error al intentar ejecutar el procedimiento almacenado " + ex.Message;
            //    }
            //}

            //finally
            //{
            //    if (SqlConexion.State == ConnectionState.Open)
            //    {
            //        SqlConexion.Close();
            //    }
            //}

            //return Respuesta;

        }


        public string SAPB1_ROMANA5(cldRomana parRomana)
        {
            string sql;
            string Respuesta = "";

            sql = "update [@HDV_ROM2] ";
            sql += "set U_PesoTara = " + parRomana.PesoTara.ToString() + " , U_PesoNeto = " + parRomana.PesoNeto.ToString() + " , U_FechaPeso2 = getdate(), U_Usr_Peso2 = " + parRomana.Usr_registro.ToString() + " ";
            sql += "where DocEntry = " + parRomana.DocEntry.ToString();

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = sql;
                SqlComando.CommandType = CommandType.Text;

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

        public string SAPB1_ROMANA9(cldRomana parRomana)
        {
            string sql;
            string Respuesta = "";

            sql = "insert [@HDV_ROM4] ( DocEntry ) ";
            sql += "select " + parRomana.DocEntry.ToString();

            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = sql;
                SqlComando.CommandType = CommandType.Text;

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

        public string SAPB1_ROMANA7(cldRomana parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_ROMANA7";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDocEntry = new SqlParameter();
                ParDocEntry.ParameterName = "@DocEntry";
                ParDocEntry.SqlDbType = SqlDbType.Int;
                ParDocEntry.Value = parRomana.DocEntry;
                SqlComando.Parameters.Add(ParDocEntry);

                SqlParameter PadLinea = new SqlParameter();
                PadLinea.ParameterName = "@Linea";
                PadLinea.SqlDbType = SqlDbType.Int;
                PadLinea.Value = parRomana.Linea;
                SqlComando.Parameters.Add(PadLinea);

                SqlParameter PadLineId = new SqlParameter();
                PadLineId.ParameterName = "@LineID";
                PadLineId.SqlDbType = SqlDbType.Int;
                PadLineId.Value = parRomana.LineId;
                SqlComando.Parameters.Add(PadLineId);

                SqlParameter PadBalanza = new SqlParameter();
                PadBalanza.ParameterName = "@Balanza";
                PadBalanza.SqlDbType = SqlDbType.Int;
                PadBalanza.Value = parRomana.idBalanza;
                SqlComando.Parameters.Add(PadBalanza);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Size = parRomana.FechaPeso1.Length;
                ParFecha.Value = parRomana.FechaPeso1;
                SqlComando.Parameters.Add(ParFecha);

                SqlParameter ParPesoBruto = new SqlParameter();
                ParPesoBruto.ParameterName = "@PesoBruto";
                ParPesoBruto.SqlDbType = SqlDbType.Float;
                ParPesoBruto.Value = parRomana.PesoBruto;
                SqlComando.Parameters.Add(ParPesoBruto);

                SqlParameter ParItemCode = new SqlParameter();
                ParItemCode.ParameterName = "@ItemCode";
                ParItemCode.SqlDbType = SqlDbType.VarChar;
                ParItemCode.Size = parRomana.ItemCode.Length;
                ParItemCode.Value = parRomana.ItemCode;
                SqlComando.Parameters.Add(ParItemCode);

                SqlParameter ParPesoEnvase = new SqlParameter();
                ParPesoEnvase.ParameterName = "@PesoEnvase";
                ParPesoEnvase.SqlDbType = SqlDbType.Float;
                ParPesoEnvase.Value = parRomana.PesoEnvase;
                SqlComando.Parameters.Add(ParPesoEnvase);

                SqlParameter PadCantEnvases = new SqlParameter();
                PadCantEnvases.ParameterName = "@CantEnvases";
                PadCantEnvases.SqlDbType = SqlDbType.Int;
                PadCantEnvases.Value = parRomana.Envases;
                SqlComando.Parameters.Add(PadCantEnvases);

                SqlParameter ParPesoNeto = new SqlParameter();
                ParPesoNeto.ParameterName = "@PesoNeto";
                ParPesoNeto.SqlDbType = SqlDbType.Float;
                ParPesoNeto.Value = parRomana.PesoNeto;
                SqlComando.Parameters.Add(ParPesoNeto);

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

        public void Consulta_Partidas_x_fecha(string fecha)
        {
            string sql;
            
            sql = "select ";
            sql += "case when t0.U_TipoPesaje = 'E' then 'Pesaje de Entrada' else 'Pesaje de Salida' end as Nom_TipoPesaje , ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.U_NumGuia , "; // U_ItemCode , U_ItemName , 
            sql += "t0.U_Patente , ";
            sql += "coalesce ( ( select sum(t1.U_CantidadBins) from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry ) , '' ) as U_CantidadBins , ";
            sql += "t1.U_FechaPeso1 , t1.U_PesoBruto , t0.U_Patente , ";
            sql += "coalesce ( ( select top 1 t1.U_NumOC from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , 0 ) as U_NumOC , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCodeBins from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCodeBins , ";
            sql += "t1.U_PesoBruto , t1.U_PesoTara , ";
            sql += "t1.U_PesoNeto , t0.U_Obs , t1.U_FechaPeso1 as Fechax , ";
            sql += "t1.U_FechaPeso2 , t0.U_DocEntry_Acceso , ";
            sql += "t0.U_Conductor , t0.U_CardCode_trans , t0.U_CardName_trans , ";
            sql += "t1.LineId , 'Pesaje N° ' + convert ( varchar(3) , LineId + 1 )  as Ref_LineId ";

            sql += "from [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "where convert ( varchar(8) , t1.U_FechaPeso1 , 112 ) = '" + fecha + "' ";
            sql += "and t0.U_Patente <> '' ";
            sql += "and t0.U_TipoPesaje in ( 'E' , 'S' ) ";

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_x_fecha1(string fecha)
        {
            string sql;

            sql = "select ";
            sql += "case when t0.U_TipoPesaje = 'E' then 'Pesaje de Entrada' else 'Pesaje de Salida' end as Nom_TipoPesaje , ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t2.U_NumOC , "; // U_ItemCode , U_ItemName , 
            sql += "t0.U_Patente , 0 as U_CantidadBins1 ,";
            sql += "t1.U_FechaPeso1 , t1.U_PesoBruto , t0.U_Patente , ";
            sql += "coalesce ( ( select top 1 t1.U_NumOC from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , 0 ) as U_NumOC , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCodeBins from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCodeBins , ";
            sql += "coalesce ( ( select sum(t1.U_CantidadBins) from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry ) , '' ) as U_CantidadBins , ";
            sql += "t1.U_PesoBruto , t1.U_PesoTara , ";
            sql += "t1.U_PesoNeto , t0.U_Obs , t1.U_FechaPeso1 as Fechax , ";
            sql += "t1.U_FechaPeso2 , t0.U_DocEntry_Acceso , ";
            sql += "t0.U_Conductor , t0.U_CardCode_trans , t0.U_CardName_trans , ";
            sql += "t1.LineId , 'Pesaje N° ' + convert ( varchar(3) , t1.LineId + 1 )  as Ref_LineId ";

            sql += "from [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry  ";
            sql += "inner join [@HDV_ROM1] t2 on t2.DocEntry = t0.DocEntry  ";

            sql += "where convert ( varchar(8) , t1.U_FechaPeso1 , 112 ) = '" + fecha + "' ";
            sql += "and t0.U_TipoPesaje <> 'I' ";
            sql += "and t0.U_Patente = '' ";
            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_x_fecha1_dys(string fecha)
        {
            string sql;

            sql = "select ";
            sql += "case when t1.U_FechaPeso1 = '19000101' then 'Pesaje de entrada' else 'Pesaje de Salida' end as Nom_TipoPesaje , ";
            sql += "t0.DocEntry , t2.U_CardCode , t2.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t2.U_NumOC , t0.U_Patente , 0 as U_CantidadBins1 , ";
            sql += "convert ( varchar(10) , t0.CreateDate , 105 ) as CreateDate , t1.U_PesoBruto , t0.U_Patente , ";
            sql += "coalesce ( ( select top 1 t1.U_NumOC from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , 0 ) as U_NumOC , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCodeBins from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCodeBins , ";
            sql += "coalesce ( ( select sum(t1.U_CantidadBins) from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry ) , '' ) as U_CantidadBins , ";
            sql += "t1.U_PesoBruto , t1.U_PesoTara , t1.U_PesoNeto , t0.U_Obs , t1.U_FechaPeso1 as Fechax , ";
            sql += "t1.U_FechaPeso2 , t0.U_DocEntry_Acceso , t0.U_Conductor , t0.U_CardCode_trans , t0.U_CardName_trans , ";
            sql += "t1.LineId , 'Pesaje N° ' + convert ( varchar(3) , t1.LineId + 1 )  as Ref_LineId ";

            sql += "from [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry  ";
            //sql += "inner join [@HDV_ROM1] t2 on t2.DocEntry = t0.DocEntry  ";
            sql += "inner join ( select t2.DocEntry , t2.U_CardCode , t2.U_CardName , t2.U_NumOC from [@HDV_ROM1] t2 group by t2.DocEntry , t2.U_CardCode , t2.U_CardName , t2.U_NumOC ) t2 on t2.DocEntry = t0.DocEntry ";

            sql += "where convert ( varchar(8) , t0.CreateDate , 112 ) = '" + fecha + "' ";
            sql += "and t0.U_TipoPesaje = 'I' ";
            sql += "and t0.U_Est_Vigente != 'N' ";

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas(String razon_acceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";  
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.U_NumGuia , t0.U_Patente , t0.U_CantidadBins , t1.U_FechaPeso1 , t1.U_PesoBruto , t1.LineId ";
            sql += "from  [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where year(t1.U_FechaPeso2) = 1900 ";
            sql += "and t0.U_TipoPesaje in ( 'E' , 'S' ) ";

            if (razon_acceso == "1")
            {
                sql += "and t0.U_DocEntry_Acceso in ( select DocEntry from [@HDV_OACC] where U_RazonAcceso in ( 1 ) ) ";
            }
            else
            {
                sql += "and t0.U_DocEntry_Acceso in ( select DocEntry from [@HDV_OACC] where U_RazonAcceso in ( 3 ) ) ";
            }

            sql += "and t0.DocEntry not in ( select U_DocEntry_Ref from [@HDV_ORCAL] where U_Object_Ref = '100100' and U_Estado = 'R' ) ";

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_dys(String razon_acceso, int d_anho)
        {
            string sql;

            sql = "select ";
            sql += "case when year(t1.U_FechaPeso2)=1900 then 'En proceso de pesaje' else 'En proceso de recepción' end as Estado, ";
            sql += "t2.U_CardCode , t2.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.DocEntry as U_NumGuia , t2.Object as Lote , t2.U_CantidadBins , t3.OrdenAfecta , t0.CreateDate as U_FechaPeso1 , t1.U_PesoBruto , t1.LineId , ";
            sql += "coalesce ( ( select top 1 ta1.Kilos from vista_inventario_lotes_completa ta1 where ta1.DistNumber = t2.Object ) , 0 ) as Stock ";

            sql += "";

            sql += "from  [@HDV_OROM] t0 with (nolock) ";
            sql += "inner join [@HDV_ROM2] t1 with (nolock) on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [@HDV_ROM1] t2 with (nolock) on t2.DocEntry = t0.DocEntry ";
            sql += "inner join vista_ProcesosProductivos t3 with (nolock) on t3.Lote = t2.Object ";

            sql += "where t0.U_TipoPesaje = 'I' ";

            //sql += "and t2.Object in ( select DistNumber from vista_inventario_lotes_completa ) ";

            if (d_anho > 0)
            {
                sql += "and year(t0.CreateDate) = " + d_anho.ToString() + " ";

            }

            sql += "order by t1.U_FechaPeso1 desc ";

            //sql = "select ";
            //sql += "t0.DocEntry , t0.U_CardCode , t0.U_CardName , ";
            //sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            //sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            //sql += "t0.U_NumGuia , t0.U_Patente , t0.U_CantidadBins , t1.U_FechaPeso1 , t1.U_PesoBruto , t1.LineId ";
            //sql += "from  [@HDV_OROM] t0 ";
            //sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry ";
            //sql += "where year(t1.U_FechaPeso2) = 1900 ";
            //sql += "and t0.U_TipoPesaje in ( 'I' ) ";

            //if (razon_acceso == "1")
            //{
            //    sql += "and t0.U_DocEntry_Acceso in ( select DocEntry from [@HDV_OACC] where U_RazonAcceso in ( 1 ) ) ";
            //}
            //else
            //{
            //    sql += "and t0.U_DocEntry_Acceso in ( select DocEntry from [@HDV_OACC] where U_RazonAcceso in ( 3 ) ) ";
            //}

            //sql += "and t0.DocEntry not in ( select U_DocEntry_Ref from [@HDV_ORCAL] where U_Object_Ref = '100100' and U_Estado = 'R' ) ";

            //sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consulta_guias_excluidas()
        {
            string sql;

            sql = "select ";
            sql += "case when year(t1.U_FechaPeso2)=1900 then 'En proceso de pesaje' else 'En proceso de recepción' end as Estado, ";
            sql += "t2.U_CardCode , t2.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.DocEntry as U_NumGuia , t2.Object as Lote , t2.U_CantidadBins , t3.OrdenAfecta , t0.CreateDate as U_FechaPeso1 , t1.U_PesoBruto , t1.LineId , ";
            sql += "coalesce ( ( select top 1 ta1.Kilos from vista_inventario_lotes_completa ta1 where ta1.DistNumber = t2.Object ) , 0 ) as Stock ";

            sql += "";

            sql += "from  [@HDV_OROM] t0 with (nolock) ";
            sql += "inner join [@HDV_ROM2] t1 with (nolock) on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [@HDV_ROM1] t2 with (nolock) on t2.DocEntry = t0.DocEntry ";
            sql += "inner join vista_ProcesosProductivos t3 with (nolock) on t3.Lote = t2.Object ";

            sql += "inner join [@HDV_ROM4] t4 with (nolock) on t4.DocEntry = t0.DocEntry ";

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_guias_excluidas2()
        {
            string sql;

            sql = "select ";
            sql += "case when year(t1.U_FechaPeso2)=1900 then 'En proceso de pesaje' else 'En proceso de recepción' end as Estado, ";
            sql += "t2.U_CardCode , t2.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.DocEntry as U_NumGuia , t2.Object as Lote , t2.U_CantidadBins , '' as OrdenAfecta , t0.CreateDate as U_FechaPeso1 , t1.U_PesoBruto , t1.LineId  ";

            sql += "";

            sql += "from  [@HDV_OROM] t0 with (nolock) ";
            sql += "inner join [@HDV_ROM2] t1 with (nolock) on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [@HDV_ROM1] t2 with (nolock) on t2.DocEntry = t0.DocEntry ";

            sql += "where t0.DocEntry not in ( select t4.DocEntry from [@HDV_ROM4] t4 ) ";

            sql += "and year(t0.CreateDate) >= 2022 and t2.Object <> '0' ";

            sql += "order by U_NumGuia ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }
        public void Consulta_Partidas_abiertas1_dys(String razon_acceso)
        {
            string sql;

            sql = "select ";
            sql += "case when year(t1.U_FechaPeso2)=1900 then 'En proceso de pesaje' else 'En proceso de recepción' end as Estado, ";
            sql += "t2.U_CardCode , t2.U_CardName , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t0.DocEntry as U_NumGuia , t2.Object as Lote , t2.U_CantidadBins , t3.OrdenAfecta , t1.U_FechaPeso1 , t1.U_PesoBruto , t1.LineId ";
            sql += "";

            sql += "from  [@HDV_OROM] t0 with (nolock) ";
            sql += "inner join [@HDV_ROM2] t1 with (nolock) on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [@HDV_ROM1] t2 with (nolock) on t2.DocEntry = t0.DocEntry ";
            sql += "inner join vista_ProcesosProductivos t3 with (nolock) on t3.Lote = t2.Object ";

            sql += "where t0.U_TipoPesaje = 'I' ";
            sql += "and t0.U_Est_Vigente != 'N' ";

            if (razon_acceso == "1")
            {
                sql += "and t1.U_FechaPeso1 = '19000101' ";

            }

            if (razon_acceso == "2")
            {
                sql += "and t1.U_FechaPeso1 <> '19000101' ";
                sql += "and t1.U_FechaPeso2 = '19000101' ";

            }

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_of(String razon_acceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t2.U_NumOC , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemCode from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemCode , ";
            sql += "coalesce ( ( select top 1 t1.U_ItemName from [@HDV_ROM1] t1 where t1.DocEntry = t0.DocEntry order by LineId ) , '' ) as U_ItemName , ";
            sql += "t1.U_PesoBruto , t1.U_FechaPeso1 , t1.LineId "; // t0.U_NumGuia , t0.U_Patente , t0.U_CantidadBins , 

            sql += "from  [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM2] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [@HDV_ROM1] t2 on t2.DocEntry = t0.DocEntry ";

            sql += "where year(t1.U_FechaPeso2) = 1900 ";
            sql += "and U_Patente = '' and U_NumGuia = 0 ";

            sql += "and t0.DocEntry not in ( select U_DocEntry_Ref from [@HDV_ORCAL] where U_Object_Ref = '100100' and U_Estado = 'R' ) ";

            sql += "order by t1.U_FechaPeso1 desc ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_x_id(int id_romana, int nLineId)
        {
            string sql;

            sql = "exec SAPB1_ROMANA1 " + id_romana + " , " + nLineId;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_x_id_exc(int id_romana)
        {
            string sql;

            sql = "SELECT DocEntry FRom [@HDV_ROM4] where DocEntry = " + id_romana;

            this.ComandoSql = sql;
            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_x_id2(int docentry , int lineid)
        {
            string sql;

            sql = "exec SAPB1_RECEPCION6 " + docentry + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consulta_Partidas_abiertas_x_id1(int docentry, int lineid)
        {
            string sql;

            sql = "exec SAPB1_RECEPCION4 " + docentry + " , " + lineid;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Nuevo_DocEntry()
        {
            string sql;

            sql = "select max(DocEntry) as DocEntry from [@HDV_OROM]";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_ItemCode_OC(string d_NumOC)
        {
            string sql;

            sql = "select t1.ItemCode , t1.Dscription from OPOR t0 inner join POR1 t1 on t1.DocEntry = t0.DocEntry  where t0.DocNum = " + d_NumOC;

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_lista_bins()
        {
            string sql;

            sql = "select ";
            sql += "ItemCode , ItemName , BWeight1 ";
            sql += "from OITM ";
            sql += "where ItmsGrpCod = 217 ";

            sql += "union all ";

            sql += "select '_' as ItemCode , '' as ItemName , 0 as BWeight1 ";

            sql += "union all ";

            sql += "select ";
            sql += "ItemCode , ItemName , BWeight1 ";
            sql += "from OITM ";
            sql += "where ItmsGrpCod = 235 ";
            sql += "and OnHand > 0 ";

            sql += "order by ItemName ";


            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }
        public void Consulta_fecha_sql()
        {
            string sql;

            sql = "select getdate() as fecha_hora ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_x_id_Detalle(int DocEntry, int LineId)
        {
            string sql;

            sql = "select top 1 ";
            sql += "t0.DocEntry , t0.LineId , ";
            sql += "t0.U_CardCode , t0.U_CardName , ";
            sql += "t0.U_ItemCode , t0.U_ItemName , ";
            sql += "coalesce ( t0.U_NumOC , 0 ) as U_NumOC , ";
            sql += "t0.U_ItemCodeBins  , ";
            sql += "t1.ItmsGrpCod , t2.ItmsGrpNam , t2.U_TipoProducto , ";
            sql += "t1.BuyUnitMsr , ";
            sql += "coalesce ( t0.U_CantidadBins , 0 ) as U_CantBins , ";
            sql += "t3.U_NumGuia , ";
            sql += "coalesce ( ( select top 1 t1.U_PesoNeto from [dbo].[@HDV_ROM2] t1 where t1.DocEntry = t0.DocEntry order by t1.U_FechaPeso1 ) , 0 ) as U_PesoNeto , ";
            sql += "t3.U_PesoGuia , ";
            sql += "t3.U_Patente , t3.U_Conductor , coalesce ( t4.MdAbsEntry , 0 ) as MdAbsEntry , ";
            sql += "upper(t6.ItemName) as ItemName_D , t6.U_HDV_VARIEDAD as U_HDV_VARIEDAD_D , ";
            sql += "coalesce ( t0.U_Codigo_CSG , '' ) as U_Codigo_CSG ,  ";
            sql += "coalesce ( t0.U_LineIDOC , -1 ) as U_LineIDOC ";

            sql += "from [@HDV_ROM1] t0 ";

            sql += "left join OITM t1 on t1.ItemCode = t0.U_ItemCode ";
            sql += "left join OITB t2 on t2.ItmsGrpCod = t1.ItmsGrpCod ";
            sql += "inner join [@HDV_OROM] t3 on t3.DocEntry = t0.DocEntry ";

            sql += "left join ( select ta0.U_RomanaEntry  , ta1.LineId , ta1.U_ItemCode , ta1.U_BaseObject , ta1.U_BaseLine , ta3.MdAbsEntry from [@HDV_OPDX] ta0 ";
            sql += "inner join [@HDV_PDX1] ta1 on ta1.DocEntry = ta0.DocEntry ";
            sql += "inner join OITL ta2 on ta2.DocType = 20 and ta2.DocEntry = ta1.U_BaseLine ";
            sql += "INNER JOIN ITL1 ta3 ON ta3.LogEntry = ta2.LogEntry ) t4 on t4.U_RomanaEntry = t0.DocEntry and t4.LineId = t0.LineId ";
            sql += "left join ( select ta2.DocNum , ta3.ItemCode , ta3.Dscription as ItemName , coalesce ( upper(ta3.U_HDV_VARIEDAD) , '' ) as U_HDV_VARIEDAD from OPOR ta2 inner join POR1 ta3 on ta3.DocEntry = ta2.DocEntry  ) t6 on t6.DocNum = t0.U_NumOC and t6.ItemCode = t0.U_ItemCode  ";
            sql += " ";


            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.LineId = " + LineId + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Detalles_Balanza(int DocEntry, int LineId, int nBalanza)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.LineId , * ";

            sql += "from [@HDV_ROM3] t0 ";

            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.U_LineId = " + LineId + " ";
            sql += "and t0.U_Balanza = " + nBalanza + " ";
            sql += "order by t0.LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Detalles_Balanza1(int DocEntry, int LineId)
        {
            string sql;

            sql = "select ";
            sql += "t0.U_ItemCode , sum(t0.U_CantEnvases) as Envases , sum(t0.U_PesoNeto) as PesoNeto ";

            sql += "from [@HDV_ROM3] t0 ";

            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.U_LineId = " + LineId + " ";

            sql += "group by t0.U_ItemCode  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_x_id_Entrada(int DocEntry, int DocType)
        {
            string sql;

            sql = "select ";
            sql += "ta0.DocEntry , ta0.DocType , ta1.MdAbsEntry ";
            sql += "from OITL ta0 ";
            sql += "inner join ITL1 ta1 ON ta1.LogEntry = ta0.LogEntry ";
            sql += "where ta0.DocEntry = " + DocEntry + " ";
            sql += "and ta0.DocType = " + DocType + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }


        public void Consulta_Partidas_x_id_Codigo(int DocEntry, int LineId)
        {
            string sql;

            sql = "select top 1 t0.LineId ";
            sql += "from[@HDV_ROM1] t0 ";
            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.U_CardCode + t0.U_ItemCode  in (select t0.U_CardCode + t0.U_ItemCode ";
            sql += "from[@HDV_ROM1] t0 ";
            sql += "where t0.DocEntry = " + DocEntry + " ";
            sql += "and t0.LineId = " + LineId + " ) ";
            sql += "and t0.LineId <> " + LineId + " ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_tabla_parametros()
        {
            string sql;

            sql = "select top 1 ";
            sql += "t0.U_Por_Tolerancia_Romana , t0.U_Por_Tolerancia_Romana2 , ";
            sql += "t0.U_Tolerancia_de_Bloqueo , t0.U_Tolerancia_de_Bloqueo2 , ";
            sql += "t0.U_Muestra_Calidad_NUE_FP , t0.U_Muestra_Calidad_NUE_FS , ";
            sql += "t0.U_Muestra_Calidad_ALM_FP , t0.U_Muestra_Calidad_ALM_FS ";

            sql += "from [@HDV_OPARAM] t0 ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_abiertas_x_id_2do_peso(int id_acceso)
        {
            string sql;

            sql = "select ";
            sql += "t0.U_PesoGuia , t1.U_CardCode , t1.U_CardName , ";
            sql += "t1.U_ItemCode , t1.U_ItemName , t1.U_NumOC , ";
            sql += "t1.U_ItemCodeBins , t1.U_CantidadBins , coalesce ( convert ( float , t2.BWeight1 ) , 0 ) as U_PesoBins , ";
            sql += "t0.U_PesoGuia , coalesce ( t1.U_LineIDOC , 0 ) as U_LineIDOC , coalesce ( t1.U_TipoCosecha , '' ) as U_TipoCosecha , ";
            sql += "coalesce ( t1.U_Codigo_CSG , '' ) as U_Codigo_CSG ";

            sql += "from [@HDV_OROM] t0 ";
            sql += "inner join [@HDV_ROM1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join OITM t2 on t2.ItemCode = t1.U_ItemCodeBins ";

            sql += "where t0.U_DocEntry_Acceso = " + id_acceso + " ";
            sql += "group by t0.U_PesoGuia , t1.U_CardCode , t1.U_CardName , t1.U_ItemCode , t1.U_ItemName , t1.U_NumOC , t1.U_ItemCodeBins , t1.U_CantidadBins , t2.BWeight1 , t1.U_LineIDOC , t1.U_TipoCosecha , t1.U_Codigo_CSG  ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Partidas_recepcion_mp(string c_tipo)
        {
            string sql;

            sql = "exec SAPB1_ROMANA3 '" + c_tipo + "' ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void SAPB1_ROMANA8(string c_Tipo)
        {
            string sql;

            sql = "exec SAPB1_ROMANA8  '" + c_Tipo + "'";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Registros_recepcion_mp(string fecha1, string fecha2, string Localidad)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , ";
            sql += "t2.FolioPref , t2.FolioNum , t2.U_DTE_Patente , ";
            sql += "t2.U_DTE_NombreChofer , t2.CardCode , t2.CardName  , ";
            sql += "t2.DocEntry as DocEntry_OPDN , t3.LineNum as LineNum_OPDN , ";
            sql += "t0.CreateDate , t0.DocEntry , t3.ItemCode , ";
            sql += "t4.ItemName , t3.U_HDV_VARIEDAD , t3.Quantity , t3.BaseRef , ";
            sql += "coalesce ( ( select top 1 t6.DocNum from [@HDV_PDX2] t5 inner join OWTR t6 on t6.DocEntry = t5.U_BaseLine where t5.DocEntry = t0.DocEntry ) , 0 ) as DocEntry_OWTR , ";
            sql += "coalesce ( ( select top 1 t5.DocEntry from [@HDV_ORCAL] t5 where t5.U_Object_Ref = '100501' and t5.U_DocEntry_Ref = t2.DocEntry  ) , 0 ) as DocEntry_OCAL ,  ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100501' and ta1.U_DocEntry_Ref = t2.DocEntry   ) , 0 ) as CantRegistros_Calidad ,  ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100501' and ta1.U_Estado = 'A' and ta1.U_DocEntry_Ref = t2.DocEntry  ) , 0 ) as CantRegistros_Aprobados , ";
            sql += "coalesce ( ( select count(*) from [@HDV_ORCAL] ta1 where ta1.U_Object_Ref = '100501' and ta1.U_Estado = 'R' and ta1.U_DocEntry_Ref = t2.DocEntry  ) , 0 ) as CantRegistros_Rechazados  ";
            sql += " ";

            sql += "from [@HDV_OPDX] t0 ";
            sql += "inner join [@HDV_PDX1] t1 on t1.DocEntry = t0.DocEntry ";
            sql += "inner join [OPDN] t2 on t2.DocEntry = U_BaseLine ";
            sql += "inner join [PDN1] t3 on t3.DocEntry = t2.DocEntry ";
            sql += "inner join OITM t4 on t4.ItemCode = t3.ItemCode ";
            sql += "  ";

            sql += "where convert ( varchar(8) , t0.CreateDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";

            sql += "and t0.Handwrtten = '" + Localidad + "' ";
            sql += "order by t0.CreateDate , t0.DocEntry  ";

            sql += "  ";


            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Camiones_Ingresados(string fecha1, string fecha2)
        {
            string sql;

            sql = "select ";
            sql += "t0.DocEntry , t0.DocNum , t0.CreateDate ,  ";
            sql += "t0.U_CardCode , t0.U_CardName , t0.U_Patente ,  ";
            sql += "t0.U_Conductor ,  ";
            sql += "coalesce((select top 1 ta1.U_CardName from[@HDV_ROM1] ta1 where ta1.DocEntry = t1.DocEntry order by ta1.LineId) , '' ) as U_Productor_Romana , ";
            sql += "coalesce((select top 1 ta1.U_ItemName from[@HDV_ROM1] ta1 where ta1.DocEntry = t1.DocEntry order by ta1.LineId) , '' ) as U_ItemName_Romana ,  ";
            sql += "coalesce((select top 1 ta1.U_FechaPeso1 from[@HDV_ROM2] ta1 where ta1.DocEntry = t1.DocEntry order by ta1.LineId) , '' ) as U_FechaPeso1 , ";
            sql += "coalesce((select top 1 ta1.U_FechaPeso2 from[@HDV_ROM2] ta1 where ta1.DocEntry = t1.DocEntry order by ta1.LineId desc) , '' ) as U_FechaPeso2 ,  ";
            sql += "coalesce((select top 1 ta1.CreateDate from[@HDV_OPDX]  ta1 where ta1.U_RomanaEntry = t1.DocEntry order by ta1.DocEntry) , '' ) as U_FechaRecepcion , ";
            sql += "coalesce((select top 1 ta1.CreateTime from[@HDV_OPDX]  ta1 where ta1.U_RomanaEntry = t1.DocEntry order by ta1.DocEntry) , '' ) as U_HoraRecepcion , ";
            sql += "coalesce ((select top 1 ta2.U_Fecha from [@HDV_ORCAL] ta1 inner join [@HDV_RCAL2] ta2 on ta2.DocEntry = ta1.DocEntry where ta1.U_Object_Ref = '100100'  and ta1.U_DocEntry_Ref = t0.DocEntry  order by ta2.U_Fecha desc ) , '' ) as U_FechaHumedad ";

            sql += "from[@HDV_OACC] t0 ";
            sql += "left join[@HDV_OROM] t1 on t1.U_DocEntry_Acceso = t0.DocEntry ";
            sql += "where convert ( varchar(8) , t0.CreateDate , 112 ) between '" + fecha1 + "' and '" + fecha2 + "' ";
            sql += "and t0.U_RazonAcceso = 1 ";
            sql += "order by t0.CreateDate ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Imagenes_de_Romana(int BaseEntry)
        {
            string sql;

            sql = "select ";
            sql += "U_BaseEntry , ";
            sql += "case when VisOrder = 0 then 'Pesaje de Entrada' else 'Pesaje de Salida' end as TipoPesaje , VisOrder , ";
            sql += "LineId , ";
            sql += "convert ( varchar(12) , U_CreateDate , 105 ) + ' ' + convert ( varchar(5) , U_CreateDate , 108 ) as CreateDate , U_Imagen ";
            sql += "from HDV_IMGP03.dbo.[@HDV_OIMG] ";
            sql += "where Object = '100100' ";
            sql += "and U_BaseEntry = " + BaseEntry.ToString() + " ";
            sql += "order by TipoPesaje , LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

        public void Consulta_Imagenes_de_entradaMP(int BaseEntry)
        {
            string sql;

            sql = "select ";
            sql += "U_BaseEntry , ";
            sql += "case when VisOrder = 0 then 'Pesaje de Entrada' else 'Pesaje de Salida' end as TipoPesaje , VisOrder , ";
            sql += "LineId , ";
            sql += "convert ( varchar(12) , U_CreateDate , 105 ) + ' ' + convert ( varchar(5) , U_CreateDate , 108 ) as CreateDate , U_Imagen ";
            sql += "from HDV_IMGP03.dbo.[@HDV_OIMG] ";
            sql += "where Object = '20' ";
            sql += "and U_BaseEntry = " + BaseEntry.ToString() + " ";
            sql += "order by TipoPesaje , LineId ";

            this.ComandoSql = sql;

            this.GestorSqlConsultar();

        }

    }
}
