using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Support()
        {
            return Content("Area: [none], Controller: Home, Action: Support");
        }
        public IActionResult CancellationPolicy()
        {
            return Content("Area: [none], Controller: Home, Action: CancellationPolicy");
        }
        public IActionResult TermsAndCondition()
        {
            return Content("Area: [none], Controller: Home, Action: TermsAndCondition");
        }
        public IActionResult CookiePolicies()
        {
            return Content("Area: [none], Controller: Home, Action: CookiePolicies");
        }
    }
}
