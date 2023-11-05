using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistrationApp.Models;

[Table("event", Schema = "docuV2")]
public class Event
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public virtual ICollection<EventRegistration>? EventRegistrations { get; set; }
}