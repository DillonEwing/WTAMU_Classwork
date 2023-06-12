using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using homework_6_DillonEwing.Models;

namespace homework_6_DillonEwing.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie {get; set;}
        
        private readonly MovieContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(MovieContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid){
                return Page();
            }

            _context.Movies.Add(Movie);
            _context.SaveChanges();

            return RedirectToPage("/Movies/index");
        }
    }
}
