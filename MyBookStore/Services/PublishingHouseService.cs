using MyBookStore.DTO.PublishingHouses;
using MyBookStore.Entities;
using MyBookStore.Repositories;

namespace MyBookStore.Services
{
    public class PublishingHouseService : IPublishingHouseService
    {
        private readonly IPublishingHouseRepository _publishingHouseRepository;

        public PublishingHouseService(IPublishingHouseRepository publishingHouseRepository)
        {
            _publishingHouseRepository = publishingHouseRepository;
        }

        public async Task<Guid?> CreateAsync(CreatePublishingHouseDto createPublishingHouseDto)
        {
            var publishingHouse = new PublishingHouse
            {
                Id = Guid.NewGuid(),
                Publisher = createPublishingHouseDto.Publisher
            };

            await _publishingHouseRepository.AddAsync(publishingHouse);
            return publishingHouse.Id;
        }

        public async Task<bool> DeleteAsync(DeletePublishingHouseDto deletePublishingHouseDto)
        {
            var publishingHouse = await _publishingHouseRepository.GetAsync(deletePublishingHouseDto.Id);
            if (publishingHouse == null)
            {
                return false;
            }

            await _publishingHouseRepository.DeleteAsync(publishingHouse);
            return true;
        }

        public async Task<IEnumerable<PublishingHouseDto>> GetAllAsync()
        {
            var publishingHouse = await _publishingHouseRepository.GetAllAsync();
            return publishingHouse.Select(x => new PublishingHouseDto
            {
                Id = x.Id,
                Publisher = x.Publisher,
                Books = x.Books.Select(x => new PublishingHouseBooksDto
                {
                    Title = x.Title
                })
            });
        }

        public async Task<PublishingHouseDto> GetAsync(Guid id)
        {
            var publishingHouse = await _publishingHouseRepository.GetAsync(id);
            return new PublishingHouseDto
            {
                Id = publishingHouse.Id,
                Publisher = publishingHouse.Publisher,
                Books = publishingHouse.Books.Select(x => new PublishingHouseBooksDto
                { 
                    Title = x.Title 
                })
            };
        }

        public async Task<bool> UpdateAsync(UpdatePublishingHouseDto updatePublishingHouseDto)
        {
            var publishingHouse = await _publishingHouseRepository.GetAsync(updatePublishingHouseDto.Id);

            if (publishingHouse == null)
            {
                return false;
            }

            publishingHouse.Publisher = updatePublishingHouseDto.Publisher;
            await _publishingHouseRepository.UpdateAsync(publishingHouse);
            return true;
        }
    }
}
