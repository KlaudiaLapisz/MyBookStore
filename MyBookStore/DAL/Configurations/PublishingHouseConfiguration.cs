using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Entities;

namespace MyBookStore.DAL.Configurations
{
    public class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Publisher).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Books).WithOne(x => x.PublishingHouse).HasForeignKey(x => x.PublishingHouseId);

            builder.ToTable("PublishingHouse");
        }
    }
}
