using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class RiderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
