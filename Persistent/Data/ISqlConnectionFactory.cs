using System.Data;

namespace TaskAPI.Persistent.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}