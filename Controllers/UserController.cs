using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using sample_api.Models;

namespace sample_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserContext _context;

        public UserController(UserContext context) 
        {
            _context = context;
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

        // GET /api/user/username
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(PostUser), new { ID = user.ID }, user);
        }

    }
}
