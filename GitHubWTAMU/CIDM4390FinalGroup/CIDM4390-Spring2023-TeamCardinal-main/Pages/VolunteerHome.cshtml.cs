using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Volunteer")]

public class VolunteerHomeModel : PageModel
{
    private readonly ILogger<VolunteerHomeModel> _logger;

    public VolunteerHomeModel(ILogger<VolunteerHomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}