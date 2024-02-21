namespace MyBookStore.DTO.PublishingHouses
{
    public class PublishingHouseDto
    {
        public Guid Id { get; set; }
        public string Publisher { get; set; }

        public IEnumerable<PublishingHouseBooksDto> Books { get; set; }
    }
}
