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
    internal class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "admin",
                Description = "admin rolu tanımlama.",
                IsActive = true,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
