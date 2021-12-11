using System;
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

        [HttpGet("/[controller]/register")]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost("/[controller]/register")]
        public IActionResult Register([FromForm] User newUser)
        {
            var result = userService.Register(newUser);
            return Redirect("/User/login");
        }

        [HttpGet("/[controller]/login")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost("/[controller]/login")]
        public IActionResult Login([FromForm] UserLogin user)
        {
            var result = userService.Login(user);
            if (result)
            {
                return Redirect("/");
            }
            return Redirect("/User/login");
        }
    }
}