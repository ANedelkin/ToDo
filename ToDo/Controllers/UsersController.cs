using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Contracts;
using ToDo.Core.Models;

namespace ToDo.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUser([FromQuery] string userName)
        {
            ListedUser? user = await _userService.GetUserByUserName(userName);
            return user != null ? Ok(new { model = user }) : NotFound();
        }
    }
}
