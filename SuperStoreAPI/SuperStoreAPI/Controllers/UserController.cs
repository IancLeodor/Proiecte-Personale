using Microsoft.AspNetCore.Mvc;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationView userCreationView)
        {
            if(userCreationView.FirstName.ToLower() == "admin")
            {
                return Problem(
                    type: "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                    title: "Forbidden",
                    detail: "Cannot set FirstName to admin.",
                    statusCode: StatusCodes.Status403Forbidden,
                    instance: HttpContext.Request.Path
                );
            }

            return Ok(await _userService.AddUser(userCreationView));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var userRepo = await _userService.GetUser(userId);
            if (userRepo == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(userId);
            return NoContent();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserCreationView userCreationView)
        {

            var user = await _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (userCreationView.FirstName.ToLower() == "admin")
            {
                return Problem(
                    type: "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                    title: "Forbidden",
                    detail: "Cannot set FirstName to admin.",
                    statusCode: StatusCodes.Status403Forbidden,
                    instance: HttpContext.Request.Path
                );
            }

            await _userService.UpdateUser(userCreationView);

            return NoContent();

        }
    }
}
