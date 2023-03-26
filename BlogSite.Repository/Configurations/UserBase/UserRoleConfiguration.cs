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
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.Role_ID)
                .OnDelete(DeleteBehavior.Restrict);

            int order = -1;

            builder.Property(p => p.Id).HasColumnOrder(++order);
            builder.Property(p => p.Role_ID).HasColumnOrder(++order);
            builder.Property(p => p.User_ID).HasColumnOrder(++order);
            builder.Property(p => p.IsActive).HasColumnOrder(++order);
            builder.Property(p => p.CreatedDate).HasColumnOrder(++order);
            builder.Property(p => p.UpdatedDate).HasColumnOrder(++order);
        }
    }
}
