using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Seeds
{
    internal class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin kullanıcıları için tanımlanmıştır.",
                IsActive = true,
                CreatedDate = DateTime.Now,
            }, new Role
            {
                Id = 2,
                Name = "BlogSiteUser",
                Description = "Blog Site kullanıcıları için tanımlanmıştır.",
                IsActive = true,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
