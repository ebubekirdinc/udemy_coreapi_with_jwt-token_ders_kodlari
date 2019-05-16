using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IActionResult bir()
        {
            return Ok("bu method da kimlik doğrulama yoktur");
        }

        [Authorize]
        public IActionResult iki()
        {
            return Ok("bu method da kimlik doğrulama vardır.");
        }
    }
}