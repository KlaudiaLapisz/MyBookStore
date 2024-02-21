namespace MyBookStore.DTO.Borrows
{
    public class CreateBorrowDto
    {
        public Guid BookId { get; set; }
        public string BorrowBy { get; set; }
        public string Notes { get; set; }   
    }
}

