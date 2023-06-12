using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _4390Project.Data;

namespace _4390Project.Pages;

[Authorize(Roles ="Admin,Student")]
public class UpdateSudentNoteModel : PageModel
{
    private readonly _4390Project.Data.ApplicationDbContext _context;
    private readonly ILogger<UpdateSudentNoteModel> _logger;

    [BindProperty]
    public string StudentNote {get; set;}= default!;

    public UpdateSudentNoteModel(ILogger<UpdateSudentNoteModel> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//get current user
        var existingNote = _context.Note.FirstOrDefault(n => n.UserID == currentUser);//find note of current student

        if(existingNote != null)
        {
            StudentNote = existingNote.StudentNote;//display existing note
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {                
        //_logger.LogInformation(StudentNote);//We now have access to what the student saved
        var CurrentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//get current user

        var existingNote = _context.Note.FirstOrDefault(n => n.UserID == CurrentUser);//find note of current student
        if(existingNote != null)
        {
            _logger.LogInformation("Note updated"); 
            existingNote.StudentNote = this.StudentNote;//update existing note 
            await _context.SaveChangesAsync();//save db
        }
        else if  (existingNote == null)
        {
            _logger.LogInformation("New Note Saved"); 
            var newNote = new Note {UserID = CurrentUser, StudentNote = StudentNote};//make new note and set student note attribute
            _context.Add(newNote);//Add the note
            await _context.SaveChangesAsync();//save db
        }
        return RedirectToPage("/StudentHome");
    }
}