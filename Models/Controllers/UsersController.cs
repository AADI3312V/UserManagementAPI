using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // GET: api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
public IActionResult GetUser(int id)
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound("User not found");

        return Ok(user);
    }
    catch (Exception)
    {
        return StatusCode(500, "Internal server error");
    }
}

        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            users.Add(user);
            return Ok(user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return Ok(user);
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            users.Remove(user);
            return Ok();
        }
    }
}