namespace CalendarApi.DTOs
{
  public class EventDto
  {
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String AuthorName { get; set; }

    public EventDto(Guid id, String title, String authorName)
    {
      this.Id = id;
      this.Title = title;
      this.AuthorName = authorName;
    }
  }
}