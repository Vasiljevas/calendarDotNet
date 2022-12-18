using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarApi.Models;
using CalendarApi.DTOs;

namespace CalendarApi.Services.Interfaces
{
  public interface IInvitationService
  {
    IEnumerable<EventDto> GetInvitationsByUserId(Guid userId);

    Invitation AcceptInvitation(Guid id, Guid userId);

    Invitation DeclineInvitation(Guid id, Guid userId);
  }
}