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
    private readonly IInvitationRepository _invitationRepository;

    public EventService(IEventRepository eventRepo, IUserRepository userRepo, IInvitationRepository inviteRepo)
    {
      this._eventRepository = eventRepo;
      this._userRepository = userRepo;
      this._invitationRepository = inviteRepo;
    }

    public EventDetailDto CreateEvent(EventFormDto newEvent, Guid userId)
    {
      var eventToAdd = new Event(Guid.NewGuid(), newEvent.Title, newEvent.Description, newEvent.StartTime, newEvent.EndTime, new List<Attendee>());
      _eventRepository.CreateEvent(eventToAdd);
      var user = _userRepository.GetUserById(userId);
      user.Events.Add(eventToAdd);
      _userRepository.UpdateUser(user);

      newEvent.InviteeIds.ForEach(id =>
      {
        var newInvitation = new Invitation(Guid.NewGuid(), user.Name, eventToAdd.Id);
        var userToInvite = _userRepository.GetUserById(id);
        _invitationRepository.CreateInvitation(newInvitation);
        userToInvite.Invitations.Add(newInvitation);
        _userRepository.UpdateUser(userToInvite);
      });

      var eventDetails = new EventDetailDto(eventToAdd.Id, eventToAdd.Title, user.Name, eventToAdd.Description, eventToAdd.StartTime, eventToAdd.EndTime, eventToAdd.Attendees);
      return eventDetails;
    }

    public IEnumerable<EventDto> DeleteEvent(Guid id, Guid userId)
    {
      _eventRepository.DeleteEvent(id);
      var invitations = _invitationRepository.GetInvitations().Where(i => i.EventId == id);
      foreach (var invitation in invitations)
      {
        _invitationRepository.DeleteInvitation(invitation.Id);
      }
      var user = _userRepository.GetUserById(userId);
      return user.Events.Select(e => new EventDto(e.Id, e.Title, user.Name, e.StartTime, e.EndTime));
    }

    public EventDetailDto UpdateEvent(Guid userId, EventFormDto eventToUpdate)
    {
      var currentEvent = _eventRepository.GetEventById(eventToUpdate.Id);
      var updatedEvent = new Event(eventToUpdate.Id, eventToUpdate.Title, eventToUpdate.Description, eventToUpdate.StartTime, eventToUpdate.EndTime, currentEvent.Attendees);
      _eventRepository.UpdateEvent(updatedEvent);
      var user = _userRepository.GetUserById(userId);
      eventToUpdate.InviteeIds.ForEach(id =>
      {
        var invitedUser = _userRepository.GetUserById(id);
        var invitationOld = invitedUser.Invitations.Find(inv => inv.EventId == eventToUpdate.Id);
        if (invitationOld == null)
        {
          var newInvitation = new Invitation(Guid.NewGuid(), user.Name, updatedEvent.Id);
          invitedUser.Invitations.Add(newInvitation);
          _userRepository.UpdateUser(invitedUser);
        }
        else
        {
          invitationOld.EventId = updatedEvent.Id;
          var item = invitedUser.Invitations.FirstOrDefault(i => i.Id == invitationOld.Id);
          item = invitationOld;
          _userRepository.UpdateUser(invitedUser);
        }
      });
      return new EventDetailDto(eventToUpdate.Id, eventToUpdate.Title, user.Name, eventToUpdate.Description, eventToUpdate.StartTime, eventToUpdate.EndTime, null);
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
      var eventsDtos = allEvents.Select(e => new EventDto(e.Id, e.Title, userName, e.StartTime, e.EndTime));
      return eventsDtos;
    }
  }
}