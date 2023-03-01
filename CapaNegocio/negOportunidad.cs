using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class negOportunidad
    {

        public string DocNum { get; set; }

        public DataTable opor_pendientes_x_cardcode(string cardcode)
        {
            string sql;

            sql = "select t0.* ";
            sql += "from OPOR t0 ";
            sql += "where t0.CardCode = '" + cardcode.Trim() + "' ";
            sql += "and t0.DocEntry in (select t1.DocEntry from POR1 t1 ";
            sql += "where t1.TargetType = -1 ";
            //sql += "and t0.CANCELED = 'N' ";
            sql += "and t1.WhsCode not in ('BASCP' , 'BPTP1' , 'BPTP2' , 'BPTP3' ) )  ";
            sql += "order by t0.DocNum ";

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
