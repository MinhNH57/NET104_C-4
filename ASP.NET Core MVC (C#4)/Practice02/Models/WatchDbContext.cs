using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Practice02.Models
{
    public class WatchDbContext:DbContext
    {
        public WatchDbContext(DbContextOptions<WatchDbContext> options):base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=Watch01;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Watch> Watches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watch>().HasData(
                new Watch { ID = Guid.NewGuid(), Name = "Rolex 1912", Origin = "US", Price = 1788, year = 1910 , Img = "Minh.png"},
                new Watch { ID = Guid.NewGuid(), Name = "Rolex 1989", Origin = "UK", Price = 5000, year = 1970 , Img = "Minh.png" }
            );
        }
    }
}
