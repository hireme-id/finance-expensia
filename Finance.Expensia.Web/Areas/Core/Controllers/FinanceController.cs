using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.Core.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
