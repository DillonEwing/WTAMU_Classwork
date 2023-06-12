using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _4390Project.Data;

namespace _4390Project.Pages;
[Authorize(Roles ="Admin,Student")]
public class ListRegistrations : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<ListRegistrations> _logger;
    public IEnumerable<SelectListItem> RegList {get;set;}

    public ListRegistrations(ILogger<ListRegistrations> logger,_4390Project.Data.ApplicationDbContext context,IEnumerable<SelectListItem> RegList)
    {
        _context=context;
        _logger = logger;
        this.RegList=RegList;
    }

    public void OnGet()
    {
        RegList=_context.Registration.Where(hh=>hh.UserID==this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Join(_context.Session,reg=>reg.SessionID,ses=>ses.SessionID,(reg,ses)=>new{RegistrationID=reg.RegistrationID,ses.Topic}).Select(i=>new SelectListItem{Text=i.Topic,Value=i.RegistrationID.ToString()});
    }
}