﻿namespace MyBookStore.Entities
{
    public class Borrow
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string BorrowBy { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Notes { get; set; }

        public Book Book { get; set; }
    }
}
