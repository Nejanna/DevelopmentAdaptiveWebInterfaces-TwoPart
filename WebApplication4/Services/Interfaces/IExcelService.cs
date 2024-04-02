using ClosedXML.Excel;

namespace WebApplication4.Services.Interfaces
{
    public interface IExcelService
    {
        MemoryStream GenerateExcel();
    }
}
