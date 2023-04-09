using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Seeds
{
    internal class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(new UserRole
            {
                Id = 1,
                User_ID = 1,
                Role_ID = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
