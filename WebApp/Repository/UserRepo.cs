using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Repository;

public class UserRepo(DataContext context)
{
       public async Task<User?> Get(string id) => await context.Users.Include(x => x.AttendingEvents).ThenInclude(x => x.ScheduledEvent).Include(x => x.OrganizedEvents).FirstOrDefaultAsync(x => x.Id == id);
}
