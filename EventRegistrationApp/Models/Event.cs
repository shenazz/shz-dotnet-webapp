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
    [Display(Name = "Start Time")]
    public DateTime StartTime { get; set; }

    [Required]
    [Display(Name = "End Time")]
    public DateTime EndTime { get; set; }

    public virtual ICollection<EventRegistration>? EventRegistrations { get; set; }


    public override string ToString()
    {
        return $"{Id}-{Name}-{Description}-{Location}-{StartTime}-{EndTime}";
    }
}