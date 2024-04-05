using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.ScheduledEvents;

public class DetailsModel(ScheduledEventRepo repo) : PageModel
{
    public ScheduledEvent GetScheduledEvent { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        ScheduledEvent? scheduledEvent = await repo.GetById(id);
        if (scheduledEvent == null) return NotFound();
        GetScheduledEvent = scheduledEvent;
        return Page();
    }
}