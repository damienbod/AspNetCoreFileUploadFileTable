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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO move this to a config
            var SQLConnectionString =  "Data Source=N275\\MSSQLSERVER2014;Initial Catalog=WebApiFileTable;Integrated Security=True;";
            optionsBuilder.UseSqlServer(SQLConnectionString);

        }
    }
}