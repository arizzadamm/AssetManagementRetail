using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AssetManagementRetail.Data
{
    public class AssetDBConn
    {
        private readonly IConfiguration _configuration;

        public AssetDBConn(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NpgsqlConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("MyDatabase");
            return new NpgsqlConnection(connectionString);
        }
    }
}
