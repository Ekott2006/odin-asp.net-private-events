using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Dto.Event;
using WebApp.Helper;
using WebApp.Repository;

namespace WebApp.Pages.ScheduledEvents;

public class CreateModel(ScheduledEventRepo repo) : PageModel
{
    public string? OrganizerId { get; set; }
    [BindProperty] public CreateScheduledEventRequest Request { get; set; } = default!;

    public IActionResult OnGet()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        OrganizerId = claim.Value;
        ViewData["UserId"] = claim.Value;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        if (!ModelState.IsValid) return Page();
        await repo.Create(Request);
        return RedirectToPage(RouteName.MyData + "/Index");
    }
}