using System;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Models;
using CalendarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CalendarApi.Repositories
{
  public class AttendeeRepository : IAttendeeRepository
  {
    private CalendarDbContext _context;

    public AttendeeRepository(CalendarDbContext context)
    {
      _context = context;
    }
    public IEnumerable<Attendee> GetAttendees()
    {
      return _context.Attendees.ToList<Attendee>();
    }
    public void CreateAttendee(Attendee attendee)
    {
      _context.Attendees.Add(attendee);
      _context.SaveChanges();
    }
  }
}