using Microsoft.EntityFrameworkCore;

namespace DeThiThuLan1.Models
{
    public class DonHangDbContext : DbContext
    {

        public DonHangDbContext(DbContextOptions<DonHangDbContext> options ) : base( options )  
        {

        }

        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang { ID = Guid.NewGuid(), Name = "Nguyen Hong Minh", DiaChi = "Vinh Loc", Tuoi = 20 }
                );
            modelBuilder.Entity<DonHang>().HasData(
                new DonHang { MaDonHang="DH01" , TenDonHang = "Giay" , NgayDat = DateTime.Parse("8/13/2024") }
                );
        }
    }
}
