using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class negCalidad
    {
        public DataTable lee_CALIDAD_MPXANALIZAR()
        {
            string sql;

            sql = "exec SAPB1_CALIDAD_MPXANALIZAR ";

            SqlConnection conn = new SqlConnection(Conexion.CnBDEmpresa);

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

        public DataTable lee_CALIDAD_MPXANALIZAR1(string c_lote)
        {
            string sql;

            sql = "exec SAPB1_CALIDAD_MPXANALIZAR1 '" + c_lote + "'";

            SqlConnection conn = new SqlConnection(Conexion.CnBDEmpresa);

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

        public DataTable lista_atributos_nueces_mp()
        {
            string sql;

            sql = "select ";
            sql += "DocEntry , U_CodAtr , U_NameAtr  ";
            sql += "from [dbo].[@VID_ATRCONTARTD] ";
            sql += "where DocEntry = 1 ";
            sql += "order by U_CodAtr ";

            SqlConnection conn = new SqlConnection(Conexion.CnBDEmpresa);

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


    }
}
