using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace _4390Project.Pages;
[Authorize(Roles ="Admin")]
public class CreateRole : PageModel
{
    private readonly ILogger<CreateRole> _logger;
    private readonly RoleManager<IdentityRole> roleManager;
    [BindProperty]
    [Display(Name = "Role Name")]
    [StringLength(60,MinimumLength =3)]
    [Required]
    public string RoleName{get;set;} = string.Empty;

    public CreateRole(ILogger<CreateRole> logger,RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        this.roleManager=roleManager;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPost() Called "+RoleName);
        if(ModelState.IsValid)
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(RoleName));
            if(result.Succeeded)
            {
                return Redirect("/ListUser");
            }
            foreach(IdentityError e in result.Errors)
            {
                ModelState.AddModelError("",e.Description);
            }
        }
        return Redirect("/CreateRole");
    }
}