using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarApi.Models
{
  public class Event
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public String Title { get; set; }
    public String Description { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public List<User> Attendees { get; set; }

    public Event() { }

    public Event(Guid id, String title, String description, DateTime startTime, DateTime endTime, List<User> attendees)
    {
      this.Id = id;
      this.Title = title;
      this.Description = description;
      this.StartTime = startTime;
      this.EndTime = endTime;
      this.Attendees = attendees;
    }
  }
}