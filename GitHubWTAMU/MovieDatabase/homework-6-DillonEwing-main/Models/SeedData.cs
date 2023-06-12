using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace homework_6_DillonEwing.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                // Look for any blogs.
                if (context.Movies.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Movies.AddRange(
                    new Movie {
                        Title = "Spider-Man", ReleaseDate = DateTime.Parse("05/03/2002"), Genre = "Action", Price = 15, Rating ="PG-13"
                    },
                    new Movie {
                        Title = "Spider-Man 2", ReleaseDate = DateTime.Parse("06/30/2004"), Genre = "Action", Price = 20, Rating ="PG-13"
                    },
                    new Movie {
                        Title = "Spider-Man 3", ReleaseDate = DateTime.Parse("05/04/2007"), Genre = "Action", Price = 10, Rating ="PG-13"
                    },
                    new Movie {
                        Title = "Spider-Man: No Way Home", ReleaseDate = DateTime.Parse("12/17/2021"), Genre = "Action", Price = 60, Rating ="PG-13"
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}
