using System.Data.SqlClient;

namespace TestBTLab.Models
{
    public interface ITimeSheetDBConnection
    {
        public SqlConnection CreateConnection();
    }
}
