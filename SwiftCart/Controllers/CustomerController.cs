using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
