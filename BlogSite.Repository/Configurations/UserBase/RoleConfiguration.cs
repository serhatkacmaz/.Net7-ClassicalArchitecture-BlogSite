using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations.UserBase
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            int order = -1;

            builder.Property(p => p.Id).HasColumnOrder(++order);
            builder.Property(p => p.Name).HasColumnOrder(++order);
            builder.Property(p => p.Description).HasColumnOrder(++order);
            builder.Property(p => p.IsActive).HasColumnOrder(++order);
            builder.Property(p => p.CreatedDate).HasColumnOrder(++order);
            builder.Property(p => p.UpdatedDate).HasColumnOrder(++order);
            builder.Property(p => p.User_ID).HasColumnOrder(++order);
        }
    }
}
