using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Journey.Infrastructure.DataAccessSQLServer.ConnectionCore
{
    public interface IConnectionFactory
    {
        public IDbConnection SQLConnection { get;}
        public void CloseConnection();
    }
}
