using Bogus;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Event;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Helper;

public static class FakeData
{
    public static async Task FillDb(ScheduledEventRepo scheduledEventRepo, UserManager<User> userManager)
    {
        Random random = new();
        List<User> users = new UserFaker().Generate(5);
        foreach (User user in users)
        {
            IdentityResult result = await userManager.CreateAsync(user, new Faker().Internet.Password().ToUpper() + new Faker().Internet.Password().ToLower());
            if (!result.Succeeded) continue;
            List<CreateScheduledEventRequest> events = new EventFaker(user.Id).Generate(random.Next(5, 30));
            foreach (CreateScheduledEventRequest e in events) await scheduledEventRepo.Create(e);
        }
    }


    private sealed class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            RuleFor(e => e.Email, f => f.Internet.Email());
            RuleFor(e => e.UserName, f => f.Internet.UserName());
        }
    }

    private sealed class EventFaker : Faker<CreateScheduledEventRequest>
    {
        public EventFaker(string id)
        {
            RuleFor(e => e.Id, _ => Guid.NewGuid());
            RuleFor(e => e.DateTime, _ => DateTime.Now);
            RuleFor(e => e.Title, f => f.Lorem.Sentence());
            RuleFor(e => e.Description, f => f.Lorem.Sentences(3));
            RuleFor(e => e.Location, f => f.Lorem.Sentence());
            RuleFor(e => e.OrganizerId, _ => id);
        }
    }
}