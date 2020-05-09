using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Journey.SQLServerDataAccess.ConnectionCore
{
    public interface IConnectionFactory
    {
        public IDbConnection SQLConnection { get;}
        public void CloseConnection();
    }
}
