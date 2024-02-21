using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetAsync(Guid id);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task AddAsync(Book book);
    }
}
