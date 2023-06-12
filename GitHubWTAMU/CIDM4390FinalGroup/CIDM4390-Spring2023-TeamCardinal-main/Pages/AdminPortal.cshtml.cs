using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin")]

public class AdminPortalModel : PageModel
{
    private readonly ILogger<AdminPortalModel> _logger;

    public AdminPortalModel(ILogger<AdminPortalModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}