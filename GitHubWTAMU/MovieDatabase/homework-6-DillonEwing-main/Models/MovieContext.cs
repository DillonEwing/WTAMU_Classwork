using Microsoft.EntityFrameworkCore;

namespace homework_6_DillonEwing.Models
{
	public class MovieContext : DbContext
	{
		public MovieContext (DbContextOptions<MovieContext> options)
			: base(options)
		{
		}
		public DbSet<Movie> Movies {get; set;}
	}
}
