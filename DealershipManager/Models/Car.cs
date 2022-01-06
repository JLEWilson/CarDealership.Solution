using System.Collections.Generic;

namespace DealershipManager.Models
{
  public class Car
  {
    public Car()
    {
      this.JoinEntities = new HashSet<CarDealership>();
    }

    public int CarId { get; set; }
    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }

    public virtual ICollection<CarDealership> JoinEntities { get;}
  }
}
