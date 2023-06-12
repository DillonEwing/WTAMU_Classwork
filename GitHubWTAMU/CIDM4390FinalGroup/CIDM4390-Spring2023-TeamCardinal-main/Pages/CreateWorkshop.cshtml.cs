using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _4390Project.Data;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Speaker")]
public class CreateWorkshopModel : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<CreateWorkshopModel> _logger;
    [BindProperty]
    public Workshop NewSpeaker { get; set; }= default!;
    
    public IEnumerable<SelectListItem> EventList {get;set;}

    public CreateWorkshopModel(ILogger<CreateWorkshopModel> logger,_4390Project.Data.ApplicationDbContext context,IEnumerable<SelectListItem> EventList)
    {
        _context=context;
        _logger = logger;
        this.EventList=EventList;
    }

    public void OnGet()
    {
        EventList=_context.Event.Select(i=>new SelectListItem{Text=i.Name,Value=i.EventID.ToString()});
    }
    public async Task<IActionResult> OnPostAsync()
    {
        NewSpeaker.UserID=this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        NewSpeaker.Available=NewSpeaker.Capacity;
        _logger.LogInformation("OnPost() Called "+NewSpeaker.EventID+" "+NewSpeaker.Topic+" "+NewSpeaker.Location+" "+NewSpeaker.Description+" "+NewSpeaker.SessionDate+" "+NewSpeaker.UserID+" "+NewSpeaker.Capacity+" "+NewSpeaker.Available+" "+NewSpeaker.RequestedItems);
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Workshop.Add(NewSpeaker);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}