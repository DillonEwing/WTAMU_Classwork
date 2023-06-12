using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the events
    public class Event
    {
    public int EventID {get; set;}// This is the "primary key"
    [StringLength(30)]
    [Required]
    public string Name {get; set;} = string.Empty;
    [StringLength(260)]
    [Required]
    public string Location {get; set;} = string.Empty;
    [Required]
    public DateTime EventDate {get; set;}
    }
}