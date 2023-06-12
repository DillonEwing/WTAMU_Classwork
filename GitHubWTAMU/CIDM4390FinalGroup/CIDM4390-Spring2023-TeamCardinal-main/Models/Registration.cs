using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the Registrations
    public class Registration
    {
    public int RegistrationID {get; set;}// This is the "primary key"
    [Required]
    public int EventID{get; set;}
    [Required]
    public string UserID {get; set;} = string.Empty;
    public int SessionID {get; set;}
    }
}