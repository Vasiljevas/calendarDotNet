using System;
using CalendarApi.Models;
using CalendarApi.Services.Interfaces;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.DTOs;

namespace CalendarApi.Services
{
  public class EventService : IEventService
  {
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;

    public EventService(IEventRepository eventRepo, IUserRepository userRepo)
    {
      this._eventRepository = eventRepo;
      this._userRepository = userRepo;
    }

    public EventDetailDto CreateEvent(Event eventToAdd, Guid userId)
    {
      _eventRepository.CreateEvent(eventToAdd);
      var user = _userRepository.GetUserById(userId);
      user.Events.Add(eventToAdd);
      _userRepository.UpdateUser(user);
      var eventDetails = new EventDetailDto(eventToAdd.Id, eventToAdd.Title, user.Name, eventToAdd.Description, eventToAdd.StartTime, eventToAdd.EndTime, eventToAdd.Attendees);
      return eventDetails;
    }

    public Event DeleteEvent(Guid id)
    {
      Event eventToDelete = _eventRepository.GetEventById(id);
      _eventRepository.DeleteEvent(id);
      return eventToDelete;
    }

    public Event UpdateEvent(Event eventToUpdate)
    {
      _eventRepository.UpdateEvent(eventToUpdate);
      return eventToUpdate;
    }

    public EventDetailDto GetEventById(Guid id)
    {
      var eventById = _eventRepository.GetEventById(id);
      var eventsAuthorName = _userRepository.GetUserByEventId(id).Name;
      return new EventDetailDto(id, eventById.Title, eventsAuthorName, eventById.Description, eventById.StartTime, eventById.EndTime, eventById.Attendees);
    }

    public IEnumerable<EventDto> GetEventsByUserId(Guid userId)
    {
      var userName = _userRepository.GetUserById(userId).Name;
      var allEvents = _userRepository.GetEventsByUserId(userId);
      var eventsDtos = allEvents.Select(e => new EventDto(e.Id, e.Title, userName));
      return eventsDtos;
    }
  }
}