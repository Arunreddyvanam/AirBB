using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult List(string id = "All")
        {
            return Content($"Area: [none], Controller: Experience, Action: List, ID: {id}");
        }
    }
}
