using System;
using Microsoft.AspNetCore.Mvc;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Services.Interfaces;
using CalendarApi.Models;
using CalendarApi.DTOs;

namespace CalendarApi.Controllers
{
  [ApiController]
  [Route("api/events")]
  public class EventController : ControllerBase
  {
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
      _eventService = eventService;
    }

    [HttpGet]
    [Route("/user/{userId}")]
    public ActionResult<IEnumerable<EventDto>> GetEventsByUserId(Guid userId)
    {
      //only get those with matching id
      return Ok(_eventService.GetEventsByUserId(userId));
    }

    [HttpGet]
    [Route("/event/{id}")]
    public ActionResult<EventDetailDto> GetEventById(Guid id)
    {
      var detailedEventById = _eventService.GetEventById(id);
      if (detailedEventById != null)
      {
        return Ok(detailedEventById);
      }
      return NotFound();
    }

    [HttpPost]
    [Route("/{userId}")]
    public ActionResult<EventDetailDto> AddNewEvent(Guid userId, [FromBody] EventFormDto newEvent)
    {
      var createdEvent = _eventService.CreateEvent(newEvent, userId);
      return Ok(createdEvent);
    }

    [HttpPut]
    [Route("/{userId}")]
    public ActionResult<EventDetailDto> UpdateEvent(Guid userId, [FromBody] EventFormDto updatedEvent)
    {
      var e = _eventService.UpdateEvent(userId, updatedEvent);
      return Ok(e);
    }

    [HttpDelete]
    [Route("/{userId}/{id}")]
    public ActionResult<IEnumerable<EventDto>> DeleteEvent(Guid userId, Guid id)
    {
      var events = _eventService.DeleteEvent(id, userId);
      return Ok(events);
    }
  }
}