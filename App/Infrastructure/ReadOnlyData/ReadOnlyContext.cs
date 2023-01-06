using System.Data;
using Microsoft.Data.SqlClient;

namespace App.Infrastructure.ReadOnlyData
{
    public class ReadOnlyContext : IReadOnlyContext, IDisposable
    {
        public IDbConnection Connection { get; }
        
        public ReadOnlyContext(string? connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}