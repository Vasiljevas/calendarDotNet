using System;
using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IEventService
  {
    public IEnumerable<Event> GetEventsByUserId(Guid userId);
    public Event GetEventById(Guid id);
    public Event CreateEvent(Event eventToCreate, Guid userId);
    public Event DeleteEvent(Guid id);
    public Event UpdateEvent(Event eventToUpdate);

  }
}