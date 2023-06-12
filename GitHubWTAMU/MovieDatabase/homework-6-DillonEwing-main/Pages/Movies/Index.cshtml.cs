using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using homework_6_DillonEwing.Models;

namespace homework_6_DillonEwing.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Movie> Movies {get; set;}

        public IndexModel(MovieContext context,ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;            
        }

        public void OnGet()
        {
            Movies = _context.Movies.ToList();
        }
    }
}
