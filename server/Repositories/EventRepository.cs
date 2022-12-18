using System;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Models;
using CalendarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CalendarApi.Repositories
{
  public class EventRepository : IEventRepository
  {
    private CalendarDbContext _context;

    public EventRepository(CalendarDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Event> GetEvents()
    {
      return _context.Events.ToList<Event>();
    }
    public Event GetEventById(Guid id)
    {
      return _context.Events.Include(e => e.Attendees).ToList<Event>().First(e => e.Id == id);
    }
    public void DeleteEvent(Guid id)
    {
      Event eventToDelete = _context.Events.ToList<Event>().First(e => e.Id == id);
      _context.Events.Remove(eventToDelete);
      _context.SaveChanges();
    }
    public void CreateEvent(Event newEvent)
    {
      _context.Events.Add(newEvent);
      _context.SaveChanges();
    }
    public void UpdateEvent(Event updatedEvent)
    {
      _context.Events.Update(updatedEvent);
      _context.SaveChanges();
    }
  }
}