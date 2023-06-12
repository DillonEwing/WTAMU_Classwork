using System.ComponentModel.DataAnnotations;

namespace _4390Project.Data
{
//this is a model of the notes
    public class Note
    {
    public int NoteID {get; set;}// This is the "primary key"
    [Required]

    public string UserID {get; set;} = string.Empty;// Will connect to student
    [Required]
    public string StudentNote {get; set;} = string.Empty;//the actual note
    }
}