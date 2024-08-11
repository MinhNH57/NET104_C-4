using Microsoft.EntityFrameworkCore;

namespace Practice_01.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=KiemTra;Trusted_Connection=True; TrustServerCertificate =True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ID = Guid.NewGuid(), Name = "Iphone 14 Plus America", SoLuong = 147, ImgUrl = "Minh.png" }
            );
        }
    }
}
