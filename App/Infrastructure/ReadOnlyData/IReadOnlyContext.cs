using System.Data;

namespace App.Infrastructure.ReadOnlyData
{
    public interface IReadOnlyContext
    {
        IDbConnection Connection { get; }        
    }
}