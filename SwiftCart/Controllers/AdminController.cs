using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
