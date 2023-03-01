using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class Conexion
    {
        //public static String CnBDEmpresa = "Data Source=SCL-HDV-DESAR; Initial Catalog=BEMPRESA; User ID=sa;Password=qwedsa_123;Trusted_Connection=no;";
        //public static String CnBDEmpresa = "Server=SCL-HDV-DESAR;Database=BEMPRESA;User Id=sa;Password=qwedsa_123;";
        //public static String CnBDEmpresa = "Server=SCL-HDV-DESAR;Database=BEMPRESA;User Id=sa;Password=qwedsa_123;";

        //public static String CnBDEmpresa = "data source=172.30.126.230;initial catalog=HDV_P03;user id=sa;password=SAPB1Admin;";
        public static String CnBDEmpresa = "data source=172.30.126.230;initial catalog=HDV_FABIAN;user id=sa;password=SAPB1Admin;";
        public String ChequearConexion()

        {
            String mensaje = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = Conexion.CnBDEmpresa;
                SqlConexion.Open();
                mensaje = "Y";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                SqlConexion.Close();
            }

            return mensaje;
        }


    }
}
