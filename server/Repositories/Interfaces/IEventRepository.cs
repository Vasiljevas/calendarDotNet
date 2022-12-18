using System;
using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IEventRepository
  {
    public IEnumerable<Event> GetEvents();
    public Event GetEventById(Guid id);
    public void DeleteEvent(Guid id);
    public void CreateEvent(Event newEvent);
    public void UpdateEvent(Event updatedEvent);

  }
}