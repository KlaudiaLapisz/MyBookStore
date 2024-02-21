using MyBookStore.DTO.BookGenres;
using MyBookStore.Entities;
using MyBookStore.Repositories;

namespace MyBookStore.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public BookGenreService(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<Guid?> CreateAsync(CreateBookGenreDto createBookGenreDto)
        {
            var bookGenre = new BookGenre
            {
                Id = Guid.NewGuid(),
                GenreName = createBookGenreDto.GenreName
            };
            await _bookGenreRepository.AddAsync(bookGenre);
            return bookGenre.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBookGenreDto updateBookGenreDto)
        {
            var bookGenre = await _bookGenreRepository.GetAsync(updateBookGenreDto.Id);
            if (bookGenre == null)
            {
                return false;
            }

            bookGenre.GenreName = updateBookGenreDto.GenreName;
            await _bookGenreRepository.UpdateAsync(bookGenre);
            return true;
        }

        public async Task<bool> DeleteAsync(DeleteBookGenreDto deleteBookGenreDto)
        {
            var bookGenre = await _bookGenreRepository.GetAsync(deleteBookGenreDto.Id);
            if (bookGenre == null)
            {
                return false;
            }

            await _bookGenreRepository.DeleteAsync(bookGenre);
            return true;
        }

        public async Task<IEnumerable<BookGenreDto>> GetAllAsync()
        {
            var bookGenres = await _bookGenreRepository.GetAllAsync();
            return bookGenres.Select(x => new BookGenreDto
            {
                Id = x.Id,
                GenreName = x.GenreName,
                Books = x.Books.Select(b => new BookGenreBooksDto
                {
                    Title = b.Title
                })
            });
        }

        public async Task<BookGenreDto> GetAsync(Guid id)
        {
            var genre = await _bookGenreRepository.GetAsync(id);
            return new BookGenreDto
            {
                Id = genre.Id,
                GenreName = genre.GenreName,
                Books = genre.Books.Select(b => new BookGenreBooksDto
                {
                    Title = b.Title
                })
            };
        }
    }
}
