using Microsoft.EntityFrameworkCore;

namespace Practice04.Models
{
    public class BookDbContext : DbContext
    {

        //public BookDbContext (DbContextOptions<BookDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=Book1;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Book> books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { ID = Guid.NewGuid() , Title = "Nham mat cho mua ha" , soTrang = 187, ngayxuatban = DateTime.Parse("7/17/2024") }
                );
        }
    }
}
