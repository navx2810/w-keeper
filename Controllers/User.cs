using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [Route("api/user")]
    public class User : Controller
    {
        [HttpGet]
        public IActionResult Get(Keeper.Code.Keeper db)
        {
            return Json(db.Users);
        }
    }
}