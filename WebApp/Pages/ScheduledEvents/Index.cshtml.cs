using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.ScheduledEvents;

public class IndexModel(
    ScheduledEventRepo scheduledEventRepo,
    EventAttendeeRepo eventAttendeeRepo)
    : PageModel
{

    public IList<ScheduledEvent> GetScheduledEvents { get; set; } = [];
    [BindProperty] public Guid EventId { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        GetScheduledEvents = await scheduledEventRepo.GetByOrganizerId(claim.Value);
        return Page();
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        await eventAttendeeRepo.Create(claim.Value, EventId);
        return RedirectToPage();
    }
}