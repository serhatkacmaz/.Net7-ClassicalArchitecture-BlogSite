using BlogSite.Core.Entities.UserBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserName = "admin Name",
                Title = "Manager",
                IsActive = true,
                CreatedDate = DateTime.Now
            });
        }
    }
}
