using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult List(string id = "All")
        {
            return Content($"Area: [none], Controller: Service, Action: List, ID: {id}");
        }
    }
}
