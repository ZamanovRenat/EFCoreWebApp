using EFCoreWebApp.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.ConsoleApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()        // подключение lazy loading
                .UseSqlite("Data Source=consoleapp.db");
        }
    }
}
