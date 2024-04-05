using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Dto.Event;
using WebApp.Model;

namespace WebApp.Repository;

public class ScheduledEventRepo(DataContext context)
{
    public async Task<List<ScheduledEvent>> GetByOrganizerId(string organizerId) => await context.ScheduledEvents
        .Include(x => x.Attendees).Where(x =>
            x.OrganizerId != organizerId && x.Attendees.FirstOrDefault(y => y.UserId == organizerId) == null)
        .ToListAsync();
    
    public async Task<ScheduledEvent?> GetById(Guid id) =>
        await context.ScheduledEvents.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Delete(Guid id) => await context.ScheduledEvents.Where(a => a.Id == id).ExecuteDeleteAsync();

    public async Task Create(CreateScheduledEventRequest request)
    {
        await context.ScheduledEvents.AddAsync(new ScheduledEvent
        {
            Id = request.Id,
            Title = request.Title,
            OrganizerId = request.OrganizerId,
            Location = request.Location,
            Description = request.Description
        });
        await context.SaveChangesAsync();
    }
}