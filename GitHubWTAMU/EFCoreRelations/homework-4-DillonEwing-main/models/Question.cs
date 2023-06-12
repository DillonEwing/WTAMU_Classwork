using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace homework_4_DillonEwing
{
    public class Question
    {
        public int QuestionId {get; set;}
        public int UserId {get; set;}
        public string QText  {get; set;}
        public DateTime QPostedDate {get; set;}
        //public List<Answer> Answers {get; set;}
        

        
        public override string ToString() {
            using (var db = new AppDbContext()) {
                User PostedBy = db.Users.Where(u=> u.UserId == UserId).Single();
                return $"{QuestionId} - {QText} - Posted by {PostedBy} on {QPostedDate}";
            }
        }                 
    }

    
}