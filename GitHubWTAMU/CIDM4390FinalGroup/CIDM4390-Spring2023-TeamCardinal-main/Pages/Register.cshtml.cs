using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _4390Project.Data;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Student,Teacher,Volunteer")]
public class RegisterModel : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<RegisterModel> _logger;
    public Workshop newWork {get;set;}= default!;
    [BindProperty]
    public Registration NewRegistration { get; set; }= default!;
    [BindProperty]
    public int EventIdHolder {get;set;}
    public IEnumerable<SelectListItem> EventList {get;set;}
    public IEnumerable<SelectListItem> SpeakerList {get;set;}

    public RegisterModel(ILogger<RegisterModel> logger,_4390Project.Data.ApplicationDbContext context,IEnumerable<SelectListItem> EventList,IEnumerable<SelectListItem> SpeakerList)
    {
        _context=context;
        _logger = logger;
        this.EventList=EventList;
        this.SpeakerList=SpeakerList;
    }

    public void OnGet()
    {
        EventList=_context.Event.Select(i=>new SelectListItem{Text=i.Name,Value=i.EventID.ToString()});
    }
    
    public void OnPostEventSelect()
    {
        _logger.LogInformation("OnPostEventSelect() Called "+EventIdHolder);
        EventList=_context.Event.Select(i=>new SelectListItem{Text=i.Name,Value=i.EventID.ToString()});
        SpeakerList=_context.Workshop.Where(hh=>hh.EventID==EventIdHolder).Where(hhhh=>hhhh.Available!=0).Select(hhh => new SelectListItem{Value=hhh.SessionID.ToString(),Text=hhh.Topic});
    }
    public async Task<IActionResult> OnPostSpeakerSelectAsync()
    {
        NewRegistration.UserID=this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _logger.LogInformation("OnPost() Called "+NewRegistration.EventID+" "+NewRegistration.UserID+" "+NewRegistration.SessionID);

        _context.Registration.Add(NewRegistration);
        newWork=_context.Workshop.FirstOrDefault(h=>h.SessionID==NewRegistration.SessionID)!;
        newWork.Available-=1;
        _context.Workshop.Update(newWork);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}