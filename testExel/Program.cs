using System.Globalization;

namespace testExel;

public class XXX
{
    static void Main()
    {}
    public static Dictionary<DateOnly, List<TestData>> BuildData(string path)
    {
        //Console.WriteLine("Hello, World!");
        var listObj = new List<TestData>();
        //var path = "/home/pasha/Documents/exelFiles/moskva_2010.xlsx";
        Helper helper = new Helper(path);
        helper.ReadExcel();
        var listDate = helper.TakeDates();
        var listHours = helper.TakeAllData();
        var dict  = new Dictionary<DateOnly, List<TestData>>();
        foreach(var item in listHours)
        {
            var obj = new TestData();
            obj.Date = DateOnly.ParseExact(item[0].Replace('.','/'), "dd/MM/yyyy",CultureInfo.InvariantCulture);
            obj.Time = item[1];
            obj.Temperature = item[2];
            obj.RelativeHumidity = item[3];
            obj.Td = item[4];
            obj.AtmospherePressure = item[5];
            obj.DirectionWind = item[6];
            obj.SpeedWind = item[7];
            obj.Cloudiness = item[8];
            obj.H = item[9];
            obj.VV = item[10];
            obj.WeatherConditions = item[11];
            listObj.Add(obj);
        }

        foreach(var item in listDate)
        {
            var list = listObj.Where(w => w.Date == item).ToList();
            dict.Add(item, list);
        }
        return dict;
    }
}