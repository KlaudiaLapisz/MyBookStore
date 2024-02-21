using MyBookStore.DTO.Authors;

namespace MyBookStore.Services
{
    public interface IAuthorService
    {
        Task<Guid?> CreateAsync(CreateAuthorDto createAuthorDto);
        Task<bool> UpdateAsync(UpdateAuthorDto updateAuthorDto);
        Task<bool> DeleteAsync(DeleteAuthorDto deleteAuthorDto);
        Task <IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetAsync(Guid id);
    }
}
