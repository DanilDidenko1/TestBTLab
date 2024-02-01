using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace TestBTLab.Models
{
    public class TimeSheetDBConnection : ITimeSheetDBConnection
    {
        //private readonly string connectionString = "Data Source=DESKTOPDANIL\\SQLEXPRESS;Initial Catalog=TaskBTlab;Integrated Security=True";;
        private readonly IConfiguration _configuration;
        public TimeSheetDBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
