using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DealershipManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace DealershipManager.Controllers
{
  public class DealershipsController : Controller
  {
    private readonly DealershipManagerContext _db;

    public DealershipsController(DealershipManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Dealership> model = _db.Dealerships.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Dealership dealership)
    {
      _db.Dealerships.Add(dealership);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisDealership = _db.Dealerships
          .Include(dealership => dealership.CarEntities)
          .ThenInclude(join => join.Car)
          .Include(dealership => dealership.SalesmanEntities)
          .ThenInclude(join => join.Salesman)
          .FirstOrDefault(dealership => dealership.DealershipId == id);
      return View(thisDealership);
    }
    public ActionResult Edit(int id)
    {
      var thisDealership = _db.Dealerships.FirstOrDefault(dealership => dealership.DealershipId == id);
      return View(thisDealership);
    }

    [HttpPost]
    public ActionResult Edit(Dealership dealership)
    {
      _db.Entry(dealership).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDealership = _db.Dealerships.FirstOrDefault(dealership => dealership.DealershipId == id);
      return View(thisDealership);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDealership = _db.Dealerships.FirstOrDefault(dealership => dealership.DealershipId == id);
      _db.Dealerships.Remove(thisDealership);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}