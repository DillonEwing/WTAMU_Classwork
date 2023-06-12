using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;    // Required for Data Validation
using System.ComponentModel.DataAnnotations.Schema;

namespace homework_6_DillonEwing.Models
{
    public class Movie
    {
        public int MovieId {get; set;}

        [BindProperty]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title {get; set;}

        [BindProperty]
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate {get; set;}

        [BindProperty]
        [StringLength(30)]
        public string Genre {get; set;}

        [BindProperty]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price {get; set;}

        [BindProperty]
        [Required]
        [StringLength(5)]
        public string Rating {get; set;}	
    }
}