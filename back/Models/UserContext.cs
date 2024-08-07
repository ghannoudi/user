using Microsoft.EntityFrameworkCore;

namespace back.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
