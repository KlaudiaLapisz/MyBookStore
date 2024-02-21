using MyBookStore.DTO.BookGenres;

namespace MyBookStore.Services
{
    public interface IBookGenreService
    {
        Task<Guid?> CreateAsync(CreateBookGenreDto createBookGenreDto);
        Task<bool> UpdateAsync(UpdateBookGenreDto updateBookGenreDto);
        Task<bool> DeleteAsync(DeleteBookGenreDto deleteBookGenreDto);
        Task<IEnumerable<BookGenreDto>> GetAllAsync();
        Task<BookGenreDto> GetAsync(Guid id);
    }
}
