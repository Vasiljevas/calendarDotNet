using CalendarApi.Data;
using CalendarApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CalendarController : ControllerBase
  {
    private readonly CalendarDbContext _context;
    public CalendarController(CalendarDbContext context) => _context = context;

    [HttpGet]
    public async Task<IEnumerable<Calendar>> GetCalendars() => await _context.Calendars.ToListAsync();

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
      var calendar = await _context.Calendars.FindAsync(id);
      return calendar == null ? NotFound() : Ok(calendar);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Calendar calendar)
    {
      await _context.Calendars.AddAsync(calendar);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = calendar.Id, calendar });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Calendar calendar)
    {
      if (id != calendar.Id) return BadRequest();

      _context.Entry(calendar).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var caledarToDelete = await _context.Calendars.FindAsync(id);
      if (caledarToDelete == null) return NotFound();

      _context.Calendars.Remove(caledarToDelete);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}