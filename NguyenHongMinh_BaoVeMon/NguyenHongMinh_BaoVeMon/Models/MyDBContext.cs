using Microsoft.EntityFrameworkCore;

namespace NguyenHongMinh_BaoVeMon.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options ):base(options) { }

        public DbSet<CanHo> Canhos { get; set; }
        public DbSet<ToaNha> toanhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanHo>().HasData(
                new CanHo { ID = "CH01", Name  = "Nha1", DienTich = 290, So = "20" }
                );
        }
    }
}
