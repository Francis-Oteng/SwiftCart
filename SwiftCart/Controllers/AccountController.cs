using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
