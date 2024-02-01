using System.Data.SqlClient;
using TestBTlab.Models;

namespace TestBTLab.Models
{
    public class TimeSheetCRUD : ITimeSheetCRUD
    {
        private readonly ITimeSheetDBConnection _connection;

        public static List<TimeSheet> timeSheets;

        public TimeSheetCRUD(ITimeSheetDBConnection connection)
        {
            _connection = connection;
            timeSheets = new List<TimeSheet>();
        }

        public IEnumerable<TimeSheet> GetAll()
        {
            timeSheets.Clear();
            using(var connect = _connection.CreateConnection()) 
            {
                connect.Open();
                string sqlExpression = "SELECT * FROM TimeSheet";
                SqlCommand command = new SqlCommand(sqlExpression, connect);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    timeSheets.Add(new TimeSheet() { Id = (int)reader.GetValue(0), employee = (int)reader.GetValue(1), reason = (int)reader.GetValue(2), start_date = (DateTime)reader.GetValue(3), duration = (int)reader.GetValue(4), discounted = (bool)reader.GetValue(5), description = (string)reader.GetValue(6) });
                }
                return timeSheets;
            }
             
        }

        public TimeSheet GetOne(int id) 
        {
            var sheet = timeSheets.FirstOrDefault(x => x.Id == id);
            return sheet;
        }

        public TimeSheet Delete(int id)
        {
            var timeSheet = timeSheets.FirstOrDefault(x => x.Id == id);
            using(var connection = _connection.CreateConnection()) 
            {
                connection.Open();
                string sqlExpression = $"DELETE FROM TimeSheet WHERE id={id}";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
            timeSheets.Remove(timeSheet); 
            return timeSheet;
        }

        public TimeSheet Create(TimeSheet timeSheet)
        {
            string sqlExpression = $"INSERT INTO TimeSheet (employee, reason, start_date, duration, discounted, description) " +
              $"VALUES ('{timeSheet.employee}', '{timeSheet.reason}', '{timeSheet.start_date}','{timeSheet.duration}','{timeSheet.discounted}','{timeSheet.description}')";
            
            using(var connection = _connection.CreateConnection()) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
            timeSheets.Add(timeSheet);
            return timeSheet;
        }

        public TimeSheet Update(TimeSheet timeSheet) 
        {
            var sheet = timeSheets.FirstOrDefault(x => x.Id == timeSheet.Id);

            string sqlExpression = $"UPDATE TimeSheet SET employee = {timeSheet.employee}, reason = {timeSheet.reason}, start_date = '{timeSheet.start_date.ToString("yyyy-MM-dd")}', " +
                $"duration = {timeSheet.duration}, discounted = {Convert.ToByte(timeSheet.discounted)}, description = '{timeSheet.description}'" +
                $"WHERE id={timeSheet.Id}";
            using( var connection = _connection.CreateConnection()) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }

            sheet.employee = timeSheet.employee;
            sheet.reason = timeSheet.reason;
            sheet.start_date = timeSheet.start_date;
            sheet.duration = timeSheet.duration;
            sheet.discounted = timeSheet.discounted;
            sheet.description = timeSheet.description;
            return sheet;
        }
    }
}
