using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Journey.SQLServerDataAccess.ConnectionCore
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IOptions<ConnectionConfig> Config;
        private IDbConnection Connection;
        public ConnectionFactory(IOptions<ConnectionConfig> config)
        {
            this.Config = config;
        }
        public IDbConnection SQLConnection
        {
            get
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(Config.Value.ConnectionString);
                }
                if (this.Connection.State != ConnectionState.Open)
                {
                    this.Connection.Open();
                }
                return this.Connection;
            }
        }
        public void CloseConnection()
        {
            if (this.Connection != null && this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
            }
        }
    }
}
