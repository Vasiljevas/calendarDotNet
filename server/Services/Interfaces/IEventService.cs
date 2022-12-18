using System;
using System.Collections.Generic;
using CalendarApi.DTOs;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IEventService
  {
    public IEnumerable<EventDto> GetEventsByUserId(Guid userId);
    public EventDetailDto GetEventById(Guid id);
    public EventDetailDto CreateEvent(Event eventToCreate, Guid userId);
    public IEnumerable<EventDto> DeleteEvent(Guid id, Guid userId);
    public EventDetailDto UpdateEvent(Guid userId, Event eventToUpdate);

  }
}