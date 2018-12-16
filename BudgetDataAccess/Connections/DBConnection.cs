using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Connections
{
    public class DBConnection
    {
        public static IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetDB"].ConnectionString);
            return conn;
        }
    }
}
