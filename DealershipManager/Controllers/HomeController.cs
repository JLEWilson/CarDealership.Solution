using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}