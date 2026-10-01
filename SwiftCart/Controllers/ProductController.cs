using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
