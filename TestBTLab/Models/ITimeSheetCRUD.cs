using TestBTlab.Models;

namespace TestBTLab.Models
{
    public interface ITimeSheetCRUD
    {
        public IEnumerable<TimeSheet> GetAll();
        public TimeSheet GetOne(int id);
        public TimeSheet Delete(int id);
        public TimeSheet Create(TimeSheet timeSheet);
        public TimeSheet Update(TimeSheet timeSheet);
    }
}
