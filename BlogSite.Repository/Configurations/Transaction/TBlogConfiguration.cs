using BlogSite.Core.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Blogs)
               .HasForeignKey(x => x.Category_ID)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
