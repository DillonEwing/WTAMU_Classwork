using System;
using System.ComponentModel.DataAnnotations;    // Required for Data Validation
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_11_DillonEwing
{
    public class Professor
    {
        public int ProfessorId {get; set;}	// Primary Key
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}