using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VersionController : ControllerBase
    {

        
            private readonly IExcelService _excelService;

            public VersionController(IExcelService excelService)
            {
                _excelService = excelService;
            }

            [HttpGet]
            [Route("Lab9")]
            public IActionResult GetData([FromQuery] string version)
            {
                switch (version)
                {
                    case "1.0":
                    var random = new Random();
                    var result = random.Next();
                    return Ok(result);
                    case "2.0":
                        return Ok("Hello, World!");
                    case "3.0":
                        MemoryStream excelStream = _excelService.GenerateExcel();
                        return File(excelStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "fileXLSX.xlsx");
                    default:
                        return NotFound();
                }
            }
        }
    }
