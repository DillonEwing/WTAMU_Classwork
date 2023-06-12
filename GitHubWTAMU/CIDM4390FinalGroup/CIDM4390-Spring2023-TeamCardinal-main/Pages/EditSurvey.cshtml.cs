using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using _4390Project.Data;

namespace _4390Project.Pages;
[Authorize(Roles ="Admin,Student")]
public class EditSurvey : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<EditSurvey> _logger;
    [BindProperty]
    public Survey PostSurvey {get; set;}= default!;
    public int holder;
    public EditSurvey(ILogger<EditSurvey> logger,_4390Project.Data.ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }
    public void OnGet(string id)
    {
        _logger.LogInformation("OnGet() Called RegistrationID="+id);
        Int32.TryParse(id,out holder);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPost() Called "+PostSurvey.RegistrationID+" "+PostSurvey.Informed+" "+PostSurvey.Expectation+" "+PostSurvey.Relevant+" "+PostSurvey.Clear+" "+PostSurvey.Interest+" "+PostSurvey.Feedback);
        if (!ModelState.IsValid)
        {
            return Redirect("/EditSurvey");
        }

        _context.Survey.Add(PostSurvey);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}