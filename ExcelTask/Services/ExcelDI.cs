using testExel;
using ExcelTask.Models;
using ExcelTask.ViewModel;

namespace ExcelTask.Services
{
    public class ExcelDI : IExcelDI
    {
        public List<PogodaVM> GetMounth(DataContext context, int mounth)
        {
            
            var data = context.DateDatas
                        .Join(context.HourAndDatas,
                        Day => Day.Id,
                        HD => HD.IdDate,
                        (Day, HD) => new PogodaVM { DateData = Day, HourAndData = HD})
                        .Where(w => w.DateData.Date.Month == mounth).ToList();
            var list = new List<PogodaVM>();
            foreach(var item in data)
            {
                var pogoda = new PogodaVM{DateData = item.DateData, HourAndData = item.HourAndData};
                list.Add(pogoda);
            }
            return list;
        }
        public async Task<string> UploadData( IFormFileCollection files, IWebHostEnvironment _appEnvironment, DataContext context)
        {
            string result = "";
            foreach(var file in files)
            {
                string path = file.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    path = fileStream.Name;
                    await file.CopyToAsync(fileStream);
                }
                var dict = XXX.BuildData(path);
                
                try
                {
                    foreach(var item in dict)
                    {
                        var list = ToModel(item.Value);
                        var date = new DateData 
                        {
                            Date = item.Key,
                            HourAndDatas = list
                        };
                        Console.WriteLine(date.Date.ToString("d"));
                        await context.DateDatas.AddAsync(date);
                    }
                    context.SaveChanges();
                   result = "Download successful";
                }
                catch(Exception ex)
                {
                    result = "Download failed " + ex.Message;
                }
                    
            }
            return result;
        }

        private List<HourAndData> ToModel(List<TestData> data)
        {
            var listHour = new List<HourAndData>();
            foreach(var item in data)
            {
                var hour = new HourAndData();
                hour.AirHumidity = float.Parse(CheckEmpetyProperty(item.RelativeHumidity));
                hour.Hour = TimeOnly.Parse(item.Time + ":00");
                hour.Temperature = float.Parse(CheckEmpetyProperty(item.Temperature));
                hour.Td = float.Parse(CheckEmpetyProperty(item.Td));
                hour.AtmospherePressure = int.Parse(CheckEmpetyProperty(item.AtmospherePressure));
                hour.DirectionWind = item.DirectionWind;
                hour.SpeedWind = int.Parse(CheckEmpetyProperty(item.SpeedWind));
                hour.Cloudiness = int.Parse(CheckEmpetyProperty(item.Cloudiness));
                hour.H = int.Parse(CheckEmpetyProperty(item.H));
                hour.VV = int.Parse(CheckEmpetyProperty(item.VV));
                hour.WeatherConditions = item.WeatherConditions;
                listHour.Add(hour);
            }
            return listHour;
        }
        private string CheckEmpetyProperty(string item) => String.IsNullOrWhiteSpace(item) ? "0" : item;
        
    }
}