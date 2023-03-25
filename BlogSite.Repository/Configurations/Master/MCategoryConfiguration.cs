using BlogSite.Core.Entities.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Configurations.Master
{
    internal class MCategoryConfiguration : IEntityTypeConfiguration<MCategory>
    {
        public void Configure(EntityTypeBuilder<MCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsUnicode().IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
