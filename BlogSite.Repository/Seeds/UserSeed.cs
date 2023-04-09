using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = 1,
                Name = "admin",
                Mail = "admin@gmail.com",
                UserName = "admin Name",
                Password = "1234",
                Title = "Manager",
                IsActive = true,
                CreatedDate = DateTime.Now
            });
        }
    }
}
