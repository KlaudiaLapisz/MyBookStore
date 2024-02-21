using MyBookStore.Entities;

namespace MyBookStore.Repositories
{
    public interface IBorrowRepository
    {
        Task<IEnumerable<Borrow>> GetAllAsync();
        Task <Borrow> GetAsync(Guid id);
        Task AddAsync (Borrow borrow);
        Task UpdateAsync (Borrow borrow);
        Task <IEnumerable<Borrow>> GetAllByBook(Guid bookId);
    }
}
