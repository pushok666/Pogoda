

namespace ExcelTask.Models
{
    public class DateData
    {
        public int Id { get; set; }
        public DateOnly Date { get; set;}
        public ICollection<HourAndData> HourAndDatas { get; set; } 
        public DateData()
        {
            HourAndDatas = new List<HourAndData>();
        }
    }
}