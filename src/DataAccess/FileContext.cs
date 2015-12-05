using Microsoft.Data.Entity;
using DataAccess.Model;
using Microsoft.Extensions.Configuration;

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
            var builder = new ConfigurationBuilder()
           .AddJsonFile("config.json")
           .AddEnvironmentVariables();
            var configuration = builder.Build();

            var sqlConnectionString = configuration["ApplicationConfiguration:SQLConnectionString"];

            optionsBuilder.UseSqlServer(sqlConnectionString);
        }
    }
}