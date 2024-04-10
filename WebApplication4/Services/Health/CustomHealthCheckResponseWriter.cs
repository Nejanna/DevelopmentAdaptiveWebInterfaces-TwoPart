using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApplication4.Services.Health
{
    public static class CustomHealthCheckResponseWriter
    {
        public static Task WriteResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var response = new
            {
                Status = result.Status.ToString(),
                TotalChecksDuration = result.TotalDuration.TotalMilliseconds,
                Results = result.Entries,
            };

            string json = JsonConvert.SerializeObject(response);

            return httpContext.Response.WriteAsync(json);
        }
    }
}



