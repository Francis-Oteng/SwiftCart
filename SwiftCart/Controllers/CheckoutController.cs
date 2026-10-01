using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
