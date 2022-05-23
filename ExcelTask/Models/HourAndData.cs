

namespace ExcelTask.Models
{
    public class HourAndData
    {
       public int Id { get; set; }
        public int IdDate { get; set; }
        public TimeOnly Hour { get; set;}
        public float Temperature { get; set;}
        public float AirHumidity { get; set; }
        public float Td { get; set; }
        public int AtmospherePressure { get; set; }
        public string DirectionWind { get; set; }
        public int SpeedWind { get; set; }
        public int Cloudiness { get; set; }
        public int H { get; set; }
        public int VV { get; set; }
        public string WeatherConditions { get; set; }
        public DateData DateData { get; set; }

        public HourAndData()
        {
            DateData = new DateData();
            DirectionWind = " ";
            WeatherConditions = " ";
        }
    }
}