using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiPoloNorte.Repository
{
    public class Conexion
    {

        protected string ConnectionString;


        public Conexion()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB_POLO_NORTE"].ConnectionString;
        }
        protected SqlConnection GetConexion()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}