using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult GetUser()
        {
            return Ok();
        }

        public IActionResult AddUser(UserResource userResource)
        {
            return Ok();
        }
    }
}