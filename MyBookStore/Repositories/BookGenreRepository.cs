using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly MyBookStoreDbContext _dbContext;

        public BookGenreRepository(MyBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BookGenre bookGenre)
        {
            await _dbContext.AddAsync(bookGenre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BookGenre bookGenre)
        {
            _dbContext.Remove(bookGenre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookGenre>> GetAllAsync()
        {
            return await _dbContext.BookGenres.Include(x=>x.Books).ToListAsync();
        }

        public async Task<BookGenre> GetAsync(Guid id)
        {
            return await _dbContext.BookGenres.Include(x=>x.Books).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(BookGenre bookGenre)
        {
            _dbContext.Update(bookGenre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
