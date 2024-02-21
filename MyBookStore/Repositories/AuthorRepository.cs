using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyBookStoreDbContext _dbContext;

        public AuthorRepository(MyBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Author author)
        {
            await _dbContext.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _dbContext.Remove(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.Include(x=>x.Books).ToListAsync();
        }

        public async Task<Author> GetAsync(Guid id)
        {
            return await _dbContext.Authors.Include(x=>x.Books).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Author author)
        {
            _dbContext.Update(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
