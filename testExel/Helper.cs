using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Globalization;

namespace testExel;

public class Helper : IHelper
{
    private int Count { get; set; }
    public string Path { get; set;}
    public IWorkbook workbook { get; set; }
    public ISheet sheet { get; set; }
    private List<DateOnly> dates { get; set; }
    private List<List<string>> allData { get; set; }
    public Helper(string path)
    {
        Path = path;
        dates = new List<DateOnly>();
        allData = new List<List<string>>();
        try 
        {
            using(FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                if (path.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                else if (path.IndexOf(".xls") > 0) 
                    workbook = new HSSFWorkbook(fs);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        sheet = workbook.GetSheetAt(Count);
    }
    public void ReadExcel()
    {   
        Count = workbook.NumberOfSheets;
        for(int i = 0; i < Count; i++)// проход по листам
        {
            sheet = workbook.GetSheetAt(i);
            if(sheet != null)
            {
                int rowCount = sheet.LastRowNum; // This may not be valid row count.
        	    IRow headerRow = sheet.GetRow(4);   
                
                int cellCount = headerRow.LastCellNum;  // Проход по колонкам Excel
                
                for (int r = (sheet.FirstRowNum + 4); r <= sheet.LastRowNum; r++) //проход по строчкам Excel  
                {
                    IRow row = sheet.GetRow(r); 
                    if (row == null) continue;  
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;  
                    dates.Add(DateOnly.ParseExact(row.GetCell(0).ToString().Replace('.','/'), "dd/MM/yyyy",CultureInfo.InvariantCulture));
                    GetAllData(row, cellCount);
                }
            }
        } 
    }
    private List<List<string>> GetAllData(IRow row, int cellCount)
    {
        var list = new List<string>();
        for (int j = row.FirstCellNum; j <= cellCount; j++)  
        {  
            if (row.GetCell(j) == null)
            {
                //string s = row.GetCell(j).ToString();
                string s = " ";
                list.Add(s);
            }
            else
                list.Add(row.GetCell(j).ToString());            
        }
        allData.Add(list);
        return allData;
    }

    public List<DateOnly> TakeDates()
    {
        return dates.Distinct().ToList();
    }

    public List<List<string>> TakeAllData()
    {
        return allData;
    }
}