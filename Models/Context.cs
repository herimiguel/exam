using Microsoft.EntityFrameworkCore;

namespace exam.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<User> Users {get; set;}
        
        public DbSet<Activity> Activities {get; set;}
        
        public DbSet<GuestConnection> GuestConnections {get; set;}



    }
    
}