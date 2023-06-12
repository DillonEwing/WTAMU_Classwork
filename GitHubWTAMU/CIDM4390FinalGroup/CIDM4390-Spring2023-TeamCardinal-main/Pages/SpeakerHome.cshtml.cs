using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Speaker")]
public class SpeakerHomeModel : PageModel
{
    private readonly ILogger<SpeakerHomeModel> _logger;

    public SpeakerHomeModel(ILogger<SpeakerHomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}