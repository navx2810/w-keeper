using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Keeper.Code;
using Keeper.Code.Validators;
using Keeper.Code.Auth.Challenges;
using System.Web;

namespace Keeper.Controllers
{
    [Route("api/account")]
    public class Account : Controller
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromServices] IAppTokenizer tokenizer, [FromServices] Code.Keeper db, [FromBody] Code.Models.User user, [FromServices] IUserChallenge challenge)
        {
            challenge.HasPassword(user);
            challenge.HasName(user);
            var me = db.Users.Where(u => u.Name.Equals(user.Name) && u.Password.Equals(user.Password)).FirstOrDefault();
            if(me != null) {
                LogUserIn(me, tokenizer);                
            }
            if(challenge.Errors.HasAny) { return BadRequest(challenge.Errors.Response); } 
            return BadRequest("Invalid information.");
        }

        [HttpGet, Route("logout")]
        public IActionResult Logout([FromServices] Code.Keeper db)
        {
            string user = Request.Cookies["user"];
            Response.Cookies.Delete("user");
            if(string.IsNullOrEmpty(user)) { return NoContent(); }
            else { return Ok(); }
        }

        [HttpPost, Route("create")]
        public IActionResult Create ([FromServices] IAppTokenizer tokenizer, [FromServices] Code.Keeper db, [ModelBinder] Code.Models.User user, [FromServices] IUserChallenge challenge)
        {
            challenge.HasName(user);
            challenge.HasPassword(user);
            user.Id = 0;
            if(challenge.Errors.HasAny) { return BadRequest(challenge.Errors.Response); }
            var me = db.Users.FirstOrDefault(u => u.Name.Equals(user.Name));
            if(me != null) { LogUserIn(me, tokenizer); }
            else {
                db.Users.Add(user);
                db.SaveChangesAsync();
                LogUserIn(user, tokenizer);
            }
            return Created($"/api/users/{user.Id}", new { Name = user.Name });
        }

        [HttpGet, Route("/api/me")]
        public IActionResult Me([FromServices] Code.Keeper db, [FromServices] IAppTokenizer tokenizer)
        {
            var cu = tokenizer.Decode(Request.Cookies["user"]);
            if(cu != null) {
                var user = db.Users.Find();
                return Json(new { Name = user.Name });
            }
            return BadRequest("You are not logged in.");
        }

        private void LogUserIn(Code.Models.User user, [FromServices] IAppTokenizer tokenizer)
        {
            var cu = new Code.DAO.ClientUser { Id = user.Id, IP = Request.Host.Host};
            Response.Cookies.Delete("user");
            Response.Cookies.Append("user", tokenizer.Encode(cu), new CookieOptions { Expires = DateTime.Now.AddHours(1), SameSite = SameSiteMode.Strict });
        }
    }
}