using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarApi.Models
{
  public class Invitation
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public String AuthorName { get; set; }

    [Required]
    public Guid EventId { get; set; }

    public Invitation(Guid id, String authorName, Guid eventId)
    {
      this.Id = id;
      this.AuthorName = authorName;
      this.EventId = eventId;
    }
  }
}