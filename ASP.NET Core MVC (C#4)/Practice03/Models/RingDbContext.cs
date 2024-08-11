using Microsoft.EntityFrameworkCore;

namespace Practice03.Models
{
    public class RingDbContext : DbContext
    {
        public RingDbContext(DbContextOptions<RingDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=Ring;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Ring> Rings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ring>().HasData(
                    new Ring { ID = Guid.NewGuid(), Name = "Ring Gold", Origin = "VietNam", Image = "Minh" },
                    new Ring { ID = Guid.NewGuid(), Name = "Ring Clonium", Origin = "VietNam", Image = "Minh" }
                ) ;
        }
    }
}
