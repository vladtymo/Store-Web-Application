using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Model)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.ImageUrl)
                .IsRequired(false);

            builder
                .HasOne(x => x.Color)
                .WithMany(x => x.Phones)
                .HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
