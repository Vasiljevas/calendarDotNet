using CalendarApi.Models;

namespace CalendarApi.DTOs
{
  public class EventFormDto
  {
    public String Title { get; set; }
    public String Description { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Attendee> Attendees { get; set; }
  }
}