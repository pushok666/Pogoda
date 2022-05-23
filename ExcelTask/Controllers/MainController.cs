using Microsoft.AspNetCore.Mvc;
using ExcelTask.Models;
using ExcelTask.Services;

namespace ExcelTask.Controllers
{
    public class MainController : Controller
    {
        private readonly DataContext _context;
        private readonly IExcelDI _excelDI;
        private readonly IWebHostEnvironment _appEnvironment;
        public MainController(DataContext dataContext, IWebHostEnvironment appEnvironment, IExcelDI excelDI)
        {
            _context = dataContext;
            _appEnvironment = appEnvironment;
            _excelDI = excelDI;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Watch()
        {
            return View();
        }
        [Route("Main/Watch/{id}")]
        public IActionResult Watch(int id)
        {
            return View(_excelDI.GetMounth(_context, id));
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {     
            return View((object) await _excelDI.UploadData(files, _appEnvironment, _context));
        }
    }
}