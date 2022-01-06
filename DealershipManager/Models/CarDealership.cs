namespace DealershipManager.Models
{
  public class CarDealership
  {
    public int CarDealershipId { get; set; }
    public int CarId { get; set; }
    public int DealershipId { get; set; }
    public virtual Car Car { get; set; }
    public virtual Dealership Dealership { get; set; }
  }
}
