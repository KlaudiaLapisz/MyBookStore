using MyBookStore.DTO.Books;

namespace MyBookStore.Services
{
    public interface IBookService
    {
        Task<Guid?> CreateAsync(CreateBookDto createBookDto);
        Task<bool> DeleteAsync(DeleteBookDto deleteBookDto);
        Task<bool> UpdateAsync(UpdateBookDto updateBookDto);
        Task <IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetAsync(Guid id);
    }
}
