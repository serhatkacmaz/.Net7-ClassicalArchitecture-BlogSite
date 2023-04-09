using BlogSite.Core.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations.Transaction
{
    internal class TBlogConfiguration : IEntityTypeConfiguration<TBlog>
    {
        public void Configure(EntityTypeBuilder<TBlog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(150);

            builder.ToTable(options =>
            {
                options.IsTemporal();
            });

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Blogs)
               .HasForeignKey(x => x.Category_ID)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            int order = -1;

            builder.Property(p => p.Id).HasColumnOrder(++order);
            builder.Property(p => p.Category_ID).HasColumnOrder(++order);
            builder.Property(p => p.Name).HasColumnOrder(++order);
            builder.Property(p => p.Content).HasColumnOrder(++order);
            builder.Property(p => p.Description).HasColumnOrder(++order);
            builder.Property(p => p.ViewNumber).HasColumnOrder(++order);
            builder.Property(p => p.IsActive).HasColumnOrder(++order);
            builder.Property(p => p.CreatedDate).HasColumnOrder(++order);
            builder.Property(p => p.UpdatedDate).HasColumnOrder(++order);
            builder.Property(p => p.User_ID).HasColumnOrder(++order);
        }
    }
}
