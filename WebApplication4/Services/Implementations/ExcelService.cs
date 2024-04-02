using ClosedXML.Excel;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class ExcelService : IExcelService
    {
        public MemoryStream GenerateExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");
                worksheet.Cell("A1").Value = "Hello";
                worksheet.Cell("B1").Value = "World";

                // Відправляємо файл клієнту як відповідь на запит

                // Потім зберігаємо робочий зошит у потік пам'яті
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0; // Поверніть позицію потоку на початок перед поверненням його
                return stream;
            }
        }
    }
}
