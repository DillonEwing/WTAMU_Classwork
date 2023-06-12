using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the Workshops
    public class Workshop : Session
    {
    [Required]
    public string UserID {get; set;} = string.Empty;
    [StringLength(260)]
    public string RequestedItems {get; set;} = string.Empty;
    }
}