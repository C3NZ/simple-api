using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using sample_api.Models;

namespace sample_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context) 
        {
            _context = context;
        }

        // GET /api/user
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            IAsyncEnumerable<User> users = _context.Users.AsAsyncEnumerable();

            List<User> all_users = new List<User>();
            await foreach (User user in users) 
            {
                all_users.Add(user);
            }

            return all_users;
        }

        // GET /api/user/username
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            User user = await _context.Users.FindAsync(username);
            if (user == null) {
                return NotFound();
            }

            return user;
        }


        // POST /api/user
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(PostUser), new { ID = user.ID }, user);
        }

        // PUT /api/user
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(PostUser), new { ID = user.ID }, user);
        }

    }
}
