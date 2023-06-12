using System;
using Microsoft.AspNetCore.Identity;
namespace _4390Project.Data
{
    public class UpdatedUser : IdentityUser
    {
        public string FirstName{get;set;} = string.Empty;
        public string LastName{get;set;} = string.Empty;
        public DateTime Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Race { get; set;} = string.Empty;
    }
}