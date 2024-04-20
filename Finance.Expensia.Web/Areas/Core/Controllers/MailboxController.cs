using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.Core.Controllers
{
	public class MailboxController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

        [AllowAnonymous]
        public IActionResult Approval()
        {
            return View();
        }
    }
}
