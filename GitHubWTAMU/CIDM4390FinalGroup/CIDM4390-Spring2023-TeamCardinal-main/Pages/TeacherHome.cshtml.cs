using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Teacher")]
public class TeacherHomeModel : PageModel
{
    private readonly ILogger<TeacherHomeModel> _logger;

    public TeacherHomeModel(ILogger<TeacherHomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}