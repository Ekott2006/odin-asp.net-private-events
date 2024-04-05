using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Repository;

public class EventAttendeeRepo(DataContext context)
{
    public async Task Create(string userId, Guid eventId)
    {
        await context.EventAttendees.AddAsync(new EventAttendee
        {
            ScheduledEventId = eventId,
            UserId = userId
        });
        await context.SaveChangesAsync();
    }

    public async Task Delete(string userId, Guid attendeesId) =>
        await context.EventAttendees.Where(a => a.Id == attendeesId && a.UserId == userId).ExecuteDeleteAsync();
}