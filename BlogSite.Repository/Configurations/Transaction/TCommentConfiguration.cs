using BlogSite.Core.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations.Transaction
{
    internal class TCommentConfiguration : IEntityTypeConfiguration<TComment>
    {
        public void Configure(EntityTypeBuilder<TComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Comment).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.Blog_ID)
                .OnDelete(DeleteBehavior.Restrict);

            int order = -1;

            builder.Property(p => p.Id).HasColumnOrder(++order);
            builder.Property(p => p.Blog_ID).HasColumnOrder(++order);
            builder.Property(p => p.ParentID).HasColumnOrder(++order);
            builder.Property(p => p.Name).HasColumnOrder(++order);
            builder.Property(p => p.Comment).HasColumnOrder(++order);
            builder.Property(p => p.IsActive).HasColumnOrder(++order);
            builder.Property(p => p.CreatedDate).HasColumnOrder(++order);
            builder.Property(p => p.UpdatedDate).HasColumnOrder(++order);
            builder.Property(p => p.User_ID).HasColumnOrder(++order);
        }
    }
}
