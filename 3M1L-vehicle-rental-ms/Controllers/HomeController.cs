using Microsoft.AspNetCore.Mvc;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
