using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DealershipManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace DealershipManager.Controllers
{
  public class SalesmenController : Controller
  {
    private readonly DealershipManagerContext _db;

    public SalesmenController(DealershipManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Salesmen.ToList());
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
    public ActionResult Create(Salesman salesman, int DealershipId)
    {
      _db.Salesmen.Add(salesman);
      _db.SaveChanges();
      if (DealershipId != 0)
      {
        _db.DealershipSalesman.Add(new DealershipSalesman() { DealershipId = DealershipId, SalesmanId = salesman.SalesmanId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSalesman = _db.Salesmen
          .Include(salesman => salesman.JoinEntities)
          .ThenInclude(join => join.Dealership)
          .FirstOrDefault(salesman => salesman.SalesmanId == id);
      return View(thisSalesman);
    }

    public ActionResult Edit(int id)
    {
      var thisSalesman = _db.Salesmen.FirstOrDefault(salesman => salesman.SalesmanId == id);
      return View(thisSalesman);
    }

    [HttpPost]
    public ActionResult Edit(Salesman salesman, int DealershipId)
    {
      if (DealershipId != 0)
      {
        _db.DealershipSalesman.Add(new DealershipSalesman() { DealershipId = DealershipId, SalesmanId = salesman.SalesmanId });
      }
      _db.Entry(salesman).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDealership(int id)
    {
      var thisSalesman = _db.Salesmen.FirstOrDefault(salesman => salesman.SalesmanId == id);
      ViewBag.DealershipId = new SelectList(_db.Dealerships, "DealershipId", "Name");
      return View(thisSalesman);
    }

    [HttpPost]
    public ActionResult AddDealership(Salesman salesman, int DealershipId)
    {
      if (DealershipId != 0)
      {
      _db.DealershipSalesman.Add(new DealershipSalesman() { DealershipId = DealershipId, SalesmanId = salesman.SalesmanId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSalesman = _db.Salesmen.FirstOrDefault(salesman => salesman.SalesmanId == id);
      return View(thisSalesman);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSalesman = _db.Salesmen.FirstOrDefault(salesman => salesman.SalesmanId == id);
      _db.Salesmen.Remove(thisSalesman);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDealership(int joinId)
    {
      var joinEntry = _db.DealershipSalesman.FirstOrDefault(entry => entry.DealershipSalesmanId == joinId);
      _db.DealershipSalesman.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}