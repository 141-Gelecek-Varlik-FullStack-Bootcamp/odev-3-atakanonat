using Comm.Model.User;
using Comm.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Comm.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        // [HttpPost]
        // public Common<Model.User.User> Register([FromBody] User newUser)
        // {
        //     var result = userService.Register(newUser);
        //     return result;
        // }

        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public void Register()
        {
            User newUser = new User();
            newUser.Name = Request.Form["User[Name]"];
            newUser.Username = Request.Form["User[Username]"];
            newUser.Email = Request.Form["User[Email]"];
            newUser.Password = Request.Form["User[Password]"];
            var result = userService.Register(newUser);
        }
    }
}