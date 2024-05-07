using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Controllers
{
    [Controller]
    public abstract class BaseController : Controller
    {
        #region Private Methods
        protected static string GetHost(HttpContext httpContext)
        {
            var scheme = httpContext.Request.Scheme;
            var host = httpContext.Request.Host.Value;

            return $"{scheme}://{host}";
        }
        #endregion
    }
}
