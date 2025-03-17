using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Clone_users_ms.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUserData()
        {
            return Ok("Hello World");
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetUserDataById(int id)
        {
            return Ok("Hello World");
        }
    }
}
