using Microsoft.EntityFrameworkCore;

namespace MspApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Committee> Committees { get; set; }
        
        public DbSet<Event> Events { get; set; }
       
       // public DbSet<WaitingUser> WaitingUsers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
