using Microsoft.AspNetCore.Identity;

namespace WebApp.Model;

public class User : IdentityUser
{
    public ICollection<ScheduledEvent> OrganizedEvents { get; set; } 
    public ICollection<EventAttendee> AttendingEvents { get; set; } 
}