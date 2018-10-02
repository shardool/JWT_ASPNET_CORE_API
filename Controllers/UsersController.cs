using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IUserService _userService;

        public APIController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/authenticate")]
        [Route("/authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("whoami")]
        [Route("/whoami")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(new { userId = "Q11070", userName = "Ghanti, Shardul", roles = new string[] { "GLOBAL_ADMIN", "POWERBI_USER" } });
        }
    }
}
