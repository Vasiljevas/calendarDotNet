using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarApi.Models;
using CalendarApi.DTOs;

namespace CalendarApi.Services.Interfaces
{
  public interface IInvitationService
  {
    IEnumerable<EventDto> GetInvitationsByUserId(Guid userId);

    void AcceptInvitation(Guid id, Guid userId);
  }
}