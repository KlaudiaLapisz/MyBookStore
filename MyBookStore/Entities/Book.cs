namespace MyBookStore.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public int PublicationDate { get; set; }
        public Guid MainGenreId { get; set; }
        public Guid PublishingHouseId { get; set; }

        public Author Author { get; set; }
        public BookGenre MainGenre { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
