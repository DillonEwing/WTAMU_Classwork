using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace homework_5_DillonEwing.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Name {get; set;}

        [BindProperty]
        [Required]
        [Display(Name="E-Mail")]
        [EmailAddress]
        public string Email {get; set;}

        [BindProperty]
        [Required]
        [StringLength(200)]
        public string Message {get; set;}

        public bool posted {get; set;}
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost() 
        {
            posted = true;
            _logger.LogInformation($"On post  {Name} {Email} {Message}");
        }
    }
}
