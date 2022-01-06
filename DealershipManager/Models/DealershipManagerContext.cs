using Microsoft.EntityFrameworkCore;

namespace DealershipManager.Models
{
  public class DealershipManagerContext : DbContext
  {
    public DbSet<Car> Cars {get;set;}
    public DbSet<Dealership> Dealerships {get;set;}
    public DbSet<Salesman> Salesmen {get;set;}
    public DbSet<CarDealership> CarDealership {get;set;}
    public DbSet<DealershipSalesman> DealershipSalesman {get;set;}

    public DealershipManagerContext(DbContextOptions options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseLazyLoadingProxies();
    }
  }
}