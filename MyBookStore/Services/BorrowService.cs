using MyBookStore.DTO.Borrows;
using MyBookStore.Entities;
using MyBookStore.Repositories;

namespace MyBookStore.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> CreateAsync(CreateBorrowDto createBorrowDto)
        {
            var book = await _bookRepository.GetAsync(createBorrowDto.BookId);
            if (book == null)
            {
                return false;
            }

            var borrows = await _borrowRepository.GetAllByBook(createBorrowDto.BookId);
            var isBorrowed = borrows.Any(x => x.ReturnDate == null);
            if (isBorrowed)
            {
                return false;
            }

            var borrow = new Borrow
            {
                Id = Guid.NewGuid(),
                BookId = createBorrowDto.BookId,
                BorrowBy = createBorrowDto.BorrowBy,
                BorrowDate = DateTime.Now,
                ReturnDate = null,
                Notes = createBorrowDto.Notes
            };

            await _borrowRepository.AddAsync(borrow);
            return true;
        }

        public async Task<IEnumerable<BorrowDto>> GetAllAsync()
        {
            var books = await _borrowRepository.GetAllAsync();
            var borrows = books.Where(x => x.ReturnDate == null);
            return borrows.Select(x => new BorrowDto
            {
                Id = x.Id,
                BorrowBy = x.BorrowBy,
                BorrowDate = x.BorrowDate,
                Notes = x.Notes,
                Book = new BorrowBookDto
                {
                    Title = x.Book.Title
                }
            });
        }

        public async Task<bool> UpdateAsync(UpdateBorrowDto updateBorrowDto)
        {
            var book = await _bookRepository.GetAsync(updateBorrowDto.BookId);
            if (book == null)
            {
                return false;
            }

            var borrows = await _borrowRepository.GetAllByBook(updateBorrowDto.BookId);
            var bookToReturn = borrows.SingleOrDefault(x => x.ReturnDate == null);
            if (bookToReturn == null)
            {
                return false;
            }

            bookToReturn.ReturnDate = DateTime.Now;
            await _borrowRepository.UpdateAsync(bookToReturn);
            return true;
        }
    }
}
