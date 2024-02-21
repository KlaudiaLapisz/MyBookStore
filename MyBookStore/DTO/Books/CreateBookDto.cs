namespace MyBookStore.DTO.Books
{
    public class CreateBookDto
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public int PublicationDate { get; set; }
        public Guid MainGenreId { get; set; }
        public Guid PublishingHouseId { get; set; }

    }
}
