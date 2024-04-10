using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication4.Services.Health
{
    public class HealthChecksDb : DbContext
    {
        public HealthChecksDb(DbContextOptions<HealthChecksDb> options) : base(options)
        {

        }

        public DbSet<HealthModel> HealthModel{ get; set; }
    }
}
