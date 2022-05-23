using ExcelTask.Models;

namespace ExcelTask.ViewModel
{
    public class PogodaVM
    {
        public DateData DateData { get; set; }
        public HourAndData HourAndData { get; set;}
        public PogodaVM()
        {
            DateData = new DateData();
            HourAndData = new HourAndData();
        }
    }
}