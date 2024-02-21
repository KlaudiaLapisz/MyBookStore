namespace MyBookStore.DTO.Authors
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<AuthorBookDto> Books { get; set; }
    }
}
