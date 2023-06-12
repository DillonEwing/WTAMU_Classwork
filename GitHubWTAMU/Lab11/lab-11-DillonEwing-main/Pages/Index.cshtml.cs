using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using lab_11_DillonEwing.Models;
namespace lab_11_DillonEwing.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProfessorContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Professor> Professors {get; set;}

        public IndexModel(ProfessorContext context ,ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            Professors = _context.Professors.ToList();
        }
    }
}
