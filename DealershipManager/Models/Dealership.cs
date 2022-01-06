using System.Collections.Generic;
namespace DealershipManager.Models
{
  public class Dealership
  {
    public Dealership()
    {
      this.CarEntities = new HashSet<CarDealership>();
      this.SalesmanEntities = new HashSet<DealershipSalesman>();
    }
    public int DealershipId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<CarDealership> CarEntities {get;set;}
    public virtual ICollection<DealershipSalesman> SalesmanEntities {get;set;}
  }
}