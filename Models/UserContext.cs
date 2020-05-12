using Microsoft.EntityFrameworkCore;

namespace sample_api.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
