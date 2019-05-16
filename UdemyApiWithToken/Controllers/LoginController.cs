using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Resources;

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
        public IActionResult Accesstoken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                AccessTokenResponse accessTokenResponse = authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);

                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.accesstoken);
                }
                else
                {
                    return BadRequest(accessTokenResponse.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse accessTokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.accesstoken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken()
        {
            return Ok();
        }
    }
}