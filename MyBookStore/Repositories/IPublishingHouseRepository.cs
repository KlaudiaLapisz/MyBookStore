using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public interface IPublishingHouseRepository
    {
        Task<IEnumerable<PublishingHouse>> GetAllAsync();
        Task<PublishingHouse> GetAsync(Guid id);
        Task AddAsync(PublishingHouse publishingHouse);
        Task UpdateAsync(PublishingHouse publishingHouse);
        Task DeleteAsync(PublishingHouse publishingHouse);
    }
}
