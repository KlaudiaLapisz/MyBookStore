using MyBookStore.DTO.Authors;

namespace MyBookStore.DTO.BookGenres
{
    public class BookGenreDto
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }

        public IEnumerable<BookGenreBooksDto> Books { get; set; }
        
    }
}
