using System.ComponentModel.DataAnnotations;

namespace WebApp.Model;

public class ScheduledEvent 
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; } 

    [MaxLength(100)]
    public required string Title { get; set; }

    [MaxLength(255)]
    public required string Description { get; set; } 

    [MaxLength(100)]
    public required string Location { get; set; }

    public string OrganizerId { get; set; } 
    public User Organizer { get; set; } 
    public ICollection<EventAttendee> Attendees { get; set; } 
}