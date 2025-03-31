
using Microsoft.EntityFrameworkCore;

namespace HOA.Models
{
    public class HOADbContext : DbContext
    {
        public HOADbContext(DbContextOptions<HOADbContext> options): base(options) { }

        //public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<Residents> Residents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<Login> Login { get; set; }

    }
}
