using System;
using CalendarApi.Models;
using CalendarApi.Services.Interfaces;
using CalendarApi.Repositories.Interfaces;

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

    public Event CreateEvent(Event eventToAdd, Guid userId)
    {
      _eventRepository.CreateEvent(eventToAdd);
      var user = _userRepository.GetUserById(userId);
      Console.WriteLine(eventToAdd.Id);
      Console.WriteLine(eventToAdd.Title);
      Console.WriteLine(eventToAdd.Description);
      Console.WriteLine(eventToAdd.StartTime);
      Console.WriteLine(eventToAdd.EndTime);
      Console.WriteLine(eventToAdd.Attendees);
      user.Events.Add(eventToAdd);
      _userRepository.UpdateUser(user);
      return eventToAdd;
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

    public Event GetEventById(Guid id)
    {
      return _eventRepository.GetEventById(id);
    }

    public IEnumerable<Event> GetEventsByUserId(Guid userId)
    {
      var allEvents = _userRepository.GetEventsByUserId(userId);
      return allEvents;
    }
  }
}