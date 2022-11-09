using Microsoft.EntityFrameworkCore;

namespace siwon.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public string DbPath { get; set; }

        public AppDbContext()
        {           
            DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "siwon.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "W pustyni i w puszczy", Author = "Henryk Sienkiewicz", CreateDate = DateTime.Now },
                new Book() { Id = 2, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", CreateDate = DateTime.Now },
                new Book() { Id = 3, Title = "Dziady", Author = "Adam Mickiewicz", CreateDate = DateTime.Now },
                new Book() { Id = 4, Title = "Lalka", Author = "Bolesław Prus", CreateDate = DateTime.Now }
                );
        }
    }
}
