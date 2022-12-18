using Microsoft.EntityFrameworkCore;
using CalendarApi.Models;

namespace CalendarApi.Data
{
  public class CalendarDbContext : DbContext
  {
    public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<User> Users { get; set; }

  }
}