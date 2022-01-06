using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DealershipManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace DealershipManager.Controllers
{
  public class CarsController : Controller
  {
    private readonly DealershipManagerContext _db;

    public CarsController(DealershipManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Cars.ToList());
    }

    public ActionResult Create()
    {
      SelectList dbData = new SelectList(_db.Dealerships, "DealershipId", "Name");
      //Create the select list item you want to add
      SelectListItem selListItem = new SelectListItem() { Value = "0", Text = "None" };
      //Create a list of select list items - this will be returned as your select list
      List<SelectListItem> newList = new List<SelectListItem>();
      //Add select list item to list of selectlistitems
      newList.Add(selListItem);
      newList.AddRange(dbData);
      //Return the list of selectlistitems as a selectlist
      ViewBag.DealershipId = new SelectList(newList, "Value", "Text", null);

      return View();
    }


    [HttpPost]
    public ActionResult Create(Car car, int DealershipId)
    {
      _db.Cars.Add(car);
      _db.SaveChanges();
      if (DealershipId != 0)
      {
        _db.CarDealership.Add(new CarDealership() { DealershipId = DealershipId, CarId = car.CarId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCar = _db.Cars
          .Include(car => car.JoinEntities)
          .ThenInclude(join => join.Dealership)
          .FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    public ActionResult Edit(int id)
    {
      var thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    [HttpPost]
    public ActionResult Edit(Car car, int DealershipId, int PreviousDealershipId)
    {

      _db.Entry(car).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDealership(int id)
    {
      var thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      ViewBag.DealershipId = new SelectList(_db.Dealerships, "DealershipId", "Name");
      return View(thisCar);
    }

    [HttpPost]
    public ActionResult AddDealership(Car car, int DealershipId)
    {
      if (DealershipId != 0)
      {
      _db.CarDealership.Add(new CarDealership() { DealershipId = DealershipId, CarId = car.CarId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      _db.Cars.Remove(thisCar);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDealership(int joinId)
    {
      var joinEntry = _db.CarDealership.FirstOrDefault(entry => entry.CarDealershipId == joinId);
      _db.CarDealership.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
