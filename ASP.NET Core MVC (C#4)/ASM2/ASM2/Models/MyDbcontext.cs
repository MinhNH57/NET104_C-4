using Microsoft.EntityFrameworkCore;

namespace ASM2.Models
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options)
        {

        }

        public DbSet<KhachHang> khachHangs { get; set; }    
        public DbSet<DonHang> donHangs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang { Id = Guid.NewGuid(), HoTen = "Nguyen Hong Minh", DiaChi = "Vinh Loc - Phung Xa", Tuoi = 20 }
                );
            modelBuilder.Entity<DonHang>().HasData(
                new DonHang { MaDonHang = "DH01", TenDonHang = "Sach", NgayDat = DateTime.Parse("8/1/2024") }
            );
        }
    }
}
