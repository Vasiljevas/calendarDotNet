using System.ComponentModel.DataAnnotations;
namespace CalendarApi.Models
{
  public class Event
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public List<User> Attendees { get; set; }

    public String Header { get; set; }
  }
}