namespace MyBookStore.DTO.Books
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublicationDate { get; set; }
        public BookAuthorDto Author { get; set; }
        public BookGenreDto GenreName { get; set; }
        public BookPublishingHouseDto PublishingHouse { get; set; }
    }
}
