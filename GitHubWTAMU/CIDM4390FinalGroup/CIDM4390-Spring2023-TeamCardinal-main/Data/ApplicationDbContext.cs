using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4390Project.Data;
public class ApplicationDbContext : IdentityDbContext<UpdatedUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Event> Event {get; set;}=null!;
    public DbSet<Registration> Registration {get; set;}=null!;
    public DbSet<Session> Session {get; set;}=null!;
    public DbSet<Workshop> Workshop {get; set;}=null!;
    public DbSet<Note> Note {get; set;}=null!;
    public DbSet<Survey> Survey {get; set;}=null!;
}