using System;
using Microsoft.EntityFrameworkCore;

namespace homework_2_DillonEwing
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        public DbSet<Patient> Patients {get; set;}
    }
}