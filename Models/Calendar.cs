using System.ComponentModel.DataAnnotations;

namespace CalendarApi.Models
{
  public class Calendar
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public List<Event> Events { get; set; }
  }
}