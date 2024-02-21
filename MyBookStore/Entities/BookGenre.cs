namespace MyBookStore.Entities
{
    public class BookGenre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }

        public ICollection <Book> Books { get; set; }
    }
}
