using Microsoft.AspNetCore.Mvc;

namespace Portal.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
