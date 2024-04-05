using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.MyData;

public class IndexModel(UserRepo userRepo, EventAttendeeRepo eventAttendeeRepo) : PageModel
{
    public User GetUser { get; set; } = default!;
    [BindProperty] public Guid EventAttendeesId { get; set; }

    public async Task<IActionResult> OnGet()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        User? user = await userRepo.Get(claim.Value);
        if (user is null) return Forbid();
        GetUser = user;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        await eventAttendeeRepo.Delete(claim.Value, EventAttendeesId);
        return RedirectToPage();
    }
}
