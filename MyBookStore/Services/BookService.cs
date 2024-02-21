using MyBookStore.DTO.Books;
using MyBookStore.Entities;
using MyBookStore.Repositories;

namespace MyBookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid?> CreateAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                AuthorId = createBookDto.AuthorId,
                MainGenreId = createBookDto.MainGenreId,
                PublicationDate = createBookDto.PublicationDate,
                PublishingHouseId = createBookDto.PublishingHouseId,
                Title = createBookDto.Title

            };

            await _bookRepository.AddAsync(book);
            return createBookDto.Id;
        }

        public async Task<bool> DeleteAsync(DeleteBookDto deleteBookDto)
        {
            var deleteBook = await _bookRepository.GetAsync(deleteBookDto.Id);
            if (deleteBook == null)
            {
                return false;
            }

            await _bookRepository.DeleteAsync(deleteBook);
            return true;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublicationDate = b.PublicationDate,
                Author = new BookAuthorDto
                {
                    FirstName = b.Author.FirstName,
                    LastName = b.Author.LastName,
                },
                GenreName = new BookGenreDto
                {
                    GenreName = b.MainGenre.GenreName,

                },
                PublishingHouse = new BookPublishingHouseDto
                {
                    Publisher = b.PublishingHouse.Publisher
                }

            });
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                PublicationDate = book.PublicationDate,
                Author = new BookAuthorDto
                {
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName
                },
                GenreName = new BookGenreDto
                {
                    GenreName = book.MainGenre.GenreName
                },
                PublishingHouse = new BookPublishingHouseDto
                {
                    Publisher = book.PublishingHouse.Publisher
                }

            };
        }

        public async Task<bool> UpdateAsync(UpdateBookDto updateBookDto)
        {
            var book = await _bookRepository.GetAsync(updateBookDto.Id);
            if (book == null)
            {
                return false;
            }

            book.AuthorId = updateBookDto.AuthorId;
            book.MainGenreId = updateBookDto.MainGenreId;
            book.PublicationDate = updateBookDto.PublicationDate;
            book.PublishingHouseId = updateBookDto.PublishingHouseId;
            book.Title = updateBookDto.Title;
            
            await _bookRepository.UpdateAsync(book);
            return true;
        }
    }
}
