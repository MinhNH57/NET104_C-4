using Microsoft.EntityFrameworkCore;

namespace SD18406.Models
{
    public class CategoryDbContext:DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) 
        { 
        }
         public DbSet<Catregory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=KiemTra;Trusted_Connection=True; TrustServerCertificate =True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catregory>().HasData(
                new Catregory { ID = Guid.NewGuid(),  Name = "Jeans", SoLuong = 145 , ImgURL = "Minh.png" },
                new Catregory { ID = Guid.NewGuid(), Name = "Cots", SoLuong = 12, ImgURL = "Minh.png" },
                new Catregory { ID = Guid.NewGuid(), Name = "Blouse", SoLuong = 145, ImgURL = "Minh.png" },
                new Catregory { ID = Guid.NewGuid(), Name = "Hat", SoLuong = 16, ImgURL = "Minh.png" });
        }
    }
}
