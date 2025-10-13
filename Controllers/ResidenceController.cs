using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Controllers
{
    public class ResidenceController : Controller
    {
        public IActionResult List(string id = "All")
        {
            return Content($"Area: [none], Controller: Residence, Action: List, ID: {id}");
        }
    }
}
