using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetAsync(Guid id);
        Task AddAsync(Author author);
        Task DeleteAsync(Author author);
        Task UpdateAsync(Author author);
    }
}
