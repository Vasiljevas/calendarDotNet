using System;
using CalendarApi.Models;
using CalendarApi.Services.Interfaces;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.DTOs;

namespace CalendarApi.Services
{
  public class InvitationService : IInvitationService
  {
    private readonly IUserRepository _userRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IAttendeeRepository _attendeeRepository;

    public InvitationService(IUserRepository userRepository, IEventRepository eventRepository, IInvitationRepository invitationRepository, IAttendeeRepository attendeeRepository)
    {
      this._userRepository = userRepository;
      this._eventRepository = eventRepository;
      this._invitationRepository = invitationRepository;
      this._attendeeRepository = attendeeRepository;
    }

    public IEnumerable<EventDto> GetInvitationsByUserId(Guid userId)
    {
      var user = _userRepository.GetUserById(userId);
      return user.Invitations.Select(i =>
      {
        var eventObj = _eventRepository.GetEventById(i.EventId);
        return new EventDto(i.Id, eventObj.Title, i.AuthorName, eventObj.StartTime, eventObj.EndTime);
      });
    }

    public Invitation AcceptInvitation(Guid id, Guid userId)
    {
      var invite = _invitationRepository.GetInvitationById(id);
      var eventI = _eventRepository.GetEventById(invite.EventId);
      var user = _userRepository.GetUserById(userId);
      var newAttendee = new Attendee(Guid.NewGuid(), user.Name, user.Email);
      _attendeeRepository.CreateAttendee(newAttendee);
      eventI.Attendees.Add(newAttendee);
      _eventRepository.UpdateEvent(eventI);
      user.Events.Add(eventI);
      _userRepository.UpdateUser(user);
      _invitationRepository.DeleteInvitation(id);
      return invite;
    }

    public Invitation DeclineInvitation(Guid id, Guid userId)
    {
      var invite = _invitationRepository.GetInvitationById(id);
      _invitationRepository.DeleteInvitation(id);
      return invite;
    }
  }
}