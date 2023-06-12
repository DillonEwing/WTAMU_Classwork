using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the Surveys
    public class Survey
    {
    public int SurveyID {get; set;}// This is the "primary key"
    [Required]
    public int RegistrationID {get; set;}
    [Required]
    [Range(1,5)]
    [Display(Name ="This workshop was informative")]
    public int Informed {get; set;}
    [Required]
    [Range(1,5)]
    [Display(Name ="This workshop was what I expected")]
    public int Expectation {get; set;}
    [Required]
    [Range(1,5)]
    [Display(Name ="This workshop was relevant to the topic")]
    public int Relevant {get; set;}
    [Required]
    [Range(1,5)]
    [Display(Name ="This workshop objectives was clear")]
    public int Clear {get; set;}
    [Required]
    [Range(1,5)]
    [Display(Name ="This workshop was help grew my interest in the subject")]
    public int Interest {get; set;}
    [StringLength(1000)]
    [Required]
    public string Feedback {get; set;} = string.Empty;
    }
}