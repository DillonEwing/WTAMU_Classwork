using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace homework_4_DillonEwing
{
    public class Answer
    {
        public int AnswerId {get; set;}
        public int UserId {get; set;}
        public int QuestionId {get; set;}
        public string AText  {get; set;}
        public DateTime APostedDate {get; set;}
        


        public override string ToString() {
            using (var db = new AppDbContext()){
                User PostedBy = db.Users.Where(u=> u.UserId == UserId).Single();
                return $"{AText} - Posted by {PostedBy} on {APostedDate}";
            }
        }            
    }
}