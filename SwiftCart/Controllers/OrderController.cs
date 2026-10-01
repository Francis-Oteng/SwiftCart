using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
