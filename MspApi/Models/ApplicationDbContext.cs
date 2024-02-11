using Microsoft.EntityFrameworkCore;

namespace MspApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<WaitingUser> WaitingUsers { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
