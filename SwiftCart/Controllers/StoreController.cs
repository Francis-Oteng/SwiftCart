using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
