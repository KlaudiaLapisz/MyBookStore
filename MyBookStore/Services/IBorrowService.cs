using MyBookStore.DTO.Borrows;

namespace MyBookStore.Services
{
    public interface IBorrowService
    {
        Task<bool> CreateAsync(CreateBorrowDto createBorrowDto);
        Task<IEnumerable<BorrowDto>> GetAllAsync();
        Task <bool> UpdateAsync (UpdateBorrowDto updateBorrowDto);
    }
}
