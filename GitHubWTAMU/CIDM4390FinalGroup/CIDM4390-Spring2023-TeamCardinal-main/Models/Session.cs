using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the Sessions
    public class Session
    {
    public int SessionID {get; set;}// This is the "primary key"
    [Required]
    public int EventID {get; set;}
    [StringLength(30)]
    [Required]
    public string Topic {get; set;} = string.Empty;
    [StringLength(100)]
    [Required]
    public string Location {get; set;} = string.Empty;
    [StringLength(260)]
    [Required]
    public string Description {get; set;} = string.Empty;
    [Required]
    public DateTime SessionDate {get; set;}
    [Required]
    public int Capacity {get; set;}
    public int Available{get; set;}
    }
}