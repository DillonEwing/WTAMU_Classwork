using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace _4390Project.Pages;
public class IndexModelO : PageModel
{
    private readonly ILogger<IndexModelO> _logger;

    public IndexModelO(ILogger<IndexModelO> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        _logger.LogInformation("OnGet() Called");
        if(HttpContext.User.IsInRole("Admin"))
        {
            _logger.LogInformation("OnGet() Called admin");
            return RedirectToPage("/AdminPortal");
        }
        else if(HttpContext.User.IsInRole("Student"))
        {
            return RedirectToPage("/StudentHome");
        }
        else if(HttpContext.User.IsInRole("Speaker"))
        {
            return RedirectToPage("/SpeakerHome");
        }
        else if(HttpContext.User.IsInRole("Teacher"))
        {
            return RedirectToPage("/TeacherHome");
        }
        else if(HttpContext.User.IsInRole("Volunteer"))
        {
            return RedirectToPage("/VolunteerHome");
        }
        else if(HttpContext.User!=null&&HttpContext.User.Identity!=null&&HttpContext.User.Identity.IsAuthenticated)
        {
            return Redirect("/Identity/Account/Manage");
        }
        else
        {
            return Page();
        }
    }
}