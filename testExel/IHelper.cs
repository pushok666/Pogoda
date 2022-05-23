
using NPOI.SS.UserModel;

interface IHelper
{
    string Path { get; set; }
    IWorkbook workbook { get; set; }
    ISheet sheet { get; set; }
}