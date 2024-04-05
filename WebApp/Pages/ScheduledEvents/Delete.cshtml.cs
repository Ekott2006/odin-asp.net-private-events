using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helper;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.ScheduledEvents;

public class DeleteModel(ScheduledEventRepo repo) : PageModel
{
    [BindProperty] public ScheduledEvent GetScheduledEvent { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        ScheduledEvent? scheduledEvent = await repo.GetById(id);
        if (scheduledEvent is null) return NotFound();
        GetScheduledEvent = scheduledEvent;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        await repo.Delete(id);
        return RedirectToPage(RouteName.MyData + "/Index");
    }
}