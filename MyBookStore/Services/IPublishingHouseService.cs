using MyBookStore.DTO.PublishingHouses;

namespace MyBookStore.Services
{
    public interface IPublishingHouseService
    {
        Task<Guid?> CreateAsync(CreatePublishingHouseDto createPublishingHouseDto);
        Task<bool> UpdateAsync(UpdatePublishingHouseDto updatePublishingHouseDto);
        Task<bool> DeleteAsync(DeletePublishingHouseDto deletePublishingHouseDto);
        Task<IEnumerable<PublishingHouseDto>> GetAllAsync();
        Task<PublishingHouseDto> GetAsync(Guid id);
    }
}
