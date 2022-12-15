using CalendarApi.Models;

namespace CalendarApi.DTOs
{
  public class EventDetailDto
  {
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String AuthorName { get; set; }
    public String Description { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<User> Attendees { get; set; }
  }
}