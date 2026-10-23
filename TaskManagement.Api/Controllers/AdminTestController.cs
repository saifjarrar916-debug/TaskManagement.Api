
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Utility;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminTestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetSomething()
        {
            return Ok("You are an authorized user");
        }

        [HttpGet("admin")]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult GetAdminSomething()
        {
            return Ok("You are an Admin");
        }
    }
}
