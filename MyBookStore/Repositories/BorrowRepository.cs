using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly MyBookStoreDbContext _dbContext;

        public BorrowRepository(MyBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Borrow borrow)
        {
            await _dbContext.AddAsync(borrow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllAsync()
        {
            return await _dbContext.Borrows
                .Include(x => x.Book)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllByBook(Guid bookId)
        {
            return await _dbContext.Borrows
                 .Where(x => x.BookId == bookId)
                 .ToListAsync();
        }

        public async Task<Borrow> GetAsync(Guid id)
        {
            return await _dbContext.Borrows
                .Include(x => x.Book)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Borrow borrow)
        {
            _dbContext.Update(borrow);
            await _dbContext.SaveChangesAsync();
        }
    }
}
