using Microsoft.AspNetCore.Mvc;

namespace Portal.PL.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Department()
        {
          
            return View();

        }
    }
}
