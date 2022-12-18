using System;
using Microsoft.AspNetCore.Mvc;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Services.Interfaces;
using CalendarApi.Models;
using CalendarApi.DTOs;

namespace CalendarApi.Controllers
{
  [ApiController]
  [Route("api/invitations")]
  public class InvitationController : ControllerBase
  {
    private readonly IInvitationService _invitationService;

    public InvitationController(IInvitationService invitationService)
    {
      _invitationService = invitationService;
    }

    [HttpGet]
    [Route("/{userId}")]
    public ActionResult<IEnumerable<EventDto>> GetInvitationsByUserId(Guid userId)
    {
      return Ok(_invitationService.GetInvitationsByUserId(userId));
    }

    [HttpPost]
    [Route("/accept/{id}/{userId}")]
    public ActionResult<Invitation> AcceptInvitation(Guid id, Guid userId)
    {
      _invitationService.AcceptInvitation(id, userId);
      return Ok();
    }
  }
}