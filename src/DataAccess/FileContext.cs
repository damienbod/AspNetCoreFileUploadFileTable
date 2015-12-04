using Microsoft.Data.Entity;
using DataAccess.Model;

namespace DataAccess
{
    public class FileContext : DbContext
    {
        public DbSet<FileDescription> FileDescriptions { get; set; }
    }
}