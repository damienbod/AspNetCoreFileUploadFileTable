using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options) :base(options)
        { }
        
        public DbSet<FileDescription> FileDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileDescription>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}