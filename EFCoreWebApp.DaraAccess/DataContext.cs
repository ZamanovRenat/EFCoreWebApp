using EFCoreWebApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.DaraAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
