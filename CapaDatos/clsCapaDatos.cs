using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Configuration;

namespace CapaDatos
{
    public class GestorSql
    {
        public string ComandoSql;
        public DataTable Resultado;
        public Boolean HayDatos;
        public int Filas;
        
        public bool  GestorUpdate()
        {
            bool validador = false;

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));
            conn.Open();
            SqlCommand ddSqlCommand = new SqlCommand(this.ComandoSql, conn);

            try
            {                     
                ddSqlCommand.ExecuteNonQuery();
                ddSqlCommand.CommandTimeout = 999999;
                validador = true;
            }
            catch
            {
                validador = false;
            }
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch
            {
            }
        
            return validador;
        }

        public void GestorSqlConsultar()
        {

            //SqlConnection conn = new SqlConnection(cConexion_SAP);
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("String_SAP"));

            SqlCommand ddSqlCommand = new SqlCommand(this.ComandoSql, conn);
            ddSqlCommand.CommandTimeout = 99999999;
            SqlDataAdapter dAd = new SqlDataAdapter(ddSqlCommand);
            DataSet dSet = new DataSet();
            try

            {
                dAd.Fill(dSet, "data");
                this.Resultado =  dSet.Tables["data"];
                
                this.Filas = this.Resultado.Rows.Count;

                if (this.Filas==0)
                {
                    this.HayDatos = false;
                }
                else
                {
                    this.HayDatos = true;
                }

            }
            catch
            {

                this.Resultado = null;
                this.Filas = 0;
                this.HayDatos = false;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }

        }
        
        


    }
}
