using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasForeignKey(x => x.User_ID);
        }
    }
}
