using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistrationApp.Models;

[Table("event_registration", Schema = "docuV2")]
public class EventRegistration
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [ForeignKey("Event")]
    public long EventId { get; set; }
}