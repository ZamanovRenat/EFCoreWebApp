using EFCoreWebApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.DaraAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DataContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
