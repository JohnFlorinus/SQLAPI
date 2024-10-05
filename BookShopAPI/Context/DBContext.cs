using Microsoft.Data.SqlClient;

namespace BookShopAPI.Context
{
    public class DBContext
    {
        private readonly string _connectionString = "";
        public DBContext(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SqlServerDB"] ?? "";
        }

        public SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
