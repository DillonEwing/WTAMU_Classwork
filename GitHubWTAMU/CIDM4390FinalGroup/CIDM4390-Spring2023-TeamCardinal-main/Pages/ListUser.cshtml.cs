using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using _4390Project.Data;

namespace _4390Project.Pages;
[Authorize(Roles ="Admin")]
public class ListUser : PageModel
{
    private readonly ILogger<ListUser> _logger;
    public UserManager<UpdatedUser> userManager;

    public ListUser(ILogger<ListUser> logger,UserManager<UpdatedUser> userManager)
    {
        _logger = logger;
        this.userManager=userManager;
    }
}