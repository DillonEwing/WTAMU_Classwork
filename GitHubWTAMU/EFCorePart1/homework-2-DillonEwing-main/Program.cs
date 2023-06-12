using System;
using System.Collections.Generic;


namespace homework_2_DillonEwing
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool for while loop
            bool running = true;

            //initialize the starting patients and their attributes
            Patient Patient1 = new Patient() {FirstName = "Roxie", LastName = "Hart", Age = 34, Gender = 'F', AdmittanceDate = DateTime.Parse("5/28/1924"), HadExam = 'Y'};
            Patient Patient2 = new Patient() {FirstName = "Grace", LastName = "Bertrand", Age = 24, Gender = 'F', AdmittanceDate = DateTime.Parse("1/15/1939"), HadExam = 'Y'};
            Patient Patient3 = new Patient() {FirstName = "Harold", LastName = "Hill", Age = 52, Gender = 'M', AdmittanceDate = DateTime.Parse("7/1/1943"), HadExam = 'N'};
            Patient Patient4 = new Patient() {FirstName = "Herman", LastName = "Dietrich", Age = 47, Gender = 'M', AdmittanceDate = DateTime.Parse("9/12/1936"), HadExam = 'Y'};

            //Add the patients we just made to the database and save
            using (var db = new AppDbContext()) {
                if (db.Database.EnsureCreated()) {
                    db.Add(Patient1);
                    db.Add(Patient2);
                    db.Add(Patient3);
                    db.Add(Patient4);
                }
                db.SaveChanges();
            }
            
            //continously ask user what they want to do, and then do it
            while (running) {
                Console.WriteLine("Do you want to add, list, update, or remove? Type done to end. Type in lowercase.");
                String User = Console.ReadLine();

                if(User == "done"){
                    running = false;
                }

                if(User == "add") {
                    addPatient();
                }

                if(User == "list"){
                    listPatients();
                }

                if(User == "update"){
                    updatePatient();
                }

                if(User == "remove"){
                    removePatient();
                }
            }
        }

        //method to list patients to console
        static void listPatients() {
            //lists patients
            using (var db = new AppDbContext()){
                foreach (var p in db.Patients)
                {
                    Console.WriteLine($"{p.PatientID} {p.FirstName} {p.LastName} {p.Age} {p.Gender} {p.AdmittanceDate} {p.HadExam}");
                }                
            }

        }

        //method to add patients to the database 
        static void addPatient() {
            //get information anout the new patient from the user
            Console.WriteLine("First Name of new patient?");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Last Name of new patient?");
            string newLastName = Console.ReadLine();
            Console.WriteLine("Age of new patient?");
            int newAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gender of new patient? M or F");
            char newGender = char.Parse(Console.ReadLine());
            Console.WriteLine("Has the new patient had an exam with the doctor? Y or N");
            char newHadExam = char.Parse(Console.ReadLine());

            //combine all the user imputs into a new patient
            Patient newPatient = new Patient() {FirstName = newFirstName, LastName = newLastName, Age = newAge, Gender = newGender, AdmittanceDate = DateTime.Now, HadExam = newHadExam};

            //add new patient to the database
            using (var db = new AppDbContext()) {                
                db.Add(newPatient);                
                db.SaveChanges();
            }
        }        

        //method to update a patient
        static void updatePatient() {
            //finds out what patient needs to be updated
            Console.WriteLine("What is the ID of the Patient you would like to update?");

            //connects to the database
            using (var db = new AppDbContext()){
                
                Patient patientToUpdate = db.Patients.Find(Convert.ToInt32(Console.ReadLine()));
                
                //asks what attribute needs to be updated
                Console.WriteLine("Would you like to update the patient's first name, last name, age, gender, or whether they have been examed? Type in lowercase.");
                string attributeToUpdate = Console.ReadLine();                

                //depending oon the user input, update the attribute
                if(attributeToUpdate == "first name") {
                    Console.WriteLine("What is the new first name?");
                    string newAttribute = Console.ReadLine();                                
                    patientToUpdate.FirstName = newAttribute;
                }
                if(attributeToUpdate == "last name") {
                    Console.WriteLine("What is the new Last name?");
                    string newAttribute = Console.ReadLine();                                
                    patientToUpdate.LastName = newAttribute;
                }
                if(attributeToUpdate == "age") {
                    Console.WriteLine("What is the new Age?");
                    int newAttribute = Convert.ToInt32(Console.ReadLine());                                
                    patientToUpdate.Age = newAttribute;                    
                }
                if(attributeToUpdate == "gender") {
                    Console.WriteLine("What is the new gender? M or F");
                    char newAttribute = char.Parse(Console.ReadLine());                                
                    patientToUpdate.Gender = newAttribute;                    
                }
                if(attributeToUpdate == "examed") {
                    Console.WriteLine("Has the Patient been examed by the doctor? Y or N");
                    char newAttribute = char.Parse(Console.ReadLine());                                
                    patientToUpdate.HadExam = newAttribute;                    
                }
                db.SaveChanges();
            }            
        }
        /*
            This is where I had the most struggle, I wasn't sure if there was a way to do
            this using less code, so I went with what I knew would work. The readline and converting
            it to the proper variable type gave me a lot of pains, but eventually I got it to work
        */

        //method to remove a patient
        static void removePatient() {
            //asks the user what patient needs to be removed
            Console.WriteLine("What is the ID of the Patient you would like to Remove?");

            //connects to the database and removes the patient that the user wants
            using (var db = new AppDbContext()) {
                Patient patientToRemove = db.Patients.Find(Convert.ToInt32(Console.ReadLine()));
                db.Remove(patientToRemove);
                db.SaveChanges();
            }
        }
    }
}