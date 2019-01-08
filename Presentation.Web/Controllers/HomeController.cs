using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetSomething()
        {
            var context = HttpContext;

            HttpContext.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;

                //Cache Matching
                httpContext.Response.Headers.Add("xkey", "654321");
                httpContext.Response.Headers.Add(HeaderNames.ETag, "123456");

                //Allowance
                httpContext.Response.Headers.Add(HeaderNames.CacheControl, "proxy-revalidate, max-age=120");

                //Freshness

                return Task.FromResult(0);
            }, context);

            return Json("dudePresentation");
        }
    }
}
