using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Gifts.DBHelper
{
    public static class DBManager
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public static IDbConnection DbConnect()
        {
            IDbConnection connection = new SqlConnection(GetConnectionString());
            return connection;
        }
        public static string GetConnectionName()
        {
            return "DefaultConnection";
        }
    }
}