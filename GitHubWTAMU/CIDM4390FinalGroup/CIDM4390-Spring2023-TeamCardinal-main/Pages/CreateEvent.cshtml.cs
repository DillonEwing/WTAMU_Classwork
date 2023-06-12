using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _4390Project.Data;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Teacher")]
public class CreateEventModel : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<CreateEventModel> _logger;
    [BindProperty]
    public Event NewEvent { get; set; }= default!;

    public CreateEventModel(ILogger<CreateEventModel> logger,_4390Project.Data.ApplicationDbContext context)
    {
        _context=context;
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Event.Add(NewEvent);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}