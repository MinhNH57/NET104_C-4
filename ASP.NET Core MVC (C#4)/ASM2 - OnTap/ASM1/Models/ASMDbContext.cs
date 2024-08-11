using Microsoft.EntityFrameworkCore;

namespace ASM1.Models
{
    public class ASMDbContext : DbContext
    {
        public ASMDbContext(DbContextOptions<ASMDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=ASM1;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>().HasData(

                new SinhVien { ID = Guid.NewGuid() , Name = "Nguyen Hong Minh" , Age = 20 , Major = "CNTT" , MaLop = "SD18401" }
                );
            modelBuilder.Entity<LopHoc>().HasData(
                new LopHoc { MaLop = "SD18401", TenLop = "PTPM98" }
                );
        }

    }
}
