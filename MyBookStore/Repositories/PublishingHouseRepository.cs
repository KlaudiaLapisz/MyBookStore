using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public class PublishingHouseRepository : IPublishingHouseRepository
    {
        private readonly MyBookStoreDbContext _dbContext;

        public PublishingHouseRepository(MyBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PublishingHouse publishingHouse)
        {
            await _dbContext.AddAsync(publishingHouse);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(PublishingHouse publishingHouse)
        {
            _dbContext.Remove(publishingHouse);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PublishingHouse>> GetAllAsync()
        {
            return await _dbContext.PublishingHouses.Include(x => x.Books).ToListAsync();
        }

        public async Task<PublishingHouse> GetAsync(Guid id)
        {
            return await _dbContext.PublishingHouses.Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PublishingHouse publishingHouse)
        {
            _dbContext.Update(publishingHouse);
            await _dbContext.SaveChangesAsync();
        }
    }
}
