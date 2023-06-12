using System;
using System.Collections.Generic;
using Homework1.Models;

namespace homework_1_DillonEwing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the list of doctors to run through later
            List<Doctor> doctorList = new List<Doctor>();

            //Make a new doctor and add it to the list
            Doctor jeffG = new Doctor {firstName = "Jeff", lastName = "Green"};
            doctorList.Add(jeffG);

            //Make new patients, make the list of patients for the doctor, and add the patients to the list
            Patient p01 = new Patient {firstName = "Bob", lastName = "Frank"};
            Patient p02 = new Patient {firstName = "Curious", lastName = "George"};
            jeffG.patientList = new List<Patient>();
            jeffG.patientList.Add(p01);
            jeffG.patientList.Add(p02);

            //Make a new doctor and add it to the list
            Doctor karliM = new Doctor {firstName = "karli", lastName = "Morgenthau"};
            doctorList.Add(karliM);

            //Make new patients, make the list of patients for the doctor, and add the patients to the list
            Patient p03 = new Patient {firstName = "Baron", lastName = "Zemo"};
            Patient p04 = new Patient { firstName = "Isaiah", lastName = "Bradley"};
            karliM.patientList = new List<Patient>();
            karliM.patientList.Add(p03);
            karliM.patientList.Add(p04);

            //Make a new doctor and add it to the list
            Doctor mobiusM = new Doctor {firstName = "Mobius", lastName = "Wilson"};
            doctorList.Add(mobiusM);

            //Make new patients, make the list of patients for the doctor, and add the patients to the list
            Patient p05 = new Patient {firstName = "Wanda", lastName =  "Maximoff"};
            Patient p06 = new Patient {firstName = "Ralph", lastName = "Bohner"};
            Patient p07 = new Patient {firstName = "Loki", lastName = "Laufeyson"};
            mobiusM.patientList = new List<Patient>();
            mobiusM.patientList.Add(p05);
            mobiusM.patientList.Add(p06);
            mobiusM.patientList.Add(p07);
            
            /*
             * Run through the list of doctors and print each doctor
             * Then run through the list of patients for the doctor and print each patient
             */
            foreach (Doctor d in doctorList){
                Console.WriteLine($"{d.firstName} {d.lastName} has the following {d.patientList.Count} patients: ");
                foreach (Patient p in d.patientList) {
                    Console.WriteLine($"    {p.firstName} {p.lastName}");
                }
            }
        }
    }
}
