namespace MyBookStore.Entities
{
    public class PublishingHouse
    {
        public Guid Id { get; set; }
        public string Publisher { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
