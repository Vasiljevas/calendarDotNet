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
    public List<Attendee> Attendees { get; set; }

    
    public EventDetailDto(Guid id, String title, String authorName, String description, DateTime startTime, DateTime endTime, List<Attendee> attendees)
    {
      this.Id = id;
      this.Title = title;
      this.AuthorName = authorName;
      this.Description = description;
      this.StartTime = startTime;
      this.EndTime = endTime;
      this.Attendees = attendees;
    }
  }
}