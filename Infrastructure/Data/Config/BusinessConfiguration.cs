using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.ContactPerson).IsRequired();
            builder.Property(p => p.ContactPerson).HasMaxLength(100);
            builder.HasOne(t => t.BusinessCategory).WithMany().HasForeignKey(p => p.BusinessCategoryId);

        }
    }
}