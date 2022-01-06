namespace DealershipManager.Models
{
  public class DealershipSalesman
  {
    public int DealershipSalesmanId {get;set;}
    public int DealershipId {get;set;}
    public int SalesmanId {get;set;}
    public virtual Dealership Dealership {get;set;}
    public virtual Salesman Salesman {get;set;}
  }
}