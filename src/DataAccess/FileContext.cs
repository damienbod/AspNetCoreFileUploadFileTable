using Microsoft.Data.Entity;
using DataAccess.Model;

namespace DataAccess
{
    public class FileContext : DbContext
    {
        public DbSet<FileDescription> FileDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileDescription>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}