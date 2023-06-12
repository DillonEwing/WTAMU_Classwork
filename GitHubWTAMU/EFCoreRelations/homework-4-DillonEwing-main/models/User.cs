using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace homework_4_DillonEwing
{
    public class User
    {
        public int UserId {get; set;}
        public string FirstName  {get; set;}
        public string LastName {get; set;}
        public string Email {get;set;}
        public DateTime RegistrationDate {get; set;}      

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }  
    }
}