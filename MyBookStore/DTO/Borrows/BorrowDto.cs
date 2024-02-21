namespace MyBookStore.DTO.Borrows
{
    public class BorrowDto
    {
        public Guid Id { get; set; }      
        public string Notes { get; set; }
        public string BorrowBy { get; set; }
        public DateTime BorrowDate { get; set; }
        public BorrowBookDto Book { get; set; }

    }
}
