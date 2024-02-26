using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Implementations.Entities;

namespace ToDoList.DataAccess.DBContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<ToDoElement>? ToDoElements { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ToDoElement>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(); 
            });
        }

    }
}