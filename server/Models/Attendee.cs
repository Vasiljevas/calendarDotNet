using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarApi.Models
{
  public class Attendee
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public String Name { get; set; }

    [Required]
    public String Email { get; set; }

    public Attendee() {}
  }
}