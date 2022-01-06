using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DealershipManager.Models
{
  public class DealershipManagerContextFactory : IDesignTimeDbContextFactory<DealershipManagerContext>
  {
    DealershipManagerContext IDesignTimeDbContextFactory<DealershipManagerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var builder = new DbContextOptionsBuilder<DealershipManagerContext>();

        builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

        return new DealershipManagerContext(builder.Options);
    }
  }
}