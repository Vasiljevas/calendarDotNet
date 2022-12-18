using System;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Models;
using CalendarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CalendarApi.Repositories
{
  public class InvitationRepository : IInvitationRepository
  {
    private CalendarDbContext _context;

    public InvitationRepository(CalendarDbContext context)
    {
      _context = context;
    }
    public IEnumerable<Invitation> GetInvitations()
    {
      return _context.Invitations.ToList<Invitation>();
    }

    public Invitation GetInvitationById(Guid id)
    {
      return _context.Invitations.ToList<Invitation>().First(i => i.Id == id);
    }

    public void CreateInvitation(Invitation invitation)
    {
      _context.Invitations.Add(invitation);
      _context.SaveChanges();
    }

    public void UpdateInvitation(Invitation invitation)
    {
      _context.Invitations.Update(invitation);
      _context.SaveChanges();
    }

    public void DeleteInvitation(Guid id)
    {
      Invitation invitation = _context.Invitations.ToList<Invitation>().First(i => i.Id == id);
      _context.Invitations.Remove(invitation);
      _context.SaveChanges();
    }
  }
}