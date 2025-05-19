using HOA.Areas.Identity.Data;
using HOA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HOA.Data;

public class HOAContext : IdentityDbContext<HOAUser>
{
    public HOAContext(DbContextOptions<HOAContext> options)
        : base(options)
    {
    }

    public DbSet<Resident> Residents { get; set; } = default!;

    public DbSet<Payment> Payments { get; set; } = default!;

    public DbSet<Event> Events { get; set; } = default!;

    public DbSet<Maintenance> Maintenances { get; set; } = default!;

    public DbSet<Announcement> Announcements { get; set; } = default!;

    public DbSet<User> Users { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
