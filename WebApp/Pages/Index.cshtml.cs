using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helper;

namespace WebApp.Pages;

public class IndexModel() : PageModel
{
    public RedirectToPageResult OnGet()
    {
        return RedirectToPage(RouteName.ScheduledEvents + "/Index");
    }
}