using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly string connectionString;

        public Conexion()
        {
            connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ReservaHotelDB;Integrated Security=True";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
