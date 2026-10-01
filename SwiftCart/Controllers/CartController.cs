using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
