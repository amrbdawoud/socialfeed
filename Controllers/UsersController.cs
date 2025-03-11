using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialfeed.Models;
using socialfeed.Services.UserService;

namespace socialfeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{id}")]
        public IActionResult EditUser(int id, [FromBody] User user){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _userService.EditUser(id, user);
            if (result == null){
                return BadRequest("Failed to edit user.");
            }
            return CreatedAtAction(nameof(GetUser), new { id = result.Id}, result);
        
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _userService.CreateUser(user);
            if (result == null){
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(GetUser), new { id = result.Id}, result);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {

            return Ok(_userService.GetUser(id));
        }
    }
}
