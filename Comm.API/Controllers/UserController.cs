using AutoMapper;
using Comm.DB.Entities;
using Comm.Model.User;
using Comm.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Comm.API.Controllers
{

    [Route("api/controller")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }

        [HttpPost]
        public bool Register(User newUser)
        {
            var result = false;
            var mappedUser = mapper.Map<Person>(newUser);
            userService.Register(mappedUser);
            return result;
        }
    }
}