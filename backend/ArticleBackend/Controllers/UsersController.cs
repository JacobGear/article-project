using ArticleBackend.Interfaces;
using ArticleBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Get All Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        // Get User by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Create User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        // Update User
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            var updatedUser = await _userService.UpdateUser(id, user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        // Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
