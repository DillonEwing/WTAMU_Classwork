using System; 
using System.Collections.Generic;

namespace homework_2_DillonEwing 
{
    public class Patient 
    {
        public int PatientID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get;set;}
        public int Age {get; set;}
        public char Gender {get; set;}
        public DateTime AdmittanceDate {get;set;}
        public char HadExam {get; set;}
    }
}