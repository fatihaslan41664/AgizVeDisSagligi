using Microsoft.AspNetCore.Mvc;

namespace AgizVeDisSagligi.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
