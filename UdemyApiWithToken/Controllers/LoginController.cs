using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Services;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Accesstoken()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult RefreshToken()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken()
        {
            return Ok();
        }
    }
}