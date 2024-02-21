using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Entities;

namespace MyBookStore.DAL.Configurations
{
    public class BorrowCobfiguration : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BorrowBy).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Notes).HasMaxLength(150);

            builder.HasOne(x=>x.Book).WithMany(x=>x.Borrows).HasForeignKey(x=>x.BookId);
            builder.ToTable("Borrow");
        }
    }
}
