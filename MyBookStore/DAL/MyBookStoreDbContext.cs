using Microsoft.EntityFrameworkCore;
using MyBookStore.Entities;

namespace MyBookStore.DAL
{
    public class MyBookStoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet <PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        public MyBookStoreDbContext(DbContextOptions<MyBookStoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
