namespace WebApp.Model;

public class EventAttendee 
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public Guid ScheduledEventId { get; set; } 
    public ScheduledEvent ScheduledEvent { get; set; } 
}
