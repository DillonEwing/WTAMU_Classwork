using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace homework_4_DillonEwing
{
    class Program
    {
        //Global variable to set a user as an active user
        public static User CurrentUser = null;
        //Function to log in
        public static void Login() {
            Console.WriteLine("Log in\nWhat is your Email?");
            String UserEmail = Console.ReadLine();
            User ActiveUser = null;
            using (var db = new AppDbContext()) {
                bool match = false;                
                foreach (var U in db.Users)
                {
                     //Checks each email in the database to see if the user is new or not
                    if (UserEmail == U.Email) {
                        match = true;
                        ActiveUser = U;
                        Program.CurrentUser = U;
                    }
                        
                }
                //Checks to see if there was a match and if so sets the current user to the match, if not makes a new user and sets it as the active user
                if (match == false) {
                    Console.WriteLine("Email is not currently assigned to a user. A new user will be created for you.");
                    Console.WriteLine("What is your first name?");
                    String UserFirst = Console.ReadLine();
                    Console.WriteLine("What is your last name?");
                    String UserLast = Console.ReadLine();

                    User NewUser = new User() {FirstName = UserFirst, LastName = UserLast, Email = UserEmail, RegistrationDate = DateTime.Now};
                    
                    db.Add(NewUser);
                    db.SaveChanges();
                    
                    Console.WriteLine($"New user has been registered.\nWelcome {NewUser.FirstName}");
                    Program.CurrentUser = NewUser;
                }

                if (match == true) {
                    Console.WriteLine($"Welcome {ActiveUser.FirstName}");
                } 
            }
        }

        //Method to list all questions and their answers
        public static void ListAll() {
            using (var db = new AppDbContext()) {                
                foreach (var q in db.Questions) {
                    Console.WriteLine(q);
                    List<Answer> QAnswer = db.Answers.Where(a=> a.QuestionId == q.QuestionId).ToList();                    
                    foreach (var a in QAnswer) {
                        Console.WriteLine($"\t{a}");
                    }
                    Console.WriteLine();
                }
            }
        }

        //Makes a list of unanswered questions and lists them
        /*public static void ListUnanswered() {
            using(var db = new AppDbContext()) {
                List<Question> UnansweredQs = db.Questions.Where(a => a.Answers.Count() == 0).ToList();
                foreach (var q in UnansweredQs) {
                    Console.WriteLine(q);
                }
            }
        }*/

        //method to ask a question, adds the question to the database
        public static void Ask() {
            Console.WriteLine("What would you like to ask?");
            string UserQ = Console.ReadLine();
            using(var db = new AppDbContext()) {
                Question newQuestion = new Question() {QText = UserQ, QPostedDate = DateTime.Now, UserId = Program.CurrentUser.UserId};
                db.Questions.Add(newQuestion);
                db.SaveChanges();
            }
        }

        //checks if the question the user wants to remove was posted by the user and exists, if so deletes it
        public static void Remove() {
            int CurrentUserId = Program.CurrentUser.UserId;
            using(var db = new AppDbContext()) {
                List<Question> UsersQs = db.Questions.Where(q=> q.UserId == CurrentUserId).ToList();
                foreach(var q in UsersQs) {
                    Console.WriteLine(q);
                }
                Console.WriteLine("Which question would you like to remove?");
                Question questionToRemove = db.Questions.Find(Convert.ToInt32(Console.ReadLine()));
                try {
                    if(questionToRemove.UserId == CurrentUserId) {
                        db.Remove(questionToRemove);
                        db.SaveChanges();
                    } else {
                        Console.WriteLine("You do not have access to remove this question.");
                    }
                }
                catch {
                    Console.WriteLine("This question does not exist.");
                }
                
            }
        }

        //Method to answer a question, creates a new answer int the database
        public static void Answer() {
            using(var db = new AppDbContext()) {
                foreach(var q in db.Questions) {
                    Console.WriteLine(q);
                }
                Console.WriteLine("Which question would you like to answer");
                int UserQInput = Convert.ToInt32(Console.ReadLine());
                if (UserQInput <= db.Questions.Count()){
                    Question questionToAnswer = db.Questions.Find(UserQInput);
                    Console.WriteLine(questionToAnswer);
                    Console.WriteLine("What is your answer?");
                    string UserA = Console.ReadLine();
                    Answer newAnswer = new Answer {AText = UserA, APostedDate = DateTime.Now, QuestionId = questionToAnswer.QuestionId, UserId = Program.CurrentUser.UserId};
                    //db.Questions.Find(UserQInput).Answers.Add(newAnswer);
                    db.Add(newAnswer);
                    db.SaveChanges();
                } else {
                    Console.WriteLine("This question does not exist.");
                }
            }
        }

        

        static void Main(string[] args)
        {
            
            //Some random users, questions, and answers to use to fill out the database at the start
            List<User> users = new List<User> {
                new User {FirstName = "Dillon", LastName = "Ewing", Email = "dillonjewing@gmail.com"},
                new User {FirstName = "Peter", LastName = "Parker", Email = "peterp@gmail.com"}
            };

            List<Question> questions = new List<Question> {
                new Question {UserId = 1, QText = "What is two plus two?"}, 
                new Question {UserId = 1, QText = "Who is Spider-man?"},
                new Question {UserId = 2, QText = "Is Eddie Brock evil?"}
            };

            List<Answer> answers = new List<Answer> {
                new Answer {UserId = 2, QuestionId = 1, AText = "Two plus two is four."},
                new Answer {UserId = 2, QuestionId = 2, AText = "Peter Parker is Spider-man."}
            };


            //trying to assign questions their answers but getting null reference exeptions or foreign key constraint failed
            //questions[0].Answers.Add(answers[0]);
            //questions[1].Answers[0] = answers[1];

            using (var db = new AppDbContext()) {
                if (db.Database.EnsureCreated()) {
                    db.AddRange(users);
                    db.AddRange(questions);
                    db.AddRange(answers);
                }
                db.SaveChanges();
            }

            


            //calls the login method at program start
            Login();
            //Continuously asks what the user wants to do and calls the appropriate method. Ends program when user wants to.
            bool running = true;
            while(running) {
                Console.WriteLine("Do you want to (list all) questions, (list unanswered) questions, (ask) a question, (remove) a question, or (answer) a question.\nType done to end.");
                string UserInput = Console.ReadLine();
                if(UserInput == "done"){
                    running = false;
                } 
                if(UserInput == "list all") {
                    ListAll();
                }
                if(UserInput == "list unanswered") {
                    //ListUnanswered();
                }
                if(UserInput =="ask") {
                    Ask();
                }
                if(UserInput == "remove") {
                    Remove();
                }
                if(UserInput == "answer") {
                    Answer();
                }
            }
        }
    }
}
