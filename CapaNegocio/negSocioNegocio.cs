using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class negSocioNegocio
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int Usr_registro { get; set; }

        public DataTable ListaTCRD_Transportistas()
        {
            string sql;

            sql = "select ";
            sql += "Code , Name ";
            sql += "from [@HDV_OTRD] ";
            sql += "order by Name ";

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand ddSqlCommand = new SqlCommand(sql, conn);
            SqlDataAdapter dAd = new SqlDataAdapter(ddSqlCommand);
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "data");
                return dSet.Tables["data"];
            }
            catch
            {

                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public string SAPB1_TRANSP(negSocioNegocio parRomana)
        {
            string Respuesta = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = ConfigurationManager.AppSettings.Get("String_SAP");
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "dbo.SAPB1_TRANSP";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCardCode = new SqlParameter();
                ParCardCode.ParameterName = "@Code";
                ParCardCode.SqlDbType = SqlDbType.VarChar;
                ParCardCode.Size = parRomana.CardCode.Length;
                ParCardCode.Value = parRomana.CardCode;
                SqlComando.Parameters.Add(ParCardCode);

                SqlParameter ParCardName = new SqlParameter();
                ParCardName.ParameterName = "@Name";
                ParCardName.SqlDbType = SqlDbType.VarChar;
                ParCardName.Size = parRomana.CardName.Length;
                ParCardName.Value = parRomana.CardName;
                SqlComando.Parameters.Add(ParCardName);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usr_Registro";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = parRomana.Usr_registro;
                SqlComando.Parameters.Add(ParUsuario);

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







    }
}
