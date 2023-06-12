using Microsoft.EntityFrameworkCore;

namespace lab_11_DillonEwing
{
	public class ProfessorContext : DbContext
	{
		public ProfessorContext (DbContextOptions<ProfessorContext> options)
			: base(options)
		{
		}
		public DbSet<Professor> Professors {get; set;}
	}
}