using ExcelTask.Models;
using ExcelTask.ViewModel;

namespace ExcelTask.Services
{
    public interface IExcelDI
    {
        List<PogodaVM> GetMounth(DataContext context, int mounth);
        Task<string> UploadData( IFormFileCollection files, IWebHostEnvironment _appEnvironment, DataContext context);
    }
}