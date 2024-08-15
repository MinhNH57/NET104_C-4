using Microsoft.EntityFrameworkCore;

namespace LuyenTap2.Models
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien { ID = Guid.NewGuid(), HoTen = "Nguyen Hong Minh", ChuyenNghanh = "CNTT", Tuoi = 20 }
                );
        }
    }
}
