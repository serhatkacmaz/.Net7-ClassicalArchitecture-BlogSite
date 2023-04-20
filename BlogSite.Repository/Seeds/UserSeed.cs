using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                Name = "admin",
                Mail = "admin@gmail.com",
                UserName = "Admin User",
                Password = "1234",
                Title = "Manager",
                IsActive = true,
                CreatedDate = DateTime.Now
            }, new User
            {
                Id = 2,
                Name = "skacmaz",
                Mail = "skacmaz@gmail.com",
                UserName = "Serhat Kaçmaz",
                Password = "1234",
                Title = "Software Developer",
                IsActive = true,
                CreatedDate = DateTime.Now
            });
        }
    }
}
