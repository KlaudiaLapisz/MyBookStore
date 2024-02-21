using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public interface IBookGenreRepository
    {
        Task<IEnumerable<BookGenre>> GetAllAsync();
        Task<BookGenre> GetAsync(Guid id);
        Task AddAsync(BookGenre bookGenre);
        Task UpdateAsync(BookGenre bookGenre);
        Task DeleteAsync(BookGenre bookGenre);
    }
}
