using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace TestBTLab.Models
{
    //Класс устанавливающий соединение с БД
    public class TimeSheetDBConnection : ITimeSheetDBConnection
    {
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
