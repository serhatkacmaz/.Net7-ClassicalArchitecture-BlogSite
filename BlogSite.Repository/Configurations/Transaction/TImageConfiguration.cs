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
    internal class TImageConfiguration : IEntityTypeConfiguration<TImage>
    {
        public void Configure(EntityTypeBuilder<TImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.Blog_ID);
        }
    }
}
