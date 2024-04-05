using System.ComponentModel.DataAnnotations;

namespace WebApp.Dto.Event;

public class CreateScheduledEventRequest
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }

    [StringLength(100, MinimumLength = 5)] public required string Title { get; set; }

    [StringLength(255, MinimumLength = 10)]
    public required string Description { get; set; }

    [StringLength(100, MinimumLength = 5)] public required string Location { get; set; }
    public string OrganizerId { get; set; }
}