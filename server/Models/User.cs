using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CalendarApi.Enums;

namespace CalendarApi.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }

    [Required]
    public String Email { get; set; }

    [Required]
    public String Password { get; set; }

    public List<Event> Events { get; set; }

    public List<Invitation> Invitations { get; set; }

    public UserRole UserRole { get; set; }
  }
}