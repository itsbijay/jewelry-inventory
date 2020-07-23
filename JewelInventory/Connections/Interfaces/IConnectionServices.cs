using System;
using System.Data.Common;

namespace Connections
{
    public interface IConnectionServices : IValidator
    {
        String CreateConnectionString<T>(T request) where T : DbConnectionStringBuilder;
        bool CheckConnection(String ConnectionString);
        String GetEntitySqlConnectionString();
    }
}