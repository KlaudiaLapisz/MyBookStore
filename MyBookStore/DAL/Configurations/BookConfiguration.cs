using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Entities;

namespace MyBookStore.DAL.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PublicationDate).IsRequired();

            builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            builder.HasOne(x => x.PublishingHouse).WithMany(x => x.Books).HasForeignKey(x => x.PublishingHouseId);
            builder.HasOne(x => x.MainGenre).WithMany(x => x.Books).HasForeignKey(x => x.MainGenreId);

            builder.ToTable("Book");
        }
    }
}
