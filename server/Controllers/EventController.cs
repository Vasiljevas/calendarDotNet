using System;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public EventController(IEventService eventService, IMapper mapper)
    {
      _eventService = eventService;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EventDto>> GetEventsByUserId(Guid userId)
    {
      //only get those with matching id
      return Ok(_eventService.GetEventsByUserId(userId));
    }

    [HttpGet]
    [Route("/{id}")]
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
    public ActionResult<EventDetailDto> AddNewEvent(Guid userId, Event newEvent)
    {
      var e = new Event(Guid.NewGuid(), newEvent.Title, newEvent.Description, newEvent.StartTime, newEvent.EndTime, new List<Attendee>());
      var createdEvent = _eventService.CreateEvent(e, userId);
      return Ok(createdEvent);
    }

    [HttpPut]
    public ActionResult<EventDetailDto> UpdateEvent(Guid userId, Event updatedEvent)
    {
      var e = _eventService.UpdateEvent(userId, updatedEvent);
      return Ok(e);
    }
  }
}