using Microsoft.AspNetCore.Mvc;

namespace rapid.Areas.Account.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
