using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace lab_11_DillonEwing.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProfessorContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProfessorContext>>()))
            {
                // Look for any blogs.
                if (context.Professors.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Professors.AddRange(
                    new Professor {
                        FirstName = "Kareem", LastName = "Dana"
                    },
                    new Professor {
                        FirstName = "Jeff", LastName = "Babb"
                    },
                    new Professor {
                        FirstName = "Sean", LastName = "Humpherys"
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}
