using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Entities;

namespace MyBookStore.DAL.Configurations
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GenreName).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Books).WithOne(x => x.MainGenre).HasForeignKey(x => x.MainGenreId);

            builder.ToTable("BookGenre");
        }
    }
}
