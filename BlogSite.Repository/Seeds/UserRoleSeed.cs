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
