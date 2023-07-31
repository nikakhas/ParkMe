using Microsoft.AspNetCore.Mvc;

namespace ParkMe.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View("~/wwwroot/mapviews.html");
        }
    }
}