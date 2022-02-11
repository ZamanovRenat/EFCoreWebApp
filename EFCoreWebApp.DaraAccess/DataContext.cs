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
            
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(p => p.Company)
            //    .WithMany(t => t.Users)
            //    .HasForeignKey(p => p.CompanyId)
            //    .HasPrincipalKey(t => t.Name);
        }
    }
}
