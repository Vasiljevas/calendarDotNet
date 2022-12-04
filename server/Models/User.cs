using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CalendarApi.Enums;

namespace CalendarApi.Models
{
  public class User
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public String Name { get; set; }

    [Required]
    public String Email { get; set; }

    [Required]
    public String Password { get; set; }

    public List<Event> Events { get; set; }

    public List<Invitation> Invitations { get; set; }

    public UserRole Role { get; set; }

    public User() { }

    public User(Guid id, String name, String email, String password, List<Event> events, List<Invitation> invitations, UserRole role)
    {
      this.Id = id;
      this.Name = name;
      this.Email = email;
      this.Password = password;
      this.Events = events;
      this.Invitations = invitations;
      this.Role = role;
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode();
    }
  }
}