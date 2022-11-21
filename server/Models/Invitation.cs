using System.ComponentModel.DataAnnotations;

namespace CalendarApi.Models
{
  public class Invitation
  {
    public int Id { get; set; }

    public int InviteeId { get; set; }
    [Required]
    public User Invitee { get; set; }

    public String Message { get; set; }
  }
}