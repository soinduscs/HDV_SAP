using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class negOItem
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public DataTable ListaOITM()
        {
            //carga procedimiento de almacenado
            DataTable TablaDatos = new DataTable("ListaOITM");
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = Conexion.CnBDEmpresa;
                SqlConexion.Open();

                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConexion;
                SqlComando.CommandText = "ListaOITM";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlComando.ExecuteNonQuery();

                SqlDataAdapter SqlAdaptadorDatos = new SqlDataAdapter(SqlComando);
                SqlAdaptadorDatos.Fill(TablaDatos);
            }

            catch (Exception ex)
            {
                TablaDatos = null;
                throw new Exception("Error al intentar ejecutar el procedimiento almacenado" + ex.Message);
            }

            finally
            {
                SqlConexion.Close();
            }

            return TablaDatos;
        }

        public DataTable busca_usractivo(string variable)
        {
            string sql;

            sql = "select top 1 ";
            sql += "ItemCode , ItemName ";
            sql += "from dbo.OITM ";
            //sql += "and t0.Clave = '" & encriptaDato(Trim(clave)) & "' ";

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

        public DataTable oitm_en_orden_de_compra(string num_pedido)
        {
            string sql;

            sql = "select ";
            sql += "ItemCode , ItemName ";
            sql += "from dbo.OITM ";
            sql += "where ItemCode in ( select t1.ItemCode  from OPOR t0 ";
            sql += "inner join POR1 t1 on t1.DocEntry = t0.DocEntry ";
            sql += "where t0.DocNum = " + num_pedido + " ) ";
            sql += "order by ItemName ";

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
