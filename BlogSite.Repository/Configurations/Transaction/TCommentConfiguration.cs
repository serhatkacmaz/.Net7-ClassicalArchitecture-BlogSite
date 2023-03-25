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
        }
    }
}
