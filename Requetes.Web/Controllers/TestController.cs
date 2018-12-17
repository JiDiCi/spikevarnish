using Microsoft.AspNetCore.Mvc;

namespace Requetes.Web.Controllers
{
    public class TestController : Controller
    {
        public JsonResult GetSomething()
        {
            return Json("dude");
        }
    }
}
