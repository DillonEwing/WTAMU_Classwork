using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using lab_11_DillonEwing.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab_11_DillonEwing.Pages
{
    public class ProfessorModel : PageModel
    {
        private readonly ProfessorContext _context;
        private readonly ILogger<ProfessorModel> _logger;
        public List<Professor> Professors {get; set;}
        public SelectList ProfessorDropDown {get; set;}

        public ProfessorModel(ProfessorContext context ,ILogger<ProfessorModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            Professors = _context.Professors.ToList();

            ProfessorDropDown = new SelectList(Professors, "ProfessorId", "FirstName");
        }
    }
}
