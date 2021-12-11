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

        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] User newUser)
        {
            var result = userService.Register(newUser);
            return Redirect("/User");
        }
    }
}