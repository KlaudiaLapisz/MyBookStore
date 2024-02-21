using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MyBookStoreDbContext _dbContext;

        public BookRepository(MyBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
           return await _dbContext.Books
                .Include(x => x.Author)
                .Include(x => x.MainGenre)
                .Include(x => x.PublishingHouse).ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await _dbContext.Books
                .Include(x=>x.Author)
                .Include(x=>x.MainGenre)
                .Include(x=>x.PublishingHouse)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
