namespace WebApp.Dto.Event;

public class CreateEventAttendeesRequest
{
    public Guid ScheduledEventId { get; set; }
    public string AttendeeId { get; set; }
}
