using System;
using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IInvitationRepository
  {
    public void DeleteInvitation(Guid id);
    
    public IEnumerable<Invitation> GetInvitations();
    public Invitation GetInvitationById(Guid id);
    public void CreateInvitation(Invitation invitation);
    public void UpdateInvitation(Invitation invitation);

  }
}