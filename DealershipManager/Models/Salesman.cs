using System.Collections.Generic;

namespace DealershipManager.Models
{
  public class Salesman
  {
    public Salesman()
    {
      this.JoinEntities = new HashSet<DealershipSalesman>();
    }

    public int SalesmanId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<DealershipSalesman> JoinEntities { get;}
  }
}
