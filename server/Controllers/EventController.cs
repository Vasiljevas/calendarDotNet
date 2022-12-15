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
      return Ok(_mapper.Map<List<EventDto>>(this._eventService.GetEventsByUserId(userId)));
    }

    [HttpGet]
    [Route("/{id}")]
    public ActionResult<EventDetailDto> GetEventById(Guid id)
    {
      var eventById = _eventService.GetEventById(id);
      if (eventById != null)
      {
        return Ok(_mapper.Map<EventDetailDto>(eventById));
      }
      return NotFound();
    }

    [HttpPost]
    public ActionResult<EventDetailDto> AddNewEvent(Guid userId, Event newEvent)
    {
      var e = new Event(Guid.NewGuid(), newEvent.Title, newEvent.Description, newEvent.StartTime, newEvent.EndTime, new List<User>());
      var createdEvent = _eventService.CreateEvent(e, userId);
      return Ok(_mapper.Map<EventDetailDto>(createdEvent));
    }
  }
}