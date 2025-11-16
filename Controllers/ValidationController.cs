using Microsoft.AspNetCore.Mvc;
using Airbnb.Models;

namespace Registration.Controllers
{
    public class ValidationController : Controller
    {
        private AirBnbContext context;
        public ValidationController(AirBnbContext ctx) => context = ctx;

        public JsonResult CheckOwner(int UserId)
        {
            string msg = Check.OwnerExists(context, UserId.ToString());
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okOwner"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
