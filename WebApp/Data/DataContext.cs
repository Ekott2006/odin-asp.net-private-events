
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data;

public class DataContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<ScheduledEvent> ScheduledEvents { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<EventAttendee> EventAttendees { get; set; } = default!;
}