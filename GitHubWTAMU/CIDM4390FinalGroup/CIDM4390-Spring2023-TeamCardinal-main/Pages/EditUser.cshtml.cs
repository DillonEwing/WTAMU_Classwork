using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using _4390Project.Data;

namespace _4390Project.Pages;
[Authorize(Roles ="Admin")]
public class EditUser : PageModel
{
    private readonly ILogger<EditUser> _logger;
    private readonly UserManager<UpdatedUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    public IEnumerable<SelectListItem> RoleList {get;set;}
    public UpdatedUser ?UserSelected {get;set;}
    [BindProperty]
    [Required]
    public string RoleSelected {get; set;} = string.Empty;
    public EditUser(ILogger<EditUser> logger,UserManager<UpdatedUser> userManager,RoleManager<IdentityRole> roleManager,IEnumerable<SelectListItem> RoleList)
    {
        _logger = logger;
        this.userManager=userManager;
        this.roleManager=roleManager;
        this.RoleList=RoleList;
    }
    public async void OnGetAsync(string id)
    {
        _logger.LogInformation("OnGet() Called id="+id);
        RoleList=roleManager.Roles.Select(i=>new SelectListItem{Text=i.Name,Value=i.Name});
        if(ModelState.IsValid)
        {
            UserSelected = await userManager.FindByIdAsync(id);
        }
    }
    public async Task<IActionResult> OnPostAsync(string Id)
    {
        if(ModelState.IsValid)
        {
            _logger.LogInformation("OnPost() Called Id "+Id+" role "+RoleSelected);
            var RoleResult = await userManager.AddToRoleAsync(await userManager.FindByIdAsync(Id),RoleSelected);
            if(RoleResult.Succeeded)
            {
                return Redirect("/ListUser");
            }
            foreach(IdentityError e in RoleResult.Errors)
            {
                ModelState.AddModelError("",e.Description);
            }
        }
        return Redirect("/EditUser");
    }
}