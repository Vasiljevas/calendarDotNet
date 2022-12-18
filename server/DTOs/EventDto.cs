namespace CalendarApi.DTOs
{
  public class EventDto
  {
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String AuthorName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public EventDto(Guid id, String title, String authorName, DateTime startTime, DateTime endTime)
    {
      this.Id = id;
      this.Title = title;
      this.AuthorName = authorName;
      this.StartTime = startTime;
      this.EndTime = endTime;
    }
  }
}