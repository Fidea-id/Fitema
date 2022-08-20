using MySql.Data.MySqlClient;
using System.Data;

namespace FitemaAPI.Database
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetDbConnection(DatabaseType databaseType = DatabaseType.Mysql);
    }

    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetDbConnection(DatabaseType databaseType = DatabaseType.Mysql)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (databaseType == DatabaseType.Mysql)
                return new MySqlConnection(connectionString);
            else throw new Exception("Database provider invalid.");
        }
    }

    public enum DatabaseType
    {
        Mysql,
        Mssql
    }

}

